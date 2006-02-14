{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe(frm) {ldelim}
	if (frm.txtname.value == '' || frm.txtprice.value == '') {ldelim}
		alert("{$lang.errormsgs.20}");
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
		<table><tr class="table_head"><td><a href="membership.php" class="subhead">{$lang.manage_membership}</a></td></tr></table>
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
					{$lang.add_membership}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form name="mshipfrm" action="savemship.php" method="post" onsubmit="javascript: return checkMe(this);">
			<table width="550" border="0" cellspacing="2" cellpadding="1">
			{if $smarty.get.errid > 0 }
    			<tr><td>&nbsp;</td><td><span class="errors">{$lang.mship_errors[$smarty.get.errid]}</span></td>
    			</tr>
			{/if}
				<tr class="oddrow">
					<td width="40%">{$lang.name}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
					<td width="60%">
						<input type="text"  name="txtname" size="20" />
					</td>
				</tr>
				<tr class="evenrow">
					<td>{$lang.price}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
					<td width="60%">
						<input type="text" name="txtprice" size="4" />
					</td>
				</tr>
				<tr class="oddrow">
					<td>{$lang.currency}</td>
					<td width="60%">
						<select name="txtcurrency">
						{html_options options=$lang.support_currency selected=$data.currency}
						</select>
					</td>
				</tr>
				<tr><td colspan="2">
					<table width="550" border="0" cellspacing="2" cellpadding="1">
					<tbody>
						{foreach from=$lang.privileges key=key item=item}
						<tr class="{cycle values="evenrow,oddrow"}">
							<td width="235">{$item}</td>
							<td width="350"><input type="checkbox" name="{$key}" /></td>
						</tr>
						{/foreach}
					</tbody>
					</table>
					</td>
				</tr>
				<tr><td colspan="2">&nbsp;</tr>
				<tr><td align="center">
					<input type="submit" class="formbutton" value="{$lang.submit}" /></td>
					<td>&nbsp;</td>
				</tr>
			</table>
      </form>
		</td>
	</tr>
</table>
</center>
{/strip}
