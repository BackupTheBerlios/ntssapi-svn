{strip}
<table width="350" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail_inside" width="100%">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="module_head" width="6"></td>
					<td class="module_head" width="526">
					{$lang.user_stats}
					</td>
					<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
				</tr>
			</table>

			{if $show }
				<table  width="100%" cellpadding="0" cellspacing="8" border="0">
					{assign var="ccount" value="0"}
					{foreach item=item key=key from=$data}
						{if $ccount==0}
							<tr>
						{/if}
							<td>{include file="userresultviewsmall.tpl"}</td>
						{if $ccount==1}
							</tr>
						{/if}
						{math equation="$ccount+1" assign="ccount"}
						{math equation="$ccount%2" assign="ccount"}
					{/foreach}
				</table>
			{else}

				<table align="center" width="350" cellspacing="5" cellpadding="1" border="0">
					<tr><td><strong>{$lang.your_user_stats}</strong></td></tr>
					<tr><td><br /></td></tr>
					{if $number_matches}
						<tr class="evenrow"><td><a href="userstats.php?show=match">{$lang.users_match_your_search}:</a></td><td>{$number_matches}</td></tr>
					{else}
						<tr class="evenrow"><td>{$lang.users_match_your_search}:</td><td>{$number_matches}</td></tr>
					{/if}
					{if $same_country}
						<tr class="oddrow"><td><a href="userstats.php?show=samecountry">{$lang.in_your_country}:</a></td><td>{$same_country}</td></tr>
					{else}
						<tr class="oddrow"><td>{$lang.in_your_country}:</td><td>{$same_country}</td></tr>
					{/if}
					{if $same_state}
						<tr class="evenrow"><td><a href="userstats.php?show=samestate">{$lang.in_your_state}:</a></td><td>{$same_state}</td></tr>
					{else}
						<tr class="evenrow"><td>{$lang.in_your_state}:</td><td>{$same_state}</td></tr>
					{/if}
					{if $same_county}
						<tr class="oddrow"><td><a href="userstats.php?show=samecounty">{$lang.in_your_county}:</a></td><td>{$same_county}</td></tr>
					{else}
						<tr class="oddrow"><td>{$lang.in_your_county}:</td><td>{$same_county}</td></tr>
					{/if}
					{if $same_city}
						<tr class="evenrow"><td><a href="userstats.php?show=samecity">{$lang.in_your_city}:</a></td><td>{$same_city}</td></tr>
					{else}
						<tr class="evenrow"><td>{$lang.in_your_city}:</td><td>{$same_city}</td></tr>
					{/if}
					{if $same_zip}
						<tr class="oddrow"><td><a href="userstats.php?show=samezip">{$lang.in_your_zip}:</a></td><td>{$same_zip}</td></tr>
					{else}
						<tr class="oddrow"><td>{$lang.in_your_zip}:</td><td>{$same_zip}</td></tr>
					{/if}
					{if $same_sex}
						<tr class="evenrow"><td><a href="userstats.php?show=samegender">{$lang.in_same_gender}:</a></td><td>{$same_sex}</td></tr>
					{else}
						<tr class="evenrow"><td>{$lang.in_same_gender}:</td><td>{$same_sex}</td></tr>
					{/if}
					{if $same_age}
						<tr class="oddrow"><td><a href="userstats.php?show=sameage">{$lang.in_same_age}:</a></td><td>{$same_age}</td></tr>
					{else}
						<tr class="oddrow"><td>{$lang.in_same_age}:</td><td>{$same_age}</td></tr>
					{/if}
					<tr><td><br /></td></tr>
					<tr><td><strong>{$lang.other_user_stats}</strong></td></tr>
					<tr><td><br /></td></tr>
					{if $same_lookagestart}
						<tr class="oddrow"><td><a href="userstats.php?show=lookagestart">{$lang.above_lookagestart}:</a></td><td>{$same_lookagestart}</td></tr>
					{else}
						<tr class="oddrow"><td>{$lang.above_lookagestart}:</td><td>{$same_lookagestart}</td></tr>
					{/if}
					{if $same_lookageend}
						<tr class="evenrow"><td><a href="userstats.php?show=lookageend">{$lang.below_lookageend}:</a></td><td>{$same_lookageend}</td></tr>
					{else}
						<tr class="evenrow"><td>{$lang.below_lookageend}:</td><td>{$same_lookageend}</td></tr>
					{/if}
					{if $same_lookgender}
						<tr class="oddrow"><td><a href="userstats.php?show=lookgender">{$lang.your_lookgender}:</a></td><td>{$same_lookgender}</td></tr>
					{else}
						<tr class="oddrow"><td>{$lang.your_lookgender}:</td><td>{$same_lookgender}</td></tr>
					{/if}
					{if $same_lookcountry}
						<tr class="evenrow"><td><a href="userstats.php?show=lookcountry">{$lang.in_look_country}:</a></td><td>{$same_lookcountry}</td></tr>
					{else}
						<tr class="evenrow"><td>{$lang.in_look_country}:</td><td>{$same_lookcountry}</td></tr>
					{/if}
					{if $same_lookstate}
						<tr class="oddrow"><td><a href="userstats.php?show=lookstate">{$lang.in_look_state}:</a></td><td>{$same_lookstate}</td></tr>
					{else}
						<tr class="oddrow"><td>{$lang.in_look_state}:</td><td>{$same_lookstate}</td></tr>
					{/if}
					{if $same_lookcounty}
						<tr class="evenrow"><td><a href="userstats.php?show=lookcounty">{$lang.in_look_county}:</a></td><td>{$same_lookcounty}</td></tr>
					{else}
						<tr class="evenrow"><td>{$lang.in_look_county}:</td><td>{$same_lookcounty}</td></tr>
					{/if}
					{if $same_lookcity}
						<tr class="oddrow"><td><a href="userstats.php?show=lookcity">{$lang.in_look_city}:</a></td><td>{$same_lookcity}</td></tr>
					{else}
						<tr class="oddrow"><td>{$lang.in_look_city}:</td><td>{$same_lookcity}</td></tr>
					{/if}
					{if $same_lookzip}
						<tr class="evenrow"><td><a href="userstats.php?show=lookzip">{$lang.in_look_zip}:</a></td><td>{$same_lookzip}</td></tr>
					{else}
						<tr class="evenrow"><td>{$lang.in_look_zip}:</td><td>{$same_lookzip}</td></tr>
					{/if}
					{if $same_timezone}
						<tr class="oddrow"><td><a href="userstats.php?show=looktimezone">{$lang.in_same_timezone}:</a></td><td>{$same_timezone}</td></tr>
					{else}
						<tr class="oddrow"><td>{$lang.in_same_timezone}:</td><td>{$same_timezone}</td></tr>
					{/if}
				</table>
			{/if}
		</td>
	</tr>
</table>
{/strip}