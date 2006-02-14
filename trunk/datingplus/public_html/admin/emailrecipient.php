<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'send_letter' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

if( $_POST['frm'] != 'frmSend' ) {

	$_SESSION['letterid'] = $letterid = $_POST['txttitle'];

	$_SESSION['fromname'] = $from = $_POST['txtsendname'];

	$_SESSION['from'] = $from = $_POST['txtfrom'];

	$_SESSION['subject'] = $subject = $_POST['txtsubject'];

	$_SESSION['message'] = $message = $_POST['txtmessage'];

	$_SESSION['save'] = $save = $_POST['txtsave'];

	$_SESSION['name'] = $name = $_POST['txtname'];

	if( $save == 'yes' ){

		$sql = 'insert into ! ( title, subject, modify, bodytext ) values ( ?, ?, ?, ? )';

		$db->query( $sql, array( ADMIN_LETTER_TABLE, $name, $subject, '133', $message ) );
	}
} else {

	$options = array();

	if( $_POST['userrange'] == 'all') {

		$sql = 'SELECT * FROM ' . USER_TABLES;
	}
	elseif( $_POST['userrange'] == 'selected' ) {

		$sql = 'SELECT * FROM ' . USER_TABLES;
	}
	elseif( $_POST['userrange'] == 'level' ) {

		$sql = 'SELECT * FROM ' . USER_TABLES;

		$options []= 'level = ' . $_POST['txtlevel'];
	}

	foreach( $_POST['txtfilteruser'] as $filter){

		if ( $filter == 'gender' ) {
			$options []= " gender = '" . $_POST['txtgender'] . "'";
		}

		if ( $filter == 'location' ) {
			$options []= " country = '" . $_POST['txtcountry'] . "'";
		}

		if ( $filter == 'age' ) {
			$options []= ' age between ' . $_POST['txtagestart'] . ' and ' . $_POST['ttxtageend'];
		}
	}

	if ( sizeof( $options ) > 0 ) {
		$sql = $sql . ' where ' . implode( ' and ', $options );
	}

	$data = $db->getAll( $sql );

	$headers['From']    = $_SESSION['fromname'] . ' <'. $_SESSION['from'] .'>';
	$headers['Subject'] = $_SESSION['subject'] ;

	foreach( $data as $index => $user ) {

		$headers['To'] = $user['email'];

		$mail_object =& Mail::factory( MAIL_TYPE, $params );
		$mail_object->send( $user['email'], $headers, $_SESSION['message'] );
	}
}

$t->assign('rendered_page', $t->fetch('admin/emailrecipient.tpl'));
		
$t->display( 'admin/index.tpl' );
exit;

?>