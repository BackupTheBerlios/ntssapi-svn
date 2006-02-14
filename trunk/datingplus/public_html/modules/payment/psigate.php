<?php
/*
  $Id: psigate.php,v 1.17 2003/06/30 20:30:37 hpdl Exp $

  osCommerce, Open Source E-Commerce Solutions
  http://www.oscommerce.com

  Copyright (c) 2003 osCommerce

  Released under the GNU General Public License
*/

  class psigate {
    var $code, $title;

// class constructor
    function psigate() {

      $this->code = 'psigate';
      $this->title = 'PSiGate';

      $this->form_action_url = 'https://order.psigate.com/psigate.asp';
    }

// class methods
    function javascript_validation() {
      if (MODULE_PAYMENT_PSIGATE_INPUT_MODE == 'Local') {
        $js = 'if (payment_value == "' . $this->code . '") {' . "\n" .
              '  var psigate_cc_number = document.checkout_payment.psigate_cc_number.value;' . "\n" .
              '  if (psigate_cc_number == "" || psigate_cc_number.length < ' . CC_NUMBER_MIN_LENGTH . ') {' . "\n" .
              '    error_message = error_message + "' . MODULE_PAYMENT_PSIGATE_TEXT_JS_CC_NUMBER . '";' . "\n" .
              '    error = 1;' . "\n" .
              '  }' . "\n" .
              '}' . "\n";

        return $js;
      } else {
        return false;
      }
    }

    function process_button() {
			global $db, $t;

			include( ROOT_DIR . 'libs/cc_validation.php');
		
			$cc = $_POST['psigate_cc_number'];
		
			$cvv = $_POST['psigate_cc_cvv'];
		
			$exp_m = $_POST['psigate_cc_expires_Month'];
		
			$exp_y = substr( $_POST['psigate_cc_expires_Year'], -2);
		
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
		
			$t->assign( 'cc_owner', trim( $_POST['psigate_cc_owner'] ) );
		
			$t->assign( 'cc_type', $cc_validation->cc_type );
		
			$t->assign( 'cc_number', $cc_validation->cc_number );
		
			$t->assign( 'cvv', $cvv );
		
			$t->assign( 'cc_part1', substr( $cc_validation->cc_number,0,4) );
		
			$t->assign( 'cc_part2', substr( $cc_validation->cc_number,-4) );
		
			$t->assign( 'cc_expiry_month', $cc_validation->cc_expiry_month );
		
			$t->assign( 'cc_expiry_year', $cc_validation->cc_expiry_year );
		
			$t->assign( 'cc_expiry_date',  $cc_validation->cc_expiry_month . '' . substr($cc_validation->cc_expiry_year,-2) );
		
			$sqlconf = 'SELECT configuration_key, configuration_value from ! where module_key = ?';
			
			$confdata = $db->getAll( $sqlconf, array( TABLE_CONFIGURATION, 'psigate' ) );
		
			foreach( $confdata as $confitem ) {
				
				$paymod_data[ $confitem['configuration_key'] ] = $confitem['configuration_value'];
				
			}

      switch ($paymod_data['MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE']) {
        case 'Always Good':
          $transaction_mode = '1';
          break;
        case 'Always Duplicate':
          $transaction_mode = '2';
          break;
        case 'Always Decline':
          $transaction_mode = '3';
          break;
        case 'Production':
        default:
          $transaction_mode = '0';
          break;
      }

      switch ($paymod_data['MODULE_PAYMENT_PSIGATE_TRANSACTION_TYPE']) {
        case 'Sale':
          $transaction_type = '0';
          break;
        case 'PostAuth':
          $transaction_type = '2';
          break;
        case 'PreAuth':
        default:
          $transaction_type = '1';
          break;
      }

			$t->assign( 'invoice_num', date('YmdHis') );
		
			$t->assign( 'payment_method', 'PSiGate' );

			$t->assign( 'MerchantID', $paymod_data['MODULE_PAYMENT_PSIGATE_MERCHANT_ID'] );

			$t->assign( 'ChargeType', $transaction_type );

			$t->assign( 'Result', $transaction_mode );
			
			$t->assign( 'IP', $_SERVER['REMOTE_ADDR'] );
	
			$t->assign('rendered_page', $t->fetch('psigate_checkout.tpl') );

    }

    function before_process() {
      return false;
    }

    function after_process() {
      return false;
    }

    function get_error() {
      global $HTTP_GET_VARS;

      if (isset($HTTP_GET_VARS['ErrMsg']) && tep_not_null($HTTP_GET_VARS['ErrMsg'])) {
        $error = stripslashes(urldecode($HTTP_GET_VARS['ErrMsg']));
      } elseif (isset($HTTP_GET_VARS['Err']) && tep_not_null($HTTP_GET_VARS['Err'])) {
        $error = stripslashes(urldecode($HTTP_GET_VARS['Err']));
      } elseif (isset($HTTP_GET_VARS['error']) && tep_not_null($HTTP_GET_VARS['error'])) {
        $error = stripslashes(urldecode($HTTP_GET_VARS['error']));
      } else {
        $error = MODULE_PAYMENT_PSIGATE_TEXT_ERROR_MESSAGE;
      }

      return array('title' => MODULE_PAYMENT_PSIGATE_TEXT_ERROR,
                   'error' => $error);
    }

    function check() {
      if (!isset($this->_check)) {
        $check_query = $db->query("select configuration_value from " . TABLE_CONFIGURATION . " where configuration_key = 'MODULE_PAYMENT_PSIGATE_STATUS'");
        $this->_check = $check_query->numRows();
      }
      return $this->_check;
    }

    function install() {
			global $db;
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Enable PSiGate Module', 'MODULE_PAYMENT_PSIGATE_STATUS', 'True', 'Do you want to accept PSiGate payments?', '6', '1', 'tep_cfg_select_option(array(\'True\', \'False\'), ', now(), 'psigate')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Merchant ID', 'MODULE_PAYMENT_PSIGATE_MERCHANT_ID', 'teststorewithcard', 'Merchant ID used for the PSiGate service', '6', '2', now(), 'psigate')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Transaction Mode', 'MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE', 'Always Good', 'Transaction mode to use for the PSiGate service', '6', '3', 'tep_cfg_select_option(array(\'Production\', \'Always Good\', \'Always Duplicate\', \'Always Decline\'), ', now(), 'psigate')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Transaction Type', 'MODULE_PAYMENT_PSIGATE_TRANSACTION_TYPE', 'PreAuth', 'Transaction type to use for the PSiGate service', '6', '4', 'tep_cfg_select_option(array(\'Sale\', \'PreAuth\', \'PostAuth\'), ', now(), 'psigate')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Credit Card Collection', 'MODULE_PAYMENT_PSIGATE_INPUT_MODE', 'Local', 'Should the credit card details be collected locally or remotely at PSiGate?', '6', '5', 'tep_cfg_select_option(array(\'Local\', \'Remote\'), ', now(), 'psigate')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Transaction Currency', 'MODULE_PAYMENT_PSIGATE_CURRENCY', 'USD', 'The currency to use for credit card transactions', '6', '6', 'tep_cfg_select_option(array(\'CAD\', \'USD\'), ', now(), 'psigate')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Sort order of display.', 'MODULE_PAYMENT_PSIGATE_SORT_ORDER', '0', 'Sort order of display. Lowest is displayed first.', '6', '0', now(), 'psigate')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, use_function, set_function, date_added, module_key) values ('Payment Zone', 'MODULE_PAYMENT_PSIGATE_ZONE', '0', 'If a zone is selected, only enable this payment method for that zone.', '6', '2', 'tep_get_zone_class_title', 'tep_cfg_pull_down_zone_classes(', now(), 'psigate')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, use_function, date_added, module_key) values ('Set Order Status', 'MODULE_PAYMENT_PSIGATE_ORDER_STATUS_ID', '0', 'Set the status of orders made with this payment module to this value', '6', '0', 'tep_cfg_pull_down_order_statuses(', 'tep_get_order_status_name', now(), 'psigate')";
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
      return array('MODULE_PAYMENT_PSIGATE_STATUS', 'MODULE_PAYMENT_PSIGATE_MERCHANT_ID', 'MODULE_PAYMENT_PSIGATE_TRANSACTION_MODE', 'MODULE_PAYMENT_PSIGATE_TRANSACTION_TYPE', 'MODULE_PAYMENT_PSIGATE_INPUT_MODE', 'MODULE_PAYMENT_PSIGATE_CURRENCY', 'MODULE_PAYMENT_PSIGATE_ZONE', 'MODULE_PAYMENT_PSIGATE_ORDER_STATUS_ID', 'MODULE_PAYMENT_PSIGATE_SORT_ORDER');
    }
  }
?>
