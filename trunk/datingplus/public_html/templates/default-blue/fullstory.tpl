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
						<td width="44" class="module_head" align="right">
							<a href="index.php?page=stories" class="module_head">{$lang.back}</a> &nbsp;
						</td>
					</tr>
				</table>
		
				<table width="100%" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}" border="0">
				{foreach item=row from=$data}
					<tr>
						<td>
							{foreach item=row from=$data}
								<span class="storyhead">{$row.header|stripslashes}</span><br/>
								<span class="storydate">{$row.date}</span><br/>
							{if $row.sender != ''}
								<span class="storyby">{$lang.by}&nbsp;
								
									{if $config.enable_mod_rewrite == 'Y'}					
										<a href="javascript:popUpScrollWindow('{$row.sender}.htm','center',650,screen.height)">{$row.username}</a>
									{else}
										<a href="javascript:popUpScrollWindow('showprofile.php?id={$row.sender}','center',650,screen.height)">{$row.username}</a>
									{/if}
								
								</span>
							{/if}
								<br /><br />
								<span class="storytext">{$row.text|stripslashes}</span><br/>
							{/foreach}
						</td>
					</tr>
				{/foreach}
				</table>
				

		</td>
	</tr>
</table>
{/strip}
