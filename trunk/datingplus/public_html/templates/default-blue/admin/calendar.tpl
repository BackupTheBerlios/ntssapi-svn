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
function confirmDelete(calendarid,conmsg,form)
{
	if (confirm(conmsg)){
		document.forms['frmDelcalendar'].txtid.value=calendarid;
		document.forms['frmDelcalendar'].submit();
	}
}
function addcalendar(form)
{
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(10)+ String.fromCharCode(13);
{/literal}
	CheckFieldString("noblank",form.txtcalendar,"{$lang.signup_js_errors.calendarname_noblank}");
	CheckFieldString("text",form.txtcalendar,"{$lang.signup_js_errors.calendarname_charset}");
{literal}
	result="";
	if( ErrorCount > 0)
	{
		for( c in ErrorMsg)
		{	//alert(c);
			result += ErrorMsg[c];
		}
		alert(result);
		return false;
	}
	document.forms['frmAddcalendar'].txtcalendar.value=form.txtcalendar.value;
	document.forms['frmAddcalendar'].txtenabled.value=form.txtenabled.value;
	document.forms['frmAddcalendar'].submit();
}
{/literal}
/* ]]> */
</script>

<form name="frmDelcalendar" action="calendar.php" method="post">
  <input type="hidden" name="txtid" value="" />
  <input type="hidden" name="delaction" value="Yes" />
  <input type="hidden" name="frm" value="frmDelcalendar" />
</form>

<form name="frmAddcalendar" action="calendar.php" method="post">
  <input type="hidden" name="txtcalendar" value="" />
  <input type="hidden" name="txtenabled" value="" />
  <input type="hidden" name="frm" value="frmAddcalendar" />
</form>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.calendar_title}</td>
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
					{$lang.total_calendars}&nbsp;{$data|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form name="frmGroupcalendar" action="groupcalendar.php" method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550">
  			<tbody>
    			<tr class="table_head">
	  				<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
	  				<th>{$lang.col_head_srno}</th>
	  				<th><a href="?sort={$lang.col_head_name|escape:url}&amp;type={$sort_type}">{$lang.col_head_name}</a></th>
	  				<th><a href="?sort={$lang.col_head_enabled|escape:url}&amp;type={$sort_type}">{$lang.col_head_enabled}</a></th>
	  				<th colspan="2" >{$lang.order}</th>
	  				<th colspan="2" >{$lang.action}</th>
				</tr>
				{assign var="mcount" value="0"}
			{foreach item=item key=key from=$data}
				{math equation="$mcount+1" assign="mcount"}
				<tr class="{cycle values="oddrow,evenrow"}">
		  			<td align="center"><input type="checkbox" name="txtcheck[]" value="{$item.id}" /></td>
		  			<td>{$mcount}</td>
		  			<td><a href="calendarevents.php?calendarid={$item.id}">{$item.calendar|stripslashes}</a></td>
		  			<td>{$item.enabled}</td>
		  		{if $mcount != 1 }
			  		<td><a href="?moveup={$item.id}"><img src="images/uparrow.JPG" alt="Move Up" border="0"/></a></td>
		  		{else}
					<td>&nbsp;</td>
		  		{/if}
		  		{if $mcount != $data|@count}
			  		<td><a href="?movedown={$item.id}"><img src="images/downarrow.JPG" alt="Move Down" border="0"/></a></td>
		  		{else}
					<td>&nbsp;</td>
		  		{/if}
		  			<td><a href="?edit={$item.id}"><img src="images/button_edit.png" alt="Edit" border="0" /></a></td>
		  			<td><a href="#" onclick="javascript:confirmDelete({$item.id},'{$lang.admin_js__delete_error_msgs[26]}')"><img src="images/button_drop.png" alt="Delete" border="0" /></a></td>
				</tr>
			{/foreach}
				<tr>
					<td colspan="2">&nbsp;</td>
					<td><input type="text" name="txtcalendar" maxlength="255" /></td>
					<td><select name="txtenabled">
		  				{html_options options=$lang.enabled_values}
						</select>
					</td>
					<td colspan="5">
						<input type="button" class="formbutton" name="btnAdd" value="{$lang.submit}" onclick="addcalendar(this.form);" />
					</td>
				</tr>
				<tr><td colspan="9">&nbsp;</td></tr>
				<tr>
				 	<td colspan="9"><img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
		 			<input type="submit" class="formbutton" value="{$lang.delete_selected}" name="groupaction" />&nbsp;
		 			<input type="submit" class="formbutton" value="{$lang.enable_selected}" name="groupaction" />&nbsp;
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