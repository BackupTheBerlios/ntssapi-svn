<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include( 'sessioninc.php' );

$valid = false;

if ( $_POST['txn_id'] ) { // PAYPAL

	$txn_id 		= $_POST['txn_id'];
	$total 			= $_POST['payment_gross'];
	$email			= $_POST['payer_email'];

	// check to see if payment is pending
	if ( $_POST['payment_status'] == 'Completed' ) {
		$valid = true;
	}
}
else if ( $_POST['order_number'] ) { // 2CHECKOUT.COM

	$txn_id			= $_POST['cart_order_id'];
	$total			= $_POST['total'];
	$email			= $_POST['email'];

	// check to see if payment is pending
	if ( $_POST['credit_card_processed'] != 'Y' ) {
		$valid = true;
	}
}
else if ( $_POST['x_amount'] ) { // AUTHORIZE.NET

	$txn_id			= $_POST['invoice_num'];
	$total			= $_POST['x_amount'];
	$email			= $_POST['x_email'];

	// check to see if payment is pending
	if ( $_POST['x_response_reason_code'] == '' ) {
		$valid = true;
	}
}
else if ( $_POST['PAYER_ACCOUNT'] ) { // E-GOLD

	$txn_id			= $_POST['PAYMENT_ID'];
	$total			= $_POST['PAYMENT_AMOUNT'];
	$valid = true; // e-gold payment are always instant, never pending
}

$vars = addslashes( serialize( $_POST ) );

// get the user information for this transaction

if ( $txn_id && $valid ) {

	$sql = 'update ! set payment_email = ?, amount_paid = ?, txn_date = ?, payment_vars = ? where id = ?';

	$db->query( $sql, array( TRANSACTIONS_TABLE, $email, $total, date('Y-m-d'), $vars, $txn_id ) );

	// get the "to" level for this transaction

	$uservars = $db->getRow( 'select user_id, to_membership from ! where id = ?', array( TRANSACTIONS_TABLE, $txn_id ) );

	$user_level		= $uservars['to_membership'];
	$user_id		= $uservars['user_id'];

	$levelvars = $db->getRow( 'select activedays, name from ! where roleid = ?', array( MEMBERSHIP_TABLE, $user_level ) );

	$activedays		= $uservars['activedays'];
	$level_name		= $uservars['name'];

	// determine when this user's membership was sent to expire, then extend it by $activedays days

	$levelend = $db->getOne( 'select levelend from ! where id = ?', array( USER_TABLE, $user_id ) );

	if ( $levelend < time() ) {
		$levelend = time();
	}

	// new expiration date for this member

	$levelend = strtotime( "+$activedays day", $levelend );

	$sql = 'UPDATE ! SET level = ?, levelend = ? WHERE id = ?';

	$db->query( $sql, array( USER_TABLE, $user_level, $levelend, $user_id ) );

	$t->assign ( 'level', $level_name );
}

$t->assign('rendered_page', $t->fetch('checkout_process.tpl') );

$t->display( 'index.tpl' );

exit;
?>