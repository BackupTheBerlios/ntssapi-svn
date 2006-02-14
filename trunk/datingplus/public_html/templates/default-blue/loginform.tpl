<form name="frmLogin" method="post" action="midlogin.php" onsubmit="javascript: return validateLogin(this);" >
<table width="100%" cellpadding="0" cellspacing="0" border="0">
	<tr>
		<td>
			<b>{$lang.members_login}</b>&nbsp;&nbsp;
			<img src="{$image_dir}blue_box.gif" width="2" height="10" alt="" />
			{$lang.signup_username}&nbsp;&nbsp;&nbsp;&nbsp;
			<input class="input" maxlength="25" name="txtusername" size="8" style='font-size:9pt;width:70px'/>
			{$lang.signup_password}
			<input class="input" type="password" name="txtpassword" size="8" style='font-size:9pt;width:70px'/>
			<input type="submit" value="{$lang.login_submit}" class='formbutton'/>
			<a href='signup.php'>{$lang.register}</a>
		</td>
	</tr>
</table>
</form>
