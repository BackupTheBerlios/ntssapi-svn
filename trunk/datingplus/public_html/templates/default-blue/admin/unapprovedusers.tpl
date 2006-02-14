{strip}
<script type="text/javascript">
/* <![CDATA[ */
{literal}
function confdel(form,errmsg){
  for(i=0;i < form.length;i++){
    if(form.elements[i].type=='checkbox' && form.elements[i].checked == true){
      selected = true;
      break;
    }else
      selected = false;
  }
  if(!selected) {
    alert(errmsg);
    return false;
  }else{
    form.submit();
    return true;
  }
}

{/literal}
/* ]]> */
</script>
<form name="frmGroupSection" action="unapprovedusers.php" method="post" onsubmit="javascript: return confdel(this,'{$lang.admin_js_error_msgs[1]}');">
<table width="573" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
		<td class="module_head" width="496">{$lang.unapproved_user}</td>
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
						{$lang.total_profiles_found}&nbsp;{$data|@count}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="550" border="0">
			<tbody>
		{if $errid != ''}
				<tr>
					<td  colspan="8"><span class="errors">{$lang.errormsgs[$errid]}</span></td>
				</tr>
				<tr><td colspan="8">&nbsp;</td></tr>
		{/if}

    			<tr class="table_head">
	  				<th>{$lang.col_head_srno}</th>
	  				<th><input type="checkbox" name="chkall" value="" onclick="checkAll(this.form,'txtchk[]',this.checked)" /></th>
	  				<th><a href="?sort={$lang.col_head_username|escape:"url"}&amp;type={$sort_type}">{$lang.col_head_username}</a></th>
            <th><a href="?sort={$lang.col_head_firstname|escape:"url"}&amp;type={$sort_type}">{$lang.col_head_name}</a></th>
            <th><a href="?sort={$lang.col_head_register_at|escape:"url"}&amp;type={$sort_type}">{$lang.col_head_register_at}</a></th>
            <th><a href="?sort={$lang.col_head_gender|escape:"url"}&amp;type={$sort_type}">{$lang.col_head_gender}</a></th>
            <th><a href="?sort={$lang.col_head_email|escape:"url"}&amp;type={$sort_type}">{$lang.col_head_email}</a></th>
	  				<th>{$lang.action}</th>
				</tr>
			{if $error == 1}
				<tr>
					<td colspan="8">{$lang.no_record_found}</td>
				</tr>
			{else}
				{assign var="mcount" value="0"}
			{foreach item=item key=key from=$data}
				{math equation="$mcount+1" assign="mcount"}
				<tr class="{cycle values="oddrow,evenrow"}">
		  			<td>{$mcount}</td>
		  			<td><input type="checkbox" name="txtchk[]" value="{$item.id}" /></td>
		  			<td>{$item.username}</td>
		  			<td>{$item.firstname|stripslashes}&nbsp;{$item.lastname|stripslashes}</td>
		  			<td>{$item.regdate|date_format:$lang.DATE_FORMAT}</td>
		  			<td>{$lang.signup_gender_values[$item.gender]}</td>
		  			<td>{$item.email}</td>
		  			<td ><a href="profile.php?edit={$item.id}">Review</a></td>
				</tr>
			{/foreach}
			{/if}
				<tr>
		 			<td colspan="8"><img src="images/arrow_ltr.png" alt="" />{$lang.with_selected}&nbsp;
		 			{foreach key=key item=item1 from=$lang.status_disp}
		 			{if $item.status != $key}
		 				<input type="submit" class="formbutton" value="{$item1}" name="groupaction" />&nbsp;
					{/if}
					{/foreach}
		 			</td>
				</tr>
  			</tbody>
			</table>
		</td>
	</tr>
</table>
</center>
</form>
{/strip}
