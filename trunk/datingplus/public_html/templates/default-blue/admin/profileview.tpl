{strip}
{include file="popheader.tpl"}
{if $err == 28 }
	<table width="80%"  align="center" border="0" cellspacing="5">
	<tr><td colspan="2" align="center" class="subtitle">{$lang.profile_details}</td></tr>
	<tr><td colspan="2" align="center">{$lang.view_profile_restricted}</td></tr>
	</table>																					
{elseif $err == 31 }
	<table width="80%"  align="center" border="0" cellspacing="5">
	<tr><td colspan="2" align="center" class="subtitle">{$lang.profile_details}</td></tr>
	<tr><td colspan="2" align="center">{$lang.profile_notset}</td></tr>
	</table>																					
{else}
	<table width="100%" border="0" CELLPADDING={$config.cellpadding} CELLSPACING={$config.cellspacing}>
		<tr>
			<td class="module_detail_inside" width="100%" valign=top>
				<TABLE WIDTH="100%" BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
					<tr>
						<td width="13%"><img src="{$image_dir}blue_window_3_bars.jpg" width="100%" height="25"></td>
						<td class="module_head" width="40%">
							{$user.username}{$lang.profile_s}
						</td>
						<td width="47%" class="module_head" align=right>
						{$lang.lastlogged}&nbsp;{$user.lastvisit|date_format:$lang.DATE_FORMAT}&nbsp;&nbsp; 
						</td>
					</tr>
				</TABLE>
				<TABLE WIDTH=100% BORDER=0 CELLPADDING={$config.cellpadding} CELLSPACING={$config.cellspacing} >
					{if $errid ne ''}
					<tr>
						<td  width="100%">
							<font color="{$lang.error_msg_color}">
							{$lang.errormsgs.$errid}</font>
						</td>
					</tr>
					{/if}
					<tr>
						<td width="100%">
							{include file="basicprofileview.tpl"}
							<table width="100%" border="0" CELLPADDING={$config.cellpadding} CELLSPACING={$config.cellspacing}>
								<tr>
									<td>
										<table width="100%" CELLPADDING=0 CELLSPACING=0 border=0>
											<tr>
												<td >
											{if $found == 1}
											
												<TABLE WIDTH="100%" BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
													<tr>
														<td width="13%"><img src="{$image_dir}blue_window_3_bars.jpg" width="100%" height="25"></td>
														<td class="module_head" width="87%">
															{$lang.profile_details}
														</td>
													</tr>
												</TABLE>
												
												<table align="center" border="0" width="100%" cellspacing=10 cellpadding=0>
													{assign var="ccount" value="0"}
													{foreach item=item from=$pref}
														{if $ccount == 0}
															<tr>
																<td valign="top" align=center>
																	{include file="sectionview.tpl"}</td>
														{elseif $ccount == 1}
																<td valign="top" align=center>
																	{include file="sectionview.tpl"}</td>
															</tr>
														{/if}
														{math equation="$ccount+1" assign="ccount"}
														{math equation="$ccount%2" assign="ccount"}
													{/foreach}
												</table>
											{else}
												{if $smarty.session.UserId != '' && $smarty.session.UserId == $smarty.get.id}
													<TABLE WIDTH="100%" BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
														<tr>
															<td width="13%"><img src="{$image_dir}blue_window_3_bars.jpg" width="100%" height="25"></td>
															<td class="module_head" width="87%">
																{$lang.profile_details}
															</td>
														</tr>
													</TABLE>
													<table width="80%"  align="center" border="0" cellspacing="5">
														<tr>
															<td colspan="2" align="center">
																{$lang.view_profile_errmsg1}
																<a href="edituser.php" onClick="javascript:window.opener.document.location = 'edituser.php';window.close();">
																{$lang.view_profile_errmsg2}</a>
															</td>
														</tr>
													</table>											
												{else}
													<TABLE WIDTH="100%" BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
														<tr>
															<td width="13%"><img src="{$image_dir}blue_window_3_bars.jpg" width="100%" height="25"></td>
															<td class="module_head" width="87%">
																{$lang.profile_details}
															</td>
														</tr>
													</TABLE>
													<table width="80%"  align="center" border="0" cellspacing="5">
														<tr>
															<td colspan="2" align="center">
																{$lang.view_profile_errmsg3}
															</td>
														</tr>
													</table>																					
												{/if}
											{/if}
											</td>
										<td>						
									</table>
								</td>
							</tr>				
						</table>
					</td>
				</tr>
				{if $smarty.session.UserId != '' && $smarty.session.UserId != $user.id }
					<tr>
						<td align=center>&nbsp;&nbsp;
						{if $smarty.session.security.favouritelist == 1}
							<input type="button" class="formbutton" value="{$lang.addtobuddylist}" onclick="javascript:window.location='buddybanlist.php?act=buddy&ref_id={$user.id}&rtnurl=showprofile.php';">&nbsp;
							<input type="button" class="formbutton" value="{$lang.addtobanlist}" onclick="javascript:window.location='buddybanlist.php?act=ban&ref_id={$user.id}&rtnurl=showprofile.php';">&nbsp;
							<input type="button" class="formbutton" value="{$lang.addtohotlist}" onclick="javascript:window.location='buddybanlist.php?act=hot&ref_id={$user.id}&rtnurl=showprofile.php';">&nbsp;
						{/if}
						{if $smarty.session.security.sendwinks == 1}
							<input type="button" class="formbutton" value="{$lang.send_wink}" onclick="javascript:window.location='sendwinks.php?ref_id={$user.id}&rtnurl=showprofile.php';"> 
						{/if}						
						{if $smarty.session.security.message == 1 && $user.id != $smarty.session.UserId}
							&nbsp;<a onClick="javascript:popUpWindow('compose.php?recipient={$user.id}','center',350,200);"><input type=button class="formbutton" value="{$lang.send_mail}"></a>
						{/if}
						{if $smarty.session.security.seepictureprofile == 1 && $snaps_cnt > 0 }
							&nbsp;<a onClick="javascript:popUpWindow('userpicgallery.php?id={$user.id}','center',600,600);"><input type=button class="formbutton" value="{$lang.pic_gallery}"></a>
						{/if}
						</td>
					</tr>
				{/if}
		<tr>
			<td align=center>
				{if $smarty.session.UserId != '' && $smarty.session.UserId != $user.id && $has_rated == 0 }
					{include file="rate.tpl"}
					<br />
				{/if}
			</td>
		</tr>		
		</table>
	</td>
</tr>
{/if}
</table>
{include file="popfooter.tpl"}
{/strip}
