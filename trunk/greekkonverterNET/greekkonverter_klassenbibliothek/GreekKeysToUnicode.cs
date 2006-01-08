namespace greekconverter
{
	using System;
	
	/// <summary> SMK GreekKeys -> Unicode
	/// *
	/// </summary>
	/// <version>  01-Sep-2002
	/// </version>
	/// <author>   Michael Neuhold
	/// </author>
	
	public class GreekKeysToUnicode
	{
		private System.String VersionDate
		{
			get
			{
				
				return "01-Sep-2002";
			}
			
		}
		private System.String ClassDesc
		{
			get
			{
				
				return "converts GreekKeys into precomposed Unicode";
			}
			
		}
		private const char NOT_ASSIGNED = '?';
		private const char NOT_SUPPORTED = '?';
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLookup " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly char[] tblLookup;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblDiacrit " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly System.String[] tblDiacrit;
		
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "16-Sep-2002"; break;
				
				case 1:  info = "Converts a short array with GreekKeys \"characters\" into Unicode"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Ut sementem feceris, ita metes.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Converts a short array with GreekKeys "characters" into Unicode.
		/// *
		/// </summary>
		/// <param name="gkString">the GreekKeys text array. The end of the text has
		/// to be marked with a null value.
		/// </param>
		/// <returns>  the text converted into Unicode
		/// </returns>
		
		internal static System.String convertString(short[] gkString)
		{
			int strPos = 0;
			System.Text.StringBuilder uniString = new System.Text.StringBuilder();
			System.String diacrit = null;
			
			MessageHandler.clearMsgQueue();
			
			while (gkString[strPos] != 0)
			{
				// if the previous character was a diacritical that usually precedes uppercase characters:
				if (diacrit != null)
				{
					// precompose the current character and the diacritical:
					uniString.Append(UnicodePrecompose.precomposeStringFirstPass(convertChar(gkString[strPos]) + diacrit));
					diacrit = null;
				}
				else
				{
					// if the current character is a diacritical that usually precedes uppercase characters:
					if ((gkString[strPos] > 127) && (gkString[strPos] < 139))
					{
						// memorize the diacritical:
						diacrit = tblDiacrit[gkString[strPos] - 128];
					}
					else
					{
						uniString.Append(convertChar(gkString[strPos]));
					}
				}
				
				strPos++;
			}
			
			
			
			return uniString.ToString();
		}
		
		
		
		/// <summary> Converts a short representing a SMK GreekKeys character into its Unicode counterpart.
		/// </summary>
		
		
		
		private static char convertChar(short gkChar)
		{
			
			return tblLookup[gkChar];
		}
		
		
		
		
		
		
		static GreekKeysToUnicode()
		{
			tblLookup = new char[256];
			tblDiacrit = new System.String[11];
			{
				// diacritics that need special treatment:
				tblDiacrit[0] = "" + UC.COMBINING_ACUTE_ACCENT;
				tblDiacrit[1] = "" + UC.COMBINING_GRAVE_ACCENT;
				tblDiacrit[2] = "" + UC.COMBINING_CIRCUMFLEX_ACCENT;
				tblDiacrit[3] = "" + UC.COMBINING_COMMA_ABOVE;
				tblDiacrit[4] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE;
				tblDiacrit[5] = "" + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblDiacrit[6] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_ACUTE_ACCENT;
				tblDiacrit[7] = "" + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblDiacrit[8] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_GRAVE_ACCENT;
				tblDiacrit[9] = "" + UC.COMBINING_COMMA_ABOVE + UC.COMBINING_CIRCUMFLEX_ACCENT; ;
				tblDiacrit[10] = "" + UC.COMBINING_REVERSED_COMMA_ABOVE + UC.COMBINING_CIRCUMFLEX_ACCENT;
				
				// initialize lookup table
				for (short i = 0; i < 256; i++)
				{
					tblLookup[i] = (char) i;
				}
				//
				// Lookup table
				//
				tblLookup[33] = UC.LUNATE_SIGMA_SYMBOL; // lowercase
				// tblLookup[34]  = '"';
				tblLookup[35] = UC.UPSILON_DIALYTIKA;
				tblLookup[36] = '\u231E'; // bottom left corner, or '
				 left floor?
 
				tblLookup [37] = UC.LUNATE_SIGMA_SYMBOL; // uppercase
				tblLookup[38] = UC.ALPHA_YPOGEGRAMMENI;
				// tblLookup[39]  = '\'';
				// tblLookup[40]  = '(';
				// tblLookup[41]  = ')';
				tblLookup[42] = NOT_ASSIGNED;
				tblLookup[43] = UC.YPOGEGRAMMENI;
				/*
				tblLookup[44]  = ',';
				tblLookup[45]  = '-';
				tblLookup[46]  = '.':
				tblLookup[47]  = '/';
				tblLookup[48]  = '0';
				tblLookup[49]  = '1';
				
				tblLookup[50]  = '2';
				
				tblLookup[51]  = '3';
				
				tblLookup[52]  = '4';
				
				tblLookup[53]  = '5';
				
				tblLookup[54]  = '6';
				
				tblLookup[55]  = '7';
				
				tblLookup[56]  = '8';
				
				tblLookup[57]  = '9';
				
				*/
				
				tblLookup[58] = UC.ANO_TELEIA;
				
				tblLookup[59] = UC.GREEK_QUESTION_MARK;
				
				// tblLookup[60]  = '<';
				
				tblLookup[61] = UC.RHO_DASIA;
				
				//tblLookup[62]  = '>';
				
				tblLookup[63] = NOT_ASSIGNED;
				
				tblLookup[64] = UC.UPSILON_DIALYTIKA_OXIA;
				
				tblLookup[65] = UC.CAPITAL_ALPHA;
				
				tblLookup[66] = UC.CAPITAL_BETA;
				
				tblLookup[67] = UC.CAPITAL_PSI;
				
				tblLookup[68] = UC.CAPITAL_DELTA;
				
				tblLookup[69] = UC.CAPITAL_EPSILON;
				
				tblLookup[70] = UC.CAPITAL_PHI;
				
				tblLookup[71] = UC.CAPITAL_GAMMA;
				
				tblLookup[72] = UC.CAPITAL_ETA;
				
				tblLookup[73] = UC.CAPITAL_IOTA;
				
				tblLookup[74] = UC.CAPITAL_XI;
				
				tblLookup[75] = UC.CAPITAL_KAPPA;
				
				tblLookup[76] = UC.CAPITAL_LAMDA;
				
				tblLookup[77] = UC.CAPITAL_MU;
				
				tblLookup[78] = UC.CAPITAL_NU;
				
				tblLookup[79] = UC.CAPITAL_OMICRON;
				
				tblLookup[80] = UC.CAPITAL_PI;
				
				tblLookup[81] = UC.SAMPI;
				
				tblLookup[82] = UC.CAPITAL_RHO;
				
				tblLookup[83] = UC.CAPITAL_SIGMA;
				
				tblLookup[84] = UC.CAPITAL_TAU;
				
				tblLookup[85] = UC.CAPITAL_UPSILON;
				
				tblLookup[86] = UC.CAPITAL_OMEGA;
				
				tblLookup[87] = UC.DIGAMMA;
				
				tblLookup[88] = UC.CAPITAL_CHI;
				
				tblLookup[89] = UC.CAPITAL_THETA;
				
				tblLookup[90] = UC.CAPITAL_ZETA;
				
				// tblLookup[91]  = '[';
				
				// tblLookup[92]  = '\\';
				
				// tblLookup[93]  = ']';
				
				tblLookup[94] = NOT_ASSIGNED;
				tblLookup[95] = '['; // double square bracket
				
				tblLookup[96] = UC.COMBINING_DOT_BELOW;
				
				tblLookup[97] = UC.ALPHA;
				
				tblLookup[98] = UC.BETA;
				
				tblLookup[99] = UC.PSI;
				
				tblLookup[100] = UC.DELTA;
				
				tblLookup[101] = UC.EPSILON;
				
				tblLookup[102] = UC.PHI;
				
				tblLookup[103] = UC.GAMMA;
				
				tblLookup[104] = UC.ETA;
				
				tblLookup[105] = UC.IOTA;
				
				tblLookup[106] = UC.XI;
				
				tblLookup[107] = UC.KAPPA;
				
				tblLookup[108] = UC.LAMDA;
				
				tblLookup[109] = UC.MU;
				
				tblLookup[110] = UC.NU;
				
				tblLookup[111] = UC.OMICRON;
				
				tblLookup[112] = UC.PI;
				
				tblLookup[113] = UC.KOPPA;
				
				tblLookup[114] = UC.RHO;
				
				tblLookup[115] = UC.SIGMA;
				
				tblLookup[116] = UC.TAU;
				
				tblLookup[117] = UC.UPSILON;
				
				tblLookup[118] = UC.OMEGA;
				
				tblLookup[119] = UC.FINAL_SIGMA;
				
				tblLookup[120] = UC.CHI;
				
				tblLookup[121] = UC.THETA;
				
				tblLookup[122] = UC.ZETA;
				
				// tblLookup[123] = '{';
				
				// tblLookup[124] = '|';
				
				// tblLookup[125] = '}';
				
				tblLookup[126] = UC.DAGGER;
				
				tblLookup[127] = NOT_ASSIGNED;
				
				// tblLookup[128] through tblLookup[138] are converted via tblDiacrit
				
				tblLookup[139] = UC.ALPHA_OXIA;
				
				tblLookup[140] = UC.ALPHA_VARIA;
				
				tblLookup[141] = UC.ALPHA_PERISPOMENI;
				
				tblLookup[142] = UC.ALPHA_PSILI;
				
				tblLookup[143] = UC.ALPHA_DASIA;
				
				tblLookup[144] = UC.ALPHA_PSILI_OXIA;
				
				tblLookup[145] = UC.ALPHA_DASIA_OXIA;
				
				tblLookup[146] = UC.ALPHA_PSILI_VARIA;
				
				tblLookup[147] = UC.ALPHA_DASIA_VARIA;
				
				tblLookup[148] = UC.ALPHA_PSILI_PERISPOMENI;
				
				tblLookup[149] = UC.ALPHA_DASIA_PERISPOMENI;
				
				tblLookup[150] = UC.ALPHA_OXIA_YPOGEGRAMMENI;
				
				tblLookup[151] = UC.ALPHA_VARIA_YPOGEGRAMMENI;
				tblLookup[152] = UC.ALPHA_PERISPOMENI_YPOGEGRAMMENI;
				
				tblLookup[153] = UC.ALPHA_PSILI_YPOGEGRAMMENI;
				
				tblLookup[154] = UC.ALPHA_DASIA_YPOGEGRAMMENI;
				
				tblLookup[155] = UC.ALPHA_PSILI_OXIA_YPOGEGRAMMENI;
				
				tblLookup[156] = UC.ALPHA_DASIA_OXIA_YPOGEGRAMMENI;
				
				tblLookup[157] = UC.ALPHA_PSILI_VARIA_YPOGEGRAMMENI;
				
				tblLookup[158] = UC.ALPHA_DASIA_VARIA_YPOGEGRAMMENI;
				
				tblLookup[159] = UC.ALPHA_PSILI_PERISPOMENI_YPOGEGRAMMENI;
				
				tblLookup[160] = NOT_ASSIGNED;
				
				tblLookup[161] = UC.EPSILON_OXIA;
				
				tblLookup[162] = UC.EPSILON_VARIA;
				
				tblLookup[163] = UC.UPSILON_DIALYTIKA_VARIA;
				
				tblLookup[164] = UC.EPSILON_PSILI;
				
				tblLookup[165] = UC.EPSILON_DASIA;
				
				tblLookup[166] = UC.EPSILON_PSILI_OXIA;
				
				tblLookup[167] = UC.EPSILON_DASIA_OXIA;
				
				tblLookup[168] = UC.EPSILON_PSILI_VARIA;
				
				tblLookup[169] = UC.EPSILON_DASIA_VARIA;
				
				tblLookup[170] = UC.ALPHA_DASIA_PERISPOMENI_YPOGEGRAMMENI;
				
				tblLookup[171] = ']'; // double square bracket
				
				tblLookup[172] = NOT_ASSIGNED;
				
				tblLookup[173] = NOT_SUPPORTED; // spacing vrachy
				
				tblLookup[174] = UC.ETA_OXIA;
				
				tblLookup[175] = UC.ETA_VARIA;
				
				tblLookup[176] = UC.ETA_PERISPOMENI;
				
				tblLookup[177] = UC.ETA_PSILI;
				
				tblLookup[178] = UC.ETA_DASIA;
				
				tblLookup[179] = UC.ETA_PSILI_OXIA;
				
				tblLookup[180] = UC.ETA_DASIA_OXIA;
				
				tblLookup[181] = UC.ETA_PSILI_VARIA;
				
				tblLookup[182] = UC.ETA_DASIA_VARIA;
				
				tblLookup[183] = UC.ETA_PSILI_PERISPOMENI;
				
				tblLookup[184] = UC.ETA_DASIA_PERISPOMENI;
				
				tblLookup[185] = UC.ETA_OXIA_YPOGEGRAMMENI;
				
				tblLookup[186] = UC.ETA_VARIA_YPOGEGRAMMENI;
				
				tblLookup[187] = UC.ETA_PERISPOMENI_YPOGEGRAMMENI;
				
				tblLookup[188] = UC.ETA_PSILI_YPOGEGRAMMENI;
				
				tblLookup[189] = UC.ETA_DASIA_YPOGEGRAMMENI;
				
				tblLookup[190] = UC.ETA_PSILI_OXIA_YPOGEGRAMMENI;
				
				tblLookup[191] = UC.ETA_DASIA_OXIA_YPOGEGRAMMENI;
				
				tblLookup[192] = UC.ETA_PSILI_VARIA_YPOGEGRAMMENI;
				
				tblLookup[193] = UC.ETA_DASIA_VARIA_YPOGEGRAMMENI;
				
				tblLookup[194] = UC.ETA_PSILI_PERISPOMENI_YPOGEGRAMMENI;
				
				tblLookup[195] = UC.ETA_DASIA_PERISPOMENI_YPOGEGRAMMENI;
				
				tblLookup[196] = UC.OMEGA_YPOGEGRAMMENI;
				
				tblLookup[197] = UC.OMEGA_OXIA;
				
				tblLookup[198] = UC.OMEGA_VARIA;
				tblLookup[199] = UC.OMEGA_PERISPOMENI;
				
				tblLookup[200] = UC.OMEGA_PSILI;
				
				tblLookup[201] = UC.OMEGA_DASIA;
				
				tblLookup[202] = UC.OMEGA_PSILI_OXIA;
				
				tblLookup[203] = UC.OMEGA_DASIA_OXIA;
				
				tblLookup[204] = UC.OMEGA_PSILI_VARIA;
				
				tblLookup[205] = UC.OMEGA_DASIA_VARIA;
				
				tblLookup[206] = UC.OMEGA_PSILI_PERISPOMENI;
				
				tblLookup[207] = UC.OMEGA_DASIA_PERISPOMENI;
				
				tblLookup[208] = UC.OMEGA_OXIA_YPOGEGRAMMENI;
				
				tblLookup[209] = UC.OMEGA_VARIA_YPOGEGRAMMENI;
				
				tblLookup[210] = UC.OMEGA_PERISPOMENI_YPOGEGRAMMENI;
				
				tblLookup[211] = UC.OMEGA_PSILI_YPOGEGRAMMENI;
				
				tblLookup[212] = UC.OMEGA_DASIA_YPOGEGRAMMENI;
				
				tblLookup[213] = UC.OMEGA_PSILI_OXIA_YPOGEGRAMMENI;
				
				tblLookup[214] = UC.OMEGA_DASIA_OXIA_YPOGEGRAMMENI;
				
				tblLookup[215] = UC.OMEGA_PSILI_VARIA_YPOGEGRAMMENI;
				
				tblLookup[216] = UC.OMEGA_DASIA_VARIA_YPOGEGRAMMENI;
				
				tblLookup[217] = UC.OMEGA_PSILI_PERISPOMENI_YPOGEGRAMMENI;
				
				tblLookup[218] = UC.OMEGA_DASIA_PERISPOMENI_YPOGEGRAMMENI;
				
				tblLookup[219] = UC.IOTA_OXIA;
				
				tblLookup[220] = UC.IOTA_VARIA;
				
				tblLookup[221] = UC.IOTA_PERISPOMENI;
				
				tblLookup[222] = UC.IOTA_PSILI;
				
				tblLookup[223] = UC.IOTA_DASIA;
				
				tblLookup[224] = UC.IOTA_PSILI_OXIA;
				
				tblLookup[225] = UC.IOTA_DASIA_OXIA;
				
				tblLookup[226] = UC.IOTA_PSILI_VARIA;
				
				tblLookup[227] = UC.IOTA_DASIA_VARIA;
				
				tblLookup[228] = UC.IOTA_PSILI_PERISPOMENI;
				
				tblLookup[229] = UC.IOTA_DASIA_PERISPOMENI;
				
				tblLookup[230] = UC.UPSILON_OXIA;
				
				tblLookup[231] = UC.UPSILON_VARIA;
				
				tblLookup[232] = UC.UPSILON_PERISPOMENI;
				
				tblLookup[233] = UC.UPSILON_PSILI;
				
				tblLookup[234] = UC.UPSILON_DASIA;
				
				tblLookup[235] = UC.UPSILON_PSILI_OXIA;
				
				tblLookup[236] = UC.UPSILON_DASIA_OXIA;
				
				tblLookup[237] = UC.UPSILON_PSILI_VARIA;
				
				tblLookup[238] = UC.UPSILON_DASIA_VARIA;
				
				tblLookup[239] = UC.UPSILON_PSILI_PERISPOMENI;
				
				tblLookup[240] = UC.UPSILON_DASIA_PERISPOMENI;
				
				tblLookup[241] = UC.OMICRON_OXIA;
				
				tblLookup[242] = UC.OMICRON_VARIA;
				
				tblLookup[243] = UC.IOTA_DIALYTIKA;
				
				tblLookup[244] = UC.OMICRON_PSILI;
				
				tblLookup[245] = UC.OMICRON_DASIA;
				tblLookup[246] = UC.OMICRON_PSILI_OXIA;
				
				tblLookup[247] = UC.OMICRON_DASIA_OXIA;
				
				tblLookup[248] = UC.OMICRON_PSILI_VARIA;
				
				tblLookup[249] = UC.OMICRON_DASIA_VARIA;
				
				tblLookup[250] = UC.ETA_YPOGEGRAMMENI;
				
				tblLookup[251] = UC.STIGMA;
				
				tblLookup[252] = '\u231F'; // bottom right corner, or '' right floor, or '
				 right corner bracket?
 
				
				tblLookup [253] = UC.IOTA_DIALYTIKA_OXIA;
				
				tblLookup[254] = UC.IOTA_DIALYTIKA_VARIA;
				
				tblLookup[255] = NOT_ASSIGNED;
			}
		}
	}
}