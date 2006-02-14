<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

if ($_SESSION['AdminId'] > 0) {

	header('location: admin/index.php');
	exit;
}

if ($_SESSION['UserId'] <= 0 && $_GET['page'] == 'login' &&  isset($_COOKIE['osdate_info']) ) {

	$cookie = $_COOKIE['osdate_info'];

	$_SESSION['txtusername'] = $cookie['username'];

	$_SESSION['txtpassword'] = $cookie['dir'] ;

	$_SESSION['rememberme'] = true;

	list($_SESSION['lookagestart'], $_SESSION['lookageend'])= split(':',$cookie['search_ages']);

	if ($cookie['username'] != "") {

		if ( !$_GET['errid'] ) {
			header("location: midlogin.php");
			exit;
		}
	}
}

if ( isset( $_GET['affid'] ) ) {

	$_SESSION['ReferalId'] = $_GET['affid'];

	if ( getenv( 'HTTP_CLIENT_IP' ) ){
		$userip = getenv( 'HTTP_CLIENT_IP' );
	}
	else if ( getenv( 'HTTP_X_FORWARDED_FOR' ) )	{
		$userip = getenv( 'HTTP_X_FORWARDED_FOR' );
	}
	else {
		$userip = getenv( 'REMOTE_ADDR' );
	}

	$sql = "select count(*) FROM ! where ip = ? and ip <> '' and affid = ?";

	$count = $db->getOne( $sql, array( AFFILIATE_REFERALS_TABLE, $userip, $_SESSION['ReferalId'] ) );

	if ( $count == 0 ) {
		$sql = "INSERT INTO ! ( affid, userid, ip ) VALUES ( ?, '', ? )";
		$db->query( $sql, array( AFFILIATE_REFERALS_TABLE, $_SESSION['ReferalId'], $userip ) );
	}
}

if ($_GET['page'] == 'login' and $_GET['errid'] != '') {

	$t->assign ( 'login_error', $lang['errormsgs'][$_GET['errid']] );
}

$_SESSION['lookagestart'] = ($_SESSION['lookagestart']!= '')?$_SESSION['lookagestart']:$config['default_start_agerange'];
$_SESSION['lookageend'] = ($_SESSION['lookageend']!= '')?$_SESSION['lookageend']:$config['default_end_agerange'];

