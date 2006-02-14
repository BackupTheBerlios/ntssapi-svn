{strip}
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" >{$lang.featured_profiles_hdr}</td>
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
					{$lang.total_profiles_found}&nbsp;{$featured|@count}
					</td>
				<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
			</tr>
		</table>
		<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
		  <tbody>
			<tr class="table_head">
			  <th width="2%">{$lang.col_head_srno}</th>
			  <th width="10%"><a href="?sort={$lang.col_head_username|escape:url}&amp;type={$sort_type}">{$lang.col_head_username}</a></th>
			  <th width="15%"><a href="?sort={$lang.col_head_firstname|escape:url}&amp;type={$sort_type}">{$lang.col_head_name}</a></th>
			  <th width="3%"><a href="?sort={$lang.level_hdr|escape:url}&amp;type={$sort_type}">{$lang.level_hdr}</a></th>
			  <th width="20%" nowrap><a href="?sort={$lang.date_from|escape:url}&amp;type={$sort_type}">{$lang.date_from}</a></th>
			  <th width="20%"><a href="?sort={$lang.date_upto|escape:url}&amp;type={$sort_type}">{$lang.date_upto}</a></th>
			  <th width="3%">{$lang.must_show}</th>
			  <th width="10%">{$lang.reqd_exposures}</th>
			  <th width="10%">{$lang.total_exposures}</th>
			  <th width="7%">{$lang.action}</th>
			</tr>
			{if $error == 1 }
			<tr>
				<td colspan="10">{$lang.no_record_found}</td>
			</tr>
			{else}
			{assign var="mcount" value="0"}
				{foreach item=item key=key from=$featured}
					{math equation="$mcount+1" assign="mcount"}
				<tr class="{cycle values="oddrow,evenrow"}">
				  <td>{$mcount}</td>
				  <td>{$item.username}</td>
				  <td>{$item.firstname|stripslashes}&nbsp;{$item.lastname|stripslashes}</td>
				  <td>{$item.level}</td>
				  <td nowrap>{$item.start_date|date_format:$lang.DATE_FORMAT}</td>
				  <td nowrap>{$item.end_date|date_format:$lang.DATE_FORMAT}</td>
				  <td>{if $item.must_show eq '1'}
						Yes
					  {else}
						No
					  {/if}</td>
				  <td>{$item.req_exposures}</td>
				  <td>{$item.exposures}</td>
				  <td>
					<a href="featured_profile.php?req_action=modify&amp;id={$item.id}&amp;bckurl=featured_profiles.php"><img src="images/button_edit.png" border="0" alt="" /></a>
				  </td>
				</tr>
				{/foreach}
			{/if}
			<tr>
				<td colspan="10" align="center">
					<a href="featured_profile.php?req_action=add"><input type="button" class="formbutton" value="{$lang.add_featured}" name="add" /></a>
				</td>
			</tr>
		  </tbody>
		</table>
		</td>
	</tr>
</table>
</center>
{/strip}