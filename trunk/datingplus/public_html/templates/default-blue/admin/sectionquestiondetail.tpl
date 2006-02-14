{strip}
<script type="text/javascript" src="../javascript/check.js"></script>
<script language="JavaScript" type="text/javascript">
/* <![CDATA[ */
{literal}

function confirmDelete(section,questionid,optid,conmsg)
{
	if (confirm(conmsg))
		document.location='?sectionid=' + section + '&questionid=' + questionid + '&delete=' + optid;
}
function confdel(errmsg){
	for(i=0;i < document.frmQuestionDetail.length;i++){
		if(document.frmQuestionDetail.elements[i].type=='checkbox' && document.frmQuestionDetail.elements[i].checked == true){
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
		document.frmQuestionDetail.submit();
		return true;
	}
}
function addOption(form)
{
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13)+ String.fromCharCode(10);
{/literal}
	CheckFieldString("noblank",form.txtanswer,"{$lang.signup_js_errors.username_noblank}");
	CheckFieldString("noblank",form.txtenabled,"{$lang.signup_js_errors.password_noblank}");
	CheckFieldString("full",form.txtanswer,"Text Values in section name");
{literal}
	result="";
	if( ErrorCount > 0)
	{
		for( c in ErrorMsg)
			result += ErrorMsg[c];
		alert(result);
		return false;
	}
	document.frmAddOption.txtanswer.value=form.txtanswer.value;
	document.frmAddOption.txtenabled.value=form.txtenabled.value;
	document.frmAddOption.submit();
	
}
{/literal}
/* ]]> */
</script>
<form name="frmQuestionDetail" method="post"  action="modifyoption.php" onSubmit="javascript: return confdel('{$lang.admin_js_error_msgs[1]}');">
	<input type="hidden" name="frm" value="frmQuestionDetail" />
	<input type="hidden" name="txtsectionid" value=	"{$smarty.get.sectionid}" />
	<input type="hidden" name="txtquestionid" value="{$smarty.get.questionid}" />
<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" /></td>
		<td class="module_head"><a href="section.php" class="subhead">{$lang.section_title}</a>&nbsp;>&nbsp;<a href="sectionquestions.php?sectionid={$smarty.get.sectionid}" class="subhead">{$lang.questions_title}</a>&nbsp;>&nbsp;{$lang.options_title}
		</td>			
	</tr>
</TABLE>
<BR />
<CENTER>
	<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
		<tr>
			<td class="module_detail_inside" width="100%">
				<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
					<tr>
						<td class="module_head" width="6"></td>
						<td class="module_head" width="400" style="padding-left:5px;">
							{$lang.question}&nbsp;{$question.question}
						</td>
						<td class="module_head" width="126">
						 	{$lang.total_options}&nbsp;{$options|@count}

						</td>
						<td width="28" valign="top" bgcolor="#D2E1F6"><img src="{$image_dir}blue_hor3.jpg" width="34" height="28" /></td>
					</tr>	
				</TABLE>
				<table class=table cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} border=0 width="550">
					{* <tr><td colspan="6">&nbsp;</td></tr> *}
					<tr class="table_head">
						<th><input type=checkbox name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
						<th>{$lang.col_head_srno}</th>
						<th><a href="?sectionid={$smarty.get.sectionid}&amp;questionid={$smarty.get.questionid}&amp;sort={$lang.col_head_answer}&amp;type={$sort_type}">{$lang.col_head_answer}</a></th>
						<th><a href="?sectionid={$smarty.get.sectionid}&amp;questionid={$smarty.get.questionid}&amp;sort={$lang.col_head_enabled}&amp;type={$sort_type}">{$lang.col_head_enabled}</a></th>	  	  
						<th colspan="2" >{$lang.action}</th>
					</tr>
				{if $question.control_type != 'textarea' }
					{assign var="mcount" value="0"}
				{foreach key=key item=item from=$options}
					{math equation="$mcount+1" assign="mcount"}
					<tr class="{cycle values="oddrow,evenrow"}"> 
						<td align="center"><input type="checkbox" name="txtcheck[]" value="{$item.id}" /></td>
						<td>{$mcount}</td>
						<td>{$item.answer|stripslashes}</td>
						<td>{$item.enabled}</td>
						<td><a href="?sectionid={$smarty.get.sectionid}&amp;edit={$item.id}"><img src="images/button_edit.png" border="0" /></a></td>
						<td><a href="#" onclick="javascript:confirmDelete({$smarty.get.sectionid},{$smarty.get.questionid},{$item.id},'{$lang.admin_js__delete_error_msgs[3]}');"><img src="images/button_drop.png" border="0" /></a></td>	  	  	  	  
					</tr>
				{/foreach}
				{/if}
					<tr>
						<td colspan="2">&nbsp;</td>
						<td><input type="text" name="txtanswer" maxlength="255" size="35" /></td>
						<td><select name="txtenabled">
		  					{html_options options=$lang.enabled_values}
							</select>
						</td>
						<td colspan="2">
							<input type="button" class="formbutton" name="btnAddOption" value="{$lang.submit}" onclick="addOption(this.form);" />
						</td>
					</tr>
					<tr>
						<td colspan="7"> <img src="images/arrow_ltr.png" />{$lang.with_selected}&nbsp;  
							<input type="submit" class="formbutton" value="{$lang.enable_selected}" name="groupaction"  />&nbsp;
							<input type="submit" class="formbutton" value="{$lang.disable_selected}" name="groupaction"  />
						</td>
					</tr>
				</table>
			</TD>
		</TR>
	</TABLE>
</CENTER>
</form>
<form name="frmAddOption" action="sectionquestiondetail.php?sectionid={$smarty.get.sectionid}&amp;questionid={$smarty.get.questionid}" method="post">
	<input type="hidden" name="txtanswer" value="" />
	<input type="hidden" name="txtquestion" value="{$smarty.get.questionid}" />
	<input type="hidden" name="txtenabled" value="" />
	<input type="hidden" name="frm" value="frmAddOption" />
</form>
{/strip}