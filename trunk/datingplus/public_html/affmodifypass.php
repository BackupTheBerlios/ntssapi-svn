<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'affsessioninc.php' );

$oldpwd = trim( $_POST['txtoldpwd'] );
$newpwd = trim( $_POST['txtnewpwd'] );
$conpwd = trim( $_POST['txtconpwd'] );

if ( $newpwd == $oldpwd ) {

	header( 'location:affchangepass.php?errid=' . OLD_NEW_PASSWORD_MUST_DIFFER );

}
elseif ( $newpwd == $conpwd ) {

	$sql = 'select id from ! where id = ? and password = ?';

	$id = $db->getOne( $sql, array( AFFILIATE_TABLE, $_SESSION['AffId'], md5( $oldpwd ) ) );

	if ( $id ) {

		$sql = 'update ! set password = ? where id = ?';

		$rs = $db->query( $sql, array( AFFILIATE_TABLE, md5( $newpwd ), $_SESSION['AffId'] ) );

		$t->assign( 'rendered_page', $t->fetch( 'affpwdchanged.tpl' ) );

		$t->display( 'index.tpl' );

		exit;
	}
	else {
		header( 'location:affchangepass.php?errid=' . WRONG_OLD_PASSWORD );//change to a constant later
	}
}
else {
	header( 'location:affchangepass.php?errid=' . PASS_CONFIRMPASS );//change to a constant later
}

?>