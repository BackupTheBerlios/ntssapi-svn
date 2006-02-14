<!-- DONE -->
{strip}
<table width="178" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="178" valign="top">

			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="150">
					{$lang.success_stories}
					</td>
					<td width="22"><img src="{$image_dir}blue_small_hor.jpg" width="22" alt="" /></td>
				</tr>
			</table>
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="6"></td>
					<td width="100%">

						<table  class="table" width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
							{foreach item=row from=$story_data}
								<tr>
									<td>
										<span class="storyhead">{$row.header|stripslashes}</span><br />
										<span class="storydate">{$row.date}</span><br />
										<span class="storyby">{$lang.by}&nbsp;
											{if $config.enable_mod_rewrite == 'Y'}
												<a href="javascript:popUpScrollWindow('{$row.sender}.htm','center',650,screen.height)">{$row.username}</a>
											{else}
												<a href="javascript:popUpScrollWindow('showprofile.php?id={$row.sender}','center',650,screen.height)">{$row.username}</a>
											{/if}
										</span><br /><br />
										<div class="storytext">{$row.text|stripslashes}</div>
										{if $config.enable_mod_rewrite == 'Y'}
											<a href='story{$row.storyid}.htm'>{$lang.more}</a>
										{else}
											<a href='index.php?page=showstory&amp;storyid={$row.storyid}'>{$lang.more}</a><br />
										{/if}
									</td>
								</tr>
							{/foreach}
						</table>
						<center>
							{if $config.enable_mod_rewrite == 'Y'}
								<a href='stories.html'>{$lang.all_stories}</a>
							{else}
								<a href='index.php?page=stories'>{$lang.all_stories}</a>
							{/if}
						</center>

					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>


{/strip}
