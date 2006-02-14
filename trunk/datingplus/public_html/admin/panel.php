<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}
include ( 'sessioninc.php' );

$now = time();

$sql = 'SELECT count(*) as ncount FROM ! WHERE status in( ?, ?)';

$pending_user = $db->getOne( $sql, array( USER_TABLE, 'Pending' , $lang['status_enum']['pending'] ) );

$active_user = $db->getOne( $sql, array( USER_TABLE, 'Active', $lang['status_enum']['active']  ) );

$pending_aff = $db->getOne( $sql, array( AFFILIATE_TABLE, 'Pending' , $lang['status_enum']['pending'] ) );

$active_aff = $db->getOne( $sql, array( AFFILIATE_TABLE, 'Active' , $lang['status_enum']['active'] ) );

$usercountsql = 'SELECT count(*) as ncount FROM !';

$sqlusers = 'SELECT count(*) as ncount FROM ! WHERE status = ?';

$picuser = 'SELECT count(distinct(userid)) as ncount FROM ! ';

$onlineuser = 'SELECT count(*) as ncount FROM !';

/* $user_visit = 'SELECT count(*) FROM ! WHERE lastvisit >= ? AND lastvisit > ?';  */

$user_visit = 'SELECT count(*) FROM ! WHERE lastvisit >= ? ';

$user_level = 'SELECT count(*) FROM ! WHERE level = ?';

$logsql = 'SELECT visits FROM ! WHERE page = ?';

$most_activesql = 'SELECT * FROM ! WHERE visits > 0 ORDER BY visits DESC';

$gendersql = 'SELECT count(*) FROM ! WHERE gender = ?';

$imcountsql = 'SELECT count(*) FROM !';

$wink_countsql = 'SELECT count(*) FROM !';

//ok so we can just use one sql statement for this >.>
$countsql = 'SELECT count(*) FROM !';

$storysql = 'SELECT count(*) FROM ! WHERE enabled = \'Y\' ';

//this is just a test I was doing so you can sort of see what I was doing with $user_visit
//$user_visit_year = 'SELECT count(*) FROM ! WHERE lastvisit >= ? AND lastvisit > 31536000';

$nusers = $db->getOne($usercountsql, array(USER_TABLE));

$pending_user = $db->getOne( $sqlusers, array( USER_TABLE, 'Pending') );

$active_user = $db->getOne( $sqlusers, array( USER_TABLE, 'Active') );

$suspend_user = $db->getOne( $sqlusers, array( USER_TABLE, 'Suspend') );

$picture_user = $db->getOne( $picuser, array( USER_SNAP_TABLE) );

$online_user = $db->getOne ( $onlineuser, array( ONLINE_USERS_TABLE ) );

$visit_min = $db->getOne ( $user_visit, array( USER_TABLE, time() - 60) );

$visit_hour = $db->getOne ( $user_visit, array( USER_TABLE, time() - 3600, ) );

$visit_day = $db->getOne ( $user_visit, array( USER_TABLE, time() - 86400) );

$visit_week = $db->getOne ( $user_visit, array( USER_TABLE, time() - 604800) );

//this is based on the last 30 days
$visit_month = $db->getOne ( $user_visit, array( USER_TABLE, time() - 2592000) );

//this is based on 365 days aka one year
$visit_year = $db->getOne ( $user_visit, array( USER_TABLE, time() - 31536000) );

$visit_twoyear = $db->getOne ( $user_visit, array( USER_TABLE, time() - 63072000) );

$visit_fiveyear = $db->getOne ( $user_visit, array( USER_TABLE, time() - 157680000) );

$visit_tenyear = $db->getOne ( $user_visit, array( USER_TABLE, time() - 315360000) );
//phew the hard part is over back to the easy stuff....

$user_level_free = $db->getOne ( $user_level, array( USER_TABLE, '4' ) );

$user_level_visitor = $db->getOne ( $user_level, array( USER_TABLE, '3' ) );

$user_level_silver = $db->getOne ( $user_level, array( USER_TABLE, '2' ) );

$user_level_gold = $db->getOne ( $user_level, array( USER_TABLE, '1' ) );

$number_visitors = $db->getRow ( $logsql, array ( LOG_TABLE, 'index' ) );
$nvisit = $number_visitors['visits'];

$mostactivepage = $db->getRow ( $most_activesql, array ( LOG_TABLE ) );
$most_active_page = $mostactivepage['page'];

$total_males = $db->getOne ( $gendersql, array ( USER_TABLE, 'M' ) );

$total_females = $db->getOne ( $gendersql, array ( USER_TABLE, 'F' ) );

$total_couples = $db->getOne ( $gendersql, array ( USER_TABLE, 'C' ) );

$im_count = $db->getOne ( $imcountsql, array ( INSTANT_MESSAGE_TABLE ) );

$wink_count = $db->getOne ( $wink_countsql, array ( VIEWS_WINKS_TABLE ) );

$mail_count = $db->getOne ( $countsql, array ( MAILBOX_TABLE ) );

$feedback_total = $db->getOne ( $logsql, array ( LOG_TABLE, 'feedback' ) );

$tellafriend_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'tellafriend' ) );

$showprofile_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'showprofile' ) );

$onlineusers_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'onlineusers' ) );

