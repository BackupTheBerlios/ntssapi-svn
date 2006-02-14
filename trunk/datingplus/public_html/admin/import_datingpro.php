<?php
	define( 'SRC_PHOTOS_URL', 'http://datingpro.ilmat/uploades/photos/' );
	define( 'IMPORT_MODULE', "import_datingpro" );

	define( 'PAGE_ID', 'admin_mgt' );
	$messages=array();
	if ( !defined( 'SMARTY_DIR' ) ) {
		include_once( '../init.php' );
	}
	include ( 'sessioninc.php' );
	include("import_config.php");

	// Save database configuration
	if(isset($_POST["db_config"])) $_SESSION[IMPORT_MODULE]=$_POST;

	function errhndl_import ( $err ) 
	{	global $t;
		global $_SESSION;
		$message="Could not connect to database. Please enter valid connection settings below."; 
		$t->assign("message",$message);
		$t->assign("db",$_SESSION[IMPORT_MODULE]);
		$t->assign('rendered_page', $t->fetch('admin/import_db_config.tpl'));  
		$t->display ( 'admin/index.tpl' );
		die();
	}
	PEAR::setErrorHandling( PEAR_ERROR_CALLBACK, 'errhndl_import' );

	$error=false;
	if(empty($_SESSION[IMPORT_MODULE])) $error=true;
	if(empty($_SESSION[IMPORT_MODULE]["db_name"]) || 
	   empty($_SESSION[IMPORT_MODULE]["db_host"]) || 
	   empty($_SESSION[IMPORT_MODULE]["db_user"])) $error=true;
	if(!$error):
		// Connecting to database
		$dsn2 = 'mysql://' . $_SESSION[IMPORT_MODULE]["db_user"] . ':' . $_SESSION[IMPORT_MODULE]["db_pass"] . '@' . $_SESSION[IMPORT_MODULE]["db_host"] . '/' . $_SESSION[IMPORT_MODULE]["db_name"];
		$db2 = @DB::connect( $dsn2 );
		if (DB::isError($db2)) $error=true;
	endif;
	if ($error)
	{	errhndl_import("");
		exit;
	}
	$db2->setFetchMode( DB_FETCHMODE_ASSOC );

