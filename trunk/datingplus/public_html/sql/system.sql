## 
## Data for table `[prefix]_admin`
## 

## 
## Data for table `[prefix]_admin_permissions`
## 

INSERT INTO `[prefix]_admin_permissions` (`id`, `adminid`, `site_stats`, `profie_approval`, `profile_mgt`, `section_mgt`, `affiliate_mgt`, `affiliate_stats`, `news_mgt`, `article_mgt`, `story_mgt`, `poll_mgt`, `search`, `ext_search`, `send_letter`, `pages_mgt`, `chat`, `chat_mgt`, `forum_mgt`, `mship_mgt`, `payment_mgt`, `banner_mgt`, `seo_mgt`, `admin_mgt`, `admin_permit_mgt`, `global_mgt`, `change_pwd`,`cntry_mgt`,`snaps_require_approval`,`featured_profiles_mgt`, `calendar_mgt`, `event_mgt`, `import_mgt`  ) VALUES (1, 1, '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1','1','1','1','1','1','1');


## 
## Data for table `[prefix]_glblsettings`
## 

INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('site_name', 'osDate', 'Site Name');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('site_title', 'Your Dating Site Title', 'Site Title');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('site_logo', '', 'Site Banner including logo to be displayed in the TOP in place of Site Name');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('admin_email', 'admin@domain.net', 'Site Administrator E-Mail');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('feedback_email', 'osDate Admin <info@domain.net>', 'Email address at which admin will receive feedback emails');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('copyright', 'Powered by osDate', 'Copyright Text');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('enable_mod_rewrite', 'N', 'Enable mod-rewrite');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('session_timeout', '15', 'Time in minutes, after which the user will be automatically logged out.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('skin_name', 'default-blue', 'Site Theme / Skin <b>(requires page refresh)</b>');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('no_last_new_users', '2', 'No. of last new profiles to be displayed on home page');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('show_featured_profiles', '4', 'No. of Featured profiles to be displayed on home page');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('list_newmembers', '10', 'Number of New Members to be listed');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('phpbb_installed', 'Y', 'Enable phpBB forum?');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('default_active_status', 'Y', 'By Default, Profile to be Active or not.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('default_user_level', '4', 'The default Level of access to the user.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('min_pass_len', '5', 'Minimum password length.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('max_pass_len', '20', 'Maximum password length.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('min_username_len', '5', 'Minimum username length.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('max_username_len', '20', 'Maximum username length.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('use_profilepopups', 'N', 'Use Javascript Popups for Profiles?');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('feedback_info', 'N', 'Feedback only from logged in User? ');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('cntry_mgt', 'Y', 'Manage Countries/States/Cities');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('default_country', 'US', 'Default Country.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('state_mandatory', 'Y', 'State to be made Mandatory Field.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('county_mandatory', 'Y', 'County/District to be made Mandatory Field.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('city_mandatory', 'Y', 'City/Town to be made Mandatory Field.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('zipcode_mandatory', 'Y', 'Zip/Pin Code to be made Mandatory Field.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('snaps_require_approval', 'N', 'Pictures must be approved before it is displayed ?');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('images_in_db', 'Y', 'Images are to be stored in DB.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('disp_snap_width', '100', 'Profile image display width.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('disp_snap_height', '150', 'Profile image display height');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('upload_snap_tnsize', '100', 'Thumbnail image size.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('upload_snap_maxsize', '400000', 'Maximum size for Picture.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('upload_snap_ext', 'jpg,png,gif,bmp', 'Upload image extensions.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('watermark_snaps', 'osdate001', 'Snaps Watermark text.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('watermark_position_h', 'right', 'Snaps Watermark Horizontal position. &lt;left/right/center&gt;');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('watermark_position_v', 'bottom', 'Snaps Watermark Vertical position. &lt;top/middle/bottom&gt;');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('watermark_margin', '10', 'Snaps Watermark Margin');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('watermark_text_shadow', '1', 'Shadow Snaps Watermark text. <1=Yes,0=No>');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('watermark_text_color', '#ffffff', 'Snaps Watermark text color.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('page_size', '5', 'No. of records to show per page in admin.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('search_results_per_page', '5', 'No. of results to show on a page.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('cellpadding', '1', 'HTML table cellpadding.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('cellspacing', '2', 'HTML table cellspacing.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('bgcolor', '#FFFFFF', 'Background color.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('textcolor', '#003366', 'Default foreground color.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('body_leftmargin', '0', 'Left margin for body tag.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('body_topmargin', '0', 'Top margin for body tag.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('start_year', '-90', 'Starting value of year in birth date field.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('end_year', '-16', 'End value in year of birth date field.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('default_start_agerange', '18', 'Default value for start age range in quick search');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('default_end_agerange', '50', 'Default value for end age range in quick search');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('length_article', '200', 'Maximum characters to display in short article text.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('length_story', '50', 'Maximum words to display in short story.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('no_news', '2', 'No. of news items to display.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('length_news', '150', 'Short news length.');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('aff_referral_price', '10', 'Price per Affiliate Referral');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('calendar_month_day_events_limit', '4', 'Maximal number of events on month\'s day');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('calendar_week_end_events_limit', '23', 'Maximal number of events on weekdays');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('calendar_week_day_events_limit', '12', 'Maximal number of events on weekends');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('calendar_day_events_limit', '40', 'Maximal number of events on day view');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('server_timezone', '-5', 'Server Timezone');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('meta_description', 'Online matchmaking and dating system. Register with us to find your perfect match. Our system includes dozens of powerful search options, advanced profiles, a live forum, and fully integrated chat. Powered by osDate, (c) 2006 TUFaT.com', 'Description in Meta Tag');
INSERT INTO `[prefix]_glblsettings` (`config_variable`, `config_value`, `description`) VALUES ('meta_keywords', 'dating, matchmaker, romance, soulmate, dating system, web date, online date, webdate, aedating, dating pro, open source dating, match.com, perfect match, personals, sex, cybersex', 'Keywords in Meta Tag');
## 
## Data for table `[prefix]_calendars`
## 

INSERT INTO `[prefix]_calendars` (`id`, `calendar`, `displayorder`, `enabled`) VALUES (1, 'Default Calendar', 0, 'Y');

## 
## Data for table `[prefix]_membership`
## 

INSERT INTO `[prefix]_membership` (`id`, `roleid`, `name`, `chat`, `forum`, `includeinsearch`, `message`, `uploadpicture`, `seepictureprofile`, `fullsignup`, `price`, `currency`, `enabled`, `activedays`, `favouritelist`, `sendwinks`, `extsearch`,`uploadpicturecnt`,`allowalbum`, `event_mgt`) VALUES (1, 1, 'Gold', '1', '1', '1', '1', '1', '1', '1', 20, 'USD', 'Y','365','1', '1', '1',20,'1','1');
INSERT INTO `[prefix]_membership` (`id`, `roleid`, `name`, `chat`, `forum`, `includeinsearch`, `message`, `uploadpicture`, `seepictureprofile`, `fullsignup`, `price`, `currency`, `enabled`, `activedays`, `favouritelist`, `sendwinks`, `extsearch`,`uploadpicturecnt`,`allowalbum`, `event_mgt`) VALUES (2, 2, 'Silver', '1', '1', '1', '1', '1', '1', '1', 10, 'USD', 'Y','365', '1', '1', '1',5,'1','1');
INSERT INTO `[prefix]_membership` (`id`, `roleid`, `name`, `chat`, `forum`, `includeinsearch`, `message`, `uploadpicture`, `seepictureprofile`, `fullsignup`, `price`, `currency`, `enabled`, `activedays`, `favouritelist`, `sendwinks`, `extsearch`,`uploadpicturecnt`,`allowalbum`, `event_mgt`) VALUES (3, 3, 'Visitor', '0', '0', '0', '0', '0', '1', '1', 0, 'USD', 'Y','1', '0', '0', '0',0,'0','0');
INSERT INTO `[prefix]_membership` (`id`, `roleid`, `name`, `chat`, `forum`, `includeinsearch`, `message`, `uploadpicture`, `seepictureprofile`, `fullsignup`, `price`, `currency`, `enabled`, `activedays`, `favouritelist`, `sendwinks`, `extsearch`,`uploadpicturecnt`,`allowalbum`, `event_mgt`) VALUES (4, 4, 'Free', '0', '0', '1', '0', '1', '1', '1', 0, 'USD', 'Y','7', '0', '0', '1',1,'0','0');


## 
## Data for table `phpbb_users`
## 

INSERT INTO `phpbb_users` (`user_id`, `user_active`, `username`, `user_password`, `user_session_time`, `user_session_page`, `user_lastvisit`, `user_regdate`, `user_level`, `user_posts`, `user_timezone`, `user_style`, `user_lang`, `user_dateformat`, `user_new_privmsg`, `user_unread_privmsg`, `user_last_privmsg`, `user_emailtime`, `user_viewemail`, `user_attachsig`, `user_allowhtml`, `user_allowbbcode`, `user_allowsmile`, `user_allowavatar`, `user_allow_pm`, `user_allow_viewonline`, `user_notify`, `user_notify_pm`, `user_popup_pm`, `user_rank`, `user_avatar`, `user_avatar_type`, `user_email`, `user_icq`, `user_website`, `user_from`, `user_sig`, `user_sig_bbcode_uid`, `user_aim`, `user_yim`, `user_msnm`, `user_occ`, `user_interests`, `user_actkey`, `user_newpasswd`) VALUES (-1, 0, 'Anonymous', '', 0, 0, 0, 1124204935, 0, 0, 0.00, NULL, '', '', 0, 0, 0, NULL, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, NULL, '', 0, '', '', '', '', '', NULL, '', '', '', '', '', '', '');
INSERT INTO `phpbb_users` (`user_id`, `user_active`, `username`, `user_password`, `user_session_time`, `user_session_page`, `user_lastvisit`, `user_regdate`, `user_level`, `user_posts`, `user_timezone`, `user_style`, `user_lang`, `user_dateformat`, `user_new_privmsg`, `user_unread_privmsg`, `user_last_privmsg`, `user_emailtime`, `user_viewemail`, `user_attachsig`, `user_allowhtml`, `user_allowbbcode`, `user_allowsmile`, `user_allowavatar`, `user_allow_pm`, `user_allow_viewonline`, `user_notify`, `user_notify_pm`, `user_popup_pm`, `user_rank`, `user_avatar`, `user_avatar_type`, `user_email`, `user_icq`, `user_website`, `user_from`, `user_sig`, `user_sig_bbcode_uid`, `user_aim`, `user_yim`, `user_msnm`, `user_occ`, `user_interests`, `user_actkey`, `user_newpasswd`) VALUES ('', 1, 'admin', md5('pass'), 1124272045, -1, 1124206587, 0, 1, 0, 0.00, NULL, NULL, 'd M Y H:i', 0, 0, 0, NULL, NULL, NULL, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

## 
## Dumping data for table `[prefix]_payment_modules`
## 

INSERT INTO `[prefix]_payment_modules` (`id`, `name`, `module_key`, `class_file`, `formfile`, `enabled`) VALUES (1, 'Authorize.Net', 'authorizenet', 'authorizenet.php', 'frmauthorizenet.tpl', 'N');
INSERT INTO `[prefix]_payment_modules` (`id`, `name`, `module_key`, `class_file`, `formfile`, `enabled`) VALUES (2, 'PayPal', 'paypal', 'paypal.php', 'frmpaypal.tpl', 'N');
INSERT INTO `[prefix]_payment_modules` (`id`, `name`, `module_key`, `class_file`, `formfile`, `enabled`) VALUES (3, '2Checkout', 'pm2checkout', 'pm2checkout.php', 'frmpm2checkout.tpl', 'N');
INSERT INTO `[prefix]_payment_modules` (`id`, `name`, `module_key`, `class_file`, `formfile`, `enabled`) VALUES (4, 'Credit Card', 'cc', 'cc.php', 'frmcc.tpl', 'N');
INSERT INTO `[prefix]_payment_modules` (`id`, `name`, `module_key`, `class_file`, `formfile`, `enabled`) VALUES (5, 'iPayment', 'ipayment', 'ipayment.php', 'frmipayment.tpl', 'N');
INSERT INTO `[prefix]_payment_modules` (`id`, `name`, `module_key`, `class_file`, `formfile`, `enabled`) VALUES (6, 'NOCHEX', 'nochex', 'nochex.php', 'frmnochex.tpl', 'N');
INSERT INTO `[prefix]_payment_modules` (`id`, `name`, `module_key`, `class_file`, `formfile`, `enabled`) VALUES (7, 'SECPay', 'secpay', 'secpay.php', 'frmsecpay.tpl', 'N');
INSERT INTO `[prefix]_payment_modules` (`id`, `name`, `module_key`, `class_file`, `formfile`, `enabled`) VALUES (8, 'PSiGate', 'psigate', 'psigate.php', 'frmpsigate.tpl', 'N');
