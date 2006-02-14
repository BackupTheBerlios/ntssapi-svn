<?php
// The format of this file is ---> $lang['message'] = 'text';
//
// You should also try to set a locale and a character encoding (plus direction). The encoding and direction
// will be sent to the template. The locale may or may not work, it's dependent on OS support and the syntax
// varies ... give it your best guess!
//

/** Translation provided by Minas Abrahamyan. */

$lang['ENCODING'] = 'windows-1251';
$lang['DIRECTION'] = 'ltr';
$lang['LEFT'] = 'left';
$lang['RIGHT'] = 'right';
$lang['DATE_FORMAT'] =  DATE_FORMAT; // This should be changed to the default date format for your language, php date() format
$lang['DATE_TIME_FORMAT'] =  DATE_TIME_FORMAT; // This should be changed to the default date format for your language, php date() format
$lang['DISPLAY_DATE_FORMAT'] =  DISPLAY_DATE_FORMAT;
$lang['DB_ERROR'] = "Простите, ваш запрос не может быть обработан из-за ошибки в базе данных.<br>Пожалуйста попробуйте снова.";


$lang['main_menu'] = 'Главное меню';
$lang['homepage'] = 'Начало';
$lang['rate_photos'] = 'Оценить фотографии';
$lang['forum'] = 'Форум';
$lang['manageforum'] = 'Управление форумом';
$lang['chat'] = 'Чат';
$lang['managechat'] = 'Управление чатом';
$lang['member_login'] = 'Войти';
$lang['featured_members'] = 'Пользователи с рекламой';
$lang['quick_search'] = 'Быстрый поиск';
$lang['my_searches'] = 'Мое найденное';
$lang['affiliates'] = 'Афилиэйт';
$lang['already_affiliate'] = 'Уже афилиэйт?';
$lang['referals'] = 'Ссылки';
$lang['title_colon'] = 'Заглавие:';
$lang['comments_colon'] = 'Комментарии:';
$lang['feedback'] = 'Обратная связь';

$lang['profiles'] = 'Анкеты';
$lang['profile_s'] = ', анкета';
$lang['total_amt'] = 'Общее количество';
$lang['banner_link'] = 'Баннер/ссылка';
$lang['clicks'] = 'Клики';
$lang['finance_calc'] = 'Финансовый калькулятор';
$lang['flash_chat_msg'] = 'FlashChat версии 4.1.0 и выше включают модуль(класс) интеграции с osDate-ом.
	Пожалуйста купите FlashChat отсюда <a href="http://www.tufat.com/chat.php" target="_blank">http://www.tufat.com/chat.php</a> и скопируйте файлы в эту папку.
	Далее, запустите инсталлятор FlashChat-а, и укажите osDate как CMS для интеграции.';
$lang['flash_chat_admin_msg'] = 'FlashChat 4.1.0 и выше включают модуль(класс) интеграции с osDate-ом.
	Пожалуйста купите FlashChat отсюда <a href="http://www.tufat.com/chat.php" target="_blank">http://www.tufat.com/chat.php</a> и скопируйте файлы в эту папку.
	Далее, запустите инсталлятор FlashChat-а, и укажите osDate как CMS для интеграции.';
$lang['affiliate_head_msg'] = 'Станьте афилиэйтом';
$lang['affiliate_head_msg2'] = 'Мы предлагаем комиссии для веб-мастеров, которые будут приводить посетителей на наш сайт.<br/>';
$lang['affiliate_success_msg1'] = 'ID вашего афилиэйтного счета:';
$lang['affiliate_success_msg2'] = 'Теперь Вы можете зайти в Ваш афилиэйтный акаунт.';
$lang['affiliate_login_title'] = "Афилиэйтный логин";
$lang['password_changed_successfully'] = 'Пароль успешно изменен.';
$lang['affiliate_registration_success'] = 'Афилиэйт успешно зарегистрирован';
$lang['login_now'] = 'Войти сейчас';
$lang['must_be_valid'] = 'Должен быть правильным';
$lang['characters'] = 'символов';
$lang['e-mail'] = 'E-mail:';
$lang['age'] = 'Возраст';
$lang['years'] = 'лет';

$lang['all_states'] = 'Все области/штаты';
//
// These terms are used at Signup page
//
$lang['welcome'] = 'Добро пожаловать';
$lang['admin_welcome'] = 'Добро пожаловать <br /> на <br /> Панель Администратора сайта <br /> ' . stripslashes(stripslashes(SITENAME));
$lang['title'] = 'Добро пожаловать на ' . stripslashes(SITENAME);
$lang['site_links'] = array(
	'home' => 'Home',
	'signup_now' => 'Зарегистрироваться',
	'chat' => 'Чат',
	'forum' => 'Форум',
	'login' => 'Войти',
	'search' => 'Поиск',
	'aboutus' => 'О нас',
	'forgot' => 'Потеряли пароль?',
	'contactus' => 'Наши контакты',
	'privacy' => 'Конфиденциальность',
	'terms_of_use' => 'Правила использования',
	'services' => 'Услуги',
	'faq' => 'ЧаВО',
	'articles' => 'Статьи',
	'affliates' => 'Афилиэйты',
	'invite_a_friend' => 'Пригласить друга',
	'feedback' => 'Отзыв'
	);

$lang['success_stories'] = 'Истории успеха';
$lang['members_login'] = 'Войти';
$lang['poll'] = 'Опрос';
$lang['news'] = 'Новости';
$lang['articles'] = 'Статьи';
$lang['poll_result'] = 'Результаты опроса';
$lang['view_poll_archive'] = 'Предыдущие опросы';
$lang['member_panel'] = 'Панель пользователя';
$lang['poll_errmsg1'] = 'Вы уже голосовали для этого опроса. Попробуйте проголосовать в другом опросе в иной день.';
$lang['close'] = 'Закрыть';
$lang['all_stories'] = 'Все истории';
$lang['all_news'] = 'Все новости';
$lang['more'] = 'дальше';
$lang['by'] = 'автор';

$lang['dont_stay_alone'] = 'Не будь один,';
$lang['join_now_for_free'] = 'присоединись сейчас, бесплатно!';
$lang['special_offer'] = 'Специальное предложение!';
$lang['welcome_to'] = 'Добро пожаловать на ';
$lang['welcome_to_site'] = 'Добро пожаловать на '.stripslashes(SITENAME);

$lang['offer_text'] = 'Узнай - почему ' . stripslashes(SITENAME) . ' - самый быстрорастущий сайт знакомств в сети. Открой анкету на ' . stripslashes(SITENAME) . ' и ты быстро получишь объективный отзыв на нее и на твое отношение к другим людям. С анкеты на ' . stripslashes(SITENAME) . ' начинается вдохновляющее путешествие на пути поиска Вашей настоящей любви!';

$lang['newest_profiles'] = 'Новые анкеты';

$lang['edit_profile'] = 'Изменить анкету';
$lang['total_profiles'] = 'Всего пользователей';
$lang['forgot'] = 'Потеряли пароль?';
$lang['hide'] = 'Скрыть';
$lang['show'] = 'Показать';
$lang['sex'] = 'Пол:';
$lang['sex_without_colon'] = 'Пол';
$lang['pageno'] = 'Страница ';
$lang['page'] = 'Страница';
$lang['previous'] = 'Предыдущие';
$lang['next'] = 'Следующие';
$lang['time_col'] = 'Время:';

$lang['save_search'] = 'Сохранить найденное';
$lang['find_your_match'] = 'Найди свою половину';

$lang['extended_search'] = 'Расширенный поиск';
$lang['matches_found'] = 'По вашему запросу найдено';
$lang['timezone'] = 'Часовой пояс:';
$lang['next_section'] = 'Следующая секция';
$lang['sign_in'] = 'Вход';
$lang['member_panel'] = 'Панель Пользователя';
$lang['aff_panel'] = 'Панель афилиэйта';
$lang['login_title'] = 'Зона пользовательского входа';
$lang['sign_out'] = 'Выйти';
$lang['login_submit'] = 'Войти';

$lang['change_password'] = 'Изменение пароля';
$lang['old_password'] = 'Старый пароль:';
$lang['new_password'] = 'Новый пароль:';
$lang['confirm_password'] = 'Подтверждение пароля:';
$lang['password_change_msg'] = 'Ваш пароль был успешно изменен.';

$lang['section_signup_title'] = 'Для регистрации';
$lang['signup'] = 'Регистрация';
$lang['section_basic_title'] = 'Начальные данные';
$lang['section_appearance_title'] = 'Внешность';
$lang['section_interests_title'] = 'Интересы';
$lang['section_lifestyle_title'] = 'Образ жизни';

