{strip}
<script type="text/javascript">
/* <![CDATA[ */
function validate(form)
{ldelim}
	ErrorCount=0;
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13);

	if ( form.payment_method[0].checked== true )
	{ldelim}
		if (form.membership.checked == 'free') {ldelim}
			ErrorMsg[1] =  "{$lang.mship_errors[4]}";
			ErrorCount++;
		{rdelim}
	{rdelim}
	else if ( form.payment_method[1].checked == true )
	{ldelim}
		CheckFieldString("noblank",form.authorizenet_ccowner,"{$lang.signup_js_errors.ccowner_noblank}");
		CheckFieldString("noblank",form.authorizenet_ccnumber,"{$lang.signup_js_errors.ccnumber_noblank}");
	{rdelim}
	else if ( form.payment_method[2].checked == true )
	{ldelim}
	{rdelim}
	else if ( form.payment_method[3].checked == true )
	{ldelim}
		CheckFieldString("noblank",form.toco_ccowner,"{$lang.signup_js_errors.ccowner_noblank}");
		CheckFieldString("noblank",form.toco_ccnumber,"{$lang.signup_js_errors.ccnumber_noblank}");
		CheckFieldString("noblank",form.toco_cvvnumber,"{$lang.signup_js_errors.cvvnumber_noblank}");
	{rdelim}
	else
	{ldelim}
		alert( "{$lang.signup_js_errors.select_payment}" );
		return false;
	{rdelim}

	result="";
	if( ErrorCount > 0)
	{ldelim}
		alert(ErrorMsg[1]);
		return false;
	{rdelim}
	return true;
{rdelim}
/* ]]> */
</script>

<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="100%" >

			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
					{$lang.membership_status}
					</td>
				</tr>
			</table>
      <form action="paymentconfirmation.php" method="post" onsubmit="javascript: return validate(this);">

			<table border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" align="center">
        
				<tr>
					<td align="center">
						<table border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" align="left">
							<tr><td colspan="3"><b>{if $memberships[$smarty.session.RoleId] == ''}{$lang.cannot_determine_membership}{else}{$lang.you_currently}{$memberships[$smarty.session.RoleId]}&nbsp;{$lang.member}{/if}.</b></td></tr>
							<tr><td colspan="3">&nbsp;</td></tr>
							<tr><td colspan="3">{$lang.choose_membership}</td></tr>
							<tr>
							{foreach item=item key=key from=$memberships}
								<td><input type="radio" name="membership" value="{$key}" checked="checked"/>{$item}</td>
							{/foreach}
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table class="table" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" width="100%" border="0" align="center">
				<tr><td>&nbsp;</td></tr>
				<tr>
					<td>
						{if $smarty.get.right == 1}
							{include file="permitmsg.tpl"}
							<br />
						{/if}
					<td>
				</tr>
				<tr>
					<td align="center">
						{include file="mshipcompare.tpl"}
					</td>
				</tr>
				<tr>
					<td>
						{if $smarty.get.err != ''}
							<br /><span class="errors">
							<b>{$smarty.get.err}</b></span><br />
						{/if}
					</td>
				</tr>
				<tr><td align="left"><br />&nbsp;&nbsp;{$lang.payment_msg1}</td></tr>
				<tr><td>&nbsp;</td></tr>
				<tr>
					<td align="center" width="571">
						{include file="freefrm.tpl"}<br />
					</td>
				</tr>
			{foreach item=item from=$data}
				<tr>
					<td align="center" width="571">
						{include file=$item.formfile}<br />
					</td>
				</tr>
			{/foreach}

				<tr><td><input class="formbutton" type="submit" value="{$lang.continue} --&gt;"/></td></tr>

			</table>
      </form>

		</td>
	</tr>
</table>
{/strip}
