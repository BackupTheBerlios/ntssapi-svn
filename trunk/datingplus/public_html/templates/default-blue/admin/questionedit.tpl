{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe(form)
{ldelim}
	if ( form.txtquestion.value == '' ){ldelim}
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
		<table><tr ><td class="module_head"><a href="section.php" class="subhead" >{$lang.section_title}</a>&nbsp;>&nbsp;<a href="sectionquestions.php?sectionid={$data.section}" class="subhead">{$lang.questions_title}</a></td></tr></table>
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
					{$lang.modify_question}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form action="modifyquestion.php" method="post" onsubmit="javascript: return checkMe(this);">
        <input type="hidden" name="txtid" value="{$data.id}" />
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
		  	<tbody>
  				<tr><td colspan="2">{if $error ne ""}<font color="{$lang.admin_error_color}">{$error}</font>{/if}</td></tr>
    			<tr>
		  			<td>{$lang.id}</td>
		  			<td>{$data.id}</td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.question}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
		  			<td><input type="text" value="{$data.question|stripslashes}" maxlength="255" size="50" name="txtquestion" /></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.description}</td>
		  			<td><input type="text" value="{$data.description|stripslashes}" maxlength="255" size="50" name="txtdescription" /></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.guideline}</td>
		  			<td><input type="text" value="{$data.guideline|stripslashes}" maxlength="255" size="50" name="txtguideline" /></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.control_type}</td>
		  			<td>
		  				<select name="txtcontroltype">
							{html_options options=$lang.display_control_type selected=$data.control_type}
						</select>
					</td>
	 			</tr>
	 			{*if $data.control_type == "textarea" *}
	 			<tr>
		  			<td>{$lang.maxlength}</td>
		  			<td><input type="text" value="{$data.maxlength}" maxlength="3" size="4" name="txtmaxlength" /></td>
	 			</tr>
	 			{*/if*}
	 			<tr>
		  			<td>{$lang.mandatory}</td>
		  			<td>
		  				<select name="txtmandatory">
		  				{html_options options=$lang.enabled_values selected=$data.mandatory}
		  				</select>
		  			</td>
	 			</tr>
				<tr>
		  			<td>{$lang.section}</td>
		  			<td>
		  				<select name="txtsection">
						{html_options options=$allsections selected=$data.section}
						</select>
		  			</td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.include_extsearch}</td>
		  			<td>
			  			<select name="txtextsearch">
		  					{html_options options=$lang.enabled_values selected=$data.extsearchable}
	  		 			</select>
					</td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.head_extsearch}</td>
		  			<td><input type="text" value="{$data.extsearchhead|stripslashes}" maxlength="255" size="50" name="txextsearchhead" /></td>
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