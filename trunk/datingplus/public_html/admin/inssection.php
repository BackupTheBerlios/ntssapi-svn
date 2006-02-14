<?php
if ( !defined( 'SMARTY_DIR' ) ){
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'section_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$section = trim( $_POST['txtsection'] );

$enabled = trim( $_POST['txtenabled'] );

$err = 0;

if ( $section == '' ) {

	 $err = SECTION_BLANK;	// change to a constant later
}

if ( $err != 0 ) {

	header ( 'location:section.php?insert=1&errid=' . $err );
	exit;
}

$sqlins = "INSERT INTO ! (section, enabled ) VALUES (  ?, ? )";

$result = $db->query( $sqlins, array( SECTIONS_TABLE, $section, $enabled ) );

header ( 'location:section.php' );
?>