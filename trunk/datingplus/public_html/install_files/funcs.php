<?php

define( 'DB_PREFIX', $_POST['dbPrefix'] );

function updateUsePageKey() {

    global $db;

    $items = $db->getAll( 'select id, resource_type, resource_id from '. DB_PREFIX.'_menu_items' );

    foreach( $items as $item ) {

        if ( $item[resource_type] == 'page' ) {

            // update menu-items to use page_id instead of page_key

            $page_key = $item[resource_id];

            if ( $page_key )
                $page_id = $db->getOne( 'select id from ' . DB_PREFIX."_pages" . " where page_key='$page_key'" );

            if ( $page_id ) {
                $db->query( 'update ' . DB_PREFIX.'_menu_items' . " set resource_id='$page_id' where id='$item[id]'" );
            }
        }


        if ( $item[resource_type] == 'form' ) {

            // update menu-items to use page_id instead of page_key

            $form_key = $item[resource_id];

            if ( $form_key )
                $form_id = $db->getOne( 'select resource_id from ' . DB_PREFIX."_settings" . " where resource_type='form' and property='form_key' and value='$form_key'" );

            if ( $form_id ) {
                $db->query( 'update ' . DB_PREFIX.'_menu_items' . " set resource_id='$form_id' where id='$item[id]'" );
            }
        }


    }

}


// upgrade to 2.1.x structure
function updateSettingsTable() {

	global $db;

	$db->setFetchMode( DB_FETCHMODE_ASSOC );

	$settings = $db->getAll( 'select * from '. DB_PREFIX."_settings" );

	foreach( $settings as $setting ) {

		if ( $setting['menu_id'] ) {
			$resourceType = 'menu';
			$resourceId = $setting['menu_id'];
			$param = $setting['param'];
		}
		else if ( $setting['skin_id'] ) {
			$resourceType = 'skin';
			$resourceId = $setting['skin_id'];
			$param = $setting['active'];
		}
		else if ( $setting['report_id'] ) {
			$resourceType = 'report';
			$resourceId = $setting['report_id'];
			$param = $setting['param'];
		}
		else {
			$resourceType = 'site';
			$resourceId = $setting[site_key];
			$param = $setting['param'];
		}

		$value = addslashes( $setting['value'] );

		$exists = $db->getOne( 'select id from '.DB_PREFIX."_settings where resource_type='$resourceType' and resource_id='$resourceId' and site_key='$setting[site_key]'" );

		if ( !$exists )
			$db->query( 'insert into '. DB_PREFIX."_settings ( resource_type, resource_id, site_key, property, value, param ) values ( '$resourceType', '$resourceId', '$setting[site_key]', '$setting[property]', '$value', '$param')" );

	}

	$db->query( 'delete from '.DB_PREFIX.'_settings where resource_type=\'\'' );

}


// upgrade to 2.1.x structure
function updateForms() {

	global $db;

	$db->setFetchMode( DB_FETCHMODE_ASSOC );

	include_once( DOC_ROOT . 'manage/settingsList.php' );

	$forms = $db->getAll( 'select * from '. DB_PREFIX.'_forms' );

	$replaceValues = array(
		'mail_to_address' => 'form_to',
		'copy_to' => 'form_cc',
		'mail_subject' => 'form_subject',
		'login_form' => 'login_form',
		'generate_report' => 'generate_report',
		'is_default' => 'is_default',
		'skin_id' => 'skin_id',
		'title' => 'form_title',
		'description' => 'form_desc',
	);

	foreach( $forms as $num=>$form ) {

		$site_data = $db->getRow( 'select default_resource_type, default_resource_id, login_form_id from '. DB_PREFIX."_sites where site_key='$form[site_key]'" );

		if ( $site_data['default_resource_type'] == 'form' && $site_data['default_resource_id'] == $form['id'] )
			$form['is_default'] = 'yes';
		else
			$form['is_default'] = 'no';

		if ( $site_data['login_form_id'] == $form['id'] )
			$form['login_form'] = 'yes';
		else
			$form['login_form'] = 'no';

		$form['generate_report'] = $form['generate_report'] == 1 ? 'yes' : 'no';


        foreach( $formSettings as $property=>$setting ) {

			if ( array_key_exists( $property, $replaceValues ) )
				$value = $form[$replaceValues[$property]];
			else
				$value = $setting[2];

            $exists = $db->getOne( 'select resource_id from '.DB_PREFIX."_settings where resource_type='form' and resource_id='{$form['id']}' and property='$property'" );

            if ( !$exists )
				$db->query( 'insert into '. DB_PREFIX."_settings ( site_key, resource_type, resource_id, property, value ) values ( '$form[site_key]', 'form', '$form[id]', '$property', '$value' )" );
        }
	}
}

