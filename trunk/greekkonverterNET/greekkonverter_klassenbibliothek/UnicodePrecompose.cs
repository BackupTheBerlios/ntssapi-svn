namespace greekconverter
{
	using System;
	
	
	/// <summary>************************
	/// </summary>
	
	/* Unicode -> Unicode       */
	
	/// <summary>************************
	/// </summary>
	
	
	
	/// <summary> Class for precomposing of fully decomposed (canonical) Unicode.
	/// <p>
	/// It uses two passes, currently only the first pass is implemented.
	/// </summary>
	
	public class UnicodePrecompose
	{
		/*
		We do a three step lookup. All 255-byte Unicode blocks we do not support for
		precomposing (that is almost all of them) point to the lo-byte array for
		"not supported". The entries in this array all point to an array with only
		one entry containing \u0000. The entries in the Greek block either
		point to the same one-entry-array (no precomposing with diacritics
		possible) or to a detail array.
		
		1st step        2nd step             3rd step
		
		+-------+          +----------+
		+++->|lo-byte|  ++++--->| not supp.|
		
		|||  +-------+  ||||    +----------+
		
		+-------+  |||  | 00   -|--+|||    | 00 uO000 |
		
		|hi-byte|  |||  | 01   -|---+||    +----------+
		
		+-------+  |||  | 02   -|----+|
		
		| 00   -|--+||  | ...   |     |
		
		| 01   -|---+|  +-------+     |     +---------+
		
		| 02   -|----+                | +-->|diacrit.o|
		
		| 03   -|---+                 | |   +---------+
		
		| ...   |   |   +-------+     | |   | 00  o   |
		
		+-------+   +-->|lo-byte|     | |   | 01  o)  |
		
		+-------+     | |   | 02  o(  |
		
		| ...   |     | |   | 03  o/  |
		
		| 9F   -|-----|-+   | ...     |
		
		| A0   -|-----+     +---------+
		
		| A1   -|---+    
		
		| ...   |   |       +---------+
		
		+-------+   +------>|diacrit.r|
		
		+---------+
		
		| 00  r   |
		
		| ...     |
		
		+---------+
		
		
		
		The diacritic detail arrays have sums of possible diacrits as index
		
		and the corresponding precomposed Unicode character as contents.
		
		character       dec    binary
		
		-----------------------------
		
		spiritus lenis:   1  ------01
		
		spiritus asper:   2  ------10
		
		acute accent:     4  ----01--
		
		grave accent:     8  ----10--
		
		circumflex acc.: 12  ----11--
		
		ypogegrammeni:   16  ---1----
		
		diaeresis:       16
		
		
		
		0    1    2    4     5    6     8     9    10   12    13    14
		
		----------------------------------------------------------------
		
		A   A)   A(   A/   A)/   A(/   A\   A)\   A(\   A=   A)=   A(=
		
		I   I)   I(   I/   I)/   I(/   I\   I)\   I(\   I=   I)=   I(=
		
		R   R)   R(
		
		16   17   18   20    21    22   24    25    26   28    29    30
		
		----------------------------------------------------------------
		
		A|  A)|  A(|  A/|  A)/|  A(/|  A\|  A)\|  A(\|  A=|  A)=|  A(=|
		
		I+            I/+              I\+              I=+
		
		
		
		This is error prone, of course, because, e.g., lenis+lenis=asper (1+1=2)
		
		which is nonsense. Detection of faulty Unicode (in terms of Greek) is
		another topic.
		*/
		
		// first step array:
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLookup " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[][][] tblLookup;
		
		// second step arrays:
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblNotSupp1st " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[][] tblNotSupp1st;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblDiacritGreek " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[][] tblDiacritGreek;
		// 0300-036F combining diacritics, 0370-03FF Greek/Coptic
		
		// third step arrays:
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblNotSupp2nd " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblNotSupp2nd;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSmA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSmA;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblCpA " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblCpA;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSmH " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSmH;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblCpH " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblCpH;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSmW " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSmW;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblCpW " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblCpW;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSmE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSmE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblCpE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblCpE;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSmO " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSmO;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblCpO " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblCpO;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSmI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSmI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblCpI " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblCpI;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSmU " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSmU;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblCpU " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblCpU;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSmR " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSmR;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblCpR " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblCpR;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblSpace " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblSpace;
		
		// combination of diacritics we can precompose:
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblDiacrit " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly short[] tblDiacrit;
		
		
		
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "20-Mar-2002"; break;
				
				case 1:  info = "Precomposes fully decomposed Unicode text"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Saepe stilum vertas.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Precomposes a fully decomposed Unicode string in a first pass.
		/// <p>
		/// The first pass handles breathing, accent, iota subscript/adscript
		/// and diaeresis.
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode string
		/// </param>
		/// <returns>  the precomposed version of the String
		/// </returns>
		public static System.String precomposeStringFirstPass(System.String uniString)
		{
			int strLen = uniString.Length, strPos, diacritVal, diacritSum = 0; // sum of values of diacritics for the current character
			System.Text.StringBuilder precomposedString = new System.Text.StringBuilder(strLen * 3), currBuff = new System.Text.StringBuilder(10); // buffer for the current character and its diacritics so far
			char currChar; // current character
			bool errFlag = false;
			
			
			
			for (strPos = 0; strPos < strLen; strPos++)
			{
				
				// "read" next character:
				
				currChar = uniString[strPos];
				
				// if current character is a diacritic:
				
				if ((currChar >= '\u0300') && (currChar <= '\u0345'))
				{
					
					// fetch the diacritic value:
					
					diacritVal = tblDiacrit[currChar & 255];
					
					// set error flag if we cannot precompose this diacritic:
					
					if (diacritVal == 0)
					{
						
						errFlag = true;
					}
					// otherwise add the value to the sum:
					else
					{
						
						diacritSum += diacritVal;
					}
				}
				// if current character is not a diacritic:
				else
				{
					
					// if there was a diacritic we cannot precompose, then append the
					
					// current character buffer to the result string and reset vars:
					
					if (errFlag)
					{
						
						precomposedString.Append(currBuff.ToString());
						
						errFlag = false;
						
						diacritSum = 0;
					}
					// else look up and append to the result string:
					else
					{
						
						precomposedString.Append(precomposeChar(currBuff, diacritSum));
						
						diacritSum = 0;
					}
					
					// reset current character buffer:
					
					currBuff.Length = 0;
				}
				
				// append current character to buffer:
				
				currBuff.Append(currChar);
			}
			
			// do not forget to handle the last character:
			
			precomposedString.Append(precomposeChar(currBuff, diacritSum));
			
			// return result:
			
			return precomposedString.ToString();
		}
		
		
		
		/// <summary> Precomposes a fully decomposed Unicode string in a second pass.
		/// <p>
		/// The second pass handles macron/vrachy and detection of small
		/// iota used instead of iota adscript. This will implemented in a future
		/// version. Currently the method returns the passed string unchanged.
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode string
		/// </param>
		/// <returns>  the precomposed version of the String
		/// </returns>
		
		public static System.String precomposeStringSecondPass(System.String uniString)
		{
			
			return uniString;
		}
		
		
		
		/*
		
		* Returns the normalized equivalent of the input character.
		*/
		
		private static System.String precomposeChar(System.Text.StringBuilder charBuff, int diacrit)
		{
			
			char lookupChar;
			
			try
			{
				
				lookupChar = tblLookup[charBuff[0] >> 8][charBuff[0] & 255][diacrit];
				
				if (lookupChar == UC.CTRL_NULL)
				{
					
					return charBuff.ToString();
				}
				else
				{
					
					return lookupChar.ToString();
				}
			}
			catch (System.Exception e)
			{
				
				return charBuff.ToString();
			}
		}
		static UnicodePrecompose()
		{
			tblLookup = new char[256][][];
			tblNotSupp1st = new char[256][];
			tblDiacritGreek = new char[256][];
			tblNotSupp2nd = new char[1];
			tblSmA = new char[32];
			tblCpA = new char[32];
			tblSmH = new char[32];
			tblCpH = new char[32];
			tblSmW = new char[32];
			tblCpW = new char[32];
			tblSmE = new char[11];
			tblCpE = new char[11];
			tblSmO = new char[11];
			tblCpO = new char[11];
			tblSmI = new char[29];
			tblCpI = new char[17];
			tblSmU = new char[29];
			tblCpU = new char[17];
			tblSmR = new char[3];
			tblCpR = new char[3];
			tblSpace = new char[29];
			tblDiacrit = new short[70];
			{
				
				int i;
				
				
				
				// generally initalize lookup tables:
				
				tblNotSupp2nd[0] = UC.CTRL_NULL;
				
				for (i = 0; i < 256; i++)
				{
					
					tblNotSupp1st[i] = tblNotSupp2nd;
					
					tblDiacritGreek[i] = tblNotSupp2nd;
					
					tblLookup[i] = tblNotSupp1st;
				}
				
				// now assign the conversion values to the table positions:
				
				// SMALL ALPHA
				
				tblSmA[0] = UC.ALPHA;
				
				tblSmA[1] = UC.ALPHA_PSILI;
				
				tblSmA[2] = UC.ALPHA_DASIA;
				
				tblSmA[3] = UC.CTRL_NULL;
				tblSmA[4] = UC.ALPHA_OXIA;
				
				tblSmA[5] = UC.ALPHA_PSILI_OXIA;
				
				tblSmA[6] = UC.ALPHA_DASIA_OXIA;
				
				tblSmA[7] = UC.CTRL_NULL;
				
				tblSmA[8] = UC.ALPHA_VARIA;
				
				tblSmA[9] = UC.ALPHA_PSILI_VARIA;
				
				tblSmA[10] = UC.ALPHA_DASIA_VARIA;
				
				tblSmA[11] = UC.CTRL_NULL;
				
				tblSmA[12] = UC.ALPHA_PERISPOMENI;
				
				tblSmA[13] = UC.ALPHA_PSILI_PERISPOMENI;
				
				tblSmA[14] = UC.ALPHA_DASIA_PERISPOMENI;
				
				tblSmA[15] = UC.CTRL_NULL;
				
				tblSmA[16] = UC.ALPHA_YPOGEGRAMMENI;
				
				tblSmA[17] = UC.ALPHA_PSILI_YPOGEGRAMMENI;
				
				tblSmA[18] = UC.ALPHA_DASIA_YPOGEGRAMMENI;
				
				tblSmA[19] = UC.CTRL_NULL;
				
				tblSmA[20] = UC.ALPHA_OXIA_YPOGEGRAMMENI;
				
				tblSmA[21] = UC.ALPHA_PSILI_OXIA_YPOGEGRAMMENI;
				
				tblSmA[22] = UC.ALPHA_DASIA_OXIA_YPOGEGRAMMENI;
				
				tblSmA[23] = UC.CTRL_NULL;
				
				tblSmA[24] = UC.ALPHA_VARIA_YPOGEGRAMMENI;
				
				tblSmA[25] = UC.ALPHA_PSILI_VARIA_YPOGEGRAMMENI;
				
				tblSmA[26] = UC.ALPHA_DASIA_VARIA_YPOGEGRAMMENI;
				
				tblSmA[27] = UC.CTRL_NULL;
				
				tblSmA[28] = UC.ALPHA_PERISPOMENI_YPOGEGRAMMENI;
				
				tblSmA[29] = UC.ALPHA_PSILI_PERISPOMENI_YPOGEGRAMMENI;
				
				tblSmA[30] = UC.ALPHA_DASIA_PERISPOMENI_YPOGEGRAMMENI;
				
				// CAPITAL ALPHA
				
				tblCpA[0] = UC.CAPITAL_ALPHA;
				
				tblCpA[1] = UC.CAPITAL_ALPHA_PSILI;
				
				tblCpA[2] = UC.CAPITAL_ALPHA_DASIA;
				
				tblCpA[3] = UC.CTRL_NULL;
				
				tblCpA[4] = UC.CAPITAL_ALPHA_OXIA;
				
				tblCpA[5] = UC.CAPITAL_ALPHA_PSILI_OXIA;
				
				tblCpA[6] = UC.CAPITAL_ALPHA_DASIA_OXIA;
				
				tblCpA[7] = UC.CTRL_NULL;
				
				tblCpA[8] = UC.CAPITAL_ALPHA_VARIA;
				
				tblCpA[9] = UC.CAPITAL_ALPHA_PSILI_VARIA;
				
				tblCpA[10] = UC.CAPITAL_ALPHA_DASIA_VARIA;
				
				tblCpA[11] = UC.CTRL_NULL;
				
				tblCpA[12] = UC.CTRL_NULL; // CAPITAL_ALPHA_PERISPOMENI
				
				tblCpA[13] = UC.CAPITAL_ALPHA_PSILI_PERISPOMENI;
				
				tblCpA[14] = UC.CAPITAL_ALPHA_DASIA_PERISPOMENI;
				
				tblCpA[15] = UC.CTRL_NULL;
				
				tblCpA[16] = UC.CAPITAL_ALPHA_PROSGEGRAMMENI;
				
				tblCpA[17] = UC.CAPITAL_ALPHA_PSILI_PROSGEGRAMMENI;
				
				tblCpA[18] = UC.CAPITAL_ALPHA_DASIA_PROSGEGRAMMENI;
				tblCpA[19] = UC.CTRL_NULL;
				
				tblCpA[20] = UC.CTRL_NULL; // CAPITAL_ALPHA_OXIA_PROSGEGRAMMENI
				
				tblCpA[21] = UC.CAPITAL_ALPHA_PSILI_OXIA_PROSGEGRAMMENI;
				
				tblCpA[22] = UC.CAPITAL_ALPHA_DASIA_OXIA_PROSGEGRAMMENI;
				
				tblCpA[23] = UC.CTRL_NULL;
				
				tblCpA[24] = UC.CTRL_NULL; // CAPITAL_ALPHA_VARIA_PROSGEGRAMMENI
				
				tblCpA[25] = UC.CAPITAL_ALPHA_PSILI_VARIA_PROSGEGRAMMENI;
				
				tblCpA[26] = UC.CAPITAL_ALPHA_DASIA_VARIA_PROSGEGRAMMENI;
				
				tblCpA[27] = UC.CTRL_NULL;
				
				tblCpA[28] = UC.CTRL_NULL; // CAPITAL_ALPHA_PERISPOMENI_PROSGEGRAMMENI
				
				tblCpA[29] = UC.CAPITAL_ALPHA_PSILI_PERISPOMENI_PROSGEGRAMMENI;
				
				tblCpA[30] = UC.CAPITAL_ALPHA_DASIA_PERISPOMENI_PROSGEGRAMMENI;
				
				// SMALL ETA
				
				tblSmH[0] = UC.ETA;
				
				tblSmH[1] = UC.ETA_PSILI;
				
				tblSmH[2] = UC.ETA_DASIA;
				
				tblSmH[3] = UC.CTRL_NULL;
				
				tblSmH[4] = UC.ETA_OXIA;
				
				tblSmH[5] = UC.ETA_PSILI_OXIA;
				
				tblSmH[6] = UC.ETA_DASIA_OXIA;
				
				tblSmH[7] = UC.CTRL_NULL;
				
				tblSmH[8] = UC.ETA_VARIA;
				
				tblSmH[9] = UC.ETA_PSILI_VARIA;
				
				tblSmH[10] = UC.ETA_DASIA_VARIA;
				
				tblSmH[11] = UC.CTRL_NULL;
				
				tblSmH[12] = UC.ETA_PERISPOMENI;
				
				tblSmH[13] = UC.ETA_PSILI_PERISPOMENI;
				
				tblSmH[14] = UC.ETA_DASIA_PERISPOMENI;
				
				tblSmH[15] = UC.CTRL_NULL;
				
				tblSmH[16] = UC.ETA_YPOGEGRAMMENI;
				
				tblSmH[17] = UC.ETA_PSILI_YPOGEGRAMMENI;
				
				tblSmH[18] = UC.ETA_DASIA_YPOGEGRAMMENI;
				
				tblSmH[19] = UC.CTRL_NULL;
				
				tblSmH[20] = UC.ETA_OXIA_YPOGEGRAMMENI;
				
				tblSmH[21] = UC.ETA_PSILI_OXIA_YPOGEGRAMMENI;
				
				tblSmH[22] = UC.ETA_DASIA_OXIA_YPOGEGRAMMENI;
				
				tblSmH[23] = UC.CTRL_NULL;
				
				tblSmH[24] = UC.ETA_VARIA_YPOGEGRAMMENI;
				
				tblSmH[25] = UC.ETA_PSILI_VARIA_YPOGEGRAMMENI;
				
				tblSmH[26] = UC.ETA_DASIA_VARIA_YPOGEGRAMMENI;
				
				tblSmH[27] = UC.CTRL_NULL;
				
				tblSmH[28] = UC.ETA_PERISPOMENI_YPOGEGRAMMENI;
				
				tblSmH[29] = UC.ETA_PSILI_PERISPOMENI_YPOGEGRAMMENI;
				
				tblSmH[30] = UC.ETA_DASIA_PERISPOMENI_YPOGEGRAMMENI;
				
				// CAPITAL ETA
				
				tblCpH[0] = UC.CAPITAL_ETA;
				
				tblCpH[1] = UC.CAPITAL_ETA_PSILI;
				tblCpH[2] = UC.CAPITAL_ETA_DASIA;
				
				tblCpH[3] = UC.CTRL_NULL;
				
				tblCpH[4] = UC.CAPITAL_ETA_OXIA;
				
				tblCpH[5] = UC.CAPITAL_ETA_PSILI_OXIA;
				
				tblCpH[6] = UC.CAPITAL_ETA_DASIA_OXIA;
				
				tblCpH[7] = UC.CTRL_NULL;
				
				tblCpH[8] = UC.CAPITAL_ETA_VARIA;
				
				tblCpH[9] = UC.CAPITAL_ETA_PSILI_VARIA;
				
				tblCpH[10] = UC.CAPITAL_ETA_DASIA_VARIA;
				
				tblCpH[11] = UC.CTRL_NULL;
				
				tblCpH[12] = UC.CTRL_NULL; // CAPITAL_ETA_PERISPOMENI
				
				tblCpH[13] = UC.CAPITAL_ETA_PSILI_PERISPOMENI;
				
				tblCpH[14] = UC.CAPITAL_ETA_DASIA_PERISPOMENI;
				
				tblCpH[15] = UC.CTRL_NULL;
				
				tblCpH[16] = UC.CAPITAL_ETA_PROSGEGRAMMENI;
				
				tblCpH[17] = UC.CAPITAL_ETA_PSILI_PROSGEGRAMMENI;
				
				tblCpH[18] = UC.CAPITAL_ETA_DASIA_PROSGEGRAMMENI;
				
				tblCpH[19] = UC.CTRL_NULL;
				
				tblCpH[20] = UC.CTRL_NULL; // CAPITAL_ETA_OXIA_PROSGEGRAMMENI
				
				tblCpH[21] = UC.CAPITAL_ETA_PSILI_OXIA_PROSGEGRAMMENI;
				
				tblCpH[22] = UC.CAPITAL_ETA_DASIA_OXIA_PROSGEGRAMMENI;
				
				tblCpH[23] = UC.CTRL_NULL;
				
				tblCpH[24] = UC.CTRL_NULL; // CAPITAL_ETA_VARIA_PROSGEGRAMMENI
				
				tblCpH[25] = UC.CAPITAL_ETA_PSILI_VARIA_PROSGEGRAMMENI;
				
				tblCpH[26] = UC.CAPITAL_ETA_DASIA_VARIA_PROSGEGRAMMENI;
				
				tblCpH[27] = UC.CTRL_NULL;
				
				tblCpH[28] = UC.CTRL_NULL; // CAPITAL_ETA_PERISPOMENI_PROSGEGRAMMENI
				
				tblCpH[29] = UC.CAPITAL_ETA_PSILI_PERISPOMENI_PROSGEGRAMMENI;
				
				tblCpH[30] = UC.CAPITAL_ETA_DASIA_PERISPOMENI_PROSGEGRAMMENI;
				
				// SMALL OMEGA
				
				tblSmW[0] = UC.OMEGA;
				
				tblSmW[1] = UC.OMEGA_PSILI;
				
				tblSmW[2] = UC.OMEGA_DASIA;
				
				tblSmW[3] = UC.CTRL_NULL;
				
				tblSmW[4] = UC.OMEGA_OXIA;
				
				tblSmW[5] = UC.OMEGA_PSILI_OXIA;
				
				tblSmW[6] = UC.OMEGA_DASIA_OXIA;
				
				tblSmW[7] = UC.CTRL_NULL;
				
				tblSmW[8] = UC.OMEGA_VARIA;
				
				tblSmW[9] = UC.OMEGA_PSILI_VARIA;
				
				tblSmW[10] = UC.OMEGA_DASIA_VARIA;
				
				tblSmW[11] = UC.CTRL_NULL;
				
				tblSmW[12] = UC.OMEGA_PERISPOMENI;
				
				tblSmW[13] = UC.OMEGA_PSILI_PERISPOMENI;
				
				tblSmW[14] = UC.OMEGA_DASIA_PERISPOMENI;
				
				tblSmW[15] = UC.CTRL_NULL;
				
				tblSmW[16] = UC.OMEGA_YPOGEGRAMMENI;
				tblSmW[17] = UC.OMEGA_PSILI_YPOGEGRAMMENI;
				
				tblSmW[18] = UC.OMEGA_DASIA_YPOGEGRAMMENI;
				
				tblSmW[19] = UC.CTRL_NULL;
				
				tblSmW[20] = UC.OMEGA_OXIA_YPOGEGRAMMENI;
				
				tblSmW[21] = UC.OMEGA_PSILI_OXIA_YPOGEGRAMMENI;
				
				tblSmW[22] = UC.OMEGA_DASIA_OXIA_YPOGEGRAMMENI;
				
				tblSmW[23] = UC.CTRL_NULL;
				
				tblSmW[24] = UC.OMEGA_VARIA_YPOGEGRAMMENI;
				
				tblSmW[25] = UC.OMEGA_PSILI_VARIA_YPOGEGRAMMENI;
				
				tblSmW[26] = UC.OMEGA_DASIA_VARIA_YPOGEGRAMMENI;
				
				tblSmW[27] = UC.CTRL_NULL;
				
				tblSmW[28] = UC.OMEGA_PERISPOMENI_YPOGEGRAMMENI;
				
				tblSmW[29] = UC.OMEGA_PSILI_PERISPOMENI_YPOGEGRAMMENI;
				
				tblSmW[30] = UC.OMEGA_DASIA_PERISPOMENI_YPOGEGRAMMENI;
				
				// CAPITAL OMEGA
				
				tblCpW[0] = UC.CAPITAL_OMEGA;
				
				tblCpW[1] = UC.CAPITAL_OMEGA_PSILI;
				
				tblCpW[2] = UC.CAPITAL_OMEGA_DASIA;
				
				tblCpW[3] = UC.CTRL_NULL;
				
				tblCpW[4] = UC.CAPITAL_OMEGA_OXIA;
				
				tblCpW[5] = UC.CAPITAL_OMEGA_PSILI_OXIA;
				
				tblCpW[6] = UC.CAPITAL_OMEGA_DASIA_OXIA;
				
				tblCpW[7] = UC.CTRL_NULL;
				
				tblCpW[8] = UC.CAPITAL_OMEGA_VARIA;
				
				tblCpW[9] = UC.CAPITAL_OMEGA_PSILI_VARIA;
				
				tblCpW[10] = UC.CAPITAL_OMEGA_DASIA_VARIA;
				
				tblCpW[11] = UC.CTRL_NULL;
				
				tblCpW[12] = UC.CTRL_NULL; // CAPITAL_OMEGA_PERISPOMENI
				
				tblCpW[13] = UC.CAPITAL_OMEGA_PSILI_PERISPOMENI;
				
				tblCpW[14] = UC.CAPITAL_OMEGA_DASIA_PERISPOMENI;
				
				tblCpW[15] = UC.CTRL_NULL;
				
				tblCpW[16] = UC.CAPITAL_OMEGA_PROSGEGRAMMENI;
				
				tblCpW[17] = UC.CAPITAL_OMEGA_PSILI_PROSGEGRAMMENI;
				
				tblCpW[18] = UC.CAPITAL_OMEGA_DASIA_PROSGEGRAMMENI;
				
				tblCpW[19] = UC.CTRL_NULL;
				
				tblCpW[20] = UC.CTRL_NULL; // CAPITAL_OMEGA_OXIA_PROSGEGRAMMENI
				
				tblCpW[21] = UC.CAPITAL_OMEGA_PSILI_OXIA_PROSGEGRAMMENI;
				
				tblCpW[22] = UC.CAPITAL_OMEGA_DASIA_OXIA_PROSGEGRAMMENI;
				
				tblCpW[23] = UC.CTRL_NULL;
				
				tblCpW[24] = UC.CTRL_NULL; // CAPITAL_OMEGA_VARIA_PROSGEGRAMMENI
				
				tblCpW[25] = UC.CAPITAL_OMEGA_PSILI_VARIA_PROSGEGRAMMENI;
				
				tblCpW[26] = UC.CAPITAL_OMEGA_DASIA_VARIA_PROSGEGRAMMENI;
				
				tblCpW[27] = UC.CTRL_NULL;
				
				tblCpW[28] = UC.CTRL_NULL; // CAPITAL_OMEGA_PERISPOMENI_PROSGEGRAMMENI
				
				tblCpW[29] = UC.CAPITAL_OMEGA_PSILI_PERISPOMENI_PROSGEGRAMMENI;
				
				tblCpW[30] = UC.CAPITAL_OMEGA_DASIA_PERISPOMENI_PROSGEGRAMMENI;
				
				// SMALL OMICRON
				tblSmO[0] = UC.OMICRON;
				
				tblSmO[1] = UC.OMICRON_PSILI;
				
				tblSmO[2] = UC.OMICRON_DASIA;
				
				tblSmO[3] = UC.CTRL_NULL;
				
				tblSmO[4] = UC.OMICRON_OXIA;
				
				tblSmO[5] = UC.OMICRON_PSILI_OXIA;
				
				tblSmO[6] = UC.OMICRON_DASIA_OXIA;
				
				tblSmO[7] = UC.CTRL_NULL;
				
				tblSmO[8] = UC.OMICRON_VARIA;
				
				tblSmO[9] = UC.OMICRON_PSILI_VARIA;
				
				tblSmO[10] = UC.OMICRON_DASIA_VARIA;
				
				// CAPITAL OMICRON
				
				tblCpO[0] = UC.CAPITAL_OMICRON;
				
				tblCpO[1] = UC.CAPITAL_OMICRON_PSILI;
				
				tblCpO[2] = UC.CAPITAL_OMICRON_DASIA;
				
				tblCpO[3] = UC.CTRL_NULL;
				
				tblCpO[4] = UC.CAPITAL_OMICRON_OXIA;
				
				tblCpO[5] = UC.CAPITAL_OMICRON_PSILI_OXIA;
				
				tblCpO[6] = UC.CAPITAL_OMICRON_DASIA_OXIA;
				
				tblCpO[7] = UC.CTRL_NULL;
				
				tblCpO[8] = UC.CAPITAL_OMICRON_VARIA;
				
				tblCpO[9] = UC.CAPITAL_OMICRON_PSILI_VARIA;
				
				tblCpO[10] = UC.CAPITAL_OMICRON_DASIA_VARIA;
				
				// SMALL EPSILON
				
				tblSmE[0] = UC.EPSILON;
				
				tblSmE[1] = UC.EPSILON_PSILI;
				
				tblSmE[2] = UC.EPSILON_DASIA;
				
				tblSmE[3] = UC.CTRL_NULL;
				
				tblSmE[4] = UC.EPSILON_OXIA;
				
				tblSmE[5] = UC.EPSILON_PSILI_OXIA;
				
				tblSmE[6] = UC.EPSILON_DASIA_OXIA;
				
				tblSmE[7] = UC.CTRL_NULL;
				
				tblSmE[8] = UC.EPSILON_VARIA;
				
				tblSmE[9] = UC.EPSILON_PSILI_VARIA;
				
				tblSmE[10] = UC.EPSILON_DASIA_VARIA;
				
				// CAPITAL EPSILON
				
				tblCpE[0] = UC.CAPITAL_EPSILON;
				
				tblCpE[1] = UC.CAPITAL_EPSILON_PSILI;
				
				tblCpE[2] = UC.CAPITAL_EPSILON_DASIA;
				
				tblCpE[3] = UC.CTRL_NULL;
				
				tblCpE[4] = UC.CAPITAL_EPSILON_OXIA;
				
				tblCpE[5] = UC.CAPITAL_EPSILON_PSILI_OXIA;
				
				tblCpE[6] = UC.CAPITAL_EPSILON_DASIA_OXIA;
				
				tblCpE[7] = UC.CTRL_NULL;
				
				tblCpE[8] = UC.CAPITAL_EPSILON_VARIA;
				
				tblCpE[9] = UC.CAPITAL_EPSILON_PSILI_VARIA;
				
				tblCpE[10] = UC.CAPITAL_EPSILON_DASIA_VARIA;
				// SMILL IOTA
				
				tblSmI[0] = UC.IOTA;
				
				tblSmI[1] = UC.IOTA_PSILI;
				
				tblSmI[2] = UC.IOTA_DASIA;
				
				tblSmI[3] = UC.CTRL_NULL;
				
				tblSmI[4] = UC.IOTA_OXIA;
				
				tblSmI[5] = UC.IOTA_PSILI_OXIA;
				
				tblSmI[6] = UC.IOTA_DASIA_OXIA;
				
				tblSmI[7] = UC.CTRL_NULL;
				
				tblSmI[8] = UC.IOTA_VARIA;
				
				tblSmI[9] = UC.IOTA_PSILI_VARIA;
				
				tblSmI[10] = UC.IOTA_DASIA_VARIA;
				
				tblSmI[11] = UC.CTRL_NULL;
				
				tblSmI[12] = UC.IOTA_PERISPOMENI;
				
				tblSmI[13] = UC.IOTA_PSILI_PERISPOMENI;
				
				tblSmI[14] = UC.IOTA_DASIA_PERISPOMENI;
				
				tblSmI[15] = UC.CTRL_NULL;
				
				tblSmI[16] = UC.IOTA_DIALYTIKA;
				
				tblSmI[17] = UC.CTRL_NULL;
				
				tblSmI[18] = UC.CTRL_NULL;
				
				tblSmI[19] = UC.CTRL_NULL;
				
				tblSmI[20] = UC.IOTA_DIALYTIKA_OXIA;
				
				tblSmI[21] = UC.CTRL_NULL;
				
				tblSmI[22] = UC.CTRL_NULL;
				
				tblSmI[23] = UC.CTRL_NULL;
				
				tblSmI[24] = UC.IOTA_DIALYTIKA_VARIA;
				
				tblSmI[25] = UC.CTRL_NULL;
				
				tblSmI[26] = UC.CTRL_NULL;
				
				tblSmI[27] = UC.CTRL_NULL;
				
				tblSmI[28] = UC.IOTA_DIALYTIKA_PERISPOMENI;
				
				// CAPITAL IOTA
				
				tblCpI[0] = UC.CAPITAL_IOTA;
				
				tblCpI[1] = UC.CAPITAL_IOTA_PSILI;
				
				tblCpI[2] = UC.CAPITAL_IOTA_DASIA;
				
				tblCpI[3] = UC.CTRL_NULL;
				
				tblCpI[4] = UC.CAPITAL_IOTA_OXIA;
				
				tblCpI[5] = UC.CAPITAL_IOTA_PSILI_OXIA;
				
				tblCpI[6] = UC.CAPITAL_IOTA_DASIA_OXIA;
				
				tblCpI[7] = UC.CTRL_NULL;
				
				tblCpI[8] = UC.CAPITAL_IOTA_VARIA;
				
				tblCpI[9] = UC.CAPITAL_IOTA_PSILI_VARIA;
				
				tblCpI[10] = UC.CAPITAL_IOTA_DASIA_VARIA;
				
				tblCpI[11] = UC.CTRL_NULL;
				
				tblCpI[12] = UC.CTRL_NULL; // CAPITAL_IOTA_PERISPOMENI
				
				tblCpI[13] = UC.CAPITAL_IOTA_PSILI_PERISPOMENI;
				
				tblCpI[14] = UC.CAPITAL_IOTA_DASIA_PERISPOMENI;
				
				tblCpI[15] = UC.CTRL_NULL;
				tblCpI[16] = UC.CAPITAL_IOTA_DIALYTIKA;
				
				// SMALL UPSILON
				
				tblSmU[0] = UC.UPSILON;
				
				tblSmU[1] = UC.UPSILON_PSILI;
				
				tblSmU[2] = UC.UPSILON_DASIA;
				
				tblSmU[3] = UC.CTRL_NULL;
				
				tblSmU[4] = UC.UPSILON_OXIA;
				
				tblSmU[5] = UC.UPSILON_PSILI_OXIA;
				
				tblSmU[6] = UC.UPSILON_DASIA_OXIA;
				
				tblSmU[7] = UC.CTRL_NULL;
				
				tblSmU[8] = UC.UPSILON_VARIA;
				
				tblSmU[9] = UC.UPSILON_PSILI_VARIA;
				
				tblSmU[10] = UC.UPSILON_DASIA_VARIA;
				
				tblSmU[11] = UC.CTRL_NULL;
				
				tblSmU[12] = UC.UPSILON_PERISPOMENI;
				
				tblSmU[13] = UC.UPSILON_PSILI_PERISPOMENI;
				
				tblSmU[14] = UC.UPSILON_DASIA_PERISPOMENI;
				
				tblSmU[15] = UC.CTRL_NULL;
				
				tblSmU[16] = UC.UPSILON_DIALYTIKA;
				
				tblSmU[17] = UC.CTRL_NULL;
				
				tblSmU[18] = UC.CTRL_NULL;
				
				tblSmU[19] = UC.CTRL_NULL;
				
				tblSmU[20] = UC.UPSILON_DIALYTIKA_OXIA;
				
				tblSmU[21] = UC.CTRL_NULL;
				
				tblSmU[22] = UC.CTRL_NULL;
				
				tblSmU[23] = UC.CTRL_NULL;
				
				tblSmU[24] = UC.UPSILON_DIALYTIKA_VARIA;
				
				tblSmU[25] = UC.CTRL_NULL;
				
				tblSmU[26] = UC.CTRL_NULL;
				
				tblSmU[27] = UC.CTRL_NULL;
				
				tblSmU[28] = UC.UPSILON_DIALYTIKA_PERISPOMENI;
				
				// CAPITAL UPSILON
				
				tblCpU[0] = UC.CAPITAL_UPSILON;
				
				tblCpU[1] = UC.CTRL_NULL; // CAPITAL_UPSILON_PSILI* do not exist - strange.
				
				tblCpU[2] = UC.CAPITAL_UPSILON_DASIA;
				
				tblCpU[3] = UC.CTRL_NULL;
				
				tblCpU[4] = UC.CAPITAL_UPSILON_OXIA;
				
				tblCpU[5] = UC.CTRL_NULL; // CAPITAL_UPSILON_PSILI_OXIA
				
				tblCpU[6] = UC.CAPITAL_UPSILON_DASIA_OXIA;
				
				tblCpU[7] = UC.CTRL_NULL;
				
				tblCpU[8] = UC.CAPITAL_UPSILON_VARIA;
				
				tblCpU[9] = UC.CTRL_NULL; // CAPITAL_UPSILON_PSILI_VARIA
				
				tblCpU[10] = UC.CAPITAL_UPSILON_DASIA_VARIA;
				
				tblCpU[11] = UC.CTRL_NULL;
				
				tblCpU[12] = UC.CTRL_NULL; // CAPITAL_UPSILON_PERISPOMENI
				
				tblCpU[13] = UC.CTRL_NULL; // CAPITAL_UPSILON_PSILI_PERISPOMENI
				
				tblCpU[14] = UC.CAPITAL_UPSILON_DASIA_PERISPOMENI;
				tblCpU[15] = UC.CTRL_NULL;
				
				tblCpU[16] = UC.CAPITAL_UPSILON_DIALYTIKA;
				
				// SMALL RHO
				
				tblSmR[0] = UC.RHO;
				
				tblSmR[1] = UC.RHO_PSILI;
				
				tblSmR[2] = UC.RHO_DASIA;
				
				// CAPITAL RHO
				
				tblCpR[0] = UC.CAPITAL_RHO;
				
				tblCpR[1] = UC.CTRL_NULL;
				
				tblCpR[2] = UC.CAPITAL_RHO_DASIA;
				
				// SPACE
				
				tblSpace[0] = UC.SPACE;
				
				tblSpace[1] = UC.PSILI;
				
				tblSpace[2] = UC.DASIA;
				
				tblSpace[3] = UC.CTRL_NULL;
				
				tblSpace[4] = UC.OXIA;
				
				tblSpace[5] = UC.PSILI_OXIA;
				
				tblSpace[6] = UC.DASIA_OXIA;
				
				tblSpace[7] = UC.CTRL_NULL;
				
				tblSpace[8] = UC.VARIA;
				
				tblSpace[9] = UC.PSILI_VARIA;
				
				tblSpace[10] = UC.DASIA_VARIA;
				
				tblSpace[11] = UC.CTRL_NULL;
				
				tblSpace[12] = UC.PERISPOMENI;
				
				tblSpace[13] = UC.PSILI_PERISPOMENI;
				
				tblSpace[14] = UC.DASIA_PERISPOMENI;
				
				tblSpace[15] = UC.CTRL_NULL;
				
				tblSpace[16] = UC.YPOGEGRAMMENI; // Also DIARESIS would be possible (_+), but that is not Greek!
				
				tblSpace[17] = UC.CTRL_NULL;
				
				tblSpace[18] = UC.CTRL_NULL;
				
				tblSpace[19] = UC.CTRL_NULL;
				
				tblSpace[20] = UC.DIALYTIKA_OXIA;
				
				tblSpace[21] = UC.CTRL_NULL;
				
				tblSpace[22] = UC.CTRL_NULL;
				
				tblSpace[23] = UC.CTRL_NULL;
				
				tblSpace[24] = UC.DIALYTIKA_VARIA;
				
				tblSpace[25] = UC.CTRL_NULL;
				
				tblSpace[26] = UC.CTRL_NULL;
				
				tblSpace[27] = UC.CTRL_NULL;
				
				tblSpace[28] = UC.DIALYTIKA_PERISPOMENI;
				
				// diacritics:
				
				for (i = 0; i < 70; i++)
				{
					
					tblDiacrit[i] = 0;
				}
				
				tblDiacrit[0] = 8; // grave accent
				
				tblDiacrit[1] = 4; // acute accent
				tblDiacrit[2] = 12; // circumflex accent, lets assume perispomeni is meant
				
				tblDiacrit[3] = 12; // tilde, lets assume perispomeni is meant
				
				tblDiacrit[8] = 16; // diaeresis/trema/umlaut
				
				tblDiacrit[19] = 1; // spiritus lenis (smooth breathing)
				
				tblDiacrit[20] = 2; // spiritus asper (rough breathing)
				
				tblDiacrit[66] = 12; // perispomeni
				
				tblDiacrit[67] = 1; // koronis, handled like spiritus lenis
				
				tblDiacrit[68] = 20; // dialytika tonos
				
				tblDiacrit[69] = 16; // iota subscript/adscript
				
				//
				
				tblLookup[3] = tblDiacritGreek;
				
				tblDiacritGreek[145] = tblCpA;
				
				tblDiacritGreek[149] = tblCpE;
				
				tblDiacritGreek[151] = tblCpH;
				
				tblDiacritGreek[153] = tblCpI;
				
				tblDiacritGreek[159] = tblCpO;
				
				tblDiacritGreek[161] = tblCpR;
				
				tblDiacritGreek[165] = tblCpU;
				
				tblDiacritGreek[169] = tblCpW;
				
				tblDiacritGreek[177] = tblSmA;
				
				tblDiacritGreek[181] = tblSmE;
				
				tblDiacritGreek[183] = tblSmH;
				
				tblDiacritGreek[185] = tblSmI;
				
				tblDiacritGreek[191] = tblSmO;
				
				tblDiacritGreek[193] = tblSmR;
				
				tblDiacritGreek[197] = tblSmU;
				
				tblDiacritGreek[201] = tblSmW;
			}
		}
	}
}