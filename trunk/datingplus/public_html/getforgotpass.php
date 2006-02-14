<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$email = trim( $_POST['txtemail'] );

if ( $email == '' ) {

	header( 'location:forgotpass.php?errid=1' );
	exit;
}

$sql = 'SELECT username, firstname, lastname, password FROM ! WHERE email = ? limit 0,1';

$row = $db->getRow( $sql, array( USER_TABLE, $email ) );

if ( $row ) {

	$chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz';

	$pwd = '';

	for( $i = 0; $i < 8; $i++ ) {

		$rand = rand( 0, strlen( $chars ) );
		$pwd .= $chars{$rand};
	}

	$p = md5( $pwd );

	$sql = 'UPDATE ! SET password = ? WHERE email = ? AND username = ?';

	$db->query( $sql, array( USER_TABLE, $p, $email, $row['username'] ) );

	$sql = 'SELECT subject, bodytext FROM ! WHERE id = ?';

	$rowletter = $db->getRow( $sql, array( ADMIN_LETTER_TABLE, '3' ) );

	if ( !$rowletter ) {

		header( 'location:forgotpass.php?errid='.NO_TEMPLATE );
		
		exit;
	} else {
		$subject = $rowletter['subject'];

		$body = $rowletter['bodytext'];

		$name = $row['firstname'] ;

		$body = str_replace( '<Name>,', $name , $body );

		$body = str_replace( '<ID>',  $row['username'] , $body );

		$body = str_replace( '<Password>', $pwd, $body );

		$loginpage = 'http://' . $_SERVER['SERVER_NAME']  . DOC_ROOT ;

		$body = str_replace( '<LoginLink>',  $loginpage , $body );

		$body = str_replace( '<SiteTitle>',  $lang['site_name'] , $body );

		$headers['From']    = $config['admin_name'] . ' <' . $config['admin_email'] . '>';
		$headers['To']      = $name . ' <' . $email . '>';
		$headers['Subject'] = $subject;

		// to change later - add this email text to $lang

		$mail_object =& Mail::factory( MAIL_TYPE, $params );
		$success = $mail_object->send( $email, $headers, $body );

		if( $success ) {
			header( 'location:forgotpass.php?errid='.PASSWORD_MAIL_SENT );
			exit;
		}
		else {
			header( 'location:forgotpass.php?errid='.MAIL_ERROR );
			exit;
		}
	}
}
else {
		header( 'location:forgotpass.php?errid='.NOT_REGISTERED );
		exit;
}
?>