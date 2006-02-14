{strip}
<script type="text/javascript">
/* <![CDATA[ */
function validate(form)
{ldelim}
	var tz=form.txttimezone.value;
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13)+ String.fromCharCode(10);

	CheckFieldString("noblank",form.txtfirstname,"{$lang.signup_js_errors.firstname_noblank}");
	CheckFieldString("noblank",form.txtlastname,"{$lang.signup_js_errors.lastname_noblank}");
	CheckFieldString("noblank",form.txtemail,"{$lang.signup_js_errors.email_noblank}");
	
	{ if $config.city_mandatory eq 'Y' }
		CheckFieldString("noblank",form.txtcity,"{$lang.signup_js_errors.city_noblank}");
	{/if}
	{ if $config.county_mandatory eq 'Y' }
		CheckFieldString("noblank",form.txtcounty,"{$lang.signup_js_errors.county_noblank}");
	{/if}
	{ if $config.zipcode_mandatory eq 'Y' }
		CheckFieldString("noblank",form.txtzip,"{$lang.signup_js_errors.zip_noblank}");
	{/if}
	{ if $config.state_mandatory eq 'Y' }
		CheckFieldString("noblank",form.txtstateprovince,"{$lang.signup_js_errors.stateprovince_noblank}");
	{/if}

	CheckFieldString("text",form.txtfirstname,"{$lang.signup_js_errors.firstname_charset}");
	CheckFieldString("text",form.txtlastname,"{$lang.signup_js_errors.lastname_charset}");
	CheckFieldString("email",form.txtemail,"{$lang.signup_js_errors.email_notvalid}");

	CheckFieldString("text",form.txtcity,"{$lang.signup_js_errors.city_charset}");
	CheckFieldString("alphanumeric",form.txtzip,"{$lang.signup_js_errors.zip_charset}");
	CheckFieldString("alphanumeric",form.txtaddress1,"{$lang.signup_js_errors.address_charset}");
	CheckFieldString("alphanumeric",form.txtaddress2,"{$lang.signup_js_errors.address_charset}");

	CheckFieldString("text",form.txtlookcity,"{$lang.signup_js_errors.address_charset}");
	CheckFieldString("alphanumeric",form.txtlookzip,"{$lang.signup_js_errors.address_charset}");

	result="";
	if (tz == '-25') {ldelim}
		ErrorMsg[ErrorCount]+="{$lang.signup_js_errors.timezone_noblank}" +  String.fromCharCode(13) +  String.fromCharCode(10);
		ErrorCount++;
	{rdelim}
	if( ErrorCount > 0)
	{ldelim}
		for( c in ErrorMsg)
			result += ErrorMsg[c]+ String.fromCharCode(13)+ String.fromCharCode(10);
		alert(result);
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
					{$lang.section_signup_title}
					</td>
				</tr>
			</table>
      {if $modify_error neq ""}
      <font color="{$lang.error_msg_color}">{$modify_error}</font>
      {/if}
      <form name="frmEditUser" method="post" action="modifyuser.php" onsubmit="javascript: if(this.chgcntry != '1')return validate(this);">
      <input type="hidden" name="txtuserid" value="{$user.id}"/>
      <input type="hidden" name="txtusername" value="{$user.username}"/>
			<table width="571" border="0" cellpadding="{$config.cellspacing}"  cellspacing="{$config.cellpadding}">
				<tr>
					<td width="100%">
						<table width="550" border="0" cellpadding="2" cellspacing="1" >
							<tr>
								<td align="center" class='edituserlink'>
									{$lang.section_signup_title}
								</td>
								{foreach key=key item=item from=$sections}
									<td align="center" class='edituserlink'>
										{if $key !=$smarty.get.sectionid}
										<a href="editquestions.php?sectionid={$key}"  class='edituserlink'>
										{/if}
										<span>{$item}</span>
										{if $key !=$smarty.get.sectionid}
											</a>
										{/if}
									</td>
								{/foreach}
							</tr>
						</table>
						<br />
						<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>{$lang.required_info_indication}
						<br />
						<br />
						<table width="550" border="0" cellpadding="0" cellspacing="0"  >
							<tr>
								<td class="module_detail_inside" width="100%">
									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td class="module_head" width="6">
											</td>
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
														<td width="33%">{$lang.signup_username} </td>
														<td width="67%"><b>{$user.username}</b>
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
														<td height="67%"> <input class="input" maxlength="50" name="txtfirstname" value="{$user.firstname|stripslashes}"/> </td>
													</tr>
													<tr>
														<td>{$lang.signup_lastname}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td> <input class="input" maxlength="50" name="txtlastname" value="{$user.lastname|stripslashes}"/> </td>
													</tr>
													<tr>
														<td>{$lang.signup_email}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td> <input class="input" maxlength="255" name="txtemail" size="40" value='{$user.email}'/>
														</td>
													</tr>
													<tr>
														<td>{$lang.signup_gender}:
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
                          <td> <select class="select" style="width: 80px;" name="txtgender" >
														{html_options options=$lang.signup_gender_values selected=$user.gender}
														</select>
														&nbsp;{$lang.looking_for}&nbsp;
														<select class="select" style="width: 105px" name="txtlookgender" >
														{html_options options=$lang.signup_gender_look selected=$user.lookgender}
														</select> </td>
													</tr>
													<tr>
														<td>{$lang.signup_pref_age_range}:
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
                          <td> <select class="select" style="width: 50px;" name="txtlookagestart">
														{html_options values=$lang.start_agerange output=$lang.start_agerange selected=$user.lookagestart}
														</select>
														{$lang.to}
                            <select class="select" style="width: 50px;" name="txtlookageend" >
														{html_options values=$lang.end_agerange output=$lang.end_agerange selected=$user.lookageend}
														</select>
														&nbsp;{$lang.signup_year_old}
														</td>
													</tr>
													<tr>
														<td>{$lang.signup_birthday}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td>

														{html_select_date_translated prefix="txtbirth" start_year=$config.start_year month_value_format="%m" time=$user.birth_date}
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
												<table id="tbl2" width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
													<tr>
														<td width="33%">{$lang.timezone}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														</td>
														<td width="67%"> <select class="select" style="width: 175px" name="txttimezone" >
														{html_options options=$lang.tz selected=$user.timezone}
														</select>
														</td>
													</tr>
													<tr>
														<td width="33%">{$lang.signup_country}																			<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														</td>
                            <td width="67%"><select class="select" style="width: 175px;" name="txtfrom" id="txtfrom"  onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
														{html_options options=$lang.countries selected=$user.country}
														</select>
														<input type="hidden" name="chgcntry" id="chgcntry" value=""/>
														</td>
													</tr>
													<tr>
														<td width="172">{$lang.signup_state_province}
														{if $config.state_mandatory == 'Y'}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														{/if}
														</td>
														<td width="344">
													{ if $lang.states|@count > 0}
														<select class="select" style="width: 175px" name="txtstateprovince" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
														{html_options options=$lang.states selected=$user.state_province}
														</select>
													{ else }
														<input name="txtstateprovince" type="text" size="30" maxlength="100" value="{$user.state_province}"/>
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
														{html_options options=$lang.counties selected=$user.county}
														</select>
													{ else }
														<input name="txtcounty" type="text" size="30" maxlength="100" value="{$user.county}"/>
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
														{html_options options=$lang.cities selected=$user.city}
														</select>
													{ else }
														<input name="txtcity" type="text" size="30" maxlength="100" value="{$user.city}"/>
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
														{html_options options=$lang.zipcodes selected=$user.zip}
														</select>
													{ else }
														<input name="txtzip" type="text" size="30" maxlength="100" value="{$user.zip}"/>
													{ /if}
														</td>
													</tr>
													<tr>
														<td>{$lang.signup_address1}</td>
														<td> <input class="input" maxlength="255" name="txtaddress1" size="40" value="{$user.address_line1|stripslashes}"/>
														</td>
													</tr>
													<tr>
														<td height="22">{$lang.signup_address2}</td>
														<td height="22"> <input class="input" maxlength="255" name="txtaddress2" size="40" value="{$user.address_line2|stripslashes}"/>
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
														<td width="33%">{$lang.signup_country}
															<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td width="67%">
                              <select class="select" style="width: 175px;" name="txtlookfrom"  onchange="javascript:this.form.chgcntry.value='1'; this.form.submit();">
															{html_options options=$lang.lookcountries selected=$user.lookcountry}
															</select>
														</td>
													</tr>
													<tr>
														<td width="172">{$lang.signup_state_province}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
														<td width="344">
													{ if $lang.lookstates|@count > 0 }
														<select class="select" style="width: 175px" name="txtlookstateprovince"	onchange="javascript:this.form.chgcntry.value='1'; this.form.submit();">
														{html_options options=$lang.lookstates selected=$user.lookstate_province}
														</select>
													{else}
														<input name="txtlookstateprovince" value="{$user.lookstate_province}" size="30" maxlength="200"/>
													{/if}
														</td>
													</tr>
													<tr>
														<td width="172">{$lang.manage_counties}:
														{if $config.county_mandatory == 'Y'}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														{/if}
														</td>
														<td width="344">
													{ if $lang.lookcounties|@count > 0}
														<select class="select" style="width: 175px" name="txtlookcounty" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
														{html_options options=$lang.lookcounties selected=$user.lookcounty}
														</select>
													{ else }
														<input name="txtlookcounty" type="text" size="30" maxlength="100" value="{$user.lookcounty}"/>
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
													{ if $lang.lookcities|@count > 0}
														<select class="select" style="width: 175px" name="txtlookcity" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
														{html_options options=$lang.lookcities selected=$user.lookcity}
														</select>
													{ else }
														<input name="txtlookcity" type="text" size="30" maxlength="100" value="{$user.lookcity}"/>
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
													{ if $lang.lookzipcodes|@count > 0}
														<select class="select" style="width: 175px" name="txtlookzip">
														{html_options options=$lang.lookzipcodes selected=$user.lookzip}
														</select>
													{ else }
														<input name="txtlookzip" type="text" size="30" maxlength="100" value="{$user.lookzip}"/>
													{ /if}
														</td>
													</tr>
													<tr>
														<td>{$lang.signup_view_online}
														<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														</td>
														<td> <input class="radio" type="radio"    value='1' name="txtviewonline" {if $user.allow_viewonline eq '1'}checked="checked"{/if}/>{$lang.yes}
														<input class="radio" type="radio" value='0' name="txtviewonline" {if $user.allow_viewonline eq '0'}checked="checked"{/if}/>{$lang.no}
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
						<center>
						<input type="submit" class="formbutton" value='{$lang.submit}'/> <input type="reset" class="formbutton" value='{$lang.reset}'/>
						</center>
					</td>
				</tr>
			</table>
      </form>
		</td>
	</tr>
</table>
<br />
{/strip}
