namespace greekconverter
{
	using System;
	
	/// <summary> Unicode -> Betacode
	/// *
	/// </summary>
	/// <version>  16-Sep-2002
	/// </version>
	/// <author>   Michael Neuhold
	/// </author>
	
	public class UnicodeToBetacode
	{
		private const int currLang = 1; // 0 for Latin, 1 for Greek, the latter is assumed as default
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NOT_SUPPORTED " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String NOT_SUPPORTED = new System.String("[1?]".ToCharArray());
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NOT_ASSIGNED " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String NOT_ASSIGNED = new System.String("[2?]".ToCharArray());
		
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
				
				case 0:  info = "16-Sep-2002"; break;
				
				case 1:  info = "Converts precomposed Unicode into Betacode"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Vis consili expers mole ruit sua.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Converts a string consisting of Greek Unicode text into Beta coding.
		/// <p>
		/// The following restrictions apply to this procedure at the moment:
		/// <ul>
		/// <li>CAPITAL_&lt;LETTER&gt;_PROSGEGRAMMENI is always rendered as *&lt;LETTER&gt;|. Betacode
		/// knows also *|&lt;LETTER&gt; (a capital letter with a iota subscript), Unicode must use a
		/// decomposed representation like CAPITAL_&lt;LETTER&gt + YPOGEGRAMMENI for this.</li>
		/// <li>&lt;LETTER&gt;_SYMBOL is rendered identical to the base letter &lt;LETTER&gt;.</li>
		/// <li>Coptic is no longer supported here, it requires a more complex logic.</li>
		/// <li>The font switching escapes ("$", "&") have to be inserted manually, since a really
		/// sophisticated recognition of the language intedend is not my main scope and would slow
		/// down program execution.</li>
		/// </ul>
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode string
		/// </param>
		/// <returns>  the string converted into Beta coding
		/// </returns>
		
		public static System.String convertString(System.String uniString)
		{
			
			int strLen = uniString.Length, strPos;
			
			System.Text.StringBuilder nameString = new System.Text.StringBuilder(strLen * 50);
			
			MessageHandler.clearMsgQueue();
			for (strPos = 0; strPos < strLen; strPos++)
			{
				nameString.Append(convertChar(uniString[strPos]));
				MessageHandler.enqueueMsg(" at pos. " + (strPos + 1).ToString() + "\n");
			}
			return nameString.ToString();
		}
		
		/*
		* Returns the Betacode equivalent of the character given as argument.*/
		internal static System.String convertChar(char uniChar)
		{
			int hibyte = uniChar >> 8;
			// look up [hibyte][lobyte]:
			// hibyte = uniChar/256 (bitshifting is faster than dividing, therefore >>8)
			// lobyte = trailing 8 bit of uniChar (masked out with bitwise AND)
			System.String s = tblLookup[hibyte][uniChar & 255];
			
			// if character can not be translated then report its hex value:
			if ((s == NOT_SUPPORTED) || (s == NOT_ASSIGNED))
			{
				return "U+" + System.Convert.ToString((int) uniChar, 16) + s;
			}
			else
			{
				// later a sophisticated recognition of the language and prefixing the rendering
				// with font switching escapes "&" or "$" can be inserted here; now we ignore
				// the language:
				return s;
			}
		}
		static UnicodeToBetacode()
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
					tblLatin1[i] = ((char) i).ToString();
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
				tblLatin1[33] = "%4"; // !
				tblLatin1[34] = "\""; // quotation mark
				tblLatin1[35] = "%101"; // # (unused)
				tblLatin1[36] = "#1219"; // $
				tblLatin1[37] = "%8"; // %
				tblLatin1[38] = "%9"; // &
				tblLatin1[39] = "'"; // apostrophe, %102 opening single quote is obsolete
				tblLatin1[40] = "[1"; // (
				
				tblLatin1[41] = "]1"; // )
				
				tblLatin1[42] = "%2"; // *
				
				tblLatin1[43] = "%7"; // +
				
				tblLatin1[44] = ",";
				
				tblLatin1[45] = "-"; // in Betacode only hyphen, minus is %160 but unused
				
				tblLatin1[46] = ".";
				
				tblLatin1[47] = "%3"; // / (slash)
				
				// 48-57 digits zero through nine
				
				tblLatin1[58] = ":"; // in Betacode Roman colon and semicolon, Greek dot above
				
				tblLatin1[59] = ";"; // Greek question mark in Unicode, too
				
				tblLatin1[60] = "[2"; // < (angle bracket)
				
				tblLatin1[61] = "%6"; // =
				
				tblLatin1[62] = "]2"; // > (angle bracket)
				
				tblLatin1[63] = "%1"; // ?
				
				tblLatin1[64] = "1220"; // @
				
				// 65-90 capital letters
				
				tblLatin1[91] = "[";
				
				tblLatin1[92] = "%103"; // \
				
				tblLatin1[93] = "]";
				
				tblLatin1[94] = "%34"; // spacing circumflex acc.
				
