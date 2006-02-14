{strip}
<form action="delquestion.php" method="post">
	<input type="hidden" name="txtid" value="{$data.id}">
	<input type="hidden" name="sectionid" value="{$data.section}">
<table class=table cellspacing={$config.cellspacing} cellpadding={$config.cellpadding} width=600 border=0>
<tbody>
	<tr> 
		<td colspan="2" class="subtitle">{$lang.delete_question}</td>
	</tr>
	<tr><td colspan="2">&nbsp;</td></tr>
	<tr><td colspan="2"><font color="{$lang.admin_error_color}">{$lang.delete_confirm_msg}{$lang.question_mark}</font></td></tr>

	<tr><td colspan="2">&nbsp;</td></tr>
	<tr> 
		<td>{$lang.id}</td>
		<td>{$data.id}</td>	  
	</tr>
	<tr>
		<td>{$lang.question}</td>
		<td>{$data.question|stripslashes}</td>	  
	</tr>
	<tr>
		<td>{$lang.description}</td>
		<td>{$data.description|stripslashes}</td>	  
	</tr>
	<tr>
		<td>{$lang.guideline}</td>
		<td>{$data.guideline|stripslashes}</td>	  
	</tr>
	<tr>
		<td>{$lang.control_type}</td>
		<td>
			{$data.control_type}
		</td>	  
	</tr>
{*if $data.control_type == "textarea" *}
	<tr>
		<td>{$lang.maxlength}</td>
		<td>{$data.maxlength}</td>	  
	</tr>
{*/if*}
	<tr>
		<td>{$lang.mandatory}</td>
		<td>
			{$data.mandatory}
		</td>
	</tr>
	<tr>
		<td>{$lang.section}</td>
		<td>
			{$data.section|stripslashes}
		</td>	  
	</tr>
	<tr>
		<td>{$lang.include_extsearch}</td>
		<td>
			{$data.extsearchable}
		</td>
	</tr>
	<tr>
		<td>{$lang.head_extsearch}</td>
		<td>{$data.extsearchhead|stripslashes}</td>	  
	</tr>
	<tr>
		<td>{$lang.enabled}</td>	  	  
		<td>
			{$data.enabled}
		</td>
	</tr>

	<tr>
		<td>&nbsp;</td>
		<td>
			<input type="submit" class="formbutton" name="delaction" value="{$lang.yes}">
		</td>
	</tr>
</tbody>
</table>
</form>
<a href="sectionquestions.php?sectionid={$data.section}">{$lang.back}</a>
{/strip}