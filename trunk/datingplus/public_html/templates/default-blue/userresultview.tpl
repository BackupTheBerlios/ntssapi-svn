{strip}

<table width="455" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" >
						{$item.username}
					</td>
					<td class="module_head" width="30%">
						{$lang.signup_gender_values[$item.gender]},
						{$item.age} {$lang.years}
					</td>
					<td width="22"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			<table width="100%" border="0">
				<tr>
					<td width="100%">


						<table border="0" width="100%">
							<tr>
								<td width="100">
							{if $smarty.session.security.seepictureprofile == 1}
									<table border="0">
									<tbody>
										<tr>
											<td width="100">
												<a href="picturepreview.php?id={$item.id}">
												<img src="getsnap.php?id={$item.id}&amp;typ=tn" width="100" border="0" alt="" />
												</a>
											</td>
										</tr>
									</tbody>
									</table>
							{/if}
								</td>
								<td valign="top">
									<table border="0">
									<tbody>
										<tr>
											<td><b>{$lang.name}</b> {$item.firstname|stripslashes}&nbsp;{$item.lastname|stripslashes}</td>
										</tr>
										<tr>
											<td>
												<br /><b>{$lang.location_col}</b>
												{if $item.city != ''}
													{$item.city|stripslashes},
												{/if}
												{if $item.statename != ''}
													{$item.statename},
												{/if}
												{if $item.countryname != ''}
													{$item.countryname]}
												{/if}
											</td>
										</tr>
									</tbody>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="2" class="statusbar" align="center" height="20">
								{if $config.enable_mod_rewrite == 'Y'}
									<a href="javascript:popUpScrollWindow('{$item.id}.htm','top',650,screen.height)">{$lang.view_profile}</a>
								{else}
									<a href="javascript:popUpScrollWindow('showprofile.php?id={$item.id}','top',650,screen.height)">{$lang.view_profile}</a>
								{/if}
								{if $smarty.session.security.message == 1}
									<a href="javascript:popUpWindow('compose.php?recipient={$item.id}','center',350,200)">{$lang.send_mail}</a>
								{/if}
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<br />
{/strip}
