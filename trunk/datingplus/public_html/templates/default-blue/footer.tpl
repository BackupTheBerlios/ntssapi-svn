{strip}
<center>
	<table cellspacing="0" cellpadding="0" width="779" border="0">
		<tr>
			<td width='100%' align='center' class="footer" height="25">
			{if $smarty.session.UserId <= 0}
				<a href='index.php?page=login' class='footerlink'>{$lang.site_links.login}</a> |
			{/if}			
			{if $config.enable_mod_rewrite == 'Y'}
				<a href='privacy.html' class='footerlink'>{$lang.site_links.privacy}</a> |
				<a href='terms_of_use.html' class='footerlink'>{$lang.site_links.terms_of_use}</a> |
				<a href='services.html' class='footerlink'>{$lang.site_links.services}</a> |
				<a href='faq.html' class='footerlink'>{$lang.site_links.faq}</a> |
				<a href='articles.html' class='footerlink'>{$lang.site_links.articles}</a> |
			{else}
				<a href='index.php?page=privacy' class='footerlink'>{$lang.site_links.privacy}</a> |
				<a href='index.php?page=terms_of_use' class='footerlink'>{$lang.site_links.terms_of_use}</a> |
				<a href='index.php?page=services' class='footerlink'>{$lang.site_links.services}</a> |
				<a href='index.php?page=faq' class='footerlink'>{$lang.site_links.faq}</a> |
				<a href='index.php?page=articles' class='footerlink'>{$lang.site_links.articles}</a> |
			{/if}
				<a href='affindex.php' class='footerlink'>{$lang.site_links.affliates}</a> |
				<a href='javascript:launchTellFriend();' class='footerlink'>{$lang.site_links.invite_a_friend}</a> |
				<a href='feedback.php' class='footerlink'>{$lang.site_links.feedback}</a>
			</td>
		</tr>
		<tr><td width='100%' align='center' height="3"></td></tr>
		<tr>
			<td width='100%' align='center'>
				<a href="http://www.tufat.com/osdate.php" class='copyright'>{$config.copyright}</a>
			</td>
		</tr>
		<tr><td width='100%' align='center' height="3"></td></tr>
	</table>

			</td>
		</tr>
	</table>
</center>

</body>
</html>
{/strip}
