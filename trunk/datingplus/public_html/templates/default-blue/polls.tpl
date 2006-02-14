{strip}
<table width="178" border="0" cellpadding="0" cellspacing="0" >
	<form name="frmpoll" action="votehere.php" method="get">
	<tr>
		<td class="module_detail" width="178" valign="top">

			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="150">{$lang.poll}
					</td>
					<td width="22"><img src="{$image_dir}blue_small_hor.jpg" width="22" height="23" alt="" /></td>
				</tr>
			</table>
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="6"></td>
					<td width="172">
						<table  class="table" width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
							<input name='pollid' type='hidden' value='{$poll_data.0.pollid}'/>
							<tr><td colspan="2">
								<span class='pollquestion'>{$poll_data.0.question|stripslashes}</span>
								<br />
								</td>
							</tr>
						{foreach item=opt from=$poll_data.options}
							<tr>
								<td width='10%' align='center' valign='top'><input type='radio' name='rdo' value='{$opt.optionid}'/></td>
								<td width='90%'><span class='polloptions'>{$opt.opt|stripslashes}</span></td>
							</tr>
						{/foreach}
							<tr>
								<td align='center' colspan='2'>
									<input type='button' name='btnVote' value='Vote' onclick='javascript:votesubmit("{$poll_data.0.pollid}","{$poll_data.curtime}");' class="formbutton"/>
								</td>
							</tr>
							<tr>
								<td colspan='2' align='center'>
								<a href='javascript:previousPolls();'>{$lang.view_poll_archive}</a>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	</form>
</table>
{/strip}



