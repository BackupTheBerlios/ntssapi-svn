<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'change_pwd' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

if ( isset( $_GET['errid'] ) ) {

	$t->assign ( 'pwd_change_error', $lang['admin_error'][$_GET['errid']] );
}

$t->assign('rendered_page', $t->fetch('admin/changepwd.tpl'));
		
$t->display ( 'admin/index.tpl' );

?>