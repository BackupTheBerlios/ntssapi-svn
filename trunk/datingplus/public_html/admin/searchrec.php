<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '..\init.php' );
}

include ( 'sessioninc.php' );

$sortme = ' order by user.username ';

if ($_SESSION['sort_by'] != '' and $_REQUEST['sort_by'] == '') {

	$_REQUEST['sort_by'] = $_SESSION['sort_by'];

}

if ($_REQUEST['sort_by'] != '') {

	$_SESSION['sort_by'] = $_REQUEST['sort_by'];

	if ($_REQUEST['sort_by'] == '') {

		$sort_by='username';

	} else {

		$sort_by=$_REQUEST['sort_by'];	
	}

	if ($_REQUEST['sort_order'] == '') {

		$sort_order='asc';

	} else {

		$sort_order=$_REQUEST['sort_order'];	

	}

	$sortme = " order by ";

	if ($sort_by == 'username') {

		$sortme .= 'user.username ';

	} elseif ( $sort_by == 'age' ) {

		$sortme .= ' age ';

	} elseif ( $sort_by == 'logintime' ) {

		$sortme .= 'user.lastvisit ';
	}

	$sortme .= $sort_order;
	
	$t->assign('sort_by', $sort_by);
	
	$t->assign('sort_order', $sort_order);

}

if ( $_POST['searchtype'] == 'simple' ) {
	
	//In case if search is at zip or city
	$searchatname = $_POST['txtsearch'];
		
	$srchby = $_POST['searchby'] . ":" ;			
	
	//If Search is at country code or state code
	$sql = 'SELECT name from ';
		
	if ( $_POST['searchby'] == 'country' ) {
		
		$sql .= COUNTRIES_TABLE;

		$sql .= " WHERE code='" . $_POST['txtsearch'] . "'";				

		$row = $db->getRow( $sql );

		$searchatname = $row['name'];

		$srchby = $lang['signup_country'];
			
	} elseif ( $_POST['searchby'] == 'state_province' ) {
		
		$sql .= STATES_TABLE;

		$sql .= " WHERE code='" . $_POST['txtsearch'] . "'";				

		$row = $db->getRow($sql);

		$searchatname = $row['name'];

		$srchby = $lang['signup_state_province'];				

	}

	$sql = 'SELECT * FROM ! ';

	$sql .= " WHERE id > 0 and " . $_POST['searchby'] . "= '" . $_POST['txtsearch'] . "'";

	//Place last query and related values in session with out sort string
	$_SESSION['LastQuery'] = $sql;

	$_SESSION['SearchBy'] = $srchby;

	$_SESSION['SearchAt'] = $searchatname;						

	$sql .= $sortme;

	$rs = $db->query ( $sql , array( USER_TABLE ));

	showPageB ( $rs, $srchby, $searchatname );

} elseif ( $_POST['searchtype'] == 'advance' ) {

	$sql = 'SELECT * FROM !  WHERE id > 0 and ';

	$sql .=  "country='" . $_POST['txtcountry'] . "' ";

	if ( $_POST['txtcity'] ) {

		if ( $_POST['txtcity'] == '*' ) {

			$sql .= $_POST['logicalop1'] . " city!=NULL ";

		} else {

			$sql .= $_POST['logicalop1'] . " city='" . $_POST['txtcity'] . "' ";

		}
	}

	if ( $_POST['txtzip'] ) {

		if ( $_POST['txtzip'] == '*' ) {

			$sql .= $_POST['logicalop2'] . " zip!=NULL ";

		} else {

			$sql .= $_POST['logicalop2'] . " zip='" . $_POST['txtzip'] . "' ";

		}
	}			


	$sql .= $sortme;

	$rs = $db->query ( $sql , array( USER_TABLE ) );

	showPageA ( $rs );			

	exit;


} elseif ( $_REQUEST'sort_by'] ) {


	$sql = $_SESSION['LastQuery'];

	$sql .= $sortme;

	$rs = $db->query ( $sql );

	showPageB ( $rs, $_SESSION['SearchBy'], $_SESSION['SearchAt'] );

	exit;
}

function showPageA ( $rs ) {

	global $lang;	
	global $db;
	global $t;

	//No Record found
	if ( $rs->numRows() == 0 ) {

		$t->assign ( 'error', "1" );

		$t->assign ( 'lang', $lang );

		$t->assign('rendered_page', $t->fetch('admin/showapsearch.tpl'));
		
		$t->display ( 'index.tpl' );				

	} else {

		$data = array();

		while ( $row = $rs->fetchRow() ) {

			$row['countryname'] = $db->getOne('select name from ! where code = ?', array( COUNTRIES_TABLE, $row['country'] ) );
			
			$row['statename'] = $db->getOne('select name from ! where code = ? and countrycode = ?', array( STATES_TABLE, $row['state_province'], $row['country'] ) );
	
			$row['statename'] = ($row['statename'] != '') ? $row['statename'] : $row['state_province'];


			$data[] = $row;

		}

		$t->assign ( 'data', $data );

		$t->assign ( 'lang', $lang );

		$t->assign('rendered_page', $t->fetch('admin/showapsearch.tpl'));
		
		$t->display ( 'index.tpl' );

	}
}


function showPageB ( $rs, $srchby, $srchatname ) {

	global $lang;	
	global $db;
	global $t;

	//No Record found
	if ( $rs->numRows() == 0 ) {

		$t->assign ( 'error', "1" );

		$t->assign ( 'searchby', $srchby );				

		$t->assign ( 'searchat', $srchatname );				

		$t->assign ( 'lang', $lang );

		$t->assign('rendered_page', $t->fetch('admin/showspsearch.tpl'));
		
		$t->display ( 'index.tpl' );				

	} else {
		//If records exists
	
		$data = array();

		while ( $row = $rs->fetchRow() ) {
			$row['countryname'] = $db->getOne('select name from ! where code = ?', array( COUNTRIES_TABLE, $row['country'] ) );
			
			$row['statename'] = $db->getOne('select name from ! where code = ? and countrycode = ?', array( STATES_TABLE, $row['state_province'], $row['country'] ) );
	
			$row['statename'] = ($row['statename'] != '') ? $row['statename'] : $row['state_province'];


			$data[] = $row;

		}

		$t->assign ( 'searchby', $srchby );

		$t->assign ( 'searchat', $srchatname );

		$t->assign ( 'data', $data );

		$t->assign ( 'lang', $lang );

		$t->assign('rendered_page', $t->fetch('admin/showspsearch.tpl'));
		
		$t->display ( 'index.tpl' );

	}
}

?>	