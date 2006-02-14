<?php

/* 	
*	This program will manage the featured profiles list
*	
*/

if ( !defined( 'SMARTY_DIR' ) ) {

	include_once( '../init.php' );

}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'profile_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

if ($_GET['id']) {

/* Need to reactivate this userid */
	$sql = 'update ! set active = ?, regdate = ?, status = ? where id = ?';
	
	$db->query($sql, array( USER_TABLE, '1', time(), 'Active', $_GET['id'] ) );

	if ( $config['phpbb_installed'] == 'Y' ) {
		
		$username = $db->getOne('select username from ! where id = ?',array(USER_TABLE, $_GET['id'] ) );
	
		$sql = "update ! set user_active = ? where username = ? ";
		
		$db->query( $sql, array( 'phpbb_users', 1, $username ) );
	}

	$t->assign('errmsg' ,USER_REACTIVATED);
	
}

$sort = findSortBy('username');

$sql = 'select id, username, firstname, lastname, regdate from ! where active = ? and status = ? order by ! ';

$t->assign('cancel_list', $db->getAll($sql, array( USER_TABLE, '0', 'Cancel',  $sort ) ) );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );			

$t->assign('rendered_page', $t->fetch('admin/reactivate.tpl'));
		
$t->display('admin/index.tpl');

?>