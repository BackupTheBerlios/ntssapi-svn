{strip}
<form name="frmQuickSearch" method="post" action="searchmatch.php">
<table class="table" cellspacing="2" cellpadding="0" border="0">
<tbody>
	<tr>
		<td>{$lang.signup_gender} </td>
		<td>
		
		{if $smarty.session.txtgender}
			{assign var=gender2 value=$smarty.session.txtgender}
		{else}
			{assign var=gender2 value="M"}
		{/if}
		
			<select class="searchselect" name="txtgender" style='width: 100px'>
			{html_options options=$lang.signup_gender_values selected=$smarty.session.txtgender}
        	</select>
		</td>	
	</tr>
	<tr>
		<td>{$lang.seeking} </td>
		<td>
		
		{if $smarty.session.txtlookgender}
			{assign var=gender2 value=$smarty.session.txtlookgender}
		{else}
			{assign var=gender2 value="F"}
		{/if}
		
	        <select class="searchselect" name="txtlookgender" style='width: 100px'>
			{html_options options=$lang.signup_gender_look selected=$gender2}
	        </select> 
		</td>
    </tr>
    <tr> 
		<td>{$lang.who_is_from} </td>
		<td>
			<select class="searchselect" name="txtlookagestart">
	  		{html_options values=$lang.start_agerange output=$lang.start_agerange selected=$smarty.session.lookagestart}
        	</select>
        	{$lang.to} 
        	<select class="searchselect" name="txtlookageend">
		  	{html_options values=$lang.end_agerange output=$lang.end_agerange selected=$smarty.session.lookageend}
        	</select>
       </td>
    </tr>
    <tr>
    	<td colspan="2">{$lang.with_photo}&nbsp;&nbsp;
    		<input type="checkbox" name="with_photo" value="1" {if $smarty.session.with_photo == '1'}checked="checked"{/if} />
    	</td>
    </tr>
    <tr> 
		<td align="right" colspan="2">
      		<input type="submit" value="{$lang.search}" class="formbutton" /></td>
    </tr>
</tbody>
</table>
</form>
{/strip}
