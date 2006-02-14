{strip}
<form action="https://secure.paypal.com/cgi-bin/webscr" method="post">
	<input type="hidden" name="cmd" value="_xclick" />
	<input type="hidden" name="add" value="1" />
	<input type="hidden" name="business" value="{$email}" />
  <input type="hidden" name="return" value="http://{$smarty.server.SERVER_NAME}{$docroot}checkout_process.php?pay_mod=paypal" />
	<input type="hidden" name="undefined_quantity" value="{$u_qty}" />
	<input type="hidden" name="item_name" value="{$item_name}" />

	{* used by checkout_process.php to validate order *}
	<input type="hidden" name="item_number" value="{$invoice_num}" />

	<input type="hidden" name="amount" value="{$amount}" />
	<input type="hidden" name="no_shipping" value="{$no_ship}" />
  <input type="hidden" name="cancel_return" value="http://{$smarty.server.SERVER_NAME}{$docroot}checkout_process.php?pay_mod=paypal" />
	<input type="hidden" name="no_note" value="{$no_note}" />
	<input type="hidden" name="currency_code" value="{$currency}" />
	<input type="hidden" name="level_name" value="{$item_name}" />
	<input type="hidden" name="user_id" value="{$smarty.session.UserId}" />
	<input type="hidden" name="user_level" value="{$item_no}" />
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
			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
				<tr>
					<td width="100%">
						<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">

							<tr><td>{$lang.info_confirm}</td></tr>
							<tr><td>{$lang.name}{$smarty.session.FullName|stripslashes}
							</td></tr>
							<tr><td>{$lang.change_mship_to}<b>{$item_name}</b>.</td></tr>
							<tr><td>{$lang.amount}{$lang.support_currency[$currency]}{$amount}</td></tr>
							<tr><td><input type="submit" class="formbutton" value="{$lang.confirm}" /></td></tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</form>
{/strip}
