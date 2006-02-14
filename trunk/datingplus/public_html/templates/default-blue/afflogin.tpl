{strip}
<script type="text/javascript">
/* <![CDATA[ */
{literal}
function validateForm(form)
{
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13);

	CheckFieldString("noblank",form.txtusername,"{$lang.signup_js_errors.email_noblank}");
	CheckFieldString("noblank",form.txtpassword,"{$lang.signup_js_errors.password_noblank}");
	CheckFieldString("email",form.txtusername,"{$lang.signup_js_errors.email_notvalid}");

	// concat all error messages into one string
	result="";
	if( ErrorCount > 0)
	{
		//for( c in ErrorMsg)
			//result += ErrorMsg[c];
		alert(ErrorMsg[1]);
		return false;
	}
	return true;
}
{/literal}
/* ]]> */
</script>
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
					{$lang.affiliate_login_title}
					</td>
				</tr>
			</table>
        <form name="frmAfflogin" method="post" action="affmidlogin.php" onsubmit="return(validateForm(this.form));">
			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
				<tbody>
			{if $smarty.get.errid ne ''}
				<tr>
				  	<td colspan="2">
						 <font color="{$lang.error_msg_color}">{$lang.errormsgs[$smarty.get.errid]}</font><br /><br />
				  	</td>
				</tr>
			{/if}
				<tr>
				  	<td colspan="2"><font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>{$lang.required_info_indication}</td>
				</tr>
				<tr>
				  	<td height="2" width="110">{$lang.signup_email}
						<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
				  	</td>
				  	<td height="2" >
						<input class="input" maxlength="25" name="txtusername" size="20"/>
				  	</td>
				</tr>
				<tr>
				  	<td>{$lang.signup_password}
				  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
				  	<td> <input class="input" type="password" name="txtpassword" size="20"/>
				  	</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<input type="submit" class="formbutton" value="{$lang.login_submit}"/>
					</td>
				</tr>
				</tbody>
			</table>
        </form>
			<br />
		</td>
	</tr>
</table>
{/strip}
