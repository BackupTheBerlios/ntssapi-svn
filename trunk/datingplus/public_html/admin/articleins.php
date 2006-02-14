<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'article_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$t->assign( 'error_msg', $lang['artile_error'][ $_GET['errid'] ] );
		
$t->assign('rendered_page', $t->fetch('admin/articleins.tpl'));
		
$t->display( 'admin/index.tpl' );

exit;
?>