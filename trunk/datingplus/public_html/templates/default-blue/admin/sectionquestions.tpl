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
function confirmDelete(questionid,sectionid,conmsg)
{
  frmDelQuestion = document.getElementsByName ("frmDelQuestion").namedItem ("frmDelQuestion");
  if (confirm(conmsg)){
    frmDelQuestion.txtid.value=questionid;
    frmDelQuestion.txtsectionid.value=sectionid;
    frmDelQuestion.submit();
  }
}
{/literal}

/* ]]> */
</script>
<form name="frmDelQuestion" action="sectionquestions.php" method="post">
  <input type="hidden" name="txtid" value="{$data.id}" />
  <input type="hidden" name="txtsectionid" value="{$data.section}" />
  <input type="hidden" name="frm" value="frmDelQuestion" />
</form>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" ><a href="section.php" class="subhead" >{$lang.section_title}</a>&nbsp;>&nbsp;{$lang.questions_title}</td>
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
						{$lang.section}&nbsp;{$sectionname|stripslashes}
					</td>
					<td class="module_head" width="126">
						{$lang.total_questions}&nbsp;{$data|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form name="frmEndisQuestion" action="endisquestions.php" method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
			<tbody>
				<tr align="center"><td colspan="8" >{if $lang.errormsgs[err] ne ""}<span class='errormsg'>{$lang.errormsgs[err]}</span>{/if}</td></tr>
			{if $data|@count > 0 }
				<tr class="table_head">
					<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
					<th>{$lang.col_head_srno}</th>
					<th><a href="?sort={$lang.col_head_question|escape:url}&amp;type={$sort_type}&amp;sectionid={$sectionid}">{$lang.col_head_question}</a></th>
					<th><a href="?sort={$lang.col_head_enabled|escape:url}&amp;type={$sort_type}&amp;sectionid={$sectionid}">{$lang.col_head_enabled}</a></th>
					<th colspan="2" >{$lang.order}</th>
					<th colspan="2" >{$lang.action}</th>
				</tr>
				{assign var="mcount" value="0"}
			{foreach item=item key=key from=$data}
				{math equation="$mcount+1" assign="mcount"}
				<tr class="{cycle values="oddrow,evenrow"}">
					<td align="center"><input type="checkbox" name="txtcheck[]" value="{$item.id}" /></td>
					<td>{$mcount}</td>
				{if $item.control_type != 'textarea'}
					<td><a href='sectionquestiondetail.php?sectionid={$sectionid}&amp;questionid={$item.id}'>{$item.question|stripslashes}</a></td>
				{else}
					<td>{$item.question|stripslashes}</td>
				{/if}
					<td>{$item.enabled}</td>
				{if $mcount != 1 }
					<td><a href="?moveup={$item.id}&amp;sectionid={$sectionid}"><img src="images/uparrow.JPG" border="0" alt="" /></a></td>
				{else}
					<td>&nbsp;</td>
				{/if}
				{if $mcount != $data|@count}
					<td><a href="?movedown={$item.id}&amp;sectionid={$sectionid}"><img src="images/downarrow.JPG" border="0" alt="" /></a></td>
				{else}
					<td>&nbsp;</td>
				{/if}
					<td><a href="?edit={$item.id}"><img src="images/button_edit.png" border="0" alt="" /></a></td>
					<td><a href="#" onclick="confirmDelete('{$item.id}','{$sectionid}','{$lang.admin_js__delete_error_msgs[2]}')"><img src="images/button_drop.png" border="0" alt="" /></a></td>
				</tr>
			{/foreach}
				<tr><td colspan="7">&nbsp;</td></tr>
				<tr>
					<td colspan="7"><img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
					<input type="submit" class="formbutton" value="{$lang.delete_selected}" name="groupaction" />&nbsp;
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
        <input type="hidden" name="sectionid" value="{$sectionid}" />
      </form>
		</td>
	</tr>
</table>
</center>
{/strip}