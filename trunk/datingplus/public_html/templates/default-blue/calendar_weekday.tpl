{strip}
<table width="180" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%" >

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td width="100%" class="module_head">
						&nbsp;&nbsp;<a href="#" onclick="javascript: mainLink('moreevents.php?calendarid={$calendarid}&amp;timestamp={$item.timestamp}'); return(false);"><font color="#FFFFFF">{$item.date.mday}</font></a><br />
					</td>
					<td width="22"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			<table width="100%" border="0" bgcolor="#FFFFFF">
				<tr>
					<td valign="top">
					{foreach item=event key=ekey from=$item.events}
						<a href="#" onclick="javascript: mainLink('event.php?event_id={$event.id}'); return(false);">{$event.event|truncate:"24"}</a><br />
					{/foreach}
					{if $item.more_events}
						<a href="#" onclick="javascript: mainLink('moreevents.php?calendarid={$calendarid}&amp;timestamp={$item.timestamp}'); return(false);">{$lang.more_events}</a><br />
					{/if}
					</td>
				</tr>
			</table>

		</td>
	</tr>
</table>
{/strip}
