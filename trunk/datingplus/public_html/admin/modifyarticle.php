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

$modified['articleid'] = $id = $_POST['id']; 

$day = $_POST['txtDay'];

$mmm = $_POST['txtMonth'];

$yyy = $_POST['txtYear'];

$modified['dat'] = $dat = strtotime( $day . ' ' . $mmm . ' ' . $yyy );

$modified['title'] = $title = $_POST['txttitle'];

$modified['text'] = $text = ltrim(rtrim($_POST['txttext']));

$err = 0 ;

if ( $title == '' ) {

	$err = NO_HDR;	
	
} elseif ( $text == '' || strlen($text) <= 0 ) {

	$err = NO_TEXT;		
}

if ( $err != 0 ) {

	$_SESSION['modified'] = $modified;
	
	header( 'location:managearticle.php?edit=' . $id . '&errid=' . $err );
	
	exit;
	
}

$title = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $title );

$sql = 'UPDATE ! SET title = ?, dat = ?, text = ? WHERE articleid = ?';

$db->query( $sql, array( ARTICLES_TABLE, $title, $dat, $text, $id ) );

header( 'location:managearticle.php' );

exit;

?> 