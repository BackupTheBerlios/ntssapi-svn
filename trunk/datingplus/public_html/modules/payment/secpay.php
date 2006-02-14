<?php
/*
  $Id: secpay.php,v 1.31 2003/01/29 19:57:15 hpdl Exp $

  osCommerce, Open Source E-Commerce Solutions
  http://www.oscommerce.com

  Copyright (c) 2003 osCommerce

  Released under the GNU General Public License
*/

  class secpay {
    var $code, $title;

// class constructor
    function secpay() {

      $this->code = 'secpay';
      $this->title = 'SECPay';

      $this->form_action_url = 'https://www.secpay.com/java-bin/ValCard';
    }

// class methods
    function javascript_validation() {
      return false;
    }

    function process_button() {

			global $db, $t;
			
			$sqlconf = 'SELECT configuration_key, configuration_value from ! where module_key = ?';
			
			$confdata = $db->getAll( $sqlconf, array( TABLE_CONFIGURATION, 'secpay' ) );
			
			foreach( $confdata as $confitem ) {
				
				$paymod_data[ $confitem['configuration_key'] ] = $confitem['configuration_value'];
				
			}

      switch ($paymod_data['MODULE_PAYMENT_SECPAY_TEST_STATUS']) {
        case 'Always Fail':
          $test_status = 'false';
          break;
        case 'Production':
          $test_status = 'live';
          break;
        case 'Always Successful':
        default:
          $test_status = 'true';
          break;
      }
		
			$t->assign( 'merchant', $paymod_data['MODULE_PAYMENT_SECPAY_MERCHANT_ID'] );

			$t->assign( 'trans_id', date('Ymdhis') );

			$t->assign( 'options', 'test_status=' . $test_status . ',dups=false,cb_post=true,cb_flds=' );
		
			$t->assign('rendered_page', $t->fetch('secpay_checkout.tpl') );

    }

    function before_process() {
      global $HTTP_POST_VARS;

      if ($HTTP_POST_VARS['valid'] == 'true') {
        if ($remote_host = getenv('REMOTE_HOST')) {
          if ($remote_host != 'secpay.com') {
            $remote_host = gethostbyaddr($remote_host);
          }
          if ($remote_host != 'secpay.com') {
            tep_redirect(tep_href_link(FILENAME_CHECKOUT_PAYMENT, tep_session_name() . '=' . $HTTP_POST_VARS[tep_session_name()] . '&payment_error=' . $this->code, 'SSL', false, false));
          }
        } else {
          tep_redirect(tep_href_link(FILENAME_CHECKOUT_PAYMENT, tep_session_name() . '=' . $HTTP_POST_VARS[tep_session_name()] . '&payment_error=' . $this->code, 'SSL', false, false));
        }
      }
    }

    function after_process() {
      return false;
    }

    function get_error() {
      global $HTTP_GET_VARS;

      if (isset($HTTP_GET_VARS['message']) && (strlen($HTTP_GET_VARS['message']) > 0)) {
        $error = stripslashes(urldecode($HTTP_GET_VARS['message']));
      } else {
        $error = MODULE_PAYMENT_SECPAY_TEXT_ERROR_MESSAGE;
      }

      return array('title' => MODULE_PAYMENT_SECPAY_TEXT_ERROR,
                   'error' => $error);
    }

    function check() {
      if (!isset($this->_check)) {
        $check_query = $db->query("select configuration_value from " . TABLE_CONFIGURATION . " where configuration_key = 'MODULE_PAYMENT_SECPAY_STATUS'");
        $this->_check = $check_query->numRows();
      }
      return $this->_check;
    }

    function install() {
			global $db;
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Enable SECpay Module', 'MODULE_PAYMENT_SECPAY_STATUS', 'True', 'Do you want to accept SECPay payments?', '6', '1', 'tep_cfg_select_option(array(\'True\', \'False\'), ', now(), 'secpay')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Merchant ID', 'MODULE_PAYMENT_SECPAY_MERCHANT_ID', 'secpay', 'Merchant ID to use for the SECPay service', '6', '2', now(), 'secpay')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Transaction Currency', 'MODULE_PAYMENT_SECPAY_CURRENCY', 'Any Currency', 'The currency to use for credit card transactions', '6', '3', 'tep_cfg_select_option(array(\'Any Currency\', \'Default Currency\'), ', now(), 'secpay')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Transaction Mode', 'MODULE_PAYMENT_SECPAY_TEST_STATUS', 'Always Successful', 'Transaction mode to use for the SECPay service', '6', '4', 'tep_cfg_select_option(array(\'Always Successful\', \'Always Fail\', \'Production\'), ', now(), 'secpay')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Sort order of display.', 'MODULE_PAYMENT_SECPAY_SORT_ORDER', '0', 'Sort order of display. Lowest is displayed first.', '6', '0', now(), 'secpay')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, use_function, set_function, date_added, module_key) values ('Payment Zone', 'MODULE_PAYMENT_SECPAY_ZONE', '0', 'If a zone is selected, only enable this payment method for that zone.', '6', '2', 'tep_get_zone_class_title', 'tep_cfg_pull_down_zone_classes(', now(), 'secpay')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, use_function, date_added, module_key) values ('Set Order Status', 'MODULE_PAYMENT_SECPAY_ORDER_STATUS_ID', '0', 'Set the status of orders made with this payment module to this value', '6', '0', 'tep_cfg_pull_down_order_statuses(', 'tep_get_order_status_name', now(), 'secpay')";
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
      return array('MODULE_PAYMENT_SECPAY_STATUS', 'MODULE_PAYMENT_SECPAY_MERCHANT_ID', 'MODULE_PAYMENT_SECPAY_CURRENCY', 'MODULE_PAYMENT_SECPAY_TEST_STATUS', 'MODULE_PAYMENT_SECPAY_ZONE', 'MODULE_PAYMENT_SECPAY_ORDER_STATUS_ID', 'MODULE_PAYMENT_SECPAY_SORT_ORDER');
    }
  }
?>
