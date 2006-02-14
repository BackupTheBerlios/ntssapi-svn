<?php
// The format of this file is ---> $lang['message'] = 'text';
//
// You should also try to set a locale and a character encoding (plus direction). The encoding and direction
// will be sent to the template. The locale may or may not work, it's dependent on OS support and the syntax
// varies ... give it your best guess!

// -----------------------------------------------
// |  Translated by Did aka Deed  v1.0 RC5  |
// |                                             |
// -----------------------------------------------



$lang['ENCODING'] = 'iso-8859-1';
$lang['DIRECTION'] = 'ltr';
$lang['LEFT'] = 'left';
$lang['RIGHT'] = 'right';
$lang['DATE_FORMAT'] =  DATE_FORMAT; // This should be changed to the default date format for your language, php date() format
$lang['DATE_TIME_FORMAT'] =  DATE_TIME_FORMAT; // This should be changed to the default date format for your language, php date() format
$lang['DISPLAY_DATE_FORMAT'] =  DISPLAY_DATE_FORMAT;
$lang['DB_ERROR'] = "D�sol�, erreur de base de donn�es. <br>Svp essayez encore";


$lang['main_menu'] = 'Menu principal';
$lang['homepage'] = 'Page d\'accueil';
$lang['rate_photos'] = 'Evaluation photos';
$lang['forum'] = 'Forum';
$lang['manageforum'] = 'Gestion de forums';
$lang['chat'] = 'Tchat';
$lang['managechat'] = 'Admin tchat';
$lang['member_login'] = 'Espace membres';
$lang['featured_members'] = 'Membres inscrits';
$lang['quick_search'] = 'Recherche rapide';
$lang['my_searches'] = 'Mes recherches';
$lang['affiliates'] = 'Affili�s';
$lang['already_affiliate'] = 'D�j� affili� ?';
$lang['referals'] = 'Referals';
$lang['title_colon'] = 'Titre:';
$lang['comments_colon'] = 'Commentaires:';
$lang['feedback'] = 'Commentaires';

$lang['profiles'] = 'Profiles';
$lang['profile_s'] = '\'Profile';
$lang['total_amt'] = 'Montant total';
$lang['banner_link'] = 'Lien_banni�re';
$lang['clicks'] = 'Cliques';
$lang['finance_calc'] = 'Calculatrice finance ';
$lang['flash_chat_msg'] = 'FlashChat 4.1.0 and higher include an integration class for osDate.
	Please purchase FlashChat from <a href="http://www.tufat.com/chat.php" target="_blank">http://www.tufat.com/chat.php</a> and copy the files to this folder.
	Then, run the FlashChat installer, and specify osDate as the CMS to integrate with.';
$lang['flash_chat_admin_msg'] = 'FlashChat 4.1.0 and higher include an integration class for osDate.
	Please purchase FlashChat from <a href="http://www.tufat.com/chat.php" target="_blank">http://www.tufat.com/chat.php</a> and copy the files to this folder.
	Then, run the FlashChat installer, and specify osDate as the CMS to integrate with.';
$lang['affiliate_head_msg'] = 'Devenez affili�s...';
$lang['affiliate_head_msg2'] = 'Nous offrons des commissions aux webmasters qui envoient des visiteurs sur notre site.<br/>';
$lang['affiliate_success_msg1'] = 'Votre num�ro de compte affili� est:';
$lang['affiliate_success_msg2'] = 'Vous pouvez acc�der � votre compte affili� maintenant. ';
$lang['affiliate_login_title'] = "Espace affili�";
$lang['password_changed_successfully'] = 'Mot de passe chang� avec succ�s.';
$lang['affiliate_registration_success'] = 'Inscription affili� r�ussie';
$lang['login_now'] = 'Connection';
$lang['must_be_valid'] = 'Doit �tre valide';
$lang['characters'] = 'Caract�res';
$lang['email'] = 'Email:';
$lang['age'] = 'Age';
$lang['years'] = 'Ans';

$lang['all_states'] = 'Tous les Etats';
//
// These terms are used at Signup page
//
$lang['welcome'] = 'Bienvenue';
$lang['admin_welcome'] = 'Bienvenue <br /> sur <br />' . stripslashes(stripslashes(SITENAME)) . '<br /> Admin Panel';
$lang['title'] = 'Bienvenue sur ' . stripslashes(SITENAME);
$lang['site_links'] = array(
	'home' => 'Accueil',
	'signup_now' => 'Rejoignez-nous',
	'chat' => 'Tchat',
	'forum' => 'Forum',
	'login' => 'Identifiez-vous',
	'search' => 'Chercher',
	'aboutus' => 'A propos ...',
	'forgot' => 'Passe oubli� ?',
	'contactus' => 'Nous contacter',
	'privacy' => 'Vie priv�e',
	'terms_of_use' => 'Conditions g�n�rales',
	'services' => 'Services',
	'faq' => 'FAQ\'s',
	'articles' => 'Articles',
	'affliates' => 'Affili�s',
	'invite_a_friend' => 'Inviter un ami',
	'feedback' => 'Commentaires'
	);

$lang['success_stories'] = 'Histoires v�cues';
$lang['members_login'] = 'Login';
$lang['poll'] = 'Sondage';
$lang['news'] = 'Nouvelles';
$lang['articles'] = 'Articles';
$lang['poll_result'] = 'R�sultats du sondage';
$lang['view_poll_archive'] = 'Autres sondages';
$lang['member_panel'] = 'Espace membre';
$lang['poll_errmsg1'] = 'Vous avez d�j� vot� pour ce sondage..';
$lang['close'] = 'Fermer';
$lang['all_stories'] = 'Toutes les histoires';
$lang['all_news'] = 'Toutes les nouvelles';
$lang['more'] = 'plus';
$lang['by'] = 'par';

$lang['dont_stay_alone'] = 'Ne restez pas seul,';
$lang['join_now_for_free'] = 'Inscrivez vous gratuitement';
$lang['special_offer'] = 'Offre Sp�ciale!';
$lang['welcome_to'] = 'Bienvenue sur ';
$lang['welcome_to_site'] = 'Bienvenue sur '.stripslashes(SITENAME);

$lang['offer_text'] = 'D�couvrez ' . stripslashes(SITENAME) . ' Le site de Rencontres le plus adapt� � votre recherche. Testez notre ' . stripslashes(SITENAME) . ' Profil Personnalis� pour savoir ce que vous inspirez vraiment aux autres ! Recherchez les profils qui vous correspondent, dialoguez en direct, g�rez votre galerie de photos... D�marrez d�s maintenant la merveilleuse aventure de l\'amour ! Inscrivez-vous Gratuitement...';

$lang['newest_profiles'] = 'Derniers profils ajout�s';

$lang['edit_profile'] = 'Modifier le profil';
$lang['total_profiles'] = 'Nombre d\'inscrits';
$lang['forgot'] = 'Passe oubli� ?';
$lang['hide'] = 'Cacher';
$lang['show'] = 'Montrer';
$lang['sex'] = 'Sexe:';
$lang['sex_without_colon'] = 'Sexe';
$lang['pageno'] = 'Page ';
$lang['page'] = 'Page';
$lang['previous'] = 'Pr�c�dent';
$lang['next'] = 'Suivant';
$lang['time_col'] = 'Heure:';

$lang['save_search'] = 'Sauvegarder la recherche';
$lang['find_your_match'] = 'Trouver une �me soeur';

$lang['extended_search'] = 'Recherche approfondie';
$lang['matches_found'] = 'Ces profils correspondent � vos crit�res.';
$lang['timezone'] = 'Fuseau horaire';
$lang['next_section'] = 'Section suivante';
$lang['sign_in'] = 'S\'inscrire';
$lang['member_panel'] = 'Espace membre';
$lang['aff_panel'] = 'Affiliate Panel';
$lang['login_title'] = 'Zone membre';
$lang['sign_out'] = 'D�connection';
$lang['login_submit'] = 'Connection';

$lang['change_password'] = 'Modifier le passe';
$lang['old_password'] = 'Ancien mot de passe:';
$lang['new_password'] = 'Nouveau mot de passe:';
$lang['confirm_password'] = 'Confirmez le mot de passe:';
$lang['password_change_msg'] = 'Votre mot de passe � �t� modifi� avec succ�s.';