				tblLatin1[95] = "_"; // is not a Betacode metacharacter, is it?
				
				tblLatin1[96] = "%33"; // spacing grave acc.
				
				// 97-122 small letters
				
				tblLatin1[123] = "[3"; // {
				
				tblLatin1[124] = "%5"; // |
				
				tblLatin1[125] = "]3"; // }
				
				tblLatin1[126] = "%107"; // ~
				
				//  tblLatin1[127] = "<control> DELETE";
				
				// C1 controls (alias names for ISO 6429): 128-159
				
				// ISO 8859-1 (aka Latin-1)
				
				tblLatin1[160] = " "; // no-break space
				
				tblLatin1[161] = "%1"; // inverted exclamation mark
				
				tblLatin1[162] = "#1200"; // ¢ cent sign
				
				tblLatin1[163] = "#1202"; // £ pound sign
				
				tblLatin1[164] = "%1"; // currency sign
				
				tblLatin1[165] = "%1"; // yen sign
				
				tblLatin1[166] = "%16"; // ¦
				
				tblLatin1[167] = "%14"; // §
				tblLatin1[168] = "%39"; // ¨ spacing diaeresis
				
				tblLatin1[169] = "#1225"; // © copyrigh sign
				
				tblLatin1[170] = "&4a&"; // fem. ordinal indic., a superscript a
				
				tblLatin1[171] = "\"6"; // « left pointing guillemet
				
				tblLatin1[172] = "%1"; // not sign
				tblLatin1[173] = "-"; // soft hyphen (non-breaking hyphen?)
				
				tblLatin1[174] = "%1"; // registered sign
				
				tblLatin1[175] = "%41"; // spacing macron, %41 is metrical long, I assume this is a spacing character
				
				tblLatin1[176] = "#1204"; // ° degree sign
				
				tblLatin1[177] = "%108"; // ±
				
				tblLatin1[178] = "&4‘2&"; // superscript 2
				
				tblLatin1[179] = "&4‘3&"; // sup. 3
				
				tblLatin1[180] = "%32"; // spacing acute acc.
				
				tblLatin1[181] = "$M&"; // micro sign, a lowercase Greek my
				
				tblLatin1[182] = "%163"; // ¶ unused
				
				tblLatin1[183] = ":"; // middle dot in Unicode used as bullet, hyphenation point and Greek middle dot
				
				// in Betacode Greek raised dot is :, %109 to delimit Roman numerals, %146 Latin word divider unused
				
				tblLatin1[184] = NOT_SUPPORTED; // there seems to be no spacing cedilla in Betacode
				
				tblLatin1[185] = "&4‘1&"; // sup. 1
				
				tblLatin1[186] = "&4o&"; // masc. ordinal indic., a superscript o
				
				tblLatin1[187] = "\"6"; // » right pointing guillemet
				
				tblLatin1[188] = "&19‘1/4&"; //¼ one quarter
				
				tblLatin1[189] = "&19‘1/2&"; // ½ one half, but &19 (begin fraction) unused
				
				tblLatin1[190] = "&19‘3/4&"; // ¾ three quarters
				
				tblLatin1[191] = "%1"; // inverted question mark
				
				tblLatin1[192] = "A\\";
				
				tblLatin1[193] = "A/";
				
				tblLatin1[194] = "A=";
				
				tblLatin1[195] = "A%24"; // Ã
				
				tblLatin1[196] = "A+"; // Ä
				
				tblLatin1[197] = "A%147"; // Å
				
				tblLatin1[198] = "#1215"; // capital ligature AE
				
				tblLatin1[199] = "C%25"; // Ç
				
				tblLatin1[200] = "E\\";
				
				tblLatin1[201] = "E/";
				
				tblLatin1[202] = "E=";
				
				tblLatin1[203] = "E+";
				
				tblLatin1[204] = "I\\";
				
				tblLatin1[205] = "I/";
				
				tblLatin1[206] = "I=";
				
				tblLatin1[207] = "I+";
				
				tblLatin1[208] = "#1212"; // Ð capital eth, the Betacode escape refers to Franklin's phonetic alphabet;
				
				// #1119 looks similar, but is sort of a numerical sign from Varro and Val. Probus
				
				tblLatin1[209] = "N%24"; // Ñ
				
				tblLatin1[210] = "O\\";
				
				tblLatin1[211] = "O/";
				
				tblLatin1[212] = "O=";
				tblLatin1[213] = "O%24"; // Õ
				
				tblLatin1[214] = "O+";
				
				tblLatin1[215] = "%159"; // × unused; %43 used as metrical sign for anceps looks the same
				
				tblLatin1[216] = "O%162"; // Ø
				
				tblLatin1[217] = "U\\";
				tblLatin1[218] = "U/";
				
				tblLatin1[219] = "U=";
				
				tblLatin1[220] = "U+";
				
				tblLatin1[221] = "Y/";
				
				tblLatin1[222] = "%1"; // capital thorn
				
				tblLatin1[223] = "#1203"; // ß
				
				tblLatin1[224] = "a\\";
				
