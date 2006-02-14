{strip}
<html>
<head>
<title>{$lang.title}</title>

<script language="Javascript">
{if $config.use_popups == 'N'}
var use_popups = false;
{else}
var use_popups = true;
{/if}
</script>
{/if}

<link href="{$css_path}default.css?{$smarty.now}" rel="stylesheet" type="text/css">
<script type="text/javascript" src="../javascript/functions.js"></script>
<script type="text/javascript" src="../javascript/check.js"></script>
<script type="text/javascript" src="../javascript/validate.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset={$lang.ENCODING}">
</head>
<body bgcolor="{$config.bgcolor}" text="{$config.textcolor}" dir="{$lang.DIRECTION}" topmargin="0" leftmargin="0" marginwidth="0" marginheight="0">
<center>
<TABLE WIDTH=779 BORDER=0 CELLPADDING=0 CELLSPACING=0 bgcolor="#EDF4F9">
	<TR>
		<TD height="33" width="154"><img src="{$image_dir}top_blue.jpg?{$smarty.now}" width="154" height="33"></TD>
		<td height="33" width="625">
				<span class="admin_head">{$lang.admin_login_title}</span>
		</td>
	</TR>
</TABLE>
	<table class=table cellspacing=9 cellpadding=0 width=779 border=0>
		<tr>
		  {if $smarty.session.AdminId != ''}
			<td valign=top width=180>
					{include file="admin/panelmenu.tpl"}
			</td>
		  {/if}
			<td valign=top width=573 class="module_detail">
{/strip}