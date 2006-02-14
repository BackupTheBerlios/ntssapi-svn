<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}	

include ( 'sessioninc.php' );
include (PEAR_DIR.'Mail/mime.php');

define( 'PAGE_ID', 'send_letter' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}	

$cmd = $_POST['cmd'];


if(isset($cmd) && $cmd=='imgposted'){

	$delimg = $_POST['delimg'];
	
	if($delimg !=''){
	
		unlink( "../emailimages/".$delimg );
		
	} else{


		$picfile_name = $_FILES['picfile']['name'];
		
		$tmpfile = $_FILES['picfile']['tmp_name'];
		
		$real_path = realpath( "../emailimages" );
		
		if(	$HTTP_ENV_VARS["OS"] == 'Windows_NT'){
		
			$real_path= str_replace("\\","\\\\",$real_path);
			
			$file = $real_path."\\\\".$picfile_name;
			
		} else {
		
			$file = $real_path."/".$picfile_name;
		}
		
		copy( $tmpfile, $file );
	}
	
	header( 'location:?' );
	exit;
}

if( $_POST['frm'] == 'frmSend' ){

	$_SESSION['letterid'] = $letterid = $_POST['txttitle'];
	
	$_SESSION['fromname'] = $fromname = $_POST['txtsendname'];
	
	$sql = 'select email from ! where id = ?';
	
	$_SESSION['from'] = $from = $db->getOne( $sql, array(  ADMIN_EMAILS_TABLE , $_POST['txtfrom'] ) );
	
	$_SESSION['subject'] = $subject = $_POST['txtsubject'];
	
	$_SESSION['message'] = $message = $_POST['txtmessage'];
	
	$_SESSION['save'] = $save = $_POST['txtsave'];
	
	$_SESSION['name'] = $name = $_POST['txtname'];
	
	$_SESSION['txtselected'] = $txtselected = $_POST['txtselected'];

	$usernames = array();
	
	if ($txtselected != '') {
	
		$txtselected = str_replace('\\n',',',$txtselected);
		
		$usernames = explode(',', $txtselected);

		$users_select = '';
		
		foreach ($usernames as $user) {
		
			if (ltrim(rtrim($user)) != '') {
			
				if ($users_select != '') {$users_select .= ','; }

				$users_select .= "upper('".ltrim(rtrim($user))."')";
			}
		}

		$users_select = ' upper(username) in ('.$users_select.')';		
	}
	
	if( $_POST['userrange'] == 'all'){
	
		$sql = 'SELECT * FROM !  WHERE 1 ';
		
	} elseif ( $_POST['userrange'] == 'selected' && $users_select != ''){
	
		$sql = 'SELECT * FROM ! WHERE '.$users_select;
		
	} elseif ( $_POST['userrange'] == 'level' ){
	
		$sql = 'SELECT * FROM ! WHERE level = ' . $_POST['txtlevel'];
		
	}

	if (count($_POST['txtfilteruser']) > 0) {

		foreach( $_POST['txtfilteruser'] as $filter ){

			if( $filter == 'gender' ) {

				$sql .= " and gender= '" . $_POST['txtgender'] . "'";

			}

			if( $filter == 'location' ) {

				if ($_POST['txtcountry'] != 'AA' && $_POST['txtcountry'] != '') {

					$sql .= " and country= '" . $_POST['txtcountry'] . "'";

				}
			}

			if( $filter == 'age' ) {

				$sql .= ' and floor(period_diff(extract(year_month from NOW()),extract(year_month from birth_date))/12)  between ' 
				. $_POST['txtagestart'] . ' and ' . $_POST['txtageend'];

			}	
		}
	}
	
	$rs=$db->getAll ( $sql, array( USER_TABLE ) );
	
	foreach( $rs as $user){

		$from = '"' . $_SESSION['fromname'] . '" <'. $_SESSION['from'] .'>';
	
		$subject = $_SESSION['subject'] ;
	
		$message = $_SESSION['message'] ;

/* 	#Link#, 		#SiteTitle#, 	#SiteName#, #NickName#, 
	#RealName#, 	#Sex#, 			#Email#, 	#UserId#, 
	#UserPicture#, 	#UserAge#, 		#UserDOB#
*/
		$link = 'http://' . $_SERVER['SERVER_NAME'] . DOC_ROOT ;

		$message1=str_replace('#Link#', $link, $message);
		$message1=str_replace('#SiteName#', SITENAME, $message1);
		$message1=str_replace('#NickName#', $user['firstname'], $message1);
		$message1=str_replace('#RealName#', $user['firstname'].' '.$rs['lastname'], $message1);
		$message1=str_replace('#Sex#', $lang['signup_gender_values'][$user['gender']], $message1);
		$message1=str_replace('#Email#', $user['email'], $message1);
		$message1=str_replace('#UserId#', $user['username'], $message1);
		$message1 = str_replace('#FromName#', $fromname, $message1);

		$attach_files=array();
	
		if ($_POST['files_to_attach'] != '') {
			$attach_files = explode(',',$_POST['files_to_attach']);
		}

		@ini_set("max_execution_time", "1200");

		/* Now create mime mail */
		$crlf = "\n";
	
		$headers = array (
			'From'    => $from,			
			'Subject' => $subject
		);
	
		$mime = new Mail_mime($crlf);

		$mime->setHTMLBody($message1);
	
		if (count($attach_files) > 0) {
			foreach ($attach_files as $file) {
				if ($file != '') {
					$mime->addAttachment("../emailimages/".$file);
				}
			}
		}	
	
		$body = $mime->get();
	
		$hdrs = $mime->headers($headers);
	
		$mail_object =& Mail::factory( MAIL_TYPE, $params );

		$mail_object->send( $user['email'], $hdrs, $body );

	}
		
	$t->assign( 'success', true );
}

