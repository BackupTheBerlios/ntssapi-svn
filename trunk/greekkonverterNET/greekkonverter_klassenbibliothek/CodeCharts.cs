namespace greekconverter
{
	using System;
	
	public class CodeCharts
	{
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "06-Mar-2002"; break;
				
				case 1:  info = "Prints code charts and name charts of the Unicode sections \"Greek\" and \"Greek Extended\" to the Java console"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Panta rhei.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Prints code charts and name charts of the Unicode sections "Greek" and "Greek Extended"
		/// to the Java console.
		/// </summary>
		public static void  printUniDesc()
		{
			char uniChar;
			System.Console.Out.WriteLine("U n i c o d e   c o d e   c h a r t s");
			System.Console.Out.WriteLine("Greek, range U+0370 to U+03FF:");
			System.Console.Out.WriteLine("------------------------------------------------------");
			System.Console.Out.WriteLine("   037   038   039   03A   03B   03C   03D   03E   03F");
			System.Console.Out.WriteLine("0              I/+   *P    U/+   P     BS    #5    KS");
			System.Console.Out.WriteLine("1              *A    *R    A     R     QS          RS");
			System.Console.Out.WriteLine("2              *B          B     J     *UH   *s    SS");
			System.Console.Out.WriteLine("3              *G    *S    G     S     */UH  s     jot");
			System.Console.Out.WriteLine("4  num   /     *D    *T    D     T     *+UH  *f");
			System.Console.Out.WriteLine("5  lnum  /+    *E    *U    E     U     FS    f");
			System.Console.Out.WriteLine("6        */A   *Z    *F    Z     F     PS    *chai");
			System.Console.Out.WriteLine("7        :     *H    *X    H     X           chai");
			System.Console.Out.WriteLine("8        */E   *Q    *Y    Q     Y           *h");
			System.Console.Out.WriteLine("9        */H   *I    *W    I     W           h");
			System.Console.Out.WriteLine("A  |     */I   *K    *+I   K     I+    st.  *j");
			System.Console.Out.WriteLine("B              *L    *+U   L     U+          j");
			System.Console.Out.WriteLine("C        */O   *M    A/    M     O/    W     *g");
			System.Console.Out.WriteLine("D              *N    E/    N     U/          g");
			System.Console.Out.WriteLine("E  ?     */U   *C    H/    C     W/    #3    *t");
			System.Console.Out.WriteLine("F        */W   *O    I/    O                 t");
			System.Console.Out.WriteLine("BS = beta symbol etc., UH = ypsilon with hook, num = numeral sign, lnum = lower numeral sign,");
			System.Console.Out.WriteLine(" : = ano telia, ? = question mark, st. = stigma");
			System.Console.Out.WriteLine("--");
			System.Console.Out.WriteLine("Greek Extended, range U+1F00 to U+1FFF:");
			System.Console.Out.WriteLine("-----------------------------------------------------------------------------------------------------");
			System.Console.Out.WriteLine("   1F0   1F1   1F2   1F3   1F4   1F5   1F6   1F7   1F8    1F9    1FA    1FB     1FC   1FD   1FE   1FF");
			System.Console.Out.WriteLine("0  A     E)    H)    I)    O)    U)    W)    A\\    A)|    H)|    W)|    A'      =     I'    U'");
			System.Console.Out.WriteLine("1  A(    E(    H(    I(    O(    U(    W(    A/    A(|    H(|    W(|    A-      =+    I-    U-");
			System.Console.Out.WriteLine("2  A)\\   E)\\   H)\\   I)\\   O)\\   U)\\   W)\\   E\\    A)\\|   H)\\|   W)\\|   A\\|     H\\|   I\\+   U\\+   W\\|");
			System.Console.Out.WriteLine("3  A(\\   E(\\   H(\\   I(\\   O(\\   U(\\   W(\\   E\\    A(\\|   H(\\|   W(\\|   A|      H|    I/+   U/+   W|");
			System.Console.Out.WriteLine("4  A)/   E)/   H)/   I)/   O)/   U)/   W)/   H\\    A)/|   H)/|   W)/|   A/|     H/|         R)    W/|");
			System.Console.Out.WriteLine("5  A(/   E(/   H(/   I(/   O(/   U(/   W(/   H/    A(/|   H(/|   W(/|                       R(");
			System.Console.Out.WriteLine("6  A)=         H)=   I)=         U)=   W)=   I\\    A)=|   H)=|   W)=|   A=      H=    I=    U=    W=");
			System.Console.Out.WriteLine("7  A(=         H(=   I(=         U(=   W(=   I/    A(=|   H(=|   W(=|   A=|     H=|   I=+   U=+   W=|");
			System.Console.Out.WriteLine("8  *)A   *)E   *)H   *)I   *)O         *)W   O\\    *)|A   *)|H   *)|W   *'A     *\\E   *'I   *'U   *\\O");
			System.Console.Out.WriteLine("9  *(A   *(E   *(H   *(I   *(O   *(U   *(W   O/    *(|A   *(|H   *(|W   *-A     */E   *-I   *-U   */O");
			System.Console.Out.WriteLine("A  *)\\A  *)\\E  *)\\H  *)\\I  *)\\O        *)\\W  U\\    *)\\|A  *)\\|H  *)\\|W  *\\A     *\\H   *\\I   *\\U   *\\W");
			System.Console.Out.WriteLine("B  *(\\A  *(\\E  *(\\H  *(\\I  *(\\O  *(\\U  *(\\W  U/    *(\\|A  *(\\|H  *(\\|W  */A     */H   */I   */U   */W");
			System.Console.Out.WriteLine("C  *)/A  *)/E  *)/H  *)/I  *)/O        *)/W  W\\    *)/|A  *)/|H  *)/|W  *|A     *|H         *(R   *|W");
			System.Console.Out.WriteLine("D  *(/A  *(/E  *(/H  *(/I  *(/O  *(/U  *(/W  W/    *(/|A  *(/|H  *(/|W  koronis )\\    (\\    \\+    /");
			System.Console.Out.WriteLine("E  *)=A        *)=H  *)=I              *)=W        *)=|A  *)=|H  *)=|W  i-adsrc )/    (/    /+    (");
			System.Console.Out.WriteLine("F  *(=A        *(=H  *(=I        *(=U  *(=W        *(=|A  *(=|H  *(=|W  )       )=    (=    \\");
			System.Console.Out.WriteLine("' = vrachy (short vowel sign), - = makron (long vowel sign)");
			System.Console.Out.WriteLine("--");
			System.Console.Out.WriteLine("N a m e   c h a r t s");
			System.Console.Out.WriteLine("The official description of the Unicode characters uses the following Greek terms:");
			System.Console.Out.WriteLine("TERM            BETA CODE        MEANING");
			System.Console.Out.WriteLine("-----------------------------------------------------------------");
			System.Console.Out.WriteLine("ANO TELEIA      a)/nw telei/a    Greek semicolon");
			System.Console.Out.WriteLine("YPOGEGRAMMENI   (upogegramme/nh  iota subscriptum");
			System.Console.Out.WriteLine("PROSGEGRAMMENI  prosgegramme/nh  iota adscriptum");
			System.Console.Out.WriteLine("TONOS           to/nos           stress(ing)");
			System.Console.Out.WriteLine("DIALYTIKA       dialutika/       diaeresis, trema");
			System.Console.Out.WriteLine("PSILI           yilh/            spiritus lenis, smooth breathing");
			System.Console.Out.WriteLine("DASIA           dasei/a          spiritus asper, rough breathing");
			System.Console.Out.WriteLine("OXIA            o)cei/a          acute accent");
			System.Console.Out.WriteLine("VARIA           barei/a          grave accent");
			System.Console.Out.WriteLine("PERISPOMENI     perispwme/nh     circumflex accent");
			System.Console.Out.WriteLine("VRACHY          braxy/           sign for short vowel }  u  -");
			System.Console.Out.WriteLine("MACRON          makro/n          sign for long vowel  }  X  X");
			System.Console.Out.WriteLine("------------------------------------------------------------------");
			System.Console.Out.WriteLine("Greek:");
			System.Console.Out.WriteLine("------");
			for (uniChar = UC.STDGRK_LOWER_BOUND; uniChar <= UC.STDGRK_UPPER_BOUND; uniChar++)
			{
				System.Console.Out.WriteLine(UnicodeToName.convertChar(uniChar));
			}
			System.Console.Out.WriteLine("--");
			System.Console.Out.WriteLine("Greek Extended:");
			System.Console.Out.WriteLine("---------------");
			
			for (uniChar = UC.EXTGRK_LOWER_BOUND; uniChar <= UC.EXTGRK_UPPER_BOUND; uniChar++)
			{
				System.Console.Out.WriteLine(UnicodeToName.convertChar(uniChar));
			}
			System.Console.Out.WriteLine("--");
		}
		
		/// <summary> Prints code chart of SMK GreekKeys to the Java console.
		/// </summary>
		public static void  printGreekKeysDesc()
		{
			System.Console.Out.WriteLine("S M K   G r e e k K e y s  c o d e   c h a r t");
			System.Console.Out.WriteLine("----------------------------------------------");
			System.Console.Out.WriteLine("Taken from the Windows version of the font Athenian and the pixel font used by DisplayGreek");
			System.Console.Out.WriteLine("   002   003   004   005   006   007   008   009   00A   00B   00C   00D   00E   00F");
			System.Console.Out.WriteLine("0        0     U/+   *P    dot   P     /     A)/         H=)   H)\\|  W/|   I)/   U(=");
			System.Console.Out.WriteLine("1  SC    1     *A    #5    A     #3    \\     A(/   E/    H)    H(\\|  W\\|   I(/   O/ ");
			System.Console.Out.WriteLine("2  \"     2     *B    *R    B     R     =     A)\\   E\\    H(    H)=|  W=|   I)\\   O\\");
			System.Console.Out.WriteLine("3  U+    3     *Y    *S    Y     S     )     A(\\   U\\+   H)/   H(=|  W)|   I(\\   I+ ");
			System.Console.Out.WriteLine("4  [?]   4     *D    *T    D     T     (     A)=   E)    H(/   W|    W(|   I)=   O)");
			System.Console.Out.WriteLine("5  *SC   5     *E    *U    E     U     )/    A(+   E(    H)\\   W/    W)/|  I(=   O(");
			System.Console.Out.WriteLine("6  A|    6     *F    *W    F     W     (/    A/|   E)/   H(\\   W\\    W(/|  U/    O)/");
			System.Console.Out.WriteLine("7  )     7     *G    V     G     J     )\\    A\\|   E(/   H)=   W=    W)\\|  U\\    O(/");
			System.Console.Out.WriteLine("8  -(    8     *H    *X    H     X     (\\    A=|   E)\\   H(=   W)    W(\\|  U=    O)\\");
			System.Console.Out.WriteLine("9  -)    9     *I    *Q    I     Q     )=    A)|   E(\\   H/|   W(    W)=|  U)    O(\\");
			System.Console.Out.WriteLine("A        :     *C    *Z    C     Z     (=    A(|   A(=|  H\\|   W)/   W(=|  U(    H|");
			System.Console.Out.WriteLine("B  |     ?     *K    [     K     {     A/    A)/|  ]]    H=|   W(/   I/    U)/   st.");
			System.Console.Out.WriteLine("C  ,     <     *L    -\\    L     -|    A\\    A(/|        H)|   W)\\   I\\    U(/   [?]");
			System.Console.Out.WriteLine("D  -     R(    *M    ]     M     }     A=    A)\\|  '     H(|   W(\\   I=    U)\\   I/+");
			System.Console.Out.WriteLine("E  .     >     *N          N     cr.   A)    A(\\|  H/    H)/|  W)=   I)    U(\\   I\\+");
			System.Console.Out.WriteLine("F  -/          *O    [[    O           A(    A)=|  H\\    H(/|  W(=   I(    U)=");
			System.Console.Out.WriteLine("characters preceded by a hyphen are to be taken literally:");
			System.Console.Out.WriteLine("  -( means brace (not rough breathing)");
			System.Console.Out.WriteLine("SC = c shaped sigma?, cr. crux, ' = vrachy (short vowel sign),");
			System.Console.Out.WriteLine(": = ano telia, ? = question mark, st. = stigma");
			System.Console.Out.WriteLine("NOTE: Athenian has A(=| on pos. 0xAA (170), DisplayGreek (more consequently) on pos. 0xA0 (160)");
			System.Console.Out.WriteLine("--");
		}
		
		/// <summary> Prints code chart of Beta Coding to the Java console.
		/// </summary>
		public static void  printBetaDesc()
		{
			System.Console.Out.WriteLine("B e t a   C o d i n g   c o d e   c h a r t");
			System.Console.Out.WriteLine("-------------------------------------------");
			System.Console.Out.WriteLine("Greek and Coptic letters:");
			System.Console.Out.WriteLine("alpha       A");
			System.Console.Out.WriteLine("beta        B");
			System.Console.Out.WriteLine("gamma       G");
			System.Console.Out.WriteLine("delta       D");
			System.Console.Out.WriteLine("epsilon     E");
			System.Console.Out.WriteLine("digamma     V");
			System.Console.Out.WriteLine("zeta        Z");
			System.Console.Out.WriteLine("eta         H");
			System.Console.Out.WriteLine("theta       Q");
			System.Console.Out.WriteLine("iota        I");
			System.Console.Out.WriteLine("kappa       K");
			System.Console.Out.WriteLine("lambda      L");
			System.Console.Out.WriteLine("my          M");
			System.Console.Out.WriteLine("ny          N");
			System.Console.Out.WriteLine("ksi         C");
			System.Console.Out.WriteLine("omikron     O");
			System.Console.Out.WriteLine("pi          P");
			System.Console.Out.WriteLine("qoppa       #3");
			System.Console.Out.WriteLine("rho         R");
			System.Console.Out.WriteLine("sigma       S");
			System.Console.Out.WriteLine("final sigma J");
			System.Console.Out.WriteLine("tau         T");
			System.Console.Out.WriteLine("ypsilon     U");
			System.Console.Out.WriteLine("phi         F");
			System.Console.Out.WriteLine("chi         X");
			System.Console.Out.WriteLine("psi         Y");
			System.Console.Out.WriteLine("omega       W");
			System.Console.Out.WriteLine("sampi       #5");
			System.Console.Out.WriteLine("Greek uppercase letters are preceded by * (e.g. *A)");
			System.Console.Out.WriteLine("--");
			System.Console.Out.WriteLine("Greek accents       Coptic letters");
			System.Console.Out.WriteLine("---------------------------------------");
			System.Console.Out.WriteLine("smooth breathing    shai             )");
			System.Console.Out.WriteLine("rough breathing     fai              (");
			System.Console.Out.WriteLine("acute accent        hori             /");
			System.Console.Out.WriteLine("grave accent        gangia           \\");
			System.Console.Out.WriteLine("circumflex accent   gima             =");
			System.Console.Out.WriteLine("iota subscript      chai             |");
			System.Console.Out.WriteLine("diaeresis           ti               +");
			System.Console.Out.WriteLine("--");
		}
	}
}