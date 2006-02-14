<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}	

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'cntry_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}


if ($_SESSION['results_per_page'] != '' and $_REQUEST['results_per_page'] == '') {
	
	$page_size = $_SESSION['results_per_page'];
	
} elseif ($_REQUEST['results_per_page'] != '') {

	$page_size = $_REQUEST['results_per_page'];

	$_SESSION['results_per_page'] = $page_size;
	
} else {

	$page_size = $config['page_size'];
}

if ($_REQUEST['action'] == 'add') {

	$t->assign('todo','add');
	
	$t->assign('rendered_page', $t->fetch('admin/managecountries.tpl'));
		
	$t->display( 'admin/index.tpl' );
	
	exit;	

} elseif ($_REQUEST['action'] == 'edit') {

	$sqledit = 'select * from ! where id = ?';
	
	$t->assign('data', $db->getRow( $sqledit, array( COUNTRIES_TABLE, $_REQUEST['id'] ) ) );
	
	$t->assign('todo','edit');
	
	$t->assign('rendered_page', $t->fetch('admin/managecountries.tpl'));
		
	$t->display( 'admin/index.tpl' );
	
	exit;
				
} elseif ( $_REQUEST['action'] == 'added' ) {

	$sqledit = 'select id from ! where code = ? or upper(name) = upper(?)';
	
	$foundid = $db->getOne( $sqledit, array( COUNTRIES_TABLE, $_REQUEST['code'], $_REQUEST['name'] ) ) ;
	
	if ($foundid > 0 ) {
	
		$t->assign('errmsg', COUNTRYCODE_INUSE);
		
		$data['code'] = $_REQUEST['code'];

		$data['name'] = $_REQUEST['name'];

		$t->assign('data', $data);

		$t->assign('todo','add');
	
		$t->assign('rendered_page', $t->fetch('admin/managecountries.tpl'));
		
		$t->display( 'admin/index.tpl' );
	
		exit;
		
	} else {
	
		$sqledit = 'insert into !(code, name) values (?, ? )';
	
		$db->query($sqledit, array( COUNTRIES_TABLE, $_REQUEST['code'], $_REQUEST['name'] ) );
		
		$errmsg = COUNTRY_ADDED;
		
	}
	
} elseif ($_REQUEST['action'] == 'edited' ) {

	$sqledit = 'select id from ! where ( code = ? or upper(name) = upper(?) ) and id <> ?';
		
	$foundid = $db->getOne( $sqledit, array( COUNTRIES_TABLE, $_REQUEST['code'], $_REQUEST['name'], $_REQUEST['id'] ) ) ;
		
	if ($foundid > 0 ) {
	
		$t->assign('errmsg', COUNTRYCODE_INUSE);
	
		$data['code'] = $_REQUEST['code'];

		$data['name'] = $_REQUEST['name'];

		$data['id'] = $_REQUEST['id'];

		$t->assign('data', $data);

		$t->assign('todo','edit');

		$t->assign('rendered_page', $t->fetch('admin/managecountries.tpl'));
		
		$t->display( 'admin/index.tpl' );
	
		exit;
		
	} else {
		
		$sqledit = 'update ! set code = ?, name = ? where id = ?';
	
		$db->query($sqledit, array( COUNTRIES_TABLE, $_REQUEST['code'], $_REQUEST['name'], $_REQUEST['id'] ) );
		
		$errmsg = COUNTRY_MODIFIED;

	}
}

if ( $_REQUEST['action'] == 'delete' ) {

	$sqledit = 'DELETE FROM ! where id = ?';
			
	$db->query( $sqledit, array( COUNTRIES_TABLE, $_REQUEST['id'] ) );

	$errmsg = COUNTRY_DELETED;
	
} elseif ( $_REQUEST['groupaction'] == $lang['delete_selected'] && count($_REQUEST['txtcheck']) > 0 ) {
/* Group delete */
	
	$del_list = " id in (";
	foreach ($_REQUEST['txtcheck'] as $k => $val) {
	
		if ($k > 0) { $del_list.= ','; }

		$del_list .= "'".$val."'";	
		
	}
	
	$del_list .= ')';

	$sqledit = 'DELETE FROM ! where !';

	$db->query( $sqledit, array( COUNTRIES_TABLE, $del_list ) );

	$errmsg = COUNTRY_DELETED;

}


$sort = findSortBy('name');

$where='';

if ($_REQUEST['searchme'] == $lang['show'] ) {

	if ($_REQUEST['countrycode'] != '') {
		
		$where = " and upper(code) like upper('%".$_REQUEST['countrycode']."%') ";
		
	} elseif ($_REQUEST['countryname'] != '') {

		$where = " and upper(name) like upper('%".$_REQUEST['countryname']."%') ";
		
	} 

	$t->assign('countrycode', $_REQUEST['countrycode']);
	$t->assign('countryname', $_REQUEST['countryname']);
}

$page = (int)$_GET['offset'];

if( $page == 0 ) { $page = 1; }

$_GET['offset'] = $page;

$upr = ($page)*$page_size - $page_size;

$sql = 'SELECT * FROM ! where code <> ? ! ORDER BY ! LIMIT !,! ';

$data = $db->getAll( $sql, array( COUNTRIES_TABLE, 'AA', $where, $sort, $upr, $page_size ) );

$t->assign('total_recs', $db->getOne('select count(*) from !', array( COUNTRIES_TABLE) ) );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );			

$t->assign( 'upr', $upr );

$t->assign('page_size', $page_size);

$t->assign('errmsg', $errmsg);

$t->assign( 'countrieslist', $data );

$t->assign('rendered_page', $t->fetch('admin/managecountries.tpl'));
		
$t->display( 'admin/index.tpl' );

?>