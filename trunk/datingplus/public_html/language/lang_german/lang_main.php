<?php
// The format of this file is ---> $lang['message'] = 'text';
//
// You should also try to set a locale and a character encoding (plus direction). The encoding and direction
// will be sent to the template. The locale may or may not work, it's dependent on OS support and the syntax
// varies ... give it your best guess!
// provided by maxxom


$lang['ENCODING'] = 'iso-8859-1';
$lang['DIRECTION'] = 'ltr';
$lang['LEFT'] = 'left';
$lang['RIGHT'] = 'right';
$lang['DATE_FORMAT'] =  '%b %d, %Y'; // This should be changed to the default date format for your language, php date() format
$lang['DATE_TIME_FORMAT'] =  '%b %d, %Y %H:%M:%S'; // This should be changed to the default date format for your language, php date() format
$lang['DISPLAY_DATE_FORMAT'] =  'MMM DD, YYYY';
$lang['DB_ERROR'] = "Die Anfrage konnte wegen eines Abfragefehlers nicht beantwortet werden.<br> Bitte später wieder versuchen.";


$lang['main_menu'] = 'Hauptmenü';
$lang['homepage'] = 'Homepage';
$lang['rate_photos'] = 'Foto bewerten';
$lang['forum'] = 'Forum';
$lang['manageforum'] = 'Forum Einstellungen';
$lang['chat'] = 'Chat';
$lang['managechat'] = 'Chat Einstellungen';
$lang['member_login'] = 'Login';
$lang['featured_members'] = 'Mitglieder des Monats';
$lang['quick_search'] = 'Schnellsuche';
$lang['my_searches'] = 'Meine Suche';
$lang['affiliates'] = 'Werbepartner';
$lang['already_affiliate'] = 'Sind Sie schon ein Werbepartner?';
$lang['referals'] = 'Verweisende Quellen';
$lang['title_colon'] = 'Titel:';
$lang['comments_colon'] = 'Kommentare:';
$lang['feedback'] = 'Feedback';


// Loginbox

$lang['unreadpanelleft'] = ' neue Nachrichten';

// guestbook
$lang['gb_to'] = 'zum Gästebuch';
$lang['gb_headline'] = 'Gästebuch';
$lang['gb_entries'] = 'Einträge gesamt:';
$lang['gb_entry_from'] = 'Von:';
$lang['gb_titel'] = 'Titel:';
$lang['gb_message'] = 'Eintrag:';
$lang['gb_send_entry'] = 'Gästebucheintrag';
$lang['send_gb'] = 'Ins Gästebuch eintragen';

$lang['profiles'] = 'Profile';
$lang['profile_s'] = '\'s Profil';
$lang['total_amt'] = 'Anzahl gesamt';
$lang['banner_link'] = 'Banner/Link';
$lang['clicks'] = 'Klicks';
$lang['finance_calc'] = 'Finanzrechner';
$lang['flash_chat_admin_msg'] = 'Flashchat noch nicht im System.';
$lang['affiliate_head_msg'] = 'Werden Sie ein Werbepartner.';
$lang['affiliate_head_msg2'] = 'Wir geben Vergünstigungen für Freundschaftswerbung.<br/>';
$lang['affiliate_success_msg1'] = 'Ihre Werbepartner ID ist:';
$lang['affiliate_success_msg2'] = 'In Ihr Werbepartner-Konto einloggen. ';
$lang['affiliate_login_title'] = "Werbepartner Login";
$lang['password_changed_successfully'] = 'Passwort erfolgreich geändert.';
$lang['affiliate_registration_success'] = 'Werbepartner Registrierung erfolgreich';
$lang['login_now'] = 'Hier einloggen';
$lang['must_be_valid'] = 'Muss gültig sein.';
$lang['characters'] = 'Zeichen';
$lang['email'] = 'Email:';
$lang['age'] = 'Alter';
$lang['years'] = 'Jahre';

$lang['all_states'] = 'Alle Staaten';
//
// These terms are used at Signup page
//
$lang['welcome'] = 'Willkommen';
$lang['admin_welcome'] = 'Willkommen <br /> im <br />' . $lang['site_name'] . '<br /> Admin Menü';
$lang['title'] = 'Willkommen bei ' . $lang['site_name'];
$lang['site_links'] = array(
	'home' => 'Home',
	'signup_now' => 'Registrieren',
	'chat' => 'Chat',
	'forum' => 'Forum',
	'login' => 'Login',
	'search' => 'Suchen',
	'aboutus' => 'Impressum',
	'forgot' => 'Passwort vergessen?',
	'contactus' => 'Kontakt',
	'privacy' => 'Privatsphäre',
	'terms_of_use' => 'AGB´s',
	'services' => 'Service',
	'faq' => 'FAQ\'s',
	'articles' => 'Artikel',
	'affliates' => 'Werbepartner',
	'invite_a_friend' => 'Seite empfehlen',
	'feedback' => 'Feedback'
	);

$lang['success_stories'] = 'Erfolgsgeschichten';
$lang['members_login'] = 'Login';
$lang['poll'] = 'Umfragen';
$lang['news'] = 'News';
$lang['articles'] = 'Artikel';
$lang['poll_result'] = 'Umfrage-Ergebnis';
$lang['view_poll_archive'] = 'vorherige Umfragen';
$lang['member_panel'] = 'Mitglieder-Menü';
$lang['poll_errmsg1'] = 'Du hast schon gewählt.';
$lang['close'] = 'Schliessen';
$lang['all_stories'] = 'Alle Geschichten';
$lang['all_news'] = 'Alle News';
$lang['more'] = 'mehr';
$lang['by'] = 'von';

$lang['dont_stay_alone'] = 'Du bist nicht alleine,';
$lang['join_now_for_free'] = 'hier kostenlos anmelden!';
$lang['special_offer'] = 'Unser spezielles Angebot!';
$lang['welcome_to'] = 'Willkommen bei ';
$lang['welcome_to_site'] = 'Willkommen bei '.stripslashes(SITENAME);

$lang['offer_text'] = 'Erkenne warum ' . stripslashes(SITENAME) . ' eine der am schnellsten wachsenden Singleportale ist. Lege jetzt Dein eigenes Profil an und finde Freunde, die Deine sexuellen Vorlieben mit Dir teilen, unkompliziert und ohne jegl. finanzielle Interessen.';

$lang['newest_profiles'] = 'Neueste Profile';

$lang['edit_profile'] = 'Profil bearbeiten';
$lang['total_profiles'] = 'Alle Profile';
$lang['forgot'] = 'Passwort vergessen?';
$lang['hide'] = 'verstecken';
$lang['show'] = 'zeigen';
$lang['sex'] = 'Geschlecht:';
$lang['sex_without_colon'] = 'Geschlecht';
$lang['pageno'] = 'Seite Nr.';
$lang['page'] = 'Seite';
$lang['previous'] = 'vorherige';
$lang['next'] = 'nächste';
$lang['time_col'] = 'Zeit:';

$lang['save_search'] = 'Suche speichern';
$lang['find_your_match'] = 'Finde einen Partner';

$lang['extended_search'] = 'Erweiterte Suche';
$lang['matches_found'] = 'Die angezeigten Profile entsprechen deiner Suche.';
$lang['timezone'] = 'Zeitzone:';
$lang['next_section'] = 'Nächste Sektion';
$lang['sign_in'] = 'Mitglieder Registrierung';
$lang['member_panel'] = 'Mitglieder-Menü';
$lang['aff_panel'] = 'Vermittler-Menü';
$lang['login_title'] = 'Mitglieder Login Bereich';
$lang['sign_out'] = 'Abmelden';
$lang['login_submit'] = 'Login';

$lang['change_password'] = 'Passwort ändern';
$lang['old_password'] = 'altes Passwort:';
$lang['new_password'] = 'neues Passwort:';
$lang['confirm_password'] = 'Passwort bestätigen:';
$lang['password_change_msg'] = 'Passwort erfolgreich geändert.';

$lang['section_signup_title'] = 'Anmelde Informationen';
$lang['signup'] = 'Registrieren';
$lang['section_basic_title'] = 'Generelle Informationen';
$lang['section_appearance_title'] = 'Figur';
$lang['section_interests_title'] = 'Hobbys';
$lang['section_lifestyle_title'] = 'Lebensstil';

$lang['signup_subtitle_login'] = 'Login Detail';
$lang['signup_subtitle_profile'] = 'Mein Profil';
$lang['signup_subtitle_address'] = 'Adresse';
$lang['signup_subtitle_appearance'] = 'Figur';
$lang['signup_subtitle_preference'] = 'Suchvorgaben';

