namespace greekconverter
{
	using System;
	
	/// <summary>*************************
	/// </summary>
	/* Unicode -> HTML-Entities */
	/// <summary>*************************
	/// </summary>
	
	/// <summary> Class for conversion of Unicode into HTML entities.
	/// <p>
	/// Since version 4.0 HTML uses the Universal Character Set (UCS) which is based on the Unicode
	/// system. Since then any Unicode character can be noted like <code>&amp;#252;</code> (decimal)
	/// or <code>&amp;#xFC;</code> (hexadecimal). For unaccented letters there are named entities
	/// like <code>&amp;alpha;</code>.
	/// <p>
	/// Alternatively you can tell the browser how to interpret the content of a HTML page by the
	/// charset-property in the meta-tag in the head-section:
	/// <code>&lt;meta http-equiv="Content-Type" content="text/html; charset=utf-8"&gt;</code>
	/// </summary>
	
	public class UnicodeToHtml
	{
		/// <summary> Sets the entity mode.
		/// <p>
		/// Pass <code>[USE_NAMED_ENT|NO_NAMED_ENT] + [DEC_ENT|HEX_ENT]</code> to determine
		/// wether you want use of named entities where available and wether you want decimal
		/// or hexadecimal numbers for numeric entities. The initialization default is
		/// <code>USE_NAMED_ENT + DEC_ENT</code>.
		/// </summary>
		internal static int Mode
		{
			// mode has previously been a parameter of function convertString, resulting in
			// the mode being bitwise ANDed on every invokation (which is superfluous nine
			// times out of ten because usually you convert a bulk of strings using the same
			// mode). Putting it into a procedure of its own has the advantage that the AND
			// is done only when really necessary.
			
			set
			{
				namedMode = value & NO_NAMED_ENT; // mask out bit 0
				numberMode = value & HEX_ENT; // mask out bit 1
			}
			
		}
		// bitwise constants; there are four possible combination:
		// 0: use named entities, where none exist use decimal numbers
		// 1: do not use named entities, use decimal numbers instead
		// 2: use named entities, where none exist use hexadecimal numbers
		// 3: do not use named entities, use hexadecimal numbers instead
		public const int USE_NAMED_ENT = 0;
		public const int NO_NAMED_ENT = 1;
		public const int DEC_ENT = 0;
		public const int HEX_ENT = 2;
		
		//UPGRADE_NOTE: Die Initialisierung von "namedMode" wurde nach static method 'greekconverter.UnicodeToHtml' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		public static int namedMode;
		//UPGRADE_NOTE: Die Initialisierung von "numberMode" wurde nach static method 'greekconverter.UnicodeToHtml' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		public static int numberMode;
		
		// for comments what is going on here look into the code of UnicodeToName
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLookup " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[][] tblLookup;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLatin1 " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblLatin1;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblDiacritGreek " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblDiacritGreek;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblPunct " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblPunct;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblNotSupported " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblNotSupported;
		
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "21-Apr-2002"; break;
				
