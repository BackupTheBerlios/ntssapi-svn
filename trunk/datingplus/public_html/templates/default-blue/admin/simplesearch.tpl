{strip}
<table border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td>
			<table  id="tblSelect" border="0" cellpadding="0" cellspacing="0" class="s_table_white">
				<tr>
					<td width="10"></td>
					<td align="center"><a href="javascript:toggleRow('rwUsername',1);">{$lang.username_without_colon}</a></td>
					<td width="10"></td>
				</tr>
			</table>
		</td>
		<td>
			<table  id="tblSelect" border="0" cellpadding="0" cellspacing="0" class="s_table_white">
				<tr>
					<td width="10"></td>
					<td align="center"><a href="javascript:toggleRow('rwCity',2);">{$lang.city}</a></td>
					<td width="10"></td>
				</tr>
			</table>
		</td>
    	<td>
			<table id="tblSelect" border="0" cellpadding="0" cellspacing="0" class="s_table_white">
				<tr>
					<td width="10"></td>
					<td align="center"><a href="javascript:toggleRow('rwZip',3);">{$lang.zip_code}</a></td>
					<td width="10"></td>
				</tr>
			</table>
	  	</td>
		{assign var="ccount" value="4"}
		{foreach item=row from=$data}
    	<td>
				<table id="tblSelect" border="0" cellpadding="0" cellspacing="0" class="s_table_white">
					<tr>
						<td width="10"></td>
						<td align="center">
							<a href="javascript:toggleRow('rw{$row.id}',{$ccount});">
							{$row.extsearchhead}</a>
						</td>
						<td width="10"></td>
					</tr>
				</table>
		  </td>
		{math equation="$ccount+1" assign="ccount"}
		{/foreach}
	</tr>
</table>
<table width="100%" cellpadding="0" cellspacing="0" class="s_table_blue" border="0">
	<tr>
		<td>
          <form name="frmsearchCity" method="post" action="searchprofiles.php" >
          	<table id="rwCity" cellpadding="3" cellspacing="3" style="display: none;">
            	<tr>
              		<td width="33%" style="font-weight: normal;">&nbsp;{$lang.enter_city} </td>
              		<td width="67%"> <input type="text" name="txtsearch" maxlength="100" size="25" />
              		</td>
            	</tr>
            	<tr>
              		<td colspan="2">
                		<input type="hidden" name="searchtype" value="simple" /> <input type="hidden" name="searchby" value="city" />
                		<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn" />
              		</td>
            	</tr>
          	</table>
      </form>
          <form name="frmsearchZip" method="post" action="searchprofiles.php" >
          	<table id="rwZip" style="display: none;" cellpadding="3" cellspacing="3" border="0">
            	<tr>
              		<td width="33%"  style="font-weight: normal;">&nbsp;{$lang.enter_zip} </td>
              		<td width="67%"> <input type="text" name="txtsearch" maxlength="100" size="25" />
              		</td>
            	</tr>
            	<tr>
              		<td colspan="2">
                		<input type="hidden" name="searchtype" value="simple" /> <input type="hidden" name="searchby" value="zip" />
                		<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn" />
              		</td>
            	</tr>
          	</table>
      </form>
          <form name="frmsearchUser" method="post" action="searchprofiles.php" >
          	<table id="rwUsername" style="display: none;" cellpadding="3" cellspacing="3">
            	<tr>
              		<td width="33%"  style="font-weight: normal;">&nbsp;{$lang.enter_username} </td>
              		<td width="67%">
              			<input type="text" name="txtsearch" maxlength="100" size="25" />
              		</td>
            	</tr>
            	<tr>
              		<td colspan="2" >
                		<input type="hidden" name="searchtype" value="simple" /> <input type="hidden" name="searchby" value="username" />
                		<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn" />
              		</td>
            	</tr>
          	</table>
      </form>
		{foreach item=row from=$data}
		{if $row.id != '5'}
          <form name="frmsearch{$row.id}" method="post" action="searchprofiles.php" >
          	<table id="rw{$row.id}" class="table" cellspacing="0" cellpadding="0" width="100%" border="0" style="display: none;">
            	<tr>
                	<td colspan="3" style="font-weight: normal;"><br />&nbsp;&nbsp;&nbsp;{$row.extsearchhead}:</td>
              	</tr>
            	{assign var="mcount" value="0"}
            	{foreach key=key item=curropt from=$row.options}
            		{if $mcount == 0 }
            		<tr>
            		{/if}
            		{math equation="$mcount+1" assign="mcount"}
              		<td width="33%" style="font-weight: normal;">&nbsp;&nbsp;<input name="{$row.id}[]" type="checkbox" value="{$key}" />
                	{$curropt}
                	<br />
                	</td>
              		{if $mcount == 3 }
              			{assign var="mcount" value="0"}
              			</tr>
            		{/if}
            	{/foreach}
            	<tr>
              		<td  colspan="3">&nbsp;</td>
            	</tr>
            	<tr>
              		<td  colspan="3">
                	<input type="hidden" name="searchtype" value="simple" /> <input type="hidden" name="searchby" value="{$row.id}" />
                	<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn" />
              		</td>
            	</tr>
          	</table>
      </form>
		{else}
          <form name="frmsearch{$row.id}" method="post" action="searchprofiles.php" >
          	<table id="rw{$row.id}"  class="table" cellspacing="0" cellpadding="0" width="100%" border="0" style="display: none;">
            	<tr>
            		<td height="5"></td>
              	</tr>
              	<tr>
                	<td style="font-weight: normal;"><br />&nbsp;&nbsp;&nbsp;{$row.extsearchhead}:</td>
              	</tr>
              	<tr>
                	<td height="5"></td>
              	</tr>
              	<tr>
                	<td style="font-weight: normal;">
						&nbsp;&nbsp;&nbsp;{$lang.between}&nbsp;
						<select name="{$row.id}[]" >
							{html_options options=$row.options}
						</select>&nbsp;{$lang.and}&nbsp;
						<select name="{$row.id}[]" >
							{html_options options=$row.endoptions}
						</select>
                  	</td>
              	</tr>
              	<tr>
                	<td>&nbsp;</td>
              	</tr>
              	<tr>
                	<td>
                  		<input type="hidden" name="searchtype" value="simple" />
                  		<input type="hidden" name="searchby" value="{$row.id}" />
                  		<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn" />
                	</td>
              	</tr>
          	</table>
      </form>
        {/if}
		{/foreach}
		</td>
	</tr>
</table>
<script language="JavaScript" type="text/javascript">
/* <![CDATA[ */
  toggleRow('rwUsername', 1);
/* ]]> */
</script>
{/strip}
