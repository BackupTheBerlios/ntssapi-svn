<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include('sessioninc.php');

define( 'PAGE_ID', 'profile_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}
	
if ( $_POST['delaction'] == 'Yes' ) {
	
	$sqldel = 'DELETE FROM ! WHERE id = ?';
		
	$result = $db->query( $sqldel, array( USER_TABLE, $_POST['txtid'] ));
	
}

header ( 'location:profile.php' );
?>