$lang['signup_subtitle_login'] = 'Для входа на сайт';
$lang['signup_subtitle_profile'] = 'Анкетные данные';
$lang['signup_subtitle_address'] = 'Адрес';
$lang['signup_subtitle_appearacnce'] = 'Внешность';
$lang['signup_subtitle_preference'] = 'Настройки поиска';

$lang['signup_username'] = 'Имя пользователя:';
$lang['signup_password'] = 'Пароль:';
$lang['signup_confirm_password'] = 'Подтверждение пароля:';

$lang['signup_firstname'] = 'Имя:';
$lang['signup_lastname'] = 'Фамилия:';
$lang['signup_e-mail'] = 'Адрес электронной почты (е-mail):';
$lang['section_mypicture'] = 'Мои фотографии';
$lang['upload'] = 'Загрузить';
$lang['upload_pictures'] = 'Загрузить фотографии';
$lang['upload_format_msgs'] = 'Допускаются только файлы форматов .jpg, .gif, .bmp или .png.';
$lang['thumbnail'] = 'Уменьшенная фотография';
$lang['picture'] = 'Фотография';
$lang['signup_picture'] = 'Моя фотография';
$lang['signup_picture2'] = 'Моя фотография:';
$lang['signup_picture3'] = 'Моя фотография:';
$lang['signup_picture4'] = 'Моя фотография:';
$lang['signup_picture5'] = 'Моя фотография:';

$lang['signup_gender'] = 'Я ';
$lang['signup_pref_age_range'] = 'В возрасте';
$lang['signup_year_old'] = 'лет';
$lang['signup_birthday'] = 'Дата рождения:';
$lang['signup_country'] = 'Страна:';
$lang['signup_state_province'] = 'Область/штат:';
$lang['signup_zip'] = 'Почтовый индекс:';
$lang['signup_city'] = 'Город / Местность: ';
$lang['signup_address1'] = 'Адрес, строка 1:';
$lang['signup_address2'] = 'Адрес, строка 2:';
$lang['signup_height'] = 'Рост: ';
$lang['signup_feet'] = 'футов';
$lang['signup_meter_inches'] = 'дюймов [ метры - если за пределами США ]';
$lang['signup_weight'] = 'Вес:';
$lang['signup_pounds'] = 'фунтов [ кг - если за пределами США ]';
$lang['signup_where_should_we_look'] = 'Где искать?';
$lang['signup_view_online'] = "Показывать что я онлайн?";

$lang['signup_gender_values'] = array(
	'M' => 'Парень',
	'F' => 'Девушка',
	'C' => 'Пара'
	);

$lang['signup_gender_look'] = array(
	'M' => 'Парня',
	'F' => 'Девушку',
	'C' => 'Пару',
	'B' => 'Парня или Девушку',
	'A' => 'Все'
	);

$lang['seeking'] = 'ищу';
$lang['who_is_from'] = 'Возраст, от';
$lang['looking_for_a'] = 'ищу';
$lang['looking_for'] = 'Ищу:';

$lang['of'] = ' из ';
$lang['to'] = ' до ';
$lang['from'] = ' от ';
$lang['for'] = ' для ';
$lang['yes'] = 'Да';
$lang['no'] = 'Нет';
$lang['cancel'] = 'Отменить';

$lang['change'] = 'Изменить';
$lang['submit'] = 'Сохранить';
$lang['reset'] = 'Очистить';

//Commonly used words

$lang['required_info_indication'] = 'указывает что поле обязательно для заполнения';
$lang['required_info_indicator'] = '* ';
$lang['required_info_indicator_color'] = 'Red';
$lang['click_here'] = 'пройдите сюда';

$lang['datetime_day']['Sunday'] = 'Вокресенье';
$lang['datetime_day']['Monday'] = 'Понедельник';
$lang['datetime_day']['Tuesday'] = 'Вторник';
$lang['datetime_day']['Wednesday'] = 'Среда';
$lang['datetime_day']['Thursday'] = 'Четверг';
$lang['datetime_day']['Friday'] = 'Пятница';
$lang['datetime_day']['Saturday'] = 'Суббота';
$lang['datetime_dayval']['Sun'] = 'Вс';
$lang['datetime_dayval']['Mon'] = 'Пн';
$lang['datetime_dayval']['Tue'] = 'Вт';
$lang['datetime_dayval']['Wed'] = 'Ср';
$lang['datetime_dayval']['Thu'] = 'Чт';
$lang['datetime_dayval']['Fri'] = 'Пт';
$lang['datetime_dayval']['Sat'] = 'Сб';

$agecounter = array();

for($i=18; $i<100; $i++ ) {
	$agecounter[] = $i;
}
$lang['start_agerange'] = $agecounter;
$lang['end_agerange'] = $agecounter;

$lang['error_msg_color'] = 'Red';
$lang['success_message'] = "Информация которую вы ввели была успешно сохранена.<br>Вы будете автоматически перенаправлены на следующую секцию в течение 5 секунд. В случает если автоматическое перенаправление не сработает, пожалуйста, кликните мышкой сами на ссылку ниже.";
$lang['signup_success_message'] = 'Поздравляем!<br>Теперь Вы зарегистрированный пользователь ' . stripslashes(SITENAME);
$lang['sendletter_success'] = 'Письмо было успешно послано.';

// These are displayed in the timezone select box
$lang['tz']['-25'] = '-- Select --';
$lang['tz']['-12.00'] = 'GMT - 12 часов';
$lang['tz']['-11.00'] = 'GMT - 11 часов';
$lang['tz']['-10.00'] = 'GMT - 10 часов';
$lang['tz']['-9.00'] = 'GMT - 9 часов';
$lang['tz']['-8.00'] = 'GMT - 8 часов';
$lang['tz']['-7.00'] = 'GMT - 7 часов';
$lang['tz']['-6.00'] = 'GMT - 6 часов';
$lang['tz']['-5.00'] = 'GMT - 5 часов';
$lang['tz']['-4.00'] = 'GMT - 4 часа';
$lang['tz']['-3.5'] = 'GMT - 3.5 часа';
$lang['tz']['-3.00'] = 'GMT - 3 часа';
$lang['tz']['-2.00'] = 'GMT - 2 часа';
$lang['tz']['-1.00'] = 'GMT - 1 час';
$lang['tz']['0.00'] = 'GMT';
$lang['tz']['1.00'] = 'GMT + 1 час';
$lang['tz']['2.00'] = 'GMT + 2 часа';
$lang['tz']['3.00'] = 'GMT + 3 часа';
$lang['tz']['3.5'] = 'GMT + 3.5 часа';
$lang['tz']['4'] = 'GMT + 4 часа';
$lang['tz']['4.5'] = 'GMT + 4.5 часов';
$lang['tz']['5.00'] = 'GMT + 5 часов';
$lang['tz']['5.5'] = 'GMT + 5.5 часов';
$lang['tz']['6.00'] = 'GMT + 6 часов';
$lang['tz']['6.5'] = 'GMT + 6.5 часов';
$lang['tz']['7.00'] = 'GMT + 7 часов';
$lang['tz']['8.00'] = 'GMT + 8 часов';
$lang['tz']['9'] = 'GMT + 9 часов';
$lang['tz']['9.5'] = 'GMT + 9.5 часов';
$lang['tz']['10.00'] = 'GMT + 10 часов';
$lang['tz']['11.00'] = 'GMT + 11 часов';
$lang['tz']['12.00'] = 'GMT + 12 часов';
$lang['tz']['13.00'] = 'GMT + 13 часов';


/*****************Admin Section Labels********************/

