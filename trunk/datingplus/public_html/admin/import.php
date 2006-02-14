<?php
	define( 'PAGE_ID', 'admin_mgt' );
	if ( !defined( 'SMARTY_DIR' ) ) {
		include_once( '../init.php' );
	}
	include ( 'sessioninc.php' );

	$t->assign('rendered_page', $t->fetch('admin/import.tpl'));  
	$t->display ( 'admin/index.tpl' );
	exit;
?>
DROP TABLE IF EXISTS `osdate_imported_questions`;
CREATE TABLE `osdate_imported_questions` (
  `id` int(11) NOT NULL auto_increment,
  `question_id` int(11) NOT NULL default '0',
  `values_ids` text NOT NULL,
  `module` varchar(50) NOT NULL default '',
  `section` varchar(50) NOT NULL default '',
  `id_spr` mediumint(9) NOT NULL default '0',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

DROP TABLE IF EXISTS `osdate_imported_users`;
CREATE TABLE `osdate_imported_users` (
  `id` int(11) NOT NULL auto_increment,
  `source_id` int(11) NOT NULL default '0',
  `user_id` int(11) NOT NULL default '0',
  `module` varchar(50) NOT NULL default '',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;