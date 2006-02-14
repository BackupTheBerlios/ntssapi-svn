{strip}
<table width="558" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" >
						<input type="radio" name="payment" value="{$item.module_key}" {if $smarty.get.payment eq $item.module_key}checked="checked"{/if} />{$item.name}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
