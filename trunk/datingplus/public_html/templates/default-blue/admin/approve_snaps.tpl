{strip}
<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" /></td>
		<td class="module_head" width="496">{$lang.snaps_require_approval}</td>
	</tr>
</TABLE>
<BR />
<CENTER>
<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td class="module_detail_inside" width="100%">
			<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
						{$lang.total_profiles_found}&nbsp;{$user_pics|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
				</tr>
			</TABLE>
			<table class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width=550 border=0>
 			<tbody>
			{if $errid ne ''} 
				<tr><td colspan="5"><span class="errors">{$lang.errormsgs[$errid]}</span></td></tr>	
			{/if}	
				<tr class="table_head"> 
				  <th width=3%>{$lang.col_head_srno}</th>
				  <th width=40%>{$lang.userdetails}</th>
				  <th width=25%>{$lang.pict}</th>
				  <th width=25%>{$lang.tnail}</th>
				  <th width=7%>{$lang.action}</th>
				</tr>
				{if $user_pics|@count <= 0 }
				<tr>
					<td colspan="5">&nbsp;{$lang.no_record_found}</td>
				</tr>
				{else}
				{assign var="mcount" value="0"}				
					{foreach item=item key=key from=$user_pics}
					{math equation="$mcount+1" assign="mcount"}		
					<tr class="{cycle values="oddrow,evenrow"}"> 
					  <td>{$mcount}</td>
					  <td align=left valign=middle>
					  <table width=100% cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" border=0>
						<tr>
							<td width=40%>{$lang.username}</td>
							<td align=left width=60%>{$item.username}</td>
						</tr>
						<tr>
							<td width=40%>{$lang.name}</td>
							<td align=left width=60%>{$item.fullname|stripslashes}</td>
						</tr>
						<tr>
							<td width=40%>{$lang.picture}:</td>
							<td align=left width=60%>{$item.picno}</td>
						</tr>
					</table>
					</td>
					<td>
						<img src="getsnap.php?id={$item.userid}&amp;picid={$item.picno}&amp;typ=pic&amp;width=100&amp;height=100" />
					</td>
					<td >
						<img src="getsnap.php?id={$item.userid}&amp;picid={$item.picno}&amp;typ=tn" />
					</td>
					<td >
						<form name=frm{$item.userid}_{$item.picno} action="approve_snaps.php" method=post>
							<input type=hidden name=id value="{$item.id}" />
							<input type=submit name=action class="formbutton" value="{$lang.Approve}" /><br />
							<input type=submit name=action class="formbutton" value="{$lang.reject}" />
						</form>
					</td>
				</tr>
				{/foreach}
				{/if}
			</tbody>
			</table>
		</TD>
	</TR>
</TABLE>
</CENTER>
{/strip}