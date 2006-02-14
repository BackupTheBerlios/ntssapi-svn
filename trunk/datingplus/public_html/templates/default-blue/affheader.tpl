<?xml version="1.0" encoding="iso-8859-1"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
{strip}
<head>
<title>{$lang.title}</title>
<link href="{$css_path}default.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
/* <![CDATA[ */
{if $config.use_popups == 'N'}
var use_popups = false;
{else}
var use_popups = true;
{/if}
/* ]]> */
</script>

<script language="JavaScript" type="text/javascript" src="../javascript/functions.js"></script>
<script language="JavaScript" type="text/javascript" src="../javascript/check.js"></script>
<script language="JavaScript" type="text/javascript" src="../javascript/validate.js"></script>

<meta http-equiv="Content-Type" content="text/html; charset={$lang.ENCODING}" />
</head>
<body bgcolor="{$config.bgcolor}" text="{$config.textcolor}" dir="{$lang.DIRECTION}">
<center>
	<table class="table" cellpadding="0" cellspacing="0" width="779" border="0">
		<tr>
			<td background={$image_dir}titlepic.jpg width="779" height="162">
				<table class="table" cellpadding="0" cellspacing="0" width="779" border="0">
					<tr>
						<td valign="top" width="375">
						</td>
						<td width="379" align="right" valign="bottom" height="162">
							{include file="searchprofile.tpl"}
							<br />
							
						</td>
					</tr>
				</table>
			</td>	
		</tr>
	</table>
	<table class="table" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="779" border="0">
		<tr>
			<td background={$image_dir}topbar.jpg height="28" bgcolor='#4E8EC8'>
				<a href="../index.php" class="menulink">{$lang.site_links.home}</a>
				<a class="menulink">{$lang.site_links.signup_now}</a>
				<a class="menulink">{$lang.site_links.chat}</a>
				<a class="menulink">{$lang.site_links.forum}</a>
				<a class="menulink">{$lang.site_links.search}</a>
			</td>
		</tr>
	</table>
{/strip}
