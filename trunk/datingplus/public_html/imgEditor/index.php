<?php
  session_start ();

  include ("../init.php");
	if( $_GET['status'] == 'start' && (int)$_GET['picno'] > 0 ){

		if ( !defined( 'SMARTY_DIR' ) )
			include_once( '../init.php' );

		$row = $db->getRow( 'SELECT * FROM ' . USER_SNAP_TABLE . ' WHERE 	userid		=\''
			. $_SESSION['UserId'] . '\' AND picno=\'' . $_GET['picno'] . '\'');


		$to_edit = ($_GET['typ']=='pic') ? 'picture' : 'tnpicture' ;

		$_SESSION['imgEdit'] = $to_edit;

		if ( $row ) {

			if (substr_count($row[$to_edit],'file:') > 0) {
				/* Get picture from file.  */
				$img = file_get_contents(ltrim(rtrim(str_replace('file:',USER_IMAGE_DIR,$row[$to_edit]) ) ) );
			} else {
				$img = base64_decode ($row[$to_edit]);
			}

			$img = imagecreatefromstring( $img );

			$imgfile = TEMP_DIR.'img'. $_SESSION['UserId'] . '_' . $_GET['picno'] . '.jpg';

			$imgname = 'img'. $_SESSION['UserId'] . '_' . $_GET['picno'] . '.jpg';

			imagejpeg ( $img , $imgfile);

			if( !file_exists( $imgfile ) ){

				echo 'file not found';
				exit;
			}
		}else{
			echo '<script language="javascript">window.close()</script>';
			exit;
		}
	}

  if ($_SESSION["browser"] != "MOZILLA")
    $setCLASSID = "classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\"";
  else
    $setCLASSID = "";

?>
<?php echo("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>\n")?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title><?=$lang['title']?></title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<script type="text/javascript">
/* <![CDATA[ */
function closeWindow(){

	window.opener.document.location = '../uploadsnaps.php';
	window.close();
}
/* ]]> */
</script>

<style type="text/css">
html, body, object {
  height: 100%;
  margin: 0;
  padding: 0;
}
</style>

</head>

<body bgcolor="#000000">
<div id="Layer1" style="position: absolute; left:0; top:0; width:100%; height:100%; z-index: 1; text-align: left">
<object <?=$setCLASSID?> height="100%" width="100%" data="imgEditor.swf?<?php echo 'imgname='.$imgfile; ?>">
  <param name="movie" value="imgEditor.swf?<?php echo 'imgname='.$imgfile; ?>" />
  <param name="quality" value="high" />
  <param name="salign" value="LT" />
  <param name="scale" value="noscale" />
</object>
</div>
</body>
</html>