//Commonly used labels
$lang['admin_login_title'] = 'Панель Администрации ' . stripslashes(SITENAME);
$lang['admin_login_msg'] = 'Логин Админа';
$lang['admin_title_msg'] = 'Панель Админа ' . stripslashes(SITENAME);
$lang['admin_panel'] = 'Панель Админа';
$lang['back'] = 'Назад';
$lang['insert_msg'] = 'Вставить новое ';
$lang['question_mark'] = '?';
$lang['id'] = 'Id:';
$lang['name'] = 'Имя:';
$lang['name_col'] = 'Имя';
$lang['enabled'] = 'Разрешено:';
$lang['action'] = 'Действие';
$lang['edit'] = 'Редактировать';
$lang['delete'] = 'Удалить';
$lang['section'] = 'Секция:';
$lang['insert_section'] = 'Вставить новую секцию';
$lang['modify_section'] = 'Изменить секцию';
$lang['modify_sections'] = 'Изменить секции';
$lang['delete_section'] = 'Удалить секцию';
$lang['delete_sections'] = 'Удалить секции';
$lang['enable_selected'] = 'Разрешить';
$lang['disable_selected'] = 'Запретить';
$lang['change_selected'] = 'Изменить';
$lang['delete_selected'] = 'Удалить';
$lang['no_select_msg'] = "Вы не выбрали варианта. Пожалуйста кликните на кнопку BACK браузера чтобы выбрать там один или больше вариантов.";
$lang['delete_confirm_msg'] = 'Уверены, что хотите удалить эту секцию?';
$lang['delete_group_confirm_msg'] = 'Уверены, что хотите удалить эти секции? Это действие не сможет быть обращено.';
$lang['enabled_values'] = array(
	'Y' => 'Да',
	'N' => 'Нет'
	);
$lang['display_control_type'] = array(
	'checkbox' => 'Чек-бокс',
	'radio' => 'Выбор из вариантов',
	'select' => 'Выпадающий список',
	'textarea' => 'Поле ввода'
	);
$lang['admin_error_color'] = 'Red';

$lang['col_head_srno'] = '#';
$lang['col_head_id'] = 'Id';
$lang['col_head_question'] = 'Вопрос';
$lang['col_head_enabled'] = 'Разрешено';
$lang['col_head_name'] = 'Имя';
$lang['col_head_username'] = 'Имя пользователя';
$lang['col_head_firstname'] = 'Имя';
$lang['col_head_lastname'] = 'Фамилия';
$lang['col_head_fullname'] = 'Полное имя';
$lang['col_head_status'] = 'Статус';
$lang['col_head_gender'] = 'Пол';
$lang['col_head_e-mail'] = 'Адрес эл. почты (e-mail)';
$lang['col_head_country'] = 'Страна';
$lang['col_head_city'] = 'Город';
$lang['col_head_zip'] = 'Почтовый индекс';
$lang['col_head_register_at'] = 'Зарегистрирован';

$lang['section_title'] = 'Управление секциями';
$lang['total_sections'] = 'Секций всего:';
$lang['profile_title'] = 'Управление анкетами';
$lang['total_profiles_found'] = 'Найдено анкет: ';
$lang['modify_profile'] = 'Редактировать анкету';

$lang['profile_signup_title'] = 'Информация о регистрации';
$lang['profile_basic_title'] = 'Начальные данные';
$lang['profile_appearance_title'] = 'Внешность';
$lang['profile_interests_title'] = 'Интересы';
$lang['profile_lifestyle_title'] = 'Образ жизни';

$lang['profile_subtitle_login'] = 'Логин';
$lang['profile_subtitle_profile'] = 'Анкета';
$lang['profile_subtitle_address'] = 'Адрес';
$lang['profile_subtitle_appearacnce'] = 'Внешность';
$lang['profile_subtitle_preference'] = 'Предпочтения';
$lang['profile_delete_confirm_msg'] = 'Вы уверены, что хотите удалить эту анкету?';
$lang['delete_profile'] = 'Удалить анкету';
$lang['profile_username'] = 'Имя пользователя:';
$lang['profile_firstname'] = 'Имя:';
$lang['profile_lastname'] = 'Фамилия:';
$lang['profile_e-mail'] = 'Адрес электронной почты (e-mail):';
$lang['profile_gender'] = 'Пол:';
$lang['profile_birthday'] = 'Дата рождения:';
$lang['profile_country'] = 'Страна:';
$lang['profile_state_province'] = 'Область/штат:';
$lang['profile_zip'] = 'Почтовый индекс:';
$lang['profile_city'] = 'Город / Местность';
$lang['profile_address1'] = 'Адрес, строка 1:';
$lang['profile_address2'] = 'Адрес, строка 2:';
$lang['find'] = 'Найти';
$lang['search'] = 'Поиск';
$lang['AND'] = 'И';
$lang['OR'] = 'ИЛИ';
$lang['order_by'] = 'Упрядочить по ';
$lang['sort_by'] = 'Отсортировать по ';
$lang['sort_types'] = array(
	'asc' => 'нарастанию',
	'desc' => 'убыванию'
	);
$lang['search_results'] = 'Результаты поиска';
$lang['no_record_found'] = 'По запросу ничего не найдено.';
$lang['search_options'] = 'Настройки поиска';
$lang['search_simple'] = 'Простой поиск';
$lang['search_advance'] = 'Продвинутый поиск';
$lang['search_advance_results'] = 'Результаты продвинутого поиска';
$lang['search_country'] = 'Поиск по странам';
$lang['search_states'] = 'Поиск по областям';
$lang['search_zip'] = 'Поиск по почтовому индексу';
$lang['search_city'] = 'Поиск по городам';
$lang['search_wildcard_msg'] = 'Вы можете ввести * в вводное поле чтоб искать все записи.';
$lang['search_location'] = '<b>Поиск по месту:</b>';
$lang['select_country'] = 'Страна:';
$lang['select_state'] = 'Область:';
$lang['enter_city'] = 'Город:';
$lang['enter_zip'] = 'Почтовый индекс:';
$lang['enter_username'] = 'Имя пользователя:';
$lang['results_per_page'] = 'Результатов на страницу';
$lang['search_results_per_page'] = array( 5 => 5 , 10 => 10, 20 => 20, 50 => 50, 100 => 100 );
$lang['order'] = 'Порядок';
$lang['up'] = 'Вверх';
$lang['down'] = 'Вниз';

$lang['question'] = 'Вопрос:';

$lang['maxlength'] = 'Максимальная длина:';
$lang['description'] = 'Описание:';
$lang['mandatory'] = 'Обязательно:';
$lang['guideline'] = 'Указания:';
$lang['control_type'] = 'Показываемый элемент управления (control):';
$lang['include_extsearch'] = 'Включать в расширенный поиск:';
$lang['head_extsearch'] = 'Заголовок расширенного поиска:';

$lang['insert_question'] = 'Вставить вопрос';
$lang['delete_question'] = 'Удалить вопрос';
$lang['modify_question'] = 'Изменить вопрос';
$lang['questions_title'] = 'Управление вопросами';
$lang['total_options'] = 'Всего вариантов:';
$lang['insert_question'] = 'Вставить новый вопрос';
$lang['total_questions'] = 'Всего вопросов:';
$lang['delete_questions'] = 'Удалить вопросы';
$lang['delete_group_questions_confirm_msg'] = 'Вы уверены, что хотите удалить эти вопросы';

// defined by ALI
$lang['option'] = 'Варианты';
$lang['answer'] = 'Ответ';
$lang['options_title'] = 'Варианты ответа на вопрос';
$lang['col_head_answer'] = 'Ответ';
$lang['with_selected'] = 'Выделенное';
$lang['ranging'] = 'Рангами';

// Instant messenger
$lang['instant_messenger'] = 'Мгновенные сообщения';
$lang['instant_message'] = 'Мгновенное сообщение';
$lang['im_from'] = 'От:';
$lang['im_message'] = 'Сообщение:';
$lang['im_reply'] = 'Ответить';
$lang['close_window'] = 'Закрыть окно';

// my matches
$lang['my_matches'] = '"Мои пары"';
$lang['i_am_a'] = 'Я -';
$lang['Looking_for'] = 'Ищу';
$lang['Between'] = 'между';
$lang['who_is_from'] = 'возраст, от';
$lang['showing'] = 'показаны от';
$lang['Showing'] = 'Показаны от';
$lang['your_search_preferences'] = 'Текущие настройки поиска:';
$lang['to_edit_search_preferences'] = 'чтоб изменить настройки поиска';

$lang['unapproved_user'] = 'Непроверенные анкеты';
$lang['gbl_settings'] = 'Глобальные настройки';
$lang['configurations'] = 'Конфигурации';
$lang['col_head_variable'] = 'Переменные';
$lang['col_head_value'] = 'Значения';

$lang['affiliate_title'] = 'Управление афилиэйтами';
$lang['col_head_counter'] = 'Счетчик';
$lang['col_head_status'] = 'Статус';

