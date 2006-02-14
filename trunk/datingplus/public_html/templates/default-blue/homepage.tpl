{strip}
<table border="0" cellpadding="0"  cellspacing="0" width="100%">
	<tr>
		<td width="571" align="center">
{if $smarty.session.UserId == ''}
			<table width="571" border="0" cellpadding="0"  cellspacing="0">
				<tr>
					<td class="module_detail" width="571">

						<table width="571" border="0" cellpadding="0"  cellspacing="0" style="height:23px">
							<tr>
								<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
								<td class="module_head" width="494">
								{$lang.special_offer|stripslashes}
								</td>
							</tr>
						</table>
						<table width="571" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="100%" align="center">
									<br />
										<table width="571" border="0" cellpadding="0" cellspacing="0" >
											<tr>
												<td width="174" valign="top" height="196" rowspan="2"><img src="{$image_dir}offerimg.jpg" height="196" width="174" alt="" /></td>
												<td width="397" valign="top" height="159" align="center" >
													<table width="95%" border="0" cellpadding="0" cellspacing="0" align="center">
														<tr>
															<td width="100%">
																<span class="offer_head">{$lang.welcome_to_site|stripslashes}</span><br /><br />
																{$lang.offer_text|stripslashes}
																<br /><br />
																<img src="{$image_dir}member_icon.jpg" width="19" height="18" border="0" alt="" />
																&nbsp;<a href="onlineusers.php">{$lang.online_users} {$online_users_count}</a>
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td width="397" valign="middle"  height="37"  align="center" class="module_head">
													<span class="text_head1">{$lang.dont_stay_alone}</span>&nbsp;
													<a href="signup.php"><span class="text_head1">{$lang.join_now_for_free}</span></a>
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
{/if}
{if $smarty.session.UserId > 0 }
{* Show the statistics since last login  *}
			<table width="571" border="0" cellpadding="0" cellspacing="0" >
				{if $smarty.get.errid != ''}
				<tr>
					<td width="571">
						<span class="errors">{$lang.errormsgs[$smarty.get.errid]}</span>
					</td>
				</tr>
				<tr><td>&nbsp;</td></tr>
				{/if}
				<tr>
					<td class="module_detail" width="571">
						<table width="571" border="0" cellpadding="0" cellspacing="0" style="height:23px">
							<tr>
								<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
								<td class="module_head" width="494">
								{$lang.sincelastlogin_hdr}
								</td>
							</tr>
						</table>
					{if $smarty.session.expired == '1'}
						<table width="571" border="0" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}" style="height:23px">
							<tr>
								<td width="6">&nbsp;</td>
								<td width="494">
									<span class="subhead"><font class="errors">{$lang.expired}</font>
									</span>
								</td>
							</tr>
						</table>
					{/if}

						<table  width="571" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}" border="0">
							<tr class="oddrow">
								<td width="40%">
									<a href="mailmessages.php?messages=inbox">
									{$lang.newmessages}</a>
								</td>
								<td width="60%">
									{$new_messages}
								</td>
							</tr>
							<tr class="evenrow">
								<td width="40%">
									<a href="listviewswinks.php?id={$smarty.session.UserId}&amp;act=V">									{$lang.profileviewed}</a>
								</td>
								<td width="60%">
									{$profile_views}
								</td>
							</tr>
							<tr class="oddrow">
								<td width="40%">
									<a href="listviewswinks.php?id={$smarty.session.UserId}&amp;act=W">									{$lang.winks_received}</a>
								</td>
								<td width="60%">
									{$winks}
								</td>
							</tr>
							<tr class="evenrow">
								<td width="40%">
									<a href="onlineusers.php">{$lang.online_users}</a>
								</td>
								<td width="60%">
									{$online_users_count}
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<br />
{/if}
{ if $config.show_featured_profiles > 0 && $featured_profiles}
{* This is for showing the Featured Profiles  *}
			<table width="571" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail" width="571">
						<table width="571" border="0" cellpadding="0" cellspacing="0" style="height:23px">
							<tr>
                <td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
								<td class="module_head" width="494">
								{$lang.featured_profiles}
								</td>
							</tr>
						</table>

						<table  width="571" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}" border="0">
						{assign var="ccount" value="0"}
						{foreach item="item" key=key from=$featured_profiles}
							{if $ccount is div by 2}
								<tr>
							{/if}
								<td>{include file="userresultviewsmall.tpl"}</td>
							{if $ccount is not div by 2}
								</tr>
							{/if}
							{math equation="$ccount+1" assign="ccount"}
						{/foreach}
              {if $ccount is not div by 2}
                </tr>
              {/if}
						</table>

					</td>
				</tr>
			</table>
			<br />
{ /if }
{if $config.list_newmembers > 0 && $newUsersList }
{* Now show the latest members names *}
			<table width="571" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail" width="571">
						<table width="571" border="0" cellpadding="0" cellspacing="0" style="height:23px">
							<tr>
                <td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
								<td class="module_head" width="494">
								{$lang.newmemberlist} {*if $smarty.session.lastvisit ne ''}&nbsp;{$lang.since_last_login}{/if*}
								</td>
							</tr>
						</table>

						<table  width="571" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}" border="0">
							{assign var="xtd" value="0"}
							{foreach item=user from=$newUsersList}
              {if $xtd is div by 2}
              <tr class="{cycle values="oddrow,evenrow"}">
              {/if}
								<td>
									{if $user.allow_viewonline eq '1'}
										<a href="javascript:popUpScrollWindow2('showprofile.php?id={$user.id}','top',650,600)">
									{/if}
									{$user.username}
									{if $user.allow_viewonline eq '1'}
										</a>
									{/if}
								</td>
              {if $xtd is not div by 2}
								</tr>
  						{/if}
              {assign value=$xtd+1 var=xtd}
							{/foreach}
              {if $xtd is not div by 2}
                </tr>
              {/if}
							<tr>
								<td colspan="2">
									<a href="newmemberslist.php">{$lang.showfulllist}</a>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<br />
{/if}
{if $config.no_last_new_users > 0 && $users}
{* Now show newest profiles       *}
			<table width="571" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail" width="571">

						<table width="571" border="0" cellpadding="0" cellspacing="0" style="height:23px">
							<tr>
                <td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
								<td class="module_head" width="494">
								{$lang.newest_profiles} {*if $smarty.session.lastvisit ne ''}&nbsp;{$lang.since_last_login}{/if*}
								</td>
							</tr>
						</table>

						<table  width="571" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}" border="0">
						{assign var="ccount" value="0"}
						{foreach item=item key=key from=$users}
							{if $ccount==0}
								<tr>
							{/if}
								<td>{include file="userresultviewsmall.tpl"}</td>
							{if $ccount==1}
								</tr>
							{/if}
							{math equation="$ccount+1" assign="ccount"}
							{math equation="$ccount%2" assign="ccount"}
						{/foreach}
						</table>

					</td>
				</tr>
			</table>
{/if}
		<br /><br />
		{$banner}
		</td>
	</tr>

</table>
{/strip}
