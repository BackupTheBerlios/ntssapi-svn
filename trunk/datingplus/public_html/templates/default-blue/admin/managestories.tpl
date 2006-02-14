{strip}
<script type="text/javascript">
/* <![CDATA[ */
{literal}
function checkAll(form,name,val){
	for( i=0 ; i < form.length ; i++)
		if( form.elements[i].type == 'checkbox' && form.elements[i].name == name )
			form.elements[i].checked = val;
}
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
/*  frmDelStory = document.getElementsByName ("frmDelStory").namedItem ("frmDelStory"); */
	if (confirm(conmsg)) {
		document.frmDelStory.deletestory.value=sid;
		document.frmDelStory.submit();
	}
}
/* ]]> */
{/literal}
</script>

<form name="frmDelStory" action="managestory.php" method="post">
  <input type="hidden" name="deletestory" value="" />
  <input type="hidden" name="frm" value="frmDelStory" />
</form>
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.manage_story}</td>
	</tr>
</table>
<br />
<center>
<table width="573" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
						{$lang.total_stories}&nbsp;{$total_recs}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form action="" name="frm" method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
			<table width="540" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td>
						<table width="540" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
							<tr>
								<td colspan="4"><a href="storyins.php">{$lang.insert_story}</a></td>
								<td colspan="3" align="right">
									{$lang.results_per_page}:&nbsp;
									<select name="results_per_page">
										{html_options options=$lang.search_results_per_page selected=$psize}
									</select>&nbsp;
									<input type="button" class="formbutton" value="{$lang.show}" onclick="document.location='?results_per_page=' + results_per_page.value" />							
								</td>
							</tr>
							<tr class="table_head">
			  					<th nowrap>{$lang.col_head_srno}</th>
			  					<th nowrap><a href="?sort={$lang.col_head_id}&amp;type={$sort_type}">{$lang.col_head_id}</a></th>
			  					<th nowrap><a href="?sort={$lang.col_head_sendtime}&amp;type={$sort_type}">{$lang.col_head_sendtime}</a></th>
			  					<th nowrap><a href="?sort={$lang.story_sender}&amp;type={$sort_type}">{$lang.story_sender}</a></th>
			  					<th nowrap><a href="?sort={$lang.news_header}&amp;type={$sort_type}&amp;offset={$smarty.get.offset}">{$lang.news_header}</a></th>
			  					<th colspan="2" >{$lang.action}</th>
							</tr>
							{assign var="n" value="$upr"}
						{foreach item=item key=key from=$data}
							{math equation="$n+1" assign="n" }
							<tr class="{cycle values="oddrow,evenrow"}">
			  					<td nowrap>{$n}</td>
			  					<td nowrap>{$item.storyid}</td>
			  					<td nowrap>{$item.date|date_format:$lang.DATE_FORMAT}</td>
			  					<td nowrap><a href="profile.php?edit={$item.sender}">{$users[$item.sender]}</a></td>
			  					<td nowrap>{$item.header|stripslashes}</td>
			  					<td nowrap><a href="?edit={$item.storyid}"><img src="images/button_edit.png" border="0" alt="" /></a></td>
			  					<td><a href="#" onclick="confirmDelete({$item.storyid},'{$lang.admin_js__delete_error_msgs[6]}')"><img src="images/button_drop.png" alt="Delete" border="0" /></a></td>
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
					{* else}
						{$lang.previous}&nbsp; *}
					{/if}
					{if $total_recs > $psize}
						<a href="?offset={$pageno+1}&amp;{$querystring}">{$lang.next}</a>&nbsp;
					{* else}
						{$lang.next}&nbsp;  *}
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