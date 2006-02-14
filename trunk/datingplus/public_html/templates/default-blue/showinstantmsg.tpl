{strip}
{include file="popheader.tpl"}
<table width="100%" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="100%">

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head">
					{$lang.instant_message}
					{if $errid == '' }
						{$lang.from}
						{$data.username}
					{/if}
					</td>
				</tr>
			</table>

			<table width="100%" cellspacing="10" cellpadding="0" border="0">
			{if $errid != ''}
				<tr>
					<td width="100%" align="center" ><span class="errors">{$lang.errormsgs[$errid]}</span></td>
				</tr>
				<tr>
					<td  align="center"><input name="btnClose" type="button" id="btnClose" onclick="window.close();" value="{$lang.close_window}"/></td>
				</tr>
			{else}
				<tr>
					<td height="90" width="100%" valign="top" align="left" class="im_text">
						<table width="100%" border="0" cellspacing="0" cellpadding="5">
							<tr>
								<td>
									{$data.message|nl2br}
								</td>
							</tr>
						</table>
					</td>
				</tr>

				<form name="frmReply" action="saveinstantmsg.php" method="post">
				<input type="hidden" name="recipientid" value="{$data.id}"/>
				<input type="hidden" name="page" value="showmessage"/>
				<tr>
					<td align="center">
						<textarea rows="7" cols="60" name="msg" style="width:300px;height:80px;"></textarea>
					</td>
				</tr>
				<tr>
					<td align="center">
						<input name="btnSend" type="submit" class="formbutton" id="btnSend" value="{$lang.im_reply}"/>
						&nbsp;<input name="btnClose" type="button" class="formbutton" id="btnClose" value="{$lang.close}" onclick="window.close()"/>
					</td>
				</tr>
				</form>

			{/if}
			</table>

		</td>
	</tr>
</table>
{include file="popfooter.tpl"}
{/strip}
