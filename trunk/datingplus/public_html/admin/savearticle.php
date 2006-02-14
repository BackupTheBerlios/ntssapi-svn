<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'article_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$day = $_POST['txtDay'];

$mmm = $_POST['txtMonth'];

$yyy = $_POST['txtYear'];

$title = $_POST['txttitle'];

$text = trim($_POST['txttext']);

$err = 0 ;

if ( $title == '' ) {

	$err = NO_HDR;	
	
} elseif ( $text == '' || strlen($text) <= 0 ) {

	$err = NO_TEXT;	
	
}

$dat = strtotime( $day . ' ' . $mmm . ' ' . $yyy );

if ( $err != 0 ) {

	$_SESSION['txttext'] = $_POST['txttext'];

	$_SESSION['txttitle'] = $_POST['txttitle'];
	
	$_SESSION['artcldate'] = $dat;

	header( 'location:articleins.php?edit=' . $id . '&errid=' . $err );

	exit;
	
}

$_SESSION['txttext'] = '';
$_SESSION['artcldate'] = '';
$_SESSION['txttitle'] = '';

$title = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $title );

$sql = 'INSERT INTO ! (  dat, title, text ) VALUES ( ?, ?, ? )';
		
$db->query( $sql, array( ARTICLES_TABLE, $dat, $title, $text ) );

header( 'location:managearticle.php' );

exit;

?>