namespace greekconverter
{
	using System;
	
	/// <summary>************************
	/// </summary>
	/* Unicode -> SMK GreekKeys */
	/// <summary>************************
	/// </summary>
	
	public class UnicodeToGreekKeys
	{
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NOT_SUPPORTED " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		//UPGRADE_NOTE: Die Initialisierung von "NOT_SUPPORTED" wurde nach static method 'greekconverter.UnicodeToGreekKeys' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private static readonly short[] NOT_SUPPORTED;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "NOT_ASSIGNED " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		//UPGRADE_NOTE: Die Initialisierung von "NOT_ASSIGNED" wurde nach static method 'greekconverter.UnicodeToGreekKeys' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private static readonly short[] NOT_ASSIGNED;
		
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLookup " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly short[][][] tblLookup;
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblLatin1 " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly short[][] tblLatin1;
		// 0000-00FF
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblDiacritGreek " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly short[][] tblDiacritGreek;
		// 0300-036F
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblGreekExtended " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly short[][] tblGreekExtended;
		// 1F00-1FFF
		//UPGRADE_NOTE: "Final" wurde aus der Deklaration von "tblNotSupported " entfernt. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private static readonly short[][] tblNotSupported;
		
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "30-Aug-2002"; break;
				
				case 1:  info = "Converts Unicode into GreekKeys"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Dulce est desipere in loco.";
					break;
				
			}
			return info;
		}
		
		private static short[] createArray(int v0, int v1, int v2)
		{
			short[] arr;
			int len = 1;
			
			if (v1 > 0)
				len = 2;
			if (v2 > 0)
				len = 3;
			
			arr = new short[len];
			arr[0] = (short) v0;
			if (len > 1)
				arr[1] = (short) v1;
			if (len > 2)
				arr[2] = (short) v2;
			return arr;
		}
		
		/// <summary> Converts a String consisting of Unicode characters into SMK GreekKeys coding.
		/// <p>
		/// Greek Characters are converted at any rate. In cases where there is no fully
		/// equivalent GreekKeys character an approximation is used: e.g. VRACHY and
		/// MACRON are skipped, RHO-PSILI is rendered as RHO, in many cases DIALYTIKA
		/// is skipped etc.
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
		
		
		
		internal static short[] convertString(System.String uniString)
		{
			
			int strLen = uniString.Length, strPos, arrLen, arrPos = 0, i;
			
			short[] result = new short[3 * strLen + 1]; // a Unicode character can be rendered into
			
			// 1-3 GreekKeys chars, +1 for null termination
			
			short[] arr = null;
			
			
			
			MessageHandler.clearMsgQueue();
			
			
			
			for (strPos = 0; strPos < strLen; strPos++)
			{
				
				// get the byte array representing the SMK coding of the current Unicode
				
				// character and copy it byte-by-byte into result:
				
				arr = convertChar(uniString[strPos]);
				
				MessageHandler.enqueueMsg(" at pos. " + (strPos + 1).ToString() + "\n");
				
				arrLen = arr.Length;
				
				
				
				for (i = 0; i < arrLen; i++)
				{
					
					result[arrPos++] = arr[i];
				}
			}
			
			result[arrPos] = 0; // null termination
			
			return result;
		}
		
		
		
		/// <summary> Converts a Unicode character into its SMK GreekKeys representation.
		/// </summary>
		
		
		
		private static short[] convertChar(char uniChar)
		{
			
			System.Int32 i = uniChar;
			
			short[] arr = tblLookup[uniChar >> 8][uniChar & 255];
			
			
			
			if (arr == NOT_ASSIGNED)
			{
				
				MessageHandler.enqueueMsg("Not defined Unicode character: U+" + System.Convert.ToString(uniChar, 16), MessageHandler.MSGLVL_ERRORMSG);
			}
			else if (arr == NOT_SUPPORTED)
			{
				
				MessageHandler.enqueueMsg("Not supported character: U+" + System.Convert.ToString(uniChar, 16), MessageHandler.MSGLVL_ERRORMSG);
			}
			else
			{
				
				MessageHandler.enqueueMsg(UnicodeToName.convertChar(uniChar), MessageHandler.MSGLVL_DEBUGMSG);
			}
			
			return arr;
		}
		static UnicodeToGreekKeys()
		{
			NOT_SUPPORTED = createArray(63, 0, 0);
			NOT_ASSIGNED = createArray(63, 0, 0);
			tblLookup = new short[256][][];
			tblLatin1 = new short[256][];
			tblDiacritGreek = new short[256][];
			tblGreekExtended = new short[256][];
			tblNotSupported = new short[256][];
			{
				int i;
				for (i = 0; i < 256; i++)
				{
					tblLookup[i] = tblNotSupported;
					tblNotSupported[i] = NOT_SUPPORTED;
					tblLatin1[i] = NOT_SUPPORTED;
					tblDiacritGreek[i] = NOT_ASSIGNED;
					tblGreekExtended[i] = NOT_ASSIGNED;
				}
				for (i = 0; i < 112; i++)
				{
					tblDiacritGreek[i] = NOT_SUPPORTED; // no combining diacritics
				}
				tblLookup[0] = tblLatin1;
				tblLookup[3] = tblDiacritGreek;
				tblLookup[31] = tblGreekExtended;
				//
				// LATIN 1
				//
				// C0 controls and basic Latin
				tblLatin1[9] = createArray(9, 0, 0); // \t
				tblLatin1[10] = createArray(10, 0, 0); // \n
				tblLatin1[11] = createArray(11, 0, 0); // vtab
				tblLatin1[12] = createArray(12, 0, 0); // \f
				tblLatin1[13] = createArray(13, 0, 0); // \r
				tblLatin1[32] = createArray(32, 0, 0); // space
				tblLatin1[34] = createArray(34, 0, 0); // ?
				tblLatin1[39] = createArray(39, 0, 0); // '
				tblLatin1[40] = createArray(40, 0, 0); // (
				tblLatin1[41] = createArray(41, 0, 0); // )
				tblLatin1[44] = createArray(44, 0, 0); // ,
				tblLatin1[45] = createArray(45, 0, 0); // -
				tblLatin1[46] = createArray(46, 0, 0); // .
				tblLatin1[47] = createArray(47, 0, 0); // /
				tblLatin1[48] = createArray(48, 0, 0); // 0
				tblLatin1[49] = createArray(49, 0, 0); // 1
				tblLatin1[50] = createArray(50, 0, 0); // 2
				tblLatin1[51] = createArray(51, 0, 0); // 3
				tblLatin1[52] = createArray(52, 0, 0); // 4
				tblLatin1[53] = createArray(53, 0, 0); // 5
				tblLatin1[54] = createArray(54, 0, 0); // 6
				tblLatin1[55] = createArray(55, 0, 0); // 7
				tblLatin1[56] = createArray(56, 0, 0); // 8
				tblLatin1[57] = createArray(57, 0, 0); // 9
				tblLatin1[58] = createArray(58, 0, 0); // :
				tblLatin1[59] = createArray(59, 0, 0); // ;
				tblLatin1[60] = createArray(60, 0, 0); // <
				tblLatin1[62] = createArray(62, 0, 0); // >
				tblLatin1[63] = createArray(63, 0, 0); // ?
				tblLatin1[91] = createArray(91, 0, 0); // [
				tblLatin1[92] = createArray(92, 0, 0); // \
				tblLatin1[93] = createArray(93, 0, 0); // ]
				tblLatin1[123] = createArray(123, 0, 0); // {
				tblLatin1[124] = createArray(124, 0, 0); // |
				tblLatin1[125] = createArray(125, 0, 0); // }
				//
				// GREEK AND COPTIC
				//
				// Based on ISO 8859-7:
				tblDiacritGreek[116] = createArray(39, 0, 0); // dexia keraia = apostrophe
				tblDiacritGreek[117] = createArray(44, 0, 0); // aristeri (=low) keraia = comma
				tblDiacritGreek[122] = createArray(43, 0, 0); // iota subscript
				tblDiacritGreek[126] = createArray(59, 0, 0); // erotimatiko
				tblDiacritGreek[132] = createArray(128, 0, 0); // tonos
				tblDiacritGreek[133] = createArray(128, 0, 0); // dialytika-tonos -> tonos
				tblDiacritGreek[134] = createArray(128, 65, 0); // */A
				tblDiacritGreek[135] = createArray(58, 0, 0); // ano teleia
				tblDiacritGreek[136] = createArray(128, 69, 0); // */E
				tblDiacritGreek[137] = createArray(128, 72, 0); // */H
				tblDiacritGreek[138] = createArray(128, 73, 0); // */I
				tblDiacritGreek[140] = createArray(128, 79, 0); // */O
				tblDiacritGreek[142] = createArray(128, 85, 0); // */U
				tblDiacritGreek[143] = createArray(128, 86, 0); // */W
				tblDiacritGreek[144] = createArray(253, 0, 0); // I/+
				tblDiacritGreek[145] = createArray(65, 0, 0); // *A
				tblDiacritGreek[146] = createArray(66, 0, 0); // *B
				tblDiacritGreek[147] = createArray(71, 0, 0); // *G
				tblDiacritGreek[148] = createArray(68, 0, 0); // *D
				tblDiacritGreek[149] = createArray(69, 0, 0); // *E
				tblDiacritGreek[150] = createArray(90, 0, 0); // *Z
				tblDiacritGreek[151] = createArray(72, 0, 0); // *H
				tblDiacritGreek[152] = createArray(89, 0, 0); // *Q
				tblDiacritGreek[153] = createArray(73, 0, 0); // *I
				tblDiacritGreek[154] = createArray(75, 0, 0); // *K
				
				tblDiacritGreek[155] = createArray(76, 0, 0); // *L
				
				tblDiacritGreek[156] = createArray(77, 0, 0); // *M
				
				tblDiacritGreek[157] = createArray(78, 0, 0); // *N
				
				tblDiacritGreek[158] = createArray(74, 0, 0); // *C
				
				tblDiacritGreek[159] = createArray(79, 0, 0); // *O
				
				tblDiacritGreek[160] = createArray(80, 0, 0); // *P
				
				tblDiacritGreek[161] = createArray(82, 0, 0); // *R
				
				tblDiacritGreek[163] = createArray(83, 0, 0); // *S
				
				tblDiacritGreek[164] = createArray(84, 0, 0); // *T
				
				tblDiacritGreek[165] = createArray(85, 0, 0); // *U
				
				tblDiacritGreek[166] = createArray(70, 0, 0); // *F
				
				tblDiacritGreek[167] = createArray(88, 0, 0); // *X
				
				tblDiacritGreek[168] = createArray(67, 0, 0); // *Y (psi)
				
				tblDiacritGreek[169] = createArray(86, 0, 0); // *W
				
				tblDiacritGreek[170] = createArray(73, 0, 0); // *+I -> *I
				
				tblDiacritGreek[171] = createArray(85, 0, 0); // *+U -> *U
				
				tblDiacritGreek[172] = createArray(139, 0, 0); // A/
				
				tblDiacritGreek[173] = createArray(161, 0, 0); // E/
				
				tblDiacritGreek[174] = createArray(174, 0, 0); // H/
				
				tblDiacritGreek[175] = createArray(219, 0, 0); // I/
				
				tblDiacritGreek[176] = createArray(64, 0, 0); // U/+
				
				tblDiacritGreek[177] = createArray(97, 0, 0); // A
				
				tblDiacritGreek[178] = createArray(98, 0, 0); // B
				
				tblDiacritGreek[179] = createArray(103, 0, 0); // G
				
				tblDiacritGreek[180] = createArray(100, 0, 0); // D
				
				tblDiacritGreek[181] = createArray(101, 0, 0); // E
				
				tblDiacritGreek[182] = createArray(122, 0, 0); // Z
				
				tblDiacritGreek[183] = createArray(104, 0, 0); // H
				
				tblDiacritGreek[184] = createArray(121, 0, 0); // Q
				
				tblDiacritGreek[185] = createArray(105, 0, 0); // I
				
				tblDiacritGreek[186] = createArray(107, 0, 0); // K
				
				tblDiacritGreek[187] = createArray(108, 0, 0); // L
				
				tblDiacritGreek[188] = createArray(109, 0, 0); // M
				
				tblDiacritGreek[189] = createArray(110, 0, 0); // N
				
				tblDiacritGreek[190] = createArray(106, 0, 0); // C
				
				tblDiacritGreek[191] = createArray(111, 0, 0); // O
				
				tblDiacritGreek[192] = createArray(112, 0, 0); // P
				
				tblDiacritGreek[193] = createArray(114, 0, 0); // R
				
				tblDiacritGreek[194] = createArray(119, 0, 0); // final S
				tblDiacritGreek[195] = createArray(115, 0, 0); // S
				
				tblDiacritGreek[196] = createArray(116, 0, 0); // T
				
				tblDiacritGreek[197] = createArray(117, 0, 0); // U
				
				tblDiacritGreek[198] = createArray(102, 0, 0); // F
				
				tblDiacritGreek[199] = createArray(120, 0, 0); // X
				
				tblDiacritGreek[200] = createArray(99, 0, 0); // Y
				
				tblDiacritGreek[201] = createArray(118, 0, 0); // W
				
				tblDiacritGreek[202] = createArray(243, 0, 0); // I+
				
				tblDiacritGreek[203] = createArray(35, 0, 0); // U+
				
				tblDiacritGreek[204] = createArray(241, 0, 0); // O/
				
				tblDiacritGreek[205] = createArray(230, 0, 0); // U/
				
				tblDiacritGreek[206] = createArray(197, 0, 0); // W/
				
				// Variant letter forms:
				
				tblDiacritGreek[208] = createArray(98, 0, 0); // B symbol -> B
				
				tblDiacritGreek[209] = createArray(122, 0, 0); // Q symbol -> Q
				
				tblDiacritGreek[210] = createArray(85, 0, 0); // *U hook -> *U
				
				tblDiacritGreek[211] = createArray(128, 85, 0); // */U hook -> */U
				
				tblDiacritGreek[212] = createArray(85, 0, 0); // *+U hook -> *U
				
				tblDiacritGreek[213] = createArray(102, 0, 0); // F symbol
				
				tblDiacritGreek[214] = createArray(112, 0, 0); // P symbol
				
				// Archaic letters:
				
				tblDiacritGreek[218] = createArray(251, 0, 0); // stigma
				
				tblDiacritGreek[219] = createArray(251, 0, 0); // small stigma
				
				tblDiacritGreek[220] = createArray(87, 0, 0); // digamma
				
				tblDiacritGreek[221] = createArray(87, 0, 0); // small digamma
				
				tblDiacritGreek[222] = createArray(113, 0, 0); // qoppa
				
				tblDiacritGreek[223] = createArray(113, 0, 0); // small qoppa
				
				tblDiacritGreek[224] = createArray(81, 0, 0); // sampi
				
				tblDiacritGreek[225] = createArray(81, 0, 0); // small sampi
				
				// Greek symbols:
				
				tblDiacritGreek[240] = createArray(107, 0, 0); // K symbol -> K
				
				tblDiacritGreek[241] = createArray(114, 0, 0); // R symbol -> R
				
				tblDiacritGreek[242] = createArray(33, 0, 0); // lunate S
				
				// additional letter:
				
				//tblDiacritGreek[243] = YOT
				
				// Greek symbols:
				
				tblDiacritGreek[244] = createArray(89, 0, 0); // *Q symbol -> *Q
				
				tblDiacritGreek[245] = createArray(101, 0, 0); // lunate E -> E
				
				//
				
				// GREEK EXTENDED
				
				//
				
				tblGreekExtended[0] = createArray(142, 0, 0); // A)
				
				tblGreekExtended[1] = createArray(143, 0, 0); // A(
				
				tblGreekExtended[2] = createArray(146, 0, 0); // A)\
				
				tblGreekExtended[3] = createArray(147, 0, 0); // A(\
				
				tblGreekExtended[4] = createArray(144, 0, 0); // A)/
				
				tblGreekExtended[5] = createArray(145, 0, 0); // A(/
				tblGreekExtended[6] = createArray(148, 0, 0); // A)=
				
				tblGreekExtended[7] = createArray(149, 0, 0); // A(=
				
				tblGreekExtended[8] = createArray(131, 65, 0); // *)A
				
				tblGreekExtended[9] = createArray(132, 65, 0); // *(A
				
				tblGreekExtended[10] = createArray(135, 65, 0); // *)\A
				
				tblGreekExtended[11] = createArray(136, 65, 0); // *(\A
				
				tblGreekExtended[12] = createArray(133, 65, 0); // *)/A
				
				tblGreekExtended[13] = createArray(134, 65, 0); // *(/A
				
				tblGreekExtended[14] = createArray(137, 65, 0); // *)=A
				
				tblGreekExtended[15] = createArray(138, 65, 0); // *(=A
				
				tblGreekExtended[16] = createArray(164, 0, 0); // E)
				
				tblGreekExtended[17] = createArray(165, 0, 0); // E(
				
				tblGreekExtended[18] = createArray(168, 0, 0); // E)\
				
				tblGreekExtended[19] = createArray(169, 0, 0); // E/\
				
				tblGreekExtended[20] = createArray(166, 0, 0); // E)/
				
				tblGreekExtended[21] = createArray(167, 0, 0); // E(/
				
				tblGreekExtended[24] = createArray(131, 69, 0); // *)E
				
				tblGreekExtended[25] = createArray(132, 69, 0); // *(E
				
				tblGreekExtended[26] = createArray(135, 69, 0); // *)\E
				
				tblGreekExtended[27] = createArray(136, 69, 0); // *(\E
				
				tblGreekExtended[28] = createArray(133, 69, 0); // *)/E
				
				tblGreekExtended[29] = createArray(134, 69, 0); // *(/E
				
				tblGreekExtended[32] = createArray(177, 0, 0); // H)
				
				tblGreekExtended[33] = createArray(178, 0, 0); // H(
				
				tblGreekExtended[34] = createArray(181, 0, 0); // H)\
				
				tblGreekExtended[35] = createArray(182, 0, 0); // H(\
				
				tblGreekExtended[36] = createArray(179, 0, 0); // H)/
				
				tblGreekExtended[37] = createArray(180, 0, 0); // H(/
				
				tblGreekExtended[38] = createArray(183, 0, 0); // H)=
				
				tblGreekExtended[39] = createArray(184, 0, 0); // H(=
				
				tblGreekExtended[40] = createArray(131, 72, 0); // *)H
				
				tblGreekExtended[41] = createArray(132, 72, 0); // *(H
				
				tblGreekExtended[42] = createArray(135, 72, 0); // *)\H
				
				tblGreekExtended[43] = createArray(136, 72, 0); // *(\H
				
				tblGreekExtended[44] = createArray(133, 72, 0); // *)/H
				
				tblGreekExtended[45] = createArray(134, 72, 0); // *(/H
				
				tblGreekExtended[46] = createArray(137, 72, 0); // *)=H
				
				tblGreekExtended[47] = createArray(138, 72, 0); // *(=H
				
				tblGreekExtended[48] = createArray(222, 0, 0); // I)
				
				tblGreekExtended[49] = createArray(223, 0, 0); // I(
				
				tblGreekExtended[50] = createArray(226, 0, 0); // I)\
				
				tblGreekExtended[51] = createArray(227, 0, 0); // I(\
				
				tblGreekExtended[52] = createArray(224, 0, 0); // I)/
				
				tblGreekExtended[53] = createArray(225, 0, 0); // I(/
				
				tblGreekExtended[54] = createArray(228, 0, 0); // I)=
				
				tblGreekExtended[55] = createArray(229, 0, 0); // I(=
				
				tblGreekExtended[56] = createArray(131, 73, 0); // *)I
				tblGreekExtended[57] = createArray(132, 73, 0); // *(I
				
				tblGreekExtended[58] = createArray(135, 73, 0); // *)\I
				
				tblGreekExtended[59] = createArray(136, 73, 0); // *(\I
				
				tblGreekExtended[60] = createArray(134, 73, 0); // *)/I
				
				tblGreekExtended[61] = createArray(135, 73, 0); // *(/I
				
				tblGreekExtended[62] = createArray(137, 73, 0); // *)=I
				
				tblGreekExtended[63] = createArray(138, 73, 0); // *(=I
				
				tblGreekExtended[64] = createArray(244, 0, 0); // O)
				
				tblGreekExtended[65] = createArray(245, 0, 0); // O(
				
				tblGreekExtended[66] = createArray(248, 0, 0); // O)\
				
				tblGreekExtended[67] = createArray(249, 0, 0); // O(\
				
				tblGreekExtended[68] = createArray(246, 0, 0); // O)/
				
				tblGreekExtended[69] = createArray(247, 0, 0); // O(/
				
				tblGreekExtended[72] = createArray(131, 79, 0); // *)O
				
				tblGreekExtended[73] = createArray(132, 79, 0); // *(O
				
				tblGreekExtended[74] = createArray(135, 79, 0); // *)\O
				
				tblGreekExtended[75] = createArray(136, 79, 0); // *(\O
				
				tblGreekExtended[76] = createArray(133, 79, 0); // *)/O
				
				tblGreekExtended[77] = createArray(134, 79, 0); // *(/O
				
				tblGreekExtended[80] = createArray(233, 0, 0); // U)
				
				tblGreekExtended[81] = createArray(234, 0, 0); // U(
				
				tblGreekExtended[82] = createArray(237, 0, 0); // U)\
				
				tblGreekExtended[83] = createArray(238, 0, 0); // U(\
				
				tblGreekExtended[84] = createArray(235, 0, 0); // U)/
				
				tblGreekExtended[85] = createArray(236, 0, 0); // U(/
				
				tblGreekExtended[86] = createArray(239, 0, 0); // U)=
				
				tblGreekExtended[87] = createArray(240, 0, 0); // U(=
				
				tblGreekExtended[89] = createArray(132, 85, 0); // *(U
				
				tblGreekExtended[91] = createArray(136, 85, 0); // *(\U
				
				tblGreekExtended[93] = createArray(134, 85, 0); // *(/U
				
				tblGreekExtended[95] = createArray(138, 85, 0); // *(=U
				
				tblGreekExtended[96] = createArray(200, 0, 0); // W)
				
				tblGreekExtended[97] = createArray(201, 0, 0); // W(
				
				tblGreekExtended[98] = createArray(204, 0, 0); // W)\
				
				tblGreekExtended[99] = createArray(205, 0, 0); // W(\
				
				tblGreekExtended[100] = createArray(202, 0, 0); // W)/
				
				tblGreekExtended[101] = createArray(203, 0, 0); // W(/
				
				tblGreekExtended[102] = createArray(206, 0, 0); // W)=
				
				tblGreekExtended[103] = createArray(207, 0, 0); // W(=
				
				tblGreekExtended[104] = createArray(131, 86, 0); // *)W
				
				tblGreekExtended[105] = createArray(132, 86, 0); // *(W
				
				tblGreekExtended[106] = createArray(135, 86, 0); // *)\W
				
				tblGreekExtended[107] = createArray(136, 86, 0); // *(\W
				
				tblGreekExtended[108] = createArray(133, 86, 0); // *)/W
				
				tblGreekExtended[109] = createArray(134, 86, 0); // *(/W
				
				tblGreekExtended[110] = createArray(137, 86, 0); // *)=W
				
				tblGreekExtended[111] = createArray(138, 86, 0); // *(=W
				tblGreekExtended[112] = createArray(140, 0, 0); // A\
				
				tblGreekExtended[113] = createArray(139, 0, 0); // A/
				
				tblGreekExtended[114] = createArray(162, 0, 0); // E\
				
				tblGreekExtended[115] = createArray(161, 0, 0); // E/
				
				tblGreekExtended[116] = createArray(175, 0, 0); // H\
				
				tblGreekExtended[117] = createArray(174, 0, 0); // H/
				
				tblGreekExtended[118] = createArray(220, 0, 0); // I\
				
				tblGreekExtended[119] = createArray(219, 0, 0); // I/
				
				tblGreekExtended[120] = createArray(242, 0, 0); // O\
				
				tblGreekExtended[121] = createArray(241, 0, 0); // O/
				
				tblGreekExtended[122] = createArray(231, 0, 0); // U\
				
				tblGreekExtended[123] = createArray(230, 0, 0); // U/
				
				tblGreekExtended[124] = createArray(198, 0, 0); // W\
				
				tblGreekExtended[125] = createArray(197, 0, 0); // W/
				
				tblGreekExtended[128] = createArray(153, 0, 0); // A)|
				
				tblGreekExtended[129] = createArray(154, 0, 0); // A(|
				
				tblGreekExtended[130] = createArray(157, 0, 0); // A)\|
				
				tblGreekExtended[131] = createArray(158, 0, 0); // A(\|
				
				tblGreekExtended[132] = createArray(155, 0, 0); // A)/|
				
				tblGreekExtended[133] = createArray(156, 0, 0); // A(/|
				
				tblGreekExtended[134] = createArray(159, 0, 0); // A)=|
				
				tblGreekExtended[135] = createArray(170, 0, 0); // A(=|
				
				tblGreekExtended[136] = createArray(131, 65, 105); // *)A|
				
				tblGreekExtended[137] = createArray(132, 65, 105); // *(A|
				
				tblGreekExtended[138] = createArray(135, 65, 105); // *)\A|
				
				tblGreekExtended[139] = createArray(136, 65, 105); // *(\A|
				
				tblGreekExtended[140] = createArray(133, 65, 105); // *)/A|
				
				tblGreekExtended[141] = createArray(134, 65, 105); // *(/A|
				
				tblGreekExtended[142] = createArray(137, 65, 105); // *)=A|
				
				tblGreekExtended[143] = createArray(138, 65, 105); // *(=A|
				
				tblGreekExtended[144] = createArray(188, 0, 0); // H)|
				
				tblGreekExtended[145] = createArray(189, 0, 0); // H(|
				
				tblGreekExtended[146] = createArray(192, 0, 0); // H)\|
				
				tblGreekExtended[147] = createArray(193, 0, 0); // H(\|
				
				tblGreekExtended[148] = createArray(190, 0, 0); // H)/|
				
				tblGreekExtended[149] = createArray(191, 0, 0); // H(/|
				
				tblGreekExtended[150] = createArray(194, 0, 0); // H)=|
				
				tblGreekExtended[151] = createArray(195, 0, 0); // H(=|
				
				tblGreekExtended[152] = createArray(131, 72, 105); // *)H|
				
				tblGreekExtended[153] = createArray(132, 72, 105); // *(H|
				
				tblGreekExtended[154] = createArray(135, 72, 105); // *)\H|
				
				tblGreekExtended[155] = createArray(136, 72, 105); // *(\H|
				
				tblGreekExtended[156] = createArray(133, 72, 105); // *)/H|
				
				tblGreekExtended[157] = createArray(134, 72, 105); // *(/H|
				
				tblGreekExtended[158] = createArray(137, 72, 105); // *)=H|
				
				tblGreekExtended[159] = createArray(138, 72, 105); // *(=H|
				
				tblGreekExtended[160] = createArray(211, 0, 0); // W)|
				tblGreekExtended[161] = createArray(212, 0, 0); // W(|
				
				tblGreekExtended[162] = createArray(215, 0, 0); // W)\|
				
				tblGreekExtended[163] = createArray(216, 0, 0); // W(\|
				
				tblGreekExtended[164] = createArray(213, 0, 0); // W)/|
				
				tblGreekExtended[165] = createArray(214, 0, 0); // W(/|
				
				tblGreekExtended[166] = createArray(217, 0, 0); // W)=|
				
				tblGreekExtended[167] = createArray(218, 0, 0); // W(=|
				
				tblGreekExtended[168] = createArray(131, 86, 105); // *)W|
				
				tblGreekExtended[169] = createArray(132, 86, 105); // *(W|
				
				tblGreekExtended[170] = createArray(135, 86, 105); // *)\W|
				
				tblGreekExtended[171] = createArray(136, 86, 105); // *(\W|
				
				tblGreekExtended[172] = createArray(133, 86, 105); // *)/W|
				
				tblGreekExtended[173] = createArray(134, 86, 105); // *(/W|
				
				tblGreekExtended[174] = createArray(137, 86, 105); // *)=W|
				
				tblGreekExtended[175] = createArray(138, 86, 105); // *(=W|
				
				tblGreekExtended[176] = createArray(97, 0, 0); // A vrachy -> A
				
				tblGreekExtended[177] = createArray(97, 0, 0); // A macron -> A
				
				tblGreekExtended[178] = createArray(151, 0, 0); // A\|
				
				tblGreekExtended[179] = createArray(38, 0, 0); // A|
				
				tblGreekExtended[180] = createArray(150, 0, 0); // A/|
				
				tblGreekExtended[182] = createArray(141, 0, 0); // A=
				
				tblGreekExtended[183] = createArray(152, 0, 0); // A=|
				
				tblGreekExtended[184] = createArray(65, 0, 0); // *A vrachy
				
				tblGreekExtended[185] = createArray(65, 0, 0); // *A macron
				
				tblGreekExtended[186] = createArray(129, 65, 0); // *\A
				
				tblGreekExtended[187] = createArray(128, 65, 0); // */A
				
				tblGreekExtended[188] = createArray(65, 105, 0); // *A|
				
				tblGreekExtended[189] = createArray(131, 0, 0); // koronis -> )
				
				tblGreekExtended[190] = createArray(105, 0, 0); // iota adscript -> I
				
				tblGreekExtended[191] = createArray(131, 0, 0); // )
				
				tblGreekExtended[192] = createArray(130, 0, 0); // =
				
				tblGreekExtended[193] = createArray(130, 0, 0); // =+ -> =
				
				tblGreekExtended[194] = createArray(186, 0, 0); // H\|
				
				tblGreekExtended[195] = createArray(250, 0, 0); // H|
				
				tblGreekExtended[196] = createArray(185, 0, 0); // H/|
				
				tblGreekExtended[198] = createArray(176, 0, 0); // H=
				
				tblGreekExtended[199] = createArray(187, 0, 0); // H=|
				
				tblGreekExtended[200] = createArray(129, 69, 0); // *\E
				
				tblGreekExtended[201] = createArray(128, 69, 0); // */E
				
				tblGreekExtended[202] = createArray(129, 72, 0); // *\H
				
				tblGreekExtended[203] = createArray(128, 72, 0); // */H
				
				tblGreekExtended[204] = createArray(72, 105, 0); // *H|
				
				tblGreekExtended[205] = createArray(135, 0, 0); // )\
				
				tblGreekExtended[206] = createArray(133, 0, 0); // )/
				
				tblGreekExtended[207] = createArray(137, 0, 0); // )=
				
				tblGreekExtended[208] = createArray(105, 0, 0); // I vrachy
				
				tblGreekExtended[209] = createArray(105, 0, 0); // I macron
				tblGreekExtended[210] = createArray(254, 0, 0); // I\+
				
				tblGreekExtended[211] = createArray(253, 0, 0); // I/+
				
				tblGreekExtended[214] = createArray(221, 0, 0); // I=
				
				tblGreekExtended[215] = createArray(221, 0, 0); // I=+ -> I=
				
				tblGreekExtended[216] = createArray(73, 0, 0); // *I vrachy
				
				tblGreekExtended[217] = createArray(73, 0, 0); // *I macron
				
				tblGreekExtended[218] = createArray(129, 73, 0); // *\I
				
				tblGreekExtended[219] = createArray(128, 73, 0); // */I
				
				tblGreekExtended[221] = createArray(136, 0, 0); // (\
				
				tblGreekExtended[222] = createArray(134, 0, 0); // (/
				
				tblGreekExtended[223] = createArray(138, 0, 0); // (=
				
				tblGreekExtended[224] = createArray(117, 0, 0); // U vrachy
				
				tblGreekExtended[225] = createArray(117, 0, 0); // U macron
				
				tblGreekExtended[226] = createArray(163, 0, 0); // U\+
				
				tblGreekExtended[227] = createArray(64, 0, 0); // U/+
				
				tblGreekExtended[228] = createArray(114, 0, 0); // R) -> R
				
				tblGreekExtended[229] = createArray(61, 0, 0); // R(
				
				tblGreekExtended[230] = createArray(232, 0, 0); // U=
				
				tblGreekExtended[231] = createArray(232, 0, 0); // U=+ -> U=
				
				tblGreekExtended[232] = createArray(85, 0, 0); // *U vrachy
				
				tblGreekExtended[233] = createArray(85, 0, 0); // *U macron
				
				tblGreekExtended[234] = createArray(129, 85, 0); // *\U
				
				tblGreekExtended[235] = createArray(128, 85, 0); // */U
				
				tblGreekExtended[236] = createArray(132, 82, 0); // *(R
				
				tblGreekExtended[237] = createArray(129, 0, 0); // \+ -> \
				
				tblGreekExtended[238] = createArray(128, 0, 0); // /+ -> /
				
				tblGreekExtended[239] = createArray(129, 0, 0); // \
				
				tblGreekExtended[242] = createArray(209, 0, 0); // W\|
				tblGreekExtended[243] = createArray(196, 0, 0); // W|
				tblGreekExtended[244] = createArray(208, 0, 0); // W/|
				tblGreekExtended[246] = createArray(199, 0, 0); // W=
				tblGreekExtended[247] = createArray(210, 0, 0); // W=|
				tblGreekExtended[248] = createArray(129, 79, 0); // *\O
				tblGreekExtended[249] = createArray(128, 79, 0); // */O
				tblGreekExtended[250] = createArray(129, 86, 0); // *\W
				tblGreekExtended[251] = createArray(128, 86, 0); // */W
				tblGreekExtended[252] = createArray(86, 105, 0); // *W|
				tblGreekExtended[253] = createArray(128, 0, 0); // /
				tblGreekExtended[254] = createArray(132, 0, 0); // (
			}
		}
	}
}