<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'change_pwd' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$id = $_POST['txtid'];

$old = $_POST['txtoldpwd'];

$new = $_POST['txtnewpwd'];

$con = $_POST['txtconpwd'];


$err = 0;

if ( $old == '' ) {

	$err = OLDPWD_BLANK; 
} elseif ( $new == '' ) {

	$err = NEWPWD_BLANK; 

} elseif ( $con == '' ) {

	$err = CONFPWD_BLANK; 

}

if ( strcmp( $new, $con ) != 0 ) {

	$err = DIFF_PASSWORDS; 
}

if ( $err > 0 ) {

	header( 'location:changepwd.php?errid=' . $err );
	exit;

}

$old = md5( $old );

$sql = 'SELECT username FROM ! WHERE id = ? AND password = ?';

$usrname = $db->getOne( $sql, array( ADMIN_TABLE, $id, $old ) );

if ( $usrname != '' ) {

	$pwd = md5( $con );

	$sql = 'UPDATE ! SET password = ? WHERE id = ?';

	$db->query( $sql, array(ADMIN_TABLE, $pwd, $id ) );

	if ( $config['phpbb_installed'] == 'Y' ) {

		$sql = 'UPDATE ! SET user_password = ?, user_regdate = ?  WHERE username = ?';

		$db->query( $sql, array('phpbb_users', md5($con), time(), $usrname ) );

	}


} else {

	header( 'location:changepwd.php?errid='.WRONG_PASSWORD );
	exit;

}

header( 'location:pwdchanged.php' );

exit;

?>