$lang['section_signup_title'] = 'Information d\'inscription';
$lang['signup'] = 'Inscription';
$lang['section_basic_title'] = 'Informations basiques';
$lang['section_appearance_title'] = 'Aspect physique';
$lang['section_interests_title'] = 'Centre d\'int�r�ts';
$lang['section_lifestyle_title'] = 'Style de vie';

$lang['signup_subtitle_login'] = 'Informations de connection';
$lang['signup_subtitle_profile'] = 'Votre profile';
$lang['signup_subtitle_address'] = 'Adresse';
$lang['signup_subtitle_appearacnce'] = 'Aspect physique';
$lang['signup_subtitle_preference'] = 'Pr�f�rences de recherche';

$lang['signup_username'] = 'Pseudo:';
$lang['signup_password'] = 'Mot de Passe:';
$lang['signup_confirm_password'] = 'Confirmation Mot de Passe:';

$lang['signup_firstname'] = 'Nom:';
$lang['signup_lastname'] = 'Pr�nom:';
$lang['signup_email'] = 'Adresse Email:';
$lang['section_mypicture'] = 'Mes Photos';
$lang['upload'] = 'Envoyer';
$lang['upload_pictures'] = 'G�rer mes photos';
$lang['upload_format_msgs'] = 'Fichiers photos uniquement aux formats .jpg ou .gif ou .png.';
$lang['thumbnail'] = 'Miniature ';
$lang['picture'] = 'Photo';
$lang['signup_picture'] = 'Ma Photo';
$lang['signup_picture2'] = 'Ma Photo 2:';
$lang['signup_picture3'] = 'Ma Photo 3:';
$lang['signup_picture4'] = 'Ma Photo 4:';
$lang['signup_picture5'] = 'Ma Photo 5:';

$lang['signup_gender'] = 'Je suis un(e)';
$lang['signup_pref_age_range'] = 'Age';
$lang['signup_year_old'] = 'ans';
$lang['signup_birthday'] = 'Anniversaire:';
$lang['signup_country'] = 'Pays:';
$lang['signup_state_province'] = 'Etat / Province:';
$lang['signup_zip'] = 'Zip / Code Postal:';
$lang['signup_city'] = 'Ville / Localit�: ';
$lang['signup_address1'] = 'Adresse, ligne 1:';
$lang['signup_address2'] = 'Adresse, ligne 2:';
$lang['signup_height'] = 'Taille: ';
$lang['signup_feet'] = 'pieds';
$lang['signup_meter_inches'] = 'inches [ metres ]';
$lang['signup_weight'] = 'Poids:';
$lang['signup_pounds'] = 'pounds [ kilogrammes ]';
$lang['signup_where_should_we_look'] = 'Ou voulez-vous faire des rencontres ?';
$lang['signup_view_online'] = "Montrer aux autres membres que vous �tes en ligne ?";

$lang['signup_gender_values'] = array(
	'M' => 'Homme',
	'F' => 'Femme',
	'C' => 'Couple'
	);

$lang['signup_gender_look'] = array(
	'M' => 'Homme',
	'F' => 'Femme',
	'C' => 'Couple',
	'B' => 'Homme ou Femme',
	'A' => 'Peu importe'
	);

$lang['seeking'] = 'Cherche un(e)';
$lang['who_is_from'] = 'de';
$lang['looking_for_a'] = 'recherchant un(e)';
$lang['looking_for'] = 'Cherche:';

$lang['of'] = ' de ';
$lang['to'] = ' � ';
$lang['from'] = ' de ';
$lang['for'] = ' pour ';
$lang['yes'] = 'Oui';
$lang['no'] = 'Non';
$lang['cancel'] = 'Annuler';

$lang['change'] = 'Changer';
$lang['submit'] = 'Sauvegarder';
$lang['reset'] = 'Recommencer';

//Commonly used words

$lang['required_info_indication'] = ' Champ obligatoire';
$lang['required_info_indicator'] = '* ';
$lang['required_info_indicator_color'] = 'red';
$lang['click_here'] = 'Cliquer ici';

$lang['datetime_day']['Sunday'] = 'Dimanche';
$lang['datetime_day']['Monday'] = 'Lundi';
$lang['datetime_day']['Tuesday'] = 'Mardi';
$lang['datetime_day']['Wednesday'] = 'Mercredi';
$lang['datetime_day']['Thursday'] = 'Jeudi';
$lang['datetime_day']['Friday'] = 'Vendredi';
$lang['datetime_day']['Saturday'] = 'Samedi';
$lang['datetime_dayval']['Sun'] = 'Dim';
$lang['datetime_dayval']['Mon'] = 'Lun';
$lang['datetime_dayval']['Tue'] = 'Mar';
$lang['datetime_dayval']['Wed'] = 'Mer';
$lang['datetime_dayval']['Thu'] = 'Jeu';
$lang['datetime_dayval']['Fri'] = 'Ven';
$lang['datetime_dayval']['Sat'] = 'Sam';

$agecounter = array();

for($i=18; $i<100; $i++ ) {
	$agecounter[] = $i;
}
$lang['start_agerange'] = $agecounter;
$lang['end_agerange'] = $agecounter;

$lang['error_msg_color'] = 'Red';
$lang['success_message'] = "L'information que vous avez saisie a �t� enregistr�e avec succ�s. <br>Vous serez automatiquement redirig� � la prochaine section dans 5 secondes . Si la redirection automatique ne fonctionne pas, Cliquez sur le lien ci-dessous .";
$lang['signup_success_message'] = 'F�licitations !<br>Maintenant vous �tes membre de  ' . stripslashes(SITENAME);
$lang['sendletter_success'] = 'La lettre a �t� envoy�e avec succ�s.';

// These are displayed in the timezone select box
$lang['tz']['-25'] = '-- Select --';
$lang['tz']['-12.00'] = 'GMT - 12 Heures';
$lang['tz']['-11.00'] = 'GMT - 11 Heures';
$lang['tz']['-10.00'] = 'GMT - 10 Heures';
$lang['tz']['-9.00'] = 'GMT - 9 Heures';
$lang['tz']['-8.00'] = 'GMT - 8 Heures';
$lang['tz']['-7.00'] = 'GMT - 7 Heures';
$lang['tz']['-6.00'] = 'GMT - 6 Heures';
$lang['tz']['-5.00'] = 'GMT - 5 Heures';
$lang['tz']['-4.00'] = 'GMT - 4 Heures';
$lang['tz']['-3.5'] = 'GMT - 3.5 Heures';
$lang['tz']['-3.00'] = 'GMT - 3 Heures';
$lang['tz']['-2.00'] = 'GMT - 2 Heures';
$lang['tz']['-1.00'] = 'GMT - 1 Heure';
$lang['tz']['0.00'] = 'GMT';
$lang['tz']['1.00'] = 'GMT + 1 Heure';
$lang['tz']['2.00'] = 'GMT + 2 Heures';
$lang['tz']['3.00'] = 'GMT + 3 Heures';
$lang['tz']['3.5'] = 'GMT + 3.5 Heures';
$lang['tz']['4'] = 'GMT + 4 Heures';
$lang['tz']['4.5'] = 'GMT + 4.5 Heures';
$lang['tz']['5.00'] = 'GMT + 5 Heures';
$lang['tz']['5.5'] = 'GMT + 5.5 Heures';
$lang['tz']['6.00'] = 'GMT + 6 Heures';
$lang['tz']['6.5'] = 'GMT + 6.5 Heures';
$lang['tz']['7.00'] = 'GMT + 7 Heures';
$lang['tz']['8.00'] = 'GMT + 8 Heures';
$lang['tz']['9'] = 'GMT + 9 Heures';
$lang['tz']['9.5'] = 'GMT + 9.5 Heures';
$lang['tz']['10.00'] = 'GMT + 10 Heures';
$lang['tz']['11.00'] = 'GMT + 11 Heures';
$lang['tz']['12.00'] = 'GMT + 12 Heures';
$lang['tz']['13.00'] = 'GMT + 13 Heures';


/*****************Admin Section Labels********************/

