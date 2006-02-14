{strip}
<script type="text/javascript">
/* <![CDATA[ */
{literal}
function confdel(form,errmsg){
	for(i=0;i < form.length;i++){
		if(form.elements[i].type=='checkbox' && form.elements[i].checked == true){
			selected = true;
			break;
		}
		else {
			selected = false;
		}
	}
	if(!selected) {
		alert(errmsg);
		return false;
	}else{
		form.submit();
		return true;
	}
}
function confirmDelete(sectionid,conmsg,form)
{
/*  frmDelPoll = document.getElementsByName ("frmDelPoll").namedItem ("frmDelPoll"); */
	if (confirm(conmsg)){
		document.frmDelPoll.txtid.value=sectionid;
		document.frmDelPoll.submit();
	}
}
function addPoll(form)
{
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------\n" + String.fromCharCode(13)+ String.fromCharCode(10);
{/literal}
	CheckFieldString("noblank",form.txtpoll,"{$lang.poll_error.txtpoll_noblank}");
{literal}
	result="";
	if( ErrorCount > 0)
	{
		for( c in ErrorMsg)
			result += ErrorMsg[c];
		alert(result);
		return false;
	}
/*  frmAddPoll = document.getElementsByName ("frmAddPoll").namedItem ("frmAddPoll");  */
	document.frmAddPoll.txtpoll.value=form.txtpoll.value;
	document.frmAddPoll.submit();
}
{/literal}
/* ]]> */
</script>

<form name="frmDelPoll" action="managepoll.php" method="post">
  <input type="hidden" name="txtid" value="" />
  <input type="hidden" name="delaction" value="Yes" />
  <input type="hidden" name="frm" value="frmDelPoll" />
</form>
<form name="frmAddPoll" action="managepoll.php" method="post">
  <input type="hidden" name="txtpoll" value="" />
  <input type="hidden" name="frm" value="frmAddPoll" />
</form>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.manage_polls}</td>
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
					{$lang.total_polls}:&nbsp;{$data|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form name="frmGroupPoll" action="managepoll.php" method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550">
		  	<tbody>
			    <tr class="table_head">
				  	<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
	  				<th>{$lang.col_head_srno}</th>
	  				<th><a href="?sort={$lang.poll|escape:url}&amp;type={$sort_type}">{$lang.poll}</a></th>
	  				<th><a href="?sort={$lang.col_head_sendtime|escape:url}&amp;type={$sort_type}">{$lang.col_head_sendtime}</a></th>
	  				<th><a href="?sort={$lang.col_head_enabled|escape:url}&amp;type={$sort_type}">{$lang.col_head_enabled}</a></th>
	  				<th><a href="?sort={$lang.active|escape:url}&amp;type={$sort_type}">{$lang.active}</a></th>
	  				<th colspan="2" >{$lang.action}</th>
				</tr>
				{assign var="mcount" value="0"}
			{foreach item=item key=key from=$data}
				{math equation="$mcount+1" assign="mcount"}
				<tr class="{cycle values="oddrow,evenrow"}">
		  			<td align="center"><input type="checkbox" name="txtcheck[]" value="{$item.pollid}" /></td>
		  			<td>{$mcount}</td>
		  			<td><a href="polloptions.php?pollid={$item.pollid}">{$item.question|stripslashes}</a>{if $item.suggested_by > 0}&nbsp;({$lang.suggested_by} &nbsp;{$item.suggested_by_username}){/if}</td>
		  			<td nowrap>{$item.date|date_format:$lang.DATE_FORMAT}</td>
		  			<td nowrap>{$lang.enabled_values[$item.enabled]}</td>
		  			<td nowrap>
		  			{if $item.active == 0 or $item.date < $smarty.now }
						<a href="?active=poll&amp;pollid={$item.pollid}">{$lang.activate}</a>
					{elseif $item.active == 1}
						{$lang.active}
					{/if}
		  			</td>
		  			<td><a href="?edit={$item.pollid}"><img src="images/button_edit.png" alt="Edit" border="0" /></a></td>
		  			<td><a href="#" onclick="confirmDelete({$item.pollid},'{$lang.admin_js__delete_error_msgs[8]}')"><img src="images/button_drop.png" alt="Delete" border="0" /></a></td>
				</tr>
			{/foreach}
				<tr>
					<td colspan="2">&nbsp;</td>
					<td><input type="text" name="txtpoll" maxlength="255" size="52" /></td>
					<td colspan="6">
						<input type="button" class="formbutton" name="btnAdd" value="{$lang.submit}" onclick="addPoll(this.form);" />
					</td>
				</tr>
				<tr><td colspan="9">&nbsp;</td></tr>
				<tr>
		 			<td colspan="9"><img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
		 				<input type="submit" class="formbutton" value="{$lang.activate}" name="groupaction" />&nbsp;&nbsp;
		 				<input type="submit" class="formbutton" value="{$lang.delete_selected}" name="groupaction" />&nbsp;&nbsp;
		 				<input type="submit" class="formbutton" value="{$lang.enable_selected}" name="groupaction" />&nbsp;&nbsp;
		 				<input type="submit" class="formbutton" value="{$lang.disable_selected}" name="groupaction" />
		 			</td>
				</tr>
  			</tbody>
			</table>
      </form>
		</td>
	</tr>
</table>
</center>
{/strip}