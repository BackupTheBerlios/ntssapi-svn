{strip}
{include file="popheader.tpl"}
<center>
<table width="573" border="0" cellpadding="0" cellspacing="0" >
	<tr>
	<td class="module_detail_inside" width="100%" height="350" valign="top">

	<table width="573" border="0" cellpadding="0" cellspacing="0">
		<tr>
			<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
			<td class="module_head" width="496">
				{$lang.view_poll_archive}
			</td>
		</tr>
	</table>
	<table class="table" width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
	{foreach item=row from=$data}
		<tr>
			<td><a href="javascript:openWin({$row.pollid})">{$row.question}</a></td>
		</tr>
	{foreachelse}
		<tr><td>{$lang.no_previous_polls}</td></tr>
	{/foreach}

</table>

	{if $config.use_popups == 'Y'}
	<tr>
	<td colspan="3">
		<center><a href="javascript:window.close();" class="closelink">{$lang.close}</a></center>
	</td>
	</tr>
	{/if}
</td>
</tr>
</table>
</center>
{include file="popfooter.tpl"}
{/strip}
