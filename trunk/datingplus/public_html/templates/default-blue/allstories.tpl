{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
					{$lang.success_stories}
					</td>
				</tr>
			</table>


			<table width="100%" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" border="0">
			{foreach item=row from=$data}
				<tr>
					<td>
						<span class="storyhead">{$row.header|stripslashes}</span><br />
						<span class="storydate">{$row.date}</span><br />
					{if $row.sender != '' }
						<span class="storyby">{$lang.by}&nbsp;
							{if $config.enable_mod_rewrite == 'Y'}
								<a href="javascript:popUpScrollWindow('{$row.sender}.htm','center',650,screen.height)">{$row.username|stripslashes}</a>
							{else}
								<a href="javascript:popUpScrollWindow('showprofile.php?id={$row.sender}','center',650,screen.height)">{$row.username|stripslashes}</a>
							{/if}

						</span>
					{/if}
						<br /><br />
						<div class="storytext">{$row.text|stripslashes}<a href='index.php?page=showstory&amp;storyid={$row.storyid}'>{$lang.more}</a></div>
						<br />
					</td>
				</tr>
			{/foreach}
			</table>


		</td>
	</tr>
</table>
{/strip}
