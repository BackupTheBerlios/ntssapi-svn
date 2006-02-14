<?xml version="1.0" encoding="{$lang.ENCODING}"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
{strip}
<head>
{if $config.site_title ne '' }
	<title>{$config.site_title}</title>
{else}
	<title>{$lang.title}</title>
{/if}

<script type="text/javascript">
/* <![CDATA[ */
{if $config.use_popups == 'N'}
var use_popups = false;
{else}
var use_popups = true;
{/if}
{if $config.use_profilepopups == 'N'}
var use_profilepopups = false;
{else}
var use_profilepopups = true;
{/if}
/* ]]> */
</script>


<link href="{$css_path}default.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="javascript/functions.js"></script>
<script type="text/javascript" src="javascript/check.js"></script>
<script type="text/javascript" src="javascript/validate.js"></script>

<script type="text/javascript">
/* <![CDATA[ */
function newvalidateLogin(form) {ldelim}
	if (form.txtusername.value == '') {ldelim}
		alert("{$lang.signup_js_errors.username_noblank}");
		return false;
	{rdelim}
	if (form.txtpassword.value == '') {ldelim}
		alert("{$lang.signup_js_errors.password_noblank}");
		return false;
	{rdelim}
{rdelim}
/* ]]> */
</script>

<meta http-equiv="Content-Type" content="text/html; charset={$lang.ENCODING}" />
<meta http-equiv="keywords" content="{$config.meta_keywords}" />
<meta http-equiv="description" content="{$config.meta_description}" />
</head>
<body text="{$config.textcolor}" dir="{$lang.DIRECTION}">
<center>
<!-- Header portion  -->
<table class="main_outer_table" cellspacing="0" cellpadding="0" width="779" border="0" >
	<tr>
		<td width="100%">
			<table width="779" border="0" cellpadding="0" cellspacing="0" class="headbg">
				<tr>
					<td width="3">&nbsp;</td>
					<td width="305" valign="bottom">
						&nbsp;<a href="index.php" class="main_title">{$lang.site_name|stripslashes}</a>
					</td>
					<td width="174" valign="top" align="center">
						<table width="174" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td>
									<img src="{$image_dir}b_02.jpg" width="58" height="52" alt="" /></td>
								<td>
									<img src="{$image_dir}b_03.jpg" width="58" height="52" alt="" /></td>
								<td>
									<img src="{$image_dir}b_04.jpg" width="58" height="52" alt="" /></td>
							</tr>
							<tr>
								<td>
									<img src="{$image_dir}b_13.jpg" width="58" height="52" alt="" /></td>
								<td>
									<img src="{$image_dir}b_14.jpg" width="58" height="52" alt="" /></td>
								<td>
									<img src="{$image_dir}b_15.jpg" width="58" height="52" alt="" /></td>
							</tr>
							<tr>
								<td>
									<img src="{$image_dir}b_16.jpg" width="58" height="52" alt="" /></td>
								<td>
									<img src="{$image_dir}b_17.jpg" width="58" height="52" alt="" /></td>
								<td>
									<img src="{$image_dir}b_18.jpg" width="58" height="52" alt="" /></td>
							</tr>
						</table>
					</td>
					<td width="49" valign="top"></td>
					<td width="236" valign="top">
						<table width="236" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td>
									<img src="{$image_dir}box_06.jpg" width="12" height="17" alt="" /></td>
								<td>
									<img src="{$image_dir}box_07.jpg" width="212" height="17" alt="" /></td>
								<td>
									<img src="{$image_dir}box_08.jpg" width="12" height="17" alt="" /></td>
							</tr>
							<tr>
								<td>
									<img src="{$image_dir}box_10.jpg" width="12" height="117" alt="" /></td>
								<td height="107" width="212" align="center" class="headbgbox">
									{include file="searchprofile.tpl"}
								</td>
								<td>
									<img src="{$image_dir}box_12.jpg" width="12" height="117" alt="" /></td>
							</tr>
							<tr>
								<td>
									<img src="{$image_dir}box_19.jpg" width="12" height="15" alt="" /></td>
								<td>
									<img src="{$image_dir}box_20.jpg" width="212" height="15" alt="" /></td>
								<td>
									<img src="{$image_dir}box_21.jpg" width="12" height="15" alt="" /></td>
							</tr>
					</table>
					</td>
				</tr>
			</table>
			<table width="779" border="0" cellpadding="0" cellspacing="0" class="loginbarbg">
				<tr>
					<td colspan="4" height="1" bgcolor="#A2863E"></td>
				</tr>
				<tr>
					<td height="33" width="154"><img src="{$image_dir}big_arrow.jpg" alt="" /></td>
					<td height="33" width="575">
						{if $smarty.session.UserId == ''}
              <form name="frmLogin" method="post" action="midlogin.php" onsubmit="javascript: return newvalidateLogin(this);" >
							<table width="100%" cellpadding="0" cellspacing="0" border="0">
								<tr>
									<td>
										<b>{$lang.members_login}</b>&nbsp;
										<img src="{$image_dir}blue_box.gif" width="2" height="10" alt="" />&nbsp;
										{$lang.signup_username}&nbsp;
										<input class="input" maxlength="25" name="txtusername" size="8" style='font-size:9pt;width:70px' />&nbsp;&nbsp;
										{$lang.signup_password}&nbsp;
										<input class="input" type="password" name="txtpassword" size="8" style='font-size:9pt;width:70px' />&nbsp;
										<input type="submit" value="{$lang.login_submit}" class='formbutton' />&nbsp;
										<a href='signup.php'>{$lang.register}</a>
									</td>
								</tr>
							</table>
              </form>
						{else}
							<strong>{$lang.welcome},&nbsp;{$smarty.session.FullName|stripslashes} &nbsp;({$smarty.session.UserName})</strong>
						{/if}
					</td>
					<td height="33" width="40" align="right" valign="middle">
					{if $smarty.session.security.extsearch == 1  and $smarty.session.expired != '1' and ( $smarty.session.status == $lang.status_enum.active or $smarty.session.status == 'Active') }
						<a href="extsearch.php"><img src="{$image_dir}search_icon.gif" border="0" width="18" height="18" alt="" /></a>&nbsp;
					{/if}
						<a href="index.php"><img src="{$image_dir}homepage_icon.gif" border="0" width="18" height="18" alt="" /></a>
					</td>
					<td height="33" width="10"></td>
				</tr>
			</table>

			<table width="779" border="0" cellpadding="0" cellspacing="5" >
				<tr>
