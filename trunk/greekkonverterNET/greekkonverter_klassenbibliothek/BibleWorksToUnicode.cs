namespace greekconverter
{
	using System;
	
	/// <summary>************************
	/// </summary>
	/*  BibleWorks -> Unicode   */
	/// <summary>************************
	/// </summary>
	
	public class BibleWorksToUnicode
	{
		private const System.String NOT_SUPPORTED = "?";
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLookup " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblLookup;
		
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "30-May-2002"; break;
				
				case 1:  info = "Converts text with BibleWorks' coding into decomposed Unicode."; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Principiis obsta, sero medicina paratur.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Converts text with BibleWorks' coding into decomposed Unicode.
		/// *
		/// *
		/// </summary>
		/// <param name="bwString">the string in BibleWorks' Greek coding
		/// </param>
		/// <returns> the string converted into Beta coding
		/// </returns>
		internal static System.String convertString(System.String bwString)
		{
			int strLen = bwString.Length, strPos;
			System.Text.StringBuilder uniString = new System.Text.StringBuilder(strLen * 2);
			char currChar, prevChar = ' ';
			
			MessageHandler.clearMsgQueue();
			
			for (strPos = 0; strPos < strLen; strPos++)
			{
				currChar = bwString[strPos];
				uniString.Append(convertChar(prevChar, currChar));
				prevChar = currChar;
				MessageHandler.enqueueMsg(" at pos. " + (strPos + 1).ToString() + "\n");
			}
			return uniString.ToString();
		}
		
		private static System.String convertChar(char prevBwChar, char bwChar)
		{
			System.String prevUniChar = tblLookup[prevBwChar], uniChar = tblLookup[bwChar], retChar = null;
			
			// if the previous character was a spacing diacritic, usually placed before
			// uppercase vowels, then we must switch characters, i.e. first output the
			// current character, then the diacritic:
			if (prevUniChar[0] == '§')
			{
				retChar = uniChar + prevUniChar.Substring(1); // switch characters
			}
			// if the previous character is not a spacing diacritic ...
			else
			{
				// ... but the current character is one, usually do nothing and wait for the
				// next invokation. there is one exception: V
				if (uniChar[0] == '§')
				{
					// V can be used as smooth breathing before uppercase vowel or as apostrophe:
					if (bwChar == 'V')
					{
						// if V is used as apostrophe then return apostrophe:
						if (prevBwChar != ' ')
						// maybe we should not rely that much on correct typesetting...
						{
							retChar = "" + UC.APOSTROPHE;
						}
						// if V is used as smooth breathing before uppercase vowel, then do nothing:
						else
						{
							retChar = ""; // empty string, wait for next invokation
						}
					}
					// no V, definitely a spacing diacritic, do nothing:
					else
					{
						retChar = ""; // empty string, wait for next invokation
					}
				}
				// if the current character is not a spacing diacritic (and the previous one
				// wasn't one either) simply return its decomposed Unicode rendering:
				else
				{
					retChar = uniChar;
				}
			}
			return retChar;
		}
		static BibleWorksToUnicode()
		{
			tblLookup = new System.String[256];
			/*
			* BibleWorks uses flying accents that are placed with heavy kerning. The sense
			* behind acute = ",", comma = "(", grave = ".", period = "Å" etc. I will never
			* understand. But in principle the coding is similar to Beta coding. Diacritics
			* that belong to uppercase characters are placed before the character. That is
			* the difficulty. Example:
			* "th/|" (betacode "th=|" ) can be easily converted into Unicode, but
			* ":A" (betacode "*)/A" ) needs a change in the order of characters
			* "V" can be a smooth breathing before uppercase character ("VA") or an apostrophe
			* at the end of a word ("katV")*/
			
			{
				int i;
				for (i = 0; i < 256; i++)
				{
					tblLookup[i] = NOT_SUPPORTED;
				}
				
				tblLookup[9] = "" + UC.HORIZONTAL_TABULATION;
				tblLookup[10] = "" + UC.LINE_FEED;
				tblLookup[11] = "" + UC.VERTICAL_TABULATION;
				tblLookup[12] = "" + UC.FORM_FEED;
				tblLookup[13] = "" + UC.CARRIAGE_RETURN;
				tblLookup[32] = " ";
				tblLookup[33] = "+";
				tblLookup[34] = "§" + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblLookup[35] = "]";
				tblLookup[36] = "(";
				tblLookup[37] = ")";
				tblLookup[38] = "-";
				tblLookup[39] = "" + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblLookup[40] = ",";
				tblLookup[41] = ".";
				tblLookup[42] = "" + UC.GREEK_QUESTION_MARK;
				tblLookup[43] = "§" + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblLookup[44] = "" + UC.COMBINING_ACUTE_ACCENT;
				tblLookup[45] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblLookup[46] = "" + UC.COMBINING_GRAVE_ACCENT;
				tblLookup[47] = "" + UC.COMBINING_PERISPOMENI;
				tblLookup[48] = "0";
				tblLookup[49] = "1";
				tblLookup[50] = "2";
				tblLookup[51] = "3";
				tblLookup[52] = "4";
				tblLookup[53] = "5";
				tblLookup[54] = "6";
				tblLookup[55] = "7";
				tblLookup[56] = "8";
				tblLookup[57] = "9";
				tblLookup[58] = "§" + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblLookup[59] = "" + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblLookup[60] = "" + UC.COMBINING_DIAERESIS + UC.COMBINING_ACUTE_ACCENT;
				tblLookup[61] = "" + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblLookup[62] = "" + UC.COMBINING_DIAERESIS + UC.COMBINING_GRAVE_ACCENT; ;
				tblLookup[63] = "" + UC.COMBINING_DIAERESIS;
				tblLookup[64] = "[";
				tblLookup[65] = "" + UC.CAPITAL_ALPHA;
				tblLookup[66] = "" + UC.CAPITAL_BETA;
				tblLookup[67] = "" + UC.CAPITAL_CHI;
				tblLookup[68] = "" + UC.CAPITAL_DELTA;
				tblLookup[69] = "" + UC.CAPITAL_EPSILON;
				tblLookup[70] = "" + UC.CAPITAL_PHI;
				tblLookup[71] = "" + UC.CAPITAL_GAMMA;
				tblLookup[72] = "" + UC.CAPITAL_ETA;
				tblLookup[73] = "" + UC.CAPITAL_IOTA;
				tblLookup[75] = "" + UC.CAPITAL_KAPPA;
				tblLookup[76] = "" + UC.CAPITAL_LAMDA;
				tblLookup[77] = "" + UC.CAPITAL_MU;
				tblLookup[78] = "" + UC.CAPITAL_NU;
				tblLookup[79] = "" + UC.CAPITAL_OMICRON;
				tblLookup[80] = "" + UC.CAPITAL_PI;
				tblLookup[81] = "" + UC.CAPITAL_THETA;
				tblLookup[82] = "" + UC.CAPITAL_RHO;
				tblLookup[83] = "" + UC.CAPITAL_SIGMA;
				tblLookup[84] = "" + UC.CAPITAL_TAU;
				tblLookup[85] = "" + UC.CAPITAL_UPSILON;
				tblLookup[86] = "§" + UC.COMBINING_COMMA_ABOVE; // or apostrophe
				tblLookup[87] = "" + UC.CAPITAL_OMEGA;
				tblLookup[88] = "" + UC.CAPITAL_XI;
				tblLookup[89] = "" + UC.CAPITAL_PSI;
				tblLookup[90] = "" + UC.CAPITAL_ZETA;
				tblLookup[91] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblLookup[92] = "" + UC.ANO_TELEIA;
				tblLookup[93] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblLookup[94] = "*";
				tblLookup[95] = "§" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_PERISPOMENI;
				tblLookup[96] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblLookup[97] = "" + UC.ALPHA;
				tblLookup[98] = "" + UC.BETA;
				tblLookup[99] = "" + UC.CHI;
				tblLookup[100] = "" + UC.DELTA;
				tblLookup[101] = "" + UC.EPSILON;
				tblLookup[102] = "" + UC.PHI;
				tblLookup[103] = "" + UC.GAMMA;
				tblLookup[104] = "" + UC.ETA;
				tblLookup[105] = "" + UC.IOTA;
				tblLookup[106] = "" + UC.FINAL_SIGMA;
				tblLookup[107] = "" + UC.KAPPA;
				tblLookup[108] = "" + UC.LAMDA;
				tblLookup[109] = "" + UC.MU;
				tblLookup[110] = "" + UC.NU;
				tblLookup[111] = "" + UC.OMICRON;
				tblLookup[112] = "" + UC.PI;
				tblLookup[113] = "" + UC.THETA;
				tblLookup[114] = "" + UC.RHO;
				tblLookup[115] = "" + UC.SIGMA;
				tblLookup[116] = "" + UC.TAU;
				tblLookup[117] = "" + UC.UPSILON;
				tblLookup[118] = "" + UC.COMBINING_COMMA_ABOVE;
				tblLookup[119] = "" + UC.OMEGA;
				tblLookup[120] = "" + UC.XI;
				tblLookup[121] = "" + UC.PSI;
				tblLookup[122] = "" + UC.ZETA;
				tblLookup[123] = "§" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblLookup[124] = "" + UC.COMBINING_YPOGEGRAMMENI;
				tblLookup[125] = "§" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblLookup[126] = "§" + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblLookup[160] = "" + UC.NO_BREAK_SPACE;
				tblLookup[182] = "" + UC.PILCROW_SIGN;
				tblLookup[183] = "" + UC.MIDDLE_DOT;
				tblLookup[184] = "!";
				tblLookup[185] = "\"";
				tblLookup[186] = "#";
				tblLookup[187] = "$";
				tblLookup[188] = "%";
				tblLookup[189] = "&";
				tblLookup[190] = "'";
				tblLookup[191] = "(";
				tblLookup[192] = ")";
				tblLookup[193] = "*";
				tblLookup[194] = "+";
				tblLookup[195] = ",";
				tblLookup[196] = "-";
				tblLookup[197] = ".";
				tblLookup[198] = "/";
				tblLookup[199] = ":";
				tblLookup[200] = ";";
				tblLookup[201] = "<";
				tblLookup[202] = "=";
				tblLookup[203] = ">";
				tblLookup[204] = "?";
				tblLookup[205] = "@";
				tblLookup[206] = "[";
				tblLookup[207] = "\\";
				tblLookup[208] = "]";
				tblLookup[209] = "^";
				tblLookup[210] = "_";
				tblLookup[211] = "`";
				tblLookup[212] = "{";
				tblLookup[213] = "|";
				tblLookup[214] = "}";
				tblLookup[215] = "~";
				tblLookup[218] = "" + UC.COMBINING_DOT_BELOW;
			}
		}
	}
}