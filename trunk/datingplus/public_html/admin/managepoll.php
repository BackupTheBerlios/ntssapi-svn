<?php
//Include init.php
if ( !defined( 'SMARTY_DIR' ) ) {	
		include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'poll_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

//Default Sorting
if( $_GET['sort'] == '' ) {
	
	$sort = ' pollid asc ';

} else if ( $_GET['sort'] == $lang['col_head_sendtime'] ) {
	
	$sort = 'date '. checkSortType ( $_GET['type'] );

} else {

	$sort = findSortBy();

}

//For Editing Polls
if ( $_GET['edit'] ) {

	$sqledit = 'SELECT * from ! Where pollid = ?';
			
	$data = $db->getRow( $sqledit, array( POLLS_TABLE, $_GET['edit'] ) );

	$data['question'] = stripslashes($data['question']);
		
	$t->assign( 'lang', $lang );
	
	$t->assign( 'error', $lang['poll_error'][ $_GET['errid'] ] );
	
	$t->assign( 'data', $data );
	
	$t->assign('rendered_page', $t->fetch('admin/polledit.tpl'));
		
	$t->display( 'admin/index.tpl' );
	exit;
}

//For Deletion of Polls
if ( $_POST['frm'] == 'frmDelPoll' && $_POST['delaction'] == 'Yes') {

	$sql = 'DELETE FROM ! WHERE pollid = ?';
					
	$rs = $db->query( $sql, array( POLLOPTS_TABLE, $_POST['txtid'] ) );

	$sqldel = 'DELETE FROM ! WHERE pollid = ?';
	
	$result = $db->query( $sqldel, array( POLLS_TABLE, $_POST['txtid'] ) );
	
	header('location:managepoll.php');
	
	exit;
}

//Insert Poll
if ( $_POST['frm'] == 'frmAddPoll') {

	$poll = $_POST['txtpoll'];
	
	$poll = eregi_replace('</?[a-z][a-z0-9]*[^<>]*>', '', $poll );
	
	$sqlins = 'INSERT INTO ! (question, date , active) VALUES (?, ?, ?)';
			   
	$result = $db->query( $sqlins, array( POLLS_TABLE, $poll, time(), '0' ) );
	
	header('location:managepoll.php');
	
	exit;
}//End of if

//Delete Group Poll
if ( $_POST['groupaction'] == $lang['delete_selected'] ) {

	$polls = $_POST['txtcheck'];
	
	foreach( $polls as $val ) {
	
		$sql = 'DELETE FROM ! WHERE pollid = ?';
					
		$db->query( $sql, array( POLLOPTS_TABLE, $val ) );
	
		$db->query( $sql, array( POLLS_TABLE, $val ) );
		
	}
	
	header('location:managepoll.php');
	
	exit;
// Enable polls
} elseif ( $_POST['groupaction'] == $lang['enable_selected'] ) {

	$polls = $_POST['txtcheck'];
	
	foreach( $polls as $val ) {
	
		$sql = 'update ! set enabled = ? WHERE pollid = ?';

		$db->query( $sql, array( POLLS_TABLE, 'Y', $val ) );
					
		$db->query( $sql, array( POLLOPTS_TABLE, 'Y', $val ) );
			
	}
	
	header('location:managepoll.php');
	
	exit;
// Disable selected polls
} elseif ( $_POST['groupaction'] == $lang['disable_selected'] ) {

	$polls = $_POST['txtcheck'];
	
	foreach( $polls as $val ) {
	
		$sql = 'update ! set enabled = ? , active= ? WHERE pollid = ?';

		$db->query( $sql, array( POLLS_TABLE, 'N','0',  $val ) );
					
		$sql = 'update ! set enabled = ? WHERE pollid = ?';

		$db->query( $sql, array( POLLOPTS_TABLE, 'N', $val ) );
			
	}
	
	header('location:managepoll.php');
	
	exit;

// Activate selected polls
} elseif ( $_POST['groupaction'] == $lang['activate'] ) {

	$polls = $_POST['txtcheck'];
	
	foreach( $polls as $val ) {
	
		$sql = 'update ! set active = ?, enabled=? WHERE pollid = ?';

		$db->query( $sql, array( POLLS_TABLE, '1','Y',  $val ) );
			
	}
	
	header('location:managepoll.php');
	
	exit;
}



if ( $_REQUEST['active'] == 'poll' ) {

	$id = $_REQUEST['pollid'];
	
	$sql = 'UPDATE ! SET active = ? WHERE pollid = ?';
	
	$result = $db->query( $sql, array( POLLS_TABLE, '1', $id ) );	
	
	header('location:managepoll.php');
	
	exit;
}


$sqlsection = 'SELECT * from ! order by ' . $sort;
				
$sectionrs = $db->getAll( $sqlsection, array( POLLS_TABLE ) );

$data = array();

foreach ( $sectionrs as $row ) {
	$row['question'] = stripslashes($row['question']);
	
	if ($row['suggested_by'] > 0) {
		
		$row['suggested_by_username'] = $db->getOne('select username from ! where id = ?', array( USER_TABLE, $row['suggested_by'] ) );
	}
	$data[] = $row;
}

$t->assign( 'lang', $lang );

$t->assign( 'sort_type', checkSortType( $_GET['type'] ) );

$t->assign( 'data', $data );

$t->assign('rendered_page', $t->fetch('admin/managepolls.tpl'));
		
$t->display( 'admin/index.tpl' );

?>