<?php

import_request_variables( 'p' );
// $name =  strtolower( $name );

if ( $dbType == 'mysql' ) { /** This check for database feature is only available for mysql. **/

	$dsn = $dbType . '://' . $user . ':' . $password . '@' . $host . '/';
	$db = @DB::connect( $dsn );


	if ( DB::isError($db) ) {
		if ( $db->code == -24 ) {
			$t->assign( 'errorLogin', 1 );
		} else if ( $db->code == -9 ) {
			$t->assign( 'errorDB', 1 );
		}
		include 'step_2.php';
		return;
	}

	$result = $db->getAll( "show databases;" );

	// check if we have rights

	if ( !DB::isError( $result ) ) {

		foreach ( $result as $index => $dbarray ) {

			$dbname = $dbarray[0];

			if ( $name == $dbname ) {
				$db_valid = true;
				break;
			}
		}
	} else {

		// if no rights - assume user entered valid db name
		// if not - this will be found in the next lines

		$db_valid = true;
	}
}

if ( $dbType != 'mysql' || $db_valid != false ) {

	$dsn = $dbType . '://' . $user . ':' . $password . '@' . $host . '/' . $name;
	$db = @DB::connect( $dsn );

} else {
	$t->assign( 'errorDBname', $result );
		include 'step_2.php';
		return;
}

if ($admin_password == '') {$admin_password = 'pass';}

define ('ADMIN_PASSWORD', $admin_password);

if ( DB::isError($db) ) {
	if ( $db->code == -24 ) {
		$t->assign( 'errorLogin', 1 );
	} else if ( $db->code == -9 ) {
		$t->assign( 'errorDB', 1 );
	}
	include 'step_2.php';
	return;
}

// Replacing config variables
$replace = array(
	'DB_USER'	=> $user,
	'DB_NAME'	=> $name,
	'DB_HOST'	=> $host,
	'DB_PASS'	=> $password,
	'DB_TYPE'	=> $dbType,
	'DB_PREFIX' => $dbPrefix,
	'DOC_ROOT' 	=> $docroot,
	'OSDATE_INSTALLED' => 1,
	'DEFAULT_LANG' => "'".str_replace('lang_','',$_REQUEST['langType'])."'",
	'DEFAULT_COUNTRY' => $countryType
);

$configData = getConfigData( $replace );
$configCreated = writeConfig( $configData );

// Replacing forum config variables
$f_replace = array(
	'dbuser'	=> $user,
	'dbname'	=> $name,
	'dbhost'	=> $host,
	'dbpasswd'	=> $password,
	'dbms'	=> $dbType,
);

$configData = f_getConfigData( $f_replace );
$configCreated = f_writeConfig( $configData );

$t->assign( 'upgrade', $upgrade );

if ( $install_type == 'upgrade' ) {

	// do upgrade here
	$t->assign( 'upgrade', 1 );

	$succ = upgradeWithFile( SQL_FILE );

	$t->assign( 'upgradeSuccessful', $succ );

} else {

	// Creating tables
	$t->assign( 'tablesCreated', executeFromFile( SQL_FILE , 'create' ) );
	$t->assign( 'tablesCreated', executeFromFile( PHPBB_FILE , 'create' ) );
	@ini_set("max_execution_time","1200");
	$t->assign( 'systemInserted', executeFromFile( SYSTEM_FILE, 'insert' ) );
	$t->assign( 'sampleInserted', executeFromFile( SAMPLE_FILE , 'insert' ) );

	$db->query( "INSERT INTO ".$dbPrefix."_admin (id, username, password, fullname, lastvisit, super_user, enabled) VALUES (1, 'admin', '".md5( ADMIN_PASSWORD )."', 'Administrator', 1124441296, 'Y', 'Y')" );

	//Update forum configuration

	$sql = "UPDATE phpbb_config SET config_value='" . $_SERVER['SERVER_NAME'] . "' WHERE config_name='server_name'";

	$db->query( $sql );

	$forumroot = addslashes( $docroot . 'forum/' );

	$sql = "UPDATE phpbb_config SET config_value='$forumroot' WHERE config_name='script_path'";

	$db->query( $sql );

	$db->query("update phpbb_users set user_password='".md5( ADMIN_PASSWORD )."' where username='admin'");

	// install modules

	// add this later, when some modules are ready. :)
}

$t->assign( 'configCreated', $configCreated );

/* Copy files from default_blue to current */

CopyFiles(TEMPLATES_DIR."default-blue/", TEMPLATES_DIR."current/");

$t->display( 'pages/install2.tpl' );

$db->disconnect();

?>