<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}	
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'profile_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}
		

if ( isset( $_GET['results_per_page'] ) && $_GET['results_per_page'] ) {

	$psize = $_GET['results_per_page'];

	$config['search_results_per_page'] = $_GET['results_per_page'] ;

	$_SESSION['ResultsPerPage'] = $_GET['results_per_page'];
	
} elseif ( $_SESSION['ResultsPerPage'] != '' ) {

	$psize = $_SESSION['ResultsPerPage'];

	$config['search_results_per_page'] = $_SESSION['ResultsPerPage'] ;

} else {

	$psize = $config['search_results_per_page'];

	$_SESSION['ResultsPerPage'] = $config['search_results_per_page'];
}

$t->assign ( 'psize',  $psize );

// rewrite later

$sql = 'SELECT u.*, floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12) as age FROM ! u, ! ou WHERE u.allow_viewonline=? AND u.status in (?, ?) AND u.id = ou.userid ';

$cpage = $_GET['page'];

if( $cpage == '' ) {
	$cpage = 1;
}

$rs = $db->query( $sql, array( USER_TABLE, ONLINE_USERS_TABLE, '1', $lang['status_enum']['active'], 'Active') );

$rcount = $rs->numRows();

if( $rcount > 0 ) {

	$t->assign( 'totalrecs', $rcount );

	$pages = ceil( $rcount / $psize );

	$start = ( $cpage - 1 ) * $psize;

	$t->assign ( 'start', $start );

	if( $pages > 1 ) {

		if ( $cpage > 1 ) {

			$prev = $cpage - 1;

			$t->assign( 'prev', $prev );

		}
		$t->assign ( 'cpage', $cpage );

		$t->assign ( 'pages', $pages );

		if ( $cpage < $pages ) {

			$next = $cpage + 1;

			$t->assign ( 'next', $next );
		}
	}
	$sql .= " limit $start, $psize"	;
}

$data = $db->getAll( $sql, array( USER_TABLE, ONLINE_USERS_TABLE, '1', $lang['status_enum']['active'], 'Active' ) );

if ( sizeof( $data ) == 0 ) {

	$t->assign ( 'error', "1" );

} else {

	hasRight('');

	$t->assign ( 'data', $data );

}

$t->assign ( 'lang', $lang );

$t->assign('rendered_page', $t->fetch('admin/onlineusers.tpl') );

$t->display ( 'admin/index.tpl' );

exit;

?>