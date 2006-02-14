<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}"  width="570">
	<tbody>
    <tr>
		<td>
			<p>
				<b>SECPay</b>
			</p>
			<p>
				<b>Merchant ID</b><br />
				Merchant ID to use for the SECPay service<br />
				<input type="text" name="configuration[MODULE_PAYMENT_SECPAY_MERCHANT_ID]" value="{$paymod_data.MODULE_PAYMENT_SECPAY_MERCHANT_ID}" />
			</p>
			<p>
				<b>Transaction Currency</b><br />
				The currency to use for credit card transactions<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_SECPAY_CURRENCY]" value="Any Currency"
								{if $paymod_data.MODULE_PAYMENT_SECPAY_CURRENCY == 'Any Currency'}checked="checked"{/if} /> Any Currency<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_SECPAY_CURRENCY]" value="Default Currency"
								{if $paymod_data.MODULE_PAYMENT_SECPAY_CURRENCY == 'Default Currency'}checked="checked"{/if} /> Default Currency
			</p>
			<p>
				<b>Transaction Mode</b><br />
				Transaction mode to use for the SECPay service<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_SECPAY_TEST_STATUS]" value="Always Successful"
								{if $paymod_data.MODULE_PAYMENT_SECPAY_TEST_STATUS == 'Always Successful'}checked="checked"{/if} /> Always Successful<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_SECPAY_TEST_STATUS]" value="Always Fail"
								{if $paymod_data.MODULE_PAYMENT_SECPAY_TEST_STATUS == 'Always Fail'}checked="checked"{/if} /> Always Fail<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_SECPAY_TEST_STATUS]" value="Production"
								{if $paymod_data.MODULE_PAYMENT_SECPAY_TEST_STATUS == 'Production'}checked="checked"{/if} /> Production
			</p>
		</td>
    </tr>
	</tbody>
</table>
{if $smarty.get.saved == 'yes'}
{strip}
			<script language="javascript">
      /* <![CDATA[ */
				alert("Settings have beed saved successfully.");
      /* ]]> */
			</script>
{/strip}
{/if}
