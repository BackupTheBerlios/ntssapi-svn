<?php
if ( !defined( 'SMARTY_DIR' ) ) {
	include_once( '../init.php' );
}		

include('sessioninc.php');

define( 'PAGE_ID', 'profile_mgt' );

if ( !checkAdminPermission( PAGE_ID ) ) {

	header( 'location:not_authorize.php' );
	exit;
}


$userid = (int)$_POST['edit'];

//Get the next section id
$sql = 'SELECT displayorder FROM ! WHERE enabled = ? and id = ?';

$displayorder = $db->getOne ( $sql, array( SECTIONS_TABLE, 'Y', (int)$_POST['sectionid'] ) );

$sql = 'SELECT id FROM ! WHERE enabled = ? and displayorder = ?' ;
	
$row  = $db->getRow( $sql, array( SECTIONS_TABLE, 'Y', $displayorder + 1) );

$section = 0;

foreach ($_POST as $questionid => $options) {

	$j = 0;	
	
	if ( $questionid == 'sectionid' ) {
	
		$section = $options;

	} elseif ( !is_array( $options ) ) {
	
		$userpref[ $j ] = $userid;
		
		$j++;
		
		if ( substr( $questionid, -1 ) == 'Y' ) {
		
			if ( $options == NULL ) {
			
				header ( 'Location:editprofilequestions.php?sectionid=' . $section . '&edit='.$userid.'&errid='.MANDATORY_FIELDS );
				exit;
				
			}
			
		}
		
		$questionid = substr( $questionid, 0, strlen( $questionid) -1  );
		
		$userpref[ $j ] = $questionid;
		
		$j++;
		
		$userpref[ $j ] = $options;
		
		$sqldel = 'DELETE FROM ! WHERE userid = ? AND questionid = ?';
		
		$sqlins = 'INSERT INTO ! ( userid, questionid, answer ) VALUES ( ?, ?, ? )';
				
		$db->query ( $sqldel, array( USER_PREFERENCE_TABLE, $userpref[0], $userpref[1] ) );
		
		$db->query ( $sqlins, array( USER_PREFERENCE_TABLE, $userpref[0], $userpref[1], $userpref[2]) );

	} else {

		$executeflag = 0;
			
		foreach( $options as $option ) {
		
			$j = 0;
			
			$userpref[ $j ] = $userid;
			
			$j++;
			
			if ( substr( $questionid, -1 ) == 'Y' ) {
			
				if ( $options == NULL ) {
				
					header ( 'Location:editprofilequestions.php?sectionid=' . $section . '&edit='.$userid.'&errid='.MANDATORY_FIELDS );
					exit;
					
				}
				
			}
			
			$qid = substr( $questionid, 0, strlen( $questionid) -1 );				
			
			$userpref[ $j ] = $qid;
			
			$j++;
			
			$userpref[ $j ] = $option;	
			
			$sqldel = 'DELETE FROM ! WHERE userid = ? AND questionid = ?';		
			
			$sqlins = 'INSERT INTO ! ( userid, questionid, answer ) VALUES (? , ?, ? )';
			
			
			if ( !$executeflag ) {

				 $db->query ( $sqldel, array( USER_PREFERENCE_TABLE, $userpref[0], $userpref[1] ) );
				 
				$executeflag = 1;
				
			}
			
			$db->query ( $sqlins, array( USER_PREFERENCE_TABLE, $userpref[0],  $userpref[1], $userpref[2] ) );						
		} //foreach
		
	} //else
	
} //foreach

if( $row['id'] != "" )
	
	header ( 'Location:editprofilequestions.php?sectionid='.$row['id'].'&edit='.$userid);
	
else
	
	header ( 'Location:profile.php?edit='.$userid);


?>