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

//For Editing Modules
if ( $_GET['edit'] ) {

	$sqledit = 'SELECT * from ! where module_key = ?';

	$data = $db->getRow( $sqledit, array( PAYMENT_MODULE_TABLE, $_GET['edit'] ) );

	$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );

	$data['formfile'] = 'admin/'.$data['formfile'];

	$t->assign( 'data', $data );

	$sqlconf = 'SELECT configuration_key, configuration_value from ! where module_key = ?';

	$confdata = $db->getAll( $sqlconf, array( TABLE_CONFIGURATION, $_GET['edit'] ) );

	foreach( $confdata as $confitem ) {

		$paymod_data[ $confitem['configuration_key'] ] = $confitem['configuration_value'];
	}

	$t->assign( 'paymod_data', $paymod_data );

	$t->assign('rendered_page', $t->fetch('admin/paymentmodedit.tpl'));

	$t->display( 'admin/index.tpl' );

	exit;
} elseif ( $_GET['delete'] ) {
//For Deletion of sections

	$sqlupd = 'UPDATE ! SET enabled = ? WHERE module_key = ?';

	$db->query( $sqlupd, array( PAYMENT_MODULE_TABLE, 'N', $_GET['delete'] ) );

	$payment= $_GET['delete'];

	require( '../modules/payment/'.$payment.'.php' );

	$payment_module = new $payment;

	$payment_module->remove();

} elseif ( $_GET['install'] ) {
//Insert new section

	$sqlupd = 'UPDATE ! SET enabled = ? WHERE module_key = ?';

	$db->query( $sqlupd, array( PAYMENT_MODULE_TABLE, 'Y', $_GET['install'] ) );

	$payment= $_GET['install'];

	require( '../modules/payment/'.$payment.'.php' );

	$payment_module = new $payment;

	$payment_module->install();

}

$sql = 'SELECT * from !';

$data = $db->getAll( $sql, array( PAYMENT_MODULE_TABLE ) );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/paymentmod.tpl'));

$t->display( 'admin/index.tpl' );

exit;
?>