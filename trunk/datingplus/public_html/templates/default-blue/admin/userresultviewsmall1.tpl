{strip}

<TABLE WIDTH=275 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td class="module_detail_inside" width="100%">
		
			<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" >
					 {$item.firstname|stripslashes}&nbsp;{$item.lastname|stripslashes}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23"></td>
				</tr>
			</TABLE>
			
			<TABLE BORDER=0 width=100% height="150">
				<tr>
					<td valign=top>
						<table border=0 width=100%>
							<tbody>
								<tr class="oddrow">
									<td><b>{$lang.username_without_colon}:</b></td>
									<td>{$item.username}</td>
								</tr>
								<tr class="evenrow">
									<td><b>{$lang.age}:</b></td>
									<td>{$item.age}</td>
								</tr>
								<tr class="oddrow">
									<td><b>{$lang.sex}</b></td>
									<td>{$lang.signup_gender_values[$item.gender]}</td>
								</tr>
								<tr class="evenrow">
									<td valign=top><b>{$lang.location_col}</b></td>
									<td>{if $item.city != ''}
										{$item.city},<br />
									{/if}
									{if $item.statename != ''}
										{$item.statename},<br />
									{/if}
									{if $item.countryname != ''}
										{$item.countryname}
									{/if}</td>
								</tr>
							</tbody>
						</table>
					</td>
					<td>
						<table border=0>
							<tbody>
							<tr>
								<td width=100>								{if $config.enable_mod_rewrite == 'Y'}
									<a href="javascript:popUpScrollWindow('{$item.id}.htm','top',650,600)">
								{else}					
									<a href="javascript:popUpScrollWindow('showprofile.php?id={$item.id}','top',650,600)">
								{/if}
									<img src="getsnap.php?id={$item.id}&typ=tn" class="smallpic">
									</a>
								</td>
							</tr>
							</tbody>
						</table>
					</td>
					
				</tr>
				<tr>
					<td colspan=2 align="center" height=20 class="statusbar">
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
</table>	
<br />
{/strip}
