<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$t->assign( 'errmsg', $lang['letter_errormsgs'][$_GET['errid']] );

$t->assign('rendered_page', $t->fetch('forgotpass.tpl') );

$t->display( 'index.tpl' );
?>