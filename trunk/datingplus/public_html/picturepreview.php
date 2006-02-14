<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

if( (int)$_GET['id'] ){

	$sql = 'SELECT username FROM ! WHERE id = ?';

	$username = $db->getOne( $sql, array( USER_TABLE, $_GET['id'] ) );

	$t->assign( 'username', $username );

	$t->assign('rendered_page', $t->fetch('picturepreview.tpl') );

	$t->display( 'index.tpl' );
}

?>
