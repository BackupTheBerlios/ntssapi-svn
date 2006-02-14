<?php

if ( !defined( 'SMARTY_DIR' ) ){ 
	include_once( '../init.php' );
}

$t->assign('rendered_page', $t->fetch('admin/chatadmin.tpl'));
		
$t->display ( 'admin/index.tpl' );

?>
