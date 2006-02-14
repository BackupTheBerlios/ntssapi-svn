{strip}
<table border=0 width=400 cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} bgcolor={$config.bgcolor}>
	{if $questionrow.control_type == "select"}
		<tr>
			<td align=left>
				<select name={$questionrow.id}{$questionrow.mandatory} class=select style="WIDTH: 100px">
					{html_options options=$questionrow.options selected=$questionrow.userpref}
				</select>
			</td>
		</tr>
	{elseif $questionrow.control_type == "radio"}
		<tr>
			<td>
			{foreach key=key item=curropt from=$questionrow.options}
				{if $key == $questionrow.userpref[0]}
					<input name={$questionrow.id}{$questionrow.mandatory} type=radio value="{$key}" checked>{$curropt} <br />
				{else}
					<input name={$questionrow.id}{$questionrow.mandatory} type=radio value="{$key}">{$curropt} <br />				
				{/if}
			{/foreach}
			</td>
		</tr>
	{elseif $questionrow.control_type == "checkbox"}
		<tr>
			<td>
				{html_checkboxes name=$questionrow.id|cat:$questionrow.mandatory options=$questionrow.options selected=$questionrow.userpref separator=<br/>}				
			</td>	
		</tr>
	{elseif $questionrow.control_type == "textarea"}
		<tr>
			<td>
					<textarea name={$questionrow.id}{$questionrow.mandatory} rows=7 cols=100>{$questionrow.userpref[0]|stripslashes}</textarea>
			</td>
		</tr>
	{/if}
</table>
{/strip}