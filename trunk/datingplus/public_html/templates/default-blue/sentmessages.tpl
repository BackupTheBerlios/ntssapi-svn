{strip}
<script type="text/javascript" src="javascript/check.js"></script>
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
{/literal}
/* ]]> */
</script>

<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.mail_messages}
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
				<tr>
					<td width="100%" align="center">

						<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" width="50%">
							<tr>
								<td width="33%"><a href="mailmessages.php" >{$lang.inbox}</a></td>
								<td width="33%">{$lang.sent}</td>
								<td width="33%"><a href="deletemessages.php" >{$lang.trashcan}({$deletemsg})</a></td>
							</tr>
						</table>

						<table width="550" border="0" cellpadding="0" cellspacing="0" >
							<tr>
								<td class="module_detail_inside" width="100%">

									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td class="module_head" width="6"></td>
											<td class="module_head">
												{$lang.sent|capitalize}
												</td>
											<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
										</tr>
									</table>
									<table width="100%" border="0">
										<tr>
											<td width="100%">
                        <form name="frmGroupMail" action="?sort={$smarty.get.sort}&amp;type={$smarty.get.type}"
                        method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
                        <input type="hidden" name="frm" value="frmGroupMail" />
												<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="98%" border="0" align="center">
													<tbody>
													<tr class="table_head">
														<th width="25"><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
														<th width="25">{$lang.col_head_srno}</th>
														<th width="200"><a href="?sort={$lang.col_head_subject}&amp;type={$sort_type}">{$lang.col_head_subject}</a></th>
														<th width="100"><a href="?sort={$lang.col_head_username}&amp;type={$sort_type}">{$lang.col_head_username}</a></th>
														<th width="100"><a href="?sort={$lang.col_head_sendtime}&amp;type={$sort_type}">{$lang.col_head_sendtime}</a></th>
													</tr>
													{assign var="mcount" value="0"}
												{foreach item=item key=key from=$data}
												{math equation="$mcount+1" assign="mcount"}
													<tr>
														<td><input type="checkbox" name="txtcheck[]" value="{$item.id}" /></td>
														<td>{$mcount}</td>
														<td><a href="showmessage.php?id={$item.id}&amp;messages=sent">{$item.subject}</a></td>
														<td><a href="showprofile.php?id={$item.recipientid}" target="_blank">{$item.username}</a></td>
														<td>{$item.sendtime|date_format:$lang.DATE_TIME_FORMAT}</td>
													</tr>
												{/foreach}
													<tr><td colspan="9">&nbsp;</td></tr>
													<tr>
														 <td colspan="9"><img src="admin/images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
															<input type="submit" class="formbutton" value="{$lang.delete}" name="groupaction" />
														 </td>
													</tr>
													</tbody>
												</table>
                        </form>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
