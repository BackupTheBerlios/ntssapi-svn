<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

if ( isset( $_GET['errid'] ) ) {

	$t->assign ( 'pwd_change_error', $lang['errormsgs'][$_GET['errid']] );
}

$t->assign('rendered_page', $t->fetch('changempass.tpl') );

$t->display ( 'index.tpl' );


?>