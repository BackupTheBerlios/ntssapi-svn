<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once ( 'init.php' );
}

$profid = trim( $_POST['profileid'] );
$userid = trim( $_POST['userid'] );
$rating = trim( $_POST['txtrate'] );

if ( $userid && $profid && $rating ) {

	$sql = 'INSERT INTO ! (id, userid, profileid, rating, rate_time ) VALUES ( ?, ?, ?, ?, ? )';

	$db->query( $sql, array( USER_RATING_TABLE, "", $userid, $profid, $rating, time() ) );

	header ( 'location:showprofile.php?id=' . $profid );
}
?>