$lang['tell_later'] = 'Нет ответа';
$lang['view_profile'] = 'Посмотреть анкету';
$lang['view_profile_errmsg1']  = 'Вы все еще не указали Ваши предпочтения.<br />Пожалуйста, заполните сначала детали анкеты.<br />.';
$lang['view_profile_errmsg2'] = '<br>Нажмите сюда чтоб заполнить предпочтения сейчас.';
$lang['view_profile_errmsg3'] = 'Пользователь пока не заполнил свою анкету, или не до конца.';
$lang['view_profile_restricted'] = 'Эта анкета ограничена для просмотров, Вы не можете ее просмотреть.';
$lang['profile_notset'] = 'Не найдена анкета пользователя.';
$lang['send_mail'] = 'Написать сообщение';
$lang['mail_messages'] = 'Мои сообщения';
$lang['col_head_subject'] = 'Тема';
$lang['col_head_sendtime'] = 'Дата';

$lang['inbox'] = 'Входящие';
$lang['sent'] = 'Посланные';
$lang['trashcan'] = 'Удаленные';
$lang['reply'] = 'Ответить';
$lang['read'] = 'как прочитанное';
$lang['unread'] = 'Отметить как непрочитанное';
$lang['new_one'] = 'новое';
$lang['new_many'] = 'новых';
$lang['restore'] = 'Восстановить';
$lang['subject'] = 'Тема';
$lang['subject_colon'] = 'Тема:';
$lang['message'] = 'Сообщение';
$lang['send'] = 'Послать';

$lang['send_letter'] = 'Послать письмо';
$lang['image_browser'] = 'Просмативатель изображений';
$lang['upload_image'] = 'Загрузить изображение';
$lang['delete_image'] = 'Удалить изображение';
$lang['show_image'] = 'Показать изображение';
$lang['send_invite'] = 'Послать приглашение';
$lang['letter_title'] = 'Новое письмо';
$lang['from_e-mail'] = 'Из адреса (e-mail):';
$lang['from_name'] = 'От (Имя):';
$lang['send_to'] = 'Послать';
$lang['e-mail_subject'] = 'Тема:';
$lang['save_as'] = 'Сохранить как';

$lang['no_message'] = 'В Ваших "Входящих" нет новых сообщений.';
$lang['descrip'] = 'Описание';

//forgot password words
$lang['forgotpass_msg1'] = "Напоминание пароля";
$lang['forgotpass_msg2'] = "Пожалуйста укажите адрес электронной почты (e-mail) который был использован при создании Вашей анкеты, по которому Вам будет высланы Ваши имя пользователя (login) и пароль.";
$lang['retreieve_info'] = 'Послать';
$lang['forgotpass'] = 'Утерянный пароль';

//Tell a friend
$lang['tellafriend'] = 'Пригласить друга';
$lang['taf_msg1'] = 'Пригласить друга на ' . stripslashes(SITENAME);
$lang['taf_yourname'] = 'Ваше имя:';
$lang['taf_youre-mail'] = 'Ваш e-mail:';
$lang['taf_friende-mail'] = "E-mail друга:";

//Auto-mail
$lang['confirm_your_profile'] = 'Подтвердить регистрацию';
$lang['letter_not_avail'] = 'Шаблон для письма не найден';
$lang['confirm_letter_sent'] = 'Письмо для подтверждения регистрации было послано по адресу (e-mail) который был указан при регистрации. Пожалуйста, откройте это e-mail письмо, чтобы завершить Вашу регистрацию.';
$lang['letter_not_sent'] = 'Проблема при посылке e-mail письма. Пожалуйста свяжитесь с Администратором.';
$lang['or'] = 'Или';
$lang['enter_confirm_code'] = 'Для того чтобы завершить Вашу регистрацию, пожалуйста, введите код подтверждения сюда:';
$lang['wrong_activationcode'] = 'Указанный код подтверждения неверен.';
$lang['confirm_success'] = 'Вернуться в начало чтоб войти.';

//Page management

$lang['manage_pages'] = 'Управление страницами';
$lang['pagetitle'] = 'Заголовок:';
$lang['pagetext'] = 'Текст:';
$lang['pagekey'] = 'Ключ:';
$lang['addpage'] = 'Добавить страницу';
$lang['page'] = 'Страница:';
$lang['addnew'] = 'Добавить новую';
$lang['modpage'] = 'Изменить страницу';
$lang['pagekey_help'] = 'http://www.yourdomain.com/index.php?key=YOUR_KEY';

$lang['y_o'] = 'y/o';
$lang['lastlogged'] = 'Был(а) в последний раз: ';
$lang['aff_stats'] = 'Статистика афилиэйтов';
$lang['total_referals'] = 'Всего рефералов (перешедших по ссылке)';
$lang['regis_referals'] = 'Зарегистрированных рефералов';
$lang['globalconfigurations'] = 'Глобальная конфигурация';

$lang['send_message_to'] = 'Сообщение';
$lang['writting_message'] = 'Послать сообщение ';
$lang['search_at'] = 'Искать в ';

//Rating module
$lang['rate_profile'] = 'Дать рейтинг анкете';
$lang['worst'] = 'Очень плохо';
$lang['excellent'] = 'Отлично';
$lang['rating'] = 'Рейтинг';
$lang['submitrating'] = 'Дать рейтинг';

//Payment Modules
$lang['mship_changed'] = 'Уровень членства изменен';
$lang['mship_changed_successfull'] = 'Ваш уровень членства был изменен на Бесплатный.';
$lang['no_payment'] = 'Отсуствует - для случая Бесплатного членства (с ограничениями)';
$lang['payment_modules'] = 'Модули оплаты';
$lang['payment_methods'] = 'Способы оплаты';
$lang['business'] = 'Бизнес:';
$lang['siteid'] = 'Id сайта:';
$lang['undefined_quantity'] = 'Неопределенное количество:';
$lang['no_shipping'] = 'Нет посылки:';
$lang['no_note'] = 'Нет заметок:';
$lang['on_off_values'] = array( 1 => 'Да', 0 => 'Нет' );
$lang['edit_payment_modules'] = 'Редактировать модуль оплаты';
$lang['trans_key'] = 'Код транзакции:';
$lang['trans_mode'] = 'Состояние транзакции:';
$lang['trans_method'] = 'Способ совершения транзакции:';
$lang['username'] = 'Имя пользователя:';
$lang['username_without_colon'] = 'Имя пользователя';
$lang['country'] = 'Страна';
$lang['country_colon'] = 'Страна:';
$lang['state'] = 'Область/штат';
$lang['city'] = 'Город';
$lang['location_col'] = 'Адрес:';
$lang['location_no_col'] = 'Адрес';
$lang['zip_code'] = 'Почтовый индекс';
$lang['attached_files'] = 'Прикрепленные файлы';
$lang['cc_owner'] = 'Имя владельца карты:';
$lang['cc_number'] = 'Номер кредитной карты:';
$lang['cc_type'] = 'Тип кредитной карты:';
$lang['cc_exp_date'] = 'Дата истекания срока кредитной карты:';
$lang['cc_cvv_number'] = 'Номер проверки кредитной карты (CVV и т.п.):';
$lang['cvv_help'] = '(расположен на задней поверхности кредитной карты, прямо под магнитной полосой)';
$lang['continue'] = 'Продолжить';
$lang['payment_msg1'] = 'Возможные способы оплаты.';
$lang['trans_method_vals'] = array(
	'CC' => 'Кредитная карта',
	'ECHECK' => 'Электронный чек',
	'ARCA' => 'ARCA - ARmenian CArd',
	'E-Dram' => 'E-Dram - Система "Электронные Драмы"'
	);
$lang['trans_mode_vals'] = array(
	'AUTH_CAPTURE' => 'AUTH_CAPTURE',
	'AUTH_ONLY' => 'AUTH_ONLY',
	'CAPTURE_ONLY' => 'CAPTURE_ONLY',
	'CREDIT' => 'CREDIT',
	'VOID' => 'VOID',
	'PRIOR_AUTH_CAPTURE' => 'PRIOR_AUTH_CAPTURE'
 );
