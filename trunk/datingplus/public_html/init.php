<?php

session_start();
error_reporting( E_ALL - E_NOTICE );

require_once( dirname(__FILE__).'/config.php' );

if ( !OSDATE_INSTALLED ) {
	die ( '<font face=Arial size=2>osDate is not installed, or a previous installation was not successfully completed.<br /><br />Please run <a href=install.php>install.php</a> to use osDate. You will need your database login parameters, and the ability to set the permissions on various files and folders on your server.</font>' );
}

// require_once MAIL_CLASSES_DIR . 'class.phpmailer.php';
require_once SMARTY_DIR . 'Smarty.class.php';
require_once PEAR_DIR . 'DB.php';
require_once PEAR_DIR . 'Mail.php';
require_once dirname(__FILE__).'/includes/internal/Functions.php' ;

if (isset( $_COOKIE['osdate_info'] ) ) {

	$cookie = $_COOKIE['osdate_info'];

	list($_SESSION['lookagestart'], $_SESSION['lookageend'])= split(':',$cookie['search_ages']);

}

$lang = array();

$_SESSION['browser'] = getUserBrowser();

$t = new Smarty;


/************************/
// SECURITY CHECK
/************************/

if ( $_SERVER[HTTP_HOST] != 'localhost' && ( file_exists( FULL_PATH.'install.php' ) || is_dir( FULL_PATH.'install_files' ) ) ) {

	echo '
	<br /><br /><br /><center>
	<table border=0 width=500 cellpadding=2 cellspacing=0>
		<tr>
			<td align=center>
				<font color=red face=Arial size=2><B>SECURITY ALERT<br /><br />Please remove the following from your server before continuing: install.php file, and the install_files folder. Then, click "Reload osDate" below to continue.<br /><br />

				<a href=index.php>Reload osDate</a></B></font>
			</td>
		</tr>
	</table></center>';

	exit;
}


/**********************************/
// PEAR SETUP
/**********************************/

$dsn = DB_TYPE . '://' . DB_USER . ':' . DB_PASS . '@' . DB_HOST . '/' . DB_NAME;
$db = @DB::connect( $dsn );
$db->setFetchMode( DB_FETCHMODE_ASSOC );

function errhndl ( $err ) {
	echo '<pre>' . $err->message;
	print_r( $err );
	die();
}

PEAR::setErrorHandling( PEAR_ERROR_CALLBACK, 'errhndl' );


/*
if ( !get_magic_quotes_gpc() ) {
   function addslashes_deep($value) {
       return is_array($value) ? array_map('addslashes_deep', $value) : addslashes($value);
   }

   $_POST 	= array_map('addslashes_deep', $_POST);
   $_GET 	= array_map('addslashes_deep', $_GET);
   $_COOKIE	= array_map('addslashes_deep', $_COOKIE);
}
*/

$params = array();// for mail sending with Pear's Mail class

if ( MAIL_TYPE == 'smtp' ) {
	$params['host'] = SMTP_HOST;
	$params['port'] = SMTP_PORT;
	$params['auth'] = (int)SMTP_AUTH;
	$params['username'] = SMTP_USER;
	$params['password'] = SMTP_PASS;
}

/**********************************/
// STARTUP CONFIGURATION DATA
/**********************************/

$configs = $db->getAll( 'SELECT * from !',array( CONFIG_TABLE ) );
$config = array();

foreach( $configs as $index => $row ) {
	$config[ $row[config_variable] ] = $row[config_value];
}

$config['use_popups'] = 'Y';

$t->assign ( 'config', $config );

$skin_name = $config['skin_name'];
$lang['site_name'] = $config['site_name'];
define ('SITENAME', $config['site_name']);

require_once LANG_DIR.$language_files['english'];

if ($_REQUEST['lang']!= '') {$opt_lang=$_REQUEST['lang'];}
elseif ($_SESSION['opt_lang'] != '') {$opt_lang=$_SESSION['opt_lang'];}
elseif ($_COOKIE['opt_lang'] != '') {$opt_lang=$_COOKIE['opt_lang'];}
else {$opt_lang=DEFAULT_LANG; }

