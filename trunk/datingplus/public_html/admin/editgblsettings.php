<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

// include ( '../includes/internal/Functions.php');

define( 'PAGE_ID', 'global_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$mships = $db->getAll('select roleid, name from ! ', array(MEMBERSHIP_TABLE) );

$memberships = array();

foreach ($mships as $row ) {
	$memberships[$row['roleid']] = $row['name'];
}

$t->assign('memberships', $memberships);


if ( $_POST['frm'] == 'frmEditConfig' ) {

	$sql = 'UPDATE ! SET config_value = ? WHERE config_variable = ?';

	$rs = $db->query( $sql, array( CONFIG_TABLE, trim( $_POST['txtconfigvalue'] ), trim( $_POST['txtconfigvariable'] ) ) );

	if ($_POST['txtconfigvariable'] == 'skin_name' ) {

		// Change in template. Copy the files to the curent directory */

		CopyFiles(TEMPLATE_DIR."default-blue/", TEMPLATE_DIR."current/");
		CopyFiles(TEMPLATE_DIR.$_POST['txtconfigvalue']."/", TEMPLATE_DIR."current/");

		/* Remove files from templates_c directory */

		if ( $handle = opendir( TEMPLATE_C_DIR ) ) {
			while ( false !== ( $file = readdir( $handle ) ) ) {
				if ( $file != '.' && $file != '..'  ) {
					unlink( TEMPLATE_C_DIR . $file );
				}
			}
			closedir($handle);
		}
	}
	header( 'location: editgblsettings.php?' . rand(10000,0) );
	exit;
}

$sql = 'SELECT config_variable, config_value, description FROM ! WHERE config_variable <> ?';

$rs = $db->getAll( $sql, array( CONFIG_TABLE, 'enable_mod_rewrite' ) );

$confdata = array();

foreach ( $rs as $row ) {
	$row['config_value'] = htmlspecialchars( $row['config_value'] );
	$confdata[] = $row;
}

$t->assign ( 'confdata', $confdata );

$temp_dirs = array();

if ( $handle = opendir( TEMPLATE_DIR ) ) {

    while (false !== ( $file = readdir( $handle ) ) ) {

		if ( $file != '.' && $file != '..'  && $file != 'pages' && $file != 'current') {

			if ( is_dir( TEMPLATE_DIR . $file ) ) {

				$temp_dirs[$file] = $file;

			}
		}
    }

    closedir($handle);
}

$t->assign ( 'template_dirs', $temp_dirs );

$t->assign('rendered_page', $t->fetch('admin/editgblsettings.tpl'));

$t->display( 'admin/index.tpl' );

$db->disconnect();
?>