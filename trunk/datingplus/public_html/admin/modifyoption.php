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
		
if ($_POST['frm'] !='frmQuestionDetail'){

	$id 	= 	trim( $_POST['txtid'] );
	
	$answer	= 	$_POST['txtanswer'];	
	
	$enable	= 	$_POST['txtenabled'];				
	
			
	$err = 0;
	
	if ( $answer == '' ) {
	
		$err = FIELDS_BLANK;
		
	}
	
	if ( $err != 0 ) {
	
		header ( 'location:sectionquestiondetail.php?sectionid=' . $_POST['txtsectionid'] . '&edit=' . $_POST['txtid'] . '&errid=' . $err );
		exit;
		
	}
	
	$sqlupd = 'UPDATE ! SET answer = ?, enabled = ?  WHERE id = ?';
	
	$result = $db->query( $sqlupd , array( OPTIONS_TABLE, $answer, $enable, $id ));

	header ( 'location:sectionquestiondetail.php?sectionid=' . $_POST['txtsectionid'] . '&edit=' . $_POST['txtid'] );
} else {

	$arr = $_POST[ 'txtcheck' ];
	
	if ( $_POST['groupaction'] == $lang['enable_selected'] && count($arr) > 0) {
		
		foreach ( $arr as $id ) {
		
			$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';
			
			$result = $db->query( $sql, array( OPTIONS_TABLE , 'Y', $id ) );
					
		}
		
	} elseif ($_POST['groupaction'] == $lang['disable_selected'] && count($arr) > 0) {
	
		foreach ( $arr as $id ) {
		
			$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';
			
			$result = $db->query( $sql, array( OPTIONS_TABLE , 'N', $id ) );
			
		}

	}
			

	header ( "location:sectionquestiondetail.php?sectionid=" . $_POST['txtsectionid'] . "&questionid=" . $_POST['txtquestionid']);
}
?>