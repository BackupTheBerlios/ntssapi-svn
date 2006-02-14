{strip}
<table width="178" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="178" valign="top">
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="150">
					{$lang.member_panel}
					</td>
					<td width="22"><img src="{$image_dir}blue_small_hor.jpg" width="22" height="25" alt="" /></td>
				</tr>
			</table>
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
          <td width="100%">
						<table width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
						<tbody>
						{if $smarty.session.security.favouritelist == 1 and $smarty.session.expired != '1' and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
							<tr>
								<td class="panelbox"><a class="panellink" href="buddybanlist.php?act=B&amp;show=1">{$lang.banlisthdr}</a></td>
							</tr>
							<tr>
								<td class="panelbox"><a class="panellink" href="buddybanlist.php?act=F&amp;show=1">{$lang.buddylisthdr}</a></td>
							</tr>
						{/if}
						{if $smarty.session.security.event_mgt == 1 and $smarty.session.expired != '1' and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
						<tr>
							<td class="panelbox">
								{if $config.use_popups == 'Y'}
									<a class="panellink" href="javascript:popUpWindow('calendar.php','center',950,600)">{$lang.calendar_title}</a>
								{else}
									<a class="panellink" target="_blank" href="calendar.php">{$lang.calendar_title}</a>
								{/if}							
							</td>
						</tr>
						{/if}
						{if  $smarty.session.expired != '1' and $smarty.session.active == '1' }
							<tr>
								<td class="panelbox"><a class="panellink" href="changempass.php">{$lang.change_password}</a></td>
							</tr>
						{/if}
						{if $smarty.session.security.chat == 1  and $smarty.session.expired != '1' and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
							<tr>
								<td class="panelbox">
                <form name='frmChat' id='frmChat' action="chat/flashchat_osdate.php" method='get' target="new">
                <input type="hidden" name='username' value="{$smarty.session.UserName}" />
                <input type="hidden" name='whatIneed' value="{$smarty.session.whatIneed}" />
                </form>
                <a class="panellink" href="#" onclick="javascrpt:document.frmChat.submit(); return(false);">{$lang.chat}</a>
								</td>
							</tr>
						{/if}
						{if $smarty.session.expired != 1 and $smarty.session.active == '1' }
							<tr>
								<td class="panelbox"><a class="panellink" href="edituser.php">{$lang.edit_profile}</a>
								</td>
							</tr>
						{/if}  
						{if $smarty.session.expired != '1' and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
							<tr>
								<td class="panelbox"><a class="panellink" href="watchevents.php">{$lang.watched_events}</a></td>
							</tr>					
						{/if}
						{if $smarty.session.security.extsearch == 1  and $smarty.session.expired != '1' and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
							<tr>
								<td class="panelbox"><a class="panellink" href="extsearch.php">{$lang.extended_search}</a></td>
							</tr>
						{/if}
						{if $smarty.session.security.forum == 1  and $smarty.session.expired != '1' and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
							<tr>
								<td class="panelbox">
									<form name='frmForum' id='frmForum' action="forum/login_osdate.php" method='post' target="new">
									<input type="hidden" name='login' value="Log in" />
									<input type="hidden" name='username' value="{$smarty.session.UserName}" />
									<input type="hidden" name='whatIneed' value="{$smarty.session.whatIneed}" />
									</form>
									<a href="#" class="panellink" onclick="javascrpt:document.frmForum.submit(); return(false);" >{$lang.forum}</a></td>
							</tr>
						{/if}
						{if $smarty.session.security.favouritelist == 1  and $smarty.session.expired != '1' and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
							<tr>
								<td class="panelbox"><a class="panellink" href="buddybanlist.php?act=H&amp;show=1">{$lang.hotlisthdr}</a></td>
							</tr>
						{/if}
						{if $smarty.session.expired != 1 and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') and $smarty.session.security.uploadpicture == 1  and $smarty.session.security.uploadpicturecnt > 0}
							<tr>
								<td class="panelbox"><a class="panellink" href="uploadsnaps.php">{$lang.upload_pictures}</a></td>
							</tr>
						{/if}
						{ if $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active' }
							<tr>
								<td class="panelbox"><a class="panellink" href="payment.php">{$lang.upgrade_membership}</a></td>
							</tr>
						{/if}
						{if $smarty.session.security.message == 1  and $smarty.session.expired != '1' and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
							<tr>
								<td class="panelbox"><a class="panellink" href="mailmessages.php?messages=inbox" >{$lang.mail_messages}&nbsp;[&nbsp;{$new_messages|default:0}&nbsp;{$lang.unread}&nbsp;]</a></td>
							</tr>
						{/if} 
						{if $smarty.session.expired != '1' and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
							<tr>
								<td class="panelbox"><a class="panellink" href="mymatches.php">{$lang.my_matches}</a></td>
							</tr>
							<tr>
								<td class="panelbox">									<a class="panellink" href="javascript:popUpWindow('userpicgallery.php?id={$smarty.session.UserId}','center',750,700)">{$lang.pic_gallery}</a>
								</td>
							</tr>
							<tr>
								<td class="panelbox"><a class="panellink" href="search.php">{$lang.search_options}</a></td>
							</tr>
							<tr>
								<td class="panelbox"><a class="panellink" href="poll.php">{$lang.suggest_poll}</a></td>
							</tr>
							<tr>
								<td class="panelbox"><a class="panellink" href="userstats.php">{$lang.user_stats}</a></td>
							</tr>
							<tr>
								<td class="panelbox">
								{if $config.enable_mod_rewrite == 'Y'}					
									<a class="panellink" href="javascript:popUpScrollWindow2('{$smarty.session.UserId}.htm','top',650,screen.height)">{$lang.view_profile}</a>
								{else}
									<a class="panellink" href="javascript:popUpScrollWindow2('showprofile.php?id={$smarty.session.UserId}','top',650,screen.height)">{$lang.view_profile}</a>
								{/if}
								</td>
							</tr>
							<tr>
								<td class="panelbox"><a class="panellink" href="listviewswinks.php?act=V">{$lang.viewslist}</a></td>
							</tr>
							<tr>
								<td class="panelbox"><a class="panellink" href="listviewswinks.php?act=W">{$lang.winkslist}</a></td>
							</tr>
						{/if}
							<tr>
								<td class="panelbox"><a class="panellink" href="cancel.php">{$lang.cancel_hdr}</a></td>
							</tr>
							<tr >
								<td class="panelbox" height="12"><a class="panellink" href="logout.php">{$lang.sign_out}</a></td>
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
