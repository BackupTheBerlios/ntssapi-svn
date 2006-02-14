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
		<table><tr class="table_head"><td><a href="calendar.php" class="subhead">{$lang.calendar_title}</a></td></tr></table>
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
					{$lang.modify_event}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" alt="" /></td>
				</tr>
			</table>
      <form action="modifyevent.php" method="post"  onsubmit="javascript:return validate(this);">
        <input type="hidden" name="txtid" value="{$data.id}" />
        <input type="hidden" name="txtuserid" value="{$data.userid}" />
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
				  	{html_select_date_translated prefix="txtdatefrom"  end_year="+5" time=$data.datetime_from} {html_select_time prefix="txtdatefrom" display_seconds=false minute_interval=30 time=$data.datetime_from}
					</td>
				</tr>
				<tr><td>{$lang.date_to}</td><td>
				  	{html_select_date_translated prefix="txtdateto"  end_year="+5" time=$data.datetime_to} {html_select_time prefix="txtdateto" display_seconds=false minute_interval=30 time=$data.datetime_to}
					</td>
				</tr>
	 			<tr>
		  			<td>{$lang.event}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
		  			<td><input type="text" name="txtevent" value="{$data.event}" size="50" maxlength="255" /></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.description}</td>
		  			<td><textarea cols="60" rows="5" name="txtdescription">{$data.description}</textarea></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.calendar}</td>
		  			<td>
		  				<select name="txtcalendar">
						{html_options options=$allcalendars selected=$data.calendarid}
						</select>
		  			</td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.enabled}</td>
	  				<td><select name="txtenabled">
	  					{html_options options=$lang.enabled_values selected=$data.enabled}
	  	 				</select>
	  				</td>
				</tr>
			    <tr>
			      	<td>{$lang.timezone}</td>
			      	<td><select class="select" style="width: 175px" name="txttimezone">
						{html_options options=$lang.tz selected=$data.timezone}
			        	</select>
			        </td>
			    </tr>
	 			<tr>
		  			<td>{$lang.recurring}</td>
		  			<td valign="middle">{$lang.recur_every}&nbsp;<input type="text" name="txtrecuroption" value="{$data.recuroption}" size="5" maxlength="5" /> {html_radios name="txtrecurring" options=$lang.recuring_labels checked=$data.recurring separator="&nbsp;"}</td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.private_to}</td>
		  			<td><input type="text" name="txtprivate_to" value="{$data.private_to}" size="50" maxlength="255" /></td>
	 			</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<input type="submit" class="formbutton" value="{$lang.submit}" />&nbsp;
						<input type="reset" class="formbutton" value="{$lang.reset}" />
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