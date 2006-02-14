<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}

if( (int)$_GET['id'] <= 0 ) {

	$userid = $_SESSION['UserId'];

} else {

	$userid = $_GET['id'];

}

$picid = ( $_GET['picid'] ) ? $_GET['picid'] : '1' ;

$typ = ( $_GET['typ'] ) ? $_GET['typ'] : 'pic' ;

$sql = 'select gender from ! where id = ?';

$gender = $db->getOne( $sql, array( USER_TABLE, $userid ) ) ;

$cond = '';

if ($typ == 'tn') { 

	$sql = 'select tnpicture as picture, active, tnext as ext from ! where userid = ? and picno = ? '.$cond;

} else {

	$sql = 'select picture, active, picext as ext from ! where userid = ? and picno = ? '.$cond;

}

$row = $db->getRow ( $sql, array( USER_SNAP_TABLE, $userid, $picid ) );

if (substr_count($row['picture'],'file:') > 0) {
	/* The picture is in file system */
	$img = file_get_contents(ltrim(rtrim(str_replace('file:',USER_IMAGE_DIR,$row['picture']) ) ) );
	
} else {

	$img = base64_decode ( $row['picture']  );

}

if ( $row['picture'] != '' ) {

	$img = imagecreatefromstring($img);

	$w = imagesx( $img );

	$h = imagesy( $img );

	$wdth = ($_GET['width']!='')?$_GET['width']:$w;
		
	$hght = ($_GET['height']!='')?$_GET['height']:$h;

	

	if ($typ == 'pic' and ( $wdth != $w or $hght != $h) ) {

		if( $w > $h ) {
			$ratio = $w / $h;
			$nw = $wdth;
			$nh = $nw / $ratio;
		} else {
			$ratio = $h / $w;
			$nh = $hght;
			$nw = $nh /$ratio;
		}
		
		$img2 = imagecreatetruecolor( $nw, $nh );

		imagecopyresampled ( $img2, $img, 0, 0, 0 , 0, $nw, $nh, $w, $h );

	} else {
	
		$img2 = $img;
	}
//	$img = base64_decode ( $row['picture'] );
	
	header("Content-Type: image/jpg");

	header("Content-Disposition: inline" );

	imagejpeg($img2);

	imagedestroy($img2);
	imagedestroy($img);
	
} else {

	if ($gender == 'M') {
		$nopic = '../images/male.jpg';
	} elseif ($gender == 'F') {
		$nopic = '../images/female.jpg';
	} elseif ($gender == 'C') {
		$nopic = '../images/couple.jpg';
	}

	$fp = fopen( $nopic , 'rb' );

	fpassthru( $fp );

	fclose( $fp );
	
}
?>