// hack - fix later
if ( strlen( $opt_lang ) <= 3 ) {
	$opt_lang = DEFAULT_LANG;
}

$langfile = LANG_DIR.$language_files[$opt_lang];

$_SESSION['opt_lang'] = $opt_lang;
setcookie('opt_lang',$opt_lang,time()+60*60*24*365);

require_once $langfile;

/* DO NOT CHANGE THESE */
$lang['status_enum'] = array(
	'approval' => 'Pending',
	'active' => 'Active',
	'rejected' => 'Reject',
	'suspended' => 'Suspend',
	);

$lang['error_msg_color'] = 'red';

$t->template_dir = TEMPLATE_DIR . 'current/';
$t->compile_dir = TEMPLATE_C_DIR;
$t->cache_dir = CACHE_DIR;
$t->caching = false;
$t->force_compile = true;
//$t->debugging = true;

$t->assign('language_options', $language_options);

/**********************************/
// GET CALENDARS
/**********************************/
$sql = 'select id, calendar from ! where enabled = ? order by displayorder asc';
$temp = $db->getAll( $sql, array( CALENDARS_TABLE, 'Y' ) );
foreach( $temp as $index => $row ) {
	$calendars[ $row[id] ] = $row[calendar];
}
$t->assign( 'calendars', $calendars );

// fix later....
$sql = 'select id, displayorder, calendar from !';
$temp = $db->getAll( $sql, array( CALENDARS_TABLE ) );
foreach( $temp as $index => $row ) {
	$calendars[ $row[id] ] = $row[calendar];
}
$t->assign( 'allcalendars', $calendars );

/**********************************/
// GET REGISTRATION SECTIONS
/**********************************/

$sql = 'select id, section from ! where enabled = ? order by displayorder asc';

$temp = $db->getAll( $sql, array( SECTIONS_TABLE, 'Y' ) );

foreach( $temp as $index => $row ) {
	$sections[ $row[id] ] = $row[section];
}

$t->assign( 'sections', $sections );

// fix later....
$sql = 'select id, displayorder, section from !';
$temp = $db->getAll( $sql, array( SECTIONS_TABLE ) );

foreach( $temp as $index => $row ) {
	$sections[ $row[id] ] = $row[section];
}

$t->assign( 'allsections', $sections );


/***********************************************/
// COUNTRIES & STATES - MOVE LATER & COLSOLIDATE
/***********************************************/

include_once('countries_list.php');

$lang['countries'] = $countries;

$lang['allcountries'] = $allcountries;
/**********************************/
// GET ONLINE USERS
/**********************************/

$sql = 'SELECT count(ou.userid) as onlineusers FROM ! ou, ! as user where ou.userid <> ifnull(?,-1) and ou.userid = user.id and user.allow_viewonline = ? ';
$usersOnline = $db->getOne( $sql, array( ONLINE_USERS_TABLE, USER_TABLE, $_SESSION['UserId'], '1' ) );
$t->assign( 'online_users_count', $usersOnline );

$t->assign( 'docroot', DOC_ROOT );
$t->assign( 'banner_dir', DOC_ROOT.'banners/' );
$t->assign( 'zodiac_dir', DOC_ROOT.'templates/'.$skin_name. '/zodiacsigns/' );
$t->assign( 'image_dir', DOC_ROOT.'templates/current/images/' );
$t->assign( 'css_path', DOC_ROOT.'templates/current/' );

include_once( 'polls.php' );
include_once( 'stories.php' );
include_once( 'news.php' );

/**********************************/
// BANNERS
/**********************************/

$banner = array();

$time = time();

$index = 0;

$sql1 = 'SELECT id FROM ! WHERE ( startdate <= ? AND  expdate >= ? ) AND enabled = ?';

$temp = $db->getAll( $sql1, array( BANNER_TABLE, $time, $time, 'Y' ) );

