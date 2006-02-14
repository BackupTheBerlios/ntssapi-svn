{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe(form) 
{ldelim}
	if (form.code.value == '' || form.name.value == ''){ldelim}
		alert("{$lang.errormsgs[20]}");
		return false;
	{rdelim}
	return true;
{rdelim}

function confirmDelete(id)
{ldelim}
	var conmsg = "{$lang.admin_js__delete_error_msgs[19]}";
	if (confirm(conmsg)){ldelim}
		document.location='managecities.php?countrycode={$countrycode}&statecode={$statecode}&countycode={$countycode}&action=delete&id='+id;
	{rdelim}
{rdelim}

function confirmDeleteSel(frm)
{ldelim}
	var conmsg = "{$lang.admin_js__delete_error_msgs[20]}";
	if (confirm(conmsg)){ldelim}
		document.frmStates.groupaction.value = "{$lang.delete_selected}";
		document.frmStates.submit();
	{rdelim}
{rdelim}
/* ]]> */
</script>

<table width="571" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="494">
			<a href="managecountries.php" class="subhead">{$lang.manage_countries}</a>&nbsp;>&nbsp;
			<a href="managestates.php?countrycode={$countrycode}" class="subhead">{$lang.manage_states}</a>&nbsp;>&nbsp;
			<a href="managecounties.php?countrycode={$countrycode}&amp;statecode={$statecode}" class="subhead">{$lang.manage_counties}</a>&nbsp;>&nbsp;
			{if $todo != ''}
				<a href="managecities.php?countrycode={$countrycode}&amp;statecode={$statecode}&amp;countycode={$countycode}" class="subhead">{$lang.manage_cities}</a>
			{else}
				{$lang.manage_cities}
			{/if}
		</td>
	</tr>
</table>
<br />
<center>
<table width="551" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="517">
					{$countryname}&nbsp;>&nbsp;
					{$statename}&nbsp;>&nbsp;
					{$countyname}&nbsp;>&nbsp;
					{if $todo == 'add'}
						{$lang.insert_city}
					{elseif $todo == 'edit'}
						{$lang.modify_city}
					{else}
						{$lang.cities_count}:&nbsp;{$total_recs}
					{/if}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			{ if $errmsg != ''} 
				<tr>
					<td width="6">&nbsp;</td>
					<td colspan="2"><span class="errors">{$lang.errormsgs[$errmsg]}</span></td>
				</tr>
			{ /if }
			</table>
		{if $todo != ''}
			<table width="540" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td align="left">
              <form name="cities" method="post" action="managecities.php" onsubmit="javascript: return checkMe(this);">
						<table width="540" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
							<tr>
								<td width="6">&nbsp;</td>
								<td align="left" width="150">
									{$lang.city_code}:<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
								</td>
								<td >
									<input type="text" name="code" value="{$data.code|stripslashes}" />
								</td>
							</tr>
							<tr>
								<td width="6">&nbsp;</td>
								<td width="150">
									{$lang.city_name}:<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
								</td>
								<td >
									<input type="text" name="name" value="{$data.name|stripslashes}" />
								</td>
							</tr>
							<tr>
								<td width="6">&nbsp;</td>
								<td align="center">
									<input name="id" type="hidden" value="{$data.id}" />
									<input name="countrycode" type="hidden" value="{$countrycode}" />
									<input name="statecode" type="hidden" value="{$statecode}" />
									<input name="countycode" type="hidden" value="{$countycode}" />
									<input type="hidden" name="action" {if $todo == 'edit'}value='edited'{else}value='added' {/if} />
									<input type="submit" class="formbutton" name="submit" {if $todo == 'edit'}value="{$lang.modify_city}"{else}value="{$lang.insert_city}" {/if} />
								</td>
							</tr>
						</table>
              </form>
					</td>
				</tr>
			</table>
		{ else }
			<table width="540" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td>
						<table width="540" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
							<tr><td colspan="3"><a href="managecities.php?countrycode={$countrycode}&amp;statecode={$statecode}&amp;countycode={$countycode}&amp;action=add">{$lang.insert_city}</a>
								<td colspan="3" align="center">
									<form action="" method="get" name="frmPageList">
									{$lang.results_per_page}&nbsp;
									<select name="results_per_page" id="results_per_page">
									{html_options options=$lang.search_results_per_page selected=$page_size}
									</select>&nbsp;
									<input type="hidden" name="countrycode" value="{$countrycode}" />
									<input type="hidden" name="countycode" value="{$countycode}" />
									<input type="hidden" name="statecode" value="{$statecode}" />
									<input type="submit" class="formbutton" value="{$lang.show}" />
									</form>
								</td>

							</tr>
            </table>
            <form action="managecities.php" method='post' name="frmStates">
              <input type="hidden" name="countrycode" value="{$countrycode}" />
              <input type="hidden" name="statecode" value="{$statecode}" />
              <input type="hidden" name="countycode" value="{$countycode}" />
            <table width="540" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
							<tr class="table_head">
							  	<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
			  					<th nowrap>{$lang.col_head_srno}</th>
			  					<th nowrap><a href="?sort={$lang.city_code|escape:url}&amp;type={$sort_type}&amp;countrycode={$countrycode}&amp;statecode={$statecode}&amp;countycode={$countycode}">{$lang.city_code}</a></th>
			  					<th nowrap><a href="?sort={$lang.city_name|escape:url}&amp;type={$sort_type}&amp;countrycode={$countrycode}&amp;statecode={$statecode}&amp;countycode={$countycode}">{$lang.city_name}</a></th>
			  					<th colspan="2" >{$lang.action}</th>
							</tr>
							{assign var="n" value="$upr"}
						{foreach item=item key=key from=$citieslist}
							{math equation="$n+1" assign="n" }
							<tr class="{cycle values="oddrow,evenrow"}">
					  			<td align="center"><input type="checkbox" name="txtcheck[]" value="{$item.id}" /></td>
			  					<td nowrap>{$n}</td>
			  					<td nowrap>{$item.code|stripslashes}</td>
			  					<td nowrap><a href="managezips.php?countrycode={$countrycode}&amp;statecode={$statecode}&amp;countycode={$countycode}&amp;citycode={$item.code}">{$item.name|stripslashes}</a></td>
			  					<td nowrap colspan="2" ><a href="managecities.php?countrycode={$countrycode}&amp;statecode={$statecode}&amp;countycode={$countycode}&amp;action=edit&amp;id={$item.id}"><img src="images/button_edit.png" alt='Edit' border="0" /></a>
								&nbsp;&nbsp;&nbsp;
								<a href="#" onclick="confirmDelete({$item.id});"><img src="images/button_drop.png" alt="Delete" border="0" /></a></td>
							</tr>
						{/foreach}
							<tr>
					 			<td colspan="5">&nbsp;&nbsp;&nbsp;
					 				<img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
								 	<input type="button" class="formbutton" value="{$lang.delete_selected}" name="checkDel" onclick="javascript: confirmDeleteSel();" />
								 	<input name="groupaction" type="hidden" value="" />
								 </td>
							</tr>
						</table>
            </form>
					</td>
				</tr>
				<tr>
					<td colspan="5" align="center">
					{assign var="pageno" value=$smarty.get.offset}
					{if $pageno == ""}{assign var="pageno" value=1}{/if}
					{if $pageno != "1"}
						<a href="managecities.php?countrycode={$countrycode}&amp;statecode={$statecode}&amp;countycode={$countycode}&amp;offset={$pageno-1}">{$lang.previous}</a>&nbsp;
					{else}
						{$lang.previous}&nbsp;
					{/if}
					{if $total_recs > $page_size}
						<a href="managecities.php?countrycode={$countrycode}&amp;statecode={$statecode}&amp;countycode={$countycode}&amp;offset={$pageno+1}">{$lang.next}</a>&nbsp;
					{else}
						{$lang.next}&nbsp;
					{/if}
					</td>
				</tr>
			</table>
			<br />
			<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td class="module_detail_inside">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="506">{$lang.filter_records}</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
						<table width="540" border="0" cellspacing="2" cellpadding="1" align="center">
							<tr>
								<td>
								<form name="srchMe" method="post" action="">
									<input type="hidden" name="countrycode" value="{$countrycode}" />
									<input type="hidden" name="statecode" value="{$statecode}" />
									<input type="hidden" name="countycode" value="{$countycode}" />
									{$lang.city_code}:&nbsp;
									<input name="citycode" value="{$citycode}" type="text" size="10" maxlength="10" />&nbsp;
									{$lang.or}&nbsp;
									{$lang.name_col}:&nbsp;
									<input type="text" name="cityname" value="{$cityname}" size="30" maxlength="100" />
									&nbsp;
									<input type="submit" class="formbutton" name="searchme" value="{$lang.show}" />
								</form>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		{/if}
		</td>
	</tr>
</table>
</center>
{/strip}