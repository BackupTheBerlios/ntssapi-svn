<?php
session_start();

if( $_SESSION['AdminId']==''){

	header('location:index.php');
	
	exit();
}
?>