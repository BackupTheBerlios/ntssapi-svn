{strip}
<script language="JavaScript" type="text/javascript">
/* <![CDATA[ */
function checkMe(frm)
{ldelim}
	if (frm.txtoption.value == ''){ldelim}
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
			<table>
				<tr class="table_head">
					<td class="module_head"><a href="polloptions.php?pollid={$data.pollid}" class="subhead"></a>&nbsp;<a href="managepoll.php" class="subhead">{$lang.manage_polls}</a>&nbsp;>&nbsp;<a href="polloptions.php?pollid={$data.pollid}" class="subhead">{$lang.poll_options}</a>
					</td>
				</tr>
			</table>
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
					{$lang.modify_option}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form name="frmOptionEdit" method="post"  action="modifypolloption.php" onsubmit="javascript: return checkMe(this);">
        <input type="hidden" name="txtpollid" value="{$data.pollid}" />
        <input type="hidden" name="txtoptionid" value="{$data.optionid}" />
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" >
				<tr>
					<td colspan="2">{if $error ne ""}<font color="{$lang.admin_error_color}">{$error}</font>{/if}</td>
				</tr>
				<tr>
					<td>{$lang.option}:<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
					<td><input name="txtoption" type="text" value="{$data.opt|stripslashes}" /></td>
				</tr>
				<tr>
					<td>{$lang.votes}:</td>
					<td><input name="txtanswer" type="text" value="{$data.result|stripslashes}" /></td>
				</tr>
				<tr>
					<td>{$lang.enabled}</td>
					<td><select name="txtenabled" >
						<option value='Y' {if $data.enabled == 'y'} selected="selected" {/if}>{$lang.yes} </option>
						<option value='N' {if $data.enabled != 'Y'} selected="selected" {/if}>{$lang.no}</option>
						</select>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center"><input name="txtsave" type="submit" class="formbutton" value="{$lang.submit}" />&nbsp;
					<input name="txtreset" type="reset" class="formbutton" value="{$lang.reset}" />
					</td>
				</tr>
			</table>
      </form>
		</td>
	</tr>
</table>
</center>
{/strip}