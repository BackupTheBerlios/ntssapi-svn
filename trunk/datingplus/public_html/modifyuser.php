<?php
if ( !defined( 'SMARTY_DIR' ) ) {

	include_once( 'init.php' );
}
include( 'sessioninc.php' );

$userid = $_SESSION['UserId'];

$modified['username'] = $username = $_POST['txtusername'] ;

$modified['firstname'] = $firstname = trim($_POST[ 'txtfirstname' ]);

$modified['lastname'] = $lastname = trim($_POST[ 'txtlastname' ]);		

$modified['email'] = $email = trim($_POST[ 'txtemail' ]);

$modified['gender'] = $gender = $_POST[ 'txtgender' ];

$modified['birthmonth'] = $birthmonth = $_POST[ 'txtbirthMonth' ];

$modified['birthday'] = $birthday = $_POST[ 'txtbirthDay' ];

$modified['birthyear'] = $birthyear = $_POST[ 'txtbirthYear' ];

$modified['birth_date'] = strtotime($birthyear.'-'.$birthmonth.'-'.$birthday);

$modified['country'] = $from = $_POST[ 'txtfrom' ];

$modified['county'] = $county = $_POST[ 'txtcounty' ];

$modified['zip'] = $zip = trim($_POST[ 'txtzip' ]);

$modified['timezone'] = $timezone = $_POST['txttimezone'];

$modified['lookgender'] = $lookgender = $_POST[ 'txtlookgender' ];

$modified['lookagestart'] = $lookagestart = $_POST[ 'txtlookagestart' ];

$modified['lookageend'] = $lookageend = $_POST[ 'txtlookageend' ];

$modified['city'] = $city = trim($_POST[ 'txtcity' ]);
	
$modified['state_province'] = $stateprovince = trim($_POST[ 'txtstateprovince' ]);

$modified['address1'] = $address1 = trim($_POST['txtaddress1' ]);

$modified['address2'] = $address2 = trim($_POST['txtaddress2' ]);		

$modified['lookcountry'] = $lookfrom = $_POST[ 'txtlookfrom' ];

$modified['lookcounty'] = $lookcounty = $_POST[ 'txtlookcounty' ];

$modified['lookcity'] = $lookcity = trim($_POST[ 'txtlookcity' ]);
	
$modified['lookstate_province'] = $lookstateprovince = trim($_POST[ 'txtlookstateprovince' ]);

$modified['lookzip'] = $lookzip = trim($_POST[ 'txtlookzip' ]);		

$modified['allow_viewonline'] = $viewonline = $_POST[ 'txtviewonline' ];

if ($_POST['chgcntry'] == '1') {

	$_SESSION['lookstateprovince'] = '';
	
	$_SESSION['modifiedrow'] = $modified;

	header ( "Location:edituser.php" );
	
	exit();

}
	
	
$err =0;

if ( $firstname == '' ) {

	$err = FIRSTNAME_REQUIRED;

} elseif ( $lastname == '' ) {

	$err = LASTNAME_REQUIRED;

} elseif ( $email == '' ) {

	$err = EMAIL_REQUIRED;

} elseif ( $city == '' && $config['city_mandatory'] == 'Y') {

	$err = CITY_REQUIRED;

} elseif ( $zip == '' && $config['zip_mandatory'] == 'Y') {

	$err = ZIP_REQUIRED;

} elseif ( strlen( $firstname ) > 50 ) {

	$err = FIRSTNAME_LENGTH;

} elseif ( strlen( $lastname ) > 25 ) {

	$err = LASTNAME_LENGTH;

} elseif ( strlen( $email ) > 255 ) {

	$err = EMAIL_LENGTH;

} elseif ( strlen( $city ) > 255 ) {

	$err = CITY_LENGTH;

} elseif ( $lookageend < $lookagestart ) {

	$err = BIGGER_STARTAGE;

} elseif ( ! checkdate( $birthmonth, $birthday, $birthyear ) ) {

	$err = INVALID_BIRTHDATE;

} elseif ($timezone == '-25' ) {

	$err = INVALID_TIMEZONE;

}

$_SESSION['modifiedrow'] = $modified;

if (  $err != 0 ) {

	header ( "Location:edituser.php?errid=$err" );
	
	exit();

}
		
//	$birthdate = strtotime ( $birthday . ' ' . $birthmonth . ' ' . $birthyear );
$birthdate = $birthyear . '-' . $birthmonth . '-' . $birthday;

$sqlins = "UPDATE ! SET
					allow_viewonline 	= '$viewonline',
					email 				= '$email',
					country 			= '$from',
					firstname 			= '".addslashes($firstname)."',
					lastname 			= '".addslashes($lastname)."',	
					gender 				= '$gender',
					lookgender 			= '$lookgender',
					lookagestart 		= '$lookagestart',
					lookageend 			= '$lookageend',
					lookcountry 		= '$lookfrom',
					address_line1 		= '".addslashes($address1)."',
					address_line2 		= '".addslashes($address2)."',	
					state_province 		= '".addslashes($stateprovince)."',
					county 				= '".addslashes($county)."',
					city 				= '".addslashes($city)."',
					zip 				= '".addslashes($zip)."',
					timezone 			= '$timezone',
					lookzip				= '".addslashes($lookzip)."',
					lookcity 			= '".addslashes($lookcity)."',
					lookcounty 			= '".addslashes($lookcounty)."',
					lookstate_province 	= '".addslashes($lookstateprovince) . "',	
					birth_date = '$birthdate' WHERE id=?";
			
$result = $db->query( $sqlins, array( USER_TABLE, $userid ) );

$sql = 'SELECT id FROM ! WHERE enabled = ? ORDER BY 
	displayorder ASC LIMIT 0, 1';

$_SESSION['modifiedrow'] = '';

$ow = $db->getRow( $sql, array( SECTIONS_TABLE, 'Y' ) );

$_SESSION['FullName'] = $firstname . ' ' . $lastname;

header( 'Location:editquestions.php?sectionid=1' );

?>