function parseCreateSql( $sql ) {

    preg_match( '/create\s+table\s+[`]?(\w+)[`]?\s*\((.*)\)/is', $sql, $matches );
    $fields = split( ',', $matches[2] );
    $existingColumns = array();

    foreach( $fields as $num=>$f ) {

        $field .= $f;

        if ( substr_count( $field, '(' ) != substr_count( $field, ')' ) ) {
            $field .= ',';
            continue;
        }

        if ( preg_match( '/\s*[`]?(\w+)[`]?\s+(.*)/i', $field, $matches ) ) {

            if ( !preg_match( '/^\s*key/i', $matches[1]) && !preg_match( '/^\s*primary/i', $matches[1]) ) {
                $existingColumns[$matches[1]] = $matches[2];
            }
            else if ( preg_match( '/^\s*key\s+[`]?(\w+)[`]?\s+(.*)/i', $matches[0], $m) ) {
                $existingColumns['key'][$m[1]] = $m[2];
            }
            else if ( preg_match( '/^\s*primary\s+key\s+(.*)?/i', $matches[0], $m) ) {
                $existingColumns['primary key'] = $m[1];
            }
        }
        $field = '';
    }

    return $existingColumns;

}

function upgradeWithFile( $fileName ) {

    global $db, $t;

    @set_time_limit(6000);

    if ( $fd = @fopen ($fileName, 'r') ) {
        $data = @fread ($fd, filesize ($fileName));
        @fclose ($fd);
    } else {
         return false;
    }

    $tab = $db->getAll( 'show tables' );
    $tables = array();
    foreach( $tab as $num=>$tbl ) {
    	// skip flashchat tables (_fc_)
    	if (strpos($tbl[0],DB_PREFIX) !== false && !stristr($tbl[0],'_fc_')) {
	        $tables[$num]['name'] = $tbl[0];
	        $flds=$db->getAll("describe ".$tbl[0]);
			$fields=array();
	        foreach($flds as $nm=>$fld) {
				$fields[]=$fld[0];
	        }
			$tables[$num]['fields']=$fields;
			$db->query("rename table ".$tbl[0]." to ".$tbl[0]."_bkp");
		}
    }

    $queries = splitSql($data);

    foreach ($queries as $sql) {
        $sql = trim($sql);
        $sql = str_replace ( '[prefix]', DB_PREFIX, $sql );

		$result = $db->query( $sql );

        if ( $db->isError( $result ) )   return false;

    }


	$t->assign( 'systemInserted', executeFromFile( SYSTEM_FILE , 'insert' ) );

	$glbldata = $db->getAll("select * from !",array(DB_PREFIX."_glblsettings_bkp") );


	foreach ($glbldata as $glbldt) {

		$db->query("update ! set config_value=?, description=? where config_variable=?", array(DB_PREFIX."_glblsettings", $glbldt[1], $glbldt[2], $glbldt[0]) );
	}

	/* Now start copy of data into new tables */

	foreach($tables as $table) {
		
		if ($table['name'] != $dbprefix."_glblsettings") {
		
			/* First check if the table is available. Otherwise, this table is not related to osdate but given the osdate prefix. Need to recreate the table */
			
	        $flds=$db->query("describe ".$table['name']);
			if (DB::isError($flds) ) {

				/* Table not present. Recreate this table */
				$db->query("create table ".$table['name']. " as select * from ".$table['name']."_bkp where 1=1");			
			}
			
			$sql = "insert into ".$table['name']." (";

			$fields="";
			foreach($table['fields'] as $n=>$fld){
				if ($fields !='') $fields.=",";
				$fields.=$fld;
			}
			$sql .=$fields.") select ".$fields." from ".$table['name']."_bkp";
			$db->query($sql);
			$db->query("drop table ".$table['name']."_bkp");
		}
	}

	$db->query("update ".DB_PREFIX."_admin set password='".md5( ADMIN_PASSWORD )."' where username='admin'");

	$db->query("update phpbb_users set password='".md5( ADMIN_PASSWORD )."' where username='admin'");

	/* Now upgrade admin_permissions table with all enabled values */
	$db->query('delete from ! where username = ?', array(DB_PREFIX.'_admin_permissions', 'admin') );
	$db->query("INSERT INTO `".DB_PREFIX."_admin_permissions` (`id`, `adminid`, `site_stats`, `profie_approval`, `profile_mgt`, `section_mgt`, `affiliate_mgt`, `affiliate_stats`, `news_mgt`, `article_mgt`, `story_mgt`, `poll_mgt`, `search`, `ext_search`, `send_letter`, `pages_mgt`, `chat`, `chat_mgt`, `forum_mgt`, `mship_mgt`, `payment_mgt`, `banner_mgt`, `seo_mgt`, `admin_mgt`, `admin_permit_mgt`, `global_mgt`, `change_pwd`,`cntry_mgt`,`snaps_require_approval`,`featured_profiles_mgt`, `calendar_mgt`, `event_mgt`, `import_mgt`  ) VALUES (1, 1, '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1','1','1','1','1','1','1')");

    return true;
}

