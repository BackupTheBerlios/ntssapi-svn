namespace greekconverter
{
	using System;
	
	/// <summary> (C) Michael Neuhold <michael.neuhold@aon.at>
	/// Version 0, startet 10-Oct-1999
	/// *
	/// </summary>
	/// <version>  23-Jun-2004
	/// </version>
	/// <author>   Michael Neuhold
	/// </author>
	
	public class GreekConverter
	{
		public GreekConverter()
		{
			InitBlock();
		}
		private void  InitBlock()
		{
			ascii2Beta = new AsciiToBetacode();
			beta2Uni = new BetacodeToUnicode();
			bw2Beta = new BibleWorksToBetacode();
			uni2Ascii = new UnicodeToAscii();
		}
		/// <summary> Returns the current message level. (For whoever might be interested in that information.)
		/// *
		/// </summary>
		/// <returns> the current message level
		/// </returns>
		/// <summary> Sets the message level of the class to the given value.  The parameter is simply passed
		/// to a private instance of class MessageHandler.
		/// *
		/// </summary>
		/// <param name="level">the message level, valid values range between MessageHandler.MSGLVL_NOMSG
		/// and MessageHandler.MSGLVL_DEBUGMSG
		/// </param>
		virtual public int MessageLevel
		{
			get
			{
				return MessageHandler.MsgLevel;
			}
			
			set
			{
				MessageHandler.MsgLevel = value;
				MessageHandler.enqueueMsg("MessageLevel set to " + value, MessageHandler.MSGLVL_STATUSMSG);
			}
			
		}
		virtual public int HTMLMode
		{
			set
			{
				UnicodeToHtml.Mode = value;
			}
			
		}
		// error messaging:
		private System.String lastErrMsg;
		// conversions:
		//UPGRADE_NOTE: Die Initialisierung von "ascii2Beta" wurde nach method 'InitBlock' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private AsciiToBetacode ascii2Beta;
		//UPGRADE_NOTE: Die Initialisierung von "beta2Uni" wurde nach method 'InitBlock' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private BetacodeToUnicode beta2Uni;
		//UPGRADE_NOTE: Die Initialisierung von "bw2Beta" wurde nach method 'InitBlock' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private BibleWorksToBetacode bw2Beta;
		//UPGRADE_NOTE: Die Initialisierung von "uni2Ascii" wurde nach method 'InitBlock' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private UnicodeToAscii uni2Ascii;
		
		/// <summary>************************
		/// </summary>
		/* generic methods          */
		/// <summary>************************
		/// </summary>
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case VersionInfo.CLASSINFO_VERSION_DATE:  info = "23-Jun-2004"; break;
				
				case VersionInfo.CLASSINFO_PROG_DESCR:  info = "Wrapper class for the conversion classes"; break;
				
				case VersionInfo.CLASSINFO_DEVELOPER:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Ut desint vires, tamen est laudanda voluntas.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Prints out the message queue to the error console.
		/// *
		/// </summary>
		/// <param name="infoHeader">information to be printed before the contents of the message queue
		/// </param>
		/// <param name="infoFooter">information to be printed after the contents of the message queue
		/// </param>
		public virtual void  printMessageQueue(System.String infoHeader, System.String infoFooter)
		{
			MessageHandler.printMsgQueue(infoHeader, infoFooter);
		}
		
		
		
		/// <summary>************************
		/// </summary>
		/* Unicode -> Unicode       */
		/// <summary>************************
		/// </summary>
		public virtual System.String decomposeUnicode(System.String uniString)
		{
			return UnicodeDecompose.normalizeString(uniString);
		}
		
		public virtual System.String precomposeUnicode(System.String uniString)
		{
			return UnicodePrecompose.precomposeStringFirstPass(uniString);
		}
		
		/// <summary>************************
		/// </summary>
		/* Unicode -> Betacode      */
		/// <summary>************************
		/// </summary>
		
		/// <summary> Converts a string consisting of Greek Unicode text into Beta coding.
		/// <p>
		/// The following restrictions apply to this procedure at the moment:
		/// <ul>
		/// <li>&lt;LETTER&gt;_PROSGEGRAMMENI is converted as if it were &lt;LETTER&gt; + IOTA</li>
		/// <li>&lt;LETTER&gt;_TONOS is not converted as &lt;LETTER&gt;_OXIA - wether this is correct I do
		/// not know for sure</li>
		/// <li>standalone accents and breathings are converted with a preceding space, so that
		/// they are separated from the preceding letter; e.g. ALPHA + DASIA_OXIA -> "a (/" (not
		/// "a(/" which would be equal to ALPHA_DASIA_OXIA)</li>
		/// <li>&lt;LETTER&gt;_SYMBOL, &lt;LETTER&gt;_VRACHY and &lt;LETTER&gt;_MACRON are converted
		/// as &lt;LETTER&gt;</li>
		/// <li>since the seven extra Coptic letters are unique in Unicode they are converted as
		/// well (except Bohairic chai for which I do not know the Betacode character)</li>
		/// </ul>
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode string
		/// </param>
		/// <returns>  the string converted into Beta coding
		/// </returns>
		public virtual System.String convertStringUniToBeta(System.String uniString)
		{
			return UnicodeToBetacode.convertString(uniString);
		}
		
		/// <summary>************************
		/// </summary>
		/* Unicode -> ASCII         */
		/// <summary>************************
		/// </summary>
		
		/// <summary> Converts a String containing Unicode characters into ASCII.
		/// *
		/// </summary>
		/// <param name="uniText">the Unicode text to be converted
		/// </param>
		/// <returns>  ASCII representation with all diacriticals stripped
		/// </returns>
		public virtual System.String convertStringUniToAscii(System.String uniString)
		{
			return uni2Ascii.convertString(uniString);
		}
		
		/// <summary>*************************
		/// </summary>
		/* Unicode -> HTML-Entities */
		/// <summary>*************************
		/// </summary>
		
		/// <summary> Converts a Unicode string into a string consisting of HTML entities.
		/// Since version 4.0 HTML uses the Universal Character Set (UCS) which is based on the Unicode
		/// system. Since then any Unicode character can be noted like <code>&amp;#252;</code> (decimal)
		/// or <code>&amp;#xFC;</code> (hexadecimal). Alternatively you can tell the browser how to interpret the
		/// </summary>
		/// <returns>  the converted text in HTML format
		/// </returns>
		
		public virtual System.String convertStringUniToHtml(System.String uniString)
		{
			return UnicodeToHtml.convertString(uniString);
		}
		
		
		/// <summary>************************
		/// </summary>
		/* Unicode -> SMK GreekKeys */
		/// <summary>************************
		/// </summary>
		
		/// <summary> Converts a String consisting of Unicode characters into SMK GreekKeys coding.
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode text
		/// </param>
		/// <returns>  the text converted into GreekKeys. Note that the return type is
		/// <strong>not a string</strong>, but a short array. Use of the String class is
		/// not possible because it tries to convert to and fro Unicode, but GreekKeys
		/// is an unknown coding to Java, therefore the values for the characters must
		/// remain untouched. The array is padded with trailing nulls.
		/// </returns>
		public virtual short[] convertStringUniToGreekKeys(System.String uniString)
		{
			return UnicodeToGreekKeys.convertString(uniString);
		}
		
		/// <summary>************************
		/// </summary>
		/* SMK GreekKeys -> Unicode */
		/// <summary>************************
		/// </summary>
		/// <summary>/**
		/// Converts a short array with GreekKeys "characters" into Unicode.
		/// *
		/// </summary>
		/// <param name="gkString">the GreekKeys text array. The end of the text has
		/// to be marked with a null value.
		/// </param>
		/// <returns>  the text converted into Unicode
		/// </returns>
		public virtual System.String convertStringGreekKeysToUni(short[] gkString)
		{
			return GreekKeysToUnicode.convertString(gkString);
		}
		
		/// <summary>************************
		/// </summary>
		/* BibleWorks -> Betacode   */
		/// <summary>************************
		/// </summary>
		
		/// <summary> Converts text with BibleWorks' coding into Beta coding. Which you can convert
		/// into Unicode then.
		/// *
		/// </summary>
		/// <param name="bwString">the string in BibleWorks' Greek coding
		/// </param>
		/// <returns> the string converted into Beta coding
		/// </returns>
		public virtual System.String convertStringBwToBeta(System.String bwString)
		{
			return bw2Beta.convertString(bwString);
		}
		
		/// <summary>************************
		/// </summary>
		/*  BibleWorks -> Unicode   */
		/// <summary>************************
		/// </summary>
		
		/// <summary> Converts text with BibleWorks' coding into Unicode.
		/// *
		/// </summary>
		/// <param name="bwString">the string in BibleWorks' Greek coding
		/// </param>
		/// <returns> the string converted into Unicode
		/// </returns>
		public virtual System.String convertStringBwToUni(System.String bwString)
		{
			return BibleWorksToUnicode.convertString(bwString);
		}
		
		/// <summary>************************
		/// </summary>
		/* Betacode -> Unicode      */
		/// <summary>************************
		/// </summary>
		
		/// <summary> Converts a Beta coded string into Unicode.
		/// </summary>
		public virtual System.String convertStringBetaToUni(System.String betaString)
		{
			return beta2Uni.convertString(betaString);
		}
		
		/// <summary>************************
		/// </summary>
		/* Betacode -> SPIonic      */
		/// <summary>************************
		/// </summary>
		
		/// <summary> Converts a Beta coded string into the key mapping of SPIonic/Sgreek.
		/// </summary>
		public virtual System.String convertStringBetaToSp(System.String betaString)
		{
			return BetacodeToSPIonic.convertString(betaString);
		}
		
		/// <summary>************************
		/// </summary>
		/* Ascii -> Betacode        */
		/// <summary>************************
		/// </summary>
		
		/// <summary> Converts an ASCII string containing Greek text into Betacode.
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode string
		/// </param>
		/// <returns>  the string converted into Beta coding
		/// </returns>
		
		public virtual System.String convertStringAsciiToBeta(System.String uniString)
		{
			return ascii2Beta.convertString(uniString);
		}
		
		/// <summary>************************
		/// </summary>
		/* Unicode -> Humanreadable */
		/// <summary>************************
		/// </summary>
		
		/// <summary> Converts a String consisting of Unicode characters into a string consisting of human
		/// readable descriptions of the characters, each character on a line of its own.
		/// *
		/// This is intended mainly for debugging purposes.
		/// If a character is not within range an "out of range" message is launched,
		/// if a character is not defined within the range a "not defined" is reported.
		/// *
		/// </summary>
		/// <param name="uniString">the Unicode string
		/// </param>
		/// <returns>  the human readable list of characters the string consists of
		/// </returns>
		public virtual System.String convertStringUniToName(System.String uniString)
		{
			return UnicodeToName.convertString(uniString);
		}
	}
}