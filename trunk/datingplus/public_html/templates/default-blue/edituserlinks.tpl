{strip}

<table width="550" border="1" cellpadding="0" cellspacing="0" >
	<tr>
		<td align="center">
			<a href="edituser.php" class='edituserlink'>{$lang.section_signup_title}</a>
		</td>
	{foreach key=key item=item from=$sections}
		<td align="center">
		{if $key !=$smarty.get.sectionid}
			<a href="editquestions.php?sectionid={$key}" class='edituserlink'>
		{/if}
			<span class='edituserlink'>{$item}</span>
		{if $key !=$smarty.get.sectionid}
			</a>
		{/if}
		</td>
	{/foreach}
	</tr>
</table>
{/strip}
