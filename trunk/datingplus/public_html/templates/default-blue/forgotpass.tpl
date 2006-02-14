{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.forgotpass_msg1}
					</td>
				</tr>
			</table>
			<table width="100%" border="0" cellpadding="{$config.cellpadding}"  cellspacing="{$config.cellspacing}">
				<tr>
					<td width="100%">
						{ if $errmsg != ''}
						 	<font color="red">{$errmsg}</font><br /><br />
						{/if}
						{$lang.forgotpass_msg2} <br/> <br />
						<form action="getforgotpass.php" method="post">
							<input type="text" name="txtemail" size="30"/><input type="submit" class="formbutton" value="{$lang.retreieve_info}"/>
						</form>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
