<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'affiliate_mgt' );

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

//Default Sorting
$sort = findSortBy('name');

//For updating affiliates
if ( $_POST['groupaction'] && count($_POST['txtchk']) > 0 ) {

	foreach ($lang['status_disp'] as $key => $val ) {
		if ($val == $_POST['groupaction']) {
			$action = $key;
		}
	}

	$sqlwhere = "";

	foreach ( $_POST['txtchk'] as $affid) {
		if ($sqlwhere != "") $sqlwhere .= ' or ';
		$sqlwhere .= " id = '".$affid."' ";
	}
	
	$sql = ' UPDATE ! SET status = ? where '.$sqlwhere;

	$db->query( $sql, array( AFFILIATE_TABLE, $action ) );

	header('Location:affiliatesview.php');
	exit;
}

//Paging View style
$page_size = $psize;

$t->assign('psize', $psize);

$page = (int)$_GET['offset'];

if( $page == 0 ) {
	$page = 1;
}

$upr = ($page) * $page_size - $page_size;
$lwr = ($page) * $page_size ;

$sql = 'SELECT * FROM ! ORDER BY ' . $sort . " LIMIT $upr,$lwr";

$data = $db->getAll( $sql, array( AFFILIATE_TABLE ) );

$t->assign( 'upr', $upr );
$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );
$t->assign( 'querystring', 'sort=' . $_GET['sort'] . '&type=' . $_GET['type']);
$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/affiliatesview.tpl'));
		
$t->display( 'admin/index.tpl' );

?>