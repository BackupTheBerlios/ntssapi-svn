{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.online_users}
					</td>
				</tr>
			</table>

			<table align="center" class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" >
			<tbody>
				{if $error == 1 }
					<tr>
						<td colspan="2">{$lang.no_record_found}</td>
					</tr>
				{else}
					<tr><td colspan="2">{$lang.total_profiles_found}&nbsp;{$totalrecs}</td></tr>
					<tr>
						<td colspan="2" align="center">
							{$lang.results_per_page}&nbsp;<br/>
							<select name="results_per_page">
								{html_options options=$lang.search_results_per_page selected=$psize}
							</select>&nbsp;
							<input type="button" value="{$lang.show}" onclick="document.location='?{$querystring|escape:url}&amp;results_per_page=' + results_per_page.value" />
						</td>
					</tr>
					<tr><td colspan="2">Showing&nbsp;{$start+1} {$lang.to}
								{assign var="totl" value=$data|@count}&nbsp;
								{$start+$totl}
						</td>
					</tr>
					<tr>
						<td >
							<table  width="100%" cellpadding="0" cellspacing="8" border="0">
							{assign var="ccount" value="0"}
							{foreach item=item key=key from=$data}
								{if $ccount==0}
									<tr>
								{/if}
									<td>{include file="admin/userresultviewsmall.tpl"}</td>
								{if $ccount==1}
									</tr>
								{/if}
								{math equation="$ccount+1" assign="ccount"}
								{math equation="$ccount%2" assign="ccount"}
							{/foreach}
							</table>
						</td>
					</tr>
				{/if}
			</tbody>
			</table>

      {if $pages neq ""}
			<table align="center" border="0" cellpadding="0" cellspacing="0" >
				<tbody>
          <tr>
						{if $prev != "" }
						<td>
							<a href="?page={$prev}&amp;{$querystring|escape:url}" ><-- {$lang.previous}<a/>&nbsp;
						</td>
						{/if}
						{if $cpage != "" && $pages != "" }
						<td>
							{$lang.pageno}&nbsp;{$cpage}&nbsp;{$lang.of}{$pages}
						</td>
						{/if}
						{if $next != "" }
						<td>
							&nbsp;<a href="?page={$next}&amp;{$querystring|escape:url}">{$lang.next} --></a>
						</td>
						{/if}
					</tr>
				</tbody>
			</table>
      {/if}
		</td>
	</tr>
</table>
{/strip}