$lang['signup_username'] = 'Benutzername:';
$lang['signup_password'] = 'Passwort:';
$lang['signup_confirm_password'] = 'Passwort bestätigen:';

$lang['signup_firstname'] = 'Vorname:';
$lang['signup_lastname'] = 'Nachname:';
$lang['signup_email'] = 'eMailadresse:';
$lang['section_mypicture'] = 'Meine Bilder';
$lang['upload'] = 'hochladen';
$lang['upload_pictures'] = 'Bilder hochladen';
$lang['upload_format_msgs'] = 'Nur .jpg, .gif, .bmp oder .png Dateien sind erlaubt.';
$lang['thumbnail'] = 'Vorschau';
$lang['picture'] = 'Bild';
$lang['signup_picture'] = 'Mein Bild';
$lang['signup_picture2'] = 'Mein Bild 2:';
$lang['signup_picture3'] = 'Mein Bild 3:';
$lang['signup_picture4'] = 'Mein Bild 4:';
$lang['signup_picture5'] = 'Mein Bild 5:';

$lang['signup_gender'] = 'Ich bin ein(e)';
$lang['signup_pref_age_range'] = 'bevorzugte Altersgruppe';
$lang['signup_year_old'] = 'Jahre alt';
$lang['signup_birthday'] = 'Geburtstag:';
$lang['signup_country'] = 'Land:';
$lang['signup_state_province'] = 'Bundesland:';
$lang['signup_zip'] = 'PLZ:';
$lang['signup_city'] = 'Stadt: ';
$lang['signup_address1'] = 'Adresse, Zeile 1:';
$lang['signup_address2'] = 'Adresse, Zeile 2:';
$lang['signup_height'] = 'Größe: ';
$lang['signup_feet'] = 'cm';
$lang['signup_meter_inches'] = 'Meter';
$lang['signup_weight'] = 'Gewicht:';
$lang['signup_pounds'] = 'kg';
$lang['signup_where_should_we_look'] = 'Wo sollen wir suchen?';
$lang['signup_view_online'] = "Online-Status anzeigen?:";

$lang['signup_gender_values'] = array(
	'M' => 'Mann',
	'F' => 'Frau',
	'C' => 'Paar'
	);

$lang['signup_gender_look'] = array(
	'M' => 'Mann',
	'F' => 'Frau',
	'C' => 'Paar',
	'B' => 'Mann oder Frau',
	'A' => 'Alles'
	);

$lang['seeking'] = 'suche eine(n)';
$lang['who_is_from'] = 'von';
$lang['looking_for_a'] = 'und suche nach eine(r/m)';
$lang['looking_for'] = 'sucht:';

$lang['of'] = ' von ';
$lang['to'] = ' bis ';
$lang['from'] = ' von ';
$lang['for'] = ' für ';
$lang['yes'] = 'Ja';
$lang['no'] = 'Nein';
$lang['cancel'] = 'Abrechen';

$lang['change'] = 'Ändern';
$lang['submit'] = 'Speichern';
$lang['reset'] = 'Löschen';

//Commonly used words

$lang['required_info_indication'] = 'Pflichtfeld';
$lang['required_info_indicator'] = '* ';
$lang['required_info_indicator_color'] = 'rot';
$lang['click_here'] = 'Hier klicken';

$lang['datetime_day']['Sunday'] = 'Sonntag';
$lang['datetime_day']['Monday'] = 'Montag';
$lang['datetime_day']['Tuesday'] = 'Dienstag';
$lang['datetime_day']['Wednesday'] = 'Mittwoch';
$lang['datetime_day']['Thursday'] = 'Donnerstag';
$lang['datetime_day']['Friday'] = 'Freitag';
$lang['datetime_day']['Saturday'] = 'Samstag';
$lang['datetime_dayval']['Sun'] = 'So';
$lang['datetime_dayval']['Mon'] = 'Mo';
$lang['datetime_dayval']['Tue'] = 'Di';
$lang['datetime_dayval']['Wed'] = 'Mi';
$lang['datetime_dayval']['Thu'] = 'Do';
$lang['datetime_dayval']['Fri'] = 'Fr';
$lang['datetime_dayval']['Sat'] = 'Sa';

$agecounter = array();

for($i=18; $i<100; $i++ ) {
	$agecounter[] = $i;
}
$lang['start_agerange'] = $agecounter;
$lang['end_agerange'] = $agecounter;

$lang['error_msg_color'] = 'Rot';
$lang['success_message'] = "Ihre Angaben wurden erfolgreich gespeichert.<br>Sie werden in 5 Sekunden automatisch weitergeleitet. Sollte die automatische Weiterleitung nicht erfolgen, klicken sie bitte hier.";
$lang['signup_success_message'] = 'Herzlichen Glückwunsch!<br>Sie sind nun ein registriertes Mitglied von ' . $lang['site_name'];
$lang['sendletter_success'] = 'Ihre Nachricht wurde erfolgreich gesendet.';

// These are displayed in the timezone select box
$lang['tz']['-25'] = '-- Select --';
$lang['tz']['-12.00'] = 'GMT - 12 Std';
$lang['tz']['-11.00'] = 'GMT - 11 Std';
$lang['tz']['-10.00'] = 'GMT - 10 Std';
$lang['tz']['-9.00'] = 'GMT - 9 Std';
$lang['tz']['-8.00'] = 'GMT - 8 Std';
$lang['tz']['-7.00'] = 'GMT - 7 Std';
$lang['tz']['-6.00'] = 'GMT - 6 Std';
$lang['tz']['-5.00'] = 'GMT - 5 Std';
$lang['tz']['-4.00'] = 'GMT - 4 Std';
$lang['tz']['-3.5'] = 'GMT - 3.5 Std';
$lang['tz']['-3.00'] = 'GMT - 3 Std';
$lang['tz']['-2.00'] = 'GMT - 2 Std';
$lang['tz']['-1.00'] = 'GMT - 1 Std';
$lang['tz']['0.00'] = 'GMT';
$lang['tz']['1.00'] = 'GMT + 1 Std';
$lang['tz']['2.00'] = 'GMT + 2 Std';
$lang['tz']['3.00'] = 'GMT + 3 Std';
$lang['tz']['3.5'] = 'GMT + 3.5 Std';
$lang['tz']['4'] = 'GMT + 4 Std';
$lang['tz']['4.5'] = 'GMT + 4.5 Std';
$lang['tz']['5.00'] = 'GMT + 5 Std';
$lang['tz']['5.5'] = 'GMT + 5.5 Std';
$lang['tz']['6.00'] = 'GMT + 6 Std';
$lang['tz']['6.5'] = 'GMT + 6.5 Std';
$lang['tz']['7.00'] = 'GMT + 7 Std';
$lang['tz']['8.00'] = 'GMT + 8 Std';
$lang['tz']['9'] = 'GMT + 9 Std';
$lang['tz']['9.5'] = 'GMT + 9.5 Std';
$lang['tz']['10.00'] = 'GMT + 10 Std';
$lang['tz']['11.00'] = 'GMT + 11 Std';
$lang['tz']['12.00'] = 'GMT + 12 Std';
$lang['tz']['13.00'] = 'GMT + 13 Std';


/*****************Admin Section Labels********************/

//Commonly used labels
$lang['admin_login_title'] = stripslashes(SITENAME) . ' Administrations Menu';
$lang['admin_login_msg'] = 'Admin Login';
$lang['admin_title_msg'] = stripslashes(SITENAME) . ' Admin Menu';
$lang['admin_panel'] = 'Admin-Menü';
$lang['back'] = 'Zurück';
$lang['insert_msg'] = 'Neu eingeben ';
$lang['question_mark'] = '?';
$lang['id'] = 'Id:';
$lang['name'] = 'Name:';
$lang['name_col'] = 'Name';
$lang['enabled'] = 'Angeschaltet:';
$lang['action'] = 'Aktion';
$lang['edit'] = 'Bearbeiten';
$lang['delete'] = 'Löschen';
$lang['section'] = 'Sektion:';
$lang['insert_section'] = 'Neue Sektion eingeben';
$lang['modify_section'] = 'Sektion ändern';
$lang['modify_sections'] = 'Sektionen ändern';
$lang['delete_section'] = 'Sektion löschen';
$lang['delete_sections'] = 'Sektionen löschen';
$lang['enable_selected'] = 'Anschalten';
$lang['disable_selected'] = 'Ausschalten';
$lang['change_selected'] = 'Ändern';
$lang['delete_selected'] = 'Löschen';
$lang['no_select_msg'] = "Sie haben keine Auswahl getroffen. Klicken sie bitte auf den Zurück-Button des Browsers und treffen eine Auswahl.";
$lang['delete_confirm_msg'] = 'Diese Sektion wirklich löschen??';
$lang['delete_group_confirm_msg'] = 'Diese Sektionen wirklich löschen? Das Löschen kann nicht rückgängig gemacht werden.';
$lang['enabled_values'] = array(
	'Y' => 'Ja',
	'N' => 'Nein'
	);