//Commonly used labels
$lang['admin_login_title'] = stripslashes(SITENAME) . ' Panneau d\'Administration';
$lang['admin_login_msg'] = 'Connection';
$lang['admin_title_msg'] = stripslashes(SITENAME) . ' Panneau d\'Administration';
$lang['admin_panel'] = 'Panneau d\'Admin';
$lang['back'] = 'Retour';
$lang['insert_msg'] = 'Ins�rer nouveau message ';
$lang['question_mark'] = '?';
$lang['id'] = 'Id:';
$lang['name'] = 'Utilisateur';
$lang['name_col'] = 'Utilisateur';
$lang['enabled'] = 'Activ�';
$lang['action'] = 'Action';
$lang['edit'] = 'Edition';
$lang['delete'] = 'Effacer';
$lang['section'] = 'Section';
$lang['insert_section'] = 'Inserer nouvelle section';
$lang['modify_section'] = 'Modifier la section';
$lang['modify_sections'] = 'Modifier les sections';
$lang['delete_section'] = 'Effacer la section';
$lang['delete_sections'] = 'Effacer les sections';
$lang['enable_selected'] = 'Activer';
$lang['disable_selected'] = 'Desactiver';
$lang['change_selected'] = 'Changer';
$lang['delete_selected'] = 'Effacer';
$lang['no_select_msg'] = 'Vous n\'avez pas choisi d\'option. Utiliser le bouton Retour de votre navigateur pour choisir une ou plusieurs options.';
$lang['delete_confirm_msg'] = 'Etes-vous certain de vouloir effacer cette section ?';
$lang['delete_group_confirm_msg'] = 'Etes-vous certain de vouloir effacer ces sections ? Cette action est irr�versible.';
$lang['enabled_values'] = array(
	'Y' => 'Oui',
	'N' => 'Non'
	);
$lang['display_control_type'] = array(
	'checkbox' => 'Checkbox',
	'radio' => 'Option Button',
	'select' => 'Drop down list',
	'textarea' => 'Inputbox'
	);
$lang['admin_error_color'] = 'Red';

$lang['col_head_srno'] = '#';
$lang['col_head_id'] = 'Id';
$lang['col_head_question'] = 'Question';
$lang['col_head_enabled'] = 'Activ�';
$lang['col_head_name'] = 'Utilisateur';
$lang['col_head_username'] = 'Utilisateur';
$lang['col_head_firstname'] = 'Pr�nom';
$lang['col_head_lastname'] = 'Nom';
$lang['col_head_fullname'] = 'Nom complet';
$lang['col_head_status'] = 'Statut';
$lang['col_head_gender'] = 'Sexe';
$lang['col_head_email'] = 'Email';
$lang['col_head_country'] = 'Pays';
$lang['col_head_city'] = 'Ville';
$lang['col_head_zip'] = 'Code Postal';
$lang['col_head_register_at'] = 'Enregistr� �';

$lang['section_title'] = 'Gestion de sections';
$lang['total_sections'] = 'Total Sections:';
$lang['profile_title'] = 'Gestion de profils';
$lang['total_profiles_found'] = 'Total des profils trouv�s:';
$lang['modify_profile'] = 'Modifier le profile';

$lang['profile_signup_title'] = 'Informations d\'inscription';
$lang['profile_basic_title'] = 'Informations basiques';
$lang['profile_appearance_title'] = 'Apparence';
$lang['profile_interests_title'] = 'Int�r�ts';
$lang['profile_lifestyle_title'] = 'Style de vie';

$lang['profile_subtitle_login'] = 'Details de connection';
$lang['profile_subtitle_profile'] = 'Profile';
$lang['profile_subtitle_address'] = 'Adresse';
$lang['profile_subtitle_appearacnce'] = 'Apparence';
$lang['profile_subtitle_preference'] = 'Pr�f�rences';
$lang['profile_delete_confirm_msg'] = 'Etes-vous certain de vouloir supprimer ce profil ?';
$lang['delete_profile'] = 'Effacer le profil';
$lang['profile_username'] = 'Nom d\'utilisateur:';
$lang['profile_firstname'] = 'Pr�nom:';
$lang['profile_lastname'] = 'Nom:';
$lang['profile_email'] = 'Adresse email:';
$lang['profile_gender'] = 'Sexe:';
$lang['profile_birthday'] = 'Anniversaire:';
$lang['profile_country'] = 'Pays:';
$lang['profile_state_province'] = 'Etat / Province:';
$lang['profile_zip'] = 'Code Postal:';
$lang['profile_city'] = 'Ville';
$lang['profile_address1'] = 'Adresse, ligne 1:';
$lang['profile_address2'] = 'Adresse, ligne 2:';
$lang['find'] = 'Trouver';
$lang['search'] = 'Chercher';
$lang['AND'] = 'ET';
$lang['OR'] = 'OU';
$lang['order_by'] = 'Trier par: ';
$lang['sort_by'] = 'Afficher par: ';
$lang['sort_types'] = array(
	'asc' => 'Ascendant',
	'desc' => 'Descendant'
	);
$lang['search_results'] = 'R�sultat de recherche';
$lang['no_record_found'] = 'Aucun profil trouv�.';
$lang['search_options'] = 'Options de recherche';
$lang['search_simple'] = 'Recherche simplifi�e';
$lang['search_advance'] = 'Recherche avanc�e';
$lang['search_advance_results'] = 'R�sultat de recherche avanc�e';
$lang['search_country'] = 'Rechercher par Pays';
$lang['search_states'] = 'Rechercher par Etat';
$lang['search_zip'] = 'Rechercher par Code Postal';
$lang['search_city'] = 'Rechercher par Ville';
$lang['search_wildcard_msg'] = 'Vous pouvez entrer * dans la bo�te de saisie pour rechercher tous les enregistrements. ';
$lang['search_location'] = '<b>Chercher par lieu:</b>';
$lang['select_country'] = 'Pays';
$lang['select_state'] = 'Etat:';
$lang['enter_city'] = 'Ville:';
$lang['enter_zip'] = 'Code Postal:';
$lang['enter_username'] = 'Pseudo:';
$lang['results_per_page'] = 'R�sultats par page';
$lang['search_results_per_page'] = array( 5 => 5 , 10 => 10, 20 => 20, 50 => 50, 100 => 100 );
$lang['order'] = 'Ordre';
$lang['up'] = 'Haut';
$lang['down'] = 'Bas';

$lang['question'] = 'Question:';

$lang['maxlength'] = 'Longueur Maximum:';
$lang['description'] = 'Description:';
$lang['mandatory'] = 'Obligatoire:';
$lang['guideline'] = 'Directive:';
$lang['control_type'] = 'Afficher les contr�les:';
$lang['include_extsearch'] = 'Inclure dans la recherche �tendue:';
$lang['head_extsearch'] = 'En-t�te de recherche �tendue:';

$lang['insert_question'] = 'Inserer une question';
$lang['delete_question'] = 'Effacer une question';
$lang['modify_question'] = 'Modifier une question';
$lang['questions_title'] = 'G�rer les questions';
$lang['total_options'] = 'Options totales:';
$lang['insert_question'] = 'Inserer une nouvelle question';
$lang['total_questions'] = 'Questions totales:';
$lang['delete_questions'] = 'Effacer les questions';
$lang['delete_group_questions_confirm_msg'] = 'Etes-vous certain de vouloir effacer les questions ?';

// defined by ALI
$lang['option'] = 'Options';
$lang['answer'] = 'R�ponses';
$lang['options_title'] = 'Question Options';
$lang['col_head_answer'] = 'R�ponse';
$lang['with_selected'] = 'Selectionn�';
$lang['ranging'] = 'Ranging';

// Instant messenger
$lang['instant_messenger'] = 'Messagerie Instantan�e';
$lang['instant_message'] = 'Message Instantan�';
$lang['im_from'] = 'De:';
$lang['im_message'] = 'Message:';
$lang['im_reply'] = 'R�ponse';
$lang['close_window'] = 'Fermer la fen�tre';

