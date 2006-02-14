<!-- Event Start -->
<table width="100%" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%" >

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td width="100%" class="module_head">
					 &nbsp;&nbsp;{$lang.calendar}&nbsp;{$calendars[$item.calendarid]}
					</td>
					<td width="22"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			<table width="100%" border="0">
				<tr class="evenrow">
					<td><b>{$item.event}</b></td>
				</tr>
				<tr class="addrow">
					<td valign="top" ><br />
						<table width="100%">
							<tr>
								<td><b>{$lang.start_date}:</b>&nbsp;{$item.datetime_from|date_format:"%d/%m/%Y"}</td>
								<td><b>{$lang.end_date}:</b>&nbsp;{$item.datetime_to|date_format:"%d/%m/%Y"}</td>
							</tr>
							<tr>
								<td><b>{$lang.start_time}:</b>&nbsp;{$item.datetime_from|date_format:"%I:%M %p"}</td>
								<td><b>{$lang.end_time}:</b>&nbsp;{$item.datetime_to|date_format:"%I:%M %p"}</td>
							</tr>
						</table><br />
					</td>
				</tr>
				<tr class="evenrow">
					<td>
					{if $item.private_to != ""}
						This event information is private
					{else}
						This is publicly-viewable event
					{/if}
					</td>
				</tr>
				<tr class="addrow">
					<td valign="top" ><br /><b>{$lang.event_description}:</b></td>
				</tr>
				<tr class="evenrow">
					<td valign="top" >{$item.description|nl2br}</td>
				</tr>
				<tr align="right" class="addrow">
					<td>
			{if $item.watched}
						<a href="watchevents.php?delete={$item.id}"><img src="{$image_dir}unwatch.gif" border="0" alt="" /></a>
			{else}
						<a href="watchevents.php?add={$item.id}"><img src="{$image_dir}watch.gif" border="0" alt="" /></a>
			{/if}
			{if $item.userid == $smarty.session.UserId}
						<a href="event.php?edit={$item.id}"><img src="{$image_dir}button_edit.png" border="0" alt="Edit" /></a>
						<a href="event.php?delete={$item.id}" onclick="javascript:return(confirm('{$lang.admin_js__delete_error_msgs[19]}'))"><img src="{$image_dir}button_drop.png" alt="Delete" border="0" /></a>
			{/if}
					</td>
				</tr>
			</table>

		</td>
	</tr>
</table>
<!-- Event Ends -->
