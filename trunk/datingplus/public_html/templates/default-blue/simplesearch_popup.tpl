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
      <table id="rwCity" cellpadding="3" cellspacing="3" style="font-weight: normal;display: none;">
        	<form name="frmsearchCity" method="post" action="searchprofiles_popup.php" >
            	<tr>
              		<td width="33%">&nbsp;{$lang.enter_city} </td>
              		<td width="67%"> <input type="text" name="txtsearch" maxlength="100" size="25"/>
              		</td>
            	</tr>
            	<tr>
              		<td colspan="2">
                		<input type="hidden" name="searchtype" value="simple"/> <input type="hidden" name="searchby" value="city"/>
                		<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn"/>
              		</td>
            	</tr>
			</form>
          	</table>
            <table id="rwZip" style="font-weight: normal;display: none;" cellpadding="3" cellspacing="3" border="0">
        	<form name="frmsearchZip" method="post" action="searchprofiles_popup.php" >
            	<tr>
              		<td width="33%">&nbsp;{$lang.enter_zip} </td>
              		<td width="67%"> <input type="text" name="txtsearch" maxlength="100" size="25"/>
              		</td>
            	</tr>
            	<tr>
              		<td colspan="2">
                		<input type="hidden" name="searchtype" value="simple"/> <input type="hidden" name="searchby" value="zip"/>
                		<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn"/>
              		</td>
            	</tr>
			</form>
          	</table>
            <table id="rwUsername" style="font-weight: normal;display: none;" cellpadding="3" cellspacing="3">
        	<form name="frmsearchUser" method="post" action="searchprofiles_popup.php" >
            	<tr>
              		<td width="33%">&nbsp;{$lang.enter_username} </td>
              		<td width="67%">
              			<input type="text" name="txtsearch" maxlength="100" size="25"/>
              		</td>
            	</tr>
            	<tr>
              		<td colspan="2" >
                		<input type="hidden" name="searchtype" value="simple"/> <input type="hidden" name="searchby" value="username"/>
                		<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn" />
              		</td>
            	</tr>
			</form>
          	</table>
		{foreach item=row from=$data}
		{if $row.id != '5'}
    <table id="rw{$row.id}" cellspacing="0" cellpadding="0" width="100%" border="0" style="font-weight: normal;display: none;">
        	<form name="frmsearch{$row.id}" method="post" action="searchprofiles_popup.php" >
            	<tr>
                	<td colspan="3"><br />&nbsp;&nbsp;&nbsp;{$row.extsearchhead}:</td>
              	</tr>
            	{assign var="mcount" value="0"}
            	{foreach key=key item=curropt from=$row.options}
            		{if $mcount == 0 }
            		<tr>
            		{/if}
            		{math equation="$mcount+1" assign="mcount"}
              		<td width="33%">&nbsp;&nbsp;<input name="{$row.id}[]" type="checkbox" value="{$key}"/>
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
                	<input type="hidden" name="searchtype" value="simple"/> <input type="hidden" name="searchby" value="{$row.id}"/>
                	<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn" />
              		</td>
            	</tr>
			</form>
          	</table>
		{else}
          <form name="frmsearch{$row.id}" method="post" action="searchprofiles_popup.php" >
            <table id="rw{$row.id}" class="table" cellspacing="0" cellpadding="0" width="100%" border="0" style="font-weight: normal;display: none;">
            	<tr>
            		<td height="5"></td>
              	</tr>
              	<tr>
                	<td><br />&nbsp;&nbsp;&nbsp;{$row.extsearchhead}:</td>
              	</tr>
              	<tr>
                	<td height="5"></td>
              	</tr>
              	<tr>
                	<td>
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
                  		<input type="hidden" name="searchtype" value="simple"/>
                  		<input type="hidden" name="searchby" value="{$row.id}"/>
                  		<input type="submit" class="formbutton" value="{$lang.search}" name="searchbtn"/>
                	</td>
              	</tr>
          	</table>
        </form>
        {/if}
		{/foreach}
       	</form>
			<script type="text/javascript">
      /* <![CDATA[ */
				toggleRow('rwUsername', 1);
      /* ]]> */
			</script>
		</td>
	</tr>
</table>
{/strip}
