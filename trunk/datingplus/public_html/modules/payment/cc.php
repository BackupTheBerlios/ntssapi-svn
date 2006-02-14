<?php
/*
  $Id: cc.php,v 1.53 2003/02/04 09:55:01 project3000 Exp $

  osCommerce, Open Source E-Commerce Solutions
  http://www.oscommerce.com

  Copyright (c) 2003 osCommerce

  Released under the GNU General Public License
*/

  class cc {
    var $code, $title;

// class constructor
    function cc() {

      $this->code = 'cc';
      $this->title = 'Credit Card';

    }

// class methods
    function update_status() {
    }

    function javascript_validation() {
      $js = '  if (payment_value == "' . $this->code . '") {' . "\n" .
            '    var cc_owner = document.checkout_payment.cc_owner.value;' . "\n" .
            '    var cc_number = document.checkout_payment.cc_number.value;' . "\n" .
            '    if (cc_owner == "" || cc_owner.length < ' . CC_OWNER_MIN_LENGTH . ') {' . "\n" .
            '      error_message = error_message + "' . MODULE_PAYMENT_CC_TEXT_JS_CC_OWNER . '";' . "\n" .
            '      error = 1;' . "\n" .
            '    }' . "\n" .
            '    if (cc_number == "" || cc_number.length < ' . CC_NUMBER_MIN_LENGTH . ') {' . "\n" .
            '      error_message = error_message + "' . MODULE_PAYMENT_CC_TEXT_JS_CC_NUMBER . '";' . "\n" .
            '      error = 1;' . "\n" .
            '    }' . "\n" .
            '  }' . "\n";

      return $js;
    }

    function process_button() {
			global $db, $t;

			include( ROOT_DIR . 'libs/cc_validation.php');
		
			$cc = $_POST['cc_number'];
		
			$exp_m = $_POST['cc_expires_Month'];
		
			$exp_y = substr( $_POST['cc_expires_Year'], -2);
		
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
		
			$t->assign( 'cc_owner', trim( $_POST['cc_owner'] ) );
		
			$t->assign( 'cc_type', $cc_validation->cc_type );
		
			$t->assign( 'cc_number', $cc_validation->cc_number );
		
			$t->assign( 'cvv', $cvv );
		
			$t->assign( 'cc_part1', substr( $cc_validation->cc_number,0,4) );
		
			$t->assign( 'cc_part2', substr( $cc_validation->cc_number,-4) );
		
			$t->assign( 'cc_expiry_month', $cc_validation->cc_expiry_month );
		
			$t->assign( 'cc_expiry_year', $cc_validation->cc_expiry_year );
		
			$t->assign( 'cc_expiry_date',  $cc_validation->cc_expiry_month . '' . substr($cc_validation->cc_expiry_year,-2) );
		
			$sqlconf = 'SELECT configuration_key, configuration_value from ! where module_key = ?';
			
			$confdata = $db->getAll( $sqlconf, array( TABLE_CONFIGURATION, 'cc' ) );
		
			foreach( $confdata as $confitem ) {
				
				$paymod_data[ $confitem['configuration_key'] ] = $confitem['configuration_value'];
				
			}

			$t->assign( 'invoice_num', date('YmdHis') );
		
			$t->assign( 'payment_method', 'Credit Card' );
		
			$t->assign('rendered_page', $t->fetch('cc_checkout.tpl') );

    }

    function before_process() {
/*      global $HTTP_POST_VARS, $order;

      if ( (defined('MODULE_PAYMENT_CC_EMAIL')) && (tep_validate_email(MODULE_PAYMENT_CC_EMAIL)) ) {
        $len = strlen($HTTP_POST_VARS['cc_number']);

        $this->cc_middle = substr($HTTP_POST_VARS['cc_number'], 4, ($len-8));
        $order->info['cc_number'] = substr($HTTP_POST_VARS['cc_number'], 0, 4) . str_repeat('X', (strlen($HTTP_POST_VARS['cc_number']) - 8)) . substr($HTTP_POST_VARS['cc_number'], -4);
      }
*/			
    }

    function after_process() {
/*      global $insert_id;

      if ( (defined('MODULE_PAYMENT_CC_EMAIL')) && (tep_validate_email(MODULE_PAYMENT_CC_EMAIL)) ) {
        $message = 'Order #' . $insert_id . "\n\n" . 'Middle: ' . $this->cc_middle . "\n\n";
        
        tep_mail('', MODULE_PAYMENT_CC_EMAIL, 'Extra Order Info: #' . $insert_id, $message, STORE_OWNER, STORE_OWNER_EMAIL_ADDRESS);
      }
*/
    }

    function check() {
      if (!isset($this->_check)) {
        $check_query = $db->query("select configuration_value from " . TABLE_CONFIGURATION . " where configuration_key = 'MODULE_PAYMENT_CC_STATUS'");
        $this->_check = $check_query->numRows();
      }
      return $this->_check;
    }

    function install() {
			global $db;
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Enable Credit Card Module', 'MODULE_PAYMENT_CC_STATUS', 'True', 'Do you want to accept credit card payments?', '6', '0', 'tep_cfg_select_option(array(\'True\', \'False\'), ', now(), 'cc')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Split Credit Card E-Mail Address', 'MODULE_PAYMENT_CC_EMAIL', '', 'If an e-mail address is entered, the middle digits of the credit card number will be sent to the e-mail address (the outside digits are stored in the database with the middle digits censored)', '6', '0', now(), 'cc')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Sort order of display.', 'MODULE_PAYMENT_CC_SORT_ORDER', '0', 'Sort order of display. Lowest is displayed first.', '6', '0' , now(), 'cc')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, use_function, set_function, date_added, module_key) values ('Payment Zone', 'MODULE_PAYMENT_CC_ZONE', '0', 'If a zone is selected, only enable this payment method for that zone.', '6', '2', 'tep_get_zone_class_title', 'tep_cfg_pull_down_zone_classes(', now(), 'cc')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, use_function, date_added, module_key) values ('Set Order Status', 'MODULE_PAYMENT_CC_ORDER_STATUS_ID', '0', 'Set the status of orders made with this payment module to this value', '6', '0', 'tep_cfg_pull_down_order_statuses(', 'tep_get_order_status_name', now(), 'cc')";
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
      return array('MODULE_PAYMENT_CC_STATUS', 'MODULE_PAYMENT_CC_EMAIL', 'MODULE_PAYMENT_CC_ZONE', 'MODULE_PAYMENT_CC_ORDER_STATUS_ID', 'MODULE_PAYMENT_CC_SORT_ORDER');
    }
  }
?>
