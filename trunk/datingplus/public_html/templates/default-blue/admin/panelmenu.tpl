{strip}
<table width="178" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="178" valign="top">
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="150">
					{$lang.admin_panel}
					</td>
					<td width="22" class="module_head"><img src="{$image_dir}blue_small_hor.jpg?{$smarty.now}" alt="" /></td>
				</tr>
			</table>
			<table cellspacing="5" cellpadding="0" width="100%" border="0">
			{if $smarty.session.Permissions.admin_mgt == 1}
				<tr>
			  		<td><a href="manageadmin.php" class="panellink">{$lang.manage_admins}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.admin_permit_mgt == 1}
				<tr>
			  		<td><a href="adminpermissions.php" class="panellink">{$lang.admin_permissions}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.affiliate_mgt == 1}
				<tr>
				  	<td><a href="affiliatesview.php" class="panellink">{$lang.affiliate_title}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.affiliate_stats == 1}
				<tr>
				  	<td><a href="affiliatestats.php" class="panellink">{$lang.aff_stats}</a></td>
				</tr>
			{/if}
			{if $config.snaps_require_approval == 'Y' && $smarty.session.Permissions.snaps_require_approval == 1}
				<tr>
			  		<td><a href="approve_snaps.php" class="panellink">{$lang.snaps_require_approval}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.article_mgt == 1}
				<tr>
					<td><a href="managearticle.php" class="panellink">{$lang.manage_article}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.banner_mgt == 1}
				<tr>
			  		<td><a href="managebanner.php" class="panellink">{$lang.manage_banners}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.calendar_mgt == 1}
				<tr>
			  		<td><a href="calendar.php" class="panellink">{$lang.calendar_admin}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.change_pwd == 1}
				<tr>
			  		<td><a href="changepwd.php" class="panellink">{$lang.change_password}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.chat_mgt == 1}
				<tr>
					<td class="panelbox"><a href="#" class="panellink" onclick="javascrpt:document.frmChat.submit(); return(false);">{$lang.chat}</a>
            <form name='frmChat' id='frmChat' action="../chat/flashchat_osdate.php" method='get'>
            <input type="hidden" name='username' value="{$smarty.session.UserName}" />
            <input type="hidden" name='whatIneed' value="{$smarty.session.whatIneed}" />
            </form>
          </td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.ext_search == 1}
				<tr>
			  		<td><a href="extsearch.php" class="panellink">{$lang.extended_search}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.featured_profiles_mgt == 1}
				<tr>
			  		<td><a href="featured_profiles.php" class="panellink">{$lang.featuredprofiles}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.forum_mgt == 1}
				<tr>
          <td class="panelbox"><a href="#" class="panellink" onclick="javascrpt:document.frmForum.submit(); return(false);">{$lang.manageforum}</a>
            <form name='frmForum' id='frmForum' action="../forum/login_osdate.php" method='post'>
            <input type="hidden" name='login' value="login" />
            <input type="hidden" name='admin' value="1" />
            <input type="hidden" name='username' value="{$smarty.session.UserName}" />
            <input type="hidden" name='whatIneed' value="{$smarty.session.whatIneed}" />
            </form>
          </td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.import_mgt == 1 }
				<tr>
				  	<td><a href="import.php" class="panellink">{$lang.import}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.cntry_mgt == 1 }
				<tr>
				  	<td><a href="managecountries.php" class="panellink">{$lang.manage_country_states}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.mship_mgt == 1}
				<tr>
			  		<td><a href="membership.php" class="panellink">{$lang.manage_membership}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.news_mgt == 1}
				<tr>
				  	<td><a href="managenews.php" class="panellink">{$lang.manage_news}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.pages_mgt == 1}
				<tr>
			  		<td><a href="managepages.php" class="panellink">{$lang.manage_pages}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.payment_mgt == 1}
				<tr>
			  		<td><a href="paymentmod.php" class="panellink">{$lang.payment_modules}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.poll_mgt == 1}
				<tr>
					<td><a href="managepoll.php" class="panellink">{$lang.manage_polls}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.profile_mgt == 1}
			<tr>
			  <td><a href="profile.php" class="panellink">{$lang.profile_title}</a></td>
			</tr>
			{/if}
			{if $smarty.session.Permissions.profie_approval == 1}
				<tr>
					<td><a class="panellink" href="unapprovedusers.php">{$lang.unapproved_user}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.profie_approval == 1}
				<tr>
					<td><a class="panellink" href="reactivate.php">{$lang.reactivate}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.search == 1}
				<tr>
				  	<td><a href="search.php" class="panellink">{$lang.search}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.section_mgt == 1}
				<tr>
				 	<td><a href="section.php" class="panellink">{$lang.section_title}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.send_letter == 1}
				<tr>
			  		<td><a href="sendletter.php" class="panellink">{$lang.send_letter}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.seo_mgt == 1}
				<tr>
			  		<td><a href="seo.php" class="panellink">{$lang.seo}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.site_stats == 1}
				<tr>
				  	<td><a class="panellink" href="panel.php">{$lang.site_statistics}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.global_mgt == 1}
				<tr>
			  		<td><a href="editgblsettings.php" class="panellink">{$lang.gbl_settings}</a></td>
				</tr>
			{/if}
			{if $smarty.session.Permissions.story_mgt == 1}
				<tr>
					<td><a href="managestory.php" class="panellink">{$lang.manage_story}</a></td>
				</tr>
			{/if}
				<tr>
					<td valign="bottom"><a href="logout.php" class="panellink">{$lang.sign_out}</a></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}