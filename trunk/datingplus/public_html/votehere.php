<?php

if( !defined( 'SMARTY_DIR' ) ) {
	require_once( 'init.php' );
}

$pollid = $_GET[ 'pollid' ];
$aid = $_GET[ 'rdo' ];
$ctime = $_GET[ 't' ];

if( $aid > 0 ) {

	if ( getenv( 'HTTP_CLIENT_IP' ) ) {
		$userip = getenv( 'HTTP_CLIENT_IP' );
	} elseif ( getenv( 'HTTP_X_FORWARDED_FOR' ) )	{
		$userip = getenv( 'HTTP_X_FORWARDED_FOR' );
	} else {
		$userip = getenv( 'REMOTE_ADDR' );
	}

	$sql = 'SELECT count(*) FROM ! WHERE  ip = ? and ip <> ? and pollid = ?';

	$count = $db->getOne( $sql, array( POLLIPS_TABLE, $userip, '', $pollid ) );

	if( $count <= 0 )	{

		$time = time();

		$sqlupd = 'INSERT INTO ! VALUES ( ?, ?, ? )';

		$db->query( $sqlupd, array( POLLIPS_TABLE, $userip, $pollid, $time ) );

		$sqlupd = 'UPDATE ! set result = result + 1 WHERE optionid = ?';

		$db->query( $sqlupd, array( POLLOPTS_TABLE, $aid ) );

		header( 'location:viewresult.php?pollid=' . $pollid . '&t=' . $time );
		exit();
	} else {
		header( 'location:viewresult.php?pollid=' . $pollid . '&t=' . $time . '&err='.USERNAME_BLANK );
		exit();
	}
} else {
	header( 'location:viewresult.php?pollid=' . $pollid . '&t=' . $time );
	exit();
}
?>