<?xml version="1.0" encoding="iso-8859-1"?>
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
/* ]]> */
</script>

<link href="{$css_path}default.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="javascript/functions.js"></script>
<script type="text/javascript" src="javascript/check.js"></script>
<script type="text/javascript" src="javascript/validate.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset={$lang.ENCODING}" />
<meta http-equiv="keywords" content="{$config.meta_keywords}" />
<meta http-equiv="description" content="{$config.meta_description}" />
</head>
<body text="{$config.textcolor}" dir="{$lang.DIRECTION}" >
<center>
<table class=main_outer_table cellspacing=0 cellpadding=0 width=779 border=0 bgcolor="{$config.bgcolor}">
	<tr>
		<td width=100%>
				<table width=779 border=0 cellpadding=0 cellspacing=0 class="headbg">
					<tr>
					 <td width=244 valign="bottom">
				<a href="index.php" class="main_title">{$lang.site_name}</a>
						</td>
						<td width=300 valign="top" align="center">
							<table width=191 border=0 cellpadding=0 cellspacing=0>
								<tr>
									<td>
										<img src="{$image_dir}pic_09.jpg" width=64 height=52 alt="" /></td>
									<td>
										<img src="{$image_dir}pic_10.jpg" width=63 height=52 alt="" /></td>
									<td>
									 <img src="{$image_dir}pic_11.jpg" width=64 height=52 alt="" /></td>
								</tr>
								<tr>
									<td>
										<img src="{$image_dir}pic_13.jpg" width=64 height=52 alt="" /></td>
									<td>
										<img src="{$image_dir}pic_14.jpg" width=63 height=52 alt="" /></td>
									<td>
									 <img src="{$image_dir}pic_15.jpg" width=64 height=52 alt="" /></td>
								</tr>
								<tr>
									<td>
										<img src="{$image_dir}pic_16.jpg" width=64 height=52 alt="" /></td>
									<td>
										<img src="{$image_dir}pic_17.jpg" width=63 height=52 alt="" /></td>
									<td>
									 <img src="{$image_dir}pic_18.jpg" width=64 height=52 alt="" /></td>
                </tr>
							</table>
            
						</td>
						<td width=235 valign="top">
							<table width=235 border=0 cellpadding=0 cellspacing=0>
								<tr>
									<td>
										<img src="{$image_dir}box_02.jpg" width=17 height=21 alt="" /></td>
									<td>
										<img src="{$image_dir}box_03.jpg" width=202 height=21 alt="" /></td>
									<td>
									 <img src="{$image_dir}box_04.jpg" width=16 height=21 alt="" /></td>
								</tr>
								<tr>
									<td>
										<img src="{$image_dir}box_05.jpg" width=17 height=107 alt="" /></td>
									<td align=center class="headbgbox">
										{include file="searchprofile.tpl"}
									</td>
									<td>
									 <img src="{$image_dir}box_07.jpg" width=16 height=107 alt="" /></td>
								</tr>
								<tr>
									<td>
										<img src="{$image_dir}box_19.jpg" width=17 height=28 alt="" /></td>
									<td>
										<img src="{$image_dir}box_20.jpg" width=202 height=28 alt="" /></td>
									<td>
									 <img src="{$image_dir}box_21.jpg" width=16 height=28 alt="" /></td>
                </tr>
							</table>
						</td>
          </tr>
				</table>
				<table width=779 border=0 cellpadding=0 cellspacing=0 class="loginbarbg">
					<tr>
						<td height="33" width="154"><img src="{$image_dir}top_blue.jpg" width="154" height="33" alt="" /></td>
						<td height="33" width="575">
							{if $smarty.session.UserId == ''}
								{include file="loginform.tpl"}
							{else}
								{include file="topmenu.tpl"}
							{/if}
						</td>
						<td height="33" width="40" align=right valign="middle">
							<a href="extsearch.php"><img src="{$image_dir}search_icon.gif" border=0 width=18 height=18 alt="" /></a>
							<a href="index.php"><img src="{$image_dir}homepage_icon.gif" border=0 width=18 height=18 alt="" /></a>
						</td>
						<td height="33" width="10"></td>
          </tr>
				</table>


		
{/strip}
