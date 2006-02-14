{strip}
{include file="popheader.tpl"}
<script type="text/javascript">
/* <![CDATA[ */
{literal}
	function mainLink(url)
	{	window.opener.document.location.href=url;
		window.opener.focus();
	}
{/literal}
/* ]]> */
</script>
<!-- MONTH -->
<table width="100%" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="100%">

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="100%">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td class="module_head">
						<a href="#" onclick="javascript: mainLink('event.php?insert=true'); return(false);"><img src="{$image_dir}new.gif" alt="{$lang.add_event}" width="14" height="11" border="0" /></a>&nbsp;&nbsp;
						{$lang.calendar}&nbsp;
						<select name="txtcalendar" onchange="javascript: document.location.href='{$smarty.server.PHP_SELF}?calendarid='+this.value+'&amp;timestamp={$timestamp}';">
						{html_options options=$allcalendars selected=$calendarid}
						</select>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?calendarid={$calendarid}&amp;timestamp={$timestamp}&amp;show=private"><img src="{$image_dir}private.gif" alt="{$lang.private_only}" width="16" height="16" border="0" /></a>&nbsp;
						<a href="{$smarty.server.PHP_SELF}?calendarid={$calendarid}&amp;timestamp={$timestamp}&amp;show=public"><img src="{$image_dir}public.gif" alt="{$lang.public_only}" width="16" height="16" border="0" /></a>&nbsp;
						<a href="{$smarty.server.PHP_SELF}?calendarid={$calendarid}&amp;timestamp={$timestamp}&amp;show=both"><img src="{$image_dir}privatepublic.gif" alt="{$lang.public_private}" width="16" height="16" border="0" /></a>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?calendarid={$calendarid}&amp;timestamp={$timestamp}&amp;view=day"><img src="{$image_dir}view_d.gif" alt="{$lang.view_day}" width="16" height="16" border="0" /></a>&nbsp;&nbsp;&nbsp;
						<a href="{$smarty.server.PHP_SELF}?calendarid={$calendarid}&amp;timestamp={$timestamp}&amp;view=week"><img src="{$image_dir}view_w.gif" alt="{$lang.view_week}" width="16" height="16" border="0" /></a>&nbsp;&nbsp;&nbsp;
						<img src="{$image_dir}view_m1.gif" alt="{$lang.view_month}" width="16" height="16" border="0" />&nbsp;&nbsp;&nbsp;
								</td>
								<td align="right" class="module_head">
            <form action="{$smarty.server.PHP_SELF}?calendarid={$calendarid}" method="post" enctype="multipart/form-data">
						<input type="hidden" name="jump_to" value="true"/>
						{$lang.jump_to}: &nbsp;{html_select_date_translated prefix="jump_date" time=$timestamp start_year="-5" end_year="+5" display_days=false}&nbsp;<input type="submit" class="formbutton" value="{$lang.ok}"/>&nbsp;
            </form>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>

			<table align="center" cellspacing="0" cellpadding="0" border="0">
				<tbody>
					<tr>
						<td align="center">
							<table width="100%">
								<tr>
									<td width="33%" align="left">
						{if $prev != "" }
							<a href="?timestamp={$prev}&amp;calendarid={$calendarid}" > {$lang.previous_month}</a>&nbsp;
						{/if}
									</td>
									<td width="33%" align="center"><b><font size="+1">{$cur_date.month}&nbsp;{$cur_date.year}</font></b></td>
									<td width="33%" align="right">
						{if $next != "" }
							 <a href="?timestamp={$next}&amp;calendarid={$calendarid}" >{$lang.next_month}</a>
						{/if}
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<table  width="100%" cellpadding="0" cellspacing="2" border="0">
								<tr align="center">
									<td><b>Monday</b></td>
									<td><b>Tuesday</b></td>
									<td><b>Wednesday</b></td>
									<td><b>Thursday</b></td>
									<td><b>Friday</b></td>
									<td><b>Saturday</b></td>
									<td><b>Sunday</b></td>
								</tr>
							{foreach item=item key=key from=$calendar}
								{if $ccount==0}
									<tr>
								{/if}
									<td>{include file="calendar_monthday.tpl"}</td>
								{if $ccount==6}
									</tr>
								{/if}
								{math equation="$ccount+1" assign="ccount"}
								{math equation="$ccount%7" assign="ccount"}
							{/foreach}
							</table>
						</td>
					</tr>
				</tbody>
			</table>
		</td>
	</tr>
</table>
{include file="popfooter.tpl"}
{/strip}
