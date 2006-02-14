<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

// rewrite later

$sql = 'SELECT im.*, user.id, user.firstname, user.lastname, user.username FROM ! user INNER JOIN ! im ON im.senderid = user.id WHERE im.recipientid = ? AND im.id = ?';

$row = $db->getRow( $sql, array( USER_TABLE, INSTANT_MESSAGE_TABLE,  $_SESSION['UserId'], $_GET['id']) );

if( $row ) {

	$sql = 'delete from ! where recipientid = ? and id = ?';

	$db->query( $sql, array( INSTANT_MESSAGE_TABLE, $_SESSION['UserId'], $_GET['id'] ) );

	$row['message'] = stripslashes( $row['message'] );

	$t->assign( 'data', $row);

} else {

	$t->assign ( 'errid', NO_MESSAGE );// change to a constant later

}

$t->display( 'showinstantmsg.tpl' );

exit;

?>