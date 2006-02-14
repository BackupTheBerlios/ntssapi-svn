<?PHP

/* State Codes  */

/**********************************/
// ALL STATES
/**********************************/

$sql = 'SELECT code, name from ! where enabled = ? and countrycode = ?  order by name';

$temp = $db->getAll( $sql, array( STATES_TABLE, 'Y', $countrycode ) );

$allstates = array();

foreach( $temp as $index => $row ) {
	$allstates[ $row[code] ] = $row[name];
}

$lang['states'] = $allstates;

?>