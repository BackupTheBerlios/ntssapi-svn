{strip}
<table width="558" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" >
						<input type="radio" name="payment" value="free" {if $smarty.get.payment eq 'free' or $data|@count eq '0'}checked="checked"{/if} />{$lang.no_payment}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
