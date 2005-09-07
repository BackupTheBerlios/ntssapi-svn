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
				if(args[0]=="v")
				{

					Console.WriteLine("ZefDiatheke Version 0.0.0.1");
					Console.WriteLine("Visit  www.zefania.de for newer version if available");
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
				Console.WriteLine("Starte Cacherstellung.... bitte warten/wait");
				ZefCache.CreateCacheChapters(false);
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
					string XSLT="";
					string Targetfile=null;

					if(args.Length==5)
					{
						XSLT=args[3];
						Targetfile=args[4];
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
							XmlDocument INFO=new XmlDocument();
							INFO.Load(PathToCacheInfoFile);

							if(Targetfile!=null)
							{   

								writer = new XmlTextWriter(AppPath+@"\"+Targetfile,Encoding.UTF8);
							}
							else
							{


								writer = new XmlTextWriter(TMPPath,Encoding.UTF8);

							}

							writer.Formatting = Formatting.Indented;
							writer.WriteStartElement("XMLBIBLE");




							XmlNodeList BOOKFiles=INFO.DocumentElement.SelectNodes("descendant::item[@bn='"+BN+"']");

							string PathToChapterFile=AppPath+@"\zefcache\"+ML.InnerText+@"\"+BN;
							string CN=null;
							bool foundXMLBIBLE=false;

							foreach(XmlNode Chapterfile in BOOKFiles)
							{
								CN=Chapterfile.Attributes.GetNamedItem("cn").Value;
								XmlTextReader reader = new XmlTextReader(PathToChapterFile+@"_"+CN+".xml");


								while (reader.Read())
								{

									if(reader.Name=="XMLBIBLE"&!foundXMLBIBLE)
									{   

										foundXMLBIBLE=true;
										reader.MoveToFirstAttribute();
										writer.WriteAttributeString(reader.Name,reader.Value);

										while(reader.MoveToNextAttribute())
										{

											writer.WriteAttributeString(reader.Name,reader.Value);

										}

									}
									if(reader.Name=="BIBLEBOOK")
									{

										writer.WriteNode(reader,true);

									}

								}

							}
							writer.WriteElementString("INFORMATION","");
							writer.WriteEndElement();// end xmlbible
							writer.Flush();
							writer.Close();
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
