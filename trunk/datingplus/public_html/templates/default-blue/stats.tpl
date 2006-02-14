{strip}
<table width="178" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="178" valign="top">

			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="150">
					{$lang.site_statistics}
					</td>
					<td width="22"><img src="{$image_dir}blue_small_hor.jpg" width="22" height="23" alt="" /></td>
				</tr>
			</table>
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="6"></td>
					<td width="100%">

						<table  class="table" width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
							<tr>
								<td width="80%">
									{$lang.weekcnt}
								</td>
								<td width="20%">
									{$weekcnt}
								</td>
							</tr>
							<tr>
								<td width="80%">
									{$lang.totalgents}
								</td>
								<td width="20%">
									{$gents}
								</td>
							</tr>
							<tr>
								<td width="80%">
									{$lang.totalfemales}
								</td>
								<td width="20%">
									{$females}
								</td>
							</tr>
						{if $couples > 0}
							<tr>
								<td width="80%">
									{$lang.totalcouples}
								</td>
								<td width="20%">
									{$couples}
								</td>
							</tr>
						{/if}
							<tr>
								<td width="80%">
									{$lang.weeksnaps}
								</td>
								<td width="20%">
									{$weeksnaps}
								</td>
							</tr>
							<tr>
								<td width="80%">
									{$lang.online_users}
								</td>
								<td width="20%">
									{$online_users_count}
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



