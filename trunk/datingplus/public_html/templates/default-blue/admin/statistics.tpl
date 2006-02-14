{strip}
<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25"></td>
		<td class="module_head" width="702">{$lang.welcome} &nbsp;{$smarty.session.AdminName}</td>
	</tr>
</TABLE>
<BR />
<BR />
<CENTER>
{if $change_pwd == 1 }
<font size=3><b>{$lang.please_be_sure}&nbsp;<a href="changepwd.php">{$lang.change_your_admin_pwd}</a></b></font><br />
<BR /><BR />
{/if}
<TABLE WIDTH=350 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td class="module_detail_inside" width="100%">
			<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.site_statistics}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23"></td>
				</tr>
			</TABLE>

			<table align="center" width="200" cellspacing="5" cellpadding="1" border="0">
				<tr class="oddrow"><td><a href="unapprovedusers.php">{$lang.pending_profiles}</a></td><td>{$pending_users}</td></tr>
				<tr class="evenrow"><td><a href="profile.php">{$lang.active_profiles}</a></td><td>{$active_users}</td></tr>	
				<tr class="oddrow"><td><a href="onlineusers.php">{$lang.online_profiles}</a></td><td>{$online_users_count}</td></tr>		
				<tr class="evenrow"><td><a href="affiliatesview.php">{$lang.pending_aff}</a></td><td>{$pending_aff}</td></tr>
				<tr class="oddrow"><td><a href="affiliatesview.php">{$lang.active_aff}</a></td><td>{$active_aff}</td></tr>	
			</table>
		</td>
	</tr>
</TABLE>
</CENTER>
{/strip}