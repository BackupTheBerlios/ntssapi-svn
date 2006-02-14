{strip}
<form action="modifygroupsection.php" method="post">
<table class=table cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} width=410 border=0>
<tbody>
	<tr> 
		<td colspan="3" class="subtitle">{$lang.modify_sections}</td>
	</tr>
{if $error ne '' }
	<tr><td colspan="3">
			<font color="{$lang.admin_error_color}">{$error}</font>
		</td>
	</tr>
{/if}
	<tr><td colspan="3">&nbsp;</td></tr>
	<tr>
		<td>{$lang.col_head_id}</td>	
		<td>{$lang.col_head_name}</td>	  
		<td>{$lang.col_head_enabled}</td>	  	  	  
	</tr>
{foreach item=item key=key from=$data}
	<input type="hidden" name="txtid[{$item.id}][0]" value="{$item.id}">	
	<tr> 
		<td>{$item.id}</td>	  
		<td><input type="text" value="{$item.section|stripslashes}" maxlength="255" size="50" name="txtid[{$item.id}][1]"></td>	  
		<td><select name="txtid[{$item.id}][2]">
			{html_options options=$lang.enabled_values selected=$item.enabled}
			</select>
		</td>
	</tr>
{/foreach}
	<tr>
		<td>&nbsp;</td>
		<td>
			<input type="submit" class="formbutton" value="{$lang.submit}">
			&nbsp;
			<input type="reset" class="formbutton" value="{$lang.reset}">			
		</td>
		<td>&nbsp;</td>		
	</tr>
</tbody>
</table>
</form>
{/strip}