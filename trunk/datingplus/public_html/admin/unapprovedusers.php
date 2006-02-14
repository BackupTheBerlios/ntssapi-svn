<?php 

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

if ( $_POST['groupaction'] != '' ){

	foreach ($lang['status_disp'] as $key => $val ) {
		if ($val == $_POST['groupaction']) {
			$action = $key;
		}
	}
	
	$sql = 'UPDATE ! SET status =?, active = 1 WHERE 0 ';
	
	foreach( $_POST['txtchk'] as $item) {
	
		$sql .= ' OR id = \'' . $item .'\'';
		
		if ($action == 'Active') {
		
			$activedays = $db->getOne('select distinct mem.activedays from ! as mem, ! as usr where usr.id = ? and mem.roleid = usr.level limit 1', array(MEMBERSHIP_TABLE, USER_TABLE, $item) );
			
			$levelend = strtotime("+$activedays day",time());

			$db->query('update ! set levelend = ? where id = ?',array( USER_TABLE, $levelend, $item) );
			
		}
	}
	if ($action == 'Reject') { $errid = PROFILES_REJECTED; }
	elseif ($action == 'Active') { 	$errid = PROFILES_ACTIVATED; }
 	else { $errid = PROFILES_SUSPENDED; }

	$rs = $db->query( $sql, array( USER_TABLE, $action ) );
	
	header( 'location: ?errid='.$errid );
	
	exit;
}

$status = $lang['status_enum']['approval'];	

$sql = 'SELECT * FROM ! WHERE status in (?, ?) ORDER BY ' . $sort;
	
$unapproved_user = $db->getAll ( $sql, array( USER_TABLE, $status, 'Approval' ) );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );			

$t->assign ( 'data' , $unapproved_user );

$t->assign ( 'errid' , $_GET['errid'] );

$t->assign ( 'lang', $lang );

$t->assign('rendered_page', $t->fetch('admin/unapprovedusers.tpl'));

$t->display ( 'admin/index.tpl' );

?>
