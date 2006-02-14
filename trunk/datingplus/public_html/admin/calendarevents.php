<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

define( 'PAGE_ID', 'calendar_mgt' );
if ( !checkAdminPermission( PAGE_ID ) ) {
	header( 'location:not_authorize.php' );
	exit;
}

	
if( $_GET['sort'] == '' ) {
	$sort = 'displayorder asc';
} else {
	$sort = findSortBy();
}	

if ( $_GET['edit'] ) {
	$sqledit = "SELECT id, ".
			   "       userid, ".
			   "       event, ".
			   "       description, ".
			   "       calendarid, ".
			   "       enabled, ".
			   "       timezone, ".
			   "       datetime_from, ".
			   "       datetime_to, ".
			   "       recurring, ".
			   "       recuroption, ".
			   "       private_to ".
			   "from ! Where id = ?";
	$data = $db->getRow( $sqledit, array( EVENTS_TABLE, $_GET['edit'] ) );
	$t->assign( 'lang', $lang );
	$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );
	$t->assign( 'data', $data );
	$t->assign('rendered_page', $t->fetch('admin/eventedit.tpl'));
	$t->display( 'admin/index.tpl' );
	exit;
}

if ( $_GET['insert'] ) {
	$calendar_name = $db->getOne('SELECT calendar from ! Where id = ?', array( CALENDARS_TABLE, $_GET['calendarid'] ) );
	$t->assign('calendarname', $calendar_name);
	$t->assign( 'lang', $lang );
	$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );			
	$t->assign('rendered_page', $t->fetch('admin/eventins.tpl'));
	$t->display( 'admin/index.tpl' );
	exit;
}

//For Deletion of calendars
if ( $_POST['frm'] == 'frmDelEvent'){
	$id = $_POST['txtid'];
	$calendar = $_POST['txtcalendarid'];
	// Deleting watches for event
	$sqldel = 'DELETE FROM ! WHERE eventid = ?';
	$result = $db->query( $sqldel, array( WATCHES_TABLE, $id ) );
	// Deleting event
	$sqldel = 'DELETE FROM ! WHERE id = ? and calendarid = ?';
	$result = $db->query( $sqldel, array( EVENTS_TABLE, $id, $calendar ) );
	$_GET['calendarid'] = $calendar;
}

if($_REQUEST["filter"]):
	$start_date=make_datetime_from_smarty("start");
	$end_date=make_datetime_from_smarty("end");
elseif($_SESSION["calendar_start"]):
	$start_date=$_SESSION["calendar_start"];
	$end_date=$_SESSION["calendar_end"];
else:
	$start_date=date("Y-m-d H:i:s",mktime (0,0,0,date("m"),date("d"),date("Y")));
	$end_date=date("Y-m-d H:i:s",mktime (23,59,59,date("m"),date("d"),date("Y")));
endif;
if($_REQUEST["period"]=="year")
{	$start_date=date("Y-m-d H:i:s",mktime (0,0,0,date("m"),date("d"),date("Y")-1));
	$end_date=date("Y-m-d H:i:s",mktime (23,59,59,date("m"),date("d"),date("Y")));
}
if($_REQUEST["period"]=="month")
{	$start_date=date("Y-m-d H:i:s",mktime (0,0,0,date("m")-1,date("d"),date("Y")));
	$end_date=date("Y-m-d H:i:s",mktime (23,59,59,date("m"),date("d"),date("Y")));
}
if($_REQUEST["period"]=="week")
{	$start_date=date("Y-m-d H:i:s",mktime (0,0,0,date("m"),date("d")-7,date("Y")));
	$end_date=date("Y-m-d H:i:s",mktime (23,59,59,date("m"),date("d"),date("Y")));
}
if($_REQUEST["period"]=="day")
{	$start_date=date("Y-m-d H:i:s",mktime (0,0,0,date("m"),date("d"),date("Y")));
	$end_date=date("Y-m-d H:i:s",mktime (23,59,59,date("m"),date("d"),date("Y")));
}
$_SESSION["calendar_start"]=$start_date;
$_SESSION["calendar_end"]=$end_date;
$t->assign("start_date",$start_date);
$t->assign("end_date",$end_date);

//Get Section id, name
$sql = 'SELECT id, calendar FROM ! WHERE id = ?';
$rowcalendar = $db->getRow( $sql, array( CALENDARS_TABLE, $_GET['calendarid'] ) );
$sql = "SELECT * ".
       "from ! ".
	   "WHERE calendarid = ? ".
	   "  and datetime_from <= '$end_date' ".
	   "  and datetime_to >= '$start_date' ".
	   "order by datetime_from ";
$data = $db->getAll( $sql, array( EVENTS_TABLE, $_GET['calendarid'] ) );
$t->assign( 'lang', $lang );
$t->assign( 'calendarname', $rowcalendar['calendar'] );
$t->assign( 'calendarid', $rowcalendar['id'] );	
$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );
$t->assign( 'data', $data );
$t->assign('rendered_page', $t->fetch('admin/calendarevents.tpl'));
$t->display( 'admin/index.tpl' );
?>	