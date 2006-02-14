<?php

if (isset($_SESSION['opt_lang'])) {

	$opt_lang=$_SESSION['opt_lang'];

	session_destroy();

	session_start();

	$_SESSION['opt_lang'] = $opt_lang;

}

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

if( trim($_POST['txtusername']) == '' ){

	$err = USERNAME_BLANK; // change to a constant later

} elseif( trim($_POST['txtpassword']) == '' ){

	$err = PASSWORD_BLANK; // change to a constant later

} else {
	$pwd = md5( trim( $_POST['txtpassword'] ) );

	$sql = 'SELECT id, fullname, lastvisit  FROM ! where username = ? and password = ?';

	$row = $db->getRow( $sql , array( ADMIN_TABLE, $_POST['txtusername'], $pwd ) );

	if( $row['id'] > 0 ) {

		$_SESSION['AdminId'] = $row['id'];

		$_SESSION['LastVisit'] = $row['lastvisit'];

		$_SESSION['AdminName'] = $row['fullname'];

		$_SESSION['UserName'] = $_POST['txtusername'];

		$_SESSION['UserId'] = '';

		$_SESSION['whatIneed'] = base64_encode( $_POST['txtpassword'] );		

		$time = time();

		$sql = 'UPDATE ! SET lastvisit = ? WHERE id = ?';

		$db->query( $sql, array( ADMIN_TABLE, $time, $row['id'] ) );

		$sql = 'SELECT * FROM ! WHERE adminid = ?';

		$rs = $db->getRow( $sql, array( ADMIN_RIGHTS_TABLE, $row['id'] ) );

		$_SESSION['Permissions'] = $rs;

		header( 'location:panel.php' );

		exit();
	} else {

		$err = INVALID_LOGIN; // change to a constant later
	}
}

header( 'location:index.php?errid=' . $err );
exit();

?>