if( isset( $_GET['page'] ) ) {

	$data = array();

	if ( $_GET['page'] == 'stories' ) {

		$sql = 'SELECT * FROM ! order by `date` desc';
		$temp = $db->getAll( $sql, array( STORIES_TABLE ) );

		foreach( $temp as $index => $row ) {

			$sql = 'SELECT username FROM ! where id = ?';
			$row['username'] = $db->getOne( $sql, array( USER_TABLE, $row[sender] ) );
			$row['text'] = stripslashes($row['text']);
			$arrtext = explode( ' ', $row[text], $config['length_story'] + 1 );
			$arrtext[ $config['length_story'] ] = '';
			$row['text'] = trim( implode( ' ', $arrtext ) ) . '...';
			$row['date'] = date( LONG_DATE_FORMAT, $row[date] );

			$data []= $row;
		}

		$t->assign ( 'data', $data );
		$t->assign('rendered_page', $t->fetch('allstories.tpl') );

	} elseif ( $_GET['page'] == 'allnews' ) {

		$sql = 'SELECT * FROM ! order by `date` desc';
		$temp = $db->getAll( $sql, array( NEWS_TABLE ) );

		foreach( $temp as $index => $row ) {
			$row['date'] = date( LONG_DATE_FORMAT, $row[date] );
			$arrtext = explode( ' ', stripslashes($row['text']), $config['length_story'] + 1);
			$arrtext[ $config['length_story'] ] = '';
			$row['text'] = trim(implode( ' ', $arrtext)) . '...';

			$data []= $row;
		}

		$t->assign ( 'data', $data );
		$t->assign('rendered_page', $t->fetch('allnews.tpl') );

	} elseif ( $_GET['page'] == 'articles' ) {

		$sql = 'SELECT * FROM ! order by dat desc';
		$temp = $db->getAll( $sql, array( ARTICLES_TABLE ) );

		foreach( $temp as $index => $row ) {

			$row['dat'] = date( LONG_DATE_FORMAT, $row['dat'] );
			$arrtext = explode( ' ', stripslashes($row['text']), $config['length_story'] + 1 );
			$arrtext[$config['length_story']] = '';
			$row['text'] = trim(implode( ' ', $arrtext)) . '...';

			$data []= $row;
		}

		$t->assign ( 'data', $data );
		$t->assign('rendered_page', $t->fetch('allarticles.tpl') );

	} elseif ( $_GET['page'] == 'showstory' ) {

		$sql = 'SELECT * FROM ! where storyid = ?';
		$temp = $db->getAll( $sql, array( STORIES_TABLE, $_GET['storyid'] ) );

		foreach( $temp as $index => $row ) {

			$sql = 'SELECT username FROM ! where id = ?';
			$row['username'] = $db->getOne( $sql, array( USER_TABLE, $row[sender] ) );

			$row['date'] = date( LONG_DATE_FORMAT, $row[date] );
			$row['text'] = stripslashes($row['text']);

			$data []= $row;
		}

		$t->assign ( 'data', $data );
		$t->assign('rendered_page', $t->fetch('fullstory.tpl') );

	} elseif ( $_GET['page'] == 'shownews' ) {

		$sql = 'SELECT * FROM ! where newsid = ?';
		$temp = $db->getAll( $sql, array( NEWS_TABLE, $_GET['newsid'] ) );

		foreach( $temp as $index => $row ) {
			$row['date'] = date(LONG_DATE_FORMAT, $row[date] );
			$row['text'] = stripslashes($row['text']);
			$data []= $row;
		}

		$t->assign ( 'data', $data );
		$t->assign('rendered_page', $t->fetch('fullnews.tpl') );

	} elseif ( $_GET['page'] == 'showarticle' ) {

		$sql = 'SELECT * FROM ! where articleid = ?';
		$temp = $db->getAll( $sql, array( ARTICLES_TABLE, $_GET['articleid'] ) );

		foreach( $temp as $index => $row ) {
			$row['dat'] = date( LONG_DATE_FORMAT, $row[dat] );
			$row['text'] = stripslashes($row['text']);
			$data []= $row;
		}

		$t->assign ( 'data', $data );
		$t->assign('rendered_page', $t->fetch('fullarticle.tpl') );

	} elseif ( $_GET['page'] == 'login' ) {

		$t->assign('rendered_page', $t->fetch('login.tpl') );

	} elseif ( $_GET['page'] != '' ) {

		$sql = 'SELECT * FROM ! where pagekey = ?';
		$row = $db->getRow( $sql, array( PAGES_TABLE, $_GET['page'] ) );

		if ( $row ) {
			$row['pagetext'] = stripslashes(stripslashes($row['pagetext']));
			$index++;
		}

		$t->assign ( 'data', $row );
		$t->assign('rendered_page', $t->fetch('page.tpl') );

	}
}