				tblLatin1[225] = "a/";
				
				tblLatin1[226] = "a=";
				
				tblLatin1[227] = "a%24"; // ã
				
				tblLatin1[228] = "a+";
				
				tblLatin1[229] = "a%147"; // å
				
				tblLatin1[230] = "#1216"; // ligature ae
				
				tblLatin1[231] = "c%25"; // ç
				
				tblLatin1[232] = "e\\";
				
				tblLatin1[233] = "e/";
				
				tblLatin1[234] = "e=";
				
				tblLatin1[235] = "e+";
				
				tblLatin1[236] = "i\\";
				
				tblLatin1[237] = "i/";
				
				tblLatin1[238] = "i=";
				
				tblLatin1[239] = "i+";
				
				tblLatin1[240] = "%1"; // eth
				
				tblLatin1[241] = "n%24"; // ñ
				
				tblLatin1[242] = "o\\";
				
				tblLatin1[243] = "o/";
				
				tblLatin1[244] = "o=";
				
				tblLatin1[245] = "o%24"; // õ
				
				tblLatin1[246] = "o+";
				
				tblLatin1[247] = "%161"; // ÷ unused
				
				tblLatin1[248] = "o%162"; // ø
				
				tblLatin1[249] = "u\\";
				
				tblLatin1[250] = "u/";
				
				tblLatin1[251] = "u=";
				
				tblLatin1[252] = "u+";
				
				tblLatin1[253] = "y/";
				
				tblLatin1[254] = "%1"; // thorn
				
				tblLatin1[255] = "y+";
				
				//
				
				// SPACING MODIFIER LETTERS
				
				//
				
				// Phonetic modifiers derived from Latin: none supported
				// Miscellaneous phonetic modifiers
				
				tblModif[185] = "#"; // prime, used for stress, emphasis, mjagkij znak, in Greek as keraia (numeral sign)
				
				tblModif[186] = "##"; // double prime, used for exaggerated stress, tverdyj znak, Betacode ## can mean fraction
				
				tblModif[188] = "%30"; // apostrophe and smooth breathing, I decided for the first
				
				tblModif[189] = "%31"; // reversed comma = spacing rough breathing
				tblModif[198] = tblLatin1[94]; // circumflex acc.
				
				tblModif[201] = tblLatin1[175]; // macron
				
				tblModif[202] = tblLatin1[180]; // spacing acute acc.
				
				tblModif[203] = tblLatin1[96]; // grave acc.
				
				// Spacing clones of diacritics
				
				tblModif[216] = "%40"; // breve, %40 is metrial short, I assume this is a spacing character
				
				tblModif[220] = tblLatin1[126]; // small tilde
				
				// Additions based on 1989 IPA: none supported
				
				// Tone letters: none supported
				
				// IPA modifiers: none supported
				
				// Other modifier letters: none supported
				
				
				
				//
				
				// COMBINING DIACRITICAL MARKS
				
				//
				
				// Ordinary diacritics
				
				tblDiacritGreek[0] = "\\"; // %21 Roman grave obsolete
				
				tblDiacritGreek[1] = "/"; // %20 Roman acute obsolete
				
				tblDiacritGreek[2] = "="; // circumflex acc., %22 Roman circumflex obsolete
				
				tblDiacritGreek[3] = "%24"; // tilde ~
				
				tblDiacritGreek[4] = "%26"; // macron
				
				//    tblDiacritGreek[5]   = "COMBINING OVERLINE";
				
				tblDiacritGreek[6] = "%27"; // breve
				
				tblDiacritGreek[7] = "%94"; // dot above, in Betacode a deletion sign
				
				tblDiacritGreek[8] = "+"; // diaeresis/umlaut; %23 umlaut and %28 diaeresis in Roman fonts are obsolete
				
				tblDiacritGreek[10] = "%147"; // ring above
				
				tblDiacritGreek[12] = "%148"; // caron/hacek
				
				tblDiacritGreek[17] = "#534"; // inverted breve, in mss. to indicate fraction or multipl.
				
				tblDiacritGreek[18] = "%25"; // cedilla
				
				tblDiacritGreek[19] = ")";
				
				tblDiacritGreek[20] = "(";
				
				tblDiacritGreek[35] = "?"; // dot below, in Betacode used for doubtful reading
				
				tblDiacritGreek[39] = "%25"; // cedilla
				
				tblDiacritGreek[40] = "%149"; // ogonek, reversed cedilla, referring "hec" (medieval for haec), unused
				
				tblDiacritGreek[47] = "%127"; // inverted breve below, for semivowel
				
				// Overstruck diacritics
				
				tblDiacritGreek[55] = "%162"; // short solidus
				
				tblDiacritGreek[56] = "%162"; // long solidus
				
				// Additions: none supported
				
				// Vietnamese tone marks (deprecated): none supported
				
				// Additions for Greek
				
				tblDiacritGreek[66] = "="; // perispomeni
				tblDiacritGreek[67] = ")"; // koronis
				
				tblDiacritGreek[68] = "/+"; // dialytika+tonos
				
