{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe(form)
{ldelim}
	if (form.txtoldpwd.value == '' || form.txtconpwd.value == '' || form.txtnewpwd.value == '' ){ldelim}
		alert("{$lang.errormsgs[20]}");
		return false;
	{rdelim}
	if (form.txtnewpwd.value != form.txtconpwd.value) {ldelim}
		alert("{$lang.errormsgs[18]}");
		return false;
	{rdelim}
	return true;
{rdelim}
/* ]]> */
</script>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">
		{$lang.change_password}
		</td>
	</tr>
</table>
<br />
<center>

<table width="550" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
						{$lang.change_password}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form action="modifypwd.php" method="post" name="frmAdmin" onsubmit="javascript: return checkMe(this);">
        <input type="hidden" name="txtid" value="{$smarty.session.AdminId}" />
			<table width="540" border="0"  cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}"  align="center">
			<tbody>
    			<tr>
      				<td colspan="2">{if $pwd_change_error ne ""}<font color="{$lang.admin_error_color}">{$pwd_change_error}</font>{/if}</td>
    			</tr>
	 			<tr>
	  				<td width="25%">{$lang.old_password}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
	  				<td><input type="password" maxlength="32" size="32" name="txtoldpwd" /></td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.new_password}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
	  				<td><input type="password" maxlength="32" size="32" name="txtnewpwd" /></td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.confirm_password}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
	  				<td><input type="password" maxlength="32" size="32" name="txtconpwd" /></td>
	 			</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<input type="submit" class="formbutton" value="{$lang.modify}" />
					</td>
				</tr>
  			</tbody>
			</table>
      </form>
		</td>
	</tr>
</table>
</center>
{/strip}