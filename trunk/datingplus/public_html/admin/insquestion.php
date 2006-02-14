<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}	

include ( 'sessioninc.php' );
	
define( 'PAGE_ID', 'section_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}
	
$id 			= 	trim( $_POST['txtid'] );

$question 		= 	trim( $_POST['txtquestion'] );

$description 	= 	trim( $_POST['txtdescription'] );

$guideline 		= 	trim( $_POST['txtguideline'] );	

$controltype 	= 	$_POST['txtcontroltype'];

$maxlength 		= 	trim( $_POST['txtmaxlength'] );

$mandatory 		= 	$_POST['txtmandatory'];

$section 		= 	$_POST['txtsection'];	

$extsearchable 	= 	$_POST['txtextsearch'];		

$extsearchhead 	= 	$_POST['txextsearchhead'];			

$enabled 		= 	$_POST['txtenabled'];				
		
//get maximum order of sections
$sql = 'SELECT MAX(displayorder) as maxorder FROM ! WHERE section = ?';
	
$maxorder = $db->getOne( $sql, array( QUESTIONS_TABLE, $_POST['txtsection'] ) );

$sqlupd = "INSERT INTO ! ( question, description, guideline, control_type, maxlength, mandatory, section, displayorder, extsearchable, extsearchhead, enabled ) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

$result = $db->query( $sqlupd, array( QUESTIONS_TABLE, $question, $description, $guideline, $controltype, $maxlength, $mandatory, $section, ($maxorder+1), $extsearchable, $extsearchhead, $enabled ) );

header ( 'location:section.php');
?>