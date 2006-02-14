<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

if (isset($_SESSION['AdminId'])) {
	header("location: panel.php");
	exit;
}

$t->assign ( 'lang', $lang );

$t->assign ( 'login_error', $lang['errormsgs'][$_GET['errid']] );

$t->assign('rendered_page', $t->fetch('admin/statistics.tpl'));

$t->display ( 'admin/index.tpl' );

?>
