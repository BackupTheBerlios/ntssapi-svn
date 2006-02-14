{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" >
						Top {$psize}
					</td>
				</tr>
			</table>

			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" >
			<tbody>
				{if $error == 1 }
					<tr>
						<td colspan="2">{$lang.no_record_found}</td>
					</tr>
				{else}
					<tr><td colspan="2" align="center"><br /><h2>{$config.site_name}&nbsp;Top&nbsp;10</h2><br /></td></tr>
					<tr>
						<td align="left">
							<table border="0">
							{assign var="ccount" value="0"}
							{foreach item=item key=key from=$data}
								{if $item.id > 0}
								{if $ccount==0}
									<tr>
								{/if}
									<td align="left">{include file="userresultviewsmall.tpl"}</td>
								{if $ccount==1}
									</tr>
								{/if}
								{math equation="$ccount+1" assign="ccount"}
								{math equation="$ccount%2" assign="ccount"}
								{/if}
							{/foreach}
							</table>
						</td>
					</tr>
				{/if}
			</tbody>
			</table>
		</td>
	</tr>
</table>
{/strip}
