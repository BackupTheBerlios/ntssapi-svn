{if $config.use_profilepopups == 'Y'}
<?xml version="1.0" encoding="{$lang.ENCODING}"?>
	<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
	<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
	{if $title != '' }
		<title>{$title}</title>
	{else}
		<title>{$config.site_title}</title>
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
	<script type="text/javascript" src="../javascript/functions.js"></script>
	<script type="text/javascript" src="../javascript/check.js"></script>
	<script type="text/javascript" src="../javascript/validate.js"></script>
	<meta http-equiv="Content-Type" content="text/html; charset={$lang.ENCODING}" />
	</head>
	<body bgcolor="#FFFFFF" text="{$config.textcolor}" dir="{$lang.DIRECTION}" >
{/if}

{if $err == 28 }
	<table width="80%"  align="center" border="0" cellspacing="5">
	<tr><td colspan="2" align="center" class="subtitle">{$lang.profile_details}</td></tr>
	<tr><td colspan="2" align="center">{$lang.view_profile_restricted}</td></tr>
	</table>
{elseif $err == 31 }
	<table width="80%"  align="center" border="0" cellspacing="5">
	<tr><td colspan="2" align="center" class="subtitle">{$lang.profile_details}</td></tr>
	<tr><td colspan="2" align="center">{$lang.profile_notset}</td></tr>
	</table>
{else}

{if $config.use_profilepopups == 'Y'}
<div class="main_outer_table" align="center">
{/if}

			{ include file="nickpage_logo.tpl"}
			{* include file="nickpage_navi.tpl" *}

	<table cellspacing="0" cellpadding="0" border="0" width="100%">
		<tr>
			{if $config.use_profilepopups == 'Y'}
			<td class="module_detail_inside" valign="top" align="center">
			{else}
			<td valign="top" align="center">
			{/if}
			

				<div class="nickwidth" align="center">

			{if $errid ne ''}
				<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" width="100%">
					<tr>
						<td align="center" colspan="2">
							<font color="{$lang.error_msg_color}">
							{$lang.errormsgs.$errid}</font>
						</td>
					</tr>
				</table>
			{/if}

			{include file="nickpage_basic.tpl"}
      <br />
			{include file="nickpage_content.tpl"}
			<br />
			{include file="nickpage_rating.tpl"}

				</div>
			</td>
		</tr>
	</table>

			<table cellspacing="0" cellpadding="0" border="0" width="100%" class="headbg">
				<tr>
					<td class="headerfooter" style="text-align:left; width:33%;">&nbsp;</td>
					<td class="headerfooter" style="text-align:center; width:33%;">&nbsp;</td>
					<td class="headerfooter" style="text-align:right; width:33%;">
						{$profile_views}&nbsp;Views&nbsp;&nbsp;
					</td>
				</tr>
			</table>

{if $config.use_profilepopups == 'Y'}
</div>
{/if}

{if $config.use_profilepopups == 'Y'}
<script type="text/javascript"> /* <![CDATA[ */ window.focus(); /* ]]> */</script>
{/if}

{if $config.use_profilepopups == 'Y'}
</body>
</html>
{/if}
{/if}