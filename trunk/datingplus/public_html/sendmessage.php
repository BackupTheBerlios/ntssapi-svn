<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

if( $_POST['frm'] == 'frmCompose' ){

	if ( $_SESSION['UserId'] != '' ) {

		$sql = 'select id from ! where username = ?';

		$row = $db->getRow( $sql, array( USER_TABLE, $_POST['txtusername'] ) );

		if( $row['id'] ) {

			$sql = 'insert into ! ( senderid, recipientid, subject, message, sendtime ) values ( ?, ?, ?, ?, ? )';

			$db->query( $sql, array( MAILBOX_TABLE, $_SESSION['UserId'], $row['id'], $_POST['txtsubject'], $_POST['txtmessage'], time() ) );

			$sql = 'insert into ! ( senderid, recipientid, subject, message, sendtime, folder ) values ( ?, ?, ?, ?, ?, ? )';

			$db->query( $sql, array( MAILBOX_TABLE, $_SESSION['UserId'], $row['id'], $_POST['txtsubject'], $_POST['txtmessage'], time(), 'sent_item' ) );
		} else {
			$err = INVALID_USERNAME;	// change to constant later
			$t->assign( 'err', $err );
		}

	} else {

		$err = NOT_LOGGED_IN;	// change to constant later
		$t->assign( 'err', $err );
	}

	$t->assign( 'lang', $lang );
	
	$t->assign('rendered_page', $t->fetch('sendmessage.tpl') );

	$t->display( 'index.tpl' );

}
else {

	$sql = 'select count(*) from ! where ( ( recipientid = ? and folder = ? ) or ( senderid = ? and folder = ? ) ) and flagdelete = ?';

	$delmsg = $db->getOne( $sql, array( MAILBOX_TABLE, $_SESSION['UserId'], 'inbox', $_SESSION['UserId'], 'send_item', 1 ) );

	$t->assign( 'deletemsg', $row['delmsg'] );

	$t->assign( 'lang', $lang );
	$t->assign('rendered_page', $t->fetch('sendmessage.tpl') );

	$t->display( 'index.tpl' );
}

?>