				tblDiacritGreek[69] = "|"; // ypogegrammeni
				
				// Additions for IPA: none supported
				
				// IPA diacritics for disordered speech: none supported
				// Double diacritics
				
				//
				
				// GREEK AND COPTIC
				
				//
				
				// Based on ISO 8859-7:
				
				tblDiacritGreek[116] = tblModif[185]; // modifier letter prime = keraia (numeral sign), "#"
				
				tblDiacritGreek[117] = "#22"; // aristeri keraia, the #163 myriad slash is obsolete
				
				tblDiacritGreek[122] = "`|"; // spacing iota subscript, simulated with preceding null character
				
				tblDiacritGreek[126] = ";"; // erotimatiko
				
				tblDiacritGreek[132] = "%32"; // spacing tonos
				
				tblDiacritGreek[133] = "%132"; // spacing dialytika tonos
				
				tblDiacritGreek[134] = "*/A";
				
				tblDiacritGreek[135] = ":"; // ano teleia (middle dot)
				
				tblDiacritGreek[136] = "*/E";
				
				tblDiacritGreek[137] = "*/H";
				
				tblDiacritGreek[138] = "*/I";
				
				tblDiacritGreek[140] = "*/O";
				
				tblDiacritGreek[142] = "*/U";
				
				tblDiacritGreek[143] = "*/W";
				
				tblDiacritGreek[144] = "I/+";
				
				tblDiacritGreek[145] = "*A";
				
				tblDiacritGreek[146] = "*B";
				
				tblDiacritGreek[147] = "*G";
				
				tblDiacritGreek[148] = "*D";
				
				tblDiacritGreek[149] = "*E";
				
				tblDiacritGreek[150] = "*Z";
				
				tblDiacritGreek[151] = "*H";
				
				tblDiacritGreek[152] = "*Q";
				
				tblDiacritGreek[153] = "*I";
				
				tblDiacritGreek[154] = "*K";
				
				tblDiacritGreek[155] = "*L";
				
				tblDiacritGreek[156] = "*M";
				
				tblDiacritGreek[157] = "*N";
				
				tblDiacritGreek[158] = "*C";
				
				tblDiacritGreek[159] = "*O";
				
				tblDiacritGreek[160] = "*P";
				
				tblDiacritGreek[161] = "*R";
				
				tblDiacritGreek[163] = "*S";
				
				tblDiacritGreek[164] = "*T";
				
				tblDiacritGreek[165] = "*U";
				
				tblDiacritGreek[166] = "*F";
				
				tblDiacritGreek[167] = "*X";
				tblDiacritGreek[168] = "*Y";
				
				tblDiacritGreek[169] = "*W";
				
				tblDiacritGreek[170] = "*I+";
				
				tblDiacritGreek[171] = "*U+";
				
				tblDiacritGreek[172] = "A/";
				tblDiacritGreek[173] = "E/";
				
				tblDiacritGreek[174] = "H/";
				
				tblDiacritGreek[175] = "I/";
				
				tblDiacritGreek[176] = "U/+";
				
				tblDiacritGreek[177] = "A";
				
				tblDiacritGreek[178] = "B";
				
				tblDiacritGreek[179] = "G";
				
				tblDiacritGreek[180] = "D";
				
				tblDiacritGreek[181] = "E";
				
				tblDiacritGreek[182] = "Z";
				
				tblDiacritGreek[183] = "H";
				
				tblDiacritGreek[184] = "Q";
				
				tblDiacritGreek[185] = "I";
				
				tblDiacritGreek[186] = "K";
				
				tblDiacritGreek[187] = "L";
				
				tblDiacritGreek[188] = "M";
				
				tblDiacritGreek[189] = "N";
				
				tblDiacritGreek[190] = "C";
				
				tblDiacritGreek[191] = "O";
				
				tblDiacritGreek[192] = "P";
				
				tblDiacritGreek[193] = "R";
				
				tblDiacritGreek[194] = "J"; // but J for final sigma seems to be out of use, instead S is used,
				
				// S1 for medial sigma at the end of a word, S2 for final sigma within a word;
				
				// for simplicity I stick with J
				
				tblDiacritGreek[195] = "S";
				
				tblDiacritGreek[196] = "T";
				
				tblDiacritGreek[197] = "U";
				
				tblDiacritGreek[198] = "F";
				
				tblDiacritGreek[199] = "X";
				
				tblDiacritGreek[200] = "Y";
				
				tblDiacritGreek[201] = "W";
				
				tblDiacritGreek[202] = "I+";
				
				tblDiacritGreek[203] = "U+";
				
				tblDiacritGreek[204] = "O/";
				
				tblDiacritGreek[205] = "U/";
				
				tblDiacritGreek[206] = "W/";
				
				// Variant letter forms:
				
				tblDiacritGreek[208] = "B"; // curled beta
				
				tblDiacritGreek[209] = "Q"; // theta symbol
				
				tblDiacritGreek[210] = "*Y"; // with hook
				
				tblDiacritGreek[211] = "*/Y";
				
