{strip}
<table cellspacing="0" cellpadding="0" border="0" width="290">
	<tr>
		<td class="module_detail_inside">

			<table cellspacing="0" cellpadding="0" border="0" width="100%">
				<tr>
					<td class="module_head">
					{$lang.rate_profile}
					</td>
				</tr>
			</table>

			<form method="post" action="rateuser.php" style="display:online;">
				<input type="hidden" value="{$smarty.get.id}" name="profileid"/>
				<input type="hidden" value="{$smarty.session.UserId}" name="userid"/>
			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" width="100%">
				<tr>
					<td align="center">
						<select name="txtrate">
						{foreach item=item from=$rate_values}
						{if $item == 0}
							<option value="{$item}" selected="selected">{$item}</option>
						{elseif $item == -5}
							<option value="{$item}">{$item}&nbsp;{$lang.worst}</option>
						{elseif $item == 5}
							<option value="{$item}">{$item}&nbsp;{$lang.excellent}</option>
						{else}
							<option value="{$item}">{$item}</option>
						{/if}
						{/foreach}
						</select><br />
						<input type="submit" class="formbutton" value="{$lang.submitrating}"/>
					</td>
				</tr>
			</table>

			<table cellspacing="0" cellpadding="0" border="0" width="100%">
				<tr>
					<td style="vertical-align:middle; width:33%; text-align:left; color:#FF0000;"><b>&nbsp;&nbsp;{$lang.worst}</b></td>
					<td align="center" width="33%" height="25" valign="middle"></td>
					<td style="vertical-align:middle; width:33%; text-align:right; color:#00FF00;"><b>{$lang.excellent}&nbsp;&nbsp;</b></td>
				</tr>
			</table>
			</form>

		</td>
	</tr>
</table>

{/strip}