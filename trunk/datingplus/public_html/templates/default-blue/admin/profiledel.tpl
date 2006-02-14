{strip}
<form action="delprofile.php" method="post">
	<input type="hidden" name="txtid" value="{$data.id}">
<table class=table cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} width="100%" border=0>
<tbody>
	<tr> 
      	<td colspan="9" class="subtitle">{$lang.delete_profile}</td>
    </tr>
	<tr><td colspan="9">&nbsp;</td></tr>
	<tr><td colspan="9"><font color="{$lang.admin_error_color}">{$lang.profile_delete_confirm_msg}{$lang.question_mark}</font></td></tr>
	<tr>
	  	<td>{$lang.col_head_id}</td>	  	  
	  	<td>{$lang.col_head_username}</td>	  
	  	<td>{$lang.col_head_firstname}</td>
	  	<td>{$lang.col_head_lastname}</td>
	  	<td>{$lang.col_head_gender}</td>
	  	<td>{$lang.col_head_email}</td>	  	  	  
	  	<td>{$lang.col_head_country}</td>	  	  
	  	<td>{$lang.col_head_city}</td>	  	  
	  	<td>{$lang.col_head_zip}</td>	  	  	  	  
	</tr>
    <tr> 
		<td>{$data.id}</td>		  
		<td>{$data.username}</td>
		<td>{$data.firstname|stripslashes}</td>
		<td>{$data.lastname|stripslashes}</td>		  
		<td>{$data.gender}</td>		  		  
		<td>{$data.email}</td>		  		  		  
		<td>{$data.country}</td>		  		  		  		  
		<td>{$data.city|stripslashes}</td>		  		  		  		  		  
		<td>{$data.zip|stripslashes}</td>		  		  		  		  		  		  
	</tr>
	<tr><td colspan="9">&nbsp;</td></tr>	
	<tr>
		<td colspan="9">
			<input type="submit" class="formbutton" name="delaction" value="{$lang.yes}">
		</td>
		<td colspan="9">&nbsp;</td>		
	</tr>
</tbody>
</table>
</form>
{/strip}