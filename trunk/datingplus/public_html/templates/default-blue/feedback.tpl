{strip}
<script type="text/javascript">
/* <![CDATA[ */
function validate(form)
{ldelim}
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0] = "" + String.fromCharCode(13);

	CheckFieldString("noblank",form.txtname,"{$lang.signup_js_errors.name_noblank}");
	CheckFieldString("noblank",form.txtemail,"{$lang.signup_js_errors.email_noblank}");
	CheckFieldString("noblank",form.txtcomments,"{$lang.signup_js_errors.comments_noblank}");

	CheckFieldString("text",form.txtname,"{$lang.signup_js_errors.name_charset}");
	CheckFieldString("email",form.txtemail,"{$lang.signup_js_errors.email_notvalid}");

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

<table border="0" cellpadding="0" cellspacing="0" width="573">
	<tr>
		<td width="100%"  class="module_detail_inside" align="center">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="496">
					{$lang.feedback}
					</td>
				</tr>
			</table>
			<table border="0" width="100%" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}">
				<tr>
					<td width="100%">
						{if $msg != '' }
							<p>
							{$lang.errormsgs[$msg]}
							</p>
						{else}
							{if $success}
								<p>
								<table>
									<tr>
										<td>
										{$lang.feedback_thanks}
										</td>
									</tr>
								</table>
								</p>
							{else}
								<br />
								<form name="frmContact" action="" method="post" onsubmit="javascript: return validate(this);">
								<input type="hidden" name="cmd" value="posted"/>
								<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
									<tr>
										<td width="25%">{$lang.subject_colon}</td>
										<td width="75%"><input type="text" name="txttitle" value="{$txttitle|stripslashes}" size="30" maxlength="30"/></td>
									</tr>
									<tr>
										<td width="25%"> {$lang.name}
											<font color='{$lang.required_info_indicator_color}'>
											{$lang.required_info_indicator}</font>
										</td>
										<td width="75%"><input type="text" name="txtname" value="{$txttname|stripslashes}" size="20" maxlength="20"/></td>
									</tr>
									<tr>
										<td width="25%">{$lang.email}
											<font color='{$lang.required_info_indicator_color}'>{$lang.required_info_indicator}</font>
										</td>
										<td width="75%"><input type="text" name="txtemail" value="{$txtemail}" size="30" maxlength="150"/>
										</td>
									</tr>
									<tr>
										<td width="25%">{$lang.country_colon}
											<font color='{$lang.required_info_indicator_color}'>{$lang.required_info_indicator}</font>
										</td>
										<td width="75%">
											<select name="txtcountry" id="txtcountry">
											{html_options options=$lang.countries selected=$config.default_country}
											</select></td>
									</tr>
									<tr>
										<td width="25%" valign="top">{$lang.comments_colon}
										<font color='{$lang.required_info_indicator_color}'>{$lang.required_info_indicator}</font>
										</td>
										<td width="75%"><textarea rows="10" cols="55" name="txtcomments">{$txtcomments|stripslashes}</textarea></td>
									</tr>
									<tr>
										<td align="center" colspan="2"><input name="submit" class="formbutton" type="submit" value="Submit"/>&nbsp;
										<input name="reset" type="reset" value="Reset" class="formbutton"/> </td>
									</tr>
								</table>
								</form>
							{/if}
						{/if}
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
