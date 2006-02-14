<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'poll_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}


$pollid = $_POST['txtpollid'];

$pollopt = $_POST['txtpolloption'];

$enabled = $_POST['txtenabled'];

$answer = ( $answer == 'Y' ) ? 1 : 0 ;

$sql = 'INSERT INTO ! (  pollid, opt, enabled ) VALUES ( ?, ?, ?  )';

$db->query( $sql, array( POLLOPTS_TABLE,  $pollid, $pollopt, $enabled ) );

header( 'location:polloptions.php?pollid=' . $pollid );

exit;
?>