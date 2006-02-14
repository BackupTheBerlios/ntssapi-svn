{strip}
<script language="JavaScript" type="text/javascript" src="../javascript/functions.js"></script>
<form name="frmSend" method="post" action="emailrecipient.php" onsubmit="">
	<input type="Hidden" name="frm" value="frmSend" />
<table class=table cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} width=600 border=0>
<tbody>
	<tr> 
		<td colspan="0" class="title">{$lang.send_letter}</td>
	</tr>
    <tr> 
      	<td colspan="0" ><input type="radio" name="userrange" value="all" checked />
	  	All
	  	</td>
	</tr>
    <tr> 
      	<td colspan="0" >
			<table cellspacing=0 cellpadding=0>
	  			<tr>
					<td valign="top"><input type="radio" name="userrange" value="selected" />Selected</td>
					<td> <textarea rows=6 cols=60></textarea></td>
				</tr>
			</table>
	  	</td>
	</tr>
    <tr> 
      	<td colspan="0" >
  			<table cellspacing=0 cellpadding=0>
	  			<tr>
					<td valign="top"><input type="radio" name="userrange" value="level" />Membership Level</td>
					<td> <select name="txtlevel">
						{html_options options=$lang.membership_levels}
						</select>
					</td>
				</tr>
			</table>
	  	</td>
	</tr>
    <tr> 
      	<td colspan="0" >&nbsp;</td>
	</tr>
    <tr> 
      	<td colspan="0" >
  			<table cellspacing=0 cellpadding=0>
	  			<tr>
					<td><input type=checkbox name="txtfilteruser[]" value="age" /></td>
					<td >Age</td>
					<td> 
						{$lang.from} &nbsp;
						<select class=select style="WIDTH: 50px" name=txtagestart height:30px;>
						{html_options values=$lang.start_agerange output=$lang.start_agerange}
						</select>
						{$lang.to} 
						<select class=select style="WIDTH: 50px" name=txtageend >
						{html_options values=$lang.end_agerange output=$lang.end_agerange }
						</select>
					</td>
				</tr>
			</table>
	  	</td>
	</tr>
    <tr> 
      	<td colspan="0" >
  			<table cellspacing=0 cellpadding=0>
	  			<tr>
					<td ><input type=checkbox name="txtfilteruser[]" value="gender" /></td>
					<td>Gender</td>
					<td>
						{foreach item=item key=key from=$lang.signup_gender_look}
						<input type="radio" name="txtgender" value="{$key}" CHECKED />{$item}
						{/foreach}
					</td>
				</tr>
			</table>
	  	</td>
	</tr>
    <tr> 
      	<td colspan="0" >
  			<table id="tbl" cellspacing=0 cellpadding=0 border=0>
	  			<tr>
					<td ><input type=checkbox name="txtfilteruser[]" value="location" /></td>
					<td>Location</td>
					<td>&nbsp;</td>
				</tr>
				<tr> 
		  			<td>&nbsp;</td>
		  			<td>{$lang.select_country}</td>
		  			<td>
						<select class=select style="WIDTH: 175px" name=txtcountry >
						<option value="AA" Selected>All Countries</option>
						{html_options options=$lang.countries selected=$config.default_country}
						</select>
		   			</td>	   
				</tr>
			</table>
	  	</td>
	</tr>
	<tr>
		<td align="center"><input type="submit" class="formbutton" value="Send" /></td>
	</tr>
</tbody>
</table>
</form>
<a href="javascript:history.go(-1)">{$lang.back}</a>
{/strip}