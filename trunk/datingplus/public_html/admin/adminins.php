<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'admin_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$t->assign( 'error_msg', $lang['admin_error'][ $_GET['errid'] ] );

$t->assign('rendered_page', $t->fetch('admin/adminins.tpl'));
		
$t->display( 'admin/index.tpl' );

exit;
?>