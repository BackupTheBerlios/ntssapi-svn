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
			try{
			//
			// TODO: Fügen Sie hier Code hinzu, um die Anwendung zu starten
            //
				
				if(args[0]=="cc")
				{
				  
					CreateCache(args);
					return;
				
				}
				if(args[0]=="lb")
				{
				  
					ListModuls(args);
					return;
				
				}
				if(args[0]=="gc")
				{
				  
					GetText(args);
					return;
				
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);
			}

		}
        
		static void GetText(string[] args){
			try{
                string AppPath=GetApplicationFolderName();
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
					else{
                      string XSLT=args[2];
					  string BN=args[3];
					  string CN=args[4];
					  
					  string PathToChapterFile=AppPath+@"\zefcache\"+ML.InnerText+@"\"+BN+@"_"+CN+@".xml";
					  if(!File.Exists(PathToChapterFile)){
					     Console.WriteLine(PathToChapterFile);
                        Console.WriteLine("Chapter not found!");
						Environment.Exit(3200);
						}
					  else{
					      
						  if(File.Exists(AppPath+@"\"+XSLT))
						  {
						      TransformXmlFile(PathToChapterFile,AppPath+@"\"+XSLT);
						      Environment.Exit(3000);
						  }
						  else
						  {
							  XmlDocument Chapter=new XmlDocument();
							  Chapter.Load(PathToChapterFile);
							  Console.WriteLine(Chapter.DocumentElement.OuterXml);
							  Environment.Exit(3000);
						  }
					   
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


		static void ListModuls(string[] args){
			try{
				XmlDocument Config=new XmlDocument();
                string AppPath=GetApplicationFolderName();
				if(File.Exists(AppPath+@"\config.xml"))
				{
                   
					Config.Load(AppPath+@"\config.xml");
					XmlNodeList ML=Config.DocumentElement.SelectNodes("descendant::modul");
					foreach(XmlNode m in ML){
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
		static void CreateCache(string[] args){
			try
			{
				string Path2ZefModul=args[1];
				
				string AppPath=GetApplicationFolderName();
				
				if(Path.GetDirectoryName(Path2ZefModul)==""){
				  
				 Path2ZefModul=AppPath+@"\"+ Path2ZefModul;
				}
				
				ZefaniaCache ZefCache = new ZefaniaCache(Path2ZefModul);
				ZefCache.BaseCacheDir=AppPath;
				
				ZefCache.CreateCacheChapters(false);
                
				System.Xml.XmlDocument Config=new XmlDocument();

				if(File.Exists(AppPath+@"\config.xml"))
				{
                   
					Config.Load(AppPath+@"\config.xml");
				
				}
				else{
				    Config.LoadXml("<module></module>");
				}
				
				XmlNode Modul=Config.DocumentElement.SelectSingleNode("descendant::modul[@name='"+ZefCache.GetBibleName+"' and text()='"+ZefCache.ModulMD5+"']");
				
				if(Modul==null){
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
			  
			catch( FileNotFoundException e){
			
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
			string xslFileName)
		{
			try
			{
				XPathDocument xmldoc = new XPathDocument(xmlSourceFileName);
				// Instanz der Klasse XslTransform erzeugen
				XslTransform xslTransform = new XslTransform();
				// XSL-Datei laden
				xslTransform.Load(xslFileName);
				//Create an XmlTextWriter which outputs to the console.
				XmlWriter writer = new XmlTextWriter(Console.Out);

                
				// XML-Datei transformieren
				xslTransform.Transform(xmldoc,null,writer, null);

			}
			catch(XmlException e)
			{
				Console.WriteLine("Exception {0}", e);
				Environment.Exit(1900);
			
			}
		}


	}
}
