<?php
//Include init.php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$name = trim( $_POST[ 'txtname' ] );

$password = trim( $_POST[ 'txtconpassword' ] );

$email = trim( $_POST[ 'txtemail' ] );

if( $name==''){

	header( 'location: affindex.php?error=' . $lang['affiliates_error'][0]);
	exit;

} elseif($password==''){

	header( 'location:affindex.php?error=' . $lang['affiliates_error'][0]);
	exit;

} elseif($email==''){

	header( 'location:affindex.php?error=' . $lang['affiliates_error'][0]);
	exit;

} elseif( $password ==''){

	header( 'location:affindex.php?error=' . $lang['affiliates_error'][0]);
	exit;

} elseif( trim($_POST['txpassword']) != $password ){

	header( 'location:affindex.php?error=' . $lang['affiliates_error'][1]);
	exit;

}

$sqlc = 'SELECT count(*) as aacount from ! where email= ? ';
echo $sqlc;
exit;

$rowc = $db->getRow( $sqlc, array( AFFILIATE_TABLE, $email ) );

if ( $rowc['aacount'] > 0 ) {

	header( 'location:affindex.php?error=' . $lang['affiliates_error'][2]);
	exit;

}

$status = $lang['status_enum']['approval'];

$regdate = time();


$sqlins = "INSERT INTO ? (  name, email, password, status, regdate ) VALUES ( ?, ?, ?, ?, ? )";

$result = $db->query ( $sqlins, array( AFFILIATE_TABLE, $name, $email, md5($password), $status, $regdate ) );

$lastid = getLastId();

$t->assign ( 'affid', $lastid );

$t->assign('rendered_page', $t->fetch('affsignupsuccess.tpl') );

$t->display( 'index.tpl' );

exit;
?>

