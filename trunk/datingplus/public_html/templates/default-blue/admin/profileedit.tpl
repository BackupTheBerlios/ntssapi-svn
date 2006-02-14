{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.modify_profile}{$lang.of}{$user.username}&nbsp;(ID:&nbsp;{$user.id})</td>
	</tr>
</table>
<br />
<table width="550" border="0" cellpadding="2" cellspacing="1">
	<tr>
		<td align="center" class='edituserlink'>
			{$lang.section_signup_title}
		</td>
	{foreach key=key item=item from=$sections}
		<td align="center" class='edituserlink'>
			{if $key !=$smarty.get.sectionid}
				<a href="editprofilequestions.php?sectionid={$key}&amp;edit={$smarty.get.edit}"  class='edituserlink'>
			{/if}
			<span>{$item}</span>
			{if $key !=$smarty.get.sectionid}
				</a>
			{/if}
		</td>
	{/foreach}
	</tr>
</table>
<form name="frmEditUser" id="frmEditUser" method="post" action="modifyprofile.php" >
<input type="hidden" name="txtuserid" value="{$user.id}" />
<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="573" border="0">
<tbody>
	<tr>
      	<td colspan="2">{if $error neq ""}<font color="{$lang.error_msg_color}">{$error}</font>{/if}</td>
    </tr>
   	<tr>
      	<td colspan="2"><font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator} </font>{$lang.required_info_indication}</td>
    </tr>
	<tr>
		<td colspan="2" align="center">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.signup_subtitle_login}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
		</td>
	</tr>
    <tr>
      	<td height="2" width="30%">{$lang.profile_username}
	  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
      	<td height="2"  width="70%"> <input type="text" value="{$user.username}" name="txtusername" />
      	</td>
    </tr>
    <tr>
      	<td >&nbsp;</td>
      	<td >&nbsp;</td>
    </tr>
	<tr>
		<td colspan="2">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.signup_subtitle_profile}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
		</td>
	</tr>
    <tr>
      	<td>{$lang.profile_firstname}
	  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
      	<td ><input class="input" maxlength="50" name="txtfirstname" value='{$user.firstname|stripslashes}' /> </td>
    </tr>
    <tr>
      	<td>{$lang.profile_lastname}
	  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
      	<td> <input class="input" maxlength="50" name="txtlastname" value='{$user.lastname|stripslashes}' /> </td>
    </tr>
    <tr>
      	<td>{$lang.profile_email}
	  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
      	<td> <input class="input" maxlength="255" name="txtemail" size="40" value='{$user.email}' />
      	</td>
    </tr>
    <tr>
      	<td>{$lang.profile_gender}
	  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
      	<td> <select class="select" style="WIDTH: 80px" name="txtgender">
			{html_options options=$lang.signup_gender_values selected=$user.gender}
        	</select>&nbsp;
{*        	{$lang.looking_for}&nbsp;
        	<select class=select style="WIDTH: 80px" name="txtlookgender">
			{html_options options=$lang.signup_gender_look selected=$user.lookgender}
        	</select>
*}
        </td>
    </tr>
{*
    <tr>
      	<td>{$lang.signup_pref_age_range}:
	  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
      	<td>
      		<select class="select" style="WIDTH: 50px" name="txtlookagestart">
	  		{html_options values="$lang.start_agerange" output=$lang.start_agerange selected=$user.lookagestart}
        	</select>
        	{$lang.to}
        	<select class="select" style="WIDTH: 50px" name="txtlookageend">
	  		{html_options values=$lang.end_agerange output=$lang.end_agerange selected=$user.lookageend}
        	</select>&nbsp;
        	{$lang.signup_year_old}
        </td>
    </tr>
*}
	<tr>
      	<td>{$lang.profile_birthday}
	  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
	  	<td>
	  		{html_select_date_translated prefix="txtbirth" start_year=$config.start_year month_value_format="%m" time=$user.birth_date}
	  	</td>
    </tr>
	<tr >
		<td colspan="2">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.signup_subtitle_address}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
		</td>
	</tr>
    <tr>
      	<td>{$lang.timezone}
	  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font> </td>
      	<td><select class="select" style="WIDTH: 175px" name="txttimezone">
			{html_options options=$lang.tz selected=$user.timezone}
        	</select>
        </td>
    </tr>
    <tr>
      	<td>{$lang.profile_country}
	  		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font> </td>
      	<td>
			<select class="select" style="WIDTH: 175px" name="txtfrom" id="txtfrom" onchange="javascript: document.frmEditUser.chgcntry.value='1'; document.frmEditUser.submit();" >
			{html_options options=$lang.countries selected=$user.country}
			</select>
			<input type="hidden" name="chgcntry" id="chgcntry" value="" />
		</td>
    </tr>
	<tr>
		<td width="172">{$lang.signup_state_province}
		{if $config.state_mandatory == 'Y' }
		<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
		{/if}
		</td>
		<td width="344">
	{ if $lang.states|@count > 0}
		<select class="select" style="WIDTH: 175px" name="txtstateprovince" onchange="javascript: document.frmEditUser.chgcntry.value='1'; document.frmEditUser.submit();" >
		{html_options options=$lang.states selected=$user.state_province}
		</select>
	{ else }
		<input name="txtstateprovince" type="text" size="30" maxlength="100" value="{$user.state_province}" />
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
			<select class="select" style="WIDTH: 175px" name="txtcounty" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
				{html_options options=$lang.counties selected=$user.county}
			</select>
		{ else }
			<input name="txtcounty" type="text" size="30" maxlength="100" value="{$user.county}" />
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
			<select class="select" style="WIDTH: 175px" name="txtcity" onchange="javascript: this.form.chgcntry.value='1'; this.form.submit();" >
			{html_options options=$lang.cities selected=$user.city}
			</select>
		{ else }
			<input name="txtcity" type="text" size="30" maxlength="100" value="{$user.city}" />
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
			<select class="select" style="WIDTH: 175px" name="txtzip">
			{html_options options=$lang.zipcodes selected=$user.zip}
			</select>
		{ else }
			<input name="txtzip" type="text" size="30" maxlength="100" value="{$user.zip}" />
		{ /if}
		</td>
	</tr>
    <tr>
      	<td>{$lang.profile_address1}</td>
      	<td> <input class="input" maxlength="255" name="txtaddress1" size="40" value="{$user.address_line1|stripslashes}" />
      	</td>
    </tr>
    <tr>
      	<td height="22">{$lang.profile_address2}</td>
      	<td height="22"> <input class="input" maxlength="255" name="txtaddress2" size="40" value="{$user.address_line2|stripslashes}" />
      	</td>
    </tr>
	<tr >
		<td colspan="2">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.upgrade_membership}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
		</td>
	</tr>
    <tr>
      	<td>{$lang.current_mship_level}</td>
      	<td><select class="select" style="WIDTH: 175px" name="txtmship">
			{html_options options=$mships selected=$user.level}
        </select> </td>
    </tr>
	<tr>
	  	<td>&nbsp;</td>
      	<td><input type="submit" class="formbutton" value='{$lang.submit}' /> <input type="reset" class="formbutton" value='{$lang.reset}' /></td>
    </tr>
</tbody>
</table>
</form>
{/strip}