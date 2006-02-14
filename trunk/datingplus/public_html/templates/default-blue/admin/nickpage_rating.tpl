{strip}
<div align="center">
<table cellspacing="0" cellpadding="0" border="0" align="center" width="290">
	<tr>
		<td class="module_detail_inside">

			<table cellspacing="0" cellpadding="4" border="0" width="100%">
				<tr>
					<td class="module_head">
						{$lang.rating}
					</td>
				</tr>
			</table>

			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" width="100%">
			{if $is_rated == 1}
				<tr>
					<td>
						<div style="text-align:right;">
						<table cellspacing="0" cellpadding="0" border="0" align="right">
							<tr>
								{foreach item=item from=$rate_values}
								<td style="height:0px; width:25px; text-align:center;">{$item}</td>
								{/foreach}
							</tr>
						</table>
						</div>
					</td>
				</tr>
			{/if}

				<tr>
					<td>

						<div style="text-align:right;">
						<table cellspacing="0" cellpadding="0" border="0" align="center">
						{if $is_rated == 1}
							<tr>
							{if $rating == 0 }
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center; color:{$color};">&#8226;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
							{elseif $rating > 0 }
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center; color:{$color};">&#8226;</td>
								{foreach item=item from=$rating_values}
									{if $item <= $rating }
										<td style="height:5px; width:25px; text-align:center; color:{$color};">&#8226;</td>
									{else}
										<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
									{/if}
								{/foreach}
							{elseif $rating < 0 }
								{foreach item=item from=$rating_values}
									{if $item >= $rating }
										<td style="height:5px; width:25px; text-align:center; color:{$color};">&#8226;</td>
									{else}
										<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
									{/if}
								{/foreach}
								<td style="height:5px; width:25px; text-align:center; color:{$color};">&#8226;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
								<td style="height:5px; width:25px; text-align:center;">&nbsp;</td>
							{/if}
							</tr>
						{elseif $is_rated == 0}
							<tr>
								<td align="center" {if $is_rated == 1}colspan="20"{/if} style="width:100%; text-align:center;"><div align="center" style="text-align: center; padding-bottom: 5px;"><b>{$lang.no_rating}</b></div></td>
							</tr>

						{if $smarty.session.UserId != '' && $smarty.session.UserId != $user.id && $has_rated == 0 }
							<tr>
								<td align="center" {if $is_rated == 1}colspan="20"{/if}>

								<form method="post" action="rateuser.php" style="display:inline;">
								<input type="hidden" value="{$smarty.get.id}" name="profileid"/>
								<input type="hidden" value="{$smarty.session.UserId}" name="userid"/>
								<table cellspacing="0" cellpadding="0" border="0" width="100%">
									<tr><td align="center">
									<select name="txtrate">
										{foreach item=item from=$rate_values}
										{if $item == 0}
										<option value="{$item}" selected="selected">{$item}</option>
										{elseif $item == -5}
										<option value="{$item}">{$item}&nbsp;({$lang.worst})</option>
										{elseif $item == 5}
										<option value="{$item}">{$item}&nbsp;({$lang.excellent})</option>
										{else}
										<option value="{$item}">{$item}</option>
										{/if}
										{/foreach}
									</select>&nbsp;&nbsp;
									<input type="submit" class="formbutton" value="{$lang.submitrating}"/>
									</td></tr>
								</table>
								</form>

								</td>
							</tr>
						{/if}

						{/if}
						</table>
						</div>


					</td>
				</tr>
			</table>

	</tr>
</table>
</div>
{/strip}