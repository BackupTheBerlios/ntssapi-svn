<?php

if(  $_SESSION['UserId'] == '' ) {

	header('location:index.php?page=login');
	exit();
}
?>