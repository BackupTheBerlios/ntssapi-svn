<?php
	//Include init.php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'calendar_mgt' );
if ( !checkAdminPermission( PAGE_ID ) ) {
	header( 'location:not_authorize.php' );
	exit;
}

//Default Sorting
if( $_GET['sort'] == '' ) {
	$sort = 'displayorder asc ';
} else if( $_GET['sort'] == $lang['col_head_name'] ) {
		$sort = 'calendar '. checkSortType ( $_GET['type'] );
} else {
	$sort = findSortBy();
}

//For Editing calendars
if ( $_GET['edit'] ) {
	$sqledit = 'SELECT id, calendar, enabled from ! Where id = ?';
	$data = $db->getRow( $sqledit, array( CALENDARS_TABLE, $_GET['edit'] ));
	$t->assign( 'lang', $lang );
	$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );
	$t->assign( 'data', $data );
	$t->assign('rendered_page', $t->fetch('admin/calendaredit.tpl'));
	$t->display( 'admin/index.tpl' );
	exit;
}

//For Deletion of calendars
if ( $_POST['frm'] == 'frmDelcalendar' && $_POST['delaction'] == 'Yes') {
	$id = $_POST['txtid'];
	//now delete the record
	// Deleting watched events
	$sql="select id from ! WHERE calendarid = ?";
	$events=$db->getAll($sql,array( EVENTS_TABLE, $id ) );
	for($i=0;$i<count($events);$i++)
	{	// Deleting watches for event
		$sqldel = 'DELETE FROM ! WHERE eventid = ?';
		$result = $db->query( $sqldel, array( WATCHES_TABLE, $events[$i]["id"] ) );
	}
	// Deleting events
	$sqldel = 'DELETE FROM ! WHERE calendarid = ?';
	$db->query( $sqldel, array( EVENTS_TABLE, $id ) );
	// Deleting calendar
	$sqldel = 'DELETE FROM ! WHERE id = ?';
	$db->query( $sqldel, array( CALENDARS_TABLE, $id ) );
	header('location:calendar.php');
	exit;
}

//Insert in calendar with max displayorder
if ( $_POST['frm'] == 'frmAddcalendar') {
	$calendar = stripslashes(trim( $_POST['txtcalendar'] ));
	$enabled = trim( $_POST['txtenabled'] );
	$sql = 'SELECT MAX(displayorder)+1 as orderno FROM ! ' ;
	$row = $db->getRow( $sql, array( CALENDARS_TABLE ) );
	$sqlins = 'INSERT INTO ! (calendar, enabled , displayorder) VALUES (?, ?, ? )';
	$db->query( $sqlins, array( CALENDARS_TABLE, $calendar, $enabled,  (is_null($row['orderno'])?"0":$row['orderno']) ) );
	header('location:calendar.php');
	exit;
}//End of if

if ( $_GET['moveup'] ) {
	$sql = 'SELECT displayorder FROM ! WHERE id = ?';
	$nrow = $db->getRow( $sql, array( CALENDARS_TABLE, $_GET['moveup'] ) );
	//to check whether it is at the highest order
	//if not then move up
	if ( $nrow['displayorder'] != 0){
		$sql = 'SELECT id, displayorder FROM ! WHERE displayorder = ?';
		$prow = $db->getRow( $sql, array( CALENDARS_TABLE, ($nrow['displayorder']-1) ) );
		$sqla = 'UPDATE ! SET displayorder = ? WHERE displayorder = ? AND id = ?';
		$db->query( $sqla, array( CALENDARS_TABLE, $nrow['displayorder'], $prow['displayorder'], $prow['id'] ));
		$db->query( $sqla, array( CALENDARS_TABLE, $nrow['displayorder']-1, $nrow['displayorder'], $_GET['moveup'] ));
		header('location:calendar.php');
		exit;
	}
	header('location:calendar.php?msg=calendar is already at the top');
	exit;
}

if ( $_GET['movedown'] ) {
	$sql = 'SELECT displayorder FROM ! WHERE id = ?';
	$nrow = $db->getRow( $sql, array( CALENDARS_TABLE,$_GET['movedown'] ) );
	//get maximum order of calendars
	$sql = 'SELECT MAX(displayorder) as maxorder FROM !';
	$maxorder = $db->getOne( $sql, array( CALENDARS_TABLE ) );
	//to check whether it is at the lowest order
	//if not then move down
	if ( $nrow['displayorder'] !=  $maxorder['maxorder'] ){
		$sql = 'SELECT id, displayorder FROM ! WHERE displayorder = ?';
		$prow = $db->getRow( $sql, array( CALENDARS_TABLE,($nrow['displayorder']+1) ) );
		$sqla = 'UPDATE ! SET displayorder = ? WHERE displayorder = ? AND
			id = ?';
		$db->query( $sqla , array( CALENDARS_TABLE, ($nrow['displayorder']+1), $nrow['displayorder'], $_GET['movedown'] ));
		$db->query( $sqla , array( CALENDARS_TABLE, $nrow['displayorder'], $prow['displayorder'], $prow['id'] ));
		header('location:calendar.php');
		exit;
	}
	header('location:calendar.php?msg=calendar is already at the bottom');
	exit;
} 		

$sqlcalendar = 'SELECT id, calendar, displayorder, enabled from ! order by ' . $sort;
$data = $db->getAll( $sqlcalendar, array(CALENDARS_TABLE) );
$t->assign( 'lang', $lang );
$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );
$t->assign( 'data', $data );
$t->assign('rendered_page', $t->fetch('admin/calendar.tpl'));
$t->display( 'admin/index.tpl' );
?>
