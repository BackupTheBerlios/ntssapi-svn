{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.featured_profiles_hdr}</td>
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
						{ if $req_action eq 'modify' }
							{ $lang.mod_featured }
						{ else }
							{ $lang.add_featured }
						{ /if }
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			<table cellspacing="2" cellpadding="1" width="550" border="0">
				<tr>
					<td colspan="2">{if $lang.errormsgs[$error_msg] ne ""}<font color="{$lang.admin_error_color}">{$lang.errormsgs[$error_msg]}</font>{/if}</td>
				</tr>
				<tr>
					<td colspan="2" width="100%">
              <form name="add_featured" action="featured_profile.php" method="post" onsubmit="javascript: return datefromtovalid( this.elements['startYear'], this.elements['startMonth'], this.elements['startDay'], this.elements['endYear'], this.elements['endMonth'], this.elements['endDay'], '{$lang.errormsgs[51]}' );">
              <input type="hidden" name="userid" value="{$data.userid}" />
              <input type="hidden" name="id" value="{$data.id}" />
              <input type="hidden" name="step" value="{$data.step}" />
              <input type="hidden" name="req_action" value="{$req_action}" />
              <input type="hidden" name="bckurl" value="{$data.bckurl}" />
						<table width="100%">
							<tr>
								<td width="25%">{$lang.profile_username}</td>
								<td width="75%"><input type="text" name="username" value="{$data.username}" onchange="javascript:this.form.elements['step'].value=1; this.form.submit();" />
								{if $data.fullname ne ""}
									&nbsp;({$data.fullname|stripslashes})
								{/if}
								</td>
							</tr>
							<tr>
								<td>{$lang.startdate}</td>
								<td>
									{html_select_date_translated prefix="start"  month_value_format="%m" time=$data.start_date|date_format end_year="+5" }
								</td>
							</tr>
							<tr>
								<td>{$lang.enddate}</td>
								<td>
									{html_select_date_translated prefix="end"  month_value_format="%m" time=$data.end_date|date_format end_year="+5"}
								</td>
							</tr>
							<tr>
								<td>{$lang.must_show}: </td>
								<td>
									<input name="must_show" type="radio" value='1' {if $data.must_show eq '1'}checked="checked"{/if} />Yes&nbsp;&nbsp;
									<input name="must_show" type="radio" value='0' {if $data.must_show ne '1'}checked="checked"{/if} />No
								</td>
							</tr>
							<tr>
								<td>{$lang.reqd_exposures}:</td>
								<td>
									<input type="text" name="req_exposures" value="{ if $data.req_exposures > 0}{$data.req_exposures}{else}999999999{/if}" />
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>
									<input type="submit" class="formbutton" value="{$lang.submit}" />&nbsp;
									<input type="reset" class="formbutton" value="{$lang.reset}" />&nbsp;
									<input type="submit" name="cancelthis"  class="formbutton" value="{$lang.cancel}" />
								</td>
							</tr>
						</table>
              </form>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</center>
{/strip}