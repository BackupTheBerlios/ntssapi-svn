{strip}
<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.newmemberlist}
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="{$config.cellpadding}" cellspacing="{$config.cellspacing}" width="100%" class="module_detail_inside">
				<tr class="table_head">
					<th width="20%">{$lang.username_hdr}</th>
					<th width="8%">{$lang.sex_without_colon}</th>
					<th width="8%">{$lang.age}</th>
					<th width="10%">{$lang.col_head_country}</th>
					<th width="20%">{$lang.col_head_city}</th>
					<th width="34%">{$lang.member_since}</th>
				</tr>
			{foreach from=$newmemberslist item=user_info}
				<tr class="{cycle values="oddrow,evenrow"}">
					<td><a href="javascript:popUpScrollWindow2('showprofile.php?id={$user_info.id}','top',650,600)">{$user_info.username}</a>
					</td>
					<td>{$lang.signup_gender_values[$user_info.gender]}</td>
					<td>{$user_info.age}</td>
					<td>{$user_info.country}</td>
					<td>{$user_info.city}</td>
					<td width="65%">{$user_info.regdate|date_format:$lang.DATE_FORMAT}
					</td>
				</tr>
			{/foreach}

			</table>
		</td>
	</tr>
</table>
{/strip}
