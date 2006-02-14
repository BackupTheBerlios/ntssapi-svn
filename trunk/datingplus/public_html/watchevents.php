<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

if ( $_GET['add'] ){
	$id = $_GET['add'];
	$sqldel = 'replace ! set userid = ?, eventid = ? ';
	$result = $db->query( $sqldel, array( WATCHES_TABLE, $_SESSION["UserId"], $id) );
}

if ( $_GET['delete'] ){
	$id = $_GET['delete'];
	$sqldel = 'DELETE FROM ! WHERE userid = ? and eventid = ? ';
	$result = $db->query( $sqldel, array( WATCHES_TABLE, $_SESSION["UserId"], $id) );
}

// Get user's data (timezone)
$user=$db->getRow("select * from ! where id=?",array(USER_TABLE, $_SESSION["UserId"]));
$t->assign("user",$user);

	// selecting all events for that date
	$query="select e.id, e.userid, e.event, e.description, ".
		   "       date_add(e.datetime_from, interval ! hour) as datetime_from, ".
		   "       date_add(e.datetime_to, interval ! hour) as datetime_to, ".
		   "       e.calendarid, e.timezone, e.private_to ".
	       "from ! as e inner join ! as we on we.eventid = e.id ".
		   "where 1 ".
		   "  and we.userid=? ".
		   "  and date_add(e.datetime_to, interval ! hour) >= now() ".
		   "order by e.datetime_from ";
	$rs=$db->query($query,array($user["timezone"], $user["timezone"], EVENTS_TABLE,WATCHES_TABLE,$_SESSION["UserId"], $config["server_timezone"]));
	while(($event=$rs->fetchRow()))
	{	$event["watched"]=1;
		$item["events"][]=$event;
	}
	if(empty($item["events"])) $t->assign("error",1);
$t->assign("date",$date);
$t->assign("events",$item["events"]);
$t->assign('rendered_page', $t->fetch('watchevents.tpl') );
$t->display ( 'index.tpl' );

exit;
?>