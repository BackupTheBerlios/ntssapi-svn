namespace greekconverter
{
	using System;
	
	public class VersionInfo
	{
		// public constants:
		public const System.String DEVELOPER_MN = "Michael Neuhold <homepage.neuhold@aon.at>";
		public const int CLASSINFO_VERSION_DATE = 0;
		public const int CLASSINFO_PROG_DESCR = 1;
		public const int CLASSINFO_DEVELOPER = 2;
		
		// private stuff:
		private static int currVersionDate;
		private static int maxVersionDate = 0;
		private static System.String currVersionDateString;
		private static System.String maxVersionDateString;
		private static System.String[] months = new System.String[]{"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
		// 12345678901234567890123456789012345678901234567890123456789012345678901234567890
		private const System.String blanks = "                                                                                ";
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case CLASSINFO_VERSION_DATE:  info = "21-Jun-2004"; break;
				
				case CLASSINFO_PROG_DESCR:  info = "Prints out version info"; break;
				
				case CLASSINFO_DEVELOPER:  info = DEVELOPER_MN; break;
				
				default:  info = "Medio tutissimus ibis.";
					break;
				
			}
			return info;
		}
		
		private static int getNumericDate(System.String date)
		{
			// date must be in format "dd-Mon-yyyy"
			int year = System.Int32.Parse(date.Substring(7));
			int mon;
			System.String month = date.Substring(3, (6) - (3));
			int day = System.Int32.Parse(date.Substring(0, (2) - (0)));
			
			for (mon = 0; mon < 12; mon++)
			{
				if (months[mon].ToUpper().Equals(month.ToUpper()))
					break;
			}
			return day + (mon + 1) * 100 + year * 10000;
		}
		
		private static System.String pad(System.String s, int len)
		{
			return s + blanks.Substring(0, (len - s.Length) - (0));
		}
		
		private static void  checkDate(System.String cname)
		{
			System.Console.Out.WriteLine(pad(cname, 25) + ": " + currVersionDateString);
			currVersionDate = getNumericDate(currVersionDateString);
			if (currVersionDate > maxVersionDate)
			{
				maxVersionDate = currVersionDate;
				maxVersionDateString = currVersionDateString;
			}
		}
		
		[STAThread]
		public static void  Main(System.String[] args)
		{
			int infotype = 0;
			/*
			// The idea is to make the other types of class info available, but this requires
			// more work (rewrite of checkDate). I have no time for it now.
			
			if( args.length > 0 )
			{
			infotype = (Integer.valueOf( args[0] ) ).intValue();
			}
			*/
			System.Console.Out.WriteLine("\n- = g r e e k c o n v e r t e r = -");
			System.Console.Out.WriteLine("Package for conversion between various representations of accented Greek");
			System.Console.Out.WriteLine("Written and currently maintained by " + DEVELOPER_MN);
			
			System.Console.Out.WriteLine("\nConversion classes:\n===================");
			
			currVersionDateString = AsciiToBetacode.getClassInfo(infotype);
			checkDate("AsciiToBetacode");
			
			currVersionDateString = BetacodeToSPIonic.getClassInfo(infotype);
			checkDate("BetacodeToSPIonic");
			
			currVersionDateString = BetacodeToUnicode.getClassInfo(infotype);
			checkDate("BetacodeToUnicode");
			
			currVersionDateString = BibleWorksToBetacode.getClassInfo(infotype);
			checkDate("BibleWorksToBetacode");
			
			currVersionDateString = BibleWorksToUnicode.getClassInfo(infotype);
			checkDate("BibleWorksToUnicode");
			
			currVersionDateString = GreekKeysToUnicode.getClassInfo(infotype);
			checkDate("GreekKeysToUnicode");
			
			currVersionDateString = UnicodeDecompose.getClassInfo(infotype);
			checkDate("UnicodeDecompose");
			
			currVersionDateString = UnicodePrecompose.getClassInfo(infotype);
			checkDate("UnicodePrecompose");
			
			currVersionDateString = UnicodeToAscii.getClassInfo(infotype);
			checkDate("UnicodeToAscii");
			
			currVersionDateString = UnicodeToBetacode.getClassInfo(infotype);
			checkDate("UnicodeToBetacode");
			
			currVersionDateString = UnicodeToGreekKeys.getClassInfo(infotype);
			checkDate("UnicodeToGreekKeys");
			
			currVersionDateString = UnicodeToHtml.getClassInfo(infotype);
			checkDate("UnicodeToHtml");
			
			currVersionDateString = UnicodeToName.getClassInfo(infotype);
			checkDate("UnicodeToName");
			
			System.Console.Out.WriteLine("\nWrapper classes:\n================");
			
			currVersionDateString = GreekConverter.getClassInfo(infotype);
			checkDate("GreekConverter");
			
			currVersionDateString = GreekFileConverter.getClassInfo(infotype);
			checkDate("GreekFileConverter");
			
			currVersionDateString = Nereus.getClassInfo(infotype);
			checkDate("Nereus");
			
			System.Console.Out.WriteLine("\nHelper classes:\n===============");
			
			currVersionDateString = CodeCharts.getClassInfo(infotype);
			checkDate("CodeCharts");
			
			currVersionDateString = DynShortArray.getClassInfo(infotype);
			checkDate("DynShortArray");
			
			currVersionDateString = GreekConvCaps.getClassInfo(infotype);
			checkDate("GreekConvCaps");
			
			currVersionDateString = MessageHandler.getClassInfo(infotype);
			checkDate("MessageHandler");
			
			currVersionDateString = UC.getClassInfo(infotype);
			checkDate("UC");
			
			currVersionDateString = getClassInfo(infotype);
			checkDate("VersionInfo");
			
			System.Console.Out.WriteLine("\n---");
			System.Console.Out.WriteLine(pad("Latest version date", 25) + ": " + maxVersionDateString);
			System.Console.Out.WriteLine("---");
		}
	}
}