<?php
if ( !defined( 'SMARTY_DIR' ) ) {

	include_once( 'init.php' );

}

$show=($_GET['show'])?$_GET['show']:0;

if ($_POST['groupaction'] == $lang['delete_selected'] ) {
	
	$checked = $_POST['txtcheck'];
	
	$act = $_POST['act'];
	
	foreach ($checked as $val) {

		$sql = 'DELETE from ! where id = ?';

		$db->query($sql, array( BUDDY_BAN_TABLE, $val ) );
	
	}

	$t->assign('errid', REMOVEDFROMLIST);
	
	$show = 1;
}

if ($_GET['remove'] == '1') {
	/* Remove from the list */

	$sql = 'DELETE from ! where id = ? ';

	$db->query($sql, array( BUDDY_BAN_TABLE, $_GET['id'] ) );

	$t->assign('errid', REMOVEDFROMLIST);
	
	$show = 1;
} 

if ($show != "1" ) {

	/* first get both the username and ref_username i.e.  login names */

	$sql = 'SELECT id, username	FROM ! WHERE id = ? AND status <> ?';

	$user = $db->getRow($sql, array( USER_TABLE, $_SESSION['UserId'], $lang['status_enum']['suspended'] ) );

	$username = $user['username'];	

	$userid = $user['id'];

	$ref_user = $db->getRow($sql, array( USER_TABLE, $_GET['ref_id'], $lang['status_enum']['suspended'] ) );

	$ref_username = $ref_user['username'];	

	$ref_userid = $ref_user['id'];

	$errid = '';

	if ($_GET['act'] == 'buddy') {
		$list='F';
		$errid = ADDEDTOBUDDYLIST;
	} elseif ( $_GET['act'] == 'hot' ) {
		$list='H';
		$errid = ADDEDTOHOTLIST;
	} else {
		$list='B'; 
		$errid = ADDEDTOBANLIST;
	}	

	/* Check if the ref_username is already in the list or not.. */
	$sql = 'select id from ! where username = ? and ref_username = ? and act = ?';

	$r=$db->getOne($sql, array( BUDDY_BAN_TABLE, $username, $ref_username, $list ) );
	if ($r > 0) {
	/* Already in the list, just ignore */
	} else {

		$ins_sql = 'insert into ! ( username, act, ref_username, act_date ) values ( ?, ?, ?, ? )';

		$db->query($ins_sql, array( BUDDY_BAN_TABLE, $username, $list, $ref_username, time() ) );
				
		/* Now delete if this username is in the opposite list. 
			i.e. if we are adding buddy, then we should remove from
			ban list, if available. Otherwise, vice versa  */

		if ($list == 'F' or $list == 'B') {

			if ($list == 'F') { $list = 'B'; }
			elseif ($list == 'B') { $list = 'F'; } 

			$sql = 'select id from ! where username = ? and ref_username = ? and act = ?';

			$xr=$db->getOne($sql, array( BUDDY_BAN_TABLE, $username, $ref_username, $list ) );

			if ($xr > 0) {
				/* Remove from the list */

				$db->query('delete from ! where id = ?', array( BUDDY_BAN_TABLE, $xr ) );
			}
		}

	}

	header("location: ".$_GET['rtnurl']."?id=".$_GET['ref_id']."&errid=".$errid);	
	exit;	

} else {
	/* Show the list  */

	$sql = 'select lis.ref_username, lis.act_date, usr.id as userid, lis.id as lisid from ! as lis, ! as usr where lis.username = ? and lis.act = ? and lis.ref_username = usr.username order by lis.ref_username ';

	$list = $db->getAll($sql, array( BUDDY_BAN_TABLE, USER_TABLE, $_SESSION['UserName'], $_REQUEST['act'] ) );
	
	$t->assign('list', $list);

	$t->assign('act', $_REQUEST['act'] );

	$t->assign('rendered_page', $t->fetch('buddybanlist.tpl') );

	$t->display('index.tpl');

}	
?>