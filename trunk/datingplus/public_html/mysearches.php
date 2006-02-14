<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include( 'sessioninc.php' );

include('state_codes.php');

$t->assign('lang', $lang);

$sql = 'SELECT * FROM ! WHERE userid = ?';

$data = $db->getAll( $sql, array( USER_SEARCH_TABLE, $_SESSION['UserId'] ) );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('mysearches.tpl') );

$t->display( 'index.tpl' );
?>