// my matches
$lang['my_matches'] = 'Mes contacts';
$lang['i_am_a'] = 'Je suis un(e)';
$lang['Looking_for'] = 'Cherche un(e)';
$lang['Between'] = 'entre';
$lang['who_is_from'] = 'de';
$lang['showing'] = 'Apparence';
$lang['your_search_preferences'] = 'Vos pr�f�rences de recherche :';
$lang['to_edit_search_preferences'] = 'Editer les pr�f�rences de recherche ';

$lang['unapproved_user'] = 'Profils pour approbation' ;
$lang['gbl_settings'] = 'Param�tres g�n�raux du site';
$lang['configurations'] = 'Configurations';
$lang['col_head_variable'] = 'Variable';
$lang['col_head_value'] = 'Valeur';

$lang['affiliate_title'] = 'Gestion des affili�s';
$lang['col_head_counter'] = 'Compteur';
$lang['col_head_status'] = 'Statut';

$lang['tell_later'] = 'Je vous le dirai plus tard';
$lang['view_profile'] = 'Visualiser le Profil';
$lang['view_profile_errmsg1']  = 'Vous n\'avez toujours pas sp�cifi� vos pr�f�rences.<br />Merci de le faire maintenant.<br />.';
$lang['view_profile_errmsg2'] = '<br>Cliquez ici pour indiquer vos pr�f�rences.';
$lang['view_profile_errmsg3'] = 'Cette personne n\'a pas encore indiqu� ses pr�f�rences.';
$lang['view_profile_restricted'] = 'C\'est un profil restreint, que vous ne pouvez pas visualiser.';
$lang['profile_notset'] = 'Aucun profil trouv� pour l\'utilisateur .';
$lang['send_mail'] = 'Envoyer un message';
$lang['mail_messages'] = 'Messages';
$lang['col_head_subject'] = 'Sujet';
$lang['col_head_sendtime'] = 'Date';

$lang['inbox'] = 'Boite de r�ception';
$lang['sent'] = 'Envoy�';
$lang['trashcan'] = 'Poubelle';
$lang['reply'] = 'R�pondre';
$lang['read'] = 'Lu';
$lang['unread'] = 'Pas lu';
$lang['restore'] = 'Restaurer';
$lang['subject'] = 'Sujet';
$lang['subject_colon'] = 'Sujet:';
$lang['message'] = 'Message';
$lang['send'] = 'Envoyer';

$lang['send_letter'] = 'Envoyer lettre';
$lang['image_browser'] = 'S�lecteur d\images';
$lang['upload_image'] = 'Envoyer image';
$lang['delete_image'] = 'Effacer image';
$lang['show_image'] = 'Afficher image';
$lang['send_invite'] = 'Envoyez l\'invitation ';
$lang['letter_title'] = 'Nouvelle lettre';
$lang['from_email'] = 'De l\'email:';
$lang['from_name'] = 'De l\'utilisateur:';
$lang['send_to'] = 'Envoyer';
$lang['email_subject'] = 'Sujet:';
$lang['save_as'] = 'Sauvegarder sous...';

$lang['no_message'] = 'Vous n\'avez pas de nouveaux messages.';
$lang['descrip'] = 'Description';

//forgot password words
$lang['forgotpass_msg1'] = "Rappel de connection";
$lang['forgotpass_msg2'] = "Veuillez fournir l'adresse e-mail avec laquelle vous avez cr�e votre profil.";
$lang['retreieve_info'] = 'Envoyer';
$lang['forgotpass'] = 'Passe oubli�';

//Tell a friend
$lang['tellafriend'] = 'Inviter un ami';
$lang['taf_msg1'] = 'Inviter un ami sur ' . stripslashes(SITENAME);
$lang['taf_yourname'] = 'Votre nom:';
$lang['taf_youremail'] = 'Votre email:';
$lang['taf_friendemail'] = 'Email de votre ami:';

//Auto-mail
$lang['confirm_your_profile'] = 'Confirmez votre inscription';
$lang['letter_not_avail'] = 'Mod�le de lettre non disponible';
$lang['confirm_letter_sent'] = 'Un email de confirmation vient de vous �tre envoy�. Veuillez valider votre inscription en cliquant sur le lien contenu dans le message.';
$lang['letter_not_sent'] = 'Impossible d\'envoyer un �mail de confirmation, veuillez contacter l\'administrateur.';
$lang['or'] = 'Ou';
$lang['enter_confirm_code'] = 'Indiquez ci-dessous le code de confirmation pour valider votre inscription.';
$lang['wrong_activationcode'] = 'Le code de confirmation indiqu� n\'est pas correct .';
$lang['confirm_success'] = 'Retour � l\'Accueil.';

//Page management

$lang['manage_pages'] = 'Gestion de pages';
$lang['pagetitle'] = 'Titre:';
$lang['pagetext'] = 'Texte:';
$lang['pagekey'] = 'cl�:';
$lang['addpage'] = 'Ajouter une page';
$lang['page'] = 'Page:';
$lang['addnew'] = 'Ajouter une nouvelle';
$lang['modpage'] = 'Modifier la page';
$lang['pagekey_help'] = 'http://www.yoursite.com/index.php?key=YOUR_KEY';

$lang['y_o'] = 'y/o';
$lang['lastlogged'] = 'Derni�re connection: ';
$lang['aff_stats'] = 'Stats des affili�s';
$lang['total_referals'] = 'Total referals';
$lang['regis_referals'] = 'Referals enregistr�s';
$lang['globalconfigurations'] = 'Configurations globales';

$lang['send_message_to'] = 'Envoyer un message priv� �';
$lang['writting_message'] = 'Ecrire un message � ';
$lang['search_at'] = 'Chercher sur ';

//Rating module
$lang['rate_profile'] = 'Noter ce profil';
$lang['worst'] = 'Pas g�nial';
$lang['excellent'] = 'Excellent';
$lang['rating'] = 'Note';
$lang['submitrating'] = 'Enregistrer cette note';

//Payment Modules
$lang['mship_changed'] = 'Niveau de membre chang�';
$lang['mship_changed_successfull'] = 'Votre niveau de membre a �t� chang� avec succ�s.';
$lang['no_payment'] = 'Pas de m�thode de payement (Dans le cadre du niveau membre gratuit)';
$lang['payment_modules'] = 'Modules de paiement';
$lang['payment_methods'] = 'M�thodes de paiement';
$lang['business'] = 'Business:';
$lang['siteid'] = 'Site Id:';
$lang['undefined_quantity'] = 'Quantit� ind�finie:';
$lang['no_shipping'] = 'Pas d\'exp�dition:';
$lang['no_note'] = 'Pas de note:';
$lang['on_off_values'] = array( 1 => 'Oui', 0 => 'Non' );
$lang['edit_payment_modules'] = 'Editer le module de paiement';
$lang['trans_key'] = 'Cl� de transaction:';
$lang['trans_mode'] = 'Mode de transaction:';
$lang['trans_method'] = 'M�thode de transaction:';
$lang['username'] = 'Pseudo:';
$lang['username_without_colon'] = 'Pseudo';
$lang['country'] = 'Pays';
$lang['country_colon'] = 'Pays:';
$lang['state'] = 'Etat';
$lang['city'] = 'Ville';
$lang['location_col'] = 'Lieu:';
$lang['location_no_col'] = 'Lieu';
$lang['zip_code'] = 'Code Postal';
$lang['attached_files'] = 'Fichiers joints';
$lang['cc_owner'] = 'Propri�taire de la carte:';
$lang['cc_number'] = 'Num�ro de carte de cr�dit:';
$lang['cc_type'] = 'Type de carte de cr�dit:';
$lang['cc_exp_date'] = 'Date d\'expiration de la carte:';
$lang['cc_cvv_number'] = 'V�rification du num�ro de la carte:';
$lang['cvv_help'] = '(Situ� � l\'arri�re de la carte)';
$lang['continue'] = 'Continuer';
$lang['payment_msg1'] = 'M�thodes de paiement disponibles.';
$lang['trans_method_vals'] = array(
	'CC' => 'Carte de cr�dit',
	'ECHECK' => 'V�rification �lectronique'
	);
