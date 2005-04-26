using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
using System.Data;
using System.Text;


namespace NewTrueSharpSwordAPI.Cache
{

	/// <summary>
	/// Die Klasse ZefCache stellt Methoden zur Erstellung eines
	/// Cache für Zefania XML Bibelmodule zur Verfügung.
	/// </summary>
	public class ZefaniaCache
	{
		/// <summary>
		///  Dieser Event wird ausgelöst, wenn versucht wird ein nicht Zefania Modul zu cachen.
		/// </summary>
		public delegate void OnInvalidFileFormatEventHandler(object sender, EventArgs e);
		/// <summary>
		/// <seealso cref="OnInvalidFileFormatEventHandler"/>
		/// </summary>
		public event OnInvalidFileFormatEventHandler OnInvalidFileFormat;
		/// <summary>
		///  Dieser Event wird ausgelöst, wenn ein Userdefinierter Inhaltsbaum endeckt wurde.
		/// </summary>
		public delegate void OnUserTreeEventHandler(object sender, EventArgs e);
		/// <summary>
		///  <see cref="OnUserTreeEventHandler"/>
		/// </summary>
		public event OnUserTreeEventHandler OnUserTree;
		/// <summary>
		/// Variable zu Zwischenspeicherung des Inhaltsbaumes
		/// </summary>
		private XmlDocument ContentTree=new XmlDocument();
		/// <summary>
		/// Ereignishandler ausgelöst, wenn eine Zerlegung in Buch, Kapitel oder Vers stattgefunden hat.
		/// </summary>
		/// <remarks>
		///  Die ArrayList enthält im Index 0 einen Eintrag der Form x:x:x = BuchNr:KapitelNr:VersNr 
		///  Die ArrayList enthält im Index 1 den Dateipfad zur zerlegten Datei.
		/// </remarks>
		public delegate void OnSplittedEventHandler(object sender, EventArgs e,ArrayList message);
		/// <summary>
		/// Das Spliced Ereignis selbst.
		/// <seealso cref="OnSplittedEventHandler"/>
		/// </summary>
		public event OnSplittedEventHandler OnSplitted;
		/// <summary>
		///  Ereignishandler ausgelöst, wenn Cache erstellt ist.
		/// </summary>
		/// <remarks>
		///  Die ArrayList enthält im Index 0 den Pfad zum Cacheverzeichnis.
		/// </remarks>
		public delegate void OnCachedEventHandler(object sender, EventArgs e,ArrayList message);
		/// <summary>
		/// Das Cached-Ereignis selbst.
		/// <seealso cref="OnCachedEventHandler"/>
		/// </summary>
		public event OnCachedEventHandler OnCachedSuccess;
		/// <summary>
		/// Feld ist true, wenn Datei als Zefania XML Module erkannt wird.
		/// </summary>
		private bool IsZefaniaFormat=false;
		/// <summary>
		///   Feld ist true wenn Usertree existiert
		/// </summary>
		private bool UserDefTree;
		/// <summary>
		///  Feld für Bibelname
		/// </summary>
		private string BibleName;
		/// <summary>
		/// Cache ist gezipped
		/// </summary>
		private bool Zipped=false;
		/// <summary>
		///  Signalisiert intern, ob der Cache für das Zefania XML Bibelmodul schon erstellt wurde.
		/// </summary>
		private bool Cached=false;
		/// <summary>
		///  zeigt, ob Modulcache für die aktuelle Instanz schon erstellt wurde.
		/// </summary>
		public bool IsCached
		{
			get
			{
				return Cached;
			}
		}
		/// <summary>
		/// Zeigt, ob Cache gezipped ist.
		/// </summary>
		public bool IsZipped
		{
			get
			{
				return Zipped;
			}
		}
		/// <summary>
		/// Gibt den Bibelnamen für den Cache zurück
		/// </summary>
		public string GetBibleName
		{
			get
			{
				return BibleName;
			}
		 
		}

