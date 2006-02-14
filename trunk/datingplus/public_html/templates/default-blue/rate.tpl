{strip}
<br />
<table width="600" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0" height="23">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.rate_profile}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			<form method="post" action="rateuser.php">
				<input type="hidden" value="{$smarty.get.id}" name="profileid"/>
				<input type="hidden" value="{$smarty.session.UserId}" name="userid"/>
			<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
				<tr>
					<td><b>{$lang.worst}</b></td>
					<td>&nbsp;</td>
				{foreach item=item from=$rate_values}
					{if $item == 0}
					<td><input type="radio" name="txtrate" value="{$item}" checked="checked"/><b>{$item}</b></td>
					{else}
					<td><input type="radio" name="txtrate" value="{$item}"/><b>{$item}</b></td>
					{/if}
				{/foreach}
					<td>&nbsp;</td>
					<td><b>{$lang.excellent}</b></td>
				</tr>
			</table>
			<table width="600" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td align="center"><input type="submit" class="formbutton" value="{$lang.submitrating}"/></td>
				</tr>
			</table>
			</form>
			<br />
		</td>
	</tr>
</table>

{/strip}
