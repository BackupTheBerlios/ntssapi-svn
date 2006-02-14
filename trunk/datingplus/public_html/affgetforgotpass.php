<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$email = trim( $_POST['txtemail'] );

if ( $email == '' ) {
	header( 'location:affforgotpass.php?errid=1' );
	exit;

}

$row = $db->getRow( 'SELECT name, email, password FROM ! WHERE email = ? limit 0,1' ,array( AFFILIATE_TABLE, $email ));

if ( $row ) {

	//Generate Password
	$chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz';

	$pwd = '';

	for( $i=0; $i<8; $i++ ) {

		$rand = rand(0,strlen($chars));

		$pwd .= $chars{$rand};
	}

	$p = md5( $pwd );

	$sql = 'UPDATE ! SET password = ? WHERE email = ?';

	$db->query( $sql, array(AFFILIATE_TABLE, $p, $email ));

	$sql = 'SELECT subject, bodytext FROM ! WHERE id = ?';

	$rowletter = $db->getRow( $sql, array( ADMIN_LETTER_TABLE, '3' ));

	if ( !$rowletter['subject'] ) {

		header( 'location:affforgotpass.php?errid='.INVALID_EMAIL );
		exit;

	}
	else {

		$subject = $rowletter['subject'];

		$body = $rowletter['bodytext'];

		$name = $row['name'];

		$body = str_replace( '<Name>,', $name , $body );

		$body = str_replace( '<ID>',  $row['email'] , $body );

		$body = str_replace( '<Password>', $pwd, $body );

		$loginpage = 'http://' . $_SERVER['SERVER_NAME'] . '/' . DOC_ROOT ;

		$body = str_replace( '<LoginLink>',  $loginpage , $body );

		$body = str_replace( '<SiteTitle>',  $lang['site_name'] , $body );

		//Send password in mail
/*		$mail->Host     = SMTP_HOST;

		$mail->Mailer   = MAIL_TYPE;

		$mail->SMTPAuth = SMTP_AUTH;

		$mail->Username = SMTP_USER;

		$mail->Password = SMTP_PASS;
*/
		$header['To'] = $email;
		$header['From'] = $config['admin_email'];
		$header['Subject'] = $subject;
		$mail_object =& Mail::factory( MAIL_TYPE, $params );
		$mail_object->send( $email, $header, $body );

		if( $mail->Send() ) {

			header( 'location:affforgotpass.php?errid='.ALL_OK );
			exit;

		}
		else {
			header( 'location:affforgotpass.php?errid='.EMAIL_PROBLEM );
			exit;

		}

	}

}
else {

		header( 'location:affforgotpass.php?errid='.NOT_REGISTERED );
		exit;

}
?>