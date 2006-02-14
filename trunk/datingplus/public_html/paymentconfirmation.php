<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

$sql = 'SELECT roleid, name, price, currency FROM ! WHERE roleid = ?';

$row = $db->getRow( $sql, array( MEMBERSHIP_TABLE, $_POST['membership'] ) );

$t->assign( 'item_no', $row['roleid'] );
$t->assign( 'item_name', $row['name'] );
$t->assign( 'amount', $row['price'] );
$t->assign( 'currency', $row['currency'] );

if ( strtolower( $_POST['payment'] ) == 'free' ) {

	if ( $_POST['membership'] == 4 ) {
	
		$t->assign('rendered_page', $t->fetch('free_checkout.tpl') );

		$t->display( 'index.tpl' );

	} else {

		header( 'location:payment.php?err=' . $lang['mship_errors'][4] );

		exit;
	}
} 
else {
	$payment = $_POST['payment'];

	if( $payment == '' ) {

		header( 'location:payment.php?err=' . $lang['signup_js_errors']['select_payment'] );

	}
	
	require( 'modules/payment/'.$payment.'.php');

  $paymod = new $payment;
	
	$paymod->process_button();
	
	$t->display( 'index.tpl' );
	
}

?>
