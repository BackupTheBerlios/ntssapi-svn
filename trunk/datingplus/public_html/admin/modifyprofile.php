<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}	

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'profile_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$userid = $_POST[ 'txtuserid' ];

$modified['username'] = $username = trim($_POST[ 'txtusername' ]);

$modified['firstname'] = $firstname = trim($_POST[ 'txtfirstname' ]);

$modified['lastname'] = $lastname = trim($_POST[ 'txtlastname' ]);		

$modified['email'] = $email = trim($_POST[ 'txtemail' ]);

$modified['gender'] = $gender = $_POST[ 'txtgender' ];

$modified['birthmonth'] = $birthmonth = $_POST[ 'txtbirthMonth' ];

$modified['birthday'] = $birthday = $_POST[ 'txtbirthDay' ];

$modified['birthyear'] = $birthyear = $_POST[ 'txtbirthYear' ];

$modified['birth_date'] = strtotime($birthyear.'-'.$birthmonth.'-'.$birthday);

$modified['country'] = $from = $_POST[ 'txtfrom' ];

$modified['zip'] = $zip = trim($_POST[ 'txtzip' ]);

$modified['timezone'] = $timezone = $_POST['txttimezone'];

$modified['city'] = $city = trim($_POST[ 'txtcity' ]);
	
$modified['county'] = $county = trim($_POST[ 'txtcounty' ]);

$modified['state_province'] = $state_province = trim($_POST[ 'txtstateprovince' ]);

$modified['address1'] = $address1 = trim($_POST['txtaddress1' ]);

$modified['address2'] = $address2 = trim($_POST['txtaddress2' ]);		

$modified['viewonline'] = $viewonline = $_POST[ 'txtviewonline' ];

$modified['mlevel'] = $mlevel = $_POST['txtmship'];

$modified['levelend'] = $levelend = $_POST['txtlevelend'];

$_SESSION['modifiedrow'] = $modified;

if ($_POST['chgcntry'] == '1' ) {

	header ( "Location:profile.php?edit=$userid" );
	exit();

}

//Check for duplicate user
$sqlc = 'SELECT count(*) as aacount from !  where username = ? and id <>?';

$row = $db->getRow( $sqlc, array( USER_TABLE, $username, $userid ) );

$sqld = "SELECT count(*) as aacount from ! where username = ?";

$rowd = $db->getRow ( $sqld, array( ADMIN_TABLE, $username) );

$sqle = "SELECT count(*) as aacount from ! where email = ? and id <>?";

$rowe = $db->getRow ( $sqle, array( USER_TABLE, $email, $userid) );
	
$err =0;

if ( $username == '' ) {

	$err = USERNAME_BLANK;
	
} elseif ( $firstname == '' ) {

	$err = FIRSTNAME_REQUIRED;
	
} elseif ( $lastname == '' ) {

	$err = LASTNAME_REQUIRED;
	
} elseif ( $email == '' ) {

	$err = EMAIL_REQUIRED;
	
} elseif ( $city == '' && $config['city_mandatory'] == 'Y') {

	$err = CITY_REQUIRED;
	
} elseif ( $zip == '' && $config['city_mandatory'] == 'Y') {

	$err = ZIP_REQUIRED;
	
} elseif ( strlen( $firstname ) > 50 ) {

	$err = FIRSTNAME_LENGTH;
	
} elseif ( strlen( $lastname ) > 25 ) {

	$err = LASTNAME_LENGTH;
	
} elseif ( strlen( $email ) > 255 ) {

	$err = EMAIL_LENGTH;
	
} elseif ( strlen( $city ) > 255 ) {

	$err = CITY_LENGTH;
	
} elseif ( $row['aacount'] > 0 ) {

	$err = USERNAME_EXISTS;
} elseif ( $rowd['aacount'] > 0 ) {

	$err = USERNAME_EXISTS;
	
} elseif ( $rowe['aacount'] > 0 ) {

	$err = EMAIL_EXISTS;
	
} elseif ( ! checkdate( $birthmonth, $birthday, $birthyear ) ) {

	$err = INVALID_BIRTHDATE;
	
}

if (  $err != 0 ) {

	header ( "Location:profile.php?edit=$userid&errid=$err" );
	exit();
	
}
	
$active = $rank = 1;

$birthdate = $birthyear . '-' . $birthmonth . '-' . $birthday;

$act_days = $db->getOne('select activedays from ! where roleid = ?', array( MEMBERSHIP_TABLE, $mlevel) );
			
$curlevel = $db->getAll('select level, levelend from ! where id = ?', array( USER_TABLE, $userid ) );

if ($curlevel['level'] != $mlevel) {

	$levelend = ($curlevel['levelend'] != '') ? $curlevel['levelend']: time();
	
	$levelend = strtotime("+$act_days day", $levelend);
}

$sqlins = 'UPDATE !' .  " SET
				username			=  '$username',
				active 				=	 '$active',
				allow_viewonline 	= '$viewonline',
				email 				= '$email',
				country 			= '$from',
				firstname 			= '".addslashes($firstname)."',
				lastname 			= '".addslashes($lastname)."',
				gender 				= '$gender',
				timezone			= '$timezone',
				address_line1 		= '".addslashes($address1)."',
				address_line2 		= '".addslashes($address2)."',
				state_province 		= '".addslashes($state_province)."',
				city 				= '".addslashes($city)."',
				zip 				= '".addslashes($zip)."',
				county 				= '".addslashes($county)."',
				birth_date 			= '$birthdate',
				levelend			= '$levelend',
				level = '$mlevel' 
				 WHERE id = ?";

$_SESSION['modifiedrow'] = '';

$result = $db->query( $sqlins, array( USER_TABLE, $userid ) );

header( 'Location:profile.php?edit=' . $userid );
?>