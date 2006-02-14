<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
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

$x=hasRight('viewpicture');

if ( $_REQUEST['frm'] == 'frmKeySearch' ){

	$keyword = trim($_REQUEST['keywords'] );

	if (count($keywords) == 0) {
	
		header ("location: extsearch.php");
		
		exit;
		
	}

	$sql = 'select user.* from ! as user, ! as cntry where user.active = ? and user.status = ? and user.country = cntry.code ';
	
	$where1=" and upper(user.firstname) like upper('%".$keyword."%') or upper(user.lastname) like upper('%".$keyword."%') or upper(user.username) like upper('%".$keyword."%') or upper(user.email) like upper('%".$keyword."%') or upper(cntry.name) like upper('%".$keyword"%') or upper(user.country) like upper('%".$keyword."%') or upper(user.lookcountry) like upper('%".$keyword."%') or upper(


	$cpage = $_GET['page'];

	if( $cpage == '' ) $cpage = 1;

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

		$qry .= " limit $start, $psize"	;
	}

	$rs = $db->getAll( $qry, array( USER_TABLE, USER_PREFERENCE_TABLE ) );

	$data = array();

	if( $rs) {
		foreach( $rs as $row) {
			$data[] = $row;
		}
	} else {
		$t->assign( 'error', 1);
	}

	$query_array = array();
	
	$q_array = explode('&',$querystring);
	
	foreach ($q_array as $qry) {

		list($k, $ans) = explode('=',$qry);

		if ($k != 'page' ) {

			$query_array[$k] = $ans;	
		}
	}

	$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

	$t->assign ( 'querystring', $query_array);

	$t->assign ( 'backlink', 'extsearch.php' );

	$t->assign ( 'data', $data );

	$t->assign ( 'lang', $lang );

	$t->assign('rendered_page', $t->fetch('showsimpsh.tpl') );

	$t->display ( 'index.tpl' );
}

function getKeySearch($field) {

	global $keywords;

	$searchme = ' (';
	
	if (count($keywords) == 1) {
	
		$searchme. = $field ." like '%".$keywords[0]."%' ";
		
	} else {
	
		foreach ($keywords as $key) {

			if ($searchme != ' (' ){ $searchme .= ' or '; }
			
			$searchme.=$field ." like '%".$keywords[0]."%' ";
			
		}
	}
	
	$searchme .= ') ';

	return $searchme;
}
?>