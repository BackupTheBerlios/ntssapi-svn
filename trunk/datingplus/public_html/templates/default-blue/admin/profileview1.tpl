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

	<table width="623" border="0" CELLPADDING=0 CELLSPACING=0>
		<tr>
			<td class="module_detail" width="623">
		
				<TABLE WIDTH=623 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
					<tr>
						<td  width="623">
						
							<TABLE WIDTH="623" BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
								<tr>
									<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25"></td>
									<td class="module_head" width="226">
										{$user.username}{$lang.profile_s}
									</td>
									<td width="320" class="module_head" align=right>
									{$lang.lastlogged} {$user.lastvisit|date_format:$lang.DATE_TIME_FORMAT} 
									</td>
								</tr>
							</TABLE>
							
							{include file="basicprofileview.tpl"}

							<table width="100%" border="0" CELLPADDING=0 CELLSPACING=0>
								<tr>
									<td>
										<table width="100%" CELLPADDING=0 CELLSPACING=0 border=0>
											<tr>
												<td >
											{if $found == 1}
											
												<TABLE WIDTH="623" BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
													<tr>
														<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25"></td>
														<td class="module_head" width="546">
															{$lang.profile_details}
														</td>
													</tr>
												</TABLE>
												
												<table align="center" border="0" width=623 cellspacing=10 cellpadding=0>
													{assign var="ccount" value="0"}
													{foreach item=item from=$pref}
														{if $ccount == 0}
															<tr>
																<td valign="top">
																	{include file="sectionview.tpl"}</td>
														{elseif $ccount == 1}
																<td valign="top">
																	{include file="sectionview.tpl"}</td>
															</tr>
														{/if}
														{math equation="$ccount+1" assign="ccount"}
														{math equation="$ccount%2" assign="ccount"}
													{/foreach}
												</table>
											{else}
												{if $smarty.session.UserId != '' && $smarty.session.UserId == $smarty.get.id}
													<table width="80%"  align="center" border="0" cellspacing="5">
														<tr>
															<td colspan="2" align="center" class="subtitle">
																{$lang.profile_details}
															</td>
														</tr>
														<tr>
															<td colspan="2" align="center">
																{$lang.view_profile_errmsg1}
																<a href="edituser.php">{$lang.view_profile_errmsg2}</a>
															</td>
														</tr>
													</table>											
												{else}
													<TABLE WIDTH="623" BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
														<tr>
															<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25"></td>
															<td class="module_head" width="546">
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
		<CENTER>
		</CENTER>		
	<BR />				
		</table>
	</td>
</tr>
{/if}
</table>
<BR />
{include file="popfooter.tpl"}
{/strip}