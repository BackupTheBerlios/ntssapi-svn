{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe()
{ldelim}
	if (document.bannerfrm.txtbanner.value == '' || document.bannerfrm.txtlinkurl.value == ''  ){ldelim}
		alert("{$lang.errormsgs[20]}");
		return false;
	{rdelim}
	document.bannerfrm.submit();
{rdelim}
/* ]]> */
</script>
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
<table width="550" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.add_banners}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

      <form name="bannerfrm" action="savebanner.php" method="post" enctype="multipart/form-data">
			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550">
			{if $smarty.get.errid > 0 }
			    <tr><td>&nbsp;</td><td>{$lang.banner_error_msgs[$smarty.get.errid]}</td></tr>
			{/if}
			    <tr> <td>{$lang.banner}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td><td><input type="file" name="txtbanner" size="35" /></td></tr>
			    <tr> <td>{$lang.linkurl}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td><td>http://<input type="text" name="txtlinkurl" size="28" /></td></tr>
			    <tr> <td>{$lang.tooltip}</td><td><input type="text" name="txttooltip" size="35" /></td></tr>
			    <tr> <td>{$lang.startdate}</td><td>{html_select_date_translated prefix="txtstart" end_year="+10" }</td></tr>
			    <tr> <td>{$lang.enddate}</td><td>{html_select_date_translated prefix="txtend" end_year="+10" }</td></tr>
				<tr><td colspan="2" align="center"><br /><input type="button" class="formbutton" value="{$lang.submit}" onclick="javascript: checkMe();" /></td></tr>
			</table>
    </form>
		</td>
	</tr>
</table>
</center>
{/strip}
