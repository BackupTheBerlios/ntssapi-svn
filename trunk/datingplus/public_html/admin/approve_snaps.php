<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'snaps_require_approval' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

if ($_POST['action'] == $lang['Approve']) {
/* approve picture */

	$sql = 'update ! set active = ? where id = ?';
	$db->query( $sql, array( USER_SNAP_TABLE, 'Y', $_POST['id'] ) );

	$errid = PICTURE_APPROVED;
	
} elseif ($_POST['action'] == $lang['reject']) {
/* Remove the picture entry */

	$sql = 'update ! set active = ? where id = ?';
	$db->query( $sql,array( USER_SNAP_TABLE, 'R', $_POST['id'] ) );
	$errid = PICTURE_REJECTED;
}


/* Now select the pictures which are not yet approved.. */
$sql = 'select id, userid, picno from ! where active = ? order by ins_time';

$pics = $db->getAll( $sql, array( USER_SNAP_TABLE, 'N' ) );

$user_pics = array();

foreach ( $pics as $row ) {

	$sql = 'select username, firstname, lastname from ! where id = ?';

	$user = $db->getRow( $sql, array( USER_TABLE, $row['userid'] ) );

	$row['username'] = $user['username'];

	$row['fullname'] = $user['firstname'] . ' '. $user['lastname'];

	$user_pics[] = $row;
}

//print_r($user_pics);
$t->assign('user_pics', $user_pics);

$t->assign('errid',$errid);

$t->assign('rendered_page', $t->fetch('admin/approve_snaps.tpl'));
		
$t->display('admin/index.tpl');
		



?>