{strip}
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="702"><a href="import.php" class="subhead">{$lang.manage_import}</a>&nbsp;>&nbsp;{$lang.import_db_configuration}</td>
	</tr>
</table>
<br />
<font color="#FF0000"><b>{$message}</b></font>
<br />
<br />
<center>
<table width="530" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">{$lang.import_db_configuration}</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form action="{$smarty.section.PHP_SELF}" method="post">
        <input type="hidden" name="db_config" value="true" />
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
	  		<tbody>
	 			<tr>
	  				<td>{$lang.db_name}</td>
	  				<td><input type="text" name="db_name" value="{$db.db_name}" /></td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.db_host}</td>
	  				<td><input type="text" name="db_host" value="{$db.db_host}" /></td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.db_user}</td>
	  				<td><input type="text" name="db_user" value="{$db.db_user}" /></td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.db_pass}</td>
	  				<td><input type="text" name="db_pass" value="{$db.db_pass}" /></td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.db_prefix}</td>
	  				<td><input type="text" name="db_prefix" value="{$db.db_prefix}" /></td>
	 			</tr>
	 			<tr>
	  				<td>{$lang.photos_url}</td>
	  				<td><input type="text" name="photos_url" value="{$db.photos_url}" /></td>
	 			</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<input type="submit" class="formbutton" value="{$lang.submit}" />&nbsp;
						<input type="reset" class="formbutton" value="{$lang.reset}" />
					</td>
				</tr>
  			</tbody>
			</table>
      </form>
		</td>
	</tr>
</table>
</center>
{/strip}