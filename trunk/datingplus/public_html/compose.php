<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

if( isset( $_POST['frm'] ) && $_POST['frm'] == 'frmCompose' ){

	if ( isset( $_SESSION['UserId'] ) && $_SESSION['UserId'] != '' ) {

		$sql = 'INSERT INTO ! (senderid, recipientid, subject, message, sendtime) values(?, ?, ?, ?, ?)';

		$db->query( $sql, array( MAILBOX_TABLE, $_SESSION['UserId'], $_POST['txtrecipient'], $_POST['txtsubject'], $_POST['txtmessage'], time() ) );

		$sql = 'INSERT INTO ! (senderid, recipientid, subject, message, sendtime, folder) values(?, ?, ?, ?, ?, ?)';

		$db->query( $sql, array( MAILBOX_TABLE, $_SESSION['UserId'], $_POST['txtrecipient'], $_POST['txtsubject'], $_POST['txtmessage'], time(), 'sent_item' ) );

		echo '<script language="JavaScript" type="text/javascript">window.close();</script>';

	}
	else{
		echo '<script language="JavaScript" type="text/javascript">window.opener.location="index.php?page=login";
		window.close();</script>';
	}

} elseif ( $_GET['recipient'] != '' && (int)$_GET['recipient'] ) {

	$sql = 'SELECT username, firstname, lastname FROM ! WHERE id = ?';

	$row = $db->getRow( $sql, array( USER_TABLE, $_GET['recipient'] ) );

	if ( $row ) {
		$t->assign( 'user', $row );
	} else {
		echo '<script language="JavaScript" type="text/javascript">window.close();</script>';
		exit;
	}

	$t->display ( 'compose.tpl' );
}
?>