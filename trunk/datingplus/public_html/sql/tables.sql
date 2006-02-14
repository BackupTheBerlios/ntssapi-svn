## 
## Table structure for table `[prefix]_admin`
## 

CREATE TABLE `[prefix]_admin` (
  `id` int(11) NOT NULL auto_increment,
  `username` varchar(25) NOT NULL default '',
  `password` varchar(32) NOT NULL default '',
  `fullname` varchar(100) NOT NULL default '',
  `lastvisit` int(11) NOT NULL default '0',
  `super_user` char(1) NOT NULL default 'N',
  `enabled` char(1) NOT NULL default 'Y',
  PRIMARY KEY  (`id`),
  KEY `username` (`username`)
) TYPE=MyISAM AUTO_INCREMENT=24 ;

## ########################################################

## 
## Table structure for table `[prefix]_admin_permissions`
## 

CREATE TABLE `[prefix]_admin_permissions` (
  `id` int(11) NOT NULL auto_increment,
  `adminid` int(11) NOT NULL default '0',
  `site_stats` char(1) NOT NULL default '0',
  `profie_approval` char(1) NOT NULL default '0',
  `profile_mgt` char(1) NOT NULL default '0',
  `section_mgt` char(1) NOT NULL default '0',
  `affiliate_mgt` char(1) NOT NULL default '0',
  `affiliate_stats` char(1) NOT NULL default '0',
  `news_mgt` char(1) NOT NULL default '0',
  `article_mgt` char(1) NOT NULL default '0',
  `story_mgt` char(1) NOT NULL default '0',
  `poll_mgt` char(1) NOT NULL default '0',
  `search` char(1) NOT NULL default '0',
  `ext_search` char(1) NOT NULL default '0',
  `send_letter` char(1) NOT NULL default '0',
  `pages_mgt` char(1) NOT NULL default '0',
  `chat` char(1) NOT NULL default '0',
  `chat_mgt` char(1) NOT NULL default '0',
  `forum_mgt` char(1) NOT NULL default '',
  `mship_mgt` char(1) NOT NULL default '0',
  `payment_mgt` char(1) NOT NULL default '0',
  `banner_mgt` char(1) NOT NULL default '0',
  `seo_mgt` char(1) NOT NULL default '0',
  `admin_mgt` char(1) NOT NULL default '0',
  `admin_permit_mgt` char(1) NOT NULL default '0',
  `global_mgt` char(1) NOT NULL default '0',
  `change_pwd` char(1) NOT NULL default '0',
  `cntry_mgt` char(1)	NOT NULL default '0',
  `snaps_require_approval` char(1)	NOT NULL	default 'N',
  `featured_profiles_mgt` char(1)	NOT NULL	default 'N',  
  `calendar_mgt` char(1) NOT NULL	default '0',  
  `event_mgt` char(1) NOT NULL	default '0',  
  `import_mgt` char(1) NOT NULL	default '0',  
  PRIMARY KEY  (`id`),
  KEY `adminid` (`adminid`)
) TYPE=MyISAM AUTO_INCREMENT=20 ;

## ########################################################

## 
## Table structure for table `[prefix]_adminemails`
## 

CREATE TABLE `[prefix]_adminemails` (
  `id` int(11) NOT NULL auto_increment,
  `email` varchar(100) NOT NULL default '',
  PRIMARY KEY  (`id`),
  KEY `email` (`email`)
) TYPE=MyISAM AUTO_INCREMENT=12 ;


## ########################################################

## 
## Table structure for table `[prefix]_aff_referals`
## 

CREATE TABLE `[prefix]_aff_referals` (
  `id` int(11) NOT NULL auto_increment,
  `affid` int(11) NOT NULL default '0',
  `userid` int(11) NOT NULL default '0',
  `ip` varchar(255) default NULL,
  PRIMARY KEY  (`id`),
  KEY `affid` (`affid`),
  KEY `userid` (`userid`)
) TYPE=MyISAM AUTO_INCREMENT=8 ;

## ########################################################

