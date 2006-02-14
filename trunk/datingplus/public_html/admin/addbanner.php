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

$t->assign('rendered_page', $t->fetch('admin/addbanner.tpl'));

$t->display( 'admin/index.tpl' );

exit;

?>