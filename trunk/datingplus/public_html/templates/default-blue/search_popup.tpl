{strip}
{include file="popheader.tpl"}
<script type="text/javascript">
/* <![CDATA[ */
{literal}
function MM_reloadPage(init) {  
	/* reloads the window if Nav4 resized */
	if (init==true) {
		with (navigator) {
			if ( appName == "Netscape" && parseInt(appVersion) == 4 ) {
				document.MM_pgW=innerWidth;
				document.MM_pgH=innerHeight;
				onresize=MM_reloadPage;
			}
		}
	} else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) {
		location.reload();
	}
}

MM_reloadPage(true);

function compile(form){
	/* 
		this function will get values from simple search form
	 	and generate a querystring for itself to avoid the values 
	 	of unused fields
	*/
	var element;
	var rdoName;

	for( i=0 ; i < form.length ; i++ ) {
		if(form.elements[i].type=='radio' && form.elements[i].name=='searchby' 
			&& form.elements[i].checked == true ){	
			rdoName=form.elements[i].value;
			eval("element=form.txt" + form.elements[i].value + "");
			break;
		}
	}

	if(!element){
		result = "";
		startHeight = 0;
		endHeight = 0
		for( i=0 ; i < form.length ; i++ ) {
			if(form.elements[i].type=='checkbox' && form.elements[i].name == rdoName + "[]" && form.elements[i].checked == true ){
				result += "&" + rdoName + escape("[]") + "=";
				eval("result += '" + form.elements[i].value + "' ");
			} else if(form.elements[i].name == rdoName + "[]" && form.elements[i].type == 'select-one'){
				eval("tmp = " + form.elements[i].value );
				if( startHeight == 0 ) {
					startHeight = tmp;
				} else if( endHeight == 0 ) {
					endHeight = tmp;
				}
			}
		}

		if( startHeight != 0 && endHeight != 0){		
			if( endHeight < startHeight){
				tmp=startHeight;
				startHeight=endHeight;
				endHeight=tmp;
			}
			for(i=startHeight; i <= endHeight ; i++){
				result += "&" + rdoName + escape("[]") + "=" + i ;
			}
		}
		document.location="searchprofiles.php?searchtype=simple&searchby=" + rdoName + "" + result;
	} else {
	
		eval("document.location='searchprofiles.php?searchtype=simple&searchby=" + rdoName
			+ "&txtsearch=" + element.value + "'");
	}
	return false;
}

{/literal}
/* ]]> */
</script>

<table width="571" border="0" cellpadding="0" cellspacing="0" >
	<tr>
		<td class="module_detail" width="571">

			<table width="571" border="0" cellpadding="0" cellspacing="0" height="23">
				<tr>
					<td width="77"><img src="{$image_dir}blue_window_3_bars.jpg" width="77" height="25" alt="" /></td>
					<td class="module_head" width="494">
						{$lang.search_options}
					</td>
				</tr>
			</table>

			<table border="0" cellpadding="0" cellspacing="10" width="100%">
				<tr>
					<td width="100%">

						<table width="550" border="0" cellpadding="0" cellspacing="0" align="center">
							<tr>
								<td class="module_detail_inside" width="100%">

									<table width="100%" border="0" cellpadding="0" cellspacing="0" height="23">
										<tr>
											<td class="module_head" width="6"></td>
											<td class="module_head" >
											{$lang.search_simple}
											</td>
											<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
										</tr>
									</table>
									<table border="0" width="100%" >
										<tr>
											<td>
												{include file="simplesearch_popup.tpl"}
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="550" border="0" cellpadding="0" cellspacing="0" align="center">
							<tr>
								<td class="module_detail_inside" width="100%">

									<table width="100%" border="0" cellpadding="0" cellspacing="0" height="23">
										<tr>
											<td class="module_head" width="6"></td>
											<td class="module_head" >
												{$lang.search_advance}
											</td>
											<td width="28"><img src="{$image_dir}blue_hor2.jpg" width="28" height="23" alt="" /></td>
										</tr>
									</table>
									<table border="0" width="100%" height="150">
										<tr>
											<td>
												{include file="advancesearch_popup.tpl"}
											</td>
										</tr>
									</table>

								</td>
							</tr>
						</table>

					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
{include file="popfooter.tpl"}
{/strip}
