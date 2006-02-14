{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe()
{ldelim}
	if (document.frmChangePass.txtoldpwd.value == '' || document.frmChangePass.txtconpwd.value == '' || document.frmChangePass.txtnewpwd.value == '' ){ldelim}
		alert("{$lang.errormsgs[20]}");
		return false;
	{rdelim}
	if (document.frmChangePass.txtnewpwd.value != document.frmChangePass.txtconpwd.value) {ldelim}
		alert("{$lang.errormsgs[18]}");
		return false;
	{rdelim}
	return true;
{rdelim}
/* ]]> */
</script>
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">
			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.change_password}
					</td>
				</tr>
			</table>
			{if $pwd_change_error != ''}
			<table class="table" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
				<tr>
					<td>
						<font color="{$lang.error_msg_color}">{$pwd_change_error}</font>
					</td>
				</tr>
			</table>
			{/if}
      <form action="modifympass.php" name="frmChangePass" method="post">
			<table class="table" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
				<tbody>
				<tr>
					<td>{$lang.old_password}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
					<td><input type="password" name="txtoldpwd" maxlength="20" size="15"/></td>
				</tr>
				<tr>
					<td>{$lang.new_password}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
					<td><input type="password" name="txtnewpwd" maxlength="20" size="15"/></td>
				</tr>
				<tr>
					<td>{$lang.confirm_password}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
					<td><input type="password" name="txtconpwd" maxlength="20" size="15"/></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					 <td><input type="submit" class="formbutton" value="{$lang.change}" onclick="return checkMe();"/></td>
				</tr>
				</tbody>
			</table>
      </form>
		</td>
	</tr>
</table>
{/strip}
