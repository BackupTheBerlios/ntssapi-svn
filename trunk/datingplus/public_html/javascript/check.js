
var ErrorCount = 0; /* No of errors */
var ErrorMsg = new Array(); /* A list of all errors */
		
ErrorMsg[0]="------------------------- The Following Errors Occured -------------------------" + String.fromCharCode(10);

/* To validate the type of input values in the form fields */
function CheckFieldString(type, formField, strMsg) {

	var checkOK;
	var checkStr = formField.value;
  	var allValid = true;
	var flagDot  = false;
	var namestr, domainstr;
	
	if (type == 'noblank')
	{
		if (checkStr == "")
  		{
  			ErrorCount++;
	   	 	ErrorMsg[ErrorCount] = strMsg  + String.fromCharCode(10);
  		}
	} else 	{
		if (type == 'integer')	{
  			checkOK = "0123456789";
  		} else if (type == 'decimal'){	
  			checkOK = "0123456789.";
		} else if (type == 'text') {
			checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
		} else if (type == 'alphanumeric') {
			checkOK = "0123456789.+-_#,/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ()_";
		} else if (type == 'full') {
			checkOK = "0123456789.,[]{}=+-_#,/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ()_:;'\\*^%$@<>?'";
		} else if (type == 'alphanum') {
			checkOK = "0123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
		} else if (type == 'email'){
			checkOK = "0123456789_-@.ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
				if ( /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,7})+$/.test(checkStr) ){
				}else{
					ErrorCount++;
					ErrorMsg[ErrorCount] = strMsg  + String.fromCharCode(10);
				}
		} else if (type == 'phone') {
			checkOK = "0123456789-+";
		} else if (type == 'URL') {
			checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.:/\\";
		} else if (type == 'path') {
			checkOK = "0123456789.+-_#,/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz () \\ ";
		} else {
			ErrorMsg[1] = "Check Validation one of the mentioned validation type is wrong" + String.fromCharCode(10);
			ErrorCount++;
			return 1;
		}
		
		/* code for email validation */
		/* if ((type == 'email') && (checkStr != "")) {	
			
			namestr = checkStr.substring(0, checkStr.indexOf("@"));  // everything before the '@'
			domainstr = checkStr.substring(checkStr.indexOf("@")+1, checkStr.length); // everything after the '@'

			// Rules: namestr cannot be empty, or that would indicate no characters before the '@',
			// domainstr must contain a period that is not the first character (i.e. right after
			// the '@').  The last character must be an alpha.
   			if ((namestr.length == 0) || (domainstr.indexOf(".") <= 0) || (domainstr.indexOf("@") != -1)) {
   				ErrorCount++;
				ErrorMsg[ErrorCount] = "Enter a valid Email Address." + String.fromCharCode(10);
   			} 
		} */		

  		for (i = 0;  i < checkStr.length;  i++)
  		{
    		ch = checkStr.charAt(i);
			for (j = 0;  j < checkOK.length;  j++) {
	      		if (ch == checkOK.charAt(j)) {
					break; }
				if (j == checkOK.length){
					
					allValid = false;
					break;
				}
			}
		
			if (type == 'decimal') /* for decimal type */
			{
				for (t = 0;  t < checkStr.length;  t++){	
				
					dot = checkStr.charAt(t)
					if (dot =='.' && flagDot == false) {
						flagDot=true;
					} else if (dot =='.' && flagDot == true){
					
						ErrorCount++;
						ErrorMsg[ErrorCount] = strMsg + String.fromCharCode(10);
						break;
					}
				}
			}
				
			if (!allValid){
			
				ErrorCount++;
				ErrorMsg[ErrorCount] = strMsg  + String.fromCharCode(10);
			}
     	}
  	}
}
