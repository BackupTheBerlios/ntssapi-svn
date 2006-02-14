{strip}
<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
	<tr>
		<td>
			[&nbsp;<a href="index.php">{$lang.section_signup_title}</a>&nbsp;]
			[&nbsp;<a href="usersnap.php">{$lang.section_mypicture}</a>&nbsp;]
			{foreach key=key item=item from=$sections}
				[&nbsp;<a href="questions.php?sectionid={$key}">{$item}</a>&nbsp;]
			{/foreach}
		</td>
	</tr>
</table>
{/strip}
