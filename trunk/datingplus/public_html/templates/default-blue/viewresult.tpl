{strip}
{include file="popheader.tpl"}
<table width="100%" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" >
					{$lang.poll_result}
					</td>
				</tr>
			</table>
			<br />
			<center>
				<table width="500" border="0" cellpadding="0" cellspacing="0" >
					<tr>
						<td class="module_detail_inside" width="100%">
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
								<tr>
									<td class="module_head" width="9"></td>
									<td class="module_head" width="469">
									{$question|stripslashes}
									</td>
									<td width="22"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
								</tr>
							</table>
							{if $err == 1 }
							<center>
							<p>
							<font color='red'>{$lang.poll_errmsg1}</font>
							</p>
							</center>
							{/if}

							<table   width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
							{foreach item=row from=$data}
								<tr>
									<td valign="top"><b>{$row.opt}</b></td>
									<td valign="top">
								{if $row.numw > 0}
										<img src="{$image_dir}{$row.c}.gif" height="18" width="{$row.numw}" alt="" />&nbsp;
										{$row.numw}%</td>
								{else}
										{math equation="ceil(x)" x=$row.numw}%</td>
								 {/if}
									<td align="right" valign="top"><b>{$row.result}&nbsp;{$lang.votes}</b></td>
								</tr>
							{/foreach}
								<tr>
									<td colspan="3" align="right"><b>Total:&nbsp;{$numtotal}&nbsp;{$lang.votes}</b></td>
								</tr>
							</table>
								<tr>
									<td colspan="3">
										<table  class="table" width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" align='center'>
											<tr>
									 			<td>
													{$lang.poll_msg}
									 			</td>
								 			</tr>
										</table>
									</td>
								</tr>
								<tr><td colspan="3" height="10"></td></tr>

								{if $config.use_popups == 'Y'}
								<tr><td colspan="3" align="center">&gt;<a href="javascript: window.close()" class="closelink">{$lang.close}</a></td></tr>
        {/if}
       </table>
      </td>
     </tr>
    </table>
   </center>
			<br />
  </td>
 </tr>
</table>

{include file="popfooter.tpl"}
{/strip}
