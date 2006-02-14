{strip}
<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
	<tr>
		<td>
		{foreach key=key item=item from=$sections}
				[
				{if $key != $smarty.get.sectionid}
				<a href="questions.php?sectionid={$key}">
				{/if}
				{$item}
				{if $key != $smarty.get.sectionid}
				</a>
				{/if}
				]
			{/foreach}
			[ <a href="index.php?page=login">{$lang.member_login}</a> ]

		</td>
	</tr>
</table>
{/strip}