$lang['display_control_type'] = array(
	'checkbox' => 'Ankreuzfeld',
	'radio' => 'Auswahlknopf',
	'select' => 'PopUp-Liste',
	'textarea' => 'Eingabefeld'
	);
$lang['admin_error_color'] = 'Rot';

$lang['col_head_srno'] = '#';
$lang['col_head_id'] = 'Id';
$lang['col_head_question'] = 'Frage';
$lang['col_head_enabled'] = 'Aktiviert';
$lang['col_head_name'] = 'Name';
$lang['col_head_username'] = 'Benutzername';
$lang['col_head_firstname'] = 'Vorname';
$lang['col_head_lastname'] = 'Nachname';
$lang['col_head_fullname'] = 'Vollständiger Name';
$lang['col_head_status'] = 'Status';
$lang['col_head_gender'] = 'Geschlecht';
$lang['col_head_email'] = 'E-Mail';
$lang['col_head_country'] = 'Land';
$lang['col_head_city'] = 'Stadt';
$lang['col_head_zip'] = 'PLZ';
$lang['col_head_register_at'] = 'Registriert am';
$lang['col_head_geworben'] = 'Geworben durch'; 
$lang['geworben'] = 'Geworben durch'; 

$lang['section_title'] = 'Profilinhalte bestimmen';
$lang['total_sections'] = 'Gesamtabschnitte:';
$lang['profile_title'] = 'Profile verwalten';
$lang['total_profiles_found'] = 'Anzahl der gefundenen Profile:';
$lang['modify_profile'] = 'Profile ändern';

$lang['profile_signup_title'] = 'Profil anmelden';
$lang['profile_basic_title'] = 'Ich bin..';
$lang['profile_appearance_title'] = 'Figur';
$lang['profile_interests_title'] = 'Hobbys';
$lang['profile_lifestyle_title'] = 'Lifestyle';

$lang['profile_subtitle_login'] = 'Anmeldeinformationen';
$lang['profile_subtitle_profile'] = 'Profil';
$lang['profile_subtitle_address'] = 'Adresse';
$lang['profile_subtitle_appearance'] = 'Figur';
$lang['profile_subtitle_preference'] = 'Vorlieben';
$lang['profile_delete_confirm_msg'] = 'Wollen sie dieses Profil wirklich löschen?';
$lang['delete_profile'] = 'Profil löschen';
$lang['profile_username'] = 'Benutzername:';
$lang['profile_firstname'] = 'Vorname:';
$lang['profile_lastname'] = 'Nachname:';
$lang['profile_email'] = 'E-Mailadresse:';
$lang['profile_gender'] = 'Geschlecht:';
$lang['profile_birthday'] = 'Geburtstag:';
$lang['profile_country'] = 'Land:';
$lang['profile_state_province'] = 'Bundesland:';
$lang['profile_zip'] = 'PLZ:';
$lang['profile_city'] = 'Stadt';
$lang['profile_address1'] = 'Adresse, Zeile 1:';
$lang['profile_address2'] = 'Adresse, Zeile 2:';
$lang['find'] = 'Finde';
$lang['search'] = 'Suchen';
$lang['AND'] = 'UND';
$lang['OR'] = 'ODER';
$lang['order_by'] = 'Sortieren nach: ';
$lang['sort_by'] = 'Sortiert nach: ';
$lang['sort_types'] = array(
	'asc' => 'aufsteigend',
	'desc' => 'absteigend'
	);
$lang['search_results'] = 'Suchergebnis';
$lang['no_record_found'] = 'Kein Ergebnis gefunden.';
$lang['search_options'] = 'Sucheinstellungen';
$lang['search_simple'] = 'Einfache Suche';
$lang['search_advance'] = 'Erweiterte Suche';
$lang['search_advance_results'] = 'Erweitertes Suchergebnis';
$lang['search_country'] = 'Suche nach Land';
$lang['search_states'] = 'Suche nach Bundesländern';
$lang['search_zip'] = 'Suche nach PLZ';
$lang['search_city'] = 'Suche nach Stadt';
$lang['search_wildcard_msg'] = 'Geben sie einen * ein,um nach allen Einträgen zu suchen.';
$lang['search_location'] = '<b>Suche nach Ort:</b>';
$lang['select_country'] = 'Land:';
$lang['select_state'] = 'Bundesland:';
$lang['enter_city'] = 'Stadt:';
$lang['enter_zip'] = 'PLZ:';
$lang['enter_username'] = 'Benutzername:';
$lang['results_per_page'] = 'Ergebnisse pro Seite';
$lang['search_results_per_page'] = array( 5 => 5 , 10 => 10, 20 => 20, 50 => 50, 100 => 100 );
$lang['order'] = 'Reihenfolge';
$lang['up'] = 'nach oben';
$lang['down'] = 'nach unten';

$lang['question'] = 'Frage:';

$lang['maxlength'] = 'Maximale Länge:';
$lang['description'] = 'Beschreibung:';
$lang['mandatory'] = 'Pflichtfeld:';
$lang['guideline'] = 'Richtlinie:';
$lang['control_type'] = 'Anzeige-Kontrolle:';
$lang['include_extsearch'] = 'In erweiterte Suche aufnehmen:';
$lang['head_extsearch'] = 'Erweiterter Suchkopf:';

$lang['insert_question'] = 'Frage einfügen';
$lang['delete_question'] = 'Frage löschen';
$lang['modify_question'] = 'Frage ändern';
$lang['questions_title'] = 'Fragen Management';
$lang['total_options'] = 'Alle Optionen:';
$lang['insert_question'] = 'Neue Frage erstellen';
$lang['total_questions'] = 'Alle Fragen:';
$lang['delete_questions'] = 'Fragen löschen';
$lang['delete_group_questions_confirm_msg'] = 'Fragen wirklich löschen?';

// defined by ALI
$lang['option'] = 'Möglichkeiten';
$lang['answer'] = 'Antwort';
$lang['options_title'] = 'Fragen Optionen';
$lang['col_head_answer'] = 'Antwort';
$lang['with_selected'] = 'Auswahl bearbeiten';
$lang['ranging'] = 'Reihenfolge';

// Instant messenger
$lang['instant_messenger'] = 'Private-Nachricht an';
$lang['instant_message'] = 'Private Nachricht';
$lang['im_from'] = 'Von:';
$lang['im_message'] = 'Nachricht:';
$lang['im_reply'] = 'Antworten';
$lang['close_window'] = 'Fenster schließen';

// my matches
$lang['my_matches'] = 'Meine Treffer';
$lang['i_am_a'] = '';
$lang['Looking_for'] = 'sucht';
$lang['Between'] = 'zwischen';
$lang['who_is_from'] = 'aus';
$lang['showing'] = 'Anzeigen';
$lang['your_search_preferences'] = 'Ihre aktuellen Suchangaben:';
$lang['to_edit_search_preferences'] = 'um die Suchangaben zu ändern';

$lang['unapproved_user'] = 'Profile noch zu überprüfen';
$lang['gbl_settings'] = 'Grundeinstellungen';
$lang['configurations'] = 'Konfigurationen';
$lang['col_head_variable'] = 'Variable';
$lang['col_head_value'] = 'Wert';

$lang['affiliate_title'] = 'Werbepartner';
$lang['col_head_counter'] = 'Zähler';
$lang['col_head_status'] = 'Status';

$lang['tell_later'] = 'Das erzähle ich später';
$lang['view_profile'] = 'Profil zeigen';
$lang['view_profile_errmsg1']  = 'Du hast keine Einstellungen festgelegt.<br />Bitte Profildetails anlegen.<br />.';
$lang['view_profile_errmsg2'] = '<br>Klicke hier, um die Einstellungen festzulegen.';
$lang['view_profile_errmsg3'] = 'Der Benutzer hat noch kein Profil angelegt.';
$lang['view_profile_restricted'] = 'Dieses Profil darfst Du nicht ansehen.';
$lang['profile_notset'] = 'Kein Profil gefunden.';
$lang['send_mail'] = 'Sende Nachricht';
$lang['mail_messages'] = 'Nachrichten';
$lang['col_head_subject'] = 'Betreff';
$lang['col_head_sendtime'] = 'Datum';

