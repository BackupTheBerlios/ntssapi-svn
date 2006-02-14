{strip}
<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0>
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" /></td>
		<td class="module_head" width="496">
		<table><tr class="table_head"><td><a href="endisquestions.php" class="subhead">{$lang.delete_questions}</a></td></tr></table>
		</td>
	</tr>
</TABLE>
<BR />
<CENTER>
<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td class="module_detail_inside" width="100%">
			<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0>
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.delete_questions}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
				</tr>
			</TABLE>
			<form action="endisquestions.php" method="post">
			<table class=table cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} width=410 border=0>
			<tbody>
				{if $error != ''}
					<tr><td colspan="3">
						<font color="{$lang.admin_error_color}">{$error}</font></td>
					</tr>
					<tr><td colspan="3">&nbsp;</td></tr>
				{/if}
				<tr><td colspan="3">
					<font color="{$lang.admin_error_color}">{$lang.delete_group_questions_confirm_msg}</font></td>
				</tr>	
				<tr class="table_head">
				  	<th>{$lang.col_head_id}</th>	
				  	<th>{$lang.col_head_name}</th>	  
				  	<th>{$lang.col_head_enabled}</th>	  	  	  
				</tr>
			{foreach item=item key=key from=$data}
    			<tr> 
					<td>{$item.id}				
						<input type="hidden" name="txtid[{$item.id}]" value="{$item.id}" />	
					</td>	  
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
		</TD>
	</TR>
</TABLE>
</CENTER>
{/strip}