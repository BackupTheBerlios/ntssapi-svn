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
function confirmDelete(optid,pid,conmsg)
{
/*  frmDelOption = document.getElementsByName ("frmDelOption").namedItem ("frmDelOption"); */
  if (confirm(conmsg)){
    document.frmDelOption.txtoptionid.value=optid;
    document.frmDelOption.txtpollid.value=pid;
    document.frmDelOption.submit();
  }
}

function addOption(form)
{
  ErrorCount=0;
  ErrorMsg = new Array();
  ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------\n" + String.fromCharCode(13)+ String.fromCharCode(10);
{/literal}
  CheckFieldString("noblank",form.txtpolloption,"{$lang.poll_error.txtpollopt_noblank}");
{literal}
  result="";
  if( ErrorCount > 0)
  {
    for( c in ErrorMsg)
      result += ErrorMsg[c];
    alert(result);
    return false;
  }
/*  frmAddOption = document.getElementsByName ("frmAddOption").namedItem ("frmAddOption"); */

  document.frmAddOption.txtpollid.value=form.txtpollid.value;
  document.frmAddOption.txtoptionid.value=form.txtoptionid.value;
  document.frmAddOption.txtpolloption.value=form.txtpolloption.value;
  document.frmAddOption.txtenabled.value=form.txtenabled.value;
  document.frmAddOption.submit();
}

function addNewOption(form)
{
  if( form.txtpolloption.value == "" ) {
{/literal}
    alert( "{$lang.poll_error.txtpollopt_noblank}" )
{literal}
  return false;
  }
return true;
}

{/literal}
/* ]]> */
</script>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="494"><a href="managepoll.php" class="subhead">{$lang.manage_polls}</a>&nbsp;>&nbsp;{$lang.modify_options}</td>
		<td class="module_head"><table><tr class="table_head"><td><a href="managepoll.php" class="subhead">{$lang.back}</a></td></tr></table></td>
	</tr>

</table>
  <form name="frmDelOption" action="polloptions.php" method="post">
    <input type="hidden" name="txtpollid" value="" />
    <input type="hidden" name="txtoptionid" value="" />
    <input type="hidden" name="delaction" value="Yes" />
    <input type="hidden" name="frm" value="frmDelOption" />
  </form>

  <form name="frmAddOption" action="addpolloption.php" method="post">
    <input type="hidden" name="txtpollid" value="" />
    <input type="hidden" name="txtoptionid" value="" />
    <input type="hidden" name="txtpolloption" value="" />
    <input type="hidden" name="txtenabled" value="" />
    <input type="hidden" name="frm" value="frmAddOption" />
  </form>

<br />
<center>
	<table width="550" border="0" cellpadding="0" cellspacing="0" >
		<tr>
			<td class="module_detail_inside" width="100%">
				<table width="100%" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td class="module_head" width="6"></td>
						<td class="module_head" width="400">
							{$lang.poll}:&nbsp;{$poll_question|stripslashes}
						</td>
						<td class="module_head" width="126">
							 {$lang.total_options}&nbsp;{$data|@count}
						</td>
						<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
					</tr>
				</table>
			{if $data|@count > 0 }
        <form name="frmOptions" action="polloptions.php" method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
        <table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
          <tbody>
					{if $smarty.get.msg}
					<tr align="center"><td colspan="8" ><span class='errormsg'>{$smarty.get.msg}</span></td>
					</tr>
					<tr><td colspan="6">&nbsp;</td></tr>
					{/if}
    				<tr class="table_head">
	  					<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
	  					<th>{$lang.col_head_srno}</th>
	  					<th><a href="?sort={$lang.option}&amp;type={$sort_type}&amp;pollid={$pollid}">{$lang.option}</a></th>
	  					<th><a href="?sort={$lang.votes}&amp;type={$sort_type}&amp;pollid={$pollid}">{$lang.votes}</a></th>
	  					<th><a href="?sort={$lang.col_head_enabled}&amp;type={$sort_type}&amp;pollid={$pollid}">{$lang.col_head_enabled}</a></th>
	  					<th colspan="2" >{$lang.action}</th>
					</tr>
					{assign var="mcount" value="0"}
				{foreach item=item key=key from=$data}
					{math equation="$mcount+1" assign="mcount"}
					<tr class="{cycle values="oddrow,evenrow"}">
		  				<td align="center"><input type="checkbox" name="txtcheck[]" value="{$item.optionid}" /></td>
		  				<td>{$mcount}</td>
		  				<td>{$item.opt|stripslashes}</td>
		  				<td align="center">{$item.result} </td>
		  				<td>{if $item.enabled == 'Y'} {$lang.yes} {else} {$lang.no} {/if}</td>
		  				<td><a href="?edit={$item.optionid}"><img src="images/button_edit.png" border="0" alt="" /></a></td>
		  				<td><a href="#" onclick="confirmDelete('{$item.optionid}','{$item.pollid}','{$lang.admin_js__delete_error_msgs[9]}')"><img src="images/button_drop.png" border="0" alt="" /></a></td>
					</tr>
				{/foreach}
					<tr>
						<td colspan="2">&nbsp;</td>
						<td colspan="2"><input type="hidden" name="txtpollid" value="{$item.pollid}" />
              <input type="hidden" name="txtoptionid" value="{$item.optionid}" />
              <input type="text" name="txtpolloption" maxlength="255" size="63" /></td>
						<td><select name="txtenabled">
		  					{html_options options=$lang.enabled_values}
							</select>
						</td>
						<td colspan="2">
							<input type="button" class="formbutton" name="btnAdd" value="{$lang.submit}" onclick="addOption(this.form);" />
						</td>
					</tr>
					<tr><td colspan="7">&nbsp;</td></tr>
					<tr>
		 				<td colspan="7"><img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
		 					<input type="submit" class="formbutton" value="{$lang.delete_selected}" name="groupaction" />&nbsp;
		 					<input type="submit" class="formbutton" value="{$lang.enable_selected}" name="groupaction" />&nbsp;
		 					<input type="submit" class="formbutton" value="{$lang.disable_selected}" name="groupaction" />
		 				</td>
					</tr>
        </tbody>
        </table>
		  </form>
      {else}
      <table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
        <tbody>
					<tr>
						<td>
							{$lang.no_record_found}&nbsp;{$lang.add_option_now}
              <form method="post" action="addpolloption.php" name="frmNewOpt">
							<table cellspacing="2" cellpadding="1">
								<input type="hidden" name="txtpollid" value="{$pollid}" />
								<tr>
									<td>{$lang.option}:<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
									<td><input type="text" name="txtpolloption" maxlength="255" size="53" /></td>
								</tr>
								<tr>
									<td>{$lang.col_head_enabled}:</td>
									<td><select name="txtenabled">
										{html_options options=$lang.enabled_values}
										</select>
									</td>
								</tr>
								<tr>
									<td colspan="2">
										<input type="submit" class="formbutton" name="btnAdd" value="{$lang.submit}" onclick=" return addNewOption(this.form);" />
									</td>
								</tr>
							</table>
              </form>
						</td>
					</tr>
			{/if}
			</td>
		</tr>
	</table>
</center>
{/strip}
