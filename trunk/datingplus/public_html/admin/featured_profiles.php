<?php

/* 	
*	This program will manage the featured profiles list
*	
*/

if ( !defined( 'SMARTY_DIR' ) ) {

	include_once( '../init.php' );

}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'profie_approval' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$sort = findSortBy('username');

$sql = 'select fet.id, fet.userid, fet.start_date, fet.end_date, fet.must_show, fet.req_exposures, fet.exposures, usr.username, usr.firstname, usr.lastname, membr.name as level from ! as fet, ! as usr, ! as membr  where fet.userid = usr.id  and membr.roleid = usr.level order by ! ';

$featured = $db->getAll($sql, array( FEATURED_PROFILES_TABLE, USER_TABLE, MEMBERSHIP_TABLE, $sort ) );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );			

$t->assign('featured', $featured);

$t->assign('rendered_page', $t->fetch('admin/featured_profiles.tpl'));
		
$t->display('admin/index.tpl');

?>