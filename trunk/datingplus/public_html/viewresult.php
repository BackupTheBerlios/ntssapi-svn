<?php
if( !defined( 'SMARTY_DIR' ) ) {
	require_once( 'init.php' );
}

$pollid = $_GET['pollid'];

$sql = 'SELECT question, date from ! WHERE pollid = ?';

$rsQ = $db->getRow( $sql, array( POLLS_TABLE, $pollid ) );

$sql = 'SELECT sum( result ) as sm FROM ! WHERE pollid = ?';

$numtotal =  $db->getOne( $sql, array( POLLOPTS_TABLE, $pollid ) );

$sql = 'SELECT opt, result FROM ! WHERE pollid = ? order by optionid';

$sqOpt = $db->getAll( $sql, array( POLLOPTS_TABLE, $pollid ) );

$date =  date( LONG_DATE_FORMAT, $rsQ['date'] );

$i = 1;

$data = array();

foreach( $sqOpt as $index => $rsOpt ) {

	$rsOpt['c'] = $i;

	if( $numtotal !=  0 ) {
		 $rsOpt['numw']  =  number_format( ( $rsOpt['result'] / $numtotal ) * 100, 2 );
	}
	else {
		$rsOpt['numw']  =  0;
	}
	
//	$sqOpt[$index] = $rsOpt;
	$data[$index] = $rsOpt;

	$i++;
}

$t->assign( 'question', stripslashes( $rsQ['question'] ) );

$t->assign( 'data', $data );

$t->assign( 'numtotal',$numtotal );

$t->assign( 'title', $lang['poll_result'] );

$t->assign( 'err',$err );

$t->display( 'viewresult.tpl' );

?>