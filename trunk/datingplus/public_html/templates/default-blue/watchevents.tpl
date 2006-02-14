{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.watched_events}
					</td>
				</tr>
			</table>

			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
				<tbody>
				{if $error == 1 }
					<tr>
						<td colspan="2">{$lang.no_record_found}</td>
					</tr>
				{else}
					<!--tr><td colspan="2">&nbsp;</td></tr-->
					<tr>
						<td>
							{foreach from=$events item=item}
								{include file="eventresultviewsmall.tpl"}
							{/foreach}
						</td>
					</tr>
				{/if}

				</tbody>
			</table>
		</td>
	</tr>
</table>
{/strip}
