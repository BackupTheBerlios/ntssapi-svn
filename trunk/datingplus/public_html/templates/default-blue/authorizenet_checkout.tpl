{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">
			<form action="https://secure.authorize.net/gateway/transact.dll" method="post">
			<input type="hidden" name="x_Login" value="{$loginid}" />
			<input type="hidden" name="x_Card_Num" value="{$cc_number}" />
			<input type="hidden" name="x_Exp_Date" value="{$cc_expiry_date}" />
			<input type="hidden" name="x_Amount" value="{$amount}" />
      <input type="hidden" name="x_Relay_URL" value="http://{$smarty.server.SERVER_NAME}{$docroot}checkout_process.php?pay_mod=authorizenet" />
			<input type="hidden" name="x_Method" value="{$trans_method}" />
			<input type="hidden" name="x_type" value="{$trans_mode}" />
			<input type="hidden" name="x_Version" value="3.0" />
			<input type="hidden" name="x_Cust_ID" value="{$smarty.session.UserId}" />
			<input type="hidden" name="x_Email_Customer" value="FALSE" />
			<input type="hidden" name="x_name" value="{$smarty.session.FullName}" />
			<input type="hidden" name="x_Customer_IP" value="{$smarty.server.REMOTE_ADDR}" />
			<input type="hidden" name="x_fp_sequence" value="{$sequence}" />
			<input type="hidden" name="x_fp_timestamp" value="{$tstamp}" />
			<input type="hidden" name="x_fp_hash" value="{$fp}" />
			<input type="hidden" name="x_Test_Request" value="TRUE" />
			<input type="hidden" name="level_name" value="{$item_name}" />

			<input type="hidden" name="user_id" value="{$smarty.session.UserId}" />
			<input type="hidden" name="user_level" value="{$item_no}" />

			{* used by checkout_process.php to validate order *}
			<input type="hidden" name="invoice_num" value="{$invoice_num}" />

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.confirmation}
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
				<tr>
					<td>
						<table width="400">
							<tr><td colspan="2"><b>{$payment_method} {$cc_type}</b></td></tr>
							<tr><td>{$lang.cc_owner}</td><td>{$cc_owner}</td></tr>
							<tr><td>{$lang.cc_number}</td><td>{$cc_part1}XXXXXXXX{$cc_part2}</td></tr>
							<tr><td>{$lang.cc_exp_date}</td><td>{$cc_expiry_month}/{$cc_expiry_year}</td></tr>
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
