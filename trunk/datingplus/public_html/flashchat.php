<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$t->assign('rendered_page', $t->fetch('flashchat.tpl') );

$t->display ( 'index.tpl' );

?>
