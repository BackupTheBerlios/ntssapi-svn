<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

$newpwd = md5( 'visitor' ); // New password
$username='username';   // Put the username you want to change password

$sql = 'update ! set password = ? where username = ?';

$db->query( $sql, array( USER_TABLE, $newpwd, $username ) );

if ( $config['phpbb_installed'] == 'Y' ) {

	$sql = 'update ! set user_password = ? where username = ?';

	$db->query( $sql, array( 'phpbb_users', $newpwd, $username ) );
}

?>