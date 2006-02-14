{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.manage_admin_permissions}</td>
	</tr>
</table>
<br />
<center>
<table cellspacing="0" cellpadding="0" width="550" border="0" align="left">
<tbody>
	<tr>
		<td align="center">
			<form name="frm" action="adminpermissions.php" method="post">

			<table width="530" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail_inside" width="100%">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="526">
									{$lang.admin_users}					
									</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
						<table border="0" width="530"  cellpadding="1" cellspacing="2">
						<tbody>
				{if $admins|@count == 0}
							<tr><td>{$lang.no_admin_user_msg1}</td></tr>
							<tr><td>{$lang.no_admin_user_msg2}&nbsp;<a href="adminins.php">{$lang.click_here}</a>.</td></tr>
				{else}
					{foreach item=item key=key from=$admins}
						{if $data.adminid == $key}
							<tr><td><input type="radio" name="adminid" value="{$key}" onclick="javascript: document.frm.submit();" checked="checked" />{$item}</td></tr>
						{else}
							<tr><td><input type="radio" name="adminid" value="{$key}" onclick="javascript: document.frm.submit();" />{$item}</td></tr>
						{/if}
					{/foreach}
			{/if}
							<tr><td>&nbsp;</td></tr>
						</tbody>
						</table>
					</td>
				</tr>
			</table>
			</form>
		</td>
	</tr>
	<tr><td>&nbsp;</td></tr>
{if $admins|@count > 0}
	<tr>
		<td align="center">
			<table width="530" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail_inside" width="100%">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="526">
									{$lang.permissions}
									</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
            <form name="frm2" method="post" action="adminpermissions.php">
              <input type="hidden" value="{$data.adminid}" name="adminid" />
              <input type="hidden" value="{$data.id}" name="id" />
						<table width="530" border="0" cellpadding="1" cellspacing="2" >
						<tbody>
					{foreach item=item key=key from=$data}
						{if $key != id && $key != adminid}
							<tr class="{cycle values="oddrow,evenrow"}">
								<td>{$lang.admin_rights[$key]}</td>
							{if $item == 1}
								<td><input type="checkbox" name="{$key}" checked="checked" /></td>
							{else}
								<td><input type="checkbox" name="{$key}" /></td>
							{/if}
							</tr>
						{/if}
					{/foreach}
							<tr>
								<td align="center" colspan="2">
								<input type="submit" class="formbutton" name="modify" value="{$lang.modify}" />
								</td>
							</tr>
						</tbody>
						</table>
            </form>
					</td>
				</tr>
			</table>
    </td>
	</tr>
{/if}
</tbody>
</table>
</center>
{/strip}