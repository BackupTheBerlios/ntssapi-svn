{strip}
<table class="table" border="0" width="400" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" bgcolor="{$config.bgcolor}">
	<tr>
		<td>
			{$questionrow.question}
			{if $questionrow.mandatory == 'Y'}
			<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
			{/if}
		</td>
	</tr>
	{if $questionrow.description != NULL}
		<tr>
			<td>
				{$questionrow.description|stripslashes}
			</td>
		</tr>
	{/if}
	<tr>
		<td>
			{capture name=moptions}
				{include file="editoptions.tpl"}
			{/capture}
			{if $smarty.capture.moptions != "" }
				{$smarty.capture.moptions|stripslashes}
			{/if}
		</td>
	</tr>
</table>
<br />
{/strip}