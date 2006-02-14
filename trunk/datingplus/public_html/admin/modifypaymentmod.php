<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'payment_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$payment = $_POST['payment'];

$configuration = $_POST['configuration'];

// fix this later - payment mod keys have extra "MODULE_PAYMENT_" string in them from osCommerce

require( '../modules/payment/'.$payment.'.php');

$payment_module = new $payment;

$payment_module->update( $configuration );

header( 'location:paymentmod.php?edit=' . $payment );
exit;

?>