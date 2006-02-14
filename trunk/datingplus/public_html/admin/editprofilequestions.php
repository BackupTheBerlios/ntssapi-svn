<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}		

include('sessioninc.php');

define( 'PAGE_ID', 'profile_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$userid = $_SESSION['UserId'];

$sectionid = $_GET[ 'sectionid' ];

$sql = 'select username from ! where id = ?';

$t->assign('username', $db->getOne($sql, array( USER_TABLE, $userid ) ) );

if ( $sectionid == '' ) {
	$sectionid = 1;
}
//Query to reterive records from osdate_questions table
// sorted descending on mandatory: that is mandatory fields should be displayed first
$sqlquestion = 'select id, question, mandatory, description, guideline, maxlength, control_type from ! where enabled = ? and section = ? and question <> ? order by mandatory desc, displayorder';
	
$questionrs = $db->getAll( $sqlquestion, array( QUESTIONS_TABLE, 'Y', $sectionid, '' ) );
	
$index = 0;

foreach ( $questionrs as $index=>$row ) {
	
	//Query to reterive record from osdate_questionoptions table
	$sqlqoption = 'Select * from ! where enabled = ? and questionid = ? order by id ';
					
	$optionsrs = $db->getAll( $sqlqoption, array( OPTIONS_TABLE, 'Y', $row['id'] ) ) ;
		
	//Place options of question at the last of array
	$row['options'] = makeOptions ( $optionsrs  );
		
	//Query to reterive user preferences
	$sqluserpref = 'Select questionid, answer from ! where userid = ? and questionid = ?';

	$userprefrs = $db->getAll( $sqluserpref, array( USER_PREFERENCE_TABLE, $userid, $row['id'] ) ) ;
					
	$row['userpref'] = makeAnswers ( $userprefrs );
				
	//Create questions array
	$data[ $index ] = $row;
		
	//frees array
}


						
$t->assign ( 'mandatory_question_error', $lang['errormsgs'][$_GET['errid']] );	

$t->assign ( 'sectionid', $_GET['sectionid'] );		

$t->assign( 'frmname', 'frm' . $sectionid );	

$t->assign ( 'head', $sections[ $sectionid ] );

$t->assign ( 'data', $data );
	
$t->assign('rendered_page', $t->fetch('admin/editprofilequestions.tpl'));
		
$t->display('admin/index.tpl');	
		
?>