		/// <summary>
		/// Gibt True zurück wenn User InhaltsBaum existiert
		/// <seealso cref="RestoreUserTree"/>
		/// </summary>
		public bool HaveUserTree
		{
			get
			{
				return UserDefTree;
			}
		 
		}

		/// <summary>
		/// Gibt die Versionsnummer der ZefaniaCache-Klasse zurück.
		/// </summary>
		public string CacheVersion
		{

			get
			{
				Version v =new Version("0.1.0.17");
				return v.Major+"."+v.Minor+"."+v.Revision+"."+v.Build;

			}

		}
		

		/// <summary>
		///  Diese Funktion ersetzt den Default Inhaltsbaum durch einen eventuell gesicherten Userdefinierten
		/// </summary>
		public void RestoreUserTree()
		{
			try
			{
			    
				if(HaveUserTree)
				{
					XmlNode UTS=ContentTree.SelectSingleNode("descendant::tree");
					if(UTS!=null)
					{
						XmlDocument CacheINFO=new XmlDocument();
						CacheINFO.Load(FullCachePath+@"\info.xml");

						XmlNode UTSDefault=CacheINFO.SelectSingleNode("descendant::tree");
						
						UTSDefault.InnerXml=UTS.InnerXml;
						UTSDefault.Attributes.GetNamedItem("userdef").InnerText="true";

						CacheINFO.Save(FullCachePath+@"\info.xml");
						
					
					}
				
				}
				else
				{
					// nichts weiter tun, wenn kein UserTree vorhanden ist.
					return;

				}
		     
			}
			catch(Exception e)
			{
				
			}
		
		
		}

		/// <summary>
		///  Der komplette Pfad zum ModulCache-Verzeichnis
		/// </summary>
		private string FullCachePath;
		/// <summary>
		///  Diese Variable enthält das Modulverzeichnis für das in einzelnen Bibelbücher zerlegte Zefania XML-Modul.
		///  <seealso cref="CacheBaseDirectory"/>
		/// </summary>
		private string ModulCacheDir;
		/// <summary>
		/// Diese Variable enthält das Basisverzeichnis für den anzulegenden Cache.
		/// <seealso cref="BaseCacheDir"/>
		/// </summary>
		/// <remarks>
		///  Voreinstellung ist das Verzeichnis, das als allgemeines Repository für programmspezifische Daten verwendet wird, die von allen Benutzern verwendet werden.
		/// </remarks>
		private string CacheBaseDirectory;
		/// <summary>
		/// Setzt oder liest das Basisverzeichnis für den Cache.
		/// <seealso cref="CacheBaseDirectory"/>
		/// </summary>
		public string BaseCacheDir
		{
			get
			{
				return CacheBaseDirectory;
			}
			set
			{
				if(Directory.Exists(value))
				{
					CacheBaseDirectory=value;
				}
				else
				{
					Directory.CreateDirectory(value);
					CacheBaseDirectory=value;
				}
			}
		}

