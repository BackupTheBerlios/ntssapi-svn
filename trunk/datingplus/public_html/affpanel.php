<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include_once( 'affsessioninc.php' );

$sql = 'SELECT count(*) as acount FROM ! where affid = ?';

$acount = $db->getOne( $sql, array( AFFILIATE_REFERALS_TABLE, $_SESSION['AffId' ] ) );

$sql = 'SELECT count(*) as num2 FROM ! where affid = ? and userid <> ?' ;

$num2 = $db->getOne( $sql, array( AFFILIATE_REFERALS_TABLE, $_SESSION['AffId'], 0  ) );

$t->assign ( 'refcounter', $acount );
$t->assign ( 'profcounter', $num2 );

$t->assign( 'rendered_page', $t->fetch( 'affpanel.tpl' ) );

$t->display ( 'index.tpl' );

?>