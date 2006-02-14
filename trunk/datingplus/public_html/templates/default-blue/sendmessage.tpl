{strip}
<script type="text/javascript" src="javascript/check.js"></script>
<form name="frmCompose" action="" method="post">
<input type="hidden" name="frm" value="frmCompose"/>
<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="500" border="0" align="center">
<tbody>
	<tr>
		<td colspan="2" align="left">
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" align="left">
				<tr>
					<td><a href="mailmessages.php" >{$lang.inbox}</a></td>
					<td>{$lang.compose}</td>
					<td><a href="sentmessages.php" >{$lang.sent}</a></td>
					<td><a href="deletemessages.php" >{$lang.trashcan}({$deletemsg})</a></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="2" align="center">
		{if $err != ''}
			{$lang.errormsgs[$err]}
		{/if}
		</td>
	</tr>
	<tr>
		<td>{$lang.username}</td>
		<td><input type="text" name="txtusername" size="35"/></td>
	</tr>
	<tr>
		<td>{$lang.subject}</td>
		<td><input type="text" name="txtsubject" size="35"/></td>
	</tr>
	<tr>
		<td valign="top">{$lang.message}</td>
		<td><textarea name="txtmessage" rows="5" wrap="on" cols="43"></textarea></td>
	</tr>
	<tr>
		<td colspan="2" align="center"><input type="submit" class="formbutton" name="btnsend" value="{$lang.send}"/></td>
	</tr>
</tbody>
</table>
</form>
<a href="memberpanel.php">{$lang.back}</a>
{/strip}
