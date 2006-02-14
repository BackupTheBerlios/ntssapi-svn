<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

if( isset( $_POST['frm'] ) && $_POST['frm'] == 'frmAffSignup' ) {

	$name = trim( $_POST[ 'txtname' ] );
	$password = trim( $_POST[ 'txtconpassword' ] );
	$email = trim( $_POST[ 'txtemail' ] );
	$t->assign('txtname', $name);
	$t->assign('txtemail',$email);
	// change later

	if( !$name ) {

		header( 'location: affindex.php?error=' . MANDATORY_FIELDS );
		exit;

	} elseif ( !$password ) {

		header( 'location:affindex.php?error=' . MANDATORY_FIELDS );
		exit;

	} elseif( !$email ) {

		header( 'location:affindex.php?error=' . MANDATORY_FIELDS );
		exit;

	} elseif( !$password ) {

		header( 'location:affindex.php?error=' . MANDATORY_FIELDS );
		exit;

	} elseif( trim( $_POST['txtpassword'] ) != $password ){

		header( 'location:affindex.php?error=' . PASS_CONFIRMPASS);
		exit;

	}

	$sql = 'SELECT count(*) as aacount from ! where email = ?';

	$rowc = $db->getRow( $sql, array( AFFILIATE_TABLE, $email ) );

	if ( $rowc['aacount'] > 0 ) {

		header( 'location:affindex.php?error='.EMAIL_EXISTS);
		exit;
	}

	$status = $lang['status_enum']['approval'];

	$regdate = time();

	$password = md5($password);

	// the affiliate confirmation code - finish this for osdate 1.1.0 release
	$code = md5( microtime() );

	$sqlins = 'INSERT INTO ! ( name, email, password, status, regdate ) VALUES ( ?, ?, ?, ?, ? )';

	$result = $db->query ( $sqlins, array( AFFILIATE_TABLE, $name, $email, $password, $status, $regdate ) );

	$lastid = getLastId( AFFILIATE_TABLE );

	// send the affiliate email...

	/*
	$header['To'] = $email;
	$header['From'] = $config['admin_email'];
	$header['Subject'] = $lang['aff_email_subject'];

	$link = 'http://' . $_SERVER['SERVER_NAME'] . DOC_ROOT . 'affindex.php?confcode=' . $code;

	$body = str_replace( '#ConfirmationLink#',  $link , $body );

	$mail_object =& Mail::factory( MAIL_TYPE, $params );
	$mail_object->send( $email, $header, str_replace( '#ConfirmationLink#', $link, $lang['aff_email_body'] ) );
	*/

	$t->assign( 'affid', $lastid );

	$t->assign('rendered_page', $t->fetch('affsignupsuccess.tpl') );

	$t->display( 'index.tpl' );

	exit;
}

if( $_GET['error'] ) {

	$t->assign( 'error', $lang['affiliates_error'][(int)$_GET['error']] );

} else {

	$t->assign( 'error', '' );
}

$t->assign('rendered_page', $t->fetch('affindex.tpl') );

$t->display( 'index.tpl' );
?>