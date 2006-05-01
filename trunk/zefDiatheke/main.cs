using System;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;
using System.IO;
using System.Reflection;
using NewTrueSharpSwordAPI.Cache;


namespace zefDiatheke
{
	/// <summary>
	/// Zusammenfassung für Class1.
	/// </summary>
	class zefdiatheke
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				//
				// TODO: Fügen Sie hier Code hinzu, um die Anwendung zu starten
				//

				if(args[0]=="cc")
				{

					CreateCache(args);
					return;

				}
				if(args[0]=="ccp")
				{

					CreateCacheAndPack(args);
					return;

				}
				if(args[0]=="lb")
				{

					ListModuls(args);
					return;

				}
				if(args[0]=="gc")
				{

					GetTextChapter(args);
					return;

				}
				if(args[0]=="gb")
				{

					GetTextBook(args);
					return;

				}
				if(args[0]=="ccpdir")
				{

					ProcessDir(args);
					return;

				}
				if(args[0]=="v")
				{

					Console.WriteLine("ZefDiatheke Version 0.0.0.9");
					Console.WriteLine("Visit  www.zefania.de for newer version if available");
					return;

				}
				if(args[0]=="lid")
				{
					ListLangIDs(args);

					return;

				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);
			}

		}

		static void GetTextChapter(string[] args)
		{
			try
			{
				string AppPath=GetApplicationFolderName();
				string TMPPath=Path.GetTempFileName();

				if(File.Exists(AppPath+@"\config.xml"))
				{
					XmlDocument Config=new XmlDocument();

					string BibleName=args[1];

					Config.Load(AppPath+@"\config.xml");
					XmlNode ML=Config.DocumentElement.SelectSingleNode("descendant::modul[@name='"+BibleName+"']");
					if(ML==null)
					{
						Environment.Exit(3100);
					}
					else
					{

						string BN=args[2];
						string CN=args[3];
						string XSLT=null;
						string Targetfile=null;

						if(args.Length==6)
						{
							XSLT=args[4];
							Targetfile=args[5];
						}


						string PathToChapterFile=AppPath+@"\zefcache\"+ML.InnerText+@"\"+BN+@"_"+CN+@".xml";

						if(!File.Exists(PathToChapterFile))
						{
							Console.WriteLine(PathToChapterFile);
							Console.WriteLine("Chapter not found!");
							Environment.Exit(3200);
						}
						else
						{

							if(File.Exists(AppPath+@"\"+XSLT)&(Targetfile!=null))
							{
								TransformXmlFile(TMPPath,AppPath+@"\"+XSLT,AppPath+@"\"+Targetfile);
								StreamReader sr = File.OpenText(TMPPath);
								String input;
								while ((input=sr.ReadLine())!=null) 
								{
									Console.WriteLine(input);
								}
								sr.Close();

								Environment.Exit(3000);
							}
							else
							{
								StreamWriter sw=null;
								StreamReader sr = File.OpenText(PathToChapterFile);
								String input;
								if(Targetfile!=null)
								{
									sw=File.CreateText(AppPath+@"\"+Targetfile);
								}
								while ((input=sr.ReadLine())!=null) 
								{
									Console.WriteLine(input);
									if(Targetfile!=null)
									{
										sw.WriteLine(input);
									}

								}
								sr.Close();
								if(Targetfile!=null)
								{
									sw.Flush();
									sw.Close();
								}
							}
							File.Delete(TMPPath);

						}


					}
				}



			}
			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);
			}
		}


		static void ListModuls(string[] args)
		{
			try
			{
				XmlDocument Config=new XmlDocument();
				string AppPath=GetApplicationFolderName();
				if(File.Exists(AppPath+@"\config.xml"))
				{

					Config.Load(AppPath+@"\config.xml");
					XmlNodeList ML=Config.DocumentElement.SelectNodes("descendant::modul");
					foreach(XmlNode m in ML)
					{
						Console.WriteLine(m.Attributes.GetNamedItem("name").InnerText);

					}


					Environment.Exit(2000);

				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);
			}

		}
		static void CreateCache(string[] args)
		{
			try
			{
				string Path2ZefModul=args[1];

				string AppPath=GetApplicationFolderName();

				if(Path.GetDirectoryName(Path2ZefModul)=="")
				{

					Path2ZefModul=AppPath+@"\"+ Path2ZefModul;
				}
                
				ZefaniaCache ZefCache = new ZefaniaCache(Path2ZefModul);
				ZefCache.BaseCacheDir=AppPath;
				Console.WriteLine(Path.GetFileName(Path2ZefModul));
				Console.WriteLine("Starte Cacherstellung.... bitte warten/wait");
				ZefCache.CreateCacheChapters(false);
				Console.WriteLine("Cache ist fertig/ready");

				System.Xml.XmlDocument Config=new XmlDocument();

				if(File.Exists(AppPath+@"\config.xml"))
				{

					Config.Load(AppPath+@"\config.xml");

				}
				else
				{
					Config.LoadXml("<module></module>");
				}

				XmlNode Modul=Config.DocumentElement.SelectSingleNode("descendant::modul[@name='"+ZefCache.GetBibleName+"' and text()='"+ZefCache.ModulMD5+"']");

				if(Modul==null)
				{
					Modul =Config.CreateNode(XmlNodeType.Element,"modul","");
					XmlNode Attrib=Config.CreateAttribute("name");
					Attrib.InnerText=ZefCache.GetBibleName;
					Modul.InnerText=ZefCache.ModulMD5;
					Modul.Attributes.SetNamedItem(Attrib);
					Config.DocumentElement.AppendChild(Modul);
					Config.Save(AppPath+@"\config.xml");

				}
				Environment.Exit(1000);



			}
			catch( FormatException e)
			{

				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1200);

			}

			catch( FileNotFoundException e)
			{

				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1500);

			}
				// Verbleibende Ausnahmen auffangen
			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);
			}


		}

		static void ProcessDir(string[] args)
		{

			try
			{
				string[] blah = new string[3];
				// Process the list of files found in the directory.
				string [] fileEntries = Directory.GetFiles(args[1].ToString());
				foreach(string fileName in fileEntries)
				{
					blah[0]="ccp";blah[1]=fileName;
					CreateCacheAndPack(blah);

				}

				Environment.Exit(1000);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1201);
			}

		}


		static void CreateCacheAndPack(string[] args)
		{
			try
			{
				string Path2ZefModul=args[1];

				string AppPath=GetApplicationFolderName();

				if(Path.GetDirectoryName(Path2ZefModul)=="")
				{

					Path2ZefModul=AppPath+@"\"+ Path2ZefModul;
				}

				ZefaniaCache ZefCache = new ZefaniaCache(Path2ZefModul);

				ZefCache.BaseCacheDir=AppPath;
				Console.WriteLine(Path.GetFileName(Path2ZefModul));
				Console.WriteLine("Starte Cacherstellung.... bitte warten/wait");
				ZefCache.CreateCacheChapters(false);

				if(File.Exists(AppPath+@"\zefmodppc.xml"))
				{

					System.Xml.XmlDocument ModullistePPC=new XmlDocument();
					ModullistePPC.Load(AppPath+@"\zefmodppc.xml");
					//nachsehen, ob ein Eintrag für dieses Modul schon in der Modulliste ist.
					XmlNode ModulEntry=ModullistePPC.DocumentElement.SelectSingleNode("descendant::modul[@filename='"+ZefCache.ModulMD5+".zip']");
					if(ModulEntry==null)
					{
						// nein neu anlegen
						XmlDocument INFO=new XmlDocument();
						INFO.Load(ZefCache.GetInfoPath);
						ModulEntry=ModullistePPC.CreateNode(XmlNodeType.Element,"modul","");

						XmlNode AttFilename=ModullistePPC.CreateNode(XmlNodeType.Attribute,"filename","");
						AttFilename.Value=ZefCache.ModulMD5+".zip";
						ModulEntry.Attributes.SetNamedItem(AttFilename);

						XmlNode Attidentifier=ModullistePPC.CreateNode(XmlNodeType.Attribute,"identifier","");
						Attidentifier.Value=INFO.SelectSingleNode("descendant::identifier").InnerText;
						ModulEntry.Attributes.SetNamedItem(Attidentifier);

						XmlNode Attlang=ModullistePPC.CreateNode(XmlNodeType.Attribute,"lang","");
						Attlang.Value=INFO.SelectSingleNode("descendant::language").InnerText;
						ModulEntry.Attributes.SetNamedItem(Attlang);

						XmlNode Attlanguage=ModullistePPC.CreateNode(XmlNodeType.Attribute,"language","");
						Attlanguage.Value=INFO.SelectSingleNode("descendant::language").InnerText;
						ModulEntry.Attributes.SetNamedItem(Attlanguage);

						XmlNode Attname=ModullistePPC.CreateNode(XmlNodeType.Attribute,"name","");
						string name=ZefCache.GetBibleName;
						name=name.Replace("XML","");
						Attname.Value=name.Trim();
						ModulEntry.Attributes.SetNamedItem(Attname);

						XmlNode Attrevision=ModullistePPC.CreateNode(XmlNodeType.Attribute,"revision","");
						Attrevision.Value=INFO.SelectSingleNode("descendant::revision").InnerText;
						ModulEntry.Attributes.SetNamedItem(Attrevision);

						XmlNode Atttype=ModullistePPC.CreateNode(XmlNodeType.Attribute,"type","");
						Atttype.Value="bible";
						ModulEntry.Attributes.SetNamedItem(Atttype);
						// und einfügen
						ModullistePPC.DocumentElement.SelectSingleNode("descendant::modules").AppendChild(ModulEntry);

						ModullistePPC.Save(AppPath+@"\zefmodppc.xml");

					}



				}


				Console.WriteLine("Cache ist fertig/ready");
				
				Console.WriteLine("Packe Cache..... bitte warten/wait");
				ZefCache.PackCache();
				Console.WriteLine("Cache ist gepackt-fertig/ready");

				System.Xml.XmlDocument Config=new XmlDocument();

				if(File.Exists(AppPath+@"\config.xml"))
				{

					Config.Load(AppPath+@"\config.xml");

				}
				else
				{
					Config.LoadXml("<module></module>");
				}

				XmlNode Modul=Config.DocumentElement.SelectSingleNode("descendant::modul[@name='"+ZefCache.GetBibleName+"' and text()='"+ZefCache.ModulMD5+"']");

				if(Modul==null)
				{
					Modul =Config.CreateNode(XmlNodeType.Element,"modul","");
					XmlNode Attrib=Config.CreateAttribute("name");
					Attrib.InnerText=ZefCache.GetBibleName;
					Modul.InnerText=ZefCache.ModulMD5;
					Modul.Attributes.SetNamedItem(Attrib);
					Config.DocumentElement.AppendChild(Modul);
					Config.Save(AppPath+@"\config.xml");

				}




			}
			catch( FormatException e)
			{

				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1200);

			}

			catch( FileNotFoundException e)
			{

				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1500);

			}
				// Verbleibende Ausnahmen auffangen
			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);
			}


		}
		static void ListLangIDs(string[] args)
		{
			try
			{

				string AppPath=GetApplicationFolderName();

				if(File.Exists(AppPath+@"\bnames.xml"))
				{
					XPathDocument Bnames = new XPathDocument(AppPath+@"\bnames.xml");
					XPathNavigator navnames = Bnames.CreateNavigator();
					XPathExpression exprnames=null; 
					XPathNodeIterator BookNames=null;
					if(args.Length==2)
					{
						exprnames=navnames.Compile("descendant-or-self::ID[position()='"+args[1].ToString()+"']/book");
						BookNames=navnames.Select(exprnames);
						while(BookNames.MoveNext())
						{

							Console.Write("["+BookNames.Current.GetAttribute("bnumber","").ToString()+"] ");
							Console.Write(BookNames.Current.GetAttribute("bshort","").ToString()+" - ");
							Console.WriteLine(BookNames.Current.Value);


						}



					}
					else
					{
						exprnames=navnames.Compile("descendant::ID");
						BookNames=navnames.Select(exprnames);
						while(BookNames.MoveNext())
						{
							Console.WriteLine(BookNames.CurrentPosition.ToString()+": "+BookNames.Current.GetAttribute("descr","").ToString());

						}
					}

				}
				else
				{

					Console.WriteLine(AppPath+@"\bnames.xml nicht gefunden/not found!");
					Console.WriteLine("Download bei/at http://tinyurl.com/8uw2u");


				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);
			}
		}
		static void GetTextBook(string[] args)
		{
			try
			{
				string AppPath=GetApplicationFolderName();
				string TMPPath=Path.GetTempFileName();

				XmlTextWriter writer;

				if(File.Exists(AppPath+@"\config.xml"))
				{
					XmlDocument Config=new XmlDocument();

					string BibleName=args[1];
					string BN=args[2];
					string XSLT=null;
					string Targetfile=null;
					string LangID=null;
					XPathDocument Bnames=null;
					XPathNavigator navnames=null;
					XPathExpression exprnames  = null;
					XPathNodeIterator BookNames=null;

					if(args.Length==5)
					{
						XSLT=args[3];
						Targetfile=args[4];
					}

					if(args.Length==6)
					{
						XSLT=args[3];
						Targetfile=args[4];
						LangID=args[5];

						if(File.Exists(AppPath+@"\bnames.xml"))
						{
							Bnames = new XPathDocument(AppPath+@"\bnames.xml");
							navnames = Bnames.CreateNavigator();
							exprnames=navnames.Compile("descendant::ID[@descr='"+LangID+"']/book");
							BookNames=navnames.Select(exprnames);
						}

					}


					Config.Load(AppPath+@"\config.xml");
					XmlNode ML=Config.DocumentElement.SelectSingleNode("descendant::modul[@name='"+BibleName+"']");
					if(ML==null)
					{
						Environment.Exit(3100);
					}
					else
					{

						string PathToCacheInfoFile=AppPath+@"\zefcache\"+ML.InnerText+@"\info.xml";

						if(!File.Exists(PathToCacheInfoFile))
						{
							Console.WriteLine(PathToCacheInfoFile);
							Console.WriteLine("info.xml not found!");
							Environment.Exit(3200);
						}
						else
						{ 
							XPathDocument INFO = new XPathDocument(PathToCacheInfoFile);
							XPathNavigator nav = INFO.CreateNavigator();

							if(Targetfile!=null)
							{   

								writer = new XmlTextWriter(AppPath+@"\"+Targetfile,Encoding.UTF8);
							}
							else
							{


								writer = new XmlTextWriter(TMPPath,Encoding.UTF8);

							}

							writer.Formatting = Formatting.Indented;



							XPathNodeIterator BOOKFiles=null;
							if(BN=="all")
							{  // Bücher und Kapitel sortieren
								XPathExpression expr  = nav.Compile("descendant::item");

								// erst nach Buchnummern
								expr.AddSort("@bn", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Number);
								BOOKFiles  = nav.Select(expr);
								// dann nach Kapitelnummern
								expr.AddSort("@cn", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Number);
								BOOKFiles  = nav.Select(expr);
							}
							else
							{   // Kapitel in Buch BN sortieren
								System.Xml.XPath.XPathExpression expr  = nav.Compile("descendant::item[@bn='"+BN+"']");
								expr.AddSort("@cn", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Number);
								BOOKFiles  = nav.Select(expr);
							}



							string PathToChapterFile=AppPath+@"\zefcache\"+ML.InnerText;
							string CN=null;

							string LastBookNumber="-1";
							bool secondBook=false;

							writer.WriteStartDocument();
							writer.WriteComment("created with zefDiatheke.exe");
							writer.WriteComment("visit: http://www.zefania.de");

							writer.WriteStartElement("XMLBIBLE"); 
							writer.WriteAttributeString("biblename",BibleName);
							writer.WriteAttributeString("type","x-bible");

							writer.WriteStartElement("INFORMATION");
							XPathExpression expr2  = nav.Compile("descendant::INFORMATION/*");
							XPathNodeIterator INFORMATION=nav.Select(expr2);

							while(INFORMATION.MoveNext())
							{
								writer.WriteElementString(INFORMATION.Current.Name,INFORMATION.Current.Value);
							}


							writer.WriteEndElement();// end information

							while (BOOKFiles.MoveNext())
							{
								CN=BOOKFiles.Current.GetAttribute("cn","").ToString();
								BN=BOOKFiles.Current.GetAttribute("bn","").ToString();
								XmlTextReader reader = new XmlTextReader(PathToChapterFile+@"\"+BN+"_"+CN+".xml");

								if(LastBookNumber!=BN)
								{
									if(secondBook)
									{

										writer.WriteEndElement();

									}

									writer.WriteStartElement("BIBLEBOOK");

									writer.WriteAttributeString("bnumber",BN);
									if(BookNames!=null)
									{

										while(BookNames.MoveNext())
										{
											if(BookNames.Current.GetAttribute("bnumber","").ToString()==BN)
											{
												string bshort=BookNames.Current.GetAttribute("bshort","").ToString();
												string blong=BookNames.Current.Value;
												writer.WriteAttributeString("bsname",bshort);
												writer.WriteAttributeString("bname",blong);
												break;

											}
										}


									}

									secondBook=true;
									LastBookNumber=BN;


								}


								while (reader.Read())
								{

									if(reader.Name=="BIBLEBOOK"&reader.NodeType == XmlNodeType.Element)
									{
										reader.Read();

										writer.WriteNode(reader,true);
									}

								}// end reader.read



							}// BOOKFiles.MoveNext
							writer.WriteEndElement();// end xmlbible
							writer.Flush();
							writer.Close();
							if(File.Exists(AppPath+@"\"+XSLT)&(Targetfile!=null))
							{
								TransformXmlFile(AppPath+@"\"+Targetfile,AppPath+@"\"+XSLT,AppPath+@"\"+Targetfile);
								StreamReader sr = File.OpenText(AppPath+@"\"+Targetfile);
								String input;
								while ((input=sr.ReadLine())!=null) 
								{
									Console.WriteLine(input);
								}
								sr.Close();

								Environment.Exit(3000);
							}
							else
							{

								StreamReader sr = File.OpenText(TMPPath);
								String input;
								while ((input=sr.ReadLine())!=null) 
								{
									Console.WriteLine(input);
								}
								sr.Close();
							}
							File.Delete(TMPPath);

						}
					}
				}

			}


			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);
			}

		}

		/* Methode zum Auslesen des Ordnernamens einer Anwendung */
		static string GetApplicationFolderName()
		{
			// FileInfo-Objekt für die Datei erzeugen, die die Eintritts-
			// Assembly speichert
			System.IO.FileInfo fi = new System.IO.FileInfo(
				System.Reflection.Assembly.GetEntryAssembly().Location);

			// Den Pfad des Verzeichnisses der Datei zurückgeben
			return fi.DirectoryName;
		}
		/* Methode zum Transformieren eines XML-Dokuments 
		* mit einem XSLT-Dokument */
		public static void TransformXmlFile(string xmlSourceFileName,
			string xslFileName, string xmlDestFileName)
		{
			try
			{
				// Instanz der Klasse XslTransform erzeugen
				XslTransform xslTransform = new XslTransform();

				// XSL-Datei laden
				xslTransform.Load(xslFileName);

				// XML-Datei transformieren
				xslTransform.Transform(xmlSourceFileName, xmlDestFileName);

			}
			catch(XmlException e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);

			}
		}

	}
}
