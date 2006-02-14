<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$id = $_GET['id'];

$sql = 'SELECT * FROM ! WHERE id = ?';

$row = $db->getRow( $sql, array( BANNER_TABLE, $id ) );

if ( $row ) {
	$t->assign( 'banid', $row['id'] );
	$t->assign( 'bannerurl', $row['bannerurl'] );
	$t->assign( 'linkurl', $row['linkurl'] );
	$t->assign( 'tooltip', $row['tooltip'] );
}

$t->assign('rendered_page', $t->fetch('banner.tpl') );

$t->display( 'index.tpl' );
exit;
?>