if( $_POST['txtsave'] == 'yes' ){

	$sql = 'select id from ! where title = ?';
	
	$rid = $db->getOne($sql, array( ADMIN_LETTER_TABLE, $name) );
	
	if ($rid > 0) {
	
		$sql = 'update ! set subject = ?, modify = ?, bodytext = ? where id = ?';
		
		$db->query($sql, array(ADMIN_LETTER_TABLE, $subject, '133', $message, $rid) );

	} else {

		$sql = 'INSERT INTO ! ( title, subject, modify, bodytext) VALUES( ?, ?, ?, ? )';
	
		$db->query( $sql, array( ADMIN_LETTER_TABLE, $name, $subject, '133', $message ) );
	}	
}


if( $_POST['frm'] == 'frmDelete' && (int)$_POST['letterid'] ){
	
	$sql = 'DELETE FROM ! WHERE id = ?';
	
	$db->query( $sql, array( ADMIN_LETTER_TABLE, $_POST['letterid'] ) );
	
	header('location: sendletter.php');
	
	exit;
}

if( $_GET['txttitle'] != ''){
	$sql = 'select * from ! where id = ?' ;
	
	$row = $db->getRow( $sql, array( ADMIN_LETTER_TABLE, $_GET['txttitle']  ) );
	
	$t->assign ( 'message' , $row );
	
}

$sql = 'select * from !';

$rs = $db->getAll( $sql, array( ADMIN_LETTER_TABLE ) );

$data = array();

foreach( $rs as $row ) {
	$data[] = $row;
}	

$t->assign ( 'letters', $data );

$sql = 'select id,name from ! ';

$rs = $db->getAll( $sql, array( MEMBERSHIP_TABLE ) );

$data = array();

foreach( $rs as $row ) {
	$data[$row['id']] = $row['name'];
}	

$t->assign ( 'memberships', $data );

$sql = 'select * from ! ';

$rs = $db->getAll( $sql, array( ADMIN_EMAILS_TABLE ) );

$emails = array();

foreach ( $rs as $row ) {
	$emails[$row['id']] = $row['email'];
}

$t->assign ( 'adminemails', $emails );

if ($handle = opendir('../emailimages')) {

	while (false !== ($file = readdir($handle))) {
	
		if ($file != "." && $file != ".." && !is_dir($file) ) {
		
			$ext = substr( $file, -3, 3 );
			
			if ( $ext == 'gif' || $ext == 'jpg'|| $ext == 'bmp' || $ext == 'png' || $ext == 'swf' ){
			
				$imgs[] = $file; 
				
			}
			
		}
	}
	
	closedir($handle); 
	
}
$base_url = 'http://' . $_SERVER['SERVER_NAME'] . DOC_ROOT ;
$t->assign('base_url',$base_url);
$t->assign ( 'images', $imgs );

$t->assign ( 'lang', $lang );

$t->assign('rendered_page', $t->fetch('admin/sendletter.tpl'));

$t->display('admin/index.tpl');
?>