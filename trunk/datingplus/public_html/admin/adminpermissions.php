<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'admin_permit_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$mid = 0;

if ( $_POST['modify'] ) {

	$site_stats 		= $_POST['site_stats'] == 'on' ? 1 : 0;
	$profie_approval	= $_POST['profie_approval'] == 'on' ? 1 : 0;
	$profile_mgt 		= $_POST['profile_mgt'] == 'on' ? 1 : 0;
	$section_mgt 		= $_POST['section_mgt'] == 'on' ? 1 : 0;
	$affiliate_mgt 		= $_POST['affiliate_mgt'] == 'on' ? 1 : 0;
	$affiliate_stats 	= $_POST['affiliate_stats'] == 'on' ? 1 : 0;
	$news_mgt 			= $_POST['news_mgt'] == 'on' ? 1 : 0;
	$article_mgt 		= $_POST['article_mgt'] == 'on' ? 1 : 0;
	$story_mgt			= $_POST['story_mgt'] == 'on' ? 1 : 0;
	$poll_mgt		 	= $_POST['poll_mgt'] == 'on' ? 1 : 0;
	$search 			= $_POST['search'] == 'on' ? 1 : 0;
	$ext_search			= $_POST['ext_search'] == 'on' ? 1 : 0;
	$send_letter 		= $_POST['send_letter'] == 'on' ? 1 : 0;
	$pages_mgt 			= $_POST['pages_mgt'] == 'on' ? 1 : 0;
	$chat 				= $_POST['chat'] == 'on' ? 1 : 0;
	$chat_mgt 			= $_POST['chat_mgt'] == 'on' ? 1 : 0;
	$forum_mgt 			= $_POST['forum_mgt'] == 'on' ? 1 : 0;
	$mship_mgt 			= $_POST['mship_mgt'] == 'on' ? 1 : 0;
	$payment_mgt 		= $_POST['payment_mgt'] == 'on' ? 1 : 0;
	$banner_mgt 		= $_POST['banner_mgt'] == 'on' ? 1 : 0;
	$seo_mgt			= $_POST['seo_mgt'] == 'on' ? 1 : 0;
	$admin_mgt 			= $_POST['admin_mgt'] == 'on' ? 1 : 0;
	$admin_permit_mgt	= $_POST['admin_permit_mgt'] == 'on' ? 1 : 0;
	$global_mgt 		= $_POST['global_mgt'] == 'on' ? 1 : 0;
	$change_pwd 		= $_POST['change_pwd'] == 'on' ? 1 : 0;
	$cntry_mgt 			= $_POST['cntry_mgt'] == 'on' ? 1 : 0;								
	$snaps_require_approval = $_POST['snaps_require_approval'] == 'on' ? 1 : 0;								
	$featured_profiles_mgt = $_POST['featured_profiles_mgt'] == 'on' ? 1 : 0;								
	$calendar_mgt 			= $_POST['calendar_mgt'] == 'on' ? 1 : 0;								
	$event_mgt 				= $_POST['event_mgt'] == 'on' ? 1 : 0;								
	$import_mgt 				= $_POST['import_mgt'] == 'on' ? 1 : 0;								


	$mid = $_POST['adminid'];

	$sql = "UPDATE ! set
		site_stats 			= $site_stats,
		profie_approval	 	= $profie_approval,
		profile_mgt 		= $profile_mgt,
		section_mgt 		= $section_mgt,
		affiliate_mgt 		= $affiliate_mgt,
		affiliate_stats 	= $affiliate_stats,
		news_mgt 			= $news_mgt,
		article_mgt 		= $article_mgt,
		story_mgt			= $story_mgt,
		poll_mgt		 	= $poll_mgt,
		search 				= $search,
		ext_search			= $ext_search,
		send_letter 		= $send_letter,
		pages_mgt 			= $pages_mgt,
		chat 				= $chat,
		chat_mgt 			= $chat_mgt,
		forum_mgt 			= $forum_mgt,
		mship_mgt 			= $mship_mgt,
		payment_mgt 		= $payment_mgt,
		banner_mgt 			= $banner_mgt,
		seo_mgt				= $seo_mgt,
		admin_mgt 			= $admin_mgt,
		admin_permit_mgt	= $admin_permit_mgt,
		global_mgt 			= $global_mgt,
		change_pwd 			= $change_pwd,
		cntry_mgt 			= $cntry_mgt,
		snaps_require_approval = $snaps_require_approval,
		featured_profiles_mgt = $featured_profiles_mgt,
		calendar_mgt 		= $calendar_mgt, 
		event_mgt 		= $event_mgt, 
		import_mgt 		= $import_mgt
	WHERE adminid = ? AND id = ?";

	 $db->query( $sql, array( ADMIN_RIGHTS_TABLE, $_POST['adminid'], $_POST['id'] ) );
}

if ( $_POST['adminid'] ) {

	$mid = $_POST['adminid'];

} else {

	$sql = 'SELECT id FROM ! WHERE super_user = ? ORDER BY id limit 1';

	$mid = $db->getOne( $sql, array( ADMIN_TABLE, 'N' ) );
}

$sql = 'SELECT * FROM ! WHERE adminid = ?';

$row = $db->getRow( $sql, array( ADMIN_RIGHTS_TABLE, $mid ) );

$t->assign( 'data', $row );


$data = array();

$sql = 'select id, username from ! where super_user = ? order by id';

$temp = $db->getAll( $sql, array( ADMIN_TABLE, 'N' ) );

foreach( $temp as $index => $row ) {
	$data[ $row[id] ] = $row[username];
}

$t->assign( 'admins', $data );

$t->assign('rendered_page', $t->fetch('admin/adminpermissions.tpl'));		

$t->display( 'admin/index.tpl' );
?>