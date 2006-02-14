{strip}
<form name="srch01" action="search.php" method="post">
  <input name="countrycode" type="hidden" value=""/>
</form>
<form name="frmadvsearch" id="frmadvsearch" method="post" action="searchprofiles.php">
<table id="tbl" class="table"  width="95%" border=0 cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
	<tbody>
		<tr>
			<td colspan="2">
				{$lang.search_location} <br />
				<br />
				{$lang.search_wildcard_msg}
			</td>
		</tr>
		<tr>
			<td>{$lang.select_country}</td>
			<td>
				<select class="select" style="width: 175px;" id="txtcountry" name="txtcountry"  onChange="javascript: document.srch01.countrycode.value=document.frmadvsearch.txtcountry.value; document.srch01.submit(); ">
				{html_options options=$lang.allcountries selected="$countrycode" }
				</select>
			</td>
		</tr>
		<tr>
			<td width="112">
				{$lang.signup_state_province}
			</td>
			<td width="361">
		{if $stateslist|@count > 0}
				<select class="select" style="width: 175px" name="txtstates"	>
				{foreach from=$stateslist key=key item=val}
					<option value="{$key}" {if $key == $userstate}selected="selected"{/if}>{$val}</option>
				{/foreach}
				</select>
		{ else }
				<input name="txtstates" value="{$txtstates}" type="text" size="30" maxlength="100" />
		{ /if }
			</td>
		</tr>
		<tr>
			<td>{$lang.enter_city}</td>
			<td> <input type="text" name="txtcity" maxlength="100" size="20" />
			</td>
		</tr>
		<tr>
			<td>{$lang.enter_zip}</td>
			<td> <input type="text" name="txtzip" maxlength="12" size="12" /> </td>
		</tr>
		<tr>
			<td colspan="2" >&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp; <input type="hidden" name="searchtype" value="advance" /></td>
			<td><input type="submit" class="formbutton" value="{$lang.search}" /></td>
		</tr>
	</tbody>
</table>
</form>
{/strip}
