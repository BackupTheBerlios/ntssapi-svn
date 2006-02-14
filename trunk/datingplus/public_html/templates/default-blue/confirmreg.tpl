{strip}
<form method="get" action="completereg.php">
<table border="0" cellpadding="0" cellspacing="0" width="571">
	<tr>
		<td width="100%"  class="module_detail_inside" align="center">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
					{$lang.confirm_your_profile}
					</td>
				</tr>
			</table>
			<table border="0" width="100%" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
				<tr>
					<td width="100%">
						<table cellpadding="5">
						{if $smarty.get.errid == '' }
							<tr><td>{$lang.confirm_letter_sent}</td></tr>

							<tr><td align="center">{$lang.or}</td></tr>

						{else}
							<tr><td>{$lang.wrong_activationcode}</td></tr>

						{/if}
							<tr><td>{$lang.enter_confirm_code}</td></tr>

							<tr><td>
									<input type="text" name="txtconfcode" size="40"/>
									&nbsp;
									<input type="submit" class="formbutton" value="{$lang.confirm_your_profile}"/>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</form>
{/strip}
