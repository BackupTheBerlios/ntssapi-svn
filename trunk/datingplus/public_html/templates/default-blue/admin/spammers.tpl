{strip}
<script language="JavaScript" type="text/javascript">

function confdel(form){ldelim}
	if (confirm("{$lang.admin_js__delete_error_msgs[18]}")) {ldelim}
		document.frm.delete_selected.value="{$lang.delete_selected}";
		form.submit();
	{rdelim}else{ldelim}
		return false;
	{rdelim}
{rdelim}

function confirmDelete(profileid,conmsg)
{ldelim}
	if (confirm(conmsg)){ldelim}
		frmDelProfile.txtdelete.value=profileid;
		frmDelProfile.submit();
	{rdelim}
{rdelim}
</script>

<TABLE WIDTH=573 BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg?{$smarty.now}" width="77" height="25"></td>
		<td class="module_head" width="496">Spammers</td>
	</tr>
	<form name="frmDelProfile" action="spammers.php" method="get">
		<input type="hidden" name="txtdelete" value="">
		<input type="hidden" name="frm" value="frmDelProfile">
	</form>
</TABLE>
<BR />
<CENTER>
<TABLE WIDTH=553 BORDER=0 CELLPADDING=0 CELLSPACING=0 >
	<tr>
		<td  width="100%" class="module_detail_inside">			
			<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0 height="23">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="524">
						Spammers
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg?{$smarty.now}" width="28" height="23"></td>
				</tr>
			</TABLE>
			<table class=table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border=0>

			{foreach item=item from=$spammers}

				<tr align="center" class="table_head">
					<th width="30%">Username:&nbsp;{$item.username}</th>
					<th width="30%">Date:&nbsp;{$item.send_time}</th>
					<th width="30%">Copies:&nbsp;{$item.copies}</th>
					<th width="10%"><a href="javascript:confirmDelete({$item.id},'{$lang.admin_js__delete_error_msgs[4]}')"><img src="images/button_drop.png" alt="Delete" border="0"></a></th>
				</tr>

				<tr>
					<td colspan=4> {$item.message} </td>
				</tr>

				<tr>
					<td colspan=4> <hr> </td>
				</tr>

			{/foreach}
			</table>
		</TD>
	</TR>
</TABLE>
</center>
<BR />
{/strip}
