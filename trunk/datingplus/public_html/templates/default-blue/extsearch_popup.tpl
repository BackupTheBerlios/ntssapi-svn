{strip}
{include file="popheader.tpl"}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">
			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.extended_search}
					</td>
				</tr>
			</table>
      <form name="frmExtSearch" id="frmExtSearch" method="post" action="extmatch_popup.php" >
        <input type="hidden" name="frm" id="frm" value="frmExtSearch"/>
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
				<tr>
					<td width="100%">
						<table width="571" border="0" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}">
							<tr>
								<td width="100%">
									<table width="550" border="0" cellpadding="0" cellspacing="0"  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<table width="100%" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="501">
														{$lang.sex|replace:":":' '}
														</td>
														<td class="module_head_right" width="25">
														<div id="div_hide_sex" style="display: inline"><a onclick="javascript: DispHideHide(document.getElementById('div_disp_sex'),document.getElementById('tbl_hide_sex'),document.getElementById('div_hide_sex'));"
														href="javascript:void(0)">{$lang.hide}</a></div>
														<div id="div_disp_sex" style="display: none"><a onclick="javascript: DispDispHide(document.getElementById('tbl_hide_sex'),document.getElementById('div_hide_sex'),document.getElementById('div_disp_sex'));"
														href="javascript:void(0)">{$lang.show}</a></div>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
													</tr>
												</table>
												<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
														<table id="tbl_hide_sex" style="display: inline" class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
														<tbody>
															<tr>
																<td>
																{foreach item=item key=key from=$lang.signup_gender_values}
																<input type="checkbox" name="txtgender[]" value="{$key}"
																{if $key == 'm'}
                checked="checked"
																{/if} />{$item|stripslashes}
																{/foreach}
																</td>
															</tr>
														</tbody>
														</table>
													</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br />
									<table width="550" border="0" cellpadding="0" cellspacing="0"  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<table width="100%" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="501">
														{$lang.looking_for|replace:":":' '}
														</td>
														<td class="module_head_right" width="25">
														<div id="div_hide_lookfor" style="display: inline"><a onclick="javascript: DispHideHide(document.getElementById('div_disp_lookfor'),document.getElementById('tbl_hide_lookfor'),document.getElementById('div_hide_lookfor'));"
														href="javascript:void(0)">{$lang.hide}</a></div>
														<div id="div_disp_lookfor" style="display: none"><a onclick="javascript: DispDispHide(document.getElementById('tbl_hide_lookfor'),document.getElementById('div_hide_lookfor'),document.getElementById('div_disp_lookfor'));"
														href="javascript:void(0)">{$lang.show}</a></div>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
													</tr>
												</table>
												<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
														<table id="tbl_hide_lookfor" style="display: inline" class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
														<tbody>
															<tr>
																<td>
																{foreach item=item key=key from=$lang.signup_gender_look}
																<input type="checkbox" name="txtlookgender[]" value="{$key}"
																{if $key == 'f'}
                checked="checked"
																{/if} />{$item|stripslashes}
																{/foreach}
																</td>
															</tr>
														</tbody>
														</table>
													</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br />
									<table width="550" border="0" cellpadding="0" cellspacing="0"  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<table width="100%" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="501">
														{$lang.signup_pref_age_range|replace:":":' '}
														</td>
														<td class="module_head_right">
														<div id="div_hide_agerange" style="display: inline"><a onclick="javascript: DispHideHide(document.getElementById('div_disp_agerange'),document.getElementById('tbl_hide_agerange'),document.getElementById('div_hide_agerange'));"
														href="javascript:void(0)">{$lang.hide}</a></div>
														<div id="div_disp_agerange" style="display: none"><a onclick="javascript: DispDispHide(document.getElementById('tbl_hide_agerange'),document.getElementById('div_hide_agerange'),document.getElementById('div_disp_agerange'));"
														href="javascript:void(0)">{$lang.show}</a></div>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
													</tr>
												</table>
												<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
														<table id="tbl_hide_agerange" style="display: inline" class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
														<tbody>
															<tr>
																<td >
																{ $lang.from }
                                <select class="select" style="width: 100px;"  name="txtlookagestart">
																<option value='' selected>{$lang.select_from_list}</option>
																{html_options values=$lang.start_agerange output=$lang.start_agerange}
																</select>
																{$lang.to}
                                <select class="select" style="width: 100px;" name="txtlookageend" >
																<option value='' selected>{$lang.select_from_list}</option>
																{html_options values=$lang.end_agerange output=$lang.end_agerange }
																</select>
																</td>
															</tr>
														</tbody>
														</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br />
									<table width="550" border="0" cellpadding="0" cellspacing="0"  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<table width="100%" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="501">
														{$lang.signup_country|replace:":":' '}
														</td>
														<td class="module_head_right" width="25">
														<div id="div_hide_country" style="display: inline"><a onclick="javascript: DispHideHide(document.getElementById('div_disp_country'),document.getElementById('tbl_hide_country'),document.getElementById('div_hide_country'));"
														href="javascript:void(0)">{$lang.hide}</a></div>
														<div id="div_disp_country" style="display: none"><a onclick="javascript: DispDispHide(document.getElementById('tbl_hide_country'),document.getElementById('div_hide_country'),document.getElementById('div_disp_country'));"
														href="javascript:void(0)">{$lang.show}</a></div>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
													</tr>
												</table>
												<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
														<table id="tbl_hide_country" style="display: inline" class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
														<tbody>
															<tr>
																<td>
																<select class="select" style="width: 175px;" name="txtfrom"  size="5" multiple>
																{html_options options=$lang.allcountries}
																</select>
																</td>
															</tr>
														</tbody>
														</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br />
							{foreach item=row from=$data}
								{if $row.id != 5 and $row.extsearchhead != ''}
									<table width="550" border="0" cellpadding="0" cellspacing="0"  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<table width="100%" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td class="module_head" width="6">&nbsp;</td>
														<td class="module_head" width="464">
															{$row.extsearchhead|replace:":":' '}
														</td>
														<td class="module_head_right" width="50" align="right">
															<div id="div_disp_{$row.id}"  style="display: inline"><a onclick="javascript: DispDispHide(document.getElementById('tbl_hide_{$row.id}'),document.getElementById('div_hide_{$row.id}'),document.getElementById('div_disp_{$row.id}'));"
															href="javascript:void(0)">{$lang.show}</a></div>
															<div id="div_hide_{$row.id}"  style="display: none"><a onclick="javascript: DispHideHide(document.getElementById('div_disp_{$row.id}'),document.getElementById('tbl_hide_{$row.id}'),document.getElementById('div_hide_{$row.id}'));"
															href="javascript:void(0)">{$lang.hide}</a></div>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
													</tr>
												</table>
												<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
															<table id="tbl_hide_{$row.id}" style="display: none" class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
															<tbody>
														{if $row.control_type == 'textarea'}
															<tr><td>
															{$row.extsearchhead|stripslashes}:&nbsp;
															<input name="{$row.id}[]"  type="text" size="40" maxlength="250"/>
															</td></tr>
														{else}
														{assign var="mcount" value="0"}
														{foreach key=key item=curropt from=$row.options}
															{if $mcount == 0 }
																<tr>
															{/if}
															{math equation="$mcount+1" assign="mcount"}
																	<td>
																	<input name="{$row.id}[]" type="checkbox" value="{$key}"/>{$curropt|stripslashes} <br />
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
												</table>
											</td>
										</tr>
									</table>
									<br />
								{elseif $row.extsearchhead != ''}
									<table width="550" border="0" cellpadding="0" cellspacing="0"  >
										<tr>
											<td class="module_detail_inside" width="100%">
												<table width="100%" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td class="module_head" width="6"></td>
														<td class="module_head" width="464">
															{$row.extsearchhead|replace:":":' '|stripslashes}
														</td>
														<td class="module_head_right" width="50" align="right">
															<div id="div_hide_{$row.id}"  style="display: none" ><a onclick="javascript: document.getElementById('frmExtSearch').height.value='no';DispHideHide(document.getElementById('div_disp_{$row.id}'),document.getElementById('tbl_hide_{$row.id}'),document.getElementById('div_hide_{$row.id}'));"
															href="javascript:void(0)">{$lang.hide}</a></div>
															<div id="div_disp_{$row.id}"  style="display: inline" ><a onclick="javascript: document.getElementById('frmExtSearch').height.value='yes';DispDispHide(document.getElementById('tbl_hide_{$row.id}'),document.getElementById('div_hide_{$row.id}'),document.getElementById('div_disp_{$row.id}'));"
															href="javascript:void(0)">{$lang.show}</a></div>
														</td>
														<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
													</tr>
												</table>
												<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="100%">
															<table id="tbl_hide_{$row.id}"  style="display: none" class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
															<tbody>
																<tr>
																	<td>{$lang.between}&nbsp;
																	<select name="{$row.id}[]" >
																	<option value='' selected>{$lang.select_from_list}</option>
																	{html_options options=$row.options }
																	</select>&nbsp; {$lang.and}&nbsp;
																	<select name="{$row.id}[]" >
																	<option value='' selected>{$lang.select_from_list}</option>
																	{html_options options=$row.endoptions}
																	</select>
																	<input type="hidden" name="height" value="no" style="visibility:hidden;"/>
																	</td>
																</tr>
															</tbody>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br />
								{/if}
							{/foreach}
									<table width="100%">
										<tr>
											<td align="center">
												<input type="submit" class="formbutton" value="{$lang.search}"/>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
      </tbody>
			</table>
      </form>
		</td>
	</tr>
</table>
{include file="popfooter.tpl"}
{/strip}
