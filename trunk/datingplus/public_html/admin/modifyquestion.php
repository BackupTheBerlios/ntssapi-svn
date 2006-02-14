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

$question 		= 	str_replace('?','\\?',trim( $_POST['txtquestion'] ) );

$description 	= 	str_replace('?','\\?',trim( $_POST['txtdescription'] ) );

$guideline 		= 	str_replace('?','\\?',trim( $_POST['txtguideline'] ) );	

$controltype 	= 	$_POST['txtcontroltype'];

$maxlength 		= 	trim( $_POST['txtmaxlength'] );

$mandatory 		= 	$_POST['txtmandatory'];

$section 		= 	$_POST['txtsection'];	

$extsearchable 	= 	$_POST['txtextsearch'];		

$extsearchhead 	= 	str_replace('?','\\?',$_POST['txextsearchhead']);			

$enabled 		= 	$_POST['txtenabled'];				
		
$err = 0;

if ( $question == '' || $maxlength == '' ) {
	$err = FIELDS_BLANK;
}

if ( $err != 0 ) {
	header ( 'location:sectionquestions.php?edit=' . $_POST['txtid'] . '&errid=' . $err );
	exit;
}

$sqlupd = "UPDATE ! SET 
			question		='" . addslashes($question) . "',
			description		='" . addslashes($description) . "',
			guideline		='" . addslashes($guideline) . "',
			control_type	='" . $controltype . "',
			maxlength		='" . $maxlength . "',
			mandatory		='" . $mandatory . "',
			section			='" . $section . "',
			extsearchable	='" . $extsearchable . "',
			extsearchhead	='" . addslashes($extsearchhead) . "',
			enabled			='" . $enabled . "' 
		  WHERE id = ?";

$result = $db->query( $sqlupd, array( QUESTIONS_TABLE, $_POST['txtid'] ) );

header ( 'location:sectionquestions.php?edit=' . $_POST['txtid'] );
exit;
?>