$lang['inbox'] = 'Posteingang';
$lang['sent'] = 'Gesendet';
$lang['trashcan'] = 'Papierkorb';
$lang['reply'] = 'Antwort';
$lang['read'] = 'lesen';
$lang['unread'] = 'ungelesen';
$lang['restore'] = 'zurücksetzen';
$lang['subject'] = 'Betreff';
$lang['subject_colon'] = 'Betreff:';
$lang['message'] = 'Nachricht';
$lang['send'] = 'Senden';

$lang['send_letter'] = 'Mitglieder anschreiben';
$lang['image_browser'] = 'Bildbrowser';
$lang['upload_image'] = 'Bild hochladen';
$lang['delete_image'] = 'Bild löschen';
$lang['show_image'] = 'Bild anzeigen';
$lang['send_invite'] = 'Absenden';
$lang['letter_title'] = 'Neuer Brief';
$lang['from_email'] = 'von Email:';
$lang['from_name'] = 'von Name:';
$lang['send_to'] = 'Senden';
$lang['email_subject'] = 'Betreff:';
$lang['save_as'] = 'Speichern unter';

$lang['no_message'] = 'Keine Nachricht im Posteingang.';
$lang['descrip'] = 'Beschreibung';

//forgot password words
$lang['forgotpass_msg1'] = "Passwort vergessen";
$lang['forgotpass_msg2'] = "Bitte eMail Adresse der Registrierung erneut angeben.";
$lang['retreieve_info'] = 'Senden';
$lang['forgotpass'] = 'Passwort vergessen?';

//Tell a friend
$lang['tellafriend'] = 'Freund einladen';
$lang['taf_msg1'] = 'Lade einen Freund ein zu ' . stripslashes(SITENAME);
$lang['taf_yourname'] = 'Dein Name:';
$lang['taf_youremail'] = 'Deine E-Mail:';
$lang['taf_friendemail'] = "E-Mail des Freundes:";

//Auto-mail
$lang['confirm_your_profile'] = 'Bestätigen sie ihre Anmeldung';
$lang['letter_not_avail'] = 'Die Funktion "letter template" wurde nicht gefunden';
$lang['confirm_letter_sent'] = 'Um Ihre Anmeldung erfolgreich abzuschließen müssen Sie Ihre Anmeldung jetzt noch bestätigen.<br />';
$lang['letter_not_sent'] = 'Die E-Mail konnte nicht versendet werden. Nehmen sie bitte Kontakt mit uns auf.';
$lang['or'] = 'oder';
$lang['enter_confirm_code'] = 'Dies erreichen Sie indem sie auf den Bestätigungslink klicken <br>oder Ihren Bestätigungscode direkt im letzten Schritt der Anmeldung im Browser eingeben.';
$lang['wrong_activationcode'] = 'Der eingegebene Bestätigungscode ist nicht korrekt.<br/ > Geben sie bitte den korrekten Code ein, um die Anmeldung zu vollenden.';
$lang['confirm_success'] = 'Zum Login bitte zur Startseite wechseln.';

//Page management

$lang['manage_pages'] = 'Redaktion';
$lang['pagetitle'] = 'Titel:';
$lang['pagetext'] = 'Text:';
$lang['pagekey'] = 'Schlüssel:';
$lang['addpage'] = 'Seite hinzufügen';
$lang['page'] = 'Seite:';
$lang['addnew'] = 'Neu hinzu';
$lang['modpage'] = 'Seite bearbeiten';
$lang['pagekey_help'] = 'http://www.singlerunde.de/index.php';

$lang['y_o'] = 'y/o';
$lang['lastlogged'] = 'Letzter Login: ';
$lang['aff_stats'] = 'Werbepartner Statistik';
$lang['total_referals'] = 'Gesamt Referrals';
$lang['regis_referals'] = 'Registrierte Referrals';
$lang['globalconfigurations'] = 'Grundeinstellungen';

$lang['send_message_to'] = 'Sende Nachricht an';
$lang['writting_message'] = 'Schreibe Nachricht für ';
$lang['search_at'] = 'Suche bei ';

//Rating module
$lang['rate_profile'] = 'Bewerte Profil';
$lang['worst'] = 'Schlecht';
$lang['excellent'] = 'Exzellent';
$lang['rating'] = 'Bewertung';
$lang['submitrating'] = 'Bewertung abschicken';

//Payment Modules
$lang['mship_changed'] = 'Mitglieder-Level geändert';
$lang['mship_changed_successfull'] = 'Dein Mitglieder-Level wurde auf GRATIS gesetzt.';
$lang['no_payment'] = 'Keine Zahlungsmethode bei Gratis Mitgliedschaft';
$lang['payment_modules'] = 'Zahlungsmodule';
$lang['payment_methods'] = 'Zahlungsmethoden';
$lang['business'] = 'Firma:';
$lang['siteid'] = 'Seiten Id:';
$lang['undefined_quantity'] = 'Unbestimmte Anzahl:';
$lang['no_shipping'] = 'Kein Versand:';
$lang['no_note'] = 'Keine Angabe:';
$lang['on_off_values'] = array( 1 => 'Ja', 0 => 'Nein' );
$lang['edit_payment_modules'] = 'Bearbeite Zahlungsmodul';
$lang['trans_key'] = 'Transaktion Schlüssel:';
$lang['trans_mode'] = 'Transaktion Modus:';
$lang['trans_method'] = 'Transaktions Methode:';
$lang['username'] = 'Benutzername:';
$lang['username_without_colon'] = 'Benutzername';
$lang['country'] = 'Land';
$lang['country_colon'] = 'Land:';
$lang['state'] = 'Bundesland';
$lang['city'] = 'Stadt';
$lang['location_col'] = 'Wohnort:';
$lang['location_no_col'] = 'Wohnort';
$lang['zip_code'] = 'PLZ';
$lang['attached_files'] = 'Dateianhänge';
$lang['cc_owner'] = 'Kreditkarteninhaber:';
$lang['cc_number'] = 'Kreditkartennummer:';
$lang['cc_type'] = 'Kreditkarten Typ:';
$lang['cc_exp_date'] = 'Ablaufdatum:';
$lang['cc_cvv_number'] = 'Kontrollnummer:';
$lang['cvv_help'] = '(auf der Rückseite der Karte)';
$lang['continue'] = 'Weiter';
$lang['payment_msg1'] = 'Verfügbare Zahlungsmethoden.';
$lang['trans_method_vals'] = array(
	'CC' => 'Kreditkarte',
	'ECHECK' => 'Electronic Check'
	);
$lang['trans_mode_vals'] = array(
	'AUTH_CAPTURE' => 'AUTH_CAPTURE',
	'AUTH_ONLY' => 'AUTH_ONLY',
	'CAPTURE_ONLY' => 'CAPTURE_ONLY',
	'CREDIT' => 'CREDIT',
	'VOID' => 'VOID',
	'PRIOR_AUTH_CAPTURE' => 'PRIOR_AUTH_CAPTURE'
 );
$lang['cc_unknown'] = 'Kreditkartenfirma ist unbekannt. Versuchen sie es erneut mit einer gültigen Kreditkarte.';
$lang['cc_invalid_date'] = 'Kreditkarte ist abgelaufen.';
$lang['cc_invalid_number'] = 'Kreditkartennummer ist ungültig.';
$lang['datetime_month'] = array(
	01=>'Januar',
	02=>'Februar',
	03=>'März',
	04=>'April',
	05=>'Mai',
	06=>'Juni',
	07=>'Juli',
	08=>'August',
	09=>'September',
	10=>'Oktober',
	11=>'November',
	12=>'Dezember'
);
$lang['amount'] = 'Betrag:';
$lang['confirmation'] = 'Bestätigung';
$lang['confirm'] = 'bestätigen';
$lang['upgrade_membership'] = 'Mitglieder-Level erneuern';
$lang['changeto'] = 'Ändern in';
$lang['current_mship_level'] = 'Momentaner Mitglieder-Level:';
$lang['membership_status'] = 'Mitglieder Level';
$lang['success_mship_change'] = 'Dein Mitglieder-Level wurde erfolgreich geändert zu ';
$lang['you_currently'] = 'Im Moment bist Du ein ';
$lang['info_confirm'] = 'Ist die folgende Information richtig?';
$lang['change_mship_to'] = 'Ändere Mitglieder-Level zu ';
//Membership
$lang['permitmsg_1'] = 'Ihr Mitglieder-Level beinhaltet leider nicht ';
$lang['permitmsg_2'] = 'Erweitern Sie ihre Mitgliedschaft zum Nutzen von  ';
$lang['permitmsg_3'] = 'Übersicht über die Mitgliedschaften';
$lang['permitmsg_4'] = 'Übersicht über die Mitgliedschaften verstecken';
$lang['privileges'] = array (
	'chat' 				=> 'Teilnehmen am Chat.',
	'forum'				=> 'Teilnehmen im Forum.',
	'includeinsearch' 	=> 'Ihr Profil in Suchresultaten anzeigen.',
	'message'			=> 'Interne Nachrichten senden.',
	'uploadpicture'		=> 'Bilder hochladen.',
	'uploadpicturecnt' 	=> 'Max. Erlaubte Bilder Upload.', 
	'allowalbum' 		=> 'Privates Bilder Album.', 
	'guestbook' 		=> 'Gästebuch.', 
	'allowim' 			=> 'Instant Messenger erlaubt', 
	'seepictureprofile' => 'Profilbilder betrachten.',
	'favouritelist'		=> 'Ihre Freundes/ Block/ Hotliste verwalten',
	'sendwinks'			=> 'Winks versenden',
	'extsearch'			=> 'Erweiterte Suche ausführen',
	'fullsignup' 		=> 'Volle Mitgliedschaft.',
	'activedays'		=> 'Dauer deiner Mitgliedschaft'
);
$lang['membership_packages'] = 'Mitglieds-Level';
$lang['membership_packages_compare'] = 'Vergleich der Mitglieder-Level';
$lang['modify'] = 'Änderungen speichern';
$lang['manage_membership'] = 'Mitglieds-Level';
$lang['privileges_msg'] = 'Privilegien';
$lang['support_currency'] = array(
		'USD' 	=> '$',
		'EUR'	=>'€',
		'INR'	=>'Rs.',
		'AUD'	=> 'AU$',
		'CD'	=> 'CAN$',
		'UKP'	=> chr(163)
		);
