<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'news_mgt' );

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

	if ($_GET['errid'] != '') {
		$data['date'] = $_SESSION['txtdate'];	
		$data['header'] = $_SESSION['txttitle'];	
		$data['text'] = $_SESSION['txttext'];	
		$data['newsid'] = $_GET['edit'];	
	} else{
		$sqledit = 'SELECT * from ! Where newsid = ?';
			
		$data = $db->getRow( $sqledit, array(NEWS_TABLE, $_GET['edit']) );
	}	
	$t->assign( 'lang', $lang );

	$t->assign( 'error_msg', $lang['news_error'][ $_GET['errid'] ] );
			
	$t->assign( 'news', $data );
	
	$t->assign('rendered_page', $t->fetch('admin/newsedit.tpl'));
		
	$t->display( 'admin/index.tpl' );
	
	exit;
}

if ( $_POST['deletenews'] ) {

	$sqledit = 'DELETE FROM ! Where newsid = ?';
			
	$db->query( $sqledit, array(NEWS_TABLE, $_POST['deletenews']) );

}


$page_size = $psize;

$t->assign('psize', $psize);

$page = (int)$_GET['offset'];

if( $page == 0 ) $page = 1;

$upr = ($page)*$page_size - $page_size;

if( $_GET['sort'] == $lang['col_head_sendtime'] ) {
	
	$sort = 'date '. checkSortType ( $_GET['type'] );
	
} else {

	$sort = findSortBy('newsid');
}

$sql = 'SELECT count(*) as num FROM !'; 

$reccount = $db->getOne( $sql, array(NEWS_TABLE) );

$t->assign ( 'total_recs',  $reccount );

$sql = 'SELECT * FROM ! ORDER BY ' . $sort . " LIMIT $upr,$page_size ";

$data = $db->getAll( $sql, array(NEWS_TABLE) );
	
$t->assign( 'lang', $lang );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->assign( 'querystring', 'sort=' . $_GET['sort'] . '&type=' . $_GET['type']);

$t->assign( 'upr', $upr );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/managenews.tpl'));
		
$t->display( 'admin/index.tpl' );


?>