$lang['trans_mode_vals'] = array(
	'AUTH_CAPTURE' => 'AUTH_CAPTURE',
	'AUTH_ONLY' => 'AUTH_ONLY',
	'CAPTURE_ONLY' => 'CAPTURE_ONLY',
	'CREDIT' => 'CREDIT',
	'VOID' => 'VOID',
	'PRIOR_AUTH_CAPTURE' => 'PRIOR_AUTH_CAPTURE'
 );
$lang['cc_unknown'] = 'Carte de cr�dit inconnue. S\'il vous pla�t, r�essayez avec une carte valide.';
$lang['cc_invalid_date'] = 'Date d\'expiration de la carte invalide. S\'il vous pla�t, r�essayez avec une carte valide.';
$lang['cc_invalid_number'] = 'Num�ro de carte de cr�dit invalide. S\'il vous pla�t, r�essayez avec une carte valide.';
$lang['amount'] = 'Montant:';
$lang['confirmation'] = 'Confirmation';
$lang['confirm'] = 'Confirmer';
$lang['upgrade_membership'] = 'Type de compte';
$lang['changeto'] = 'Changer pour';
$lang['current_mship_level'] = 'Niveau membre actuel:';
$lang['membership_status'] = 'Statut membre:';
$lang['success_mship_change'] = 'Votre niveau de membre a �t� chang� pour:';
$lang['you_currently'] = 'Vous �tes actuellement ';
$lang['info_confirm'] = 'L\'information suivante est-elle correcte ?';
$lang['change_mship_to'] = 'Changer le niveau de membre pour:';
//Membership
$lang['permitmsg_1'] = 'D�sol�, votre niveau de membre n\'inclut pas';
$lang['permitmsg_2'] = 'S\'il vous pla�t, changer votre niveau de membre pour utiliser ';
$lang['permitmsg_3'] = 'Tableau de comparaison des niveaux de membre';
$lang['permitmsg_4'] = 'Cacher le tableau de comparaison des niveaux de membre';
$lang['privileges'] = array (
	'chat' 				=> 'Participer au tchat.',
	'forum'				=> 'Participer au forum.',
	'includeinsearch' 	=> 'Inclure dans les r�sultats de recherche.',
	'message'			=> 'Envoyer le message .',
	'uploadpicture'		=> 'Charger les images.',
	'seepictureprofile' => 'Voir les photos du profil.',
	'fullsignup' 		=> 'Inscription compl�te.'
);
$lang['membership_packages'] = 'Packages membres';
$lang['membership_packages_compare'] = 'Comparaison des packages membres';
$lang['modify'] = 'Enregistrer les changements';
$lang['manage_membership'] = 'Gestion d\'adh�sion ';
$lang['privileges_msg'] = 'Privil�ges';
$lang['support_currency'] = array( 'USD' => '$', 'EUR'=>'�' );
$lang['price'] = 'Prix: ';
$lang['currency'] = 'Monnaie: ';
$lang['choose_membership'] = 'Choisissez un niveau de membre:';
$lang['add_membership'] = 'Ajouter de nouveaux types de membres';
$lang['membership_types'] = 'Types de membres';
$lang['member'] = 'Membre';

$lang['select_letter'] = 'Choisir une lettre:';
$lang['body'] = 'Corps:';
$lang['module'] = 'Module';
$lang['uninstall'] = 'D�sinstaller';
$lang['install'] = 'Installer';
$lang['modify_option'] = 'Modifier l\'option';

$lang['only_jpg'] = 'Seulement les fichiers jpg, gif et png sont accept�s.';
$lang['upload_unsuccessful'] = 'La photo ne peut �tre sauvegard�e.';
$lang['upload_successful'] = 'La photo � �t� sauvegard�e.';
$lang['between'] = 'Entre';
$lang['and'] = 'et';
$lang['profile_details'] = 'D�tails du Profil';
$lang['personal_details'] = 'Details Personnels';


//Banner Management
$lang['manage_banners'] = 'Gestion de banni�res';
$lang['add_banners'] = 'Ajouter des banni�res';
$lang['edit_banners'] = 'Editer les Banni�res';
$lang['size'] = 'Taille';
$lang['size_px'] = 'Taille (px)';
$lang['banner_linkurl'] = 'Banni�re / Liens URL';
$lang['banner_sizes'] = array(
	'468X60' => '468 x 60',
	'100X500'=>'100 x 500',
	'120X120'=>'120 x 120'
);
$lang['banner_sizes_name'] = array( 'horizontal', 'vertical', 'square' );
$lang['startdate'] = 'Date de d�but:';
$lang['enddate'] = 'Date de fin:';
$lang['tooltip'] = 'Astuce:';
$lang['linkurl'] = 'Lien Url:';
$lang['banner'] = 'Banni�re:';
$lang['total_banner'] = 'Total Banni�res:';
$lang['online_users'] = 'Membres en ligne: ';
$lang['site_statistics'] = 'Statistiques du site';
$lang['pending_profiles'] = 'Profils en attente';
$lang['active_profiles'] = 'Profils actifs';
$lang['online_profiles'] = 'Profils en ligne';
$lang['pending_aff'] = 'Affili�s en attente';
$lang['total_affiliates'] = 'Total des affili�s';
$lang['active_aff'] = 'Affili�s actifs';
$lang['no_rating'] = 'Aucune note actuellement';

//SEO Words
$lang['seo'] = 'Param�tres SEO';
$lang['seo_head'] = 'Optimisation pour moteurs de recherches';
$lang['sef_msg'] = 'URLs pr�f�r�es des moteurs de recherches';
$lang['seo_enable'] = 'Activer l\' URL Rewriting en utilisant le mod_rewrite:';
$lang['yes_msg'] ='URL rewriting est une fonction utilisable seulement avec \nApache web server, avec l\'extension mod_rewrite activ�e.\nAssurez-vous que votre serveur supporte cette fonction.\nRappelez-vous �galement de renommer le fichier .htaccess.txt en .htaccess.';
$lang['keywords'] = 'Mots cl�s:';
$lang['page_tags_msg'] = 'Titre de page &  Balises Meta';
$lang['max_255'] = 'Maximum 255 charact�res';

//News / Story / Article Manangement
$lang['manage_news'] = 'Gestion de nouvelles';
$lang['manage_story'] = 'Gestion des histoires v�cues';
$lang['manage_article'] = 'Gestion des articles';
$lang['news_header'] = 'En-t�te';
$lang['total_news'] = 'Total de nouvelles:';
$lang['total_articles'] = 'Total d\'articles:';
$lang['total_stories'] = 'Total d\'histoires:';
$lang['article_title'] = 'Titre';
$lang['story_sender'] = 'Exp�diteur';
$lang['story_sender_msg'] = 'Id du profil [chiffre]';
$lang['modify_article'] = 'Modifier article';
$lang['modify_news'] = 'Modifier nouvelles';
$lang['modify_story'] = 'Modifier histoire';
$lang['insert_article'] = 'Ajouter un article';
$lang['insert_story'] = 'Ajouter une histoire';
$lang['insert_news'] = 'Ajouter une nouvelle';
$lang['dat'] = 'Date:';

//Poll Words
$lang['manage_polls'] = 'Gestion de sondages';
$lang['modify_poll'] = 'Modifier le sondage';
$lang['total_polls'] = 'Total sondages';
$lang['poll'] = 'Sondage';
$lang['add_polls'] = 'Ajouter des sondages';
$lang['add_options'] = 'Ajouter des options';
$lang['active'] = 'Active';
$lang['activate'] = 'Activer';
$lang['option'] = 'Option';
$lang['modify_options'] = 'Modifier des options';
$lang['add_option_now'] = 'Ajouter l\'option maintenant.';
$lang['poll_options'] = 'Options du sondage';
$lang['votes'] = 'Vote(s)';
//Filter Records
$lang['filter_options'] = array(
	'id' => 'Id',
	'username' => 'Utilisateur',
	'city' => 'Ville',
	'zip' => 'Code Postal',
	'status' => 'Statut'
	);
$lang['first'] = 'Premier';
$lang['last'] = 'Dernier';
$lang['filter_records'] = 'Filtrer les enregistrements';
$lang['search_at'] = 'Chercher �';
$lang['criteria'] = 'Crit�res';

