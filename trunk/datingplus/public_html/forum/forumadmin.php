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
	 
	include_once( '../admin/sessioninc.php' );

	include_once( '../config.php' );
	
/*	if ( !defined( 'SMARTY_DIR' ) ) {
	
		include_once( '../init.php' );
	
	}
*/
	$sql = "SELECT  username, password FROM " . ADMIN_TABLE .
			" where id='". $_SESSION['AdminId'] . "'";
		
	$row = $db->sql_fetchrow( $sql );
	
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
