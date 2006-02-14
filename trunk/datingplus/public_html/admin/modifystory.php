<?php
if ( !defined( 'SMARTY_DIR' ) ){
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'story_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$id = $_POST['id'];

$day = $_POST['txtDay'];

$mmm = $_POST['txtMonth'];

$yyy = $_POST['txtYear'];

$title = trim($_POST['txttitle']);

$text = trim($_POST['txttext']);

$sender = $_POST['txtsender'];

$dat = strtotime( $day . ' ' . $mmm . ' ' . $yyy );



$err = 0 ;

if ( $title == '' ) {

	$err = NO_STORY_HDR;	// change to a constant later
}
elseif ( $text == '' || strlen($text) <= 0  ) {

	$err = NO_STORY_TEXT;	// change to a constant later
}
elseif ( $sender == '' ) {

	$err = NO_STORY_SENDER;
}

if ( $err > 0 ) {
	$_SESSION['modified']['header'] = $title;
	$_SESSION['modified']['text'] = $text;
	$_SESSION['modified']['sender'] = $sender;
	$_SESSION['modified']['date'] = $dat;
	$_SESSION['modified']['storyid'] = $id;
	
	header( 'location:managestory.php?edit=' . $id . '&errid=' . $err );
	exit;

}

$title = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $title );

$sql = 'UPDATE ! SET header = ?, date = ?, sender = ?, text = ? WHERE storyid = ?';

$db->query( $sql, array( STORIES_TABLE, $title, $dat, $sender, $text, $id ) );

header( 'location:managestory.php' );

exit;

?>