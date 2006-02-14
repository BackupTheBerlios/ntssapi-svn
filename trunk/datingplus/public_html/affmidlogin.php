<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

// to do: change error codes to PHP constants

if ($_POST['txtusername'] == '' or $_POST['txtpassword'] == '') {

	$err = MANDATORY_FIELDS;

} else {

	$sql = 'select id, name, status from ! where email = ? and password = ?';

	$row = $db->getRow( $sql, array( AFFILIATE_TABLE, $_POST['txtusername'],  md5( $_POST['txtpassword'] ) ) );

	if( $row ){

		if( $row['status'] == $lang['status_enum']['active'] ) {

			$_SESSION['AffId'] = $row['id'];

			$_SESSION['AffName'] = $row['name'];

			header('location:affpanel.php');
			exit();

		} elseif( $row['status'] == $lang['status_enum']['approval'] ) {

			$err = NOT_ACTIVE;

		} elseif( $row['status'] == $lang['status_enum']['rejected'] ) {

			$err = SUBMISSION_DECLINED;

		} elseif( $row['status'] == $lang['status_enum']['suspended'] ) {

			$err = ACCOUNT_SUSPENDED;
		}

	} else {

		$err = INVALID_LOGIN;

	}
}

header( 'location:afflogin.php?errid=' . $err );
exit();

?>