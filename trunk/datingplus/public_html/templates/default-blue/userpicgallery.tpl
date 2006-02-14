{strip}
{if $config.use_popups == 'Y'}
{include file="popheader.tpl"}
{/if}
<table align="center" class="module_head" width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="77">
			<img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" />
		</td>
		<td align="left" class="module_head" width="663">
			&nbsp;{$username}'s Picture Gallery
		</td>
	</tr>
	<tr>
		<td colspan="2" class="module_detail" align="center" width="100%">
		<table width="100%" cellpadding="0" cellspacing="0">
		{if $err != ''}
			<tr><td colspan="2">&nbsp;</td></tr>
			<tr><td colspan="2" >
				<span class="errors">&nbsp;{$lang.errormsgs[$err]}<br />&nbsp;</span>
				</td>
			</tr>
		{/if}
		<tr><td colspan="2">
    <form name="album01" action="userpicgallery.php" method="post" >
      <input type="hidden" name="username" value="{$username}"/>
      <input name="id" type="hidden" value="{$userid}"/>
			<table cellpadding="0" cellspacing="0" width="100%">
				<tr><td>&nbsp;</td></tr>
				<tr>
					<td width="6">&nbsp;</td>
					<td >{$lang.album_hdr}:&nbsp;&nbsp;
						<select name="album_id" >
						<option value="" selected>{$lang.public}</option>
						{foreach from=$useralbums item=album}
						<option value="{$album.id}" {if $album.id== $album_id} selected {/if}>{$album.name}</option>
						{/foreach}
						</select>
						{if $smarty.session.UserId != $userid }
							&nbsp;&nbsp;&nbsp;
							{$lang.signup_password}&nbsp;
							<input name="album_passwd" type="password" size="15"/>
						{else}
							<input name="album_passwd" type="hidden" value='' size="15"/>
						{/if}
						&nbsp;&nbsp;
						<input type="submit" value="{$lang.show}"/>
						&nbsp;&nbsp;
						{if $smarty.session.expired != 1 and $smarty.session.active == '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') and $smarty.session.security.uploadpicture == 1  and $smarty.session.security.uploadpicturecnt > 0 and $userid == $smarty.session.UserId}
						<a class="panellink" href=";" onClick="javascript: opener.location='uploadsnaps.php'; window.close();" >{$lang.upload_pictures}</a>
						{/if}						
					</td>
				</tr>
				<tr><td>&nbsp;</td></tr>
			</table>
    </form>
			</td>
		</tr>
		{if $pics|count <= 0}
			<tr><td colspan="2">&nbsp;</td></tr>
			<tr><td colspan="2" >
				<span class="errors">&nbsp;{$lang.errormsgs[82]}<br />&nbsp;</span>
				</td>
			</tr>
		{else}
			<tr>
				<td align="center">
					{foreach item=pic from=$pics}
						<a href="getsnap.php?id={$userid}&amp;picid={$pic.picno}&amp;typ=pic&amp;album_id={$album_id}" target="MemberFullPic">
						<img src="getsnap.php?id={$userid}&amp;typ=tn&amp;picid={$pic.picno}&amp;album_id={$album_id}" alt="{$username}'s picture # {$pic.picno}" border="0" class="smallpic" /></a>&nbsp;
					{/foreach}
				</td>
			</tr>
			<tr><td><hr size="2" /></td></tr>
			<tr>
				<td align="center" valign="top" >
				<center>
				<iframe src="getsnap.php?id={$userid}&amp;picid={$pics.0.picno}&amp;typ=pic&amp;album_id={$album_id}" name="MemberFullPic" align="center" scrolling="auto" frameborder="0" width="625" height="590" >
				<center>Sorry, your browser doesn't support iframes.</center>
				</iframe>
				</center>
				</td>
			</tr>
		{/if}
		</table>
		</td>
	</tr>
</table>
{if $config.use_popups == 'Y'}
{include file="popfooter.tpl"}
{/if}
{/strip}