<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'event_mgt' );
if ( !checkAdminPermission( PAGE_ID ) ) {
	header( 'location:not_authorize.php' );
	exit;
}

if ($_POST['action'] == $lang['Approve']) {
/* approve */

	$sql = 'update ! set enabled = ? where id = ?';
	$db->query( $sql, array( EVENTS_TABLE, 'Y', $_POST['id'] ) );

	$errid = EVENT_APPROVED;
	
} elseif ($_POST['action'] == $lang['reject']) {
/* Remove and remove */
	$sql = 'delete from ! where id = ?';
	$db->query( $sql,array( EVENTS_TABLE, $_POST['id'] ) );
	$errid = EVENT_REJECTED;
}


$sql = 'select * from ! where enabled = ? and private_to = "" and userid <> 0 order by datetime_from';
$items = $db->getAll( $sql, array( EVENTS_TABLE, 'N' ) );
$events = array();
foreach ( $items as $row ) {
	$sql = 'select username, firstname, lastname from ! where id = ?';
	$user = $db->getRow( $sql, array( USER_TABLE, $row['userid'] ) );
	$row['username'] = $user['username'];
	$row['fullname'] = $user['firstname'] . ' '. $user['lastname'];
	$events[] = $row;
}

//print_r($events);
$t->assign('events', $events);
$t->assign('errid',$errid);
$t->assign('rendered_page', $t->fetch('admin/approve_events.tpl'));
$t->display('admin/index.tpl');
?>