$lang['price'] = 'Preis: ';
$lang['currency'] = 'Währung: ';
$lang['choose_membership'] = 'Wählen Sie ein Mitglieds-Level:';
$lang['add_membership'] = 'Ergänzen Sie ein Mitglieds-Level';
$lang['membership_types'] = 'Mitglieds-Level';
$lang['member'] = 'Mitglied';

$lang['select_letter'] = 'Brief auswählen:';
$lang['body'] = 'Körper:';
$lang['module'] = 'Modul';
$lang['uninstall'] = 'Deinstallieren';
$lang['install'] = 'Installieren';
$lang['modify_option'] = 'Modifiziere Option';

$lang['only_jpg'] = 'Nur JPG-Dateien sind zugelassen.';
$lang['upload_unsuccessful'] = 'Bild konnte nicht hochgeladen werden.';
$lang['upload_successful'] = 'Bild wurde gespeichert.';
$lang['between'] = 'Zwischen';
$lang['and'] = 'und';
$lang['profile_details'] = 'Profil Details';
$lang['personal_details'] = 'Persönliche Details';


//Banner Management
$lang['manage_banners'] = 'Banner Management';
$lang['add_banners'] = 'Banner hinzufügen';
$lang['edit_banners'] = 'Banner bearbeiten';
$lang['size'] = 'Größe';
$lang['size_px'] = 'Größe (px)';
$lang['banner_linkurl'] = 'Banner / Link URL';
$lang['banner_sizes'] = array(
	'468X60' => '468 x 60',
	'100X500'=>'100 x 500',
	'120X120'=>'120 x 120'
);
$lang['banner_sizes_name'] = array( 'horizontal', 'vertikal', 'querformat' );
$lang['startdate'] = 'Start Datum:';
$lang['enddate'] = 'End Datum:';
$lang['tooltip'] = 'Tooltip:';
$lang['linkurl'] = 'Link Url:';
$lang['banner'] = 'Banner:';
$lang['total_banner'] = 'Gesamt Banner:';
$lang['online_users'] = 'Mitglieder jetzt online: ';
$lang['site_statistics'] = 'Registrierungs-Statistik';
$lang['pending_profiles'] = 'Neu-Mitglieder (freischalten)';
$lang['active_profiles'] = 'Aktive Profile';
$lang['online_profiles'] = 'Online Profile';
$lang['pending_aff'] = 'Neu-Werbepartner (freischalten)';
$lang['total_affiliates'] = 'Anzahl Werbepartner';
$lang['active_aff'] = 'Aktive Vermittlungen';
$lang['no_rating'] = 'Nicht bewertet';

//SEO Words
$lang['seo'] = 'meta Einstellungen';
$lang['seo_head'] = 'Suchmaschinen Einstelungen';
$lang['sef_msg'] = 'Suchmaschinenfreundliche URLs';
$lang['seo_enable'] = 'Aktiviere URL Rewriting mittels mod_rewrite:';
$lang['yes_msg'] ='URL rewriting funktioniert nur mit einem Apache Internetserver, mit aktiviertem mod_rewrite.\nBitte vergewissern Sie sich dass Ihr Server diese Voraussetzungen erfüllt.\nBitte denken Sie auch daran die .htaccess.txt Datei in .htaccess zu ändern.';
$lang['keywords'] = 'Schlüsselworte:';
$lang['page_tags_msg'] = 'Seiten Titel & Meta Tags';
$lang['max_255'] = 'Maximum 255 Zeichen';

//News / Story / Article Manangement
$lang['manage_news'] = 'News Management';
$lang['manage_story'] = 'Geschichten Management';
$lang['manage_article'] = 'Artikel Management';
$lang['news_header'] = 'Überschrift';
$lang['total_news'] = 'Gesamt News:';
$lang['total_articles'] = 'Gesamt Artikel:';
$lang['total_stories'] = 'Gesamt Geschichten:';
$lang['article_title'] = 'Titel';
$lang['story_sender'] = 'Einsender';
$lang['story_sender_msg'] = 'Profil Id [Digit]';
$lang['modify_article'] = 'Bearbeite Artikel';
$lang['modify_news'] = 'Bearbeite News';
$lang['modify_story'] = 'Bearbeite Geschichte';
$lang['insert_article'] = 'Artikel hinzufügen';
$lang['insert_story'] = 'Geschichte hinzufügen';
$lang['insert_news'] = 'News hinzufügen';
$lang['dat'] = 'Datum:';

//Poll Words
$lang['manage_polls'] = 'Umfragen verwalten';
$lang['modify_poll'] = 'Umfrage ändern';
$lang['total_polls'] = 'Alle Umfragen';
$lang['poll'] = 'Umfrage';
$lang['add_polls'] = 'Umfrage hinzufügen';
$lang['add_options'] = 'Optionen hinzufügen';
$lang['active'] = 'Aktiv';
$lang['activate'] = 'Aktivieren';
$lang['option'] = 'Option';
$lang['modify_options'] = 'Optionen ändern';
$lang['add_option_now'] = 'Option hinzufügen.';
$lang['poll_options'] = 'Umfrage Optionen';
$lang['votes'] = 'Stimme(n)';
//Filter Records
$lang['filter_options'] = array(
	'id' => 'Id',
	'username' => 'Benutzername',
	'city' => 'Stadt',
	'zip' => 'PLZ',
	'status' => 'Status'
	);
$lang['first'] = 'Erste';
$lang['last'] = 'Letzte';
$lang['filter_records'] = 'Ergebnis filtern';
$lang['search_at'] = 'Suche unter';
$lang['criteria'] = 'Kriterien';

