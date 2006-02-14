<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'news_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$day = $_POST['txtDay'];

$mmm = $_POST['txtMonth'];

$yyy = $_POST['txtYear'];


$title = $_POST['txttitle'];

$text = trim($_POST['txttext']);

$dat = strtotime( $day . ' ' . $mmm . ' ' . $yyy );


$err = 0 ;

if ( $title == '' ) {

	$err = NO_HDR;

} elseif ( $text == '' || strlen($text) <= 0 ) {

	$err = NO_TEXT;

}

if ( $err > 0 ) {
	$_SESSION['txttitle'] = $title;
	$_SESSION['txttext'] = $text;
	$_SESSION['txtdate'] = $dat;	
	header( 'location:newsins.php?errid=' . $err );
	exit;

}

$_SESSION['txttitle'] = '';
$_SESSION['txttext'] = '';
$_SESSION['txtdate'] = '';

$title = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $title );

$sql = 'INSERT INTO ! (  date, header, text) VALUES ( ?, ?, ? )';

$db->query( $sql, array( NEWS_TABLE, $dat, $title, $text) );

header( 'location:managenews.php' );

exit;

?>