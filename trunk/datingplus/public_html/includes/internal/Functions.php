<?php

/**
Generic PHP functions. Please only put general-use PHP functions
in this file. Feature-specific functions should be kept local to
the particular feature.
*/



/**
 * Builds an associative array from an $array columns $key and $value
 */
function getAssocArray( $key, $value, $array ) {

    $assocArray = array ();

    $arrayCount = count ($array);

    for ($i = 0; $i < $arrayCount; $i++) {
        $assocArray[$array[$i][$key]] = $array[$i][$value];
    }

    return $assocArray;
}

/**
 * Display any polls for the given user id. If $uid = false, then display any
 * polls being shown to all users.
 */
function displayPolls() {
	global $db, $t, $site;

	if ( !$uid )
		$uid = '0';

	//print_r( $_SESSION );

	$group = $_SESSION['es_auth']['group_id'];

	$activePolls = $db->getAll( 'select * from ! where site_key = ? and active = ?', array(POLLS_TABLE, $site, '1') );

	//print_r( $activePolls );

	// for each available active poll, check to see if it has been displayed to the users

	$newActivePolls = array();

	$userip = $_SERVER['REMOTE_ADDR'];

	foreach( $activePolls as $index => $row ) {

		// check user authentication to view this poll

		if ( ( $_SESSION['es_auth']['group_id'] > 0 && $row[group_id] == 'auth' )
			|| $_SESSION['es_auth']['group_id'] == $row[group_id]
			|| $row[group_id] == 'all' ) {

			$pollViewed = $db->getOne( 'select id from ! where poll_id = ? and site_key = ? and user_ip = ?', array(POLLRESULTS_TABLE, $row[id], $site, $userip) );


			if ( !$pollViewed ) {
				$newActivePolls [] = $row;
			}
		}
	}

	//print_r( $newActivePolls );

	// poll popup code will be displayed in default.tpl
	$t->assign( 'activePolls', $newActivePolls );
}

/**
 * Determines the login form ID, and generates an internal path to it
 */
/*
function getLoginFormPath() {
	return FULL_PATH . 'getForm.php';
}
*/

/**
 * Write a binary file to the specified path. Used for image caching feature.
 */
function writeFile ( $path, $data )
{
	$fp = fopen ( $path, 'wb' ) or die ( "Can't open file $path for writing" );
	$fout = fwrite ( $fp , $data );

	if ( !$data )
		die ( "Write failure! No data to write to $path!" );

	if ( $fout == 0 )
		die ( "Write failure! File $path NOT written" );

	fclose ( $fp );
}

/**
 * Returns a link to a cached image
 * //image.php?type=vt_image
 */
function getImage( $options ) {

	global $cacheImages, $refreshCache, $site;

	if ( $refreshCache )
		$ext = '?' . time();

	if ( $cacheImages && !$options['id'] ) {
		echo DOC_ROOT . TEMP_DIR . '/' . $site . '/' . $options['type'] . '.gif' . $ext;
	}
	else if ( $cacheImages ) {
		echo DOC_ROOT . TEMP_DIR . '/' . $site . '/' . $options['type'] . $options['id'] . '.gif' . $ext;
	}
	else if ( $options['id'] ) {
		echo DOC_ROOT . 'image.php?type=' . $options['type'] . '&id=' . $options['id'];
	}
	else {
		echo DOC_ROOT . 'image.php?type=' . $options['type'];
	}
}

/**
 * E-mail syntax checker
 */
function validEmail( $email ) {
	if ( eregi( "^[0-9a-z]([-_.]?[0-9a-z]*)*@[0-9a-z]([-.]?[0-9a-z])*\\.[a-z]*$", $email, $check ) ) {
		if ( strstr( $check[0], "@" ) )
			return true;
	}
	return false;
}

/**
 * Reads data from the $_FILES array for the image named $name
 */
function getFileData( $name ) {
	return addslashes( @fread( fopen( $_FILES[$name][tmp_name], "rb" ), @filesize( $_FILES[$name][tmp_name] ) ) );
}

/**
 * Reads data from the $_FILES array for the image named $name
 */
