<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'section_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}	

$question = $_POST[ 'txtquestion' ];

$description = $_POST[ 'txtdescription' ];		

$guideline = $_POST[ 'txtguideline' ];		

$controltype = $_POST[ 'txtcontroltype' ];

$maxlength = $_POST[ 'txtmaxlength' ];

$options = $_POST[ 'txtoptions' ];

$mandatory = $_POST[ 'txtmandatory' ];

$section = $_POST[ 'txtsection' ];

$enabled = $_POST[ 'txtenabled' ];

$err =0;

if ( $question == '' ) {

	$err = 1;
	
} elseif ( (($controltype == 'textarea') || ($controltype == 'input')) && ( $maxlength == '' ) ) {

	$err = 2;
	
}			

if (  $err != 0  ) ) {

	header ( "Location:addquestion.php?errid=$err" );
	exit();
	
}
?>