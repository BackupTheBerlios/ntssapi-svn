{strip}
<script type="text/javascript">
/* <![CDATA[ */
  _editor_url = '../javascript/htmlarea/';
  _editor_lang = 'en';
  var use_popups = true;
/* ]]> */
</script>
{literal}
<script type="text/javascript" src="../javascript/htmlarea/htmlarea.js"></script>
<script type="text/javascript" src="../javascript/htmlarea/dialog.js"></script>
<script type="text/javascript" src="../javascript/htmlarea/lang/en.js"></script>
{/literal}
<script type="text/javascript">
/* <![CDATA[ */
function ltrvalidate( form )
{ldelim}
	errcnt=0;
	EMsg = '';

	if (form.txtsubject.value == '') {ldelim}
		errcnt++;
		EMsg += "{$lang.signup_js_errors.subject_noblank}\n";
	{rdelim}	
	if (form.txtsendname.value == '') {ldelim}
		errcnt++;
		EMsg += "{$lang.signup_js_errors.sendname_noblank}\n";
	{rdelim}	
	if (form.txtmessage.value == '') {ldelim}
		errcnt++;
		EMsg += "{$lang.signup_js_errors.comments_noblank}\n";
	{rdelim}		
	if( form.txtsave.checked == true && form.txtname.value == ''){ldelim}
		errcnt++;
		EMsg += "{$lang.signup_js_errors.lettertitle_noblank}\n";
	{rdelim}	
	/* concat all error messages into one string */
	if( errcnt > 0)	{ldelim}
		alert(EMsg);
		return false;
	{rdelim}
	form.submit();
{rdelim}
{literal}
function delLetter(letter){
	document.frmDelete.letterid.value = letter;
	document.frmDelete.submit();
}
{/literal}
/* ]]> */
</script>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" >{$lang.send_letter}</td>
	</tr>
