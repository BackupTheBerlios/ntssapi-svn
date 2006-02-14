if ( use_popups == undefined ) {
	var use_popups = true;
}

function isValidEmail( fieldValue ) {
	if ( /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,7})+$/.test(fieldValue) )
		return true;
	
	return false;
}


function isValidURL(url) {

	if ( url == null )
		return false;

/* space extr */
	var reg='^ *';
/* protocol */	
	reg = reg+'(?:([Hh][Tt][Tt][Pp](?:[Ss]?))(?:\:\\/\\/))?';
/* usrpwd */	
	reg = reg+'(?:(\\w+\\:\\w+)(?:\\@))?';
/* domain */
	reg = reg+'([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}|localhost|([Ww][Ww][Ww].|[a-zA-Z0-9].)[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,6})';
/* port */
	reg = reg+'(\\:\\d+)?';
/* path */
	reg = reg+'((?:\\/.*)*\\/?)?';
/* filename */
	reg = reg+'(.*?\\.(\\w{2,4}))?';
/* qrystr */
	reg = reg+'(\\?(?:[^\\#\\?]+)*)?';
/* bkmrk */
	reg = reg+'(\\#.*)?';
/* space extr */
	reg = reg+' *$';

	return url.match(reg);
}

/* returns true if checkStr contains only characters specified in checkOK
   probably can be replaced with a more efficient regular expression  */

function isValidString( checkStr, checkOK ) {

	if ( !checkOK )
		var checkOK = '';

	var allValid = true;

	for (i = 0;  i < checkStr.length;  i++) {
		ch = checkStr.charAt(i);
		
		for (j = 0;  j < checkOK.length;  j++)
			if (ch == checkOK.charAt(j))
				break;
		
		if (j == checkOK.length) {
			allValid = false;
			break;
		}
	}
	
	return allValid;
}

var alphabeticChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
var numericChars = "0123456789";

function isNumeric ( fieldValue ) {
	if ( /[0-9]/.test ( fieldValue ) )
		return true;
	return false;
}

function isNumeric( val, addChars ) {
	return isValidString( val, numericChars + addChars );
}

function isAlphabetic( val ) {
	if ( /[A-Za-z]/.test ( val ) )
		return true;
	return false;
}

function isAlphabetic( val, addChars ) {
	return isValidString( val, alphabeticChars + addChars );
}

function isAlphaNumeric( val ) {
	if ( /\w/.test ( val ) )
		return true;
	return false;
}

function isAlphaNumeric( val, addChars ) {
	return isValidString( val, alphabeticChars + numericChars + addChars );
}

function DispDispHide ( disp1, disp2, hide )
{
    if (hide) hide.style.display = 'none';
    if (disp1) disp1.style.display = 'inline';
    if (disp2) disp2.style.display = 'inline';
}

function DispHideHide ( disp, hide1, hide2 )
{
    if (hide1) hide1.style.display = 'none';
    if (hide2) hide2.style.display = 'none';
    if (disp) disp.style.display = 'inline';
}

function showHide( paramA, paramB)
{
	if (paramA.value == 'US') 
		paramB.rows['row_usstates'].style.display ='inline';
	else
		paramB.rows['row_usstates'].style.display = 'none';
		
	if (paramA.value == 'CA') 
		paramB.rows['row_castates'].style.display ='inline';
	else
		paramB.rows['row_castates'].style.display = 'none';
		
	if (paramA.value == 'AU') 
		paramB.rows['row_austates'].style.display ='inline';
	else
		paramB.rows['row_austates'].style.display = 'none';
		
	if (paramA.value == 'GB') 
		paramB.rows['row_gbstates'].style.display ='inline';
	else
		paramB.rows['row_gbstates'].style.display = 'none';
		
}