## 
## Table structure for table `[prefix]_affiliates`
## 

CREATE TABLE `[prefix]_affiliates` (
  `id` int(10) NOT NULL auto_increment,
  `name` varchar(255) NOT NULL default '',
  `email` varchar(255) NOT NULL default '',
  `password` varchar(32) NOT NULL default '',
  `status` varchar(255) NOT NULL default '',
  `regdate` int(11) NOT NULL default '0',
  PRIMARY KEY  (`id`),
  KEY `email` (`email`)
) TYPE=MyISAM PACK_KEYS=0 AUTO_INCREMENT=11 ;

## ########################################################

## 
## Table structure for table `[prefix]_articles`
## 

CREATE TABLE `[prefix]_articles` (
  `articleid` int(11) NOT NULL auto_increment,
  `dat` int(11) NOT NULL default '0',
  `title` varchar(255) default NULL,
  `text` longtext,
  PRIMARY KEY  (`articleid`),
  KEY `dat` (`dat`),
  KEY `title` (`title`)
) TYPE=MyISAM AUTO_INCREMENT=11 ;

## ########################################################

## 
## Table structure for table `[prefix]_banners`
## 

CREATE TABLE `[prefix]_banners` (
  `id` int(11) NOT NULL auto_increment,
  `name` varchar(255) NOT NULL default '',
  `bannerurl` text,
  `linkurl` varchar(255) default NULL,
  `tooltip` varchar(255) default NULL,
  `size` varchar(20) default NULL,
  `startdate` int(11) NOT NULL default '0',
  `expdate` int(11) NOT NULL default '0',
  `clicks` int(11) NOT NULL default '0',
  `enabled` char(1) NOT NULL default 'Y',
  PRIMARY KEY  (`id`),
  KEY `startdate` (`startdate`),
  KEY `expdate` (`expdate`),
  KEY `linkurl` (`linkurl`)
) TYPE=MyISAM AUTO_INCREMENT=11 ;

## ########################################################

## 
## Table structure for table `[prefix]_countries`
## 

CREATE TABLE `[prefix]_countries` (
  `id` int(11) NOT NULL auto_increment,
  `loc` char(2) default NULL,
  `code` char(2) default NULL,
  `name` varchar(100) default NULL,
  `enabled` char(1) default 'Y',
  PRIMARY KEY  (`id`),
  KEY `name` (`name`),
  KEY `code` (`code`) 
) TYPE=MyISAM AUTO_INCREMENT=221 ;

## ########################################################

## 
## Table structure for table `[prefix]_glblsettings`
## 

CREATE TABLE `[prefix]_glblsettings` (
  `config_variable` varchar(50) NOT NULL default '',
  `config_value` varchar(255) NOT NULL default '',
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`config_variable`)
) TYPE=MyISAM;

## ########################################################

## 
## Table structure for table `[prefix]_instant_message`
## 

CREATE TABLE `[prefix]_instant_message` (
  `id` int(11) NOT NULL auto_increment,
  `senderid` int(11) NOT NULL default '0',
  `recipientid` int(11) NOT NULL default '0',
  `message` varchar(254) NOT NULL default '',
  `pingflag` tinyint(1) NOT NULL default '0',
  `sendtime` int(11) NOT NULL default '0',
  PRIMARY KEY  (`id`),
  KEY `senderid` (`senderid`),
  KEY `recipientid` (`recipientid`),
  KEY `sendtime` (`sendtime`)
) TYPE=MyISAM AUTO_INCREMENT=13 ;

## ########################################################

## 
## Table structure for table `[prefix]_letters`
## 

CREATE TABLE `[prefix]_letters` (
  `id` int(8) NOT NULL auto_increment,
  `title` varchar(100) NOT NULL ,
  `subject` varchar(254) NOT NULL ,
  `MODIFY` int(8) NOT NULL default '0',
  `bodytext` text NOT NULL,
  `autosendsignup` tinyint(1) NOT NULL default '0',
  PRIMARY KEY  (`id`),
  KEY `subject` (`subject`),
  KEY `title` (`title`)
) TYPE=MyISAM AUTO_INCREMENT=21 ;

