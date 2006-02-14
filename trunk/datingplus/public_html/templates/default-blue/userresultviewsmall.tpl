{strip}

<table width="270" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%" >
		
			<table width="100%" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" >
					{$item.username}
					</td>
					<td width="22"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			
			<table border="0" width="100%">
				<tr>
					<td valign="top">
						<table border="0" width="100%">
							<tbody>
								<tr class="addrow">
									<td valign="top" ><b>{$lang.age}:</b></td>
									<td>{$item.age}</td>
								</tr>
								<tr class="evenrow">
									<td valign="top" ><b>{$lang.sex}</b></td>
									<td>{$lang.signup_gender_values[$item.gender]}</td>
								</tr>
								<tr class="addrow">
									<td valign="top" ><b>{$lang.looking_for}</b></td>
									<td>{$lang.signup_gender_look[$item.lookgender]}</td>
								</tr>
								<tr class="evenrow">
									<td valign="top" ><b>{$lang.location_col}</b></td>
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
						<table border="0">
							<tbody>
							<tr>
								<td width="100">
								{if $config.enable_mod_rewrite == 'Y'}
									<a href="javascript:popUpScrollWindow2('{$docroot}{$item.id}.htm','center',650,600)">
								{else}					
									<a href="javascript:popUpScrollWindow2('{$docroot}showprofile.php?id={$item.id}','center',650,600)">
								{/if}
									<img src="getsnap.php?id={$item.id}&amp;typ=tn" class="smallpic" alt="" />
									</a>
								</td>
							</tr>
							</tbody>
						</table>
					</td>
					
				</tr>
				<tr>
					<td colspan="2"  align="center" height="20" class="statusbar">
						{if $config.enable_mod_rewrite == 'Y'}
							<a href="javascript:popUpScrollWindow2('{$docroot}{$item.id}.htm','center',650,600)">{$lang.view_profile}</a>
						{else}
							<a href="javascript:popUpScrollWindow2('{$docroot}showprofile.php?id={$item.id}','center',650,600)">{$lang.view_profile}</a>
						{/if}
					{if $smarty.session.security.message == 1 && $item.id != $smarty.session.UserId && $smarty.session.UserId != '' }												
						&nbsp;<a href="javascript:popUpWindow('{$docroot}compose.php?recipient={$item.id}','center',350,200)">{$lang.send_mail}</a>
					{/if}
					</td>
				</tr>
			</table>
			
		</td>
	</tr>
</table>
<br />
{/strip}
