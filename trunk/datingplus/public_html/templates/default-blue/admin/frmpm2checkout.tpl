<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}"  width="570">
	<tbody>
    <tr>
		<td>
			<p>
				<b>2CheckOut.com</b>
			</p>
			<p>
				<b>Login/Merchant ID</b><br />
				Login/Merchant ID used for the 2CheckOut service<br />
				<input type="text" name="configuration[MODULE_PAYMENT_2CHECKOUT_LOGIN]" value="{$paymod_data.MODULE_PAYMENT_2CHECKOUT_LOGIN}" />
			</p>
			<p>
				<b>Transaction Mode</b><br />
				Transaction mode used for the 2Checkout service<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_2CHECKOUT_TESTMODE]" value="Test"
						{if $paymod_data.MODULE_PAYMENT_2CHECKOUT_TESTMODE == 'Test'}checked="checked"{/if} /> Test<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_2CHECKOUT_TESTMODE]" value="Production"
						{if $paymod_data.MODULE_PAYMENT_2CHECKOUT_TESTMODE == 'Production'}checked="checked"{/if} /> Production
			</p>
			<p>
				<b>Merchant Notifications</b><br />
				Should 2CheckOut e-mail a receipt to the store owner?<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_2CHECKOUT_EMAIL_MERCHANT]" value="True"
						{if $paymod_data.MODULE_PAYMENT_2CHECKOUT_EMAIL_MERCHANT == 'True'}checked="checked"{/if} /> True<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_2CHECKOUT_EMAIL_MERCHANT]" value="False"
						{if $paymod_data.MODULE_PAYMENT_2CHECKOUT_EMAIL_MERCHANT == 'False'}checked="checked"{/if} /> False
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
