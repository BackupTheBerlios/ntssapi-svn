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

	
$sort = findSortBy();


if ( $_GET['questionid']  ) {

	//check for delete parameter in URL
	//if yes then do delete action
	if($_GET['delete']) {
	
		$id	= 	trim( $_GET['delete'] );
		
		$sqlupd = 'DELETE FROM ! WHERE id = ?';
		
		$result = $db->query( $sqlupd, array( OPTIONS_TABLE, $id ) );
		
		//now after deletion remove delete parameter from URL
		header ( 'location:sectionquestiondetail.php?sectionid=' . $_GET['sectionid'] . '&questionid=' . $_GET['questionid']  );
		
		exit;
	}elseif ($_POST['frm'] == 'frmAddOption' ){

		$sqlins = 'INSERT INTO ! (answer,questionid,enabled) values(?, ?, ?)';
			
		$db->query( $sqlins, array( OPTIONS_TABLE, $_POST['txtanswer'], $_POST['txtquestion'], $_POST['txtenabled'] ) );

		header ( 'location:sectionquestiondetail.php?sectionid=' . $_GET['sectionid'] . '&questionid=' . $_GET['questionid']  );
		exit;
	}

	$sort = findSortBy();
	
	//get question from DB and add it to smarty
	$sql = 'SELECT * from ! Where id = ?' ;
	
	$question = $db->getRow( $sql, array( QUESTIONS_TABLE, $_GET['questionid'] ) );
		
	$t->assign('question', $question);
	
	//get question options from DB and add it to smarty

	$sql = 'SELECT * from ! Where questionid = ? order by ' . $sort;
				
	$optdata = $db->getAll( $sql, array(OPTIONS_TABLE,$_GET['questionid'] ) );
	
	$optds = array();
	
	foreach ( $optdata as $opts) {
	
		$opts['answer'] = stripslashes($opts['answer']);

		$optds[] = $opts;	
	}

	$t->assign('options', $optds);
	
	$t->assign( 'lang', $lang );
	
	$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );
	
	$t->assign('rendered_page', $t->fetch('admin/sectionquestiondetail.tpl'));
		
	$t->display( 'admin/index.tpl' );

	exit;

} elseif ( $_GET['edit'] ) {

	$sql = 'SELECT * from ! Where id = ?';
			
	$opt = $db->getRow( $sql, array( OPTIONS_TABLE, $_GET['edit']) );
	
	$opt['answer'] =  stripslashes($opt['answer']);
	
	$t->assign('option', $opt );
	
	$t->assign( 'lang', $lang );
	
	$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );	

	//Display index.tpl file
	
	$t->assign('rendered_page', $t->fetch('admin/optionedit.tpl'));

	$t->display( 'admin/index.tpl' );
	
	exit;		

} else {

	header('location:section.php');
	exit;
	
}

?>