## ########################################################

## 
## Table structure for table `[prefix]_mailbox`
## 

CREATE TABLE `[prefix]_mailbox` (
  `id` bigint(20) NOT NULL auto_increment,
  `senderid` int(11) NOT NULL default '0',
  `recipientid` int(11) NOT NULL default '0',
  `subject` varchar(254) default NULL,
  `message` text NOT NULL,
  `flagread` tinyint(1) NOT NULL default '0',
  `sendtime` int(11) NOT NULL default '0',
  `flagdelete` tinyint(1) NOT NULL default '0',
  `folder` varchar(10) NOT NULL default 'inbox',
  PRIMARY KEY  (`id`),
  KEY `senderid` (`senderid`),
  KEY `recipientid` (`recipientid`),
  KEY `subject` (`subject`),
  KEY `flagread` (`flagread`),
  KEY `sendtime` (`sendtime`),
  KEY `flagdelete` (`flagdelete`),
  KEY `folder` (`folder`)
) TYPE=MyISAM AUTO_INCREMENT=27 ;

## ########################################################

## 
## Table structure for table `[prefix]_membership`
## 

CREATE TABLE `[prefix]_membership` (
  `id` int(11) NOT NULL auto_increment,
  `roleid` int(11) NOT NULL default '0',
  `name` varchar(255) NOT NULL default '',
  `chat` char(1) NOT NULL default '0',
  `forum` char(1) NOT NULL default '0',
  `includeinsearch` char(1) NOT NULL default '0',
  `message` char(1) NOT NULL default '0',
  `allowim` char(1) NOT NULL default '0',  
  `uploadpicture` char(1) NOT NULL default '0',
  `uploadpicturecnt` int(4) NOT NULL default '1',  
  `allowalbum` char(1) NOT NULL default '0',
  `event_mgt` char(1) NOT NULL default '0',  
  `seepictureprofile` char(1) NOT NULL default '0',
  `favouritelist` char(1) NOT NULL default '0',
  `sendwinks` char(1) NOT NULL default '0',
  `extsearch` char(1) NOT NULL default '0',
  `activedays` int(11) NOT NULL default '0',  
  `fullsignup` char(1) NOT NULL default '0',
  `price` decimal(11,2) NOT NULL default '0',
  `currency` char(3) NOT NULL default '',
  `enabled` char(1) NOT NULL default 'Y',
  PRIMARY KEY  (`id`),
  KEY `name` (`name`),
  KEY `roleid` (`roleid`)
) TYPE=MyISAM AUTO_INCREMENT=19 ;


## ########################################################

## 
## Table structure for table `[prefix]_news`
## 

CREATE TABLE `[prefix]_news` (
  `newsid` int(10) unsigned NOT NULL auto_increment,
  `date` int(11) NOT NULL default '0',
  `header` varchar(50) NOT NULL default '',
  `text` longtext NOT NULL,
  PRIMARY KEY  (`newsid`),
  KEY `date` (`date`),
  KEY `header` (`header`)
) TYPE=MyISAM AUTO_INCREMENT=8 ;

## ########################################################

## 
## Table structure for table `[prefix]_onlineusers`
## 

CREATE TABLE `[prefix]_onlineusers` (
  `userid` int(8) NOT NULL default '0',
  `lastactivitytime` int(11) NOT NULL default '0',
  KEY `userid` (`userid`),
  KEY `lastactivitytime` (`lastactivitytime`)
) TYPE=MyISAM;

## ########################################################

## 
## Table structure for table `[prefix]_pages`
## 

CREATE TABLE `[prefix]_pages` (
  `id` int(11) NOT NULL auto_increment,
  `pagekey` varchar(100) NOT NULL default '',
  `title` varchar(255) NOT NULL default '',
  `pagetext` text NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `pagekey` (`pagekey`),
  KEY `title` (`title`)
) TYPE=MyISAM AUTO_INCREMENT=7 ;

