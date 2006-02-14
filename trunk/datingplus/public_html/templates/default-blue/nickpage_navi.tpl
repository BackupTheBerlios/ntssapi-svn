{strip}
{if isset($smarty.session.UserId) && $smarty.session.UserId != '' && $smarty.session.UserId != $user.id }

	<table cellspacing="0" cellpadding="4" border="0" width="100%">
		<tr>
			<td class="footer" align="center">
			{if $smarty.session.security.seepictureprofile == 1 or ( $smarty.session.UserId != '' && $smarty.session.UserId == $user.id) }
				<a href="#" onClick="javascript:popUpWindow('userpicgallery.php?id={$user.id}','center',600,600);" class="footerlink">{$lang.pic_gallery}</a>&nbsp;
				{assign var=found value=true}
			{/if}
			{if $smarty.session.security.message == 1 && $user.id != $smarty.session.UserId}
  				{if $found}|{/if}&nbsp;<a href="#" onClick="javascript: use_popups = true; popUpWindow('compose.php?recipient={$user.id}','center',350,200);" class="footerlink">{$lang.send_mail}</a>&nbsp;
  				{assign var=found value=true}
			{/if}
			{if $smarty.session.security.sendwinks == 1}
				{if $found}|{/if}&nbsp;<a href="#" onclick="javascript:window.location='sendwinks.php?ref_id={$user.id}&amp;rtnurl=showprofile.php';" class="footerlink">{$lang.send_wink}</a>&nbsp;
				{assign var=found value=true}


			{/if}
			{if $smarty.session.security.favouritelist == 1}
				{if $found}|{/if}&nbsp;
<a href="#" onclick="javascript:window.location='buddybanlist.php?act=buddy&amp;ref_id={$user.id}&amp;rtnurl=showprofile.php';" class="footerlink">{$lang.addtobuddylist}</a>



				&nbsp;|&nbsp;<a href="#" onclick="javascript:window.location='buddybanlist.php?act=ban&amp;ref_id={$user.id}&amp;rtnurl=showprofile.php';" class="footerlink">{$lang.addtobanlist}</a>
				&nbsp;|&nbsp;<a href="#" onclick="javascript:window.location='buddybanlist.php?act=hot&amp;ref_id={$user.id}&amp;rtnurl=showprofile.php';" class="footerlink">{$lang.addtohotlist}</a>
			{/if}
			</td>
		</tr>
	</table>

{/if}
{/strip}