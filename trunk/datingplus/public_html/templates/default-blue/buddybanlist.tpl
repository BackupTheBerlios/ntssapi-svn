{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="494">
			{if $act eq 'F'}
				{$lang.buddylisthdr}
			{elseif $act eq 'B'}
				{$lang.banlisthdr}
			{elseif $act eq 'H'}
				{$lang.hotlisthdr}
			{/if}
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
					<td class="module_head" width="516">
						{$lang.total_profiles_found}&nbsp;{$list|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form name="buddybanFrm" action="buddybanlist.php" method="post">
			<table class="table" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="550" border="0">
			<tbody>
		{ if $errid ne '' }
				<tr>
					<td colspan="4"><font class="errors">{$lang.errormsgs.$errid}</font></td>
				</tr>
				<tr><td colspan="4">&nbsp;</td></tr>
		{ /if }
		{if $error == 1 }
				<tr>
					<td colspan="4">{$lang.no_record_found}</td>
				</tr>
				<tr><td colspan="4">&nbsp;</td></tr>
		{else}
			{ if $list }
				<tr class="table_head">
					<th width="5%"><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /><input type="hidden" name="act" value="{$act}" /></th >
					<th width="5%">{$lang.col_head_srno}</th>
					<th width="35%">{$lang.username_hdr}</th>
					<th width="30%">{$lang.col_head_sendtime} </th>
					<th width="25%">{$lang.action}</th>
				</tr>
				{assign var="mcount" value="0"}
				{foreach item=item key=key from=$list}
					{math equation="$mcount+1" assign="mcount"}
				<tr class="{cycle  values="oddrow,evenrow"}">
					<td width="5%" align="center">
						<input type="checkbox" name="txtcheck[]" value="{$item.lisid}" /></td>
					<td width="5%">{$mcount}</td>
					<td width="35%"><a href="javascript:popUpScrollWindow2('showprofile.php?id={$item.userid}','top',650,screen.height)">{$item.ref_username}</a></td>
					<td width="30%">{$item.act_date|date_format:$lang.DATE_FORMAT}</td>
					<td width="25%"><a onclick="javascript:window.location='buddybanlist.php?id={$item.lisid}&amp;act={$act}&amp;remove=1';"><input name="rem" value="{$lang.Remove}" type="button" class="formbutton" /></a>
					</td>
				</tr>
				{/foreach}
				<tr>
					<td colspan="4" align="left">
						<img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
						<input type="submit" class="formbutton" value="{$lang.delete_selected}" name="groupaction" />
					</td>
				</tr>
			{ else }
				<tr>
					<td colspan="3">{$lang.no_record_found}</td>
				</tr>
			{/if}
		{/if}
			</tbody>
			</table>
     </form>
		</td>
	</tr>
</table>
</center>
{/strip}
