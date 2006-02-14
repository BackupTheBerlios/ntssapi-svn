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

	header( 'location: calendar.php?msg=' . $lang['no_select_msg'] );
	exit;
}

$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';

if ( $_POST['groupaction'] == $lang['enable_selected'] ) {

	foreach ( $arr as $id ) {

		$result = $db->query( $sql, array( CALENDARS_TABLE, 'Y', $id) );
	}
	header ( 'location:calendar.php' );
	exit;

} elseif ($_POST['groupaction'] == $lang['disable_selected'] ) {

	foreach ( $arr as $id ) {

		$result = $db->query( $sql, array( CALENDARS_TABLE, 'N', $id) );
	}
	header ( 'location:calendar.php' );
	exit;

}

// Editing calendar
foreach ( $arr as $calendarid ) {

	$sqledit = 'SELECT id, calendar, enabled from ! Where id = ?';

	$row = $db->getRow( $sqledit, array( CALENDARS_TABLE, $calendarid) );

	$data[] = $row;

}

$t->assign( 'lang', $lang );

$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );

$t->assign( 'data', $data );

if ( $_POST['groupaction'] == $lang['change_selected'] ) {

	$t->assign('rendered_page', $t->fetch('admin/groupcalendaredit.tpl' ));

} elseif ($_POST['groupaction'] == $lang['delete_selected'] ) {

	$t->assign('rendered_page', $t->fetch('admin/groupcalendardel.tpl' ));

}

$t->display('admin/index.tpl');

?>