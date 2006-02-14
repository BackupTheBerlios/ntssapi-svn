{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe(form)
{ldelim}
	if (form.txtsection.value == '' ){ldelim}
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
		<table><tr class="table_head"><td><a href="section.php" class="subhead">{$lang.section_title}</a></td></tr></table>
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
					{$lang.modify_section}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      {if $error ne ""}
			<font color="{$lang.admin_error_color}">{$error}</font>
      {/if}
      <form action="modifysection.php" method="post" onsubmit="javascript: return checkMe(this);">
        <input type="hidden" name="txtid" value="{$data.id}" />
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
	  		<tbody>
    			<tr>
	  				<td>{$lang.id}</td>
	  				<td>{$data.id}</td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.name}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
	  				<td><input type="text" value="{$data.section|stripslashes}" maxlength="255" size="50" name="txtsection" /></td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.enabled}</td>
	  				<td><select name="txtenabled">
	  					{html_options options=$lang.enabled_values selected=$data.enabled}
	  	 				</select>
	  				</td>
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