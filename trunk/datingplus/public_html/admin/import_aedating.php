<?php
	define( 'SRC_PHOTOS_URL', 'http://aedating.ilmat/id_img/' );
	define( 'IMPORT_MODULE', "import_aedating" );

	define( 'PAGE_ID', 'admin_mgt' );
	$messages=array();
	if ( !defined( 'SMARTY_DIR' ) ) {
		include_once( '../init.php' );
	}
	include ( 'sessioninc.php' );
	include("import_config.php");
	include("import_aedating_prof.php");

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
		$sections=$db->getAll($query);
		$t->assign("sections",$sections);
		$t->assign('rendered_page', $t->fetch('admin/import_section.tpl'));  
		$t->display ( 'admin/index.tpl' );
		exit;
	endif;

	// =================================================================================
	// IMPORTING USERS
	// =================================================================================
	if($module=="users"):
		// 1. DELETING PREVIOUS IMPORTS
		$query="select * from ".DB_PREFIX."_imported_users where module='aedating'";
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
		$query="delete from ".DB_PREFIX."_imported_users where module='aedating'";
		$db->query($query);
		$messages[]="Deleting previous imported users... OK";

		if($action=="import"):
			// 2. IMPORTING NEW USERS
			// Importing new users
			$query="select * from Profiles";
			$result2=$db2->query($query);
			while(($data=$result2->fetchRow()))
			{	// 2.1 IMPORTING SIGNUP INFORMATION
				$gendres=array("male"=>"M","female"=>"F","couple"=>"C");
				$statuses=array("Unconfirmed"=>"Pending","Approval"=>"Pending","Active"=>"Active","Rejected"=>"Reject","Suspended"=>"Suspend");
				
				$fields=array();
				$fields["username"]=$data["NickName"];
				$fields["password"]=md5($data["Password"]);
				$fields["firstname"]=$data["RealName"];
				$fields["lastname"]=$data["RealName2"];
				$fields["email"]=$data["Email"];
				$fields["gender"]=$gendres[$data["Sex"]];
				$fields["lookgender"]=$gendres[$data["LookingFor"]];
				$lookingage=explode("-",$data["LookingAge"]);
				$fields["lookagestart"]=$lookingage[0];
				$fields["lookageend"]=$lookingage[1];
				$fields["birth_date"]=$data["DateOfBirth"];
				if(!empty($data["Country"]))
				{	$src_country=$prof[countries][$data["Country"]];
					$fields["country"]=$db->getOne("select code from ".DB_PREFIX."_countries where name='".$src_country."'");
				}
				$fields["city"]=$data["City"];
				$fields["zip"]=$data["zip"];
				$fields["active"]=($data["Status"]=="Active"?"1":"0");
				$fields["status"]=$statuses[$data["Status"]];

				// Inserting into osdate_user
				$query=insert_query(DB_PREFIX."_user",$fields);
				$result=$db->query($query);
				$imported_user_id=$db->getOne("select last_insert_id()");

				// Inserting into osdate_inserted_users
				$fields=array();
				$fields["source_id"]=$data["ID"];
				$fields["user_id"]=$imported_user_id;
				$fields["module"]="aedating";
				$query=insert_query(DB_PREFIX."_imported_users",$fields);
				$db->query($query);
//debug($imported_user_id);

				// 2.2 IMPORTING PHOTOS OF USER
				for($picno=0;$picno<=10;$picno++)
				if(!empty($data["Pic_".$picno."_addon"]))
				{	// Creating new image
					$fields=array();
					$fields["userid"]=$imported_user_id;
					$fields["picno"]=$picno+1;

					$filename=$_SESSION[IMPORT_MODULE]["photos_url"].$data["ID"]."_".$picno."_".$data["Pic_".$picno."_addon"].".jpg";
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

					$fields["active"]="1";
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

	// Generates new questions based on specified field from 'Profile' table
	function questions_make($section,$section_id,$arrayname,$question,$control_type)
	{	global $db,$db2;
		global $prof;
		$questions_tbl=DB_PREFIX."_questions";
		$questionoptions_tbl=DB_PREFIX."_questionoptions";
		$imported_questions_tbl=DB_PREFIX."_imported_questions";

		// Adding new question to osdate_questions table
		$question_fields=array();
		$question_fields["question"]=$question;
		$question_fields["control_type"]=$control_type;
		$question_fields["mandatory"]="N";
		$question_fields["section"]=$section_id;
		$question_fields["displayorder"]=0;
		$question_fields["extsearchhead"]=$question;
		$query=insert_query($questions_tbl,$question_fields);
		$db->query($query);
		$imported_question_id=$db->getOne("select last_insert_id()");

		// Importing options for this question
		if($control_type=="select"):
			$values=array();
			foreach($prof[$arrayname] as $key=>$value)
			{	// Adding new options for this question
				$option_fields=array();
				$option_fields["answer"]=$value;
				$option_fields["questionid"]=$imported_question_id;
				$query=insert_query($questionoptions_tbl,$option_fields);
				$db->query($query);
				$values[$key]=$db->getOne("select last_insert_id()");
			}
		endif;

		// Adding new question to osdate_imported_questions table
		$imported_question_fields=array();
		$imported_question_fields["question_id"]=$imported_question_id;
		$imported_question_fields["values_ids"]=serialize($values);
		$imported_question_fields["module"]="aedating";
		$imported_question_fields["section"]=$section;
		$query=insert_query($imported_questions_tbl,$imported_question_fields);
		$db->query($query);
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
	function questions_update_answers($section,$fieldname,$control_type)
	{	global $db,$db2;
		$questions_tbl=DB_PREFIX."_questions";
		$questionoptions_tbl=DB_PREFIX."_questionoptions";
		$imported_questions_tbl=DB_PREFIX."_imported_questions";
		$imported_users_tbl=DB_PREFIX."_imported_users";
		$userpreference_tbl=DB_PREFIX."_userpreference";
		
		// Cycle trough all records in $pm_section_spr_user
		$query="select * from Profiles ";
		$profile_result=$db2->query($query);
		while(($profile_data=$profile_result->fetchRow()))
		{	// 1. Get imported_questions record
			$query="select * from $imported_questions_tbl where section='$section' and module='aedating' ";
			$imported_question=$db->getRow($query);
			$imported_question["values_ids"]=unserialize($imported_question["values_ids"]);
			// 2. Get imported_user record
			$query="select * from $imported_users_tbl where source_id=".$profile_data["ID"]." and module='aedating' ";
			$imported_user=$db->getRow($query);
			// 3. Insert new record to $userpreference_tbl
			$fields=array();
			$fields["userid"]=$imported_user["user_id"];
			$fields["questionid"]=$imported_question["question_id"];
			if($control_type=="select")
				$fields["answer"]=$imported_question["values_ids"][$profile_data[$fieldname]];
			elseif($control_type=="textarea")
				$fields["answer"]=$profile_data[$fieldname];
			$query=insert_query($userpreference_tbl,$fields);
			$db->query($query);
		}
	}

$importing_fields=array();
$importing_fields[]=array("section"=>"children",
                          "fieldname"=>"Children",
						  "control_type"=>"select",
						  "question"=>"Children"
						 );
$importing_fields[]=array("section"=>"where_children",
                          "fieldname"=>"WhereChildren",
						  "control_type"=>"select",
						  "question"=>"Where Children"
						 );
$importing_fields[]=array("section"=>"want_children",
                          "fieldname"=>"WantChildren",
						  "control_type"=>"select",
						  "question"=>"Want Children"
						 );
$importing_fields[]=array("section"=>"height",
                          "fieldname"=>"Height",
						  "control_type"=>"select",
						  "question"=>"Height"
						 );
$importing_fields[]=array("section"=>"bodytype",
                          "fieldname"=>"BodyType",
						  "control_type"=>"select",
						  "question"=>"Body Type"
						 );
$importing_fields[]=array("section"=>"religion",
                          "fieldname"=>"Religion",
						  "control_type"=>"select",
						  "question"=>"Religion"
						 );
$importing_fields[]=array("section"=>"ethnicity",
                          "fieldname"=>"Ethnicity",
						  "control_type"=>"select",
						  "question"=>"Ethnicity"
						 );
$importing_fields[]=array("section"=>"maritalstatus",
                          "fieldname"=>"MaritalStatus",
						  "control_type"=>"select",
						  "question"=>"Marital Status"
						 );
$importing_fields[]=array("section"=>"occupation",
                          "fieldname"=>"Occupation",
						  "control_type"=>"textarea",
						  "question"=>"Occupation"
						 );
$importing_fields[]=array("section"=>"education",
                          "fieldname"=>"Education",
						  "control_type"=>"select",
						  "question"=>"Education"
						 );
$importing_fields[]=array("section"=>"income",
                          "fieldname"=>"Income",
						  "control_type"=>"select",
						  "question"=>"Income"
						 );
$importing_fields[]=array("section"=>"smoker",
                          "fieldname"=>"Smoker",
						  "control_type"=>"select",
						  "question"=>"Smoker"
						 );
$importing_fields[]=array("section"=>"drinker",
                          "fieldname"=>"Drinker",
						  "control_type"=>"select",
						  "question"=>"Drinker"
						 );
$importing_fields[]=array("section"=>"descriptionme",
                          "fieldname"=>"DescriptionMe",
						  "control_type"=>"textarea",
						  "question"=>"Description Me"
						 );
$t->assign("importing_fields",$importing_fields);
	// =================================================================================
	// IMPORTING FIELDS
	// =================================================================================
	foreach($importing_fields as $field_key=>$field_array)
	{	if($module==$field_array["section"]):
			questions_delete($module);
			$messages[]="Deleting previous imports... OK";
			if($action=="import"):
				questions_make($module,$section_id,$field_array["section"],$field_array["question"],$field_array["control_type"]);
				$messages[]="Importing questions... OK";
				questions_update_answers($module,$field_array["fieldname"],$field_array["control_type"]);
				$messages[]="Updating users answers... OK";
			endif;
		endif;
	}

	// Calculating statistics
	$imported=array();
	$imported["users"]=$db->getOne("select count(*) from ".DB_PREFIX."_imported_users where module='aedating' ");
	foreach($importing_fields as $field_key=>$field_array)
	{	$imported[$field_array["section"]]=$db->getOne("select count(*) from ".DB_PREFIX."_imported_questions where module='aedating' and section='".$field_array["section"]."' "); }
	$t->assign("imported",$imported);

	$t->assign("messages",$messages);
	$t->assign('rendered_page', $t->fetch('admin/import_aedating.tpl'));  
	$t->display ( 'admin/index.tpl' );
?>