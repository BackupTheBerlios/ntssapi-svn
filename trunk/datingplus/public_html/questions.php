<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

$sectionid = $_GET[ 'sectionid' ];

// Query to reterive records from osdate_questions table, sorted descending on mandatory: that is, mandatory fields should be displayed first

$sql = "select id, question, mandatory, description, guideline, maxlength, control_type from ? where enabled = ? and section = ? order by mandatory desc, displayorder";

//Execute query
$temp = $db->getAll( $sql, array( QUESTIONS_TABLE, 'Y', $sectionid ) );

//Fetch records
$index = 0;

//while ( $row = $questionrs->fetchRow() ) {

foreach( $temp as $index => $row ) {

	//Query to reterice record from osdate_questionoptions table
	$sqlqoption = 'select * from ! where enabled = ? and questionid = ? order by id';

	$options = $db->getAll( $sqlqoption, array( OPTIONS_TABLE, 'Y', $row[id] ) ) ;

	//Place options of question at the last of array
	$row['options'] = makeOptions ( $optionsrs );

	//Create questions array
	$data []= $row;
}


//Assign template variables to Smarty
$t->assign ( 'mandatory_question_error', $lang['errormsgs'][$_GET['errid']] );

$t->assign ( 'sectionid', $_GET['sectionid'] );

$t->assign("frmname", "frm" . $sectionid );

$t->assign ( 'head', $sections[ $sectionid ] );

$t->assign ( 'data', $data );

$t->assign('rendered_page', $t->fetch('questions.tpl') );

//Display template
$t->display('index.tpl');


?>