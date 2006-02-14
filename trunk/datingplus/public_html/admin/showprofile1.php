<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}	

include ( 'sessioninc.php' );

include('../state_codes.php');

$t->assign('lang', $lang);

define( 'PAGE_ID', 'profile_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

	
if( $_GET['id'] != '' && (int)$_GET['id'] == -1 ){
	
	$t->assign( 'err', 28 );
	
	$t->display( 'admin/profileview.tpl' );				
	
	exit;
	
} elseif( $_GET['id'] != '' && (int)$_GET['id'] != 0 ){

	$sql = 'SELECT id, username , country , firstname , lastname, gender , state_province , lastvisit,
		picture , city , floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12) as age
		FROM !  WHERE id =? AND status <>? ';
		
	$rs=$db->query( $sql, array(USER_TABLE , $_GET['id'], $lang['status_enum']['suspended']) );
	
	if( $rs->numRows() > 0 ){
	
		$user=$rs->fetchRow();
		
		$user['m_status'] = checkOnlineStats( $user['id']  );
		
		$sqlSections = 'SELECT * FROM ! WHERE enabled=? ORDER BY displayorder';
		
		$dataSections = $db->getAll( $sqlSections, array(SECTIONS_TABLE, 'Y') );
		
		$found = false;
		
		foreach( $dataSections as $section ){
			
			$sqlpref = 'SELECT DISTINCT q.id, q.question, q.extsearchhead, 
				q.control_type as type FROM ! pref INNER JOIN ! q ON pref.questionid = q.id WHERE pref.userid = ? AND q.section = ? ORDER BY q.id ';
				
			$rsPref = $db->getAll( $sqlpref, array( USER_PREFERENCE_TABLE,  QUESTIONS_TABLE, $_GET['id'], $section['id']) );

			$prefs = array();
			
			if( count($rsPref) > 0 ){
			
				foreach ( $rsPref as $row ){
					
					if ($row['type'] != 'textarea') {

						$sqlopt = 'SELECT pref.answer as answer, opt.answer as anstxt from ! pref left join ! opt on pref.questionid = opt.questionid and opt.id = pref.answer where pref.userid = ? and opt.questionid = ? ';

						$rsOptions = $db->getAll( $sqlopt, array( USER_PREFERENCE_TABLE, OPTIONS_TABLE, $_GET['id'], $row['id'] ) );

					} else {

						$sqlopt = 'select pref.answer as answer, pref.answer as anstxt from ! pref where pref.userid = ? and pref.questionid = ?';

						$rsOptions = $db->getAll( $sqlopt, array( USER_PREFERENCE_TABLE, $_GET['id'], $row['id'] ) );
					}

					$opts = array();	
					
					foreach( $rsOptions as $row ){						
						$opts[] = $opt;
					}
					
					$row['options'] = $opts;
					
					$prefs[] = $row;
					
					$found = true;
				}
			}
			if( count($prefs) > 0 ){
			
				$pref[] = array( 'SectionName' => $section['section'], 'preferences' => $prefs );
			}
		}
	}
	
	hasRight('');			

	$t->assign( 'user', $user );
	
	$arr = array();
	
	for( $i=-5; $i<=5; $i++ ) {	$arr[$i] = $i; }
	
	$t->assign ( 'rate_values', $arr );					
		
	//Calculate Profile Rating
	$sqlrate = 'SELECT count(rating) as tv , sum(rating) as sm FROM ! WHERE profileid = ?';
	
	$rowrate = $db->getRow(  $sqlrate, array( USER_RATING_TABLE, $_GET['id'] ) );
	
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
			
			for( $i=-1,$j=1; $i>=$rating; $i--, $j++ ) {	
				$arr[$j] = $i; 
			}
			
			$t->assign ( 'rating_values', $arr );					
			
			$diff = 5 + $rating;						
			
			for( $i=0; $i<=$diff;  $i++ ) {	$arr[$i] = $i; }
			
			$t->assign ( 'diff_values', $arr );					
			
		} elseif ( $rating == 0 ) {
		
			$color = '#0000FF';
			
			$arr = array();
			
			for( $i=0; $i<=$rating; $i++ ) {	
				$arr[$i] = $i; 
			}
			
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
	
		$sqlcrate = 'SELECT count(*) as c  FROM ! WHERE userid = ? AND profileid = ?';
		
		$c = $db->getOne(  $sqlcrate, array( USER_RATING_TABLE,  $_SESSION['UserId'], $_GET['id']) );
					
		if ( $c == 0 ) {
			
			$t->assign( 'has_rated', '0' );					
			
		} else {
			
			$t->assign( 'has_rated', '1' );
			
		}
	}
	
	if ( $found ){
	
		$t->assign ( 'found', 1);
	
		$t->assign( 'pref', $pref);		
	
	}

	$t->display( 'admin/profileview.tpl' );							

	exit;	
}
?>