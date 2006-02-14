{strip}
{include file="lang_select.tpl"}
<br />
{if $smarty.session.UserId != ''}
	{include file="panelmenu.tpl"}
	<br />
	{if $smarty.session.active == 1 && $smarty.session.security.allowim == 1}
		{include file="im.tpl"}
		<br />
	{/if}
{else}
	{include file="stats.tpl"}
	<br />
{/if}
{if $config.no_news > 0}
	{include file="news.tpl"}
	<br />
{/if}
{if $poll_data|@count > 0 }
	{include file="polls.tpl"}
	<br />
{/if}
{include file="stories.tpl"}
<br />
{/strip}
