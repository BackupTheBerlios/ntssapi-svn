namespace greekconverter
{
	using System;
	/// <version>  06-Mar-2005
	/// </version>
	/// <author>   Michael Neuhold
	/// </author>
	
	public class GreekFileConverter
	{
		virtual public System.String ErrMsg
		{
			get
			{
				return errMsg;
			}
			
		}
		// symbolic constants
		// miscellaneous
		public const int SUCCESS = 0;
		public const int ERR_GENERAL = - 1;
		private const int ERR_FILE_PARAMS = - 2;
		private const int ERR_UNKNOWN_CONV = - 3;
		private const int ERR_NO_UTF = - 4;
		private const int ERR_FILE_OPEN = - 5;
		private const int ERR_IO = - 6;
		private const int ERR_PARAMS = - 7;
		// private member vars:
		private int convFrom, convInto;
		private System.String errMsg;
		private GreekConverter gc;
		private System.String encString = null;
		private System.IO.StreamReader cIn = null;
		private System.IO.StreamWriter cOut = null;
		private System.IO.BufferedStream bIn = null;
		private System.IO.BufferedStream bOut = null;
		private System.IO.StreamReader isr;
		private System.IO.StreamWriter osw;
		
		/// <summary> Gets some information about the current class.
		/// *
		/// </summary>
		/// <param name="infoType">the kind of information, you want: 0=version date,
		/// 1=short description, 2=author
		/// </param>
		/// <returns> a string containing the requested information
		/// </returns>
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case VersionInfo.CLASSINFO_VERSION_DATE:  info = "06-Mar-2005"; break;
				
				case VersionInfo.CLASSINFO_PROG_DESCR:  info = "Converts whole files from one Greek encoding into another one using class GreekConverter"; break;
				
				case VersionInfo.CLASSINFO_DEVELOPER:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Dimidium qui coepit habet.";
					break;
				
			}
			return info;
		}
		
		public GreekFileConverter()
		{
			gc = new GreekConverter();
		}
		
		/// <summary> Sets some additional options for the conversion.
		/// <p>
		/// The only recognized option is the entity mode for converting into html.
		/// *
		/// </summary>
		/// <param name="optType"> kind of option
		/// </param>
		/// <param name="optVal">  value
		/// </param>
		public virtual void  setOption(int optType, int optVal)
		{
			switch (optType)
			{
				
				case GreekConvCaps.HTML_ENTITY_MODE:  gc.HTMLMode = optVal; break;
				}
		}
		
		/// <summary> Opens input file depending on the conversion mode and input encoding.
		/// <p>
		/// If conversion mode is converting from GreekKeys then a data stream is
		/// opened. In all other cases a character stream is opened: if conversion mode
		/// is converting from Unicode and input encoding is null then an UTF-8 file
		/// is opened. If conversion mode is neither from GreekKeys nor from Unicode
		/// and input encoding is null then the local charset is used.
		/// </summary>
		public virtual int openInput(System.String inputFile, System.String inputEncoding, int convFrom)
		{
			try
			{
				// open input stream:
				//
				// 1. byte stream:
				if (convFrom == GreekConvCaps.GREEKKEYS)
				{
					bIn = new System.IO.BufferedStream(new System.IO.BinaryReader(new System.IO.FileStream(inputFile, System.IO.FileMode.Open, System.IO.FileAccess.Read)));
				}
				// 2. character stream:
				else
				{
					// use UTF-8 as default encoding for Unicode
					if ((inputEncoding == null) && (convFrom == GreekConvCaps.UNICODE))
					{
						inputEncoding = "UTF-8";
					}
					// use local charset or input encoding specified:
					if (inputEncoding == null)
					{
						isr = new System.IO.StreamReader(inputFile);
					}
					else
					{
						//UPGRADE_TODO: Constructor 'java.io.InputStreamReader.InputStreamReader' wurde in 'System.IO.StreamReader' konvertiert und weist ein anderes Verhalten auf. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
						isr = new System.IO.StreamReader(new System.IO.FileStream(inputFile, System.IO.FileMode.Open, System.IO.FileAccess.Read), System.Text.Encoding.GetEncoding(inputEncoding));
					}
					//UPGRADE_TODO: Expected value der Parameter von constructor 'java.io.BufferedReader.BufferedReader' sind in der entsprechende Zuordnung von .NET unterschiedlich. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1092"'
					cIn = new System.IO.StreamReader(isr.BaseStream, System.Text.Encoding.UTF7);
				}
				return SUCCESS;
			}
			catch (System.IO.IOException e)
			{
				handleException(e, "Error opening " + inputFile + " for input");
				return ERR_FILE_OPEN;
			}
		}
		
		/// <summary> Opens output file depending on the conversion mode and output encoding.
		/// <p>
		/// If conversion mode is converting inot GreekKeys then a data stream is
		/// opened. In all other cases a character stream is opened: if conversion mode
		/// is converting into Unicode and output encoding is null then an UTF-8 file
		/// is opened. If conversion mode is neither into GreekKeys nor into Unicode
		/// and output encoding is null then the local charset is used.
		/// </summary>
		public virtual int openOutput(System.String outputFile, System.String outputEncoding, int convInto)
		{
			try
			{
				// open input stream:
				//
				// 1. byte stream:
				if (convInto == GreekConvCaps.GREEKKEYS)
				{
					bOut = new System.IO.BufferedStream(new System.IO.BinaryWriter(new System.IO.FileStream(outputFile, System.IO.FileMode.Create)));
					//UPGRADE_TODO: Die Entsprechung method 'java.io.InputStreamReader.getEncoding'  in .NET gibt möglicherweise einen anderen Wert zurück. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
					encString = isr.CurrentEncoding.EncodingName;
					// since we write binary data we assume output file encoding identical to input file encoding
				}
				// 2. character stream:
				else
				{
					// use UTF-8 as default encoding for Unicode
					if ((outputEncoding == null) && (convInto == GreekConvCaps.UNICODE))
					{
						outputEncoding = "UTF-8";
					}
					// use local charset or input encoding specified:
					if (outputEncoding == null)
					{
						osw = new System.IO.StreamWriter(outputFile);
					}
					else
					{
						osw = new System.IO.StreamWriter(new System.IO.FileStream(outputFile, System.IO.FileMode.Create));
					}
					//UPGRADE_ISSUE: Constructor 'java.io.BufferedWriter.BufferedWriter' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaioBufferedWriterBufferedWriter_javaioWriter"'
					cOut = new BufferedWriter(osw);
					//UPGRADE_ISSUE: Method 'java.io.OutputStreamWriter.getEncoding' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaioOutputStreamWritergetEncoding"'
					encString = osw.getEncoding();
				}
				return SUCCESS;
			}
			catch (System.IO.IOException e)
			{
				handleException(e, "Error opening " + outputFile + " for output");
				return ERR_FILE_OPEN;
			}
		}
		
		/// <summary> Closes input stream.
		/// </summary>
		public virtual void  closeInput()
		{
			try
			{
				if (bIn != null)
				{
					//UPGRADE_TODO: Method 'java.io.FilterInputStream.close' wurde in 'System.IO.BinaryReader.Close' konvertiert und weist ein anderes Verhalten auf. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javaioFilterInputStreamclose"'
					bIn.Close();
				}
				else if (cIn != null)
				{
					cIn.Close();
				}
			}
			catch (System.IO.IOException e)
			{
				handleException(e, "Error closing input file");
			}
		}
		
		/// <summary> Closes output stream.
		/// </summary>
		public virtual void  closeOutput()
		{
			try
			{
				if (bOut != null)
				{
					bOut.Close();
				}
				else if (cOut != null)
				{
					cOut.Close();
				}
			}
			catch (System.IO.IOException e)
			{
				handleException(e, "Error closing output file");
			}
		}
		
		// print out localized message for the passed exception:
		private void  handleException(System.Exception e, System.String defMsg)
		{
			errMsg = e.Message;
			if (errMsg == null)
			{
				errMsg = defMsg;
			}
			System.Console.Error.WriteLine(errMsg);
			SupportClass.WriteStackTrace(e, Console.Error);
		}
		
		// do the plausibility checks for file names fields,
		// is not private because must be invoked by Nereus
		internal virtual int checkFileParams(System.String inputFile, System.String outputFile)
		{
			int retVal = SUCCESS;
			if ((inputFile == null) || inputFile.Equals(""))
			{
				errMsg = "You have not provided the name of the source file.";
				retVal = ERR_FILE_PARAMS;
			}
			else if ((outputFile == null) || outputFile.Equals(""))
			{
				errMsg = "You have not provided the name for the destination file.";
				retVal = ERR_FILE_PARAMS;
			}
			else
			{
				System.IO.FileInfo ifile = new System.IO.FileInfo(inputFile);
				System.IO.FileInfo ofile = new System.IO.FileInfo(outputFile);
				if (ifile.compareTo(ofile) == 0)
				{
					errMsg = "Source and destination cannot be the same.";
					retVal = ERR_FILE_PARAMS;
				}
			}
			if (retVal != SUCCESS)
			{
				System.Console.Error.WriteLine("ERROR! " + errMsg);
			}
			return retVal;
		}
		
		// check plausibility of encoding parameters:
		private int checkEncParams(int convMode, System.String inputEncoding, System.String outputEncoding)
		{
			int retVal = SUCCESS;
			
			// check for validity of conversion parameter:
			switch (convMode)
			{
				
				case GreekConvCaps.UNICODE_BETACODE: 
				case GreekConvCaps.UNICODE_ASCII: 
				case GreekConvCaps.UNICODE_HTML: 
				case GreekConvCaps.UNICODE_GREEKKEYS: 
				case GreekConvCaps.UNICODE_NAMES: 
				case GreekConvCaps.BETACODE_UNICODE: 
				case GreekConvCaps.BETACODE_SPIONIC: 
				case GreekConvCaps.ASCII_BETACODE: 
				case GreekConvCaps.BIBLEWORKS_UNICODE: 
				case GreekConvCaps.BIBLEWORKS_BETACODE: 
				case GreekConvCaps.GREEKKEYS_UNICODE: 
				case GreekConvCaps.UNICODE_DECOMPOSE: 
				case GreekConvCaps.UNICODE_PRECOMPOSE: 
					break;
				
				default: 
					errMsg = "Not recognized or not supported conversion.";
					retVal = ERR_UNKNOWN_CONV;
					break;
				
			}
			// if no error so far then proceed:
			if (retVal == SUCCESS)
			{
				convFrom = GreekConvCaps.getConvInput(convMode);
				convInto = GreekConvCaps.getConvOutput(convMode);
				
				// check for appropriate input file encoding:
				if ((convFrom == GreekConvCaps.UNICODE) && ((inputEncoding == null) || (!inputEncoding.Substring(0, (3) - (0)).Equals("UTF"))))
				{
					errMsg = "Conversion from Greek Unicode needs UTF input file encoding.";
					retVal = ERR_NO_UTF;
				}
			}
			// if no error so far then proceed:
			if (retVal == SUCCESS)
			{
				// check for appropriate output file encoding:
				if ((convInto == GreekConvCaps.UNICODE) && ((outputEncoding == null) || (!outputEncoding.Substring(0, (3) - (0)).Equals("UTF"))))
				{
					errMsg = "Conversion into Unicode needs UTF output file encoding.";
					retVal = ERR_NO_UTF;
				}
			}
			
			if (retVal != SUCCESS)
			{
				System.Console.Error.WriteLine("ERROR! " + errMsg);
			}
			return retVal;
		}
		
		public virtual int convertFile(System.String inputFile, System.String outputFile, int convMode)
		{
			return convertFile(inputFile, outputFile, convMode, null, null);
		}
		
		/// <summary> Converts the file and writes another file.
		/// *
		/// </summary>
		/// <param name="inputFile">     name (and path) of the source file
		/// </param>
		/// <param name="outputFile">    name (and path) of the destination file
		/// </param>
		/// <param name="convMode">      a number describing the conversion
		/// </param>
		/// <param name="inputEncoding"> a String describing the encoding of the input file
		/// (UTF-8, ISO-8859-1, null for local charset)
		/// </param>
		/// <param name="outputEncoding">a String describing the encoding of the output file
		/// </param>
		/// <returns> 0 if successful, a negative value if an error occured
		/// </returns>
		public virtual int convertFile(System.String inputFile, System.String outputFile, int convMode, System.String inputEncoding, System.String outputEncoding)
		{
			short[] s = null;
			int i;
			System.String inLine, outLine;
			int lineNum = 0, retVal;
			
			System.Console.Out.WriteLine("Invoking method convertFile of class " + GetType().FullName);
			System.Console.Out.WriteLine("Version " + getClassInfo(0));
			
			// open input and output files:
			retVal = openInput(inputFile, inputEncoding, convFrom);
			if (retVal != SUCCESS)
			{
				return retVal;
			}
			
			retVal = openOutput(outputFile, outputEncoding, convInto);
			if (retVal != SUCCESS)
			{
				return retVal;
			}
			
			gc.MessageLevel = 2;
			
			try
			{
				//
				// read / convert / write
				//
				if (convFrom == GreekConvCaps.GREEKKEYS)
				{
					int b; // the byte represented by an int
					bool newLineFlag = false;
					DynShortArray dynArr = new DynShortArray(512, 255);
					
					while ((b = bIn.ReadByte()) != - 1)
					// -1 is returned if end of file is reached
					{
						if ((b == 10) || (b == 13))
						// line by line -- not really necessary
						{
							// CR-LF and LF-CR  may only result in one new line:
							if (!newLineFlag)
							{
								if ((lineNum++ % 20) == 0)
								{
									System.Console.Out.Write(".");
								}
								dynArr.pushElem((short) 0); // mark end of "string"
								outLine = gc.convertStringGreekKeysToUni(dynArr.Array);
								//UPGRADE_NOTE: Ausnahmen, die in .NET von der Entsprechung von method 'java.io.BufferedWriter.write' ausgelöst wurden, können unterschiedlich sein. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1099"'
								cOut.Write(outLine, 0, outLine.Length);
								cOut.WriteLine();
								dynArr.reset();
								newLineFlag = true; // new line written -> raise flag
							}
							else
							{
								newLineFlag = false; // current byte byte was the corresponding CR/LF -> lower flag
							}
						}
						else
						{
							dynArr.pushElem((short) b);
						}
					}
					// output the rest of the array, if there is one:
					if (dynArr.Pos > - 1)
					{
						outLine = gc.convertStringGreekKeysToUni(dynArr.Array);
						//UPGRADE_NOTE: Ausnahmen, die in .NET von der Entsprechung von method 'java.io.BufferedWriter.write' ausgelöst wurden, können unterschiedlich sein. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1099"'
						cOut.Write(outLine, 0, outLine.Length);
						cOut.WriteLine();
					}
				}
				// everything else can be read from a BufferedReader
				else
				{
					while ((inLine = cIn.ReadLine()) != null)
					{
						// give some indication of progress:
						if ((lineNum++ % 20) == 0)
						{
							System.Console.Out.Write(".");
						}
						
						if (convInto == GreekConvCaps.GREEKKEYS)
						{
							// convert and print message queue:
							s = gc.convertStringUniToGreekKeys(inLine);
							gc.printMessageQueue("line " + (lineNum + 1).ToString(), null);
							i = 0;
							// output the short array via the StreamOutputWriter
							while (s[i] != 0)
							{
								bOut.WriteByte((byte) s[i]);
								i++;
							}
							bOut.WriteByte((System.Byte) 13); bOut.WriteByte((System.Byte) 10); // new line Windows style
						}
						// write to BufferedWriter
						else
						{
							switch (convMode)
							{
								
								// *_GREEKKEYS and GREEKKEYS_* are handled above!    
								case GreekConvCaps.UNICODE_BETACODE: 
									outLine = gc.convertStringUniToBeta(inLine); break;
								
								case GreekConvCaps.UNICODE_ASCII: 
									outLine = gc.convertStringUniToAscii(inLine); break;
								
								case GreekConvCaps.UNICODE_HTML: 
									outLine = gc.convertStringUniToHtml(inLine); break;
								
								case GreekConvCaps.UNICODE_NAMES: 
									outLine = gc.convertStringUniToName(inLine); break;
								
								case GreekConvCaps.BETACODE_UNICODE: 
									outLine = gc.convertStringBetaToUni(inLine); break;
								
								case GreekConvCaps.BETACODE_SPIONIC: 
									outLine = gc.convertStringBetaToSp(inLine); break;
								
								case GreekConvCaps.ASCII_BETACODE: 
									outLine = gc.convertStringAsciiToBeta(inLine); break;
								
								case GreekConvCaps.BIBLEWORKS_BETACODE: 
									outLine = gc.convertStringBwToBeta(inLine); break;
								
								case GreekConvCaps.BIBLEWORKS_UNICODE: 
									outLine = gc.convertStringBwToUni(inLine); break;
								
								case GreekConvCaps.UNICODE_DECOMPOSE: 
									outLine = gc.decomposeUnicode(inLine); break;
								
								case GreekConvCaps.UNICODE_PRECOMPOSE: 
									outLine = gc.precomposeUnicode(inLine); break;
								
								default: 
									outLine = ""; // this line should never be reached
									break;
								
							} // switch
							gc.printMessageQueue("line " + (lineNum + 1).ToString(), null);
							//UPGRADE_NOTE: Ausnahmen, die in .NET von der Entsprechung von method 'java.io.BufferedWriter.write' ausgelöst wurden, können unterschiedlich sein. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1099"'
							cOut.Write(outLine, 0, outLine.Length);
							cOut.WriteLine();
						}
						// while
					} // else
				}
				// else
				
				//
				// close streams
				//
				closeInput();
				closeOutput();
				return SUCCESS;
			}
			catch (System.IO.IOException e)
			{
				errMsg = e.Message;
				if (errMsg == null)
				{
					errMsg = "IOError - look at the console window.";
					if (convFrom == GreekConvCaps.UNICODE)
					{
						errMsg = errMsg + " (Maybe invalid Unicode input.)";
					}
				}
				if (lineNum != 0)
				{
					errMsg += " - line " + lineNum.ToString();
				}
				SupportClass.WriteStackTrace(e, Console.Error);
				return ERR_IO;
			}
		}
		
		
		[STAThread]
		public static void  Main(System.String[] args)
		{
			int retVal;
			//12345678901234567890123456789012345678901234567890123456789012345678901234567890
			System.String usg = "GreekFileConverter srcfile destfile convmode [-inputenc value] [-outputenc value]";
			
			if (args.Length == 1)
			{
				if (args[0].Equals("-?"))
				{
					System.Console.Out.WriteLine(usg);
					System.Console.Out.WriteLine(" srcfile     file name (and path) of the source text file");
					System.Console.Out.WriteLine(" destfile    file name (and path) of the output destination file");
					System.Console.Out.WriteLine(" convmode    Greek conversion mode");
					System.Console.Out.WriteLine(" -inputenc   encoding of srcfile, e.g. US-ASCII, ISO-8859-1, UTF-8");
					System.Console.Out.WriteLine("             default is the local charset");
					System.Console.Out.WriteLine(" -outputenc  encoding of destfile, like -inputenc");
					System.Console.Out.WriteLine(" Valid conversion modes are:");
					System.Console.Out.WriteLine(GreekConvCaps.ConvModes);
					return ;
				}
			}
			
			// check for enough parameters
			// analyze arguments:
			System.String srcFile = null, destFile = null, convMode = null, inputEnc = null, outputEnc = null, errMsg = null, opt = null;
			
			// test for minimal number of arguments possible:
			if (args.Length < 3)
			{
				System.Console.Error.WriteLine("ERROR! Wrong number of parameters. Usage:\n" + usg + "\nInvoke with \"-?\" to get help on parameters.");
				System.Environment.Exit(- 1);
			}
			
			int i = 0;
			while (i < args.Length)
			{
				if (args[i][0] == '-')
				{
					try
					{
						opt = args[i].Substring(1);
						i++;
						if (opt.Equals("inputenc"))
						{
							inputEnc = args[i];
						}
						else if (opt.Equals("outputenc"))
						{
							outputEnc = args[i];
						}
						else
						{
							errMsg = "Unrecognized option -" + opt;
						}
					}
					catch (System.IndexOutOfRangeException e)
					{
						System.Console.Error.WriteLine("ERROR! Missing value for option -" + opt);
						System.Environment.Exit(ERR_PARAMS);
					}
				}
				else
				{
					if (srcFile == null)
					{
						srcFile = args[i];
					}
					else if (destFile == null)
					{
						destFile = args[i];
					}
					else if (convMode == null)
					{
						convMode = args[i];
					}
					else
					{
						errMsg = "Extra parameter " + args[i];
					}
				}
				// if there has been an error
				if (errMsg != null)
				{
					System.Console.Error.WriteLine("ERROR! " + errMsg);
					System.Environment.Exit(ERR_PARAMS);
				}
				i++;
			}
			
			GreekFileConverter gfc = new GreekFileConverter();
			// check parameters:
			retVal = gfc.checkFileParams(srcFile, destFile);
			if (retVal == SUCCESS)
			{
				retVal = gfc.checkEncParams(System.Int32.Parse(convMode), inputEnc, outputEnc);
			}
			if (retVal == SUCCESS)
			{
				retVal = gfc.convertFile(srcFile, destFile, System.Int32.Parse(convMode), inputEnc, outputEnc);
			}
		}
	}
}