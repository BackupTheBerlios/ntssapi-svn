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
		
		
if( $_POST['frm'] == 'frmGroupDelete' ){

	foreach( $_POST['txtid'] as $arr ) {
	
		$id = $arr;
		
		$sql = 'SELECT displayorder, section FROM ! WHERE id = ?';
		
		$displayorder = $db->getRow( $sql, array( QUESTIONS_TABLE, $id ) );
					
		$sql = 'SELECT MAX(displayorder) as maxorder FROM !';
		
		$maxorder = $db->getOne( $sql, array( QUESTIONS_TABLE ) );
			
		//move the records below this record up
		$i=$displayorder['displayorder'] + 1;
		
		while ($i <= $maxorder ){
			
			$sql = 'UPDATE ! SET displayorder = ? WHERE displayorder = ? ';
				
			$db->query( $sql, array(QUESTIONS_TABLE, $i-1 , $i));

			$i++;
		}
			
		//now delete the record
		$sqldel = 'DELETE FROM ! WHERE id = ?';
		//echo $sqldel;
		$db->query ( $sqldel, array(QUESTIONS_TABLE, $id) );
		
	}
		
	header ( "location:sectionquestions.php?sectionid=" . $displayorder['section'] );
	exit;
}
	
$arr = $_POST[ 'txtcheck' ];

if ( count( $arr ) == 0 ) {

	header( 'location: sectionquestions.php?sectionid=' . $_POST['sectionid'] . '&msg=' . $lang['no_select_msg'] );
	exit;
	
}	
if ( $_POST['groupaction'] == $lang['enable_selected'] ) {

	foreach ( $arr as $id ) {
	
		$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';
		
		$result = $db->query( $sql, array( QUESTIONS_TABLE, 'Y', $id ) );
		
	}
	
	header ( "location:sectionquestions.php?sectionid=" . $_POST['sectionid'] );
	exit;
} elseif ($_POST['groupaction'] == $lang['disable_selected'] ) {

	foreach ( $arr as $id ) {
	
		$sql = 'UPDATE ! SET enabled = ? WHERE id = ?';
		
		$result = $db->query( $sql, array( QUESTIONS_TABLE, 'N', $id ) );
		
	}
	
	header ( "location:sectionquestions.php?sectionid=" . $_POST['sectionid'] );
	exit;
	
} else if ($_POST['groupaction'] == $lang['delete_selected'] ) {

	$sql = 'SELECT * from ! Where 0 ';
	
	foreach ( $arr as $questionid ) {
		$sql .= " or id=" . $questionid;
	}
	$rsQuestions = $db->getAll( $sql, array( QUESTIONS_TABLE ) );
	$data = array();
	foreach ( $rsQuestions as $row ) {
		$row['question'] = stripslashes($row['question']);
		$row['description'] = stripslashes($row['description']);
		$row['guideline'] = stripslashes($row['guideline']);
		$row['extsearchhead'] = stripslashes($row['extsearchhead']);
		$data[] = $row;
	}
			
	$t->assign( 'lang', $lang );
	
	$t->assign( 'data', $data );
	
	$t->assign('rendered_page', $t->fetch('admin/groupquestiondel.tpl'));
		
	$t->display( 'admin/index.tpl' );	
	exit;
}		
?>