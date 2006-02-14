<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'banner_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
	
}
	
//Delete Banner
if ( $_POST['txtid'] ) {

	$sql = 'DELETE FROM ! WHERE id = ?';
	
	$db->query( $sql, array( BANNER_TABLE, $_POST['txtid'] ) );

} elseif ( $_POST['enable'] ) {

	foreach( $_POST['txtcheck'] as $val ) {
	
		$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';
			
		$db->query( $sql, array( BANNER_TABLE, 'Y', $val ) );
	}
} elseif ( $_POST['disable'] ) {

	foreach( $_POST['txtcheck'] as $val ) {
		
		$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';
		
		$db->query( $sql, array( BANNER_TABLE, 'N', $val ) );
	}
} elseif( $_GET['edit'] ) {

	$sql = 'SELECT * FROM ! WHERE id = ?';
	
	$row = $db->getRow( $sql, array( BANNER_TABLE, $_GET['edit'] ) );
		
	$row['bannerurl'] = stripslashes( $row['bannerurl'] );

	$row['tooltip'] = stripslashes( $row['tooltip'] );	

	$dim = split( 'x', $row['size'] );

	$row['width'] = trim( $dim[0] );

	$row['height'] = trim( $dim[1] );	

	$row['type'] = substr( $row['name'], -3, 3 );	
	
	$t->assign( 'data', $row );
		
	$t->assign('rendered_page', $t->fetch('admin/banneredit.tpl'));
		
	$t->display( 'admin/index.tpl' );

	exit;
}
	
$sql = 'SELECT * FROM !';

$rs = $db->getAll( $sql, array( BANNER_TABLE ) );
	
$data = array();

foreach( $rs as $row ) {

	$row['bannerurl'] = stripslashes( $row['bannerurl'] );

	$dim = split( 'x', $row['size'] );

	$row['width'] = trim( $dim[0] );

	$row['height'] = trim( $dim[1] );	

	$row['type'] = substr( $row['name'], -3, 3 );

	$data[] = $row;
}

$t->assign( 'data', $data );
	
$t->assign('rendered_page', $t->fetch('admin/managebanner.tpl'));
		
$t->display( 'admin/index.tpl' );

exit;
?>