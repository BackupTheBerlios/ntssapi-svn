<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'poll_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$pollid	= 	$_POST['txtpollid'];			

$optid	= 	$_POST['txtoptionid'];				

$option	= 	trim( $_POST['txtoption'] );

$answer	= 	$_POST['txtanswer'];	

$enable	= 	$_POST['txtenabled'];				


$err = 0;

if ( $option == '' ) {

	$err = OPTION_BLANK;

}

if ( $err != 0 ) {

	header ( 'location:polloptions.php?edit=$pollid&errid=' . $err );
	exit;

}

$option = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $option );

$sqlupd = 'UPDATE ! SET opt = ?, result = ?, enabled = ? WHERE optionid = ? AND pollid = ?';

$result = $db->query( $sqlupd, array( POLLOPTS_TABLE, $option, $answer,$enable, $optid, $pollid ) );

header ( 'location:polloptions.php?pollid=' . $pollid );
?>