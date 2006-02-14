<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$t->assign( 'page', $_GET['page'] );
$t->assign( 'sectionid', $_GET['section'] );
$t->assign('rendered_page',$t->fetch('success.tpl'));

$t->display( 'index.tpl' );

?>
