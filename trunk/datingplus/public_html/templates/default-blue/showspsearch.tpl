{strip}
<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="1000" border="0">
<tbody>
	<tr>
		<td colspan="8" class="subtitle">{$lang.search_results}
			{$lang.for}
			"{$searchby|capitalize} {$searchat|capitalize}"
		</td>
	</tr>
	<tr><td colspan="8">&nbsp;</td></tr>
	<tr><td colspan="8">{$lang.total_profiles} {$data|@count}</td></tr>
	<tr><td colspan="8">&nbsp;</td></tr>
	<tr>
		<td>{$lang.col_head_srno}</td>
		<td><a href="?sort={$lang.col_head_username}&amp;type={$sort_type}">{$lang.col_head_username}</a></td>
		<td><a href="?sort={$lang.col_head_firstname}&amp;type={$sort_type}">{$lang.col_head_firstname}</a></td>
		<td><a href="?sort={$lang.col_head_register_at}&amp;type={$sort_type}">{$lang.col_head_register_at}</a></td>
		<td><a href="?sort={$lang.col_head_gender}&amp;type={$sort_type}">{$lang.col_head_gender}</a></td>
		<td><a href="?sort={$lang.col_head_email}&amp;type={$sort_type}">{$lang.col_head_email}</a></td>
		<td colspan="2" >{$lang.action}</td>
	</tr>
{if $error == 1 }
	<tr>
		<td colspan="8">{$lang.no_record_found}</td>
	</tr>
{else}
{assign var="mcount" value="0"}
{foreach item=item key=key from=$data}
{math equation="$mcount+1" assign="mcount"}
	<tr>
		<td>{$mcount}</td>
		<td>{$item.username|stripslashes}</td>
		<td>{$item.firstname|stripslashes}</td>
		<td>{$item.birth_date|date_format:$lang.DATE_FORMAT}</td>
		<td>{$item.gender}</td>
		<td>{$item.email}</td>
		<td><a href="?edit={$item.id}"><img src="images/button_edit.png" border="0" alt="" /></a></td>
		<td><a href="?delete={$item.id}"><img src="images/button_drop.png" border="0" alt="" /></a></td>
	</tr>
{/foreach}
{/if}
</tbody>
</table>

<a href="search.php">{$lang.back}</a>
{/strip}
