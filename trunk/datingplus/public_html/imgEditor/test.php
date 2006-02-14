<?php

if ( !defined( 'SMARTY_DIR' ) )
	include_once( '../init.php' );

$command = $_GET['command'];
if($command == 'crop'){
	$x1 = $_GET['x1'];
	$y1 = $_GET['y1'];
	$x2 = $_GET['x2'];
	$y2 = $_GET['y2'];
	$n = $_GET['n'];

	if($x1 > $x2){

		$t = $x1;
		$x1 = $x2;
		$x2 = $t;
	}
	if($y1 > $y2){

		$t = $y1;
		$y1 = $y2;
		$y2 = $t;
	}

	$width = $x2 - $x1;
	$height = $y2 - $y1;

	if( ($n-1) <= 0 ){
		$imgname = '../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno'] . '.jpg';
	}else{
		$imgname = '../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno']
		. '_' . ($n - 1) . '.jpg';
	}


	$im = imagecreatefromjpeg ($imgname);
	if($im){
		$newim = imagecreatetruecolor($width, $height);
		imagecopyresized ( $newim, $im, 0, 0, $x1, $y1, $width, $height, $width, $height);
		imagejpeg($newim,'../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno'] . '_' . $n . '.jpg');
		imagedestroy($newim);
		imagedestroy($im);

		echo '&gl_status=yes&';
		exit;
	}
}
elseif($command == 'resize'){
	$n = $_GET['n'];
	//$persize = $_GET['persize'];
	$new_width=$_GET['width'];
	$new_height=$_GET['height'];

	if( ($n-1) <= 0 ){
		$imgname = '../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno'] . '.jpg';
	}else{
		$imgname = '../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno']
		. '_' . ($n - 1) . '.jpg';
	}

	$im = imagecreatefromjpeg ($imgname);
	if($im){
		$swidth = imagesx($im);
		$sheight = imagesy($im);
		//$width = $swidth * $persize /100;
		//$height = $sheight * $persize /100;
		$newim = imagecreatetruecolor($new_width, $new_height);
		//imagecopyresampled ( $newim, $im, 0, 0, 0, 0, $width, $height, $swidth, $sheight);
		imagecopyresampled ( $newim, $im, 0, 0, 0, 0, $new_width, $new_height, $swidth, $sheight);
		imagejpeg($newim,'../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno'] . '_' . $n . '.jpg');

		echo '&gl_status=yes&';
		exit;
	}
}
elseif($command == 'save'){

	$n = $_GET['n'];

	$pic = $_SESSION['imgEdit'];

	if( (int)$_GET['picno'] ){

		if( $n <= 0 ){
			$img = '../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno'] . '.jpg';
		}else{
			$img = '../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno'] . '_' . $n . '.jpg';
		}
		$handle = fopen ( $img, "rb");
//			fpassthru( $handle );
		$orgimg = fread ( $handle, filesize( $img ) );
		fclose ($handle);

		//$orgimg = imagecreatefromstring($orgimg);
		$orgimg1 = imagecreatefromstring($orgimg);
		if ($config['snaps_require_approval'] == 'Y') {

			$act = 'N';

		} else {

			$act = 'Y';

		}

		if ($pic == 'tnpicture') {

			$w = imagesx($orgimg1);
			$h = imagesx($orgimg1);
			$tnsize = $config['upload_snap_tnsize'];
			if ($w > $tnsize || $h > $tnsize) {
				echo '&gl_status=no&';
				exit;
			}

			$sql = 'select id, tnpicture as picture, active, tnext as ext from ! where userid = ? and picno = ? ';

		} else {

			$sql = 'select id, picture, active, picext as ext from ! where userid = ? and picno = ? ';

		}

		$row = $db->getRow ( $sql, array( USER_SNAP_TABLE, $_SESSION['UserId'], $_GET['picno'] ) );
		if (substr_count($row['picture'],'file:') > 0) {
			$filename = ltrim( rtrim ( str_replace('file:','',$row['picture'] ) ) );
		} else { $filename = ''; }

		$userid = $_SESSION['UserId'];

		if ($config['images_in_db'] == 'N') {

			if ($pic == 'picture') {
				$imgfile = writeImageToFile($orgimg, $userid, '1'.$_POST['txtpicno'],$filename);

				$newimg = 'file:'.$imgfile;
			} else {

				$imgfile = writeImageToFile($tnimg, $userid, '2'.$_POST['txtpicno'],$filename);

				$newimg = 'file:'.$imgfile;
			}


		} else {
			echo "&name1=this&";
			$newimg = base64_encode($orgimg);

		}

		if ($pic == 'picture' ) {

			$sql = 'update ! set picture = ?, ins_time = ?, active=?, picext=? where userid = ? and picno = ? and id = ?';

			$db->query( $sql, array( USER_SNAP_TABLE, $newimg, time(), $act, 	'jpg', $userid, $_GET['picno'], $row['id'] ) );

		} else {

			$sql = 'update ! set tnpicture = ?, ins_time = ?, active=?, picext=? where userid = ? and picno = ? and id = ?';

			$db->query( $sql, array( USER_SNAP_TABLE, $newimg, time(), $act, 	'jpg', $userid, $_GET['picno'], $row['id'] ) );

		}


		$file = '../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno'] . '.jpg';
		unlink( $file );

		$i=1;
		while( file_exists('../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno'] . '_' . $i . '.jpg') ){

			unlink( '../temp/img' . $_SESSION['UserId'] . '_' . $_GET['picno'] . '_' . $i . '.jpg' );
			$i++;
		}


		echo '&gl_status=yes&';
		exit;
	}else{
		echo '&gl_status=no&';
		exit;
	}
}

function writeImageToFile($img, $userid, $picno, $file="") {
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