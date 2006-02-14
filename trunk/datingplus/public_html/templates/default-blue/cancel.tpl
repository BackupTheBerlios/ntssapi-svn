{strip}
<table border="0" cellpadding="0" cellspacing="0" width="571">
	<tr>
		<td width="100%"  class="module_detail_inside" align="center">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
					{$lang.cancel_hdr}
					</td>
				</tr>
			</table>
			<table border="0" width="100%" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
				<tr>
					<td width="100%">
						<table cellpadding="5">
						{if $step eq '1'}
							<tr><td>{$lang.cancel_txt01}</td></tr>
							<tr><td>
								<form name="cancel1" method="post" action="cancel.php">
									<input name="action" type="submit" value="{$lang.cancel_opt01}" class="formbutton"/>&nbsp;
									<input name="action" type="submit" value="{$lang.cancel_opt02}" class="formbutton"/>
								</form>
								</td>
							</tr>
						{ elseif $step eq '2' }
							<tr><td>{$lang.cancel_domsg}</td></tr>
						{ else }
							<tr><td>{$lang.cancel_nomsg}</td></tr>
						{/if}
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
