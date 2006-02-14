/* JavaScript Document */
<!--
function doSubmit() {
	var mfrm = document.frmSignup;

	if ( mfrm.txtusername.value == '' ) {
		alert ( 'Username is missing' );
		mfrm.txtusername.focus();
		return false;
	} else if ( isNumeric ( mfrm.txtusername.value.charAt(0) ) ) {
		alert ( 'Username must start with alphabet' );
		mfrm.txtusername.focus();
		return false;				
	} else if ( mfrm.txtpassword.value == '' ) {
		alert ( 'Please input password' );
		mfrm.txtpassword.focus();
		return false;
	} else if ( isNumeric( mfrm.txtpassword.value.charAt(0) ) ) {
		alert ( 'Password must start with alphabet' );
		mfrm.txtpassword.focus();
		return false;				
	} else if ( mfrm.txtpassword2.value == '' ) {
		alert ( 'Please input confirm password' );
		mfrm.txtpassword2.focus();
		return false;
	} else if ( isNumeric( mfrm.txtpassword2.value.charAt(0) ) ) {
		alert ( 'Confirm Password must start with alphabet' );
		mfrm.txtpassword2.focus();
		return false;				
	} else if ( mfrm.txtpassword.value != mfrm.txtpassword2.value ) {
		alert ( 'Password and Confirm Password must be same' );
		mfrm.txtpassword2.focus();
		return false;				
	} else if ( mfrm.txtfirstname.value == '' ) {
		alert ( 'Please input first name' );
		mfrm.txtfirstname.focus();
		return false;
	} else if ( isNumeric( mfrm.txtfirstname.value.charAt(0) ) ) {
		alert ( 'First name must start with alphabet' );
		mfrm.txtfirstname.focus();
		return false;				
	} else if ( !isAlphabetic( mfrm.txtfirstname.value ) ) {
		alert ( 'First name should be alphabetic' );
		mfrm.txtfirstname.focus();
		return false;				
	} else if ( mfrm.txtlastname.value == '' ) {
		alert ( 'Please input last name' );
		mfrm.txtlastname.focus();
		return false;
	} else if ( isNumeric( mfrm.txtlastname.value.charAt(0) ) ) {
		alert ( 'Last name must start with alphabet' );
		mfrm.txtlastname.focus();
		return false;				
	} else if ( !isAlphabetic( mfrm.txtlastname.value ) ) {
		alert ( 'Last name should be alphabetic' );
		mfrm.txtlastname.focus();
		return false;				
	} else if ( mfrm.txtemail.value == '' ) {
		alert ( 'Please input email' );
		mfrm.txtemail.focus();
		return false;
	} else if ( !isValidEmail( mfrm.txtemail.value ) ) {
		alert ( 'Please input valid email' );
		mfrm.txtemail.focus();
		return false;
	} else if ( mfrm.txtcity.value == '' ) {
		alert ( 'Please input city' );
		mfrm.txtcity.focus();
		return false;
	} else if ( isNumeric( mfrm.txtcity.value.charAt(0) ) ) {
		alert ( 'City name must start with alphabet' );
		mfrm.txtcity.focus();
		return false;				
	} else if ( mfrm.txtstateprovince.value == '' ) {
		alert ( 'Please input state or province' );
		mfrm.txtstateprovince.focus();
		return false;
	} else if ( mfrm.txtzip.value == '' ) {
		alert ( 'Please input zip code' );
		mfrm.txtzip.focus();
		return false;
	} else if ( mfrm.txtaddress1.value == '' ) {
		alert ( 'Please input address line 1' );
		mfrm.txtaddress1.focus();
		return false;
	} else {
		return true;
	}
	return false;
}

-->
