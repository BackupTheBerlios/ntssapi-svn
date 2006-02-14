{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.seo_head}</td>
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
					{$lang.sef_msg|escape:htmlall}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form action="saveseo.php" method="post">
			<table cellspacing="0" cellpadding="0" width="550">
		  	<tbody>
				<tr>
					<td>&nbsp;{$lang.seo_enable}</td>
				{if $enable_mod_rewrite == 'N' }
					<td><input type="radio" name="txtseo" value="Y" onclick="javascript: alert( '{$lang.yes_msg}');" />{$lang.yes}</td>
					<td><input type="radio" name="txtseo" value="N" checked="checked" />{$lang.no}</td>
				{elseif $enable_mod_rewrite == 'Y' }
					<td><input type="radio" name="txtseo" value="Y" checked="checked" onclick="javascript: alert( '{$lang.yes_msg}');" />{$lang.yes}</td>
					<td><input type="radio" name="txtseo" value="N" />{$lang.no}</td>
				{/if}
				</tr>
				<tr><td colspan="3">&nbsp;</td></tr>
				<tr><td colspan="3">&nbsp;</td></tr>
				<tr>
					<td colspan="3">
						<table width="550" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="526">
									{$lang.page_tags_msg|escape:html}
								</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="3">
						<table>
							<tr>
								<td>{$lang.title_colon}</td>
								<td><input type="text" name="txttitle" value="{$site_title}" size="50" /></td>
								<td>{$lang.max_255}</td>
							</tr>
							<tr><td colspan="3">&nbsp;</td></tr>
							<tr>
								<td valign="top">{$lang.description}</td>
								<td><textarea name="txtdesc" cols="50" rows="5">{$meta_description|stripslashes}</textarea></td>
								<td>{$lang.max_255}</td>
							</tr>
							<tr><td colspan="3">&nbsp;</td></tr>
							<tr>
								<td valign="top">{$lang.keywords}</td>
								<td><textarea name="txtkeyword" cols="50" rows="5">{$meta_keywords|stripslashes}</textarea></td>
								<td>{$lang.max_255}</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr><td align="center" colspan="3">	<br /><input type="submit" class="formbutton" value="{$lang.modify}" /></td></tr>
	  		</tbody>
			</table>
      </form>
			<br />
		</td>
	</tr>
</table>
</center>
<br />
{/strip}