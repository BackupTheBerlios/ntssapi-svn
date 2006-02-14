<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'section_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$id = trim( $_POST['txtid'] );

$section = trim( $_POST['txtsection'] );

$enabled = trim( $_POST['txtenabled'] );

$err = 0;

if ( $section == '' ) {
	$err = SECTION_BLANK;
}

if ( $err != 0 ) {

	header ( 'location:section.php?edit=' . $_POST['txtid'] . '&errid=' . $err );
	exit;
}

$sqlupd = 'UPDATE ! SET section = ?, enabled = ? WHERE id = ?';

$result = $db->query( $sqlupd, array( SECTIONS_TABLE, $section, $enabled, $id  ) );

header ( 'location:section.php' );
?>