function showHide( paramA)
{
	if (paramA == 'US' ) {
		document.getElementById('row_usstates').style.display ='inline';
	} else {
		document.getElementById('row_usstates').style.display = 'none';
	}
	if (paramA == 'CA') { 
		document.getElementById('row_castates').style.display ='inline';
	} else {
		document.getElementById('row_castates').style.display = 'none';
	}
	if (paramA == 'AU') { 
		document.getElementById('row_austates').style.display ='inline';
	} else {
		document.getElementById('row_austates').style.display = 'none';
	}
	if (paramA == 'GB') { 
		document.getElementById('row_gbstates').style.display ='inline';
	} else {
		document.getElementById('row_gbstates').style.display = 'none';
	}
}

function showHidePref( paramA, paramB)
{
	if (paramA.value == 'US') {
		paramB.rows['row_lookusstates'].style.display ='inline';
	} else {
		paramB.rows['row_lookusstates'].style.display = 'none';
	}
	if (paramA.value == 'CA') {
		paramB.rows['row_lookcastates'].style.display ='inline';
	} else {
		paramB.rows['row_lookcastates'].style.display = 'none';
	}
	if (paramA.value == 'AU') { 
		paramB.rows['row_lookaustates'].style.display ='inline';
	} else {
		paramB.rows['row_lookaustates'].style.display = 'none';
	}
	if (paramA.value == 'GB') { 
		paramB.rows['row_lookgbstates'].style.display ='inline';
	} else {
		paramB.rows['row_lookgbstates'].style.display = 'none';
	}
}

function showHidePref( paramA)
{
	if (paramA == 'US' ) {
		document.getElementById('row_lookusstates').style.display ='inline';
	} else {
		document.getElementById('row_lookusstates').style.display = 'none';
	}
	if (paramA == 'CA') { 
		document.getElementById('row_lookcastates').style.display ='inline';
	} else {
		document.getElementById('row_lookcastates').style.display = 'none';
	}
	if (paramA == 'AU') { 
		document.getElementById('row_lookaustates').style.display ='inline';
	} else {
		document.getElementById('row_lookaustates').style.display = 'none';
	}
	if (paramA == 'GB') {
		document.getElementById('row_lookgbstates').style.display ='inline';
	} else {
		document.getElementById('row_lookgbstates').style.display = 'none';
	}
}

function openWin(id)
{
	if ( use_popups == false ) {
		window.location.href = 'viewresult.php?pollid=' + id;
		return;
	}

	var width=550;
	var height=378;
	var left = (screen.width/2) - width/2;
	var top = (screen.height/2) - height/2;
	
	openpopup=window.open('viewresult.php?pollid=' + id ,'','width='+width+',height='+height+',left='+left+',top='+top+',resizable=yes,scrollbars=yes,status=no');
	openpopup.opener.name='abc';
}

function previousPolls(){

	if ( use_popups == false ) {
		window.location.href = 'previouspolls.php';
		return;
	}

	var width=600;
	var height=378;
	var left = (screen.width/2) - width/2;
	var top = (screen.height/2) - height/2;
	
	openpopup=window.open('previouspolls.php' ,'popupwin','width='+width+',height='+height+',left='+left+',top='+top+',resizable=yes,scrollbars=yes,status=no');
	openpopup.opener.name="abc";
}


function launchTellFriend ()
{
	if ( use_popups == false ) {
		window.location.href = 'tellafriend.php';
		return;
	}

	var left = (screen.width/2) - 280/2;
	var top = (screen.height/2) - 280/2;
	var win = "width=280,height=250,left=" + left + ",top=" + top + ",copyhistory=no,directories=no,menubar=no,location=no,resizable=yes,scrollbars=yes";
	window.open("tellafriend.php",'tellfriend',win);
}

function launchTellFriendProfile ( sID )
{
	if ( use_popups == false ) {
		window.location.href = 'tellafriend.php?ID=' + sID;
		return;
	}

	var left = (screen.width/2) - 280/2;
	var top = (screen.height/2) - 280/2;
	var win = "width=280,height=300,left=" + left + ",top=" + top + ",copyhistory=no,directories=no,menubar=no,location=no,resizable=yes,scrollbars=yes";
	window.open("tellfriend.php?ID=" + sID,'tellfriendprofile',win);
}

