namespace greekconverter
{
	using System;
	
	/// <summary> Some constants and functions describing the available conversions.
	/// *
	/// </summary>
	/// <version>  06-Mar-2005
	/// </version>
	/// <author>   Michael Neuhold
	/// </author>
	
	public class GreekConvCaps
	{
		public static System.String ConvModes
		{
			// list available conversions and their numeric codes:
			
			get
			{
				return "Unicode -> Betacode:    " + UNICODE_BETACODE + "\nUnicode -> ASCII:       " + UNICODE_ASCII + "\nUnicode -> HTML:        " + UNICODE_HTML + "\nUnicode -> GreekKeys:   " + UNICODE_GREEKKEYS + "\nUnicode -> Names:       " + UNICODE_NAMES + "\nBetacode -> Unicode:    " + BETACODE_UNICODE + "\nBetacode -> SPIonic:    " + BETACODE_SPIONIC + "\nASCII -> Betacode:      " + ASCII_BETACODE + "\nBibleworks -> Unicode:  " + BIBLEWORKS_UNICODE + "\nBibleworks -> Betacode: " + BIBLEWORKS_BETACODE + "\nGreekKeys -> Unicode:   " + GREEKKEYS_UNICODE + "\nUnicode -> Decomposed:  " + UNICODE_DECOMPOSE + "\nUnicode -> Precomposed: " + UNICODE_PRECOMPOSE;
			}
			
		}
		// symbolic constants
		// encodings:
		public const int UNICODE = 1;
		public const int BETACODE = 2;
		public const int HTML = 3;
		public const int GREEKKEYS = 4;
		public const int BIBLEWORKS = 5;
		public const int ASCII = 6;
		public const int NAMES = 7;
		public const int SPIONIC = 8;
		public const int DECOMPOSE = 1;
		public const int PRECOMPOSE = 2;
		public const int MLT = 1000; // multiplier
		public const int MODMLT = 10; // modifier multiplier
		// supported conversions:
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "UNICODE_BETACODE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int UNICODE_BETACODE = UNICODE * MLT + BETACODE;
		// 1002
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "UNICODE_ASCII " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int UNICODE_ASCII = UNICODE * MLT + ASCII;
		// 1006
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "UNICODE_HTML " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int UNICODE_HTML = UNICODE * MLT + HTML;
		// 1003
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "UNICODE_GREEKKEYS " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int UNICODE_GREEKKEYS = UNICODE * MLT + GREEKKEYS;
		// 1004
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "UNICODE_NAMES " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int UNICODE_NAMES = UNICODE * MLT + NAMES;
		// 1007
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "BETACODE_UNICODE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int BETACODE_UNICODE = BETACODE * MLT + UNICODE;
		// 2001
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "BETACODE_SPIONIC " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int BETACODE_SPIONIC = BETACODE * MLT + SPIONIC;
		// 2008
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "ASCII_BETACODE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int ASCII_BETACODE = ASCII * MLT + BETACODE;
		// 6001
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "BIBLEWORKS_UNICODE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int BIBLEWORKS_UNICODE = BIBLEWORKS * MLT + UNICODE;
		// 5001
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "BIBLEWORKS_BETACODE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int BIBLEWORKS_BETACODE = BIBLEWORKS * MLT + BETACODE;
		// 5002
		//public static final int BIBLEWORKS_GREEKKEYS = BIBLEWORKS*MLT + GREEKKEYS;  // 5004
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "GREEKKEYS_UNICODE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int GREEKKEYS_UNICODE = GREEKKEYS * MLT + UNICODE;
		// 4001
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "UNICODE_DECOMPOSE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int UNICODE_DECOMPOSE = UNICODE * MLT + UNICODE + DECOMPOSE * MODMLT;
		// 1011
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "UNICODE_PRECOMPOSE " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly int UNICODE_PRECOMPOSE = UNICODE * MLT + UNICODE + PRECOMPOSE * MODMLT;
		// 1021
		// option types:
		public const int HTML_ENTITY_MODE = 1;
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case VersionInfo.CLASSINFO_VERSION_DATE:  info = "06-Mar-2005"; break;
				
				case VersionInfo.CLASSINFO_PROG_DESCR:  info = "Contains constants and functions describing the available conversions"; break;
				
				case VersionInfo.CLASSINFO_DEVELOPER:  info = VersionInfo.DEVELOPER_MN; break;
				
				default:  info = "Ut desint vires, tamen est laudanda voluntas.";
					break;
				
			}
			return info;
		}
		
		// extract conversion input type from conversion mode (i.e. ASCII from ASCII_BETACODE):
		public static int getConvInput(int cvMode)
		{
			return (int) cvMode / MLT;
		}
		// extract conversion output type from conversion mode (i.e. BETACODE from ASCII_BETACODE):
		public static int getConvOutput(int cvMode)
		{
			return (cvMode % MLT) % MODMLT;
		}
		// extract conversion option from conversion mode (i.e. HTML_ENTITY_MODE from ?)
		public static int getConvOpts(int cvMode)
		{
			return (cvMode % MLT) / MODMLT;
		}
		
	}
}