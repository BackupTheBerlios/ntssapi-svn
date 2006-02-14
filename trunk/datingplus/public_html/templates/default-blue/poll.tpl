{strip}
<script type="text/javascript">
/* <![CDATA[ */
function checkfornull(frm)
{ldelim}
	var val = frm.elements['txtquestion'].value;
	if (val == "")
	{ldelim}
		alert("{$lang.signup_js_errors.question_noblank}");
		return false;
	{rdelim}
	return true;
{rdelim}
/* ]]> */
</script>
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.suggest_poll}
					</td>
				</tr>
			</table>
        <form name="question" action="poll.php" method="post" onsubmit="javascript: return checkfornull(this);">
			<table class="table" cellspacing="{$config.cellspacing}"  cellpadding="{$config.cellpadding}">
				{if $error_msg != ''}
				<tr>
					<td colspan="2">
					<br />
						<font color="{$lang.error_msg_color}">{$error_msg}&nbsp;</font>
					<br />
					</td>
				</tr>
				{/if}
				<tr>
					<td colspan="2"></td>
				</tr>
				<tr>
					<td width="10%">
						{$lang.col_head_question}:
					</td>
					<td width="90%">
						<input type="text" name="txtquestion" value="{$txtquestion|stripslashes}" size="60" maxlength="250" {if $step eq 2}readonly="readonly"{/if}/>
					</td>
				</tr>
				<tr>
					<td colspan="2"></td>
				</tr>
				<tr>
					<td colspan="2" width="100%">
						<table class="table" cellspacing="0"  cellpadding="0">
							<tr>
								<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
								<td class="module_head" width="494">
									{$lang.poll_options}:
								</td>
							</tr>
						</table>
						<table class="table" cellspacing="{$config.cellspacing}"  cellpadding="{$config.cellpadding}">
							<tr>
								<td colspan="2">&nbsp;</td>
							</tr>
							<tr class="table_head">
								<th width="5%">{$lang.col_head_srno}</th>
								<th width="95%">{$lang.option}</th>
							</tr>
							{if $txtoptions|@count > 0}
							{assign var="mcount" value="0"}
							{assign var="classtype" value="oddrow"}
							{foreach name=pollopts key=idx from=$txtoptions item=opt}
							{math equation="$mcount+1" assign="mcount"}
								<tr class="classtype">
									<td width="5%">{$mcount}</td>
									<td width="95%"><input name="txtoptions[]" value="{$opt|stripslashes}" {if $saved eq 1}readonly{/if} size="80"/></td>
								</tr>
								{if $classtype eq "oddrow"}
								{assign var="classtype" value="evenrow"}
								{else}
								{assign var="classtype" value="oddrow"}
								{/if}
							{/foreach}
							{else}
								{math equation="$mcount+1" assign="mcount"}
								<tr class="classtype">
									<td width="5%">{$mcount}</td>
									<td width="95%"><input name="txtoptions[]" value="" size="80"/></td>
								</tr>
							{/if}
							{if $classtype eq "oddrow"}
							{assign var="classtype" value="evenrow"}
							{else}
							{assign var="classtype" value="oddrow"}
							{/if}
							{math equation="$mcount+1" assign="mcount"}
						{if $saved ne 1}
							<tr class="classtype">
								<td>{$mcount}</td>
								<td><input name="txtoptions[]" value="" size="80"/></td>
							</tr>
						{/if}
						</table>
					</td>
				</tr>
				{if $saved ne 1}
				<tr>
					<td colspan="2" align="center">
						<input name="action" value="{$lang.moreoptions}" type="submit" class="formbutton"/>&nbsp;
						<input name="action" value="{$lang.savepoll}" type="submit" class="formbutton"/>
					</td>
				</tr>
				{/if}
			</table>
        </form>
		</td>
	</tr>
</table>
{/strip}
