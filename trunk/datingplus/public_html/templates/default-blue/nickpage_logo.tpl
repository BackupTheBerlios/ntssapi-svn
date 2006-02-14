<table cellspacing="0" cellpadding="0" border="0" width="100%" class="headbg">
	
	{if $config.use_profilepopups == 'Y'}
	<tr>
		<td colspan="2" valign="middle" align="center">
<!-- logo
			<a href="/" class="main_title"><img src="{$image_dir}logo.png" alt="{$lang.site_name|stripslashes}" title="{$lang.site_name|stripslashes}" border="0" style="padding:10px;" alt="" /></a>
-->
			<a href="/" class="main_title">{$lang.site_name|stripslashes}</a>
		</td>
	</tr>
	{/if}
	<tr>
		<td class="headerfooter" style="text-align:left;">
			&nbsp;&nbsp;{$user.username}{$lang.profile_s}
		</td>
		<td class="headerfooter" style="text-align:right;">
			{$lang.lastlogged}&nbsp;{$user.lastvisit|date_format:$lang.DATE_FORMAT}&nbsp;&nbsp;
		</td>
	</tr>
</table>