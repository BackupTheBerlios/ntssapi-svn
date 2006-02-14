<?php
if ( !defined( 'SMARTY_DIR' ) )

	include_once( '../init.php' );

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'mship_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$vchat 					= $_POST['chat'] == 'on' ? 1 : 0;

$vforum 				= $_POST['forum'] == 'on' ? 1 : 0;

$vincludeinsearch 		= $_POST['includeinsearch'] == 'on' ? 1 : 0;

$vmessage 				= $_POST['message'] == 'on' ? 1 : 0;

$vuploadpicture 		= $_POST['uploadpicture'] == 'on' ? 1 : 0;

$vallowalbum 		= $_POST['allowalbum'] == 'on' ? 1 : 0;

$vuploadpicturecnt = $_POST['uploadpicturecnt'];

$vseepictureprofile 	= $_POST['seepictureprofile'] == 'on' ? 1 : 0;

$vfullsignup 			= $_POST['fullsignup'] == 'on' ? 1 : 0;

$vprice					= trim( $_POST['txtprice'] );

$vcurrency				= trim( $_POST['txtcurrency'] );

$vname					= trim( $_POST['txtname'] );

if( $vname == '' ) {

	$err = NO_NAME;

} elseif( $vprice == '' ) {

	$err = NO_PRICE;

} elseif( $vcurrency == '' ) {

	$err = NO_CURRENCY;

}

if ( $err != 0 ) {

	header( 'location:addmship.php?errid=' . $err );
	exit;

}

$sql = 'INSERT INTO ! ' .
" ( name, chat, forum, includeinsearch, message, uploadpicture, seepictureprofile, uploadpicturecnt, allowalbum, fullsignup, price,currency )
 VALUES (  '$vname', '$vchat', '$vforum', '$vincludeinsearch', '$vmessage', '$vuploadpicture', '$vseepictureprofile', '$vuploadpicturecnt', '$vallowalbum', '$vfullsignup', '$vprice', '$vcurrency' )";

$db->query( $sql, array( MEMBERSHIP_TABLE ) );

$id = getLastId( MEMBERSHIP_TABLE );

$sql = 'UPDATE ! SET roleid = ? WHERE id = ?';

$db->query( $sql, array( MEMBERSHIP_TABLE, $id, $id ) );

header( 'location:membership.php' );
?>