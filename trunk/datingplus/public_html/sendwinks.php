<?php
if ( !defined( 'SMARTY_DIR' ) ) {

	include_once( 'init.php' );

}

	/* first get both the username and ref_username i.e.  login names */

$sql = 'insert into ! (userid, ref_userid, act, act_time) values (?, ?, ?, ?)';

$db->query($sql, array( VIEWS_WINKS_TABLE, $_GET['ref_id'], $_SESSION['UserId'], 'W', time() ) );


header("location: ".$_GET['rtnurl']."?id=".$_GET['ref_id'].'&errid='.WINKISSENT);	
exit;

?>