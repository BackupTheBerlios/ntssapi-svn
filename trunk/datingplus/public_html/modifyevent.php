<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}	

include ( 'sessioninc.php' );

$id 			= 	trim( $_POST['txtid'] );
$userid 			= 	trim( $_POST['txtuserid'] );
$event 			= 	stripslashes(trim( $_POST['txtevent'] ));
$description 	= 	stripslashes(trim( $_POST['txtdescription'] ));
$calendar 		= 	$_POST['txtcalendar'];
$enabled 		= 	(empty($_POST['txtprivate_to'])?"Y":"N");
$timezone 		= 	$_POST['txttimezone'];
$day = $_POST['txtdatefromDay'];
$mmm = $_POST['txtdatefromMonth'];
$yyy = $_POST['txtdatefromYear'];
$hhh = $_POST['txtdatefromHour'];
$iii = $_POST['txtdatefromMinute'];
$datefrom = $dat = $yyy."-".$mmm."-".$day." ".$hhh.":".$iii;
$day = $_POST['txtdatetoDay'];
$mmm = $_POST['txtdatetoMonth'];
$yyy = $_POST['txtdatetoYear'];
$hhh = $_POST['txtdatetoHour'];
$iii = $_POST['txtdatetoMinute'];
$dateto = $dat = $yyy."-".$mmm."-".$day." ".$hhh.":".$iii;
$recurring 		= 	$_POST['txtrecurring'];
$recuroption 		= 	$_POST['txtrecuroption'];
$private_to 		= 	stripslashes($_POST['txtprivate_to']);

$sqlupd = "UPDATE ! ".
	      "SET userid = ?, ".
		  "    event	= ?, ".
		  "    description = ?, ".
		  "    calendarid = ?, ".
		  "    enabled = ?, ".
		  "    timezone = ?, ".
		  "    datetime_from = DATE_SUB(?, INTERVAL $timezone HOUR), ".
		  "    datetime_to = DATE_SUB(?, INTERVAL $timezone HOUR), ".
		  "    recurring = ?, ".
		  "    recuroption = ?, ".
		  "    private_to = ? ".
		  "where id= ?";
$result = $db->query( $sqlupd, array( EVENTS_TABLE, $userid, $event, $description, $calendar, $enabled, $timezone, $datefrom, $dateto, $recurring, $recuroption, $private_to, $id ) );
send_watched_mails($id);
header ( 'location: event.php?event_id='.$id);
?>