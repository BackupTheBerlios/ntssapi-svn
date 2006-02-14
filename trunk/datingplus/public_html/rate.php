<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once ( 'init.php' );
}

$arr = array();

for( $i = 0 $i <= 9; $i++ ) {
	$arr[$i] = $i;
}

$t->assign ( 'rate_values', $arr );

$t->assign('rendered_page', $t->fetch('rate.tpl') );

$t->display ( 'index.tpl' );
?>