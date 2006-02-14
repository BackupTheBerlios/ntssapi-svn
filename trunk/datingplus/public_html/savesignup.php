<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$_SESSION['firstname'] = $firstname = trim($_POST[ 'txtfirstname' ]);

$_SESSION['lastname'] = $lastname = trim($_POST[ 'txtlastname' ]);

$_SESSION['username'] = $username = trim($_POST[ 'txtusername' ]);

$password = trim($_POST[ 'txtpassword' ]);

$password2 = trim($_POST[ 'txtpassword2' ]);

$_SESSION['password'] = $password;

$_SESSION['password2'] = $password2;

$_SESSION['email'] = $email = trim($_POST[ 'txtemail' ]);

$_SESSION['gender'] = $gender = trim($_POST[ 'txtgender' ]);

$birthmonth = trim($_POST[ 'txtbirthMonth' ]);

$birthday = trim($_POST[ 'txtbirthDay' ]);

$birthyear = trim($_POST[ 'txtbirthYear' ]);

$_SESSION['selectedtime'] = $birthdate = strtotime($birthyear.'-'.$birthmonth.'-'.$birthday);

$_SESSION['timezone'] = $timezone = trim($_POST[ 'txttimezone' ]);

$_SESSION['lookgender'] = $lookgender = trim($_POST[ 'txtlookgender' ]);

$_SESSION['txtlookagestart'] = $lookagestart = trim($_POST[ 'txtlookagestart' ]);

$_SESSION['txtlookageend'] = $lookageend = trim($_POST[ 'txtlookageend' ]);

$_SESSION['from'] = $from = trim($_POST[ 'txtfrom' ]);

$_SESSION['address1'] = $address1 = trim($_POST['txtaddress1' ]);

$_SESSION['address2'] = $address2 = trim($_POST['txtaddress2' ]);

$_SESSION['stateprovince'] = $stateprovince = trim($_POST[ 'txtstateprovince' ]);

$_SESSION['countycode'] = $county = trim($_POST[ 'txtcounty' ]);

$_SESSION['citycode'] = $city = trim($_POST[ 'txtcity' ]);

$_SESSION['zip'] = $zip = trim($_POST[ 'txtzip' ]);

$_SESSION['lookfrom'] = $lookfrom = trim($_POST[ 'txtlookfrom' ]);

$_SESSION['lookstateprovince'] = $lookstateprovince = trim($_POST[ 'txtlookstateprovince' ]);

$_SESSION['lookcounty'] = $lookcounty = trim($_POST[ 'txtlookcounty' ]);

$_SESSION['lookcity'] = $lookcity = trim($_POST[ 'txtlookcity' ]);

$_SESSION['lookzip'] = $lookzip = trim($_POST[ 'txtlookzip' ]);

$_SESSION['viewonline'] = $viewonline = trim($_POST[ 'txtviewonline' ]);

if (  $_POST['chgcntry'] == '1'   ) {

	header ( "Location:signup.php" );
	exit();

}

//Check for duplicate user
$sqlc = 'SELECT count(*) as aacount from ! where username = ?';

$rowc = $db->getRow( $sqlc, array( USER_TABLE, $username ) );

$rowd = $db->getRow( $sqlc, array( ADMIN_TABLE, $username )  );

$rowf = $db->getRow( $sqlc, array( 'phpbb_users', $username )  );

//Check for duplicate email
$sqle = "SELECT count(*) as aacount from ! where email = ?";


$rowe = $db->getRow( $sqle, array( USER_TABLE, $email ) );

$err =0;


if ( $rowc['aacount'] > 0  or $rowd['aacount'] > 0 or $rowf['aacount'] > 0 ) {

	$err = USERNAME_EXISTS;

} elseif ( $rowe['aacount'] > 0 ) {

	$err = EMAIL_EXISTS;

// nickpage START
} elseif ( !preg_match('/^[a-zA-Z0-9\-_]+$/', $_SESSION['username']) ) {
	$err = NICKPAGE_USERNAME;
// nickpage END

} elseif ( ! checkdate( $birthmonth, $birthday, $birthyear ) ) {

	$err = INVALID_BIRTHDATE;

} elseif ( $firstname == '' ) {

	$err = FIRSTNAME_REQUIRED;

} elseif ( $lastname == '' ) {

	$err = LASTNAME_REQUIRED;

} elseif ( $email == '' ) {

	$err = EMAIL_REQUIRED;

} elseif ( $stateprovince == '' && $config['state_mandatory'] == 'Y') {

	$err = STATEPROVINCE_NEEDED;

} elseif ( $county == ''  && $config['county_mandatory'] == 'Y') {

	$err = COUNTY_REQUIRED;

} elseif ( $city == ''  && $config['city_mandatory'] == 'Y') {

	$err = CITY_REQUIRED;

} elseif ( $zip == ''  && $config['zipcode_mandatory'] == 'Y') {

	$err = ZIP_REQUIRED;

} elseif ( strlen( $firstname ) > 50 ) {

	$err = FIRSTNAME_LENGTH;

} elseif ( strlen( $lastname ) > 50 ) {

	$err = LASTNAME_LENGTH;

} elseif ( strlen( $email ) > 255 ) {

	$err = EMAIL_LENGTH;

} elseif ( strlen( $city ) > 255 ) {

	$err = CITY_LENGTH;

} elseif ( $lookageend < $lookagestart ) {

	$err = BIGGER_STARTAGE;

} elseif ($timezone == '-25' ) {

	$err = INVALID_TIMEZONE;
}

