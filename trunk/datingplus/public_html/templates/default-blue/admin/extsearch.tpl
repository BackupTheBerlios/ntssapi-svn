{strip}
<TABLE WIDTH=571 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td class="module_detail" width="571">
			<TABLE WIDTH=571 BORDER=0 CELLPADDING=0 CELLSPACING=0>
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" /></td>
					<td class="module_head" width="494">
						{$lang.extended_search}
					</td>
				</tr>
			</TABLE>
			<form name="frmExtSearch" id="frmExtSearch" method=post action="extmatch.php" >
				<input type="hidden" name="frm" id="frm" value="frmExtSearch" />				
			<table border="0" cellpadding=0 cellspacing=0 width=100%>
				<tr>
					<td width="100%">
						<TABLE WIDTH=571 BORDER=0 cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}">
							<tr>
								<td width="100%">
									<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="501">
														{$lang.sex|replace:":":' '}
														</td>
														<td class="module_head_right" width="25">
														<DIV id=div_hide_sex style="DISPLAY: inline" name="div_hide_sex"><A onclick="javascript: DispHideHide(document.getElementById('div_disp_sex'),document.getElementById('tbl_hide_sex'),document.getElementById('div_hide_sex'));" 									
														href="javascript:void(0)">{$lang.hide}</A></DIV>
														<DIV id=div_disp_sex style="DISPLAY: none" name="div_disp_sex"><A onclick="javascript: DispDispHide(document.getElementById('tbl_hide_sex'),document.getElementById('div_hide_sex'),document.getElementById('div_disp_sex'));" 
														href="javascript:void(0)">{$lang.show}</A></DIV>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
													</tr>
												</TABLE>
												<TABLE WIDTH=100% BORDER=0 cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
														<table id=tbl_hide_sex style="DISPLAY: inline" name="tbl_hide_sex" class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width=100% border=0>
														<tbody>
															<tr>
																<td>
																{foreach item=item key=key from=$lang.signup_gender_values}
																<input type="checkbox" name="txtgender[]" value="{$key}" 
																{if $key == 'M'}
																Checked
																{/if} />{$item|stripslashes}
																{/foreach}
																</td>
															</tr>
														</tbody>
														</table>
													</td>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
									<br />
									<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0>
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="501">
														{$lang.looking_for|replace:":":' '}
														</td>
														<td class="module_head_right" width="25">
														<DIV id=div_hide_lookfor style="DISPLAY: inline" name="div_hide_lookfor"><A onclick="javascript: DispHideHide(document.getElementById('div_disp_lookfor'),document.getElementById('tbl_hide_lookfor'),document.getElementById('div_hide_lookfor'));" 									
														href="javascript:void(0)">{$lang.hide}</A></DIV>
														<DIV id=div_disp_lookfor style="DISPLAY: none" name="div_disp_lookfor"><A onclick="javascript: DispDispHide(document.getElementById('tbl_hide_lookfor'),document.getElementById('div_hide_lookfor'),document.getElementById('div_disp_lookfor'));" 
														href="javascript:void(0)">{$lang.show}</A></DIV>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
													</tr>
												</TABLE>
												<TABLE WIDTH=100% BORDER=0 cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
														<table id=tbl_hide_lookfor style="DISPLAY: inline" name="tbl_hide_lookfor" class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width=100% border=0>
														<tbody>
															<tr>
																<td>
																{foreach item=item key=key from=$lang.signup_gender_look}
																<input type="checkbox" name="txtlookgender[]" value="{$key}" 
																{if $key == 'F'}
																Checked
																{/if} />{$item|stripslashes}
																{/foreach}
																</td>
															</tr>
														</tbody>
														</table>
													</td>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
									<br />
									<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="501">
														{$lang.signup_pref_age_range|replace:":":' '}
														</td>
														<td class="module_head_right">
														<DIV id=div_hide_agerange style="DISPLAY: inline" name="div_hide_agerange"><A onclick="javascript: DispHideHide(document.getElementById('div_disp_agerange'),document.getElementById('tbl_hide_agerange'),document.getElementById('div_hide_agerange'));" 									
														href="javascript:void(0)">{$lang.hide}</A></DIV>
														<DIV id=div_disp_agerange style="DISPLAY: none" name="div_disp_agerange"><A onclick="javascript: DispDispHide(document.getElementById('tbl_hide_agerange'),document.getElementById('div_hide_agerange'),document.getElementById('div_disp_agerange'));" 
														href="javascript:void(0)">{$lang.show}</A></DIV>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
													</tr>
												</TABLE>
												<TABLE WIDTH=100% BORDER=0 cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
														<table id=tbl_hide_agerange style="DISPLAY: inline" name="tbl_hide_lookfor" class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width=100% border=0>
														<tbody>
															<tr>
																<td >
																{ $lang.from }
																<select class=select style="WIDTH: 100px;"   height:"30px"  name="txtlookagestart">
																<option value='' selected>{$lang.select_from_list}</optin>
																{html_options values=$lang.start_agerange output=$lang.start_agerange}
																</select>
																{$lang.to} 
																<select class=select style="WIDTH: 100px" name="txtlookageend"  height:30px;>
																<option value='' selected>{$lang.select_from_list}</optin>
																{html_options values=$lang.end_agerange output=$lang.end_agerange }
																</select>
																</td>
															</tr>
														</tbody>
														</table>
														</td>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
									<br />
									<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="501">
														{$lang.signup_country|replace:":":' '|stripslashes}
														</td>
														<td class="module_head_right" width="25">
														<DIV id=div_hide_country style="DISPLAY: inline" name="div_hide_country"><A onclick="javascript: DispHideHide(document.getElementById('div_disp_country'),document.getElementById('tbl_hide_country'),document.getElementById('div_hide_country'));" 									
														href="javascript:void(0)">{$lang.hide}</A></DIV>
														<DIV id=div_disp_country style="DISPLAY: none" name="div_disp_country"><A onclick="javascript: DispDispHide(document.getElementById('tbl_hide_country'),document.getElementById('div_hide_country'),document.getElementById('div_disp_country'));" 
														href="javascript:void(0)">{$lang.show}</A></DIV>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
													</tr>
												</TABLE>
												<TABLE WIDTH=100% BORDER=0 cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
														<table id=tbl_hide_country style="DISPLAY: inline" name="tbl_hide_lookfor" class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width=100% border=0>
														<tbody>
															<tr>
																<td>
																<select class=select style="WIDTH: 175px" name=txtfrom height:30px; size="5" multiple>
																{html_options options=$lang.allcountries}
																</select>
																</td>
															</tr>
														</tbody>
														</table>
														</td>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
									<br />
							{foreach item=row from=$data}
								{if $row.id != 5 and $row.extsearchhead != ''}
									<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="464">
															{$row.extsearchhead|replace:":":' '|stripslashes}
														</td>
														<td class="module_head_right" width="50" align=right>
															<DIV id="div_disp_{$row.id}"  style="DISPLAY: inline" name="div_disp_{$row.id}"><A onclick="javascript: DispDispHide(document.getElementById('tbl_hide_{$row.id}'),document.getElementById('div_hide_{$row.id}'),document.getElementById('div_disp_{$row.id}'));" 
															href="javascript:void(0)">{$lang.show}</A></DIV>
															<DIV id="div_hide_{$row.id}"  style="DISPLAY: none" name="div_hide_{$row.id}"><A onclick="javascript: DispHideHide(document.getElementById('div_disp_{$row.id}'),document.getElementById('tbl_hide_{$row.id}'),document.getElementById('div_hide_{$row.id}'));" 
															href="javascript:void(0)">{$lang.hide}</A></DIV>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
													</tr>
												</TABLE>
												<TABLE WIDTH=100% BORDER=0 cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
															<table id="tbl_hide_{$row.id}" style="DISPLAY: none"   name="tbl_hide_{$row.id}" class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width=100% border=0>
															<tbody>
														{if $row.control_type == 'textarea'}
															<tr><td>
															{$row.extsearchhead|stripslashes}:&nbsp;
															<input name="{$row.id}[]"  type="text" size="40" maxlength="250" />
															</td></tr>
														{else}
														{assign var="mcount" value="0"}			
														{foreach key=key item=curropt from=$row.options}
															{if $mcount == 0 }
																<tr>
															{/if}
															{math equation="$mcount+1" assign="mcount"}		
																	<td>
																	<input name={$row.id}[] type=checkbox value="{$key}" />{$curropt|stripslashes} <br />
																	</td>
															{if $mcount == 2 }
																{assign var="mcount" value="0"}							
																</tr>
															{/if}
														{/foreach}
														{/if}
															</tbody>
															</table>
														</td>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
									<br />
								{elseif $row.extsearchhead != ''}
									<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
													<tr>
														<td class="module_head" width="6"></td>
														<td class="module_head" width="464">
															{$row.extsearchhead|replace:":":' '|stripslashes}
														</td>
														<td class="module_head_right" width="50" align=right>
															<DIV id="div_hide_{$row.id}"  style="DISPLAY: none" name="div_hide_{$row.id}"><A onclick="javascript: document.getElementById('frmExtSearch').height.value='no';DispHideHide(document.getElementById('div_disp_{$row.id}'),document.getElementById('tbl_hide_{$row.id}'),document.getElementById('div_hide_{$row.id}'));"
															href="javascript:void(0)">{$lang.hide}</A></DIV>
															<DIV id="div_disp_{$row.id}"  style="DISPLAY: inline" name="div_disp_{$row.id}"><A onclick="javascript: document.getElementById('frmExtSearch').height.value='yes';DispDispHide(document.getElementById('tbl_hide_{$row.id}'),document.getElementById('div_hide_{$row.id}'),document.getElementById('div_disp_{$row.id}'));"
															href="javascript:void(0)">{$lang.show}</A></DIV>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
													</tr>
												</TABLE>
												<TABLE WIDTH=100% BORDER=0 cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
															<table id="tbl_hide_{$row.id}"  style="DISPLAY: none" name="tbl_hide_{$row.id}" class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width=100% border=0>
															<tbody>
																<tr>
																	<td>     {$lang.between}&nbsp;
																	<select name="{$row.id}[]" >
																	<option value='' selected>{$lang.select_from_list}</option>
																	{html_options options=$row.options }
																	</select>&nbsp; {$lang.and}&nbsp;
																	<select name="{$row.id}[]" >
																	<option value='' selected>{$lang.select_from_list}</option>
																	{html_options options=$row.endoptions}
																	</select>
																	<input type="hidden" name="height" value="no"  />
																	</td>
																</tr>
															</tbody>
															</table>
														</td>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
									<br />
								{/if}	
							{/foreach}
									<table width="100%">
										<tr>
											<td align="center">
												<input type="submit" class="formbutton" value="{$lang.search}" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</form>
			</TABLE>
		</td>
	</tr>
</TABLE>
	
{/strip}
