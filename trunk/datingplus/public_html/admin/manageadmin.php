<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'admin_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}
if ( isset( $_GET['results_per_page'] ) && $_GET['results_per_page'] ) {

	$psize = $_GET['results_per_page'];
	
	$config['search_results_per_page'] = $_GET['results_per_page'] ;
	
	$_SESSION['ResultsPerPage'] = $_GET['results_per_page'];		
	
} elseif( $_SESSION['ResultsPerPage'] != '' ) {

	$psize = $_SESSION['ResultsPerPage'];
	
	$config['search_results_per_page'] = $_SESSION['ResultsPerPage'] ;		
	
} else {

	$psize = $config['page_size'];
	
	$_SESSION['ResultsPerPage'] = $config['page_size'];
	
}

if ( $_GET['edit'] ) {

	$sqledit = 'SELECT * from ! where id = ?';

	$data = $db->getRow( $sqledit, array( ADMIN_TABLE, $_GET['edit'] ) );

	$t->assign( 'lang', $lang );

	$t->assign( 'error_msg', $lang['admin_error'][ $_GET['errid'] ] );

	$t->assign( 'admin', $data );

	$t->assign('rendered_page', $t->fetch('admin/adminedit.tpl'));
		
	$t->display( 'admin/index.tpl' );

	exit;
}

if ( $_POST['deleteadmin'] ) {

	$sqledit = 'DELETE FROM ! where id = ?';

	$db->query( $sqledit, array( ADMIN_TABLE, $_POST['deleteadmin'] ) );

	$sqledit = 'DELETE FROM !  where adminid = ?';

	$db->query( $sqledit, array( ADMIN_RIGHTS_TABLE, $_POST['deleteadmin'] ) );

	if ( $config['phpbb_installed'] == 'Y' ) {

		$sql = 'DELETE FROM phpbb_users Where user_id = ?';

		$db->query( $sql, array( $_POST['deleteadmin'] ) );
	}
}

$_SESSION['txtuname'] = $_SESSION['txtfullname'] = '';

$page_size = $psize;

$t->assign('psize', $psize);

$page = (int)$_GET['offset'];

if( $page == 0 ) $page = 1;

$upr = ($page)*$page_size - $page_size;

$sort = findSortBy();

$sql = 'SELECT count(*) as num FROM !';

$reccount = $db->getOne( $sql, array( ADMIN_TABLE) );

$t->assign ( 'total_recs',  $reccount );

$sql = 'SELECT * FROM ! ORDER BY ' . $sort . " LIMIT $upr,$page_size ";

$data = $db->getAll( $sql, array( ADMIN_TABLE ) );

$t->assign( 'lang', $lang );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->assign( 'querystring', 'sort=' . $_GET['sort'] . '&type=' . $_GET['type']);

$t->assign( 'upr', $upr );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/manageadmin.tpl'));
		
$t->display( 'admin/index.tpl' );

?>