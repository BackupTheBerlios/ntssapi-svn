{strip}
{*include header template*}
{include file="signuplinks.tpl"}
<font color="{$lang.error_msg_color}">{$mandatory_question_error}</font>
<form name="{$frmname}" method="post" action="savequestion.php">
<input type="hidden" name="sectionid" value="{$sectionid}"/>
<table class="table" width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="{$config.bgcolor}">
<tbody>
    <tr>
    	<td colspan="2" class="title">{$head}</td>
    </tr>
	<tr>
		<td colspan="2" width="100%">
{*Outer Loop to traverse outer dimension data array*}
	{foreach item=questionrow from=$data}
		{if $questionrow.control_type == "select"}
			<table class="table" width="250" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
			<tbody>
				<tr>
					<td width="250">
						<table width="250" border="0">
						<tbody>
							<tr>
								<td width="250">
									{$questionrow.question}
									{if $questionrow.mandatory == 'Y'}
									<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
									{/if}
									<br/>
									{if $questionrow.description != NULL}
											{$questionrow.description}
									{/if}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
					<td width="329">
						<table class="table" width="329" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
						<tbody>
							<tr>
								<td width="329">
									<select name="{$questionrow.id}{$questionrow.mandatory}" class="select" style="width: 125px">
										<option value="0">{$lang.tell_later}</option>
										{html_options options=$questionrow.options}
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
			<table class="table" width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
			<tbody>
				<tr>
					<td width="250">
						<table class="table" width="250" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
						<tbody>
							<tr>
								<td  align="left">
									{$questionrow.question}
									{if $questionrow.mandatory == 'Y'}
										<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
									{/if}
									<br/>
									{if $questionrow.description != NULL}
										{$questionrow.description}
									{/if}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
					<td width="329">
						<table class="table" width="329" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
						<tbody>
							<tr>
								<td>
							{foreach name="iterator" key=key item=curropt from=$questionrow.options}
									<input name="{$questionrow.id}{$questionrow.mandatory}"  type="radio"  value="{$key}"  checked />{$curropt}
								{if $smarty.foreach.iterator.iteration%2 == 0 }
									</td></tr><tr><td>
								{else}
									</td><td>
								{/if}
							{/foreach}
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
			</tbody>
			</table>

		{elseif $questionrow.control_type == "checkbox"}
			<table class="table" width="700" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
			<tbody>
				<tr>
					<td>
						<table class="table" width="250" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
						<tbody>
							<tr>
								<td  align="left">
									{$questionrow.question}
									{if $questionrow.mandatory == 'Y'}
										<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
									{/if}
									<br/>
									{if $questionrow.description != NULL}
										{$questionrow.description}
									{/if}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
					<td>
						<table class="table" width="450" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
						<tbody>
							<tr>
								<td align="left">
									{html_checkboxes name=$questionrow.id|cat:$questionrow.mandatory   options=$questionrow.options separator=<br/>}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
			</tbody>
			</table>
		{elseif $questionrow.control_type == "textarea"}
			<table width="700">
			<tbody>
				<tr>
					<td>
						<table class="table" width="450" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
						<tbody>
							<tr>
								<td  align="left">
									{$questionrow.question}
									{if $questionrow.mandatory == 'Y'}
										<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
									{/if}
									<br/>
									{if $questionrow.description != NULL}
										{$questionrow.description}
									{/if}
								</td>
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table class="table" width="450" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
						<tbody>
							<tr>
								<td>
									<textarea name="{$questionrow.id}{$questionrow.mandatory}" rows="7" cols="100"></textarea>
								</td>
							</tr>
						</tbody>
						</table>
					</td>
				</tr>
			</tbody>
			</table>
		{/if}
			<table class="table" width="100%" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
			<tbody><tr><td>&nbsp;</td></tr></tbody>
			</table>

	{/foreach}
		</td>
	</tr>
</tbody>
</table>
<table width="400">
	<tr>
		<td align="center">
			<input type="submit" class="formbutton" value="Save" />
			<input type="reset" value="Reset" class="formbutton"/>
		</td>
	</tr>
</table>
</form>
{/strip}
