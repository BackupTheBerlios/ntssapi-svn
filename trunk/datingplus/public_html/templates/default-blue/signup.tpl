{strip}
<script type="text/javascript">
/* <![CDATA[ */
function validateme(form)
{ldelim}
	var tz=form.txttimezone.value;
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13);

	/* log details */
	CheckFieldString("noblank",form.txtusername,"{$lang.signup_js_errors.username_noblank}");
	CheckFieldString("noblank",form.txtpassword,"{$lang.signup_js_errors.password_noblank}");
	CheckFieldString("noblank",form.txtpassword2,"{$lang.signup_js_errors.con_password_noblank}");
	/*profile*/
	CheckFieldString("noblank",form.txtfirstname,"{$lang.signup_js_errors.firstname_noblank}");
	CheckFieldString("noblank",form.txtlastname,"{$lang.signup_js_errors.lastname_noblank}");
	CheckFieldString("noblank",form.txtemail,"{$lang.signup_js_errors.email_noblank}");
	/*address*/
	
	{ if $config.state_mandatory eq 'Y' }
		CheckFieldString("noblank",form.txtstateprovince,"{$lang.signup_js_errors.stateprovince_noblank}");
	{/if}
	{ if $config.county_mandatory eq 'Y' }
		CheckFieldString("noblank",form.txtcounty,"{$lang.signup_js_errors.county_noblank}");
	{/if}
	{ if $config.city_mandatory eq 'Y' }
		CheckFieldString("noblank",form.txtcity,"{$lang.signup_js_errors.city_noblank}");
	{/if}
	{ if $config.zipcode_mandatory eq 'Y' }
		CheckFieldString("noblank",form.txtzip,"{$lang.signup_js_errors.zip_noblank}");
	{/if}
	/*preferences
	empty */

	/*log details*/
	CheckFieldString("alphanum",form.txtusername,"{$lang.signup_js_errors.username_charset}");
	CheckFieldString("alphanum",form.txtpassword,"{$lang.signup_js_errors.password_charset}");

	/*profile*/
	CheckFieldString("text",form.txtfirstname,"{$lang.signup_js_errors.firstname_charset}");
	CheckFieldString("text",form.txtlastname,"{$lang.signup_js_errors.lastname_charset}");
	CheckFieldString("email",form.txtemail,"{$lang.signup_js_errors.email_notvalid}");
	/*address*/
	CheckFieldString("text",form.txtcounty,"{$lang.signup_js_errors.county_charset}");
	CheckFieldString("text",form.txtcity,"{$lang.signup_js_errors.city_charset}");
	CheckFieldString("alphanumeric",form.txtzip,"{$lang.signup_js_errors.zip_charset}");
	/*preferences*/
	CheckFieldString("text",form.txtlookcity,"{$lang.signup_js_errors.address_charset}");
	CheckFieldString("alphanumeric",form.txtlookzip,"{$lang.signup_js_errors.address_charset}");

	if(form.txtusername.value.length >= {$config.min_username_len} && form.txtusername.value.length <= {$config.max_username_len}){ldelim}
		if ( !isNaN(form.txtusername.value.charAt(0)) ){ldelim}
			ErrorCount++;
			ErrorMsg[ErrorCount] = "{$lang.signup_js_errors.username_start_alpha}"  + String.fromCharCode(13);
		{rdelim}
	{rdelim}else{ldelim}
		ErrorCount++;
		ErrorMsg[ErrorCount] = "{$lang.signup_js_errors.username_outrange}"  + String.fromCharCode(13);
	{rdelim}

	if( form.txtpassword.value.length >= {$config.min_pass_len} && form.txtpassword.value.length <= {$config.max_pass_len}){ldelim}
		if ( form.txtpassword.value != form.txtpassword2.value ){ldelim}
			ErrorCount++;
				ErrorMsg[ErrorCount] = "{$lang.signup_js_errors.password_nomatch}"  + String.fromCharCode(13);
		{rdelim}
	{rdelim}else{ldelim}
		ErrorCount++;
		ErrorMsg[ErrorCount] = "{$lang.signup_js_errors.password_outrange}"  + String.fromCharCode(13);
	{rdelim}
	if (tz == '-25') {ldelim}
		ErrorCount++;
		ErrorMsg[ErrorCount]="{$lang.signup_js_errors.timezone_noblank}" +  String.fromCharCode(13) +  String.fromCharCode(10);
	{rdelim}

	/* concat all error messages into one string */
	result="";
	if( ErrorCount > 0)
	{ldelim}
		/* for( c in ErrorMsg)
			result += ErrorMsg[c]; */
		alert(ErrorMsg[1]);
		return false;
	{rdelim}
	return true;
{rdelim}
/* ]]> */
</script>

