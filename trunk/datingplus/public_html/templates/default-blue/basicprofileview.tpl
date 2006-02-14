{strip}
<table width="623" align="center" border="0" cellpadding="0"  cellspacing="0">
	<tr>
		<td width="120"  align="center">
			<table border="0" width="100%"  align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<img src="getsnap.php?id={$user.id}&amp;typ=pic&amp;width={$config.disp_snap_width}&amp;height={$config.disp_snap_height}" alt="" />
					</td>
				</tr>
			</table>
		</td>
		<td align="center" valign="top">
			<table width="300" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail_inside" width="100%">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="266">{$lang.personal_details}</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
						<table width="100%" border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" >
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
					</td>
				</tr>
			</table>
		</td>
		<td align="center" width="193" valign="top">
			{include file="rating.tpl"}
		</td>
	</tr>
</table>
{/strip}
