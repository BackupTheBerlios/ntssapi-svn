<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

/*
$data['title'] = $lang['memberpanel'];

$t->assign('data',$data);

$t->assign('rendered_page', $t->fetch('memberpanel.tpl') );

$t->display ( 'index.tpl' );
*/

header("location: index.php");
exit;
?>