				tblDiacritGreek[212] = "*Y+";
				tblDiacritGreek[213] = "F"; // script phi
				
				tblDiacritGreek[214] = "P"; // omega-shaped pi
				
				tblDiacritGreek[215] = "K'"; // abbr. for kai
				
				// Archaic letters:
				
				tblDiacritGreek[218] = "#2"; // stigma
				tblDiacritGreek[219] = "#2"; // small stigma, but can see no difference in Betacode
				
				tblDiacritGreek[220] = "*V"; // digamma
				
				tblDiacritGreek[221] = "V"; // small digamma, but can see no difference in Betacode
				
				tblDiacritGreek[222] = "#3"; // qoppa
				
				tblDiacritGreek[223] = "#3"; // small qoppa, but can see no difference in Betacode
				
				tblDiacritGreek[224] = "#5"; // sampi
				
				tblDiacritGreek[225] = "#5"; // small sampi, but can see no difference in Betacode
				
				// Coptic unique letters 226-239: supporting them here does not make any sense.
				
				// Betacode has the backslash for combining overline 0305 *preceeding* its character;
				
				// continous overline above several letters is indicated with angle brackets <...>,
				
				// whereas the Unicode overline automatically connects on left and right. To support
				
				// Coptic to a sensible extent, there is much more coding needed.
				
				// Greek symbols:
				
				tblDiacritGreek[240] = "K";
				
				tblDiacritGreek[241] = "R"; // tailed rho
				
				tblDiacritGreek[242] = "S3"; // lunate sigma, obsolete in Betacode since around 1985, although still occurring
				
				// additional letter:
				
				tblDiacritGreek[243] = "j"; // jot
				
				// Greek symbols:
				
				tblDiacritGreek[244] = "*Q"; // capital theta symbol, looks like a mere typographic variant
				
				tblDiacritGreek[245] = "E"; // lunate epsilon symbol, looks like a mere typographic variant
				
				//
				
				// GREEK EXTENDED
				
				//
				
				// Betacode distinguishes between *|A (iota subscripted below capital letter)
				
				// and *A| (usual iota adscript, as it seems). Unicode has no such distinction,
				
				// therefore only the last one is used in rendering.
				
				tblGreekExtended[0] = "A)";
				
				tblGreekExtended[1] = "A(";
				
				tblGreekExtended[2] = "A)\\";
				
				tblGreekExtended[3] = "A(\\";
				
				tblGreekExtended[4] = "A)/";
				
				tblGreekExtended[5] = "A(/";
				
				tblGreekExtended[6] = "A)=";
				
				tblGreekExtended[7] = "A(=";
				
				tblGreekExtended[8] = "*)A";
				
				tblGreekExtended[9] = "*(A";
				
				tblGreekExtended[10] = "*)\\A";
				
				tblGreekExtended[11] = "*(\\A";
				
				tblGreekExtended[12] = "*)/A";
				
				tblGreekExtended[13] = "*(/A";
				
				tblGreekExtended[14] = "*)=A";
				tblGreekExtended[15] = "*(=";
				
				tblGreekExtended[16] = "E)";
				
				tblGreekExtended[17] = "E(";
				
				tblGreekExtended[18] = "E)\\";
				
				tblGreekExtended[19] = "E(\\";
				tblGreekExtended[20] = "E)/";
				
				tblGreekExtended[21] = "E(/";
				
				tblGreekExtended[24] = "*)E";
				
				tblGreekExtended[25] = "*(E";
				
				tblGreekExtended[26] = "*)\\E";
				
				tblGreekExtended[27] = "*(\\E";
				
				tblGreekExtended[28] = "*)/E";
				
				tblGreekExtended[29] = "*(/E";
				
				tblGreekExtended[32] = "H)";
				
				tblGreekExtended[33] = "H(";
				
				tblGreekExtended[34] = "H)\\";
				
				tblGreekExtended[35] = "H(\\";
				
				tblGreekExtended[36] = "H)/";
				
				tblGreekExtended[37] = "H(/";
				
				tblGreekExtended[38] = "H)=";
				
				tblGreekExtended[39] = "H(=";
				
				tblGreekExtended[40] = "*)H";
				
				tblGreekExtended[41] = "*(H";
				
				tblGreekExtended[42] = "*)\\H";
				
				tblGreekExtended[43] = "*(\\H";
				
				tblGreekExtended[44] = "*)/H";
				
				tblGreekExtended[45] = "*(/H";
				
				tblGreekExtended[46] = "*)=H";
				
				tblGreekExtended[47] = "*(=H";
				
				tblGreekExtended[48] = "I)";
				
				tblGreekExtended[49] = "I(";
				
				tblGreekExtended[50] = "I)\\";
				
				tblGreekExtended[51] = "I(\\";
				
				tblGreekExtended[52] = "I)/";
				
				tblGreekExtended[53] = "I(/";
				
				tblGreekExtended[54] = "I)=";
				
				tblGreekExtended[55] = "I(=";
				
				tblGreekExtended[56] = "*)I";
				