$lang['cc_unknown'] = 'Компания кредитной карты неизвестна. Пожалуйста, попробуйте снова работающей кредитной картой.';
$lang['cc_invalid_date'] = 'Неправильный срок истечения кредитной карты. Пожалуйста, попробуйте снова работающей кредитной картой.';
$lang['cc_invalid_number'] = 'Неправильный номер кредитной карты. Пожалуйста попробуйте снова работающей кредитной картой.';
$lang['amount'] = 'Количество:';
$lang['confirmation'] = 'Подтверждение';
$lang['confirm'] = 'Подтвердить';
$lang['upgrade_membership'] = 'Статус членства';
$lang['changeto'] = 'Изменить на';
$lang['current_mship_level'] = 'Текущий уровень членства:';
$lang['membership_status'] = 'Уровень членства';
$lang['success_mship_change'] = 'Ваш уровень членства был успешн изменен на';
$lang['you_currently'] = 'Вы сейчас - ';
$lang['info_confirm'] = 'Пожалуйста, подтвердите: ';
$lang['change_mship_to'] = 'Изменить уровень членства на ';
//Membership
$lang['permitmsg_1'] = 'Простите, Ваш уровень членства не включает ';
$lang['permitmsg_2'] = 'Пожалуйста, повысьте Ваш уровень членства чтоб использовать ';
$lang['permitmsg_3'] = 'Таблица сравнения уровней членства';
$lang['permitmsg_4'] = 'Скрыть таблицу сравнения уровней членства';
$lang['privileges'] = array (
	'chat' 				=> 'Участие в чатах.',
	'forum'				=> 'Участие в форуме.',
	'includeinsearch' 	=> 'Включение в результаты поисков.',
	'message'			=> 'Посылка сообщений на эл. почту (e-mail).',
	'uploadpicture'		=> 'Загрузка фотографий на сайт.',
	'seepictureprofile' => 'Просмотр фотографий анкет.',
	'favouritelist'		=> 'Управление папками',
	'sendwinks'			=> 'Подмигнуть',
	'extsearch'			=> 'Расширенный поиск',
	'fullsignup' 		=> 'Полная подписка на все.'
);
$lang['membership_packages'] = 'Пакеты членства';
$lang['membership_packages_compare'] = 'Сравнение пакетов членства';
$lang['modify'] = 'Сохранить изменения';
$lang['manage_membership'] = 'Управление пакетами';
$lang['privileges_msg'] = 'Привилегии';
$lang['support_currency'] = array(
        'AMD'=>'AMD',
		'USD' 	=> '$',
		'EUR'	=>'Ђ',
		'INR'	=>'Rs.',
		'AUD'	=> 'AU$',
		'CD'	=> 'CAN$',
		'UKP'	=> chr(163)
		);
$lang['price'] = 'Цена: ';
$lang['currency'] = 'Валюта: ';
$lang['choose_membership'] = 'Выберите пакет:';
$lang['add_membership'] = 'Добавить новый пакет';
$lang['membership_types'] = 'Пакеты';
$lang['member'] = 'пакета пользователь';

$lang['select_letter'] = 'Выбрать письмо:';
$lang['body'] = 'Сообщение:';
$lang['module'] = 'Модуль';
$lang['uninstall'] = 'Удалить инсталляцию';
$lang['install'] = 'Инсталлировать';
$lang['modify_option'] = 'Изменить опции';

$lang['only_jpg'] = 'Допускаются только файлы форматов .jpg, .gif, .bmp или .png.';
$lang['upload_unsuccessful'] = 'Фотография не может быть загружена на сайт.';
$lang['upload_successful'] = 'Фотографии загружены на сайт.';
$lang['between'] = 'Между';
$lang['and'] = 'и';
$lang['profile_details'] = 'Детали анкеты';
$lang['personal_details'] = 'Личные данные';


//Banner Management
$lang['manage_banners'] = 'Управление баннерами';
$lang['add_banners'] = 'Добавить баннер';
$lang['edit_banners'] = 'Редактировать баннер';
$lang['size'] = 'Размер';
$lang['size_px'] = 'Размер (px)';
$lang['banner_linkurl'] = 'Баннер / URL ссылки';
$lang['banner_sizes'] = array(
	'468X60' => '468 x 60',
	'100X500'=>'100 x 500',
	'120X120'=>'120 x 120'
);
$lang['banner_sizes_name'] = array( 'горизонтальный', 'вертикальный', 'квадратный' );
$lang['startdate'] = 'Дата начала:';
$lang['enddate'] = 'Дата окончания:';
$lang['tooltip'] = 'Текст при наведении мышью (Tooltip):';
$lang['linkurl'] = 'Url ссылки:';
$lang['banner'] = 'Баннер:';
$lang['total_banner'] = 'Всего баннеров:';
$lang['online_users'] = 'Сейчас онлайн:';
$lang['site_statistics'] = 'Статистика';
$lang['pending_profiles'] = 'Пользователей ждущих подтверждения';
$lang['active_profiles'] = 'Активных пользователей';
$lang['online_profiles'] = 'Пользователей онлайн';
$lang['pending_aff'] = 'Афилиэйтов ждущих подтверждения';
$lang['total_affiliates'] = 'Афилиэйтов всего';
$lang['active_aff'] = 'Афилиэйтов активных';
$lang['no_rating'] = 'Нет рейтинга';

//SEO Words
$lang['seo'] = 'SEO-настройки';
$lang['seo_head'] = 'Оптимизация под поисковики (Search Engine Optimization)';
$lang['sef_msg'] = 'URL-ы, дружественные поисковым машинам';
$lang['seo_enable'] = 'Разрешить URL Rewriting используя mod_rewrite:';
$lang['yes_msg'] ='URL rewriting - опция доступная только при использовании \nвеб-сервера Apache, со включенным модулем расширений mod_rewrite.\nПожалуйста убедитеcь, что Ваш сервер подходит под эти требования.\nПомните также, пожалуйста, что надо переименовывать файл .htaccess.txt в .htaccess.';
$lang['keywords'] = 'Ключевые слова:';
$lang['page_tags_msg'] = 'Заголовки страниц и таги Meta';
$lang['max_255'] = 'Максимум 255 символов';

//News / Story / Article Manangement
$lang['manage_news'] = 'Управление новостями';
$lang['manage_story'] = 'Управление историями';
$lang['manage_article'] = 'Управление статьями';
$lang['news_header'] = 'Загловок';
$lang['total_news'] = 'Всего новостей:';
$lang['total_articles'] = 'Всего статей:';
$lang['total_stories'] = 'Всего историй:';
$lang['article_title'] = 'Заголовок';
$lang['story_sender'] = 'Автор';
$lang['story_sender_msg'] = 'Id Анкеты [цифрами]';
$lang['modify_article'] = 'Редактировать статью';
$lang['modify_news'] = 'Редактировать новость';
$lang['modify_story'] = 'Редактировать историю';
$lang['insert_article'] = 'Добавить статью';
$lang['insert_story'] = 'Добавить историю';
$lang['insert_news'] = 'Добавить новость';
$lang['dat'] = 'Дата:';

//Poll Words
$lang['manage_polls'] = 'Управление опросами';
$lang['modify_poll'] = 'Редактировать опрос';
$lang['total_polls'] = 'Всего опросов';
$lang['poll'] = 'Опрос';
$lang['add_polls'] = 'Добавить опросы';
$lang['add_options'] = 'Добавить вариант';
$lang['active'] = 'Активный';
$lang['activate'] = 'Активировать';
$lang['option'] = 'Вариант';
$lang['modify_options'] = 'Изменить варианты';
$lang['add_option_now'] = 'Добавить вариант.';
$lang['poll_options'] = 'Настройки опроса';
$lang['votes'] = 'Голосов';
//Filter Records
$lang['filter_options'] = array(
	'id' => 'Id',
	'username' => 'Имя пользователя',
	'city' => 'Город',
	'zip' => 'Почтовый индекс',
	'status' => 'Статус'
	);
$lang['first'] = 'Первый';
$lang['last'] = 'Последний';
$lang['filter_records'] = 'Фильровать записи';
$lang['search_at'] = 'Поиск при';
$lang['criteria'] = 'Критерии';

