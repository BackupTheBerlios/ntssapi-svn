<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$t->assign('rendered_page',$t->fetch('signupsuccess.tpl'));

$t->display( 'index.tpl' );

?>
