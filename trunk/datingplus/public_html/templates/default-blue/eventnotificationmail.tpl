<p>Dear {$user.firstname} {$user.lastname}, event that you watched on was changed.</p>
<!-- Event Start -->
<table width="100%" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%" >

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="100%" class="module_head">
					 {$lang.calendar}&nbsp;{$calendars[$event.calendarid]}
					</td>
				</tr>
			</table>

			<table width="100%" border="0">
				<tr class="evenrow">
					<td><b>{$event.event}</b></td>
				</tr>
				<tr class="addrow">
					<td valign="top" >
						<table width="100%">
							<tr>
								<td><b>{$lang.start_date}:</b>&nbsp;{$event.datetime_from|date_format:"%d/%m/%Y"}</td>
								<td><b>{$lang.end_date}:</b>&nbsp;{$event.datetime_to|date_format:"%d/%m/%Y"}</td>
							</tr>
							<tr>
								<td><b>{$lang.start_time}:</b>&nbsp;{$event.datetime_from|date_format:"%I:%M %p"}</td>
								<td><b>{$lang.end_time}:</b>&nbsp;{$event.datetime_to|date_format:"%I:%M %p"}</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr class="evenrow">
					<td>
					{if $event.private_to != ""}
						This event information is private
					{else}
						This is publicity-viewbale event
					{/if}
					</td>
				</tr>
				<tr class="addrow">
					<td valign="top" ><b>{$lang.event_description}:</b></td>
				</tr>
				<tr class="evenrow">
					<td valign="top" >{$event.description|nl2br}</td>
				</tr>
			</table>

		</td>
	</tr>
</table>
<!-- Event Ends -->
