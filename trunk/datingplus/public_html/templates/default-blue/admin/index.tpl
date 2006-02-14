<?xml version="1.0" encoding="{$lang.ENCODING}"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
{strip}
<head>

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

	<title>{$lang.title}</title>
	<link href="{$css_path}default.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../javascript/functions.js"></script>
	<script type="text/javascript" src="../javascript/check.js"></script>
	<script type="text/javascript" src="../javascript/validate.js"></script>
	<script type="text/javascript" src="../javascript/editor.js"></script>
	<meta http-equiv="Content-Type" content="text/html; charset={$lang.ENCODING}" />
</head>
<body bgcolor="{$config.bgcolor}" text="{$config.textcolor}" dir="{$lang.DIRECTION}">
<center>
<table width="779" border="0" cellpadding="0" cellspacing="0" class="loginbarbg">
	<tr>
		<td height="33" width="154"><img src="{$image_dir}top_blue.jpg" alt="" /></td>
		<td height="33" width="625">
			<span class="admin_head">{$lang.admin_login_title|stripslashes}  / <a href="{$docroot}index.php">{$lang.home_title|stripslashes}</a></span>
		</td>
	</tr>
</table>
<table class="table" cellspacing="9" cellpadding="0" width="779" border="0">
	<tr>
{if $smarty.session.AdminId == '' }
		<td valign="top" align="center" colspan="2">
			<br /><br /><br /><br /><br /><br />
			<center>
      {if $login_error neq ""}
			<font color="{$lang.error_msg_color}">{$login_error}</font>
      {/if}
      <br/><br/>
				<table width="178" border="0" cellpadding="0" cellspacing="0" >
					<tr>
						<td class="module_detail" width="178" valign="top">

							<table width="178" border="0" cellpadding="0" cellspacing="0" style="height:23px">
								<tr>
									<td class="module_head" width="6"></td>
									<td class="module_head" width="150">
										{$lang.admin_login_msg}
									</td>
									<td width="22"><img src="{$image_dir}blue_small_hor.jpg" width="22" height="23" alt="" /></td>
								</tr>
							</table>
              <form name="frmlogin" method="post" action="midlogin.php">
							<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0">
								<tr>
									<td><span class='text8pt'>{$lang.signup_username}</span></td>
                  <td><input class="input" maxlength="25" name="txtusername" size="8" style='font-size:9pt;width:75px' /></td>
								</tr>
								<tr>
									<td><span class='text8pt'>{$lang.signup_password}</span></td>
									<td><input class="input" type="password" name="txtpassword" size="8" style='font-size:9pt;width:75px' /></td>
								</tr>
								<tr>
									<td></td>
									<td><input type="submit" value="{$lang.login_submit}" class='formbutton' /></td>
								</tr>
							</table>
            </form>
            <script type="text/javascript">
            /* <![CDATA[ */
              document.getElementsByName ("txtusername").item (0).focus ();
            /* ]]> */
            </script>
						</td>
					</tr>
				</table>
			</center>
		</td>
{else}
		<td valign="top" width="180">
			{include file="admin/panelmenu.tpl"}
		</td>
		<td width="577" valign="top">
			{$rendered_page}
		</td>
{/if}

	</tr>
	<tr>
		<td width='100%' align='center' colspan="2">
			<a href="http://www.tufat.com/osdate.php" target="_blank" class='copyright'>{$config.copyright}</a>
		</td>
	</tr>
</table>
</center>
</body>
</html>
{/strip}