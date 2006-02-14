<?php

if(  $_SESSION['AffId'] == '' ) {

	header('location:afflogin.php');

	exit();
}
?>