//Admin Management
$lang['manage_admins'] = 'Admin Verwaltung';
$lang['total_admins'] = 'Alle Admins';
$lang['add_admin'] = 'Admin hinzufügen';
$lang['modify_admin'] = 'Admin ändern';
$lang['fullname'] = 'Vor- und Nachname';
$lang['please_be_sure'] = 'Stellen sie sicher, dass';
$lang['change_your_admin_pwd'] = 'ändern sie ihr Admin-Passwort.';
$lang['superuser'] = 'Super Nutzer';
$lang['no_admin_user_msg1'] = 'Es gibt keinen Admin-Nutzer. Bitte erst einen Admin-Nutzer anlegen.';
$lang['no_admin_user_msg2'] = 'Admin-Nutzer nun anlegen';
$lang['access_denied'] = 'Zugriff verweigert';
$lang['not_authorize'] = 'Sie sind nicht berechtigt, diese Seite zu sehen. Kontakten sie bitte den Super-Admin.';
//Admin Permissions Management
$lang['admin_permissions'] = 'Admin Rechte';
$lang['manage_admin_permissions'] = 'Admin Rechte Management';
$lang['admin_users'] = 'Admin Benutzer';
$lang['permissions'] = 'Module';
$lang['superuser_noteditable'] = 'Achtung: SuperUser(s) sind nicht veränderbar.';
$lang['all'] = 'Alle';
$lang['selected'] = 'Ausgewählte in';
$lang['selected_users'] = 'Ausgewählte User';
$lang['separate_users_by_coma'] = 'Usernamen mit Komma getrennt eingeben.';
$lang['admin_rights'] = array(
			'site_stats' 		=> 'Mitglieder-Statistik',
			'profie_approval' 	=> 'Neue Mitglieder freischalten',
			'profile_mgt' 		=> 'Mitglieder bearbeiten',
			'section_mgt' 		=> 'Rubriken verwalten',
			'affiliate_mgt' 	=> 'Werbepartner verwalten',
			'affiliate_stats' 	=> 'Werbepartner Statistik',
			'news_mgt' 			=> 'News Verwaltung',
			'article_mgt' 		=> 'Artikel Verwaltung',
			'story_mgt'			=> 'Story Verwaltung',
			'poll_mgt'		 	=> 'Umfragen verwalten',
			'search' 			=> 'Suche',
			'ext_search'		=> 'Erweiterte Suche',
			'send_letter' 		=> 'Nachricht senden',
			'pages_mgt' 		=> 'Seiten verwalten',
			'chat' 				=> 'Chat',
			'chat_mgt' 			=> 'Chat Verwaltung',
			'forum_mgt' 		=> 'Forum Verwaltung',
			'mship_mgt' 		=> 'Mitglieds-Level bearbeiten',
			'payment_mgt' 		=> 'Zahlungsarten',
			'banner_mgt' 		=> 'Banner Verwaltung',
			'seo_mgt' 			=> 'SEO Einstellungen',
			'admin_mgt' 		=> 'Admin Verwaltung',
			'admin_permit_mgt'	=> 'Admin Nutzerrechte',
			'global_mgt' 		=> 'Generelle Einstellungen',
			'change_pwd'		=> 'Passwort ändern',
			'cntry_mgt'		=> 'Länder/Bundesländer/Städte bearbeiten',
			'snaps_require_approval'	=> 'Bilder überprüfen',
			'featured_profiles_mgt'		=> 'Profile der populären Mitglieder'
								);

$lang['cntry_mgt']	= 'Länder/Bundesländer/Städte bearbeiten';
$lang['register_now'] = 'Noch kein Mitglied? Registrieren Sie sich jetzt.';
$lang['addtobuddylist'] = 'Zur Freundesliste hinzufügen';
$lang['addtobanlist'] = 'Zur Bann- Liste hinzufügen';
$lang['addtohotlist'] = 'Zur Hot- Liste hinzufügen';
$lang['buddylisthdr'] = 'Freundesliste';
$lang['banlisthdr'] = 'Bann- Liste';
$lang['hotlisthdr'] = 'Hot- Liste';
$lang['username_hdr'] = 'Username';
$lang['fullname_hdr'] = 'Voller Name';
$lang['register'] = 'Jetzt registrieren';
$lang['featured_profiles'] = 'Populäre Profile';
$lang['bigger_pic_size'] = 'Ihr Bild übersteigt die max. Bildgrösse von '.$config['upload_snap_maxsize'].' KB.';
$lang['snaps_require_approval'] = 'Bilder überprüfen';
$lang['upload_picture_caption'] = 'Hauptbild: ';
$lang['upload_thumbnail_caption'] = 'Vorschau: ';
$lang['Approve'] = 'Bestätigen';
$lang['Remove'] = 'Löschen';
$lang['userdetails'] = 'User Information';
$lang['pict'] = 'Bild';
$lang['tnail'] = 'Vorschau';
$lang['reqact'] = 'Gewünschte Aktion';
$lang['newmemberlist'] = 'Neueste Mitglieder';
$lang['yearsold'] = 'Jahre alt';
$lang['Male'] = 'Männlich';
$lang['Female'] = 'Weiblich';
$lang['showfulllist'] = 'Zeige gesamte Liste';
$lang['featuredprofiles'] = 'Populäre Mitglieder';
$lang['featured_profiles_hdr'] = 'Profile der populären Mitglieder';
$lang['nonfeatured_profiles_hdr'] = 'Normale Mitglieder';
$lang['level_hdr'] = 'Level';
$lang['date_from'] = 'Anfangsdatum';
$lang['date_upto'] = 'Enddatum';
$lang['must_show'] = 'Muss angezeigt werden';
$lang['reqd_exposures'] = 'Benötigte Profilaufrufe';
$lang['total_exposures'] = 'Gesamte Profilaufrufe';
$lang['add_featured'] = 'Füge Profil zu populären Mitgliedern hinzu';
$lang['mod_featured'] = 'Ändere Profile der populären Mitglieder';
$lang['member_since'] = 'Mitglied seit';
$lang['invalid_username'] = 'ungültiger Benutzername';
$lang['weekcnt'] = 'Neue Profile letzte Woche:';
$lang['totalgents'] = 'Gesamt Männer:';
$lang['totalfemales'] = 'Gesamt Frauen:';
$lang['weeksnaps'] = 'Neue Bilder letzte Woche:';
$lang['since_last_login'] = 'seit letztem Login';
$lang['sincelastlogin_hdr'] ='Seit letztem Login';
$lang['newmessages'] = 'Neue Nachrichten:';
$lang['profileviewed'] = 'Anzahl Besucher Ihres Profils:';
$lang['winks_received'] = 'Anzahl Winks erhalten:';
$lang['send_wink'] = 'Sende einen Wink';
$lang['listofviews'] = 'Diese Mitglieder haben Ihr Profil angesehen';
$lang['listofwinks'] = 'Diese Mitglieder haben Ihnen einen Wink gesendet';
$lang['winkslist'] = 'Winks Liste';
$lang['viewslist'] = 'Betrachter Liste';
$lang['suggest_poll'] = 'Schlage eine Umfrage vor';
$lang['savepoll'] = 'Starte Umfrage';
$lang['moreoptions'] = 'Mehr Optionen';
$lang['minimum_options'] = 'Mindestens zwei Optionen benötigt';
$lang['pollsuggested'] = 'Vielen Dank! Ihr Umfragevorschlag wurde an den Administrator gesendet.';
$lang['suggested_by'] = 'Vorgeschlagen von:';
$lang['any_where'] = 'Überall';
$lang['memberpanel'] = "Homepage des Mitglieds";
$lang['feedback_thanks'] = 'Vielen Dank! Ihre Nachricht wurde an den Administrator gesendet.';
$lang['cancel_hdr'] = 'Mitgliedschaft kündigen';
$lang['cancel_txt01'] = 'Sie haben die Kündigung Ihrer Mitgliedschaft bei <b>'.stripslashes(SITENAME).'</b> beantragt.<br /><br />Sind Sie sicher dass Sie ihre Mitgliedschaft löschen möchten? ';
$lang['cancel_opt01'] = 'Ja, bitte kündigen';
$lang['cancel_opt02'] = 'Nein, bitte nicht kündigen';
$lang['cancel_domsg'] = 'Vielen Dank für Ihre Mitgliedschaft bei '.stripslashes(SITENAME).'. <br /><br /> Wir bedauern Ihre Entscheidung und hoffen dass ihnen Ihre Mitgliedschaft persönlichen Nutzen gebracht hat. <br /><br />Sie sind herzlich willkommen zu einem späteren Zeitpunkt wieder eine Mitgliedschaft einzugehen.';
$lang['cancel_nomsg'] = 'Vielen Dank dass Sie '.stripslashes(SITENAME).' doch weiterhin nutzen möchten.';
$lang['reject'] = 'Abweisen';
$lang['unread'] = 'Ungelesen';
$lang['membership_hdr'] = 'Mitgliedschaft Level';
/* RC6 */
$lang['edit_pict'] = 'Hauptbild ändern';
$lang['edit_thmpnail'] = 'Vorschaubild ändern';
$lang['letter_options'] = 'Nachrichten Optionen';
$lang['pic_gallery'] = 'Bildergalerie';
$lang['reactivate'] = 'Reaktiviere Mitglied';
$lang['cancel_list'] = 'Liste beendeter Mitgliedschaften';
$lang['cancel_date'] = 'Beendet am';
$lang['language_opt'] = 'Sprache' ;
$lang['change_language'] = 'Ändere Sprache';
$lang['with_photo'] = 'Nur mit Bild';
$lang['logintime'] = 'Login Zeit';
$lang['manage_country_states'] = 'Ändere Bundesland/Land';
$lang['manage_countries'] = 'Ändere Länder';
$lang['countries_count'] = 'Anzahl der Länder';
$lang['insert_country'] = 'Land hinzufügen';
$lang['modify_country'] = 'Ändere Land';
$lang['country_code'] = 'Ländercode';
$lang['country_name'] = 'Name Land';
$lang['manage_states'] = 'Bundesländer verwalten';
$lang['states_count'] = 'Anzahl Bundesländer';
$lang['insert_state'] = 'Bundesland hinzufügen';
$lang['modify_state'] = 'Ändere Bundesland';
$lang['state_code'] = 'Bundesland Abkürzung';
$lang['state_name'] = 'Bundesland Name';
$lang['totalcouples'] = 'Anzahl Paare gesamt:';
$lang['active_days'] = 'Gültig für wieviel Tage?';
$lang['activedays_array'] = array('1'=>'1','7'=>'7','30'=>'30','90'=>'90','180'=>'180','365'=>'365');
$lang['expired'] = 'Ihre bezahlte Mitgliedschaft ist abgelaufen. <br /><br /><a href="payment.php" class="errors">Bitte erneuern Sie ihre Mitgliedschaft</a> und geniessen Sie weiterhin die Vorteile bei '. stripslashes(SITENAME);
$lang['compose'] = 'Verfassen';
$lang['email_feedback_subject'] = 'Nachricht eines Mitglieds von '.SITENAME;

