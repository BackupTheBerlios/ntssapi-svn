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

$arr = $_POST[ 'txtcheck' ];
if ( count( $arr ) == 0 ) {
	header( 'location: calendarevents.php?calendarid=' . $_POST['calendarid'] . '&msg=' . $lang['no_select_msg'] );
	exit;
}	
if ( $_POST['groupaction'] == $lang['enable_selected'] ) {
	foreach ( $arr as $id ) {
		$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';
		$result = $db->query( $sql, array( EVENTS_TABLE, 'Y', $id ) );
	}
	header ( "location:calendarevents.php?calendarid=" . $_POST['calendarid'] );
	exit;
} elseif ($_POST['groupaction'] == $lang['disable_selected'] ) {
	foreach ( $arr as $id ) {
		$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';
		$result = $db->query( $sql, array( EVENTS_TABLE, 'N', $id ) );
	}
	header ( "location:calendarevents.php?calendarid=" . $_POST['calendarid'] );
	exit;
}
?>