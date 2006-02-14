<?php

if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

$userid = $_SESSION['UserId'];

$sql = 'SELECT id, picture, tnpicture FROM ! WHERE userid = ? AND picno = ?';

$row = $db->getRow( $sql, array( USER_SNAP_TABLE, $userid, $_POST['txtpicno'] ) );


$err = 0;

if ($config['snaps_require_approval'] == 'Y') {

	$act = 'N';

} else {

	$act = 'Y';

}

$curr_imgfile = $curr_tnimgfile = '';

if ($config['images_in_db'] == 'N') {

	if (substr_count($row['picture'], 'file:' )>0 ) {
		$curr_imgfile = ltrim(rtrim(str_replace('file:','',$row['picture'] ) ) );
	}
	if (substr_count($row['tnpicture'],'file:' )>0 ) {
		$curr_tnimgfile = ltrim(rtrim(str_replace('file:','',$row['tnpicture'] ) ) );
	}
}

$allwdsize = $config['upload_snap_maxsize'];

if( is_uploaded_file( $_FILES['txtimage']['tmp_name'] ) ) { 

	$img_file = $_FILES['txtimage']['tmp_name'];

	$ext = split( '/', $_FILES['txtimage']['type'] );

	$picext = strtolower($ext[1]);

	if( $picext == 'pjpeg' || $picext == 'jpeg'){

		$picext = 'jpg';
	}
	
	if( $picext == 'x-png' ) {
		$picext= 'png';
	}
	//echo "$picext<br>";

	$ext_ok = '0';

	foreach (explode(',',$config['upload_snap_ext']) as $ex) {
		

		if ( $ex == $picext ) $ext_ok++;

	}
	
	if ( $ext_ok <= '0' ) { 

		header( 'location:uploadsnaps.php?msg=' .WRONG_TYPE  );
		exit;

	}
	
	
	$handle = fopen ($img_file, 'rb');

	/* Get current picture size and allowed size. If pic size is more than the allowed size, flag error.. */

	$picsize= filesize ($img_file);

	if ($picsize > $allwdsize) {
		
		header( 'location:uploadsnaps.php?msg='.BIG_PIC_SIZE );
		exit;
			
	}

	$orgimg = fread($handle, filesize ($img_file));

	fclose ($handle);
	
 	
	if ( $picext != 'jpg' ) {
	/* convert the picture to jpg. This is to enable picture editing  */
		
		
		//$jpgfile = createThumb($orgimg, 'N');
		$img_tmp=createImg($picext,$img_file);
		$jpgfile = createJpeg($img_tmp, 'N');
		$newimg = file_get_contents($jpgfile);
		
		unlink($jpgfile);

		
	
	} else {
	
		$newimg = $orgimg;
	}

	if ($row['tnpicture'] == '' && !is_uploaded_file( $_FILES['tnimage']['tmp_name'] ) ) {

		//$tnimg_file = createThumb( $orgimg );
		$img_tmp=createImg($picext,$img_file);
		$tnimg_file = createJpeg($img_tmp);
		
		$tnimg = file_get_contents($tnimg_file);
		
		$tnext = 'jpg';
		
		unlink($tnimg_file);
	}
	$picext = 'jpg';
	
	if ($config['images_in_db'] == 'N') {

		$imgfile = writeImgFile($newimg, $userid, '1'.$_POST['txtpicno'],$curr_imgfile);

		$newimg = 'file:'.$imgfile;

		if ($row['tnpicture'] == '') {

			$tnimgfile = writeImgFile($tnimg, $userid, '2'.$_POST['txtpicno'],$curr_tnimgfile);

			$tnimg = 'file:'.$tnimgfile;
		}
	} else {
	
		$newimg = base64_encode($newimg);

		if ($row['tnpicture'] == '') {
			

			$tnimg = base64_encode($tnimg);
		}
	}

	if ( $row ) {

		$sql = 'update ! set picture = ?, ins_time = ?, active=?, picext=? where userid = ? and picno = ? and id = ?';	

		$db->query( $sql, array( USER_SNAP_TABLE, $newimg, $time, $act, 	$picext, $userid, $_POST['txtpicno'], $row['id'] ) );

	} else {
				
		$sql = 'insert into ! ( id, userid, picno, picture, ins_time, active, picext, tnpicture, tnext ) values ( ?, ?, ?, ?, ?, ?, ?, ?, ? )';

		$db->query( $sql, array( USER_SNAP_TABLE, '', $userid, $_POST['txtpicno'], $newimg, $time, $act, $picext, $tnimg, $tnext ) );

	}

	header( 'location:uploadsnaps.php?msg='.PICTURE_LOADED );
	exit;

}

