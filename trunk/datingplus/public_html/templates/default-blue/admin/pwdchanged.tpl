{strip}
<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" /></td>
		<td class="module_head" width="496">
		{$lang.change_password}
		</td>
	</tr>
</TABLE>
<BR />
<CENTER>
<table cellspacing=2 cellpadding=1 width=400 border=0>
	<input type="hidden" name="txtid" value="{$smarty.session.AdminId}" />
<tbody>
    <tr> 
      	<td>{$lang.password_changed_successfully}<br /><br />
			{$lang.logout_login}</td>      	
    </tr>
</tbody>
</table>
</center>
{/strip}