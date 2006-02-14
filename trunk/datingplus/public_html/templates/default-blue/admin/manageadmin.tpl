{strip}
<script type="text/javascript">
/* <![CDATA[ */
{literal}
function confdel(form,errmsg){
	for(i=0;i < form.length;i++){
		if(form.elements[i].type=='checkbox' && form.elements[i].checked == true){
			selected = true;
			break;
		}else 
			selected = false;
	}
	if(!selected) {
		alert(errmsg);
		return false;
	}else{
		form.submit();
		return true;
	}
}
function confirmDelete(sid,conmsg)
{
	if (confirm(conmsg)) {
		document.frmDelAdmin.deleteadmin.value=sid;
		document.frmDelAdmin.submit();
	}
}
{/literal}
/* ]]> */
</script>

<form name="frmDelAdmin" action="manageadmin.php" method="post">
  <input type="hidden" name="deleteadmin" value="" />
  <input type="hidden" name="frm" value="frmDelAdmin" />
</form>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.manage_admins}</td>
	</tr>
</table>
<br />
<center>
<table width="550" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
						{$lang.total_admins}:&nbsp;{$total_recs}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form action="" name="frm" method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
			<table width="540" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td>
						<table width="540" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
							<tr><td colspan="3"><a href="adminins.php">{$lang.add_admin}</a></td>
								<td colspan="5" align="right">
								{$lang.results_per_page}:&nbsp;
								<select name="results_per_page">
									{html_options options=$lang.search_results_per_page selected=$psize}
								</select>&nbsp;
								<input type="button" class="formbutton" value="{$lang.show}" onclick="document.location='?results_per_page=' + results_per_page.value" />							
								</td>
							</tr>
							<tr class="table_head">
							  	<th nowrap width="5%">
							  	{$lang.col_head_srno}
							  	</th>
			  					<th nowrap width="5%">
			  						<a href="?sort={$lang.col_head_id|escape:url}&amp;type={$sort_type}">{$lang.col_head_id}</a>
			  					</th>
			  					<th nowrap width="20%">
			  						<a href="?sort={$lang.col_head_username|escape:url}&amp;type={$sort_type}">{$lang.col_head_username}</a>
			  					</th>
			  					<th nowrap width="30%">
			  						<a href="?sort={$lang.admin_col_head_fullname|escape:url}&amp;type={$sort_type}">{$lang.admin_col_head_fullname}</a>
			  					</th>
			  					<th nowrap width="10%">
			  						<a href="?sort={$lang.superuser|escape:url}&amp;type={$sort_type}">{$lang.superuser}</a>
			  					</th>
			  					<th nowrap width="10%">
			  						<a href="?sort={$lang.col_head_enabled|escape:url}&amp;type={$sort_type}">{$lang.col_head_enabled}</a>
			  					</th>
			  					<th colspan="2" width="10%" >
			  						{$lang.action}
			  					</th>
							</tr>
							{assign var="n" value="$upr"}
						{foreach item=item key=key from=$data}
							{math equation="$n+1" assign="n" }
							<tr class="{cycle values="oddrow,evenrow"}">
			  					<td nowrap>{$n}</td>
			  					<td nowrap>{$item.id}</td>
			  					<td nowrap>{$item.username}</td>
			  					<td nowrap>{$item.fullname|stripslashes}</td>
			  					<td nowrap>{$item.super_user}</td>
			  					<td nowrap>{$item.enabled}</td>
			  					<td nowrap align="center"><a href="?edit={$item.id}"><img src="images/button_edit.png" border="0" alt="" /></a>
			  					</td>
							{if $total_recs > 1 }				
			  					<td nowrap align="center"><a href="#" onclick="confirmDelete({$item.id},'{$lang.admin_js__delete_error_msgs[11]}')"><img src="images/button_drop.png" alt="Delete" border="0" /></a>
			  					</td>
							{else}
			  					<td nowrap align="center"> -- </td>
							{/if}
							</tr>
						{/foreach}
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="3" align="center">
					{assign var="pageno" value=$smarty.get.offset}
					{if $pageno == ""}{assign var="pageno" value=1}{/if}
					{if $pageno != "1"}
						<a href="?offset={$pageno-1}&amp;{$querystring}">{$lang.previous}</a>&nbsp;
					{*else}
						{$lang.previous}&nbsp;  *}
					{/if}
					{if $total_recs > $psize}
						<a href="?offset={$pageno+1}&amp;{$querystring}">{$lang.next}</a>&nbsp;
					{*else}
						{$lang.next}&nbsp; *}
					{/if}
					</td>
				</tr>
			</table>
      </form>
		</td>
	</tr>
</table>
</center>
{/strip}