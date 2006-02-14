
<script type="text/javascript">
/* <![CDATA[ */
function validate(form)
{ldelim}
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13);

	CheckFieldString("noblank",form.txtname,"{$lang.signup_js_errors.name_noblank}");
	CheckFieldString("text",form.txtname,"{$lang.signup_js_errors.name_charset}");
	
	CheckFieldString("noblank",form.txtemail,"{$lang.signup_js_errors.email_noblank}");
	CheckFieldString("email",form.txtemail,"{$lang.signup_js_errors.email_notvalid}");

	CheckFieldString("noblank",form.txtpassword,"{$lang.signup_js_errors.password_noblank}");
	CheckFieldString("noblank",form.txtconpassword,"{$lang.signup_js_errors.password_noblank}");
	CheckFieldString("alphanum",form.txtpassword,"{$lang.signup_js_errors.password_charset}");	
	CheckFieldString("alphanum",form.txtpassword,"");

		if(form.txtname.value.length >= {$config.min_username_len} ){ldelim}
			if ( !isNaN(form.txtname.value.charAt(0)) ){ldelim}
				ErrorCount++;
				ErrorMsg[ErrorCount] = "{$lang.signup_js_errors.username_start_alpha}"  + String.fromCharCode(13);
			{rdelim}
		{rdelim}else{ldelim}
			ErrorCount++;
			ErrorMsg[ErrorCount] = "{$lang.signup_js_errors.username_outrange}"  + String.fromCharCode(13);		
		{rdelim}

	if( form.txtpassword.value.length >= {$config.min_pass_len} && form.txtpassword.value.length <= {$config.max_pass_len}){ldelim}
		if ( form.txtpassword.value != form.txtconpassword.value ){ldelim}
			ErrorCount++;
				ErrorMsg[ErrorCount] = "{$lang.signup_js_errors.password_nomatch}"  + String.fromCharCode(13);
		{rdelim}
	{rdelim}else{ldelim}
		ErrorCount++;
		ErrorMsg[ErrorCount] = "{$lang.signup_js_errors.password_outrange}"  + String.fromCharCode(13);	
	{rdelim}


	/* concat all error messages into one string */
	result="";
	if( ErrorCount > 0)
	{ldelim}
		alert(ErrorMsg[1]);
		return false;
	{rdelim}
	return true;
{rdelim}
/* ]]> */
</script>
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">
			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.affiliate_head_msg}
					</td>
				</tr>
			</table>
      <form name="frmAffSignup" method="post" action="" onsubmit="javascript:return validate(this);">
      <input type="hidden" name="frm" value="frmAffSignup" />
			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
				{if $error ne ""}
				<tr>
					<td colspan="2" align="center">
						<font class="errors">{$error}</font><br/>
					</td>
				</tr>
				{/if}
				 <tr>
				  <td colspan="2">{$lang.already_affiliate}&nbsp;
						<a href="afflogin.php">{$lang.login_now}</a><br/><br/>
					</td>
				</tr>
				<tr>
					<td>{$lang.name}</td>
					<td><input type="text" name="txtname" maxlength="20" size="20" value="{$txtname}" />&nbsp;&nbsp;&nbsp;({$config.min_username_len}{$lang.to}{$config.max_username_len}&nbsp;{$lang.characters})</td>
				</tr>
				<tr>
					<td>{$lang.email}</td>
					<td><input type="text" name="txtemail" maxlength="255" size="20" value="{$txteamil}" />&nbsp;&nbsp;&nbsp;{$lang.must_be_valid}</td>
				</tr>

				<tr>
					<td>{$lang.signup_password}</td>
					<td><input type="password" name="txtpassword" maxlength="10" size="20" />&nbsp;&nbsp;&nbsp;({$config.min_pass_len}{$lang.to}{$config.max_pass_len}&nbsp;{$lang.characters})</td>
				</tr>
				<tr>
					<td>{$lang.confirm_password}</td>
					<td><input type="password" name="txtconpassword" maxlength="10" size="20" /></td>
				</tr>
				<tr>
					<td align="center">
						<input type="submit" class="formbutton" value="{$lang.submit}" />
					</td>
				</tr>
			</table>
      </form>
		</td>
	</tr>
</table>