				tblGreekExtended[57] = "*(I";
				
				tblGreekExtended[58] = "*)\\I";
				
				tblGreekExtended[59] = "*(\\I";
				
				tblGreekExtended[60] = "*)/I";
				
				tblGreekExtended[61] = "*(/I";
				
				tblGreekExtended[62] = "*)=I";
				
				tblGreekExtended[63] = "*(=I";
				
				tblGreekExtended[64] = "O)";
				
				tblGreekExtended[65] = "O(";
				tblGreekExtended[66] = "O)\\";
				
				tblGreekExtended[67] = "O(\\";
				
				tblGreekExtended[68] = "O)/";
				
				tblGreekExtended[69] = "O(/";
				
				tblGreekExtended[72] = "*)O";
				tblGreekExtended[73] = "*(O";
				
				tblGreekExtended[74] = "*)\\O";
				
				tblGreekExtended[75] = "*(\\O";
				
				tblGreekExtended[76] = "*)/O";
				
				tblGreekExtended[77] = "*(/O";
				
				tblGreekExtended[80] = "U)";
				
				tblGreekExtended[81] = "U(";
				
				tblGreekExtended[82] = "U)\\";
				
				tblGreekExtended[83] = "U(\\";
				
				tblGreekExtended[84] = "U)/";
				
				tblGreekExtended[85] = "U(/";
				
				tblGreekExtended[86] = "U)=";
				
				tblGreekExtended[87] = "U(=";
				
				tblGreekExtended[89] = "*(U";
				
				tblGreekExtended[91] = "*(\\U";
				
				tblGreekExtended[93] = "*(/U";
				
				tblGreekExtended[95] = "*(=U";
				
				tblGreekExtended[96] = "W)";
				
				tblGreekExtended[97] = "W(";
				
				tblGreekExtended[98] = "W)\\";
				
				tblGreekExtended[99] = "W(\\";
				
				tblGreekExtended[100] = "W)/";
				
				tblGreekExtended[101] = "W(/";
				
				tblGreekExtended[102] = "W)=";
				
				tblGreekExtended[103] = "W(=";
				
				tblGreekExtended[104] = "*)W";
				
				tblGreekExtended[105] = "*(W";
				
				tblGreekExtended[106] = "*)\\W";
				
				tblGreekExtended[107] = "*(\\W";
				
				tblGreekExtended[108] = "*)/W";
				
				tblGreekExtended[109] = "*(/W";
				
				tblGreekExtended[110] = "*)=W";
				
				tblGreekExtended[111] = "*(=W";
				
				tblGreekExtended[112] = "A\\";
				
				tblGreekExtended[113] = "A/";
				
				tblGreekExtended[114] = "E\\";
				
				tblGreekExtended[115] = "E/";
				
				tblGreekExtended[116] = "H\\";
				
				tblGreekExtended[117] = "H/";
				
				tblGreekExtended[118] = "I\\";
				
				tblGreekExtended[119] = "I/";
				
				tblGreekExtended[120] = "O\\";
				tblGreekExtended[121] = "O/";
				
				tblGreekExtended[122] = "U\\";
				
				tblGreekExtended[123] = "U/";
				
				tblGreekExtended[124] = "W\\";
				
				tblGreekExtended[125] = "W/";
				tblGreekExtended[128] = "A)|";
				
				tblGreekExtended[129] = "A(|";
				
				tblGreekExtended[130] = "A)\\|";
				tblGreekExtended[131] = "A(\\|";
				
				tblGreekExtended[132] = "A)/|";
				
				tblGreekExtended[133] = "A(/|";
				
				tblGreekExtended[134] = "A)=|";
				
				tblGreekExtended[135] = "A(=|";
				
				tblGreekExtended[136] = "*)A|";
				
				tblGreekExtended[137] = "*(A|";
				
				tblGreekExtended[138] = "*)\\A|";
				
				tblGreekExtended[139] = "*(\\A|";
				
				tblGreekExtended[140] = "*)/A|";
				
				tblGreekExtended[141] = "*(/A|";
				
				tblGreekExtended[142] = "*)=A|";
				
				tblGreekExtended[143] = "*(=A|";
				
				tblGreekExtended[144] = "H)|";
				
				tblGreekExtended[145] = "H(|";
				
				tblGreekExtended[146] = "H)\\|";
				
				tblGreekExtended[147] = "H(\\|";
				
				tblGreekExtended[148] = "H)/|";
				
				tblGreekExtended[149] = "H(/|";
				
				tblGreekExtended[150] = "H)=|";
				
				tblGreekExtended[151] = "H(=|";
				
				tblGreekExtended[152] = "*)H|";
				
				tblGreekExtended[153] = "*(H|";
				
				tblGreekExtended[154] = "*)\\H|";
				
				tblGreekExtended[155] = "*(\\H|";
				
				tblGreekExtended[156] = "*)/H|";
				
				tblGreekExtended[157] = "*(/H|";
				
				tblGreekExtended[158] = "*)=H|";
				
