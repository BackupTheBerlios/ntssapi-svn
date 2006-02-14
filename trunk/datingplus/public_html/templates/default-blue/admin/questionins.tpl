{strip}
<script type="text/javascript">
/* <![CDATA[ */
function validate(form)
{ldelim}
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13);

	CheckFieldString("noblank",form.txtquestion,"{$lang.signup_js_errors.question_noblank}");
	CheckFieldString("noblank",form.txtmaxlength,"{$lang.signup_js_errors.maxlength_noblank}");

	CheckFieldString("full",form.txtquestion,"{$lang.signup_js_errors.question_charset}1");
	CheckFieldString("full",form.txtdescription,"{$lang.signup_js_errors.description_charset}2");
	CheckFieldString("full",form.txtguideline,"{$lang.signup_js_errors.guideline_charset}3");
	CheckFieldString("integer",form.txtmaxlength,"{$lang.signup_js_errors.maxlength_charset}4");
	CheckFieldString("full",form.txextsearchhead,"{$lang.signup_js_errors.extsearchhead_charset}5");

	if (form.txtextsearch.value == 'Y' && form.txextsearchhead.value == '')
	{ldelim}
		ErrorCount ++;
		ErrorMsg[1] = "{$lang.admin_js__delete_error_msgs[16]}";
	{rdelim}
	result="";
	if( ErrorCount > 0)
	{ldelim}
		alert(ErrorMsg[1]);
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
					{$lang.section}&nbsp;{$sectionname|stripslashes}&nbsp;&nbsp;>>&nbsp;&nbsp;
					{$lang.insert_question}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form action="insquestion.php" method="post"  onsubmit="javascript:return validate(this);">
        <input type="hidden" name="txtid" value="{$data.id}" />
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
	 			<tr>
		  			<td>{$lang.question}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
		  			<td><input type="text" maxlength="255" size="50" name="txtquestion" /></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.description}</td>
		  			<td><input type="text" maxlength="255" size="50" name="txtdescription" /></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.guideline}</td>
		  			<td><input type="text"  maxlength="255" size="50" name="txtguideline" /></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.control_type}</td>
		  			<td>
		  				<select name="txtcontroltype">
						{html_options options=$lang.display_control_type }
						</select>
					</td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.maxlength}</td>
		  			<td><input type="text" value="0" maxlength="3" size="4" name="txtmaxlength" /></td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.mandatory}</td>
		  			<td>
		  				<select name="txtmandatory">
		  				{html_options options=$lang.enabled_values }
		  	 			</select>
		  	 		</td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.section}</td>
		  			<td>
		  				<select name="txtsection">
						{html_options options=$allsections selected=$smarty.get.sectionid}
						</select>
		  			</td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.include_extsearch}</td>
		  			<td>
			  			<select name="txtextsearch">
		  				{html_options options=$lang.enabled_values }
	  		 			</select>
					</td>
	 			</tr>
	 			<tr>
		  			<td>{$lang.head_extsearch}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
		  			<td><input type="text" maxlength="255" size="50" name="txextsearchhead" /></td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.enabled}</td>
	  				<td><select name="txtenabled">
	  					{html_options options=$lang.enabled_values }
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