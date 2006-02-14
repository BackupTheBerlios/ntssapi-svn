<?php

global $t;

// type list
$typeValues = array( 'mysql', 'pgsql', 'ibase', 'msql', 'mssql', 'oci8', 'odbc', 'sybase', 'ifx', 'fbsql');

$typeNames  = array(  	'MySQL',
						'PostgreSQL',
						'InterBase',
						'Mini SQL',
						'Microsoft SQL Server',
						'Oracle 7/8/8i',
						'ODBC (Open Database Connectivity)',
						'SyBase',
						'Informix',
						'FrontBase'
					);

// defaults
$langType = 'lang_english';
$langtypeValues = array( 'lang_english','lang_german','lang_dutch','lang_spanish','lang_russian','lang_french');
$langtypeNames  = array( 'English', 'German', 'Dutch', 'Spanish', 'Russian', 'French' );
$countryType = 'US';

include( 'countries.php' );

// REQUEST_URI env. var. not available in Apache
$request = $_SERVER['PHP_SELF'];

if ( strlen( $_SERVER[QUERY_STRING] ) > 0 ) {
	$request .= '?' . $_SERVER[QUERY_STRING];
}

$docroot = ( preg_match( '/\/(.+)\/.*/', $request, $matches ) ) ? '/'. $matches[1] .'/' : '/';

$t->assign( 'docroot', $docroot );
$t->assign( 'host', 'localhost' );
$t->assign( 'dbPrefix' , 'osdate' );
$t->assign( 'typeValues', $typeValues );
$t->assign( 'typeNames', $typeNames );
$t->assign( 'langtypeValues', $langtypeValues );
$t->assign( 'langtypeNames', $langtypeNames );
$t->assign( 'langType', $langType );
$t->assign( 'countrytypeValues', $countrytypeValues );
$t->assign( 'countrytypeNames', $countrytypeNames );
$t->assign( 'countryType', $countryType );


if ( isset($user) ) { /** Already posted. **/
	$t->assign ( 'user' , $user );
	$t->assign ( 'host' , $host );
	$t->assign ( 'password' , $password );
	$t->assign ( 'name' , $_POST['name'] );
	$t->assign ( 'countryType', $_POST['countryType'] );

	$t->assign ( 'dbType' , $dbType );
	$t->assign ( 'dbPrefix' , $dbPrefix );
}

// fix this later
//$t->assign( 'version', $version );

$t->display( 'pages/install.tpl' );

?>