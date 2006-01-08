namespace greekconverter
{
	using System;
	
	/// <summary>*************************
	/// </summary>
	/* Unicode -> Official names */
	/// <summary>*************************
	/// </summary>
	
	/// <summary> Class for conversion of Unicode text into official character names.
	/// <p>
	/// On rare occasions short explaining remarks have been added. Supported
	/// character ranges are:
	/// <ul>
	/// <li>C0 Controls and Basic Latin (0000-007F)</li>
	/// <li>C1 Controls and Latin-1 Supplement (0080-00FF)</li>
	/// <li>Greek and Coptic (0370-03FF)</li>
	/// <li>Greek Extended (1F00-1FFF)</li>
	/// <li>Combining Characters (0300-036F)</li>
	/// <li>Spacing Modifier Letters (02B0-02EE)</li>
	/// <li>General Punctiation (2000-206F)</li>
	/// </ul>
	/// </summary>
	
	public class UnicodeToName
	{
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NOT_SUPPORTED " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String NOT_SUPPORTED = new System.String(": Not supported by GreekConverter".ToCharArray());
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NOT_ASSIGNED " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String NOT_ASSIGNED = new System.String(": Reserved (not yet assigned)".ToCharArray());
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLookup " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[][] tblLookup;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLatin1 " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblLatin1;
		// 0000-00FF
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblModif " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblModif;
		// 02B0-02EE
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblDiacritGreek " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblDiacritGreek;
		// 0300-036F combining diacritics, 0370-03FF Greek/Coptic
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblGreekExtended " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblGreekExtended;
		// 1F00-1FFF
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblPunct " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblPunct;
		// 2000-206F
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblNotSupported " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblNotSupported;
		
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "01-Apr-2002"; break;
				
				case 1:  info = "Converts Unicode into official character names"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Amicus certus in re incerta cernitur.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Converts a String consisting of Unicode characters into official character names,
		/// each character on a line of its own.
		/// <p>
		/// This is intended mainly for debugging purposes.
		/// If a character is not within range an "not supported" message is launched,
		/// if a character is not defined within the range a "not defined" is reported.
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode string
		/// </param>
		/// <returns>  the list of character names
		/// </returns>
		public static System.String convertString(System.String uniString)
		{
			int strLen = uniString.Length, strPos;
			System.Text.StringBuilder nameString = new System.Text.StringBuilder(strLen * 50);
			
			for (strPos = 0; strPos < strLen; strPos++)
			{
				nameString.Append(convertChar(uniString[strPos]) + "\n");
			}
			return nameString.ToString();
		}
		
		/*
		* Returns the official Unicode character name of the character given as argument.*/
		internal static System.String convertChar(char uniChar)
		{
			// look up [hibyte][lobyte]:
			// hibyte = uniChar/256 (bitshifting is faster than dividing, therefore >>8)
			// lobyte = trailing 8 bit of uniChar (masked out with bitwise AND)
			System.String s = tblLookup[uniChar >> 8][uniChar & 255];
			
			// if character can not be translated then report its hex value:
			if ((s == NOT_SUPPORTED) || (s == NOT_ASSIGNED))
			{
				return "U+" + System.Convert.ToString((int) uniChar, 16) + s;
			}
			else
			{
				return s;
			}
		}
		static UnicodeToName()
		{
			tblLookup = new System.String[256][];
			tblLatin1 = new System.String[256];
			tblModif = new System.String[256];
			tblDiacritGreek = new System.String[256];
			tblGreekExtended = new System.String[256];
			tblPunct = new System.String[256];
			tblNotSupported = new System.String[256];
			{
				int i;
				// generally initialize lookup tables:
				for (i = 0; i < 256; i++)
				{
					tblLookup[i] = tblNotSupported;
					tblNotSupported[i] = NOT_SUPPORTED;
					// tblLatin is entirely occupied with characters and we do support all of them
					tblModif[i] = NOT_SUPPORTED;
					tblDiacritGreek[i] = NOT_ASSIGNED;
					tblGreekExtended[i] = NOT_ASSIGNED;
					tblPunct[i] = NOT_SUPPORTED;
				}
				// now mount the LoByte character blocks into the HiByte block:
				tblLookup[0] = tblLatin1;
				tblLookup[2] = tblModif;
				tblLookup[3] = tblDiacritGreek;
				tblLookup[31] = tblGreekExtended;
				tblLookup[32] = tblPunct;
				// now assign the conversion values to the table positions:
				//
				// LATIN 1
				//
				// C0 controls and basic Latin
				tblLatin1[0] = "<control> NULL";
				tblLatin1[1] = "<control> START OF HEADING";
				tblLatin1[2] = "<control> START OF TEXT";
				tblLatin1[3] = "<control> END OF TEXT";
				tblLatin1[4] = "<control> END OF TRANSMISSION";
				tblLatin1[5] = "<control> ENQUIRY";
				tblLatin1[6] = "<control> ACKNOWLEDGE";
				tblLatin1[7] = "<control> BELL";
				tblLatin1[8] = "<control> BACKSPACE";
				tblLatin1[9] = "<control> HORIZONTAL TABULATION";
				tblLatin1[10] = "<control> LINE FEED";
				tblLatin1[11] = "<control> VERTICAL TABULATION";
				tblLatin1[12] = "<control> FORM FEED";
				tblLatin1[13] = "<control> CARRIAGE RETURN";
				tblLatin1[14] = "<control> SHIFT OUT";
				tblLatin1[15] = "<control> SHIFT IN";
				tblLatin1[16] = "<control> DATA LINK ESCAPE";
				tblLatin1[17] = "<control> DEVICE CONTROL ONE";
				tblLatin1[18] = "<control> DEVICE CONTROL TWO";
				tblLatin1[19] = "<control> DEVICE CONTROL THREE";
				tblLatin1[20] = "<control> DEVICE CONTROL FOUR";
				tblLatin1[21] = "<control> NEGATIVE ACKNOWLEDGE";
				tblLatin1[22] = "<control> SYNCHRONOUS IDLE";
				tblLatin1[23] = "<control> END OF TRANSMISSION BLOCK";
				tblLatin1[24] = "<control> CANCEL";
				tblLatin1[25] = "<control> END OF MEDIUM";
				tblLatin1[26] = "<control> SUBSTITUTE";
				tblLatin1[27] = "<control> ESCAPE";
				tblLatin1[28] = "<control> FILE SEPARATOR";
				tblLatin1[29] = "<control> GROUP SEPARATOR";
				tblLatin1[30] = "<control> RECORD SEPARATOR";
				tblLatin1[31] = "<control> UNIT SEPARATOR";
				tblLatin1[32] = "SPACE";
				tblLatin1[33] = "EXCLAMATION MARK";
				tblLatin1[34] = "QUOTATION MARK";
				tblLatin1[35] = "NUMBER SIGN (hash, crosshatch)";
				tblLatin1[36] = "DOLLAR SIGN";
				tblLatin1[37] = "PERCENT SIGN";
				tblLatin1[38] = "AMPERSAND";
				tblLatin1[39] = "APOSTROPHE = APOSTROPHE-QUOTE = APL";
				tblLatin1[40] = "LEFT PARENTHESIS = OPENING PARENTHESIS";
				tblLatin1[41] = "RIGHT PARENTHESIS = CLOSING PARENTHESIS";
				tblLatin1[42] = "ASTERISK (star)";
				tblLatin1[43] = "PLUS SIGN";
				tblLatin1[44] = "COMMA";
				tblLatin1[45] = "HYPHEN-MINUS";
				tblLatin1[46] = "FULL STOP = PERIOD";
				tblLatin1[47] = "SOLIDUS = SLASH";
				tblLatin1[48] = "DIGIT ZERO";
				tblLatin1[49] = "DIGIT ONE";
				tblLatin1[50] = "DIGIT TWO";
				tblLatin1[51] = "DIGIT THREE";
				tblLatin1[52] = "DIGIT FOUR";
				tblLatin1[53] = "DIGIT FIVE";
				tblLatin1[54] = "DIGIT SIX";
				tblLatin1[55] = "DIGIT SEVEN";
				tblLatin1[56] = "DIGIT EIGHT";
				tblLatin1[57] = "DIGIT NINE";
				tblLatin1[58] = "COLON";
				tblLatin1[59] = "SEMICOLON";
				tblLatin1[60] = "LESS-THAN SIGN";
				tblLatin1[61] = "EQUALS SIGN";
				tblLatin1[62] = "GREATER-THAN SIGN";
				tblLatin1[63] = "QUESTION MARK";
				tblLatin1[64] = "COMMERCIAL AT";
				tblLatin1[65] = "LATIN CAPITAL LETTER A";
				tblLatin1[66] = "LATIN CAPITAL LETTER B";
				tblLatin1[67] = "LATIN CAPITAL LETTER C";
				tblLatin1[68] = "LATIN CAPITAL LETTER D";
				tblLatin1[69] = "LATIN CAPITAL LETTER E";
				tblLatin1[70] = "LATIN CAPITAL LETTER F";
				tblLatin1[71] = "LATIN CAPITAL LETTER G";
				tblLatin1[72] = "LATIN CAPITAL LETTER H";
				tblLatin1[73] = "LATIN CAPITAL LETTER I";
				tblLatin1[74] = "LATIN CAPITAL LETTER J";
				tblLatin1[75] = "LATIN CAPITAL LETTER K";
				tblLatin1[76] = "LATIN CAPITAL LETTER L";
				tblLatin1[77] = "LATIN CAPITAL LETTER M";
				tblLatin1[78] = "LATIN CAPITAL LETTER N";
				tblLatin1[79] = "LATIN CAPITAL LETTER O";
				tblLatin1[80] = "LATIN CAPITAL LETTER P";
				tblLatin1[81] = "LATIN CAPITAL LETTER Q";
				tblLatin1[82] = "LATIN CAPITAL LETTER R";
				tblLatin1[83] = "LATIN CAPITAL LETTER S";
				tblLatin1[84] = "LATIN CAPITAL LETTER T";
				tblLatin1[85] = "LATIN CAPITAL LETTER U";
				tblLatin1[86] = "LATIN CAPITAL LETTER V";
				tblLatin1[87] = "LATIN CAPITAL LETTER W";
				tblLatin1[88] = "LATIN CAPITAL LETTER X";
				tblLatin1[89] = "LATIN CAPITAL LETTER Y";
				tblLatin1[90] = "LATIN CAPITAL LETTER Z";
				tblLatin1[91] = "LEFT SQUARE BRACKET = OPENING SQUARE BRACKET";
				tblLatin1[92] = "REVERSE SOLIDUS = BACKSLASH";
				tblLatin1[93] = "RIGHT SQUARE BRACKET = CLOSING SQUARE BRACKET";
				tblLatin1[94] = "CIRCUMFLEX ACCENT";
				tblLatin1[95] = "LOW LINE = SPACING UNDERSCORE";
				tblLatin1[96] = "GRAVE ACCENT";
				tblLatin1[97] = "LATIN SMALL LETTER A";
				tblLatin1[98] = "LATIN SMALL LETTER B";
				tblLatin1[99] = "LATIN SMALL LETTER C";
				tblLatin1[100] = "LATIN SMALL LETTER D";
				tblLatin1[101] = "LATIN SMALL LETTER E";
				tblLatin1[102] = "LATIN SMALL LETTER F";
				tblLatin1[103] = "LATIN SMALL LETTER G";
				tblLatin1[104] = "LATIN SMALL LETTER H";
				tblLatin1[105] = "LATIN SMALL LETTER I";
				tblLatin1[106] = "LATIN SMALL LETTER J";
				tblLatin1[107] = "LATIN SMALL LETTER K";
				tblLatin1[108] = "LATIN SMALL LETTER L";
				tblLatin1[109] = "LATIN SMALL LETTER M";
				tblLatin1[110] = "LATIN SMALL LETTER N";
				tblLatin1[111] = "LATIN SMALL LETTER O";
				tblLatin1[112] = "LATIN SMALL LETTER P";
				tblLatin1[113] = "LATIN SMALL LETTER Q";
				tblLatin1[114] = "LATIN SMALL LETTER R";
				tblLatin1[115] = "LATIN SMALL LETTER S";
				tblLatin1[116] = "LATIN SMALL LETTER T";
				tblLatin1[117] = "LATIN SMALL LETTER U";
				tblLatin1[118] = "LATIN SMALL LETTER V";
				tblLatin1[119] = "LATIN SMALL LETTER W";
				tblLatin1[120] = "LATIN SMALL LETTER X";
				tblLatin1[121] = "LATIN SMALL LETTER Y";
				tblLatin1[122] = "LATIN SMALL LETTER Z";
				tblLatin1[123] = "LEFT CURLY BRACKET = OPENING CURLY BRACKET";
				tblLatin1[124] = "VERTICAL LINE = VERTICAL BAR";
				tblLatin1[125] = "RIGHT CURLY BRACKET = CLOSLING CURLY BRACKET";
				tblLatin1[126] = "TILDE";
				tblLatin1[127] = "<control> DELETE";
				// C1 controls (alias names for ISO 6429)
				tblLatin1[128] = "<control>";
				tblLatin1[129] = "<control>";
				tblLatin1[130] = "<control> BREAK PERMITTED HERE";
				tblLatin1[131] = "<control> NO BREAK HERE";
				tblLatin1[132] = "<control>";
				tblLatin1[133] = "<control> NEXT LINE";
				tblLatin1[134] = "<control> START OF SELECTED AREA";
				tblLatin1[135] = "<control> END OF SELECTED AREA";
				tblLatin1[136] = "<control> CHARACTER TABULATION SET";
				tblLatin1[137] = "<control> CHARACTER TABULATION WITH JUSTIFICATION";
				tblLatin1[138] = "<control> LINE TABULATION SET";
				tblLatin1[139] = "<control> PARTIAL LINE DOWN";
				tblLatin1[140] = "<control> PARTIAL LINE UP";
				tblLatin1[141] = "<control> REVERSE LINE FEED";
				tblLatin1[142] = "<control> SINGLE SHIFT TWO";
				tblLatin1[143] = "<control> SINGLE SHIFT THREE";
				tblLatin1[144] = "<control> DEVICE CONTROL STRING";
				tblLatin1[145] = "<control> PRIVATE USE ONE";
				tblLatin1[146] = "<control> PRIVATE USE TWO";
				tblLatin1[147] = "<control> SET TRANSMIT STATE";
				tblLatin1[148] = "<control> CANCEL CHARACTER";
				tblLatin1[149] = "<control> MESSAGE WAITING";
				tblLatin1[150] = "<control> START OF GUARDED AREA";
				tblLatin1[151] = "<control> END OF GUARDED AREA";
				tblLatin1[152] = "<control> START OF STRING";
				tblLatin1[153] = "<control>";
				tblLatin1[154] = "<control> SINGLE CHARACTER INTRODUCER";
				tblLatin1[155] = "<control> CONTROL SEQUENCE INTRODUCER";
				tblLatin1[156] = "<control> STRING TERMINATOR";
				tblLatin1[157] = "<control> OPERATING SYSTEM COMMAND";
				tblLatin1[158] = "<control> PRIVACY MESSAGE";
				tblLatin1[159] = "<control> APPLICATION PROGRAM COMMAND";
				// ISO 8859-1 (aka Latin-1)
				tblLatin1[160] = "NO-BREAK SPACE";
				tblLatin1[161] = "INVERTED EXCLAMATION MARK";
				tblLatin1[162] = "CENT SIGN";
				tblLatin1[163] = "POUND SIGN";
				tblLatin1[164] = "CURRENCY SIGN";
				tblLatin1[165] = "YEN SIGN";
				tblLatin1[166] = "BROKEN BAR = BROKEN VERTICAL BAR";
				tblLatin1[167] = "SECTION SIGN (paragraph sign)";
				tblLatin1[168] = "DIAERESIS";
				tblLatin1[169] = "COPYRIGHT SIGN";
				tblLatin1[170] = "FEMININE ORDINAL INDICATOR";
				tblLatin1[171] = "LEFT-POINTING DOUBLE ANGLE QUOTATION MARK = LEFT POINTING GUILLEMET (chevrons)";
				tblLatin1[172] = "NOT SIGN";
				tblLatin1[173] = "<control> SOFT HYPHEN";
				tblLatin1[174] = "REGISTERED SIGN = REGISTERED TRADE MARK SIGN";
				tblLatin1[175] = "MACRON";
				tblLatin1[176] = "DEGREE SIGN";
				tblLatin1[177] = "PLUS-MINUS SIGN";
				tblLatin1[178] = "SUPERSCRIPT TWO";
				tblLatin1[179] = "SUPERSCRIPT THREE";
				tblLatin1[180] = "ACUTE ACCENT";
				tblLatin1[181] = "MICRO SIGN";
				tblLatin1[182] = "PILCROW SIGN = PARAGRAPH SIGN";
				tblLatin1[183] = "MIDDLE DOT";
				tblLatin1[184] = "CEDILLA";
				tblLatin1[185] = "SUPERSCRIPT ONE";
				tblLatin1[186] = "MASCULINE ORDINAL INDICATOR";
				tblLatin1[187] = "RIGHT-POINTING DOUBLE ANGLE QUOTATION MARK = RIGHT POINTING GUILLEMET";
				tblLatin1[188] = "VULGAR FRACTION ONE QUARTER";
				tblLatin1[189] = "VULGAR FRACTION ONE HALF";
				tblLatin1[190] = "VULGAR FRACTION THREE QUARTERS";
				tblLatin1[191] = "INVERTED QUESTION MARK";
				tblLatin1[192] = "LATIN CAPITAL LETTER A WITH GRAVE";
				tblLatin1[193] = "LATIN CAPITAL LETTER A WITH ACUTE";
				tblLatin1[194] = "LATIN CAPITAL LETTER A WITH CIRCUMFLEX";
				tblLatin1[195] = "LATIN CAPITAL LETTER A WITH TILDE";
				tblLatin1[196] = "LATIN CAPITAL LETTER A WITH DIAERESIS (umlaut A)";
				tblLatin1[197] = "LATIN CAPITAL LETTER A WITH RING ABOVE (angstrom sign)";
				tblLatin1[198] = "LATIN CAPITAL LETTER AE = LATIN CAPITAL LIGATURE AE";
				tblLatin1[199] = "LATIN CAPITAL LETTER C WITH CEDILLA";
				tblLatin1[200] = "LATIN CAPITAL LETTER E WITH GRAVE";
				tblLatin1[201] = "LATIN CAPITAL LETTER E WITH ACUTE";
				tblLatin1[202] = "LATIN CAPITAL LETTER E WITH CIRCUMFLEX";
				tblLatin1[203] = "LATIN CAPITAL LETTER E WITH DIAERESIS";
				tblLatin1[204] = "LATIN CAPITAL LETTER I WITH GRAVE";
				tblLatin1[205] = "LATIN CAPITAL LETTER I WITH ACUTE";
				tblLatin1[206] = "LATIN CAPITAL LETTER I WITH CIRCUMFLEX";
				tblLatin1[207] = "LATIN CAPITAL LETTER I WITH DIAERESIS";
				tblLatin1[208] = "LATIN CAPITAL LETTER ETH";
				tblLatin1[209] = "LATIN CAPITAL LETTER N WITH TILDE";
				tblLatin1[210] = "LATIN CAPITAL LETTER O WITH GRAVE";
				tblLatin1[211] = "LATIN CAPITAL LETTER O WITH ACUTE";
				tblLatin1[212] = "LATIN CAPITAL LETTER O WITH CIRCUMFLEX";
				tblLatin1[213] = "LATIN CAPITAL LETTER O WITH TILDE";
				tblLatin1[214] = "LATIN CAPITAL LETTER O WITH DIAERESIS";
				tblLatin1[215] = "MULTIPLICATION SIGN";
				tblLatin1[216] = "LATIN CAPITAL LETTER O WITH STROKE = LATIN CAPITAL LETTER O SLASH";
				tblLatin1[217] = "LATIN CAPITAL LETTER U WITH GRAVE";
				tblLatin1[218] = "LATIN CAPITAL LETTER U WITH ACUTE";
				tblLatin1[219] = "LATIN CAPITAL LETTER U WITH CIRCUMFLEX";
				tblLatin1[220] = "LATIN CAPITAL LETTER U WITH DIAERESIS";
				tblLatin1[221] = "LATIN CAPITAL LETTER Y WITH ACUTE";
				tblLatin1[222] = "LATIN CAPITAL LETTER THORN";
				tblLatin1[223] = "LATIN SMALL LETTER SHARP S (Eszett)";
				tblLatin1[224] = "LATIN SMALL LETTER A WITH GRAVE";
				tblLatin1[225] = "LATIN SMALL LETTER A WITH ACUTE";
				tblLatin1[226] = "LATIN SMALL LETTER A WITH CIRCUMFLEX";
				tblLatin1[227] = "LATIN SMALL LETTER A WITH TILDE";
				tblLatin1[228] = "LATIN SMALL LETTER A WITH DIAERESIS";
				tblLatin1[229] = "LATIN SMALL LETTER A WITH RING ABOVE";
				tblLatin1[230] = "LATIN SMALL LETTER AE = LATIN SMALL LIGATURE AE (ash)";
				tblLatin1[231] = "LATIN SMALL LETTER C WITH CEDILLA";
				tblLatin1[232] = "LATIN SMALL LETTER E WITH GRAVE";
				tblLatin1[233] = "LATIN SMALL LETTER E WITH ACUTE";
				tblLatin1[234] = "LATIN SMALL LETTER E WITH CIRCUMFLEX";
				tblLatin1[235] = "LATIN SMALL LETTER E WITH DIAERESIS";
				tblLatin1[236] = "LATIN SMALL LETTER I WITH GRAVE";
				tblLatin1[237] = "LATIN SMALL LETTER I WITH ACUTE";
				tblLatin1[238] = "LATIN SMALL LETTER I WITH CIRCUMFLEX";
				tblLatin1[239] = "LATIN SMALL LETTER I WITH DIAERESIS";
				tblLatin1[240] = "LATIN SMALL LETTER ETH";
				tblLatin1[241] = "LATIN SMALL LETTER N WITH TILDE";
				tblLatin1[242] = "LATIN SMALL LETTER O WITH GRAVE";
				tblLatin1[243] = "LATIN SMALL LETTER O WITH ACUTE";
				tblLatin1[244] = "LATIN SMALL LETTER O WITH CICRUMFLEX";
				tblLatin1[245] = "LATIN SMALL LETTER O WITH TILDE";
				tblLatin1[246] = "LATIN SMALL LETTER O WITH DIAERESIS";
				tblLatin1[247] = "DIVISION SIGN";
				tblLatin1[248] = "LATIN SMALL LETTER O WITH STROKE = LATIN SMALL LETTER O SLASH";
				tblLatin1[249] = "LATIN SMALL LETTER U WITH GRAVE";
				tblLatin1[250] = "LATIN SMALL LETTER U WITH ACUTE";
				tblLatin1[251] = "LATIN SMALL LETTER U WITH CIRCUMFLEX";
				tblLatin1[252] = "LATIN SMALL LETTER U WITH DIAERESIS";
				tblLatin1[253] = "LATIN SMALL LETTER Y WITH ACUTE";
				tblLatin1[254] = "LATIN SMALL LETTER THORN";
				tblLatin1[255] = "LATIN SMALL LETTER Y WITH DIAERESIS";
				//
				// SPACING MODIFIER LETTERS
				//
				// Phonetic modifiers derived from Latin
				tblModif[176] = "MODIFIER LETTER SMALL H";
				tblModif[177] = "MODIFIER LETTER SMALL H WITH HOOK";
				tblModif[178] = "MODIFIER LETTER SMALL J";
				tblModif[179] = "MODIFIER LETTER SMALL R";
				tblModif[180] = "MODIFIER LETTER SMALL TURNED R";
				tblModif[181] = "MODIFIER LETTER SMALL TURNED R WITH HOOK";
				tblModif[182] = "MODIFIER LETTER SMALL CAPITAL INVERTED R";
				tblModif[183] = "MODIFIER LETTER SMALL W";
				tblModif[184] = "MODIFIER LETTER SMALL Y";
				// Miscellaneous phonetic modifiers
				tblModif[185] = "MODIFIER LETTER PRIME";
				tblModif[186] = "MODIFIER LETTER DOUBLE PRIME";
				tblModif[187] = "MODIFIER LETTER TURNED COMMA";
				tblModif[188] = "MODIFIER LETTER APOSTROPHE";
				tblModif[189] = "MODIFIER LETTER REVERSED COMMA";
				tblModif[190] = "MODIFIER LETTER RIGHT HALF RING";
				tblModif[191] = "MODIFIER LETTER LEFT HALF RING";
				tblModif[192] = "MODIFIER LETTER GLOTTAL STOP";
				tblModif[193] = "MODIFIER LETTER REVERSED GLOTTAL STOP";
				tblModif[194] = "MODIFIER LETTER LEFT ARROWHEAD";
				tblModif[195] = "MODIFIER LETTER RIGHT ARROWHEAD";
				tblModif[196] = "MODIFIER LETTER UP ARROWHEAD";
				tblModif[197] = "MODIFIER LETTER DOWN ARROWHEAD";
				tblModif[198] = "MODIFIER LETTER CIRCUMFLEX ACCENT";
				tblModif[199] = "CARON";
				tblModif[200] = "MODIFIER LETTER VERTICAL LINE";
				tblModif[201] = "MODIFIER LETTER MACRON";
				tblModif[202] = "MODIFIER LETTER ACUTE ACCENT";
				tblModif[203] = "MODIFIER LETTER GRAVE ACCENT";
				tblModif[204] = "MODIFIER LETTER LOW VERTICAL LINE";
				tblModif[205] = "MODIFIER LETTER LOW MACRON";
				tblModif[206] = "MODIFIER LETTER LOW GRAVE ACCENT";
				tblModif[207] = "MODIFIER LETTER LOW ACUTE ACCENT";
				tblModif[208] = "MODIFIER LETTER TRIANGULAR COLON";
				tblModif[209] = "MODIFIER LETTER HALF TRIANGULAR COLON";
				tblModif[210] = "MODIFIER LETTER CENTRED RIGHT HALF RING";
				tblModif[211] = "MODIFIER LETTER CENTRED LEFT HALF RING";
				tblModif[212] = "MODIFIER LETTER UP TACK";
				tblModif[213] = "MODIFIER LETTER DOWN TACK";
				tblModif[214] = "MODIFIER LETTER PLUS SIGN";
				tblModif[215] = "MODIFIER LETTER MINUS SIGN";
				// Spacing clones of diacritics
				tblModif[216] = "BREVE";
				tblModif[217] = "DOT ABOVE";
				tblModif[218] = "RING ABOVE";
				tblModif[219] = "OGONEK";
				tblModif[220] = "SMALL TILDE";
				tblModif[221] = "DOUBLE ACUTE ACCENT";
				// Additions based on 1989 IPA
				tblModif[222] = "MODIFIER LETTER RHOTIC HOOK";
				tblModif[223] = "MODIFIER LETTER CROSS ACCENT";
				tblModif[224] = "MODIFIER LETTER SMALL GAMMA";
				tblModif[225] = "MODIFIER LETTER SMALL L";
				tblModif[226] = "MODIFIER LETTER SMALL S";
				tblModif[227] = "MODIFIER LETTER SMALL X";
				tblModif[228] = "MODIFIER LETTER SMALL REVERSED GLOTTAL STOP";
				// Tone letters
				tblModif[229] = "MODIFIER LETTER EXTRA-HIGH TONE BAR";
				tblModif[230] = "MODIFIER LETTER HIGH TONE BAR";
				tblModif[231] = "MODIFIER LETTER MID TONE BAR";
				tblModif[232] = "MODIFIER LETTER LOW TONE BAR";
				tblModif[233] = "MODIFIER LETTER EXTRA-LOW TONE BAR";
				tblModif[234] = "MODIFIER LETTER YIN DEPARTING TONE MARK";
				tblModif[235] = "MODIFIER LETTER YANG DEPARTING TONE MARK";
				// IPA modifiers
				tblModif[236] = "MODIFIER LETTER VOICING";
				tblModif[237] = "MODIFIER LETTER UNASPIRATED";
				// Other modifier letters
				tblModif[238] = "MODIFIER LETTER DOUBLE APOSTROPHE";
				//
				// COMBINING DIACRITICAL MARKS
				//
				// Ordinary diacritics
				tblDiacritGreek[0] = "COMBINING GRAVE ACCENT";
				tblDiacritGreek[1] = "COMBINING ACUTE ACCENT";
				tblDiacritGreek[2] = "COMBINING CIRCUMFLEX ACCENT";
				tblDiacritGreek[3] = "COMBINING TILDE";
				tblDiacritGreek[4] = "COMBINING MACRON";
				tblDiacritGreek[5] = "COMBINING OVERLINE";
				tblDiacritGreek[6] = "COMBINING BREVE (Greek vrachy)";
				tblDiacritGreek[7] = "COMBINING DOT ABOVE";
				tblDiacritGreek[8] = "COMBINING DIAERESIS (umlaut, Greek dialytika)";
				tblDiacritGreek[9] = "COMBINING HOOK ABOVE";
				tblDiacritGreek[10] = "COMBINING RING ABOVE";
				tblDiacritGreek[11] = "COMBINING DOUBLE ACUTE ACCENT";
				tblDiacritGreek[12] = "COMBINING CARON (hacek)";
				tblDiacritGreek[13] = "COMBINING VERTICAL LINE ABOVE";
				tblDiacritGreek[14] = "COMBINING DOUBLE VERTICAL LINE ABOVE";
				tblDiacritGreek[15] = "COMBINING DOUBLE GRAVE ACCENT";
				tblDiacritGreek[16] = "COMBINING CANDRABINDU";
				tblDiacritGreek[17] = "COMBINING INVERTED BREVE";
				tblDiacritGreek[18] = "COMBINING TURNED COMMA ABOVE (cedilla)";
				tblDiacritGreek[19] = "COMBINING COMMA ABOVE (Greek psili)";
				tblDiacritGreek[20] = "COMBINING REVERSED COMMA ABOVE (Greek dasia)";
				tblDiacritGreek[21] = "COMBINING COMMA ABOVE RIGHT";
				tblDiacritGreek[22] = "COMBINING GRAVE ACCENT BELOW";
				tblDiacritGreek[23] = "COMBINING ACUTE ACCENT BELOW";
				tblDiacritGreek[24] = "COMBINING LEFT TACK BELOW";
				tblDiacritGreek[25] = "COMBINING RIGHT TACK BELOW";
				tblDiacritGreek[26] = "COMBINING LEFT ANGLE ABOVE";
				tblDiacritGreek[27] = "COMBINING HORN";
				tblDiacritGreek[28] = "COMBINING LEFT HALF RING BELOW";
				tblDiacritGreek[29] = "COMBINING UP TACK BELOW";
				tblDiacritGreek[30] = "COMBINING DOWN TACK BELOW";
				tblDiacritGreek[31] = "COMBINING PLUS SIGN BELOW";
				tblDiacritGreek[32] = "COMBINING MINUS SIGN BELOW";
				tblDiacritGreek[33] = "COMBINING PALATALIZED HOOK BELOW";
				tblDiacritGreek[34] = "COMBINING RETROFLEX HOOK BELOW";
				tblDiacritGreek[35] = "COMBINING DOT BELOW (nang)";
				tblDiacritGreek[36] = "COMBINING DIAERESIS BELOW";
				tblDiacritGreek[37] = "COMBINING RING BELOW";
				tblDiacritGreek[38] = "COMBINING COMMA BELOW";
				tblDiacritGreek[39] = "COMBINING CEDILLA";
				tblDiacritGreek[40] = "COMBINING OGONEK";
				tblDiacritGreek[41] = "COMBINING VERTICAL LINE BELOW";
				tblDiacritGreek[42] = "COMBINING BRIDGE BELOW";
				tblDiacritGreek[43] = "COMBINING INVERTED DOUBLE ARCH BELOW";
				tblDiacritGreek[44] = "COMBINING CARON BELOW";
				tblDiacritGreek[45] = "COMBINING CIRCUMFLEX ACCENT BELOW";
				tblDiacritGreek[46] = "COMBINING BREVE BELOW";
				tblDiacritGreek[47] = "COMBINING INVERTED BREVE BELOW";
				tblDiacritGreek[48] = "COMBINING TILDE BELOW";
				tblDiacritGreek[49] = "COMBINING MACRON BELOW";
				tblDiacritGreek[50] = "COMBINING LOW LINE";
				tblDiacritGreek[51] = "COMBINING DOUBLE LOW LINE";
				// Overstruck diacritics
				tblDiacritGreek[52] = "COMBINING TILDE OVERLAY";
				tblDiacritGreek[53] = "COMBINING SHORT STROKE OVERLAY";
				tblDiacritGreek[54] = "COMBINING LONG STROKE OVERLAY";
				tblDiacritGreek[55] = "COMBINING SHORT SOLIDUS OVERLAY";
				tblDiacritGreek[56] = "COMBINING LONG SOLIDUS OVERLAY";
				// Additions
				tblDiacritGreek[57] = "COMBINING RIGHT HALF RING BELOW";
				tblDiacritGreek[58] = "COMBINING INVERTED BRIDGE BELOW";
				tblDiacritGreek[59] = "COMBINING SQUARE BELOW";
				tblDiacritGreek[60] = "COMBINING SEAGULL BELOW";
				tblDiacritGreek[61] = "COMBINING X ABOVE";
				tblDiacritGreek[62] = "COMBINING VERTICAL TILDE";
				tblDiacritGreek[63] = "COMBINING DOUBLE OVERLINE";
				// Vietnamese tone marks (deprecated)
				tblDiacritGreek[64] = "COMBINING GRAVE TONE MARK";
				tblDiacritGreek[65] = "COMBINING ACUTE TONE MARK";
				// Additions for Greek
				tblDiacritGreek[66] = "COMBINING GREEK PERISPOMENI";
				tblDiacritGreek[67] = "COMBINING GREEK KORONIS";
				tblDiacritGreek[68] = "COMBINING GREEK DIALYTIKA TONOS";
				tblDiacritGreek[69] = "COMBINING GREEK YPOGEGRAMMENI = GRREK NON-SPACING IOTA BELOW (iota subcript and adscript)";
				// Additions for IPA
				tblDiacritGreek[70] = "COMBINING BRIDGE ABOVE";
				tblDiacritGreek[71] = "COMBINING EQUALS SIGN BELOW";
				tblDiacritGreek[72] = "COMBINING DOUBLE VERTICAL LINE BELOW";
				tblDiacritGreek[73] = "COMBINING LEFT ANGLE BELOW";
				tblDiacritGreek[74] = "COMBINING NOT TILDE ABOVE";
				// IPA diacritics for disordered speech
				tblDiacritGreek[75] = "COMBINING HOMOTHETIC ABOVE";
				tblDiacritGreek[76] = "COMBINING ALMOST EQUAL TO ABOVE";
				tblDiacritGreek[77] = "COMBINING LEFT RIGHT ARROW BELOW";
				tblDiacritGreek[78] = "COMBINING UPWARDS ARROW BELOW";
				// Double diacritics
				tblDiacritGreek[96] = "COMBINING DOUBLE TILDE";
				tblDiacritGreek[97] = "COMBINING DOUBLE INVERTED BREVE";
				tblDiacritGreek[98] = "COMBINING DOUBLE RIGHTWARDS ARROW BELOW";
				//
				// GREEK AND COPTIC
				//
				// Based on ISO 8859-7:
				tblDiacritGreek[116] = "GREEK NUMERAL SIGN (dexia keraia)";
				tblDiacritGreek[117] = "GREEK LOWER NUMERAL SIGN (aristeri keraia)";
				tblDiacritGreek[122] = "GREEK YPOGEGRAMMENI (iota subscript)";
				tblDiacritGreek[126] = "GREEK QUESTION MARK (erotimatiko)";
				tblDiacritGreek[132] = "GREEK TONOS";
				tblDiacritGreek[133] = "GREEK DIALYTIKA TONOS";
				tblDiacritGreek[134] = "GREEK CAPITAL LETTER ALPHA WITH TONOS";
				tblDiacritGreek[135] = "GREEK ANO TELEIA (Greek semicolon)";
				tblDiacritGreek[136] = "GREEK CAPITAL LETTER EPSILON WITH TONOS";
				tblDiacritGreek[137] = "GREEK CAPITAL LETTER ETA WITH TONOS";
				tblDiacritGreek[138] = "GREEK CAPITAL LETTER IOTA WITH TONOS";
				tblDiacritGreek[140] = "GREEK CAPITAL LETTER OMICRON WITH TONOS";
				tblDiacritGreek[142] = "GREEK CAPITAL LETTER UPSILON WITH TONOS";
				tblDiacritGreek[143] = "GREEK CAPITAL LETTER OMEGA WITH TONOS";
				tblDiacritGreek[144] = "GREEK SMALL LETTER IOTA WITH DIALYTIKA AND TONOS";
				tblDiacritGreek[145] = "GREEK CAPITAL LETTER ALPHA";
				tblDiacritGreek[146] = "GREEK CAPITAL LETTER BETA";
				tblDiacritGreek[147] = "GREEK CAPITAL LETTER GAMMA";
				tblDiacritGreek[148] = "GREEK CAPITAL LETTER DELTA";
				tblDiacritGreek[149] = "GREEK CAPITAL LETTER EPSILON";
				tblDiacritGreek[150] = "GREEK CAPITAL LETTER ZETA";
				tblDiacritGreek[151] = "GREEK CAPITAL LETTER ETA";
				tblDiacritGreek[152] = "GREEK CAPITAL LETTER THETA";
				tblDiacritGreek[153] = "GREEK CAPITAL LETTER IOTA (iota adscript)";
				tblDiacritGreek[154] = "GREEK CAPITAL LETTER KAPPA";
				tblDiacritGreek[155] = "GREEK CAPITAL LETTER LAMDA";
				tblDiacritGreek[156] = "GREEK CAPITAL LETTER MU";
				tblDiacritGreek[157] = "GREEK CAPITAL LETTER NU";
				tblDiacritGreek[158] = "GREEK CAPITAL LETTER XI";
				tblDiacritGreek[159] = "GREEK CAPITAL LETTER OMICRON";
				tblDiacritGreek[160] = "GREEK CAPITAL LETTER PI";
				tblDiacritGreek[161] = "GREEK CAPITAL LETTER RHO";
				tblDiacritGreek[163] = "GREEK CAPITAL LETTER SIGMA";
				tblDiacritGreek[164] = "GREEK CAPITAL LETTER TAU";
				tblDiacritGreek[165] = "GREEK CAPITAL LETTER UPSILON";
				tblDiacritGreek[166] = "GREEK CAPITAL LETTER PHI";
				tblDiacritGreek[167] = "GREEK CAPITAL LETTER CHI";
				tblDiacritGreek[168] = "GREEK CAPITAL LETTER PSI";
				tblDiacritGreek[169] = "GREEK CAPITAL LETTER OMEGA";
				tblDiacritGreek[170] = "GREEK CAPITAL LETTER IOTA WITH DIALYTIKA";
				tblDiacritGreek[171] = "GREEK CAPITAL LETTER UPSILON WITH DIALYTIKA";
				tblDiacritGreek[172] = "GREEK SMALL LETTER ALPHA WITH TONOS";
				tblDiacritGreek[173] = "GREEK SMALL LETTER EPSILON WITH TONOS";
				tblDiacritGreek[174] = "GREEK SMALL LETTER ETA WITH TONOS";
				tblDiacritGreek[175] = "GREEK SMALL LETTER IOTA WITH TONOS";
				tblDiacritGreek[176] = "GREEK SMALL LETTER UPSILON WITH DIALYTIKA AND TONOS";
				tblDiacritGreek[177] = "GREEK SMALL LETTER ALPHA";
				tblDiacritGreek[178] = "GREEK SMALL LETTER BETA";
				tblDiacritGreek[179] = "GREEK SMALL LETTER GAMMA";
				tblDiacritGreek[180] = "GREEK SMALL LETTER DELTA";
				tblDiacritGreek[181] = "GREEK SMALL LETTER EPSILON";
				tblDiacritGreek[182] = "GREEK SMALL LETTER ZETA";
				tblDiacritGreek[183] = "GREEK SMALL LETTER ETA";
				tblDiacritGreek[184] = "GREEK SMALL LETTER THETA";
				tblDiacritGreek[185] = "GREEK SMALL LETTER IOTA";
				tblDiacritGreek[186] = "GREEK SMALL LETTER KAPPA";
				tblDiacritGreek[187] = "GREEK SMALL LETTER LAMDA";
				tblDiacritGreek[188] = "GREEK SMALL LETTER MU";
				tblDiacritGreek[189] = "GREEK SMALL LETTER NU";
				tblDiacritGreek[190] = "GREEK SMALL LETTER XI";
				tblDiacritGreek[191] = "GREEK SMALL LETTER OMICRON";
				tblDiacritGreek[192] = "GREEK SMALL LETTER PI";
				tblDiacritGreek[193] = "GREEK SMALL LETTER RHO";
				tblDiacritGreek[194] = "GREEK SMALL LETTER FINAL SIGMA";
				tblDiacritGreek[195] = "GREEK SMALL LETTER SIGMA";
				tblDiacritGreek[196] = "GREEK SMALL LETTER TAU";
				tblDiacritGreek[197] = "GREEK SMALL LETTER UPSILON";
				tblDiacritGreek[198] = "GREEK SMALL LETTER PHI";
				tblDiacritGreek[199] = "GREEK SMALL LETTER CHI";
				tblDiacritGreek[200] = "GREEK SMALL LETTER PSI";
				tblDiacritGreek[201] = "GREEK SMALL LETTER OMEGA";
				tblDiacritGreek[202] = "GREEK SMALL LETTER IOTA WITH DIALYTIKA";
				tblDiacritGreek[203] = "GREEK SMALL LETTER UPSILON WITH DIALYTIKA";
				tblDiacritGreek[204] = "GREEK SMALL LETTER OMICRON WITH TONOS";
				tblDiacritGreek[205] = "GREEK SMALL LETTER UPSILON WITH TONOS";
				tblDiacritGreek[206] = "GREEK SMALL LETTER OMEGA WITH TONOS";
				// Variant letter forms:
				tblDiacritGreek[208] = "GREEK BETA SYMBOL = GREEK SMALL LETTER CURLED BETA";
				tblDiacritGreek[209] = "GREEK THETA SYMBOL = GREEK SMALL LETTER SCRIPT THETA";
				tblDiacritGreek[210] = "GREEK UPSILON WITH HOOK SYMBOL = GREEK CAPITAL LETTER UPSILON HOOK";
				tblDiacritGreek[211] = "GREEK UPSILON WITH ACUTE AND HOOK SYMBOL = GREEK CAPITAL LETTER UPSILON HOOK TONOS";
				tblDiacritGreek[212] = "GREEK UPSILON WITH DIAERESIS AND HOOK SYMBOL = GREEK CAPITAL LETTER UPSILON HOOK DIAERESIS";
				tblDiacritGreek[213] = "GREEK PHI SYMBOL = GREEK SMALL LETTER SCRIPT PHI";
				tblDiacritGreek[214] = "GREEK PI SYMBOL = GREEK SMALL LETTER OMEGA PI";
				tblDiacritGreek[215] = "GREEK KAI SYMBOL";
				// Archaic letters:
				tblDiacritGreek[218] = "GREEK LETTER STIGMA";
				tblDiacritGreek[219] = "GREEK SMALL LETTER STIGMA";
				tblDiacritGreek[220] = "GREEK LETTER DIGAMMA";
				tblDiacritGreek[221] = "GREEK SMALL LETTER DIGAMMA";
				tblDiacritGreek[222] = "GREEK LETTER KOPPA";
				tblDiacritGreek[223] = "GREEK SMALL LETTER KOPPA";
				tblDiacritGreek[224] = "GREEK LETTER SAMPI";
				tblDiacritGreek[225] = "GREEK SMALL LETTER SAMPI";
				// Coptic unique letters:
				tblDiacritGreek[226] = "COPTIC CAPITAL LETTER SHEI (shai)";
				tblDiacritGreek[227] = "COPTIC SMALL LETTER SHEI (shai)";
				tblDiacritGreek[228] = "COPTIC CAPITAL LETTER FEI (fai)";
				tblDiacritGreek[229] = "COPTIC SMALL LETTER FEI (fai)";
				tblDiacritGreek[230] = "COPTIC CAPITAL LETTER KHEI (chai)";
				tblDiacritGreek[231] = "COPTIC SMALL LETTER KHEI (chai)";
				tblDiacritGreek[232] = "COPTIC CAPITAL LETTER HORI";
				tblDiacritGreek[233] = "COPTIC SMALL LETTER HORI";
				tblDiacritGreek[234] = "COPTIC CAPITAL LETTER GANGIA (janjia)";
				tblDiacritGreek[235] = "COPTIC SMALL LETTER GANGIA (janjia)";
				tblDiacritGreek[236] = "COPTIC CAPITAL LETTER SHIMA (gima)";
				tblDiacritGreek[237] = "COPTIC SMALL LETTER SHIMA (gima)";
				tblDiacritGreek[238] = "COPTIC CAPITAL LETTER DEI (ti)";
				tblDiacritGreek[239] = "COPTIC SMALL LETTER DEI (ti)";
				// Greek symbols:
				tblDiacritGreek[240] = "GREEK KAPPA SYMBOL = GREEK SMALL LETTER SCRIPT KAPPA";
				tblDiacritGreek[241] = "GREEK RHO SYMBOL = GREEK SMALL LETTER TAILED RHO";
				tblDiacritGreek[242] = "GREEK LUNATE SIGMA SYMBOL = GREEK SMALL LETTER LUNATE SIGMA (i.e. c-shaped sigma)";
				// additional letter:
				tblDiacritGreek[243] = "GREEK LETTER YOT (simply a 'j')";
				// Greek symbols:
				tblDiacritGreek[244] = "GREEK CAPITAL THETA SYMBOL";
				tblDiacritGreek[245] = "GREEK LUNATE EPSILON SYMBOL";
				//
				// GREEK EXTENDED
				//
				tblGreekExtended[0] = "GREEK SMALL LETTER ALPHA WITH PSILI";
				tblGreekExtended[1] = "GREEK SMALL LETTER ALPHA WITH DASIA";
				tblGreekExtended[2] = "GREEK SMALL LETTER ALPHA WITH PSILI AND VARIA";
				tblGreekExtended[3] = "GREEK SMALL LETTER ALPHA WITH DASIA AND VARIA";
				tblGreekExtended[4] = "GREEK SMALL LETTER ALPHA WITH PSILI AND OXIA";
				tblGreekExtended[5] = "GREEK SMALL LETTER ALPHA WITH DASIA AND OXIA";
				tblGreekExtended[6] = "GREEK SMALL LETTER ALPHA WITH PSILI AND PERISPOMENI";
				tblGreekExtended[7] = "GREEK SMALL LETTER ALPHA WITH DASIA AND PERISPOMENI";
				tblGreekExtended[8] = "GREEK CAPITAL LETTER ALPHA WITH PSILI";
				tblGreekExtended[9] = "GREEK CAPITAL LETTER ALPHA WITH DASIA";
				tblGreekExtended[10] = "GREEK CAPITAL LETTER ALPHA WITH PSILI AND VARIA";
				tblGreekExtended[11] = "GREEK CAPITAL LETTER ALPHA WITH DASIA AND VARIA";
				tblGreekExtended[12] = "GREEK CAPITAL LETTER ALPHA WITH PSILI AND OXIA";
				tblGreekExtended[13] = "GREEK CAPITAL LETTER ALPHA WITH DASIA AND OXIA";
				tblGreekExtended[14] = "GREEK CAPITAL LETTER ALPHA WITH PSILI AND PERISPOMENI";
				tblGreekExtended[15] = "GREEK CAPITAL LETTER ALPHA WITH DASIA AND PERISPOMENI";
				tblGreekExtended[16] = "GREEK SMALL LETTER EPSILON WITH PSILI";
				tblGreekExtended[17] = "GREEK SMALL LETTER EPSILON WITH DASIA";
				tblGreekExtended[18] = "GREEK SMALL LETTER EPSILON WITH PSILI AND VARIA";
				tblGreekExtended[19] = "GREEK SMALL LETTER EPSILON WITH DASIA AND VARIA";
				tblGreekExtended[20] = "GREEK SMALL LETTER EPSILON WITH PSILI AND OXIA";
				tblGreekExtended[21] = "GREEK SMALL LETTER EPSILON WITH DASIA AND OXIA";
				tblGreekExtended[24] = "GREEK CAPITAL LETTER EPSILON WITH PSILI";
				tblGreekExtended[25] = "GREEK CAPITAL LETTER EPSILON WITH DASIA";
				tblGreekExtended[26] = "GREEK CAPITAL LETTER EPSILON WITH PSILI AND VARIA";
				tblGreekExtended[27] = "GREEK CAPITAL LETTER EPSILON WITH DASIA AND VARIA";
				tblGreekExtended[28] = "GREEK CAPITAL LETTER EPSILON WITH PSILI AND OXIA";
				tblGreekExtended[29] = "GREEK CAPITAL LETTER EPSILON WITH DASIA AND OXIA";
				tblGreekExtended[32] = "GREEK SMALL LETTER ETA WITH PSILI";
				tblGreekExtended[33] = "GREEK SMALL LETTER ETA WITH DASIA";
				tblGreekExtended[34] = "GREEK SMALL LETTER ETA WITH PSILI AND VARIA";
				tblGreekExtended[35] = "GREEK SMALL LETTER ETA WITH DASIA AND VARIA";
				tblGreekExtended[36] = "GREEK SMALL LETTER ETA WITH PSILI AND OXIA";
				tblGreekExtended[37] = "GREEK SMALL LETTER ETA WITH DASIA AND OXIA";
				tblGreekExtended[38] = "GREEK SMALL LETTER ETA WITH PSILI AND PERISPOMENI";
				tblGreekExtended[39] = "GREEK SMALL LETTER ETA WITH DASIA AND PERISPOMENI";
				tblGreekExtended[40] = "GREEK CAPITAL LETTER ETA WITH PSILI";
				tblGreekExtended[41] = "GREEK CAPITAL LETTER ETA WITH DASIA";
				tblGreekExtended[42] = "GREEK CAPITAL LETTER ETA WITH PSILI AND VARIA";
				tblGreekExtended[43] = "GREEK CAPITAL LETTER ETA WITH DASIA AND VARIA";
				tblGreekExtended[44] = "GREEK CAPITAL LETTER ETA WITH PSILI AND OXIA";
				tblGreekExtended[45] = "GREEK CAPITAL LETTER ETA WITH DASIA AND OXIA";
				tblGreekExtended[46] = "GREEK CAPITAL LETTER ETA WITH PSILI AND PERISPOMENI";
				tblGreekExtended[47] = "GREEK CAPITAL LETTER ETA WITH DASIA AND PERISPOMENI";
				tblGreekExtended[48] = "GREEK SMALL LETTER IOTA WITH PSILI";
				tblGreekExtended[49] = "GREEK SMALL LETTER IOTA WITH DASIA";
				tblGreekExtended[50] = "GREEK SMALL LETTER IOTA WITH PSILI AND VARIA";
				tblGreekExtended[51] = "GREEK SMALL LETTER IOTA WITH DASIA AND VARIA";
				tblGreekExtended[52] = "GREEK SMALL LETTER IOTA WITH PSILI AND OXIA";
				tblGreekExtended[53] = "GREEK SMALL LETTER IOTA WITH DASIA AND OXIA";
				tblGreekExtended[54] = "GREEK SMALL LETTER IOTA WITH PSILI AND PERISPOMENI";
				tblGreekExtended[55] = "GREEK SMALL LETTER IOTA WITH DASIA AND PERISPOMENI";
				tblGreekExtended[56] = "GREEK CAPITAL LETTER IOTA WITH PSILI";
				tblGreekExtended[57] = "GREEK CAPITAL LETTER IOTA WITH DASIA";
				tblGreekExtended[58] = "GREEK CAPITAL LETTER IOTA WITH PSILI AND VARIA";
				tblGreekExtended[59] = "GREEK CAPITAL LETTER IOTA WITH DASIA AND VARIA";
				tblGreekExtended[60] = "GREEK CAPITAL LETTER IOTA WITH PSILI AND OXIA";
				tblGreekExtended[61] = "GREEK CAPITAL LETTER IOTA WITH DASIA AND OXIA";
				tblGreekExtended[62] = "GREEK CAPITAL LETTER IOTA WITH PSILI AND PERISPOMENI";
				tblGreekExtended[63] = "GREEK CAPITAL LETTER IOTA WITH DASIA AND PERISPOMENI";
				tblGreekExtended[64] = "GREEK SMALL LETTER OMICRON WITH PSILI";
				tblGreekExtended[65] = "GREEK SMALL LETTER OMICRON WITH DASIA";
				tblGreekExtended[66] = "GREEK SMALL LETTER OMICRON WITH PSILI AND VARIA";
				tblGreekExtended[67] = "GREEK SMALL LETTER OMICRON WITH DASIA AND VARIA";
				tblGreekExtended[68] = "GREEK SMALL LETTER OMICRON WITH PSILI AND OXIA";
				tblGreekExtended[69] = "GREEK SMALL LETTER OMICRON WITH DASIA AND OXIA";
				tblGreekExtended[72] = "GREEK CAPITAL LETTER OMICRON WITH PSILI";
				tblGreekExtended[73] = "GREEK CAPITAL LETTER OMICRON WITH DASIA";
				tblGreekExtended[74] = "GREEK CAPITAL LETTER OMICRON WITH PSILI AND VARIA";
				tblGreekExtended[75] = "GREEK CAPITAL LETTER OMICRON WITH DASIA AND VARIA";
				tblGreekExtended[76] = "GREEK CAPITAL LETTER OMICRON WITH PSILI AND OXIA";
				tblGreekExtended[77] = "GREEK CAPITAL LETTER OMICRON WITH DASIA AND OXIA";
				tblGreekExtended[80] = "GREEK SMALL LETTER UPSILON WITH PSILI";
				tblGreekExtended[81] = "GREEK SMALL LETTER UPSILON WITH DASIA";
				tblGreekExtended[82] = "GREEK SMALL LETTER UPSILON WITH PSILI AND VARIA";
				tblGreekExtended[83] = "GREEK SMALL LETTER UPSILON WITH DASIA AND VARIA";
				tblGreekExtended[84] = "GREEK SMALL LETTER UPSILON WITH PSILI AND OXIA";
				tblGreekExtended[85] = "GREEK SMALL LETTER UPSILON WITH DASIA AND OXIA";
				tblGreekExtended[86] = "GREEK SMALL LETTER UPSILON WITH PSILI AND PERISPOMENI";
				tblGreekExtended[87] = "GREEK SMALL LETTER UPSILON WITH DASIA AND PERISPOMENI";
				tblGreekExtended[89] = "GREEK CAPITAL LETTER UPSILON WITH DASIA";
				tblGreekExtended[91] = "GREEK CAPITAL LETTER UPSILON WITH DASIA AND VARIA";
				tblGreekExtended[93] = "GREEK CAPITAL LETTER UPSILON WITH DASIA AND OXIA";
				tblGreekExtended[95] = "GREEK CAPITAL LETTER UPSILON WITH DASIA AND PERISPOMENI";
				tblGreekExtended[96] = "GREEK SMALL LETTER OMEGA WITH PSILI";
				tblGreekExtended[97] = "GREEK SMALL LETTER OMEGA WITH DASIA";
				tblGreekExtended[98] = "GREEK SMALL LETTER OMEGA WITH PSILI AND VARIA";
				tblGreekExtended[99] = "GREEK SMALL LETTER OMEGA WITH DASIA AND VARIA";
				tblGreekExtended[100] = "GREEK SMALL LETTER OMEGA WITH PSILI AND OXIA";
				tblGreekExtended[101] = "GREEK SMALL LETTER OMEGA WITH DASIA AND OXIA";
				tblGreekExtended[102] = "GREEK SMALL LETTER OMEGA WITH PSILI AND PERISPOMENI";
				tblGreekExtended[103] = "GREEK SMALL LETTER OMEGA WITH DASIA AND PERISPOMENI";
				tblGreekExtended[104] = "GREEK CAPITAL LETTER OMEGA WITH PSILI";
				tblGreekExtended[105] = "GREEK CAPITAL LETTER OMEGA WITH DASIA";
				tblGreekExtended[106] = "GREEK CAPITAL LETTER OMEGA WITH PSILI AND VARIA";
				tblGreekExtended[107] = "GREEK CAPITAL LETTER OMEGA WITH DASIA AND VARIA";
				tblGreekExtended[108] = "GREEK CAPITAL LETTER OMEGA WITH PSILI AND OXIA";
				tblGreekExtended[109] = "GREEK CAPITAL LETTER OMEGA WITH DASIA AND OXIA";
				tblGreekExtended[110] = "GREEK CAPITAL LETTER OMEGA WITH PSILI AND PERISPOMENI";
				tblGreekExtended[111] = "GREEK CAPITAL LETTER OMEGA WITH DASIA AND PERISPOMENI";
				tblGreekExtended[112] = "GREEK SMALL LETTER ALPHA WITH VARIA";
				tblGreekExtended[113] = "GREEK SMALL LETTER ALPHA WITH OXIA";
				tblGreekExtended[114] = "GREEK SMALL LETTER EPSILON WITH VARIA";
				tblGreekExtended[115] = "GREEK SMALL LETTER EPSILON WITH OXIA";
				tblGreekExtended[116] = "GREEK SMALL LETTER ETA WITH VARIA";
				tblGreekExtended[117] = "GREEK SMALL LETTER ETA WITH OXIA";
				tblGreekExtended[118] = "GREEK SMALL LETTER IOTA WITH VARIA";
				tblGreekExtended[119] = "GREEK SMALL LETTER IOTA WITH OXIA";
				tblGreekExtended[120] = "GREEK SMALL LETTER OMICRON WITH VARIA";
				tblGreekExtended[121] = "GREEK SMALL LETTER OMICRON WITH OXIA";
				tblGreekExtended[122] = "GREEK SMALL LETTER UPSILON WITH VARIA";
				tblGreekExtended[123] = "GREEK SMALL LETTER UPSILON WITH OXIA";
				tblGreekExtended[124] = "GREEK SMALL LETTER OMEGA WITH VARIA";
				tblGreekExtended[125] = "GREEK SMALL LETTER OMEGA WITH OXIA";
				tblGreekExtended[128] = "GREEK SMALL LETTER ALPHA WITH PSILI AND YPOGEGRAMMENI";
				tblGreekExtended[129] = "GREEK SMALL LETTER ALPHA WITH DASIA AND YPOGEGRAMMENI";
				tblGreekExtended[130] = "GREEK SMALL LETTER ALPHA WITH PSILI AND VARIA AND YPOGEGRAMMENI";
				tblGreekExtended[131] = "GREEK SMALL LETTER ALPHA WITH DASIA AND VARIA AND YPOGEGRAMMENI";
				tblGreekExtended[132] = "GREEK SMALL LETTER ALPHA WITH PSILI AND OXIA AND YPOGEGRAMMENI";
				tblGreekExtended[133] = "GREEK SMALL LETTER ALPHA WITH DASIA AND OXIA AND YPOGEGRAMMENI";
				tblGreekExtended[134] = "GREEK SMALL LETTER ALPHA WITH PSILI AND PERISPOMENI AND YPOGEGRAMMENI";
				tblGreekExtended[135] = "GREEK SMALL LETTER ALPHA WITH DASIA AND PERISPOMENI AND YPOGEGRAMMENI";
				tblGreekExtended[136] = "GREEK CAPITAL LETTER ALPHA WITH PSILI AND PROSGEGRAMMENI";
				tblGreekExtended[137] = "GREEK CAPITAL LETTER ALPHA WITH DASIA AND PROSGEGRAMMENI";
				tblGreekExtended[138] = "GREEK CAPITAL LETTER ALPHA WITH PSILI AND VARIA AND PROSGEGRAMMENI";
				tblGreekExtended[139] = "GREEK CAPITAL LETTER ALPHA WITH DASIA AND VARIA AND PROSGEGRAMMENI";
				tblGreekExtended[140] = "GREEK CAPITAL LETTER ALPHA WITH PSILI AND OXIA AND PROSGEGRAMMENI";
				tblGreekExtended[141] = "GREEK CAPITAL LETTER ALPHA WITH DASIA AND OXIA AND PROSGEGRAMMENI";
				tblGreekExtended[142] = "GREEK CAPITAL LETTER ALPHA WITH PSILI AND PERISPOMENI AND PROSGEGRAMMENI";
				tblGreekExtended[143] = "GREEK CAPITAL LETTER ALPHA WITH DASIA AND PERISPOMENI AND PROSGEGRAMMENI";
				tblGreekExtended[144] = "GREEK SMALL LETTER ETA WITH PSILI AND YPOGEGRAMMENI";
				tblGreekExtended[145] = "GREEK SMALL LETTER ETA WITH DASIA AND YPOGEGRAMMENI";
				tblGreekExtended[146] = "GREEK SMALL LETTER ETA WITH PSILI AND VARIA AND YPOGEGRAMMENI";
				tblGreekExtended[147] = "GREEK SMALL LETTER ETA WITH DASIA AND VARIA AND YPOGEGRAMMENI";
				tblGreekExtended[148] = "GREEK SMALL LETTER ETA WITH PSILI AND OXIA AND YPOGEGRAMMENI";
				tblGreekExtended[149] = "GREEK SMALL LETTER ETA WITH DASIA AND OXIA AND YPOGEGRAMMENI";
				tblGreekExtended[150] = "GREEK SMALL LETTER ETA WITH PSILI AND PERISPOMENI AND YPOGEGRAMMENI";
				tblGreekExtended[151] = "GREEK SMALL LETTER ETA WITH DASIA AND PERISPOMENI AND YPOGEGRAMMENI";
				tblGreekExtended[152] = "GREEK CAPITAL LETTER ETA WITH PSILI AND PROSGEGRAMMENI";
				tblGreekExtended[153] = "GREEK CAPITAL LETTER ETA WITH DASIA AND PROSGEGRAMMENI";
				tblGreekExtended[154] = "GREEK CAPITAL LETTER ETA WITH PSILI AND VARIA AND PROSGEGRAMMENI";
				tblGreekExtended[155] = "GREEK CAPITAL LETTER ETA WITH DASIA AND VARIA AND PROSGEGRAMMENI";
				tblGreekExtended[156] = "GREEK CAPITAL LETTER ETA WITH PSILI AND OXIA AND PROSGEGRAMMENI";
				tblGreekExtended[157] = "GREEK CAPITAL LETTER ETA WITH DASIA AND OXIA AND PROSGEGRAMMENI";
				tblGreekExtended[158] = "GREEK CAPITAL LETTER ETA WITH PSILI AND PERISPOMENI AND PROSGEGRAMMENI";
				tblGreekExtended[159] = "GREEK CAPITAL LETTER ETA WITH DASIA AND PERISPOMENI AND PROSGEGRAMMENI";
				tblGreekExtended[160] = "GREEK SMALL LETTER OMEGA WITH PSILI AND YPOGEGRAMMENI";
				tblGreekExtended[161] = "GREEK SMALL LETTER OMEGA WITH DASIA AND YPOGEGRAMMENI";
				tblGreekExtended[162] = "GREEK SMALL LETTER OMEGA WITH PSILI AND VARIA AND YPOGEGRAMMENI";
				tblGreekExtended[163] = "GREEK SMALL LETTER OMEGA WITH DASIA AND VARIA AND YPOGEGRAMMENI";
				tblGreekExtended[164] = "GREEK SMALL LETTER OMEGA WITH PSILI AND OXIA AND YPOGEGRAMMENI";
				tblGreekExtended[165] = "GREEK SMALL LETTER OMEGA WITH DASIA AND OXIA AND YPOGEGRAMMENI";
				tblGreekExtended[166] = "GREEK SMALL LETTER OMEGA WITH PSILI AND PERISPOMENI AND YPOGEGRAMMENI";
				tblGreekExtended[167] = "GREEK SMALL LETTER OMEGA WITH DASIA AND PERISPOMENI AND YPOGEGRAMMENI";
				tblGreekExtended[168] = "GREEK CAPITAL LETTER OMEGA WITH PSILI AND PROSGEGRAMMENI";
				tblGreekExtended[169] = "GREEK CAPITAL LETTER OMEGA WITH DASIA AND PROSGEGRAMMENI";
				tblGreekExtended[170] = "GREEK CAPITAL LETTER OMEGA WITH PSILI AND VARIA AND PROSGEGRAMMENI";
				tblGreekExtended[171] = "GREEK CAPITAL LETTER OMEGA WITH DASIA AND VARIA AND PROSGEGRAMMENI";
				tblGreekExtended[172] = "GREEK CAPITAL LETTER OMEGA WITH PSILI AND OXIA AND PROSGEGRAMMENI";
				tblGreekExtended[173] = "GREEK CAPITAL LETTER OMEGA WITH DASIA AND OXIA AND PROSGEGRAMMENI";
				tblGreekExtended[174] = "GREEK CAPITAL LETTER OMEGA WITH PSILI AND PERISPOMENI AND PROSGEGRAMMENI";
				tblGreekExtended[175] = "GREEK CAPITAL LETTER OMEGA WITH DASIA AND PERISPOMENI AND PROSGEGRAMMENI";
				tblGreekExtended[176] = "GREEK SMALL LETTER ALPHA WITH VRACHY";
				tblGreekExtended[177] = "GREEK SMALL LETTER ALPHA WITH MACRON";
				tblGreekExtended[178] = "GREEK SMALL LETTER ALPHA WITH VARIA AND YPOGEGRAMMENI";
				tblGreekExtended[179] = "GREEK SMALL LETTER ALPHA WITH YPOGEGRAMMENI";
				tblGreekExtended[180] = "GREEK SMALL LETTER ALPHA WITH OXIA AND YPOGEGRAMMENI";
				tblGreekExtended[182] = "GREEK SMALL LETTER ALPHA WITH PERISPOMENI";
				tblGreekExtended[183] = "GREEK SMALL LETTER ALPHA WITH PERISPOMENI AND YPOGEGRAMMENI";
				tblGreekExtended[184] = "GREEK CAPITAL LETTER ALPHA WITH VRACHY";
				tblGreekExtended[185] = "GREEK CAPITAL LETTER ALPHA WITH MACRON";
				tblGreekExtended[186] = "GREEK CAPITAL LETTER ALPHA WITH VARIA";
				tblGreekExtended[187] = "GREEK CAPITAL LETTER ALPHA WITH OXIA";
				tblGreekExtended[188] = "GREEK CAPITAL LETTER ALPHA WITH PROSGEGRAMMENI";
				tblGreekExtended[189] = "GREEK KORONIS";
				tblGreekExtended[190] = "GREEK PROSGEGRAMMENI";
				tblGreekExtended[191] = "GREEK PSILI";
				tblGreekExtended[192] = "GREEK PERISPOMENI";
				tblGreekExtended[193] = "GREEK DIALYTIKA AND PERISPOMENI";
				tblGreekExtended[194] = "GREEK SMALL LETTER ETA WITH VARIA AND YPOGEGRAMMENI";
				tblGreekExtended[195] = "GREEK SMALL LETTER ETA WITH YPOGEGRAMMENI";
				tblGreekExtended[196] = "GREEK SMALL LETTER ETA WITH OXIA AND YPOGEGRAMMENI";
				tblGreekExtended[198] = "GREEK SMALL LETTER ETA WITH PERISPOMENI";
				tblGreekExtended[199] = "GREEK SMALL LETTER ETA WITH PERISPOMENI AND YPOGEGRAMMENI";
				tblGreekExtended[200] = "GREEK CAPITAL LETTER EPSILON WITH VARIA";
				tblGreekExtended[201] = "GREEK CAPITAL LETTER EPSILON WITH OXIA";
				tblGreekExtended[202] = "GREEK CAPITAL LETTER ETA WITH VARIA";
				tblGreekExtended[203] = "GREEK CAPITAL LETTER ETA WITH OXIA";
				tblGreekExtended[204] = "GREEK CAPITAL LETTER ETA WITH PROSGEGRAMMENI";
				tblGreekExtended[205] = "GREEK PSILI AND VARIA";
				tblGreekExtended[206] = "GREEK PSILI AND OXIA";
				tblGreekExtended[207] = "GREEK PSILI AND PERISPOMENI";
				tblGreekExtended[208] = "GREEK SMALL LETTER IOTA WITH VRACHY";
				tblGreekExtended[209] = "GREEK SMALL LETTER IOTA WITH MACRON";
				tblGreekExtended[210] = "GREEK SMALL LETTER IOTA WITH DIALYTIKA AND VARIA";
				tblGreekExtended[211] = "GREEK SMALL LETTER IOTA WITH DIALYTIKA AND OXIA";
				tblGreekExtended[214] = "GREEK SMALL LETTER IOTA WITH PERISPOMENI";
				tblGreekExtended[215] = "GREEK SMALL LETTER IOTA WITH DIALYTIKA AND PERISPOMENI";
				tblGreekExtended[216] = "GREEK CAPITAL LETTER IOTA WITH VRACHY";
				tblGreekExtended[217] = "GREEK CAPITAL LETTER IOTA WITH MACRON";
				tblGreekExtended[218] = "GREEK CAPITAL LETTER IOTA WITH VARIA";
				tblGreekExtended[219] = "GREEK CAPITAL LETTER IOTA WITH OXIA";
				tblGreekExtended[221] = "GREEK DASIA AND VARIA";
				tblGreekExtended[222] = "GREEK DASIA AND OXIA";
				tblGreekExtended[223] = "GREEK DASIA AND PERISPOMENI";
				tblGreekExtended[224] = "GREEK SMALL LETTER UPSILON WITH VRACHY";
				tblGreekExtended[225] = "GREEK SMALL LETTER UPSILON WITH MACRON";
				tblGreekExtended[226] = "GREEK SMALL LETTER UPSILON WITH DIALYTIKA AND VARIA";
				tblGreekExtended[227] = "GREEK SMALL LETTER UPSILON WITH DIALYTIKA AND OXIA";
				tblGreekExtended[228] = "GREEK SMALL LETTER RHO WITH PSILI";
				tblGreekExtended[229] = "GREEK SMALL LETTER RHO WITH DASIA";
				tblGreekExtended[230] = "GREEK SMALL LETTER UPSILON WITH PERISPOMENI";
				tblGreekExtended[231] = "GREEK SMALL LETTER UPSILON WITH DIALYTIKA AND PERISPOMENI";
				tblGreekExtended[232] = "GREEK CAPITAL LETTER UPSILON WITH VRACHY";
				tblGreekExtended[233] = "GREEK CAPITAL LETTER UPSILON WITH MACRON";
				tblGreekExtended[234] = "GREEK CAPITAL LETTER UPSILON WITH VARIA";
				tblGreekExtended[235] = "GREEK CAPITAL LETTER UPSILON WITH OXIA";
				tblGreekExtended[236] = "GREEK CAPITAL LETTER RHO WITH DASIA";
				tblGreekExtended[237] = "GREEK DIALYTIKA AND VARIA";
				tblGreekExtended[238] = "GREEK DIALYTIKA AND OXIA";
				tblGreekExtended[239] = "GREEK VARIA";
				tblGreekExtended[242] = "GREEK SMALL LETTER OMEGA WITH VARIA AND YPOGEGRAMMENI";
				tblGreekExtended[243] = "GREEK SMALL LETTER OMEGA WITH YPOGEGRAMMENI";
				tblGreekExtended[244] = "GREEK SMALL LETTER OMEGA WITH OXIA AND YPOGEGRAMMENI";
				tblGreekExtended[246] = "GREEK SMALL LETTER OMEGA WITH PERISPOMENI";
				tblGreekExtended[247] = "GREEK SMALL LETTER OMEGA WITH PERISPOMENI AND YPOGEGRAMMENI";
				tblGreekExtended[248] = "GREEK CAPITAL LETTER OMICRON WITH VARIA";
				tblGreekExtended[249] = "GREEK CAPITAL LETTER OMICRON WITH OXIA";
				tblGreekExtended[250] = "GREEK CAPITAL LETTER OMEGA WITH VARIA";
				tblGreekExtended[251] = "GREEK CAPITAL LETTER OMEGA WITH OXIA";
				tblGreekExtended[252] = "GREEK CAPITAL LETTER OMEGA WITH PROSGEGRAMMENI";
				tblGreekExtended[253] = "GREEK OXIA";
				tblGreekExtended[254] = "GREEK DASIA";
				//
				// GENERAL PUNCTIATION
				//
				// Spaces
				tblPunct[0] = "EN QUAD"; // n-width space, = 2002
				tblPunct[1] = "EM QUAD"; // m-width space, = 2003
				tblPunct[2] = "EN SPACE"; //  ~ 0020 SPACE
				tblPunct[3] = "EM SPACE";
				tblPunct[4] = "THREE-PER-EM SPACE"; // ~ 0020 SPACE
				tblPunct[5] = "FOUR-PER-EM SPACE"; // ~ 0020 SPACE
				tblPunct[6] = "SIX-PER-EM SPACE"; // ~ 0020 SPACE
				tblPunct[7] = "FIGURE SPACE"; // ~ <NO BRAKE> 0020 SPACE
				tblPunct[8] = "PUNCTUATION SPACE"; // ~ 0020 SPACE
				tblPunct[9] = "THIN SPACE"; // ~ 0020 SPACE
				tblPunct[10] = "HAIR SPACE"; // ~ 0020 SPACE
				tblPunct[11] = "ZERO WIDTH SPACE";
				// Formatting characters
				tblPunct[12] = "ZERO WIDTH NON-JOINER";
				tblPunct[13] = "ZERO WIDTH JOINER";
				tblPunct[14] = "LEFT-TO-RIGHT MARK";
				tblPunct[15] = "RIGHT-TO-LEFT-MARK";
				// Dashes
				tblPunct[16] = "HYPHEN";
				tblPunct[17] = "NON-BREAKING HYPHEN";
				tblPunct[18] = "FIGURE DASH";
				tblPunct[19] = "EN DASH";
				tblPunct[20] = "EM DASH";
				tblPunct[21] = "HORIZONTAL BAR - QUOTATION DASH";
				// General punctuation
				tblPunct[22] = "DOUBLE VERTICAL LINE";
				tblPunct[23] = "DOUBLE LOW LINE"; // spacing char.
				tblPunct[24] = "LEFT SINGLE QUOTATION MARK - SINGLE TURNED COMMA QUOTATION MARK";
				tblPunct[25] = "RIGHT SINGLE QUOTATION MARK - SINGLE COMMA QUOTATION MARK"; // apostrophe
				tblPunct[26] = "SINGLE LOW-9 QUOTATION MARK - LOW SINGLE COMMA QUOTATION MARK";
				tblPunct[27] = "SINGLE HIGH-REVERSED-9 QUOTATION MARK - SINGLE REVERSED COMMA QUOTATION MARK"; // variant of 2018
				tblPunct[28] = "LEFT DOUBLE QUOTATION MARK - DOUBLE TURNED COMMA QUOTATION MARK";
				tblPunct[29] = "RIGHT DOUBLE QUOTATION MARK - DOUBLE COMMA QUOTATION MARK";
				tblPunct[30] = "DOUBLE LOW-9 QUOTATION MARK - LOW DOUBLE COMMA QUOTATION MARK";
				tblPunct[31] = "DOUBLE HIGH-REVERSED-9 QUOTATION MARK - DOUBLE REVERSED COMMA QUOTATION MARK"; // variant of 201C
				tblPunct[32] = "DAGGER (obelisk)";
				tblPunct[33] = "DOUBLE DAGGER";
				tblPunct[34] = "BULLET";
				tblPunct[35] = "TRIANGULAR BULLET";
				tblPunct[36] = "ONE DOT LEADER"; // ~ 002E full stop
				tblPunct[37] = "TWO DOT LEADER"; // .. (2 times 002E)
				tblPunct[38] = "HORIZONTAL ELLIPSIS"; // ...
				tblPunct[39] = "HYPHENATION POINT";
				// Formatting characters
				tblPunct[40] = "LINE SEPARATOR";
				tblPunct[41] = "PARAGRAPH SEPARATOR";
				tblPunct[42] = "LEFT-TO-RIGHT EMBEDDING";
				tblPunct[43] = "RIGHT-TO-LEFT EMBEDDING";
				tblPunct[44] = "POP DIRECTIONAL FORMATTING";
				tblPunct[45] = "LEFT-TO-RIGHT OVERRIDE";
				tblPunct[46] = "RIGHT-TO-LEFT OVERRIDE";
				tblPunct[47] = "NARROW NO-BREAK SPACE";
				// General punctuation
				tblPunct[48] = "PER MILLE SIGN";
				tblPunct[49] = "PER TEN THOUSAND SIGN";
				tblPunct[50] = "PRIME";
				tblPunct[51] = "DOUBLE PRIME";
				tblPunct[52] = "TRIPLE PRIME";
				tblPunct[53] = "REVERSED PRIME";
				tblPunct[54] = "REVERSED DOUBLE PRIME";
				tblPunct[55] = "REVERSED TRIPLE PRIME";
				tblPunct[56] = "CARET";
				tblPunct[57] = "SINGLE LEFT-POINTING ANGLE QUOTATION MARK - LEFT POINTING SINGLE GUILLEMET";
				tblPunct[58] = "SINGLE RIGHT-POINTING ANGLE QUOTATION MARK - RIGHT POINTING SINGLE GUILLEMET";
				tblPunct[59] = "REFERENCE MARK";
				tblPunct[60] = "DOUBLE EXCLAMATION MARK"; // ~ !!
				tblPunct[61] = "INTERROBANG"; // overlapping ? and !
				tblPunct[62] = "OVERLINE - SPACING OVERSCORE";
				tblPunct[63] = "UNDERTIE";
				tblPunct[64] = "CHARACTER TIE";
				tblPunct[65] = "CARET INSERTION POINT"; // proofreader's insertion mark
				tblPunct[66] = "ASTERISM";
				tblPunct[67] = "HYPHEN BULLET";
				tblPunct[68] = "FRACTION SLASH"; // = solidus (slash)
				tblPunct[69] = "LEFT SQUARE BRACKET WITH QUILL";
				tblPunct[70] = "RIGHT SQUARE BRACKET WITH QUILL";
				tblPunct[71] = NOT_ASSIGNED;
				tblPunct[72] = "QUESTION EXCLAMATION MARK"; // ~ ?!
				tblPunct[73] = "EXCLAMATION QUESTION MARK"; // ~ !?
				tblPunct[74] = "TIRONIAN SIGN ET";
				tblPunct[75] = "REVERSED PILCROW SIGN";
				tblPunct[76] = "BLACK LEFTWARDS BULLET";
				tblPunct[77] = "BLACK RIGHTWARDS BULLET";
				// Deprecated
				tblPunct[106] = "INHIBIT SYMMETRIC SWAPPING";
				tblPunct[107] = "ACTIVATE SYMMETRIC SWAPPING";
				tblPunct[108] = "INHIBIT ARABIC FORM SHAPING";
				tblPunct[109] = "ACTIVATE ARABIC FORM SHAPING";
				tblPunct[110] = "NATIONAL DIGIT SHAPES";
				tblPunct[111] = "NOMINAL DIGIT SHAPES";
			}
		}
	}
}