//Admin Management
$lang['manage_admins'] = 'Управление админами';
$lang['total_admins'] = 'Всего админов';
$lang['add_admin'] = 'Добавить нового админа';
$lang['modify_admin'] = 'Изменить админа';
$lang['fullname'] = 'Полное имя';
$lang['please_be_sure'] = 'Пожалуйста, убедитесь, что Вы';
$lang['change_your_admin_pwd'] = 'изменили пароль администратора по умолчанию';
$lang['superuser'] = 'Супер-пользователь';
$lang['no_admin_user_msg1'] = 'В системе сейчас нет админов, которые не Супер-пользователи. Чтобы менять привилегии, пожалуйста, сначала создайте нового админа.';
$lang['no_admin_user_msg2'] = 'Чтобы создать нового админ-пользователя';
$lang['access_denied'] = 'Доступ запрещен';
$lang['not_authorize'] = 'Вам не разрешен доступ к этой странице. Пожалуйста, свяжитесь с вашим Супер-админом.';
//Admin Permissions Management
$lang['admin_permissions'] = 'Привилегии админов';
$lang['manage_admin_permissions'] = 'Управление привилегиями админов';
$lang['admin_users'] = 'Пользователи-Админы';
$lang['permissions'] = 'Модули';
$lang['superuser_noteditable'] = 'Прим.: Супер-пользователи не редакитруемы.';
$lang['all'] = 'Все';
$lang['selected'] = 'Выделенные';
$lang['selected_users'] = 'Выделенные пользователи';
$lang['separate_users_by_coma'] = 'Введите имена пользователей, разделенные запятыми';
$lang['admin_rights'] = array(
		'site_stats' 				=> 'Статистика сайта',
		'profie_approval'		 	=> 'Анкеты для подтверждения',
		'profile_mgt' 				=> 'Управление анкетами',
		'section_mgt' 				=> 'Управление секциями',
		'affiliate_mgt' 			=> 'Управление афилиэйтами',
		'affiliate_stats'		 	=> 'Статистика афилиэйтов',
		'news_mgt' 					=> 'Управление новостями',
		'article_mgt' 				=> 'Управление статьями',
		'story_mgt'					=> 'Управление историями',
		'poll_mgt'		 			=> 'Управление опросами',
		'search' 					=> 'Поиск',
		'ext_search'				=> 'Расширенный поиск',
		'send_letter' 				=> 'Послать письмо',
		'pages_mgt' 				=> 'Управление страницами',
		'chat' 						=> 'Чат',
		'chat_mgt' 					=> 'Управление чатом',
		'forum_mgt' 				=> 'Управление форумом',
		'mship_mgt' 				=> 'Управление членством',
		'payment_mgt' 				=> 'Модули оплаты',
		'banner_mgt' 				=> 'Управление баннерами',
		'seo_mgt' 					=> 'SEO-настройки',
		'admin_mgt' 				=> 'Управление админами',
		'admin_permit_mgt'			=> 'Привилегии админов',
		'global_mgt' 				=> 'Глобальные настройки сайта',
		'change_pwd'				=> 'Изменение пароля',
		'cntry_mgt'					=> 'Управление Странами/Областями/Городами',
		'snaps_require_approval'	=> 'Проверка фотографий',
		'featured_profiles_mgt'		=> 'Анкеты с показами'
								);
/* Added by Vijay Nair   */
$lang['cntry_mgt']	= 'Управление Странами / Областями / Городами';
$lang['register_now'] = 'Нет анкеты? Зарегистрируйтесь!';
$lang['addtobuddylist'] = 'Добавить в Избранные';
$lang['addtobanlist'] = 'Добавить в Черный список';
$lang['addtohotlist'] = 'Добавить в Горячие';
$lang['buddylisthdr'] = 'Папка Избранные';
$lang['banlisthdr'] = 'Папка Черный список';
$lang['hotlisthdr'] = 'Папка Горячие';
$lang['username_hdr'] = 'Имя пользователя';
$lang['fullname_hdr'] = 'Полное имя';
$lang['register'] = 'Зарегистрироваться';
$lang['featured_profiles'] = 'Анкеты с показами';
$lang['bigger_pic_size'] = 'Размер картинки больше допустимого';
$lang['snaps_require_approval'] = 'Допуск фотографий';
$lang['upload_picture_caption'] = 'Главная фотография: ';
$lang['upload_thumbnail_caption'] = 'Уменьшенная фотография: ';
$lang['Approve'] = 'Подтвердить';
$lang['Remove'] = 'Удалить';
$lang['userdetails'] = 'Информация о пользователе';
$lang['pict'] = 'Фотка';
$lang['tnail'] = 'Уменьшенное';
$lang['reqact'] = 'Совершить действие';
$lang['newmemberlist'] = 'Новые пользователи';
$lang['yearsold'] = 'лет';
$lang['Male'] = 'Мужской';
$lang['Female'] = 'Женский';
$lang['showfulllist'] = 'Показать полный список';
$lang['featuredprofiles'] = 'Анкеты с показами';
$lang['featured_profiles_hdr'] = 'Анкеты с показами';
$lang['nonfeatured_profiles_hdr'] = 'Пользователи без показов';
$lang['level_hdr'] = 'Уровень';
$lang['date_from'] = 'Дата начала';
$lang['date_upto'] = 'Дата окончания';
$lang['must_show'] = 'Должно показываться';
$lang['reqd_exposures'] = 'Требуется показать';
$lang['total_exposures'] = 'Показано всего';
$lang['add_featured'] = 'Добавить анкету в список с показами';
$lang['mod_featured'] = 'Редактировать анкету в списке с показами';
$lang['member_since'] = 'Пользователь с';
$lang['invalid_username'] = 'Неправильное имя пользователя';
$lang['weekcnt'] = 'Анкет за неделю:';
$lang['totalgents'] = 'Всего парней:';
$lang['totalfemales'] = 'Всего девушек:';
$lang['weeksnaps'] = 'Фотографий за неделю:';
$lang['since_last_login'] = 'с последнего посещения';
$lang['sincelastlogin_hdr'] ='С последнего посещения';
$lang['newmessages'] = 'Новых сообщений:';
$lang['profileviewed'] = 'Вашу анкету просмотрели:';
$lang['winks_received'] = 'Подмигиваний получено:';
$lang['send_wink'] = 'Подмигнуть';
$lang['listofviews'] = 'Вашу анкету просмотрели';
$lang['listofwinks'] = 'Вам подмигнули';
$lang['winkslist'] = 'Подмигивания';
$lang['viewslist'] = 'Просмотры';
$lang['suggest_poll'] = 'Предложить опрос';
$lang['savepoll'] = 'Послать опрос';
$lang['moreoptions'] = 'Еще варианты';
$lang['minimum_options'] = 'Для опроса необходимо мининум два варианта';
$lang['pollsuggested'] = 'Спасибо! Предложенный Вами опрос переслан Администрации сайта.';
$lang['suggested_by'] = 'Предложено:';
$lang['any_where'] = 'Любой, где';
$lang['memberpanel'] = "Домашняя страничка пользователя";
$lang['feedback_thanks'] = 'Спасибо за Ваш отзыв.  Ваше сообщение переслано Администрации сайта.';
$lang['cancel_hdr'] = 'Удалить анкету';
$lang['cancel_txt01'] = 'Вы запросили удаления анкеты и прекращение членства в <b>'.stripslashes(SITENAME).'</b>.<br /><br />Вы уверены, что Вы хотите этого? ';
$lang['cancel_opt01'] = 'Да, я уверен(а)';
$lang['cancel_opt02'] = 'Нет, я не хочу прекращать членство и удалять анкету';
$lang['cancel_domsg'] = 'Спасибо за использование сайта '.stripslashes(SITENAME).'. <br /><br /> Мы сожалеем о том, что Вы более не с нами, но мы приветствуем Вас обратно сюда снова в любое время, и мы надеемся, что Вы нашли наши услуги полезными.';
$lang['cancel_nomsg'] = 'Спасибо за использование сайта '.stripslashes(SITENAME).'. <br /><br /> Мы ценим Ваше постоянство, и надеемся Вы находите наши услуги полезными.';
$lang['reject'] = 'Отказать';
//! $lang['unread'] = 'Непрочитанное';
$lang['membership_hdr'] = 'Уровень подписки';
$lang['edit_pict'] = 'Редактировать главную фотографию';
$lang['edit_thmpnail'] = 'Редактировать уменьшенную фотографию';
$lang['letter_options'] = 'Опции писем';
$lang['pic_gallery'] = 'Посмотреть фотографии';
$lang['reactivate'] = 'Ре-активировать пользователя';
$lang['cancel_list'] = 'Прерванные пользователи';
$lang['cancel_date'] = 'Дата прерывания';
$lang['language_opt'] = 'Выбор языка' ;
$lang['change_language'] = 'Поменять язык';
$lang['with_photo'] = 'Только с фотографией';
$lang['logintime'] = 'Время входа';
$lang['manage_country_states'] = 'Управление странами/областями';
$lang['manage_countries'] = 'Управление странами';
$lang['countries_count'] = 'Кол-во стран';
$lang['insert_country'] = 'Добавить страну';
$lang['modify_country'] = 'Редактировать страну';
$lang['country_code'] = 'Код страны';
$lang['country_name'] = 'Название страны';
$lang['manage_states'] = 'Управление облстями';
$lang['states_count'] = 'Кол-во областей';
$lang['insert_state'] = 'Добавить область';
$lang['modify_state'] = 'Редактировать область';
$lang['state_code'] = 'Код области';
$lang['state_name'] = 'Имя области';
$lang['totalcouples'] = 'Пар-пользователей, всего:';
$lang['active_days'] = 'Сколько дней активно?';
$lang['activedays_array'] = array('1'=>'1','7'=>'7','30'=>'30','90'=>'90','180'=>'180','365'=>'365');
$lang['expired'] = 'Истек cрок Вашего членства, <br /><br /><a href="payment.php">Здесь можно</a> возобновить Ваше членство и продолжать пользоваться сайтом '. stripslashes(SITENAME);
$lang['compose'] = 'Составить';
$lang['email_feedback_subject'] = 'Отзыв от Пользователя сайта '.SITENAME;

