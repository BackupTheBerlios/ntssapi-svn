{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.payment_modules}</td>
	</tr>
</table>
<br />
<center>
<table cellspacing="0" cellpadding="0" width="550" border="0" align="left">
	<tr>
		<td align="center">
			<table width="530" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td class="module_detail_inside" width="100%">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="module_head" width="6"></td>
								<td class="module_head" width="526">
									{$lang.payment_modules}
									</td>
								<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
							</tr>
						</table>
						<table border="0" width="530"  cellpadding="1" cellspacing="2">
			  				<tr class="table_head">
								<th>{$lang.module}</th>
								<th>{$lang.action}</th>
							</tr>
						{foreach item=item from=$data}
							<tr  class="{cycle values="oddrow,evenrow"}">
								<td>{$item.name|stripslashes}</td>
								<td align="center">
								{if $item.enabled == 'Y'}
									<a href="?edit={$item.module_key}">{$lang.edit}</a>&nbsp;&nbsp;
									<a href="?delete={$item.module_key}">{$lang.uninstall}</a>
								{else}
									<a href="?install={$item.module_key}">{$lang.install}</a>
								{/if}
								</td>
							</tr>
						{/foreach}
							<tr><td>&nbsp;</td></tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</center>
{/strip}