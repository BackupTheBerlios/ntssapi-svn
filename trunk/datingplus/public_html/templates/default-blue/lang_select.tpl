{strip}
<table width="178" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="178" valign="top">
			<table width="178" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="150">
					{$lang.language_opt}
					</td>
					<td width="22"><img src="{$image_dir}blue_small_hor.jpg" width="22" height="23" alt="" /></td>
				</tr>
			</table>
			<table width="178" border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
				<tr>
					<td width="6"></td>
					<td width="172">
            <form name="langopt" action="index.php" method="post">
						<table  class="table" width="100%" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
							<tr>
								<td>
									{html_options name=lang options=$language_options selected=$smarty.session.opt_lang} 
								</td>
							</tr>
							<tr>
								<td>
								<input type="submit" class="formbutton" value="{$lang.change_language}" />
								</td>
							</tr>
						</table>
            </form>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}



