{strip}
<table width="178" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="178" valign="top">
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="150">
					{$lang.instant_messenger}
					</td>
					<td width="22"><img src="{$image_dir}blue_small_hor.jpg" width="22" height="23" alt="" /></td>
				</tr>
			</table>
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="100%">

						<table  class="table" width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
							<tr>
								<td>
									<object {if $smarty.session.browser neq "MOZILLA"}classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"{/if} width="172" height="220" data="messenger.swf">
										<param name="movie" value="messenger.swf">
										<param name="quality" value="high">
										<param name="bgcolor" value="#F8FBFF">
										</object>
									<object {if $smarty.session.browser neq "MOZILLA"}classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"{/if} width="1" height="1" data="PingIM.swf">
										<param name="movie" value="PingIM.swf">
										<param name="quality" value="high">
									</object>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