## ########################################################

## 
## Table structure for table `[prefix]_payment_config`
## 

CREATE TABLE `[prefix]_payment_config` (
  `configuration_id` int(11) NOT NULL auto_increment,
  `configuration_title` varchar(64) NOT NULL default '',
  `configuration_key` varchar(64) NOT NULL default '',
  `configuration_value` varchar(255) NOT NULL default '',
  `configuration_description` varchar(255) NOT NULL default '',
  `configuration_group_id` int(11) NOT NULL default '0',
  `sort_order` int(5) default NULL,
  `last_modified` datetime default NULL,
  `date_added` datetime NOT NULL default '0000-00-00 00:00:00',
  `use_function` varchar(255) default NULL,
  `set_function` varchar(255) default NULL,
  `module_key` varchar(255) NOT NULL default '',
  PRIMARY KEY  (`configuration_id`)
) TYPE=MyISAM AUTO_INCREMENT=1 ;

## ########################################################

## 
## Table structure for table `[prefix]_payment_modules`
## 

CREATE TABLE `[prefix]_payment_modules` (
  `id` int(11) NOT NULL auto_increment,
  `name` varchar(255) NOT NULL default '',
  `module_key` varchar(255) NOT NULL default '',
  `class_file` varchar(255) NOT NULL default '',
  `formfile` varchar(255) NOT NULL default '',
  `enabled` char(1) NOT NULL default 'N',
  PRIMARY KEY  (`id`),
  KEY `name` (`name`)
) TYPE=MyISAM AUTO_INCREMENT=9 ;


## ########################################################

## 
## Table structure for table `[prefix]_pollips`
## 

CREATE TABLE `[prefix]_pollips` (
  `ip` varchar(15) default NULL,
  `pollid` int(11) default NULL,
  `time` int(11) default NULL,
  KEY `pollid` (`pollid`),
  KEY `time` (`time`),
  KEY `ip` (`ip`)
) TYPE=MyISAM;

## ########################################################

## 
## Table structure for table `[prefix]_polloptions`
## 

CREATE TABLE `[prefix]_polloptions` (
  `optionid` int(11) NOT NULL auto_increment,
  `pollid` int(11) default NULL,
  `opt` varchar(255) default NULL,
  `result` int(11) NOT NULL default '0',
  `enabled` char(1) NOT NULL default 'Y',
  PRIMARY KEY  (`optionid`),
  KEY `enabled` (`enabled`),
  KEY `pollid` (`pollid`)
) TYPE=MyISAM AUTO_INCREMENT=31 ;

## ########################################################

## 
## Table structure for table `[prefix]_polls`
## 

CREATE TABLE `[prefix]_polls` (
  `pollid` int(11) NOT NULL auto_increment,
  `question` varchar(255) default NULL,
  `date` int(11) NOT NULL default '0',
  `enabled` char(1) NOT NULL default 'Y',
  `active` tinyint(1) NOT NULL default '0',
  `options` varchar(255) default NULL,
  `suggested_by` int(11) default 0,  
  PRIMARY KEY  (`pollid`),
  KEY `active` (`active`),
  KEY `date` (`date`),
  KEY `enabled` (`enabled`)
) TYPE=MyISAM AUTO_INCREMENT=11 ;

## ########################################################

## 
## Table structure for table `[prefix]_questionoptions`
## 

CREATE TABLE `[prefix]_questionoptions` (
  `id` mediumint(8) NOT NULL auto_increment,
  `answer` text,
  `questionid` mediumint(8) NOT NULL default '0',
  `enabled` char(1) NOT NULL default 'Y',
  PRIMARY KEY  (`id`),
  KEY `questionid` (`questionid`),
  KEY `enabled` (`enabled`)
) TYPE=MyISAM COMMENT='Store information about question options' AUTO_INCREMENT=407 ;

## ########################################################

## 
## Table structure for table `[prefix]_questions`
## 

