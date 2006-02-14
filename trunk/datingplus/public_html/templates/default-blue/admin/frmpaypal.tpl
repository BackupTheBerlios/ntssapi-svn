<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}"  width="570">
	<tbody>
    <tr>
		<td>
			<p>
				<b>PayPal</b>
			</p>
			<p>
				<b>E-Mail Address</b><br />
				The e-mail address to use for the PayPal service<br />
				<input type="text" name="configuration[MODULE_PAYMENT_PAYPAL_ID]" value="{$paymod_data.MODULE_PAYMENT_PAYPAL_ID}" size="40" />
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
