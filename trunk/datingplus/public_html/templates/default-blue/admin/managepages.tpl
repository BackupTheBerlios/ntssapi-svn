{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe()
{ldelim}
	if (document.frmPage.txttitle.value == '' || document.frmPage.txtkey.value == '' ){ldelim}
		alert("{$lang.errormsgs[20]}");
		return false;
	{rdelim}
	return true;
{rdelim}
/* ]]> */
</script>
<script type="text/javascript">
/* <![CDATA[ */
  _editor_url = '../javascript/htmlarea/';
  _editor_lang = 'en';
/* ]]> */
</script>

{literal}
<script type="text/javascript" src="../javascript/htmlarea/htmlarea.js"></script>
<script type="text/javascript" src="../javascript/htmlarea/dialog.js"></script>
<script type="text/javascript" src="../javascript/htmlarea/lang/en.js"></script>
{/literal}

<table width="575" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" /></td>
		<td class="module_head" width="498">{$lang.manage_pages}</td>
	</tr>
</table>
<table width="575" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" align="center">
				<tr><td>{if $error_msg ne ""}<font color="red">{$error_msg}</font>{/if}</td></tr>
				<tr>
					<td>
            <form method="post" action="" name="frm1">
						<table border="0">
							<tr><td width="45">{$lang.page}</td>
								<td><select name="txtpage" onchange="javascript: document.frm1.submit();"><option value="0" {if $curpage == '0'}selected="selected"{/if}>{$lang.addnew}</option>{html_options options=$pagedata selected=$curpage}</select></td>
							</tr>
						</table>
            </form>
					{if $curpage == '0' or $curpage == ''}
            <form method="post" action="savepage.php" name="frmPage">
						<table border="0">
							<tr><td width="45">{$lang.pagetitle}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
								<td width="525"><input type="text" name="txttitle" size="25" maxlength="100" value="{$pagerec.title|stripslashes}" /></td>
							</tr>
							<tr><td width="45">{$lang.pagekey}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
								<td width="525"><input type="text" name="txtkey" size="25" value="{$pagerec.pagekey|stripslashes}" />&nbsp;{$lang.pagekey_help}</td>
							</tr>
							<tr><td colspan="2">
								<textarea name="txtbody" id="txtbody" style="width:550px;height:300px;">{$pagerec.pagetext|stripslashes|escape:htmlall}</textarea></td>
							</tr>
							<tr><td colspan="2" align="center">
								<input type="submit" class="formbutton" value="{$lang.addpage}" onclick="return checkMe();" />
								</td>
							</tr>
						</table>
            </form>
					{else}
            <form method="post" action="modifypage.php" name="frmPage">
              <input type="hidden" name="pageid" value="{$pagerec.id}" />
						<table border="0">
							<tr><td width="45">{$lang.pagetitle}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
								<td width="525"><input type="text" name="txttitle" size="25" value="{$pagerec.title|stripslashes}" /></td>
							</tr>
							<tr><td width="45">{$lang.pagekey}<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
								<td width="525"><input type="text" name="txtkey" size="25" value="{$pagerec.pagekey|stripslashes}" />&nbsp;{$lang.pagekey_help}</td>
							</tr>
							<tr><td colspan="2">
								<textarea name="txtbody" id="txtbody" style="width:550px;height:300px;">{$pagerec.pagetext|stripslashes|escape:htmlall}</textarea>
								</td>
							</tr>
							<tr><td colspan="2" align="center">
								<input type="submit" class="formbutton" value="{$lang.modpage}" onclick="return checkMe();" /></td>
							</tr>
						</table>
            </form>
					{/if}
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<script type="text/javascript">
/* <![CDATA[ */
	enableWYSIWYG('txtbody');
/* ]]> */
</script>
{/strip}