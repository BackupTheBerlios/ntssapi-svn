<?php

/* 	
*	This program will add profile to featured profiles list
*	
*/

if ( !defined( 'SMARTY_DIR' ) ) {

	include_once( '../init.php' );

}

include ( 'sessioninc.php' );

$req_action = $_GET['req_action'] ;

$data = array();

if ($req_action == '' && $_POST['req_action'] != '') {
	
	$req_action = $_POST['req_action'];
	
} 

if ( $_POST['cancelthis'] == $lang['cancel']) {
/* Cancel this procedure*/

	header ('location: '.$_POST['bckurl']);

	exit;	
}

$t->assign('req_action', $req_action);

$data['bckurl'] = $_GET['bckurl'];

if ( $_GET['userid'] > 0 ) {

	$sql = 'select username, firstname, lastname from ! where id = ?';
	
	$row  = $db->getRow($sql, array( USER_TABLE, $_GET['userid'] ) );
	
	$data['step'] = 2;
	
	$data['username'] = $row['username'];
	
	$data['fullname'] = $row['firstname'].' '.$row['lastname'];
	
	$t->assign('data', $data);

	$t->assign('rendered_page', $t->fetch('admin/featured_profile.tpl'));
		
	$t->display('admin/index.tpl');
		
	exit;

}

$start_date = strtotime($_POST['startYear'].'-'.$_POST['startMonth'].'-'.$_POST['startDay']);

$end_date = strtotime($_POST['endYear'].'-'.$_POST['endMonth'].'-'.$_POST['endDay']);

$data['start_date'] = $start_date;

$data['end_date']  = $end_date;	


if ($_POST['req_action'] == 'add' && $_POST['step'] == 1) {

	$data['step'] = '2';

	$data['username'] = $_POST['username'];

	if ($data['username'] != '') {

		$sql = 'select firstname, lastname from ! where username = ?';

		$row = $db->getRow( $sql, array( USER_TABLE, $data['username'] ) );

		if ($row) {

			$data['fullname'] = $row['firstname'].' '.$row['lastname'];

		} else {
		
			$data['fullname'] = $lang['invalid_username'];
		
		}
	}

	$t->assign('data', $data);

	$t->assign('rendered_page', $t->fetch('admin/featured_profile.tpl'));
		
	$t->display('admin/index.tpl');
		
	exit;
		
} elseif ($req_action == 'add') {
	/* Add routine */

	if ( $_POST['username'] != '' ) { 

		foreach ($_POST as $key => $val) {

			$data[$key] = $val;

		}

		/* Get the user id for the username */

		$sql = 'select id from ! where username = ?';

		$userid = $db->getOne( $sql, array( USER_TABLE, $_POST['username'] ) );

		$sql = 'select username, firstname, lastname from ! where id = ?';

		$usr = $db->getRow($sql, array( USER_TABLE, $userid ) );

		$data['username'] 		= $usr['username'];

		$data['fullname'] 		= $usr['firstname'].' '.$usr['lastname'];

		if ($end_date < $start_date) {

			$t->assign('error_msg', ERR_STARTDATE_BEFORE_ENDDATE);

			$t->assign('data', $data);

			$t->assign('rendered_page', $t->fetch('admin/featured_profile.tpl'));
		
			$t->display('admin/index.tpl');

			exit;

		} 

		/* 
			If this username is already in featured list, it should be modified only 
		*/

		$sql = 'select id from ! where userid = ?';

		$uid = $db->getOne( $sql, array( FEATURED_PROFILES_TABLE, $userid ) );

		if ($uid > 0 ) {

			$t->assign('error_msg', ERR_EXISTING );

			$t->assign('data', $data);

			$t->assign('rendered_page', $t->fetch('admin/featured_profile.tpl'));
		
			$t->display('admin/index.tpl');

			exit;

		}

		$sql = 'insert into ! (userid, start_date, end_date, must_show, req_exposures) values ( ?, ?, ?, ?, ?  )';

		$db->query($sql, array( FEATURED_PROFILES_TABLE, $userid, $start_date, $end_date, $_POST['must_show'], $_POST['req_exposures'] ) );

		if ($_POST['bckurl'] != '') {
		
			header ('location: '.$_POST['bckurl']);

		} else {
		
			header ('location: featured_profiles.php');
		
		}
		exit;
	
	} else {
	
		$t->assign('data', $data);

		$t->assign('rendered_page', $t->fetch('admin/featured_profile.tpl'));
		
		$t->display('admin/index.tpl');

		exit;
			
	}
}

if ($req_action == 'modify' ) {

/*	
	Modify routine. Get the record..
	
*/

	if ($_POST['userid'] > 0) {
	
	/* 
		Update the record. Only the start and end date and req_exposures to be updated.
	
	*/
		foreach ($_POST as $key => $val) {

			$data[$key] = $val;

		}

		if ($end_date < $start_date) {

			$t->assign('error_msg', ERR_STARTDATE_BEFORE_ENDDATE );

			$t->assign('data', $data);

			$t->assign('rendered_page', $t->fetch('admin/featured_profile.tpl'));
		
			$t->display('admin/index.tpl');

			exit;

		} 

		$sql = 'update ! set start_date = ?, end_date = ?, req_exposures = ?, must_show = ?  where id = ?';
		
		$db->query($sql, array( FEATURED_PROFILES_TABLE, $start_date, $end_date, $_POST['req_exposures'], $_POST['must_show'], $_POST['id'] ));

		header ('location: featured_profiles.php');
	
		exit;
	
	} else {

		$sql = 'select id, userid, start_date, end_date, must_show, req_exposures from ! where id = ?';

		$row = $db->getRow($sql, array( FEATURED_PROFILES_TABLE, $_GET['id'] ) );

		$sql = 'select username, firstname, lastname from ! where id = ?';

		$usr = $db->getRow($sql, array( USER_TABLE, $row['userid'] ) );

		$data['username'] 		= $usr['username'];

		$data['fullname'] 		= $usr['firstname'].' '.$usr['lastname'];

		$data['id'] 			= $row['id'];

		$data['userid'] 		= $row['userid'];

		$data['start_date'] 	= $row['start_date'];

		$data['end_date'] 		= $row['end_date'];

		$data['must_show'] 		= $row['must_show'];

		$data['req_exposures'] 	= $row['req_exposures'];

		$t->assign('data', $data);

		$t->assign('rendered_page',  $t->fetch('admin/featured_profile.tpl'));
		
		$t->display('admin/index.tpl');
	}
}
?>