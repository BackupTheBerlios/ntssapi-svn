<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );
include (PEAR_DIR.'Mail/mime.php');

define( 'PAGE_ID', 'profile_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}


if ( isset( $_GET['results_per_page'] ) && $_GET['results_per_page'] ) {

	$psize = $_GET['results_per_page'];
	
	$config['search_results_per_page'] = $_GET['results_per_page'] ;
	
	$_SESSION['ResultsPerPage'] = $_GET['results_per_page'];		
	
} elseif( $_SESSION['ResultsPerPage'] != '' ) {

	$psize = $_SESSION['ResultsPerPage'];
	
	$config['search_results_per_page'] = $_SESSION['ResultsPerPage'] ;		
	
} else {

	$psize = $config['page_size'];
	
	$_SESSION['ResultsPerPage'] = $config['page_size'];
	
}



//Default Sorting
$sort = findSortBy();

$data=array();

//For Editing Sections
if ( $_GET['edit'] ) {


	if ($_SESSION['modifiedrow'] != '') {
	
		$data = $_SESSION['modifiedrow'];
		
		$data['id'] = $_GET['edit'];
		$_SESSION['modifiedrow'] = '';
		
	} else {

		$sqledit = 'SELECT * from ! Where id = ?';
			
		$data = $db->getRow( $sqledit, array( USER_TABLE, $_GET['edit'] ) );

	}	

	$lang['states'] = getStates($data['country'],'N');

	$lang['lookcountries'] = $allcountries;

	$lang['lookstates'] = getStates($data['lookfrom']);

	if ($data['state_province'] != '') {

		$lang['counties'] = getCounties($data['country'], $data['state_province'], 'N');

		if (count($lang['counties']) == 1) {
			foreach ($lang['counties'] as $key => $val) {
				$data['county'] = $key;
			}
		}

		if ($data['county'] != '') {

			$lang['cities'] = getCities($data['country'], $data['state_province'], $data['county'], 'N');

			if (count($lang['cities']) == 1) {
				foreach($lang['cities'] as $key => $val) {
					$data['city'] = $key;
				}
			}

			if ($data['city'] != '') {

				$lang['zipcodes'] = getZipcodes($data['country'], $data['state_province'], $data['county'], $data['city'], 'N');
			}
		}
	}

	if ($data['lookstate_province'] != '') {

		$lang['lookcounties'] = getCounties($data['lookcountry'], $data['lookstate_province'], 'Y');

		if (count($lang['lookcounties']) == 1) {
			foreach ($lang['lookcounties'] as $key => $val) {
				$data['lookcounty'] = $key;
			}
		}

		if ($data['lookcounty'] != '') {

			$lang['lookcities'] = getCities($data['lookcountry'], $data['lookstate_province'], $data['lookcounty'], 'Y');

			if (count($lang['lookcities']) == 1) {
				foreach($lang['lookcities'] as $key => $val) {
					$data['lookcity'] = $key;
				}
			}

			if ($data['lookcity'] != '') {

				$lang['lookzipcodes'] = getZipcodes($data['lookcountry'], $data['lookstate_province'], $data['lookcounty'], $data['lookcity'], 'Y');
			}
		}
	}

	$t->assign( 'lang', $lang );

	$t->assign( 'error', $lang['errormsgs'][ $_GET['errid'] ] );
			
	$t->assign( 'user', $data );

	$_SESSION['UserId'] = $_GET['edit'];
	
	$sql = 'SELECT * FROM ! WHERE enabled=?';

	$rs = $db->getAll( $sql, array( MEMBERSHIP_TABLE, 'Y' ) );

	$mships = array();
	
	foreach ( $rs as $row ) {
	
		$mships[$row['roleid']] = $row['name'];
	
	}

	$t->assign( 'mships', $mships );

	$t->assign('rendered_page', $t->fetch('admin/profileedit.tpl'));
		
	$t->display( 'admin/index.tpl' );
	
	exit;
}

//For Deletion of profiles
if ( $_GET['txtdelete'] ) {

	deleteUser($_GET['txtdelete']);
	
	$t->assign('errmsg', PROFILE_DELETED);

} elseif ($_POST['delete_selected'] == $lang['delete_selected']) {

	@ini_set("max_execution_time","1200");

	$arr = $_POST['txtchk'];

	if (count($arr) > 0) {
		/* Delete profile routine */
		foreach ($arr as $userId) {
			deleteUser($userId);
		}			

		$t->assign('errmsg', PROFILES_DELETED);		
	}
}


$mships = $db->getAll('select roleid, activedays from ! order by roleid',array( MEMBERSHIP_TABLE) );

$memberships = array();

foreach ($mships as  $val) {
	
	$memberships[$val['roleid']] = $val['activedays'];
}

if ( $_POST['groupaction'] ) {

	$arr = $_POST['txtchk'];

	$status = 	$_POST['groupaction'];
	
	foreach ($lang['status_disp'] as $key=>$val) {

		if ($val == $_POST['groupaction']) {
	
			$status = $key;
		}
	}

	if ( $status == $lang['changeto'] and count($arr) > 0 ) {
	
		$level =  $_POST['txtmlevel'];
		
		foreach( $arr as $val ) {
			$userlevel = $db->getAll('select level, levelend from ! where id = ?', array( USER_TABLE, $val) ); 

			if ($userlevel[0]['levelend'] == '') {

				$userlevel[0]['levelend'] = time();

			}

			$levelend = $userlevel[0]['levelend'];
			
			$add_days = $memberships[$userlevel[0]['level']];
		
			$sql = 'UPDATE !  SET level = ?, levelend = ?  WHERE id = ?';
			
			$db->query( $sql, array( USER_TABLE, $level,  strtotime("+$add_days day",$levelend), $val ) );
			
		}
		
	} elseif ( count($arr) > 0 ) {
	
		foreach( $arr as $val ) {
		
			$userlevel = $db->getAll('select level, levelend from ! where id = ?', array( USER_TABLE, $val) ); 

			if ($userlevel[0]['levelend'] == '') {

				$userlevel[0]['levelend'] = time();

			}

			$levelend = $userlevel[0]['levelend'];
			
			$add_days = $memberships[$userlevel[0]['level']];
					
			$sql = 'UPDATE ! SET status = ?, levelend = ? , active=? WHERE id = ?';
			
			$db->query( $sql, array( USER_TABLE, $status, strtotime("+$add_days day",$levelend), '1', $val ) );
			
		}
	}
}

$t->assign ( 'psize',  $psize );

$page_size = $psize;

$page = (int)$_GET['offset'];

if( $page == 0 ) $page = 1;

$upr = ($page)*$page_size - $page_size;

if ( $_POST['filter'] == 1 ) {

	$searchat = $_POST['txtsrchat'];
	
	$search = $_POST['txtsearch'];	

	$sql = "SELECT * FROM ! WHERE $searchat LIKE '%$search%'";
	
	
} else {

	$sql = 'SELECT * FROM ! ';

	$sql .= ' ORDER BY ' . $sort . " LIMIT $upr,$page_size ";	
}



$data = $db->getAll( $sql, array( USER_TABLE ) );

if ( $_POST['filter'] == 1 ) {

	$searchat = $_POST['txtsrchat'];
	
	$search = $_POST['txtsearch'];	
	
	$sql = "SELECT * FROM ! WHERE $searchat LIKE '%$search%'";
	
} else {

	$sql = 'SELECT * FROM ! ';

}

$rs = $db->query( $sql, array( USER_TABLE) );

$reccount = $rs->numRows();

$t->assign ( 'total_recs',  $reccount );

$total_pages = ceil( $reccount / $page_size );

$pages_vals = array();

for( $i=1; $i<=$total_pages; $i++ ) { $pages_vals[$i] = $i; }

$t->assign ( 'total_pages',  $pages_vals );

$page_limit = 5;
$j = 1;
if ( $page > 2 ) { $page = $page - 2; } else { $page = 1; }
for( $i=$page; $i<=$total_pages; $i++ ) { 
	$pages_show[$i] = $i; 
	
	$j++;
	if ( $j > $page_limit )	break;
}

$t->assign ( 'pages_show',  $pages_show );

$t->assign ( 'reccount',  $reccount );
	
$t->assign( 'lang', $lang );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->assign( 'querystring', 'sort=' . $_GET['sort'] . '&type=' . $_GET['type']);

$t->assign( 'upr', $upr );

$t->assign( 'data', $data );

$sql = 'SELECT * FROM ! WHERE enabled = ?';

$rs = $db->getAll( $sql, array( MEMBERSHIP_TABLE, 'Y' ) );

$mships = array();
	
foreach ( $rs as $row ) {
	
	$mships[$row['roleid']] = $row['name'];
	
}

$t->assign( 'mships', $mships );

$t->assign('rendered_page', $t->fetch('admin/profile.tpl'));
		
$t->display( 'admin/index.tpl' );


function deleteUser($userId) {
	/* Delete profile routine */
	global $db, $config;
	
	$rec = $db->getRow('select * from ! where id = ?', array( USER_TABLE, $userId) );

	$username = $rec['username'];

/*	
	Email sending routine. Disabled now. Vijay
	
	$header=array(
		'From' => $config['admin_email'],
		'Subject' => 'Reg. Your profile with '.SITENAME
		);
	$message = 'Hello '.$rec['firstname'].' '.$rec['lastname'].',<br><br>';
	$message.= 'Your profile is removed from '.SITENAME.' by Administrator. <br><br> If you have any questions, kindly contact the Administrator using the feedback form.<br><br>';
	$message.='Thank you<br><br>Administrator<br>'.SITENAME;
	
	$mime = new Mail_mime('');
	
	$mime->setHTMLBody($message);

	$body = $mime->get();
	
	$hdrs = $mime->headers($header);
	
	$mail_object =& Mail::factory( MAIL_TYPE, $params );

	$mail_object->send( $rec['email'], $hdrs, $body );
*/
	$db->query('delete from ! where username = ? or ref_username = ?', array(BUDDY_BAN_TABLE, $username, $username) );

	$db->query('delete from ! where userid = ?', array(FEATURED_PROFILES_TABLE, $userId ) );

	$db->query('delete from ! where senderid = ? or recipientid = ?', array(INSTANT_MESSAGE_TABLE, $userId, $userId) );

	$db->query('delete from ! where senderid = ? or recipientid = ?', array(MAILBOX_TABLE, $userId, $userId) );

	$db->query('delete from ! where userid = ?', array(ONLINE_USERS_TABLE, $userId ) );

	$db->query('delete from ! where userid = ?', array(USER_RATING_TABLE, $userId ) );

	$db->query('delete from ! where userid = ?', array(USER_SEARCH_TABLE, $userId ) );

	$db->query('delete from ! where userid = ?', array(USER_SNAP_TABLE, $userId ) );

	$db->query('delete from ! where userid = ? or ref_userid = ?', array(VIEWS_WINKS_TABLE, $userId, $userId) );

	$db->query('delete from ! where id = ?', array(USER_TABLE, $userId ) );

	$db->query('delete from ! where username = ?', array('phpbb_users', $username ) );
}
?>	