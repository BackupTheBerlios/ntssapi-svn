{strip}
<table width="296" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="268">
						{$item.SectionName}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>
			<table width="100%" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td width="100%">

						<table width="100%" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
						{assign var="previd" value="0"}
						{foreach item=subitem from=$item.preferences}

							{if $subitem.type == "select" || $subitem.type == "radio"}
								<tr class="{cycle values="oddrow,evenrow"}">
									<td valign="top"><b>{$lang.extsearchhead[$subitem.extsearchhead]}: </b></td>
									<td>
										{if $subitem.options != ''}
											{$subitem.options}
										{else}
											{$lang.tell_later}
										{/if}
									</td>
								</tr>

							{elseif $subitem.type == "textarea"}
								<tr class="{cycle values="oddrow,evenrow"}">
									<td valign="top" ><b>{$lang.extsearchhead[$subitem.extsearchhead]}: </b></td>
									<td>
										{if $subitem.options != ''}
											{$subitem.options|stripslashes}
										{else}
											{$lang.tell_later}
										{/if}
									</td>
								</tr>

							{elseif $subitem.type == "checkbox"}

								<tr class="{cycle values="oddrow,evenrow"}">
									<td valign="top"><b>{$lang.extsearchhead[$subitem.extsearchhead]}: </b></td>
									<td>
										{* fix this later in showprofile.php *}
										{if $subitem.options != '' and $subitem.options != ', '}
											{$subitem.options}
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

