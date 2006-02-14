{strip}
<form action="changemship.php" method="post">
	<input type="hidden" name="item_name" value="{$item_name}"/>
	<input type="hidden" name="item_number" value="{$item_no}"/>
	<input type="hidden" name="level_name" value="{$item_name}"/>
	<input type="hidden" name="user_id" value="{$smarty.session.UserId}"/>
	<input type="hidden" name="user_level" value="{$item_no}"/>
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
					<tr><td width="100%">
						<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
							<tr><td>{$lang.info_confirm}</td></tr>
							<tr><td>{$lang.name}&nbsp;{$smarty.session.FullName|stripslashes}
								</td>
							</tr>
							<tr><td>{$lang.change_mship_to}&nbsp;<b>{$item_name}</b>.</td></tr>
							<tr><td><input type="submit" class="formbutton" value="{$lang.confirm}"/></td></tr>
						</table>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</form>
{/strip}
