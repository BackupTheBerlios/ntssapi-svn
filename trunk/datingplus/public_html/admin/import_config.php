<?php
	@set_time_limit(0);	// No time limits
	ignore_user_abort(1);	// Ignoring user aborting

	function debug($var)
	{	echo("<pre>");
		print_r($var);
		echo("</pre>");
	}

	function insert_query($table,$set)
	{	global $table_prefix;
		$fields=NULL;
		$query="insert into ".$table_prefix.$table." set ";
		foreach($set as $key=>$value)
		{	if($value!=NULL)
				$fields[]=$key."='".mysql_escape_string(trim($value))."'";
		}
		$query.=implode(", ",$fields);
		return($query);
	}

	function update_query($table,$set,$where)
	{	$fields=NULL;
		$query="update ".$table." set ";
		foreach($set as $key=>$value)
		{	if($value!=NULL)
				$fields[]=$key."='".mysql_escape_string(trim($value))."'";
		}
		$query.=implode(", ",$fields);
		$query.=$where;
		return($query);
	}

	function FileExtention($filename)
	{	$path_parts = pathinfo($filename);
		return(strtolower($path_parts["extension"]));
	}

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
	$real_tpath = realpath ("../temp");

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