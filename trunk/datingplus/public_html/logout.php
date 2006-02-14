<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$sql = 'DELETE FROM ! WHERE userid = ?';

$db->query( $sql, array( ONLINE_USERS_TABLE, $_SESSION['UserId'] ) );

session_destroy();

unset( $_COOKIE['osdate_info'] );
unset( $cookie );
unset( $_SESSION );

//header('location:index.php');

include( 'index.php' );

exit();
?>