{strip}
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
		<table><tr class="table_head"><td><a href="managestory.php" class="subhead">{$lang.manage_story}</a></td></tr></table>
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
						{$lang.modify_story}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			<table width="550" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr><td>{if $error_msg ne ""}<font color="red">{$error_msg}</font>{/if}</td></tr>
				<tr>
					<td>
					<form method="post" action="modifystory.php">
            <input type="hidden" name="id" value="{$story.storyid}" />
					<table width="550" border="0" align="center" cellpadding="1" cellspacing="2">
						<tr><td>{$lang.news_header}:</td><td><input type="text" name="txttitle" size="50" value="{$story.header|stripslashes}" /></td></tr>
						<tr><td>{$lang.dat}</td><td>
						  	{html_select_date_translated prefix="txt"  time=$story.date|date_format end_year="+5" month_value_format="%B"}
							</td>
						</tr>
						<tr><td>{$lang.story_sender}:</td>
							<td><select name="txtsender">{html_options options=$users selected=$story.sender}</select>
							</td>
						</tr>
						<tr><td colspan="2">
							<textarea name="txttext" id="txttext" style="width:550px;height:300px;">{$story.text|stripslashes|escape:htmlall}</textarea></td>
						</tr>
						<tr><td colspan="2" align="center">
							<input type="submit" class="formbutton" value="{$lang.modify}" />&nbsp;
					<input type="reset" class="formbutton" value="{$lang.reset}" /></td>
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
