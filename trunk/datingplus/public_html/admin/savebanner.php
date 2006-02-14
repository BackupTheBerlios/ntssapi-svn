<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

include ( 'sessioninc.php' );

define( 'PAGE_ID', 'banner_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}

$err = 0;

if ( $_FILES['txtbanner'] == '' ) {

	$err = BANNER_BLANK;	// change to a constant later
}
elseif( $_POST['txtlinkurl'] == '' ) {

	$err = LINK_BLANK;	// change to a constant later
}

if ( $err != 0 ) {

	header( 'location:addbanner.php?errid=' . $err );
	exit;
}


if( is_uploaded_file( $_FILES['txtbanner']['tmp_name'] ) ) {
	$imgw = 0;

	$imgh = 0;

	$imgsize = '';

	$linkurl = 'http://' . $_POST['txtlinkurl'];

	$tooltip = $_POST['txttooltip'];

	$ext = split( "/", $_FILES['txtbanner']['type'] );

	$size = getimagesize(	$_FILES['txtbanner']['tmp_name'] );

	if($ext[1] == 'pjpeg' || $ext[1]=='jpeg'){

		$imgw =  $size[0];

		$imgh =  $size[1];

		$ext[1] = 'jpg';

		$imgsize = $imgw . ' x '  . $imgh;

	} elseif( $ext[1] == 'x-shockwave-flash' ){

		$ext[1] = 'swf';

	} elseif( $ext[1] == 'gif' ){

		$imgw =  $size[0];

		$imgh =  $size[1];

		$ext[1] = 'gif';

		$imgsize = $imgw . ' x ' . $imgh;

	} elseif( $ext[1] == 'bmp' ){

		$imgw =  $size[0];

		$imgh =  $size[1];

		$ext[1] = 'bmp';

		$imgsize = $imgw . ' x ' . $imgh;

	} elseif( $ext[1] == 'x-png' || $ext[1] == 'png' ){

		$imgw =  $size[0];

		$imgh =  $size[1];

		$ext[1] = 'png';

		$imgsize = $imgw . ' x ' . $imgh;

	} else {

		$err = WRONG_TYPE;
		header( 'location:addbanner.php?errid=' . $err );
		exit;

	}

	/// Start Date
	$sdd = $_POST['txtstartDay'];

	$smm = $_POST['txtstartMonth'];

	$syy = $_POST['txtstartYear'];

	$startdate = mktime(0,0,0,$smm,$sdd,$syy,0);

	/// Expity Date
	$edd = $_POST['txtendDay'];

	$emm = $_POST['txtendMonth'];

	$eyy = $_POST['txtendYear'];

	$expirydate = mktime(0,0,0,$emm,$edd,$eyy,0);

	$sql = "INSERT INTO ! (  linkurl, tooltip, size, startdate, expdate ) VALUES (  ?, ? , ?, ?, ? )";

	$db->query( $sql, array( BANNER_TABLE, $linkurl, $_POST['txttooltip'], $imgsize, $startdate, $expirydate ) );

	$lastid = getLastId( BANNER_TABLE );

	$fname = $lastid . '.' . $ext[1];

	$bannerlink = '';

	if( $ext[1] == 'jpg' || $ext[1] == 'gif' || $ext[1] == 'bmp' || $ext[1] == 'x-png' ){

		$bannerlink="<a href='banclick.php?id=$lastid' target='_blank'><img src='" . DOC_ROOT. 'banners/' . $fname . "' border='0' width='$imgw' height='$imgh' alt=\"$tooltip\"></a>";
	}
	elseif( $ext[1] == 'swf' ){

		$bannerlink ="<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0'>";
		$bannerlink .= "<param name='movie' value='" . DOC_ROOT. 'banners/' . $fname . "'>";
		$bannerlink .="<param name='quality' value='high'>";
		$bannerlink .="<embed src='" . DOC_ROOT. 'banners/' . $fname . "' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed></object>";

	}
	$bannerlink = addslashes( $bannerlink );

	$sql = 'UPDATE ! SET name = ?, bannerurl = ? WHERE id = ?';

	$db->query( $sql, array( BANNER_TABLE, $fname, $bannerlink, $lastid ) );

	$real_path = BANNER_DIR;

	if(	$HTTP_ENV_VARS["OS"] == 'Windows_NT'){

		$real_path= str_replace("\\","\\\\",$real_path);

		$file = $real_path."\\".$fname;
	}
	else {

		$file = $real_path."/".$fname;

	}
	copy( $_FILES['txtbanner']['tmp_name'], $file);

	header( 'location:managebanner.php' );

	exit;
}
?>