		/// <summary>
		/// Die Variable enthält den Dateipfad zum Zefania XML Bibelmodul.
		/// <seealso cref="ZefaniaCache"/>
		/// <seealso cref="Path"/>
		/// </summary>
		private string ModulPath;
		/// <summary>
		/// Die Eigenschaft "PathToModul" der Klasse ZefaniaCache liefert den Pfad zum Zefania XML Modul zurück;
		/// <seealso cref="ZefaniaCache"/>
		/// <seealso cref="ModulPath"/>
		/// </summary>
		public string PathToModul
		{

			get
			{
				return ModulPath;
			}

		}
		/// <summary>
		/// Konstruktor für die ZefaniaCache Klasse.
		/// <seealso cref="ModulPath"/>
		/// <seealso cref="Path"/>
		/// </summary>
		/// <remarks>
		///  Setzt das Cache-Basisverzeichnis auf das allgemeine Repository das für programmspezifische Daten verwendet wird, die von allen Benutzern verwendet werden.
		///  <seealso cref="CacheBaseDirectory"/>
		/// </remarks>
		/// <param name="pathToZefaniaModul">Dateipfad zu einem Zefania XML Bibelmodul</param>
		public ZefaniaCache(string pathToZefaniaModul)
		{
			//
			// Pfad zum Zefania XML Modul zur weiteren Verwendung sichern.
			//
			ModulPath=pathToZefaniaModul;
			//
			// Basisverzeichnis für Cache setzen.
			//
			BaseCacheDir=Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData);
		}
		/// <summary>
		/// Diese Methode berechnet aus dem Zefania XML Bibelmodul einen MD5-Hashwert, der als Verzeichnisname
		/// für das in Bibelbücher(Kapitel) zerlegte Zefania XML Bibelmodul dient.
		/// </summary>
		/// <returns>
		///   MD5-Hashwert des Zefania XML Bibelmoduls.
		/// </returns>
		private string CreateMD5Dir()
		{

			FileStream fs = File.OpenRead(ModulPath);
			try
			{
				MD5CryptoServiceProvider cryptHandler;
				cryptHandler = new MD5CryptoServiceProvider();
				byte[] hash = cryptHandler.ComputeHash(fs);
				string ret = "";
				foreach (byte a in hash) 
				{
					if (a<16)
						ret += "0" + a.ToString ("x");
					else
						ret += a.ToString ("x");
				}
				return ret ;
			}
			catch(Exception e)
			{
				return e.Message;
			}

		}

