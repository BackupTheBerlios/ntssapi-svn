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
	
		
foreach( $_POST as $arr ) {

	foreach ( $arr as $rec ) {
	
		$sqlupd = 'UPDATE ! SET section = ?,  enabled = ? WHERE id = ?';
						
		$result = $db->query ( $sqlupd, array( SECTIONS_TABLE,$rec[1], $rec[2], $rec[0] ) );		
	}
}

header ( 'location:section.php' );
?>