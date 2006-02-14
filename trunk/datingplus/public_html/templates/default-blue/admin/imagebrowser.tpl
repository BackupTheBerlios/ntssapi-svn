{strip}
<script type="text/javascript">
/* <![CDATA[ */
{literal}
function confdel(img){
	if(img !=''){
		var cf = confirm('Are you sure to delete this Image?');
		if(cf){
			document.frmupload.delimg.value = img;
			document.frmupload.submit();
		}
	}
	else{
		alert("Please select the image first.");
	}
}
function showimage(img){
	if(img !=''){
		window.open('../emailimages/'+img);
	}
	else{
		alert("Please select the image first.");
	}
}
{/literal}
/* ]]> */
</script>

<form name="frmupload" action="" method="post" enctype="multipart/form-data">
  <input type="hidden" name="delimg" value="" />
  <input type="hidden" name="cmd" value="imgposted" />
  <input type="hidden" name="page" value="" />
<table width="380" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td valign="top"  class="module_detail_inside">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="374">
					{$lang.image_browser}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			<table border="0" width="100%">
				<tr>
					<td>
						<select name="imgfiles" size="5" style="width:370px" onchange="javascript:txtfileurl.value='{$base_url}emailimages/'+imgfiles.value; document.getElementById('files_to_attach').value +=imgfiles.value+',';">
							{html_options values=$images output=$images}
						</select>
					</td>
				</tr>
				<tr>
					<td>
					<input type="file" name="picfile" size="28" />&nbsp;
					<input type="submit" class="formbutton" value="{$lang.upload_image}" />
					</td>
				</tr>
				<tr>
					<td align="center">
					<input type="button" class="formbutton" value="{$lang.show_image}" onclick="javascript:showimage(imgfiles.value);" />&nbsp;
					<input type="button" class="formbutton" value="{$lang.delete_image}" onclick="javascript:confdel(imgfiles.value);" />
					</td>
				</tr>
				<tr>
					<td>
						<input type="text" size="60" name="txtfileurl" value="" />
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</form>

{/strip}