<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'admin_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$_SESSION['txtuname'] = $name = $_POST['txtuname'];

$pwd = $_POST['txtpassword'];

$_SESSION['txtfullname'] = $fullname = $_POST['txtfullname'];

$superuser = $_POST['txtsuperuser'];

$enabled = $_POST['txtenabled'];


$err = 0 ;

if ( $name == '' ) {

	$err = USERNAME_BLANK;	

} elseif ( $pwd == '' ) {

	$err = PASSWORD_BLANK;	

} elseif ( $fullname == '' ) {

	$err = FULLNAME_BLANK;	

}

if ( $err > 0 ) {

	header( 'location:adminins.php?errid=' . $err );
	exit;

}

$sql = 'SELECT id FROM ! WHERE username = ? ';

$rid = $db->getOne( $sql, array( ADMIN_TABLE, $name ) );

$sqlc = 'SELECT count(*) as aacount from ! where username = ?';

$rowc = $db->getOne( $sqlc, array( USER_TABLE, $name, ) );

$rowf = $db->getOne( $sqlc, array( 'phpbb_users', $name, ) );

if ( $rid > 0 or $rowc > 0 or $rowf > 0 ) {

	header( 'location:adminins.php?errid='.ALREADY_EXISTS );
	exit;
}

$pwd = md5( $pwd );

$sql = 'INSERT INTO ! ( username, password, fullname, super_user, enabled ) VALUES ( ?, ?, ?, ?, ? )';

$db->query( $sql, array(ADMIN_TABLE, $name, $pwd, $fullname, $superuser, $enabled ) );

$lastid = getLastId( ADMIN_TABLE );

$sql = "INSERT INTO ! (  adminid,  profie_approval, profile_mgt, change_pwd ) VALUES (  ?, ?, ?, ? )";

$db->query( $sql, array( ADMIN_RIGHTS_TABLE, $lastid, '1', '1', '1' ) );

$userlevel=2;

if ($superuser == 'Y') { $userlevel = 1; }

if ( $config['phpbb_installed'] == 'Y' ) {

	$userid = $db->getOne('select max(user_id)+1 from !', array( 'phpbb_users' ) );
	
	$sql = 'INSERT INTO ! ( user_id, username, user_password, user_level, user_regdate ) VALUES ( ?, ?, ?, ?, ? )';

	$db->query( $sql, array( 'phpbb_users', $userid, $name, $pwd, $userlevel, time() ) );

}

header( 'location:manageadmin.php' );

exit;

?>