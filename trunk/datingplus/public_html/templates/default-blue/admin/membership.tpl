{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe()
{ldelim}
	if (document.frm2.txtname.value == '' || document.frm2.txtprice.value == '' ){ldelim}
		alert("{$lang.errormsgs[20]}");
		return false;
	{rdelim}
	document.frm2.modify.value="{$lang.modify}";
	document.frm2.submit();
{rdelim}
/* ]]> */
</script>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.manage_membership}</td>
	</tr>
</table>
<br />
<center>
<table cellspacing="0" cellpadding="0" width="550" border="0" align="left">
<tbody>
	<tr>
		<td align="center">
			<form name="frm" action="membership.php" method="post">
			<table width="530" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail_inside" width="100%">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="526">
									{$lang.membership_types}:
									</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
						<table border="0" width="530"  cellpadding="1" cellspacing="2">
						<tbody>
					{foreach item=item key=key from=$memberships}
						{if $data.roleid == $key}
							<tr><td><input type="radio" name="membership" value="{$key}" onclick="javascript: document.frm.submit();" checked="checked" />{$item}</td></tr>
						{else}
							<tr><td><input type="radio" name="membership" value="{$key}" onclick="javascript: document.frm.submit();" />{$item}</td></tr>
						{/if}
					{/foreach}
						</tbody>
						<tr><td></td></tr>
						<tr><td><a href="addmship.php">{$lang.add_membership}</a></td>
						</tr>
						</table>
					</td>
				</tr>
			</table>
			</form>
		</td>
	</tr>
	<tr><td>&nbsp;</td></tr>
	<tr><td>&nbsp;</td></tr>
	<tr>
		<td align="center">
			<table width="530" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail_inside" width="100%">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="526">
									{$lang.privileges_msg}:
									</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
            <form name="frm2" method="post" action="membership.php">
              <input type="hidden" value="{$data.roleid}" name="mshipid" />
              <input type="hidden" value="{$data.id}" name="id" />
						<table width="530" border="0" cellpadding="1" cellspacing="2" >
							<tbody>
								{foreach from=$lang.privileges key=key item=item}
								{if $key != 'activedays' }
								<tr  class="{cycle values="oddrow,evenrow"}">
									<td width="60%">{$item}</td>
									<td width="40%">{if $key=='uploadpicturecnt'}
										&nbsp;<input type="text" size="4" name="{$key}" value="{$data[$key]}" />
										{else}
										<input type="checkbox" name="{$key}" {if $data[$key] eq '1'}checked="checked"{/if} />
										{/if}
										</td>
								</tr>
								{/if}
								{/foreach}
								<tr  class="evenrow">
									<td colspan="2">
										<table width="530" cellpadding="0" cellspacing="0">
											<tr>
												<td width="60%">{$lang.name}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
												<td width="40%">&nbsp;<input type="text" value="{$data.name}" name="txtname" size="10" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr  class="oddrow">
									<td colspan="2">
										<table width="530" cellpadding="0" cellspacing="0">
											<tr>
												<td width="60%">{$lang.price}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
												</td>
												<td width="40%">&nbsp;<input type="text" value="{$data.price}" name="txtprice" size="10" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr  class="evenrow">
									<td colspan="2">
										<table width="530" cellpadding="0" cellspacing="0">
											<tr>
												<td width="60%">{$lang.currency}</td>
												<td width="40%">&nbsp;<select name="txtcurrency">{html_options options=$lang.support_currency selected=$data.currency}</select></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr  class="oddrow">
									<td colspan="2">
										<table width="530" cellpadding="0" cellspacing="0">
											<tr>
												<td width="60%">{$lang.active_days}:</td>
												<td width="40%">&nbsp;<select name="activedays">{html_options options=$lang.activedays_array selected=$data.activedays}</select></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td align="center" colspan="2">
										<br />
										<input name="modify" type="hidden" value="" />
										<input type="button" class="formbutton" value="{$lang.modify}" onclick="javascript:checkMe();" />&nbsp;
									{if $data.roleid != 3}
										<input type="submit" class="formbutton" value="{$lang.delete_selected}" name="delete" />&nbsp;
										{if $data.enabled == 'N'}
										<input type="submit"  class="formbutton" value="{$lang.enable_selected}" name="enable" />
										{elseif $data.enabled == 'Y'}
										<input type="submit" class="formbutton" value="{$lang.disable_selected}" name="disable" />
										{/if}
									{/if}
									</td>
								</tr>
							</tbody>
						</table>
            </form>
					</td>
				</tr>
			</table>
			<br />
		</td>
	</tr>
</tbody>
</table>
</center>
{/strip}