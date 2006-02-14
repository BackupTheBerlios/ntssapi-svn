{strip}
<script type="text/javascript">
/* <![CDATA[ */
function confdel(form){ldelim}
  if (confirm("{$lang.admin_js__delete_error_msgs[18]}")) {ldelim}
    document.frm.delete_selected.value="{$lang.delete_selected}";
    form.submit();
  {rdelim}else{ldelim}
    return false;
  {rdelim}
{rdelim}

function confirmDelete(profileid,conmsg)
{ldelim}
  if (confirm(conmsg)){ldelim}
    document.frmDelProfile.txtdelete.value=profileid;
    document.frmDelProfile.submit();
  {rdelim}
{rdelim}
/* ]]> */
</script>
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.profile_title}</td>
	</tr>
</table>
<form name="frmDelProfile" action="profile.php" method="get">
  <input type="hidden" name="txtdelete" value="" />
  <input type="hidden" name="frm" value="frmDelProfile" />
</form>
<form  action="profile.php" method="get">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr >
		<td class="module_detail_inside">
			<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
				<tr>
				 	<td nowrap><img src="images/featured.gif" border="0" alt="" />&nbsp;{$lang.makefeatured}</td>
					<td align="right">{$lang.results_per_page}:&nbsp;
						<select name="results_per_page">
							{html_options options=$lang.search_results_per_page selected=$psize}
						</select>&nbsp;
						<input type="button" class="formbutton" value="{$lang.show}" onclick="document.location='?{$querystring|escape:"url"}&amp;results_per_page=' + results_per_page.value" />
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</form>
<center>
<table width="100%" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.total_profiles}:&nbsp;{$reccount}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form action="" name="frm" method="post" >
			<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
			{if $errmsg != ''}
				<tr><td colspan="9"><span class="errors">{$lang.errormsgs[$errmsg]}</span></td></tr>
				<tr><td colspan="9">&nbsp;</td></tr>
			{/if}
				<tr>
					<td>
						<table width="540" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
							<tr class="table_head">
								<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtchk[]',this.checked)" /></th>
			  					<th nowrap>{$lang.col_head_srno}</th>
			  					<th nowrap><a href="?sort={$lang.col_head_id}&amp;type={$sort_type}">{$lang.col_head_id}</a></th>
			  					<th nowrap><a href="?sort={$lang.col_head_username}&amp;type={$sort_type}">{$lang.col_head_username}</a></th>
			  					<th nowrap>{* <a href="?sort={$lang.col_head_fullname}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}"> *}{$lang.col_head_fullname}{* </a> *}</th>
			  					<th nowrap><a href="?sort={$lang.col_head_gender}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}">{$lang.col_head_gender_short}</a></th>
			  					<th nowrap><a href="?sort={$lang.level_hdr}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}">{$lang.level_hdr}</a></th>
			  					<th nowrap><a href="?sort={$lang.col_head_status}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}">{$lang.col_head_status}</a></th>
			  					<th colspan="3" >{$lang.action}</th>
							</tr>
							{assign var="n" value="$upr"}
						{foreach item=item key=key from=$data}
							{math equation="$n+1" assign="n" }
							<tr class="{cycle values="oddrow,evenrow"}">
			  					<td align="center"><input type="checkbox" name="txtchk[]" value="{$item.id}" /></td>
			  					<td nowrap>{$n}</td>
			  					<td nowrap>{$item.id}</td>
			  					<td nowrap>{$item.username}</td>
			  					<td nowrap>{$item.firstname|stripslashes}&nbsp;{$item.lastname|stripslashes}</td>
			  					<td nowrap align="center">{$item.gender}</td>
								<td nowrap align="center">{$mships[$item.level]}</td>
			  					<td nowrap>{$lang.status_disp[$item.status]}</td>
			  					<td nowrap><a href="?edit={$item.id}"><img src="images/button_edit.png" border="0" alt="" /></a></td>
			  					<td nowrap><a href="featured_profile.php?req_action=add&amp;userid={$item.id}&amp;bckurl=profile.php"><img src="images/featured.gif" border="0" alt="" /></a></td>
								<td nowrap><a href="#" onclick="javascript:confirmDelete({$item.id},'{$lang.admin_js__delete_error_msgs[4]}')"><img src="images/button_drop.png" alt="Delete" border="0" /></a></td>
							</tr>
						{/foreach}
						</table>
					</td>
				</tr>
				<tr>
					<td align="center">
						<b>
					{if $total_pages|@count > 1}
						{assign var="pageno" value=$smarty.get.offset}
						{if $pageno == ""}{assign var="pageno" value=1}{/if}
						{if $pageno != "1"}
							<a href="?offset=1&amp;{$querystring|escape:"url"}">{$lang.first}</a>&nbsp;|&nbsp;
							<a href="?offset={$pageno-1}&amp;{$querystring|escape:"url"}">{$lang.previous}</a>&nbsp;|&nbsp;
						{/if}
						{if $total_pages|@count <= 5}
						{foreach item=pagenos from=$total_pages}
							{if $pageno != $pagenos}
								<a href="?offset={$pagenos}&amp;{$querystring|escape:"url"}">{$pagenos}</a>&nbsp;
							{else}
								[{$pagenos}]&nbsp;
							{/if}
						{/foreach}
						{else}
						{foreach item=pagenos from=$pages_show}
							{if $pageno != $pagenos}
								<a href="?offset={$pagenos}&amp;{$querystring|escape:"url"}">{$pagenos}</a>&nbsp;
							{else}
								[{$pagenos}]&nbsp;
							{/if}
						{/foreach}
					<!--<a href="?offset={$pagenos+1}&{$querystring|escape:"url"}">Next</a>-->
						{/if}
						{if $pageno !=  $total_pages|@count}
							&nbsp;|&nbsp;<a href="?offset={$pageno+1}&amp;{$querystring|escape:"url"}">{$lang.next}</a>&nbsp;|&nbsp;
							<a href="?offset={$total_pages|@count}&amp;{$querystring|escape:"url"}">{$lang.last}</a>
						{/if}
					{/if}
						</b>
					</td>
				</tr>
				<tr>
					<td colspan="3" align="center">&nbsp;</td>
				</tr>
				<tr>
					<td colspan="3" >
						<table border="0" cellpadding="0" cellspacing="0">
							<tr>
				 				<td><img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
			 					{foreach key=key item=item1 from=$lang.status_disp}
									<input type="submit" class="formbutton" value="{$item1}" name="groupaction" />&nbsp;
								{/foreach}
								<input type="button" class="formbutton" value="{$lang.delete_selected}" name="del01" onclick="javascript: confdel(form);" />&nbsp;
								<input type="hidden" name="delete_selected" value="" />
								<input type="submit" class="formbutton" value="{$lang.changeto}" name="groupaction" />&nbsp;
								<select name="txtmlevel">
									{html_options options=$mships}
								</select>
			 					</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
    </form>
			<br />
			<table width="100%" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail_inside" width="100%">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="526">{$lang.filter_records}</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
            <form action="profile.php" method="post" >
              <input type="hidden" name="filter" value="1" />
						<table width="540" border="0" cellspacing="2" cellpadding="1" align="center">
							<tr>
								<td>
								{if $smarty.post.txtsrchat == '' }
									{$lang.search_at}:&nbsp;<select name="txtsrchat">{html_options options=$lang.filter_options selected="username"}</select>
								{else}
									{$lang.search_at}:&nbsp;<select name="txtsrchat">{html_options options=$lang.filter_options selected=$smarty.post.txtsrchat}</select>
								{/if}
									&nbsp;{$lang.criteria}:&nbsp;<input type="text" name="txtsearch" size="30" value="{$smarty.post.txtsearch}" />&nbsp;
									<input type="submit" class="formbutton" value="{$lang.search}" />
								</td>
							</tr>
						</table>
          </form>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</center>
{/strip}