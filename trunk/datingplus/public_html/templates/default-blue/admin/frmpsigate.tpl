<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}"  width="570">
	<tbody>
		<td>
			<p>
				<b>PSiGate</b>
			</p>
			
			<p>
				<b>Merchant ID</b><br />
				Merchant ID used for the PSiGate service
				<br />
				<input type="text" name="configuration[MODULE_PAYMENT_PSIGATE_MERCHANT_ID]" value="{$paymod_data.MODULE_PAYMENT_PSIGATE_MERCHANT_ID}" />
			</p>
			<p>
				<b>Transaction Mode</b><br />
				Transaction mode to use for the PSiGate service
				<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE]" value="Production"
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE == 'Production'}CHECKED{/if} /> Production<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE]" value="Always Good" 
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE == 'Always Good'}CHECKED{/if} /> Always Good<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE]" value="Always Duplicate"
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE == 'Always Duplicate'}CHECKED{/if} /> Always Duplicate<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE]" value="Always Decline"
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE == 'Always Decline'}CHECKED{/if} /> Always Decline
			</p>
			<p>			
				<b>Transaction Type</b><br />
				Transaction type to use for the PSiGate service
				<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_TRANSACTION_TYPE]" value="Sale"
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_TRANSACTION_TYPE == 'Sale'}CHECKED{/if} /> Sale<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_TRANSACTION_TYPE]" value="PreAuth" 
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_TRANSACTION_TYPE == 'PreAuth'}CHECKED{/if} /> PreAuth<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_TRANSACTION_TYPE]" value="PostAuth"
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_TRANSACTION_TYPE == 'PostAuth'}CHECKED{/if} /> PostAuth
			</p>
			<p>			
				<b>Credit Card Collection</b><br />
				Should the credit card details be collected locally or remotely at PSiGate?
				<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_INPUT_MODE]" value="Local" 
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_INPUT_MODE == 'Local'}CHECKED{/if} /> Local<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_INPUT_MODE]" value="Remote"
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_INPUT_MODE == 'Remote'}CHECKED{/if} /> Remote
			</p>
			<p>			
				<b>Transaction Currency</b><br />
				The currency to use for credit card transactions
				<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_CURRENCY]" value="CAD"
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_CURRENCY == 'CAD'}CHECKED{/if} /> CAD<br />
				<input type="radio" name="configuration[MODULE_PAYMENT_PSIGATE_CURRENCY]" value="USD" 
				{if $paymod_data.MODULE_PAYMENT_PSIGATE_CURRENCY == 'USD'}CHECKED{/if} /> USD
			</p>
		</td>
	</tbody>
</table>
{if $smarty.get.saved == 'yes'}
{strip}
			<script language="javascript">
				alert("Settings have beed saved successfully.");
			</script>
{/strip}			
{/if}
