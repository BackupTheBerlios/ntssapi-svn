{strip}
<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" /></td>
		<td class="module_head" width="496">{$lang.events_require_approval}</td>
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
						{$lang.total_events_found}&nbsp;{$events|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
				</tr>
			</TABLE>
			<table class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width=550 border=0>
 			<tbody>
			{ if $errid ne ''} 
				<tr><td colspan="5"><span class="errors">{$lang.errormsgs[$errid]}</span></td></tr>	
				<tr><td colspan="5">&nbsp;</td></tr>	
			{ /if }
				<tr class="table_head"> 
					<th>{$lang.col_head_event}</th>
				  	<th>{$lang.action}</th>
				</tr>
				{if $events|@count <= 0 }
				<tr>
					<td colspan="5">&nbsp;{$lang.no_record_found}</td>
				</tr>
				{else}
					{foreach item=item key=key from=$events}
					<tr class="{cycle values="oddrow,evenrow"}"> 
					<td>
						<table>
							<tr>
								<td>{$lang.col_head_username}:</td>
								<td>{$item.username}</td>
							</tr>
							<tr>
								<td>{$lang.col_head_fullname}:</td>
								<td>{$item.fullname}</td>
							</tr>
							<tr>
								<td>{$lang.col_head_calendar}:</td>
								<td>{$calendars[$item.calendarid]}</td>
							</tr>
							<tr>
								<td>{$lang.col_head_datefrom}:</td>
								<td>{$item.datetime_from|date_format:"%d/%m/%Y %H:%M"}</td>
							</tr>
							<tr>
								<td>{$lang.col_head_dateto}:</td>
								<td>{$item.datetime_to|date_format:"%d/%m/%Y %H:%M"}</td>
							</tr>
							<tr>
								<td>{$lang.col_head_event}:</td>
								<td>{$item.event|stripslashes}</td>
							</tr>
							<tr>
								<td>{$lang.col_head_description}:</td>
								<td>{$item.description|nl2br}</td>
							</tr>
						</table>
					</td>
					<td >
						<form name=frm{$item.userid}_{$item.picno} action="" method=post>
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