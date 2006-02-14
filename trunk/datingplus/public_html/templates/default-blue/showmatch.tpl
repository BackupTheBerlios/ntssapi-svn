{strip}
<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
<tbody>
	<tr>
		<td colspan="5" class="subtitle">{$lang.matches_found}
		</td>
	</tr>
	<tr><td colspan="5">&nbsp;</td></tr>
	<tr><td colspan="5">{$lang.total_profiles} {$data|@count}</td></tr>
	<tr><td colspan="5">&nbsp;</td></tr>
	<tr>
		<td>{$lang.col_head_srno}</td>
		<td>{$lang.col_head_firstname}</td>
		<td>{$lang.col_head_lastname}</td>
		<td>{$lang.col_head_email}</td>
		<td>{$lang.col_head_country}</td>
	</tr>
{if $error == 1 }
	<tr>
		<td colspan="5">{$lang.no_record_found}</td>
	</tr>
{else}
	{assign var="mcount" value="0"}				
	{foreach item=item key=key from=$data}
	{math equation="$mcount+1" assign="mcount"}		
		<tr>
			<td>{$mcount}</td>
			<td>{$item.firstname|stripslashes}</td>
			<td>{$item.lastname|stripslashes}</td>
			<td>{$item.email}</td>
			<td>{$item.country}</td>
		</tr>
	{/foreach}
{/if}
</tbody>
</table>
{/strip}
