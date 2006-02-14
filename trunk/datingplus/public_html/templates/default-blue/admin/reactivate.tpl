{strip}
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" >{$lang.cancel_list}</td>
	</tr>
</table>
<br />
<center>
<table width="573" border="0" cellpadding="0" cellspacing="0" >
	<tr>
	<td class="module_detail_inside" width="100%">
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="module_head" width="6">&nbsp;</td>
				<td class="module_head" width="539">
					{$lang.total_profiles_found}&nbsp;{$cancel_list|@count}
					</td>
				<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
			</tr>
		</table>
		<table class="table" cellspacing="{$config.cellspacing}" 
		cellpadding="{$config.cellpadding}" width="100%" border="0">
		  <tbody>
			{if $errmsg != '' or $cancel_list|@count <= 0 }
			<tr>
				<td colspan="5">
					&nbsp;<span class="errors">
					{if $errmsg != ''}
						{$lang.errormsgs[$errmsg]}
					{elseif $cancel_list|@count <= 0 }
						{$lang.no_record_found}
					{/if}
					</span>
				</td>
			</tr>
			{/if}
			{if $cancel_list|@count > 0 }
				<tr class="table_head">
				  <th width="2%">{$lang.col_head_srno}</th>
				  <th width="10%"><a href="?sort={$lang.col_head_username|escape:url}&amp;type={$sort_type}">{$lang.col_head_username}</a></th>
				  <th width="15%"><a href="?sort={$lang.col_head_firstname|escape:url}&amp;type={$sort_type}">{$lang.col_head_name}</a></th>
				  <th width="20%">{$lang.cancel_date}</th>
				  <th width="7%">{$lang.action}</th>
				</tr>
				{assign var="mcount" value="0"}
				{foreach item=item key=key from=$cancel_list}
					{math equation="$mcount+1" assign="mcount"}
				<tr class="{cycle values="oddrow,evenrow"}">
				  <td>{$mcount}</td>
				  <td>{$item.username}</td>
				  <td>{$item.firstname|stripslashes|stripslashes}&nbsp;{$item.lastname|stripslashes|stripslashes}</td>
				  <td nowrap>{$item.regdate|date_format:$lang.DATE_FORMAT}</td>
				  <td>&nbsp;&nbsp;
					<input type="button" class="formbutton" value="{$lang.reactivate}" onclick="javascript:window.location='reactivate.php?id={$item.id}';">
				  </td>
				</tr>
				{/foreach}
			{/if}
		  </tbody>
		</table>
		</td>
	</tr>
</table>
</center>
{/strip}