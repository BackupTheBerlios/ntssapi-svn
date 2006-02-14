<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$t->assign( 'title', $lang['site_links']['invite_a_friend'] );

if ( $config['use_popups'] == 'N' ) {

	$t->assign('rendered_page', $t->fetch('tellafriend.tpl') );
	$t->display ( 'index.tpl' );
}
else {
	$t->display( 'tellafriend.tpl' );
}
?>