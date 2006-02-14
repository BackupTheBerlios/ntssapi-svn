<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

//define( 'PAGE_ID', 'global_mgt' );

//if ( !checkAdminPermission( PAGE_ID ) ) {

//	header( 'location:not_authorize.php' );
//	exit;
//}


//For Deletion of profiles
if ( $_GET['txtdelete'] ) {
	deleteUser($_GET['txtdelete']);
}



$spamwords='';
$sql = 'SELECT word FROM !';
$rs = $db->getAll( $sql, array( 'osdate_spamwords' ) );
foreach ( $rs as $row ) {
	if( $spamwords != '' )
		$spamwords = $spamwords . ' OR ';
	$spamwords = $spamwords . 'm.message LIKE \'%' . $row['word'] . '%\'';
}


$sql = 'SELECT u.id, u.username, DATE_FORMAT( FROM_UNIXTIME( m.sendtime ), \'%Y%m%d\' ) send_time, m.message, count(*) copies FROM ! u INNER JOIN ! m ON u.id = m.senderid AND m.folder = \'sent_item\' AND ( ' . $spamwords . ' ) GROUP BY 1, 2, 3, 4 HAVING count(*) > 1 ORDER BY 3 DESC LIMIT 300 ';

$rs = $db->getAll( $sql, array( USER_TABLE, MAILBOX_TABLE ) );

$spammers = array();

foreach ( $rs as $row ) {
	$spammers[] = $row;
}

$t->assign ( 'spammers', $spammers );

$t->assign('rendered_page', $t->fetch('admin/spammers.tpl'));

$t->display( 'admin/index.tpl' );

$db->disconnect();


function deleteUser($userId) {
	/* Delete profile routine */
	global $db, $config;
	
	$rec = $db->getRow('select * from ! where id = ?', array( USER_TABLE, $userId) );

	$username = $rec['username'];

	$db->query('delete from ! where username = ? or ref_username = ?', array(BUDDY_BAN_TABLE, $username, $username) );

	$db->query('delete from ! where userid = ?', array(FEATURED_PROFILES_TABLE, $userId ) );

	$db->query('delete from ! where senderid = ? or recipientid = ?', array(INSTANT_MESSAGE_TABLE, $userId, $userId) );

	$db->query('delete from ! where senderid = ? or recipientid = ?', array(MAILBOX_TABLE, $userId, $userId) );

	$db->query('delete from ! where userid = ?', array(ONLINE_USERS_TABLE, $userId ) );

	$db->query('delete from ! where userid = ?', array(USER_RATING_TABLE, $userId ) );

	$db->query('delete from ! where userid = ?', array(USER_SEARCH_TABLE, $userId ) );

	$db->query('delete from ! where userid = ?', array(USER_SNAP_TABLE, $userId ) );

	$db->query('delete from ! where userid = ? or ref_userid = ?', array(VIEWS_WINKS_TABLE, $userId, $userId) );

	$db->query('delete from ! where id = ?', array(USER_TABLE, $userId ) );

	$db->query('delete from ! where username = ?', array('phpbb_users', $username ) );
}
?>
