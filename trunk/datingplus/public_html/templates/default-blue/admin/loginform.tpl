{strip}
<script type="text/javascript">
/* <![CDATA[ */
  document.frmlogin.txtusername.focus();
/* ]]> */
</script>

<br /><br /><br /><br /><br /><br />
<center>
<font color="{$lang.error_msg_color}">{$login_error}</font><br/><br/>
	<table width="178" border="0" cellpadding="0" cellspacing="0" >
		<tr>
			<td class="module_detail" width="178" valign="top">

				<table width="178" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td class="module_head" width="6"></td>
						<td class="module_head" width="150">
							{$lang.admin_login_msg}
						</td>
						<td width="22"><img src="{$image_dir}blue_small_hor.jpg" width="22" height="23"></td>
					</tr>
				</table>
        <form name="frmlogin" method="post" action="midlogin.php">
				<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
					<tr>
						<td><span class='text8pt'>{$lang.signup_username}</span></td>
						<td><input class="input" maxlength="25" name="txtusername" size="8" style='font-size:9pt;width:75px'></td>
					</tr>
					<tr>
						<td><span class='text8pt'>{$lang.signup_password}</span></td>
						<td><input class="input" type="password" name="txtpassword" size="8" style='font-size:9pt;width:75px'></td>
					</tr>
					<tr>
						<td></td>
						<td><input type="submit" value="{$lang.login_submit}" class='formbutton'></td>
					</tr>
				</table>
      </form>
			</td>
		</tr>
	</table>
</center>
{/strip}
