namespace greekconverter
{
	using System;
	
	/// <summary>************************
	/// </summary>
	/* Unicode -> ASCII         */
	/// <summary>************************
	/// </summary>
	
	public class UnicodeToAscii
	{
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "23-Mar-2002"; break;
				
				case 1:  info = "Converts Greek Unicode into ASCII"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = ".";
					break;
				
			}
			return info;
		}
		
		/// <summary> Converts a String containing Unicode characters into ASCII.
		/// *
		/// Conversion is done according to following rules:
		/// <ul>
		/// <li>Rough breathing -> h, therefore Rho at the beginning of a word -> rh, double Rho -> rrh</li>
		/// <li>Theta -> th, Phi -> ph, Chi -> ch</li>
		/// <li>Xi -> x, Psi -> ps, Zeta -> z</li>
		/// <li>Ypsilon rendered according as usual in German: -> y, but as second vowel of a diphthongs -> u,
		/// therefore: EY -> eu, AY -> au, OY -> ou, HY -> &ecirc;u, WY -> &ocirc;u; but YI -> yi (where Ypsilon is
		/// the *first* vowel of the diphthong)</li>
		/// <li>Eta -> &ecirc;, Omega -> &ocirc;</li>
		/// <li>Iota subscript is skipped (but agath&ecirc; tych&ecirc; looks strange as dative, doesn't it)</li>
		/// <li>Iota adscript should be skipped, too, but I found no method to dedect a PROSGEGRAMMENI
		/// in all cases (Haid&ecirc;s should of course be Had&ecirc;s, but how to know from the pure text?)</li>
		/// <li>Apostrophe -> ' (single quote)</li>
		/// </ul>
		/// *
		/// </summary>
		/// <param name="uniText">the Unicode text to be converted
		/// </param>
		/// <returns>  ASCII representation with all diacriticals stripped
		/// </returns>
		// Looks trivial at first sight but isn't:
		//  i(/ppoj -> hippos ("i(" -> "hi"), but ai(re/w -> haire&ocirc; ("a" -> "ha", "i(" -> "i")
		// that is: in diphthongs the rough breathing belongs to the second vowel in Greek, but has to be put
		// before the first vowel in ASCII transliteration. The same applies to case:
		//  Ai(re/w -> Haire&ocirc;
		// that is: uppercase Alpha rendered lowercase, because the case has to be transfered to the breathing.
		
		internal virtual System.String convertString(System.String uniText)
		{
			int strLen = uniText.Length, strPos = 0;
			System.String asciiText = new System.String("".ToCharArray()), asciiChar = new System.String("".ToCharArray()); // a single rendered character (e.g. "th", therefore a string)
			char prevChar = ' ', nextChar;
			bool diphthong = false, rho = false;
			
			MessageHandler.clearMsgQueue();
			MessageHandler.enqueueMsg("Input >" + uniText + "< has " + strLen + " characters\n", MessageHandler.MSGLVL_DEBUGMSG);
			
			while (strPos < strLen)
			{
				// get next character and increment string position:
				nextChar = uniText[strPos++];
				// if current char is IOTA, YPSILON:
				if (isDiphthongSecondVowel(nextChar))
				{
					// if previous char was ALPHA, EPSILON, OMICRON:
					if (isDiphthongFirstVowel(prevChar))
					{
						// convert the previous character, but use the breathing of the current one:
						asciiChar = convertChar(prevChar, getSecondVowelBreathing(nextChar)?1:0);
						diphthong = true;
					}
					else
					{
						// convert the previous character using its own breathing:
						asciiChar = convertChar(prevChar, 0);
					}
				}
				// if current char is a RHO:
				else if ((isRho(nextChar)) && (isRho(prevChar)))
				{
					asciiChar = convertChar(prevChar, 0);
					rho = true;
				}
				// current char is not IOTA / YPSILON nor RHO:
				else
				{
					// if we are currently converting a diphthong:
					if (diphthong)
					{
						// convert y to  u:
						asciiChar = convertChar(prevChar, 2);
						diphthong = false;
					}
					else if (rho)
					{
						asciiChar = convertChar(prevChar, 1);
						rho = false;
					}
					else
					{
						// niente di speciale:
						asciiChar = convertChar(prevChar, 0);
					}
				}
				
				asciiText += asciiChar;
				prevChar = nextChar;
				MessageHandler.enqueueMsg(" at pos. " + strPos + "\n");
			}
			
			// the same procedure for the last character again:
			if (diphthong)
			{
				// convert y to  u:
				asciiChar = convertChar(prevChar, 2);
			}
			else
			{
				// niente di speciale:
				asciiChar = convertChar(prevChar, 0);
			}
			
			asciiText += asciiChar;
			MessageHandler.enqueueMsg(" at pos. " + strPos);
			
			return asciiText.Substring(1); // trim the leading space
		}
		
		/*
		* Converts a Unicode character into some sort of ASCII representation.
		* Some characters (uppercase and lowercase ALPHA, EPSILON, OMICRON, ETA, OMEGA, UPSILON
		* without accent, breathing and DIALYTIKA) can be the first vowel of a diphthong; if the
		* second vowel of a diphthong has a breathing (e.g. ALPHA+IOTA_DASIA), it must be put before
		* the first vowel ("hai", not "ahi"). In these cases the parameter alt=1 means "render with
		* rough breathing".
		* The characters that can be the second vowel (lowercase IOTA, UPSILON without DIALYTIKA ) must
		* be returned without rough breathing (which has already been put before the first vowel),
		* UPSILON must be rendered as "u" instead of "y". In these cases the parameter alt=2 means
		* "render as second vowel of a diphthong" (no rough breathing, "u" if UPSILON).
		* UPSILON can be first or second vowel of a diphthong and therefore receive alt=1 and alt=2.
		* A RHO is rendered "rh" if the preceding character is a RHO, too. This is meant by alt=1.*/
		private System.String convertChar(char uniChar, int alt)
		{
			System.String asciiChar = new System.String("".ToCharArray());
			
			switch (uniChar)
			{
				
				// Coptic stuff:
				case UC.CAPITAL_SHEI:  asciiChar = "Š"; break;
				
				case UC.SHEI:  asciiChar = "š"; break;
				
				case UC.CAPITAL_FEI:  asciiChar = "F"; break;
				
				case UC.FEI:  asciiChar = "f"; break;
				
				case UC.CAPITAL_KHEI:  asciiChar = "Ch"; break;
				
				case UC.KHEI:  asciiChar = "ch"; break;
				
				case UC.CAPITAL_HORI:  asciiChar = "H"; break;
				
				case UC.HORI:  asciiChar = "h"; break;
				
				case UC.CAPITAL_GANGIA:  asciiChar = "Dš"; break; // like *j*ungle
				
				case UC.GANGIA:  asciiChar = "dš"; break;
				
				case UC.CAPITAL_SHIMA:  asciiChar = "Š"; break; // originally g or kj
				
				case UC.SHIMA:  asciiChar = "š"; break;
				
				case UC.CAPITAL_DEI:  asciiChar = "T"; break;
				
				case UC.DEI:  asciiChar = "ti"; break;
					//case UC.DASIA                       : asciiChar = " ("; break;
					//case UC.DASIA_OXIA                  : asciiChar = " (/"; break;
					//case UC.DASIA_PERISPOMENI           : asciiChar = " (="; break;
					//case UC.DASIA_VARIA                 : asciiChar = " (\\"; break;
					//case UC.DIALYTIKA_OXIA              : asciiChar = " /+"; break;
					//case UC.DIALYTIKA_PERISPOMENI       : asciiChar = " =+"; break;
					//case UC.DIALYTIKA_TONOS             : asciiChar = " /+"; break; 
					//case UC.DIALYTIKA_VARIA             : asciiChar = " \\+"; break;
					//case UC.LOWER_NUMERAL_SIGN          : break;
					//case UC.NUMERAL_SIGN:               : break;
					//case UC.OXIA                        : asciiChar = " /"; break;
					//case UC.PERISPOMENI                 : asciiChar = " ="; break;
					//case UC.PSILI                       : asciiChar = " )"; break;
					//case UC.PSILI_OXIA                  : asciiChar = " )/"; break;
					//case UC.PSILI_PERISPOMENI           : asciiChar = " )="; break;
					//case UC.PSILI_VARIA                 : asciiChar = " )\\"; break;
					//case UC.SAMPI                       : asciiChar = "#5"; break;
					//case UC.STIGMA                      : asciiChar = ""; break;
					//case UC.TONOS                       : asciiChar = " /"; break;
					//case UC.VARIA                       : asciiChar = " \\"; break;
					//case UC.YPOGEGRAMMENI               : asciiChar = "|"; break;
				
				case UC.QUESTION_MARK:  asciiChar = "?"; break;
				
				
				case UC.ALPHA_DASIA: 
				case UC.ALPHA_DASIA_OXIA: 
				case UC.ALPHA_DASIA_OXIA_YPOGEGRAMMENI: 
				case UC.ALPHA_DASIA_PERISPOMENI: 
				case UC.ALPHA_DASIA_PERISPOMENI_YPOGEGRAMMENI: 
				case UC.ALPHA_DASIA_VARIA: 
				case UC.ALPHA_DASIA_VARIA_YPOGEGRAMMENI: 
				case UC.ALPHA_DASIA_YPOGEGRAMMENI:  asciiChar = "ha"; break;
					// Alpha without accent/breathing could be the first vowel of a diphthong:
				
				case UC.ALPHA: 
				case UC.ALPHA_VRACHY: 
				case UC.ALPHA_MACRON:  if (alt == 1)
					{
						asciiChar = "ha"; break;
					}
					goto case UC.ALPHA_OXIA;
				
				
				case UC.ALPHA_OXIA: 
				case UC.ALPHA_OXIA_YPOGEGRAMMENI: 
				case UC.ALPHA_PERISPOMENI: 
				case UC.ALPHA_PERISPOMENI_YPOGEGRAMMENI: 
				case UC.ALPHA_PSILI: 
				case UC.ALPHA_PSILI_OXIA: 
				case UC.ALPHA_PSILI_OXIA_YPOGEGRAMMENI: 
				case UC.ALPHA_PSILI_PERISPOMENI: 
				case UC.ALPHA_PSILI_PERISPOMENI_YPOGEGRAMMENI: 
				case UC.ALPHA_PSILI_VARIA: 
				case UC.ALPHA_PSILI_VARIA_YPOGEGRAMMENI: 
				case UC.ALPHA_PSILI_YPOGEGRAMMENI: 
				case UC.ALPHA_TONOS: 
				case UC.ALPHA_VARIA: 
				case UC.ALPHA_VARIA_YPOGEGRAMMENI: 
				case UC.ALPHA_YPOGEGRAMMENI:  asciiChar = "a"; break;
				
				
				case UC.ANO_TELEIA:  asciiChar = ":"; break;
				
				case UC.BETA: 
				case UC.BETA_SYMBOL:  asciiChar = "b"; break;
				
				
				case UC.CAPITAL_ALPHA_DASIA: 
				case UC.CAPITAL_ALPHA_DASIA_OXIA: 
				case UC.CAPITAL_ALPHA_DASIA_OXIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ALPHA_DASIA_PERISPOMENI: 
				case UC.CAPITAL_ALPHA_DASIA_PERISPOMENI_PROSGEGRAMMENI: 
				case UC.CAPITAL_ALPHA_DASIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ALPHA_DASIA_VARIA: 
				case UC.CAPITAL_ALPHA_DASIA_VARIA_PROSGEGRAMMENI:  asciiChar = "Ha"; break;
					// Capital Alpha without accent/breathing could be the first vowel of a diphthong:
				
				case UC.CAPITAL_ALPHA: 
				case UC.CAPITAL_ALPHA_VRACHY: 
				case UC.CAPITAL_ALPHA_MACRON:  if (alt == 1)
					{
						asciiChar = "Ha"; break;
					}
					goto case UC.CAPITAL_ALPHA_OXIA;
				
				
				case UC.CAPITAL_ALPHA_OXIA: 
				case UC.CAPITAL_ALPHA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ALPHA_PSILI: 
				case UC.CAPITAL_ALPHA_PSILI_OXIA: 
				case UC.CAPITAL_ALPHA_PSILI_OXIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ALPHA_PSILI_PERISPOMENI: 
				case UC.CAPITAL_ALPHA_PSILI_PERISPOMENI_PROSGEGRAMMENI: 
				case UC.CAPITAL_ALPHA_PSILI_PROSGEGRAMMENI: 
				case UC.CAPITAL_ALPHA_PSILI_VARIA: 
				case UC.CAPITAL_ALPHA_PSILI_VARIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ALPHA_TONOS: 
				case UC.CAPITAL_ALPHA_VARIA:  asciiChar = "A"; break;
				
				case UC.CAPITAL_BETA:  asciiChar = "B"; break;
				
				case UC.CAPITAL_CHI:  asciiChar = "Ch"; break;
				
				case UC.CAPITAL_DELTA:  asciiChar = "D"; break;
				
				
				case UC.CAPITAL_EPSILON_DASIA: 
				case UC.CAPITAL_EPSILON_DASIA_OXIA: 
				case UC.CAPITAL_EPSILON_DASIA_VARIA:  asciiChar = "He"; break;
					// Capital Epsilon without accent/breathing could be the first vowel of a diphthong:
				
				case UC.CAPITAL_EPSILON:  if (alt == 1)
					{
						asciiChar = "He"; break;
					}
					goto case UC.CAPITAL_EPSILON_OXIA;
				
				
				case UC.CAPITAL_EPSILON_OXIA: 
				case UC.CAPITAL_EPSILON_PSILI: 
				case UC.CAPITAL_EPSILON_PSILI_OXIA: 
				case UC.CAPITAL_EPSILON_PSILI_VARIA: 
				case UC.CAPITAL_EPSILON_TONOS: 
				case UC.CAPITAL_EPSILON_VARIA:  asciiChar = "E"; break;
				
				
				case UC.CAPITAL_ETA_DASIA: 
				case UC.CAPITAL_ETA_DASIA_OXIA: 
				case UC.CAPITAL_ETA_DASIA_OXIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ETA_DASIA_PERISPOMENI: 
				case UC.CAPITAL_ETA_DASIA_PERISPOMENI_PROSGEGRAMMENI: 
				case UC.CAPITAL_ETA_DASIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ETA_DASIA_VARIA: 
				case UC.CAPITAL_ETA_DASIA_VARIA_PROSGEGRAMMENI:  asciiChar = "Hê"; break;
					// Capital Eta without accent/breathing could be the first vowel of a diphthong:
				
				case UC.CAPITAL_ETA:  if (alt == 1)
					{
						asciiChar = "Hê"; break;
					}
					goto case UC.CAPITAL_ETA_OXIA;
				
				
				case UC.CAPITAL_ETA_OXIA: 
				case UC.CAPITAL_ETA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ETA_PSILI: 
				case UC.CAPITAL_ETA_PSILI_OXIA: 
				case UC.CAPITAL_ETA_PSILI_OXIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ETA_PSILI_PERISPOMENI: 
				case UC.CAPITAL_ETA_PSILI_PERISPOMENI_PROSGEGRAMMENI: 
				case UC.CAPITAL_ETA_PSILI_PROSGEGRAMMENI: 
				case UC.CAPITAL_ETA_PSILI_VARIA: 
				case UC.CAPITAL_ETA_PSILI_VARIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_ETA_TONOS: 
				case UC.CAPITAL_ETA_VARIA:  asciiChar = "Ê"; break;
				
				
				case UC.CAPITAL_GAMMA:  asciiChar = "G"; break;
				
				case UC.CAPITAL_IOTA_DASIA: 
				case UC.CAPITAL_IOTA_DASIA_OXIA: 
				case UC.CAPITAL_IOTA_DASIA_PERISPOMENI: 
				case UC.CAPITAL_IOTA_DASIA_VARIA:  asciiChar = "Hi"; break;
				
				case UC.CAPITAL_IOTA: 
				case UC.CAPITAL_IOTA_MACRON: 
				case UC.CAPITAL_IOTA_OXIA: 
				case UC.CAPITAL_IOTA_PSILI: 
				case UC.CAPITAL_IOTA_PSILI_OXIA: 
				case UC.CAPITAL_IOTA_PSILI_PERISPOMENI: 
				case UC.CAPITAL_IOTA_PSILI_VARIA: 
				case UC.CAPITAL_IOTA_TONOS: 
				case UC.CAPITAL_IOTA_VARIA: 
				case UC.CAPITAL_IOTA_VRACHY:  asciiChar = "I"; break;
				
				case UC.CAPITAL_IOTA_DIALYTIKA:  asciiChar = "Ï"; break;
				
				case UC.CAPITAL_KAPPA:  asciiChar = "K"; break;
				
				case UC.CAPITAL_LAMDA:  asciiChar = "L"; break;
				
				case UC.CAPITAL_MU:  asciiChar = "M"; break;
				
				case UC.CAPITAL_NU:  asciiChar = "N"; break;
				
				
				case UC.CAPITAL_OMEGA_DASIA: 
				case UC.CAPITAL_OMEGA_DASIA_OXIA: 
				case UC.CAPITAL_OMEGA_DASIA_OXIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_OMEGA_DASIA_PERISPOMENI: 
				case UC.CAPITAL_OMEGA_DASIA_PERISPOMENI_PROSGEGRAMMENI: 
				case UC.CAPITAL_OMEGA_DASIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_OMEGA_DASIA_VARIA: 
				case UC.CAPITAL_OMEGA_DASIA_VARIA_PROSGEGRAMMENI:  asciiChar = "Hô"; break;
					// Capital Omega without accent/breathing could be the first vowel of a diphthong:
				
				case UC.CAPITAL_OMEGA:  if (alt == 1)
					{
						asciiChar = "Hô"; break;
					}
					goto case UC.CAPITAL_OMEGA_OXIA;
				
				case UC.CAPITAL_OMEGA_OXIA: 
				case UC.CAPITAL_OMEGA_PROSGEGRAMMENI: 
				case UC.CAPITAL_OMEGA_PSILI: 
				case UC.CAPITAL_OMEGA_PSILI_OXIA: 
				case UC.CAPITAL_OMEGA_PSILI_OXIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_OMEGA_PSILI_PERISPOMENI: 
				case UC.CAPITAL_OMEGA_PSILI_PERISPOMENI_PROSGEGRAMMENI: 
				case UC.CAPITAL_OMEGA_PSILI_PROSGEGRAMMENI: 
				case UC.CAPITAL_OMEGA_PSILI_VARIA: 
				case UC.CAPITAL_OMEGA_PSILI_VARIA_PROSGEGRAMMENI: 
				case UC.CAPITAL_OMEGA_TONOS: 
				case UC.CAPITAL_OMEGA_VARIA:  asciiChar = "Ô"; break;
				
				
				case UC.CAPITAL_OMICRON_DASIA: 
				case UC.CAPITAL_OMICRON_DASIA_OXIA: 
				case UC.CAPITAL_OMICRON_DASIA_VARIA:  asciiChar = "Ho"; break;
					// Capital Omicron without accent/breathing could be the first vowel of a diphthong:
				
				case UC.CAPITAL_OMICRON:  if (alt == 1)
					{
						asciiChar = "Ho"; break;
					}
					goto case UC.CAPITAL_OMICRON_OXIA;
				
				case UC.CAPITAL_OMICRON_OXIA: 
				case UC.CAPITAL_OMICRON_PSILI: 
				case UC.CAPITAL_OMICRON_PSILI_OXIA: 
				case UC.CAPITAL_OMICRON_PSILI_VARIA: 
				case UC.CAPITAL_OMICRON_TONOS: 
				case UC.CAPITAL_OMICRON_VARIA:  asciiChar = "O"; break;
				
				
				case UC.CAPITAL_PHI:  asciiChar = "Ph"; break;
				
				case UC.CAPITAL_PI:  asciiChar = "P"; break;
				
				case UC.CAPITAL_PSI:  asciiChar = "Ps"; break;
				
				case UC.CAPITAL_RHO:  if (alt == 1)
						asciiChar = "RH";
					else
						asciiChar = "R"; break;
				
				case UC.CAPITAL_RHO_DASIA:  asciiChar = "Rh"; break;
				
				case UC.CAPITAL_SIGMA:  asciiChar = "S"; break;
				
				case UC.CAPITAL_TAU:  asciiChar = "T"; break;
				
				case UC.CAPITAL_THETA:  asciiChar = "Th"; break;
				
				
				case UC.CAPITAL_UPSILON_DASIA: 
				case UC.CAPITAL_UPSILON_DASIA_OXIA: 
				case UC.CAPITAL_UPSILON_DASIA_PERISPOMENI: 
				case UC.CAPITAL_UPSILON_DASIA_VARIA:  asciiChar = "Hy"; break;
					// Capital Ypsilon without accent/breathing could be the first vowel of a diphthong:
				
				case UC.CAPITAL_UPSILON: 
				case UC.CAPITAL_UPSILON_VRACHY:  if (alt == 1)
					{
						asciiChar = "Hy"; break;
					}
					goto case UC.CAPITAL_UPSILON_MACRON;
				
				case UC.CAPITAL_UPSILON_MACRON: 
				case UC.CAPITAL_UPSILON_OXIA: 
				case UC.CAPITAL_UPSILON_TONOS: 
				case UC.CAPITAL_UPSILON_VARIA:  asciiChar = "Y"; break;
				
				case UC.CAPITAL_UPSILON_DIALYTIKA:  asciiChar = "Ÿ"; break;
				
				
				case UC.CAPITAL_XI:  asciiChar = "X"; break;
				
				case UC.CAPITAL_ZETA:  asciiChar = "Z"; break;
				
				case UC.CHI:  asciiChar = "ch"; break;
				
				case UC.DELTA:  asciiChar = "d"; break;
				
				case UC.DIGAMMA:  asciiChar = "v"; break;
				
				case UC.EPSILON_DASIA: 
				case UC.EPSILON_DASIA_OXIA: 
				case UC.EPSILON_DASIA_VARIA:  asciiChar = "he"; break;
					// Epsilon without accent/breathing could be the first vowel of a diphthong:
				
				case UC.EPSILON:  if (alt == 1)
					{
						asciiChar = "he"; break;
					}
					goto case UC.EPSILON_OXIA;
				
				case UC.EPSILON_OXIA: 
				case UC.EPSILON_PSILI: 
				case UC.EPSILON_PSILI_OXIA: 
				case UC.EPSILON_PSILI_VARIA: 
				case UC.EPSILON_TONOS: 
				case UC.EPSILON_VARIA:  asciiChar = "e"; break;
				
				
				case UC.ETA_DASIA: 
				case UC.ETA_DASIA_OXIA: 
				case UC.ETA_DASIA_OXIA_YPOGEGRAMMENI: 
				case UC.ETA_DASIA_PERISPOMENI: 
				case UC.ETA_DASIA_PERISPOMENI_YPOGEGRAMMENI: 
				case UC.ETA_DASIA_VARIA: 
				case UC.ETA_DASIA_VARIA_YPOGEGRAMMENI: 
				case UC.ETA_DASIA_YPOGEGRAMMENI:  asciiChar = "hê"; break;
					// Eta without accent/breathing could be the first vowel of a diphthong:
				
				case UC.ETA:  if (alt == 1)
					{
						asciiChar = "hê"; break;
					}
					goto case UC.ETA_OXIA;
				
				case UC.ETA_OXIA: 
				case UC.ETA_OXIA_YPOGEGRAMMENI: 
				case UC.ETA_PERISPOMENI: 
				case UC.ETA_PERISPOMENI_YPOGEGRAMMENI: 
				case UC.ETA_PSILI: 
				case UC.ETA_PSILI_OXIA: 
				case UC.ETA_PSILI_OXIA_YPOGEGRAMMENI: 
				case UC.ETA_PSILI_PERISPOMENI: 
				case UC.ETA_PSILI_PERISPOMENI_YPOGEGRAMMENI: 
				case UC.ETA_PSILI_VARIA: 
				case UC.ETA_PSILI_VARIA_YPOGEGRAMMENI: 
				case UC.ETA_PSILI_YPOGEGRAMMENI: 
				case UC.ETA_TONOS: 
				case UC.ETA_VARIA: 
				case UC.ETA_VARIA_YPOGEGRAMMENI: 
				case UC.ETA_YPOGEGRAMMENI:  asciiChar = "ê"; break;
				
				
				case UC.FINAL_SIGMA:  asciiChar = "s"; break;
				
				case UC.GAMMA:  asciiChar = "g"; break;
					
					// Iota could be the second vowel of a diphthong; if it has a breathing it must be put before the vowel:
				
				case UC.IOTA_DASIA: 
				case UC.IOTA_DASIA_OXIA: 
				case UC.IOTA_DASIA_PERISPOMENI: 
				case UC.IOTA_DASIA_VARIA:  if (alt == 2)
						asciiChar = "i";
					else
						asciiChar = "hi"; break;
				
				
				case UC.IOTA_MACRON: 
				case UC.IOTA: 
				case UC.IOTA_OXIA: 
				case UC.IOTA_PERISPOMENI: 
				case UC.IOTA_PSILI: 
				case UC.IOTA_PSILI_OXIA: 
				case UC.IOTA_PSILI_PERISPOMENI: 
				case UC.IOTA_PSILI_VARIA: 
				case UC.IOTA_TONOS: 
				case UC.IOTA_VARIA: 
				case UC.IOTA_VRACHY:  asciiChar = "i"; break;
				
				case UC.IOTA_DIALYTIKA: 
				case UC.IOTA_DIALYTIKA_OXIA: 
				case UC.IOTA_DIALYTIKA_PERISPOMENI: 
				case UC.IOTA_DIALYTIKA_TONOS: 
				case UC.IOTA_DIALYTIKA_VARIA:  asciiChar = "ï"; break;
				
				
				case UC.KAPPA:  asciiChar = "k"; break;
				
				case UC.KAPPA_SYMBOL:  asciiChar = "k"; break;
				
				case UC.KOPPA:  asciiChar = "q"; break;
				
				case UC.KORONIS:  asciiChar = "'"; break;
				
				case UC.LAMDA:  asciiChar = "l"; break;
				
				case UC.LUNATE_SIGMA_SYMBOL:  asciiChar = "s"; break;
				
				case UC.MU:  asciiChar = "m"; break;
				
				case UC.NU:  asciiChar = "n"; break;
				
				
				case UC.OMEGA_DASIA: 
				case UC.OMEGA_DASIA_OXIA: 
				case UC.OMEGA_DASIA_OXIA_YPOGEGRAMMENI: 
				case UC.OMEGA_DASIA_PERISPOMENI: 
				case UC.OMEGA_DASIA_PERISPOMENI_YPOGEGRAMMENI: 
				case UC.OMEGA_DASIA_VARIA: 
				case UC.OMEGA_DASIA_VARIA_YPOGEGRAMMENI: 
				case UC.OMEGA_DASIA_YPOGEGRAMMENI:  asciiChar = "hô"; break;
					// Omega without accent/breathing could be the first vowel of a diphthong:
				
				case UC.OMEGA:  if (alt == 1)
					{
						asciiChar = "hô"; break;
					}
					goto case UC.OMEGA_OXIA;
				
				case UC.OMEGA_OXIA: 
				case UC.OMEGA_OXIA_YPOGEGRAMMENI: 
				case UC.OMEGA_PERISPOMENI: 
				case UC.OMEGA_PERISPOMENI_YPOGEGRAMMENI: 
				case UC.OMEGA_PSILI: 
				case UC.OMEGA_PSILI_OXIA: 
				case UC.OMEGA_PSILI_OXIA_YPOGEGRAMMENI: 
				case UC.OMEGA_PSILI_PERISPOMENI: 
				case UC.OMEGA_PSILI_PERISPOMENI_YPOGEGRAMMENI: 
				case UC.OMEGA_PSILI_VARIA: 
				case UC.OMEGA_PSILI_VARIA_YPOGEGRAMMENI: 
				case UC.OMEGA_PSILI_YPOGEGRAMMENI: 
				case UC.OMEGA_TONOS: 
				case UC.OMEGA_VARIA: 
				case UC.OMEGA_VARIA_YPOGEGRAMMENI: 
				case UC.OMEGA_YPOGEGRAMMENI:  asciiChar = "ô"; break;
				
				
				case UC.OMICRON_DASIA: 
				case UC.OMICRON_DASIA_OXIA: 
				case UC.OMICRON_DASIA_VARIA:  asciiChar = "ho"; break;
					// Omicron without accent/breathing could be the first vowel of a diphthong:
				
				case UC.OMICRON:  if (alt == 1)
					{
						asciiChar = "ho"; break;
					}
					goto case UC.OMICRON_OXIA;
				
				case UC.OMICRON_OXIA: 
				case UC.OMICRON_PSILI: 
				case UC.OMICRON_PSILI_OXIA: 
				case UC.OMICRON_PSILI_VARIA: 
				case UC.OMICRON_TONOS: 
				case UC.OMICRON_VARIA:  asciiChar = "o"; break;
				
				
				case UC.PHI: 
				case UC.PHI_SYMBOL:  asciiChar = "ph"; break;
				
				case UC.PI: 
				case UC.PI_SYMBOL:  asciiChar = "p"; break;
				
				case UC.PROSGEGRAMMENI:  asciiChar = "i"; break;
				
				case UC.PSI:  asciiChar = "ps"; break;
				
				case UC.RHO:  if (alt == 1)
					{
						asciiChar = "rh"; break;
					}
					goto case UC.RHO_PSILI;
				
				case UC.RHO_PSILI: 
				case UC.RHO_SYMBOL:  asciiChar = "r"; break;
				
				case UC.RHO_DASIA:  asciiChar = "rh"; break;
				
				case UC.SIGMA:  asciiChar = "s"; break;
				
				case UC.TAU:  asciiChar = "t"; break;
				
				case UC.THETA: 
				case UC.THETA_SYMBOL:  asciiChar = "th"; break;
					
					// Ypsilon with DIALYTIKA or MACRON cannot be part of a diphthong:
				
				case UC.UPSILON_DIALYTIKA: 
				case UC.UPSILON_DIALYTIKA_OXIA: 
				case UC.UPSILON_DIALYTIKA_PERISPOMENI: 
				case UC.UPSILON_DIALYTIKA_TONOS: 
				case UC.UPSILON_DIALYTIKA_VARIA: 
				case UC.UPSILON_DIAERESIS_HOOK_SYMBOL:  asciiChar = "ÿ"; break;
				
				case UC.UPSILON_MACRON:  asciiChar = "y"; break;
					// Ypsilon could be the second vowel of a diphthong; if it has a breathing it must be put before the vowel:
				
				case UC.UPSILON_DASIA: 
				case UC.UPSILON_DASIA_OXIA: 
				case UC.UPSILON_DASIA_PERISPOMENI: 
				case UC.UPSILON_DASIA_VARIA:  if (alt == 2)
						asciiChar = "u";
					else
						asciiChar = "hy"; break;
					// Ypsilon without accent/breathing could be the first vowel of a diphthong:
				
				case UC.UPSILON_VRACHY: 
				case UC.UPSILON_HOOK_SYMBOL: 
				case UC.UPSILON:  if (alt == 1)
					{
						asciiChar = "hy"; break;
					}
					// if it has none:
					goto case UC.UPSILON_ACUTE_HOOK_SYMBOL;
				
				case UC.UPSILON_ACUTE_HOOK_SYMBOL: 
				case UC.UPSILON_OXIA: 
				case UC.UPSILON_PERISPOMENI: 
				case UC.UPSILON_PSILI: 
				case UC.UPSILON_PSILI_OXIA: 
				case UC.UPSILON_PSILI_PERISPOMENI: 
				case UC.UPSILON_PSILI_VARIA: 
				case UC.UPSILON_TONOS: 
				case UC.UPSILON_VARIA:  if (alt == 2)
						asciiChar = "u";
					else
						asciiChar = "y"; break;
				
				
				case UC.XI:  asciiChar = "x"; break;
				
				case UC.YOT:  asciiChar = "j"; break;
				
				case UC.ZETA:  asciiChar = "z"; break;
					/*
					case UC.HORIZONTAL_TABULATION       : asciiChar = HORIZONTAL_TABULATION + ""; break;
					case UC.VERTICAL_TABULATION         : asciiChar = VERTICAL_TABULATION + ""; break;
					case UC.LINE_FEED                   : asciiChar = "\n"; break;
					case UC.FORM_FEED                   : asciiChar = "\f"; break;
					case UC.CARRIAGE_RETURN             : asciiChar = CARRIAGE_RETURN + ""; break;
					case UC.SPACE                       : asciiChar = " "; break;*/
				
				default: 
					if (uniChar <= UC.USASCII_UPPER_BOUND)
					{
						asciiChar = uniChar.ToString();
					}
					else
					{
						asciiChar = "{?}";
						System.Int32 i = uniChar;
						MessageHandler.enqueueMsg("U+" + System.Convert.ToString(uniChar, 16) + " cannot be converted", MessageHandler.MSGLVL_ERRORMSG);
					}
					break;
				
			}
			MessageHandler.enqueueMsg(UnicodeToName.convertChar(uniChar) + " -> " + asciiChar + (alt > 0?" (" + alt + ")":""), MessageHandler.MSGLVL_DEBUGMSG);
			return asciiChar;
		}
		
		/*
		* Returns true if the Unicode character can be the first vowel of a diphthong.*/
		private bool isDiphthongFirstVowel(char uniChar)
		{
			switch (uniChar)
			{
				
				case UC.CAPITAL_ALPHA: 
				case UC.CAPITAL_ALPHA_MACRON: 
				case UC.CAPITAL_ALPHA_VRACHY: 
				case UC.ALPHA: 
				case UC.ALPHA_MACRON: 
				case UC.ALPHA_VRACHY: 
				case UC.CAPITAL_EPSILON: 
				case UC.EPSILON: 
				case UC.CAPITAL_OMICRON: 
				case UC.OMICRON: 
				case UC.CAPITAL_ETA: 
				case UC.ETA: 
				case UC.CAPITAL_OMEGA: 
				case UC.OMEGA: 
				case UC.CAPITAL_UPSILON: 
				case UC.CAPITAL_UPSILON_VRACHY: 
				// but not MACRON!
				case UC.UPSILON: 
				case UC.UPSILON_VRACHY: 
				case UC.UPSILON_HOOK_SYMBOL: 
					return true;
				
				default: 
					return false;
				
			}
		}
		
		/*
		* Returns true if the Unicode character can be the second vowel of a diphthong.*/
		private bool isDiphthongSecondVowel(char uniChar)
		{
			switch (uniChar)
			{
				
				case UC.IOTA_DASIA: 
				case UC.IOTA_DASIA_OXIA: 
				case UC.IOTA_DASIA_PERISPOMENI: 
				case UC.IOTA_DASIA_VARIA: 
				case UC.UPSILON_DASIA: 
				case UC.UPSILON_DASIA_OXIA: 
				case UC.UPSILON_DASIA_PERISPOMENI: 
				case UC.UPSILON_DASIA_VARIA: 
				case UC.IOTA: 
				case UC.IOTA_OXIA: 
				case UC.IOTA_PERISPOMENI: 
				case UC.IOTA_PSILI: 
				case UC.IOTA_PSILI_OXIA: 
				case UC.IOTA_PSILI_PERISPOMENI: 
				case UC.IOTA_PSILI_VARIA: 
				case UC.IOTA_TONOS: 
				case UC.IOTA_VARIA: 
				case UC.IOTA_VRACHY: 
				case UC.UPSILON: 
				case UC.UPSILON_ACUTE_HOOK_SYMBOL: 
				case UC.UPSILON_HOOK_SYMBOL: 
				case UC.UPSILON_OXIA: 
				case UC.UPSILON_PERISPOMENI: 
				case UC.UPSILON_PSILI: 
				case UC.UPSILON_PSILI_OXIA: 
				case UC.UPSILON_PSILI_PERISPOMENI: 
				case UC.UPSILON_PSILI_VARIA: 
				case UC.UPSILON_TONOS: 
				case UC.UPSILON_VARIA: 
				case UC.UPSILON_VRACHY: 
					return true;
				
				default: 
					return false;
				
			}
		}
		
		/*
		* Returns true if the Unicode character is a iota or ypsilon with rough breathing.
		* What a heck! isDiphthongSecondVowel() has the information at hand but cannot return it,
		* since you cannot change the value of Boolean or Number objects. And because an object
		* reference is passed by value you cannot change the target it actually points to.
		* I should have programmed this with C++!*/
		private bool getSecondVowelBreathing(char uniChar)
		{
			switch (uniChar)
			{
				
				case UC.IOTA_DASIA: 
				case UC.IOTA_DASIA_OXIA: 
				case UC.IOTA_DASIA_PERISPOMENI: 
				case UC.IOTA_DASIA_VARIA: 
				case UC.UPSILON_DASIA: 
				case UC.UPSILON_DASIA_OXIA: 
				case UC.UPSILON_DASIA_PERISPOMENI: 
				case UC.UPSILON_DASIA_VARIA: 
					return true;
				
				default: 
					return false;
				
			}
		}
		
		/*
		* Returns true if the Unicode character contains a rho.*/
		private bool isRho(char uniChar)
		{
			switch (uniChar)
			{
				
				case UC.CAPITAL_RHO: 
				case UC.CAPITAL_RHO_DASIA: 
				case UC.RHO: 
				case UC.RHO_DASIA: 
				case UC.RHO_PSILI: 
				case UC.RHO_SYMBOL: 
					return true;
				
				default: 
					return false;
				
			}
		}
	}
}