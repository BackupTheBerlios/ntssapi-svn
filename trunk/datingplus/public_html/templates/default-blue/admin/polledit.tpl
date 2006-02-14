{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe()
{ldelim}
	if (document.frmPoll.txtquestion.value == ''){ldelim}
		alert("{$lang.errormsgs[20]}");
		return false;
	{rdelim}
	document.frmPoll.submit();
{rdelim}
/* ]]> */
</script>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">
		<table><tr class="table_head"><td><a href="managepoll.php" class="subhead">{$lang.manage_polls}</a></td></tr></table>
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
					{$lang.modify_poll}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      {if $error ne ""}
			<font color="{$lang.admin_error_color}">{$error}</font>
      {/if}
      <form action="modifypoll.php" method="post" name="frmPoll">
        <input type="hidden" name="txtid" value="{$data.pollid}" />
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
		  	<tbody>
    			<tr>
	  				<td>{$lang.id}</td>
	  				<td>{$data.pollid}</td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.poll}:<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
	  				<td><input type="text" value="{$data.question|stripslashes}" maxlength="255" size="50" name="txtquestion" /></td>
	 			</tr>
				<tr>
					<td>{$lang.dat}</td>
					<td>{html_select_date_translated prefix="txtdate"  month_value_format="%m" time=$data.date|date_format end_year="+5" } </td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<input type="button" class="formbutton" value="{$lang.submit}" onclick="javascript: checkMe();" />&nbsp;
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
