{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.confirmation}
					</td>
				</tr>
			</table>

<form action="https://order.psigate.com/psigate.asp" method="post">
<input type="hidden" name="MerchantID" value="{$MerchantID}" />
<input type="hidden" name="FullTotal" value="{$amount}" />
<input type="hidden" name="ThanksURL" value="http://{$smarty.server.SERVER_NAME}{$docroot}checkout_process.php?pay_mod=psigate" />
<input type="hidden" name="NoThanksURL" value="http://{$smarty.server.SERVER_NAME}{$docroot}checkout_cancel.php?pay_mod=psigate" />
<input type="hidden" name="Bname" value="{$cc_owner}" />
<input type="hidden" name="ChargeType" value="{$ChargeType}" />
<input type="hidden" name="Result" value="{$Result}" />
<input type="hidden" name="IP" value="{$IP}" />
<input type="hidden" name="CardNumber" value="{$cc_number}" />
<input type="hidden" name="ExpMonth" value="{$cc_expiry_month}" />
<input type="hidden" name="ExpYear" value="{$cc_expiry_year}" />


			{* used by checkout_process.php to validate order *}
			<input type="hidden" name="cart_order_id" value="{$invoice_num}" />

			<input type="hidden" name="level_name" value="{$item_name}" />
			<input type="hidden" name="user_id" value="{$smarty.session.UserId}" />
			<input type="hidden" name="user_level" value="{$item_no}" />

			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
				<tr>
					<td width="100%">

						<table width="400">
							<tr><td colspan="2"><b>{$payment_method} {$cc_type}</b></td></tr>
							<tr><td>{$lang.cc_owner}</td><td>{$cc_owner}</td></tr>
							<tr><td>{$lang.cc_number}</td><td>{$cc_part1}XXXXXXXX{$cc_part2}</td></tr>
							<tr><td>{$lang.cc_exp_date}</td><td>{$cc_expiry_month}, {$cc_expiry_year}</td></tr>
							<tr><td>{$lang.amount}</td><td>{$lang.support_currency[$currency]}{$amount}</td></tr>
							<tr><td colspan="2">{$lang.change_mship_to} <b>{$item_name}</b>.</td></tr>
						</table>

					</td>
				</tr>
				<tr>
					<td><input type="submit" class="formbutton" value="{$lang.confirm}" /></td>
				</tr>
			</table>
			</form>

		</td>
	</tr>
</table>
{/strip}
