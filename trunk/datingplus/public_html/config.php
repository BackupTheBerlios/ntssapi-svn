<?php
/*
-----------
DB Settings
-----------
*/

define( 'DB_USER', 'root' );
define( 'DB_NAME', 'database' );
define( 'DB_HOST', 'localhost' );
define( 'DB_PASS', '' );
define( 'DB_TYPE', 'mysql' );
define( 'DB_PREFIX', 'osdate' );


// -------------
// Mail settings
// -------------

	// text|html
define( 'MAIL_FORMAT', 'text' );
		//mail|sendmail|smtp
define( 'MAIL_TYPE', 'smtp' );
define( 'SMTP_HOST', 'localhost' );
define( 'SMTP_PORT', '25' );
define( 'SMTP_AUTH', '0' );
define( 'SMTP_USER', '' );
define( 'SMTP_PASS', '' );
define( 'SM_PATH', '' );


/*  Define Language Options */
$language_options = array(
	'english' 	=> 'English',
	'german'	=> 'German',
	'greek'		=> 'Greek',
	'dutch' 	=> 'Dutch',
	'spanish'	=> 'Spanish',
	'russian'	=> 'Russian',
	'portuguese'=> 'Portuguese',
	'french'	=> 'French',
	'turkish'	=> 'Turkish',
	'romanian' 	=> 'Romanian'
	);

$language_files = array(
	'english' 	=> 'lang_english/lang_main.php',
	'german'	=> 'lang_german/lang_main.php',
	'greek'		=> 'lang_greek/lang_main.php',
	'dutch'		=> 'lang_dutch/lang_main.php',
	'spanish'	=> 'lang_spanish/lang_main.php',
	'russian'	=> 'lang_russian/lang_main.php',
	'portuguese'=> 'lang_portuguese/lang_main.php',
	'french'	=> 'lang_french/lang_main.php',
	'turkish'	=> 'lang_turkish/lang_main.php',
	'romanian'	=> 'lang_romanian/lang_main.php'
	);

define( 'DEFAULT_LANG', 'english' );

// ---------------
// Default Country
// ---------------

define( 'DEFAULT_COUNTRY', 'US' );

// ---------------
// Get ROOT Path
// ---------------

define( 'FULL_PATH', dirname(__FILE__) . '/' );

// -----------
// PATH Settings
// -----------
define( 'ROOT_DIR', FULL_PATH );
define( 'ADMIN_DIR', FULL_PATH . 'admin/' );
define( 'BANNER_DIR', FULL_PATH . 'banners' );
define( 'SMARTY_DIR', FULL_PATH . 'libs/Smarty/libs/' );
define( 'AUTH_DIR', FULL_PATH . 'libs/Auth/' );
define( 'TEMPLATE_DIR', FULL_PATH . 'templates/' );
define( 'TEMPLATE_C_DIR', FULL_PATH . 'templates_c/' );
define( 'CACHE_DIR', FULL_PATH . 'cache/' );
define( 'CONFIG_DIR', FULL_PATH . 'configs/' );
define( 'PEAR_DIR', FULL_PATH . 'libs/Pear/' );
define( 'LANG_DIR', FULL_PATH . 'language/' );
define( 'MAIL_CLASSES_DIR', FULL_PATH . 'libs/mail/' );
define( 'TEMP_DIR', FULL_PATH.'temp/' );
define( 'USER_IMAGE_DIR', FULL_PATH.'userimages/');

// ---------------------
// GLOBAL PATH Settings
// --------------------
define( 'OSDATE_INSTALLED', '0' );
define( 'DOC_ROOT', '/' );
define( 'LONG_DATE_FORMAT', 'F j, Y' );
define( 'SHORT_DATE_FORMAT', 'm/d/y' );
define( 'DISPLAY_DATE_FORMAT', 'MMM DD, YYYY');
define( 'DATE_TIME_FORMAT', '%b %d, %Y %I:%M:%S %P');
define( 'DATE_FORMAT', '%b %d, %Y');

// ----------------
// DB TABLE Names
// ---------------

