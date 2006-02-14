{strip}
<script type="text/javascript" src="../javascript/check.js"></script>
<script type="text/javascript">
/* <![CDATA[ */
{literal}
function confdel(form,errmsg){
	for(i=0;i < form.length;i++){
		if(form.elements[i].type=='checkbox' && form.elements[i].checked == true){
			selected = true;
			break;
		}
		else {
			selected = false;
		}
	}
	if(!selected) {
		alert(errmsg);
		return false;
	}else{
		form.submit();
		return true;
	}
}
function confirmDelete(sectionid,conmsg,form)
{
	if (confirm(conmsg)){
		form.txtid.value=sectionid;
		form.submit();
	}
}
{/literal}
/* ]]> */
</script>
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.manage_banners}</td>
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
					{$lang.total_banner}&nbsp; {$data|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
      <form name="frmGroupBanner" action="managebanner.php" method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
        <input type="hidden" name="txtid" />
			<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550">
				<tr>
					<td colspan="7"><span class='modulehead'><a href="addbanner.php">{$lang.add_banners}</a></span></td>
				</tr>
			    <tr class="table_head">
					<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtcheck[]',this.checked)" /></th>
					<th align="center">{$lang.col_head_srno}</th>
					<th align="center">{$lang.size_px}</th>
					<th align="center">{$lang.clicks}</th>
					<th align="center">{$lang.col_head_enabled}</th>
					<th colspan="2" align="center">{$lang.action}</th>
				</tr>
				{assign var="mcount" value="0"}
			{foreach item=item key=key from=$data}
				{math equation="$mcount+1" assign="mcount"}
				<tr class="oddrow">
					<td align="center"><input type="checkbox" name="txtcheck[]" value="{$item.id}" /></td>
					<td align="center">{$mcount}</td>
					<td align="center">{$item.size}</td>
					<td align="center">{$item.clicks}</td>
					<td align="center">{$item.enabled}</td>
					<td colspan="2" align="center"><a href="?edit={$item.id}"><img src="images/button_edit.png" alt="Edit" border="0" /></a>&nbsp;
            <a href="#" onclick="javascript:confirmDelete({$item.id},'{$lang.admin_js__delete_error_msgs[10]}', document.frmGroupBanner)"><img src="images/button_drop.png" alt="Delete" border="0" /></a></td>
				</tr>
				<tr class="evenrow">
					<td colspan="7" align="center">
						<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550">
							<tr>
								<td  align="center">
									<center>
									{if $item.type == 'jpg' || $item.type == 'gif' || $item.type == 'bmp'|| $item.type == 'png' }
										<img src="{$banner_dir}{$item.name}" width="{$item.width}" height="{$item.height}" alt="" />
										<br /><a href="{$item.linkurl}" target="_blank">{$item.linkurl}</a>
									{else}
                  <object {if $smarty.session.browser neq "MOZILLA"}classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"{/if} data="{$banner_dir}{$item.name}">
										<param name='movie' value="{$banner_dir}{$item.name}">
										<param name='quality' value='high'>
                  </object>
										<br /><a href="http://{$item.linkurl}" target="_blank">{$item.linkurl}</a>
									{/if}
									</center>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			{/foreach}
				<tr>
		 			<td align="left" colspan="7">
		 				<img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
		 				<input type="submit" class="formbutton" value="{$lang.enable_selected}" name="enable" />&nbsp;
		 				<input type="submit" class="formbutton" value="{$lang.disable_selected}" name="disable" />
		 			</td>
				</tr>
			</table>
    </form>
		</td>
	</tr>
</table>
</center>
<br />
{/strip}