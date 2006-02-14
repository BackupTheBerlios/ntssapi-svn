<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include( 'sessioninc.php' );

$t->assign('lang', $lang);

$sql = 'SELECT country, state_province FROM ! WHERE id = ?';

$row1 = $db->getRow( $sql, array( USER_TABLE, $_SESSION['UserId'] ) );

if ($_REQUEST['countrycode'] != '') {

	$countrycode = $_REQUEST['countrycode'];

	$stateslist = getStates($countrycode);

	if (count($stateslist) > 0) {
	
		$t->assign('stateslist', $stateslist );
	
	}
	
} else {

	$countrycode = $row1['countrycode'];
	
}

$sql = 'select * from ! where ( extsearchable = ? and enabled = ? ) and ( id = ? or id = ? )';

$data = $db->getAll( $sql, array( QUESTIONS_TABLE, 'Y', 'Y', 1, 5 ) );

foreach( $data as $index => $row ) {

	$sqloptions = 'select * from ! where enabled = ? and questionid = ? order by id';

	$optrs = $db->getAll( $sqloptions, array( OPTIONS_TABLE, 'Y', $row['id'] ) ) ;

	$row['options'] = makeOptions ( $optrs );
	
	$endoptions = makeOptions ($optrs);
	
	krsort($endoptions);
	
	reset($endoptions);
	
	$row['endoptions'] = $endoptions;

	$data[ $index ] = $row;
}

$t->assign ( 'data', $data );

$t->assign( 'countrycode', $countrycode );

$t->assign( 'userstate', $row1['state_province'] );

$t->assign ( 'lang', $lang );

$t->assign('rendered_page', $t->fetch('search.tpl') );

$t->display ( 'index.tpl' );

?>