$newmemberlist_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'newmemberlist' ) );

$banner_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'banner' ) );

$poll_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'poll' ) );

$gallery_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'gallery' ) );

$aff_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'affiliate' ) );

$signup_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'signup' ) );

$allnews_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'allnews' ) );

$stories_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'stories' ) );

$searchmatch_use = $db->getOne ( $logsql, array ( LOG_TABLE, 'searchmatch' ) );

/*
$forum_topics = $db->getOne ( $countsql, array ( PHPBB_TOPICS_TABLE ) );

$forum_posts = $db->getOne ( $countsql, array ( PHPBB_POSTS_TABLE ) );

$forum_bans = $db->getOne ( $countsql, array ( PHPBB_BANS_TABLE ) );

$forum_groups = $db->getOne ( $countsql, array ( PHPBB_GROUPS_TABLE ) );

$forum_pms = $db->getOne ( $countsql, array ( PHPBB_PM_TABLE ) );
*/

$story_count = $db->getOne ( $storysql, array ( STORIES_TABLE ) );

$aff_count = $db->getOne ( $countsql, array ( AFFILIATE_TABLE ) );

$affref_count = $db->getOne ( $countsql, array ( AFFILIATE_REFERALS_TABLE ) );

$news_count = $db->getOne ( $countsql, array ( NEWS_TABLE ) );

$pages_count = $db->getOne ( $countsql, array ( PAGES_TABLE ) );

$polls_count = $db->getOne ( $countsql, array ( POLLS_TABLE ) );

$langauge_count = count($language_options);

$sql = 'SELECT count(*) as ncount FROM ! WHERE id = ? AND password = ?';

$row = $db->getRow( $sql, array(ADMIN_TABLE, $_SESSION['AdminId'], md5('pass') ) );

$change_pwd = $row['ncount'];

$t->assign ( 'change_pwd' , $change_pwd );

$t->assign ( 'pending_users' , $pending_user );

$t->assign ( 'active_users' , $active_user );

$t->assign ( 'pending_aff' , $pending_aff );

$t->assign ( 'active_aff' , $active_aff );

$t->assign ( 'nusers' , $nusers );

$t->assign ( 'active_user' , $active_user );

$t->assign ( 'pending_user', $pending_user );

$t->assign ( 'suspend_user', $suspend_user );

$t->assign ( 'picture_user', $picture_user );

$t->assign ( 'online_user', $online_user );

$t->assign ( 'visit_min', $visit_min );

$t->assign ( 'visit_hour', $visit_hour );

$t->assign ( 'visit_day', $visit_day );

$t->assign ( 'visit_week', $visit_week );

$t->assign ( 'visit_month', $visit_month );

$t->assign ( 'visit_year', $visit_year );

$t->assign ( 'visit_twoyear', $visit_twoyear );

$t->assign ( 'visit_fiveyear', $visit_fiveyear );

$t->assign ( 'visit_tenyear', $visit_tenyear );

$t->assign ( 'user_level_free', $user_level_free );

$t->assign ( 'user_level_visitor', $user_level_visitor );

$t->assign ( 'user_level_silver', $user_level_silver );

$t->assign ( 'user_level_gold', $user_level_gold );

$t->assign ( 'total_visits', $nvisit );

$t->assign ( 'most_active_page', $most_active_page );

$t->assign ( 'total_males', $total_males );

$t->assign ( 'total_females', $total_females );

$t->assign ( 'total_couples', $total_couples );

$t->assign ( 'feedback_total', $feedback_total+0 );

$t->assign ( 'im_count', $im_count );

$t->assign ( 'wink_count', $wink_count );

$t->assign ( 'mail_count', $mail_count );

$t->assign ( 'tellafriend_use', $tellafriend_use+0 );

$t->assign ( 'showprofile_use', $showprofile_use+0 );

$t->assign ( 'onlineusers_use', $onlineusers_use+0 );

$t->assign ( 'newmemberlist_use', $newmemberlist_use+0 );

$t->assign ( 'banner_use', $banner_use+0 );

$t->assign ( 'poll_use', $poll_use+0 );

$t->assign ( 'gallery_use', $gallery_use+0 );

$t->assign ( 'aff_use', $aff_use+0 );

$t->assign ( 'signup_use', $signup_use+0 );

$t->assign ( 'allnews_use', $allnews_use+0 );

$t->assign ( 'stories_use', $stories_use+0 );

$t->assign ( 'searchmatch_use', $searchmatch_use+0 );

$t->assign ( 'forum_topics', $forum_topics );

$t->assign ( 'forum_posts', $forum_posts );

$t->assign ( 'forum_bans', $forum_bans );

$t->assign ( 'forum_groups', $forum_groups );

$t->assign ( 'forum_pms', $forum_pms );

$t->assign ( 'story_count', $story_count );

$t->assign ( 'aff_count', $aff_count );

$t->assign ( 'affref_count', $affref_count );

$t->assign ( 'news_count', $news_count );

$t->assign ( 'pages_count', $pages_count );

$t->assign ( 'polls_count', $polls_count );

$t->assign ( 'langauge_count', $langauge_count );

$t->assign('rendered_page', $t->fetch('admin/panel.tpl'));

$t->display ( 'admin/index.tpl' );
?>