{strip}
{if $error ne ""}
<font color="{$lang.admin_error_color}">{$error}</font>
{/if}
<form action="inssection.php" method="post">
<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="600" border="0">
<tbody>
	<tr>
		<td colspan="2" class="subtitle">{$lang.insert_section}</td>
	</tr>
	<tr><td colspan="5">&nbsp;</td></tr>
	<tr>
		<td>{$lang.name}</td>
		<td><input type="text" maxlength="255" size="50" name="txtsection" /></td>
	</tr>
	<tr>
		<td>{$lang.enabled}</td>
		<td><select name="txtenabled">
			{html_options options=$lang.enabled_values selected=$data.enabled}
		</select>
		</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td>
			<input type="submit" class="formbutton" value="{$lang.submit}" />&nbsp;
			<input type="reset" class="formbutton"value="{$lang.reset}" />
		</td>
	</tr>
</tbody>
</table>
</form>
{/strip}