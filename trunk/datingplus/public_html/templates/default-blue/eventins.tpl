{strip}
<script type="text/javascript">
/* <![CDATA[ */
function validate(form)
{ldelim}
	if ( form.txtevent.value == '' ){ldelim}
		alert("{$lang.errormsgs[20]}");
		return false;
	{rdelim}
	return true;
{rdelim}
/* ]]> */
</script>
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">
		<table><tr class="table_head"><td><font color="#FFFFFF"><b>{$lang.calendar_title}</b></font></td></tr></table>
		</td>
	</tr>
</table>
<br />
<center>
<table width="550" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.calendar_title}&nbsp;{$calendarname|stripslashes}&nbsp;&nbsp;>>&nbsp;&nbsp;
					{$lang.insert_event}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form action="insevent.php" method="post" name="eventform" id="eventform" onsubmit="javascript:return validate(this);">
        <input type="hidden" name="txtuserid" value="{$smarty.session.UserId}"/>
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
		  	<tbody>
			{ if $error != ''}
    			<tr>
					<td colspan="2">
						<font color="{$lang.admin_error_color}">{$error}</font>
					</td>
    			</tr>
				<tr><td colspan="5">&nbsp;</td></tr>
			{/if}
				<tr><td>{$lang.date_from}</td><td>
				  	{html_select_date_translated prefix="txtdatefrom"  end_year="+5"} {html_select_time prefix="txtdatefrom" display_seconds=false minute_interval=30}
					</td>
				</tr>
				<tr><td>{$lang.date_to}</td><td>
				  	{html_select_date_translated prefix="txtdateto"  end_year="+5"} {html_select_time prefix="txtdateto" display_seconds=false minute_interval=30}
					</td>
				</tr>
	 			<tr>
		  			<td>{$lang.event}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
		  			<td><input type="text" maxlength="255" size="50" name="txtevent"/></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.description}</td>
		  			<td><textarea cols="60" rows="5" name="txtdescription"></textarea></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.calendar}</td>
		  			<td>
		  				<select name="txtcalendar">
						{html_options options=$allcalendars selected=$smarty.get.calendarid}
						</select>
		  			</td>
	 			</tr>
			    <tr>
			      	<td>{$lang.timezone}</td>
              <td><select class="select" style="width: 175px;" name="txttimezone" >
						{html_options options=$lang.tz selected=$user.timezone}
			        	</select>
			        </td>
			    </tr>
	 			<tr>
		  			<td>{$lang.recurring}</td>
		  			<td valign="middle">{$lang.recur_every}&nbsp;<input type="text" name="txtrecuroption" size="5" maxlength="5"/> {html_radios name="txtrecurring" options=$lang.recuring_labels separator="&nbsp;" selected=0}</td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.private_to}</td>
		  			<td><input type="text" maxlength="255" size="50" name="txtprivate_to"/>
						<input type="button" class="formbutton" value="{$lang.search}" onclick="javascript:popUpScrollWindow('extsearch_popup.php','center',640,600)"/>
					</td>
	 			</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<input type="submit" class="formbutton" value="{$lang.submit}"/>&nbsp;
						<input type="reset" class="formbutton" value="{$lang.reset}"/>
					</td>
				</tr>
  			</tbody>
			</table>
      </form>
		</td>
	</tr>
</table>
</center>
{/strip}