{strip}
<table width="558" border="0" cellpadding="0" cellspacing="0" align="CENTER">
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" >
						<input type="radio" name="payment_method" value="{$item.id}" {if $smarty.get.payment_method eq $item.id}checked="checked"{/if}/>{$item.name}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			{if $data.show_form}
			<table width="100%" border="0" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}">
				<tr><td width="35%">{$lang.cc_owner}</td><td width="65%"><input type="text" name="toco_ccowner"/></td></tr>
				<tr><td>{$lang.cc_number}</td><td><input type="text" name="toco_ccnumber"/></td></tr>
				<tr><td>{$lang.cc_exp_date}</td>
					<td>
						{html_select_date_translated display_days=false end_year=+10 prefix="toco_exp_"}
					</td>
				</tr>
				<tr><td>{$lang.cc_cvv_number}</td><td><input type="text" name="toco_cvvnumber" size="4" maxlength="3"/>&nbsp;{$lang.cvv_help}</td></tr>
			</table>
			{/if}
		</td>
	</tr>
</table>
{/strip}