if ( sizeof( $temp ) > 0 ) {

	$j = 1;

	foreach( $temp as $index => $row ) {
		$banner[$j++] = $row[id];
	}

	$my_banner = $banner[ rand( 1, --$j ) ];

	$sql2 = 'SELECT bannerurl FROM ! WHERE id = ?';

	$bannerURL = $db->getOne( $sql2, array( BANNER_TABLE, $my_banner ) );

	$t->assign( 'banner', stripslashes( $bannerURL ) );
}

$t->assign( 'lang', $lang );


/**********************************/
// UPDATE ONLINE STATUS
/**********************************/

if ( isset( $_SESSION['UserId'] ) ) {

	if ( $_SESSION['UserId'] ) {

		$sql = 'SELECT * FROM ! WHERE userid = ?';

		$isOnline = $db->getOne( $sql, array( ONLINE_USERS_TABLE, $_SESSION['UserId'] ) );

		if( $isOnline > 0 ) {
			$sql = 'UPDATE ! SET lastactivitytime= ? WHERE userid = ?';

			$db->query( $sql, array( ONLINE_USERS_TABLE, $time, $_SESSION['UserId'] ) );
		}
		else {
			$sql = 'INSERT INTO ! ( userid, lastactivitytime ) values (?, ? )';

			$db->query( $sql, array( ONLINE_USERS_TABLE, $_SESSION['UserId'], $time ) );
		}

		$sql = 'select count(*) from ! where recipientid = ? and flagread = ? and folder = ?';

		$t->assign('new_messages', $db->getOne($sql, array(MAILBOX_TABLE, $_SESSION['UserId'], '0', 'inbox') ) );

	}
}

/***********************************/
/* Collect site statistics         */
/***********************************/

$sql = 'select count(*) from ! where active = ? and regdate > ? and status in ( ?, ?) ';

$weekcnt = $db->getOne( $sql, array( USER_TABLE, '1', strtotime("-7 day"), 'Active', $lang['status_enum']['active'] ) );

$t->assign( 'weekcnt', $weekcnt );

$sql = 'select sum(if(gender=\'M\',1,0)) as gents, sum(if(gender=\'F\',1,0)) as females, sum(if(gender=\'C\',1,0)) as couples from ! where active = ? and status in (?, ?)';

$row = $db->getRow( $sql, array( USER_TABLE, '1', 'Active', $lang['status_enum']['active']  ) );

$t->assign( 'gents', $row['gents'] );

$t->assign( 'females', $row['females'] );

$t->assign( 'couples', $row['couples'] );

$sql = 'select count(*) from ! where ins_time > ? ';

$weeksnaps = $db->getOne( $sql, array( USER_SNAP_TABLE, strtotime("-7 day") ) );

$t->assign( 'weeksnaps', $weeksnaps );

/**********************************/
// TOGGLE CHECK ONLINE STATUS
/**********************************/

if ( !isset( $_SESSION['LastExecTime'] ) ) {
	$_SESSION['LastExecTime'] = time();
}

if ( time() - $_SESSION['LastExecTime'] > 300 ) {

	$sql = 'SELECT * FROM !';

	$temp = $db->getAll( $sql, array( ONLINE_USERS_TABLE ) );

	if ( sizeof( $temp ) > 0 ) {

		foreach( $temp as $index => $row ) {
			if ( ( time() - $row['lastactivitytime'] ) > (int)( $config['session_timeout'] * 60 ) ) {

				$db->query( 'DELETE FROM ! WHERE userid = ?', array( ONLINE_USERS_TABLE, $row['userid'] ) );
			}
		}
	}
	$_SESSION['LastExecTime'] = time();
}

function querystring( $arr ) {

	$str = '';

	foreach( $arr as $item ) {

		if( !is_array( $_GET[$item]) ){
			$str .= $item . '=' . urlencode($_GET[$item]) . '&';
		} elseif (is_array( $_GET[$item]) ) {
			foreach( $_GET[$item] as $subitem) {
				$str .= $item . urlencode('[]') . '=' . urlencode($subitem) . '&';
			}
		} elseif( !is_array( $_POST[$item]) ){
			$str .= $item . '=' . urlencode($_POST[$item]) . '&';
		} elseif (is_array( $_POST[$item]) ) {
			foreach( $_POST[$item] as $subitem) {
				$str .= $item . urlencode('[]') . '=' . urlencode($subitem) . '&';
			}
		}
	}

	return $str;
}