if ( strlen( $_SERVER['QUERY_STRING'] ) <= 0 or(( $_GET['errid'] == NOT_YET_APPROVED or $_GET['errid'] == NOT_ACTIVE) && $_SESSION['UserId'] > 0 ) ){

	$last_users = $config['no_last_new_users'];

	/* Modify the newest profile condition to be from last visit time if user is logged in */

	if ( $last_users > 0 ) {
/*		if ( isset($_SESSION['lastvisit']) ) {

			$sqlNewUsers = "SELECT *, floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12) as age  FROM ! WHERE status in (?, ?) and regdate >= ? ORDER BY regdate DESC LIMIT 0, $last_users";

			$newUsers = $db->getAll( $sqlNewUsers, array( USER_TABLE,$lang['status_enum']['active'], 'Active', $_SESSION['lastvisit'] ) );

		} else {  */

			$sqlNewUsers = "SELECT *, floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12) as age  FROM ! WHERE status in (?, ?) ORDER BY regdate DESC LIMIT 0, $last_users";

			$newUsers = $db->getAll( $sqlNewUsers, array( USER_TABLE , $lang['status_enum']['active'], 'Active') );
/*		} */

		$list = array();

		foreach ($newUsers as $row) {

			/* Get countryname and statename */
			$countryname = $db->getOne('select name from ! where code = ?', array(COUNTRIES_TABLE, $row['country'] ) );

			$statename = $db->getOne('select name from ! where code = ? and countrycode = ?', array(STATES_TABLE, $row['state_province'], $row['country'] ) );

			$row['countryname'] = $countryname;

			$row['statename'] = ($statename != '') ? $statename : $row['state_province'];

			$list[] = $row;

		}

	}

	$t->assign( 'users', $list );

	if ($config['list_newmembers'] > 0) {
		/* Get list of latest 10 userid */
/*		if ( isset($_SESSION['lastvisit']) ) {

			$sqlNew = "SELECT id, username, floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12) as age, (case gender when 'M' then 'Male' when 'F' then 'Female' else 'Couple' end ) as gender, allow_viewonline, city, country  FROM ! WHERE status in (?, ?) and regdate >= ? ORDER BY regdate DESC LIMIT 0,".$config['list_newmembers'];

			$newUsersList = $db->getAll( $sqlNew, array( USER_TABLE, $lang['status_enum']['active'], 'Active', $_SESSION['lastvisit'] ));

		} else {  */

			$sqlNew = "SELECT id, username, floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12) as age, (case gender when 'M' then 'Male' when 'F' then 'Female' else 'Couple' end ) as gender, allow_viewonline, city, country, state_province  FROM ! WHERE status in (?, ?)  ORDER BY regdate DESC LIMIT 0,".$config['list_newmembers'];

			$newUsersList = $db->getAll( $sqlNew, array( USER_TABLE, $lang['status_enum']['active'], 'Active' ));

/*		} */

		$list = array();

		foreach ($newUsersList as $row) {

			/* Get countryname and statename */
			$countryname = $db->getOne('select name from ! where code = ?', array(COUNTRIES_TABLE, $row['country'] ) );

			$statename = $db->getOne('select name from ! where code = ? and countrycode = ?', array(STATES_TABLE, $row['state_province'], $row['country'] ) );

			$row['countryname'] = $countryname;

			$row['statename'] = ($statename != '') ? $statename : $row['state_province'];

			$list[] = $row;

		}

		$t->assign('newUsersList',$list);

	}

	if ($config['show_featured_profiles'] > 0 ) {

		$xid = ($_SESSION['UserId'] > 0)?$_SESSION['UserId']:'0';

		$sql = 'select id, userid from ! where ? between start_date and end_date and req_exposures > exposures  and userid <> ? order by userid limit 0, ! ';

		$list = $db->getAll($sql, array( FEATURED_PROFILES_TABLE, time(), $xid,  $config['show_featured_profiles'] ) );

		$featured_profiles = array();

		foreach ($list as $usr) {

			$sql = 'select *, floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12) as age from ! where id = ?';

			$row = $db->getRow($sql, array( USER_TABLE, $usr['userid'] ) );

			/* Get countryname and statename */
			$countryname = $db->getOne('select name from ! where code = ?', array(COUNTRIES_TABLE, $row['country'] ) );

			$statename = $db->getOne('select name from ! where code = ? and countrycode = ?', array(STATES_TABLE, $row['state_province'], $row['country'] ) );

			$row['countryname'] = $countryname;

			$row['statename'] = ($statename != '') ? $statename : $user['state_province'];

			$featured_profiles[] = $row;

			$sql = 'update ! set exposures = exposures + 1 where id = ?';

			$db->query($sql, array( FEATURED_PROFILES_TABLE, $usr['id'] ) );
		}

		$t->assign('featured_profiles', $featured_profiles);

	}

	if ($_SESSION['UserId'] > 0 ) {

		/* Get some stats */

		$sql = 'select count(*) from ! where userid = ? and act_time > ? and act = ?';

		$t->assign('profile_views', $db->getOne($sql, array( VIEWS_WINKS_TABLE, $_SESSION['UserId'], $_SESSION['lastvisit'], 'V' ) ) );

		$t->assign('winks', $db->getOne($sql, array( VIEWS_WINKS_TABLE, $_SESSION['UserId'], $_SESSION['lastvisit'], 'W' ) ) );


		$sql = 'select count(*) from ! where recipientid = ? and flagread = 0 and folder = ?';

		$t->assign('new_messages', $db->getOne($sql, array( MAILBOX_TABLE, $_SESSION['UserId'], 'inbox' ) ) );

	}

	$t->assign('rendered_page', $t->fetch('homepage.tpl') );

}

$t->display( 'index.tpl' );
?>