define ( 'USER_TABLE', DB_PREFIX . '_user' );
define ( 'QUESTIONS_TABLE', DB_PREFIX . '_questions' );
define ( 'OPTIONS_TABLE', DB_PREFIX . '_questionoptions' );
define ( 'SECTIONS_TABLE', DB_PREFIX . '_sections' );
define ( 'USER_PREFERENCE_TABLE', DB_PREFIX . '_userpreference' );
define ( 'USER_SNAP_TABLE', DB_PREFIX . '_usersnaps' );
define ( 'ADMIN_TABLE', DB_PREFIX . '_admin' );
define ( 'COUNTRIES_TABLE', DB_PREFIX . '_countries' );
define ( 'STATES_TABLE', DB_PREFIX . '_states' );
define ( 'CONFIG_TABLE', DB_PREFIX . '_glblsettings' );
define ( 'USER_SEARCH_TABLE', DB_PREFIX . '_usersearches' );
define ( 'AFFILIATE_TABLE', DB_PREFIX . '_affiliates' );
define ( 'AFFILIATE_REFERALS_TABLE', DB_PREFIX . '_aff_referals' );
define ( 'MAILBOX_TABLE', DB_PREFIX . '_mailbox' );
define ( 'INSTANT_MESSAGE_TABLE', DB_PREFIX . '_instant_message' );
define ( 'MEMBERSHIP_TABLE', DB_PREFIX . '_membership' );
define ( 'POLLS_TABLE', DB_PREFIX . '_polls' );
define ( 'POLLOPTS_TABLE', DB_PREFIX . '_polloptions' );
define ( 'POLLIPS_TABLE', DB_PREFIX . '_pollips' );
define ( 'NEWS_TABLE', DB_PREFIX . '_news' );
define ( 'STORIES_TABLE', DB_PREFIX . '_stories' );
define ( 'ARTICLES_TABLE', DB_PREFIX . '_articles' );
define ( 'ADMIN_LETTER_TABLE', DB_PREFIX . '_letters' );
define ( 'ONLINE_USERS_TABLE', DB_PREFIX . '_onlineusers' );
define ( 'PAGES_TABLE', DB_PREFIX . '_pages' );
define ( 'USER_RATING_TABLE', DB_PREFIX . '_userrating' );
define ( 'PAYMENT_MODULE_TABLE', DB_PREFIX . '_payment_modules' );
define ( 'TABLE_CONFIGURATION', DB_PREFIX . '_payment_config' );
define ( 'BANNER_TABLE', DB_PREFIX . '_banners' );
define ( 'ADMIN_EMAILS_TABLE', DB_PREFIX . '_adminemails' );
define ( 'ADMIN_RIGHTS_TABLE', DB_PREFIX . '_admin_permissions' );
define ( 'BUDDY_BAN_TABLE', DB_PREFIX . '_buddy_ban_list' );
define ( 'FEATURED_PROFILES_TABLE', DB_PREFIX . '_featured_profiles' );
define ( 'VIEWS_WINKS_TABLE', DB_PREFIX . '_views_winks' );

/* Release 1.0 */
define ( 'COUNTIES_TABLE', DB_PREFIX . '_counties' );
define ( 'CITIES_TABLE', DB_PREFIX . '_cities' );
define ( 'USERALBUMS_TABLE', DB_PREFIX . '_useralbums' );
define ( 'TRANSACTIONS_TABLE', DB_PREFIX . '_transactions' );
define ( 'LOG_TABLE', DB_PREFIX . '_log' );
define ( 'CALENDARS_TABLE', DB_PREFIX . '_calendars ' );
define ( 'EVENTS_TABLE', DB_PREFIX . '_calendarevents ' );
define ( 'WATCHES_TABLE', DB_PREFIX . '_calendarwatchevents ' );

/* Modified in Release 1.0 */
define ( 'ZIPCODES_TABLE', DB_PREFIX . '_zips' );

// ----------------
// Error Message Codes
// ---------------

