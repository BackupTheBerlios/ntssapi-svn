namespace greekconverter
{
	using System;
	/// <summary>************************
	/// </summary>
	/* Betacode -> Unicode      */
	/// <summary>************************
	/// </summary>
	
	public class BetacodeToUnicode
	{
		public BetacodeToUnicode()
		{
			InitBlock();
		}
		private void  InitBlock()
		{
			bracketStack = new System.Collections.Stack();
			state = STATE_NORMAL;
		}
		private const char UNDEFINED_SYMBOL = '\x0000';
		private const sbyte CASE_LOWER = 0;
		private const sbyte CASE_UPPER = 1; // chars preceeded by *
		private const sbyte WORDEND_NO = 0; // for distinction between medial and final sigma
		private const sbyte WORDEND_YES = 1;
		// status
		private const int STATE_NORMAL = 0;
		private const int STATE_SYMBOL = 1;
		private const int STATE_UPPERCASE = 2;
		// first-step lookup table
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLookup " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[][] tblLookup;
		// lookup table for mapping Latin letters to Greek ones,
		// for ease of use be case-sensitive:
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblChars " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblChars;
		// lookup tables for punctuation symbols (% with following number):
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblPunct " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblPunct;
		// lookup tables for text symbols (# with following number):
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblTSyms " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblTSyms;
		// sigma lookup table:
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSigma " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSigma;
		// lookup table for brackets ([ with following number):
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLBrack " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblLBrack;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblRBrack " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblRBrack;
		// lookup table for quotation marks (" with following number):
		//  private static final char tblQuots = new String[33];
		// lookup table for determining if a character is the end of a word:
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblWordEnd " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly sbyte[] tblWordEnd;
		
		
		//UPGRADE_NOTE: Die Initialisierung von "bracketStack" wurde nach method 'InitBlock' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		internal System.Collections.Stack bracketStack;
		//UPGRADE_NOTE: Die Initialisierung von "state" wurde nach method 'InitBlock' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		internal int state;
		
		//UPGRADE_NOTE: Das Feld "EnclosingInstance" wurde der BetaSymbol-Klasse hinzugefügt, um auf die einschließende Instanz zuzugreifen. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1019"'
		private class BetaSymbol
		{
			private void  InitBlock(BetacodeToUnicode enclosingInstance)
			{
				this.enclosingInstance = enclosingInstance;
			}
			private BetacodeToUnicode enclosingInstance;
			virtual public char Character
			{
				get
				{
					return character;
				}
				
				set
				{
					character = value;
				}
				
			}
			virtual public char Breathing
			{
				set
				{
					breathing = value.ToString();
				}
				
			}
			//UPGRADE_TODO: Die getBreathing-Methode wurde in "get accessor" konvertiert. Dieser Name steht mit einer anderen Eigenschaft in Konflikt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1137"'
			virtual public System.String Breathing
			{
				get
				{
					return breathing;
				}
				
			}
			virtual public char Accent
			{
				set
				{
					accent = value.ToString();
				}
				
			}
			//UPGRADE_TODO: Die getAccent-Methode wurde in "get accessor" konvertiert. Dieser Name steht mit einer anderen Eigenschaft in Konflikt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1137"'
			virtual public System.String Accent
			{
				get
				{
					return accent;
				}
				
			}
			virtual public char Iota
			{
				set
				{
					iota = value.ToString();
				}
				
			}
			//UPGRADE_TODO: Die getIota-Methode wurde in "get accessor" konvertiert. Dieser Name steht mit einer anderen Eigenschaft in Konflikt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1137"'
			virtual public System.String Iota
			{
				get
				{
					return iota;
				}
				
			}
			virtual public char Diaeresis
			{
				set
				{
					diaeresis = value.ToString();
				}
				
			}
			//UPGRADE_TODO: Die getDiaeresis-Methode wurde in "get accessor" konvertiert. Dieser Name steht mit einer anderen Eigenschaft in Konflikt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1137"'
			virtual public System.String Diaeresis
			{
				get
				{
					return diaeresis;
				}
				
			}
			virtual public sbyte Case
			{
				get
				{
					return charCase;
				}
				
				set
				{
					charCase = value;
				}
				
			}
			virtual public sbyte WordEnd
			{
				get
				{
					return wordEnd;
				}
				
				set
				{
					wordEnd = value;
				}
				
			}
			virtual public System.String NumStr
			{
				set
				{
					numStr = value;
				}
				
			}
			virtual public int Num
			{
				get
				{
					return System.Int32.Parse(numStr);
				}
				
				set
				{
					numStr = value.ToString();
				}
				
			}
			public BetacodeToUnicode Enclosing_Instance
			{
				get
				{
					return enclosingInstance;
				}
				
			}
			internal char character;
			internal System.String breathing, accent, iota, diaeresis;
			internal sbyte charCase, wordEnd;
			internal System.String numStr;
			
			public virtual void  reset()
			{
				character = ' ';
				breathing = "";
				accent = "";
				iota = "";
				diaeresis = "";
				charCase = greekconverter.BetacodeToUnicode.CASE_LOWER;
				wordEnd = greekconverter.BetacodeToUnicode.WORDEND_NO;
				numStr = "0";
			}
			
			public BetaSymbol(BetacodeToUnicode enclosingInstance)
			{
				InitBlock(enclosingInstance);
				reset();
			}
			
			
			
			
			
			
			
			
			public virtual void  appNumStr(System.String val)
			{
				numStr += val;
			}
			
		}
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "12-Feb-2004"; break;
				
				case 1:  info = "Converts a Beta coded string into *decomposed* Unicode."; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Quid sit futurum cras, fuge quaerere.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Converts a Beta coded string into Unicode.
		/// <p>
		/// The procedure uses the following algorithm:
		/// <ul>
		/// <li>If the current Betacode character is a letter then the preceding letter with its
		/// breathing, accent etc. is converted into a Unicode character:
		/// e.g. "me/n" -> M - E/ - N: when the 'N' is encountered, the preceding 'E' with its attribute OXIA is
		/// converted.</li>
		/// <li>With capital letters the accents are preceding its letter, therefore an additional
		/// letter has to be read and then the conversion be invoked:
		/// e.g. "*(=wn" -> W=( - N (with capital 'W'): when the 'W' is encountered, the following 'N' is read, then
		/// 'W' with its attributes CAPITAL, DASIA and PERISPOMENI is converted.</li>
		/// </ul>
		/// BE CAREFUL: This function is not forgiving. If your Betacode is faulty the output will be crap.
		/// </summary>
		public virtual System.String convertString(System.String betaText)
		{
			//    betaText += ' ';  // append a word end character
			int strLen = betaText.Length, strPos = 0;
			System.Text.StringBuilder uniText = new System.Text.StringBuilder(strLen);
			char currChar = ' ', prevChar = ' '; // the buffered character
			BetaSymbol betaSym = new BetaSymbol(this);
			bool endOfString = false;
			MessageHandler.clearMsgQueue();
			MessageHandler.enqueueMsg("Input >" + betaText + "< has " + strLen + " characters", MessageHandler.MSGLVL_STATUSMSG);
			
			while (strPos < strLen)
			{
				currChar = betaText[strPos++]; // read character
				//System.out.println( "-" + currChar + "/" + nextChar + "/" + betaSym.getCharacter() );
				switch (currChar)
				{
					
					// start an uppercase character:
					case '*': 
						uniText.Append(convertChar(betaSym));
						betaSym.Case = CASE_UPPER;
						state = STATE_UPPERCASE;
						break;
						// diacritics:
					
					case ')':  betaSym.Breathing = UC.COMBINING_COMMA_ABOVE; break;
					
					case '(':  betaSym.Breathing = UC.COMBINING_REVERSED_COMMA_ABOVE; break;
					
					case '/':  betaSym.Accent = UC.COMBINING_ACUTE_ACCENT; break;
					
					case '\\':  betaSym.Accent = UC.COMBINING_GRAVE_ACCENT; break;
					
					case '=':  betaSym.setAccent(UC.COMBINING_PERISPOMENI); break;
					
					case '|':  betaSym.Iota = UC.COMBINING_YPOGEGRAMMENI; break;
					
					case '+':  betaSym.Diaeresis = UC.COMBINING_DIAERESIS; break;
						// start a symbol / brace:
					
					case '%': 
					case '#': 
					case '[': 
					case ']': 
						uniText.Append(convertChar(betaSym));
						betaSym.Character = currChar;
						state = STATE_SYMBOL;
						break;
						// sigma (has uppercase/lowercase distinction and can be suffixed with digits):
					
					case 's': 
					case 'S': 
						if (state == STATE_UPPERCASE)
						{
							betaSym.Character = currChar;
							state = STATE_NORMAL; // end of uppercase character
							break;
						}
						// if lowercase there might be trailing digits -> behave like symbols (%. #):
						else
						{
							uniText.Append(convertChar(betaSym));
							betaSym.Character = currChar;
							state = STATE_SYMBOL;
							break;
						}
						// digits:
						goto case '0';
					
					case '0': 
					case '1': 
					case '2': 
					case '3': 
					case '4': 
					case '5': 
					case '6': 
					case '7': 
					case '8': 
					case '9': 
						if (state == STATE_SYMBOL)
						{
							betaSym.appNumStr(currChar.ToString());
							break;
						}
						// anything else:
						goto default;
					
					default: 
						if (state == STATE_UPPERCASE)
						{
							betaSym.Character = currChar;
							state = STATE_NORMAL; // end of uppercase character
							break;
						}
						// otherwise convert previous character:
						else
						{
							betaSym.WordEnd = tblWordEnd[currChar]; // determine word end
							uniText.Append(convertChar(betaSym)); // convert letter
							betaSym.Character = currChar;
						}
						break;
					
				} // switch
				
				MessageHandler.enqueueMsg(" at pos. " + strPos + "\n");
			}
			
			// do not forget to convert the very last letter:
			betaSym.WordEnd = WORDEND_YES;
			uniText.Append(convertChar(betaSym));
			MessageHandler.enqueueMsg(" at pos. " + strPos + "\n");
			
			return uniText.ToString();
		}
		
		/// <summary> Converts a Betacode "character" into Unicode
		/// </summary>
		private System.String convertChar(BetaSymbol betaSym)
		{
			System.Text.StringBuilder uniBuf = new System.Text.StringBuilder(5);
			System.String uniStr;
			char symChar = betaSym.Character, uniChar;
			sbyte charCase = betaSym.Case;
			int symNum = betaSym.Num;
			
			try
			{
				// if a letter then distinguish lowercase / uppercase:
				if (tblLookup[symChar] == tblChars)
				{
					if (charCase == CASE_UPPER)
					{
						symNum = System.Char.ToUpper(symChar);
					}
					else
					{
						symNum = System.Char.ToLower(symChar);
					}
				}
				// if a sigma then be careful, here is a trap: *S, S1, S2 and S3 are defined,
				// but what is the correct conversion for S12? medial sigma followed by digit
				// 2? or a question mark indicating "did not understand what was meant". what
				// for *S1? uppercase sigma followed by digit 1?
				// to keep it simple we do the following:
				// + for uppercase sigma we handle the trailing digits as characters if their own,
				//   *S1 = uppercase sigma followed by digit 1.
				// + for lowercase sigma we use the trailing digits as array subscript, in case
				//   of undefined subscripts (S12) we run into an exception and the S12 is written
				//   to the output unchanged.
				//   Due to this S0 and S4 are valid subscripts!!!
				// + if there are no trailing digits we must check if a final sigma is required.
				else if (tblLookup[symChar] == tblSigma)
				{
					if (charCase == CASE_UPPER)
					{
						symNum = 4; // uppercase sigma
					}
					else
					{
						if ((symNum == 0) && (betaSym.WordEnd == WORDEND_YES))
						// ... at word end
						{
							symNum = 2; // final sigma
						}
					}
				}
				uniChar = tblLookup[symChar][symNum];
				// if undefined Symbol then output the input:
				if (uniChar == UNDEFINED_SYMBOL)
				{
					uniBuf.Append(symChar);
					uniBuf.Append(symNum);
				}
				else
				{
					uniBuf.Append(uniChar);
					uniBuf.Append(betaSym.Breathing);
					uniBuf.Append(betaSym.Diaeresis); // Unicode stacking order: diaeresis before accent
					uniBuf.Append(betaSym.Accent);
					uniBuf.Append(betaSym.Iota);
				}
			}
			// e.g. %4711 -> out of bounds -> output the input
			catch (System.Exception e)
			{
				// e.printStackTrace();
				uniBuf.Append(symChar);
				uniBuf.Append(symNum);
			}
			// reset member vars and return conversion result:
			state = STATE_NORMAL;
			betaSym.reset();
			uniStr = uniBuf.ToString();
			MessageHandler.enqueueMsg(UnicodeToName.convertString(uniStr), MessageHandler.MSGLVL_STATUSMSG);
			return uniStr;
		}
		static BetacodeToUnicode()
		{
			tblLookup = new char[256][];
			tblChars = new char[256];
			tblPunct = new char[164];
			tblTSyms = new char[23];
			tblSigma = new char[5];
			tblLBrack = new char[33];
			tblRBrack = new char[33];
			tblWordEnd = new sbyte[256];
			{
				int i;
				//
				// first-step lookup table
				//
				// initialize lookup table:
				for (i = 0; i < 256; i++)
				{
					tblLookup[i] = tblChars;
				}
				//    tblLookup['"']  = tblQuots;  // not yet implemented
				tblLookup['#'] = tblTSyms;
				tblLookup['%'] = tblPunct;
				tblLookup['S'] = tblSigma;
				tblLookup['['] = tblLBrack;
				tblLookup[']'] = tblRBrack;
				tblLookup['s'] = tblSigma;
				//
				// letter lookup table
				//
				// initialize lookup table:
				for (i = 0; i < 256; i++)
				{
					tblChars[i] = (char) i;
				}
				// fill in Greek letters:
				// uppercase chars:
				tblChars['!'] = UC.ONE_DOT_LEADER; // missing letter dot
				tblChars['?'] = UC.COMBINING_DOT_BELOW; // uncertain character dot
				tblChars[65] = UC.CAPITAL_ALPHA; // A
				tblChars[66] = UC.CAPITAL_BETA; // B
				tblChars[67] = UC.CAPITAL_XI; // C
				tblChars[68] = UC.CAPITAL_DELTA; // D
				tblChars[69] = UC.CAPITAL_EPSILON; // E
				tblChars[70] = UC.CAPITAL_PHI; // F
				tblChars[71] = UC.CAPITAL_GAMMA; // G
				tblChars[72] = UC.CAPITAL_ETA; // H
				tblChars[73] = UC.CAPITAL_IOTA; // I
				tblChars[74] = UNDEFINED_SYMBOL; // J not defined
				tblChars[75] = UC.CAPITAL_KAPPA; // K
				tblChars[76] = UC.CAPITAL_LAMDA; // L
				tblChars[77] = UC.CAPITAL_MU; // M
				tblChars[78] = UC.CAPITAL_NU; // N
				tblChars[79] = UC.CAPITAL_OMICRON; // O
				tblChars[80] = UC.CAPITAL_PI; // P
				tblChars[81] = UC.CAPITAL_THETA; // Q
				tblChars[82] = UC.CAPITAL_RHO; // R
				tblChars[83] = UC.CAPITAL_SIGMA; // S
				tblChars[84] = UC.CAPITAL_TAU; // T
				tblChars[85] = UC.CAPITAL_UPSILON; // U
				tblChars[86] = UC.DIGAMMA; // V
				tblChars[87] = UC.CAPITAL_OMEGA; // W
				tblChars[88] = UC.CAPITAL_CHI; // X
				tblChars[89] = UC.CAPITAL_PSI; // Y
				tblChars[90] = UC.CAPITAL_ZETA; // Z
				// lowercase chars:
				tblChars[97] = UC.ALPHA; // a
				tblChars[98] = UC.BETA; // b
				tblChars[99] = UC.XI; // c
				tblChars[100] = UC.DELTA; // d
				tblChars[101] = UC.EPSILON; // e
				tblChars[102] = UC.PHI; // f
				tblChars[103] = UC.GAMMA; // g
				tblChars[104] = UC.ETA; // h
				tblChars[105] = UC.IOTA; // i
				tblChars[106] = UC.FINAL_SIGMA; // j, but use is deprecated!
				tblChars[107] = UC.KAPPA; // k
				tblChars[108] = UC.LAMDA; // l
				tblChars[109] = UC.MU; // m
				tblChars[110] = UC.NU; // n
				tblChars[111] = UC.OMICRON; // o
				tblChars[112] = UC.PI; // p
				tblChars[113] = UC.THETA; // q
				tblChars[114] = UC.RHO; // r
				tblChars[115] = UC.SIGMA; // s
				tblChars[116] = UC.TAU; // t
				tblChars[117] = UC.UPSILON; // u
				tblChars[118] = UC.SMALL_DIGAMMA; // v
				tblChars[119] = UC.OMEGA; // w
				tblChars[120] = UC.CHI; // x
				tblChars[121] = UC.PSI; // y
				tblChars[122] = UC.ZETA; // z
				
				//
				// punctuation symbols lookup table
				//
				// initialize lookup table:
				for (i = 0; i < 164; i++)
				{
					tblPunct[i] = UNDEFINED_SYMBOL; // signal for not defined / not convertable
				}
				// fill table:
				tblPunct[0] = UC.DAGGER; // '%' without number (not '%0'), crux indicating corrupt text
				tblPunct[1] = '?';
				tblPunct[2] = '*'; // mostly to denote lacunae
				tblPunct[3] = '/';
				tblPunct[4] = '!';
				tblPunct[5] = '|'; // denoting lineation or pagination
				tblPunct[6] = '=';
				tblPunct[7] = '+';
				tblPunct[8] = '%'; // unused
				tblPunct[9] = '&';
				tblPunct[10] = ':'; // dicolon in Greek font
				tblPunct[11] = '.'; // "oversized period", don't know its Unicode counterpart
				tblPunct[12] = UC.DIVISION_TIMES; // asterisk (crux)
				tblPunct[13] = UC.DOUBLE_DAGGER; // unused
				tblPunct[14] = '§';
				tblPunct[15] = UC.PRIME; // short vertical bar indicating line breaks
				tblPunct[16] = UC.BROKEN_VERTICAL_BAR; // unused
				tblPunct[17] = UC.DOUBLE_VERTICAL_LINE; // similar to #5
				tblPunct[18] = '<'; // apostrophe (abbrev. marker), sometimes like <, sometimes like '
				tblPunct[19] = UC.HYPHEN; // mid-line hyphen
				tblPunct[20] = UC.COMBINING_ACUTE_ACCENT; // obsolete
				tblPunct[21] = UC.COMBINING_GRAVE_ACCENT; // obsolete
				tblPunct[22] = UC.COMBINING_CIRCUMFLEX_ACCENT; // obsolete
				tblPunct[23] = UC.COMBINING_DIAERESIS; // combining umlaut, obsolete
				tblPunct[24] = UC.COMBINING_TILDE;
				tblPunct[25] = UC.COMBINING_CEDILLA;
				tblPunct[26] = UC.COMBINING_MACRON;
				tblPunct[27] = UC.COMBINING_BREVE;
				tblPunct[28] = UC.COMBINING_DIAERESIS; // combining diaeresis, obsolete
				tblPunct[29] = UC.COMBINING_DOT_BELOW; // combining colon below, don't know its Unicode counterpart
				tblPunct[30] = UC.PSILI; // smooth breathing without letter
				tblPunct[31] = UC.DASIA; // rough breathing -"-
				tblPunct[32] = UC.OXIA; // acute accent -"-
				tblPunct[33] = UC.VARIA; // grave accent -"-
				tblPunct[34] = UC.PERISPOMENI; // circumflex accent -"-
				tblPunct[35] = UC.PSILI_OXIA; // )/
				tblPunct[36] = UC.DASIA_OXIA; // (/
				tblPunct[37] = UC.DASIA_VARIA; // (\
				tblPunct[38] = UC.DASIA_PERISPOMENI; // (=
				tblPunct[39] = UC.DIAERESIS; // diaresis without letter
				tblPunct[40] = UC.MODIFIER_BREVE; // metrical short
				tblPunct[41] = UC.MACRON; // metrical long
				// %42 two shorts over one long
				tblPunct[43] = 'x'; // anceps
				// %44 metrical long over short
				// %45 metrical short over long
				// %46 metrical long over two shorts
				tblPunct[47] = '='; // metrical long over long
				// %48 metrical short over short
				// %49 metrical triple shorts (i.e. short over short over short)
				// %50 - %73 papyrological fractions
				// %80 inscr. blank space (v.)
				// %81 inscr. blank spaces (vac.)
				// %91 H-like rough breathing (left half of H)
				// %92 H-like smooth breathing (right half of H)
				// %93 papyr. dot-backslash-dot combining form above letter
				tblPunct[94] = UC.COMBINING_DOT_ABOVE; // ancient deletion sign
				// %95 papyr. dot-slash-dot combining form above letter
				// %96 Alexandrian hyphen (looks like u, sometimes turned 90° to the right
				// %97 Myriad diaeresis combining form (looks like umlaut)
				tblPunct[98] = UC.DITTO_MARK; // looks like right pointing guillemet
				// 99 undefined
				tblPunct[100] = ';'; // semicolon
				tblPunct[101] = '#'; // hash sign, unused
				tblPunct[102] = '\''; // opening single quote, obsolete
				tblPunct[103] = '\\'; // backslash
				tblPunct[104] = UC.CARET; // caret
				// %105 triple vertical bar
				// %106 tilde over double dash
				tblPunct[107] = '~'; // tilde
				tblPunct[108] = '±'; // plus-minus
				tblPunct[109] = '·'; // mid-line dot
				// %110 small round hollow dot (like degree sign, but on the line)
				// 111-126 not defined
				tblPunct[127] = UC.COMBINING_INVERTED_BREVE_BELOW;
				tblPunct[128] = UC.COMBINING_CIRCUMFLEX_ACCENT; // over-caret combining form (looks like inverted hacek)
				tblPunct[129] = UC.DAGGER; // secondary crux, but cannot see any difference to %
				// %130 dot over *previous* numeral combining form, unused
				// 131 not defined
				tblPunct[132] = UC.DIALYTIKA_OXIA; // /+ without letter
				tblPunct[133] = UC.PSILI_VARIA; // )\ -"-
				tblPunct[134] = UC.PSILI_PERISPOMENI; // )= -"-
				// 135-139 not defined
				// %140 metrical triple long, i.e. long over long over long
				// %141 metrical two shors joined
				// %142 previous vowel short by position
				// 143 not defined
				// %144 metrical breve in longo vel longum in brevi
				// %145 metrical long with stress mark
				// %146 mid line dot: Latin word divider, unused
				tblPunct[147] = UC.COMBINING_RING_ABOVE; // Skandinavian bolle combining form
				tblPunct[148] = UC.COMBINING_CARON; // hacek combining form
				tblPunct[149] = UC.COMBINING_OGONEK; // reverse cedilla (hec) combining form, unused
				tblPunct[150] = '|'; // metrical foot devider, looks like vertical bar, obsolete
				tblPunct[151] = UC.HYPHEN; // insert rule (leader), unused
				tblPunct[152] = '.'; // insert dots (leader), unused
				tblPunct[153] = UC.HYPHEN; // insert hyphens (leader), unused
				tblPunct[154] = UC.THEREFORE; // three-dot pattern, unused
				// %155 three-dot pattern up-side down, unused
				// 156 not defined
				// %157 inverted crux (dagger up-side down), unused
				tblPunct[158] = UC.ASTERISM; // three-asterisk pattern, unused
				tblPunct[159] = '×'; // multiplication sign, unused
				tblPunct[160] = '-'; // minus sign, unused
				tblPunct[161] = '÷'; // division sign, unused
				tblPunct[162] = UC.COMBINING_LONG_SOLIDUS_OVERLAY; // slash through prev. letter combining form
				tblPunct[163] = '¶'; // paragraph sign, unused
				// 164-169 not defined
				// %170 apograph emendation combining form, looks like a * below character
				// %171 combined fragments, looks like a double slash
				
				//
				// text symbols lookup table
				//
				// initialize lookup table:
				for (i = 0; i < 23; i++)
				{
					tblTSyms[i] = UNDEFINED_SYMBOL;
				}
				// fill table:
				// only a few symbols are supported; an overwhelming number of symbols are signs
				// for ancient editorial, numerical symbols, papyrological and inscriptional symbols
				// weights and measures, astronomical symbols, musical symbols etc. Most of them are
				// not supported here because either there is no Unicode counterpart (in most cases)
				// or they are of very rare occurrence.
				tblTSyms[0] = UC.NUMERAL_SIGN; // numeric signifier or abbr. marker
				tblTSyms[1] = UC.KOPPA; // sigmoid koppa (mainly numeric, obsolete)
				tblTSyms[2] = UC.STIGMA;
				tblTSyms[3] = UC.KOPPA; // Q-like koppa
				tblTSyms[4] = UC.KOPPA; // G-like stigma/koppa (almost always koppa, obsolete, use #2/#3 instead)
				tblTSyms[5] = UC.SAMPI;
				tblTSyms[6] = UC.HYPHEN; // paragraphos
				tblTSyms[7] = '.'; // partial letter (any shape)
				tblTSyms[9] = UC.COMBINING_ACUTE_ACCENT; // editorial acute combining form
				tblTSyms[17] = '/'; // lineola obliqua
				tblTSyms[19] = UC.COMBINING_GRAVE_ACCENT; // editorial grave combining form
				tblTSyms[22] = UC.LOWER_NUMERAL_SIGN; // low keraia
				
				//
				// sigma lookup table
				//
				tblSigma[0] = UC.SIGMA;
				tblSigma[1] = UC.SIGMA; // S1 medial sigma at the end of a word
				tblSigma[2] = UC.FINAL_SIGMA; // S2 final sigma in the middle of a word
				tblSigma[3] = UC.LUNATE_SIGMA_SYMBOL; // S3 lunate sigma, obsolete
				tblSigma[4] = UC.CAPITAL_SIGMA;
				//
				// brackets lookup table
				//
				//
				// initialize lookup table:
				for (i = 0; i < 33; i++)
				{
					tblLBrack[i] = UNDEFINED_SYMBOL; // signal for not defined / not convertable
					tblRBrack[i] = UNDEFINED_SYMBOL;
				}
				tblLBrack[0] = '['; // square brackets denote completions (rarely deletions)
				tblRBrack[0] = ']';
				tblLBrack[1] = '('; // parenthesis (sometimes used to denote additions)
				tblRBrack[1] = ')';
				tblLBrack[2] = UC.LEFT_ANGLE_BRACKET; // angle brackets denote interpolations (cod.), sometimes additions (pap.)
				tblRBrack[2] = UC.RIGHT_ANGLE_BRACKET;
				tblLBrack[3] = '{'; // braces denote interpolations (pap.) or editorial deletions (cod.)
				tblRBrack[3] = '}';
				tblLBrack[4] = UC.LEFT_WHITE_SQUARE_BRACKET;
				tblRBrack[4] = UC.RIGHT_WHITE_SQUARE_BRACKET;
				tblLBrack[5] = UC.BOTTOM_LEFT_CORNER;
				tblRBrack[5] = UC.BOTTOM_RIGHT_CORNER;
				tblLBrack[6] = UC.TOP_LEFT_CORNER;
				tblRBrack[6] = UC.TOP_RIGHT_CORNER;
				tblLBrack[7] = UC.TOP_LEFT_CORNER;
				tblRBrack[7] = UC.BOTTOM_RIGHT_CORNER;
				tblLBrack[8] = UC.BOTTOM_LEFT_CORNER;
				tblRBrack[8] = UC.TOP_RIGHT_CORNER;
				// [9 raised dot brackets, archaic bracketting in papyri
				// [10 large square brackets, unused
				tblLBrack[11] = UC.SUBSCRIPT_LEFT_PARENTHESIS; // to enclose missing letter dot
				tblRBrack[11] = UC.SUBSCRIPT_RIGHT_PARENTHESIS;
				// [12 arrows denoting ipsissima verba
				tblLBrack[13] = '['; // tilted square brackets
				tblRBrack[13] = ']';
				// [14 hymn brackets, looking like |: :|
				// [15 "decipherment of codes" = ??
				tblLBrack[16] = UC.LEFT_WHITE_LENTICULAR_BRACKET;
				tblRBrack[16] = UC.RIGHT_WHITE_LENTICULAR_BRACKET;
				// [17 hollow lower square brackets, look like a hollow L - mirrored L
				tblLBrack[18] = UC.LEFT_DOUBLE_ANGLE_BRACKET;
				tblRBrack[18] = UC.RIGHT_DOUBLE_ANGLE_BRACKET;
				// 19 not defined
				tblLBrack[20] = UC.LEFT_CURLY_BRACKET_UPPER_HOOK;
				tblRBrack[20] = UC.RIGHT_CURLY_BRACKET_UPPER_HOOK;
				tblLBrack[21] = UC.CURLY_BRACKET_EXTENSION;
				tblRBrack[21] = UC.CURLY_BRACKET_EXTENSION;
				tblLBrack[22] = UC.LEFT_CURLY_BRACKET_MIDDLE_PIECE;
				tblRBrack[22] = UC.RIGHT_CURLY_BRACKET_MIDDLE_PIECE;
				tblLBrack[23] = UC.LEFT_CURLY_BRACKET_LOWER_HOOK;
				tblRBrack[23] = UC.RIGHT_CURLY_BRACKET_LOWER_HOOK;
				// 24-29 not defined
				tblLBrack[30] = UC.LEFT_PARENTHESIS_UPPER_HOOK;
				tblRBrack[30] = UC.RIGHT_PARENTHESIS_UPPER_HOOK;
				tblLBrack[31] = UC.LEFT_PARENTHESIS_EXTENSION;
				tblRBrack[31] = UC.RIGHT_PARENTHESIS_EXTENSION;
				tblLBrack[32] = UC.LEFT_PARENTHESIS_LOWER_HOOK;
				tblRBrack[32] = UC.RIGHT_PARENTHESIS_LOWER_HOOK;
				// [33 parenthesis used as punctuation
				// [34 parenthesis used as deletion marker
				// [35 - [49 reserved papyrological brackets
				// [50 rejected text of main ed. (epigr.)
				// [51 erased text (epigr.)
				// [52 text before correction (epigr.)
				// [53 parenthesis used as punctuation
				// [54 - [69 reserved epigraphical brackets
				
				//
				// quotation marks lookup table
				//
				// Because correct matching seems to depend on typographical conventions
				// I need to see some text using these symbols.
				
				//
				// word end lookup table
				//
				for (i = 0; i < 256; i++)
				{
					tblWordEnd[i] = WORDEND_NO;
				}
				tblWordEnd[' '] = WORDEND_YES;
				tblWordEnd['.'] = WORDEND_YES;
				tblWordEnd[':'] = WORDEND_YES;
				tblWordEnd[';'] = WORDEND_YES;
				tblWordEnd[','] = WORDEND_YES;
				tblWordEnd['#'] = WORDEND_YES;
				tblWordEnd['%'] = WORDEND_YES;
				tblWordEnd['['] = WORDEND_YES;
				tblWordEnd[']'] = WORDEND_YES;
				tblWordEnd['"'] = WORDEND_YES;
				tblWordEnd['$'] = WORDEND_YES;
				tblWordEnd['<'] = WORDEND_YES;
				tblWordEnd['>'] = WORDEND_YES;
				tblWordEnd['@'] = WORDEND_YES;
			}
		}
	}
}