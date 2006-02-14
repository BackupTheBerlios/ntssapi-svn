{strip}
<table width="550" border="0" cellpadding="2" cellspacing="1" >
	<tr>
		<td align="center" class='edituserlink'>
			<a href="profile.php?edit={$smarty.get.edit}">{$lang.section_signup_title}</a>
		</td>
	{foreach key=key item=item from=$sections}
		<td align="center" class='edituserlink'>
			{if $key !=$smarty.get.sectionid}
				<a href="editprofilequestions.php?sectionid={$key}&amp;edit={$smarty.get.edit}"  class='edituserlink'>
			{/if}
			<span>{$item}</span>
			{if $key !=$smarty.get.sectionid}
				</a>
			{/if}
		</td>
	{/foreach}
	</tr>
</table>

{/strip}