<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">
			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
					{$lang.signup}
					</td>
				</tr>
			</table>
      <form name="frmSignup" id="frmSignup" method="post" action="savesignup.php" onsubmit="javascript: return validateme(this);">
			<table width="571" border="0" cellpadding="0" cellspacing="9">
				<tr>
					<td width="100%" valign="top">
					{if $smarty.get.errid != ''}
						<font color="#FF0000">{$lang.errormsgs[$smarty.get.errid]}</font><br /><br />
					{/if}
						<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>{$lang.required_info_indication}
						<br /><br />
						<table width="550" border="0" cellpadding="0" cellspacing="0"  >
							<tr>
								<td class="module_detail_inside" width="100%">
									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td class="module_head" width="6"></td>
											<td class="module_head" width="516">
											{$lang.signup_subtitle_login}
											</td>
											<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
										</tr>
									</table>
									<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
										<tr>
											<td width="100%">
												<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td height="2" >{$lang.signup_username}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td height="2" > <input class="input" maxlength="25" name="txtusername" size="{$config.max_username_len}" value="{$smarty.session.username}" />&nbsp;
														({$config.min_username_len}{$lang.to}{$config.max_username_len}&nbsp;{$lang.characters})
														</td>
													</tr>
													<tr>
														<td>{$lang.signup_password}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td> <input class="input" type="password" name="txtpassword" size="{$config.max_pass_len}" value="{$password}" />&nbsp;({$config.min_pass_len}{$lang.to}{$config.max_pass_len}&nbsp;{$lang.characters})
														</td>
													</tr>
													<tr>
														<td>{$lang.signup_confirm_password}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td> <input class="input" type="password" name="txtpassword2" size="{$config.max_pass_len}" value="{$password2}" />
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
						<table width="550" border="0" cellpadding="0" cellspacing="0" >
							<tr>
								<td class="module_detail_inside" width="100%">
									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td class="module_head" width="6"></td>
											<td class="module_head" width="516">
											{$lang.signup_subtitle_profile}
											</td>
											<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
										</tr>
									</table>
									<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
										<tr>
											<td width="100%">
												<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="33%">{$lang.signup_firstname}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td width="67%"><input class="input" maxlength="50" name="txtfirstname" value="{$smarty.session.firstname}" /></td>
													</tr>
													<tr>
														<td>{$lang.signup_lastname}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td> <input class="input" maxlength="50" name="txtlastname" value="{$smarty.session.lastname}" /> </td>
													</tr>
													<tr>
														<td>{$lang.signup_email}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td> <input class="input" maxlength="255" name="txtemail" size="40" value="{$smarty.session.email}" />
														</td>
													</tr>
													<tr>
														<td>{$lang.signup_gender}:
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
                          <td> <select class="select" style="width: 80px;" name="txtgender" >
														{html_options options=$lang.signup_gender_values selected=$smarty.session.gender}
														</select>&nbsp;
														{$lang.looking_for_a}&nbsp;
														<select class="select" style="width: 100px" name="txtlookgender">
														{if $smarty.session.lookgender == ''}
														{html_options options=$lang.signup_gender_look selected='F'}
														{else}
														{html_options options=$lang.signup_gender_look selected=$smarty.session.lookgender }
														{/if}
														</select> </td>
													</tr>
													<tr>
														<td>{$lang.signup_pref_age_range}:
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td> <select class="select" style="width: 50px" name="txtlookagestart">
														{html_options values=$lang.start_agerange output=$lang.start_agerange}
														</select>
														{$lang.to}
														<select class="select" style="width: 50px" name="txtlookageend">
														{html_options values=$lang.end_agerange output=$lang.end_agerange selected='99'}
														</select>&nbsp;
														{$lang.signup_year_old}. </td>
													</tr>
													<tr>
														<td>{$lang.signup_birthday}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td>
														{html_select_date_translated prefix="txtbirth" start_year=$config.start_year end_year=$config.end_year month_value_format="%m" time=$selectedtime}
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
						<table width="550" border="0" cellpadding="0" cellspacing="0" >
							<tr>
								<td class="module_detail_inside" width="100%">
									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td class="module_head" width="6"></td>
											<td class="module_head" width="516">
											{$lang.signup_subtitle_address}
											</td>
											<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
										</tr>
									</table>
									<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
										<tr>
											<td width="100%">
												<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" id="tbl2">
													<tr>
														<td>
															{$lang.timezone}
															<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														</td>
														<td>
															
                              												<select class="select" style="width: 175px;" name="txttimezone">
															{html_options options=$lang.tz selected=$smarty.session.timezone}
															</select>
														</td>
													</tr>
													<tr>
														<td width="33%">{$lang.signup_country}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font> </td>
                          <td width="67%"><select class="select" style="width: 175px;" name="txtfrom" id="txtfrom"  onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
														{html_options options=$lang.countries selected=$smarty.session.from}
														</select>
														<input type="hidden" name="chgcntry" id="chgcntry" value="" />
														</td>
													</tr>
													<tr>
														<td width="172">
														{$lang.signup_state_province}
														{if $config.state_mandatory == 'Y'}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														{/if}
														</td>
														<td width="344">
													{ if $lang.states|@count > 0}
														<select class="select" style="width: 175px" name="txtstateprovince" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
														{html_options options=$lang.states selected=$smarty.session.stateprovince}
														</select>
													{ else }
														<input name="txtstateprovince" type="text" size="30" maxlength="100" value="{$txtstateprovince}" />
													{ /if}
														</td>
													</tr>
													<tr>
														<td width="172">{$lang.manage_counties}:
														{if $config.county_mandatory == 'Y'}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														{/if}
														</td>
														<td width="344">
													{ if $lang.counties|@count > 0}
														<select class="select" style="width: 175px" name="txtcounty" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
														{html_options options=$lang.counties selected=$smarty.session.countycode}
														</select>
													{ else }
														<input name="txtcounty" type="text" size="30" maxlength="100" value="{$smarty.session.countycode}" />
													{ /if}
														</td>
													</tr>
													<tr>
														<td>
															{$lang.signup_city}
															{if $config.city_mandatory == 'Y' }
															<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
															{/if}
														</td>
														<td>
													{ if $lang.cities|@count > 0}
														<select class="select" style="width: 175px" name="txtcity" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
														{html_options options=$lang.cities selected=$smarty.session.citycode}
														</select>
													{ else }
														<input name="txtcity" type="text" size="30" maxlength="100" value="{$smarty.session.citycode}" />
													{ /if}
														</td>
													</tr>
													<tr>
														<td>
															{$lang.signup_zip}
															{if $config.zipcode_mandatory == 'Y' }
															<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
															{/if}
														</td>
														<td>
													{ if $lang.zipcodes|@count > 0}
														<select class="select" style="width: 175px" name="txtzip">
														{html_options options=$lang.zipcodes selected=$smarty.session.zip}
														</select>
													{ else }
														<input name="txtzip" type="text" size="30" maxlength="100" value="{$smarty.session.zip}" />
													{ /if}
														</td>
													</tr>
													<tr>
														<td>
															{$lang.signup_address1}
														</td>
														<td>
															<input class="input" maxlength="255" name="txtaddress1" size="40" value="{$smarty.session.address1}" />
														</td>
													</tr>
													<tr>
														<td height="22">
															{$lang.signup_address2}
														</td>
														<td height="22">
															<input class="input" maxlength="255" name="txtaddress2" size="40" value="{$smarty.session.address2}" />
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
						<table width="550" border="0" cellpadding="0" cellspacing="0" >
							<tr>
								<td class="module_detail_inside" width="100%">
									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td class="module_head" width="6"></td>
											<td class="module_head" width="516">
											{$lang.signup_subtitle_preference}
											</td>
											<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
										</tr>
									</table>
									<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
										<tr>
											<td width="100%">
											<table width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" id="tbl">
												<tr>
													<td colspan="2">{$lang.signup_where_should_we_look}  </td>
												</tr>
												<tr>
													<td width="33%">
														{$lang.signup_country}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
													</td>
													<td width="67%">
                            <select class="select" style="width: 175px;" name="txtlookfrom"  onchange="javascript:this.form.chgcntry.value='1'; this.form.submit();">
														{html_options options=$lang.lookcountries selected=$smarty.session.lookfrom}
														</select>
													</td>
												</tr>
												<tr>
													<td width="172">{$lang.signup_state_province}
													<td width="344">
												{ if $lang.lookstates|@count > 0 }
													<select class="select" style="width: 175px" name="txtlookstateprovince" onchange="javascript:this.form.chgcntry.value='1'; this.form.submit();">
													{html_options options=$lang.lookstates selected=$smarty.session.lookstateprovince}
													</select>
												{else}
													<input name="txtlookstateprovince" value="{$smarty.session.lookstateprovince}" size="30" maxlength="200" />
												{/if}
													</td>
												</tr>
												<tr>
													<td width="172">{$lang.manage_counties}:
													</td>
													<td width="344">
												{ if $lang.lookcounties|@count > 0}
													<select class="select" style="width: 175px" name="txtlookcounty" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
													{html_options options=$lang.lookcounties selected=$smarty.session.lookcounty}
													</select>
												{ else }
													<input name="txtlookcounty" type="text" size="30" maxlength="100" value="{$smarty.session.lookcounty}" />
												{ /if}
													</td>
												</tr>
												<tr>
													<td>
														{$lang.signup_city}
													</td>
													<td>
												{ if $lang.lookcities|@count > 0}
													<select class="select" style="width: 175px" name="txtlookcity" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
													{html_options options=$lang.lookcities selected=$smarty.session.lookcity}
													</select>
												{ else }
													<input name="txtlookcity" type="text" size="30" maxlength="100" value="{$smarty.session.lookcity}" />
												{ /if}
													</td>
												</tr>
												<tr>
													<td>
														{$lang.signup_zip}
													</td>
													<td>
												{ if $lang.lookzipcodes|@count > 0}
													<select class="select" style="width: 175px" name="txtlookzip">
													{html_options options=$lang.lookzipcodes selected=$smarty.session.lookzip}
													</select>
												{ else }
													<input name="txtlookzip" type="text" size="30" maxlength="100" value="{$smarty.session.lookzip}" />
												{ /if}
													</td>
												</tr>
												<tr>
													<td>{$lang.signup_view_online}
													<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
													<td align="left"><input class="radio" type="radio" checked="checked" value="1"  name="txtviewonline" />
													{$lang.yes}&nbsp;
													<input class="radio" type="radio" value="0"
													name="txtviewonline" />
													{$lang.no} </td>
												</tr>

											</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<br />
						<center>
						<input type="submit" class="formbutton" value='{$lang.submit}' />&nbsp;<input type="reset" class="formbutton" value='{$lang.reset}' />
						</center>
					</td>
				</tr>
			</table>
    </form>
		</td>
	</tr>
</table>
{/strip}
