<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

define( 'PAGE_ID', 'poll_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}
	
$id = trim( $_POST['txtid'] );

$question = trim( $_POST['txtquestion'] );
	
$err = 0;
if ( $question == '' ) {

	$err = OPTION_BLANK;
}

if ( $err != 0 ) {

	header ( 'location:managepoll.php?edit=' . $_POST['txtid'] . '&errid=' . $err );
	exit;
	
}

$dat = strtotime( $_POST['txtdateYear'].'-'.$_POST['txtdateMonth'].'-'.$_POST['txtdateDay'] );

$question = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $question );

$sqlupd = 'UPDATE ! SET question = ?, date = ?  WHERE pollid = ?';
		  
$result = $db->query( $sqlupd, array( POLLS_TABLE, $question, $dat, $id ) );

header ( 'location:managepoll.php' );
?>