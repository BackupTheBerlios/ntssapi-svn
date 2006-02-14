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
function confirmDelete(eventid,calendarid,conmsg)
{
	if (confirm(conmsg)){
		document.frmDelEvent.txtid.value=eventid;
		document.frmDelEvent.txtcalendarid.value=calendarid;
		document.frmDelEvent.submit();
	}
}
{/literal}
/* ]]> */
</script>

<form name="frmDelEvent" action="calendarevents.php" method="post">
  <input type="hidden" name="txtid" value="{$data.id}" />
  <input type="hidden" name="txtcalendarid" value="{$data.calendar}" />
  <input type="hidden" name="frm" value="frmDelEvent" />
</form>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" ><a href="calendar.php" class="subhead" >{$lang.calendar_title}</a>&nbsp;>&nbsp;{$lang.events_title}</td>
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
					<td class="module_head" width="400">
						{$lang.calendar}&nbsp;{$calendarname|stripslashes}
					</td>
					<td class="module_head" width="126">
						{$lang.total_events}&nbsp;{$data|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form name="frmEndisEvent" action="endisevents.php" method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
			<tbody>
				<tr><td colspan="7"><a href="?calendarid={$calendarid}&amp;insert=event">Add Event</a></td></tr>
				<tr align="center"><td colspan="6" >{if $lang.errormsgs[err] ne ""}<span class='errormsg'>{$lang.errormsgs[err]}</span>{/if}</td></tr>
			{if $data|@count > 0 }
				<tr class="table_head">
					<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
					<th>{$lang.col_head_datefrom}</th>
					<th>{$lang.col_head_dateto}</th>
					<th>{$lang.col_head_event}</th>
					<th>{$lang.col_head_enabled}</th>
					<th colspan="2" >{$lang.action}</th>
				</tr>
				{assign var="mcount" value="0"}
			{foreach item=item key=key from=$data}
				{math equation="$mcount+1" assign="mcount"}
				<tr class="{cycle values="oddrow,evenrow"}">
					<td align="center"><input type="checkbox" name="txtcheck[]" value="{$item.id}" /></td>
					<td>{$item.datetime_from|date_format:"%d/%m/%Y %I:%M %p"}</td>
					<td>{$item.datetime_to|date_format:"%d/%m/%Y %I:%M %p"}</td>
					<td>{$item.event|stripslashes}</td>
					<td>{$item.enabled}</td>
					<td><a href="?edit={$item.id}"><img src="images/button_edit.png" border="0" alt="" /></a></td>
					<td><a href="#" onclick="javascript:confirmDelete('{$item.id}','{$calendarid}','{$lang.admin_js__delete_error_msgs[25]}')"><img src="images/button_drop.png" border="0" alt="" /></a></td>
				</tr>
			{/foreach}
				<tr><td colspan="7">&nbsp;</td></tr>
				<tr>
					<td colspan="7"><img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
					<input type="submit" class="formbutton" value="{$lang.enable_selected}" name="groupaction" />&nbsp;
					<input type="submit" class="formbutton" value="{$lang.disable_selected}" name="groupaction" />
					</td>
				</tr>
			{else}
				<tr>
					<td>
						{$lang.no_record_found}
					</td>
				</tr>
			{/if}

			</tbody>
			</table>
        <input type="hidden" name="calendarid" value="{$calendarid}" />
      </form>
		</td>
	</tr>
</table>
</center>
{/strip}