function getFileFromDiskData( $name ) {
	return addslashes( @fread( fopen( $name, "rb" ), @filesize( $name ) ) );
}


/*
// somewhat buggy when inputs contain / and \ symbols
function stri_replace($old, $new, $haystack) {
	 return preg_replace('/'.quotemeta($old).'/i', $new, $haystack);
}
*/

/**
 * Case-insensitive string replacement - from www.php.net
 */
function stri_replace($find,$replace,$string)
{
    if( !is_array($find) )
    	$find = array($find);

	if(!is_array($replace))
	{
		if(!is_array($find)) {
			$replace = array($replace);
		}
		else {
			// this will duplicate the string into an array the size of $find
			$c = count($find);
			$rString = $replace;
			unset($replace);

			for ($i = 0; $i < $c; $i++) {
				$replace[$i] = $rString;
			}
		}
	}
	foreach($find as $fKey => $fItem) {
		$between = explode(strtolower($fItem),strtolower($string));
		$pos = 0;

		foreach($between as $bKey => $bItem) {
			$between[$bKey] = substr($string,$pos,strlen($bItem));
			$pos += strlen($bItem) + strlen($fItem);
		}
		$string = implode($replace[$fKey],$between);
	}
	return($string);
}

/**
 * Splits set of sql queries into an array
 */
function splitSql($sql)
{
    $sql = preg_replace("/\r/s", "\n", $sql);
    $sql = preg_replace("/[\n]{2,}/s", "\n", $sql);
    $lines = explode("\n", $sql);
    $queries = array();
    $inQuery = 0;
    $i = 0;

    foreach ($lines as $line) {
        $line = trim($line);

        if (!$inQuery) {
            if (preg_match("/^CREATE/i", $line)) {
                $inQuery = 1;
                $queries[$i] = $line;
            }
            elseif (!empty($line) && $line[0] != "#") {
                $queries[$i] = preg_replace("/;$/i", "", $line);
                $i++;
            }
        }
        elseif ($inQuery) {
            if (preg_match("/^[\)]/", $line)) {
                $inQuery = 0;
                $queries[$i] .= preg_replace("/;$/i", "", $line);
                $i++;
            }
            elseif (!empty($line) && $line[0] != "#") {
                $queries[$i] .= $line;
            }
        }
    }

    return $queries;
}


function parseInsertSql( $sql, $table, &$fields, &$values ) {
    
      $sql = trim( $sql );

      if ( empty( $sql ) || $sql[0] == '#' )
          return false;
          
      $sql = str_replace( '[prefix]_', DB_PREFIX.'_', $sql );
      
      $pattern = '/insert\s+into\s+`?'.$table.'`?\s+\((.*?)\)\s+values\s+\((.*?)\)\s*$/i';
      
      if ( !preg_match( $pattern, $sql, $matches ) ) 
          return false;
      
      $tempFields = split( ',', trim( $matches[1], ' ' ) );
      
      foreach ( $tempFields as $field ) {
          $fields[] = trim( $field, ' `' );
      }
      
      $tempValues = split( ',', trim( $matches[2], ' ' ) );
      $value = '';
      
      for ( $i=0, $n=count( $tempValues ); $i<$n; $i++ ) {
          
          $value .= $tempValues[$i];
          
          if ( (substr_count( $value, '\'' ) - substr_count( $value, '\\\'' )) % 2 == 0 ) {
              $values[] = trim( $value, " '" );
              $value = '';
          } else { 
              $value .= ',';
          }
      }
      
      return true;
 

}

/**
 * retrieves the user's browser type
 */
