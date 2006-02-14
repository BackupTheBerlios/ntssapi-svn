<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}"  width="570">
	<tbody>
    <tr>
		<td>
			<p>
				<b>Authorize.Net</b>
			</p>
			<p>
				<b>Login Username</b><br />
				The login username used for the Authorize.net service<br />
				<input type="text" name="configuration[MODULE_PAYMENT_AUTHORIZENET_LOGIN]" value="{$paymod_data.MODULE_PAYMENT_AUTHORIZENET_LOGIN}" />
			</p>
			<p>
				<b>Transaction Key</b><br />
				Transaction Key used for encrypting TP data<br />
				<input type="text" name="configuration[MODULE_PAYMENT_AUTHORIZENET_TXNKEY]" value="{$paymod_data.MODULE_PAYMENT_AUTHORIZENET_TXNKEY}" />
			</p>
			<p>
				<b>Transaction Mode</b><br />
				Transaction mode used for processing orders<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_AUTHORIZENET_TESTMODE]" value="Test"
										{if $paymod_data.MODULE_PAYMENT_AUTHORIZENET_TESTMODE== 'Test'}checked{/if} /> Test<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_AUTHORIZENET_TESTMODE]" value="Production"
										{if $paymod_data.MODULE_PAYMENT_AUTHORIZENET_TESTMODE == 'Production'}checked{/if} /> Production
			</p>
			<p>
				<b>Transaction Method</b><br />
				Transaction method used for processing orders<br />

				<input type="radio" name="configuration[MODULE_PAYMENT_AUTHORIZENET_METHOD]" value="Credit Card"
										{if $paymod_data.MODULE_PAYMENT_AUTHORIZENET_METHOD == 'Credit Card'}checked="checked"{/if} /> Credit Card<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_AUTHORIZENET_METHOD]" value="eCheck"
										{if $paymod_data.MODULE_PAYMENT_AUTHORIZENET_METHOD == 'eCheck'}checked="checked"{/if} /> eCheck
			</p>
		</td>
    </tr>
	</tbody>
</table>
{if $smarty.get.saved == 'yes'}
{strip}
			<script type="text/javascript">
      /* <![CDATA[ */
				alert("Settings have beed saved successfully.");
      /* ]]> */
			</script>
{/strip}
{/if}
