<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'poll_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

if (  $_GET['edit'] ) {

	$id = $_GET['edit'];
	
	$sql = 'SELECT * FROM ! WHERE optionid = ?';
	
	$row = $db->getRow( $sql, array( POLLOPTS_TABLE, $id ) );
	
	$t->assign( 'data', $row );
	
	$t->assign( 'error	', $lang['poll_error'][$_GET['errid']] );
	
	$t->assign('rendered_page', $t->fetch('admin/polloptsedit.tpl'));
		
	$t->display( 'admin/index.tpl' );
	
	exit;
}

if ( $_POST['groupaction']  ) {

	$pollid =  $_POST['txtpollid'];
	
	$optid =  $_POST['txtoptionid'];		
	
	$opts =  $_POST['txtcheck'];	

	if ( $_POST['groupaction']	== $lang['enable_selected'] ) {
	
		foreach( $opts as $val ) {
		
			$sql = 'UPDATE ! SET enabled = ? WHERE optionid = ? AND pollid = ?';
			
			$rs = $db->query( $sql, array( POLLOPTS_TABLE, 'Y', $val, $pollid ) );
		}
	} elseif ( $_POST['groupaction']	== $lang['disable_selected'] ) {
	
		foreach( $opts as $val ) {
		
			$sql = 'UPDATE ! SET enabled = ? WHERE optionid = ? AND pollid = ?';
			
			$rs = $db->query( $sql, array( POLLOPTS_TABLE, 'N', $val, $pollid ) );
			
		}
		
	} elseif ( $_POST['groupaction']	== $lang['delete_selected'] ) {
	
		foreach( $opts as $val ) {
		
			$sql = 'DELETE FROM ! WHERE optionid = ? AND pollid = ?';
					
			$db->query( $sql, array( POLLOPTS_TABLE, $val, $pollid ) );
			
		}
		
	}
	
}

if ( $_POST['frm'] == 'frmDelOption' ) {

	$pollid 	= $_POST['txtpollid'];
	
	$optid 	= $_POST['txtoptionid'];	
	
	$sql = 'DELETE FROM ! WHERE optionid = ? AND pollid = ?';
					
	$db->query( $sql, array( POLLOPTS_TABLE, $optid, $pollid ) );
	
}

if ( $_GET['pollid'] ) {

	$pollid = $_GET['pollid'];
	
} else {

	$pollid = $_POST['txtpollid'];
	
}

//Default Sorting

$sort = findSortBy('optionid');

$sqlsection = 'SELECT * from ! WHERE pollid = ? order by ' . $sort;	
			
$data = $db->getAll( $sqlsection, array( POLLOPTS_TABLE, $pollid ) );

$t->assign( 'lang', $lang );

$sqlsection = 'SELECT question from ! WHERE pollid = ?';
				
$row = $db->getRow( $sqlsection, array( POLLS_TABLE, $pollid ) );

$t->assign( 'poll_question', stripslashes( $row['question'] ) );

$t->assign( 'pollid', $pollid );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/polloptions.tpl'));
		
$t->display( 'admin/index.tpl' );


?>