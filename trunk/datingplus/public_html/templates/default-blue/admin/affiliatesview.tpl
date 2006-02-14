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

{/literal}
/* ]]> */
</script>
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.affiliate_title}</td>
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
					{$lang.total_affiliates}:&nbsp;{$data|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			<form name="frmGroupSelection" method="post" action="affiliatesview.php" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" align="center" width="530">
				<tr>
				<td colspan="6" align="right">
					{$lang.results_per_page}:&nbsp;
					<select name="results_per_page">
						{html_options options=$lang.search_results_per_page selected=$psize}
					</select>&nbsp;
					<input type="button" class="formbutton" value="{$lang.show}" onclick="document.location='?results_per_page=' + results_per_page.value" />							
				</td>
				</tr>
				<tr class="table_head">
					<th><input type="checkbox" name="chkbox" onclick="checkAll(this.form,'txtchk[]',this.checked)" /></th>
					<th>{$lang.col_head_srno}</th>
					<th nowrap><a href="?sort={$lang.col_head_name|escape:url}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}">{$lang.col_head_name}</a></th>
				  	<th nowrap><a href="?sort={$lang.col_head_email|escape:url}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}">{$lang.col_head_email}</a></th>
					<th nowrap><a href="?sort={$lang.col_head_register_at|escape:url}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}">{$lang.col_head_register_at}</a></th>
					<th nowrap><a href="?sort={$lang.col_head_status|escape:url}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}">{$lang.col_head_status}</a></th>
				</tr>
				{assign var="n" value="$upr"}
			{foreach item=item key=key from=$data}
				{math equation="$n+1" assign="n"}
				<tr class="{cycle values="oddrow,evenrow"}">
					<td align="center"><input type="checkbox" name="txtchk[]" value="{$item.id}" /></td>
					<td>{$n}</td>
					<td nowrap >{$item.name}</td>
					<td nowrap >{$item.email}</td>
					<td nowrap >{$item.regdate|date_format:$lang.DATE_FORMAT}</td>
					<td nowrap >{$lang.status_disp[$item.status]}</td>
				</tr>
			{/foreach}
				<tr>
					<td align="center" colspan="6">
					{assign var="pageno" value=$smarty.get.offset}
					{if $pageno == ""}{assign var="pageno" value=1}{/if}
					{if $pageno != "1"}
						<a href="?offset={$pageno-1}&amp;{$querystring|escape:url}">{$lang.previous}</a>&nbsp;
					{else}
						{$lang.previous}&nbsp;
					{/if}
					{if $data|@count >= $psize}
						<a href="?offset={$pageno+1}&amp;{$querystring|escape:url}">{$lang.next}</a>&nbsp;
					{else}
						{$lang.next}
					{/if}
					</td>
				</tr>
				<tr>
					<td colspan="6">
						<img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
						{foreach key=key item=item1 from=$lang.status_disp}
							<input type="submit" class="formbutton" value="{$item1}" name="groupaction" />&nbsp;
						{/foreach}
					</td>
				</tr>
				<tr><td colspan="6"></td></tr>
			</table>
			</form>
		</td>
	</tr>
</table>
</center>
{/strip}