/******************************************/
/* ALL ERROR MESSAGES ARE DEFINED BELOW.  */
/******************************************/

// Affiliates error
$lang['affiliates_error'] = array(
	18=>'Пароли не совпадают',
	20=>'Все поля обязательны для заполнения.',
	21=>'Все поля обязательны для заполнения.',
	25=>'Адрес e-mail, котрый вы ввели уже зарегистрирован как афилиэйт. Пожалуйста, введите другой e-mail адрес.'
);

//Signup Error Messages
//These are the signup error messages, Please do not change the sequence.
$lang['errormsgs']= array(
	00 => '',
	01 => 'Имя пользователя - обязательное для заполнения поле.',
	02 => 'Пароль - обязательное для заполнения поле.',
	03 => 'Подтверждение пароля - обязательное для заполнения поле.',
	04 => 'Имя - обязательное для заполнения поле.',
	05 => 'Фамилия - обязательное для заполнения поле.',
	06 => 'Адрес E-mail - обязательное для заполнения поле.',
	07 => 'Город - обязательное для заполнения поле.',
	08 => 'Почтовый индекс - обязательное для заполнения поле.',
	09 => 'Адрес, строка 1 - обязательное для заполнения поле.',
	10 => 'Максимальная длина данных в поле имя пользователя - 25 символов.',
	11 => 'Максимальная длина данных в поле имя - 50 символов.',
	12 => 'Максимальная длина данных в поле фамилия - 50 символов.',
	13 => 'Максимальная длина данных в поле E-mail адресе 255 символов.',
	14 => 'Максимальная длина данных в поле город - 100 символов.',
	15 => 'Максимальная длина данных в поле Адрес, строка 1 - 255 символов.',
	16 => 'Имя пользователя должно начинаться с буквы.',
	17 => 'Пароль должен начинаться с буквы.',
	18 => 'Пароль и подтверждение пароля должны совпадать.',
	19 => 'Пожалуйста, введите правильный адрес E-mail',
	20 => 'Обязательная информация должна быть введена.',
	21 => "Логин/пароль, который Вы дали не дает Вам доступа к системе. Пожалуйста, проверьте Ваш ввод и попробуйте снова.",
	22 => 'Пользователь с таким именем уже существует, пожалуйста, выберите себе другое имя пользователя.',
	23 => 'Старый пароль, который Вы дали - неверен. Пожалуйста проверьте Ваш старый пароль и попробуйте заново.',
	25 => 'Пользователь с таким e-mail адресом уже зарегистрирован.' ,
	27 => 'Сообщение не нашлось.',
	28 => 'Пожалуйста, сначала выберите файл.',
	29 => 'Формат файла не подерживается, пожалуйста выберите другой',
	30 => 'Вопрос уже и так в начале.',
	31 => 'Вопрос уже и так в конце.',
	32 => 'Спасибо за Ваши комментарии. Ваш отзыв скоро будет обработан.',
	33 => 'Почтовый индекс не соответствует указанной области.',
	34 => 'Неверый почтовый индекс',
	36 => 'Ваша анкета приостановлена. Пожалуйста, свяжитесь с администратором по поводу деталей.',
	37 => 'Ваши заявки отклонены. Пожалуйста, свяжитесь с администратором по поводу деталей.',
	38 => 'Вы указали неверную дату рождения. Пожалуйста, проверьте ее и попробуйте снова.',
	39 => 'Старый и новый пароли должны не совпадать',
	40 => 'Возраст "От" должен быть меньше или равен возраста "До"',
	51 => 'Дата началадолжна быть до даты окончания',
	52 => 'Данный пользователь уже присуствует в списке',
	53 => 'Неверная дата',
	54 => 'Неверное имя пользователя',
	55 => 'Сначала Вы должны зайти как пользователь, чтоб посылать сообщения',
	56 => $lang['bigger_pic_size'],
	57 => $lang['only_jpg'],
	58 => $lang['upload_unsuccessful'],
	59 => 'Эта анкета добавлена к списку',
	60 => 'Размер уменьшенной фотографии - большой.',
	61 => 'Указанный код активации - неверен',
	62 => 'Имя пользователя удалено из списка',
	63 => 'Этот пользователь уже был добавлен в Ваш список "Избранные"',
	64 => 'Этот пользователь уже был добавлен в Ваш "Черный список"',
	65 => 'Этот пользователь уже был добавлен в Ваш список "Горячие"',
	66 => 'Ваше подмигивание было послано этому пользователю',
	67 => $lang['upload_successful'],
	68 => 'Подтверждение фотографии обновлено',
	69 => 'Отказ в приеме фотографии обновлен',
	70 => 'Записи о просмотрах удалены',
	71 => 'Записи о подмигиваниях удалены',
	72 => 'Анкета пользователя ре-активирована',
	/* Added in RC6  */
	72 => 'Анкета пользователя неактивирована',
	73 => 'Страна добавлена',
	74 => 'Страна удалена',
	75 => 'Название или код страны уже занят',
	76 => 'Данные страны изменены',
	77 => 'Добавлена область',
	78 => 'Область удалена',
	79 => 'Название или код области уже заняты',
	80 => 'Данные области отредактированы',
	81 => 'Название страны/области должно присуствовать',
	82 => 'Пользователь не загрузил ни одной фотографии. ',
	83 => 'Анкета удалена',
	84 => 'Отмеченные анкеты удалены.',
/* Modified in RC6  */
	26 => "Ваша анкета пока не активирована. Пожалуйста, <a href='completereg.php'>активируйте Вашу анкету</a> введя код активации или проследовав по ссылке которые даны в письме, посланном по e-mail адресу, указанному при регистрации.",
	35 => 'Ваша анкета пока не активна. Пожалуйста подождите активации, или свяжитесь с администрацией сайта.'
	);

// Javascript error messages
$lang['admin_js_error_msgs'] = array(
	'',
	'Пожалуйста, сначала отметьте в чек-боксе.',
	'Вы уверены, что хотите стереть?',
	'Вы уверены, что хотите стереть этот баннер?'
	);
$lang['admin_js__delete_error_msgs'] = array('',
	1=> 'Вы уверены, что хотите стереть эту секцию?\nЭто действие не сможет быть обращено.',
	2=> 'Вы уверены, что хотите стереть этот вопрос из этой секции?\nЭто действие не сможет быть обращено.',
	3=> 'Вы уверены, что хотите стереть вариант этого вопроса?\nЭто действие не сможет быть обращено.',
	4=> 'Вы уверены, что хотите стереть эту анкету?\nЭто действие не сможет быть обращено.',
	5=> 'Вы уверены, что хотите стереть эту новость?\nЭто действие не сможет быть обращено.',
	6=> 'Вы уверены, что хотите стереть эту историю?\nЭто действие не сможет быть обращено.',
	7=> 'Вы уверены, что хотите стереть эту статью?\nЭто действие не сможет быть обращено.',
	8=> 'Вы уверены, что хотите стереть этот опрос?\nЭто действие не сможет быть обращено.',
	9=> 'Вы уверены, что хотите стереть вариант этого опроса?\nЭто действие не сможет быть обращено.',
	10=> 'Вы уверены, что хотите стереть этот баннер?\nЭто действие не сможет быть обращено.',
	11=> 'Вы уверены, что хотите стереть этого админа?\nЭто действие не сможет быть обращено.',
/* Added in RC6 */
	12=>'Вы уверены, что хотите стереть эту страну?',
	13=>'Вы уверены, что хотите стереть эту область?',
	14=>'Вы уверены, что хотите стереть эти страны?',
	15=>'Вы уверены, что хотите стереть эти области?',
	16=>'При расширенном поиске должен быть задан заголовок расширенного поиска.',
	17 => 'В случае интервала имен пользователей должны быть заданы начальное и конечное.',
	18 => 'Вы уверены, что хотите стереть эти анкеты?\nЭто действие не сможет быть обращено.',
	);

