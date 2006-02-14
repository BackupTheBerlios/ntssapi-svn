{strip}

<TABLE WIDTH=455 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td class="module_detail_inside" width="100%">

			<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" >
						{$item.username}
					</td>
					<td class="module_head" width="30%">
						{$lang.signup_gender_values[$item.gender]},&nbsp; 
						{$item.age}&nbsp;{$lang.years}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23"></td>
				</tr>
			</TABLE>
			<TABLE WIDTH=100% BORDER=0>
				<tr>
					<td width="100%">
						<table border=0 width=100% height="150">
							<tr>
								<td width=100>
									<table border=0>
									<tbody>
										<tr>
											<td width=100>
												<a href="picturepreview.php?id={$item.id}">
												<img src="getsnap.php?id={$item.id}&typ=tn" width="100" border=0>
												</a>
											</td>
										</tr>
									</tbody>
									</table>
								</td>
								<td valign=top>
									<table border=0>
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
								<td colspan=2 bgcolor="#CCCCCC" align="center" height=20>
								{if $config.enable_mod_rewrite == 'Y'}					
									<a href="javascript:popUpScrollWindow('{$docroot}{$item.id}.htm','center',650,screen.height)">{$lang.view_profile}</a>
								{else}
									<a href="javascript:popUpScrollWindow('{$docroot}showprofile.php?id={$item.id}','center',650,screen.height)">{$lang.view_profile}</a>					
								{/if}
								</td>												
							</tr>												
						</table>
					</td>
				</tr>
			</TABLE>
		</td>
	</tr>
</TABLE>
<br />
{/strip}
