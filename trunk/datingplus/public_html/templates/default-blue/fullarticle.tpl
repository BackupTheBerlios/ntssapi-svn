{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">
			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="450">
					{$lang.articles}
					</td>
					<td width="44" class="module_head" align="right">
						<a href="index.php?page=articles"><font color="white">{$lang.back}</font></a>&nbsp;&nbsp;
					</td>
				</tr>
			</table>
			<table width="100%" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}" border="0">
			{foreach item=row from=$data}
				<tr>
					<td>
						{foreach item=row from=$data}
							<span class="newshead">{$row.title|stripslashes}</span><br/>
							<span class="newsdate">{$row.dat}</span><br/><br/>
							<span class="newstext">{$row.text|stripslashes}</span><br/>
						{/foreach}
					</td>
				</tr>
			{/foreach}
			</table>
		</td>
	</tr>
</table>
{/strip}