</table>
<table width="573" cellspacing="5" cellpadding="0" border="0" align="center">
<tbody>
{if $smarty.get.err != '' }
	<tr>
      	<td colspan="2" align="center" ><font color="#FF0000">{$lang.errormsgs[$smarty.get.err]}</font></td>
    </tr>
    <tr><td >&nbsp;</td></tr>
{/if}
    <tr>
      	<td colspan="2" align="center" width="573">
	  	{include file="admin/imagebrowser.tpl"}
	  	</td>
    </tr>
    <tr>
      	<td colspan="2" align="center" width="573" height="10"></td>
    </tr>
	<tr>
		<td colspan="2"  valign="top"  class="module_detail_inside">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" >{$lang.letter_options}</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form name="frmsend" method="post" action=""  enctype="multipart/form-data">
        <input type="hidden" name="frm" value="frmSend" />
			<table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
				<tr>
					<td colspan="2">
						<table cellspacing="2" cellpadding="2" border="0" align="center">
							<tr>
								<td width="89">{$lang.select_letter}</td>
								<td width="484">
									<select name="txttitle" onchange="document.location='sendletter.php?txttitle=' + this.options[this.selectedIndex].value">
									<option value="0">{$lang.letter_title}</option>
									{foreach item=item from=$letters}
										<option value="{$item.id}" {if $smarty.get.txttitle == $item.id} selected="selected" {/if}>{$item.title}</option>
									{/foreach}
									</select>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<table cellspacing="2" cellpadding="1" border="0" align="center">
							<tr>
								<td width="89">{$lang.from_name}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
								<td width="484"><input type="text" name="txtsendname" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<table cellspacing="2" cellpadding="1" border="0">
							<tr>
								<td width="89">
									{$lang.from_email} 
								</td>
								<td width="484">
									<select name="txtfrom">
									{html_options options=$adminemails}
									</select>
									<input type="button"  class="formbutton" name="button" value=" ... " onclick="popUpScrollWindow ('adminemail.php','center',300,200)" />
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<table cellspacing="2" cellpadding="1" border="0">
							<tr>
								<td rowspan="8" width="89" valign="top">To:</td>
								<td width="484" ><input type="radio" name="userrange" value="all" checked="checked" />{$lang.all}
								</td>
							</tr>
							<tr>
								<td>
									<table cellspacing="0" cellpadding="0">
										<tr>
											<td valign="top"><input type="radio" name="userrange" value="level" />{$lang.membership_hdr}&nbsp;</td>
											<td><select name="txtlevel">
												{html_options options=$memberships}
												</select>
											</td>
										</tr>
									</table>
				 				</td>
							</tr>
							<tr>
								<td width="484" >
									<input type="radio" name="userrange" value="selected" />{$lang.selected_users}&nbsp;({$lang.separate_users_by_coma})
								</td>
							</tr>
							<tr>
								<td>
									<table cellspacing="0" cellpadding="0">
										<tr>
											<td valign="top"></td>
											<td><textarea name="txtselected" cols="60" rows="6" id="txtselected"></textarea></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="0" >&nbsp;</td>
							</tr>
							<tr>
								<td colspan="0" >
									<table cellspacing="0" cellpadding="0">
										<tr>
											<td ><input type="checkbox" name="txtfilteruser[]" value="age" /></td>
											<td >{$lang.age}&nbsp;</td>
											<td>
												{$lang.from}&nbsp;
												<select class="select" style="width: 50px" name="txtagestart">
												{html_options values=$lang.start_agerange output=$lang.start_agerange selected='18' }
												</select>
												{$lang.to} 
												<select class="select" style="width: 50px" name="txtageend" >
												{html_options values=$lang.end_agerange output=$lang.end_agerange selected='99'}
												</select>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="0" >
									<table cellspacing="0" cellpadding="0">
										<tr>
											<td ><input type="checkbox" name="txtfilteruser[]" value="gender" /></td>
											<td>{$lang.sex_without_colon}</td>
											<td>{foreach item=item key=key from=$lang.signup_gender_look}
												<input type="radio" name="txtgender" value="{$key}" checked="checked" />{$item}
											{/foreach}
											</td>
										</tr>
									</table>
	  							</td>
							</tr>
							<tr>
								<td colspan="0" >
									<table id="tbl" cellspacing="0" cellpadding="0" border="0">
										<tr>
											<td valign="bottom"><input type="checkbox" name="txtfilteruser[]" value="location" />{$lang.select_country}&nbsp;</td>
											<td>
											<select class="select" style="width: 175px" name="txtcountry" >
											{html_options options=$lang.countries selected=$config.default_country}
											</select>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<br />
						<table width="573" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="545">{$lang.compose}</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr><td colspan="2">&nbsp;</td></tr>
				<tr>
					<td width="89">&nbsp;{$lang.attached_files}</td>
					<td width="484">
						<input type="text" id="files_to_attach" name="files_to_attach" value="" size="54" />
					</td>
				</tr>
				<tr><td colspan="2">&nbsp;</td></tr>
				<tr>
					<td width="89">
						&nbsp;{$lang.email_subject}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
					</td>
					<td width="484">
						<input type="text" name="txtsubject" value="{$message.subject}" size="54" />
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<table border="0" cellspacing="0" cellpadding="5">
							<tr>
								<td><br/>Constants:<br/>
							#Link#, #SiteTitle#, #SiteName#, #NickName#, #RealName#, #Sex#, #Email#, #UserId#, 
							#UserPicture#, #UserAge#, #UserDOB#
								</td>
							</tr>
							<tr>
								<td>
									<textarea name="txtmessage" id="txtmessage" style="width:550px;height:300px;">{$message.bodytext|escape:htmlall}</textarea>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<input type="checkbox" name="txtsave" value="yes"
						onclick="this.form.txtname.disabled = !this.checked" /> {$lang.save_as}&nbsp;
						<input type="text" name="txtname" disabled size="60" />
					</td>
				</tr>
				<tr><td></td></tr>
				<tr>
					<td colspan="2" align="center">
						<input type="button" class="formbutton" name="txtsubmit" value="{$lang.send_to}" onclick="javascript: ltrvalidate(document.frmsend);" />
						{if $smarty.get.txttitle != 0}				
						<input type="button" class="formbutton" name="txtdelete" value="{$lang.delete}"
						onclick="if(confirm('{$lang.admin_js_error_msgs[2]}')) delLetter({$smarty.get.txttitle})" />
						{/if}
						<br /><br />
					</td>
				</tr>
			</table>
      </form>
		</td>
	</tr>
</tbody>
</table>
<form name="frmDelete" method="post" action="">
	<input type="hidden" name="frm" value="frmDelete" />
	<input type="hidden" name="letterid" />
</form>

{/strip}