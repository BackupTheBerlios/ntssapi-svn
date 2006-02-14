<?php

$sql = 'SELECT pollid FROM ! WHERE enabled = ? AND active = ? and date >= ?';

$data = $db->getAll( $sql, array( POLLS_TABLE, 'Y', '1', time() ) );

if (count($data) > 0)  { 

	srand((float) microtime() * 10000000);

	$key = array_rand($data, 1);

	$pollid = $data[$key]['pollid'];

	$sql = 'SELECT * FROM ! WHERE pollid = ? ';

	$row = $db->getAll( $sql, array( POLLS_TABLE, $pollid ) );

	$options = $db->getAll( $sql, array( POLLOPTS_TABLE, $pollid ) );

	$row['curtime'] = time();

	$row['question'] = stripslashes( $row['question'] );

	$row['options'] = poll_opts( $options );

	$t->assign( 'poll_data', $row );

}

function poll_opts( $options )
{
	$result = array();

	foreach( $options as $index => $row ) {
	
		$result[ $row['optionid'] ] = $row;
	}

	return $result;
}
?>