if (  $err > 0 ) {

	header ( "Location:signup.php?errid=$err" );
	exit();
}

$active =  0;

$lastvisit = $regdate = time();

$level = ($config['default_user_level']!='')? $config['default_user_level']:4;

$activedays = $db->getOne('select activedays from ! where roleid = ?', array( MEMBERSHIP_TABLE, $level ) );

$levelend = strtotime("+$activedays day",time());

$rank = 1;

$actkey = md5( $email . time() );

$status =  $lang['status_enum']['approval'] ;

$pwd = md5( $password );

$sqlins = "INSERT INTO !
				(
				active,
				username,
				password,
				lastvisit,
				regdate,
				level,
				timezone,
				allow_viewonline,
				rank,
				email,
				country,
				actkey,
				firstname,
				lastname,
				gender,
				lookgender,
				lookagestart,
				lookageend,
				lookcountry,
				address_line1,
				address_line2,
				state_province,
				county,
				city,
				zip,
				lookstate_province,
				lookcounty,
				lookcity,
				lookzip,
				birth_date,
				status,
				levelend)
		 VALUES (  ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

//Insert record
$result = $db->query ( $sqlins, array( USER_TABLE, $active, $username, $pwd, $lastvisit, $regdate, $level, $timezone, $viewonline, $rank, $email, $from, $actkey, $firstname, $lastname, $gender, $lookgender, $lookagestart, $lookageend, $lookfrom, $address1, $address2, $stateprovince, $county, $city, $zip, $lookstateprovince, $lookcounty, $lookcity, $lookzip, date("Y-m-d",$birthdate), $status,  $levelend ) );

$lastid = getLastId( USER_TABLE );

//Store the id in session
$_SESSION['TempUserId'] = $lastid;

//Create user in phpbb
if ( $config['phpbb_installed'] == 'Y' ) {

	$userid = $db->getOne('select max(user_id)+1 from !', array( 'phpbb_users' ) );

	$sql = "INSERT INTO ! ( user_id, username, user_password, user_email, user_regdate ) VALUES ( ?, ?, ?, ?,? )";

	$db->query( $sql, array( 'phpbb_users', $userid, $username, $pwd, $email, time() ) );
}

//update referals
if ( $_SESSION['ReferalId'] ) {

	$sql = "INSERT INTO ! (  affid, userid ) VALUES (  ?, ? )";

	$db->query( $sql, array( AFFILIATE_REFERALS_TABLE, $_SESSION['ReferalId'], $lastid ));

}


$sql = 'SELECT subject, bodytext FROM ! WHERE id = ?';

$rowletter = $db->getRow( $sql, array( ADMIN_LETTER_TABLE, '1' ));

if ( $rowletter ) {

	$header['Subject'] = $rowletter['subject']. ' ' . $lang['site_name'];

	$header['From'] = $config['admin_email'];

	$header['To'] = $firstname.' '.$lastname.'<'.$email.'>';

	$body = $rowletter['bodytext'];

	$name = $firstname ;

	$body = str_replace( '#Name#',  $name , $body );

	$body = str_replace( '#SiteName#',  SITENAME , $body );

	$body = str_replace( '#ConfCode#',  $actkey , $body );

	$link = 'http://' . $_SERVER['SERVER_NAME'] . DOC_ROOT . 'completereg.php?confcode';

	$body = str_replace( '#ConfirmationLink#',  $link , $body );

	$body = str_replace( '#StrID#',  $username , $body );

	$body = str_replace( '#Email#',  $email , $body );

	$body = str_replace( '#Password#',  $password , $body );


	//Send password in mail
	$mail =& Mail::factory( MAIL_TYPE, $params );

	$mail->send( $email, $header, $body );

	header( 'location:confirmreg.php' );

	exit;

}

?>