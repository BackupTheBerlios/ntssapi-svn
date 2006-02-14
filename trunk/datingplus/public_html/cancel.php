<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

if ($_POST['action'] == '' or !$_POST['action']) {
	
	$t->assign('step','1');
	
} else {

	if ($_POST['action'] == $lang['cancel_opt01']) {
	/* Cancel membership */

		$username = $db->getOne('select username from ! where id = ?',array( USER_TABLE, $_SESSION['UserId'] ) ) ;
		
		$sql = 'update ! set status=?, active=?, regdate = ? where id = ?';
		
		$db->query($sql, array( USER_TABLE, 'Cancel', 0, time(), $_SESSION['UserId'] ) );
		
		if ( $config['phpbb_installed'] == 'Y' ) {
		
			$sql = "update ! set user_active = ? where username = ? ";
		
			$db->query( $sql, array( 'phpbb_users', 0, $username ) );
		}

		$sql = 'DELETE FROM ! WHERE userid = ?';

		$db->query( $sql, array( ONLINE_USERS_TABLE, $_SESSION['UserId'] ) );

		session_destroy();
		
		session_start();

		$t->assign('step','2');
		
	} else {

		$t->assign('step','3');
	
	}

}

$t->assign( 'rendered_page', $t->fetch( 'cancel.tpl' ) );
	
$t->display('index.tpl');

?>