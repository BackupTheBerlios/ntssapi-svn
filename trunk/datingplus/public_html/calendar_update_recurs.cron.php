<?php
include_once( 'init.php' );

	// Days
	$sql="update ! ".
		 "set datetime_from=date_add(datetime_from, interval recuroption day), ".
		 "    datetime_to=date_add(datetime_to, interval recuroption day)  ".
		 "where recurring = 1 ".
		 "  and to_days(date_add(datetime_from, interval recuroption day)) = to_days(date_sub(now(),interval ! hour)) ";
	$db->query($sql, array(EVENTS_TABLE, $config["server_timezone"]));

	// Weeks
	$sql="update ! ".
		 "set datetime_from=date_add(datetime_from, interval recuroption*7 day), ".
		 "    datetime_to=date_add(datetime_to, interval recuroption*7 day)  ".
		 "where recurring = 2 ".
		 "  and to_days(date_add(datetime_from, interval recuroption*7 day)) = to_days(date_sub(now(),interval ! hour)) ";
	$db->query($sql, array(EVENTS_TABLE, $config["server_timezone"]));

	// Monthes
	$sql="update ! ".
		 "set datetime_from=date_add(datetime_from, interval recuroption month), ".
		 "    datetime_to=date_add(datetime_to, interval recuroption month)  ".
		 "where recurring = 3 ".
		 "  and to_days(date_add(datetime_from, interval recuroption month)) = to_days(date_sub(now(),interval ! hour)) ";
	$db->query($sql, array(EVENTS_TABLE, $config["server_timezone"]));

	// Years
	$sql="update ! ".
		 "set datetime_from=date_add(datetime_from, interval recuroption year), ".
		 "    datetime_to=date_add(datetime_to, interval recuroption year)  ".
		 "where recurring = 4 ".
		 "  and to_days(date_add(datetime_from, interval recuroption year)) = to_days(date_sub(now(),interval ! hour)) ";
	$db->query($sql, array(EVENTS_TABLE, $config["server_timezone"]));

exit;
?>