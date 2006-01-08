namespace greekconverter
{
	using System;
	
	/// <summary>************************
	/// </summary>
	/* BibleWorks -> Betacode   */
	/// <summary>************************
	/// </summary>
	
	public class BibleWorksToBetacode
	{
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "23-Mar-2002"; break;
				
				case 1:  info = "Converts text with BibleWorks' coding into Beta coding - no longer being maintained"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Est modus in rebus, sunt certi denique fines.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Converts text with BibleWorks' coding into Beta coding. Which you can convert
		/// into Unicode then.
		/// *
		/// BibleWorks uses flying accents that are placed with heavy kerning. The sense
		/// behind acute = ",", comma = "(", grave = ".", period = "Å" etc. I will never
		/// understand. But in principle the coding is similar to Beta coding.
		/// *
		/// </summary>
		/// <param name="bwString">the string in BibleWorks' Greek coding
		/// </param>
		/// <returns> the string converted into Beta coding
		/// </returns>
		internal virtual System.String convertString(System.String bwString)
		{
			int strLen = bwString.Length, strPos;
			System.String betaString = new System.String("".ToCharArray());
			char currChar, prevChar = ' ';
			
			
			
			MessageHandler.clearMsgQueue();
			
			
			
			for (strPos = 0; strPos < strLen; strPos++)
			{
				
				currChar = bwString[strPos];
				
				betaString += convertChar(prevChar, currChar);
				
				prevChar = currChar;
				
				MessageHandler.enqueueMsg(" at pos. " + (strPos + 1).ToString() + "\n");
			}
			
			
			
			return betaString;
		}
		
		
		
		private System.String convertChar(char prevBwChar, char bwChar)
		{
			
			System.String betaChar;
			
			char bwUpperChar = System.Char.ToUpper(bwChar);
			
			
			
			switch (bwChar)
			{
				
				
				case '|':  betaChar = "|"; break;
				
				
				case '?':  betaChar = "+"; break; // not sure
				
				
				
				
				case ',':  betaChar = "/"; break;
				
				
				case '<':  betaChar = "/+"; break;
				
				
				case '.':  betaChar = "\\"; break;
				
				
				case '>':  betaChar = "\\+"; break;
				
				
				case '/':  betaChar = "="; break;
				
				
				
				
				case 'v':  betaChar = ")"; break; // psili with kerning
				
				
				case '`':  betaChar = "("; break; // dasia with kerning
				
				
				case 'V': 
					
					if (prevBwChar == ' ')
					// maybe we should not rely that much on correct typesetting...
					{
						
						betaChar = "*)"; // psili before capital letter (no kerning)
					}
					else
					{
						
						betaChar = "'"; // apostrophe
					}
					
					break;
				
				
				case '~':  betaChar = "*("; break; // dasia before capital letter
				
				
				
				
				case ';':  betaChar = ")/"; break;
				
				
				case '[':  betaChar = "(/"; break;
				
				
				case '\'':  betaChar = ")\\"; break;
				
				
				case ']':  betaChar = "(\\"; break;
				
				
				case '=':  betaChar = ")="; break;
				
				
				case '-':  betaChar = "(="; break;
				
				
				
				
				case ':':  betaChar = "*)/"; break;
				
				
				case '{':  betaChar = "*(/"; break;
				
				
				case '"':  betaChar = "*)\\"; break;
				
				
				case '}':  betaChar = "*(\\"; break;
				
				
				case '+':  betaChar = "*)="; break;
				
				
				case '_':  betaChar = "*(="; break;
				
				
				
				
				case '\\':  betaChar = ":"; break; // Greek semicolon (ano teleia)
				
				
				case 'Ç':  betaChar = ":"; break; // [199]
				
				
				case '*':  betaChar = ";"; break;
				
				
				case 'È':  betaChar = ";"; break; // Greek question mark [200]
				
				
				case '(':  betaChar = ","; break;
				
				
				case 'Ã':  betaChar = ","; break; // [195]
				
				
				case ')':  betaChar = "."; break;
				
				
				case 'Å':  betaChar = "."; break; // period [197]
				
				
				case '@':  betaChar = "["; break;
				
				
				case 'Î':  betaChar = "["; break; // [206] 
				
				
				case '#':  betaChar = "]"; break;
				
				
				case 'Ð':  betaChar = "]"; break; // [208]
				
				
				case '$':  betaChar = "["; break; // should be "(", but round brackets are not possible
				
				
				case '¿':  betaChar = "["; break; // "(" [191]
				
				
				case '%':  betaChar = "]"; break; // ")"
				
				
				case 'À':  betaChar = "["; break; // ")" [192]
				
				
				
				
				case '^':  betaChar = "•"; break; // "*" not possible
				
				
				case 'Á':  betaChar = "•"; break;
				
				
				case '&':  betaChar = "-"; break;
				
				
				case 'Ä':  betaChar = "-"; break;
				
				
				case '!':  betaChar = "†"; break; // "+" not possible
				
				
				case 'Â':  betaChar = "†"; break; // "+" [194]
				
				
				case '¹':  betaChar = "\""; break; // [185]
				
				
				case '¸':  betaChar = "!"; break; // [184]
				
				
				case 'º':  betaChar = "#"; break; // but could be dangerous, since # is metacharacter, too (#3=koppa, #5=sampi)
				
				
				case '»':  betaChar = "$"; break; // [187] but have seen $ as metacharacter (for existence of varia lectio?)
				
				
				case '¼':  betaChar = "%"; break; // [188] 
				
				
				case '½':  betaChar = "&"; break; // [189]
				
				
				case '¾':  betaChar = "'"; break; // [190]
				
				
				
				
				case 'É':  betaChar = "<"; break; // [201]
				
				
				case 'Ë':  betaChar = ">"; break; // [203]
				
				
				case 'Ì':  betaChar = "?"; break; // [204]
				
				
				case 'Í':  betaChar = "@"; break; // [205]
				
				
				case 'Ñ':  betaChar = "^"; break; // [209]
				
				
				case 'Ò':  betaChar = "_"; break; // [210]
				
				
				case 'Ó':  betaChar = "`"; break; // [211]
				
				
				case 'Ô':  betaChar = "{"; break; // [212]
				
				
				case 'Ö':  betaChar = "}"; break; // [214]
				
				
				case '×':  betaChar = "~"; break; // [215]
				
				
				
				
				case UC.HORIZONTAL_TABULATION: 
				case UC.LINE_FEED: 
				case UC.VERTICAL_TABULATION: 
				case UC.FORM_FEED: 
				case UC.CARRIAGE_RETURN: 
				case UC.SPACE:  betaChar = bwChar.ToString(); break;
				
				
				
				
				default: 
					
					if (bwChar > 127)
					// other characters out of US-ASCII range cannot be converted
					{
						
						betaChar = "?"; break;
					}
					else if ((bwChar >= '0') && (bwChar <= '9'))
					// digits are digits are digits
					{
						
						betaChar = bwChar.ToString();
					}
					else
					{
						
						switch (bwUpperChar)
						{
							
							
							case 'C':  betaChar = "X"; break;
							
							
							case 'X':  betaChar = "C"; break;
							
							
							default:  betaChar = bwUpperChar.ToString();
								break;
							
						}
						
						if (System.Char.IsUpper(bwChar) && (prevBwChar == ' '))
						{
							
							betaChar = "*" + betaChar;
						}
						// in all other cases there should have been an accent etc. with "*" prefixed
					}
					break;
				
			}
			
			return betaChar;
		}
	}
}