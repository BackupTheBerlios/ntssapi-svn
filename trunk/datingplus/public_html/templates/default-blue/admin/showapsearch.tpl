{strip}
<table class=table cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} width=1000 border=0>
<tbody>
	<tr> 
      	<td colspan="8" class="subtitle">{$lang.search_advance_results}
 	  	</td>
    </tr>
	<tr><td colspan="8">&nbsp;</td></tr>
	<tr><td colspan="8">{$lang.total_profiles} {$data|@count}</td></tr>		
	<tr><td colspan="8">&nbsp;</td></tr>	
    <tr> 
	  	<td>{$lang.col_head_srno}</td>	  	  
	  	<td>{$lang.col_head_username}</td>	  
	  	<td>{$lang.col_head_firstname}</td>
	  	<td>{$lang.col_head_register_at}</td>
	  	<td>{$lang.col_head_gender}</td>
	  	<td>{$lang.col_head_email}</td>	  	  	  
	  	<td colspan="2" >{$lang.action}</td>
	</tr>
	{if $error == 1 }
	<tr>
		<td colspan="8">{$lang.no_record_found}</td>
	</tr>
	{else}
	{assign var="mcount" value="0"}				
		{foreach item=item key=key from=$data}
			{math equation="$mcount+1" assign="mcount"}		
		<tr> 
		  	<td>{$mcount}</td>		  
		  	<td>{$item.username}</td>
		  	<td>{$item.firstname|stripslashes}</td>
		  	<td>{$item.birth_date|date_format:$lang.DATE_FORMAT}</td>		  
		  	<td>{$item.gender}</td>		  		  
		  	<td>{$item.email}</td>		  		  		  
		  	<td><a href="?edit={$item.id}"><img src="images/button_edit.png" border="0"></a></td>
		  	<td><a href="?delete={$item.id}"><img src="images/button_drop.png" border="0"></a></td>	  	  	  	  
		</tr>
		{/foreach}
	{/if}
	</form>
</tbody>
</table>

<a href="search.php">{$lang.back}</a>
{/strip}