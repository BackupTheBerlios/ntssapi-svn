{strip}
<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
	<tr>
		<td rowspan="6" width="20%" align="center"><img src="getsnap.php?id={$smarty.get.id}&amp;typ=tn" alt="" /></td>
		<td width="40%">Username</td>
		<td width="40%">{$user.username}</td>
	</tr>
	<tr>
		<td>Name</td>
		<td>{$user.firstname|stripslashes}&nbsp;{$user.lastname|stripslashes}</td>
	</tr>
	<tr>
		<td>Gender</td>
		<td>{if $user.gender == "M"} Male {else} Female {/if}</td>
	</tr>
	<tr>
		<td>Age</td>
		<td>{$user.age}</td>
	</tr>
	<tr>
		<td>Country</td>
		<td>{$lang.countries[$user.country]}</td>
	</tr>
	<tr>
		<td>City</td>
		<td>{$user.city|stripslashes}</td>
	</tr>
	{assign var="previd" value="0"}
	{foreach item=item from=$pref}
		{if $item.type == "select" || $item.type == "radio"}
			{if $item.anstxt != ""}
			<tr>
				<td colspan="2">{$item.question}</td>
				<td>{$item.anstxt}</td>
			</tr>
			{/if}
		{elseif $item.type == "textarea"}
			{if $item.answer != ""}
			<tr>
				<td colspan="2">{$item.question}</td>
				<td>{$item.answer|stripslashes}</td>
			</tr>
			{/if}
		{elseif $item.type == "checkbox"}
		{if $previd == $item.id }
			<tr>
				<td colspan="2">&nbsp;</td>
				<td>{$item.anstxt}</td>
			</tr>
		{else}
			<tr>
				<td colspan="2"><b>{$item.question}</b></td>
				<td>{$item.anstxt}</td>
			</tr>
		{/if}
		{assign var="previd" value=$item.id}
		{/if}
	{/foreach}
</table>
{/strip}
