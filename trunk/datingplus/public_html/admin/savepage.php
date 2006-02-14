<?php
session_start();

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}
include( 'sessioninc.php' );

define( 'PAGE_ID', 'pages_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$ptitle = $_POST['txttitle'];

$pkey = $_POST['txtkey'];

$pbody = ltrim(rtrim($_POST['txtbody']));

$err = 0;

if ( $ptitle == '' ) {

	$err = NO_PAGE_HDR;

} elseif ( $pkey == '' ) {

	$err = NO_PAGE_KEY;

} elseif( $pbody == '' or strlen($pbody) <= 0 ) {

	$err = NO_PAGE_TEXT;

}

$_SESSION['modifiedpage'] = array('title'	=>	$ptitle,
					'pagekey'	=>	$pkey,
					'pagetext'	=>	$pbody
					);
if ( $err != 0 ) {

	header ( 'location:managepages.php?errid=' . $err );
	exit;

}

$sql = 'SELECT Count(*) as num FROM !  WHERE pagekey = ? ';

$rs = $db->query( $sql, array(PAGES_TABLE, $pkey ) );

if ( $rs->numRows() > 0 ) {

	$row = $rs->fetchRow();

	if ( $row['num'] > 0 ) {

		header( 'location:managepages.php?errid='.PAGE_EXISTS );
		exit;

	}

}

$sql = 'INSERT INTO ! ( title, pagekey, pagetext) VALUES ( ?, ?, ? )';

$rs = $db->query( $sql, array( PAGES_TABLE, $ptitle, $pkey, $pbody ) );

$_SESSION['modifiedpage']['id'] = getLastId( PAGES_TABLE );

header( 'location:managepages.php' );

exit;
?>