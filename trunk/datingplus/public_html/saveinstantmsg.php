<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$id = $_POST['recipientid'];

/*
$msg = ( !get_magic_quotes_gpc() ) ? addslashes($_POST['msg']) : $_POST['msg'];
*/

$msg = $_POST['msg'];

if( $_SESSION['UserId'] && (int)$id && $msg ) {

	$sql = 'insert into ! ( senderid, recipientid, message, sendtime ) values ( ?, ?, ?, ? )';

	$db->query( $sql, array( INSTANT_MESSAGE_TABLE, $_SESSION['UserId'], $id, $msg, time() ) );

	if( $_POST['page'] == 'showmessage' ) {
		echo '<script language="javascript" type="text/javascript">window.close();</script>';
		exit;
	}

	print('&gb_status=yes&');
	print("&sql=$sql&");

}
else {
	print('&gb_status=no');
	print("&gb_id=id");
	print("&gb_msg=msg&");
}
?>
