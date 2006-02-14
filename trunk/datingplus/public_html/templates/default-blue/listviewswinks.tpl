{strip}

<table width="571" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="494">
			{if $act eq 'V'}
				{$lang.listofviews}
			{elseif $act eq 'W'}
				{$lang.listofwinks}
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

			<table class="table" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="550" border="0">
			<tbody>
			{if $errid ne ''}
				<tr><td colspan="3"><font class="errors">{$lang.errormsgs[$errid]}</font></td></tr>
				<tr><td colspan="3">&nbsp;</td></tr>
			{/if}
			{if $list|@count eq 0 }
				<tr>
					<td colspan="3">{$lang.no_record_found}</td>
				</tr>
			{else}
				<form name="listviewwinksFrm" action="listviewswinks.php" method="post">
				<tr class="table_head">
					<th ><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)"/></th >
					<th >{$lang.col_head_srno}</th>
					<th >{$lang.username_hdr}</th>
					<th >{$lang.col_head_sendtime}</th>
					<th >{$lang.action}</th>
				</tr>
				<input type="hidden" name="act" value="{$act}"/>
				{assign var="mcount" value="0"}
				{foreach item=item key=key from=$list}
					{math equation="$mcount+1" assign="mcount"}
					<tr class="{cycle  values="oddrow,evenrow"}">
						<td width="5%" align="center">
							<input type="checkbox" name="txtcheck[]" value="{$item.id}"/></td>
						<td width="5%">{$mcount}</td>
						<td width="50%">{if $config.use_profilepopups != 'Y'}<a href="javascript:popUpScrollWindow2('showprofile.php?id={$item.ref_userid}','top',650,screen.height)">{$item.username}</a>{else}<a href="javascript:popUpScrollWindow('showprofile.php?id={$item.ref_userid}','top',650,screen.height)">{$item.username}</a>{/if}</td>
						<td width="30%">{$item.act_time|date_format:$lang.DATE_FORMAT}</td>
						<td width="10%">
						<a href="listviewswinks.php?id={$item.id}&amp;remove=1&amp;act={$act}"><input name="rem" value="{$lang.Remove}" type="button" class="formbutton"/></a>
						</td>
					</tr>
				{/foreach}
				<tr>
					<td colspan="4" align="left">
						<img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
						<input type="submit" class="formbutton" value="{$lang.delete_selected}" name="groupaction"/>
					</td>
				</tr>
				</form>
			{/if}
			</tbody>
			</table>
		</td>
	</tr>
</table>
</center>
{/strip}
