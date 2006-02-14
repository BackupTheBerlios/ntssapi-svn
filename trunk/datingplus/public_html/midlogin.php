<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

// to do: change error codes to PHP constants

if ( $_SESSION['txtusername'] != '' && !$_POST['txtusername'] ) {

	$_POST['txtusername'] = $_SESSION['txtusername'];
	$_POST['txtpassword'] = base64_decode( $_SESSION['txtpassword'] );
	$_POST['rememberme']  = $_SESSION['rememberme'];
}

if ( $_POST['txtusername'] == '' ) {

	$err = USERNAME_BLANK;

} elseif( $_POST['txtpassword'] == '' ){

	$err = PASSWORD_BLANK;

} else {

	$pwd = md5( trim( $_POST['txtpassword'] ) );

	$sql = 'SELECT id, username, firstname, lastname, level, status, lastvisit, levelend, active FROM ! where username = ? and password = ? and status not in (?, ?, ?, ?)';

	$row = $db->getRow( $sql, array( USER_TABLE, $_POST['txtusername'], $pwd, $lang['status_enum']['rejected'], 'Reject', $lang['status_enum']['suspended'], 'Suspend' ) );

	if( $row['id'] > 0 ) {

		$opt_lang=$_SESSION['opt_lang'];

		session_destroy();

		session_start();

		$_SESSION['opt_lang'] = $opt_lang;

		$cookie['username'] = $row['username'];

		if ($_POST['rememberme']) {
			$cookie['dir'] = base64_encode($_POST['txtpassword']);
			setcookie("osdate_info[username]", $cookie['username'], strtotime("+30day"), "/" );
			setcookie("osdate_info[dir]", $cookie['dir'], strtotime("+30day"), "/" );
		} else {
			setcookie("osdate_info[username]", $cookie['username'], strtotime("-1day"), "/" );
			setcookie("osdate_info[dir]", $cookie['dir'], strtotime("-1day"), "/" );
		}

		$_SESSION['UserId'] = $row['id'];

		$_SESSION['UserName'] = $row['username'];

		$_SESSION['FirstName'] = $row['firstname'];

		$_SESSION['FullName'] = $row['firstname'] . ' ' . $row['lastname'];

		$_SESSION['whatIneed'] = base64_encode($_POST['txtpassword']);

		if (date('Ymd',$row['levelend']) < date('Ymd')) {

			$_SESSION['RoleId'] = $config['default_user_level'];

			$_SESSION['expired'] = 1;

		} elseif( $row['status'] == $lang['status_enum']['approval'] ){

			$_SESSION['RoleId'] = $config['default_user_level'];

		} elseif( $row['active'] != '1' ){

			$_SESSION['RoleId'] = $config['default_user_level'];

		} else {

			$_SESSION['RoleId'] = $row['level'];
		}

		$_SESSION['active'] = $row['active'];

		$_SESSION['lastvisit'] = $row['lastvisit'];

		$_SESSION['status'] = $row['status'];

		$sql = 'DELETE FROM ! WHERE userid = ?';

		$db->query( $sql, array( ONLINE_USERS_TABLE, $_SESSION['UserId'] ) );

		$sql = 'insert into ! ( userid, lastactivitytime ) values ( ?, ? )';

		$visittime=time();

		$db->query( $sql, array( ONLINE_USERS_TABLE, $_SESSION['UserId'], $visittime ) );

		$sql = "UPDATE ! SET lastvisit=? WHERE id=?";

		$db->query( $sql ,array( USER_TABLE, $visittime,$_SESSION['UserId'] ) );

		hasRight('');

		if ( $row['active'] != '1') {

			$err = NOT_ACTIVE;
			header( 'location:index.php?errid=' . $err );
			exit();

		}
		if ( $row['status'] == $lang['status_enum']['approval'] or $row['status'] == 'Pending' ) {

			$err = NOT_YET_APPROVED;
			header( 'location:index.php?errid=' . $err );
			exit();

		}

		header('Location: index.php');
//		include('index.php');
		exit;

	} else {

		$err = INVALID_USERNAME;

		setcookie("osdate_info", '', strtotime("+30day"), "/" );

	}

}
header( 'location:index.php?page=login&errid=' . $err );
exit();
?>