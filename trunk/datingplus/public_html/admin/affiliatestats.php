<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'affiliate_stats' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}


//Default Sorting
$sort = findSortBy('name');

//Paging View style
$page_size = $config['page_size'];

$page = (int)$_GET['offset'];

if( $page == 0 ) $page = 1;

$upr = ($page)*$page_size - $page_size;

$lwr = ($page)*$page_size ;

$sql = 'SELECT * FROM ! WHERE status in (?, ?) ORDER BY ' . $sort . " LIMIT $upr, $lwr";

$rs = $db->getAll( $sql, array( AFFILIATE_TABLE, 'Active', $lang['status_enum']['active'] ) );

$data = array();

foreach ( $rs as $row ) {

	$sqlc = 'SELECT count(*) as num1 FROM ! WHERE affid = ?';

	$rowc = $db->getRow( $sqlc, array( AFFILIATE_REFERALS_TABLE, $row['id'] ) );

	$row['totalref'] = $rowc['num1'];

	unset( $rowc );

	$sqlcc = 'SELECT count(*) as num2 FROM ! WHERE affid = ?  and userid <>  ?' ;

	$rowc = $db->getRow( $sqlcc, array( AFFILIATE_REFERALS_TABLE, $row['id'], '0' ) );

	$row['regref'] = $rowcc['num2'];

	unset( $rowcc );

	$data[] = $row;
}

unset ($rs);

$t->assign( 'upr', $upr );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->assign( 'querystring', 'sort=' . $_GET['sort'] . '&type=' . $_GET['type']);

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/affiliatestats.tpl'));
		
$t->display( 'admin/index.tpl' );


?>