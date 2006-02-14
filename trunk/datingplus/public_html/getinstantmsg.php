<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$sql = 'SELECT * FROM ! WHERE ( unix_timestamp() - sendtime ) > 600';

$delayedMsgs = $db->getAll( $sql, array( INSTANT_MESSAGE_TABLE ) );

if( sizeof( $delayedMsgs) > 0 ) {

	foreach( $delayedMsgs as $msg ){

		$sql = 'insert into ! ( senderid, recipientid, subject, message, sendtime, folder ) values ( ?, ?, ?, ?, ?, ? )';

		// maybe allow subject lines later?

		$db->query( $sql, array( $msg['senderid'], $msg['recipientid'], 'Subject', $msg['message'], time(), 'inbox' ) );

		$sql = 'delete from ! where id = ?';

		$db->query( $sql, array( INSTANT_MESSAGE_TABLE, $msg['id'] ) );
	}
}

$sql = 'select * from ! where pingflag = ? and recipientid = ? order by id limit 0, 1';

$row = $db->getRow( $sql, array( INSTANT_MESSAGE_TABLE, 0, $_SESSION['UserId'] ) );

if ( $row ) {
	$sql = 'UPDATE ! SET pingflag = ? WHERE id = ?';

	$db->query( $sql, array( INSTANT_MESSAGE_TABLE, 1, $row['id'] ) );

	print( '&found=yes&ids='.$row['id']."&sql=$sql" );

}
else {
	print('&found=no&');
}

?>