{strip}
<table width="193" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="190">
			<table width="100%" border="0" cellpadding="0" cellspacing="0" height="23">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="180">
					&nbsp; {$lang.rating}
					</td>
					<td width="7"><img src="{$image_dir}blue_hor2.jpg" height="23"></td>
				</tr>
			</table>
			<table cellspacing="0" cellpadding="0" border="0" bordercolor="#FFFF00" width="184">
				<tr>
					<td align="center">
						<table cellspacing="0" cellpadding="0" border="0" width="100%">
							<tr>
								<td align="center" colspan="11" height="10"></td>
							</tr>
							<tr>
							{foreach item=item from=$rate_values}
								<td width="14" align="right">{$item}</td>
							{/foreach}
							</tr>
							<tr>
								<td align="center" colspan="11" height="12"></td>
							</tr>
		
						{if $is_rated == 1 }
							<tr>
							{if $rating == 0 }
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td bgcolor="{$color}" width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
							{elseif $rating > 0 }
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								{foreach item=item from=$rating_values}
									{if $item <= $rating }
										<td bgcolor="{$color}" width="14">&nbsp;</td>
									{else}
										<td  width="14">&nbsp;</td>
									{/if}
								{/foreach}
							{elseif $rating < 0 }
								{foreach item=item from=$diff_values}
									<td  width="14">&nbsp;</td>
        {/foreach}
								{foreach item=item from=$rating_values}
									{if $item >= $rating }
										<td bgcolor="{$color}" width="14">&nbsp;</td>
									{else}
										<td  width="14">&nbsp;</td>
									{/if}												
								{/foreach}
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
								<td width="14">&nbsp;</td>
				
							{/if}																				
							</tr>
						{elseif $is_rated == 0}
							<tr>
								<td align="center" colspan="11">{$lang.no_rating}</td>
							</tr>
						{/if}
						</table>
					</td>
				</tr>
			</table>
			<br />
		</td>
	</tr>
</table>
{/strip}

