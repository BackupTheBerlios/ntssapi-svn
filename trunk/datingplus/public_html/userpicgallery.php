<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$userid = $_REQUEST['id'];

$username = $db->getOne('select username from ! where id = ?',array( USER_TABLE, $userid) );

$useralbums = $db->getAll('select id, name from ! where username = ?', array(USERALBUMS_TABLE, $username) );

$album_passwd = $_REQUEST['album_passwd'];

$album_id = $_REQUEST['album_id'];

if ($album_id != '') {

	$pwd = $db->getOne('select passwd from ! where username = ? and  id = ?', array(USERALBUMS_TABLE, $username, $album_id) );

	if ($pwd != md5($album_passwd) && $userid != $_SESSION['UserId']) {

		$err = INVALID_PASSWORD;

		$album_id = '';
	}
}

if ($album_id != '') {
	$pics = $db->getAll('select picno from ! where userid = ? and album_id =?',array( USER_SNAP_TABLE, $userid, $album_id) );
} else {
	$pics = $db->getAll('select picno from ! where userid = ? and album_id in(?,?)',array( USER_SNAP_TABLE, $userid, '',0) );
}

$t->assign('useralbums', $useralbums);

$t->assign('username',$username);

$t->assign('pics',$pics);

$t->assign('userid',$userid);

$t->assign('err', $err);

$t->assign('album_id', $album_id);

if ( $config['use_popups'] == 'Y' ) {
	$t->display( 'userpicgallery.tpl' );
}
else {
	$t->assign( 'rendered_page', $t->fetch( 'userpicgallery.tpl' ) );

	$t->display ( 'index.tpl' );
}


?>