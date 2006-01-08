namespace greekconverter
{
	using System;
	
	/// <summary> This class contains symbolic constants for Unicode characters.
	/// </summary>
	public class UC
	{
		// legacy constants
		// boundaries or character ranges; isn't there a class Char.Unicode or the like?:
		internal const char USASCII_UPPER_BOUND = '\u0079'; // 127
		internal const char EXTASCII_UPPER_BOUND = '\u00FF'; // 255
		internal const char STDGRK_LOWER_BOUND = '\u0370';
		internal const char STDGRK_UPPER_BOUND = '\u03FF';
		internal const char EXTGRK_LOWER_BOUND = '\u1F00';
		internal const char EXTGRK_UPPER_BOUND = '\u1FFF';
		// end of legacy constants
		
		//
		// The Latin-1 Unicode block contains some characters that can be used in Greek:
		// 003B SEMICOLON    = 037E GREEK_QUESTION_MARK
		// 0060 GRAVE_ACCENT = 1FEF VARIA (spacing)
		// 00B4 ACUTE_ACCENT = 1FFD OXIA (spacing)
		// 00B7 MIDDLE_DOT   = 0387 ANO_TELEIA
		
		//
		// C0 Controls and Basic Latin (US-ASCII)
		//
		// controls are prefixed with CTRL_, except the white space characters 0009-000D and 0020
		//
		internal const char CTRL_NULL = '\u0000';
		internal const char CTRL_START_OF_HEADING = '\u0001';
		internal const char CTRL_START_OF_TEXT = '\u0002';
		internal const char CTRL_END_OF_TEXT = '\u0003';
		internal const char CTRL_END_OF_TRANSMISSION = '\u0004';
		internal const char CTRL_ENQUIRY = '\u0005';
		internal const char CTRL_ACKNOWLEDGE = '\u0006';
		internal const char CTRL_BELL = '\u0007';
		internal const char CTRL_BACKSPACE = '\u0008';
		// some white space characters need special treatment:
		internal const char HORIZONTAL_TABULATION = '\u0009';
		internal const char LINE_FEED = '\n'; // u000A is rejected by the compiler
		internal const char VERTICAL_TABULATION = '\u000B';
		internal const char FORM_FEED = '\u000C';
		internal const char CARRIAGE_RETURN = '\r'; // u000D is rejected by the compiler;
		//
		internal const char CTRL_SHIFT_OUT = '\u000E';
		internal const char CTRL_SHIFT_IN = '\u000F';
		internal const char CTRL_DATA_LINK_ESCAPE = '\u0010';
		internal const char CTRL_DEVICE_CONTROL_ONE = '\u0011';
		internal const char CTRL_DEVICE_CONTROL_TWO = '\u0012';
		internal const char CTRL_DEVICE_CONTROL_THREE = '\u0013';
		internal const char CTRL_DEVICE_CONTROL_FOUR = '\u0014';
		internal const char CTRL_NEGATIVE_ACKNOWLEDGE = '\u0015';
		internal const char CTRL_SYNCHRONOUS_IDLE = '\u0016';
		internal const char CTRL_END_OF_TRANSMISSION_BLOCK = '\u0017';
		internal const char CTRL_CANCEL = '\u0018';
		internal const char CTRL_END_OF_MEDIUM = '\u0019';
		internal const char CTRL_SUBSTITUTE = '\u001A';
		internal const char CTRL_ESCAPE = '\u001B';
		internal const char CTRL_FILE_SEPARATOR = '\u001C';
		internal const char CTRL_GROUP_SEPARATOR = '\u001D';
		internal const char CTRL_RECORD_SEPARATOR = '\u001E';
		internal const char CTRL_UNIT_SEPARATOR = '\u001F';
		internal const char SPACE = ' '; // u0020 is rejected by the compiler;
		internal const char EXCLAMATION_MARK = '\u0021';
		internal const char QUOTATION_MARK = '\';
		internal const char NUMBER_SIGN = '\u0023'; // hash, crosshatch: #
		internal const char DOLLAR_SIGN = '\u0024';
		internal const char PERCENT_SIGN = '\u0025';
		internal const char AMPERSAND = '\u0026'; // ligature from Latin ET "and"
		internal const char APOSTROPHE = '\''; // u0027 is rejected by the compiler
		internal const char LEFT_PARENTHESIS = '\u0028';
		internal const char RIGHT_PARENTHESIS = '\u0028';
		internal const char ASTERISK = '\u002A'; // star: *
		internal const char PLUS_SIGN = '\u002B';
		internal const char COMMA = '\u002C';
		internal const char HYPHEN_MINUS = '\u002D';
		internal const char PERIOD = '\u002E';
		internal const char SLASH = '\u002F';
		internal const char DIGIT_ZERO = '\u0030';
		internal const char DIGIT_ONE = '\u0031';
		internal const char DIGIT_TWO = '\u0032';
		internal const char DIGIT_THREE = '\u0033';
		internal const char DIGIT_FOUR = '\u0034';
		internal const char DIGIT_FIVE = '\u0035';
		internal const char DIGIT_SIX = '\u0036';
		internal const char DIGIT_SEVEN = '\u0037';
		internal const char DIGIT_EIGHT = '\u0038';
		internal const char DIGIT_NINE = '\u0039';
		internal const char COLON = '\u003A'; // :
		internal const char SEMICOLON = '\u003B'; // ; id. to 037E GREEK_QUESTION_MARK
		internal const char LESS_THAN_SIGN = '\u003C';
		internal const char EQUALS_SIGN = '\u003D';
		internal const char GREATER_THAN_SIGN = '\u003E';
		internal const char QUESTION_MARK = '\u003F';
		internal const char COMMERCIAL_AT = '\u0040'; // @
		internal const char CAPITAL_A = '\u0041';
		internal const char CAPITAL_B = '\u0042';
		internal const char CAPITAL_C = '\u0043';
		internal const char CAPITAL_D = '\u0044';
		internal const char CAPITAL_E = '\u0045';
		internal const char CAPITAL_F = '\u0046';
		internal const char CAPITAL_G = '\u0047';
		internal const char CAPITAL_H = '\u0048';
		internal const char CAPITAL_I = '\u0049';
		internal const char CAPITAL_J = '\u004A';
		internal const char CAPITAL_K = '\u004B';
		internal const char CAPITAL_L = '\u004C';
		internal const char CAPITAL_M = '\u004D';
		internal const char CAPITAL_N = '\u004E';
		internal const char CAPITAL_O = '\u004F';
		internal const char CAPITAL_P = '\u0050';
		internal const char CAPITAL_Q = '\u0051';
		internal const char CAPITAL_R = '\u0052';
		internal const char CAPITAL_S = '\u0053';
		internal const char CAPITAL_T = '\u0054';
		internal const char CAPITAL_U = '\u0055';
		internal const char CAPITAL_V = '\u0056';
		internal const char CAPITAL_W = '\u0057';
		internal const char CAPITAL_X = '\u0058';
		internal const char CAPITAL_Y = '\u0059';
		internal const char CAPITAL_Z = '\u005A';
		internal const char LEFT_SQUARE_BRACKET = '\u005B';
		internal const char BACKSLASH = '\\'; // u005C is rejected by the compiler
		internal const char RIGHT_SQUARE_BRACKET = '\u005D';
		internal const char CIRCUMFLEX_ACCENT = '\u005E';
		internal const char UNDERSCORE = '\u005F';
		internal const char GRAVE_ACCENT = '\u0060'; // id. to 1FEF VARIA (spacing)
		internal const char SMALL_A = '\u0061';
		internal const char SMALL_B = '\u0062';
		internal const char SMALL_C = '\u0063';
		internal const char SMALL_D = '\u0064';
		internal const char SMALL_E = '\u0065';
		internal const char SMALL_F = '\u0066';
		internal const char SMALL_G = '\u0067';
		internal const char SMALL_H = '\u0068';
		internal const char SMALL_I = '\u0069';
		internal const char SMALL_J = '\u006A';
		internal const char SMALL_K = '\u006B';
		internal const char SMALL_L = '\u006C';
		internal const char SMALL_M = '\u006D';
		internal const char SMALL_N = '\u006E';
		internal const char SMALL_O = '\u006F';
		internal const char SMALL_P = '\u0070';
		internal const char SMALL_Q = '\u0071';
		internal const char SMALL_R = '\u0072';
		internal const char SMALL_S = '\u0073';
		internal const char SMALL_T = '\u0074';
		internal const char SMALL_U = '\u0075';
		internal const char SMALL_V = '\u0076';
		internal const char SMALL_W = '\u0077';
		internal const char SMALL_X = '\u0078';
		internal const char SMALL_Y = '\u0079';
		internal const char SMALL_Z = '\u007A';
		internal const char LEFT_CURLY_BRACKET = '\u007B';
		internal const char VERTICAL_BAR = '\u007C';
		internal const char RIGHT_CURLY_BRACKET = '\u007D';
		internal const char TILDE = '\u007E';
		internal const char CTRL_DELETE = '\u007F';
		//
		// C1 Controls and Latin-1 Supplement
		//
		internal const char CTRL_0080 = '\u0080';
		internal const char CTRL_0081 = '\u0081';
		internal const char CTRL_BREAK_PERMITTED_HERE = '\u0082';
		internal const char CTRL_NO_BREAK_HERE = '\u0083';
		internal const char CTRL_0084 = '\u0084';
		internal const char CTRL_NEXT_LINE = '\u0085';
		internal const char CTRL_START_OF_SELECTED_AREA = '\u0086';
		internal const char CTRL_END_OF_SELECTED_AREA = '\u0087';
		internal const char CTRL_CHARACTER_TABULATION_SET = '\u0088';
		internal const char CTRL_CHARACTER_TABULATION_WITH_JUSTIFICATION = '\u0089';
		internal const char CTRL_LINE_TABULATION_SET = '\u008A';
		internal const char CTRL_PARTIAL_LINE_DOWN = '\u008B';
		internal const char CTRL_PARTIAL_LINE_UP = '\u008C';
		internal const char CTRL_REVERSE_LINE_FEED = '\u008D';
		internal const char CTRL_SINGLE_SHIFT_TWO = '\u008E';
		internal const char CTRL_SINGLE_SHIFT_THREE = '\u008F';
		internal const char CTRL_DEVICE_CONTROL_STRING = '\u0090';
		internal const char CTRL_PRIVATE_USE_ONE = '\u0091';
		internal const char CTRL_PRIVATE_USE_TWO = '\u0092';
		internal const char CTRL_SET_TRANSMIT_STATE = '\u0093';
		internal const char CTRL_CANCEL_CHARACTER = '\u0094';
		internal const char CTRL_MESSAGE_WAITING = '\u0095';
		internal const char CTRL_START_OF_GUARDED_AREA = '\u0096';
		internal const char CTRL_END_OF_GUARDED_AREA = '\u0096';
		internal const char CTRL_START_OF_STRING = '\u0098';
		internal const char CTRL_0099 = '\u0099';
		internal const char CTRL_SINGLE_CHARACTER_INTRODUCER = '\u009A';
		internal const char CTRL_CONTROL_SEQUENCE_INTRODUCER = '\u009B';
		internal const char CTRL_STRING_TERMINATOR = '\u009C';
		internal const char CTRL_OPERATING_SYSTEM_COMMAND = '\u009D';
		internal const char CTRL_PRIVACY_MESSAGE = '\u009E';
		internal const char CTRL_APPLICATION_PROGRAM_COMMAND = '\u009F';
		internal const char NO_BREAK_SPACE = '\u00A0';
		internal const char INVERTED_EXCLAMATION_MARK = '\u00A1';
		internal const char CENT_SIGN = '\u00A2';
		internal const char POUND_SIGN = '\u00A3';
		internal const char CURRENCY_SIGN = '\u00A4';
		internal const char YEN_SIGN = '\u00A5'; // why is that within Latin-1?
		internal const char BROKEN_VERTICAL_BAR = '\u00A6';
		internal const char SECTION_SIGN = '\u00A7'; // paragraph sign: §
		internal const char DIAERESIS = '\u00A8'; // umlaut dots
		internal const char COPYRIGHT_SIGN = '\u00A9';
		internal const char FEMININE_ORDINAL_INDICATOR = '\u00AA';
		internal const char LEFT_POINTING_GUILLEMET = '\u00AB';
		internal const char NOT_SIGN = '\u00AC';
		internal const char CTRL_SOFT_HYPHEN = '\u00AD';
		internal const char REGISTERED_SIGN = '\u00AE';
		internal const char MACRON = '\u00AF'; // spacing
		internal const char DEGREE_SIGN = '\u00B0';
		internal const char PLUS_MINUS_SIGN = '\u00B1';
		internal const char SUPERSCRIPT_TWO = '\u00B2';
		internal const char SUPERSCRIPT_THREE = '\u00B3';
		internal const char ACUTE_ACCENT = '\u00B4'; // id. to 1FFD OXIA (spacing)
		internal const char MICRO_SIGN = '\u00B5';
		internal const char PILCROW_SIGN = '\u00B6'; // what WinWord uses to denote end of paragraph
		internal const char MIDDLE_DOT = '\u00B7'; // id. to 0387 ANO_TELEIA
		internal const char CEDILLA = '\u00B8';
		internal const char SUPERSCRIPT_ONE = '\u00B9';
		internal const char MASCULINE_ORDINAL_INDICATOR = '\u00BA';
		internal const char RIGHT_POINTING_GUILLEMET = '\u00BB';
		internal const char VULGAR_FRACTION_ONE_QUARTER = '\u00BC';
		internal const char VULGAR_FRACTION_ONE_HALF = '\u00BD';
		internal const char VULGAR_FRACTION_THREE_QUARTERS = '\u00BE';
		internal const char INVERTED_QUESTION_MARK = '\u00BF';
		internal const char CAPITAL_A_GRAVE = '\u00C0';
		internal const char CAPITAL_A_ACUTE = '\u00C1';
		internal const char CAPITAL_A_CIRCUMFLEX = '\u00C2';
		internal const char CAPITAL_A_TILDE = '\u00C3';
		internal const char CAPITAL_A_DIAERESIS = '\u00C4'; // umlaut A
		internal const char CAPITAL_A_RING_ABOVE = '\u00C5'; // angstrom sign
		internal const char CAPITAL_AE = '\u00C6';
		internal const char CAPITAL_C_CEDILLA = '\u00C7';
		internal const char CAPITAL_E_GRAVE = '\u00C8';
		internal const char CAPITAL_E_ACUTE = '\u00C9';
		internal const char CAPITAL_E_CIRCUMFLEX = '\u00CA';
		internal const char CAPITAL_E_DIAERESIS = '\u00CB';
		internal const char CAPITAL_I_GRAVE = '\u00CC';
		internal const char CAPITAL_I_ACUTE = '\u00CD';
		internal const char CAPITAL_I_CIRCUMFLEX = '\u00CE';
		internal const char CAPITAL_I_DIAERESIS = '\u00CF';
		internal const char CAPITAL_ETH = '\u00D0';
		internal const char CAPITAL_N_TILDE = '\u00D1';
		internal const char CAPITAL_O_GRAVE = '\u00D2';
		internal const char CAPITAL_O_ACUTE = '\u00D3';
		internal const char CAPITAL_O_CIRCUMFLEX = '\u00D4';
		internal const char CAPITAL_O_TILDE = '\u00D5';
		internal const char CAPITAL_O_DIAERESIS = '\u00D6';
		internal const char MULTIPLICATION_SIGN = '\u00D7';
		internal const char CAPITAL_O_STROKE = '\u00D8';
		internal const char CAPITAL_U_GRAVE = '\u00D9';
		internal const char CAPITAL_U_ACUTE = '\u00DA';
		internal const char CAPITAL_U_CIRCUMFLEX = '\u00DB';
		internal const char CAPITAL_U_DIAERESIS = '\u00DC';
		internal const char CAPITAL_Y_ACUTE = '\u00DD';
		internal const char CAPITAL_THORN = '\u00DE';
		internal const char SMALL_SHARP_S = '\u00DF'; // German sz-ligature
		internal const char SMALL_A_GRAVE = '\u00E0';
		internal const char SMALL_A_ACUTE = '\u00E1';
		internal const char SMALL_A_CIRCUMFLEX = '\u00E2';
		internal const char SMALL_A_TILDE = '\u00E3';
		internal const char SMALL_A_DIAERESIS = '\u00E4';
		internal const char SMALL_A_RING_ABOVE = '\u00E5';
		internal const char SMALL_AE = '\u00E6';
		internal const char SMALL_C_CEDILLA = '\u00E7';
		internal const char SMALL_E_GRAVE = '\u00E8';
		internal const char SMALL_E_ACUTE = '\u00E9';
		internal const char SMALL_E_CIRCUMFLEX = '\u00EA';
		internal const char SMALL_E_DIAERESIS = '\u00EB';
		internal const char SMALL_I_GRAVE = '\u00EC';
		internal const char SMALL_I_ACUTE = '\u00ED';
		internal const char SMALL_I_CIRCUMFLEX = '\u00EE';
		internal const char SMALL_I_DIAERESIS = '\u00EF';
		internal const char SMALL_ETH = '\u00F0';
		internal const char SMALL_N_TILDE = '\u00F1';
		internal const char SMALL_O_GRAVE = '\u00F2';
		internal const char SMALL_O_ACUTE = '\u00F3';
		internal const char SMALL_O_CICRUMFLEX = '\u00F4';
		internal const char SMALL_O_TILDE = '\u00F5';
		internal const char SMALL_O_DIAERESIS = '\u00F6';
		internal const char DIVISION_SIGN = '\u00F7';
		internal const char SMALL_O_STROKE = '\u00F8';
		internal const char SMALL_U_GRAVE = '\u00F9';
		internal const char SMALL_U_ACUTE = '\u00FA';
		internal const char SMALL_U_CIRCUMFLEX = '\u00FB';
		internal const char SMALL_U_DIAERESIS = '\u00FC';
		internal const char SMALL_Y_ACUTE = '\u00FD';
		internal const char SMALL_THORN = '\u00FE';
		internal const char SMALL_Y_DIAERESIS = '\u00FF';
		//
		// Combining Diacritical Marks
		//
		internal const char COMBINING_GRAVE_ACCENT = '\u0300';
		internal const char COMBINING_ACUTE_ACCENT = '\u0301';
		internal const char COMBINING_CIRCUMFLEX_ACCENT = '\u0302';
		internal const char COMBINING_TILDE = '\u0303';
		internal const char COMBINING_MACRON = '\u0304';
		internal const char COMBINING_OVERLINE = '\u0305';
		internal const char COMBINING_BREVE = '\u0306';
		internal const char COMBINING_DIAERESIS = '\u0308';
		internal const char COMBINING_RING_ABOVE = '\u030A';
		internal const char COMBINING_COMMA_ABOVE = '\u0313'; // = PSILI
		internal const char COMBINING_REVERSED_COMMA_ABOVE = '\u0314'; // = DASIA
		internal const char COMBINING_DOT_BELOW = '\u0323';
		internal const char COMBINING_CEDILLA = ''; ;
 
		static final char COMBINING_PERISPOMENI = 0342;
		internal const char COMBINING_KORONIS = '\u0343'; // id. to 0313 COMBINING_COMMA_ABOVE
		internal const char COMBINING_DIALYTIKA_TONOS = '\u0344'; // "use of this char. is discouraged" = 0308+0301
		internal const char COMBINING_YPOGEGRAMMENI = '\u0345';
		//
		// Greek and Coptic (Range: U+0370 to U+03FF)
		//
		// Based on ISO 8859-7
		internal const char NUMERAL_SIGN = '\u0374';
		internal const char LOWER_NUMERAL_SIGN = '\u0375';
		internal const char YPOGEGRAMMENI = '\u037A';
		internal const char GREEK_QUESTION_MARK = '\u037E';
		internal const char TONOS = '\u0384';
		internal const char DIALYTIKA_TONOS = '\u0385';
		internal const char CAPITAL_ALPHA_TONOS = '\u0386';
		internal const char ANO_TELEIA = '\u0387';
		internal const char CAPITAL_EPSILON_TONOS = '\u0388';
		internal const char CAPITAL_ETA_TONOS = '\u0389';
		internal const char CAPITAL_IOTA_TONOS = '\u038A';
		internal const char CAPITAL_OMICRON_TONOS = '\u038C';
		internal const char CAPITAL_UPSILON_TONOS = '\u038E';
		internal const char CAPITAL_OMEGA_TONOS = '\u038F';
		internal const char IOTA_DIALYTIKA_TONOS = '\u0390';
		internal const char CAPITAL_ALPHA = '\u0391';
		internal const char CAPITAL_BETA = '\u0392';
		internal const char CAPITAL_GAMMA = '\u0393';
		internal const char CAPITAL_DELTA = '\u0394';
		internal const char CAPITAL_EPSILON = '\u0395';
		internal const char CAPITAL_ZETA = '\u0396';
		internal const char CAPITAL_ETA = '\u0397';
		internal const char CAPITAL_THETA = '\u0398';
		internal const char CAPITAL_IOTA = '\u0399';
		internal const char CAPITAL_KAPPA = '\u039A';
		internal const char CAPITAL_LAMDA = '\u039B';
		internal const char CAPITAL_MU = '\u039C';
		internal const char CAPITAL_NU = '\u039D';
		internal const char CAPITAL_XI = '\u039E';
		internal const char CAPITAL_OMICRON = '\u039F';
		internal const char CAPITAL_PI = '\u03A0';
		internal const char CAPITAL_RHO = '\u03A1';
		internal const char CAPITAL_SIGMA = '\u03A3';
		internal const char CAPITAL_TAU = '\u03A4';
		internal const char CAPITAL_UPSILON = '\u03A5';
		internal const char CAPITAL_PHI = '\u03A6';
		internal const char CAPITAL_CHI = '\u03A7';
		internal const char CAPITAL_PSI = '\u03A8';
		internal const char CAPITAL_OMEGA = '\u03A9';
		internal const char CAPITAL_IOTA_DIALYTIKA = '\u03AA';
		internal const char CAPITAL_UPSILON_DIALYTIKA = '\u03AB';
		internal const char ALPHA_TONOS = '\u03AC';
		internal const char EPSILON_TONOS = '\u03AD';
		internal const char ETA_TONOS = '\u03AE';
		internal const char IOTA_TONOS = '\u03AF';
		internal const char UPSILON_DIALYTIKA_TONOS = '\u03B0';
		internal const char ALPHA = '\u03B1';
		internal const char BETA = '\u03B2';
		internal const char GAMMA = '\u03B3';
		internal const char DELTA = '\u03B4';
		internal const char EPSILON = '\u03B5';
		internal const char ZETA = '\u03B6';
		internal const char ETA = '\u03B7';
		internal const char THETA = '\u03B8';
		internal const char IOTA = '\u03B9';
		internal const char KAPPA = '\u03BA';
		internal const char LAMDA = '\u03BB';
		internal const char MU = '\u03BC';
		internal const char NU = '\u03BD';
		internal const char XI = '\u03BE';
		internal const char OMICRON = '\u03BF';
		internal const char PI = '\u03C0';
		internal const char RHO = '\u03C1';
		internal const char FINAL_SIGMA = '\u03C2';
		internal const char SIGMA = '\u03C3';
		internal const char TAU = '\u03C4';
		internal const char UPSILON = '\u03C5';
		internal const char PHI = '\u03C6';
		internal const char CHI = '\u03C7';
		internal const char PSI = '\u03C8';
		internal const char OMEGA = '\u03C9';
		internal const char IOTA_DIALYTIKA = '\u03CA';
		internal const char UPSILON_DIALYTIKA = '\u03CB';
		internal const char OMICRON_TONOS = '\u03CC';
		internal const char UPSILON_TONOS = '\u03CD';
		internal const char OMEGA_TONOS = '\u03CE';
		// Variant letterforms
		internal const char BETA_SYMBOL = '\u03D0';
		internal const char THETA_SYMBOL = '\u03D1';
		internal const char UPSILON_HOOK_SYMBOL = '\u03D2';
		internal const char UPSILON_ACUTE_HOOK_SYMBOL = '\u03D3';
		internal const char UPSILON_DIAERESIS_HOOK_SYMBOL = '\u03D4';
		internal const char PHI_SYMBOL = '\u03D5';
		internal const char PI_SYMBOL = '\u03D6';
		internal const char KAI_SYMBOL = '\u03D7';
		// Archaic letters
		internal const char STIGMA = '\u03DA';
		internal const char SMALL_STIGMA = '\u03DB';
		internal const char DIGAMMA = '\u03DC';
		internal const char SMALL_DIGAMMA = '\u03DD';
		internal const char KOPPA = '\u03DE';
		internal const char SMALL_KOPPA = '\u03DF';
		internal const char SAMPI = '\u03E0';
		internal const char SMALL_SAMPI = '\u03E1';
		// Coptic-unique letters
		internal const char CAPITAL_SHEI = '\u03E2';
		internal const char SHEI = '\u03E3';
		internal const char CAPITAL_FEI = '\u03E4';
		internal const char FEI = '\u03E5';
		internal const char CAPITAL_KHEI = '\u03E6';
		internal const char KHEI = '\u03E7';
		internal const char CAPITAL_HORI = '\u03E8';
		internal const char HORI = '\u03E9';
		internal const char CAPITAL_GANGIA = '\u03EA';
		internal const char GANGIA = '\u03EB';
		internal const char CAPITAL_SHIMA = '\u03EC';
		internal const char SHIMA = '\u03ED';
		internal const char CAPITAL_DEI = '\u03EE';
		internal const char DEI = '\u03EF';
		// Greek symbols
		internal const char KAPPA_SYMBOL = '\u03F0';
		internal const char RHO_SYMBOL = '\u03F1';
		internal const char LUNATE_SIGMA_SYMBOL = '\u03F2'; // c-shaped Sigma
		// Additional letter
		internal const char YOT = '\u03F3'; // j
		// Greek symbols
		internal const char CAPITAL_THETA_SYMBOL = '\u03F4';
		internal const char LUNATE_EPSILON_SYMBOL = '\u03F5';
		//
		// Greek Extended (Range: U+1F00 to U+1FFF)
		//
		internal const char ALPHA_PSILI = '\u1F00';
		internal const char ALPHA_DASIA = '\u1F01';
		internal const char ALPHA_PSILI_VARIA = '\u1F02';
		internal const char ALPHA_DASIA_VARIA = '\u1F03';
		internal const char ALPHA_PSILI_OXIA = '\u1F04';
		internal const char ALPHA_DASIA_OXIA = '\u1F05';
		internal const char ALPHA_PSILI_PERISPOMENI = '\u1F06';
		internal const char ALPHA_DASIA_PERISPOMENI = '\u1F07';
		internal const char CAPITAL_ALPHA_PSILI = '\u1F08';
		internal const char CAPITAL_ALPHA_DASIA = '\u1F09';
		internal const char CAPITAL_ALPHA_PSILI_VARIA = '\u1F0A';
		internal const char CAPITAL_ALPHA_DASIA_VARIA = '\u1F0B';
		internal const char CAPITAL_ALPHA_PSILI_OXIA = '\u1F0C';
		internal const char CAPITAL_ALPHA_DASIA_OXIA = '\u1F0D';
		internal const char CAPITAL_ALPHA_PSILI_PERISPOMENI = '\u1F0E';
		internal const char CAPITAL_ALPHA_DASIA_PERISPOMENI = '\u1F0F';
		internal const char EPSILON_PSILI = '\u1F10';
		internal const char EPSILON_DASIA = '\u1F11';
		internal const char EPSILON_PSILI_VARIA = '\u1F12';
		internal const char EPSILON_DASIA_VARIA = '\u1F13';
		internal const char EPSILON_PSILI_OXIA = '\u1F14';
		internal const char EPSILON_DASIA_OXIA = '\u1F15';
		internal const char CAPITAL_EPSILON_PSILI = '\u1F18';
		internal const char CAPITAL_EPSILON_DASIA = '\u1F19';
		internal const char CAPITAL_EPSILON_PSILI_VARIA = '\u1F1A';
		internal const char CAPITAL_EPSILON_DASIA_VARIA = '\u1F1B';
		internal const char CAPITAL_EPSILON_PSILI_OXIA = '\u1F1C';
		internal const char CAPITAL_EPSILON_DASIA_OXIA = '\u1F1D';
		internal const char ETA_PSILI = '\u1F20';
		internal const char ETA_DASIA = '\u1F21';
		internal const char ETA_PSILI_VARIA = '\u1F22';
		internal const char ETA_DASIA_VARIA = '\u1F23';
		internal const char ETA_PSILI_OXIA = '\u1F24';
		internal const char ETA_DASIA_OXIA = '\u1F25';
		internal const char ETA_PSILI_PERISPOMENI = '\u1F26';
		internal const char ETA_DASIA_PERISPOMENI = ''; ;
 
		static final char CAPITAL_ETA_PSILI = 1F28;
		internal const char CAPITAL_ETA_DASIA = '\u1F29';
		internal const char CAPITAL_ETA_PSILI_VARIA = '\u1F2A';
		internal const char CAPITAL_ETA_DASIA_VARIA = '\u1F2B';
		internal const char CAPITAL_ETA_PSILI_OXIA = '\u1F2C';
		internal const char CAPITAL_ETA_DASIA_OXIA = '\u1F2D';
		internal const char CAPITAL_ETA_PSILI_PERISPOMENI = '\u1F2E';
		internal const char CAPITAL_ETA_DASIA_PERISPOMENI = '\u1F2F';
		internal const char IOTA_PSILI = '\u1F30';
		internal const char IOTA_DASIA = '\u1F31';
		internal const char IOTA_PSILI_VARIA = '\u1F32';
		internal const char IOTA_DASIA_VARIA = '\u1F33';
		internal const char IOTA_PSILI_OXIA = '\u1F34';
		internal const char IOTA_DASIA_OXIA = '\u1F35';
		internal const char IOTA_PSILI_PERISPOMENI = '\u1F36';
		internal const char IOTA_DASIA_PERISPOMENI = '\u1F37';
		internal const char CAPITAL_IOTA_PSILI = '\u1F38';
		internal const char CAPITAL_IOTA_DASIA = '\u1F39';
		internal const char CAPITAL_IOTA_PSILI_VARIA = '\u1F3A';
		internal const char CAPITAL_IOTA_DASIA_VARIA = '\u1F3B';
		internal const char CAPITAL_IOTA_PSILI_OXIA = '\u1F3C';
		internal const char CAPITAL_IOTA_DASIA_OXIA = '\u1F3D';
		internal const char CAPITAL_IOTA_PSILI_PERISPOMENI = '\u1F3E';
		internal const char CAPITAL_IOTA_DASIA_PERISPOMENI = '\u1F3F';
		internal const char OMICRON_PSILI = '\u1F40';
		internal const char OMICRON_DASIA = '\u1F41';
		internal const char OMICRON_PSILI_VARIA = '\u1F42';
		internal const char OMICRON_DASIA_VARIA = '\u1F43';
		internal const char OMICRON_PSILI_OXIA = '\u1F44';
		internal const char OMICRON_DASIA_OXIA = '\u1F45';
		internal const char CAPITAL_OMICRON_PSILI = '\u1F48';
		internal const char CAPITAL_OMICRON_DASIA = '\u1F49';
		internal const char CAPITAL_OMICRON_PSILI_VARIA = '\u1F4A';
		internal const char CAPITAL_OMICRON_DASIA_VARIA = '\u1F4B';
		internal const char CAPITAL_OMICRON_PSILI_OXIA = '\u1F4C';
		internal const char CAPITAL_OMICRON_DASIA_OXIA = '\u1F4D';
		internal const char UPSILON_PSILI = '\u1F50';
		internal const char UPSILON_DASIA = '\u1F51';
		internal const char UPSILON_PSILI_VARIA = '\u1F52';
		internal const char UPSILON_DASIA_VARIA = '\u1F53';
		internal const char UPSILON_PSILI_OXIA = '\u1F54';
		internal const char UPSILON_DASIA_OXIA = '\u1F55';
		internal const char UPSILON_PSILI_PERISPOMENI = '\u1F56';
		internal const char UPSILON_DASIA_PERISPOMENI = '\u1F57';
		internal const char CAPITAL_UPSILON_DASIA = '\u1F59';
		internal const char CAPITAL_UPSILON_DASIA_VARIA = '\u1F5B';
		internal const char CAPITAL_UPSILON_DASIA_OXIA = '\u1F5D';
		internal const char CAPITAL_UPSILON_DASIA_PERISPOMENI = '\u1F5F';
		internal const char OMEGA_PSILI = '\u1F60';
		internal const char OMEGA_DASIA = '\u1F61';
		internal const char OMEGA_PSILI_VARIA = '\u1F62';
		internal const char OMEGA_DASIA_VARIA = '\u1F63';
		internal const char OMEGA_PSILI_OXIA = '\u1F64';
		internal const char OMEGA_DASIA_OXIA = '\u1F65';
		internal const char OMEGA_PSILI_PERISPOMENI = '\u1F66';
		internal const char OMEGA_DASIA_PERISPOMENI = '\u1F67';
		internal const char CAPITAL_OMEGA_PSILI = '\u1F68';
		internal const char CAPITAL_OMEGA_DASIA = '\u1F69';
		internal const char CAPITAL_OMEGA_PSILI_VARIA = '\u1F6A';
		internal const char CAPITAL_OMEGA_DASIA_VARIA = '\u1F6B';
		internal const char CAPITAL_OMEGA_PSILI_OXIA = '\u1F6C';
		internal const char CAPITAL_OMEGA_DASIA_OXIA = '\u1F6D';
		internal const char CAPITAL_OMEGA_PSILI_PERISPOMENI = '\u1F6E';
		internal const char CAPITAL_OMEGA_DASIA_PERISPOMENI = '\u1F6F';
		internal const char ALPHA_VARIA = '\u1F70';
		internal const char ALPHA_OXIA = '\u1F71';
		internal const char EPSILON_VARIA = '\u1F72';
		internal const char EPSILON_OXIA = '\u1F73';
		internal const char ETA_VARIA = '\u1F74';
		internal const char ETA_OXIA = '\u1F75';
		internal const char IOTA_VARIA = '\u1F76';
		internal const char IOTA_OXIA = '\u1F77';
		internal const char OMICRON_VARIA = '\u1F78';
		internal const char OMICRON_OXIA = '\u1F79';
		internal const char UPSILON_VARIA = '\u1F7A';
		internal const char UPSILON_OXIA = '\u1F7B';
		internal const char OMEGA_VARIA = '\u1F7C';
		internal const char OMEGA_OXIA = '\u1F7D';
		internal const char ALPHA_PSILI_YPOGEGRAMMENI = '\u1F80';
		internal const char ALPHA_DASIA_YPOGEGRAMMENI = '\u1F81';
		internal const char ALPHA_PSILI_VARIA_YPOGEGRAMMENI = '\u1F82';
		internal const char ALPHA_DASIA_VARIA_YPOGEGRAMMENI = '\u1F83';
		internal const char ALPHA_PSILI_OXIA_YPOGEGRAMMENI = '\u1F84';
		internal const char ALPHA_DASIA_OXIA_YPOGEGRAMMENI = '\u1F85';
		internal const char ALPHA_PSILI_PERISPOMENI_YPOGEGRAMMENI = '\u1F86';
		internal const char ALPHA_DASIA_PERISPOMENI_YPOGEGRAMMENI = '\u1F87';
		internal const char CAPITAL_ALPHA_PSILI_PROSGEGRAMMENI = '\u1F88';
		internal const char CAPITAL_ALPHA_DASIA_PROSGEGRAMMENI = '\u1F89';
		internal const char CAPITAL_ALPHA_PSILI_VARIA_PROSGEGRAMMENI = '\u1F8A';
		internal const char CAPITAL_ALPHA_DASIA_VARIA_PROSGEGRAMMENI = '\u1F8B';
		internal const char CAPITAL_ALPHA_PSILI_OXIA_PROSGEGRAMMENI = '\u1F8C';
		internal const char CAPITAL_ALPHA_DASIA_OXIA_PROSGEGRAMMENI = '\u1F8D';
		internal const char CAPITAL_ALPHA_PSILI_PERISPOMENI_PROSGEGRAMMENI = '\u1F8E';
		internal const char CAPITAL_ALPHA_DASIA_PERISPOMENI_PROSGEGRAMMENI = '\u1F8F';
		internal const char ETA_PSILI_YPOGEGRAMMENI = '\u1F90';
		internal const char ETA_DASIA_YPOGEGRAMMENI = '\u1F91';
		internal const char ETA_PSILI_VARIA_YPOGEGRAMMENI = '\u1F92';
		internal const char ETA_DASIA_VARIA_YPOGEGRAMMENI = '\u1F93';
		internal const char ETA_PSILI_OXIA_YPOGEGRAMMENI = '\u1F94';
		internal const char ETA_DASIA_OXIA_YPOGEGRAMMENI = '\u1F95';
		internal const char ETA_PSILI_PERISPOMENI_YPOGEGRAMMENI = '\u1F96';
		internal const char ETA_DASIA_PERISPOMENI_YPOGEGRAMMENI = '\u1F97';
		internal const char CAPITAL_ETA_PSILI_PROSGEGRAMMENI = '\u1F98';
		internal const char CAPITAL_ETA_DASIA_PROSGEGRAMMENI = '\u1F99';
		internal const char CAPITAL_ETA_PSILI_VARIA_PROSGEGRAMMENI = '\u1F9A';
		internal const char CAPITAL_ETA_DASIA_VARIA_PROSGEGRAMMENI = '\u1F9B';
		internal const char CAPITAL_ETA_PSILI_OXIA_PROSGEGRAMMENI = '\u1F9C';
		internal const char CAPITAL_ETA_DASIA_OXIA_PROSGEGRAMMENI = '\u1F9D';
		internal const char CAPITAL_ETA_PSILI_PERISPOMENI_PROSGEGRAMMENI = '\u1F9E';
		internal const char CAPITAL_ETA_DASIA_PERISPOMENI_PROSGEGRAMMENI = '\u1F9F';
		internal const char OMEGA_PSILI_YPOGEGRAMMENI = '\u1FA0';
		internal const char OMEGA_DASIA_YPOGEGRAMMENI = '\u1FA1';
		internal const char OMEGA_PSILI_VARIA_YPOGEGRAMMENI = '\u1FA2';
		internal const char OMEGA_DASIA_VARIA_YPOGEGRAMMENI = '\u1FA3';
		internal const char OMEGA_PSILI_OXIA_YPOGEGRAMMENI = '\u1FA4';
		internal const char OMEGA_DASIA_OXIA_YPOGEGRAMMENI = '\u1FA5';
		internal const char OMEGA_PSILI_PERISPOMENI_YPOGEGRAMMENI = '\u1FA6';
		internal const char OMEGA_DASIA_PERISPOMENI_YPOGEGRAMMENI = '\u1FA7';
		internal const char CAPITAL_OMEGA_PSILI_PROSGEGRAMMENI = '\u1FA8';
		internal const char CAPITAL_OMEGA_DASIA_PROSGEGRAMMENI = '\u1FA9';
		internal const char CAPITAL_OMEGA_PSILI_VARIA_PROSGEGRAMMENI = '\u1FAA';
		internal const char CAPITAL_OMEGA_DASIA_VARIA_PROSGEGRAMMENI = '\u1FAB';
		internal const char CAPITAL_OMEGA_PSILI_OXIA_PROSGEGRAMMENI = '\u1FAC';
		internal const char CAPITAL_OMEGA_DASIA_OXIA_PROSGEGRAMMENI = '\u1FAD';
		internal const char CAPITAL_OMEGA_PSILI_PERISPOMENI_PROSGEGRAMMENI = '\u1FAE';
		internal const char CAPITAL_OMEGA_DASIA_PERISPOMENI_PROSGEGRAMMENI = '\u1FAF';
		internal const char ALPHA_VRACHY = '\u1FB0';
		internal const char ALPHA_MACRON = '\u1FB1';
		internal const char ALPHA_VARIA_YPOGEGRAMMENI = '\u1FB2';
		internal const char ALPHA_YPOGEGRAMMENI = '\u1FB3';
		internal const char ALPHA_OXIA_YPOGEGRAMMENI = '\u1FB4';
		internal const char ALPHA_PERISPOMENI = '\u1FB6';
		internal const char ALPHA_PERISPOMENI_YPOGEGRAMMENI = '\u1FB7';
		internal const char CAPITAL_ALPHA_VRACHY = '\u1FB8';
		internal const char CAPITAL_ALPHA_MACRON = '\u1FB9';
		internal const char CAPITAL_ALPHA_VARIA = '\u1FBA';
		internal const char CAPITAL_ALPHA_OXIA = '\u1FBB';
		internal const char CAPITAL_ALPHA_PROSGEGRAMMENI = '\u1FBC';
		internal const char KORONIS = '\u1FBD';
		internal const char PROSGEGRAMMENI = '\u1FBE';
		internal const char PSILI = '\u1FBF';
		internal const char PERISPOMENI = '\u1FC0';
		internal const char DIALYTIKA_PERISPOMENI = '\u1FC1';
		internal const char ETA_VARIA_YPOGEGRAMMENI = '\u1FC2';
		internal const char ETA_YPOGEGRAMMENI = '\u1FC3';
		internal const char ETA_OXIA_YPOGEGRAMMENI = '\u1FC4';
		internal const char ETA_PERISPOMENI = '\u1FC6';
		internal const char ETA_PERISPOMENI_YPOGEGRAMMENI = '\u1FC7';
		internal const char CAPITAL_EPSILON_VARIA = '\u1FC8';
		internal const char CAPITAL_EPSILON_OXIA = '\u1FC9';
		internal const char CAPITAL_ETA_VARIA = '\u1FCA';
		internal const char CAPITAL_ETA_OXIA = '\u1FCB';
		internal const char CAPITAL_ETA_PROSGEGRAMMENI = '\u1FCC';
		internal const char PSILI_VARIA = '\u1FCD';
		internal const char PSILI_OXIA = '\u1FCE';
		internal const char PSILI_PERISPOMENI = '\u1FCF';
		internal const char IOTA_VRACHY = '\u1FD0';
		internal const char IOTA_MACRON = '\u1FD1';
		internal const char IOTA_DIALYTIKA_VARIA = '\u1FD2';
		internal const char IOTA_DIALYTIKA_OXIA = '\u1FD3';
		internal const char IOTA_PERISPOMENI = '\u1FD6';
		internal const char IOTA_DIALYTIKA_PERISPOMENI = '\u1FD7';
		internal const char CAPITAL_IOTA_VRACHY = '\u1FD8';
		internal const char CAPITAL_IOTA_MACRON = '\u1FD9';
		internal const char CAPITAL_IOTA_VARIA = '\u1FDA';
		internal const char CAPITAL_IOTA_OXIA = '\u1FDB';
		internal const char DASIA_VARIA = '\u1FDD';
		internal const char DASIA_OXIA = '\u1FDE';
		internal const char DASIA_PERISPOMENI = '\u1FDF';
		internal const char UPSILON_VRACHY = '\u1FE0';
		internal const char UPSILON_MACRON = '\u1FE1';
		internal const char UPSILON_DIALYTIKA_VARIA = '\u1FE2';
		internal const char UPSILON_DIALYTIKA_OXIA = '\u1FE3';
		internal const char RHO_PSILI = '\u1FE4';
		internal const char RHO_DASIA = '\u1FE5';
		internal const char UPSILON_PERISPOMENI = '\u1FE6';
		internal const char UPSILON_DIALYTIKA_PERISPOMENI = '\u1FE7';
		internal const char CAPITAL_UPSILON_VRACHY = '\u1FE8';
		internal const char CAPITAL_UPSILON_MACRON = '\u1FE9';
		internal const char CAPITAL_UPSILON_VARIA = '\u1FEA';
		internal const char CAPITAL_UPSILON_OXIA = '\u1FEB';
		internal const char CAPITAL_RHO_DASIA = '\u1FEC';
		internal const char DIALYTIKA_VARIA = '\u1FED';
		internal const char DIALYTIKA_OXIA = '\u1FEE';
		internal const char VARIA = '\u1FEF';
		internal const char OMEGA_VARIA_YPOGEGRAMMENI = '\u1FF2';
		internal const char OMEGA_YPOGEGRAMMENI = '\u1FF3';
		internal const char OMEGA_OXIA_YPOGEGRAMMENI = '\u1FF4';
		internal const char OMEGA_PERISPOMENI = '\u1FF6';
		internal const char OMEGA_PERISPOMENI_YPOGEGRAMMENI = '\u1FF7';
		internal const char CAPITAL_OMICRON_VARIA = '\u1FF8';
		internal const char CAPITAL_OMICRON_OXIA = '\u1FF9';
		internal const char CAPITAL_OMEGA_VARIA = '\u1FFA';
		internal const char CAPITAL_OMEGA_OXIA = '\u1FFB';
		internal const char CAPITAL_OMEGA_PROSGEGRAMMENI = '\u1FFC';
		internal const char OXIA = '\u1FFD';
		internal const char DASIA = '\u1FFE';
		//
		// Decomposed Strings for precomposed Greek characters
		//
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_YPOGEGRAMMENI = " " + COMBINING_YPOGEGRAMMENI;
		internal const System.String NRM_QUESTION_MARK = ";";
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_TONOS = " " + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_DIALYTIKA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_DIALYTIKA_TONOS = " " + COMBINING_DIAERESIS + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_TONOS = "" + CAPITAL_ALPHA + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ANO_TELEIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ANO_TELEIA = "" + MIDDLE_DOT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_EPSILON_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_EPSILON_TONOS = "" + CAPITAL_EPSILON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_TONOS = "" + CAPITAL_ETA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_TONOS = "" + CAPITAL_IOTA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMICRON_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMICRON_TONOS = "" + CAPITAL_OMICRON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_TONOS = "" + CAPITAL_UPSILON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_TONOS = "" + CAPITAL_OMEGA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_DIALYTIKA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_DIALYTIKA_TONOS = "" + IOTA + COMBINING_DIAERESIS + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_DIALYTIKA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_DIALYTIKA = "" + CAPITAL_IOTA + COMBINING_DIAERESIS;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_DIALYTIKA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_DIALYTIKA = "" + CAPITAL_UPSILON + COMBINING_DIAERESIS;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_TONOS = "" + ALPHA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_EPSILON_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_EPSILON_TONOS = "" + EPSILON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_TONOS = "" + ETA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_TONOS = "" + IOTA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DIALYTIKA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DIALYTIKA_TONOS = "" + UPSILON + COMBINING_DIAERESIS + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_DIALYTIKA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_DIALYTIKA = "" + IOTA + COMBINING_DIAERESIS;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DIALYTIKA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DIALYTIKA = "" + UPSILON + COMBINING_DIAERESIS;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMICRON_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMICRON_TONOS = "" + OMICRON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_TONOS = "" + UPSILON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_TONOS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_TONOS = "" + OMEGA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_BETA_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_BETA_SYMBOL = "" + BETA;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_THETA_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_THETA_SYMBOL = "" + THETA;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_HOOK_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_HOOK_SYMBOL = "" + CAPITAL_UPSILON;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_ACUTE_HOOK_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_ACUTE_HOOK_SYMBOL = "" + CAPITAL_UPSILON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DIAERESIS_HOOK_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DIAERESIS_HOOK_SYMBOL = "" + CAPITAL_UPSILON + COMBINING_DIAERESIS;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_PHI_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_PHI_SYMBOL = "" + PHI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_PI_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_PI_SYMBOL = "" + PI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_KAPPA_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_KAPPA_SYMBOL = "" + KAPPA;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_RHO_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_RHO_SYMBOL = "" + RHO;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_THETA_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_THETA_SYMBOL = "" + CAPITAL_THETA;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_LUNATE_EPSILON_SYMBOL " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_LUNATE_EPSILON_SYMBOL = "" + EPSILON;
		
		// Greek extended
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PSILI = "" + ALPHA + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_DASIA = "" + ALPHA + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PSILI_VARIA = "" + ALPHA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_DASIA_VARIA = "" + ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PSILI_OXIA = "" + ALPHA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_DASIA_OXIA = "" + ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PSILI_PERISPOMENI = "" + ALPHA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_DASIA_PERISPOMENI = "" + ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_PSILI = "" + CAPITAL_ALPHA + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_DASIA = "" + CAPITAL_ALPHA + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_PSILI_VARIA = "" + CAPITAL_ALPHA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_DASIA_VARIA = "" + CAPITAL_ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_PSILI_OXIA = "" + CAPITAL_ALPHA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_DASIA_OXIA = "" + CAPITAL_ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_PSILI_PERISPOMENI = "" + CAPITAL_ALPHA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_DASIA_PERISPOMENI = "" + CAPITAL_ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_EPSILON_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_EPSILON_PSILI = "" + EPSILON + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_EPSILON_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_EPSILON_DASIA = "" + EPSILON + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_EPSILON_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_EPSILON_PSILI_VARIA = "" + EPSILON + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_EPSILON_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_EPSILON_DASIA_VARIA = "" + EPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_EPSILON_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_EPSILON_PSILI_OXIA = "" + EPSILON + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_EPSILON_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_EPSILON_DASIA_OXIA = "" + EPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_EPSILON_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_EPSILON_PSILI = "" + CAPITAL_EPSILON + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_EPSILON_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_EPSILON_DASIA = "" + CAPITAL_EPSILON + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_EPSILON_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_EPSILON_PSILI_VARIA = "" + CAPITAL_EPSILON + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_EPSILON_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_EPSILON_DASIA_VARIA = "" + CAPITAL_EPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_EPSILON_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_EPSILON_PSILI_OXIA = "" + CAPITAL_EPSILON + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_EPSILON_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_EPSILON_DASIA_OXIA = "" + CAPITAL_EPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PSILI = "" + ETA + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_DASIA = "" + ETA + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PSILI_VARIA = "" + ETA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_DASIA_VARIA = "" + ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PSILI_OXIA = "" + ETA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_DASIA_OXIA = "" + ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PSILI_PERISPOMENI = "" + ETA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_DASIA_PERISPOMENI = "" + ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_PSILI = "" + CAPITAL_ETA + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_DASIA = "" + CAPITAL_ETA + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_PSILI_VARIA = "" + CAPITAL_ETA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_DASIA_VARIA = "" + CAPITAL_ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_PSILI_OXIA = "" + CAPITAL_ETA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_DASIA_OXIA = "" + CAPITAL_ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_PSILI_PERISPOMENI = "" + CAPITAL_ETA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_DASIA_PERISPOMENI = "" + CAPITAL_ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_PSILI = "" + IOTA + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_DASIA = "" + IOTA + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_PSILI_VARIA = "" + IOTA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_DASIA_VARIA = "" + IOTA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_PSILI_OXIA = "" + IOTA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_DASIA_OXIA = "" + IOTA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_PSILI_PERISPOMENI = "" + IOTA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_DASIA_PERISPOMENI = "" + IOTA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_PSILI = "" + CAPITAL_IOTA + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_DASIA = "" + CAPITAL_IOTA + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_PSILI_VARIA = "" + CAPITAL_IOTA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_DASIA_VARIA = "" + CAPITAL_IOTA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_PSILI_OXIA = "" + CAPITAL_IOTA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_DASIA_OXIA = "" + CAPITAL_IOTA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_PSILI_PERISPOMENI = "" + CAPITAL_IOTA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_DASIA_PERISPOMENI = "" + CAPITAL_IOTA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMICRON_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMICRON_PSILI = "" + OMICRON + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMICRON_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMICRON_DASIA = "" + OMICRON + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMICRON_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMICRON_PSILI_VARIA = "" + OMICRON + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMICRON_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMICRON_DASIA_VARIA = "" + OMICRON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMICRON_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMICRON_PSILI_OXIA = "" + OMICRON + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMICRON_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMICRON_DASIA_OXIA = "" + OMICRON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMICRON_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMICRON_PSILI = "" + CAPITAL_OMICRON + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMICRON_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMICRON_DASIA = "" + CAPITAL_OMICRON + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMICRON_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMICRON_PSILI_VARIA = "" + CAPITAL_OMICRON + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMICRON_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMICRON_DASIA_VARIA = "" + CAPITAL_OMICRON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMICRON_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMICRON_PSILI_OXIA = "" + CAPITAL_OMICRON + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMICRON_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMICRON_DASIA_OXIA = "" + CAPITAL_OMICRON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_PSILI = "" + UPSILON + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DASIA = "" + UPSILON + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_PSILI_VARIA = "" + UPSILON + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DASIA_VARIA = "" + UPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_PSILI_OXIA = "" + UPSILON + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DASIA_OXIA = "" + UPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_PSILI_PERISPOMENI = "" + UPSILON + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DASIA_PERISPOMENI = "" + UPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_DASIA = "" + CAPITAL_UPSILON + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_DASIA_VARIA = "" + CAPITAL_UPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_DASIA_OXIA = "" + CAPITAL_UPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_DASIA_PERISPOMENI = "" + CAPITAL_UPSILON + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PSILI = "" + OMEGA + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_DASIA = "" + OMEGA + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PSILI_VARIA = "" + OMEGA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_DASIA_VARIA = "" + OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PSILI_OXIA = "" + OMEGA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_DASIA_OXIA = "" + OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PSILI_PERISPOMENI = "" + OMEGA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_DASIA_PERISPOMENI = "" + OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_PSILI = "" + CAPITAL_OMEGA + COMBINING_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_DASIA = "" + CAPITAL_OMEGA + COMBINING_REVERSED_COMMA_ABOVE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_PSILI_VARIA = "" + CAPITAL_OMEGA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_DASIA_VARIA = "" + CAPITAL_OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_PSILI_OXIA = "" + CAPITAL_OMEGA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_DASIA_OXIA = "" + CAPITAL_OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_PSILI_PERISPOMENI = "" + CAPITAL_OMEGA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_DASIA_PERISPOMENI = "" + CAPITAL_OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_VARIA = "" + ALPHA + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_OXIA = "" + ALPHA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_EPSILON_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_EPSILON_VARIA = "" + EPSILON + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_EPSILON_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_EPSILON_OXIA = "" + EPSILON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_VARIA = "" + ETA + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_OXIA = "" + ETA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_VARIA = "" + IOTA + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_OXIA = "" + IOTA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMICRON_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMICRON_VARIA = "" + OMICRON + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMICRON_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMICRON_OXIA = "" + OMICRON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_VARIA = "" + UPSILON + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_OXIA = "" + UPSILON + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_VARIA = "" + OMEGA + COMBINING_GRAVE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_OXIA = "" + OMEGA + COMBINING_ACUTE_ACCENT;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PSILI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PSILI_YPOGEGRAMMENI = "" + ALPHA + COMBINING_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_DASIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_DASIA_YPOGEGRAMMENI = "" + ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PSILI_VARIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PSILI_VARIA_YPOGEGRAMMENI = "" + ALPHA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_DASIA_VARIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_DASIA_VARIA_YPOGEGRAMMENI = "" + ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PSILI_OXIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PSILI_OXIA_YPOGEGRAMMENI = "" + ALPHA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_DASIA_OXIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_DASIA_OXIA_YPOGEGRAMMENI = "" + ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PSILI_PERISPOMENI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PSILI_PERISPOMENI_YPOGEGRAMMENI = "" + ALPHA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_DASIA_PERISPOMENI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_DASIA_PERISPOMENI_YPOGEGRAMMENI = "" + ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_PSILI_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_PSILI_PROSGEGRAMMENI = "" + CAPITAL_ALPHA + COMBINING_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_DASIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_DASIA_PROSGEGRAMMENI = "" + CAPITAL_ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_PSILI_VARIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_PSILI_VARIA_PROSGEGRAMMENI = "" + CAPITAL_ALPHA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_DASIA_VARIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_DASIA_VARIA_PROSGEGRAMMENI = "" + CAPITAL_ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_PSILI_OXIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_PSILI_OXIA_PROSGEGRAMMENI = "" + CAPITAL_ALPHA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_DASIA_OXIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_DASIA_OXIA_PROSGEGRAMMENI = "" + CAPITAL_ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_PSILI_PERISPOMENI_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_PSILI_PERISPOMENI_PROSGEGRAMMENI = "" + CAPITAL_ALPHA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_DASIA_PERISPOMENI_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_DASIA_PERISPOMENI_PROSGEGRAMMENI = "" + CAPITAL_ALPHA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PSILI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PSILI_YPOGEGRAMMENI = "" + ETA + COMBINING_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_DASIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_DASIA_YPOGEGRAMMENI = "" + ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PSILI_VARIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PSILI_VARIA_YPOGEGRAMMENI = "" + ETA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_DASIA_VARIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_DASIA_VARIA_YPOGEGRAMMENI = "" + ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PSILI_OXIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PSILI_OXIA_YPOGEGRAMMENI = "" + ETA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_DASIA_OXIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_DASIA_OXIA_YPOGEGRAMMENI = "" + ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PSILI_PERISPOMENI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PSILI_PERISPOMENI_YPOGEGRAMMENI = "" + ETA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_DASIA_PERISPOMENI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_DASIA_PERISPOMENI_YPOGEGRAMMENI = "" + ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_PSILI_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_PSILI_PROSGEGRAMMENI = "" + CAPITAL_ETA + COMBINING_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_DASIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_DASIA_PROSGEGRAMMENI = "" + CAPITAL_ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_PSILI_VARIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_PSILI_VARIA_PROSGEGRAMMENI = "" + CAPITAL_ETA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_DASIA_VARIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_DASIA_VARIA_PROSGEGRAMMENI = "" + CAPITAL_ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_PSILI_OXIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_PSILI_OXIA_PROSGEGRAMMENI = "" + CAPITAL_ETA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_DASIA_OXIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_DASIA_OXIA_PROSGEGRAMMENI = "" + CAPITAL_ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_PSILI_PERISPOMENI_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_PSILI_PERISPOMENI_PROSGEGRAMMENI = "" + CAPITAL_ETA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_DASIA_PERISPOMENI_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_DASIA_PERISPOMENI_PROSGEGRAMMENI = "" + CAPITAL_ETA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PSILI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PSILI_YPOGEGRAMMENI = "" + OMEGA + COMBINING_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_DASIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_DASIA_YPOGEGRAMMENI = "" + OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PSILI_VARIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PSILI_VARIA_YPOGEGRAMMENI = "" + OMEGA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_DASIA_VARIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_DASIA_VARIA_YPOGEGRAMMENI = "" + OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PSILI_OXIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PSILI_OXIA_YPOGEGRAMMENI = "" + OMEGA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_DASIA_OXIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_DASIA_OXIA_YPOGEGRAMMENI = "" + OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PSILI_PERISPOMENI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PSILI_PERISPOMENI_YPOGEGRAMMENI = "" + OMEGA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_DASIA_PERISPOMENI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_DASIA_PERISPOMENI_YPOGEGRAMMENI = "" + OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_PSILI_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_PSILI_PROSGEGRAMMENI = "" + CAPITAL_OMEGA + COMBINING_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_DASIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_DASIA_PROSGEGRAMMENI = "" + CAPITAL_OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_PSILI_VARIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_PSILI_VARIA_PROSGEGRAMMENI = "" + CAPITAL_OMEGA + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_DASIA_VARIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_DASIA_VARIA_PROSGEGRAMMENI = "" + CAPITAL_OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_PSILI_OXIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_PSILI_OXIA_PROSGEGRAMMENI = "" + CAPITAL_OMEGA + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_DASIA_OXIA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_DASIA_OXIA_PROSGEGRAMMENI = "" + CAPITAL_OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_PSILI_PERISPOMENI_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_PSILI_PERISPOMENI_PROSGEGRAMMENI = "" + CAPITAL_OMEGA + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_DASIA_PERISPOMENI_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_DASIA_PERISPOMENI_PROSGEGRAMMENI = "" + CAPITAL_OMEGA + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_VRACHY " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_VRACHY = "" + ALPHA + COMBINING_BREVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_MACRON " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_MACRON = "" + ALPHA + COMBINING_MACRON;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_VARIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_VARIA_YPOGEGRAMMENI = "" + ALPHA + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_YPOGEGRAMMENI = "" + ALPHA + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_OXIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_OXIA_YPOGEGRAMMENI = "" + ALPHA + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PERISPOMENI = "" + ALPHA + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ALPHA_PERISPOMENI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ALPHA_PERISPOMENI_YPOGEGRAMMENI = "" + ALPHA + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_VRACHY " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_VRACHY = "" + CAPITAL_ALPHA + COMBINING_BREVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_MACRON " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_MACRON = "" + CAPITAL_ALPHA + COMBINING_MACRON;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_VARIA = "" + CAPITAL_ALPHA + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_OXIA = "" + CAPITAL_ALPHA + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ALPHA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ALPHA_PROSGEGRAMMENI = "" + CAPITAL_ALPHA + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_KORONIS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_KORONIS = " " + COMBINING_COMMA_ABOVE;
		// preferred over KORONIS
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_PROSGEGRAMMENI = " " + COMBINING_YPOGEGRAMMENI;
		// = 03B9 greek small letter iota, but then precomposing would be difficult
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_PSILI = " " + COMBINING_COMMA_ABOVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_PERISPOMENI = " " + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_DIALYTIKA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_DIALYTIKA_PERISPOMENI = " " + COMBINING_DIAERESIS + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_VARIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_VARIA_YPOGEGRAMMENI = "" + ETA + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_YPOGEGRAMMENI = "" + ETA + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_OXIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_OXIA_YPOGEGRAMMENI = "" + ETA + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PERISPOMENI = "" + ETA + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_ETA_PERISPOMENI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_ETA_PERISPOMENI_YPOGEGRAMMENI = "" + ETA + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_EPSILON_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_EPSILON_VARIA = "" + CAPITAL_EPSILON + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_EPSILON_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_EPSILON_OXIA = "" + CAPITAL_EPSILON + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_VARIA = "" + CAPITAL_ETA + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_OXIA = "" + CAPITAL_ETA + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_ETA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_ETA_PROSGEGRAMMENI = "" + CAPITAL_ETA + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_PSILI_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_PSILI_VARIA = " " + COMBINING_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_PSILI_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_PSILI_OXIA = " " + COMBINING_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_PSILI_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_PSILI_PERISPOMENI = " " + COMBINING_COMMA_ABOVE + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_VRACHY " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_VRACHY = "" + IOTA + COMBINING_BREVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_MACRON " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_MACRON = "" + IOTA + COMBINING_MACRON;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_DIALYTIKA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_DIALYTIKA_VARIA = "" + IOTA + COMBINING_DIAERESIS + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_DIALYTIKA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_DIALYTIKA_OXIA = "" + IOTA + COMBINING_DIAERESIS + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_PERISPOMENI = "" + IOTA + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_IOTA_DIALYTIKA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_IOTA_DIALYTIKA_PERISPOMENI = "" + IOTA + COMBINING_DIAERESIS + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_VRACHY " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_VRACHY = "" + CAPITAL_IOTA + COMBINING_BREVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_MACRON " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_MACRON = "" + CAPITAL_IOTA + COMBINING_MACRON;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_VARIA = "" + CAPITAL_IOTA + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_IOTA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_IOTA_OXIA = "" + CAPITAL_IOTA + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_DASIA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_DASIA_VARIA = "" + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_DASIA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_DASIA_OXIA = "" + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_DASIA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_DASIA_PERISPOMENI = "" + COMBINING_REVERSED_COMMA_ABOVE + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_VRACHY " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_VRACHY = "" + UPSILON + COMBINING_BREVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_MACRON " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_MACRON = "" + UPSILON + COMBINING_MACRON;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DIALYTIKA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DIALYTIKA_VARIA = "" + UPSILON + COMBINING_DIAERESIS + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DIALYTIKA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DIALYTIKA_OXIA = "" + UPSILON + COMBINING_DIAERESIS + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_RHO_PSILI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_RHO_PSILI = "" + RHO + COMBINING_COMMA_ABOVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_RHO_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_RHO_DASIA = "" + RHO + COMBINING_REVERSED_COMMA_ABOVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_PERISPOMENI = "" + UPSILON + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_UPSILON_DIALYTIKA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_UPSILON_DIALYTIKA_PERISPOMENI = "" + UPSILON + COMBINING_DIAERESIS + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_VRACHY " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_VRACHY = "" + CAPITAL_UPSILON + COMBINING_BREVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_MACRON " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_MACRON = "" + CAPITAL_UPSILON + COMBINING_MACRON;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_VARIA = "" + CAPITAL_UPSILON + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_UPSILON_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_UPSILON_OXIA = "" + CAPITAL_UPSILON + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_RHO_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_RHO_DASIA = "" + CAPITAL_RHO + COMBINING_REVERSED_COMMA_ABOVE;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_DIALYTIKA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_DIALYTIKA_VARIA = " " + COMBINING_DIAERESIS + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_DIALYTIKA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_DIALYTIKA_OXIA = " " + COMBINING_DIAERESIS + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_VARIA = " " + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_VARIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_VARIA_YPOGEGRAMMENI = "" + OMEGA + COMBINING_GRAVE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_YPOGEGRAMMENI = "" + OMEGA + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_OXIA_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_OXIA_YPOGEGRAMMENI = "" + OMEGA + COMBINING_ACUTE_ACCENT + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PERISPOMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PERISPOMENI = "" + OMEGA + COMBINING_PERISPOMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OMEGA_PERISPOMENI_YPOGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OMEGA_PERISPOMENI_YPOGEGRAMMENI = "" + OMEGA + COMBINING_PERISPOMENI + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMICRON_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMICRON_VARIA = "" + CAPITAL_OMICRON + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMICRON_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMICRON_OXIA = "" + CAPITAL_OMICRON + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_VARIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_VARIA = "" + CAPITAL_OMEGA + COMBINING_GRAVE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_OXIA = "" + CAPITAL_OMEGA + COMBINING_ACUTE_ACCENT;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_CAPITAL_OMEGA_PROSGEGRAMMENI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_CAPITAL_OMEGA_PROSGEGRAMMENI = "" + CAPITAL_OMEGA + COMBINING_YPOGEGRAMMENI;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_OXIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_OXIA = " " + COMBINING_ACUTE_ACCENT;
		// id. to ACUTE_ACCENT = ?
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NRM_DASIA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		internal static readonly System.String NRM_DASIA = " " + COMBINING_REVERSED_COMMA_ABOVE;
		//
		// SPACING MODIFIER LETTERS
		//
		// Miscellaneous phonetic modifiers
		// I must admit I do not understand the difference between the spacing ACUTE ACCENT
		// and the MODIFIER LETTER ACUTE ACCENT or between APOSTROPHE and MODIFIER LETTER APOSTROPHE!
		internal const char MODIFIER_PRIME = '\u02B9'; // id. to 0374 NUMERAL_SIGN (dexia keraia)
		internal const char MODIFIER_APOSTROPHE = '\u02BC';
		internal const char MODIFIER_REVERSED_COMMA = '\u02BD';
		internal const char MODIFIER_CIRCUMFLEX_ACCENT = '\u02C6';
		internal const char MODIFIER_MACRON = '\u02C9';
		internal const char MODIFIER_ACUTE_ACCENT = '\u02CA';
		internal const char MODIFIER_GRAVE_ACCENT = '\u02CB';
		// Spacing clones of diacritics
		internal const char MODIFIER_BREVE = '\u02D8';
		internal const char MODIFIER_SMALL_TILDE = '\u02DC';
		//
		// GENERAL PUNCTUATION
		//
		internal const char HYPHEN = '\u2010';
		internal const char RIGHT_SINGLE_QUOTATION_MARK = '\u0219'; // preferred over 0027 APOSTROPHE
		internal const char DAGGER = '\u2020'; // obelisk, long cross
		internal const char DOUBLE_DAGGER = '\u2021'; // double obelisk
		internal const char PRIME = '\u2032';
		// abbr. for minutes and feet (looks like apostrophe or acute accent)
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "11-May-2002"; break;
				
				case 1:  info = "Contains symbolic constants for Unicode characters."; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "In magnis et voluisse sat est.";
					break;
				
			}
			return info;
		}
	}
}