CREATE TABLE `[prefix]_questions` (
  `id` int(8) NOT NULL auto_increment,
  `question` varchar(255) NOT NULL default '',
  `description` varchar(255) default NULL,
  `guideline` varchar(255) default NULL,
  `control_type` varchar(100) NOT NULL default '',
  `maxlength` int(3) NOT NULL default '0',
  `mandatory` char(1) NOT NULL default 'Y',
  `section` tinyint(2) NOT NULL default '0',
  `displayorder` tinyint(2) NOT NULL default '0',
  `extsearchable` char(1) NOT NULL default 'N',
  `extsearchhead` varchar(255) default NULL,
  `enabled` char(1) NOT NULL default 'Y',
  PRIMARY KEY  (`id`),
  KEY `enabled` (`enabled`)
) TYPE=MyISAM COMMENT='Stores information about questions' AUTO_INCREMENT=37 ;

## ########################################################

## 
## Table structure for table `[prefix]_sections`
## 

CREATE TABLE `[prefix]_sections` (
  `id` int(8) NOT NULL auto_increment,
  `section` varchar(255) NOT NULL default '',
  `displayorder` tinyint(2) NOT NULL default '0',
  `enabled` char(1) NOT NULL default '',
  PRIMARY KEY  (`id`),
  KEY `enabled` (`enabled`),
  KEY `displayorder` (`displayorder`)
) TYPE=MyISAM AUTO_INCREMENT=25 ;

## ########################################################

## 
## Table structure for table `[prefix]_states`
## 

CREATE TABLE `[prefix]_states` (
  `id` int(8) NOT NULL auto_increment,
  `code` varchar(10) default NULL,
  `name` varchar(100) default NULL,
  `enabled` char(1) default 'Y',
  `countrycode` varchar(5) NOT NULL default 'US',
  PRIMARY KEY  (`id`),
  KEY `code` (`code`),
  KEY `enabled` (`enabled`),
  KEY `countrycode` (`countrycode`)
) TYPE=MyISAM AUTO_INCREMENT=78 ;

## ########################################################

## 
## Table structure for table `[prefix]_stories`
## 

CREATE TABLE `[prefix]_stories` (
  `storyid` int(10) unsigned NOT NULL auto_increment,
  `date` int(11) NOT NULL default '0',
  `sender` bigint(8) unsigned NOT NULL default '0',
  `header` varchar(50) NOT NULL default '',
  `text` longtext NOT NULL,
  `enabled` char(1) NOT NULL default '',
  PRIMARY KEY  (`storyid`),
  KEY `date` (`date`),
  KEY `sender` (`sender`),
  KEY `header` (`header`),
  KEY `enabled` (`enabled`)
) TYPE=MyISAM AUTO_INCREMENT=7 ;

## ########################################################

## 
## Table structure for table `[prefix]_user`
## 

