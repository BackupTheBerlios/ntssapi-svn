{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="702">{$lang.welcome} &nbsp;{$smarty.session.AdminName}</td>
	</tr>
</table>
<br />
<br />
<center>
{if $change_pwd == 1 }
<font size="3"><b>{$lang.please_be_sure}&nbsp;<a href="changepwd.php">{$lang.change_your_admin_pwd}</a></b></font><br />
<br /><br />
{/if}
<table width="350" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.site_statistics}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			<table align="center" width="350" cellspacing="5" cellpadding="1" border="0">
				<tr><td><strong>Main stats:</strong></td></tr>
				<tr class="oddrow"><td>{if $pending_users eq '0'}{$lang.pending_profiles}{else}<a href="unapprovedusers.php">{$lang.pending_profiles}</a>{/if}</td><td>{$pending_users}</td></tr>
				<tr class="evenrow"><td>{if $active_users eq '0'}{$lang.active_profiles}{else}<a href="profile.php">{$lang.active_profiles}</a>{/if}</td><td>{$active_users}</td></tr>
				<tr class="oddrow"><td>{if $online_users_count eq '0'}{$lang.online_profiles}{else}<a href="onlineusers.php">{$lang.online_profiles}</a>{/if}</td><td>{$online_users_count}</td></tr>
				<tr class="evenrow"><td>{if $pending_aff eq '0'}{$lang.pending_aff}{else}<a href="affiliatesview.php">{$lang.pending_aff}</a>{/if}</td><td>{$pending_aff}</td></tr>
				<tr class="oddrow"><td>{if $active_aff eq '0'}{$lang.active_aff}{else}<a href="affiliatesview.php">{$lang.active_aff}</a>{/if}</td><td>{$active_aff}</td></tr>
				<tr><td>&nbsp;</td></tr>
				<tr><td><strong>Signon stats:</strong></td></tr>
				<tr class="evenrow"><td>Users in the past minute:</td><td>{$visit_min}</td></tr>
				<tr class="oddrow"><td>Users in the past hour:</td><td>{$visit_hour}</td></tr>
				<tr class="evenrow"><td>Users in the past day:</td><td>{$visit_day}</td></tr>
				<tr class="oddrow"><td>Users in the past week:</td><td>{$visit_week}</td></tr>
				<tr class="evenrow"><td>Users in the past month:</td><td>{$visit_month}</td></tr>
				<tr class="oddrow"><td>Users in the past year:</td><td>{$visit_year}</td></tr>
				<tr class="evenrow"><td>Users in the past 2 years:</td><td>{$visit_twoyear}</td></tr>
				<tr class="oddrow"><td>Users in the past 5 years</td><td>{$visit_fiveyear}</td></tr>
				<tr class="evenrow"><td>Users in the past 10 years:</td><td>{$visit_tenyear}</td></tr>
				<tr><td>&nbsp;</td></tr>
				<tr><td><strong>User stats:</strong></td></tr>
				<tr class="evenrow"><td>Total users:</td><td>{$nusers}</td></tr>
				<tr class="oddrow"><td>Total active users:</td><td>{$active_user}</td></tr>
				<tr class="evenrow"><td>Total pending users:</td><td>{$pending_user}</td></tr>
				<tr class="oddrow"><td>Total suspended users:</td><td>{$suspend_user}</td></tr>
				<tr class="evenrow"><td>Total users that have pictures:</td><td>{$picture_user}</td></tr>
				<tr class="oddrow"><td>Users online:</td><td>{$online_user}</td></tr>
				<tr class="evenrow"><td>Free members:</td><td>{$user_level_free}</td></tr>
				<tr class="oddrow"><td>Silver members:</td><td>{$user_level_silver}</td></tr>
				<tr class="evenrow"><td>Gold members:</td><td>{$user_level_gold}</td></tr>
				<tr class="oddrow"><td>Visitor members:</td><td>{$user_level_visitor}</td></tr>
				<tr class="evenrow"><td>Men:</td><td>{$total_males}</td></tr>
				<tr class="oddrow"><td>Women:</td><td>{$total_females}</td></tr>
				<tr class="oddrow"><td>Couples:</td><td>{$total_couples}</td></tr>
				<tr><td>&nbsp;</td></tr>
				<tr><td><strong>Visitor stats:</strong></td></tr>
				<tr class="evenrow"><td>Visitors to site:</td><td>{$total_visits}</td></tr>
				<tr class="oddrow"><td>Most active page:</td><td>{$most_active_page}.php</td></tr>
				<tr><td>&nbsp;</td></tr>
				<tr><td><strong>Site stats:</strong></td></tr>
				<tr class="oddrow"><td>Times feedback form has been used:</td><td>{$feedback_total}</td></tr>
				<tr class="evenrow"><td>Times an IM has been sent:</td><td>{$im_count}</td></tr>
				<tr class="oddrow"><td>Times a wink was sent:</td><td>{$wink_count}</td></tr>
				<tr class="evenrow"><td>Times a message was sent to a mailbox:</td><td>{$mail_count}</td></tr>
				<tr class="oddrow"><td>Times invite a friend was used:</td><td>{$tellafriend_use}</td></tr>
				<tr class="evenrow"><td>Times show profile was used:</td><td>{$showprofile_use}</tr>
				<tr class="oddrow"><td>Times online users was clicked</td><td>{$onlineusers_use}</tr>
				<tr class="evenrow"><td>Times new member list was clicked:</td><td>{$newmemberlist_use}</td></tr>
				<tr class="oddrow"><td>Times banner was clicked:</td><td>{$banner_use}</tr>
				<tr class="evenrow"><td>Times poll was used:</td><td>{$poll_use}</td></tr>
				<tr class="oddrow"><td>Times picture gallery was used:</td><td>{$gallery_use}</td></tr>
				<tr class="evenrow"><td>Times affiliates was clicked:</td><td>{$aff_use}</td></tr>
				<tr class="oddrow"><td>Times signup was clicked:</td><td>{$signup_use}</td></tr>
				<tr class="evenrow"><td>Times news was clicked:</td><td>{$allnews_use}</td></tr>
				<tr class="oddrow"><td>Times stories was clicked:</td><td>{$stories_use}</td></tr>
				<tr class="evenrow"><td>Times searchmatch was clicked:</td><td>{$searchmatch_use}</td></tr>
				<tr class="oddrow"><td>Number of affiliates:</td><td>{$aff_count}</td></tr>
				<tr class="evenrow"><td>Number of affiliate referrals:</td><td>{$affref_count}</td></tr>
				<tr class="oddrow"><td>Number of pages referrals:</td><td>{$pages_count}</td></tr>
				<tr class="evenrow"><td>Number of news items:</td><td>{$news_count}</td></tr>
				<tr class="oddrow"><td>Number of stories:</td><td>{$story_count}</td></tr>
				<tr class="evenrow"><td>Number of polls:</td><td>{$polls_count}</td></tr>
				<tr class="oddrow"><td>Number of languages available:</td><td>{$langauge_count}</td></tr>
				<tr><td>&nbsp;</td></tr>
				{*
				<tr><td><strong>Forum stats:</strong></td></tr>
				<tr class="oddrow"><td>Topics in forum:</td><td>{$forum_topics}</td></tr>
				<tr class="evenrow"><td>Posts in forum:</td><td>{$forum_posts}</td></tr>
				<tr class="oddrow"><td>Bans in forum:</td><td>{$forum_bans}</td></tr>
				<tr class="evenrow"><td>Groups in forum:</td><td>{$forum_groups}</td></tr>
				<tr class="oddrow"><td>PM's in forum</td><td>{$forum_pms}</td></tr>
				*}
			</table>
		</td>
	</tr>
</table>
</center>
{/strip}