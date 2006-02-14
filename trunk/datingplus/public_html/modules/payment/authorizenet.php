<?php
/*
  $Id: authorizenet.php,v 1.48 2003/04/10 21:42:30 project3000 Exp $

  osCommerce, Open Source E-Commerce Solutions
  http://www.oscommerce.com

  Copyright (c) 2003 osCommerce

  Released under the GNU General Public License
*/

  class authorizenet {
    var $code, $title;

// class constructor
    function authorizenet() {

      $this->code = 'authorizenet';
      $this->title = 'Authorize.Net';

      $this->form_action_url = 'https://secure.authorize.net/gateway/transact.dll';
    }

// Authorize.net utility functions
// DISCLAIMER:
//     This code is distributed in the hope that it will be useful, but without any warranty; 
//     without even the implied warranty of merchantability or fitness for a particular purpose.

// Main Interfaces:
//
// function InsertFP ($loginid, $txnkey, $amount, $sequence) - Insert HTML form elements required for SIM
// function CalculateFP ($loginid, $txnkey, $amount, $sequence, $tstamp) - Returns Fingerprint.

// compute HMAC-MD5
// Uses PHP mhash extension. Pl sure to enable the extension
// function hmac ($key, $data) {
//   return (bin2hex (mhash(MHASH_MD5, $data, $key)));
//}

// Thanks is lance from http://www.php.net/manual/en/function.mhash.php
//lance_rushing at hot* spamfree *mail dot com
//27-Nov-2002 09:36 
// 
//Want to Create a md5 HMAC, but don't have hmash installed?
//
//Use this:

function hmac ($key, $data)
{
   // RFC 2104 HMAC implementation for php.
   // Creates an md5 HMAC.
   // Eliminates the need to install mhash to compute a HMAC
   // Hacked by Lance Rushing

   $b = 64; // byte length for md5
   if (strlen($key) > $b) {
       $key = pack("H*",md5($key));
   }
   $key  = str_pad($key, $b, chr(0x00));
   $ipad = str_pad('', $b, chr(0x36));
   $opad = str_pad('', $b, chr(0x5c));
   $k_ipad = $key ^ $ipad ;
   $k_opad = $key ^ $opad;

   return md5($k_opad  . pack("H*",md5($k_ipad . $data)));
}
// end code from lance (resume authorize.net code)

// Calculate and return fingerprint
// Use when you need control on the HTML output
function CalculateFP ($loginid, $txnkey, $amount, $sequence, $tstamp, $currency = "") {
  return ($this->hmac ($txnkey, $loginid . "^" . $sequence . "^" . $tstamp . "^" . $amount . "^" . $currency));
}

// Inserts the hidden variables in the HTML FORM required for SIM
// Invokes hmac function to calculate fingerprint.

function InsertFP ($loginid, $txnkey, $amount, $sequence, $currency = "") {
  $tstamp = time ();
  $fingerprint = $this->hmac ($txnkey, $loginid . "^" . $sequence . "^" . $tstamp . "^" . $amount . "^" . $currency);

  $str = tep_draw_hidden_field('x_fp_sequence', $sequence) .
         tep_draw_hidden_field('x_fp_timestamp', $tstamp) .
         tep_draw_hidden_field('x_fp_hash', $fingerprint);

  return $str;
}
// end authorize.net code

// class methods

    function javascript_validation() {
      $js = '  if (payment_value == "' . $this->code . '") {' . "\n" .
            '    var cc_owner = document.checkout_payment.authorizenet_cc_owner.value;' . "\n" .
            '    var cc_number = document.checkout_payment.authorizenet_cc_number.value;' . "\n" .
            '    if (cc_owner == "" || cc_owner.length < ' . CC_OWNER_MIN_LENGTH . ') {' . "\n" .
            '      error_message = error_message + "' . MODULE_PAYMENT_AUTHORIZENET_TEXT_JS_CC_OWNER . '";' . "\n" .
            '      error = 1;' . "\n" .
            '    }' . "\n" .
            '    if (cc_number == "" || cc_number.length < ' . CC_NUMBER_MIN_LENGTH . ') {' . "\n" .
            '      error_message = error_message + "' . MODULE_PAYMENT_AUTHORIZENET_TEXT_JS_CC_NUMBER . '";' . "\n" .
            '      error = 1;' . "\n" .
            '    }' . "\n" .
            '  }' . "\n";

      return $js;
    }

    function process_button() {

			global $db, $t, $lang, $amount;
		
			include( ROOT_DIR . 'libs/cc_validation.php');
		
			$cc = $_POST['authorizenet_cc_number'];
		
			$exp_m = $_POST['authorizenet_cc_expires_Month'];
		
			$exp_y = substr( $_POST['authorizenet_cc_expires_Year'], -2);
		
			$cc_validation = new cc_validation();
		
			$result = $cc_validation->validate( $cc, $exp_m, $exp_y );
		
			$error = '';
		
			switch ($result) {
				case -1:
					$error = $lang['cc_unknown'] . '<br />' .  substr($cc_validation->cc_number, 0, 4) . 'XXXXXXXXXXXX';
					break;
		
				case -2:
				case -3:
				case -4:
					$error = $lang['cc_invalid_date'];
					break;
		
				case false:
					$error = $lang['cc_invalid_number'];
					break;
			}
		
			if ( ($result == false) || ($result < 1) ) {
		
				header( 'location:payment.php?err=' . $error );
				exit;
		
			}
			$t->assign( 'cc_owner', trim( $_POST['authorizenet_cc_owner'] ) );
		
			$t->assign( 'cc_type', $cc_validation->cc_type );
		
			$t->assign( 'cc_number', $cc_validation->cc_number );
		
			$t->assign( 'cc_part1', substr( $cc_validation->cc_number,0,4) );
		
			$t->assign( 'cc_part2', substr( $cc_validation->cc_number,-4) );
		
			$t->assign( 'cc_expiry_month', $cc_validation->cc_expiry_month );
		
			$t->assign( 'cc_expiry_year', $cc_validation->cc_expiry_year );
		
			$t->assign( 'cc_expiry_date',  $cc_validation->cc_expiry_month . '' . substr($cc_validation->cc_expiry_year,-2) );
		
			$sequence = rand( 1, 1000 );
		
			$sqlconf = 'SELECT configuration_key, configuration_value from ! where module_key = ?';
			
			$confdata = $db->getAll( $sqlconf, array( TABLE_CONFIGURATION, 'authorizenet' ) );
			
			foreach( $confdata as $confitem ) {
				
				$paymod_data[ $confitem['configuration_key'] ] = $confitem['configuration_value'];
				
			}

		
			$tstamp = time();
		
			$fp = CalculateFP ( $paymod_data['MODULE_PAYMENT_AUTHORIZENET_LOGIN'], $paymod_data['MODULE_PAYMENT_AUTHORIZENET_TXNKEY'], $amount, $sequence, $tstamp );
		
			$t->assign( 'payment_method', 'Authorize.Net' );
		
			$t->assign( 'loginid', $paymod_data['MODULE_PAYMENT_AUTHORIZENET_LOGIN'] );
		
			$t->assign( 'trans_mode', $paymod_data['MODULE_PAYMENT_AUTHORIZENET_TESTMODE'] );
		
			$t->assign( 'trans_method', $paymod_data['MODULE_PAYMENT_AUTHORIZENET_METHOD'] );
		
			$t->assign( 'sequence', $sequence );
		
			$t->assign( 'tstamp', $tstamp );
		
			$t->assign( 'fp', $fp );
		
			$t->assign('rendered_page', $t->fetch('authorizenet_checkout.tpl') );
		
    }

    function before_process() {
      global $HTTP_POST_VARS;

      if ($HTTP_POST_VARS['x_response_code'] == '1') return;
      if ($HTTP_POST_VARS['x_response_code'] == '2') {
        tep_redirect(tep_href_link(FILENAME_CHECKOUT_PAYMENT, 'error_message=' . urlencode(MODULE_PAYMENT_AUTHORIZENET_TEXT_DECLINED_MESSAGE), 'SSL', true, false));
      }
      // Code 3 is an error - but anything else is an error too (IMHO)
      tep_redirect(tep_href_link(FILENAME_CHECKOUT_PAYMENT, 'error_message=' . urlencode(MODULE_PAYMENT_AUTHORIZENET_TEXT_ERROR_MESSAGE), 'SSL', true, false));
    }

    function after_process() {
      return false;
    }

    function get_error() {
      global $HTTP_GET_VARS;

      $error = array('title' => MODULE_PAYMENT_AUTHORIZENET_TEXT_ERROR,
                     'error' => stripslashes(urldecode($HTTP_GET_VARS['error'])));

      return $error;
    }

    function check() {
      if (!isset($this->_check)) {
        $check_query = $db->query("select configuration_value from " . TABLE_CONFIGURATION . " where configuration_key = 'MODULE_PAYMENT_AUTHORIZENET_STATUS'");
        $this->_check = $check_query->numRows();
      }
      return $this->_check;
    }

    function install() {
			global $db;
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Enable Authorize.net Module', 'MODULE_PAYMENT_AUTHORIZENET_STATUS', 'True', 'Do you want to accept Authorize.net payments?', '6', '0', 'tep_cfg_select_option(array(\'True\', \'False\'), ', now(), 'authorizenet')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Login Username', 'MODULE_PAYMENT_AUTHORIZENET_LOGIN', 'testing', 'The login username used for the Authorize.net service', '6', '0', now(), 'authorizenet')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Transaction Key', 'MODULE_PAYMENT_AUTHORIZENET_TXNKEY', 'Test', 'Transaction Key used for encrypting TP data', '6', '0', now(), 'authorizenet')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Transaction Mode', 'MODULE_PAYMENT_AUTHORIZENET_TESTMODE', 'Test', 'Transaction mode used for processing orders', '6', '0', 'tep_cfg_select_option(array(\'Test\', \'Production\'), ', now(), 'authorizenet')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Transaction Method', 'MODULE_PAYMENT_AUTHORIZENET_METHOD', 'Credit Card', 'Transaction method used for processing orders', '6', '0', 'tep_cfg_select_option(array(\'Credit Card\', \'eCheck\'), ', now(), 'authorizenet')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Customer Notifications', 'MODULE_PAYMENT_AUTHORIZENET_EMAIL_CUSTOMER', 'False', 'Should Authorize.Net e-mail a receipt to the customer?', '6', '0', 'tep_cfg_select_option(array(\'True\', \'False\'), ', now(), 'authorizenet')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Sort order of display.', 'MODULE_PAYMENT_AUTHORIZENET_SORT_ORDER', '0', 'Sort order of display. Lowest is displayed first.', '6', '0', now(), 'authorizenet')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, use_function, set_function, date_added, module_key) values ('Payment Zone', 'MODULE_PAYMENT_AUTHORIZENET_ZONE', '0', 'If a zone is selected, only enable this payment method for that zone.', '6', '2', 'tep_get_zone_class_title', 'tep_cfg_pull_down_zone_classes(', now(), 'authorizenet')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, use_function, date_added, module_key) values ('Set Order Status', 'MODULE_PAYMENT_AUTHORIZENET_ORDER_STATUS_ID', '0', 'Set the status of orders made with this payment module to this value', '6', '0', 'tep_cfg_pull_down_order_statuses(', 'tep_get_order_status_name', now(), 'authorizenet')";
			$db->query( $sqlupd );
    }

		function update( $configuration ) {
			global $db;
			while (list ($key, $val) = each ($configuration)) {
				$sqlupd = "update ! set configuration_value = ? where configuration_key = ? ";
				$db->query( $sqlupd, array( TABLE_CONFIGURATION, $val, $key ) );
			}
		}

    function remove() {
			global $db;
      $sqlupd = "delete from " . TABLE_CONFIGURATION . " where configuration_key in ('" . implode("', '", $this->keys()) . "')";
			$db->query( $sqlupd );
    }

    function keys() {
      return array('MODULE_PAYMENT_AUTHORIZENET_STATUS', 'MODULE_PAYMENT_AUTHORIZENET_LOGIN', 'MODULE_PAYMENT_AUTHORIZENET_TXNKEY', 'MODULE_PAYMENT_AUTHORIZENET_TESTMODE', 'MODULE_PAYMENT_AUTHORIZENET_METHOD', 'MODULE_PAYMENT_AUTHORIZENET_EMAIL_CUSTOMER', 'MODULE_PAYMENT_AUTHORIZENET_ZONE', 'MODULE_PAYMENT_AUTHORIZENET_ORDER_STATUS_ID', 'MODULE_PAYMENT_AUTHORIZENET_SORT_ORDER');
    }
  }
?>
