<?php

if( !defined( 'SMARTY_DIR' ) ) {
	require_once( 'init.php' );
}

$sql = 'select * from ! where enabled = ? and active = ? order by date desc';

$data = $db->getAll( $sql, array( POLLS_TABLE, 'Y', '0' ) );

$t->assign( 'data', $data);

$t->assign( 'title', $lang['view_poll_archive']);

$t->display( 'previouspolls.tpl' );

?>