var popUpWin=0;

function popUpWindow(URLStr, left, top, width, height)
{
	if ( use_popups == false ) {
		window.location.href = URLStr;
		return;
	}

	if(popUpWin)
	{
		if(!popUpWin.closed) {popUpWin.close();}
	}
	popUpWin = open(URLStr, 'popUpWin', 'toolbar=no,location=yes,directories=no,status=no,menubar=no,scrollbar=no,resizable=yes,copyhistory=yes,width='+width+',height='+height+',left='+left+', top='+top+',screenX='+left+',screenY='+top+'');
}

function showIM(msgid){
	popUpWindow('showinstantmsg.php?id=' + msgid,'center',320,260,msgid);
}

function popUpWindow(URLStr, align, width, height, msgid)
{
	if ( use_popups == false ) {
		window.location.href = URLStr;
		return;
	}

/*	if(popUpWin){
	
		if(!popUpWin.closed) popUpWin.close();
	}

*/
	if( align == 'center' ){
	
		var left = (screen.width/2) - width/2;
		var top = (screen.height/2) - height/2;
	} else {
	
		var left = 0;
		var top = 0;	
	}
	
	popUpWin = open(URLStr, 'popUpWin'+msgid, 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbar=no,resizable=yes,copyhistory=yes,width='+width+',height='+height+',left='+left+', top='+top+',screenX='+left+',screenY='+top+'');
}


function popUpScrollWindow(URLStr, align, width, heightParam)
{
	if ( use_popups == false ) {
		window.location.href = URLStr;
		return;
	}

	height = screen.height - 150;
	height = Math.min( height, heightParam );
	
/*	if(popUpWin){
	
		if(!popUpWin.closed) { popUpWin.close(); }
	}
*/
	if( align == 'center' ){
	
		var left = (screen.width/2) - width/2;
		var top = (screen.height/2) - height/2;
	}else if( align == 'top' ){
	
		var left = (screen.width/2) - width/2;
		var top = 0;
	}else{
	
		var left = 0;
		var top = 0;	
	}
	
	popUpWin = open(URLStr, 'popUpWin', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=yes,width='+width+',height='+height+',left='+left+', top='+top+',screenX='+left+',screenY='+top+'');
	popUpWin.opener.name="abc1";	
}

function popUpScrollWindow2 (URLStr, align, width, heightParam)
{
	if ( use_profilepopups == false ) {
		window.location.href = URLStr;
		return;
	}

	height = screen.height - 150;
	height = Math.min( height, heightParam );
	
/*	if(popUpWin){
	
		if(!popUpWin.closed) { popUpWin.close(); }
	}
*/
	if( align == 'center' ){
	
		var left = (screen.width/2) - width/2;
		var top = (screen.height/2) - height/2;
	}else if( align == 'top' ){
	
		var left = (screen.width/2) - width/2;
		var top = 0;
	}else{
	
		var left = 0;
		var top = 0;	
	}
	
	popUpWin = open(URLStr, 'popUpWin', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=yes,width='+width+',height='+height+',left='+left+', top='+top+',screenX='+left+',screenY='+top+'');
	popUpWin.opener.name="abc1";	
}

var prevRow = null;

function toggleRow(rwId, num){

	if( prevRow != null ) {
		prevRow.style.display ='none';
	}
	prevRow = obj = document.getElementById(rwId);
	obj.style.display ='inline';
	
	for( i=0; i<document.getElementById('tblSelect').length ; i++ ){
	
		if( i == num ) {
			document.getElementById('tblSelect')[i].className = "s_table_blue";
		} else {
			document.getElementById('tblSelect')[i].className = "s_table_white";
		}
	}
}


function votesubmit(id,curtime)
{
	var width=600;
	var height=378;
	var left = (screen.width/2) - width/2;
	var top = (screen.height/2) - height/2;

	nop = document.frmpoll.rdo.length;
	var i, rdo;
	rdo = '0';
	for (i=0 ; i<nop ; i++)
	{
		if (document.frmpoll.rdo[i].checked)
		{
			rdo = document.frmpoll.rdo[i].value;
		}
	}
	if ( use_popups == false ) {
		if ( rdo == "" ) {
			window.location.href = 'viewresult.php?t=' + curtime + '&pollid=' + id;
		}
		else {
			window.location.href = 'votehere.php?t=' + curtime + '&rdo=' + rdo + '&pollid=' + id;
		}
		return;
	}
	
	if (rdo=="")
	{
		openpopup=window.open('viewresult.php?t=' + curtime + '&pollid=' + id ,'','width='+width+',height='+height+',left='+left+',top='+top+',resizable=yes,scrollbars=yes,status=no');
		openpopup.opener.name='abc';
	} else {
		openpopup=window.open('votehere.php?t=' + curtime + '&rdo=' + rdo + '&pollid=' + id ,'','width='+width+',height='+height+',left='+left+',top='+top+',resizable=yes,scrollbars=yes,status=no');
		openpopup.opener.name='abc';
	}
}

function selectRdo(form,rdo){

	for( i=0 ; i < form.length ; i++ ) {
		if( form.elements[i].type=='radio' && form.elements[i].name=='searchby' 
			&& form.elements[i].value == rdo ) {
			form.elements[i].checked=true;
		}
	}
}

function checkAll(form,name,val){
	for( i=0 ; i < form.length ; i++) {
		if( form.elements[i].type == 'checkbox' && form.elements[i].name == name ) {
			form.elements[i].checked = val;
		}
	}
}

function datefromtovalid(sy,sm,sd,ey,em,ed,msg)
{
	month=new Array("JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC")
	var syear=sy[sy.selectedIndex].value;
	var smonth=sm[sm.selectedIndex].value;
	var sdays=sd[sd.selectedIndex].value;
	var eyear=ey[ey.selectedIndex].value;
	var emonth=em[em.selectedIndex].value;
	var edays=ed[ed.selectedIndex].value;
	for (var count=0;count<12;count++)
	{
		if ((smonth== month[count]))
		{
			smonth=count;
		}
		if ((emonth== month[count]))
		{
			emonth=count;
		}
	}
	from_date=new Date(syear,smonth,sdays);
	to_date=new Date(eyear,emonth,edays);
	if (from_date > to_date) 
	{
	 	alert(msg);
	 	return false;
	}
	return true;
}

function DateCheck(syr, smt, sdt, msg)
{
   hdt=sdt[sdt.selectedIndex].value;
   hmt=smt[smt.selectedIndex].value;
   hyr=syr[syr.selectedIndex].value;

   hms_maxval=31;
   if ((hmt=="APR") || (hmt=="JUN") || (hmt=="SEP") || (hmt=="NOV")){hms_maxval=30;}
   if ((hmt=="FEB") && (hyr%4)==0){hms_maxval=29;}
   if ((hmt=="FEB") && (hyr%4)!=0){hms_maxval=28;}
   if (parseInt(hdt)>hms_maxval) 
   {
      alert(msg);
      return false;
   }
   return true;
}



function validateLogin(form)
{
	ErrorMsg = new Array();
	ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(13);

	CheckFieldString("noblank",form.txtusername,"{$lang.signup_js_errors.username_noblank}");
	CheckFieldString("noblank",form.txtpassword,"{$lang.signup_js_errors.password_noblank}");

	CheckFieldString("alphanum",form.txtusername,"{$lang.signup_js_errors.username_charset}");
	CheckFieldString("alphanum",form.txtpassword,"{$lang.signup_js_errors.password_charset}");

	/* concat all error messages into one string */
	result="";
	if( ErrorCount > 0)
	{
		alert(ErrorMsg[1]);
		return false;
	}
	return true;
}