CREATE TABLE `[prefix]_user` (
  `id` int(11) NOT NULL auto_increment,
  `active` tinyint(1) default '0',
  `username` varchar(25) NOT NULL default '',
  `password` varchar(32) NOT NULL default '',
  `lastvisit` int(11) NOT NULL default '0',
  `regdate` int(11) NOT NULL default '0',
  `level` tinyint(4) default '4',
  `timezone` decimal(5,2)  default '',
  `allow_viewonline` tinyint(1) NOT NULL default '1',
  `rank` int(11) default '0',
  `email` varchar(255) default NULL,
  `country` varchar(11) NOT NULL default '',
  `actkey` varchar(32) default NULL,
  `firstname` varchar(50) default NULL,
  `lastname` varchar(50) default NULL,
  `gender` char(1) NOT NULL default 'M',
  `lookgender` char(1) NOT NULL default '',
  `lookagestart` int(11) NOT NULL default '0',
  `lookageend` int(11) NOT NULL default '0',
  `lookcountry` varchar(255) NOT NULL default '',
  `address_line1` varchar(100) default NULL,
  `address_line2` varchar(100) default NULL,
  `state_province` varchar(50) default NULL,
  `county` varchar(50) default NULL,  
  `city` varchar(100) default NULL,
  `zip` varchar(10) default NULL,
  `birth_date` date NOT NULL,
  `lookstate_province` varchar(50) default NULL,
  `lookcounty` varchar(50) default NULL,    
  `lookcity` varchar(100) default NULL,
  `lookzip` varchar(100) default NULL,
  `picture` char(1) NOT NULL default '0',
  `status` varchar(20) NOT NULL default 'Pending',
  `levelend` int(11) default NULL ,  
  PRIMARY KEY  (`id`),
  KEY `username` (`username`),
  KEY `level` (`level`),
  KEY `rank` (`rank`),
  KEY `email` (`email`),
  KEY `fullname` (`firstname`),
  KEY `gender` (`gender`),
  KEY `city` (`city`),
  KEY `zip` (`zip`),
  KEY `country` (`country`),
  KEY `picture` (`picture`),
  KEY `allow_viewonline` (`allow_viewonline`),
  KEY `lastvisit` (`lastvisit`),
  KEY `lookgender` (`lookgender`),
  KEY `state_province` (`state_province`),
  KEY `lookcountry` (`lookcountry`),
  KEY `lookageend` (`lookageend`),
  KEY `lookagestart` (`lookagestart`),
  KEY `lookstate_province` (`lookstate_province`),
  KEY `lookcity` (`lookcity`),
  KEY `lookzip` (`lookzip`),
  KEY `status` (`status`)
) TYPE=MyISAM AUTO_INCREMENT=104 ;

## ########################################################

## 
## Table structure for table `[prefix]_userpreference`
## 

CREATE TABLE `[prefix]_userpreference` (
  `id` bigint(12) NOT NULL auto_increment,
  `userid` int(11) NOT NULL default '0',
  `questionid` int(8) NOT NULL default '0',
  `answer` text default null,
  PRIMARY KEY  (`id`),
  KEY `userid` (`userid`),
  KEY `questionid_answer` (`questionid`)
) TYPE=MyISAM AUTO_INCREMENT=808 ;

## ########################################################

## 
## Table structure for table `[prefix]_userrating`
## 

CREATE TABLE `[prefix]_userrating` (
  `id` int(11) NOT NULL auto_increment,
  `userid` int(11) NOT NULL default '0',
  `profileid` int(11) NOT NULL default '0',
  `rating` int(11) NOT NULL default '0',
  `rate_time` int(32) NOT NULL default '0',
  PRIMARY KEY  (`id`),
  KEY `userid` (`userid`),
  KEY `profileid` (`profileid`),
  KEY `rating` (`rating`)
) TYPE=MyISAM AUTO_INCREMENT=17 ;

## ########################################################

## 
## Table structure for table `[prefix]_usersearches`
## 

CREATE TABLE `[prefix]_usersearches` (
  `id` int(11) NOT NULL auto_increment,
  `userid` int(11) NOT NULL default '0',
  `query` text NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `userid` (`userid`)
) TYPE=MyISAM AUTO_INCREMENT=5 ;

## ########################################################

## 
## Table structure for table `[prefix]_usersnaps`
## 

CREATE TABLE `[prefix]_usersnaps` (
  `id` bigint(11) NOT NULL auto_increment,
  `userid` int(11) NOT NULL default '0',
  `picno` int(11) NOT NULL default '0',
  `picture` mediumtext NOT NULL,
  `tnpicture` text NOT NULL,
  `ins_time` int(11) NOT NULL,
  `active` char(1) NOT NULL default 'N',
  `picext` varchar(10) not null default 'jpg',
  `tnext` varchar(10) not null default 'jpg',
  `album_id` int(11) default null,  
  PRIMARY KEY  (`id`),
  KEY `userid` (`userid`,`picno` ),
  KEY `albumids` (`userid`,`album_id`,`picno` )
) TYPE=MyISAM AUTO_INCREMENT=37 ;

## ########################################################

## 
## Table structure for table `[prefix]_buddy_ban_list`
## act ( F=Friend, B=Banned, H=Hotlist ) 

