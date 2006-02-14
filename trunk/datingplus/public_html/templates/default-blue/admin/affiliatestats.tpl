{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.aff_stats}</td>
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
						{$lang.total_affiliates}:&nbsp;{$data|@count}</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" align="center" width="530">
				<tr class="table_head">
					<th>{$lang.col_head_srno}</th>
					<th nowrap><a href="?sort={$lang.col_head_name}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}">{$lang.col_head_name}</a></th>
					<th nowrap align="center">{$lang.total_referals}</th>
					<th nowrap align="center">{$lang.regis_referals}</th>
				</tr>
				{assign var="n" value="$upr"}
			{foreach item=item key=key from=$data}
				{math equation="$n+1" assign="n"}
				<tr class="{cycle values="oddrow,evenrow"}">
					<td>{$n}</td>
					<td nowrap >{$item.name}</td>
					<td nowrap align="center">{$item.totalref}</td>
					<td nowrap align="center">{$item.regref}</td>
				</tr>
			{/foreach}
				<tr><td colspan="6">&nbsp;</td></tr>
				<tr>
					<td align="center" colspan="6">
					{assign var="pageno" value=$smarty.get.offset}
					{if $pageno == ""}{assign var="pageno" value=1}{/if}

					{if $pageno != "1"}
						<a href="?offset={$pageno-1}&amp;{$querystring}">{$lang.previous}</a>&nbsp;
					{else}
					{/if}

					{if $data|@count >= $config.page_size}
						<a href="?offset={$pageno+1}&amp;{$querystring}">{$lang.next}</a>&nbsp;
					{else}
					{/if}
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</center>
{/strip}