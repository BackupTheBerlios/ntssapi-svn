{strip}
<table width="550" border="0" cellpadding="0" cellspacing="0"  >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="501">
						{$lang.permitmsg_3}
					</td>
					<td class="module_head_right" width="25">
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			<table id="div_hide_mcomp" style="display: inline" width="100%" border="0" cellspacing="{$config.cellspacing}"  cellpadding="{$config.cellpadding}">
				<tr>
					<td width="100%">
						<table width="550" cellspacing="{$config.cellspacing}"  cellpadding="{$config.cellpadding}" align="center" border="0" >
							<tr class="table_head">
								<th align="center">{$lang.privileges_msg}</th>
							{foreach item=item key=key from=$memberships}
								<th >{$item}</th>
							{/foreach}
							</tr>
							{foreach from=$m_row key=key item=row}
								{if $key ne 'price' and $key ne 'currency'}
							<tr>
								<td>
									{$lang.privileges[$key]}
								</td>
								{foreach item=item from=$row key=key1}
								<td align="center">
									{if $key == 'activedays' or $key == 'uploadpicturecnt'}
										{$item}
									{elseif $item == 1} <img src="{$image_dir}tick.jpg" border="0" alt="" /> {else} <img src="{$image_dir}cross.jpg" border="0" alt="" /> {/if}
								</td>
								{/foreach}
							</tr>
								{/if}
							{/foreach}
							<tr><td colspan="4">&nbsp;</td></tr>
							<tr class="table_head">
								<th>{$lang.price}</th>
							{section name=item loop=$m_row.price}
								<th>
									{if $m_row.currency[item] == 'USD' }
									$
									{elseif $m_row.currency[item] == 'EUR' }

									{/if}

									{$m_row.price[item]}
								</th>
							{/section}
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
