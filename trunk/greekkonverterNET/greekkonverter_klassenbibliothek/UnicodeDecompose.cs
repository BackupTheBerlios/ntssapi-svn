namespace greekconverter
{
	using System;
	
	/// <summary>************************
	/// </summary>
	/* Unicode -> Unicode       */
	/// <summary>************************
	/// </summary>
	
	/// <summary> Class for decomposing and normalizing Unicode text.
	/// *
	/// </summary>
	
	public class UnicodeDecompose
	{
		/// <summary> Constants that define the degree of normalization.
		/// </summary>
		public const int FULL_EQUIVALENTS = 1; // decompose/normalize only full equivalents
		public const int SPACING_DIACRITICS = 2; // decompose spacing diacritics into space + combining diacritic
		public const int VARIANTS_SYMBOLS = 4; // normalize also variant letterforms and symbols into their non-symbol counterparts
		
		// private Strings:
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NOT_SUPPORTED " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String NOT_SUPPORTED = new System.String("?".ToCharArray());
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "RESERVED " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String RESERVED = new System.String("#".ToCharArray());
		// the lookup tables:
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblUnicodeBlocks " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[][] tblUnicodeBlocks;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLatin1 " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblLatin1;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblDiacritGreek " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblDiacritGreek;
		// 0300-036F combining diacritics, 0370-03FF Greek/Coptic
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblGreekExtended " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblGreekExtended;
		// 1F00-1FFF
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblNotSupported " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblNotSupported;
		
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "28-Mar-2002"; break;
				
				case 1:  info = "Decomposes / normalizes Greek Unicode text"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "De nihilo nihil.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Normalizes a Unicode string.
		/// <p>
		/// Particularly, it:
		/// <ul>
		/// <li>fully decomposes precomposed Greek characters</li>
		/// <li>replaces some characters with their preferred equivalences (e.g.
		/// combining koronis with combining comma above, greek question mark with
		/// semicolon, ano teleia with middle dot; but not: dexia keraia with
		/// modifier letter prime, prosgegrammeni with small iota)</li>
		/// <li>decomposes spacing diacritics into SPACE + non-spacing diacritic
		/// (might not be correct, but the visual output is the same) if invoked
		/// with SPACING_DIACRITICS</li>
		/// <li>replaces Greek symbols and variant letterforms with their ordinary
		/// non-symbol counterparts (except lunate sigma, which is distinguished
		/// from normal sigma in GreekKeys) if invoked with VARIANTS_SYMBOLS</li>
		/// </ul>
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode string
		/// </param>
		/// <param name="mode">the degree of normalization (see the constants above)
		/// </param>
		/// <returns>  the decomposed and normalized version of the String
		/// </returns>
		public static System.String normalizeString(System.String uniString, int mode)
		{
			int strLen = uniString.Length, strPos;
			System.Text.StringBuilder decomposedString = new System.Text.StringBuilder(strLen * 3);
			
			if ((mode & SPACING_DIACRITICS) == SPACING_DIACRITICS)
			{
				// initialization goes here
			}
			
			if ((mode & VARIANTS_SYMBOLS) == VARIANTS_SYMBOLS)
			{
				// initialization goes here
			}
			
			for (strPos = 0; strPos < strLen; strPos++)
			{
				decomposedString.Append(normalizeChar(uniString[strPos]));
			}
			return decomposedString.ToString();
		}
		
		/// <summary> Shortcut for <code>normalizeString( uniString, SPACING_DIACRITICS + VARIANTS_SYMBOLS )</code>
		/// </summary>
		public static System.String normalizeString(System.String uniString)
		{
			return normalizeString(uniString, SPACING_DIACRITICS + VARIANTS_SYMBOLS);
		}
		
		/*
		* Returns the normalized equivalent of the input character.*/
		private static System.String normalizeChar(char uniChar)
		{
			return tblUnicodeBlocks[uniChar >> 8][uniChar & 255];
		}
		static UnicodeDecompose()
		{
			tblUnicodeBlocks = new System.String[256][];
			tblLatin1 = new System.String[256];
			tblDiacritGreek = new System.String[256];
			tblGreekExtended = new System.String[256];
			tblNotSupported = new System.String[256];
			// initialization of the static arrays:
			{
				int i;
				// generally initalize lookup tables:
				for (i = 0; i < 256; i++)
				{
					tblUnicodeBlocks[i] = tblNotSupported;
					tblNotSupported[i] = NOT_SUPPORTED;
					tblLatin1[i] = ((char) i).ToString();
					tblDiacritGreek[i] = ((char) (768 + i)).ToString(); // 768 = 0300
					tblGreekExtended[i] = RESERVED;
				}
				// now mount the LoByte character blocks into the HiByte block:
				tblUnicodeBlocks[0] = tblLatin1;
				tblUnicodeBlocks[3] = tblDiacritGreek;
				tblUnicodeBlocks[31] = tblGreekExtended;
				// now assign the conversion values to the table positions:
				// ISO 8859-1 (aka Latin-1)
				tblLatin1[192] = "A" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[193] = "A" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[194] = "A" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[195] = "A" + UC.COMBINING_TILDE;
				tblLatin1[196] = "A" + UC.COMBINING_DIAERESIS;
				tblLatin1[197] = "A" + UC.COMBINING_RING_ABOVE;
				tblLatin1[199] = "C" + UC.COMBINING_CEDILLA;
				tblLatin1[200] = "E" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[201] = "E" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[202] = "E" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[203] = "E" + UC.COMBINING_DIAERESIS;
				tblLatin1[204] = "I" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[205] = "I" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[206] = "I" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[207] = "I" + UC.COMBINING_DIAERESIS;
				tblLatin1[209] = "N" + UC.COMBINING_TILDE;
				tblLatin1[210] = "O" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[211] = "O" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[212] = "O" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[213] = "O" + UC.COMBINING_TILDE;
				tblLatin1[214] = "O" + UC.COMBINING_DIAERESIS;
				tblLatin1[217] = "U" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[218] = "U" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[219] = "U" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[220] = "U" + UC.COMBINING_DIAERESIS;
				tblLatin1[221] = "Y" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[224] = "a" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[225] = "a" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[226] = "a" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[227] = "a" + UC.COMBINING_TILDE;
				tblLatin1[228] = "a" + UC.COMBINING_DIAERESIS;
				tblLatin1[229] = "a" + UC.COMBINING_RING_ABOVE;
				tblLatin1[230] = "c" + UC.COMBINING_CEDILLA;
				tblLatin1[232] = "e" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[233] = "e" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[234] = "e" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[235] = "e" + UC.COMBINING_DIAERESIS;
				tblLatin1[236] = "i" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[237] = "i" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[238] = "i" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[239] = "i" + UC.COMBINING_DIAERESIS;
				tblLatin1[241] = "n" + UC.COMBINING_TILDE;
				tblLatin1[242] = "o" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[243] = "o" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[244] = "o" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[245] = "o" + UC.COMBINING_TILDE;
				tblLatin1[246] = "o" + UC.COMBINING_DIAERESIS;
				tblLatin1[249] = "u" + UC.COMBINING_GRAVE_ACCENT;
				tblLatin1[250] = "u" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[251] = "u" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblLatin1[252] = "u" + UC.COMBINING_DIAERESIS;
				tblLatin1[253] = "y" + UC.COMBINING_ACUTE_ACCENT;
				tblLatin1[255] = "y" + UC.COMBINING_DIAERESIS;
				// precomposed combining diacrital -> use discouraged:
				tblDiacritGreek[68] = "" + UC.COMBINING_DIAERESIS + UC.COMBINING_GRAVE_ACCENT;
				//
				// GREEK + COPTIC
				//
				// Based on ISO 8859-7:
				// tblDiacritGreek[116] = "" + NUMERAL SIGN (dexia keraia)"; // =02B9 modifier letter prime, because no conversion supports 02B9!
				tblDiacritGreek[122] = " " + UC.COMBINING_YPOGEGRAMMENI;
				tblDiacritGreek[126] = ";"; // semicolon preferred over erotimatiko
				tblDiacritGreek[132] = " " + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[133] = " " + UC.COMBINING_DIAERESIS + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[134] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[135] = "" + UC.MIDDLE_DOT; ;
				tblDiacritGreek[136] = "" + UC.CAPITAL_EPSILON + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[137] = "" + UC.CAPITAL_ETA + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[138] = "" + UC.CAPITAL_IOTA + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[140] = "" + UC.CAPITAL_OMICRON + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[142] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[143] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[144] = "" + UC.IOTA + UC.COMBINING_DIAERESIS + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[170] = "" + UC.CAPITAL_IOTA + UC.COMBINING_DIAERESIS;
				tblDiacritGreek[171] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_DIAERESIS;
				tblDiacritGreek[172] = "" + UC.ALPHA + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[173] = "" + UC.EPSILON + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[174] = "" + UC.ETA + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[175] = "" + UC.IOTA + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[176] = "" + UC.UPSILON + UC.COMBINING_DIAERESIS + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[202] = "" + UC.IOTA + UC.COMBINING_DIAERESIS;
				tblDiacritGreek[203] = "" + UC.UPSILON + UC.COMBINING_DIAERESIS;
				tblDiacritGreek[204] = "" + UC.OMICRON + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[205] = "" + UC.UPSILON + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[206] = "" + UC.OMEGA + UC.COMBINING_ACUTE_ACCENT;
				// variant letter forms:
				tblDiacritGreek[208] = "" + UC.BETA;
				tblDiacritGreek[209] = "" + UC.THETA;
				tblDiacritGreek[210] = "" + UC.CAPITAL_UPSILON;
				tblDiacritGreek[211] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_ACUTE_ACCENT;
				tblDiacritGreek[212] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_DIAERESIS;
				tblDiacritGreek[213] = "" + UC.PHI;
				tblDiacritGreek[214] = "" + UC.PI;
				// Greek symbols:
				tblDiacritGreek[240] = "" + UC.KAPPA;
				tblDiacritGreek[241] = "" + UC.RHO;
				// tblDiacritGreek[242] = "" + UC.FINAL_SIGMA; // is distinguished e.g. in GreekKeys
				tblDiacritGreek[244] = "" + UC.CAPITAL_THETA;
				tblDiacritGreek[245] = "" + UC.EPSILON;
				//
				// GREEK EXTENDED
				//
				tblGreekExtended[0] = "" + UC.ALPHA + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[1] = "" + UC.ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[2] = "" + UC.ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[3] = "" + UC.ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[4] = "" + UC.ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[5] = "" + UC.ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[6] = "" + UC.ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[7] = "" + UC.ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[8] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[9] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[10] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[11] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[12] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[13] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[14] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[15] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[16] = "" + UC.EPSILON + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[17] = "" + UC.EPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[18] = "" + UC.EPSILON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[19] = "" + UC.EPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[20] = "" + UC.EPSILON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[21] = "" + UC.EPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[24] = "" + UC.CAPITAL_EPSILON + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[25] = "" + UC.CAPITAL_EPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[26] = "" + UC.CAPITAL_EPSILON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[27] = "" + UC.CAPITAL_EPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[28] = "" + UC.CAPITAL_EPSILON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[29] = "" + UC.CAPITAL_EPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[32] = "" + UC.ETA + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[33] = "" + UC.ETA + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[34] = "" + UC.ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[35] = "" + UC.ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[36] = "" + UC.ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[37] = "" + UC.ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[38] = "" + UC.ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[39] = "" + UC.ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[40] = "" + UC.CAPITAL_ETA + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[41] = "" + UC.CAPITAL_ETA + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[42] = "" + UC.CAPITAL_ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[43] = "" + UC.CAPITAL_ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[44] = "" + UC.CAPITAL_ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[45] = "" + UC.CAPITAL_ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[46] = "" + UC.CAPITAL_ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[47] = "" + UC.CAPITAL_ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[48] = "" + UC.IOTA + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[49] = "" + UC.IOTA + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[50] = "" + UC.IOTA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[51] = "" + UC.IOTA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[52] = "" + UC.IOTA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[53] = "" + UC.IOTA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[54] = "" + UC.IOTA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[55] = "" + UC.IOTA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[56] = "" + UC.CAPITAL_IOTA + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[57] = "" + UC.CAPITAL_IOTA + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[58] = "" + UC.CAPITAL_IOTA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[59] = "" + UC.CAPITAL_IOTA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[60] = "" + UC.CAPITAL_IOTA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[61] = "" + UC.CAPITAL_IOTA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[62] = "" + UC.CAPITAL_IOTA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[63] = "" + UC.CAPITAL_IOTA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[64] = "" + UC.OMICRON + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[65] = "" + UC.OMICRON + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[66] = "" + UC.OMICRON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[67] = "" + UC.OMICRON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[68] = "" + UC.OMICRON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[69] = "" + UC.OMICRON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[72] = "" + UC.CAPITAL_OMICRON + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[73] = "" + UC.CAPITAL_OMICRON + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[74] = "" + UC.CAPITAL_OMICRON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[75] = "" + UC.CAPITAL_OMICRON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[76] = "" + UC.CAPITAL_OMICRON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[77] = "" + UC.CAPITAL_OMICRON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[80] = "" + UC.UPSILON + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[81] = "" + UC.UPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[82] = "" + UC.UPSILON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[83] = "" + UC.UPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[84] = "" + UC.UPSILON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[85] = "" + UC.UPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[86] = "" + UC.UPSILON + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[87] = "" + UC.UPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[89] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[91] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[93] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[95] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[96] = "" + UC.OMEGA + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[97] = "" + UC.OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[98] = "" + UC.OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[99] = "" + UC.OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[100] = "" + UC.OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[101] = "" + UC.OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[102] = "" + UC.OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[103] = "" + UC.OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[104] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[105] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[106] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[107] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[108] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[109] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[110] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[111] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[112] = "" + UC.ALPHA + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[113] = "" + UC.ALPHA + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[114] = "" + UC.EPSILON + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[115] = "" + UC.EPSILON + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[116] = "" + UC.ETA + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[117] = "" + UC.ETA + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[118] = "" + UC.IOTA + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[119] = "" + UC.IOTA + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[120] = "" + UC.OMICRON + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[121] = "" + UC.OMICRON + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[122] = "" + UC.UPSILON + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[123] = "" + UC.UPSILON + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[124] = "" + UC.OMEGA + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[125] = "" + UC.OMEGA + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[128] = "" + UC.ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[129] = "" + UC.ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[130] = "" + UC.ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[131] = "" + UC.ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[132] = "" + UC.ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[133] = "" + UC.ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[134] = "" + UC.ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[135] = "" + UC.ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[136] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[137] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[138] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[139] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[140] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[141] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[142] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[143] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[144] = "" + UC.ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[145] = "" + UC.ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[146] = "" + UC.ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[147] = "" + UC.ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[148] = "" + UC.ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[149] = "" + UC.ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[150] = "" + UC.ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[151] = "" + UC.ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[152] = "" + UC.CAPITAL_ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[153] = "" + UC.CAPITAL_ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[154] = "" + UC.CAPITAL_ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[155] = "" + UC.CAPITAL_ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[156] = "" + UC.CAPITAL_ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[157] = "" + UC.CAPITAL_ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[158] = "" + UC.CAPITAL_ETA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[159] = "" + UC.CAPITAL_ETA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[160] = "" + UC.OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[161] = "" + UC.OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[162] = "" + UC.OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[163] = "" + UC.OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[164] = "" + UC.OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[165] = "" + UC.OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[166] = "" + UC.OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[167] = "" + UC.OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[168] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[169] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[170] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[171] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[172] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[173] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[174] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[175] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[176] = "" + UC.ALPHA + UC.COMBINING_BREVE;
				tblGreekExtended[177] = "" + UC.ALPHA + UC.COMBINING_MACRON;
				tblGreekExtended[178] = "" + UC.ALPHA + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[179] = "" + UC.ALPHA + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[180] = "" + UC.ALPHA + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[182] = "" + UC.ALPHA + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[183] = "" + UC.ALPHA + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[184] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_BREVE;
				tblGreekExtended[185] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_MACRON;
				tblGreekExtended[186] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[187] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[188] = "" + UC.CAPITAL_ALPHA + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[189] = " " + UC.COMBINING_COMMA_ABOVE; // preferred over KORONIS
				tblGreekExtended[190] = " " + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[191] = " " + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[192] = " " + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[193] = " " + UC.COMBINING_DIAERESIS + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[194] = "" + UC.ETA + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[195] = "" + UC.ETA + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[196] = "" + UC.ETA + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[198] = "" + UC.ETA + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[199] = "" + UC.ETA + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[200] = "" + UC.CAPITAL_EPSILON + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[201] = "" + UC.CAPITAL_EPSILON + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[202] = "" + UC.CAPITAL_ETA + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[203] = "" + UC.CAPITAL_ETA + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[204] = "" + UC.CAPITAL_ETA + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[205] = " " + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[206] = " " + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[207] = " " + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[208] = "" + UC.IOTA + UC.COMBINING_BREVE;
				tblGreekExtended[209] = "" + UC.IOTA + UC.COMBINING_MACRON;
				tblGreekExtended[210] = "" + UC.IOTA + UC.COMBINING_DIAERESIS + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[211] = "" + UC.IOTA + UC.COMBINING_DIAERESIS + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[214] = "" + UC.IOTA + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[215] = "" + UC.IOTA + UC.COMBINING_DIAERESIS + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[216] = "" + UC.CAPITAL_IOTA + UC.COMBINING_BREVE;
				tblGreekExtended[217] = "" + UC.CAPITAL_IOTA + UC.COMBINING_MACRON;
				tblGreekExtended[218] = "" + UC.CAPITAL_IOTA + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[219] = "" + UC.CAPITAL_IOTA + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[221] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[222] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[223] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[224] = "" + UC.UPSILON + UC.COMBINING_BREVE;
				tblGreekExtended[225] = "" + UC.UPSILON + UC.COMBINING_MACRON;
				tblGreekExtended[226] = "" + UC.UPSILON + UC.COMBINING_DIAERESIS + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[227] = "" + UC.UPSILON + UC.COMBINING_DIAERESIS + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[228] = "" + UC.RHO + UC.COMBINING_COMMA_ABOVE;
				tblGreekExtended[229] = "" + UC.RHO + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[230] = "" + UC.UPSILON + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[231] = "" + UC.UPSILON + UC.COMBINING_DIAERESIS + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[232] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_BREVE;
				tblGreekExtended[233] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_MACRON;
				tblGreekExtended[234] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[235] = "" + UC.CAPITAL_UPSILON + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[236] = "" + UC.CAPITAL_RHO + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblGreekExtended[237] = " " + UC.COMBINING_DIAERESIS + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[238] = " " + UC.COMBINING_DIAERESIS + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[239] = " " + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[242] = "" + UC.OMEGA + UC.COMBINING_GRAVE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[243] = "" + UC.OMEGA + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[244] = "" + UC.OMEGA + UC.COMBINING_ACUTE_ACCENT + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[246] = "" + UC.OMEGA + UC.COMBINING_PERISPOMENI;
				tblGreekExtended[247] = "" + UC.OMEGA + UC.COMBINING_PERISPOMENI + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[248] = "" + UC.CAPITAL_OMICRON + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[249] = "" + UC.CAPITAL_OMICRON + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[250] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_GRAVE_ACCENT;
				tblGreekExtended[251] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_ACUTE_ACCENT;
				tblGreekExtended[252] = "" + UC.CAPITAL_OMEGA + UC.COMBINING_YPOGEGRAMMENI;
				tblGreekExtended[253] = " " + UC.COMBINING_ACUTE_ACCENT; // id. to ACUTE_ACCENT = ?
				tblGreekExtended[254] = " " + UC.COMBINING_REVERSED_COMMA_ABOVE;
			}
		}
	}
}