function checkOnlineStats( $userid  ) {
	global $db;

	$sql = 'SELECT count(*) as num FROM ! WHERE userid = ?';

	if ( $db->getOne( $sql, array( ONLINE_USERS_TABLE, $userid ) ) ) {
		return 'online';
	}
	else {
		return 'offline';
	}
}

/****************HMAC Hash Generation Function used in Credit Card Transaction*****************/
function hmac ($key, $data)
{
// RFC 2104 HMAC implementation for php.
// Creates an md5 HMAC.
// Eliminates the need to install mhash to compute a HMAC
// Hacked by Lance Rushing

	$b = 64; // byte length for md5

	if (strlen($key) > $b) {

	   $key = pack("H*",md5($key));

	}

	$key  = str_pad($key, $b, chr(0x00));

	$ipad = str_pad('', $b, chr(0x36));

	$opad = str_pad('', $b, chr(0x5c));

	$k_ipad = $key ^ $ipad ;

	$k_opad = $key ^ $opad;

	return md5($k_opad  . pack("H*",md5($k_ipad . $data)));
}
// end code from lance (resume authorize.net code)

// Calculate and return fingerprint
// Use when you need control on the HTML output
function CalculateFP ($loginid, $txnkey, $amount, $sequence, $tstamp, $currency = "") {

	return (hmac ($txnkey, $loginid . "^" . $sequence . "^" . $tstamp . "^" . $amount . "^" . $currency));

}

function getLastId() {
	global $db;
	return $db->getOne( 'select LAST_INSERT_ID()' );
}

function hasRight($field){
	global $db, $config;

	if( $_SESSION['security'] == '' ){
		if ($_SESSION['UserId'] == '') {

			$sqlsecurity = 'SELECT * FROM ! where name = ?';

			$row = $db->getRow( $sqlsecurity, array( MEMBERSHIP_TABLE, 'Visitor' ) );

		} elseif( $_SESSION['UserId'] != '' and $_SESSION['expired'] != '1' ){

			// fix later

			$sqlsecurity = 'SELECT * FROM ! where roleid = ?';

			$row = $db->getRow( $sqlsecurity, array( MEMBERSHIP_TABLE, $_SESSION['RoleId'] ) );

		} else {

			$sqlsecurity = 'SELECT * FROM ! WHERE  roleid = ?';

			$row = $db->getRow( $sqlsecurity, array( MEMBERSHIP_TABLE, $config['default_user_level'] ) );

		}

		if( $row ) {
			$_SESSION['security'] = $row;
		}
	}

	return (int)$_SESSION['security'][$field];
}

function checkAdminPermission( $str ) {
	$permit = $_SESSION['Permissions'];
	return $permit[$str] ? 1 : 0;
}

/* Ascertain the sort type */

function checkSortType( $sort_type ) {
	$n_sort_type = '';

	if ( $sort_type == '' ) {

		$n_sort_type = 'asc';

	} elseif ( $sort_type == 'asc' ) {

		$n_sort_type = 'desc' ;

	} elseif( $sort_type == 'desc' ) {

		$n_sort_type = 'asc' ;

	}
	return $n_sort_type;
}

function makeOptions ( $options ) {

	$result = array();

	foreach( $options as $index => $row ) {

		$result[ $row[id] ] = $row[answer];
	}
	return $result;
}

function makeAnswers ( $options ) {

	$result = array();

	foreach( $options as $index => $row ) {

		$result []= $row[answer];
	}
	return $result;
}

