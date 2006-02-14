{strip}
<script type="text/javascript">
/* <![CDATA[ */
function validate(form)
{ldelim}
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13);

	CheckFieldString("noblank",form.txtoldpwd,"{$lang.signup_js_errors.old_password_noblank}");
	CheckFieldString("noblank",form.txtnewpwd,"{$lang.signup_js_errors.new_password_noblank}");
	CheckFieldString("noblank",form.txtconpwd,"{$lang.signup_js_errors.con_password_noblank}");


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

<center>
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
					{$lang.change_password}
					</td>
				</tr>
			</table>
      <form action="affmodifypass.php" name="frmChangePass" method="post" onsubmit="javascript: return validate( this );">
			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">

				{if $pwd_change_error}
				<tr>
					<td><font color={$lang.error_msg_color}>{$pwd_change_error}</font><br/><br />
					</td>
				</tr>
				{/if}
				<tr>
					<td>
						<table class="table" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
							<tbody>
								<tr>
								  <td>{$lang.old_password}</td>
								  <td><input type="password" name="txtoldpwd" maxlength="20" size="15" /></td>
								</tr>
								<tr>
								  <td>{$lang.new_password}</td>
								  <td><input type="password" name="txtnewpwd" maxlength="20" size="15" /></td>
								</tr>
								<tr>
								  <td>{$lang.confirm_password}</td>
								  <td><input type="password" name="txtconpwd" maxlength="20" size="15" /></td>
								</tr>
								<tr>
									<td>&nbsp;</td>
								   <td><input type="submit" class="formbutton" value="{$lang.change}" /></td>
								</tr>
							</tbody>
						</table>
					</td>
				</tr>
			</table>
      </form>
			</td>
		</tr>
</table>
</center>
{/strip}
