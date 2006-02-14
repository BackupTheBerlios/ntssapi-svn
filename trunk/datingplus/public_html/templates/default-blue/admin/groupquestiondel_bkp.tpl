{strip}
<form name="frmGroupDelete" action="endisquestions.php" method="post">
<input type="hidden" name="frm" value="frmGroupDelete" />
<table class=table cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} width="100%" border=0>
<tbody>
	<tr> 
		<td colspan="3" class="subtitle">{$lang.delete_questions}</td>
	</tr>
{if $error ne ''}
	<tr>
		<td colspan="3">
			<font color="{$lang.admin_error_color}">{$error}</font>
		</td>
	</tr>
{/if}
	<tr><td colspan="3">&nbsp;</td></tr>
	<tr>
		<td colspan="3"><font color="{$lang.admin_error_color}">{$lang.delete_group_questions_confirm_msg}{$lang.question_mark}</font></td>
	</tr>	
	<tr class="table_head">
		<th>{$lang.col_head_id}</th>	
		<th>{$lang.col_head_name}</th>	  
		<th>{$lang.col_head_enabled}</th>	  	  	  
	</tr>
{foreach item=item key=key from=$data}
	<tr> 
		<td><input type="hidden" name="txtid[{$item.id}]" value="{$item.id}" />	
			{$item.id}</td>	  
		<td>{$item.question|stripslashes}</td>	  
		<td>{$item.enabled}</td>
	</tr>
{/foreach}
	<tr>
		<td>&nbsp;</td>
		<td>
			<input type="submit" class="formbutton" value="{$lang.delete}" />
			&nbsp;
			<input type="reset" class="formbutton" value="{$lang.cancel}" />			
		</td>
		<td>&nbsp;</td>		
	</tr>
</tbody>
</table>
</form>
{/strip}