function findSortBy ( $def = 'id' ) {

	global $lang, $_REQUEST;

	if( $_REQUEST['sort'] == '' ) {

		return( $def. ' '. 'asc');

	} else if( $_REQUEST['sort'] == $lang['col_head_id'] ) {

		$sort_by = $def;

	} else if( $_REQUEST['sort'] == $lang['col_head_username'] ) {

		$sort_by = 'username';

	} else if( $_REQUEST['sort'] == $lang['col_head_name'] ) {

		$sort_by = 'name';

	} else if( $_REQUEST['sort'] == $lang['col_head_firstname'] ) {

		$sort_by = 'firstname';

	} else if( $_REQUEST['sort'] == $lang['col_head_register_at'] ) {

		$sort_by = 'regdate';

	} 	else if ( $_REQUEST['sort'] == $lang['col_head_gender'] ) {

		$sort_by = 'gender';

	} else if ( $_REQUEST['sort'] == $lang['col_head_email'] ) {

		$sort_by = 'email';

	} elseif ( $_REQUEST['sort'] == $lang['col_head_subject'] ) {

		$sort_by = 'subject';

	} elseif ( $_REQUEST['sort'] == $lang['col_head_sendtime'] ) {

		$sort_by = 'sendtime';

	}else if( $_REQUEST['sort'] == $lang['total_referals'] ) {

		$sort_by = 'totalref';

	}else if ( $_REQUEST['sort'] == $lang['regis_referals'] ) {

		$sort_by = 'regref';

	} else if ( $_REQUEST['sort'] == $lang['col_head_status'] ) {

		$sort_by = 'status';

	} else if ( $_REQUEST['sort'] == $lang['level_hdr'] ) {

		$sort_by = 'level';

	} else if ( $_REQUEST['sort'] == $lang['date_from'] ) {

		$sort_by = 'start_date';

	} else if ( $_REQUEST['sort'] == $lang['date_upto'] ) {

		$sort_by = 'end_date';
	} else if ( $_REQUEST['sort'] == $lang['admin_col_head_fullname'] ) {

		$sort_by = 'fullname ';

	} else if( $_REQUEST['sort'] == $lang['col_head_fullname'] ) {

		return( 'firstname '.checkSortType ( $_REQUEST['type'] ) . ', lastname '.checkSortType ( $_REQUEST['type'] ) );

	} else if( $_REQUEST['sort'] == $lang['superuser'] ) {

		$sort_by = 'super_user';

	} else if( $_REQUEST['sort'] == $lang['col_head_enabled'] ) {

		$sort_by = 'enabled';

	}  else if( $_REQUEST['sort'] == $lang['article_title'] ) {

		$sort_by = 'title';

	} else if( $_REQUEST['sort'] == $lang['news_header'] ) {

		$sort_by = 'header';

	} else if( $_REQUEST['sort'] == $lang['poll'] ) {

		$sort_by = 'question';

	} else if( $_REQUEST['sort'] == $lang['active'] ) {

		$sort_by = 'active';

	} else if( $_REQUEST['sort'] == $lang['news_header'] ) {

		$sort_by = 'header';

	} else if( $_REQUEST['sort'] == $lang['story_sender'] ) {

		$sort_by = 'sender';

	} else if( $_REQUEST['sort'] == $lang['option'] ) {

		$sort_by = 'opt';

	} else if( $_REQUEST['sort'] == $lang['votes'] ) {

		$sort_by = 'result';

	} else if( $_REQUEST['sort'] == $lang['col_head_answer'] ) {

		$sort_by = 'answer';

	} else if( $_REQUEST['sort'] == $lang['col_head_question'] ) {

		$sort_by = 'question';

	} else if ( $_REQUEST['sort'] == $lang['state_code'] || $_REQUEST['sort'] == $lang['country_code']  || $_REQUEST['sort'] == $lang['county_code']|| $_REQUEST['sort'] == $lang['city_code'] || $_REQUEST['sort'] == $lang['zip_code']  ) {

		$sort_by = 'code';

	} else if ( $_REQUEST['sort'] == $lang['state_name'] || $_REQUEST['sort'] == $lang['country_name'] || $_REQUEST['sort'] == $lang['county_name'] || $_REQUEST['sort'] == $lang['city_name'] ) {

		$sort_by = 'name';

	}

	return ($sort_by . ' ' . checkSortType ( $_REQUEST['type'] ));
}

