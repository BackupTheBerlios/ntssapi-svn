{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">
			{* {$smarty.session.LastQuery} *}
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" >
						{$lang.search_results}
					</td>
				</tr>
			</table>

			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" >
			<tbody>
				{if $error == 1 }
					<tr>
						<td colspan="2">{$lang.no_record_found}</td>
					</tr>
				{else}
					<tr><td colspan="2">{$lang.total_profiles_found}&nbsp;{$totalrecs}</td></tr>
					<tr>
						<td  height="21" valign="bottom">
            <form action="" method="post">
							{$lang.sort_by|replace:':':''}&nbsp;
							<select name="sort_by">
								<option value="username" {if $sort_by eq 'username'} selected="selected" {/if}>{$lang.username|replace:':':''}</option>
								<option value="age" {if $sort_by eq 'age'}selected{/if}> {$lang.age} </option>
								<option value="logintime" {if $sort_by eq 'logintime'}selected{/if}>{$lang.logintime}</option>
							</select>&nbsp;
							<select name="sort_order">
								{html_options options=$lang.sort_types selected=$sort_order}
							</select>&nbsp;&nbsp;&nbsp;
							{$lang.results_per_page}&nbsp;
							<select name="results_per_page">
								{html_options options=$lang.search_results_per_page selected=$psize}
							</select>
							&nbsp;<input type="submit" class="formbutton" value="{$lang.show}" />
							{foreach from=$querystring key=key item=item}
								<input type="hidden" name="{$key}" value="{$item}" />
							{/foreach}
            </form>
						</td>
					</tr>
					<tr><td colspan="2" height="21" valign="bottom">Showing&nbsp;{$start+1} {$lang.to}
								{assign var="totl" value=$data|@count}
								{$start+$totl}
						</td>
					</tr>
					<tr>
						<td align="left">
							<table border="0">
							{assign var="ccount" value="0"}
							{foreach item=item key=key from=$data}
								{if $item.id > 0}
								{if $ccount==0}
									<tr>
								{/if}
									<td align="left">{include file="userresultviewsmall.tpl"}</td>
								{if $ccount==1}
									</tr>
								{/if}
								{math equation="$ccount+1" assign="ccount"}
								{math equation="$ccount%2" assign="ccount"}
								{/if}
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
							<a href="?page={$prev}
							{foreach from=$querystring key=key item=val}
								&amp;{$key}={$val}
							{/foreach}
							" >&lt;-- {$lang.previous}</a>&nbsp;&nbsp;
      </td>
      {/if}
						{if $cpage != "" && $pages != "" }
      <td>
							{$lang.pageno} {$cpage} {$lang.of} {$pages}
      </td>
      {/if}
						{if $next != "" }
						<td >
							&nbsp;&nbsp;<a href="?page={$next}{foreach from=$querystring key=key item=val}
								&amp;{$key}={$val}
							{/foreach}
							">{$lang.next} --&gt;</a>
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