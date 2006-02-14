<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

if( $_GET['del'] == 'yes' ){

	$sql = 'SELECT id, picture, tnpicture FROM ! WHERE userid = ? AND picno = ?';

	$row = $db->getRow( $sql, array( USER_SNAP_TABLE, $_SESSION['UserId'], $_GET['picno'] ) );

	if ($config['images_in_db'] == 'N') {
	
		if (substr_count($row['picture'], 'file:' )>0 ) {
			$curr_imgfile = ltrim(rtrim(str_replace('file:','',$row['picture'] ) ) );
		}
		if (substr_count($row['tnpicture'],'file:' )>0 ) {
			$curr_tnimgfile = ltrim(rtrim(str_replace('file:','',$row['tnpicture'] ) ) );
		}
	}

	if ($_GET['typ'] == 'tn' ) {
		@unlink(USER_IMAGE_DIR.$curr_tnimgfile);
		$sql = 'update ! set tnpicture = ?, tnext = ? where userid = ? and picno = ?';

	} elseif ($_GET['typ'] == 'pic') { 
		@unlink(USER_IMAGE_DIR.$curr_imgfile);
		$sql = 'update ! set picture = ?, picext = ? where userid = ? and picno = ?';

	}

	$db->query ( $sql, array( USER_SNAP_TABLE, '', '', $_SESSION['UserId'], $_GET['picno'] ) );

	$recdel = $db->getOne('select id from ! where userid = ? and picno = ? and picture = ? and tnpicture = ?', array( USER_SNAP_TABLE, $_SESSION['UserId'], $_GET['picno'], '','' ) ) ;
	
	if ($recdel > 0) {
	
		$db->query('delete from ! where userid = ? and picno = ?',array( USER_SNAP_TABLE, $_SESSION['UserId'], $_GET['picno'] ) );

	}

	header('location:?');

	exit;
}

if( function_exists( imagejpeg ) ) {
	$t->assign( 'editable', 1 );
} else {
	$t->assign( 'editable', 0 );
}

$sql = 'select picno, picture, tnpicture, album_id from ! where userid = ?';

$rows = $db->getAll( $sql, array( USER_SNAP_TABLE, $_SESSION['UserId'] ) );

$userdata = $db->getRow('select usr.level, usr.username,  mem.uploadpicture, mem.uploadpicturecnt, mem.allowalbum from ! as usr, ! as mem where mem.roleid = usr.level and usr.id = ?', array(USER_TABLE, MEMBERSHIP_TABLE, $_SESSION['UserId']  ) );

$data = array();

foreach ($rows as $row) {

	$data[$row['picno']] = $row;
}

$useralbums = $db->getAll('select id, name from ! where username = ? order by name', array(USERALBUMS_TABLE, $userdata['username'] ) );

$t->assign('maxsize', floor($config['upload_snap_maxsize']/1000));

$t->assign('album_id', $_POST['album_id']);

$t->assign('useralbums',$useralbums);

$t->assign('userdata',$userdata);

$t->assign ( 'lang', $lang );

$t->assign ( 'data', $data );

$t->assign('max_picture_cnt', (count($data)+1 < $userdata['uploadpicturecnt'])? count($data)+1 : $userdata['uploadpicturecnt'] );

$t->assign('rendered_page',$t->fetch('usersnap.tpl'));

$t->display ( 'index.tpl' );

?>