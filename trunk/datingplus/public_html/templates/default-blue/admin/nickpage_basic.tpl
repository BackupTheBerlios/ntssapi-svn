{strip}
<table cellspacing="0" cellpadding="0" border="0" width="100%">
	<tr>
		<td align="left" valign="middle">


	{if $smarty.session.security.seepictureprofile == 1 && $snap_cnt > 0 && $smarty.session.UserId != '' && $smarty.session.UserId != $user.id }
		<a href="#" onclick="javascript:popUpWindow('userpicgallery.php?id={$user.id}','center',600,600);" class="footerlink"><img src="getsnap.php?id={$user.id}&amp;typ=pic&amp;width={$config.disp_snap_width}&amp;height={$config.disp_snap_height}" class="smallpic" style="margin:10px 20px 10px 0px;" alt="" /></a>
	{else}
		<img src="getsnap.php?id={$user.id}&amp;typ=pic&amp;width={$config.disp_snap_width}&amp;height={$config.disp_snap_height}" class="smallpic" style="margin:10px 20px 10px 0px;" alt="" />
	{/if}

		</td>
		<td width="100%" align="center" valign="middle">

			<div class="module_detail_inside" align="center">

						<table cellspacing="0" cellpadding="4" border="0" width="100%">
							<tr>
								<td class="module_head">{$lang.personal_details}</td>
							</tr>
						</table>

						<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" width="100%">
							<tr class="addrow">
								<td>
									<b>{$lang.age}:</b>
								</td>
								<td>
									{$user.age}
								</td>
							</tr>
							<tr class="evenrow">
								<td>
									<b>{$lang.sex}</b>
								</td>
								<td>
									{$lang.signup_gender_values[$user.gender]}
								</td>
							</tr>
							<tr class="addrow">
								<td>
									<b>{$lang.looking_for}</b>
								</td>
								<td>{$lang.signup_gender_look[$user.lookgender]}</td>
							</tr>
							<tr class="evenrow">
								<td>
									<b>{$lang.location_col}</b>
								</td>
								<td>{if $user.city != ''}
										{$user.city},&nbsp;
									{/if}
									{if $user.statename != ''}
										{$user.statename},&nbsp;
									{/if}
									{if $user.countryname != ''}
										{$user.countryname}
									{/if}
								</td>
							</tr>
						</table>

			</div>

		</td>
	</tr>
</table>
{/strip}
