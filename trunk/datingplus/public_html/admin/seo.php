<?php 

if ( !defined( 'SMARTY_DIR' ) ) {

	include_once( '../init.php' );	
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'seo_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

		
$t->assign ( 'lang', $lang );

$sql = 'SELECT config_variable, config_value FROM ! WHERE config_variable = ?';

$row = $db->getRow( $sql, array( CONFIG_TABLE, 'site_title' ) );

$t->assign( 'site_title', $row['config_value'] );

$row = $db->getRow( $sql, array( CONFIG_TABLE, 'meta_description') );

$t->assign( 'meta_description', $row['config_value'] );

$row = $db->getRow( $sql, array( CONFIG_TABLE, 'meta_keywords') );

$t->assign( 'meta_keywords', $row['config_value'] );

$row = $db->getRow( $sql, array( CONFIG_TABLE, 'enable_mod_rewrite') );

$t->assign( 'enable_mod_rewrite', $row['config_value'] );

$t->assign('rendered_page', $t->fetch('admin/seo.tpl'));

$t->display ( 'admin/index.tpl' );
	
?>