<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

if( $_GET['id'] != '' && (int)$_GET['id'] == -1 ){

	$t->assign( 'err', 28 );

	if ( $config['use_profilepopups'] == 'Y' ) {
		$t->display( 'admin/nickpage.tpl' );
	}
	else {
		$t->assign('rendered_page', $t->fetch('admin/nickpage.tpl') );
		$t->display ( 'admin/index.tpl' );
	}

	exit;

} elseif( $_GET['id'] != '' && (int)$_GET['id'] != 0 ){

	$sql = 'SELECT id, username , country , firstname , lastname, gender , lookgender, state_province , lastvisit,
		picture , city , floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12)  as age
		FROM ! WHERE id = ? AND status <> ?';

	$user=$db->getRow( $sql ,array( USER_TABLE, $_GET['id'], $lang['status_enum']['suspended'] ));

	/* Get countryname and statename */
	$countryname = $db->getOne('select name from ! where code = ?', array(COUNTRIES_TABLE, $user['country'] ) );
	
	$statename = $db->getOne('select name from ! where code = ? and countrycode = ?', array(STATES_TABLE, $user['state_province'], $user['country'] ) );
	
	$user['countryname'] = $countryname;

	$user['statename'] = ($statename != '') ? $statename : $user['state_province'];
	
	$user['m_status'] = checkOnlineStats( $user['id']  );
	
	$sqlSections = 'SELECT * FROM ! WHERE enabled = ? ORDER BY displayorder';

	$dataSections = $db->getAll( $sqlSections, array( SECTIONS_TABLE, 'Y'  ) );

	$found = false;

	foreach( $dataSections as $section ){

		$prefs = array();

		$sqlpref = 'SELECT DISTINCT q.id, q.question, q.extsearchhead,
			q.control_type as type FROM ! pref INNER JOIN ! q ON pref.questionid = q.id WHERE pref.userid = ? AND q.section = ? ORDER BY q.id ';

		$rsPref = $db->getAll( $sqlpref,array( USER_PREFERENCE_TABLE, QUESTIONS_TABLE, $_GET['id'], $section['id'] ) );

		foreach( $rsPref as $row ){

/*			$sqlopt = 'SELECT pref.answer as answer, opt.answer as anstxt FROM ! pref INNER JOIN ! q ON pref.questionid = q.id LEFT JOIN ! opt ON pref.answer = opt.id WHERE pref.userid = ?  AND q.section = ? and q.id= ? and q.question  = ? and q.extsearchhead = ? and q.control_type = ? ORDER BY q.id ';
$rsOptions = $db->getAll( $sqlopt, array( USER_PREFERENCE_TABLE, QUESTIONS_TABLE, OPTIONS_TABLE, $_GET['id'], $section['id'], $row['id'], str_replace("'","\'",$row['question']), $row['extsearchhead'],  $row['type'] ) );
*/
			if ($row['type'] != 'textarea') {

				$sqlopt = 'SELECT pref.answer as answer, opt.answer as anstxt from ! pref left join ! opt on pref.questionid = opt.questionid and opt.id = pref.answer where pref.userid = ? and opt.questionid = ? ';

				$rsOptions = $db->getAll( $sqlopt, array( USER_PREFERENCE_TABLE, OPTIONS_TABLE, $_GET['id'], $row['id'] ) );

			} else {
			
				$sqlopt = 'select pref.answer as answer, pref.answer as anstxt from ! pref where pref.userid = ? and pref.questionid = ?';

				$rsOptions = $db->getAll( $sqlopt, array( USER_PREFERENCE_TABLE, $_GET['id'], $row['id'] ) );
			}

			$opts = array();

			foreach( $rsOptions as $key=>$opt ){
				$opts[] = $opt['anstxt'];
			}
			
			if (count($opts)>0) {
				$optsPhr = implode( ', ', $opts);
			} else {
				$optsPhr = "";
			}

			$row['options'] = $optsPhr;

			$prefs[] = $row;

			$found = true;
		}
		
		if( count($prefs) > 0 ){

			$pref[] = array( 'SectionName' => $section['section'], 'preferences' => $prefs );
		}
	}


	/* Get snaps count */
	$snaps_cnt = $db->getOne('select count(*) from ! where userid = ?', array( USER_SNAP_TABLE, $_GET['id'] ) );
	
	$t->assign('snaps_cnt', $snaps_cnt);
	
	hasRight('');

	$t->assign( 'user', $user );

	$arr = array();

	for( $i=-5; $i<=5; $i++ ) {
		$arr[$i] = $i;
	}

	$t->assign ( 'rate_values', $arr );

	//Calculate Profile Rating
	$sqlrate = 'SELECT count(rating) as tv , sum(rating) as sm FROM ! WHERE profileid = ?';

	$rowrate = $db->getRow($sqlrate, array( USER_RATING_TABLE, $_GET['id'] ) );

	$tv = $rowrate['tv'];

	$sm = $rowrate['sm'];

	if ( $tv == 0 ) {

		$is_rated = 0;

		$t->assign( 'is_rated', $is_rated );

	} else {

		$tv = ($tv == 0) ? 1 : $tv;

		$rating = round( $sm / $tv );


		if ( $rating < 0 ) {

			$color = '#FF0000';

			$arr = array();

			for( $i=-1,$j=1; $i>=$rating; $i--, $j++ ) {	$arr[$j] = $i; }

			$t->assign ( 'rating_values', $arr );

			$diff = 5 + $rating;

			for( $i=0; $i<=$diff;  $i++ ) {	$arr[$i] = $i; }

			$t->assign ( 'diff_values', $arr );

		} elseif ( $rating == 0 ) {

			$color = '#0000FF';

			$arr = array();

			for( $i=0; $i<=$rating; $i++ ) {	$arr[$i] = $i; }

			$t->assign ( 'rating_values', $arr );

		} elseif ( $rating > 0 ) {

			$color = '#00FF00';

			$arr = array();

			for( $i=1; $i<=5; $i++ ) {	$arr[$i] = $i; }

			$t->assign ( 'rating_values', $arr );

		}

		$is_rated = 1;

		$t->assign( 'total_votes', $tv );

		$t->assign( 'rating', $rating );

		$t->assign( 'is_rated', $is_rated );

		$t->assign( 'color', $color );
	}

	//Check user has already rated
	if ( $_SESSION['UserId'] ) {

		$sqlcrate = 'SELECT count(*) as c  FROM !  WHERE userid = ? AND profileid = ?';

		$rowcrate = $db->getRow(  $sqlcrate, array( USER_RATING_TABLE, $_SESSION['UserId'], $_GET['id'] ));

		$c = $rowcrate['c'];

		if ( $c == 0 ) {
			$t->assign( 'has_rated', '0' );
		}else {
			$t->assign( 'has_rated', '1' );
		}
	}

	if( $found ){

		$t->assign ( 'found', 1);

		$t->assign( 'pref', $pref);

	}

	/* Now add this view to profile_views table, if no user logged, make it -1  */

	$sql = 'insert into ! (userid, ref_userid, act_time, act) values (?, ?, ?, ?)';

	$byuser = ($_SESSION['UserId']>0)?$_SESSION['UserId']:-1;

	if ($_GET['id'] != $_SESSION['UserId']) {

		$db->query($sql, array( VIEWS_WINKS_TABLE, $_GET['id'], $byuser, time(), 'V' ) );

	}
	
	$t->assign('title',$user['username'].' '.$lang['profile_s'] );

	$t->assign('errid', $_GET['errid']);

	if ( $config['use_profilepopups'] == 'Y' ) {
		$t->display( 'admin/nickpage.tpl' );
	}
	else {
		$t->assign('rendered_page', $t->fetch('admin/nickpage.tpl') );
		$t->display ( 'admin/index.tpl' );
	}


}
?>