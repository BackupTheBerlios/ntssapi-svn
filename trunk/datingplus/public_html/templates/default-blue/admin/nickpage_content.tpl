{if $found == 1}
		<table cellspacing="0" cellpadding="0" border="0" width="100%">
			{assign var="ccount" value="0"}
			{foreach item=item from=$pref}
			{if $ccount == 0}
				<tr>
					<td align="center" valign="top">
					{include file="nickpage_section.tpl"}
					</td>
				</tr>
			{elseif $ccount == 1}
				<tr>
					<td align="center" valign="top">
					{include file="nickpage_section.tpl"}
					</td>
				</tr>
			{/if}
			
				<tr>
				<td>&nbsp;</td>
				</tr>
			{math equation="$ccount+1" assign="ccount"}
			{math equation="$ccount%2" assign="ccount"}
			
			{/foreach}
		</table>
{else}

	{if $smarty.session.UserId != '' && $smarty.session.UserId == $smarty.get.id}
		<table cellspacing="0" cellpadding="0" border="0" width="100%">
			<tr>
				<td class="module_head">
					{$lang.profile_details}
				</td>
			</tr>
		</table>

		<table width="80%"  align="center" border="0" cellspacing="5">
			<tr>
				<td colspan="2" align="center">
					{$lang.view_profile_errmsg1}
					<a href="edituser.php" onclick="javascript:window.opener.document.location = 'edituser.php';window.close();">{$lang.view_profile_errmsg2}</a>
				</td>
			</tr>
		</table>
	{else}
		<table width="80%"  align="center" border="0" cellspacing="5">
			<tr>
				<td colspan="2" align="center">
					{$lang.view_profile_errmsg3}
				</td>
			</tr>
		</table>
	{/if}
{/if}