/******************************************/
/* ALL ERROR MESSAGES ARE DEFINED BELOW.  */
/******************************************/

// Affiliates error
$lang['affiliates_error'] = array(
	18 =>'Passwörter stimmen nicht überein',
	20 =>'Alle Felder sind notwendig.',
	21 =>'Alle Felder sind notwendig.',
	25 =>'Diese eMail-Adresse wird schon verwendet. Bitte eine andere wählen.'
);

//Signup Error Messages
//These are the signup error messages, Please do not change the sequence.
$lang['errormsgs']= array(
	00 => '',
	01 => 'Benutzername muss ausgefüllt werden.',
	02 => 'Passwort muss ausgefüllt werden.',
	03 => 'Passwortbestätigung muss ausgefüllt werden.',
	04 => 'Vorname muss ausgefüllt werden.',
	05 => 'Nachname muss ausgefüllt werden.',
	06 => 'E-Mailadresse muss ausgefüllt werden.',
	07 => 'Stadt muss ausgefüllt werden.',
	08 => 'PLZ muss ausgefüllt werden.',
	09 => 'Strasse, Haus-Nr. müssen ausgefüllt werden.',
	10 => 'Maximale Länge von Benutzername ist 25 Zeichen.',
	11 => 'Maximale Länge von Vorname ist 50 Zeichen.',
	12 => 'Maximale Länge von Nachname ist 50 Zeichen.',
	13 => 'Maximale Länge der E-Mail ist 255 Zeichen.',
	14 => 'Maximale Länge von Stadt ist 100 Zeichen.',
	15 => 'Maximale Länge von Strasse, Haus-Nr. ist 255 Zeichen.',
	16 => 'Benutzername muss mit einem Buchstaben anfangen.',
	17 => 'Passwort muss mit einem Buchstaben anfangen',
	18 => 'Passwort und Passwortbestätigung müssen übereinstimmen.',
	19 => 'Bitte eine gültige E-Mailadresse eingeben.',
	20 => 'Sie haben nicht alle Pflichtfelder ausgefüllt.',
	21 => 'Der Zutritt wurde verweigert. Nutzername und/oder Passwort sind nicht korrekt. Logindaten bitte überprüfen und neu eingeben.',
	22 => 'Der Nutzername ist schon vergeben. geben sie bitte einen anderen Namen ein.',
	23 => 'Das alte Passwort ist falsch. Bitte überprüfen und neu eingeben.',
	25 => 'Die E-Mail wurde schon registriert.' ,
	27 => 'Kann keine Nachricht finden.',
	28 => 'Bitte erst eine Datei auswählen.',
	29 => 'Datei Format wird nicht unterstützt. Bitte anderes wählen.',
	30 => 'Diese Frage steht schon oben.',
	31 => 'Diese Frage steht schon unten.',
	32 => 'Danke für den Kommentar. Ihre Anfrage wird umgehend bearbeitet.',
	33 => 'Die PLZ passt nicht zum Staat.',
	34 => 'PLZ nicht gültig.',
	36 => 'Ihr Zugang wurde vorübergehend gesperrt. Nehmen sie bitte Kontakt mit uns auf.',
	37 => 'Ihre Registrierung wurde abgelehnt. Nehmen sie bitte Kontakt mit uns auf.',
	38 => 'Das Geburtsdatum wurde falsch eingegeben. Bitte neu eingeben.',
	39 => 'Altes und neues Passwort muss übereinstimmen',
	40 => 'Anfangsdatum muss größer oder gleich dem Enddatum sein.',
	51 => 'Anfangsdatum muss zeitlich vor dem Enddatum liegen.',
	52 => 'Diese Mitglied steht schon auf der Liste.',
	53 => 'Ungültiges Datum',
	54 => 'Ungültiger Nutzernamen',
	55 => 'Zuerst Einloggen, um eine Nachricht zu schicken!',
	56 => $lang['bigger_pic_size'],
	57 => $lang['only_jpg'],
	58 => $lang['upload_unsuccessful'],
	59 => 'Diese Profil wurde der Liste angefügt.',
	60 => 'Das Mini-Bild ist zu groß.',
	61 => 'Der Aktivierungs-Code ist ungültig.',
	62 => 'Das Mitglied wurde von der Liste gelöscht',
	63 => 'Dieses Mitglied wurde zu Ihrer Freundesliste hinzugefügt.',
	64 => 'Dieses Mitglied wurde zu Ihrer Sperr-Liste hinzugefügt.',
	65 => 'Dieses Mitglied wurde zu Ihren Favoriten hinzugefügt.',
	66 => 'Ihr Wink wurde an folgendes Mitglied gesendet',
	67 => $lang['upload_successful'],
	68 => 'Die Überprüfung des Bildes ist erfolgt',
	69 => 'Das Bild wurde abgewiesen',
	70 => 'Die gespeicherten Zugriffszahlen wurden auf Null gesetzt',
	71 => 'Die gespeicherten Winks wurden entfernt',
	/* Added in RC6  */
	72 => 'Der Mitglieds-Login wurde wieder freigschaltet.',
	73 => 'Das Land wurde hinzugefügt',
	74 => 'Das Land wurde gelöscht',
	75 => 'Ländercode oder Ländername bereits in Benutzung',
	76 => 'Das Land wurde geändert',
	77 => 'Das Bundesland wurde hinzugefügt',
	78 => 'Das Bundesland wurde gelöscht',
	79 => 'Bundesland Code oder Name bereits in Benutzung',
	80 => 'Das Bundesland wurde geändert',
	81 => 'Name Bundesland/Kreis muss verfügbar sein',
	82 => 'Dieses Mitglied hat noch keine Bilder hochgeladen. ',
	83 => 'Das Profil ist gelöscht',
	84 => 'Die gewählten Profile wurden gelöscht.',

/* Modified in RC6  */
	26 => 'Ihr Profil ist noch nicht freigeschaltet. Bitte später versuchen oder den Admin kontaktieren.',
	35 => 'Sie sind noch nicht als Mitglied freigeschaltet. Antworten sie bitte auf die E-Mail, die ihnen nach ihrer Anmeldung an ihre E-Mailadresse geschickt wurde.',
	);

// Javascript error messages
$lang['admin_js_error_msgs'] = array(
	'',
	'Erst eine Checkbox auswählen.',
	'Wollen sie wirklich löschen?',
	'Wollen sie diesen Banner wirklich löschen?'
	);
$lang['admin_js__delete_error_msgs'] = array('',
				1=> 'Wollen sie diese Rubrik wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				2=> 'Wollen sie diese Frage in der Rubrik wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				3=> 'Wollen sie diese Auswahl in der Frage wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				4=> 'Wollen sie dieses Profil wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				5=> 'Wollen sie diese News wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				6=> 'Wollen sie diesen Story wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				7=> 'Wollen sie diesen Artikel wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				8=> 'Wollen sie diese Umfrage wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				9=> 'Wollen sie diese Auswahl in der Umfrage wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				10=> 'Wollen sie diesen Banner wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
				11=> 'Wollen sie diesen Admin wirklich löschen?\nDiese Aktion kann nicht mehr rückgängig gemacht werden.',
/* Added in RC6 */
	12=>'Sind Sie sicher dass Sie dieses Land löschen wollen?',
	13=>'Sind Sie sicher dass Sie dieses Bundesland/Kreis löschen wollen?',
	14=>'Sind Sie sicher dass Sie diese Länder löschen wollen?',
	15=>'Sind Sie sicher dass Sie diese Bundesländer/Kreise löschen wollen?',
	16=>'Erweiterte Suche Header muss existieren wenn in Erweiterter Suche eingeschlossen.',
	17 => 'Usernamen müssen eingegeben werden wenn Username Liste ausgewählt wurde.',
	18 => 'Sins Sie sicher dass diese Profile gelöscht werden sollen?\nDiese Aktion kann nicht rückgängig gemacht werden.',
	);

