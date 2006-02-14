{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.modify_profile}{$lang.of}{$username}&nbsp;(ID:&nbsp;{$smarty.get.edit})</td>
	</tr>
</table>
<br />
{include file="admin/editprofilelinks.tpl"}
<form name="{$frmname}" method="post" action="modifyprofilequestion.php">
  <input type="hidden" name="sectionid" value="{$sectionid}" />
  <input type="hidden" name="edit" value="{$smarty.get.edit}" />
<table class="table" width="573" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
<tbody>
	<tr>
    <td>{if $mandatory_question_error neq ""}<font color="{$lang.error_msg_color}">{$mandatory_question_error}</font>{/if}</td>
  	</tr>
	<tr>
		<td>
			<table width="573" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$head|stripslashes}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			{*Outer Loop to traverse outer dimension data array*}
	{foreach item=questionrow from=$data}
		{if $questionrow.question != '' }
		{if $questionrow.control_type == "select"}
			<table class="table" width="573" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
			<tbody>
				<tr>
					<td width="250" valign="top">
						<table width="250" border="0">
						<tbody>
							<tr>
								<td width="250">
									<b>{$questionrow.question}</b>
									{if $questionrow.mandatory == 'Y'}
										<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
									{/if}
									<br/>
									{if $questionrow.description != NULL}
										{$questionrow.description|stripslashes}
									{/if}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
					<td width="305" valign="top">
						<table class="table" width="305" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
						<tbody>
							<tr>
								<td  width="305">
									<select name="{$questionrow.id}{$questionrow.mandatory}" class="select" style="WIDTH: 100px">
									<option value="0">{$lang.tell_later}</option>
									{html_options options=$questionrow.options selected=$questionrow.userpref}
									</select>
								</td>
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
			</tbody>
			</table>
		{elseif $questionrow.control_type == "radio"}
			<table class="table" width="573" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
			<tbody>
				<tr>
					<td width="250" valign="top">
						<table class="table" width="250" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" >
						<tbody>
							<tr>
								<td  align="left" valign="top">
									<b>{$questionrow.question}</b>
									{if $questionrow.mandatory == 'Y'}
										<font color={$lang.required_info_indicator_color}>{$lang.required_info_indicator}</font>
									{/if}
									<br/>
									{if $questionrow.description != NULL}
										{$questionrow.description|stripslashes}
									{/if}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
					<td width="305" valign="top">
						<table class="table" width="305" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
						<tbody>
							<tr>
								<td valign="top">
									{foreach name="iterator" key=key item=curropt from=$questionrow.options}
									{if $key == $questionrow.userpref[0]}
										<input name="{$questionrow.id}{$questionrow.mandatory}" type="radio" value="{$key}" checked="checked" />{$curropt|stripslashes}
									{else}
										<input name="{$questionrow.id}{$questionrow.mandatory}" type="radio" value="{$key}" />{$curropt|stripslashes}
									{/if}
									{* if $smarty.foreach.iterator.iteration%2 == 0 }
										</td></tr><tr><td>
									{else}
										</td><td>
									{/if *}
										</td></tr><tr><td>
									{/foreach}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
			</tbody>
			</table>
		{elseif $questionrow.control_type == "checkbox"}
			<table class="table" width="573" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
			<tbody>
				<tr>
					<td valign="top">
						<table class="table" width="250" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
						<tbody>
							<tr>
								<td  align="left" valign="top">
									<b>{$questionrow.question}</b>
									{if $questionrow.mandatory == 'Y'}
										<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
									{/if}
									<br/>
									{if $questionrow.description != NULL}
										{$questionrow.description|stripslashes}
									{/if}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
					<td width="305" valign="top">
						<table class="table" width="305" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
						<tbody>
							<tr>
								<td align="left" valign="top">
									{html_checkboxes options=$questionrow.options selected=$questionrow.userpref separator=<br/> name=$questionrow.id|cat:$questionrow.mandatory }
								</td>
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
			</tbody>
			</table>
		{elseif $questionrow.control_type == "textarea"}
			<table width="573">
			<tbody>
				<tr>
					<td valign="top">
						<table class="table" width="570" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" >
						<tbody>
							<tr>
								<td  align="left" valign="top">
									<b>{$questionrow.question}</b>
									{if $questionrow.mandatory == 'Y'}
										<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
									{/if}
									<br/>
									{if $questionrow.description != NULL}
										{$questionrow.description|stripslashes}
									{/if}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
				<tr>
					<td valign="top">
						<table class="table" width="450" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" >
						<tbody>
							<tr>
								<td valign="top">
									<textarea name="{$questionrow.id}{$questionrow.mandatory}" rows="7" cols="50">{$questionrow.userpref[0]|stripslashes|escape:"htmlall"}</textarea>
								</td>
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
			</tbody>
			</table>
		{/if}
			<table class="table" width="573" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
			<tbody>
				<tr><td>&nbsp;</td></tr>
			</tbody>
			</table>
		{/if}
	{/foreach}
			<table width="573" border="0">
				<tr>
					<td align="center">
						<input type="submit" value="Save" class="formbutton" />&nbsp;
						<input type="reset" value="Reset" class="formbutton" />
					</td>
				</tr>
			</table>
		</td>
	</tr>
</tbody>
</table>
</form>
{/strip}