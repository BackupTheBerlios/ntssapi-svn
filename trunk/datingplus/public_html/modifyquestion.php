<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( 'init.php' );
}

include('sessioninc.php');

$userid = $_SESSION['UserId'];

$sql = 'select displayorder from ! where enabled = ? and id = ?';

$row = $db->getRow( $sql, array( SECTIONS_TABLE, 'Y', $_POST['sectionid'] ) );


$sql = 'select id from ! where enabled = ? and displayorder = ?';

$row = $db->getRow( $sql, array( SECTIONS_TABLE, 'Y', $row['displayorder'] + 1 ) );


foreach ( $_POST as $questionid => $options ) {

	$j = 0;

	if ( $questionid == 'sectionid' ) {

	} elseif ( !is_array( $options ) ) {

		$userpref[ $j ] = $userid;
		$j++;

		if ( substr( $questionid, -1 ) == 'Y' ) {

			if ( $options == NULL ) {

				header ( 'Location:editquestions.php?sectionid=' . $_POST['sectionid'] . '&errid='.MANDATORY_FIELDS );

				exit;
			}
		}

		$questionid = substr( $questionid, 0, strlen( $questionid) -1  );

		$userpref[ $j ] = $questionid;

		$j++;

		$userpref[ $j ] = $options;

		$sqldel = 'DELETE FROM ! WHERE userid = ? AND questionid = ?';

		$result = $db->query ( $sqldel, array( USER_PREFERENCE_TABLE, $userpref[0], $userpref[1] ) );

		$sqlins = 'INSERT INTO ! ( userid, questionid, answer ) VALUES ( ?, ?, ? )';

		$result = $db->query ( $sqlins, array( USER_PREFERENCE_TABLE, $userpref[0], $userpref[1], $userpref[2] ) );

	} else {

		$executeflag = 0;

		foreach( $options as $option ) {

			$j = 0;

			$userpref[ $j ] = $userid;

			$j++;

			if ( substr( $questionid, -1 ) == 'Y' ) {

				if ( $options == NULL ) {

					header ( 'Location:editquestions.php?sectionid='. $_POST['sectionid'] . '&errid='.MANDATORY_FIELDS );

					exit;
				}
			}

			$qid = substr( $questionid, 0, strlen( $questionid) -1 );

			$userpref[ $j ] = $qid;

			$j++;

			$userpref[ $j ] = $option;

			$sqldel = 'DELETE FROM ! WHERE userid = ? AND questionid = ?';

			$sqlins = 'INSERT INTO ! ( userid, questionid, answer ) VALUES ( ?, ?, ? )';

			if ( !$executeflag ) {

				$result = $db->query ( $sqldel, array( USER_PREFERENCE_TABLE, $userpref[0], $userpref[1] ) );

				$executeflag = 1;
			}

			$result = $db->query ( $sqlins, array( USER_PREFERENCE_TABLE, $userpref[0], $userpref[1], $userpref[2] ) );

		} //foreach

	} //else


} //foreach

if( $row['id'] != "" ) {

	header ( 'Location:editquestions.php?sectionid='. $row['id'] );
} else {
	header ( 'Location:edituser.php' );
}

?>