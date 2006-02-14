<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

$mship = $_REQUEST['item_number'];

$activedays = $db->getOne('select activedays from ! where roleid = ?', array( MEMBERSHIP_TABLE, $mship ) );

$levelend = $db->getOne('select levelend from ! where id = ?', array(USER_TABLE, $_SESSION['UserId'] ) );

if ($levelend < time()) { $levelend = time(); }

$levelend = strtotime("+$activedays day", $levelend);

$sql = 'UPDATE ! SET level = ?, levelend = ?  WHERE id = ?';

$db->query( $sql, array( USER_TABLE, $mship, $levelend, $_SESSION['UserId'] ) );

$t->assign('rendered_page', $t->fetch('mshipchanged.tpl') );

$t->display( 'index.tpl' );

?>