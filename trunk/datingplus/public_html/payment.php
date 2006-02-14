<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include ( 'sessioninc.php' );

$sql = 'SELECT * from ! WHERE enabled = ?';

$data = $db->getAll( $sql, array( PAYMENT_MODULE_TABLE, 'Y' ) );

$t->assign( 'data', $data );

$privilges = array(
	'chat',
	'forum',
	'includeinsearch',
	'message',
	'uploadpicture',
	'uploadpicturecnt',
	'allowim',
	'allowalbum',
	'seepictureprofile',
	'favouritelist',
	'sendwinks',
	'extsearch',
	'fullsignup',
	'activedays',
	'price',
	'currency'
);

$sql = 'select id, roleid, name from ! where enabled = ? and id <> ? order by price';

$j = 0;

$temp = $db->getAll( $sql, array( MEMBERSHIP_TABLE, 'Y', 3 ) );

$m_row = array();

$m_name = array();

foreach( $temp as $index => $rowtmp ) {

	$sql = 'select * from ! where id = ?';

	$temp2 = $db->getAll( $sql, array( MEMBERSHIP_TABLE, $rowtmp['id'] ) );

	$m_name[$rowtmp['roleid']] = $rowtmp['name'];

	foreach( $temp2 as $index2 => $row ) {

		foreach( $privilges as $item ) {

			$m_row[$item][$j] = $row[$item];
		}

		$j++;
	}
}

$t->assign( 'm_row' , $m_row );

$t->assign( 'memberships' , $m_name );

$t->assign('privileges',$privileges);

$t->assign('rendered_page', $t->fetch('payment.tpl') );

$t->display( 'index.tpl' );

exit;

?>