		/// <summary>
		///  Diese Methode erstellt den Cache für das Zefania XML Bibelmodul; Das Modul wird in einzelne Bibelbücher zerlegt.
		/// </summary>
		/// <remarks>Zerlegt ein Zefania XML Bibelmodul in einzelne Bibelbücher; Sollte der Cache schon existieren wird er zuerst gelöscht.</remarks>
		///<param name="zippedCache">Wenn zippedCache = true, werden die Bibelbücher gezipped</param>
		public void CreateCacheBooks(bool zippedCache)
		{
			try
			{
				
				
				Zipped=zippedCache;
				EventArgs e1=new EventArgs();

				ArrayList List=new ArrayList();

				ModulCacheDir=CreateMD5Dir();
				FullCachePath=BaseCacheDir+@"\zefcache\"+ModulCacheDir;
				// eventuell schon vorhandenen Inhaltsbaum sichern
				UserDefTree=CatchUserTree();
				// end

				if(Directory.Exists(FullCachePath)==true)
				{

					Directory.Delete(FullCachePath,true);

				}

				if(Directory.Exists(FullCachePath)==false)
				{

					Directory.CreateDirectory(FullCachePath);

				}
				//ModulCacheInfos
				XmlDocument CacheINFO=new XmlDocument();
				CacheINFO.LoadXml("<config><INFORMATION/><cacheinfo><sourcepath/><modulmd5/><zipped/><type/></cacheinfo></config>");
				
				XmlNode sourcepath=CacheINFO.SelectSingleNode("descendant::sourcepath");
				sourcepath.InnerText=ModulPath;

				XmlNode md5=CacheINFO.SelectSingleNode("descendant::modulmd5");
				md5.InnerText=ModulCacheDir;
				
				XmlNode zip=CacheINFO.SelectSingleNode("descendant::zipped");
				zip.InnerText=zippedCache.ToString();
				

				XmlNode type=CacheINFO.SelectSingleNode("descendant::type");
				type.InnerText="x-books";
				
			
				//endModuleCacheInfos
		     
				string book;
				string xmlbible="";
				string bnumber;
				XmlTextReader ModulReader=new XmlTextReader(ModulPath);
				while (ModulReader.Read()) 
				{
					if(ModulReader.Name=="XMLBIBLE")
					{

						xmlbible="";

						ModulReader.MoveToFirstAttribute();
						xmlbible=ModulReader.Name+"=\""+ModulReader.Value+"\" ";

						while(ModulReader.MoveToNextAttribute())
						{

							xmlbible=xmlbible+ModulReader.Name+"=\""+ModulReader.Value+"\" ";

						}
						xmlbible="<XMLBIBLE "+xmlbible+">";
						ModulReader.MoveToElement();

						IsZefaniaFormat=true;

					}// end XMLBIBLE

					if(ModulReader.Name=="BIBLEBOOK")
					{
						bnumber=ModulReader.GetAttribute("bnumber");
						book=ModulReader.ReadOuterXml();
						book=xmlbible+"<INFORMATION/>"+book+"</XMLBIBLE>";

						if(zippedCache)
						{
							
							
							UTF8Encoding utf8 = new UTF8Encoding();
        
							byte[]buffer = utf8.GetBytes(book);
							
							ZipOutputStream s = new ZipOutputStream(File.Create(FullCachePath+@"\"+bnumber+".zip"));
							s.SetLevel(9);

							ZipEntry entry = new ZipEntry(FullCachePath+@"\"+bnumber+".xml");
							s.PutNextEntry(entry);
							s.Write(buffer, 0, buffer.Length);

							s.Finish();
							s.Close();
							
						}
						else
						{
							StreamWriter sr = File.CreateText(FullCachePath+@"\"+bnumber+".xml");
							sr.WriteLine (book);
							sr.Close();
						}



						if(OnSplitted!=null)
						{
							List.Clear();
							List.Add(bnumber+":0:0");
							List.Add(FullCachePath+@"\"+bnumber+".xml");
							// Das Splitted-Ereignis auslösen
							OnSplitted(this,e1,List);

						}

					}// end Bibelbook
					// CopyDublinCore2CacheInfo
					
					if(ModulReader.Name=="INFORMATION")
					{
						XmlNode INFODC=CacheINFO.SelectSingleNode("descendant::INFORMATION");

						if(INFODC!=null)
						{
							INFODC.InnerXml=ModulReader.ReadInnerXml();
							XmlNode title=INFODC.SelectSingleNode("descendant::title");
							if(title!=null)
							{
								BibleName=title.InnerText;
							}
						};
					 
					}
					
					//endCopyDC

				}
				ModulReader.Close();
				Cached=true;
				// Invalid File Format
				if(IsZefaniaFormat==false)
				{
					// Invalid file event auslösen
					OnInvalidFileFormat(this,e1);
					return;
				
				}
				// end invalid file format
				
				CacheINFO.Save(FullCachePath+@"\info.xml");
				// Inhaltsbaum aufbauen
				CreateDefaultTree();
				// end Inhaltsbaum

				// eventuell userdefinierten Inhaltsbaum per Event melden
				if(OnUserTree!=null)
				{
					if(UserDefTree)
					{
					   
						OnUserTree(this,e1);
                        					
					}
				}
				// end 
				
				if(OnCachedSuccess!=null)
				{
					
					
					List.Clear();
					List.Add(FullCachePath);
					// Das Cached Ereignis auslösen.
					OnCachedSuccess(this,e1,List);

				}


			}
			catch(Exception e)
			{
				
				string x=e.Message;
			}

		}// end CreateCacheBooks()

		/// <summary>
		///  Diese Methode erstellt den Cache für das Zefania XML Bibelmodul; Das Modul wird in einzelne Kapitel zerlegt.
		/// </summary>
		/// <remarks>Zerlegt ein Zefania XML Bibelmodul in einzelne Bibelkapitel; Sollte der Cache schon existieren wird er zuerst gelöscht.</remarks>
		/// <param name="zippedCache">Wenn zippedCache = true, werden die Bibelkapitel gezipped.</param>
		public void CreateCacheChapters(bool zippedCache)
		{
			try
			{
				Zipped=zippedCache;
				EventArgs e1=new EventArgs();
				ArrayList List=new ArrayList();
				ModulCacheDir=CreateMD5Dir();
				FullCachePath=BaseCacheDir+@"\zefcache\"+ModulCacheDir;

				// eventuell schon vorhandenen Inhaltsbaum sichern
				UserDefTree=CatchUserTree();
				// end

				if(Directory.Exists(FullCachePath)==true)
				{

					Directory.Delete(FullCachePath,true);

				}

				if(Directory.Exists(FullCachePath)==false)
				{

					Directory.CreateDirectory(FullCachePath);

				}
				// ModulCacheInfos
				XmlDocument CacheINFO=new XmlDocument();
				CacheINFO.LoadXml("<config><INFORMATION/><cacheinfo><sourcepath/><modulmd5/><zipped/><type/></cacheinfo></config>");
				
				XmlNode sourcepath=CacheINFO.SelectSingleNode("descendant::sourcepath");
				sourcepath.InnerText=ModulPath;
				
				XmlNode md5=CacheINFO.SelectSingleNode("descendant::modulmd5");
				md5.InnerText=ModulCacheDir;
				
				XmlNode zip=CacheINFO.SelectSingleNode("descendant::zipped");
				zip.InnerText=zippedCache.ToString();
				

				XmlNode type=CacheINFO.SelectSingleNode("descendant::type");
				type.InnerText="x-chapters";
				
				// endModuleCacheInfos
				string chapter;
				string xmlbible="";
				string xmlbook="";
				string bnumber="0";
				string cnumber;
				XmlTextReader ModulReader=new XmlTextReader(ModulPath);
				while (ModulReader.Read()) 
				{

					if(ModulReader.Name=="XMLBIBLE")
					{

						xmlbible="";

						ModulReader.MoveToFirstAttribute();
						xmlbible=ModulReader.Name+"=\""+ModulReader.Value+"\" ";

						while(ModulReader.MoveToNextAttribute())
						{

							xmlbible=xmlbible+ModulReader.Name+"=\""+ModulReader.Value+"\" ";

						}
						xmlbible="<XMLBIBLE "+xmlbible+">";
						ModulReader.MoveToElement();
						IsZefaniaFormat=true;
					}// end XMLBIBLE


					if(ModulReader.Name=="BIBLEBOOK")
					{
						bnumber=ModulReader.GetAttribute("bnumber");
						xmlbook="<BIBLEBOOK bnumber=\""+bnumber+"\">";

					}// end Bibelbook

					if(ModulReader.Name=="CHAPTER")
					{

						cnumber=ModulReader.GetAttribute("cnumber");
						chapter=ModulReader.ReadOuterXml();
						chapter=xmlbible+"<INFORMATION/>"+xmlbook+chapter+"</BIBLEBOOK></XMLBIBLE>";


						if(zippedCache)
						{
							
							UTF8Encoding utf8 = new UTF8Encoding();
        
							byte[]buffer = utf8.GetBytes(chapter);

							ZipOutputStream s = new ZipOutputStream(File.Create(FullCachePath+@"\"+bnumber+"_"+cnumber+".zip"));
							s.SetLevel(9);

							ZipEntry entry = new ZipEntry(bnumber+"_"+cnumber+".xml");
							s.PutNextEntry(entry);
							s.Write(buffer, 0, buffer.Length);

							s.Finish();
							s.Close();
							

						}
						else
						{
							StreamWriter sr = File.CreateText(FullCachePath+@"\"+bnumber+"_"+cnumber+".xml");
							sr.WriteLine (chapter);
							sr.Close();
						}
						if(OnSplitted!=null)
						{
							List.Clear();
							List.Add(bnumber+":"+cnumber+":0");
							List.Add(FullCachePath+@"\"+bnumber+"_"+cnumber+".xml");
							// Das Splitted-Ereignis auslösen
							OnSplitted(this,e1,List);

						}

					}// end Chapter

					// CopyDublinCore2CacheInfo
					
					if(ModulReader.Name=="INFORMATION")
					{
						XmlNode INFODC=CacheINFO.SelectSingleNode("descendant::INFORMATION");
						if(INFODC!=null)
						{
							INFODC.InnerXml=ModulReader.ReadInnerXml();
							XmlNode title=INFODC.SelectSingleNode("descendant::title");
							if(title!=null)
							{
								BibleName=title.InnerText;
							}
						};
					 
					}

					//endCopyDC

				}
				ModulReader.Close();
				// Invalid File Format
				if(IsZefaniaFormat==false)
				{
					// Invalid file event auslösen
					OnInvalidFileFormat(this,e1);
					return;
				
				}
				// end invalid file format

				Cached=true;
				CacheINFO.Save(FullCachePath+@"\info.xml");
				// Inhaltsbaum aufbauen
				CreateDefaultTree();
				// end Inhaltsbaum
				// eventuell userdefinierten Inhaltsbaum per Event melden
				if(OnUserTree!=null)
				{
					if(UserDefTree)
					{
					   
						OnUserTree(this,e1);
                        					
					}
				}
				// end 
				if(OnCachedSuccess!=null)
				{
					List.Clear();
					List.Add(FullCachePath);
					// Das Cached Ereignis auslösen.
					OnCachedSuccess(this,e1,List);

				}

			}
			catch(Exception e)
			{
                 
			}

		}// end CreateCacheBooks()
		/// <summary>
		///  Diese Methode erzeugt aus dem Zefania XML Modul einen Inhaltsbaum für die Verwendung 
		///  in Bibelnavigations Klassen. 
		/// </summary>
		private void CreateDefaultTree()
		{
			try
			{   
				XmlDocument CacheInfo=new XmlDocument();
				CacheInfo.Load(FullCachePath+@"\info.xml");

				XmlNode attr00=CacheInfo.CreateNode(XmlNodeType.Attribute,"title","");
				attr00.InnerText=GetBibleName;
				XmlNode attr01=CacheInfo.CreateNode(XmlNodeType.Attribute,"userdef","");
				attr01.InnerText="false";
				
				XmlNode ContentTree =CacheInfo.CreateNode(XmlNodeType.Element,"tree","");
				ContentTree.Attributes.SetNamedItem(attr00);
				ContentTree.Attributes.SetNamedItem(attr01);

				XmlNode attr1=CacheInfo.CreateNode(XmlNodeType.Attribute,"title","");
				
				XmlNode AT_Node=CacheInfo.CreateNode(XmlNodeType.Element,"group","");
				
				attr1.InnerText="AT";
				AT_Node.Attributes.SetNamedItem(attr1);
				ContentTree.AppendChild(AT_Node);

				XmlNode attr2=CacheInfo.CreateNode(XmlNodeType.Attribute,"title","");
				
				XmlNode NT_Node=CacheInfo.CreateNode(XmlNodeType.Element,"group","");;
				attr2.InnerText="NT";
				NT_Node.Attributes.SetNamedItem(attr2);
				ContentTree.AppendChild(NT_Node);

				XmlNode attr3=CacheInfo.CreateNode(XmlNodeType.Attribute,"title","");
				XmlNode AP_Node=CacheInfo.CreateNode(XmlNodeType.Element,"group","");;
				attr3.InnerText="AP";
				AP_Node.Attributes.SetNamedItem(attr3);
				ContentTree.AppendChild(AP_Node);
				CacheInfo.DocumentElement.AppendChild(ContentTree);
                
				
				string[] Books;
						
				if(IsZipped)
				{	
					Books=Directory.GetFiles(FullCachePath,"*.zip");
				}
				else
				{
						
					Books=Directory.GetFiles(FullCachePath,"*.xml");
				}
				string ChapterNumber="0";string BookNumber="0";
				XmlTextReader ModulReader=null;
				
				UTF8Encoding utf8 = new UTF8Encoding();
				foreach(string BookFile in Books)
				{
					MemoryStream sr =new MemoryStream();
					if(Path.GetFileName(BookFile)=="info.xml"){continue;}


					if(IsZipped)
					{
					
						
						
						ZipInputStream s = new ZipInputStream(File.OpenRead(BookFile));
						ZipEntry theEntry;
 
						while ((theEntry = s.GetNextEntry()) != null) 
						{
							int nBytes = 2048;
							byte[] data = new byte[2048];
							while((nBytes = s.Read(data, 0, data.Length))  > 0)
							{   
								
								byte[]buffer = utf8.GetBytes(utf8.GetString(data, 0, nBytes));
								sr.Write(buffer,0,buffer.Length);
								
							}
							
							
						}
						
						s.Close();
						sr.Position=0;
						ModulReader = new XmlTextReader(sr);
						
						
					}
					else
					{

						ModulReader = new XmlTextReader(BookFile);
					
					}
                    
					while (ModulReader.Read()) 
					{
						if(ModulReader.Name=="BIBLEBOOK")
						{
								 
							BookNumber=ModulReader.GetAttribute("bnumber");
										
						}
						if(ModulReader.Name=="CHAPTER")
						{
								 
							ChapterNumber=ModulReader.GetAttribute("cnumber");
							if(ChapterNumber==null){continue;}
							XmlNode Entry =CacheInfo.CreateNode(XmlNodeType.Element,"item","");
							XmlNode attr5=CacheInfo.CreateNode(XmlNodeType.Attribute,"bn","");
							XmlNode attr6=CacheInfo.CreateNode(XmlNodeType.Attribute,"cn","");
									
							XmlNode attr8=CacheInfo.CreateNode(XmlNodeType.Attribute,"active","");
							attr5.InnerText=BookNumber;
							attr6.InnerText=ChapterNumber;
									
							attr8.InnerText=false.ToString();
							Entry.Attributes.SetNamedItem(attr5);
							Entry.Attributes.SetNamedItem(attr6);
									
							Entry.Attributes.SetNamedItem(attr8);
							if(Convert.ToInt16(BookNumber)<40)
							{
								AT_Node.AppendChild(Entry);
								
							}
							if(Convert.ToInt16(BookNumber)>39&Convert.ToInt16(BookNumber)<67)
							{
								NT_Node.AppendChild(Entry);
								
							}

							if(Convert.ToInt16(BookNumber)>66)
							{
								AP_Node.AppendChild(Entry);
								
							}
										
						}
                           
					}// end while

					ModulReader.Close();
					sr.Close();
					

				}// end foreach

				CacheInfo.Save(FullCachePath+@"\info.xml");
              
				
			}
			catch(Exception e)
			{
				
			}
	
		}
		/// <summary>
		///  Liest eine eventuell vorhandene Cache Info Datei und sichert, falls vorhanden, einen durch den User veränderten Inhaltsbaum
		///  in der Variable ContentTree <seealso cref="ContentTree"/>
		/// </summary>
		/// <returns>Gibt True zurück, wenn ein Userdefinierter Inhaltsbaum gefunden wurde.</returns>
		private bool CatchUserTree()
		{

			try
			{
				if(File.Exists(FullCachePath+@"\info.xml"))
				{
					ContentTree.Load(FullCachePath+@"\info.xml");
					XmlNode UT=ContentTree.SelectSingleNode("descendant::tree/@userdef");
					if(UT!=null)
					{
						if(UT.InnerText=="false")
						
						{return false;}

						if(UT.InnerText=="true")
						
						{return true;}
					
					}
					else
					{
					
						return false;

					}

				}
				else
				{
					return false;
				}
				return false;
			}
			catch(Exception e)
			{
				return false;   
			}
		
		}
	}
		
}	