CREATE TABLE `[prefix]_buddy_ban_list` (
	`id` 			int(11) 		NOT NULL auto_increment,
	`username` 		varchar(25) 	NOT NULL,
	`act`			char(1)			NOT NULL,
	`ref_username` 	varchar(25) 	NOT NULL,
	`act_date` 		int(11)			NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `act`(`act`),
  KEY `act_username` (`act`,`username`),
  KEY `act_ref_username` (`act`, `ref_username`)
) TYPE=MyISAM ;

## ########################################################

## 
## Table structure for table `[prefix]_featured_profiles`
##  

CREATE TABLE `[prefix]_featured_profiles` (
	`id` 			int(11) 	NOT NULL auto_increment,
	`userid` 		int(11) 	NOT NULL ,
	`start_date` 	int(11)		NOT NULL ,
	`end_date` 		int(11)		NOT NULL ,
	`must_show` 	char(1) 	NOT NULL ,
	`req_exposures` int(11) 	NOT NULL ,
	`exposures` 	int(11) 	NOT NULL ,	
  PRIMARY KEY  (`id`),
  KEY `userid` (`userid`)
) TYPE=MyISAM ;
		
## ########################################################

## 
## Table structure for table `[prefix]_views_winks`
##  

CREATE TABLE `[prefix]_views_winks` (
	`id` 			int(11) 	NOT NULL auto_increment,
	`userid` 		int(11) 	NOT NULL ,
	`ref_userid` 	int(11)		NOT NULL ,
	`act_time` 		int(11)		NOT NULL ,
	`act`			char(1)		NOT NULL default 'V',
  PRIMARY KEY  (`id`),
  KEY `act` (`act`),
  KEY `userid`(`userid`),
  KEY `ref_userid` (`ref_userid`)
) TYPE=MyISAM ;
		
## ########################################################

## 
## Table structure for table `[prefix]_counties`
## 

CREATE TABLE `[prefix]_counties` (
  `id` int(8) NOT NULL auto_increment,
  `code` varchar(10) default NULL,
  `name` varchar(100) default NULL,
  `enabled` char(1) default 'Y',
  `countrycode` varchar(5) NOT NULL default 'US',
  `statecode` varchar(10) NULL,  
  PRIMARY KEY  (`id`),
  KEY `code` (`code`),
  KEY `countrystate` (`countrycode`,`statecode`)
) TYPE=MyISAM;


## ########################################################

## 
## Table structure for table `[prefix]_cities`
## 

CREATE TABLE `[prefix]_cities` (
  `id` int(8) NOT NULL auto_increment,
  `code` varchar(10) default NULL,
  `name` varchar(100) default NULL,
  `enabled` char(1) default 'Y',
  `countrycode` varchar(5) NOT NULL default 'US',
  `statecode` varchar(10) NULL,  
  `countycode` varchar(10) NULL,  
  PRIMARY KEY  (`id`),
  KEY `code` (`code`),
  KEY `countrystate` (`countrycode`,`statecode`),
  KEY `countrystatecounty` (`countrycode`,`statecode`,`countycode`)
) TYPE=MyISAM;

## ########################################################

## 
## Table structure for table `[prefix]_zips`
## 

CREATE TABLE `[prefix]_zips` (
  `id` int(8) NOT NULL auto_increment,
  `code` varchar(30) default NULL,
  `enabled` char(1) default 'Y',
  `countrycode` varchar(5) NOT NULL default 'US',
  `statecode` varchar(10) NULL,  
  `countycode` varchar(10) NULL,  
  `citycode` varchar(10) NULL,  
  PRIMARY KEY  (`id`),
  KEY `code` (`code`),
  KEY `countrystate` (`countrycode`,`statecode`),
  KEY `countrystatecounty` (`countrycode`,`statecode`,`countycode`),
  KEY `countrystatecountycity` (`countrycode`,`statecode`,`countycode`, `citycode`)
) TYPE=MyISAM;

## ########################################################

## 
## Table structure for table `[prefix]_useralbums`
## 

