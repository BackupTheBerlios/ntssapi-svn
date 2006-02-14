<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}	

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'story_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$sql = 'SELECT id, username FROM ! ORDER BY username';

$rsuser = $db->getAll( $sql, array( USER_TABLE) );

foreach ( $rsuser as $row ) {

	$users[ $row['id'] ] = $row['username'];
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

$t->assign( 'users', $users );

if ( $_GET['edit'] ) {

	if ($_SESSION['modified'] != '') {
	
		$data = $_SESSION['modified'];
		
		$_SESSION['modified'] = '';
	} else {

		$sqledit = 'SELECT * from ! Where storyid = ?';
			
		$data = $db->getRow( $sqledit, array( STORIES_TABLE, $_GET['edit'] ) );
	}		
	$t->assign( 'lang', $lang );

	$t->assign( 'error_msg', $lang['story_error'][ $_GET['errid'] ] );
			
	$t->assign( 'story', $data );
	
	$t->assign('rendered_page', $t->fetch('admin/storyedit.tpl'));
		
	$t->display( 'admin/index.tpl' );
	
	exit;
}

if ( $_POST['deletestory'] ) {

	$sqledit = 'DELETE FROM ! Where storyid = ?';
			
	$db->query( $sqledit, array( STORIES_TABLE, $_POST['deletestory'] ) );

}

$t->assign('psize', $psize);

$page_size = $psize;

$page = (int)$_GET['offset'];

if( $page == 0 ) { $page = 1; }

$upr = ($page)*$page_size - $page_size;

if( $_GET['sort'] == $lang['col_head_sendtime'] ) {
	
	$sort = 'date '. checkSortType ( $_GET['type'] );

} else {

	$sort = findSortBy('storyid');

}
$sql = 'SELECT count(*) as num FROM !';

$reccount = $db->getOne( $sql, array( STORIES_TABLE ) );

$t->assign ( 'total_recs',  $reccount );

$sql = 'SELECT * FROM ! ORDER BY ' . $sort . " LIMIT $upr,$page_size ";

$data = $db->getAll( $sql, array( STORIES_TABLE ) );

$t->assign( 'lang', $lang );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->assign( 'querystring', 'sort=' . $_GET['sort'] . '&type=' . $_GET['type']);

$t->assign( 'upr', $upr );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/managestories.tpl'));
		
$t->display( 'admin/index.tpl' );

?>