function getUserBrowser()
{
    global $HTTP_USER_AGENT, $_SERVER;
    if (!empty($_SERVER['HTTP_USER_AGENT'])) {
        $HTTP_USER_AGENT = $_SERVER['HTTP_USER_AGENT'];
    }
    elseif (getenv("HTTP_USER_AGENT")) {
        $HTTP_USER_AGENT = getenv("HTTP_USER_AGENT");
    }
    elseif (empty($HTTP_USER_AGENT)) {
        $HTTP_USER_AGENT = "";
    }

    if (eregi("MSIE ([0-9].[0-9]{1,2})", $HTTP_USER_AGENT, $regs)) {
        $browser['agent'] = 'MSIE';
        $browser['version'] = $regs[1];
    }
    elseif (eregi("Mozilla/([0-9].[0-9]{1,2})", $HTTP_USER_AGENT, $regs)) {
        $browser['agent'] = 'MOZILLA';
        $browser['version'] = $regs[1];
    }
    elseif (eregi("Opera(/| )([0-9].[0-9]{1,2})", $HTTP_USER_AGENT, $regs)) {
        $browser['agent'] = 'OPERA';
        $browser['version'] = $regs[2];
    }
    else {
        $browser['agent'] = 'OTHER';
        $browser['version'] = 0;
    }

    return $browser['agent'];
}

// possibly eliminate?
function getNewWindowHref( $href, $width, $height ) {
    $uw = $width + 10;
    $uh = $height + 20;
    return "javascript:launchCentered( '$href', $uw, $uh, 'resizable=no,scrollbars=no' );";
}

/**
 * Appends array $source to the end of array $dest
 */
function array_append( $dest, $source ) {
    $n = count( $dest );
    $n1 = count( $source );
    for ( $index=$n; $index<$n+$n1; $index++ ) {
        $dest[$index] = $source[$index-$n];
    }
    return $dest;
}




/**
 * Determines if GD library is installed
 */
function gdInstalled() {
    return function_exists( 'gd_info' );
}



function getSetting( $name, $default=NULL ) {
    global $db, $site, $moduleKey;

    $value = $db->getOne( 'select value from '.MODULESETTINGS_TABLE." where name='$name' and site_key='$site' and module_key='$moduleKey'" );

    return isset( $value ) ? $value : $default;
}

function assignCenterVariables( $body_x, $body_w, &$layerData ) {
    
    global $db, $t, $c, $site;
    
    
    $bodyWPercent = ereg( "\%", $body_w );
    $bodyXPercent = ereg( "\%", $body_x );
    
    $minLayerX = 10000;
    $maxLayerX = 0;
    
    if ( is_array($layerData) && count($layerData) )

    foreach( $layerData as $layer ) {
    	
    	$layer[_left] = intval( $layer[_left] );
    	$layer[width] = intval( $layer[width] );
    	
        if ( $layer[_left] < $minLayerX )
            $minLayerX = $layer[_left];

        if ( $layer[_left] + $layer[width] > $maxLayerX )
            $maxLayerX = $layer[_left] + $layer[width];
    }
    

    $c->_table = SETTINGS_TABLE;
    $c->_field = 'value';
    $c->_id = $t->get_template_vars( 'bgImageId' );
    
    //echo $c->_id, $c->path( 'full' );
    
    $bgDim = @getimagesize( $c->path( 'full' ) );
    //print_r( $bgDim );
    $t->assign( 'bgImageWidth', intval( $bgDim[0] ) );

    $t->assign( 'minLayerX', $minLayerX );
    $t->assign( 'maxLayerX', $maxLayerX );
    $t->assign( 'bodyWPercent' , $bodyWPercent );
    $t->assign( 'bodyXPercent' , $bodyXPercent );
    $t->assign( 'percentWValue', floatval( $body_w / 100 ) );
    $t->assign( 'percentXValue', floatval( $body_x / 100 ) );
}


function isInTemplate( $resourceType, $resourceId ) {
    
    global $site, $db;

    $menuItem = $db->getRow( 'select id, in_template from '. MENUITEMS_TABLE ." where site_key='$site' and resource_type='$resourceType' and resource_id='$resourceId'" );
    if ( $menuItem ) {
        $in_template = $menuItem['in_template'];
    }
    else 
        $in_template = 'yes';
        
    return $in_template == 'yes' ? true : false;

}

function cut( $value, $len ) {
    return ( strlen($value) > $len ) ? substr( $value, 0, $len - 1) .'...' : $value;
}