// Don't use double qoutes(") in the item's text
$lang['signup_js_errors'] = array(
	'username_noblank' => 'Пожалуйста введите имя пользователя.' ,
	'password_noblank' => 'Пожалуйста введите пароль.',
	'old_password_noblank' => 'Старый пароль должен быть указан.',
	'new_password_noblank' => 'Новый пароль должен быть указан.',
	'con_password_noblank' => 'Подтверждение нового пароля должно быть указано.',
	'firstname_noblank' => 'Имя должно быть указано.',
	'name_noblank' => 'Пожалуйста, введите Ваше имя.',
	'lastname_noblank' => 'Фамилия должна быть указана.',
	'e-mail_noblank' => 'e-mail адрес должен быть указан.',
	'city_noblank' => 'Город должен быть указан.',
	'zip_noblank' => 'Почтовый индекс должен быть указан.',
	'address1_noblank' => 'Адрес (по крайней мере один) должен быть указан.',
	'sectionname_noblank' => 'Пожалуйста, введите имя этой секции.',
	'sendname_noblank' => 'Пожалуйста, введите имя посылающего.',
	'comments_noblank' => 'Пожалуйста, введите комментарии, которые Вы хотели послать.',
	'question_noblank' => 'Пожалуйста, введите вопрос.',
	'extsearchhead_noblank' => 'Пожалуйста, введите заголовок расширенного поиска.',

	'username_charset' => 'В имени пользователя (username) допускаются только латинские буквы, цифры и знак подчеркивания.',
	'password_charset' => 'В пароле допускаются только буквы, цифры и знак подчеркивания.',
	'firstname_charset' => 'В имени допускаются только буквы.',
	'lastname_charset' => 'В фамилии допускаются только буквы.',
	'city_charset' => 'Имя города должно быть на букву.',
	'zip_charset' => 'В почтовом индексе допускаются только цифры.',
	'address_charset' => 'Пожалуйста, введите правильный адрес.',
	'sectionname_charset' => 'В имени секции допускаются только буквы.',
	'sendname_charset' => 'В имени посылающего допускаются только буквы.',
	'name_charset' => 'Пожалуйста, для имени используйте только буквы.',
	'maxlength_charset' => 'Пожалуйста, введите число - для максимальной длины.',

	'e-mail_notvalid' => 'Адрес почты неправильный.',
	'password_nomatch' => 'Пароли не совпадают.',
	'password_outrange' => 'Пароль должен быть в длину в указанном диапазоне.',
	'username_outrange' => 'Имя пользователя должно быть не короче и не длиннее, чем указано.',
	'username_start_alpha' => 'Имя пользователя должно начинаться с буквы.',
	'ccowner_noblank' => 'Владелец кредитной карты должен быть указан.',
	'ccnumber_noblank' => 'Номер кредитной карты должен быть указан.',
	'cvvnumber_noblank' => 'Номер проверки кредитной карты (CVV и т.п.) должен быть указан.',
	'select_payment' => 'Пожалуйста, укажите сначала способ оплаты.',
	);

$lang['letter_errormsgs'] = array(
		0 => 'Ваш пароль отослан Вам по почте. Пожалуйста, проверьте Ваш e-mail.',
		1 => 'Пожалуйста, укажите адрес e-mail который Вы использовали при регистрации.',
		2 => 'Шаблон письма для случая утерянного пароля не найден. Пожалуйста, свяжитесь с администратором.',
		4 => 'Возникла проблема при посылке e-mail сообщения. Пожалуйста, свяжитесь с администратором.',
		5 => 'Вы не являетесь зарегистрированным пользователем сайта ' . stripslashes(SITENAME) . '.<br/>Пожалуйста, укажите адрес e-mail который Вы использовали при регистрации.'
	);

$lang['taf_errormsgs'] = array(
		0 => 'Приглашение послано.',
		'sendername_noblank' => 'Пожалуйста, введите Ваше имя.',
		'sendere-mail_noblank' => 'Пожалуйста, введите Ваш e-mail адрес.',
		'recipiente-mail_noblank' => 'Пожалуйста, введите e-mail получателя.',
		'sendername_charset' => 'Пожалуйста, введите только буквы в Вашем имени.',
		'sendere-mail_charset' => 'Пожалуйста, введите правильный e-mail.',
		'recipiente-mail_charset' => 'Пожалуйста, введите правильный e-mail получателя.',
		2 => 'Шаблон письма для случая пригласить друга не найден. Пожалуйста, свяжитесь с администратором.',
		3 => 'Возникла проблема при посылке приглашения. Пожалуйста, свяжитесь с администратором.',
	);
$lang['pages_errormsgs'] = array( '',
	1 => 'Заголовок страницы отсуствует.',
	2 => 'Ключ страницы отсуствует.',
	3 => 'Текст страницы отсуствует.',
	4 => 'Такой ключ страницы уже есть. Пожалуйста, выберите другой ключ.',
	);

$lang['artile_error'] = array(
	1 => 'Заголовок статьи - обязательное для заполнения поле.',
	2 => 'Текст статьи - обязательное для заполнения поле.',
	3 => 'Дата статьи - обязательное для заполнения поле.'
);
$lang['story_error'] = array(
	1 => 'Заголовок истории - обязательное для заполнения поле.',
	2 => 'Текст  истории - обязательное для заполнения поле.',
	3 => 'Дата истории - обязательное для заполнения поле.',
	4 => 'Автор истории - обязательное для заполнения поле.'
);
$lang['news_error'] = array(
	1 => 'Заголовок новости - обязательное для заполнения поле.',
	2 => 'Текст новости - обязательное для заполнения поле.',
	3 => 'Дата новости - обязательное для заполнения поле.'
);

$lang['mship_errors'] = array (
	1=> 'Имя - обязательное для заполнения поле.',
	2=> 'Цена - обязательное для заполнения поле.',
	3=> 'Валюта - обязательное для заполнения поле.',
	4 => 'Способ оплаты "отсутсвует" может быть выставлено только когда уровень членства меняется на "Бесплатный".'
);
$lang['admin_error_msgs'] = array (
	'',
	'Секция - обязательное для заполнения поле.',
	'Пожалуйста, заполните все требуемые поля.'
	);
$lang['admin_error'] = array(
	'',
	1 => 'Username админа не может быть пустым.',
	2 => 'Пароль админа не может быть пустым.',
	3 => 'Полное имя админа не может быть пустым.',
	4 => 'Старый пароль не может быть пустым.',
	5 => 'Новый пароль не может быть пустым.',
	6 => 'Подтверждение нового пароля не может быть пустым.',
	7 => 'Новый пароль и его подтверджение не совпадают.',
	8 => 'Старый пароль, который Вы ввели - неверен. Пожалуйста, попробуйте снова.',
	9 => 'Указанное username уже занято. Пожалуйста, выберите другое.'
);

$lang['banner_error_msgs'] = array( '',
	1 => 'Поле Баннер не может быть оставлено пустым.',
	2 => 'Поле URL ссылки не может быть оставлено пустым.',
	3 => 'Поле Tooltip не может быть оставлено пустым.',
	4 => 'Допускаются только .jpg баннеры.'
);
$lang['poll_error'] = array(
	1 => 'Поле Опрос не может быть пустым.',
	2 => 'Поле Дата опроса не может быть пустым.',
	3 => 'Поле Вариант не может быть пустым.',
	'txtpoll_noblank'  => 'Поле Опрос - обязательно для заполнения.',
	'txtpollopt_noblank'  => 'Поле Вариант опроса - обязательно для заполнения.'
	);

$lang['copyrt_url']='http://www.tufat.com/osdate.php';

$lang['status_disp'] = array(
	'Pending' => 'Ждущие подтверждения',
	'Active' => 'Активные',
	'Reject' => 'Отклоненные',
	'Suspend' => 'Приостановленные',
	);

$lang['mysettings'] = 'Мои настройки';
$lang['user_lists'] = 'Папки';
$lang['login_settings'] = 'Логин, пароль';
$lang['no_pics'] = 'Нет фотографий';
$lang['my_page'] = 'Моя страница';
$lang['write_new_msg'] = 'Написать новое сообщение';
$lang['view_winkslist'] = 'Просмотреть подмигивания';


$lang['datetime_month'] = array(
	1=>'Январь',
	2=>'Февраль',
	3=>'Март',
	4=>'Апрель',
	5=>'Май',
	6=>'Июнь',
	7=>'Июль',
	8=>'Август',
	9=>'Сентабрь',
	10=>'Октябрь',
	11=>'Ноябрь',
	12=>'Декабрь'
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