CREATE TABLE `[prefix]_useralbums` (
  `id` 		 	int(8) NOT NULL auto_increment,
  `username` 	varchar(25) NOT NULL,
  `name` 		varchar(100) default NULL,
  `passwd` 		varchar(100) default NULL,
  PRIMARY KEY  (`id`),
  KEY `usernamename` (`username`,`name`)
) TYPE=MyISAM;

## ########################################################

## 
## Table structure for table `[prefix]_transactions`
## 

CREATE TABLE `[prefix]_transactions` (
  `id` int(8) NOT NULL auto_increment,
  `user_id` int(8) NOT NULL default '0',
  `payment_email` varchar(100) NOT NULL default '',
  `from_membership` tinyint(4) NOT NULL default '0',
  `to_membership` tinyint(4) NOT NULL default '0',
  `amount_paid` double NOT NULL default '0',
  `txn_date` date NOT NULL default '0000-00-00',
  `payment_mod` tinyint(4) NOT NULL default '0',
  `payment_vars` text NOT NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM AUTO_INCREMENT=1 ;

## ########################################################

## 
## Table structure for table `[prefix]_log`
## 

CREATE TABLE `[prefix]_log` (
  `id` int(11) NOT NULL auto_increment,
  `page` varchar(20) NOT NULL default '',
  `visits` int(11) NOT NULL default '0',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM AUTO_INCREMENT=1 ;

## ########################################################
## ########################################################
##  Final Release 1.0
## ########################################################
## ########################################################
# --------------------------------------------------------
#
# Table structure for table `[prefix]_calendarevents`
#

CREATE TABLE `[prefix]_calendarevents` (
  `id` int(11) NOT NULL auto_increment,
  `userid` int(11) NOT NULL default '0',
  `event` varchar(255) NOT NULL default '',
  `description` text NOT NULL,
  `recurring` int(11) NOT NULL default '0',
  `recuroption` varchar(255) NOT NULL default '0',
  `calendarid` int(11) NOT NULL default '0',
  `enabled` char(1) NOT NULL default '',
  `timezone` decimal(5,2) NOT NULL default '0.00',
  `datetime_from` datetime NOT NULL default '0000-00-00 00:00:00',
  `datetime_to` datetime NOT NULL default '0000-00-00 00:00:00',
  `private_to` varchar(255) NOT NULL default '',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

# --------------------------------------------------------

#
# Table structure for table `[prefix]_calendars`
#

CREATE TABLE `[prefix]_calendars` (
  `id` int(8) NOT NULL auto_increment,
  `calendar` varchar(255) NOT NULL default '',
  `displayorder` tinyint(2) NOT NULL default '0',
  `enabled` char(1) NOT NULL default '',
  PRIMARY KEY  (`id`),
  KEY `enabled` (`enabled`),
  KEY `displayorder` (`displayorder`)
) TYPE=MyISAM;

# --------------------------------------------------------

#
# Table structure for table `[prefix]_calendarwatchevents`
#

CREATE TABLE `[prefix]_calendarwatchevents` (
  `userid` int(11) NOT NULL default '0',
  `eventid` int(11) NOT NULL default '0',
  PRIMARY KEY  (`userid`,`eventid`)
) TYPE=MyISAM;

# --------------------------------------------------------

#
# Table structure for table `[prefix]_imported_questions`
#

CREATE TABLE `[prefix]_imported_questions` (
  `id` int(11) NOT NULL auto_increment,
  `question_id` int(11) NOT NULL default '0',
  `values_ids` text NOT NULL,
  `module` varchar(50) NOT NULL default '',
  `section` varchar(50) NOT NULL default '',
  `id_spr` mediumint(9) NOT NULL default '0',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

# --------------------------------------------------------

#
# Table structure for table `[prefix]_imported_users`
#

CREATE TABLE `[prefix]_imported_users` (
  `id` int(11) NOT NULL auto_increment,
  `source_id` int(11) NOT NULL default '0',
  `user_id` int(11) NOT NULL default '0',
  `module` varchar(50) NOT NULL default '',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

