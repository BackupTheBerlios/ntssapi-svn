<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

if( $_POST['frm'] == 'frmGroupMail' ) {

	$arr = $_POST['txtcheck'];

	if( $_POST['groupaction'] == $lang['delete'] ) {

		if( is_array( $_POST['txtcheck'] ) AND count( $_POST['txtcheck'] ) ) {

				foreach( $arr as $id) {

					$sql = 'update ! set flagdelete = ? where id = ? and recipientid = ? and folder = ?';

					$db->query( $sql, array( MAILBOX_TABLE, 1, $id, $_SESSION['UserId'], 'inbox' ) );
				}
		}
	} elseif( $_POST['groupaction'] == $lang['read'] ) {

		foreach( $arr as $id ) {

			$sql = 'update ! set flagread = ? where id = ? and recipientid = ? and folder = ?';

			$db->query( $sql, array( MAILBOX_TABLE, 1, $id, $_SESSION['UserId'], 'inbox' ) );
		}
	} elseif( $_POST['groupaction'] == $lang['unread'] ) {

		foreach( $arr as $id ) {

			$sql = 'update ! set flagread = ? where id = ? and recipientid = ? and folder = ?';

			$db->query( $sql, array( MAILBOX_TABLE, 0, $id, $_SESSION['UserId'], 'inbox' ) );
		}
	}

	header( 'Location:mailmessages.php?sort='. $_GET['sort'] . '&type=' . $_GET['type'] );
	exit;
}

$sqlselect = ' user.username, user.firstname, user.lastname, msg.* ';

$sqlfrom = USER_TABLE . ' user INNER JOIN ' . MAILBOX_TABLE . ' msg ON user.id=msg.senderid';

$sqlwhere = 'msg.recipientid=\'' . $_SESSION['UserId'] . '\' and flagdelete=0 and folder=\'inbox\'';

$sqlorder = findSortBy( 'username' );

$sql = 'SELECT ' . 	$sqlselect .
	' FROM ' . 		$sqlfrom .
	' WHERE ' . 	$sqlwhere .
	' ORDER BY '. 	$sqlorder;

$data = $db->getAll( $sql );

//count number of mails in trash can

$sql = 'select count(*) from ! where ( ( recipientid = ? and folder = ? ) or ( senderid = ? and folder = ? ) ) and flagdelete = ?';

$delmsg = $db->getOne( $sql, array( MAILBOX_TABLE, $_SESSION['UserId'], 'inbox', $_SESSION['UserId'], 'sent_item', 1 ) );

$t->assign( 'deletemsg', $delmsg );
$t->assign( 'lang', $lang );
$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );
$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('mailmessages.tpl') );

$t->display ( 'index.tpl' );


?>