/** 
* This will remove HTML tags, javascript sections
* and white space. It will also convert some
* common HTML entities to their text equivalent.
* $conent should contain an HTML document.
* From PHP Manual.
*/
function stripHTMLTags( $content ) {
    
    $search = array ("'<script[^>]*?>.*?</script>'si",  // Strip out javascript
                     "'<\s*br\s*(\/)?>'i",              // Replace brs to spaces
                     "'<[\/\!]*?[^<>]*?>'si",           // Strip out html tags
                     "'([\r\n])[\s]+'",                 // Strip out white space
                     "'&(quot|#34);'i",                 // Replace html entities
                     "'&(amp|#38);'i",
                     "'&(lt|#60);'i",
                     "'&(gt|#62);'i",
                     "'&(nbsp|#160);'i",
                     "'&(iexcl|#161);'i",
                     "'&(cent|#162);'i",
                     "'&(pound|#163);'i",
                     "'&(copy|#169);'i",
                     "'&#(\d+);'");
    
    $replace = array ("",
                      " ",
                      "",
                      "\\1",
                      "\"",
                      "&",
                      "<",
                      ">",
                      " ",
                      chr(161),
                      chr(162),
                      chr(163),
                      chr(169),
                      "chr(\\1)");
    
    $content = preg_replace ($search, $replace, $content);
    
    return $content;
}


/**
 * Return values and titles array from table to be used in smarty template
 */
function getCombo( $table, $values, $titles, $where='' ) {
	
	global $site, $db;
	
	if ( $where == '' )
		$where = "site_key='$site'";
		
	$items = $db->getAll( "select $values, $titles from $table where $where" );
	
	$aValues = array();
	$aTitles = array();
	
	if ( is_array( $items ) && count( $items ) ) {
		foreach ( $items as $idx=>$item ) {
			$aValues[] = $item[$values];
			$aTitles[] = $item[$titles];
		}
	}
	
	return array( $aValues, $aTitles );
}


function getSQLShares( $resource, $permission='' ) {
	
	$ids = array();
	
	if ( !$permission ) {
		// any permissison
		$ids = @array_keys( $_SESSION['shares'][$resource] );
	}
	else {
	
		if ( is_array( $_SESSION['shares'][$resource] ) && count( $_SESSION['shares'][$resource] ) )
		foreach ( $_SESSION['shares'][$resource] as $id=>$prop ) {
			if ( $prop[$permission] ) 
				$ids[] = $id;
		}
	}
	
	if ( !@count( $ids ) )
		$ids = array( 0 );
		
	return implode( ',', $ids );
	
}


/**
 * Used for creation smarty html_select arrays
 */
function getKeyTitle( $key, $title, $table, $shared='' ) {
	
	global $db, $site;
	
	// get arrays for smarty html_options
	
	$keys = array();
	$titles = array();
	
	if ( $shared ) {
		$list = $db->getAll( "select $key, if( $key in ($shared), concat($title, '[shared]'), $title) as $title from $table where (site_key='$site' or $key in ($shared)) order by $title" );
	}
	else {
		$list = $db->getAll( "select $key, $title from $table where site_key='$site' order by $title" );
	}
	
	foreach ( $list as $idx=>$item ) {
		$keys[] = $item[$key];
		$titles[] = $item[$title];
	}
	
	array_unshift( $keys, 0 );
	array_unshift( $titles, '- Select One -' );
	
	return array( $keys, $titles );
}

if (!function_exists(CopyFiles)) {
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
			if($file == "." || $file == ".." || $file == 'Thumbs.db' || $file == 'readme.txt') {
				continue;
			} elseif (is_dir($fromdir."/".$file)) {
				if ($recursed == 1) {
					$temp = CopyFiles($fromdir."/".$file, $todir."/".$file, $recursed);
				}
			} elseif (file_exists($fromdir."/".$file)) {
				/* copy($fromdir."/".$file, $todir."/".$file); */
				/* Trying to overcome the issue of installation on some
				   systems where copy command may be issuing some unwanted checks.  */
				$data = file_get_contents($fromdir."/".$file);
				$fout = fopen($todir."/".$file,'wb');
				$fx = fwrite($fout, $data);
				fclose($fout);
			}
		}

		closedir($dir);
		return true;
	}
}

