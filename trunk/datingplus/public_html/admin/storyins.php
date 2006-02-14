<?php
if ( !defined( 'SMARTY_DIR' ) ){
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'story_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$sql = 'SELECT id, username FROM ! ORDER BY username';

$rsuser = $db->getAll( $sql, array( USER_TABLE ) );

foreach( $rsuser as $row ) {

	$users[ $row['id'] ] = $row['username'];
}

$t->assign( 'users', $users );

$t->assign( 'error_msg', $lang['story_error'][ $_GET['errid'] ] );
		
$t->assign('rendered_page', $t->fetch('admin/storyins.tpl'));

$t->display( 'admin/index.tpl' );

exit;
?>