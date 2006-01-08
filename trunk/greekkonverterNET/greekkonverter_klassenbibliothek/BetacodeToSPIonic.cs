namespace greekconverter
{
	using System;
	
	/// <summary>************************
	/// </summary>
	/* Betacode -> SPIonic      */
	/// <summary>************************
	/// </summary>
	
	public class BetacodeToSPIonic
	{
		private const char UNDEFINED_SYMBOL = '\x0000';
		private const sbyte WORDEND_NO = 0;
		private const sbyte WORDEND_YES = 1;
		// lookup table for determining if a character is the end of a word:
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblWordEnd " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly sbyte[] tblWordEnd;
		
		
		private static bool UPPERCASE = false;
		// chars preceeded by *
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case VersionInfo.CLASSINFO_VERSION_DATE:  info = "20-Jun-2004"; break;
				
				case VersionInfo.CLASSINFO_PROG_DESCR:  info = "Converts a Beta coded string into simplified (SPIonic/Sgreek) Beta code."; break;
				
				case VersionInfo.CLASSINFO_DEVELOPER:  info = VersionInfo.DEVELOPER_MN; break;
				
				default:  info = "Sic itur ad astra.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Converts a TLG Beta coded string into simplified (SPIonic/Sgreek) Beta code
		/// <ul>
		/// <li>character case of code matches case of encoded text: A -> a, *A -> A</li>
		/// <li>SPIonic rendering of final sigma: S_ (S followed by whitespace) -> j</li>
		/// <li>all escapes remain unconverted: %nn -> %nn</li>
		/// </ul>
		/// </summary>
		public static System.String convertString(System.String betaText)
		{
			betaText += ' '; // append a word end character
			int strLen = betaText.Length, strPos = 0;
			System.Text.StringBuilder uniText = new System.Text.StringBuilder(strLen);
			char currChar, prevChar; // the buffered character
			
			MessageHandler.clearMsgQueue();
			MessageHandler.enqueueMsg("Input >" + betaText + "< has " + strLen + " characters", MessageHandler.MSGLVL_STATUSMSG);
			
			prevChar = betaText[strPos++]; // read first character
			while (strPos < strLen)
			{
				currChar = betaText[strPos++]; // read next character
				//System.out.println( prevChar + "-" + currChar );
				switch (currChar)
				{
					
					// start of an uppercase character:
					case '*': 
						UPPERCASE = true;
						// do not output anything!!
						break;
						// anything else:
					
					default: 
						if (tblWordEnd[currChar] == WORDEND_YES)
						{
							if (((prevChar == 'S') || (prevChar == 's')) && !(UPPERCASE))
							{
								uniText.Append('j');
								prevChar = currChar;
								break;
							}
						}
						//
						if (UPPERCASE)
						{
							if (prevChar > 64)
							// if the current character is one that has an uppercase, 64=@
							{
								uniText.Append(System.Char.ToUpper(prevChar));
								UPPERCASE = false;
							}
							// otherwise currChar is a diacritic placed between * and the character [*)/A]
							else
							{
								uniText.Append(prevChar);
							}
						}
						else
						{
							uniText.Append(System.Char.ToLower(prevChar));
						}
						prevChar = currChar;
						break;
					
				} // switch
				
				MessageHandler.enqueueMsg(" at pos. " + strPos + "\n");
			}
			
			return uniText.ToString();
		}
		static BetacodeToSPIonic()
		{
			tblWordEnd = new sbyte[256];
			{
				int i;
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
				tblWordEnd['\n'] = WORDEND_YES;
				tblWordEnd['\r'] = WORDEND_YES;
				tblWordEnd['\t'] = WORDEND_YES;
				tblWordEnd['"'] = WORDEND_YES;
				tblWordEnd['\''] = WORDEND_YES;
			}
		}
	}
}