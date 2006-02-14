{strip}
<table cellspacing="0" cellpadding="0" border="0" width="100%">
	<tr>
		<td class="module_detail_inside">

			<table cellspacing="0" cellpadding="4" border="0" width="100%">
				<tr>
					<td class="module_head">
						{$item.SectionName}
					</td>
				</tr>
			</table>

			<table cellspacing="0" cellpadding="0" border="0" width="100%">
				<tr>
					<td>

						<table cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}" border="0" width="100%">
						{assign var="previd" value="0"}
						{foreach item=subitem from=$item.preferences}

							{if $subitem.type == "select" || $subitem.type == "radio"}
								<tr class="{cycle values="oddrow,evenrow"}">
									<td valign="top" width="200"><b>{$subitem.extsearchhead}: </b></td>
									<td>
										{if $subitem.options != ''}
											{$subitem.options|stripslashes|escape:"htmlall"|wordwrap:80:"<br />\n":true}
										{else}
											{$lang.tell_later}
										{/if}
									</td>
								</tr>

							{elseif $subitem.type == "textarea"}
								<tr class="{cycle values="oddrow,evenrow"}">
									<td valign="top" width="200"><b>{$subitem.extsearchhead}: </b></td>
									<td>
										{if $subitem.options != ''}
                      {$subitem.options|stripslashes|escape:"htmlall"|wordwrap:80:"<br />\n":true}
										{else}
											{$lang.tell_later}
										{/if}
									</td>
								</tr>

							{elseif $subitem.type == "checkbox"}

								<tr class="{cycle values="oddrow,evenrow"}">
									<td valign="top" width="200"><b>{$subitem.extsearchhead}: </b></td>
									<td>
										{* fix this later in showprofile.php *}
										{if $subitem.options != '' and $subitem.options != ', '}
                      {$subitem.options|stripslashes|escape:"htmlall"|wordwrap:80:"<br />\n":true}
										{else}
											{$lang.tell_later}
										{/if}
									</td>
								</tr>

							{/if}

						{/foreach}
						{assign var="previd" value=$item.id}
						</table>
					</td>
				</tr>
      </table>
		</td>
	</tr>
</table>
{/strip}

