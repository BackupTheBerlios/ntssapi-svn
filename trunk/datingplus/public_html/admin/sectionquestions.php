<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

define( 'PAGE_ID', 'section_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}
	
if( $_GET['sort'] == '' ) {

	$sort = 'displayorder asc';

} else {

	$sort = findSortBy();

}	

if ( $_GET['edit'] ) {

	$sqledit = 'SELECT * from ! Where id = ?';
	
	$data = $db->getRow( $sqledit, array( QUESTIONS_TABLE, $_GET['edit'] ) );
		
	$t->assign( 'lang', $lang );
	
	$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );
			
	$t->assign( 'data', $data );
	
	$t->assign('rendered_page', $t->fetch('admin/questionedit.tpl'));

	$t->display( 'admin/index.tpl' );
	
	exit;
}

//For Deletion of sections
if ( $_POST['frm'] == 'frmDelQuestion'){

	$id = $_POST['txtid'];
	
	$section = $_POST['txtsectionid'];
	
	$sql = 'SELECT displayorder FROM ! WHERE id = ? AND section = ?';
		
	$displayorder = $db->getOne( $sql, array( QUESTIONS_TABLE, $id, $section ) );
	
	$sql = 'SELECT MAX(displayorder) as maxorder FROM !	WHERE section = ?';
		
	$maxorder = $db->getOne( $sql, array( QUESTIONS_TABLE, $section ) );
	
	//move the records below this record, one step up
	$i=$displayorder + 1;
	
	while ($i <= $maxorder ){
	
		$sql = 'UPDATE ! SET displayorder = ? WHERE displayorder = ? 
			AND section = ?';
			
		$db->query( $sql, array( QUESTIONS_TABLE, $i-1 , $i, $section ));
		
		$i++;
	}

	$sqldel = 'DELETE FROM ! WHERE id = ? and section = ?';
	
	$result = $db->query( $sqldel, array( QUESTIONS_TABLE, $id, $section ) );
	
	$_GET['sectionid'] = $section;
}

//Move order of question 1 level up
if ( $_GET['moveup'] ) {

	$sql = 'SELECT displayorder FROM ! WHERE id = ? AND section = ?';
		
	$nrow = $db->getRow( $sql, array( QUESTIONS_TABLE, $_GET['moveup'], $_GET['sectionid'] ) );
	
	if ( $nrow['displayorder'] != 1){
	
		$sql = 'SELECT id, displayorder FROM ! WHERE displayorder = ? AND section = ?';
			
		$prow = $db->getRow( $sql, array( QUESTIONS_TABLE, ($nrow['displayorder']-1), $_GET['sectionid'] ) );
		
		$sqla = 'UPDATE ! SET displayorder = ? WHERE displayorder = ? AND
			id = ? AND section = ?';
			
		$db->query( $sqla , array( QUESTIONS_TABLE, $nrow['displayorder'], $prow['displayorder'], $prow['id'], $_GET['sectionid'] ));
	
		$db->query( $sqla , array( QUESTIONS_TABLE, ($nrow['displayorder']-1), $nrow['displayorder'], $_GET['moveup'], $_GET['sectionid'] ));

		header('location:sectionquestions.php?sectionid=' . $_GET['sectionid']);
		exit;
		
	}
	
	header('location:sectionquestions.php?sectionid=' . $_GET['sectionid'] . '&err='.QUESTION_ON_TOP );

	exit;
	
}

//Move order of question 1 level down
if ( $_GET['movedown'] ) {

	$sql = 'SELECT displayorder FROM !  WHERE id = ? AND section = ?';
		
	$nrow = $db->getRow( $sql, array( QUESTIONS_TABLE , $_GET['movedown'], $_GET['sectionid'] ) );
	
		
	//get maximum order of sections
	$sql = 'SELECT MAX(displayorder) as maxorder FROM ! WHERE section = ?';
		
	$maxorder = $db->getOne( $sql, array( QUESTIONS_TABLE, $_GET['sectionid'] ) );

	if ( $nrow['displayorder'] !=  $maxorder['maxorder'] ){
		
		$sql = 'SELECT id, displayorder FROM ! WHERE displayorder = ? AND section = ?';
		
		$prow = $db->getRow( $sql, array( QUESTIONS_TABLE, ($nrow['displayorder']+1), $_GET['sectionid'] ) );
				
		$sqla = 'UPDATE ! SET displayorder = ? WHERE displayorder = ? AND
			id = ? AND section = ?';
			
		$db->query( $sqla , array( QUESTIONS_TABLE, $nrow['displayorder']+1, $nrow['displayorder'], $_GET['movedown'], $_GET['sectionid'] ));
	
		$db->query( $sqla , array( QUESTIONS_TABLE, ($nrow['displayorder']), $prow['displayorder'], $prow['id'], $_GET['sectionid'] ));

		header( 'location:sectionquestions.php?sectionid=' . $_GET['sectionid'] );
		exit;
	}
	header('location:sectionquestions.php?sectionid=' . $_GET['sectionid'] . '&err='  . QUESTION_AT_BOTTOM );
	exit;
}


//Get Section id, name
$sql = 'SELECT id, section FROM ! WHERE id = ?';

$rowsection = $db->getRow( $sql, array( SECTIONS_TABLE, $_GET['sectionid'] ) );

$sql = 'SELECT * from ! WHERE section = ? order by ' . $sort;

$data = $db->getAll( $sql, array( QUESTIONS_TABLE, $_GET['sectionid'] ) );
	
$t->assign( 'lang', $lang );

$t->assign( 'sectionname', $rowsection['section'] );

$t->assign( 'sectionid', $rowsection['id'] );	

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/sectionquestions.tpl'));

$t->display( 'admin/index.tpl' );



?>	