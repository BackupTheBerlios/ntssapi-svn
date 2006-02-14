<?php
if ( !defined( 'SMARTY_DIR' ) ) {

	include_once( 'init.php' );

}

if ($_POST['groupaction'] == $lang['delete_selected'] ) {

	$checked = $_POST['txtcheck'];
	
	foreach ($checked as $val) {
	
		$sql = 'DELETE from ! where id = ? ';

		$db->query($sql, array( VIEWS_WINKS_TABLE, $val ) );
	
	}

	$t->assign('errid',($act=='V'?'70':'71') );

}

if ($_GET['id'] != '' && $_GET['remove'] == '1' ) {

	$sql = 'delete from ! where id = ?';
	
	$db->query($sql, array( VIEWS_WINKS_TABLE, $_GET['id'] ) );

	$t->assign('errid',($_GET['act']=='V'?'70':'71') );
}

$sql = 'select distinct lis.id, lis.userid, lis.ref_userid, lis.act_time, usr.username from ! as lis, ! as usr where lis.userid = ? and lis.ref_userid = usr.id and act = ? and usr.id <> ? order by usr.username ';

$list = $db->getAll($sql, array( VIEWS_WINKS_TABLE, USER_TABLE, $_SESSION['UserId'], $_REQUEST['act'], $_SESSION['UserId'] ) );
	
$t->assign('list', $list);

$t->assign('act', $_GET['act']);

$t->assign('rendered_page', $t->fetch('listviewswinks.tpl') );

$t->display('index.tpl');


?>