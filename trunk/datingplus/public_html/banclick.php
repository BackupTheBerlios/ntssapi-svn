<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

$id = $_GET['id'];

$sql = 'SELECT clicks, linkurl FROM ! WHERE id = ?';

$row = $db->getRow( $sql, array( BANNER_TABLE, $id ) );

$clicks = $row['clicks'] + 1;
$linkurl = $row['linkurl'];

$sql = 'UPDATE ! SET clicks = ? WHERE id = ?';

$db->query( $sql, array( BANNER_TABLE, $clicks, $id ) );

header( 'location:' . $linkurl );

exit;
?>