/**
* Executes sql queries from the file
* $mode - 'insert' or 'create', to know at what stage we are ...
*/
function executeFromFile( $fileName , $mode = 'insert' )
{
    global $db;

    @set_time_limit(1200);

    if ( $fd = @fopen ($fileName, 'r') ) {
        $data = @fread ($fd, filesize ($fileName));
        @fclose ($fd);
    } else {
         return false;
    }

    if (empty($data))
        return false;

    $queries = splitSql($data);

    foreach ($queries as $sql) {
        $sql = trim($sql);
        //echo $sql . "\n\n";

        if (empty($sql) || $sql[0] == '#')
            continue;

        $sql = str_replace ( '[prefix]', DB_PREFIX, $sql);

        if ( $mode == 'create' ) {
            $tbl = explode ( '`', $sql );
            $result = $db -> tableInfo ( $tbl[1] );

            if ( !$db->isError( $result ) ) {
                continue;
            }
        }

        /**
         ** Do these set of commands if we're in create mode and table doesn't exist
         ** AND, in insert mode or upgrade mode ..
         **/

        $result = $db->query( $sql );

        if ( $db->isError( $result ) ) {

            // debug
            // print_r( $result );


            if ( $result->code == -5 && $mode == 'insert' ) // -5 is duplication of record
                continue;
            else {
                return false;
            }
        }

    }
    return true;
}

function changeConfigVariable( $line, $name, $value )
{
	if (!( strpos ($line , $name) === FALSE) && preg_match ('/\s*define\s*\(\s*\'\s*'. $name .'\'\s*,/', $line)) {
		if ( $name == 'DEFAULT_LANG' ) {
			$out = 'define( \''. $name .'\', '. $value .' );'. "\n";
		}
		else {
			$out = 'define( \''. $name .'\', \''. $value .'\' );'. "\n";
		}
        return $out;
    }
    else
        return false;
}


function getConfigData( $replace )
{
    $line = file ( CONFIG_FILE );
    $s = '';

    foreach ( $line as $k => $v )
    {
        $replaced = 0;

        foreach ( $replace as $name=>$value ) {
            if ( $l = changeConfigVariable( $v, $name, $value) ) {
                $configData .= $l;
                $replaced = 1;
            }
        }
        if ( !$replaced )
            $configData .= $v;
    }
    return $configData;
}

function writeConfig( $configData )
{
    // Writing config file to the root directory
    $fp = @fopen( CONFIG_FILE, 'wb' );

    if ( $fp ) {
        fwrite( $fp, $configData );
        fclose( $fp );
        return true;
    }
    else
        return false;
}


//Forum Configuration changing

function f_changeConfigVariable( $line, $name, $value )
{
	if (!( strpos ($line , $name) === FALSE) ) {
			$out = '$'. $name .'= \''. $value .'\';'. "\n";
        return $out;
    }
    else
        return false;
}


function f_getConfigData( $replace )
{
    $line = file ( FORUM_CONFIG_FILE );
    $s = '';

    foreach ( $line as $k => $v )
    {
        $replaced = 0;

        foreach ( $replace as $name=>$value ) {
            if ( $l = f_changeConfigVariable( $v, $name, $value) ) {
                $configData .= $l;
                $replaced = 1;
            }
        }
        if ( !$replaced )
            $configData .= $v;
    }
    return $configData;
}

function f_writeConfig( $configData )
{
    // Writing config file to the root directory
    $fp = @fopen( FORUM_CONFIG_FILE, 'wb' );

    if ( $fp ) {
        fwrite( $fp, $configData );
        fclose( $fp );
        return true;
    }
    else
        return false;
}


function Message( $message, $good )
{
    if ( $good )
        $yesno = '<b><font color="green">Yes</font></b>';
    else
        $yesno = '<b><font color="red">No</font></b>';

    echo '<tr><td class="normal">'. $message .'</td><td>'. $yesno .'</td></tr>';
}

/**
 ** Check writeability of needed files and directories - used for step 1.
 **/

function isWriteable ( $canContinue, $file, $mode, $desc ) {
    @chmod( $file, $mode );
    $good = is_writable( $file ) ? 1 : 0;
    Message ( $desc.' is writable: ', $good );
    return ( $canContinue && $good );
}

