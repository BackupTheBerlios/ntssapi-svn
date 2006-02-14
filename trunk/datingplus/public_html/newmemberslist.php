<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$sqlNew = "SELECT id, username, floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12) as age, gender, city, country, regdate  FROM ! WHERE status in (?, ?) and allow_viewonline = ? ORDER BY regdate desc";

$newmemberslist = $db->getAll($sqlNew, array( USER_TABLE, 'Active', $lang['status_enum']['active'],  '1' ) );

$t->assign('newmemberslist',$newmemberslist);

$t->assign('rendered_page', $t->fetch('newmemberslist.tpl') );

$t->display( 'index.tpl' );

exit;
?>