<?xml version="1.0" encoding="{$lang.ENCODING}"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
<script type="text/javascript" src="javascript/functions.js"></script>
<script type="text/javascript" src="javascript/check.js"></script>
<script type="text/javascript" src="javascript/validate.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset={$lang.ENCODING}" />
</head>
<body bgcolor="#FFFFFF" text="{$config.textcolor}" dir="{$lang.DIRECTION}">
<center>
