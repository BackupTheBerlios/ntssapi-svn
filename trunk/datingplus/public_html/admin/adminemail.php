<?php

if ( !defined( 'SMARTY_DIR' ) ) {

	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'send_letter' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$sort = findSortBy();

//check for delete parameter in URL; if yes then do delete action
if($_GET['delete']) {

	$id	= 	trim( $_GET['delete'] );

	$sqlupd = 'DELETE FROM ! WHERE id = ? ';

	$db->query( $sqlupd, array( ADMIN_EMAILS_TABLE, $id) );

	header ( 'location:?' );
	exit;
}
elseif ($_POST['frm'] == 'frmAddEmail' ){

	$sqlins = 'INSERT INTO ! ( email ) values( ? )';

	$db->query( $sqlins, array( ADMIN_EMAILS_TABLE, $_POST['txtemail'] ) );

	header ( 'location:?' );
	exit;
}

$sort = findSortBy();

$sql = 'SELECT * FROM ! ORDER BY ' . $sort;

$data = $db->getAll( $sql, array( ADMIN_EMAILS_TABLE ) );

$t->assign( 'emails', $data );
$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->display( 'admin/adminemail.tpl' );

exit;


?>