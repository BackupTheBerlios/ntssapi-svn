<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$t->assign ( 'login_error', $lang['errormsgs'][$_GET['errid']] );

$t->assign('rendered_page', $t->fetch('login.tpl') );

$t->display( 'index.tpl' );
?>