<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include( 'sessioninc.php' );

$userid = $_SESSION['UserId'];

$sectionid = $_GET[ 'sectionid' ];

if ( $sectionid == '' ) {
	$sectionid = 1;
}

// Query to reterive records from osdate_questions table
// sorted descending on mandatory: that is mandatory fields should be displayed first

$sqlquestion = 'select id, question, mandatory, description, guideline, maxlength, control_type from ! where enabled = ? and section = ? and question <> ? order by mandatory desc, displayorder';

$temp = $db->getAll( $sqlquestion, array( QUESTIONS_TABLE, 'Y', $sectionid , '') );

$data = array();

foreach( $temp as $index => $row ) {

	// reterive record from osdate_questionoptions table

	$sql = 'select * from ! where enabled = ? and questionid = ? order by id';

	$options = $db->getAll( $sql, array( OPTIONS_TABLE, 'Y', $row['id'] ) ) ;

	$row['options'] = makeOptions ( $options );

	$sql = 'select questionid, answer from ! where userid = ? and questionid = ?';

	$userprefrs = $db->getAll( $sql, array( USER_PREFERENCE_TABLE, $userid, $row['id'] ) ) ;

	$row['userpref'] = makeAnswers ( $userprefrs );

	$data [] = $row;
}

if ( isset( $_GET['errid'] ) ) {

	$t->assign( 'mandatory_question_error', $lang['errormsgs'][$_GET['errid']] );

}

$t->assign( 'sectionid', $_GET['sectionid'] );

$t->assign('frmname', 'frm' . $sectionid );

$t->assign( 'head', $sections[ $sectionid ] );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('editquestions.tpl') );

$t->display('index.tpl');

?>