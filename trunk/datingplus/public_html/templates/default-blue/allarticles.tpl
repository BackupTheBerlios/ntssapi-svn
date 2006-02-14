{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

				<table width="571" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
						<td class="module_head" width="494">
						{$lang.articles}
						</td>
					</tr>
				</table>
		
				<table width="100%" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" border="0">
				{foreach item=row from=$data}
					<tr>
						<td>
							<span class="newshead">{$row.title|stripslashes}</span><br/>
							<span class="newsdate">{$row.dat}</span><br/>
							<span class="newstext">{$row.text|stripslashes}</span>

							<a href='index.php?page=showarticle&amp;articleid={$row.articleid}'>{$lang.more}</a>
				
						</td>
					</tr>
				{/foreach}
			</table>
		</td>
	</tr>
</table>
{/strip}
