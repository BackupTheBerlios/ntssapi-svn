<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$cmd = $_POST['cmd'];

if( $cmd == 'posted' ){

	$txttitle = trim($_POST['txttitle']);
	$txtname = trim($_POST['txtname']);
	$txtemail = trim($_POST['txtemail']);
	$txtcountry = trim($_POST['txtcountry']);
	$txtcomments = trim($_POST['txtcomments']);

	$headers['From']    = $config['admin_email'];
	$headers['To']      = $config['feedback_email'];
	$headers['Subject'] = $lang['email_feedback_subject'];

	// to change later - add this email text to $lang
	// also change to xhtml

	$message = "Dear Site Administrator,<br><br>";
	$message .= "You have just received comments from a visitor to your dating site. The details are as follows:<br><br>";
	$message .= "Title: $txttitle<br>";
	$message .= "Name: $txtname<br>";
	$message .= "Email: $txtemail<br>";
	$message .= "Country: " . $lang['countries'][$txtcountry] . "<br>";
	$message .= "Comments: $txtcomments<br><br>";
	$message .= "Thanks,<br>";
	$message .= $lang['site_name'] . " Daemon<br><br>";
	$message .= 'Note: This is a system generated message. If you have received it by mistake, please ignore it.';

	// if non-html email, replace <br> with \n
	// to fix later: html email not handled correctly by Pear Mail class

	if ( MAIL_FORMAT == 'text' ) {
		$message = str_replace( '<br>', "\n", $message );
	}

	$mail =& Mail::factory( MAIL_TYPE, $params );

	if ( $mail->send( $txtemail, $headers, $message ) ) {
		$t->assign( 'success', true );
	}

}

$t->assign('rendered_page', $t->fetch('feedback.tpl') );

$t->display( 'index.tpl' );
exit;
?>