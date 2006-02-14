<?php
/*
  $Id: pm2checkout.php,v 1.19 2003/01/29 19:57:15 hpdl Exp $

  osCommerce, Open Source E-Commerce Solutions
  http://www.oscommerce.com

  Copyright (c) 2003 osCommerce

  Released under the GNU General Public License
*/

  class pm2checkout {
    var $code, $title;

// class constructor
    function pm2checkout() {

      $this->code = 'pm2checkout';
      $this->title = '2CheckOut.com';

      $this->form_action_url = 'https://www.2checkout.com/cgi-bin/Abuyers/purchase.2c';
    }

// class methods
    function javascript_validation() {
      $js = '  if (payment_value == "' . $this->code . '") {' . "\n" .
            '    var cc_number = document.checkout_payment.pm_2checkout_cc_number.value;' . "\n" .
            '    if (cc_number == "" || cc_number.length < ' . CC_NUMBER_MIN_LENGTH . ') {' . "\n" .
            '      error_message = error_message + "' . MODULE_PAYMENT_2CHECKOUT_TEXT_JS_CC_NUMBER . '";' . "\n" .
            '      error = 1;' . "\n" .
            '    }' . "\n" .
            '  }' . "\n";

      return $js;
    }

    function process_button() {

			global $db, $t;

			include( ROOT_DIR . 'libs/cc_validation.php');
		
			$cc = $_POST['pm_2checkout_cc_number'];
		
			$cvv = $_POST['pm_2checkout_cc_cvv'];
		
			$exp_m = $_POST['pm_2checkout_cc_expires_Month'];
		
			$exp_y = substr( $_POST['pm_2checkout_cc_expires_Year'], -2);
		
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
		
			$t->assign( 'cc_owner', trim( $_POST['pm_2checkout_cc_owner'] ) );
		
			$t->assign( 'cc_type', $cc_validation->cc_type );
		
			$t->assign( 'cc_number', $cc_validation->cc_number );
		
			$t->assign( 'cvv', $cvv );
		
			$t->assign( 'cc_part1', substr( $cc_validation->cc_number,0,4) );
		
			$t->assign( 'cc_part2', substr( $cc_validation->cc_number,-4) );
		
			$t->assign( 'cc_expiry_month', $cc_validation->cc_expiry_month );
		
			$t->assign( 'cc_expiry_year', $cc_validation->cc_expiry_year );
		
			$t->assign( 'cc_expiry_date',  $cc_validation->cc_expiry_month . '' . substr($cc_validation->cc_expiry_year,-2) );
		
			$sqlconf = 'SELECT configuration_key, configuration_value from ! where module_key = ?';
			
			$confdata = $db->getAll( $sqlconf, array( TABLE_CONFIGURATION, 'pm2checkout' ) );
		
			foreach( $confdata as $confitem ) {
				
				$paymod_data[ $confitem['configuration_key'] ] = $confitem['configuration_value'];
				
			}

			$t->assign( 'invoice_num', date('YmdHis') );
		
			$t->assign( 'payment_method', '2CheckOut.com' );

			$t->assign( 'loginid', $paymod_data['MODULE_PAYMENT_2CHECKOUT_LOGIN'] );
		
			$t->assign('rendered_page', $t->fetch('pm2checkout_checkout.tpl') );

/*
      global $HTTP_POST_VARS, $order_info;

      $process_button_string = tep_draw_hidden_field('x_login', MODULE_PAYMENT_2CHECKOUT_LOGIN) .
                               tep_draw_hidden_field('x_amount', number_format($order_info['order_amount'], 2)) .
                               tep_draw_hidden_field('x_invoice_num', date('YmdHis')) .
                               tep_draw_hidden_field('x_test_request', ((MODULE_PAYMENT_2CHECKOUT_TESTMODE == 'Test') ? 'Y' : 'N')) .
                               tep_draw_hidden_field('x_card_num', $this->cc_card_number) .
                               tep_draw_hidden_field('cvv', $HTTP_POST_VARS['pm_2checkout_cc_cvv']) .
                               tep_draw_hidden_field('x_exp_date', $this->cc_expiry_month . substr($this->cc_expiry_year, -2)) .
                               tep_draw_hidden_field('x_first_name', $HTTP_POST_VARS['pm_2checkout_cc_owner_firstname']) .
                               tep_draw_hidden_field('x_last_name', $HTTP_POST_VARS['pm_2checkout_cc_owner_lastname']) .
                               tep_draw_hidden_field('x_receipt_link_url', tep_href_link(FILENAME_CHECKOUT_PROCESS, '', 'SSL')) .
                               tep_draw_hidden_field('x_email_merchant', ((MODULE_PAYMENT_2CHECKOUT_EMAIL_MERCHANT == 'True') ? 'TRUE' : 'FALSE'));

      return $process_button_string;
*/
    }

    function before_process() {
      global $HTTP_POST_VARS;

      if ($HTTP_POST_VARS['x_response_code'] != '1') {
        tep_redirect(tep_href_link(FILENAME_CHECKOUT_PAYMENT, 'error_message=' . urlencode(MODULE_PAYMENT_2CHECKOUT_TEXT_ERROR_MESSAGE), 'SSL', true, false));
      }
    }

    function after_process() {
      return false;
    }

    function get_error() {
      global $HTTP_GET_VARS;

      $error = array('title' => MODULE_PAYMENT_2CHECKOUT_TEXT_ERROR,
                     'error' => stripslashes(urldecode($HTTP_GET_VARS['error'])));

      return $error;
    }

    function check() {
      if (!isset($this->_check)) {
        $check_query = $db->query("select configuration_value from " . TABLE_CONFIGURATION . " where configuration_key = 'MODULE_PAYMENT_2CHECKOUT_STATUS'");
        $this->_check = $check_query->numRows();
      }
      return $this->_check;
    }

    function install() {
			global $db;

      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Enable 2CheckOut Module', 'MODULE_PAYMENT_2CHECKOUT_STATUS', 'True', 'Do you want to accept 2CheckOut payments?', '6', '0', 'tep_cfg_select_option(array(\'True\', \'False\'), ', now(), 'pm2checkout')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Login/Store Number', 'MODULE_PAYMENT_2CHECKOUT_LOGIN', '18157', 'Login/Store Number used for the 2CheckOut service', '6', '0', now(), 'pm2checkout')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Transaction Mode', 'MODULE_PAYMENT_2CHECKOUT_TESTMODE', 'Test', 'Transaction mode used for the 2Checkout service', '6', '0', 'tep_cfg_select_option(array(\'Test\', \'Production\'), ', now(), 'pm2checkout')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Merchant Notifications', 'MODULE_PAYMENT_2CHECKOUT_EMAIL_MERCHANT', 'True', 'Should 2CheckOut e-mail a receipt to the store owner?', '6', '0', 'tep_cfg_select_option(array(\'True\', \'False\'), ', now(), 'pm2checkout')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Sort order of display.', 'MODULE_PAYMENT_2CHECKOUT_SORT_ORDER', '0', 'Sort order of display. Lowest is displayed first.', '6', '0', now(), 'pm2checkout')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, use_function, set_function, date_added, module_key) values ('Payment Zone', 'MODULE_PAYMENT_2CHECKOUT_ZONE', '0', 'If a zone is selected, only enable this payment method for that zone.', '6', '2', 'tep_get_zone_class_title', 'tep_cfg_pull_down_zone_classes(', now(), 'pm2checkout')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, use_function, date_added, module_key) values ('Set Order Status', 'MODULE_PAYMENT_2CHECKOUT_ORDER_STATUS_ID', '0', 'Set the status of orders made with this payment module to this value', '6', '0', 'tep_cfg_pull_down_order_statuses(', 'tep_get_order_status_name', now(), 'pm2checkout')";
			$db->query( $sqlupd );
    }

    function remove() {
			global $db;
      $sqlupd = "delete from " . TABLE_CONFIGURATION . " where configuration_key in ('" . implode("', '", $this->keys()) . "')";
			$db->query( $sqlupd );
    }

		function update( $configuration ) {
			global $db;
			while (list ($key, $val) = each ($configuration)) {
				$sqlupd = "update ! set configuration_value = ? where configuration_key = ? ";
				$db->query( $sqlupd, array( TABLE_CONFIGURATION, $val, $key ) );
			}
		}

    function keys() {
      return array('MODULE_PAYMENT_2CHECKOUT_STATUS', 'MODULE_PAYMENT_2CHECKOUT_LOGIN', 'MODULE_PAYMENT_2CHECKOUT_TESTMODE', 'MODULE_PAYMENT_2CHECKOUT_EMAIL_MERCHANT', 'MODULE_PAYMENT_2CHECKOUT_ZONE', 'MODULE_PAYMENT_2CHECKOUT_ORDER_STATUS_ID', 'MODULE_PAYMENT_2CHECKOUT_SORT_ORDER');
    }
  }
?>
