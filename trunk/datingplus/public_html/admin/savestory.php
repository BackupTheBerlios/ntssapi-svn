<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}	

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'story_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$day = $_POST['txtDay'];

$mmm = $_POST['txtMonth'];

$yyy = $_POST['txtYear'];

$dat = strtotime( $day . ' ' . $mmm . ' ' . $yyy );

$_SESSION['txttitle'] = $title = trim($_POST['txttitle']);

$_SESSION['txttext'] = $text = trim($_POST['txttext']);

$_SESSION['txtsender'] = $sender = $_POST['txtsender'];

$_SESSION['txtdate'] = $dat;

$err = 0 ;

if ( $title == '' ) {

	$err = NO_STORY_HDR;	
	
} elseif ( $text == '' || strlen($text) <= 0 ) {

	$err = NO_STORY_TEXT;	
	
} elseif ( $sender == '' ) {

	$err = NO_STORY_SENDER;	
	
}

if ( $err > 0 ) {

	header( 'location:storyins.php?errid=' . $err );
	exit;
	
}

$_SESSION['txttitle'] ='';

$_SESSION['txttext'] = '';

$_SESSION['txtsender'] = '';

$_SESSION['txtdate'] = '';

$title = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $title );

$sql = 'INSERT INTO ! ( date, sender, header, text, enabled ) VALUES ( ?, ?, ?, ?, ?  )';
		

$db->query( $sql, array(STORIES_TABLE, $dat, $sender, $title, $text, 'Y' ) );

header( 'location:managestory.php' );

exit;

?>