define ('USERNAME_BLANK','1');
define ('PASSWORD_BLANK','2');
define ('FIRSTNAME_REQUIRED','4');
define ('LASTNAME_REQUIRED','5');
define ('EMAIL_REQUIRED','6');
define ('CITY_REQUIRED','7');
define ('ZIP_REQUIRED','8');
define ('FIRSTNAME_LENGTH','11');
define ('LASTNAME_LENGTH','12');
define ('EMAIL_LENGTH','13');
define ('CITY_LENGTH','14');
define ('PASS_CONFIRMPASS', '18');
define ('MANDATORY_FIELDS', '20');
define ('INVALID_LOGIN','21');
define ('USERNAME_EXISTS', '22');
define ('WRONG_OLD_PASSWORD','23');
define ('EMAIL_EXISTS','25');
define ('NOT_ACTIVE', '26');
define ('NO_MESSAGE','27');
define ('UNSUPPORTED_FILE_FORMAT','29');
define ('QUESTION_ON_TOP','30');
define ('QUESTION_AT_BOTTOM','31');
define ('NOT_YET_APPROVED','35');
define ('ACCOUNT_SUSPENDED', '36');
define ('SUBMISSION_DECLINED', '37');
define ('INVALID_BIRTHDATE','38');
define ('OLD_NEW_PASSWORD_MUST_DIFFER', '39');
define ('BIGGER_STARTAGE','40');
define ('ERR_STARTDATE_BEFORE_ENDDATE', '51');
define ('ERR_EXISTING', '52');
define ('INVALID_DATE', '53');
define ('INVALID_USERNAME','54');
define ('NOT_LOGGED_IN','55');
define ('BIG_PIC_SIZE','56');
define ('WRONG_TYPE','57');
define ('FAILED_UPLOAD','58');
define ('PROFILEISADDEDTOLIST','59');
define ('BIGTHUMBNAIL','60');
define ('INVALID_ACTIVATION_CODE','61');
define ('REMOVEDFROMLIST','62');
define ('ADDEDTOBUDDYLIST','63');
define ('ADDEDTOBANLIST','64');
define ('ADDEDTOHOTLIST','65');
define ('WINKISSENT','66');
define ('PICTURE_LOADED','67');
define ('PICTURE_APPROVED','68');
define ('PICTURE_REJECTED','69');
define ('USER_REACTIVATED', '72');
define ('COUNTRY_ADDED','73');
define ('COUNTRY_DELETED', '74');
define ('COUNTRYCODE_INUSE','75');
define ('COUNTRY_MODIFIED','76');
define ('STATE_ADDED','77');
define ('STATE_DELETED', '78');
define ('STATECODE_INUSE', '79');
define ('STATE_MODIFIED','76');
define ('STATEPROVINCE_NEEDED','81');
define ('PROFILE_DELETED','83');
define ('PROFILES_DELETED', '84');
define ('PROFILES_ACTIVATED','85');
define ('PROFILES_REJECTED','86');
define ('PROFILES_SUSPENDED','87');

/* Relese 1.0 */

define ('COUNTY_ADDED','88');
define ('COUNTY_DELETED', '89');
define ('COUNTYCODE_INUSE','90');
define ('COUNTY_MODIFIED','91');
define ('CITY_ADDED','92');
define ('CITY_DELETED', '93');
define ('CITYCODE_INUSE','94');
define ('CITY_MODIFIED','95');
define ('ZIP_ADDED','96');
define ('ZIP_DELETED', '97');
define ('ZIPCODE_INUSE','98');
define ('ZIP_MODIFIED','99');
define ('COUNTY_REQUIRED','100');
define ('INVALID_PASSWORD','101');

define ('EVENT_APPROVED','102');
define ('EVENT_REJECTED','103');

define ('REGN_COMPLETED','200');
define ('INVALID_TIMEZONE','301');
define ('ALBUM_CHANGED','302');

/* Folowing are for template oriented messages. */
define ('NO_TEMPLATE', '2');
define ('PASSWORD_MAIL_SENT','0');
define ('MAIL_ERROR','4');
define ('NOT_REGISTERED','5');

/* Story errors */
define ('NO_STORY_HDR','1');
define ('NO_STORY_TEXT','2');
define ('NO_STORY_SENDER','4');

/* Page errors */
define ('NO_PAGE_HDR','1');
define ('NO_PAGE_KEY','2');
define ('NO_PAGE_TEXT','3');
define ('PAGE_EXISTS','4');

/* News and Articles errors */
define ('NO_HDR','1');
define ('NO_TEXT','2');

/* Membership errors */
define ('NO_NAME','1');
define ('NO_PRICE','2');
define ('NO_CURRENCY','3');

/* Banner Messages */
define ('BANNER_BLANK','1');
define ('LINK_BLANK','2');
define ('WRONG_TYPE','4');

/* POll Error */
define ('OPTION_BLANK','3');

/* Admin errors */
define ('USERNAME_BLANK','1');
define ('PASSWORD_BLANK','2');
define ('FULLNAME_BLANK','3');
define ('OLDPWD_BLANK','4');
define ('NEWPWD_BLANK','5');
define ('CONFPWD_BLANK','6');
define ('DIFF_PASSWORDS','7');
define ('WRONG_PASSWORD','8');

/* Letter errors */
define ('INVALID_EMAIL','2');
define ('ALL_OK','0');
define ('EMAIL_PROBLEM','4');
define ('NOT_REGISTERED','5');

/* others */
define ('ALREADY_EXISTS','9');

define ('SECTION_BLANK','1');
define ('FIELDS_BLANK','2');
define ('CALENDAR_BLANK','3');

@ini_set('include_path',PEAR_DIR.':'.get_include_path());

?>