//debug($_SESSION[IMPORT_MODULE]);
//debug($db2);

	if($action=="section"):
		$query="select * from ".DB_PREFIX."_sections";
		$sections=$db->getAll($query,$dest_conn);
		$t->assign("sections",$sections);
		$t->assign('rendered_page', $t->fetch('admin/import_section.tpl'));  
		$t->display ( 'admin/index.tpl' );
	endif;

	// =================================================================================
	// IMPORTING USERS
	// =================================================================================
	if($module=="users"):
		// 1. DELETING PREVIOUS IMPORTS
		$query="select * from ".DB_PREFIX."_imported_users where module='datingpro'";
		$result=$db->query($query);
		while(($data=$result->fetchRow()))
		{	// 1. Deleting users
			$query="delete from ".DB_PREFIX."_user where id=".$data["user_id"];
			$db->query($query);
			// 2. Deleting users images
			$query="delete from ".DB_PREFIX."_usersnaps where userid=".$data["user_id"];
			$db->query($query);
			// 3. Deleting users answers
			$query="delete from ".DB_PREFIX."_userpreference where userid=".$data["user_id"];
			$db->query($query);
		}
		// 4. Deleting from imported_users
		$query="delete from ".DB_PREFIX."_imported_users where module='datingpro'";
		$db->query($query);
		$messages[]="Deleting previous imported users... OK";

		if($action=="import"):
			// 2. IMPORTING NEW USERS
			// Importing new users
			$query="select * from ".$_SESSION[IMPORT_MODULE]["db_prefix"]."_user";
			$result2=$db2->query($query);
			while(($data=$result2->fetchRow()))
			{	// 2.1 IMPORTING SIGNUP INFORMATION
				// Creating new record
				$query="select * from ".$_SESSION[IMPORT_MODULE]["db_prefix"]."_user_match where id_user=".$data["id"];
				$data_match=$db2->getRow($query);
				
				$gendres=array("1"=>"M","2"=>"F");
				$statuses=array("0"=>"Pending","1"=>"Active");
				
				$fields=array();
				$fields["username"]=$data["login"];
				$fields["password"]=$data["password"];
				$fields["firstname"]=$data["fname"];
				$fields["lastname"]=$data["sname"];
				$fields["email"]=$data["email"];
				$fields["gender"]=$gendres[$data["gender"]];
				$fields["lookgender"]=$gendres[$data_match["gender"]];
				$fields["lookagestart"]=$data_match["age_min"];
				$fields["lookageend"]=$data_match["age_max"];
				$fields["birth_date"]=$data["date_birthday"];
				if(!empty($data["id_country"]))
				{	$src_country=$db2->getOne("select name from ".$_SESSION[IMPORT_MODULE]["db_prefix"]."_country_spr where id=".$data["id_country"]);
					$fields["country"]=$db->getOne("select code from ".DB_PREFIX."_countries where name='".$src_country."'");
				}
				if(!empty($data["id_city"]))
					$fields["city"]=$db2->getOne("select name from ".$_SESSION[IMPORT_MODULE]["db_prefix"]."_city_spr where id=".$data["id_city"]);
				$fields["zip"]=$data["zipcode"];
				if(!empty($data_match["id_city"]))
					$fields["lookcity"]=$db2->getOne("select name from ".$_SESSION[IMPORT_MODULE]["db_prefix"]."_city_spr where id=".$data_match["id_city"]);
				$fields["active"]=$data["status"];
				$fields["status"]=$statuses[$data["status"]];

				// Inserting into osdate_user
				$query=insert_query(DB_PREFIX."_user",$fields);
				$db->query($query);
				$imported_user_id=$db->getOne("select last_insert_id()");

				// Inserting into osdate_inserted_users
				$fields=array();
				$fields["source_id"]=$data["id"];
				$fields["user_id"]=$imported_user_id;
				$fields["module"]="datingpro";
				$query=insert_query(DB_PREFIX."_imported_users",$fields);
				$db->query($query);
//debug($imported_user_id);

				// 2.2 IMPORTING PHOTOS OF USER
				$actives=array("0"=>"N","1"=>"Y");
				$picno=1;
				$query="select * from ".$_SESSION[IMPORT_MODULE]["db_prefix"]."_user_upload ".
					   "where id_user=".$data["id"]." and upload_type='f' ";
				$upload_result=$db2->query($query);
				while(($upload_data=$upload_result->fetchRow()))
				{	// Creating new image
					$fields=array();
					$fields["userid"]=$imported_user_id;
					$fields["picno"]=$picno++;

					$filename=$_SESSION[IMPORT_MODULE]["photos_url"].$upload_data["upload_path"];

					$userid=$imported_user_id;
					$img_tmp=createImg(FileExtention($filename),$filename);
					$jpgfile = createJpeg($img_tmp, 'N');
					$newimg = file_get_contents($jpgfile);

					$img_tmp=createImg(FileExtention($filename),$filename);
					$tnimg_file = createJpeg($img_tmp);
					$tnimg = file_get_contents($tnimg_file);

					if ($config['images_in_db'] == 'N') 
					{	$imgfile = writeImageToFile($newimg, $userid, '1'.$picno,"");
						$newimg = 'file:'.$imgfile;
						$tnimgfile = writeImageToFile($tnimg, $userid, '2'.$picno,"");
						$tnimg = 'file:'.$tnimgfile;
					}
					else
					{	$newimg = base64_encode($newimg);
						$tnimg = base64_encode($tnimg);
					}
					$fields["picture"]=$newimg;
					$fields["tnpicture"]=$tnimg;
					
					$fields["active"]=$actives[$upload_data["status"]];
					$fields["picext"]="jpg";
					$fields["picext"]="jpg";
					$query=insert_query(DB_PREFIX."_usersnaps",$fields);
					$db->query($query);
				}
			}
			$messages[]="Importing signup information... OK";
			$messages[]="Importing users photos... OK";
		endif; // $action=="import"
	endif;

	// Generates new questions based on specified section from 'pn_SECTION_spr' table
	function questions_make($section,$section_id)
	{	global $db,$db2;
		$pm_section_spr=$_SESSION[IMPORT_MODULE]["db_prefix"]."_".$section."_spr";
		$pm_section_spr_values=$_SESSION[IMPORT_MODULE]["db_prefix"]."_".$section."_spr_values";
		$questions_tbl=DB_PREFIX."_questions";
		$questionoptions_tbl=DB_PREFIX."_questionoptions";
		$imported_questions_tbl=DB_PREFIX."_imported_questions";
		// Cycle trough all pm_$section_spr
		$query="select * from $pm_section_spr ";
		$spr_result=$db2->query($query);
		while(($spr_data=$spr_result->fetchRow()))
		{	// Adding new question to osdate_questions table
			$question_fields=array();
			$question_fields["question"]=$spr_data["name"];
			$question_fields["control_type"]="select";
			$question_fields["mandatory"]="N";
			$question_fields["section"]=$section_id;
			$question_fields["displayorder"]=$spr_data["sorter"];
			$question_fields["extsearchhead"]=$spr_data["name"];
			$query=insert_query($questions_tbl,$question_fields);
			$db->query($query);
			$imported_question_id=$db->getOne("select last_insert_id()");

			// Importing options from source tables
			$values=array();
			$query="select * from $pm_section_spr_values where id_spr=".$spr_data["id"];
			$spr_values_result=$db2->query($query);
			while(($spr_values_data=$spr_values_result->fetchRow()))
			{	// Adding new options for this question
				$option_fields=array();
				$option_fields["answer"]=$spr_values_data["name"];
				$option_fields["questionid"]=$imported_question_id;
				$query=insert_query($questionoptions_tbl,$option_fields);
				$db->query($query);
				$values[$spr_values_data["id"]]=$db->getOne("select last_insert_id()");
			}

			// Adding new question to osdate_imported_questions table
			$imported_question_fields=array();
			$imported_question_fields["question_id"]=$imported_question_id;
			$imported_question_fields["values_ids"]=serialize($values);
			$imported_question_fields["module"]="datingpro";
			$imported_question_fields["section"]=$section;
			$imported_question_fields["id_spr"]=$spr_data["id"];
			$query=insert_query($imported_questions_tbl,$imported_question_fields);
			$db->query($query);
		}
	}

	// Delete questions of the section
	function questions_delete($section)
	{	global $db,$db2;
		$questions_tbl=DB_PREFIX."_questions";
		$questionoptions_tbl=DB_PREFIX."_questionoptions";
		$imported_questions_tbl=DB_PREFIX."_imported_questions";
		$userpreference_tbl=DB_PREFIX."_userpreference";
		
		// Cycle trough all imported questions
		$query="select * from $imported_questions_tbl where section='$section' ";
		$imported_result=$db->query($query);
		while(($imported_data=$imported_result->fetchRow()))
		{	// 1. Deleting users answers to questions
			$query="delete from $userpreference_tbl where questionid=".$imported_data["question_id"];
			$db->query($query);
			// 2. Deleting questionoptions
			$query="delete from $questionoptions_tbl where questionid=".$imported_data["question_id"];
			$db->query($query);
			// 3. Deleting questions themselves
			$query="delete from $questions_tbl where id=".$imported_data["question_id"];
			$db->query($query);
		}
		// 4. Deleting from imported questions table
		$query="delete from $imported_questions_tbl where section='$section' ";
		$db->query($query);
	}

	// Update users answers to questions of the section
	function questions_update_answers($section)
	{	global $db,$db2;
		$questions_tbl=DB_PREFIX."_questions";
		$questionoptions_tbl=DB_PREFIX."_questionoptions";
		$imported_questions_tbl=DB_PREFIX."_imported_questions";
		$imported_users_tbl=DB_PREFIX."_imported_users";
		$userpreference_tbl=DB_PREFIX."_userpreference";
		$pm_section_spr_user=$_SESSION[IMPORT_MODULE]["db_prefix"]."_".$section."_spr_user";
		
		// Cycle trough all records in $pm_section_spr_user
		$query="select * from $pm_section_spr_user ";
		$spr_user_result=$db2->query($query);
		while(($spr_user_data=$spr_user_result->fetchRow()))
		{	// 1. Get imported_questions record
			$query="select * from $imported_questions_tbl where id_spr=".$spr_user_data["id_spr"]." and section='$section' and module='datingpro' ";
			$imported_question=$db->getRow($query);
			$imported_question["values_ids"]=unserialize($imported_question["values_ids"]);
			// 2. Get imported_user record
			$query="select * from $imported_users_tbl where source_id=".$spr_user_data["id_user"]." and module='datingpro' ";
			$imported_user=$db->getRow($query);
			// 3. Insert new record to $userpreference_tbl
			$fields=array();
			$fields["userid"]=$imported_user["user_id"];
			$fields["questionid"]=$imported_question["question_id"];
			$fields["answer"]=$imported_question["values_ids"][$spr_user_data["id_value"]];
			$query=insert_query($userpreference_tbl,$fields);
			$db->query($query);
		}
	}

	// =================================================================================
	// IMPORTING DESCRIPTIONS
	// =================================================================================
	if($module=="descriptions"):
		questions_delete("descr");
		$messages[]="Deleting previous imports... OK";
		if($action=="import"):
			questions_make("descr",$section_id);
			$messages[]="Importing questions... OK";
			questions_update_answers("descr");
			$messages[]="Updating users answers... OK";
		endif;
	endif;

	// =================================================================================
	// IMPORTING PEROSNALITIES
	// =================================================================================
	if($module=="personalities"):
		questions_delete("personality");
		$messages[]="Deleting previous imports... OK";
		if($action=="import"):
			questions_make("personality",$section_id);
			$messages[]="Importing questions... OK";
			questions_update_answers("personality");
			$messages[]="Updating users answers... OK";
		endif;
	endif;

	// =================================================================================
	// IMPORTING PORTRAITS
	// =================================================================================
	if($module=="portraits"):
		questions_delete("portrait");
		$messages[]="Deleting previous imports... OK";
		if($action=="import"):
			questions_make("portrait",$section_id);
			$messages[]="Importing questions... OK";
			questions_update_answers("portrait");
			$messages[]="Updating users answers... OK";
		endif;
	endif;

	// =================================================================================
	// IMPORTING INTERESTS
	// =================================================================================
	if($module=="interests"):
		$section="interests";
		$pm_section_spr=$_SESSION[IMPORT_MODULE]["db_prefix"]."_".$section."_spr";
		$pm_section_spr_user=$_SESSION[IMPORT_MODULE]["db_prefix"]."_".$section."_spr_user";
		$questions_tbl=DB_PREFIX."_questions";
		$questionoptions_tbl=DB_PREFIX."_questionoptions";
		$imported_questions_tbl=DB_PREFIX."_imported_questions";
		$imported_users_tbl=DB_PREFIX."_imported_users";
		$userpreference_tbl=DB_PREFIX."_userpreference";

		// 1. DELETING PREVIOUS IMPORTS
		questions_delete("interests");
		$messages[]="Deleting previous imports... OK";
		
		if($action=="import"):
		// 2. IMPORTING QUESTION
		// Adding new question to osdate_questions table
		$question_fields=array();
		$question_fields["question"]="Interests";
		$question_fields["control_type"]="checkbox";
		$question_fields["mandatory"]="N";
		$question_fields["section"]=$section_id;
		$question_fields["extsearchhead"]="Interests";
		$query=insert_query($questions_tbl,$question_fields);
		$db->query($query);
		$imported_question_id=$db->getOne("select last_insert_id()");

		// Importing options from source tables
		$values=array();
		$query="select * from $pm_section_spr ";
		$spr_result=$db2->query($query);
		while(($spr_data=$spr_result->fetchRow()))
		{	// Adding new options for this question
			$option_fields=array();
			$option_fields["answer"]=$spr_data["name"];
			$option_fields["questionid"]=$imported_question_id;
			$query=insert_query($questionoptions_tbl,$option_fields);
			$db->query($query);
			$values[$spr_data["id"]]=$db->getOne("select last_insert_id()");
		}

		// Adding new question to osdate_imported_questions table
		$imported_question_fields=array();
		$imported_question_fields["question_id"]=$imported_question_id;
		$imported_question_fields["values_ids"]=serialize($values);
		$imported_question_fields["module"]="datingpro";
		$imported_question_fields["section"]=$section;
		$query=insert_query($imported_questions_tbl,$imported_question_fields);
		$db->query($query);
		$messages[]="Importing questions... OK";
		
		// 3. UPDATING ANSWERS
		// Cycle trough all records in $pm_section_spr_user
		$query="select * from $pm_section_spr_user ";
		$spr_user_result=$db2->query($query);
		while(($spr_user_data=$spr_user_result->fetchRow()))
		if($spr_user_data["id_value"]<3)
		{	// 1. Get imported_questions record
			$query="select * from $imported_questions_tbl where section='$section' and module='datingpro' ";
			$imported_question=$db->getRow($query);
			$imported_question["values_ids"]=unserialize($imported_question["values_ids"]);
			// 2. Get imported_user record
			$query="select * from $imported_users_tbl where source_id=".$spr_user_data["id_user"]." and module='datingpro' ";
			$imported_user=$db->getRow($query);
			// 3. Insert new record to $userpreference_tbl
			$fields=array();
			$fields["userid"]=$imported_user["user_id"];
			$fields["questionid"]=$imported_question["question_id"];
			$fields["answer"]=$imported_question["values_ids"][$spr_user_data["id_spr"]];
			$query=insert_query($userpreference_tbl,$fields);
			$db->query($query);
		}
		$messages[]="Updating users answers... OK";
		endif;
	endif;

	// Calculating statistics
	$imported=array();
	$imported["users"]=$db->getOne("select count(*) from ".DB_PREFIX."_imported_users where module='datingpro' ");
	$imported["descriptions"]=$db->getOne("select count(*) from ".DB_PREFIX."_imported_questions where module='datingpro' and section='descr' ");
	$imported["personalities"]=$db->getOne("select count(*) from ".DB_PREFIX."_imported_questions where module='datingpro' and section='personality' ");
	$imported["portraits"]=$db->getOne("select count(*) from ".DB_PREFIX."_imported_questions where module='datingpro' and section='portrait' ");
	$imported["interests"]=$db->getOne("select count(*) from ".DB_PREFIX."_imported_questions where module='datingpro' and section='interests' ");
	$t->assign("imported",$imported);

	$t->assign("messages",$messages);
	$t->assign('rendered_page', $t->fetch('admin/import_datingpro.tpl'));  
	$t->display ( 'admin/index.tpl' );
?>