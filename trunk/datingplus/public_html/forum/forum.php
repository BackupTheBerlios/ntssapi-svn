<?php
define('IN_PHPBB', true);
$phpbb_root_path = './';
include($phpbb_root_path . 'extension.inc');
include($phpbb_root_path . 'common.'.$phpEx);

//
// Set page ID for session management
//
$userdata = session_pagestart($user_ip, PAGE_LOGIN);
init_userprefs($userdata);
//
// End session management
//

if( $userdata['session_logged_in'] ) 
   { 
	session_end($userdata['session_id'], $userdata['user_id']);
   } 

/*	if ( !defined( 'SMARTY_DIR' ) )
		include_once( '../init.php' );
*/

	include_once( '../config.php' );
	
	include_once( '../sessioninc.php' );
	
	if ( !hasRight( 'forum' ) ) {
		header( 'location:../payment.php?right=1&feature=forum' );
		exit;
	}	

	$sql = "SELECT  username, password FROM " . USER_TABLE .
			" where id='". $_SESSION['UserId'] .
			 "' AND status = 'Active'";

	$row = $db->sql_fetchrow ( $sql );
				
?>
<html>
<head>
</head>
<body onLoad="javascript: document.frmLogin.submit();">
<form action="forumlogin.php" method="post" name="frmLogin">
<input type="hidden" name="username" size="25" maxlength="40" value="<?=$row['username']?>" />
<input type="hidden" name="password" size="25" maxlength="32" value="<?=$row['password']?>" />
<input type="hidden" name="autologin" />
<input type="hidden" name="redirect" value="" />
<input type="hidden" name="login" class="mainoption" value="1" />
</form>
</body>
</html>
