{strip}

{if $config.use_popups == 'Y'}
{include file="popheader.tpl"}
{/if}

<script type="text/javascript" src="javascript/check.js"></script>
<script type="text/javascript">
/* <![CDATA[ */
function validate(form)
{ldelim}
	ErrorCount=0;
	ErrorMsg = new Array();

	CheckFieldString("noblank",form.txtsendername,"{$lang.taf_errormsgs.sendername_noblank}");
	CheckFieldString("noblank",form.txtsenderemail,"{$lang.taf_errormsgs.senderemail_noblank}");
	CheckFieldString("noblank",form.txtrcpntemail,"{$lang.taf_errormsgs.recipientemail_noblank}");

	CheckFieldString("text",form.txtsendername,"{$lang.taf_errormsgs.sendername_charset}");
	CheckFieldString("email",form.txtsenderemail,"{$lang.taf_errormsgs.senderemail_charset}");
	CheckFieldString("email",form.txtrcpntemail,"{$lang.taf_errormsgs.recipientemail_charset}");

	if( ErrorCount > 0)
	{ldelim}
		alert(ErrorMsg[1]);
		return false;
	{rdelim}
	return true;
{rdelim}
/* ]]> */
</script>

<table width="300" border="0" cellpadding="1" cellspacing="2">
	<tr>
		<td class="module_detail_inside" width="100%">

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6">&nbsp;</td>
					<td class="module_head" width="526">
					{$lang.taf_msg1}
					</td>
					<td width="22"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

      <form name="frmCompose" action="sendinvite.php" method="post" onsubmit="javascript: return validate(this);">

			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">

		{if $msg eq ''}
				<tr><td colspan="2">&nbsp;</td></tr>
				<tr><td>{$lang.taf_yourname}</td>
				<td><input type="text" name="txtsendername" size="33"/></td></tr>
				<tr><td colspan="2">&nbsp;</td></tr>
				<tr><td>{$lang.taf_youremail}</td>
					<td><input type="text" name="txtsenderemail" size="33"/></td>
				</tr>
				<tr><td colspan="2">&nbsp;</td></tr>
				<tr><td>{$lang.taf_friendemail}</td>
					<td><input type="text" name="txtrcpntemail" size="33"/></td>
				</tr>
				<tr><td colspan="2">&nbsp;</td></tr>
				<tr><td align="center" colspan="2">
					<input type="submit" class="formbutton" name="btnsend" value="{$lang.send_invite}"/>
					</td>
				</tr>
		{else}
				<tr><td colspan="2">{$msg}</td></tr>
				<tr><td colspan="2">&nbsp;</td></tr>
				<tr><td align="center" colspan="2">
					<input type="submit" class="formbutton" name="btnsend" value="{$lang.close_window}" onclick="javascript: window.close();"/>
					</td>
				</tr>
				<tr><td colspan="2">&nbsp;</td></tr>
		{/if}
			</table>
      </form>
		</td>
	</tr>
</table>

{if $config.use_popups == 'Y'}
{include file="popfooter.tpl"}
{/if}
{/strip}
