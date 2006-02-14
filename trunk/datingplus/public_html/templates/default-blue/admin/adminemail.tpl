{strip}
{include file="admin/popheader.tpl"}

<script type="text/javascript">
/* <![CDATA[ */
{literal}
function confirmDelete(optid,conmsg){

	if (confirm(conmsg))
		document.location='?delete=' + optid;
}
function addEmail(form){
	
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13)+ String.fromCharCode(10);
{/literal}
	CheckFieldString("noblank",form.txtemail,"{$lang.signup_js_errors.username_noblank}");
	CheckFieldString("email",form.txtemail,"");
{literal}
	result="";
	if( ErrorCount > 0)
	{
		for( c in ErrorMsg)
			result += ErrorMsg[c];
		alert(result);
		return false;
	}
	document.frmAddEmail.txtemail.value=form.txtemail.value;
	document.frmAddEmail.submit();
}
{/literal}
/* ]]> */
</script>

<form name="frmAddEmail" action="?" method="post">
<input type="hidden" name="txtemail" value="" />
<input type="hidden" name="frm" value="frmAddEmail" />
</form>

<form name="frmAdminEmails" method="post"  action="modifyoption.php" onSubmit="javascript: return confdel('{$lang.admin_js_error_msgs[1]}');">
<input type="hidden" name="frm" value="frmAdminEmails" />
<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" >
	<tr class="table_head">
		<td >{$lang.col_head_srno}</td>
		<td ><a href="?sort={$lang.col_head_email}&amp;type={$sort_type}">{$lang.col_head_email}</a></td>
		<td >{$lang.action}</td>
	</tr>
		{if $question.control_type != 'textarea' }
			{assign var="mcount" value="0"}
			{foreach key=key item=item from=$emails}
			{math equation="$mcount+1" assign="mcount"}
	<tr class="{cycle values="oddrow,evenrow"}">
		<td>{$mcount}</td>
		<td>{$item.email}</td>
		<td><a href="#" onclick="confirmDelete({$item.id},'{$lang.admin_js_error_msgs[2]}');"><img src="images/button_drop.png" border="0" alt="" /></a></td>
	</tr>
			{/foreach}
		{/if}
	<tr>
		<td>&nbsp;</td>
		<td><input type="text" name="txtemail" maxlength="255" size="30" /></td>
		<td colspan="2">
			<input type="button" class="formbutton" name="btnAddEmail" value="{$lang.submit}" onclick="addEmail(this.form);" />
		</td>
	</tr>
	<tr>
		<td colspan="2" align="center" height="16">
			<input type="button" class="formbutton" value="{$lang.close_window}" onClick="javascript: window.close();" />
		</td>
	</tr>
</table>
</form>
{include file="admin/popfooter.tpl"}
{/strip}