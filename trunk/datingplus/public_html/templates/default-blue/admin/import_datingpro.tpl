{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="702"><a href="import.php" class="subhead">{$lang.manage_import}</a>&nbsp;>&nbsp;{$lang.manage_import_datingpro}</td>
	</tr>
</table>
<br />
{section name=message loop=$messages}
	{$messages[message]}<br>
{/section}
<br />
<center>
<table width="530" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0" height="23">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">{$lang.manage_import_select}</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			<table align="center" width="100%" cellspacing="5" cellpadding="1" border="0">

  				<tr class="table_head">
					<th>{$lang.module}</td>
					<th>{$lang.imported}</td>
					<th>{$lang.action}</td>
				</tr>
				<tr class="oddrow">
					<td>Users</td>
					<td align="right">{$imported.users}</td>
					<td>
						<a href="{$smarty.server.PHP_SELF}?module=users&amp;action=import">{$lang.import}</a>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?module=users">{$lang.empty}</a>
					</td>
				</tr>
				<tr class="evenrow">
					<td>Descriptions</td>
					<td align="right">{$imported.descriptions}</td>
					<td>
						<a href="{$smarty.server.PHP_SELF}?module=descriptions&action=section">{$lang.import}</a>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?module=descriptions">{$lang.empty}</a>
					</td>
				</tr>
				<tr class="oddrow">
					<td>Personalities</td>
					<td align="right">{$imported.personalities}</td>
					<td>
						<a href="{$smarty.server.PHP_SELF}?module=personalities&amp;action=section">{$lang.import}</a>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?module=personalities">{$lang.empty}</a>
					</td>
				</tr>
				<tr class="evenrow">
					<td>Desired Portraits</td>
					<td align="right">{$imported.portraits}</td>
					<td>
						<a href="{$smarty.server.PHP_SELF}?module=portraits&amp;action=section">{$lang.import}</a>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?module=portraits">{$lang.empty}</a>
					</td>
				</tr>
				<tr class="oddrow">
					<td>Interests</td>
					<td align="right">{$imported.interests}</td>
					<td>
						<a href="{$smarty.server.PHP_SELF}?module=interests&amp;action=section">{$lang.import}</a>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?module=interests">{$lang.empty}</a>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</center>
{/strip}