{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">
		<table><tr class="table_head"><td><a href="paymentmod.php" class="subhead">{$lang.payment_modules}</a></td></tr></table>
		</td>
	</tr>
</table>
<br />
<center>
<table width="550" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.edit_payment_modules}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>


			<form action="modifypaymentmod.php" method="post">
				<input type="hidden" name="payment" value="{$data.module_key}" />

				{include file=$data.formfile}<br />

				<input type="submit" class="formbutton" value="{$lang.submit}" />
 			</form>
 		</td>
 	</tr>
</table>
</center>
{/strip}