function getStates ($countrycode='US', $all='Y', $order='name') {

	$states = array();

	global $db;
	
	$sql = 'select code, name from ! where countrycode = ? order by !';
	
	$recs = $db->getAll($sql, array( STATES_TABLE, $countrycode, $order ) );

	if (count($recs) <= 0) return $states;
	
	foreach ($recs as $rec) {
	
		$states[$rec['code']] = $rec['name'];

	}

	$recs = $states;
	
	$states=array();
	if ($all == 'Y') {
	
		$states['AA'] = ($recs['AA']!='')?$recs['AA']:'All States';
	
	}	
	foreach ($recs as $key => $val) {
	
		if ($key != 'AA') {
		
			$states[$key] = $val;
		
		}
	}
	
	return $states;

}

function getCounties ($countrycode='US', $statecode = 'AA', $all='Y', $order='name') {

	$counties = array();

	global $db;
	
	if ($statecode == 'AA') {
		$sql = 'select code, name from ! where countrycode = ? and statecode <> ? order by !';
	} else {
		$sql = 'select code, name from ! where countrycode = ? and statecode = ? order by !';
	}	

	$recs = $db->getAll($sql, array( COUNTIES_TABLE, $countrycode, $statecode, $order ) );

	if (count($recs) <= 0) return $counties;
	
	foreach ($recs as $rec) {
	
		$counties[$rec['code']] = $rec['name'];

	}

	$recs = $counties;
	
	$counties=array();
	if ($all == 'Y') {
	
		$counties['AA'] = ($recs['AA']!='')?$recs['AA']:'All Counties/Districts';
	
	}	
	foreach ($recs as $key => $val) {
	
		if ($key != 'AA') {
		
			$counties[$key] = $val;
		
		}
	}
	
	return $counties;

}

function getCities ($countrycode='US', $statecode = 'AA', $countycode = 'AA', $all='Y', $order='name') {

	$cities = array();

	global $db;
	
	if ($countycode == 'AA') {
	 	$sql = 'select code, name from ! where countrycode = ? and statecode = ? and countycode <> ? order by !';
	} else {
	 	$sql = 'select code, name from ! where countrycode = ? and statecode = ? and countycode = ? order by !';	
	}
	$recs = $db->getAll($sql, array( CITIES_TABLE, $countrycode, $statecode, $countycode, $order ) );

	if (count($recs) <= 0) return $cities;
	
	foreach ($recs as $rec) {
	
		$cities[$rec['code']] = $rec['name'];

	}

	$recs = $cities;
	
	$cities=array();
	if ($all == 'Y') {
	
		$cities['AA'] = ($recs['AA']!='')?$recs['AA']:'All Cities/Towns';
	
	}	
	foreach ($recs as $key => $val) {
	
		if ($key != 'AA') {
		
			$cities[$key] = $val;
		
		}
	}
	
	return $cities;

}


function getZipcodes ($countrycode='US', $statecode = 'AA', $countycode = 'AA', $citycode = 'AA', $all='Y', $order='code') {

	$zipcodes = array();

	global $db;
	
	if ($citycode == 'AA') {
		$sql = 'select code, code as cd1 from ! where countrycode = ? and statecode = ? and countycode = ? and citycode <> ? order by code';
	} else {
		$sql = 'select code, code as cd1  from ! where countrycode = ? and statecode = ? and countycode = ? and citycode = ? order by code';
	}
	$recs = $db->getAll($sql, array( ZIPCODES_TABLE, $countrycode, $statecode, $countycode, $citycode) );

	if (count($recs) <= 0) return $zipcodes;
	
	foreach ($recs as $rec) {
	
		$zipcodes[$rec['code']] = $rec['cd1'];

	}

	$recs = $zipcodes;
	
	$zipcodes=array();
	if ($all == 'Y') {
	
		$zipcodes['AA'] = ($recs['AA']!='')?$recs['AA']:'All Zip/Pin Codes';
	
	}	
	foreach ($recs as $key => $val) {
	
		if ($key != 'AA') {
		
			$zipcodes[$key] = $val;
		
		}
	}
	
	return $zipcodes;

}


?>