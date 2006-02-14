<?php 
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'pages_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$page = $_POST['txtpage'];

$t->assign('curpage', $page);
		
if ($_SESSION['modifiedpage'] != '') {

	$t->assign('pagerec', $_SESSION['modifiedpage']);

	$t->assign('curpage', $_SESSION['modifiedpage']['id']);

	$_SESSION['modifiedpage'] = '';
	
} elseif ( $page != '0' ) {
	
	$sql = 'SELECT id, pagekey, title, pagetext FROM ! WHERE id = ?';			
	
	$row = $db->getRow( $sql, array( PAGES_TABLE, $page ) );
		
	$t->assign( 'pagerec', $row );
} 

$sql = 'SELECT id, title as answer FROM !';

$rs = $db->getAll( $sql, array( PAGES_TABLE ) );

$t->assign ( 'error_msg', $lang['pages_errormsgs'][$_GET['errid']] );	
	
$t->assign( 'pagedata', makeOptions( $rs ) );

$t->assign('rendered_page', $t->fetch('admin/managepages.tpl'));
		
$t->display ( 'admin/index.tpl' );



?>