//Admin Management
$lang['manage_admins'] = 'Gestion des admins';
$lang['total_admins'] = 'Total des Admins';
$lang['add_admin'] = 'Ajouter un Admin';
$lang['modify_admin'] = 'Modifier un admin';
$lang['fullname'] = 'Nom complet';
$lang['please_be_sure'] = 'Soyez certain de';
$lang['change_your_admin_pwd'] = 'Changer votre mot de passe admin.';
$lang['superuser'] = 'Super Utilisateur';
$lang['no_admin_user_msg1'] = 'Il n\'y a pas d\'admins non super utilisateurs. Cr�ez-en un d\'abord.';
$lang['no_admin_user_msg2'] = 'Pour cr�er un nouvel utilisateur admin maintenant';
$lang['access_denied'] = 'Acc�s Refus�';
$lang['not_authorize'] = 'Vous n\'�tes pas autoris� � acc�der � cette page. Contactez votre super admin.';
//Admin Permissions Management
$lang['admin_permissions'] = 'Permissions d\'admins';
$lang['manage_admin_permissions'] = 'Gestions des permissions';
$lang['admin_users'] = 'Utilisateurs Admin';
$lang['permissions'] = 'Modules';
$lang['superuser_noteditable'] = 'Note: Super Utilisateur n\'est pas �ditable.';
$lang['all'] = 'Tous';
$lang['selected'] = 'S�lectionn�';
$lang['selected_users'] = 'Utilisateurs s�lectionn�s';
$lang['separate_users_by_coma'] = 'Entrez les noms d\'utilisateurs s�par�s par des virgules';
$lang['admin_rights'] = array(
		'site_stats' 				=> 'Statistiques du site',
		'profie_approval'		 	=> 'Profils en attente d\'approbation',
		'profile_mgt' 				=> 'G�rer les profils',
		'section_mgt' 				=> 'G�rer les sections',
		'affiliate_mgt' 			=> 'G�rer les affili�s',
		'affiliate_stats'		 	=> 'Statistiques des affili�s',
		'news_mgt' 					=> 'G�rer les nouvelles',
		'article_mgt' 				=> 'G�rer les articles',
		'story_mgt'					=> 'G�rer les histoires',
		'poll_mgt'		 			=> 'G�rer les sondages',
		'search' 					=> 'Recherche',
		'ext_search'				=> 'Recherches �tendues',
		'send_letter' 				=> 'Envoyer une lettre',
		'pages_mgt' 				=> 'G�rer les pages',
		'chat' 						=> 'Salon de tchat',
		'chat_mgt' 					=> 'G�rer les tchats',
		'forum_mgt' 				=> 'G�rer les forums',
		'mship_mgt' 				=> 'G�rer les niveaux de membre',
		'payment_mgt' 				=> 'Modules de paiement',
		'banner_mgt' 				=> 'G�rer les banni�res',
		'seo_mgt' 					=> 'G�rer les optimisations pour moteurs de recherche',
		'admin_mgt' 				=> 'Gestion admin',
		'admin_permit_mgt'			=> 'Permissions des admins',
		'global_mgt' 				=> 'R�glages globaux du site',
		'change_pwd'				=> 'Changer le mot de passe',
		'cntry_mgt'					=> 'G�rer Pays/Etats/Villes',
		'snaps_require_approval'	=> 'Approuver les photos',
		'featured_profiles_mgt'		=> 'Profils inclus'
								);
/* Added by Vijay Nair   */
$lang['cntry_mgt']	= 'G�rer Pays / Etats / Villes';
$lang['register_now'] = 'Pas encore membre ? Inscrivez-vous maintenant.';
$lang['addtobuddylist'] = 'Ajouter � la liste des amis';
$lang['addtobanlist'] = 'Ajouter � la liste noire';
$lang['addtohotlist'] = 'Ajouter aux coups de coeur';
$lang['buddylisthdr'] = 'Liste de mes amis';
$lang['banlisthdr'] = 'Profils ind�sirables';
$lang['hotlisthdr'] = 'Coups de coeur';
$lang['username_hdr'] = 'Pseudo';
$lang['fullname_hdr'] = 'Nom complet';
$lang['register'] = 'Rejoignez-nous';
$lang['featured_profiles'] = 'Profils inclus';
$lang['bigger_pic_size'] = 'La taille de la photo est trop grande';
$lang['snaps_require_approval'] = 'Approuver les photos';
$lang['upload_picture_caption'] = 'Photo: ';
$lang['upload_thumbnail_caption'] = 'Miniature : ';
$lang['Approve'] = 'Approuver';
$lang['Remove'] = 'Retirer';
$lang['userdetails'] = 'Informations utilisateur';
$lang['pict'] = 'Photo';
$lang['tnail'] = 'Miniature';
$lang['reqact'] = 'Action souhait�e';
$lang['newmemberlist'] = 'Derniers membres inscrits';
$lang['yearsold'] = 'ans';
$lang['Male'] = 'Homme';
$lang['Female'] = 'Femme';
$lang['showfulllist'] = 'Afficher la liste compl�te';
$lang['featuredprofiles'] = 'Profils inclus';
$lang['featured_profiles_hdr'] = 'Profils des membres inclus';
$lang['nonfeatured_profiles_hdr'] = 'Membres normaux';
$lang['level_hdr'] = 'Niveau';
$lang['date_from'] = 'Date de d�but';
$lang['date_upto'] = 'Jusqu\'� la date';
$lang['must_show'] = 'Doit montrer';
$lang['reqd_exposures'] = 'Expositions requises';
$lang['total_exposures'] = 'Total des expositions';
$lang['add_featured'] = 'Ajouter le profil � la liste des inclus';
$lang['mod_featured'] = 'Modifier le Profil dans la liste des inclus';
$lang['member_since'] = 'Membre depuis';
$lang['invalid_username'] = 'Pseudo invalide';
$lang['weekcnt'] = 'Nouveaux membres:';
$lang['totalgents'] = 'Hommes inscrits:';
$lang['totalfemales'] = 'Femmes inscrites:';
$lang['weeksnaps'] = 'Nouvelles photos:';
$lang['since_last_login'] = 'Depuis votre derni�re connection';
$lang['sincelastlogin_hdr'] ='Depuis votre derni�re connection';
$lang['newmessages'] = 'Nouveaux messages re�us:';
$lang['profileviewed'] = 'Nombre d\'affichage de votre profil:';
$lang['winks_received'] = 'Nombre de clins d\'oeil re�us:';
$lang['send_wink'] = 'Envoyer un clin d\'oeil';
$lang['listofviews'] = 'Liste des membres ayant regard� votre profil';
$lang['listofwinks'] = 'Liste des membres vous ayant envoy� un clin d\'oeil';
$lang['winkslist'] = 'Liste des clins d\'oeil';
$lang['viewslist'] = 'Liste des affichages';
$lang['suggest_poll'] = 'Sugg�rer un sondage';
$lang['savepoll'] = 'Envoyer un sondage';
$lang['moreoptions'] = 'Plus d\'options';
$lang['minimum_options'] = 'Au minimum deux options';
$lang['pollsuggested'] = 'Merci d\'avoir propos� un nouveau sondage.';
$lang['suggested_by'] = 'Sugg�r� par:';
$lang['any_where'] = 'N\'importe o�';
$lang['memberpanel'] = "Page d'\accueil du membre";
$lang['feedback_thanks'] = 'Merci pour votre commentaire. Votre message a �t� exp�di� � l\'administrateur du site.';
$lang['cancel_hdr'] = 'Annuler votre abonnement';
$lang['cancel_txt01'] = 'Vous avez demand� l\'annulation de votre abonnement <b>'.stripslashes(SITENAME).'</b>.<br /><br />Etes-vous s�r?';
$lang['cancel_opt01'] = 'Oui, je suis s�r';
$lang['cancel_opt02'] = 'Non, c\'est une erreur';
$lang['cancel_domsg'] = 'Merci beaucoup d\'avoir utilis� '.stripslashes(SITENAME).'. <br /><br />� bient�t.';
$lang['cancel_nomsg'] = 'Merci beaucoup d\'avoir utilis� '.stripslashes(SITENAME).'. <br /><br />� bient�t.';
$lang['reject'] = 'Rejeter';
$lang['unread'] = 'Non lu';
$lang['membership_hdr'] = 'Niveau d\'adh�sion';
$lang['edit_pict'] = '�diter l\'Image principale';
$lang['edit_thmpnail'] = 'Editer la miniature';
$lang['letter_options'] = 'Options de la lettre';
$lang['pic_gallery'] = 'Galerie Photos';
$lang['reactivate'] = 'Reactiver un utilisateur';
$lang['cancel_list'] = 'Liste de membres annul�s ';
$lang['cancel_date'] = 'Date annul�e';
$lang['language_opt'] = 'Option de langue' ;
$lang['change_language'] = 'Changer la langue';
$lang['with_photo'] = 'Avec photos seulement';
$lang['logintime'] = 'Temps de connecion';

