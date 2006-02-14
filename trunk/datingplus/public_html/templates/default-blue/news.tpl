{strip}
<table width="178" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="178" valign="top">

			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="150">
					{$lang.news}
					</td>
					<td width="22"><img src="{$image_dir}blue_small_hor.jpg" width="22" height="23" alt="" /></td>
				</tr>
			</table>
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="6"></td>
					<td width="100%">

						<table  class="table" width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
							<tr>
								<td>
									{foreach item=row from=$news_data}
										<span class="newshead">{$row.header|stripslashes}</span><br/>
										<span class="newsdate">{$row.date}</span><br/>
										<span class="newstext">{$row.text|stripslashes}</span>
										{if $config.enable_mod_rewrite == 'Y'}
											<a href='news{$row.newsid}.htm'>{$lang.more}</a>
										{else}
										<a href='index.php?page=shownews&amp;newsid={$row.newsid}'>{$lang.more}</a>
										{/if}
										<br/><br/>
									{/foreach}
								</td>
							</tr>
						</table>
						<center>
							{if $config.enable_mod_rewrite == 'Y'}
							<a href='allnews.html'>{$lang.all_news}</a>
							{else}
							<a href='index.php?page=allnews'>{$lang.all_news}</a>
							{/if}
						</center>

					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
