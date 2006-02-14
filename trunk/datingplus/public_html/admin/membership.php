<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'mship_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

//default membership level
$mid = 1;

if ( $_POST['modify'] ) {

	$vchat 					= $_POST['chat'] == 'on' ? 1 : 0;

	$vforum 				= $_POST['forum'] == 'on' ? 1 : 0;

	$vincludeinsearch 		= $_POST['includeinsearch'] == 'on' ? 1 : 0;

	$vmessage 				= $_POST['message'] == 'on' ? 1 : 0;

	$vuploadpicture 		= $_POST['uploadpicture'] == 'on' ? 1 : 0;

	$vseepictureprofile 	= $_POST['seepictureprofile'] == 'on' ? 1 : 0;

	$vfavouritelist 	= $_POST['favouritelist'] == 'on' ? 1 : 0;

	$vsendwinks 	= $_POST['sendwinks'] == 'on' ? 1 : 0;

	$vextsearch 	= $_POST['extsearch'] == 'on' ? 1 : 0;

	$vfullsignup 			= $_POST['fullsignup'] == 'on' ? 1 : 0;

	$vuploadpicturecnt = $_POST['uploadpicturecnt'];

	$vallowalbum = 	$_POST['allowalbum'] == 'on' ? 1: 0;

	$vallowim = 	$_POST['allowim'] == 'on' ? 1: 0;

	$vprice					= $_POST['txtprice'];

	$vcurrency				= $_POST['txtcurrency'];

	$vname					= $_POST['txtname'];

	$activedays			= $_POST['activedays'];

	$event_mgt 			= $_POST['event_mgt'] == 'on' ? 1: 0;

	$mid = $_POST['mshipid'];


	$sql = 'UPDATE ! ' .
	" SET	name				= '$vname',
			chat 				= '$vchat',
			forum				= '$vforum',
			includeinsearch		= '$vincludeinsearch',
			message				= '$vmessage',
			uploadpicture		= '$vuploadpicture',
			uploadpicturecnt 	= '$vuploadpicturecnt',
			allowalbum 			= '$vallowalbum',
			allowim 			= '$vallowim',
			seepictureprofile	= '$vseepictureprofile',
			favouritelist		= '$vfavouritelist',
			sendwinks			= '$vsendwinks',
			extsearch			= '$vextsearch',
			fullsignup			= '$vfullsignup',
			price				= '$vprice',
			currency			= '$vcurrency',
			activedays			= '$activedays',
			event_mgt			= '$event_mgt'
			WHERE roleid = ? AND id = ?";

	 $db->query( $sql, array( MEMBERSHIP_TABLE, $_POST['mshipid'], $_POST['id']) );

} elseif( $_POST['enable'] ) {

	 $sql = 'UPDATE ! SET enabled = ? WHERE id = ?';

	 $db->query( $sql, array( MEMBERSHIP_TABLE, 'Y', $_POST['id']) );

} elseif( $_POST['disable'] ) {

	 $sql = 'UPDATE ! SET enabled = ? WHERE id = ?';

	 $db->query( $sql, array( MEMBERSHIP_TABLE, 'N', $_POST['id']) );

} elseif( $_POST['delete'] ) {

	 $sql = 'DELETE FROM !  WHERE id =?';

	 $db->query( $sql, array( MEMBERSHIP_TABLE ,$_POST['id'] ) );

	 $mid = $db->getOne('select id from ! limit 1', array( MEMBERSHIP_TABLE) );
}

if ( $_POST['membership'] ) {

	$mid = $_POST['membership'];

}

$data = array();

$row = $db->getRow( 'SELECT * FROM ! WHERE roleid = ?', array(MEMBERSHIP_TABLE, $mid) );

$t->assign( 'data', $row );

$roles = array();

$rs = $db->getAll( 'SELECT roleid, name FROM !',array( MEMBERSHIP_TABLE ) );

foreach ( $rs as $row ) {

	$roles[$row['roleid']] = $row['name'];
}

$t->assign( 'memberships', $roles );

$t->assign('rendered_page', $t->fetch('admin/membership.tpl'));

$t->display( 'admin/index.tpl' );
?>