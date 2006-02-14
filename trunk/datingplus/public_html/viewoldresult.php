<?php

if( !defined('SMARTY_DIR') ) {
	require_once( 'init.php' );
}

$pollid = $_GET[ 'pollid' ];

$sql = 'SELECT question, date from ! WHERE pollid=?';

$rsQ = $db->getRow( $sql, array( POLLS_TABLE, $pollid) );

$sql = 'SELECT sum( result ) as sm FROM ! WHERE pollid=?';

$numtotal = $db->getOne( $sql, array( POLLOPTS_TABLE, $pollid) );

$sql = ' SELECT opt, result FROM ! WHERE pollid=? order by optionid';

$sqOpt = $db->getAll($sql, array( POLLOPTS_TABLE, $pollid) );


$date = date( LONG_DATE_FORMAT, $rsQ['date']);

$i = 1;

$index = 0;

foreach ($sqOpt as $rsOpt ) {

	$$rsOpt['c'] = sprintf( '%02d', $i);

	if( $numtotal != 0 ) {

		 $rsOpt['numw'] = number_format( ( $rsOpt['result'] / $numtotal ) * 100, 2 );

	} else {

		$rsOpt['numw'] = 0;
	}

	$data[$index]=$rsOpt;

	$index++;

	$i++;

}

$t->assign( 'question', $rsQ['question'] );

$t->assign( 'data', $data );

$t->assign( 'numtotal', $numtotal );

$t->assign( 'err', $err );

$t->assign('rendered_page',$t->fetch('viewresult.tpl'));

$t->display( 'index.tpl' );

 ?>