// Don't use double qoutes(") in the item's text
$lang['signup_js_errors'] = array(
	'username_noblank' => 'Bitte Benutzernamen eingeben.' ,
	'password_noblank' => 'Bitte Passwort eingeben.',
	'old_password_noblank' => 'Altes Passwort muss angegeben werden.',
	'new_password_noblank' => 'Neues Passwort muss angegeben werden.',
	'con_password_noblank' => 'Passwort muss bestätigt werden.',
	'firstname_noblank' => 'Vorname muss angegeben werden.',
	'name_noblank' => 'Bitte Namen eingeben.',
	'lastname_noblank' => 'Nachname muss angegeben werden.',
	'email_noblank' => 'E-Mail muss angegeben werden.',
	'city_noblank' => 'Stadt muss angegeben werden.',
	'zip_noblank' => 'PLZ muss angegeben werden.',
	'address1_noblank' => 'Bitte mindestens Strasse und Hausnr. eingeben.',
	'sectionname_noblank' => 'Namen für diese Sektion angeben.',
	'sendname_noblank' => 'Absendername muss angegeben werden.',
	'comments_noblank' => 'Bitte den Kommentar eingeben, der abgeschickt werden soll.',
	'question_noblank' => 'Frage muss angegeben werden.',
	'extsearchhead_noblank' => 'Erweiterter Suchkopf muss angegeben werden.',
	'username_charset' => 'Nur Buchstaben a-z oder A-Z, Zahlen 0-9 und Unterstrich \'_\' sind gültig.',
	'password_charset' => 'Nur Buchstaben a-z oder A-Z, Zahlen 0-9 und Unterstrich \'_\' sind gültig.',
	'firstname_charset' => 'Nur Buchstaben für Vorname.',
	'lastname_charset' => 'Nur Buchstaben für Nachname.',
	'city_charset' => 'Nur Buchstaben für Stadtname.',
	'zip_charset' => 'Nur Zahlen für den PLZ Code.',
	'address_charset' => 'Bitte gültige Adresse eingeben.',
	'sectionname_charset' => 'Nur Buchstaben für Name.',
	'sendname_charset' => 'Nur Buchstaben für Absender.',
	'name_charset' => 'Nur Buchstaben für Name.',
	'maxlength_charset' => 'Nur ganze Zahlen sind für Feldlängen erlaubt.',
	'email_notvalid' => 'E-Mailadresse ist nicht gültig.',
	'password_nomatch' => 'Passwörter stimmen nicht überein.',
	'password_outrange' => 'Passwort hat die falsche Länge.',
	'username_outrange' => 'Benutzername hat die falsche Länge.',
	'username_start_alpha' => 'Benutzername muss mit einem Buchstaben anfangen.',
	'ccowner_noblank' => 'Bitte Inhaber der Kreditkarte eingeben.',
	'ccnumber_noblank' => 'Bitte Nummer der Kreditkarte eingeben.',
	'cvvnumber_noblank' => 'Bitte Kontrollnummer der Kreditkarte eingeben.',
	'select_payment' => 'Bitte zuerst eine Zahlungsart auswählen.',
    'stateprovince_noblank' => 'Name Bundesland/Kreis verfügbar sein.',
    'county_noblank' => 'Bezirk muss angegeben werden',
	/* Added in RC6 */
	'subject_noblank'	=> 'Betreff der Nachricht muss angegeben sein',
	);

$lang['letter_errormsgs'] = array(
				0 => 'Das Passwort ist per E-Mail an sie abgeschickt worden. Überprüfen sie bitte ihren Maileingang.',
				1 => 'Geben sie unten bitte nur die E-Mailadresse ein, die sie bei der Registrierung angegeben haben.',
				2 => 'Passwort vergessen Funktion wurde nicht gefunden. Nehmen sie bitte Kontakt mit uns auf.',
				4 => 'Die E-Mail konnte nicht versendet werden. Nehmen sie bitte Kontakt mit uns auf.',
				5 => 'Sie sind kein registriertes Mitglied von ' . $lang['site_name'] . '.<br/>Geben sie unten bitte nur die E-Mailadresse ein, die sie bei der Registrierung angegeben haben.'
	);

$lang['taf_errormsgs'] = array(
				0 => 'Einladung wurde versendet.',
				'sendername_noblank' => 'Bitte Namen eingeben.',
				'senderemail_noblank' => 'Bitte deine E-Mail eingeben.',
				'recipientemail_noblank' => 'Bitte E-Mailadresse des Empfängers eingeben.',
				'sendername_charset' => 'Nur Buchstaben für Name.',
				'senderemail_charset' => 'Gültige eMail Adresse eingeben.',
				'recipientemail_charset' => 'Gültige Empfänger-eMail Adresse eingeben.',
				2 => 'Die Funktion "Freunden empfehlen" wurde nicht gefunden. Nehmen sie bitte Kontakt mit uns auf.',
				3 => 'Die Einladung konnte wegen eines Fehlers nicht gesendet werden. Nehmen sie bitte Kontakt mit uns auf.',
	);
$lang['pages_errormsgs'] = array( '',
					1 => 'Seiten Titel fehlt.',
					2 => 'Seitenschlüssel fehlt.',
					3 => 'Seitentext fehlt.',
					4 => 'Seiten- Schlüssel schon vorhanden. Bitte wählen Sie einen anderen Schlüssel.',
		);

$lang['artile_error'] = array(
	1 => 'Arikel Überschrift ist ein Pflichtfeld.',
	2 => 'Arikel Text ist ein Pflichtfeld.',
	3 => 'Arikel Datum ist ein Pflichtfeld.'
);
$lang['story_error'] = array(
	1 => 'Story Überschrift ist ein Pflichtfeld.',
	2 => 'Story Text ist ein Pflichtfeld.',
	3 => 'Story Datum ist ein Pflichtfeld.',
	4 => 'Story Absender ist ein Pflichtfeld.'
);
$lang['news_error'] = array(
	1 => 'News Überschrift ist ein Pflichtfeld.',
	2 => 'News Text ist ein Pflichtfeld.',
	3 => 'News Datum ist ein Pflichtfeld.'
);

$lang['mship_errors'] = array (
	1=> 'Name ist ein notwendiges Feld.',
	2=> 'Preis ist ein notwendiges Feld.',
	3=> 'Währung ist ein notwendiges Feld.',
	4 => 'Ohne Zahlungsmethode geht nur bei Mitglieds-Level GRATIS.'
);
$lang['admin_error_msgs'] = array (
	'',
	'Rubrik ist ein Pflichtfeld.',
	'Bitte alle Pflichtfelder ausfüllen.'
	);
$lang['admin_error'] = array(
	'',
	1 => 'Admin-Nutzername ist ein Pflichtfeld.',
	2 => 'Admin-Passwort ist ein Pflichtfeld.',
	3 => 'Admin Vor-und Nachname ist ein Pflichtfeld.',
	4 => 'Altes Passwort ist ein Pflichtfeld.',
	5 => 'Neues Passwort ist ein Pflichtfeld.',
	6 => 'Passwortbestätigung ist ein Pflichtfeld.',
	7 => 'Neues Passwort und Passwortbestätigung müssen übereinstimmen.',
	8 => 'Das alte Passwort stimmt nicht. Bitte neu eingeben.',
	9 => 'Der gewählte Nutzername wurde schon vergeben. Bitte einen anderen Namen wählen.'
);

$lang['banner_error_msgs'] = array( '',
	1 => 'Banner muss angegeben sein.',
	2 => 'Link URL muss angegeben sein.',
	3 => 'Tooltip muss ausgefüllt sein.',
	4 => 'Nur .jpg Banner sind erlaubt.'
);
$lang['poll_error'] = array(
	1 => 'Umfrage muss ausgefüllt sein.',
	2 => 'Datum muss ausgefüllt sein.',
	3 => 'Option muss ausgefüllt sein.',
  'txtpoll_noblank'  => 'Umfrage ist ein Pflichtfeld.',
	'txtpollopt_noblank'  => 'Umfrage-Option ist ein Pflichtfeld.'
	);

$lang['status_disp'] = array(
	'Pending' => 'in Bearbeitung',
	'Active' => 'Aktiv',
	'Reject' => 'Abgelehnt',
	'Suspend' => 'Gesperrt',
	);


?>