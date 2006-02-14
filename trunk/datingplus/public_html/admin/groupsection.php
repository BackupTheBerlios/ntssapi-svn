<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}	
include ( 'sessioninc.php' );
	
define( 'PAGE_ID', 'section_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}
	
$arr = $_POST[ 'txtcheck' ];

if ( count( $arr ) == 0 ) {

	header( 'location: section.php?msg=' . $lang['no_select_msg'] );
	exit;
}

$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';

if ( $_POST['groupaction'] == $lang['enable_selected'] ) {

	foreach ( $arr as $id ) {
	
		$result = $db->query( $sql, array( SECTIONS_TABLE, 'Y', $id) );
	}
	header ( 'location:section.php' );
	exit;					

} elseif ($_POST['groupaction'] == $lang['disable_selected'] ) {

	foreach ( $arr as $id ) {
	
		$result = $db->query( $sql, array( SECTIONS_TABLE, 'N', $id) );
	}
	header ( 'location:section.php' );
	exit;					

}		

// Editing section
foreach ( $arr as $sectionid ) {

	$sqledit = 'SELECT id, section, enabled from ! Where id = ?';
		
	$row = $db->getRow( $sqledit, array( SECTIONS_TABLE, $sectionid) );
	
	$data[] = $row;	

}

$t->assign( 'lang', $lang );

$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );

$t->assign( 'data', $data );

if ( $_POST['groupaction'] == $lang['change_selected'] ) {

	$t->assign('rendered_page', $t->fetch('admin/groupsectionedit.tpl' ));	
	
} elseif ($_POST['groupaction'] == $lang['delete_selected'] ) {

	$t->assign('rendered_page', $t->fetch('admin/groupsectiondel.tpl' ) );	
	
}

$t->display('admin/index.tpl');

?>