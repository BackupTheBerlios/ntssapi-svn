<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

$sql = 'SELECT id, username, password, email FROM !';

$data = $db->getAll( $sql, array( USER_TABLE ) );

$userid = $db->getOne('select max(user_id)+1 from !', array( 'phpbb_users' ) );

foreach( $data as $index => $row ) {

	$db->query('delete from ! where username = ?', array('phpbb_users', $row['username']) );
	
	$sql = 'insert into ! ( user_id, username, user_password, user_email, user_active, user_level , user_regdate) values ( ?, ?, ?, ?, ?, ?, ? )';

	// md5( $row['password'] ) ?

	$db->query( $sql, array( 'phpbb_users', $userid, $row['username'], $row['password'], $row['email'], 1, 0, time() ) );

	$userid++;
}

$sql = 'SELECT id, username, password FROM !';

$data = $db->getAll( $sql, array( ADMIN_TABLE ) );

foreach( $data as $index => $row ) {

	$db->query('delete from ! where username = ?', array('phpbb_users', $row['username']) );

	$sql = 'insert into ! ( user_id, username, user_password, user_email, user_active, user_level, user_regdate ) values ( ?, ?, ?, ?, ?, ?, ? )';

	// md5( $row['password'] ) ?

	$db->query( $sql, array( 'phpbb_users', $userid, $row['username'], $row['password'], $row['email'], 1, 1 , time()) );
	
	$userid++;
}
?>
<center><br><b>The members are created in Forum</b></center>
