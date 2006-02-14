{strip}
<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td width="100%" align="center" class="module_detail">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head">
					{$lang.members_login}
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
				<tr>
					<td width="100%">
						{if $login_error != ''}
							<font color="{$lang.error_msg_color}">{$login_error}</font>
							<br/><br />
						{elseif $smarty.get.err == 200 }
							{ include file="completereg.tpl" }
						{/if}
            <form name="frmLogin" method="post" action="midlogin.php" onsubmit="javascript: return newvalidateLogin(this);" >
						<table class="table" cellspacing="{$config.cellspacing}"  cellpadding="{$config.cellpadding}" border="0">
							<tr>
								<td><span class='text8pt'>{$lang.signup_username}</span></td>
								<td><input class="input" maxlength="25" name="txtusername" size="15" />
								&nbsp;&nbsp;
								<input type="checkbox" name="rememberme"/> Remember Me
								</td>
							</tr>
							<tr>
								<td><span class='text8pt'>{$lang.signup_password}</span></td>
								<td><input class="input" type="password" name="txtpassword" size="15"/>
								&nbsp;&nbsp;&nbsp;
								<a href="forgotpass.php">{$lang.site_links.forgot}</a></td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" value="{$lang.login_submit}"  class='formbutton'/>
								&nbsp;&nbsp;<a href="signup.php">{$lang.register_now}</a> </td>
							</tr>
						</table>
            </form>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
