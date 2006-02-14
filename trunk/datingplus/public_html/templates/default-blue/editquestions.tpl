{strip}
<form name="{$frmname}" method="post" action="modifyquestion.php">
<input type="hidden" name="sectionid" value="{$sectionid}"/>
<table width="571" border="0" cellpadding="0" cellspacing="0" >
  <tbody>
	<tr>
		<td class="module_detail" width="571">
			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
					{$head}
					</td>
				</tr>
			</table>
			<table width="571" border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" >
				<tr>
					<td width="100%">
						<table width="550" border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" >
							<tr>
								<td align="center" class='edituserlink'>
									<a href="edituser.php">{$lang.section_signup_title}</a>
								</td>
							{foreach key=key item=item from=$sections}
								<td align="center" class='edituserlink'>
									{if $key !=$smarty.get.sectionid}
										<a href="editquestions.php?sectionid={$key}"  class='edituserlink'>
									{/if}
									<span>{$item}</span>
									{if $key !=$smarty.get.sectionid}
										</a>
									{/if}
								</td>
							{/foreach}
							</tr>
						</table>
						<table width="100%" border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}">
							<tr>
								<td width="100%">
				{*Outer Loop to traverse outer dimension data array*}
						{foreach item=questionrow from=$data}
							{if $questionrow.control_type == "select"}
									<table class="table" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
									<tbody>
										<tr>
											 <td width="200" valign="top">
												<table width="200" border="0">
												<tbody>
													<tr>
														<td width="200">
															<b>{$questionrow.question}</b>
														{if $questionrow.mandatory == 'Y'}
															<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														{/if}
															<br/>
														{if $questionrow.description != NULL}
															{$questionrow.description}
														{/if}
														</td>
													</tr>
												</tbody>
												</table>
											</td>
											<td width="290" valign="top">
												<table class="table" width="290" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
												<tbody>
													<tr>
														<td  width="290">
															<select name="{$questionrow.id}{$questionrow.mandatory}">
																<option value="0">{$lang.tell_later}</option>
																{html_options options=$questionrow.options selected=$questionrow.userpref}
															</select>
														</td>
													</tr>
												</tbody>
												</table>
											</td>
										</tr>
									</tbody>
									</table>
							{elseif $questionrow.control_type == "radio"}
									<table class="table" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
									<tbody>
										<tr>
											<td width="200" valign="top">
												<table class="table" width="200" border="0" cellspacing="{$config.cellspacing}"  cellpadding="{$config.cellpadding}">
												<tbody>
													<tr>
														<td  align="left" valign="top">
															<b>{$questionrow.question}</b>
														{if $questionrow.mandatory == 'Y'}
															<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														{/if}
															<br/>
														{if $questionrow.description != NULL}
															{$questionrow.description}
														{/if}
														</td>
													</tr>
												</tbody>
												</table>
											</td>
											<td width="290" valign="top">
												<table class="table" width="290" border="0" cellspacing="{$config.cellspacing}"  cellpadding="{$config.cellpadding}" >
												<tbody>
													<tr>
														<td valign="top">
														{foreach name="iterator"  key=key  item=curropt from=$questionrow.options}
															{if $key == $questionrow.userpref[0]}
																<input type="radio" name="{$questionrow.id}{$questionrow.mandatory}"  value="{$key}" checked/>{$curropt}
															{else}
																<input  type="radio" name="{$questionrow.id}{$questionrow.mandatory}" value="{$key}"/>{$curropt}
															{/if}
															{* if $smarty.foreach.iterator.iteration%2 == 0 }
																</td></tr><tr><td>
															{else}
																</td><td>
															{/if *}
															</td></tr><tr><td>
														{/foreach}
														</td>
													</tr>
												</tbody>
												</table>
											</td>
										</tr>
									</tbody>
									</table>
							{elseif $questionrow.control_type == "checkbox"}
									<table class="table" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
									<tbody>
										<tr>
											<td width="200" valign="top">
												<table class="table" width="200" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
												<tbody>
													<tr>
														<td  align="left" valign="top">
															<b>{$questionrow.question}</b>
															{if $questionrow.mandatory == 'Y'}
																<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
															{/if}
															<br/>
															{if $questionrow.description != NULL}
																{$questionrow.description}
															{/if}
														</td>
													</tr>
												</tbody>
												</table>
											</td>
											<td width="290" valign="top">
												<table class="table" width="290" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
												<tbody>
													<tr>
														<td align="left" valign="top">
															{html_checkboxes options=$questionrow.options selected=$questionrow.userpref separator=<br/>  name=$questionrow.id|cat:$questionrow.mandatory }
														</td>
													</tr>
												</tbody>
												</table>
											</td>
										</tr>
									</tbody>
									</table>
							{elseif $questionrow.control_type == "textarea"}
									<table width="100%">
									<tbody>
										<tr>
											<td>
												<table class="table" width="440" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
												<tbody>
													<tr>
														<td  align="left" valign="top">
															<b>{$questionrow.question}</b>
														{if $questionrow.mandatory == 'Y'}
															<font color="{$lang.required_info_indicator_color}">{$lang.required_info_indicator}</font>
														{/if}
															<br/>
														{if $questionrow.description != NULL}
															{$questionrow.description}
														{/if}
														</td>
													</tr>
												</tbody>
												</table>
											<td>
										</tr>
										<tr>
											<td>
												<table class="table" width="290" border="0" cellspacing="{$config.cellspacing}" cellpadding="{$config.cellpadding}">
												<tbody>
													<tr>
														<td>
															<textarea name="{$questionrow.id}{$questionrow.mandatory}" rows="7" cols="50">{$questionrow.userpref[0]}</textarea>
														</td>
													</tr>
												</tbody>
												</table>
											</td>
										</tr>
									</tbody>
									</table>
							{/if}
									<br />
						{/foreach}
								</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td align="center">
									<input type="submit" class="formbutton" value="Save" /> <input type="reset" class="formbutton" value="Reset" />
								</td>
							</tr>
						</table>
						<br /><br />
					</td>
				</tr>
			</table>
		</td>
	</tr>
  </tbody>
</table>
</form>
<br />

{/strip}
