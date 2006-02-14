{strip}
<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="23" /></td>
		<td class="module_head" width="496">
			<table>
				<tr class="table_head">
					<td class="module_head">
						<a href="section.php" class="subhead">{$lang.section_title}</a>
						&nbsp;<span class="subhead">></span>
						&nbsp;<a href="sectionquestions.php?sectionid={$smarty.get.sectionid}" class="subhead">{$lang.questions_title}</a>
						&nbsp;<span class=subhead>></span>&nbsp;
						<a href="sectionquestiondetail.php?sectionid={$smarty.get.sectionid}&amp;questionid={$option.questionid}" class="subhead">{$lang.options_title}</a>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</TABLE>
<BR />
<CENTER>
<TABLE WIDTH=550 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td class="module_detail_inside" width="100%">
			<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 >
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.modify_option}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" /></td>
				</tr>
			</TABLE>
			<form name="frmOptionEdit" method="post"  action="modifyoption.php">
			<input type="hidden" name="txtsectionid" value="{$smarty.get.sectionid}" />
			<table class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border=0 >
			{ if $error != ''}
				<tr>
					<td colspan="2"><font color="{$lang.admin_error_color}">{$error}</font></td>
				</tr>
				<tr>
					<td> &nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			{/if}
				<tr>
					<td>{$lang.id}</td>
					<td>{$option.id}<input type="hidden" name="txtid" value="{$option.id}" /></td>
				</tr>
				<tr>
					<td>{$lang.answer}</td>
					<td><input name="txtanswer" type="text" value="{$option.answer|stripslashes}" /></td>
				</tr>
				<tr>
					<td>{$lang.enabled}</td>
					<td><select name="txtenabled" >
						<option value="Y" {if $option.enabled == 'Y'} selected {/if}>{$lang.yes} </option>
						<option value="N" {if $option.enabled != 'Y'} selected {/if} >{$lang.no}</option>
						</select>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<input name="txtsave" type="submit" class="formbutton" value="{$lang.submit}" />&nbsp;			  
						<input name="txtreset" type="reset" class="formbutton" value="{$lang.reset}" />
					</td>
				</tr>
			</table>
			</form>
		</TD>
	</TR>
</TABLE>
</center>
{/strip}