//Log code by Nathan Adams
$page = $_SERVER['REQUEST_URI'];
$IS_IN_ADMIN = strpos($page, 'admin');
$IS_NOT_SCRIPT = strpos($page, '?');
if ($IS_NOT_SCRIPT === FALSE){
	if ($IS_IN_ADMIN === FALSE){
		$pos = strrpos($page, '/');
		$page_script = substr($page, $pos+1);
		$sql_page = str_replace('.php', '', $page_script);
		if ($sql_page != 'getuser' && $sql_page != 'getinstantmsg'){
			if ($sql_page == ''){
				$sql_page = 'index';
			}
			$check_tablesql = 'SELECT * FROM ! WHERE page = ?';
			$check_table = $db->getRow ( $check_tablesql, array ( LOG_TABLE, $sql_page ) );
			$count_array = count($check_table);
			if ($count_array > 0){ //ok it exists
				$update_log = 'UPDATE ! SET visits = visits + 1 WHERE page = ?';
				$query = $db->Query ( $update_log, array ( LOG_TABLE, $sql_page ) );
			} else {
				$create_row = "INSERT INTO ! (page, visits) VALUES (?, '1')";
				$db->Query ( $create_row, array ( LOG_TABLE, $sql_page ) );
			}
		}
	}
}

	function make_datetime_from_smarty($prefix)
	{	global $_REQUEST;
		$date=$_REQUEST[$prefix."Year"]."-".$_REQUEST[$prefix."Month"]."-".$_REQUEST[$prefix."Day"];
		$time=$_REQUEST[$prefix."Hour"];
		if(isset($_REQUEST[$prefix."Minute"])) $time.=":".$_REQUEST[$prefix."Minute"];
		if(isset($_REQUEST[$prefix."Second"])) $time.=":".$_REQUEST[$prefix."Second"];
		return($date." ".$time);
	}

	function send_watched_mails($eventid)
	{	global $config;
		global $db;
		global $lang;
		global $t;
		global $params;

		$sql="select u.* ".
			 "from ! as u inner join ! as we on u.id=we.userid ".
			 "where we.eventid=? ";
		$users=$db->getAll($sql,array(USER_TABLE,WATCHES_TABLE,$eventid));

		if($users)
		foreach($users as $key=>$user)
		{	$recipients = $user["email"];

			$query="select id, userid, event, description, ".
				   "       date_add(datetime_from, interval ! hour) as datetime_from, ".
				   "       date_add(datetime_to, interval ! hour) as datetime_to, ".
				   "       calendarid, timezone, private_to ".
				   "from ! ".
				   "where id=? ";
			$event=$db->getRow($query,array($user["timezone"], $user["timezone"], EVENTS_TABLE,$eventid));

			$headers['From']    = $config['admin_email'];
//			$headers['To']      = $user["email"];
			$headers['Subject'] = $lang['event_notification'];

			$t->assign("user",$user);
			$t->assign("event",$event);
			$body = $t->fetch('eventnotificationmail.tpl');

			// Create the mail object using the Mail::factory method
			$mail_object =& Mail::factory(MAIL_TYPE, $params);

			$mail_object->send($recipients, $headers, $body);
		}
	}

	function getdate_safe($timestamp)
	{	$date=array();
		$date["seconds"]=date("s",$timestamp);
		$date["minutes"]=date("i",$timestamp);
		$date["hours"]=date("H",$timestamp);
		$date["mday"]=date("j",$timestamp);
		$date["wday"]=date("w",$timestamp);
		$date["mon"]=date("m",$timestamp);
		$date["year"]=date("Y",$timestamp);
		$date["yday"]=date("z",$timestamp);
		$date["weekday"]=date("D",$timestamp);
		$date["month"]=date("F",$timestamp);
		return($date);
	}
?>
