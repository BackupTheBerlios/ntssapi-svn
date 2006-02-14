<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'calendar_mgt' );
if ( !checkAdminPermission( PAGE_ID ) ) {
	header( 'location:not_authorize.php' );
	exit;
}

$id = trim( $_POST['txtid'] );

$calendar = stripslashes(trim( $_POST['txtcalendar'] ));

$enabled = trim( $_POST['txtenabled'] );

$err = 0;

if ( $calendar == '' ) {
	$err = CALENDAR_BLANK;
}

if ( $err != 0 ) {

	header ( 'location:calendar.php?edit=' . $_POST['txtid'] . '&errid=' . $err );
	exit;
}

$sqlupd = 'UPDATE ! SET calendar = ?, enabled = ? WHERE id = ?';

$result = $db->query( $sqlupd, array( CALENDARS_TABLE, $calendar, $enabled, $id  ) );

header ( 'location:calendar.php' );
?>