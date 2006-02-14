{strip}
{include file="popheader.tpl"}
<script type="text/javascript">
/* <![CDATA[ */
document.title='{$lang.send_message_to} {$user.username}';
/* ]]> */
</script>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td class="module_head" width="6"></td>
		<td class="module_head" width="526">
		{$lang.writting_message} {$user.username}
		</td>
		<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
	</tr>
</table>

<form name="frmCompose" action="" method="post">
  <input type="hidden" name="frm" value="frmCompose"/>
<table class="table" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" border="0">
	<tr>
		<td colspan="2" >&nbsp;</td>
	</tr>
	<tr>
		<td>{$lang.subject}</td>
		<td><input type="text" name="txtsubject" size="35"/>
			<input type="hidden" name="txtrecipient" value="{$smarty.get.recipient}"/>
		</td>
	</tr>
	<tr>
		<td valign="top">{$lang.message}</td>
		<td><textarea name="txtmessage" rows="5" cols="30"></textarea></td>
	</tr>
	<tr>
		<td colspan="2" align="center"><input type="submit" class="formbutton" name="btnsend" value="{$lang.send}"/></td>
	</tr>
</table>
</form>
{include file="popfooter.tpl"}
{/strip}
