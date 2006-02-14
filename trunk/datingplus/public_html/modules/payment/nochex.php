<?php
/*
  $Id: nochex.php,v 1.12 2003/01/29 19:57:15 hpdl Exp $

  osCommerce, Open Source E-Commerce Solutions
  http://www.oscommerce.com

  Copyright (c) 2003 osCommerce

  Released under the GNU General Public License
*/

  class nochex {
    var $code, $title;

// class constructor
    function nochex() {

      $this->code = 'nochex';

      $this->title = 'NOCHEX';

      $this->form_action_url = 'https://www.nochex.com/nochex.dll/checkout';
    }

// class methods

    function javascript_validation() {
      return false;
    }

    function pre_confirmation_check() {
      return false;
    }

    function confirmation() {
      return false;
    }

    function process_button() {
			global $db, $t;
			
			$sqlconf = 'SELECT configuration_key, configuration_value from ! where module_key = ?';
			
			$confdata = $db->getAll( $sqlconf, array( TABLE_CONFIGURATION, 'nochex' ) );
			
			foreach( $confdata as $confitem ) {
				
				$paymod_data[ $confitem['configuration_key'] ] = $confitem['configuration_value'];
				
			}
		
			$t->assign( 'email', $paymod_data['MODULE_PAYMENT_NOCHEX_ID'] );

			$t->assign( 'ordernumber', $_SESSION['UserId'] . '-' . date('Ymdhis') );
		
			$t->assign('rendered_page', $t->fetch('nochex_checkout.tpl') );

    }

    function before_process() {
      return false;
    }

    function after_process() {
      return false;
    }

    function output_error() {
      return false;
    }

    function check() {
      if (!isset($this->_check)) {
        $check_query = $db->query("select configuration_value from " . TABLE_CONFIGURATION . " where configuration_key = 'MODULE_PAYMENT_NOCHEX_STATUS'");
        $this->_check = $check_query->numRows();
      }
      return $this->_check;
    }

    function install() {
			global $db;
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, date_added, module_key) values ('Enable NOCHEX Module', 'MODULE_PAYMENT_NOCHEX_STATUS', 'True', 'Do you want to accept NOCHEX payments?', '6', '3', 'tep_cfg_select_option(array(\'True\', \'False\'), ', now(), 'nochex')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('E-Mail Address', 'MODULE_PAYMENT_NOCHEX_ID', 'you@yourbuisness.com', 'The e-mail address to use for the NOCHEX service', '6', '4', now(), 'nochex')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, date_added, module_key) values ('Sort order of display.', 'MODULE_PAYMENT_NOCHEX_SORT_ORDER', '0', 'Sort order of display. Lowest is displayed first.', '6', '0', now(), 'nochex')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, use_function, set_function, date_added, module_key) values ('Payment Zone', 'MODULE_PAYMENT_NOCHEX_ZONE', '0', 'If a zone is selected, only enable this payment method for that zone.', '6', '2', 'tep_get_zone_class_title', 'tep_cfg_pull_down_zone_classes(', now(), 'nochex')";
			$db->query( $sqlupd );
      $sqlupd = "insert into " . TABLE_CONFIGURATION . " (configuration_title, configuration_key, configuration_value, configuration_description, configuration_group_id, sort_order, set_function, use_function, date_added, module_key) values ('Set Order Status', 'MODULE_PAYMENT_NOCHEX_ORDER_STATUS_ID', '0', 'Set the status of orders made with this payment module to this value', '6', '0', 'tep_cfg_pull_down_order_statuses(', 'tep_get_order_status_name', now(), 'nochex')";
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
      return array('MODULE_PAYMENT_NOCHEX_STATUS', 'MODULE_PAYMENT_NOCHEX_ID', 'MODULE_PAYMENT_NOCHEX_ZONE', 'MODULE_PAYMENT_NOCHEX_ORDER_STATUS_ID', 'MODULE_PAYMENT_NOCHEX_SORT_ORDER');
    }
  }
?>
