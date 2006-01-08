namespace greekconverter
{
	using System;
	
	/// <summary>************************
	/// </summary>
	/* Ascii -> Betacode        */
	/// <summary>************************
	/// </summary>
	
	public class AsciiToBetacode
	{
		
		/// <summary> Converts an ASCII string containing Greek text into Betacode.
		/// *
		/// The purpose behind this is a means to convert ASCII text into Unicode.
		/// You must do a two step conversion: ASCII->Betacode, Betacode->Unicode.
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode string
		/// </param>
		/// <returns>  the string converted into Beta coding
		/// </returns>
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "26-Apr-2002"; break;
				
				case 1:  info = "Converts an ASCII string containing Greek text into Betacode"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Omnes una manet nox.";
					break;
				
			}
			return info;
		}
		
		public virtual System.String convertString(System.String uniString)
		{
			int strLen = uniString.Length, strPos;
			char currChar, prevChar = UC.LINE_FEED;
			bool isEndOfWord = false;
			System.String betaString = new System.String("".ToCharArray());
			
			// append space for character read ahead (avoid index out of bounds exception):
			uniString = uniString + " ";
			
			MessageHandler.clearMsgQueue();
			
			for (strPos = 0; strPos < strLen; strPos++)
			{
				currChar = uniString[strPos];
				betaString += convertChar(prevChar, currChar, uniString[strPos + 1]);
				prevChar = currChar;
				MessageHandler.enqueueMsg(" at pos. " + (strPos + 1).ToString() + "\n");
			}
			return betaString;
		}
		
		private System.String getAsciiConvChar(char origChar, char convChar)
		{
			System.String ret = new System.String("".ToCharArray());
			
			if (System.Char.IsUpper(origChar))
			{
				ret = "*" + convChar;
			}
			else
			{
				
				ret = "" + convChar;
			}
			
			
			
			return ret;
		}
		
		
		
		/*
		
		* For conversion the previous and the next letter must be known:
		
		* s can only be converted, if we know if the previous character was s (thus being
		* converted into psi) or if the following letter is a space, interpunction etc.
		
		* (final sigma). P could be followed  by h (->phi) or s (->psi) and so on.
		*/
		
		private System.String convertChar(char prevChar, char currChar, char nextChar)
		{
			
			char currCharUpper = System.Char.ToUpper(currChar), nextCharUpper = System.Char.ToUpper(nextChar);
			
			System.String betaChar = new System.String("".ToCharArray());
			
			
			
			if (currChar > UC.USASCII_UPPER_BOUND)
			{
				
				switch (currChar)
				{
					
					
					case 'Ê':  betaChar = "*H"; break;
					
					
					case 'ê':  betaChar = "H"; break;
					
					
					case 'Ô':  betaChar = "*W"; break;
					
					
					case 'ô':  betaChar = "W"; break;
					
					
					case 'Ï':  betaChar = "*+I"; break;
					
					
					case 'ï':  betaChar = "I+"; break;
					
					
					case 'Ÿ':  betaChar = "*+U"; break;
					
					
					case 'ÿ':  betaChar = "U+"; break;
					
					
					default:  betaChar = "?";
						break;
					
				}
			}
			else
			{
				
				switch (currCharUpper)
				{
					
					
					case 'A': 
					case 'B': 
					case 'D': 
					case 'E': 
					case 'G': 
					case 'I': 
					case 'L': 
					case 'M': 
					case 'N': 
					case 'O': 
					case 'R': 
					case 'U': 
					case 'Z': 
					case ',': 
					case ';': 
					case '.': 
					case ':': 
					case '?': 
					case '\'': 
					case '"': 
					case '(': 
					case ')': 
					case UC.HORIZONTAL_TABULATION: 
					case UC.LINE_FEED: 
					case UC.VERTICAL_TABULATION: 
					case UC.FORM_FEED: 
					case UC.CARRIAGE_RETURN: 
					case UC.SPACE: 
						
						betaChar = getAsciiConvChar(currChar, currCharUpper);
						
						break;
					
					
					
					
					case 'T': 
					case 'C': 
					case 'K': 
						
						if (nextCharUpper != 'H')
						{
							
							betaChar = getAsciiConvChar(currChar, currCharUpper);
						}
						
						break; // else wait for H to convert into THETA, CHI
					
					
					
					
					case 'P': 
						
						if ((nextCharUpper != 'H') && (nextCharUpper != 'S'))
						{
							
							betaChar = getAsciiConvChar(currChar, currCharUpper);
						}
						
						break; // else wait for H or S to convert into PHI or PSI
					
					
					
					
					case 'Y': 
						
						betaChar = getAsciiConvChar(currChar, 'U');
						
						break;
					
					
					case 'X': 
						
						betaChar = getAsciiConvChar(currChar, 'C');
						
						break;
					
					
					
					
					case 'S': 
						
						if (prevChar == 'P')
						{
							
							betaChar = "*Y";
						}
						else if (prevChar == 'p')
						{
							
							betaChar = "Y";
						}
						else
						{
							
							// lowercase or final SIGMA?:
							
							if (currChar == 's')
							{
								
								switch (nextChar)
								{
									
									
									case ',': 
									case ';': 
									case '.': 
									case ':': 
									case '?': 
									case '-': 
									case '/': 
									case '(': 
									case ')': 
									case '[': 
									case ']': 
									case '{': 
									case '}': 
									case UC.HORIZONTAL_TABULATION: 
									case UC.LINE_FEED: 
									case UC.VERTICAL_TABULATION: 
									case UC.FORM_FEED: 
									case UC.CARRIAGE_RETURN: 
									case UC.SPACE: 
										
										betaChar = "J"; break;
									
									
									default: 
										
										betaChar = "S";
										break;
									
								}
							}
							// all that remains must be uppercase SIGMA:
							else
							{
								
								betaChar = "*S";
							}
						}
						
						break;
					
					
					
					
					case 'H': 
						
						switch (prevChar)
						{
							
							
							case 'T':  betaChar = "*Q"; break;
							
							
							case 't':  betaChar = "Q"; break;
							
							
							case 'P':  betaChar = "*F"; break;
							
							
							case 'p':  betaChar = "F"; break;
							
							
							case 'C': 
							case 'K':  betaChar = "*X"; break;
							
							
							case 'c': 
							case 'k':  betaChar = "X";
								break;
							}
						break;
					}
			}
			
			return betaChar;
		}
	}
}