<!-- Leftside Menu   -->
					<td width="178" valign="top">
						{include file="leftcolumn.tpl"}
					</td>
<!-- Rendered page -->
					<td width="601" valign="top">
						{$rendered_page}
					</td>
				</tr>
			</table>
<!--  Footer   -->
			<table cellspacing="0" cellpadding="0" width="779" border="0">
				<tr>
					<td width='100%' align='center' class="footer" height="25">
						{if $smarty.session.UserId <= 0}
							<a href='index.php?page=login' class='footerlink'>{$lang.site_links.login}</a> |&nbsp;
						{/if}
						{if $config.enable_mod_rewrite == 'Y'}
							<a href='privacy.html' class='footerlink'>{$lang.site_links.privacy}</a> |&nbsp;
							<a href='terms_of_use.html' class='footerlink'>{$lang.site_links.terms_of_use}</a> |&nbsp;
							<a href='services.html' class='footerlink'>{$lang.site_links.services}</a> |&nbsp;
							<a href='faq.html' class='footerlink'>{$lang.site_links.faq}</a> |&nbsp;
							<a href='articles.html' class='footerlink'>{$lang.site_links.articles}</a> |&nbsp;
						{else}
							<a href='index.php?page=privacy' class='footerlink'>{$lang.site_links.privacy}</a> |&nbsp;
							<a href='index.php?page=terms_of_use' class='footerlink'>{$lang.site_links.terms_of_use}</a> |&nbsp;
							<a href='index.php?page=services' class='footerlink'>{$lang.site_links.services}</a> |&nbsp;
							<a href='index.php?page=faq' class='footerlink'>{$lang.site_links.faq}</a> |&nbsp;
							<a href='index.php?page=articles' class='footerlink'>{$lang.site_links.articles}</a> |&nbsp;
						{/if}
						<a href='affindex.php' class='footerlink'>{$lang.site_links.affliates}</a> |&nbsp;
						<a href='javascript:launchTellFriend();' class='footerlink'>{$lang.site_links.invite_a_friend}</a>
		{* Feedback link depending on the option in global site settings *}
						{if ( $config.feedback_info == 'Y' && $smarty.session.UserId != '') or $config.feedback_info == 'N'}
							&nbsp;|&nbsp;
							<a href='feedback.php' class='footerlink'>{$lang.site_links.feedback}</a>
						{/if}
					</td>
				</tr>
				<tr><td width='100%' align='center' height="3"></td></tr>
				<tr>
					<td width='100%' align='center'>
						<a href="http://www.tufat.com/osdate.php" class='copyright' target="_blank">{$config.copyright}</a>
					</td>
				</tr>
				<tr><td width='100%' align='center' height="3"></td></tr>
			</table>
		</td>
	</tr>
</table>
</center>
</body>
</html>
{/strip}