if ( is_uploaded_file( $_FILES['tnimage']['tmp_name'] ) ) {

	$tnimg_file = $_FILES['tnimage']['tmp_name'];

	$ext = split( '/', $_FILES['tnimage']['type'] );

	$tnext = strtolower($ext[1]);

	$tnsize = $config['upload_snap_tnsize'];

	if( $tnext == 'pjpeg' || $tnext == 'jpeg'){

		$tnext = 'jpg';

	}

	if( $tnext == 'x-png' ) {
		$tnext= 'png';
	}

	$ext_ok = 0;

	foreach (explode(',',$config['upload_snap_ext']) as $ex) {

		if ( $ex == $tnext ) $ext_ok++;

	}

	if ( $ext_ok <= 0 ) { 

		header( 'location:uploadsnaps.php?msg=' .WRONG_TYPE  );
		exit;

	}

	$picsize= filesize ($tnimg_file);

	if ($picsize > $allwdsize) {
		
		header( 'location:uploadsnaps.php?msg='.BIG_PIC_SIZE );
		exit;
			
	}

	list($tnwidth, $tnheight, $tntype, $tnattr) = getimagesize($tnimg_file);

	
	if ($tnwidth > $tnsize or $tnheight > $tnsize) {
				
			header( 'location:uploadsnaps.php?msg='.BIGTHUMBNAIL );
			exit;
	}		

	$handle = fopen ($tnimg_file, 'rb');

	/* Get current picture size and allowed size. If pic size is more than the allowed size, flag error.. */
	
	$tnimg = fread($handle, filesize ($tnimg_file));

	fclose ($handle);

	if ( $tnext != 'jpg' ) {
		
	/* convert the picture to jpg. This is to enable picture editing  */
	
		//$jpgfile = createThumb($tnimg, 'N');
		$img_tmp=createImg($tnext,$tnimg_file);
		$jpgfile = createJpeg($img_tmp, 'N');
			
		$newtnimg = file_get_contents($jpgfile);
		
		unlink($jpgfile);

		$tnext = 'jpg';
	
	} else {
	
		$newtnimg = $tnimg;
	}

	if ($config['images_in_db'] == 'N') {

		$tnimgfile = writeImgFile($newtnimg, $userid, $_POST['txtpicno'], $curr_tnimgfile);

		$tnimg = 'file:'.tnimgfile;
	} else {
	
		$tnimg = base64_encode( $newtnimg );
	}

	if ($row) {

		$sql = 'update ! set tnpicture = ?, ins_time = ?, active=?, tnext=? where id = ?';	

		$db->query( $sql, array( USER_SNAP_TABLE, $tnimg, $time, $act, 	$tnext, $row['id'] ) );

	} else {

		$sql = 'insert into ! ( id, userid, picno, tnpicture, ins_time, active, tnext ) values ( ?, ?, ?, ?, ?, ?, ? )';

		$db->query( $sql, array( USER_SNAP_TABLE, "", $userid, $_POST['txtpicno'], $tnimg, $time, $act, $tnext ) );

	}

	header( 'location:uploadsnaps.php?msg='.PICTURE_LOADED );
	exit;

}

header( 'location:uploadsnaps.php?msg='.FAILED_UPLOAD );
exit;

function createImg($type,$file) {
	if($type == 'bmp') $img=imagecreatefromwbmp($file);
	else if($type == 'png') $img=imagecreatefrompng($file);
	else if($type == 'gif') $img=imagecreatefromgif($file);
	else if($type == 'jpg') $img=imagecreatefromjpeg($file);
	return $img;
}



function createJpeg( $img , $reduce='Y') {

	global $config;
	global $userid;
	global $ext;

	$tnsize = $config['upload_snap_tnsize'];
	
	//$img = imagecreatefrompng($org); 

	$w = imagesx( $img );

	$h = imagesy( $img );

	if ($reduce == 'Y') {
		if( $w > $h ) {
			$ratio = $w / $h;
			$nw = $tnsize;
			$nh = $nw / $ratio;
		} else {
			$ratio = $h / $w;
			$nh = $tnsize;
			$nw = $nh /$ratio;
		}
	} else {
	
		$nh = $h;
		$nw = $w;
	}

	$img2 = imagecreatetruecolor( $nw, $nh );

	imagecopyresampled ( $img2, $img, 0, 0, 0 , 0, $nw, $nh, $w, $h );

	$fimg = 'img_' . $userid . '.jpg';

	$real_tpath = realpath ("temp");

	if(	$HTTP_ENV_VARS['OS'] == 'Windows_NT'){

		$real_tpath= str_replace( "\\", "\\\\", $real_tpath);

		$file = $real_tpath . "\\" . $fimg;

	}else{

		$file = $real_tpath . "/" . $fimg;

	}

	imagejpeg( $img2, $file );

	imagedestroy($img2);
	
	imagedestroy($img);
	
	return $file;
}



function writeImgFile($img, $userid, $picno, $file="") {
/* This routine will create an image file */
	if ($file == '') {
		$filename= time().$userid.$picno.'.jpg';
	} else {
		$filename = $file;	
	}
	
	$img = imagecreatefromstring( $img );
	imagejpeg($img, USER_IMAGE_DIR.$filename);
	
	return ($filename);
}
?>