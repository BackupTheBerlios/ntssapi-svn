<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'admin_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$id = $_POST['txtid'];

$fullname = $_POST['txtfullname'];

$superuser = $_POST['txtsuperuser'];

$enabled = $_POST['txtenabled'];


$err = 0 ;


if ( $fullname == '' ) {

	$err = FULLNAME_BLANK;	// change to a constant later
}

if ( $err > 0 ) {

	header( 'location:manageadmin.php?edit=' . $id . '&errid=' . $err );
	exit;
}

$username = $db->getOne('select username from ! where id = ?', array( ADMIN_TABLE, $id ) );

$sql = 'UPDATE ! SET fullname = ?, super_user = ?, enabled = ? WHERE id = ?';

$db->query( $sql, array( ADMIN_TABLE, $fullname, $superuser, $enabled, $id ) );

$level = 1;

if ($superuser == 'N') { $level = 2; }

$sql = 'UPDATE ! SET user_level = ? WHERE username = ?';

$db->query( $sql, array( 'phpbb_users', $level, $username ) );


header( 'location:manageadmin.php' );

exit;

?>