				case 1:  info = "Converts Unicode (precomposed or decomposed) into HTML entities"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Sapere aude!";
					break;
				
			}
			return info;
		}
		
		
		/// <summary> Converts a Unicode string into a string consisting of HTML entities.
		/// Since version 4.0 HTML uses the Universal Character Set (UCS) which is based on the Unicode
		/// system. Since then any Unicode character can be noted like <code>&amp;#252;</code> (decimal)
		/// or <code>&amp;#xFC;</code> (hexadecimal). Alternatively you can tell the browser how to interpret the
		/// content of a HTML page by the charset-property in the meta-tag in the head-section:
		/// <code>&lt;meta http-equiv="Content-Type" content="text/html; charset=utf-8"&gt;</code>
		/// *
		/// </summary>
		/// <param name="uniText">the Unicode text string
		/// </param>
		/// <returns>  the converted text in HTML format
		/// </returns>
		internal static System.String convertString(System.String uniString)
		{
			System.Text.StringBuilder htmlString = new System.Text.StringBuilder();
			int strLen = uniString.Length, i;
			
			MessageHandler.clearMsgQueue();
			
			for (i = 0; i < strLen; i++)
			{
				htmlString.Append(convertChar(uniString[i]));
				MessageHandler.enqueueMsg(" at pos. " + (i + 1).ToString() + "\n");
			}
			
			return htmlString.ToString();
		}
		
		/*
		* Converts a Unicode character into an HTML entity.*/
		private static System.String convertChar(char uniChar)
		{
			System.String htmlEntity = new System.String("".ToCharArray());
			System.Int32 i = uniChar;
			
			// US-ASCII characters remain as they are, this includes treatment of
			// white space characters:
			if (uniChar <= UC.USASCII_UPPER_BOUND)
			{
				htmlEntity = uniChar.ToString();
			}
			else
			{
				if (namedMode == USE_NAMED_ENT)
				{
					htmlEntity = tblLookup[uniChar >> 8][uniChar & 255];
				}
				
				if (htmlEntity.Equals(""))
				// do not use named entities specified or no named entity available
				{
					if (numberMode == DEC_ENT)
					{
						htmlEntity = "&#" + System.Convert.ToString(uniChar) + ";";
					}
					else
					{
						htmlEntity = "&#x" + System.Convert.ToString(uniChar, 16) + ";";
					}
				}
			}
			return htmlEntity;
		}
		static UnicodeToHtml()
		{
			namedMode = USE_NAMED_ENT;
			numberMode = DEC_ENT;
			tblLookup = new System.String[256][];
			tblLatin1 = new System.String[256];
			tblDiacritGreek = new System.String[256];
			tblPunct = new System.String[256];
			tblNotSupported = new System.String[256];
			{
				int i;
				for (i = 0; i < 256; i++)
				{
					tblLookup[i] = tblNotSupported;
					tblNotSupported[i] = "";
					tblLatin1[i] = "";
					tblDiacritGreek[i] = "";
					tblPunct[i] = "";
				}
				tblLookup[0] = tblLatin1;
				tblLookup[3] = tblDiacritGreek;
				tblLookup[32] = tblPunct;
				// Latin 1:
				tblLatin1[160] = "&nbsp;"; // no-break space
				tblLatin1[161] = "&iexcl;"; // inverted exclamation mark
				tblLatin1[162] = "&cent;"; // cent sign
				tblLatin1[163] = "&pound;"; // pound sign
				tblLatin1[164] = "&curren;"; // currency sign
				tblLatin1[165] = "&yen;"; // yen sign
				tblLatin1[166] = "&brvbar;"; // broken vertical bar
				tblLatin1[167] = "&sect;"; // section sign §
				tblLatin1[168] = "&uml;"; // umlaut dots
				tblLatin1[169] = "&copy;"; // copyright sign
				tblLatin1[170] = "&ordf;"; // feminine ordinal indicator
				tblLatin1[171] = "&laquo;"; // left-pointing angle quotation mark
				tblLatin1[172] = "&not;"; // not sign
				tblLatin1[173] = "&shy;"; // short hyphen
				tblLatin1[174] = "&reg;"; // registered sign
				tblLatin1[175] = "&macr;"; // macron
				tblLatin1[176] = "&deg;"; // degree sign
				tblLatin1[177] = "&plusmn;"; // plus-minus
				tblLatin1[178] = "&sup2;"; // superscript 2
				tblLatin1[179] = "&sup3;"; // superscript 3
				tblLatin1[180] = "&acute;"; // acute accent
				tblLatin1[181] = "&micro;"; // micro sign
				tblLatin1[182] = "&para;"; // paragraph sign
				tblLatin1[183] = "&middot;"; // middle dot
				tblLatin1[184] = "&cedil;"; // cedilla
				tblLatin1[185] = "&sup1;"; // superscript 1
				tblLatin1[186] = "&ordm;"; // masculine ordinal indicator
				tblLatin1[187] = "&raquo;"; // right-pointing angle quotation mark
				tblLatin1[188] = "&frac14;"; // fraction 1/4
				tblLatin1[189] = "&frac12;"; // fraction 1/2
				tblLatin1[190] = "&frac34;"; // fraction 3/4
				tblLatin1[191] = "&iquest;"; // inverted question mark
				tblLatin1[192] = "&Agrave;"; // capital A with grave
				tblLatin1[193] = "&Aacute;"; // capital A with acute
				tblLatin1[194] = "&Acirc;"; // capital A with circumflex
				tblLatin1[195] = "&Atilde;"; // capital A with tilde
				tblLatin1[196] = "&Auml;"; // capital A with umlaut
				tblLatin1[197] = "&Aring;"; // capital A with ring
				tblLatin1[198] = "&AElig;"; // capital ligature AE
				tblLatin1[199] = "&Ccedil;"; // capital C with cedilla
				tblLatin1[200] = "&Egrave;"; // capital E with grave
				tblLatin1[201] = "&Eacute;"; // capital E with acute
				tblLatin1[202] = "&Ecirc;"; // capital E with circumflex
				tblLatin1[203] = "&Euml;"; // capital E with umlaut
				tblLatin1[204] = "&Igrave;"; // capital I with grave
				tblLatin1[205] = "&Iacute;"; // capital I with acute
				tblLatin1[206] = "&Icirc;"; // capital I with circumflex
				tblLatin1[207] = "&Iuml;"; // capital I with umlaut
				tblLatin1[208] = "&ETH;"; // icelandic capital Eth
				tblLatin1[209] = "&Ntilde;"; // capital N with tilde
				tblLatin1[210] = "&Ograve;"; // capital O with grave
				tblLatin1[211] = "&Oacute;"; // capital O with acute
				tblLatin1[212] = "&Ocirc;"; // capital O with circumflex
				tblLatin1[213] = "&Otilde;"; // capital O with tilde
				tblLatin1[214] = "&Ouml;"; // capital O with umlaut
				tblLatin1[215] = "&times;"; // times sign
				tblLatin1[216] = "&Oslash;"; // capital O with slash
				tblLatin1[217] = "&Ugrave;"; // capital U with grave
				tblLatin1[218] = "&Uacute;"; // capital U with acute
				tblLatin1[219] = "&Ucirc;"; // capital U with circumflex
				tblLatin1[220] = "&Uuml;"; // capital U with umlaut
				tblLatin1[221] = "&Yacute;"; // capital Y with acute
				tblLatin1[222] = "&THORN;"; // icelandic capital Thorn
				tblLatin1[223] = "&szlig;"; // ligature sz (sharp s)
				tblLatin1[224] = "&agrave;"; // small a with grave
				tblLatin1[225] = "&aacute;"; // small a with acute
				tblLatin1[226] = "&acirc;"; // small a with circumflex
				tblLatin1[227] = "&atilde;"; // small a with tilde
				tblLatin1[228] = "&auml;"; // small a with umlaut
				tblLatin1[229] = "&aring;"; // small a with ring
				tblLatin1[230] = "&aelig;"; // small ligature ae
				tblLatin1[231] = "&ccedil;"; // small c with cedilla
				tblLatin1[232] = "&egrave;"; // small e with grave
				tblLatin1[233] = "&eacute;"; // small e with acute
				tblLatin1[234] = "&ecirc;"; // small e with circumflex
				tblLatin1[235] = "&euml;"; // small e with umlaut
				tblLatin1[236] = "&igrave;"; // small i with grave
				tblLatin1[237] = "&iacute;"; // small i with acute
				tblLatin1[238] = "&icirc;"; // small i with circumflex
				tblLatin1[239] = "&iuml;"; // small i with umlaut
				tblLatin1[240] = "&eth;"; // icelandic small eth
				tblLatin1[241] = "&ntilde;"; // small n with tilde
				tblLatin1[242] = "&ograve;"; // small o with grave
				tblLatin1[243] = "&oacute;"; // small o with acute
				tblLatin1[244] = "&ocirc;"; // small o with circumflex
				tblLatin1[245] = "&otilde;"; // small o with tilde
				tblLatin1[246] = "&ouml;"; // small o with umlaut
				tblLatin1[247] = "&divide;"; // division sign
				tblLatin1[248] = "&oslash;"; // small o with slash
				tblLatin1[249] = "&ugrave;"; // small u with grave
				tblLatin1[250] = "&uacute;"; // small u with acute
				tblLatin1[251] = "&ucirc;"; // small u with circumflex
				tblLatin1[252] = "&uuml;"; // small u with umlaut
				tblLatin1[253] = "&yacute;"; // small y with acute
				tblLatin1[254] = "&thorn;"; // icelandic small thorn
				tblLatin1[255] = "&yuml;"; // small y with umlaut
				// Greek letters:
				tblDiacritGreek[145] = "&Alpha;";
				tblDiacritGreek[146] = "&Beta;";
				tblDiacritGreek[147] = "&Gamma;";
				tblDiacritGreek[148] = "&Delta;";
				tblDiacritGreek[149] = "&Epsilon;";
				tblDiacritGreek[150] = "&Zeta;";
				tblDiacritGreek[151] = "&Eta;";
				tblDiacritGreek[152] = "&Theta;";
				tblDiacritGreek[153] = "&Iota;";
				tblDiacritGreek[154] = "&Kappa;";
				tblDiacritGreek[155] = "&Lambda;";
				tblDiacritGreek[156] = "&Mu;";
				tblDiacritGreek[157] = "&Nu;";
				tblDiacritGreek[158] = "&Xi;";
				tblDiacritGreek[159] = "&Omicron;";
				tblDiacritGreek[160] = "&Pi;";
				tblDiacritGreek[161] = "&Rho;";
				tblDiacritGreek[163] = "&Sigma;";
				tblDiacritGreek[164] = "&Tau;";
				tblDiacritGreek[165] = "&Upsilon;";
				tblDiacritGreek[166] = "&Phi;";
				tblDiacritGreek[167] = "&Chi;";
				tblDiacritGreek[168] = "&Psi;";
				tblDiacritGreek[169] = "&Omega;";
				tblDiacritGreek[177] = "&alpha;";
				tblDiacritGreek[178] = "&beta;";
				tblDiacritGreek[179] = "&gamma;";
				tblDiacritGreek[180] = "&delta;";
				tblDiacritGreek[181] = "&epsilon;";
				tblDiacritGreek[182] = "&zeta;";
				tblDiacritGreek[183] = "&eta;";
				tblDiacritGreek[184] = "&theta;";
				tblDiacritGreek[185] = "&iota;";
				tblDiacritGreek[186] = "&kappa;";
				tblDiacritGreek[187] = "&lambda;";
				tblDiacritGreek[188] = "&mu;";
				tblDiacritGreek[189] = "&nu;";
				tblDiacritGreek[190] = "&xi;";
				tblDiacritGreek[191] = "&omicron;";
				tblDiacritGreek[192] = "&pi;";
				tblDiacritGreek[193] = "&rho;";
				tblDiacritGreek[194] = "&sigmaf;"; // final sigma
				tblDiacritGreek[195] = "&sigma;";
				tblDiacritGreek[196] = "&tau;";
				tblDiacritGreek[197] = "&upsilon;";
				tblDiacritGreek[198] = "&phi;";
				tblDiacritGreek[199] = "&chi;";
				tblDiacritGreek[200] = "&psi;";
				tblDiacritGreek[201] = "&omega;";
				tblDiacritGreek[209] = "&thetasym;"; // small theta symbol
				tblDiacritGreek[210] = "&upsih;"; // capital ypsilon with hook
				tblDiacritGreek[214] = "&piv;"; // small pi symbol (omega-shaped pi)
				// general punctuation:
				tblPunct[2] = "&ensp;"; // n space
				tblPunct[3] = "&emsp;"; // m space
				tblPunct[9] = "&thinsp;"; // thin space
				tblPunct[12] = "&zwnj;"; // zero width non-joiner
				tblPunct[13] = "&zwj;"; // zero width joiner
				tblPunct[14] = "&lrm;"; // left-to-right mark
				tblPunct[15] = "&rlm;"; // right-to-left mark
				tblPunct[19] = "&ndash;"; // n dash
				tblPunct[20] = "&mdash;"; // m dash
				tblPunct[24] = "&lsquo;"; // left single quotation mark
				tblPunct[25] = "&rsquo;"; // right single quotation mark, apostrophe
				tblPunct[26] = "&sbquo;"; // single low-9 quotation mark
				tblPunct[28] = "&ldquo;"; // left double quotation mark
				tblPunct[29] = "&rdquo;"; // right double quotation mark
				tblPunct[30] = "&bdquo;"; // double low-9 quotation mark
				tblPunct[32] = "&dagger;"; // dagger
				tblPunct[33] = "&Dagger;"; // double dagger
				tblPunct[34] = "&bull;"; // bullet
				tblPunct[38] = "&hellip;"; // horizontal ellipsis
				tblPunct[48] = "&permil;"; // per mille sign
				tblPunct[50] = "&prime;"; // prime
				tblPunct[57] = "&lsaquo;"; // left-pointing single angle quotation mark
				tblPunct[58] = "&rsaquo;"; // right-pointing single angle quotation mark
				tblPunct[62] = "&oline;"; // (spacing) overline
				tblPunct[68] = "&frasl;"; // fraction slash
			}
		}
	}
}