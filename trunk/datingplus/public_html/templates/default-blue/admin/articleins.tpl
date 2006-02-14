{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkMe()
{ldelim}
	if (document.frmArticle.txttitle.value == '' ){ldelim}
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
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">
		<table><tr class="table_head"><td><a href="managearticle.php" class="subhead">{$lang.manage_article}</a></td></tr></table>
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
						{$lang.insert_article}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			<table width="550" border="0" align="center" cellpadding="0" cellspacing="0" >
				<tr><td>{if $error_msg neq ""}<font color="red">{$error_msg}</font>{/if}</td></tr>
				<tr>
					<td>
            <form method="post" name="frmArticle" action="savearticle.php">
						<table border="0" cellpadding="1" cellspacing="2" >
							<tr><td>{$lang.article_title}:<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font></td>
							<td><input type="text" name="txttitle" id="txttitle" size="50" value="{$smarty.session.txttitle}" /></td></tr>
							<tr><td>{$lang.dat}</td><td>
							  	{html_select_date_translated prefix="txt"  end_year="+5" month_value_format="%B" time=$smarty.session.artcldate}
								</td>
							</tr>
							<tr><td colspan="2"><textarea name="txttext" id="txttext" style="width:550px;height:300px;">{$smarty.session.txttext|escape:htmlall}</textarea></td>
							</tr>
							<tr><td colspan="2" align="center"><input type="submit" class="formbutton" value="{$lang.submit}" onclick="return checkMe();" /></td>
							</tr>
						</table>
          </form>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</center>
<br /><br />
<script type="text/javascript">
/* <![CDATA[ */
	enableWYSIWYG('txttext');
/* ]]> */
</script>
{/strip}