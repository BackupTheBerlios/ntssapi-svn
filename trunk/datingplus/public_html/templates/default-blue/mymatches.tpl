{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.my_matches}
					</td>
				</tr>
			</table>

			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
				<tbody>
				<tr><td colspan="2">&nbsp;</td></tr>
				<tr>
					<td colspan="2">
						{$lang.your_search_preferences}<br/>
						<blockquote>{$lang.i_am_a}&nbsp;<b>{$lang.signup_gender_values[$user.gender]}</b>&nbsp;{$lang.Looking_for}&nbsp;
						<b>{$lang.signup_gender_look[$user.lookgender]}</b>&nbsp;{$lang.Between}&nbsp;<b>{$user.lookagestart}</b>&nbsp;and&nbsp;<b>{$user.lookageend}</b>,&nbsp;
						{if $user.lookcountry != 'AA' && $lang.countries[$user.lookcountry] != '' }
							{$lang.who_is_from}&nbsp;<b>{$lang.countries[$user.lookcountry]}</b>
						{elseif $user.lookcountry == 'AA'}
							{$lang.who_is_from}&nbsp;{$lang.any_where}
						{/if}
						{if $lang.allstates[$user.lookstate_province] != ''}
							, <b>{$lang.allstates[$user.lookstate_province]}</b>
						{/if}
						{if $user.lookcity != ''}
							, <b>{$user.lookcity}</b>
						{/if}
						{if $user.lookzip != ''}
							, <b>{$user.lookzip}</b>
						{/if}<br/>
						<center><a href="edituser.php#search_preferences">{$lang.click_here}</a>&nbsp;{$lang.to_edit_search_preferences}</center>
						</blockquote>
					</td>
				</tr>
				{if $error == 1 }
					<tr>
						<td colspan="2">{$lang.no_record_found}</td>
					</tr>
				{else}
					<tr>
						<td colspan="2" align="center">
							{$lang.results_per_page}&nbsp;&nbsp;
							<select name="results_per_page" id="results_per_page">
								{html_options options=$lang.search_results_per_page selected=$psize}
							</select>&nbsp;
							<input type="button" class="formbutton" value="{$lang.show}" onclick="document.location='?{$querystring}&amp;results_per_page=' + results_per_page.value"/>
						</td>
					</tr>
					<tr><td colspan="2">&nbsp;</td></tr>
					<tr><td colspan="2">
						{$lang.total_profiles_found}&nbsp;{$totalrecs}&nbsp;&nbsp;&nbsp;
						{$lang.showing}&nbsp;{$start+1} {$lang.to}
						{assign var="totl" value=$data|@count}
						{$start+$totl}
						</td></tr>
					<tr>
						<td>
							<table  width="100%" cellpadding="0" cellspacing="8" border="0">
							{assign var="ccount" value="0"}
							{foreach item=item key=key from=$data}
								{if $ccount==0}
									<tr>
								{/if}
									<td>{include file="userresultviewsmall.tpl"}</td>
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
			<table align="center" cellspacing="0" cellpadding="0" border="0">
				<tbody>
					<tr>
						{if $prev != "" }
						<td>
							<a href="?page={$prev}&amp;{$querystring}" > {$lang.previous}</a>&nbsp;
						</td>
						{/if}
						{if $cpage != "" && $pages != "" }
						<td>
							{$lang.page}&nbsp;{$cpage}{$lang.of}{$pages}&nbsp;
						</td>
						{/if}
						{if $next != "" }
						<td>
							 <a href="?page={$next}&amp;{$querystring}" >{$lang.next}</a>
						</td>
						{/if}
					</tr>
				</tbody>
			</table>
		</td>
	</tr>
</table>
{/strip}
