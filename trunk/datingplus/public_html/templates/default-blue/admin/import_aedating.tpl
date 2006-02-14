{strip}
<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" /></td>
		<td class="module_head" width="702"><a href="import.php" class="subhead">{$lang.manage_import}</a>&nbsp;>&nbsp;{$lang.manage_import_aedating}</td>
	</tr>
</TABLE>
<BR />
{section name=message loop=$messages}
	{$messages[message]}<br>
{/section}
<BR />
<CENTER>
<TABLE WIDTH=530 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td class="module_detail_inside" width="100%">
			<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">{$lang.manage_import_select}</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
				</tr>
			</TABLE>

			<table align="center" width="100%" cellspacing="5" cellpadding="1" border="0">
				
  				<tr class="table_head">
					<th>{$lang.module}</th>
					<th>{$lang.imported}</th>
					<th>{$lang.action}</th>		
				</tr>
				<tr class="oddrow">
					<td>Users</td>
					<td align="right">{$imported.users}</td>
					<td>
						<a href="{$smarty.server.PHP_SELF}?module=users&amp;action=import">{$lang.import}</a>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?module=users">{$lang.empty}</a>
					</td>
				</tr>
{section name=field_array loop=$importing_fields}
				<tr class="evenrow">
					<td>{$importing_fields[field_array].question}</td>
					{assign var=section value=$importing_fields[field_array].section}
					<td align="right">{$imported[$section]}</td>
					<td>
						<a href="{$smarty.server.PHP_SELF}?module={$importing_fields[field_array].section}&amp;action=section">{$lang.import}</a>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?module={$importing_fields[field_array].section}">{$lang.empty}</a>
					</td>
				</tr>
{/section}


			</table>
		</td>
	</tr>
</TABLE>
</CENTER>
{/strip}