/******************************************/
/* ALL ERROR MESSAGES ARE DEFINED BELOW.  */
/******************************************/

// Affiliates error
$lang['affiliates_error'] = array(
	18=>'Le mot de passe ne correspond pas',
	20=>'Tous les champs doivent �tre renseign�s.',
	21=>'Tous les champs doivent �tre renseign�s.',
	25=>'Cette adresse �mail est d�j� utilis�e. Veuillez en utiliser une autre.'
);

//Signup Error Messages
//These are the signup error messages, Please do not change the sequence.
$lang['errormsgs']= array(
	00 => '',
	01 => 'Le Pseudo est un champ � saisie obligatoire.',
	02 => 'Le Mot de passe est un champ � saisie obligatoire.',
	03 => 'La Confirmation est un champ � saisie obligatoire.',
	04 => 'Le Nom est un champ � saisie obligatoire.',
	05 => 'L\'Adresse �mail est un champ � saisie obligatoire.',
	06 => 'Le Pseudo est un champ � saisie obligatoire.',
	07 => 'La ville est un champ � saisie obligatoire.',
	08 => 'Le Code Postal est un champ � saisie obligatoire.',
	09 => 'Le ligne Adresse 1 est un champ � saisie obligatoire.',
	10 => 'La longueur maximum du Pseudo est 25 caract�res.',
	11 => 'La longueur maximum du Nom est 25 caract�res.',
	12 => 'La longueur maximum du Pr�nom est 25 caract�res.',
	13 => 'La longueur maximum d\'Email est 25 caract�res.',
	14 => 'La longueur maximum de la Ville est 100 caract�res..',
	15 => 'La longueur maximum de la ligne Adresse 1 est 255 caract�res..',
	16 => 'Le Pseudo doit commencer par une lettre.',
	17 => 'Le Mot de passe doit commencer par une lettre.',
	18 => 'Le mot de passe et sa confirmation doivent �tre identiques.',
	19 => 'Veuillez entrer une adresse �mail valide',
	20 => 'L\'information exig�e doit �tre �crite.',
	21 => 'Les informations d\'ouverture que vous avez fournies ne permettent pas l\'acc�s au syst�me. Veuillez v�rifier vos donn�es et essayer de nouveau.',
	22 => 'Ce pseudo existe d�j�, veuillez en choisir un autre.',
	23 => 'L\'ancien mot de passe que vous avez fourni n\'est pas correct. Veuillez v�rifier l\'ancien mot de passe et essayer de nouveau.',
	25 => 'Email d�j� enregistr�.' ,
	26 => 'Votre statut n\'est pas actif. Veuillez attendre l\'approbation de votre profil, ou contactez un administrateur',
	27 => 'Impossible de trouver le message .',
	28 => 'Veuillez choisir un fichier d\'abord .',
	29 => 'Le format de fichier n\'est pas reconnu, Veuillez en choisir un autre',
	30 => 'La question est d�j� en haut.',
	31 => 'La question est d�j� en bas.',
	32 => 'Merci pour votre commentaire. Votre commentaire sera trait� bient�t .',
	33 => 'Le code postal ne correspond pas � l\'�tat indiqu�.',
	34 => 'Le Code Postal n\'est pas valide',
	35 => 'Votre profil n\'a pas encore �t� approuv�. Veuillez r�pondre � l\'email qui a �t� envoy� � l\'adresse utilis�e pour l\'enregistrement. ',
	36 => 'Votre compte a �t� suspendu. Veuillez contacter l\'administrateur pour plus de d�tails.',
	37 => 'Votre soumission a �t� refus�e. Veuillez contacter l\'administrateur pour plus de d�tails.',
	38 => 'Vous avez indiqu� une date de naissance incorrecte. Veuillez la v�rifier et essayer de nouveau.',
	39 => 'L\'ancien et le nouveau mot de passe ne doivent pas �tre identiques',
	40 => 'L\'�ge de d�but doit �tre inf�rieur � l\'�ge de fin',
	51 => 'La date de d�but doit �tre avant la date de fin',
	52 => 'Ce membre est d�j� sur la liste',
	53 => 'Date incorrecte',
	54 => 'Pseudo incorrect',
	55 => 'Vous devez vous connecter avant d\'envoyer le message ',
	56 => $lang['bigger_pic_size'],
	57 => $lang['only_jpg'],
	58 => $lang['upload_unsuccessful'],
	59 => 'Ce profil est ajout� � la liste',
	60 => 'La taille de la miniature est trop grande.',
	61 => 'Le code d\'activation est incorrect',
	62 => 'Ce pseudo � �t� retir� de la liste',
	63 => 'Cette personne a �t� ajout�e � la liste de vos amis',
	64 => 'Cette personne a �t� ajout�e � la liste noire',
	65 => 'Cette personne a �t� ajout�e � la liste des coups de coeur',
	66 => 'Votre clin d\'oeil � �t� envoy� � cette personne',
	67 => $lang['upload_successful'],
	68 => 'L\'approbation de l\'image est mise � jour ',
	69 => 'Le refus de l\'image est mis � jour',
	70 => 'L\'enregistrement des vues est effac�',
	71 => 'L\'enregistrement des clins d\'oeil est effac�',
	72 => 'Le compte d\'utilisateur est r�activ� ',
	);

// Javascript error messages
$lang['admin_js_error_msgs'] = array(
	'',
	'Choisissez d\'abord une case � cocher.',
	'Etes-vous certains de vouloir effacer ?',
	'Etes-vous certains de vouloir effacer cette banni�re ?'
	);
$lang['admin_js__delete_error_msgs'] = array('',
	1=> 'Etes-vous certains de vouloir effacer cette section ?\nCette action est irr�versible.',
	2=> 'Etes-vous certains de vouloir effacer la question de cette section ?\nCette action est irr�versible.',
	3=> 'Etes-vous certains de vouloir effacer l\'option de cette question ?\nCette action est irr�versible.',
	4=> 'Etes-vous certains de vouloir effacer ce profil ?\nCette action est irr�versible.',
	5=> 'Etes-vous certains de vouloir effacer ce nouvel item ?\nCette action est irr�versible.',
	6=> 'Etes-vous certains de vouloir effacer cette histoire ?\nCette action est irr�versible.',
	7=> 'Etes-vous certains de vouloir effacer cet article ?\nCette action est irr�versible.',
	8=> 'Etes-vous certains de vouloir effacer ce sondage ?\nCette action est irr�versible.',
	9=> 'Etes-vous certains de vouloir effacer cette option du sondage ?\nCette action est irr�versible.',
	10=> 'Etes-vous certains de vouloir effacer cette banni�re ?\nCette action est irr�versible.',
	11=> 'Etes-vous certains de vouloir effacer cet administrateur ?\nCette action est irr�versible.'
	);

