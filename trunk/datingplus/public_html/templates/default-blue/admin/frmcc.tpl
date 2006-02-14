<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}"  width="570">
	<tbody>
  <tr>
		<td>
			<p>
				<b>Credit Card</b>
			</p>
			<p>
				<b>Split Credit Card E-Mail Address</b><br />
				If an e-mail address is entered, the middle digits of the credit card number
				 will be sent to the e-mail address (the outside digits are stored in the database
				 with the middle digits censored)<br />
				<input type="text" name="configuration[MODULE_PAYMENT_CC_EMAIL]" value="{$paymod_data.MODULE_PAYMENT_CC_EMAIL}" size="40" />
			</p>
		</td>
  </tr>
	</tbody>
</table>
{if $smarty.get.saved == 'yes'}
{strip}
			<script language="javascript">
				alert("Settings have beed saved successfully.");
			</script>
{/strip}
{/if}