function FTPerrhndl ( $error ) {
    global $FTPerr;

    if ( !$FTPerr ) {
        $FTPerr = true;
        $errmsg = $error;
        include 'step1.5.tpl';
    }
}

function errhndl ( $err ) {

    switch( $err->code ) {
        case -24:
            $msg = 'There was an error connecting to the database, please make sure it is running and that your login settings are correct.';
            break;

        default:
            $msg = 'The installer generated error code: ' . $err->code;
            break;
    }
    echo '<tr><td colspan=2 valign=top>';
    echo "<font face=Arial><h2>Unexpected Error</h2><font face=Arial size=2>$msg<br /><br /></font>

    Detailed error: ".$err->message."</td></tr></table>";

    die();
}

function CopyFiles($fromdir, $todir, $recursed = 1 ) {
	if ($fromdir == "" or !is_dir($fromdir)) {
		echo ('Invalid directory');
		return false;
	}
	if ($todir == "") {
		echo('Output Directory name is missing');
		return false;
	}

	if (!file_exists($todir)) {
		mkdir($todir);
	}

	$filelist = array();
	$dir = opendir($fromdir);

	while($file = readdir($dir)) {
		if($file == "." || $file == ".." || $file=='Thumbs.db' || $file == 'readme.txt') {
			continue;
		} elseif (is_dir($fromdir."/".$file)) {
			if ($recursed == 1) {
				$temp = CopyFiles($fromdir."/".$file, $todir."/".$file, $recursed);
			}
		} elseif (file_exists($fromdir."/".$file)) {
			/* copy($fromdir."/".$file, $todir.$file); */
			/* Trying to overcome the issue of installation on some systems
			   where copy command may be issuing some unwanted checks.  */
			$data = file_get_contents($fromdir."/".$file);
			$fout = fopen($todir."/".$file, 'wb');
			$fx = fwrite($fout, $data);
			fclose($fout);
		}
	}

	closedir($dir);
	return true;
}

/*	Modified by Vijay Nair to forcibly create tables and copy data from bkp table

		if ( ($tableIdx = array_search( $table, $tables )) === false ) {

            // create table
            $result = $db->query( $sql );

            if ( $db->isError( $result ) )
                return false;
        }
        else {

            // update or add fields

            $r = $db->query( 'show create table '. $tables[$tableIdx] );
            $r = $r->fetchRow();

            $existingColumns = parseCreateSql( $r[1] );

            $newColumns = parseCreateSql( $sql );

            // -------------
            // update fields
            // -------------

            foreach ( $newColumns as $name=>$value ) {

                // skip indexes as primary keys because we already updates them
                if ( $name != 'key' && $name != 'primary key' ) {

                    if ( !@in_array( $name, @array_keys( $existingColumns ) ) ) {

                        // new field, add it

                        $result = $db->query( 'alter table '.$tables[$tableIdx]." add `$name` $value" );
                        if ( $db->isError( $result ) ) {
                            return false;
                        }

                    }
                    else if ( $existingColumns[$name] != $newColumns[$name] ) {
                        $result = $db->query( 'alter table '.$tables[$tableIdx]." change `$name` `$name` $value" );
                        if ( $db->isError( $result ) ) {
                            return false;
                        }
                    }
                }
            }



            // -------------------
            // update primary keys
            // -------------------

            if ( ($existingColumns['primary key'] != $newColumns['primary key']) && $newColumns['primary key'] ) {
                $result = $db->query( 'alter table '.$tables[$tableIdx].' drop primary key, add primary key '. $newColumns['primary key'] );
                if ( $db->isError( $result ) )
                    return false;
            }


            // ----------------------------------------------------------
            // update indexes
            // delete all keys from 'existingColumns' and create new ones
            // ----------------------------------------------------------

            if ( is_array( $newColumns['key']) && count( $newColumns['key'] ) )
            foreach ( $newColumns['key'] as $keyName=>$keyValue ) {

                if ( !@in_array( $keyName, @array_keys( $existingColumns['key'] ) ) ) {

                    // add a new key

                    $result = $db->query( 'alter table '.$tables[$tableIdx].' add index '. $keyValue );
                    if ( $db->isError( $result ) ) {
                        return false;
                    }

                }
                else if ( $newColums['key'][$keyName] != $existingColumns[$keyName] ) {

                    // change existing key
                    $result = $db->query( 'alter table '.$tables[$tableIdx].' drop index '.$keyName.', add index '. $keyValue );
                    if ( $db->isError( $result ) ) {
                        return false;
                    }
                }
            }
        }
 */


?>