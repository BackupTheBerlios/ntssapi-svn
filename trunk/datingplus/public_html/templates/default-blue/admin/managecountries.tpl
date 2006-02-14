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
	var conmsg = "{$lang.admin_js__delete_error_msgs[12]}";
	if (confirm(conmsg)){ldelim}
		document.location='managecountries.php?action=delete&id='+id;
	{rdelim}
{rdelim}

function confirmDeleteSel(frm)
{ldelim}
	var conmsg = "{$lang.admin_js__delete_error_msgs[14]}";
	if (confirm(conmsg)){ldelim}
		document.frmCntry.groupaction.value = "{$lang.delete_selected}";
		document.forms['frmCntry'].submit();
	{rdelim}
{rdelim}
/* ]]> */
</script>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">
			{if $todo != ''}
				<a href="managecountries.php" class="subhead">{$lang.manage_countries}</a>&nbsp;>&nbsp;
				{if $todo == 'add'}
					{$lang.insert_country}
				{else}
					{$lang.modify_country}
				{/if}
			{else}
				{$lang.manage_countries}
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
					{if $todo == 'add'}
						{$lang.insert_country}
					{elseif $todo == 'edit'}
						{$lang.modify_country}
					{else}
						{$lang.countries_count}:&nbsp;{$total_recs}
					{/if}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			{ if $errmsg != ''}
				<tr>
					<td width="6">&nbsp;</td>
					<td colspan="2" style="padding-top: 5px; padding-bottom: 5px;"><span class="errors">{$lang.errormsgs[$errmsg]}</span></td>
				</tr>
			{ /if }
			</table>
		{if $todo != ''}
			<table width="540" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td align="left">
           <form name="cntry" method="post" action="managecountries.php" onsubmit="javascript: return checkMe(this);">
						<table width="540" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
							<tr>
								<td width="6">&nbsp;</td>
								<td align="left" width="150">
									{$lang.country_code}:<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
								</td>
								<td >
									<input type="text" name="code" {if $todo == 'edit' or $errmsg != ''}value="{$data.code|stripslashes}"{else}value=''{/if} />
								</td>
							</tr>
							<tr>
								<td width="6">&nbsp;</td>
								<td width="150">
									{$lang.country_name}:<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
								</td>
								<td >
									<input type="text" name="name" {if $todo == 'edit' or $errmsg != ''}value="{$data.name|stripslashes}"{else}value=''{/if} />
								</td>
							</tr>
							<tr>
								<td width="6">&nbsp;</td>
								<td align="center">
									<input name="id" type="hidden" value="{$data.id}" />
									<input type="submit" class="formbutton" name="submit" {if $todo == 'edit'}value="{$lang.modify_country}"{else}value="{$lang.insert_country}" {/if} />
									<input type="hidden" name="action" {if $todo == 'edit'}value='edited'{else}value='added' {/if} />
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
							<tr><td colspan="3"><a href="managecountries.php?action=add">{$lang.insert_country}</a>
								<td colspan="3" align="center">
									<form action="" method="get" name="frmPageOpt">
									{$lang.results_per_page}&nbsp;
									<select name="results_per_page" id="results_per_page">
									{html_options options=$lang.search_results_per_page selected=$page_size}
									</select>&nbsp;
									<input type="submit" class="formbutton" value="{$lang.show}" />
									</form>
								</td>
							</tr>
            </table>
            <form action="managecountries.php" method='post' name="frmCntry" >
            <table width="540" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
							<tr class="table_head">
							  	<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
			  					<th nowrap>{$lang.col_head_srno}</th>
			  					<th nowrap><a href="?sort={$lang.country_code|escape:url}&amp;type={$sort_type}">{$lang.country_code}</a></th>
			  					<th nowrap><a href="?sort={$lang.country_name|escape:url}&amp;type={$sort_type}">{$lang.country_name}</a></th>
			  					<th >{$lang.action}</th>
							</tr>
							{assign var="n" value="$upr"}
						{foreach item=item key=key from=$countrieslist}
							{math equation="$n+1" assign="n" }
							<tr class="{cycle values="oddrow,evenrow"}">
					  			<td align="center"><input type="checkbox" name="txtcheck[]" value="{$item.id}" /></td>
			  					<td nowrap>{$n}</td>
			  					<td nowrap>{$item.code|stripslashes}</td>
			  					<td nowrap width="50%"><a href="managestates.php?countrycode={$item.code}">{$item.name|stripslashes}</a></td>
			  					<td nowrap><a href="managecountries.php?action=edit&amp;id={$item.id}"><img src="images/button_edit.png" alt='Edit' border="0" /></a>
			  					&nbsp;&nbsp;&nbsp;
			  					<a href="javascript:confirmDelete({$item.id});"><img src="images/button_drop.png" alt="Delete" border="0" /></a></td>
							</tr>
						{/foreach}
							<tr>
					 			<td colspan="4">&nbsp;&nbsp;&nbsp;
					 				<img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
								 	<input type="button" class="formbutton" value="{$lang.delete_selected}" name="checkdel" onclick="javascript:confirmDeleteSel();" />
								 	<input type="hidden" name="groupaction" value="" />
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
						<a href="managecountries.php?offset={$pageno-1}">{$lang.previous}</a>&nbsp;
					{else}
						{$lang.previous}&nbsp;
					{/if}
					{if $total_recs > $config.page_size}
						<a href="managecountries.php?offset={$pageno+1}">{$lang.next}</a>&nbsp;
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
									{$lang.country_code}:&nbsp;
									<input name="countrycode" value="{$countrycode}" type="text" size="4" maxlength="4" />&nbsp;
									{$lang.or}&nbsp;
									{$lang.country_name}:&nbsp;
									<input type="text" name="countryname" value="{$countryname}" size="30" maxlength="100" />
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