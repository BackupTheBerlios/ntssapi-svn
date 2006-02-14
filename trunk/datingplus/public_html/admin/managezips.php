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


$sql = 'select name from ! where code = ?';

$t->assign('countryname', $db->getOne( $sql, array( COUNTRIES_TABLE, $_REQUEST['countrycode'] ) ) );

$t->assign('countrycode', $_REQUEST['countrycode'] );

$t->assign('statename', $db->getOne( $sql, array( STATES_TABLE, $_REQUEST['statecode'] ) ) );

$t->assign('statecode', $_REQUEST['statecode'] );

$t->assign('countyname', $db->getOne( $sql, array( COUNTIES_TABLE, $_REQUEST['countycode'] ) ) );

$t->assign('countycode', $_REQUEST['countycode'] );

$t->assign('cityname', $db->getOne( $sql, array( CITIES_TABLE, $_REQUEST['citycode'] ) ) );

$t->assign('citycode', $_REQUEST['citycode'] );

if ($_REQUEST['action'] == 'add') {

	$t->assign('todo','add');
	
	$t->assign('rendered_page', $t->fetch('admin/managezips.tpl'));
		
	$t->display( 'admin/index.tpl' );
	
	exit;	

} elseif ($_REQUEST['action'] == 'edit') {

	$sqledit = 'select * from ! where id = ?';
	
	$t->assign('data', $db->getRow( $sqledit, array( ZIPCODES_TABLE, $_REQUEST['id'] ) ) );
	
	$t->assign('todo','edit');
	
	$t->assign('rendered_page', $t->fetch('admin/managezips.tpl'));
		
	$t->display( 'admin/index.tpl' );
	
	exit;
				
} elseif ( $_REQUEST['action'] == 'added' ) {

	$sqledit = 'select id from ! where countrycode = ? and statecode = ? and countycode = ? and citycode=? and code = ? ';
	
	$foundid = $db->getOne( $sqledit, array( ZIPCODES_TABLE, $_REQUEST['countrycode'], $_REQUEST['statecode'], $_REQUEST['countycode'], $_REQUEST['citycode'], $_REQUEST['code'] ) ) ;
	
	if ($foundid > 0 ) {
	
		$t->assign('errmsg', ZIPCODE_INUSE);
		
		$data['code'] = $_REQUEST['code'];

		$data['name'] = $_REQUEST['name'];

		$t->assign('data', $data);

		$t->assign('todo','add');
	
		$t->assign('rendered_page', $t->fetch('admin/managezips.tpl'));
		
		$t->display( 'admin/index.tpl' );
	
		exit;
		
	} else {
	
		$sqledit = 'insert into !(countrycode, statecode, countycode, citycode, code) values (?, ?, ?, ?, ?)';
	
		$db->query($sqledit, array( ZIPCODES_TABLE, $_REQUEST['countrycode'], $_REQUEST['statecode'], $_REQUEST['countycode'], $_REQUEST['citycode'], $_REQUEST['code'] ) );
		
		$errmsg = ZIP_ADDED;
		
	}
	
} elseif ($_REQUEST['action'] == 'edited' ) {

	$sqledit = 'select id from ! where countrycode = ? and statecode = ? and countycode = ? and citycode = ? and code = ? and id <> ?';
		
	$foundid = $db->getOne( $sqledit, array( ZIPCODES_TABLE, $_REQUEST['countrycode'], $_REQUEST['statecode'], $_REQUEST['countycode'],  $_REQUEST['citycode'], $_REQUEST['code'], $_REQUEST['id'] ) ) ;
		
	if ($foundid > 0 ) {
	
		$t->assign('errmsg', ZIPCODE_INUSE);
	
		$data['code'] = $_REQUEST['code'];

		$data['name'] = $_REQUEST['name'];

		$data['id'] = $_REQUEST['id'];

		$t->assign('data', $data);

		$t->assign('todo','edit');

		$t->assign('rendered_page', $t->fetch('admin/managezips.tpl'));
		
		$t->display( 'admin/index.tpl' );
	
		exit;
		
	} else {
		
		$sqledit = 'update ! set code = ? where id = ?';
	
		$db->query($sqledit, array( ZIPCODES_TABLE, $_REQUEST['code'], $_REQUEST['id'] ) );
		
		$errmsg = ZIP_MODIFIED;
	}
}

if ( $_REQUEST['action'] == 'delete' ) {

	$sqledit = 'DELETE FROM ! where id = ?';
			
	$db->query( $sqledit, array( ZIPCODES_TABLE, $_REQUEST['id'] ) );

	$errmsg = ZIP_DELETED;
	
} elseif ( $_REQUEST['groupaction'] == $lang['delete_selected'] && count($_REQUEST['txtcheck']) > 0 ) {
/* Group delete */
	
	$del_list = " id in (";
	foreach ($_REQUEST['txtcheck'] as $k => $val) {
	
		if ($k > 0) { $del_list.= ','; }

		$del_list .= "'".$val."'";	
		
	}
	
	$del_list .= ')';

	$sqledit = 'DELETE FROM ! where ! ';
	
	$db->query( $sqledit, array( ZIPCODES_TABLE, $del_list ) );

	$errmsg = ZIP_DELETED;

}

$where='';

if ($_REQUEST['searchme'] == $lang['show'] ) {
	
	if ($_REQUEST['zipcode'] != '') {
		
		$where = " and upper(code) like upper('%".$_REQUEST['zipcode']."%') ";
		
	} 

	$t->assign('zipcode', $_REQUEST['zipcode']);
}

$page = (int)$_GET['offset'];

if( $page == 0 ) { $page = 1; }

$_GET['offset'] = $page;

$upr = ($page)*$page_size - $page_size;

$sql = 'SELECT * FROM ! where countrycode = ? and statecode = ? and countycode = ? and citycode = ? ' . $where . ' ' . $sort . ' ORDER BY code LIMIT ?,? ';
 
 $data = $db->getAll( $sql, array( ZIPCODES_TABLE, $_REQUEST['countrycode'], $_REQUEST['statecode'], $_REQUEST['countycode'], $_REQUEST['citycode'], $upr, (int)$page_size ) );
 
$t->assign('total_recs', $db->getOne('select count(*) from ! where countrycode = ? and statecode = ? and countycode = ? and citycode = ? ', array( ZIPCODES_TABLE, $_REQUEST['countrycode'], $_REQUEST['statecode'], $_REQUEST['countycode'], $_REQUEST['citycode'] ) ) );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );			

$t->assign('countrycode', $_REQUEST['countrycode']);

$t->assign('statecode', $_REQUEST['statecode']);

$t->assign('countycode', $_REQUEST['countycode']);

$t->assign('citycode', $_REQUEST['citycode']);

$t->assign( 'upr', $upr );

$t->assign('page_size', $page_size);

$t->assign('errmsg', $errmsg);

$t->assign( 'zipslist', $data );

$t->assign('rendered_page', $t->fetch('admin/managezips.tpl'));
		
$t->display( 'admin/index.tpl' );

?>
