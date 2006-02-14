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

if ( $_POST['delaction'] == 'Yes' ) {

	$sqldel = 'DELETE FROM ! WHERE id = ?';

	$db->query( $sql, array( QUESTIONS_TABLE, $_POST['txtid'] ) );
}

header ( 'location:sectionquestions.php?sectionid=' . $_POST['sectionid'] );

?>