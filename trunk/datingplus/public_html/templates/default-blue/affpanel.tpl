{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
					{$lang.aff_panel}								
					</td>
				</tr>
			</table>
			<br />
			<table width="555" border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" align="center">
				<tr>
					<td class="module_detail_inside" width="100%">

						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="521">
									{$lang.welcome}&nbsp;{$smarty.session.AffName}
								</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
						<table width="100%" border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
							<tr><td colspan="2">
						<a href="affchangepass.php">{$lang.change_password}</a>&nbsp;&nbsp;<a href="afflogout.php">{$lang.sign_out}</a>
								<br />
								<br />
							</td></tr>
							<tr>
								<td>{$lang.total_amt}:</td>
								<td><b>${$profcounter*$config.aff_referral_price}</b></td>
							</tr>
							<tr><td colspan="2"></td></tr>
							<tr>
								<td>{$lang.banner_link}:</td>
								<td>http://{$smarty.server.SERVER_NAME}{$docroot}index.php?affid={$smarty.session.AffId}</td>
							</tr>
							<tr><td colspan="2"></td></tr>
							<tr>
								<td>{$lang.referals}:</td>
								<td>{$refcounter}</td>
							</tr>
							<tr><td colspan="2"></td></tr>
							<tr>
								<td>
								{if $profcounter > 0 }
									{$lang.profiles}:
								{else}
									{$lang.profiles}:
								{/if}
								</td>
								<td>{$profcounter}</td>
							</tr>
						</table>
						<br />
					</td>
				</tr>
			</table>
			<br />
		</td>
	</tr>
</table>
{/strip}
