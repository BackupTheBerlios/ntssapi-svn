{strip}
<script type="text/javascript">
/* <![CDATA[ */

function validate(form,val){ldelim}

	form=document.getElementById(form);

	form.txtconfigvariable.value = val;
	form.txtconfigvalue.value = document.getElementById('txtconfigval').value;
	form.submit();
{rdelim}
/* ]]> */
</script>
<script type="text/javascript" src="../javascript/picker.js"></script>

<form name="frmEditConfig" id="frmEditConfig" method="post" action="editgblsettings.php">
  <input type="hidden" name="frm" value="frmEditConfig" />
  <input type="hidden" name="txtconfigvariable" value="" />
  <input type="hidden" name="txtconfigvalue" value="" />
</form>

<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg?{$smarty.now}" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.globalconfigurations}</td>
	</tr>
</table>
<br />
<center>
<table width="553" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td  width="100%" class="module_detail_inside">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="524">
						{$lang.globalconfigurations}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg?{$smarty.now}" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			<form name="frm001" action="">
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0">
				<tr align="center" class="table_head">
					<th width="60%">{$lang.descrip}</th>
					<th width="35%">{$lang.col_head_value}</th>
					<th width="5%">{$lang.edit}</th>
				</tr>
			{foreach item=item from=$confdata}
				<tr class="{cycle values="oddrow,evenrow"}">
					<td>{$item.description}<a name="{$item.config_variable}"></a></td>
					{if $smarty.get.edit != $item.config_variable}
					<td>{if $item.config_variable == 'default_user_level'}
							{$memberships[$item.config_value]}
						{else}
							{$item.config_value}
						{/if}
					</td>
					{elseif $smarty.get.edit eq 'phpbb_installed' or $smarty.get.edit eq 'cntry_mgt' or $smarty.get.edit eq 'snaps_require_approval' or $smarty.get.edit eq 'images_in_db' or $smarty.get.edit eq'default_active_status' or $smarty.get.edit eq 'state_mandatory' or $smarty.get.edit eq 'county_mandatory'or $smarty.get.edit eq 'city_mandatory'or $smarty.get.edit eq 'zipcode_mandatory' or $smarty.get.edit eq 'feedback_info' or $smarty.get.edit eq 'use_profilepopups'}
					<td>
						<select name="txtconfigval" id="txtconfigval">
							{html_options options=$lang.enabled_values selected=$item.config_value}
						</select>
					</td>
					{elseif $smarty.get.edit == 'default_country'}
					<td>
						<select name="txtconfigval" id="txtconfigval">
							{html_options options=$lang.countries selected=$item.config_value}
						</select>
					</td>
					{elseif $smarty.get.edit == 'skin_name'}
					<td>
						<select name="txtconfigval" id="txtconfigval">
							{html_options options=$template_dirs selected=$item.config_value}
						</select>
					</td>
					{elseif $smarty.get.edit == 'default_user_level' }
					<td>
						<select name="txtconfigval" id="txtconfigval">
							{html_options options=$memberships selected=$item.config_value}
						</select>
					</td>
					{else}
						{if $smarty.get.value == '' }
					<td>
						<input type="text" name="txtconfigval"  id="txtconfigval" value="{$item.config_value}" size="25" />
					</td>
						{else}
					<td>
						<input type="text" name="txtconfigval"  id="txtconfigval" value="#{$smarty.get.value}" size="25" />
					</td>
						{/if}	
					{/if}
			
					{if $smarty.get.edit != $item.config_variable}
					<td>
						{* Mozilla doesnot implement showModalDialog *}
						
						<a href="?edit={$item.config_variable}#{$item.config_variable}">
						<img src="images/button_edit.png" border="0" alt="" />
						</a>
					</td>
					{else}
					<td nowrap>
						{if $smarty.get.edit == 'watermark_text_color' or $smarty.get.edit == 'bgcolor' or $smarty.get.edit == 'textcolor' }
							<a href="javascript:TCP.popup(document.forms['frm001'].elements['txtconfigval'])"><img width="15" height="13" border="0" alt="Click Here to Pick up the color" src="images/sel.gif" /></a>
						{/if}
						<a href="javascript:validate('frmEditConfig','{$item.config_variable}');">
						<img src="images/button_save.jpg" border="0" alt="" /></a>&nbsp;
						<a href="editgblsettings.php#{$item.config_variable}">
						<img src="images/button_cancel1.jpg" border="0" alt="Cancel" /></a>
					</td>
					{/if}
				</tr>
			{/foreach}
			</table>
			</form>
		</td>
	</tr>
</table>
</center>
<br />
{/strip}