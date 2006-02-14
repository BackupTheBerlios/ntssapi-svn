<?php
/*
  $Id: ipayment.php,v 1.32 2003/01/29 19:57:14 hpdl Exp $

  osCommerce, Open Source E-Commerce Solutions
  http://www.oscommerce.com

  Copyright (c) 2003 osCommerce

  Released under the GNU General Public License
*/

  class ipayment {
    var $code, $title;

// class constructor
    function ipayment() {

      $this->code = 'ipayment';
      $this->title = 'iPayment';

      $this->form_action_url = 'https://ipayment.de/merchant/' . MODULE_PAYMENT_IPAYMENT_ID . '/processor.php';
    }

// class methods

    function javascript_validation() {
      $js = '  if (payment_value == "' . $this->code . '") {' . "\n" .
            '    var cc_owner = document.checkout_payment.ipayment_cc_owner.value;' . "\n" .
            '    var cc_number = document.checkout_payment.ipayment_cc_number.value;' . "\n" .
            '    if (cc_owner == "" || cc_owner.length < ' . CC_OWNER_MIN_LENGTH . ') {' . "\n" .
            '      error_message = error_message + "' . MODULE_PAYMENT_IPAYMENT_TEXT_JS_CC_OWNER . '";' . "\n" .
            '      error = 1;' . "\n" .
            '    }' . "\n" .
            '    if (cc_number == "" || cc_number.length < ' . CC_NUMBER_MIN_LENGTH . ') {' . "\n" .
            '      error_message = error_message + "' . MODULE_PAYMENT_IPAYMENT_TEXT_JS_CC_NUMBER . '";' . "\n" .
            '      error = 1;' . "\n" .
            '    }' . "\n" .
            '  }' . "\n";

      return $js;
    }

    function process_button() {
			global $db, $t;

			include( ROOT_DIR . 'libs/cc_validation.php');
		
			$cc = $_POST['ipayment_cc_number'];
		
			$cvv = $_POST['ipayment_cc_cvv'];
		
			$exp_m = $_POST['ipayment_cc_expires_Month'];
		
			$exp_y = substr( $_POST['ipayment_cc_expires_Year'], -2);
		
			$cc_validation = new cc_validation();
		
			$result = $cc_validation->validate($cc,$exp_m,$exp_y);
		
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
		
			$t->assign( 'cc_owner', trim( $_POST['ipayment_cc_owner'] ) );
		
			$t->assign( 'cc_type', $cc_validation->cc_type );
		
			$t->assign( 'cc_number', $cc_validation->cc_number );
		
			$t->assign( 'cvv', $cvv );
		
			$t->assign( 'cc_part1', substr( $cc_validation->cc_number,0,4) );
		
			$t->assign( 'cc_part2', substr( $cc_validation->cc_number,-4) );
		
			$t->assign( 'cc_expiry_month', $cc_validation->cc_expiry_month );
		
			$t->assign( 'cc_expiry_year', $cc_validation->cc_expiry_year );
		
			$t->assign( 'cc_expiry_date',  $cc_validation->cc_expiry_month . '' . substr($cc_validation->cc_expiry_year,-2) );
		
			$sqlconf = 'SELECT configuration_key, configuration_value from ! where module_key = ?';
			
			$confdata = $db->getAll( $sqlconf, array( TABLE_CONFIGURATION, 'ipayment' ) );
		
			foreach( $confdata as $confitem ) {
				
				$paymod_data[ $confitem['configuration_key'] ] = $confitem['configuration_value'];
				
			}

			$t->assign( 'invoice_num', date('YmdHis') );
		
			$t->assign( 'payment_method', 'iPayment' );

			$t->assign( 'trx_id', $paymod_data['MODULE_PAYMENT_IPAYMENT_ID'] );

			$t->assign( 'trxuser_id', $paymod_data['MODULE_PAYMENT_IPAYMENT_USER_ID'] );

			$t->assign( 'trxpassword', $paymod_data['MODULE_PAYMENT_IPAYMENT_PASSWORD'] );
		
			$t->assign('rendered_page', $t->fetch('ipayment_checkout.tpl') );

    }

    function before_process() {
      return false;
    }

    function after_process() {
      return false;
    }

    function get_error() {
      global $HTTP_GET_VARS;

      $error = array('title' => IPAYMENT_ERROR_HEADING,
                     'error' => ((isset($HTTP_GET_VARS['error'])) ? stripslashes(urldecode($HTTP_GET_VARS['error'])) : IPAYMENT_ERROR_MESSAGE));

      return $error;
    }

    function check() {
      if (!isset($this->_check)) {
        $check_query = $db->query("select configuration_value from " . TABLE_CONFIGURATION . " where configuration_key = 'MODULE_PAYMENT_IPAYMENT_STATUS'");
        $this->_check = $check_query->numRows();
      }
      return $this->_check;
    }

    function install() {

 			global $db;

	    $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Enable iPayment Module', 'MODULE_PAYMENT_IPAYMENT_STATUS', 'True', 'Do you want to accept iPayment payments?', '6', '1', 'tep_cfg_select_option(array(\'True\', \'False\'), ', now(), 'ipayment')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Account Number', 'MODULE_PAYMENT_IPAYMENT_ID', '99999', 'The account number used for the iPayment service', '6', '2', now(), 'ipayment')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('User ID', 'MODULE_PAYMENT_IPAYMENT_USER_ID', '99999', 'The user ID for the iPayment service', '6', '3', now(), 'ipayment')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('User Password', 'MODULE_PAYMENT_IPAYMENT_PASSWORD', '0', 'The user password for the iPayment service', '6', '4', now(), 'ipayment')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Transaction Currency', 'MODULE_PAYMENT_IPAYMENT_CURRENCY', 'Either EUR or USD, else EUR', 'The currency to use for credit card transactions', '6', '5', 'tep_cfg_select_option(array(\'Always EUR\', \'Always USD\', \'Either EUR or USD, else EUR\', \'Either EUR or USD, else USD\'), ', now(), 'ipayment')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Sort order of display.', 'MODULE_PAYMENT_IPAYMENT_SORT_ORDER', '0', 'Sort order of display. Lowest is displayed first.', '6', '0', now(), 'ipayment')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, use_function, set_function, date_added, module_key) values ('Payment Zone', 'MODULE_PAYMENT_IPAYMENT_ZONE', '0', 'If a zone is selected, only enable this payment method for that zone.', '6', '2', 'tep_get_zone_class_title', 'tep_cfg_pull_down_zone_classes(', now(), 'ipayment')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, use_function, date_added, module_key) values ('Set Order Status', 'MODULE_PAYMENT_IPAYMENT_ORDER_STATUS_ID', '0', 'Set the status of orders made with this payment module to this value', '6', '0', 'tep_cfg_pull_down_order_statuses(', 'tep_get_order_status_name', now(), 'ipayment')";
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
      return array('MODULE_PAYMENT_IPAYMENT_STATUS', 'MODULE_PAYMENT_IPAYMENT_ID', 'MODULE_PAYMENT_IPAYMENT_USER_ID', 'MODULE_PAYMENT_IPAYMENT_PASSWORD', 'MODULE_PAYMENT_IPAYMENT_CURRENCY', 'MODULE_PAYMENT_IPAYMENT_ZONE', 'MODULE_PAYMENT_IPAYMENT_ORDER_STATUS_ID', 'MODULE_PAYMENT_IPAYMENT_SORT_ORDER');
    }
  }
?>
