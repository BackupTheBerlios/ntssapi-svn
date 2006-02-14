<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$sname = trim( $_POST['txtsendername'] );
$semail = trim( $_POST['txtsenderemail'] );
$femail = trim( $_POST['txtrcpntemail'] );

// fix this file later
/*
if ( $sname || $semail || $femail ) {

	echo $lang['taf_errormsgs'][1] ;
	exit;
}
*/

$sql = 'select subject, bodytext from ! where id = ?';

$rowletter = $db->getRow( $sql, array( ADMIN_LETTER_TABLE, 2 ) );

if ( !$rowletter ) {

	$t->assign('msg', ($lang['taf_errormsgs'][2]) ) ;

} else {

	$subject = $rowletter['subject'];
	$body = $rowletter['bodytext'];

	$link = 'http://' . $_SERVER['SERVER_NAME'] . DOC_ROOT ;

	$body = str_replace( '#Link#',  $link , $body );
	$body = str_replace( '#FromName#',  $sname , $body );

	$headers['From']    = $sname . ' <'. $semail . '>';
	$headers['Subject'] = $subject;
	$headers['To'] = $femail;

	$mail_object =& Mail::factory( MAIL_TYPE, $params );

	$success = $mail_object->send( $femail, $headers, $body );

	if( $success ) {
		$t->assign('msg', $lang['taf_errormsgs'][0] );
	} else {
		$t->assign('msg', $lang['taf_errormsgs'][3] );
	}
}

$t->display('tellafriend.tpl');
?>