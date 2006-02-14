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

foreach( $_POST['txtid'] as $arr ) {

	$id = $arr;

	$sql = 'SELECT displayorder FROM ! WHERE id = ?';

	$displayorder = $db->getRow( $sql, array( SECTIONS_TABLE, $id ) );

	$sql = 'select max(displayorder) as maxorder from !';

	$maxorder = $db->getOne( $sql, array( SECTIONS_TABLE ) );

	//move the records below this record up
	$i = $displayorder['displayorder'] + 1;

	while ( $i <= $maxorder['maxorder'] ){

		$sql = 'UPDATE ! SET displayorder = ? WHERE displayorder = ?';

		$db->query( $sql, array( SECTIONS_TABLE, $i - 1, $i ) );

		$i++;
	}

	$sqldel = 'DELETE FROM ! WHERE id = ?';

	$db->query ( $sqldel, array( SECTIONS_TABLE, $id ) );
}

header ( 'location:section.php' );

?>