				tblGreekExtended[159] = "*(=H|";
				
				tblGreekExtended[160] = "W)|";
				
				tblGreekExtended[161] = "W(|";
				
				tblGreekExtended[162] = "W)\\|";
				
				tblGreekExtended[163] = "W(\\|";
				
				tblGreekExtended[164] = "W)/|";
				
				tblGreekExtended[165] = "W(/|";
				
				tblGreekExtended[166] = "W)=|";
				
				tblGreekExtended[167] = "W(=|";
				
				tblGreekExtended[168] = "*)W|";
				
				tblGreekExtended[169] = "*(W|";
				tblGreekExtended[170] = "*)\\W|";
				
				tblGreekExtended[171] = "*(\\W|";
				
				tblGreekExtended[172] = "*)/W|";
				
				tblGreekExtended[173] = "*(/W|";
				
				tblGreekExtended[174] = "*)=W|";
				tblGreekExtended[175] = "*(=W|";
				
				tblGreekExtended[176] = "A%27"; // alpha vrachy
				
				tblGreekExtended[177] = "A%26"; // alpha macron
				
				tblGreekExtended[178] = "A\\|";
				
				tblGreekExtended[179] = "A|";
				
				tblGreekExtended[180] = "A/|";
				
				tblGreekExtended[182] = "A=";
				
				tblGreekExtended[183] = "A=|";
				
				tblGreekExtended[184] = "*A%27"; // capital alpha vrachy
				
				tblGreekExtended[185] = "*A%26"; // capital alpha macron
				
				tblGreekExtended[186] = "*\\A";
				
				tblGreekExtended[187] = "*/A";
				
				tblGreekExtended[188] = "*A|";
				
				tblGreekExtended[189] = "%30"; // spacing koronis
				
				tblGreekExtended[190] = "I"; // spacing prosgegrammeni, in Unicode = iota
				
				tblGreekExtended[191] = "%30"; // spacing psili (smooth br.)
				
				tblGreekExtended[192] = "%34"; // spacing perspomeni (circumflex acc.)
				
				tblGreekExtended[193] = " =+ "; // spacing dialytika perispomeni, that's a workaround
				
				tblGreekExtended[194] = "H\\|";
				
				tblGreekExtended[195] = "H|";
				
				tblGreekExtended[196] = "H/|";
				
				tblGreekExtended[198] = "H=";
				
				tblGreekExtended[199] = "H=|";
				
				tblGreekExtended[200] = "*\\E";
				
				tblGreekExtended[201] = "*/E";
				
				tblGreekExtended[202] = "*\\H";
				
				tblGreekExtended[203] = "*/H";
				
				tblGreekExtended[204] = "*H|";
				
				tblGreekExtended[205] = "%133"; // )\ spacing psili+varia
				
				tblGreekExtended[206] = "%35"; // )/ spacing psili+oxia
				
				tblGreekExtended[207] = "%134"; // spacing psili+perispomeni
				
				tblGreekExtended[208] = "I%27"; // iota vrachy
				
				tblGreekExtended[209] = "I%26"; // iota macron
				
				tblGreekExtended[210] = "I\\+";
				
				tblGreekExtended[211] = "I/+";
				
				tblGreekExtended[214] = "I=";
				
				tblGreekExtended[215] = "I=+";
				
				tblGreekExtended[216] = "*I%27"; // capital iota vrachy
				
				tblGreekExtended[217] = "*I%26"; // capital iota macron
				
				tblGreekExtended[218] = "*\\I";
				
				tblGreekExtended[219] = "*/I";
				
				tblGreekExtended[221] = "%37"; // (\ spacing dasia+varia
				tblGreekExtended[222] = "%36"; // (/ spacing dasia+oxia
				
				tblGreekExtended[223] = "%38"; // (= spacing dasia+perispomeni
				
				tblGreekExtended[224] = "U%27"; // ypsilon vrachy
				
				tblGreekExtended[225] = "U%26"; // ypsilon macron
				
				tblGreekExtended[226] = "U\\+";
				tblGreekExtended[227] = "U/+";
				
				tblGreekExtended[228] = "R)";
				
				tblGreekExtended[229] = "R(";
				
				tblGreekExtended[230] = "U=";
				
				tblGreekExtended[231] = "U=+";
				
				tblGreekExtended[232] = "*U%27"; // capital ypsilon vrachy
				
				tblGreekExtended[233] = "*U%26"; // capital ypsilon macron
				
				tblGreekExtended[234] = "*\\U";
				
				tblGreekExtended[235] = "*/U";
				
				tblGreekExtended[236] = "*(R";
				
				tblGreekExtended[237] = " \\+ "; // dialytika varia, that's a workaround
				
				tblGreekExtended[238] = "%132"; // /+ spacing dialytika+oxia
				
				tblGreekExtended[239] = "%33"; // spacing varia (grave acc.)
				
				tblGreekExtended[242] = "W\\|";
				
				tblGreekExtended[243] = "W|";
				
				tblGreekExtended[244] = "W/|";
				
