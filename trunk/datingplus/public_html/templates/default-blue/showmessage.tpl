{strip}
{literal}
<script type="text/javascript">
/* <![CDATA[ */
var popUpWin=0;
function popUpWindow(URLStr, left, top, width, height)
{
  if(popUpWin)
  {
    if(!popUpWin.closed) popUpWin.close();
  }
  popUpWin = open(URLStr, 'popUpWin', 'toolbar=no,location=no,directories=no,status=no,menub ar=no,scrollbar=no,resizable=no,copyhistory=yes,width='+width+',height='+height+',left='+left+', top='+top+',screenX='+left+',screenY='+top+'');
}
/* ]]> */
</script>
{/literal}

<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.mail_messages}
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
				<tr>
					<td width="100%" align="CENTER">

						<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" width="50%">
							<tr>
								<td width="33%"><a href="mailmessages.php" >{$lang.inbox}</a></td>
								<td width="33%"><a href="sentmessages.php" >{$lang.sent}</a></td>
								<td width="33%"><a href="deletemessages.php" >{$lang.trashcan}({$deletemsg|default:0})</a></td>
							</tr>
						</table>

						<table width="550" border="0" cellpadding="0" cellspacing="0" >
							<tr>
								<td class="module_detail_inside" width="100%">

									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td class="module_head" width="6"></td>
											<td class="module_head">
												{$data.subject|stripslashes}
											</td>
											<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
										</tr>
									</table>
									<table width="100%" border="0">
										<tr>
											<td width="100%">

												<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" width="98%">
													<tbody>
													<tr>
														<td width="15%"><b>{$lang.username}</b> </td>
														<td width="85%">{$data.username}</td>
													</tr>
													<tr>
														<td><b>{$lang.name}</b></td>
														<td>{$data.firstname|stripslashes}&nbsp;{$data.lastname|stripslashes}</td>
													</tr>
													<tr>
														<td><b>{$lang.time_col}</b></td>
														<td>{$data.sendtime|date_format:$lang.DATE_TIME_FORMAT}</td>
													</tr>
													<tr>
														<td colspan="2">{$data.message|stripslashes}</td>
													</tr>
													{if $smarty.get.messages == 'inbox' }
													<tr>
														<td colspan="2">
															<a href="javascript:popUpWindow('compose.php?recipient={$data.senderid}',100,100,350,200)">
															{$lang.reply}</a>
														</td>
													</tr>
													{/if}
													</tbody>
												</table>

											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>

					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
