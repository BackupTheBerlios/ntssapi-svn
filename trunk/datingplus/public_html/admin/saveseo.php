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


$mod_rewrite = $_POST['txtseo'];

$title = $_POST['txttitle'];

$title = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $title );

$desc = $_POST['txtdesc'];

$desc = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $desc );

$keywords = $_POST['txtkeyword'];

$keywords = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $keywords );

$sql = 'UPDATE ! SET config_value = ? WHERE config_variable = ?';
		
$db->query( $sql, array(CONFIG_TABLE, $mod_rewrite, 'enable_mod_rewrite') );	

$db->query( $sql, array(CONFIG_TABLE, $title, 'site_title') );	
		
$db->query( $sql, array(CONFIG_TABLE, $desc, 'meta_description') );	

$db->query( $sql, array(CONFIG_TABLE, $keywords, 'meta_keywords') );	

header( 'location:seo.php' );

?>