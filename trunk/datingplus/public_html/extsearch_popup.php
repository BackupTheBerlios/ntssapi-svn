<?php
if ( !defined( 'SMARTY_DIR' ) ){
	include_once( 'init.php' );
}
include ( 'sessioninc.php' );

define( 'PAGE_ID', 'ext_search' );

$sql = 'SELECT * FROM ! WHERE ( extsearchable = ? AND enabled = ? ) ';

$rs = $db->getAll( $sql, array( QUESTIONS_TABLE, 'Y', 'Y' ) );

$data = array();

foreach ( $rs as $index => $row ) {
	//Query to reterice record from osdate_questionoptions table
	$sqloptions = 'SELECT * FROM ! WHERE enabled = ? AND questionid = ? order by id';
	$optrs = $db->getAll( $sqloptions, array( OPTIONS_TABLE, 'Y', $row['id'] ) ) ;
	//Place options of question at the last of array
	$row['options'] = makeOptions ( $optrs );
	$endoptions = makeOptions ($optrs);
	krsort($endoptions);
	reset($endoptions);
	$row['endoptions'] = $endoptions;
	//Create questions array
	$data[ $index ] = $row;

}

$db->disconnect();

//Display index.tpl file
$t->assign( 'lang', $lang );
$t->assign ( 'data', $data );
$t->assign ( 'path', '..\\' );
//$t->assign('rendered_page', $t->fetch('extsearch.tpl'));
$t->display( 'extsearch_popup.tpl' );

?>
