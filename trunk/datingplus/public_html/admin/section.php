<?php
	//Include init.php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'section_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

//Default Sorting
if( $_GET['sort'] == '' ) {

	$sort = 'displayorder asc ';

} else if( $_GET['sort'] == $lang['col_head_name'] ) {
	
		$sort = 'section '. checkSortType ( $_GET['type'] );

} else {

	$sort = findSortBy();

}

//For Editing Sections
if ( $_GET['edit'] ) {

	$sqledit = 'SELECT id, section, enabled from ! Where id = ?';
			
	$data = $db->getRow( $sqledit, array( SECTIONS_TABLE, $_GET['edit'] ));
		
	$t->assign( 'lang', $lang );
	
	$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );
	
	$t->assign( 'data', $data );
	
	$t->assign('rendered_page', $t->fetch('admin/sectionedit.tpl'));
		
	$t->display( 'admin/index.tpl' );
	exit;
}

//For Deletion of sections
if ( $_POST['frm'] == 'frmDelSection' && $_POST['delaction'] == 'Yes') {

	$id = $_POST['txtid'];

	$sql = 'SELECT displayorder FROM ! WHERE id = ?';
	
	$displayorder = $db->getOne( $sql, array( SECTIONS_TABLE, $id ) );
		
	$sql = 'SELECT MAX(displayorder) as maxorder FROM ! ';
	
	$maxorder = $db->getOne( $sql, array( SECTIONS_TABLE ) );
	
	//move the records below this record up
	$i=$displayorder['displayorder'] + 1;
	
	while ($i <= $maxorder['maxorder'] ){
	
		$sql = 'UPDATE ! SET displayorder = ? WHERE displayorder = ? ';
		
		$db->query( $sql, array( SECTIONS_TABLE,  $i-1 , $i ));
		
		$i++;
	}
	
	//now delete the record
	$sqldel = 'DELETE FROM ! WHERE id = ?';
	
	$db->query( $sqldel, array( SECTIONS_TABLE, $id ) );
	
	header('location:section.php');
	exit;
}

//Insert in Section with max displayorder
if ( $_POST['frm'] == 'frmAddSection') {

	$section = trim( $_POST['txtsection'] );
	
	$enabled = trim( $_POST['txtenabled'] );
			
	$sql = 'SELECT MAX(displayorder)+1 as orderno FROM ! ' ;
	
	$row = $db->getRow( $sql, array( SECTIONS_TABLE ) );
	
	$sqlins = 'INSERT INTO ! (section, enabled , displayorder) VALUES (?, ?, ? )';

	$db->query( $sqlins, array( SECTIONS_TABLE, $section, $enabled,  $row['orderno'] ) );
	
	header('location:section.php');
	exit;
}//End of if

if ( $_GET['moveup'] ) {

	$sql = 'SELECT displayorder FROM ! WHERE id = ?';
	
	$nrow = $db->getRow( $sql, array( SECTIONS_TABLE, $_GET['moveup'] ) );
	
	//to check whether it is at the highest order
	//if not then move up
	if ( $nrow['displayorder'] != 1){

		$sql = 'SELECT id, displayorder FROM ! WHERE displayorder = ?';
		
		$prow = $db->getRow( $sql, array( SECTIONS_TABLE, ($nrow['displayorder']-1) ) );
				
		$sqla = 'UPDATE ! SET displayorder = ? WHERE displayorder = ? AND id = ?';
			
		$db->query( $sqla, array( SECTIONS_TABLE, $nrow['displayorder'], $prow['displayorder'], $prow['id'] ));
	
		$db->query( $sqla, array( SECTIONS_TABLE, $nrow['displayorder']-1, $nrow['displayorder'], $_GET['moveup'] ));

		header('location:section.php');
		exit;
	}
	
	header('location:section.php?msg=Section is already at the top');

	exit;
}

if ( $_GET['movedown'] ) {

	$sql = 'SELECT displayorder FROM ! WHERE id = ?';

	$nrow = $db->getRow( $sql, array( SECTIONS_TABLE,$_GET['movedown'] ) );

	//get maximum order of sections
	$sql = 'SELECT MAX(displayorder) as maxorder FROM !';

	$maxorder = $db->getOne( $sql, array( SECTIONS_TABLE ) );

	//to check whether it is at the lowest order
	//if not then move down
	if ( $nrow['displayorder'] !=  $maxorder['maxorder'] ){

		$sql = 'SELECT id, displayorder FROM ! WHERE displayorder = ?';

		$prow = $db->getRow( $sql, array( SECTIONS_TABLE,($nrow['displayorder']+1) ) );

		$sqla = 'UPDATE ! SET displayorder = ? WHERE displayorder = ? AND
			id = ?';

		$db->query( $sqla , array( SECTIONS_TABLE, ($nrow['displayorder']+1), $nrow['displayorder'], $_GET['movedown'] ));

		$db->query( $sqla , array( SECTIONS_TABLE, $nrow['displayorder'], $prow['displayorder'], $prow['id'] ));

		header('location:section.php');
		exit;
	}

	header('location:section.php?msg=Section is already at the bottom');

	exit;
} 		
//Insert new section
elseif ( $_GET['insert'] == 'question') {

	$section_name = $db->getOne('SELECT section from ! Where id = ?', array( SECTIONS_TABLE, $_GET['sectionid'] ) );

	$t->assign('sectionname', $section_name);
	
	$t->assign( 'lang', $lang );
	
	$t->assign( 'error', $lang['admin_error_msgs'][ $_GET['errid'] ] );			
	
	$t->assign('rendered_page', $t->fetch('admin/questionins.tpl'));
		
	$t->display( 'admin/index.tpl' );
	
	exit;
}

$sqlsection = 'SELECT id, section, displayorder, enabled from ! order by ' . $sort;
				
$data = $db->getAll( $sqlsection, array(SECTIONS_TABLE) );

$t->assign( 'lang', $lang );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/section.tpl'));
		
$t->display( 'admin/index.tpl' );


?>