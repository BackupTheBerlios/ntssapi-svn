<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$t->assign('rendered_page', $t->fetch('searchprofile.tpl') );

$t->display( 'index.tpl' );

?>
