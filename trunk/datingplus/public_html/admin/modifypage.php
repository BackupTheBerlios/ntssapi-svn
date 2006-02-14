<?php
//session_start();

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'pages_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$ptitle = trim( $_POST['txttitle'] );

$pkey = trim( $_POST['txtkey'] );

$pbody = trim( $_POST['txtbody'] );

$pageid = $_POST['pageid'];

$modifiedpage = array('title'	=>	$ptitle,
					'pagekey'	=>	$pkey,
					'pagetext'	=>	$pbody,
					'id'		=>	$pageid
					);
$err = 0;

if ( $ptitle == '' ) {

	$err = NO_PAGE_HDR;
} elseif ( $pkey == '' ) {

	$err = NO_PAGE_KEY;
} elseif( $pbody == '' ) {

	$err = NO_PAGE_TEXT;
}

$_SESSION['modifiedpage'] = $modifiedpage;

if ( $err ) {

	header ( 'location:managepages.php?errid=' . $err );
	exit;
}

$sql = 'UPDATE ! SET title = ?, pagekey = ?, pagetext = ? WHERE id = ?';

$rs = $db->query( $sql, array( PAGES_TABLE, $ptitle, $pkey, $pbody, $pageid ) );

header( 'location:managepages.php' );

exit;
?>