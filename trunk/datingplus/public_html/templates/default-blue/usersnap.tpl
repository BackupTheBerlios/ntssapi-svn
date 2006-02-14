{strip}
<script type="text/javascript">
/* <![CDATA[ */
function conDelete(picno,typ){ldelim}

	if( confirm('{$lang.admin_js_error_msgs[2]}') )

		document.location='?del=yes&picno=' + picno + '&typ=' + typ ;
{rdelim}
function validate( form ){ldelim}

	imgSrc = form.txtimage.value;
	tnSrc = form.tnimage.value;
	if( imgSrc == '' && tnSrc == '') {ldelim}
		alert('{$lang.errormsgs[28]}');
	{rdelim} else {ldelim}
		imgExt =imgSrc.substr( imgSrc.lastIndexOf('.')+1 );
		tnExt = tnSrc.substr( imgSrc.lastIndexOf('.')+1 );

		exts = ' {$config.upload_snap_ext}';

		if ( ( imgExt != '' && exts.indexOf(imgExt) == -1) && ( tnExt != '' &&  exts.indexOf(tnExt) == -1) ) {ldelim}
			alert('{$lang.errormsgs[29]}');
		{rdelim}
		else {ldelim}
			form.submit();
		{rdelim}
	{rdelim}
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
					{$lang.upload_pictures}
					</td>
				</tr>
			</table>

			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%">
			{if $smarty.get.msg ne ""}
				<tr>
					<td class="errors">{$lang.errormsgs[$smarty.get.msg]}</td>
				</tr>
				<tr><td>&nbsp;</td></tr>
			{/if}
				<tr>
					<td width="100%">
						{$lang.upload_format_msgs}&nbsp;&nbsp;&nbsp;{$lang.maxsize}: {$maxsize}<br /><br />
						{section name="sec" loop=$max_picture_cnt+1 start="1" step="1"}
						<form method="post" name="loadFrm{$smarty.section.sec.index}" action="savesnap.php" enctype="multipart/form-data" >
						<input type="hidden" name="txtpicno" value="{$smarty.section.sec.index}"/>

						<table width="100%" border="0" cellpadding="0" cellspacing="0" >
							<tr>
								<td class="module_detail_inside" width="100%">

									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td class="module_head" width="6"></td>
											<td class="module_head" >
											{$lang.picture}&nbsp;{$smarty.section.sec.index}
											</td>
											<td width="22"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
										</tr>
									</table>
									<table class="table" cellspacing="0" cellpadding="0" width="100%" border="0">
										<tr><td align="center" width="50%" valign="middle" height="20">
											<span class="text_head2">{$lang.upload_picture_caption|replace:':':''}</span>
											</td>
											<td align="center" width="50%" valign="middle" height="20" >
											<span class="text_head2">{$lang.upload_thumbnail_caption|replace:':':''}</span>
											</td>
										</tr>
										<tr>
											<td align="center" width="50%">
											<img src="getsnap.php?picid={$smarty.section.sec.index}&amp;typ=pic&amp;width={$config.disp_snap_width}&amp;height={$config.disp_snap_height}" class="smallpic" alt="" /><br />
											</td>
											<td align="center" width="50%">
											<img src="getsnap.php?picid={$smarty.section.sec.index}&amp;typ=tn" class="smallpic" alt="" /><br />
											</td>
										</tr>
										<tr><td colspan="2">&nbsp;</td></tr>
										<tr>
											<td align="center" width="50%" valign="bottom" >
											<input type="file" name="txtimage"/>&nbsp;
											</td>
											<td align="center" width="50%" valign="bottom" >												<input type="file" name="tnimage"/>&nbsp;
											</td>
										</tr>
										<tr><td colspan="2">&nbsp;</td></tr>
									{if $smarty.session.security.allowalbum == '1'}
										{*
										Process the album name portion and
										password acceptance
										*}
										<tr><td colspan="2">
											<table cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td width="6">&nbsp;</td>
													<td >{$lang.album_hdr}:&nbsp;&nbsp;
														<select name="album_id">
														<option value="0" selected>{$lang.public}</option>
														{foreach from=$useralbums item=album}
														<option value="{$album.id}" {if $album.id==$data[$smarty.section.sec.index].album_id} selected {/if}>{$album.name}</option>
														{/foreach}
														</select>
														&nbsp;&nbsp;{$lang.or}&nbsp;{$lang.addnew}:&nbsp;
														<input name="album_name" size="12" maxlength="25" type="text"/>
														&nbsp;
														{$lang.signup_password}&nbsp;
														<input name="album_passwd" type="password" size="12"/>
														{if $data[$smarty.section.sec.index].picture ne ''}												&nbsp;<input type="submit" name="changealbum" value="{$lang.change_album}" class="formbutton"/>
														{/if}
													</td>
												</tr>
											</table>
											</td>
										</tr>
									{/if}
										<tr><td colspan="2">&nbsp;</td></tr>
										<tr>
											<td align="center" width="50%">
											<input type="hidden" name="uploadtypeloadFrm{$smarty.section.sec.index}" id="uploadtypeloadFrm{$smarty.section.sec.index}" value="" />
											{if $data[$smarty.section.sec.index].picture ne ''}
											<input type="button" onclick="javascript:popUpWindow('imgEditor/index.php?status=start&amp;typ=pic&amp;picno={$smarty.section.sec.index}', 'center', 615, 450)" value="{$lang.edit_pict}" class="formbutton"/>&nbsp;
											<input type="button" onclick="javascript:conDelete('{$smarty.section.sec.index}','pic')" value="{$lang.delete}" class="formbutton"/>&nbsp;
											{/if}
											<input type="button" value="{$lang.upload}" onclick="javascript: document.getElementById('uploadtypeloadFrm{$smarty.section.sec.index}').value='pic'; validate(this.form)" class="formbutton"/>
											</td>
											<td align="center" width="50%">
											{if $data[$smarty.section.sec.index].tnpicture ne ''}
											<input type="button" onclick="javascript:popUpWindow('imgEditor/index.php?status=start&amp;typ=tn&amp;picno={$smarty.section.sec.index}', 'center', 615, 450)" value="{$lang.edit_thmpnail}" class="formbutton"/>&nbsp;
											<input type="button" onclick="javascript:conDelete('{$smarty.section.sec.index}','tn')" value="{$lang.delete}" class="formbutton"/>&nbsp;
											{/if}
											<input type="button" value="{$lang.upload}" onclick="javascript: document.getElementById('uploadtypeloadFrm{$smarty.section.sec.index}').value='tn'; validate(this.form)" class="formbutton"/>
											</td>
										</tr>
										<tr><td colspan="2">&nbsp;</td></tr>
									</table>
								</td>
							</tr>
						</table>
						</form>
						{/section}
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{/strip}