// Don't use double qoutes(") in the item's text
$lang['signup_js_errors'] = array(
	'username_noblank' => 'Entrez le nom d\'utilisateur.' ,
	'password_noblank' => 'Entrez le mot de passe.',
	'old_password_noblank' => 'L\'ancien mot de passe doit �tre saisi.',
	'new_password_noblank' => 'Veuillez sp�cifier un nouveau mot de passe.',
	'con_password_noblank' => 'Vous devez confirmer votre mot de passe.',
	'firstname_noblank' => 'Entrez votre pr�nom.',
	'name_noblank' => 'Entrez votre nom.',
	'lastname_noblank' => 'Le nom doit �tre saisi.',
	'email_noblank' => 'Entrez votre adresse e-mail.',
	'city_noblank' => 'La ville doit �tre saisie.',
	'zip_noblank' => 'Le code postal doit �tre saisi.',
	'address1_noblank' => 'Une adresse au moins doit �tre saisie.',
	'sectionname_noblank' => 'Entrez un nom pour cette section.',
	'sendname_noblank' => 'Entrez le nom de l\'exp�diteur.',
	'comments_noblank' => 'Entrez les commentaires que vous voulez envoyer.',
	'question_noblank' => 'Entrez une question.',
	'extsearchhead_noblank' => 'Entrez l\'en-t�te de recherche �tendue.',

	'username_charset' => 'Seulement lettres, chiffres et espaces soulign�s \'_\' sont autoris�s pour le nom d\'utilisateur.',
	'password_charset' => 'Seulement lettres, chiffres et espaces soulign�s \'_\' sont autoris�s pour le mot de passe.',
	'firstname_charset' => 'Seules des lettres sont autoris�es pour le pr�nom.',
	'lastname_charset' => 'Seules des lettres sont autoris�es pour le nom.',
	'city_charset' => 'Le nom de la ville doit �tre alphab�tique.',
	'zip_charset' => 'Seuls des chiffres pour le code postal.',
	'address_charset' => 'Entrez une adresse valide.',
	'sectionname_charset' => 'Seules les lettres sont autoris� pour les noms de section.',
	'sendname_charset' => 'Seules des lettres sont autoris�es pour le nom d\'exp�diteur.',
	'name_charset' => 'Utilisez seulement des lettres pour le nom.',
	'maxlength_charset' => 'Entrez un entier pour la valeur maxi.',

	'email_notvalid' => 'Adresse e-mail invalide.',
	'password_nomatch' => 'Le mot de passe ne correspond pas.',
	'password_outrange' => 'La longueur du mot de passe doit �tre comprise entre les valeurs indiqu�es.',
	'username_outrange' => 'La longueur du nom d\'utilisateur doit �tre comprise entre les valeurs indiqu�es.',
	'username_start_alpha' => 'Le nom d\'utilisateur doit commencer par une lettre.',
	'ccowner_noblank' => 'Le propri�taire de la carte de cr�dit doit �tre sp�cifi�.',
	'ccnumber_noblank' => 'Le num�ro de carte de cr�dit doit �tre sp�cifi�.',
	'cvvnumber_noblank' => 'Le num�ro de v�rification de la carte de cr�dit doit �tre sp�cifi�.',
	'select_payment' => 'Choisissez d\'abord une m�thode de paiement.',
	);

$lang['letter_errormsgs'] = array(
		0 => 'Votre mot de passe vous a �t� exp�di�, v�rifi� votre boite de r�ception.',
		1 => 'Entrez l\'adresse e-mail que vous avez fourni lors de l\'enregistrement.',
		2 => 'Exemple de lettre d\'oubli de mot de passe non trouv�. Veuillez contacter l\'administrateur.',
		4 => 'Il y a un probl�me avec l\'envoi de mail. Veuillez contacter l\'administrateur.',
		5 => 'Vous n\'�tes pas un membre inscrit de ' . stripslashes(SITENAME) . '.<br/>Entrez l\'adresse e-mail que vous avez fourni lors de l\'enregistrement.'
	);

$lang['taf_errormsgs'] = array(
		0 => 'L\'invitation � �t� envoy�e avec succ�s.',
		'sendername_noblank' => 'Veuillez entrer votre nom.',
		'senderemail_noblank' => 'Veuillez entrer votre adresse e-mail.',
		'recipientemail_noblank' => 'Veuillez entrer votre adresse de r�ception.',
		'sendername_charset' => 'Veuillez n\'entrer que des lettres pour votre nom.',
		'senderemail_charset' => 'Veuillez entrer une adresse e-mail valide.',
		'recipientemail_charset' => 'Veuillez entrer une adresse de r�ception valide.',
		2 => 'Exemple de lettre inviter un ami non trouv�. Veuillez contacter l\'administrateur.',
		3 => 'Il y � un probl�me avec l\'envoi d\'invitation. Veuillez contacter l\'administrateur.',
	);
$lang['pages_errormsgs'] = array( '',
	1 => 'Titre de page manquant.',
	2 => 'Cl� de page manquante.',
	3 => 'Page de texte manquante.',
	4 => 'La cl� de page existe d�j�. Choisissez une autre cl�.',
	);

$lang['artile_error'] = array(
	1 => 'Le titre d\'article est un champ requis.',
	2 => 'Le texte d\'article est un champ requis.',
	3 => 'La date de l\'article est un champ requis.'
);
$lang['story_error'] = array(
	1 => 'L\'en-t�te de l\'histoire est un champ requis.',
	2 => 'Le texte de l\'histoire est un champ requis.',
	3 => 'La date de l\'histoire est un champ requis.',
	4 => 'L\'exp�diteur de l\histoire est un champ requis.'
);
$lang['news_error'] = array(
	1 => 'L\'en-t�te de la nouvelle est un champ requis.',
	2 => 'Le texte de la nouvelle est un champ requis.',
	3 => 'La date de la nouvelle est un champ requis.'
);

$lang['mship_errors'] = array (
	1=> 'Le nom est un champ requis.',
	2=> 'Le prix est un champ requis.',
	3=> 'La monnaie est un champ requis.',
	4 => 'Pas de m�thode de paiement est uniquement disponible pour le niveau d\'inscription gratuit.'
);
$lang['admin_error_msgs'] = array (
	'',
	'Section est un champ requis.',
	'Veuillez compl�ter tous les champs requis.'
	);
$lang['admin_error'] = array(
	'',
	1 => 'Le nom d\'utilisateur admin ne peut �tre vide.',
	2 => 'Le mot de passe admin ne peut �tre vide.',
	3 => 'Le nom complet de l\'admin ne peut �tre vide.',
	4 => 'Ancien mot de passe ne peut �tre vide.',
	5 => 'Nouveau mot de passe ne peut �tre vide.',
	6 => 'Confirmation du mot de passe ne peut �tre vide.',
	7 => 'Nouveau mot de passe et confirmation mot de passe doivent correspondre.',
	8 => 'L\'ancien mot de passe que vous avez saisi est incorrect. Veuillez r�essayer.',
	9 => 'Le nom d\'utilisateur choisi est d�j� utilis�. Veuillez en choisir un autre.'
);

$lang['banner_error_msgs'] = array( '',
	1 => 'La banni�re ne peut �tre vide.',
	2 => 'L\'adresse du lien ne peut-�tre vide.',
	3 => 'L\'astuce ne peut-�tre vide.',
	4 => 'Seules les banni�res en .jpg sont autoris�es.'
);
$lang['poll_error'] = array(
	1 => 'Sondage ne peut-�tre laiss� vide.',
	2 => 'Date de sondage ne peut-�tre vide.',
	3 => 'Option ne peut-�tre vide.',
	'txtpoll_noblank'  => 'Sondage est un champ requis.',
	'txtpollopt_noblank'  => 'Option sondage ne peut-�tre vide.'
	);

$lang['status_disp'] = array(
	'Pending' => 'En attente',
	'Active' => 'Actif',
	'Reject' => 'Rejet�',
	'Suspend' => 'Suspendu',
	);
$lang['datetime_month'] = array(
	1=>'Janvier',
	2=>'F�vrier',
	3=>'Mars',
	4=>'Avril',
	5=>'Mai',
	6=>'Juin',
	7=>'Juillet',
	8=>'Ao�t',
	9=>'Septembre',
	10=>'Octobre',
	11=>'Novembre',
	12=>'D�cembre'
);
$lang['datetime_day'] = array(
	'sunday' => 'Sunday',
	'monday' => 'Monday',
	'tuesday' => 'Tuesday',
	'wednesday' => 'Wednesday',
	'thursday' => 'Thursday',
	'friday' => 'Friday',
	'saturday' => 'Saturday'
);

$_SESSION['datetime_month'] = $lang['datetime_month'];
$_SESSION['datetime_day'] = $lang['datetime_day'];


?>