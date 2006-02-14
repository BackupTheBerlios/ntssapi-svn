{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">
		<table><tr class="table_head"><td><a href="managebanner.php" class="subhead">{$lang.manage_banners}</a></td></tr></table>
		</td>
	</tr>
</table>
<br />
<center>
<form name="bannerfrm" action="modifybanner.php" method="post" enctype="multipart/form-data">
<table width="550" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.edit_banners}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			<input type="hidden" value="{$data.id}" name="txtid" />
			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550">
						  	<tr><td align="center" colspan="2">
				{if $data.type == 'jpg' || $data.type == 'gif' || $data.type == 'bmp'|| $data.type == 'png' }
					  	<img src="{$banner_dir}{$data.name}" width="{$data.width}" height="{$data.height}" alt="" />
					  	<br /><a href="{$data.linkurl}" target="_blank">{$data.linkurl}</a>
				{else}
					<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0'>
					<param name='movie' value="{$banner_dir}{$data.name}">
					<param name='quality' value='high'>
					<embed src="{$banner_dir}{$data.name}" quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed></object>
				  	<br /><a href="http://{$data.linkurl}" target="_blank">{$data.linkurl}</a>
				{/if}
					</td>
				</tr>
			</table>

			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550">
			{if $smarty.get.errid > 0}
    			<tr><td>&nbsp;</td>
    				<td>{$lang.banner_error_msgs[$smarty.get.errid]}</td>
    			</tr>
			{/if}
    			<tr> <td valign="top">{$lang.banner}</td>
					 <td><input type="file" name="txtbanner" size="35" /></td>
				</tr>

				<tr> <td>{$lang.linkurl}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
					<td><input type="text" name="txtlinkurl" size="35" value="{$data.linkurl}" /></td>
				</tr>
				<tr> <td>{$lang.tooltip}</td>
					<td><input type="text" name="txttooltip" size="35" value="{$data.tooltip}" /></td>
				</tr>
				<tr> <td>{$lang.startdate}</td>
					<td>{html_select_date_translated prefix="txtstart"  time=$data.startdate end_year="+10" }</td>
				</tr>
				<tr> <td>{$lang.enddate}</td>
					<td>{html_select_date_translated prefix="txtend"  time=$data.expdate end_year="+10"}</td>
				</tr>
				<tr><td colspan="2" align="center"><br/><input type="submit" class="formbutton" value="{$lang.modify}" /></td></tr>
			</table>
		</td>
	</tr>
</table>
</form>
</center>
{/strip}