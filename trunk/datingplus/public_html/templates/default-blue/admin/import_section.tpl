{strip}
<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0>
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" /></td>
		<td class="module_head" width="702"><a href="import.php" class="subhead">{$lang.manage_import}</a>&nbsp;>&nbsp;{$lang.select_section}</td>
	</tr>
</TABLE>
<BR />
<BR />
{$message}
<CENTER>
<TABLE WIDTH=530 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td class="module_detail_inside" width="100%">
			<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">{$lang.select_section}</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
				</tr>
			</TABLE>

			<form action="{$smarty.section.PHP_SELF}" method="post">
				<input type="hidden" name="module" value="{$smarty.request.module}" />
				<input type="hidden" name="action" value="import" />
			<table class=table cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} width=550 border=0>
	  		<tbody>
	 			<tr>
	  				<td>{$lang.section}</td>
	  				<td><select name="section_id">
						{section name=section loop=$sections}
							<option value="{$sections[section].id}">{$sections[section].section}</option>
						{/section}
						</select>
					</td>	  
	 			</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<input type="submit" class="formbutton" value="{$lang.submit}" />&nbsp;
						<input type="reset" class="formbutton" value="{$lang.reset}" />			
					</td>
				</tr>
  			</tbody>
			</table>
			</form>
		</td>
	</tr>
</TABLE>
</CENTER>
{/strip}