				tblGreekExtended[246] = "W=";
				
				tblGreekExtended[247] = "W=|";
				
				tblGreekExtended[248] = "*\\O";
				
				tblGreekExtended[249] = "*/O";
				
				tblGreekExtended[250] = "*\\W";
				
				tblGreekExtended[251] = "*/W";
				
				tblGreekExtended[252] = "*=W";
				
				tblGreekExtended[253] = "%32"; // spacing oxia (acute acc.)
				
				tblGreekExtended[254] = "%31"; // spacing dasia (rough br.)
				
				//
				
				// GENERAL PUNCTUATION
				
				//
				
				// Spaces
				
				// the Betacode ^n for n quarter spaces is obsolete, hence we render all with simple space
				
				tblPunct[0] = " "; // en quad = en space (n-width space)
				
				tblPunct[1] = " "; // em quad = em space (m-width space)
				
				tblPunct[2] = " "; // en space, half an em, ~ 0020 SPACE
				
				tblPunct[3] = " "; // em space, space equal to the type size in points, ~ 0020 SPACE
				
				tblPunct[4] = " "; // 3-per-em space, thick space, ~ 0020 SPACE
				
				tblPunct[5] = " "; // 4-per-em space, mid space, ~ 0020 SPACE
				
				tblPunct[6] = " "; // 6-per-em space, thin space, ~ 0020 SPACE
				
				tblPunct[7] = " "; // figure space, fixed width font space, ~ <NO BRAKE> 0020 SPACE
				
				tblPunct[8] = " "; // punctuation space, ~ 0020 SPACE
				
				tblPunct[9] = " "; // thin space, ~ 0020 SPACE
				
				tblPunct[10] = " "; // hair space, ~ 0020 SPACE
				
				tblPunct[11] = "`"; // zero width space, ` in Betacode is a null character used as separator
				// Formatting characters: none supported
				
				// Dashes
				
				tblPunct[16] = "-"; // hyphen
				
				tblPunct[17] = "-"; // non-breaking hyphen
				
				tblPunct[18] = "-"; // figure dash
				tblPunct[19] = "-"; // en dash
				
				tblPunct[20] = "--"; // em dash, used for parentheses
				
				tblPunct[21] = "#6"; // Unicode: horizontal bar, quotation dash; Betacode: paragraphos, indicating new paragraph or speaker change
				
				// General punctuation
				
				tblPunct[24] = "\"3"; //left single quotation mark, %102 single quote obsolete
				
				tblPunct[25] = "\"3"; // right single quotation mark, apostrophe
				
				tblPunct[26] = "\"4"; // single low 9 quot. mark
				
				tblPunct[27] = tblPunct[24]; // single high-rev.-9 quot. mark
				
				tblPunct[28] = "\""; // left double quot. mark
				
				tblPunct[29] = "\""; // right double quot. mark
				
				tblPunct[30] = "\"1"; // double low 9 quot. mark
				
				tblPunct[31] = tblPunct[28]; // double high-rev.-9 quot. mark
				
				tblPunct[32] = "%"; // dagger / obelisk, % denotes irremediable text, %129 secundary crux looks the same but denotes interpolation
				
				tblPunct[33] = "%13"; // double dagger, in Betacode unused
				
				//  tblPunct[34] = "BULLET";
				
				//  tblPunct[35] = "TRIANGULAR BULLET";
				
				tblPunct[36] = "."; // one dot leader, ~ 002E full stop
				
				tblPunct[37] = ".."; // two dot leader, ~ .. (2 times 002E)
				
				tblPunct[38] = "..."; // horizontal ellipsis
				
				tblPunct[39] = "."; // hyphenation point, looks like middle dot
				
				// Formatting characters
				
				tblPunct[47] = " "; // narrow no-brake space
				
				// General punctuation
				
				tblPunct[50] = tblModif[185]; // prime, abbr. for minutes and feet
				tblPunct[51] = tblModif[186]; // double prime, abbr. for seconds and inches
				tblPunct[56] = "%104"; // caret
				tblPunct[57] = "\"7"; // left pointing single guillemet
				tblPunct[58] = "\"7"; // right pointing single guillemet
				tblPunct[59] = "#13"; // reference mark (=Japanese kome, Urdu paragraph separator), looks nearly like %12 asterisk
				// and totally like #13 asteriskos, but is used differently (omission, wrong position etc.)
				tblPunct[60] = "%4%4"; // double exclamation mark, ~ !!
				tblPunct[61] = "%1%4"; // interrobang, overlapping ? and !
				tblPunct[66] = "%158"; // asterism = three asterisks forming a triangle, in Betacode unused
				tblPunct[67] = "-"; // hyphen bullet
				tblPunct[68] = "%3"; // fraction slash, typographically = solidus (slash)
				tblPunct[71] = NOT_ASSIGNED;
				tblPunct[72] = "%1%4"; // question exclamation mark, ~ ?!
				tblPunct[73] = "%4%1"; // exclamation question mark, ~ !?
				// Deprecated: none supported
			}
		}
	}
}