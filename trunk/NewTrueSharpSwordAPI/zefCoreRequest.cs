using System;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;


namespace NewTrueSharpSwordAPI.Queries
{
	/// <summary>
	/// Mit zefCoreRequest kann ein Zefania XML Cache mit einer Liste von Bibelstellen im
	/// Format:
	/// 40:7:9
	/// 56:12:7
	/// 19:4:5
	/// abgefragt werden.
	/// </summary>
	public class zefCoreRequest
	{
		StringBuilder ResultXMLStringX=new StringBuilder(5000);
		/// <summary>
		///  Dieser Event wird ausgelöst, wenn die Abfrage komplett beendet wurde.
		/// </summary>
		/// <remarks>Das Ergebnis kann dann über <seealso cref="ResultRequestPages"/> untersucht werden.</remarks>
		public delegate void OnRequestFinishedEventHandler(object sender, EventArgs e, ArrayList ResultList);
		/// <summary>
		/// <seealso cref="OnRequestFinishedEventHandler"/>
		/// </summary>
		public event OnRequestFinishedEventHandler OnRequestFinished;
		/// <summary>
		///  Dieser Event wird ausgelöst, wenn eine Seite für eine Abfrage erstellt wurde.
		/// </summary>
		public delegate void OnRequestPageEventHandler(object sender, EventArgs e, string XmlRequestPage);
		/// <summary>
		/// <seealso cref="OnRequestPageEventHandler"/>
		/// </summary>
		public event OnRequestPageEventHandler OnPageRequest;
		/// <summary>
		/// Die Anzahl der Verse auf einer Ergebnisseite
		/// </summary>
		private int FMaxVersePerPage;
		/// <summary>
		/// Eine Liste der BaseCacheDirs.
		/// </summary>
		private ArrayList FCacheDirectories;
		/// <summary>
		/// Eine Liste für die Ergebnise einer Abfrage.
		/// </summary>
		private ArrayList FResultRequestPages;
		/// <summary>
		/// Die Liste der abzufragenden Bibelmodule identifiziert durch ihren MD5-Hashwert.
		/// </summary>
		private ArrayList FMD5ModulDirList;
		/// <summary>
		/// Setzt oder liest die Liste der Cache-Verzeichnise
		/// </summary>
		public ArrayList CacheDirectories
		{
			get
			{
				return FCacheDirectories;
			}
			set
			{
				FCacheDirectories=value;
			}
		}
		/// <summary>
		/// Die Liste der abzufragenden Zefania XML Bibelmodule.
		/// </summary>
		public ArrayList MD5ModulDirList
		{

			get
			{
				return FMD5ModulDirList;
			}
			set
			{

				FMD5ModulDirList=value;

			}

		}
		/// <summary>
		/// Liefert die Liste der Ergebniseiten zurück;
		/// </summary>
		public ArrayList ResultRequestPages
		{

			get
			{

				return FResultRequestPages;

			}

		}
		/// <summary>
		/// Setzt oder liest die maxmimal Anzahl der Verse auf einer Ergebnisseite
		/// </summary>
		public int MaxVersePerPage
		{

			get
			{
				return FMaxVersePerPage;

			}
			set
			{
				FMaxVersePerPage=value;
			}

		}

		/// <summary>
		/// Gibt die Versionsnummer der CoreRequest-Klasse zurück.
		/// </summary>
		public string CoreRequestVersion
		{

			get
			{
				Version v =new Version("0.0.0.7");
				return v.Major+"."+v.Minor+"."+v.Revision+"."+v.Build;

			}

		}
		public zefCoreRequest()
		{
			FMaxVersePerPage=50;
			FCacheDirectories=new ArrayList();
			FResultRequestPages=new ArrayList();
			FMD5ModulDirList=new ArrayList();
		}
		/// <summary>
		/// Diese Methode leitet die Abfrage ein.
		/// </summary>
		/// <param name="VersesItems">Die Liste der einzelnen Bibelverse im Format BN:CN:VN</param>
		/// <returns>true, wenn Ergebnisverse vorhanden sind</returns>
		public bool GetRequest(ArrayList VersesItems)
		{
			// vorhergehende Ergebnisliste löschen
			FResultRequestPages.Clear();
			ArrayList SubVerses=new ArrayList();

			try
			{   // Versanzahl auf Requestpages berechnen.
				decimal SubCount=(MaxVersePerPage/FMD5ModulDirList.Count);

				int LOWER=0;

				int UPER=Convert.ToInt16(SubCount);

				if(UPER==0){UPER=1;SubCount=1;}

				decimal CountPages=VersesItems.Count/SubCount;

				for (int i = 1; i<= Convert.ToInt16(CountPages)-1 ; i++)
				{
					SubVerses=VersesItems.GetRange(LOWER,UPER);
					LOWER=i*UPER;
					BuildResultPage(SubVerses);
				}

				if(LOWER+UPER<=VersesItems.Count)
				{

					SubVerses=VersesItems.GetRange(LOWER,UPER);
					LOWER=LOWER+UPER;
					BuildResultPage(SubVerses);

				}

				if(LOWER<VersesItems.Count)
				{

					SubVerses=VersesItems.GetRange(LOWER,VersesItems.Count-LOWER);
					BuildResultPage(SubVerses);
				}


				if(FResultRequestPages.Count!=0)
				{
					if(OnRequestFinished!=null)
					{
						EventArgs e1=new EventArgs();
						OnRequestFinished(this,e1,ResultRequestPages);
					}
					return true;
				}
				else
					return false;

			}
			catch(Exception e)
			{

				return false;

			}


		}// end getRequest
		/// <summary>
		///  Erzeugt eine Ergebnisseite mit Versen durch Abfrage des ModulCaches.
		/// </summary>
		/// <param name="SubVerses">Enthält eine Untermenge der VerseItems Liste abhängig von MaxVersePerPage
		/// und Anzahl der Bibelausgaben in FMD5ModulDirList.
		/// <seealso cref="GetRequest"/> </param>
		private void BuildResultPage(ArrayList SubVerses)
		{

			string BN,CN,VN;
			string PathToCachedFile="";
			string[] VersItemArray;

			ResultXMLStringX.Length=0;

			try
			{
				ResultXMLStringX.Append("<XMLBIBLE xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"zef2005.xsd\" version=\"2.0.0.2\" status=\"v\" biblename=\"internal\" type=\"x-other\" >\n<INFORMATION/>");

				foreach(string VersItem in SubVerses)
				{
					// eventuell vorhandene Leerzeichen entfernen.

					VersItemArray=VersItem.Split(':');
					BN=VersItemArray[0].Trim();CN=VersItemArray[1].Trim();VN=VersItemArray[2].Trim();
					// wir gehen alle Modul IDs durch


					ResultXMLStringX.Append("<BIBLEBOOK bnumber=\""+BN+"\">\n<CHAPTER cnumber=\""+CN+"\">\n");

					int CountTransLations=0;

					foreach(string ModulMD5 in FMD5ModulDirList)
					{
						// wir durchsuchen CacheDIRS, die an verschiedenen Speicherorten liegen können.
						CountTransLations++;
						foreach(string CacheDir in FCacheDirectories)
						{
							// teste ob ein file vom type x-books vorliegt
							PathToCachedFile=CacheDir+@"\"+ModulMD5+@"\"+BN+".xml";

							if(File.Exists(PathToCachedFile))
							{
								// Cache mit x-Books gefunden
								// Vers ergänzen mit id
								// 
								GetVerseXBooks(CountTransLations,PathToCachedFile,BN,CN,VN);

								// ok nächste Modul ID
								continue;

							}

							// teste ob ein file vom type x-chapters vorliegt
							PathToCachedFile=CacheDir+@"\"+ModulMD5+@"\"+BN+"_"+CN+".xml";
							if(File.Exists(PathToCachedFile))
							{
								// Cache mit x-chapters gefunden	
								GetVerseXChapters(CountTransLations,PathToCachedFile,BN,CN,VN);
								// ok nächste Modul ID
								continue;
							}

							//zip files

							PathToCachedFile=CacheDir+@"\"+ModulMD5+@"\"+BN+".zip";

							if(File.Exists(PathToCachedFile))
							{
								// Cache mit x-Books gefunden
								// Vers ergänzen mit id
								// 
								GetVerseXBooksZip(CountTransLations,PathToCachedFile,BN,CN,VN);
								// ok nächste Modul ID
								continue;
							}

							PathToCachedFile=CacheDir+@"\"+ModulMD5+@"\"+BN+"_"+CN+".zip";
							if(File.Exists(PathToCachedFile))
							{
								// Cache mit x-chapters gefunden	
								GetVerseXChaptersZip(CountTransLations,PathToCachedFile,BN,CN,VN);
								// ok nächste Modul ID
								continue;
							}
							else 
								ResultXMLStringX.Append("\n"+"<VERS id=\""+CountTransLations.ToString()+"\" vnumber=\""+VN+"\">--</VERS>");




						}//end CacheDir

					}	// end ModulMd5

					ResultXMLStringX.Append("\n</CHAPTER>\n</BIBLEBOOK>");

				}

				ResultXMLStringX.Append("\n</XMLBIBLE>");
				FResultRequestPages.Add(AddAppInfo(ResultXMLStringX.ToString()));

				if(OnPageRequest!=null)
				{
					// Page Request Event feuern
					EventArgs e1=new EventArgs();
					OnPageRequest(this,e1,ResultXMLStringX.ToString());
				}

			}
			catch(Exception e)
			{

			}

		}
		/// <summary>
		///  Liefert aus einem x-chapters file den Verstext incl. XML-Markup zurück.
		/// </summary>
		/// <param name="PathToCachedBookFile">Der Pfad zur Buchdatei im Cache.</param>
		/// <param name="BN">Die Buchnummer</param>
		/// <param name="CN">Die Kapitelnummer</param>
		/// <param name="VN">Die Versnummer</param>
		/// <param name="TranslationID">Die Übersetzungen durchzählen</param>
		private void GetVerseXChapters(int TranslationID,string PathToCachedBookFile,string BN,string CN,string VN)
		{
			bool VersFound=false;
			XmlTextReader ModulReader=new XmlTextReader(PathToCachedBookFile);
			// was ist das?
			object oChapter = ModulReader.NameTable.Add("CHAPTER");
			object oCaption = ModulReader.NameTable.Add("CAPTION");
			object oVers = ModulReader.NameTable.Add("VERS");
			object oRemark = ModulReader.NameTable.Add("REMARK");
			object oXref = ModulReader.NameTable.Add("XREF");
			// vergL: http://tinyurl.com/dfumx
			try
			{
				while (ModulReader.Read()) 
				{

					if(ModulReader.Name.Equals(oCaption))
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string caption=ModulReader.ReadOuterXml();
							caption=caption.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(caption);

						}

					}


					if((ModulReader.Name.Equals(oRemark))&VersFound)
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string remark=ModulReader.ReadOuterXml();
							remark=remark.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(remark);

						}

					}

					if((ModulReader.Name.Equals(oXref))&VersFound)
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string xref=ModulReader.ReadOuterXml();
							xref=xref.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(xref);

						}

					}

					if(ModulReader.Name.Equals(oVers))
					{
						if (VersFound)
						{
							// wir können abrechen, da nächster vers gefunden ist.
							break;}
						if(ModulReader.GetAttribute("vnumber")==VN)
						{   

							// Sodele Vers gefunden!
							string vers=ModulReader.ReadOuterXml();
							vers=vers.Replace("vnumber=","id=\""+TranslationID.ToString()+"\" vnumber=");
							ResultXMLStringX.Append(vers);

							VersFound=true;


						}
					}
				}// end while
				if( VersFound==false)
				{
					ResultXMLStringX.Append("<VERS id=\""+TranslationID.ToString()+"\" vnumber=\""+VN+"\">--</VERS>");		
				}

			}
			catch(Exception e)
			{



			}


		}
		/// <summary>
		///  Liefert aus einem x-chapters zipped file den Verstext incl. XML-Markup zurück.
		/// </summary>
		/// <param name="PathToCachedBookFile">Der Pfad zur zip Buchdatei im Cache.</param>
		/// <param name="BN">Die Buchnummer</param>
		/// <param name="CN">Die Kapitelnummer</param>
		/// <param name="VN">Die Versnummer</param>
		/// <param name="TranslationID">Übersetzungen durchzählen</param>
		private void GetVerseXChaptersZip(int TranslationID,string PathToCachedBookFile,string BN,string CN,string VN)
		{
			bool VersFound=false;
			ZipInputStream s = new ZipInputStream(File.OpenRead(PathToCachedBookFile));

			s.GetNextEntry();

			XmlTextReader ModulReader=new XmlTextReader(s);
			// was ist das?
			object oChapter = ModulReader.NameTable.Add("CHAPTER");
			object oCaption = ModulReader.NameTable.Add("CAPTION");
			object oVers = ModulReader.NameTable.Add("VERS");
			object oRemark = ModulReader.NameTable.Add("REMARK");
			object oXref = ModulReader.NameTable.Add("XREF");
			// vergL: http://tinyurl.com/dfumx

			try
			{
				while (ModulReader.Read()) 
				{

					if(ModulReader.Name.Equals(oCaption))
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string caption=ModulReader.ReadOuterXml();
							caption=caption.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(caption);

						}

					}

					if((ModulReader.Name.Equals(oRemark))&VersFound)
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string remark=ModulReader.ReadOuterXml();
							remark=remark.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(remark);

						}

					}

					if((ModulReader.Name.Equals(oXref)&VersFound))
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string xref=ModulReader.ReadOuterXml();
							xref=xref.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(xref);

						}

					}

					if(ModulReader.Name.Equals(oVers))
					{
						if (VersFound)
						{
							// wir können abrechen, da nächster vers gefunden ist.
							break;}
						if(ModulReader.GetAttribute("vnumber")==VN)
						{   

							// Sodele Vers gefunden!
							string vers=ModulReader.ReadOuterXml();
							vers=vers.Replace("vnumber=","id=\""+TranslationID.ToString()+"\" vnumber=");
							ResultXMLStringX.Append(vers);

							VersFound=true;


						}
					}
				}// end while
				s.Close();
				if( VersFound==false)
				{
					ResultXMLStringX.Append("<VERS id=\""+TranslationID.ToString()+"\" vnumber=\""+VN+"\">--</VERS>");	
				}


			}
			catch(Exception e)
			{
				s.Close();


			}


		}

		/// <summary>
		/// Liefert aus einem x-books file den Verstext incl. XML-Markup zurück.
		/// </summary>
		/// <param name="PathToCachedBookFile">Der Pfad zur Buchdatei im Cache.</param>
		/// <param name="BN">Die Buchnummer</param>
		/// <param name="CN">Die Kapitelnummer</param>
		/// <param name="VN">Die Versnummer</param>
		/// <param name="TranslationID">Übersetzungen durchzählen</param>
		private void GetVerseXBooks(int TranslationID,string PathToCachedBookFile,string BN,string CN,string VN)
		{

			bool ChapterFound=false;
			bool VersFound=false;

			XmlTextReader ModulReader=new XmlTextReader(PathToCachedBookFile);

			// was ist das?
			object oChapter = ModulReader.NameTable.Add("CHAPTER");
			object oCaption = ModulReader.NameTable.Add("CAPTION");
			object oVers = ModulReader.NameTable.Add("VERS");
			object oRemark = ModulReader.NameTable.Add("REMARK");
			object oXref = ModulReader.NameTable.Add("XREF");

			// vergL: http://tinyurl.com/dfumx

			try
			{   
				while (ModulReader.Read()) 
				{



					if(ModulReader.Name.Equals(oChapter))
					{   
						if(ModulReader.GetAttribute("cnumber")==CN)
						{   
							ChapterFound=true;
						}

					}

					if((ModulReader.Name.Equals(oCaption))&ChapterFound)
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string caption=ModulReader.ReadOuterXml();
							caption=caption.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(caption);

						}

					}

					if((ModulReader.Name.Equals(oRemark))&VersFound)
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string remark=ModulReader.ReadOuterXml();
							remark=remark.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(remark);

						}

					}

					if((ModulReader.Name.Equals(oXref))&VersFound)
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string xref=ModulReader.ReadOuterXml();
							xref=xref.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(xref);

						}

					}

					if((ModulReader.Name.Equals(oVers))&ChapterFound)
					{
						if (VersFound)
						{
							// wir können abrechen, da nächster vers gefunden ist.
							break;}
						if(ModulReader.GetAttribute("vnumber")==VN)
						{   

							// Sodele Vers gefunden!
							string vers=ModulReader.ReadOuterXml();
							vers=vers.Replace("vnumber=","id=\""+TranslationID.ToString()+"\" vnumber=");
							ResultXMLStringX.Append(vers);

							VersFound=true;


						}
					}


				}//end while
				if( VersFound==false)
				{
					ResultXMLStringX.Append("<VERS id=\""+TranslationID.ToString()+"\" vnumber=\""+VN+"\">--</VERS>");		
				}

			}
			catch(Exception e)
			{



			}


		}// end get x-books

		/// <summary>
		/// Liefert aus einem x-books zipped file den Verstext incl. XML-Markup zurück.
		/// </summary>
		/// <param name="PathToCachedBookFile">Der Pfad zur zip Buchdatei im Cache.</param>
		/// <param name="BN">Die Buchnummer</param>
		/// <param name="CN">Die Kapitelnummer</param>
		/// <param name="VN">Die Versnummer</param>
		/// <param name="TranslationID">Übersetzungen durchzählen</param>
		private void GetVerseXBooksZip(int TranslationID,string PathToCachedBookFile,string BN,string CN,string VN)
		{

			bool ChapterFound=false;
			bool VersFound=false;

			ZipInputStream s = new ZipInputStream(File.OpenRead(PathToCachedBookFile));

			s.GetNextEntry();

			XmlTextReader ModulReader=new XmlTextReader(s);
			// was ist das?
			object oChapter = ModulReader.NameTable.Add("CHAPTER");
			object oCaption = ModulReader.NameTable.Add("CAPTION");
			object oVers = ModulReader.NameTable.Add("VERS");
			object oRemark = ModulReader.NameTable.Add("REMARK");
			object oXref = ModulReader.NameTable.Add("XREF");
			// vergL: http://tinyurl.com/dfumx
			try
			{   
				while (ModulReader.Read()) 
				{


					if(ModulReader.Name.Equals(oChapter))
					{   
						if(ModulReader.GetAttribute("cnumber")==CN)
						{   
							ChapterFound=true;
						}

					}

					if((ModulReader.Name.Equals(oCaption))&ChapterFound)
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string caption=ModulReader.ReadOuterXml();
							caption=caption.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(caption);

						}

					}

					if((ModulReader.Name.Equals(oRemark))&VersFound)
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string remark=ModulReader.ReadOuterXml();
							remark=remark.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(remark);

						}

					}

					if((ModulReader.Name.Equals(oXref))&VersFound)
					{   
						if(ModulReader.GetAttribute("vref")==VN)

						{   
							string xref=ModulReader.ReadOuterXml();
							xref=xref.Replace("vref=","id=\""+TranslationID.ToString()+"\" vref=");
							ResultXMLStringX.Append(xref);

						}

					}


					if((ModulReader.Name.Equals(oVers))&ChapterFound)
					{
						if (VersFound)
						{
							// wir können abrechen, da nächster vers gefunden ist.
							break;}
						if(ModulReader.GetAttribute("vnumber")==VN)
						{   

							// Sodele Vers gefunden!
							string vers=ModulReader.ReadOuterXml();
							vers=vers.Replace("vnumber=","id=\""+TranslationID.ToString()+"\" vnumber=");
							ResultXMLStringX.Append(vers);

							VersFound=true;


						}
					}


				}//end while
				s.Close();
				if( VersFound==false)
				{
					ResultXMLStringX.Append("<VERS id=\""+TranslationID.ToString()+"\" vnumber=\""+VN+"\">--</VERS>");		
				}	

			}
			catch(Exception e)
			{
				s.Close();


			}


		}// end get


		/// <summary>
		///  Fügt eine ResultPage die ApplicationInfo hinzu.
		/// </summary>
		/// <param name="ResultXml">Das XML Markup der RequestPage</param>
		/// <returns>Das XML Markup der RequestPage mit APPINFO</returns>
		private string AddAppInfo(string ResultXml)
		{

			XmlDocument XMLPage=new XmlDocument();
			string PathToCachedInfoFile;
			int CountTransLations=0;

			try
			{

				XMLPage.LoadXml(ResultXml);

				XmlNode APPINFO=XMLPage.DocumentElement.SelectSingleNode("descendant::APPINFO");

				if(APPINFO==null)
				{
					APPINFO=XMLPage.CreateNode(XmlNodeType.Element,"APPINFO","");
				}

				XmlAttribute ATT1=XMLPage.CreateAttribute("","client","");
				ATT1.Value="NewTrueSharpSwordAPI";
				APPINFO.Attributes.Append(ATT1);

				XmlAttribute ATT2=XMLPage.CreateAttribute("","version","");
				ATT2.Value="1.0.0.0";
				APPINFO.Attributes.Append(ATT2);

				foreach(string ModulMD5 in FMD5ModulDirList)
				{
					// wir durchsuchen CacheDIRS, die an verschiedenen Speicherorten liegen können.
					CountTransLations++;
					foreach(string CacheDir in FCacheDirectories)
					{
						PathToCachedInfoFile=CacheDir+@"\"+ModulMD5+@"\info.xml";

						if(File.Exists(PathToCachedInfoFile))
						{
							// Cache Info File gefunden

							XmlTextReader ModulReader=new XmlTextReader(PathToCachedInfoFile);
							while (ModulReader.Read()) 
							{
								if(ModulReader.Name=="title")
								{   
									XmlNode TRANSLATION=XMLPage.CreateNode(XmlNodeType.Element,"TRANSLATION","");
									TRANSLATION.InnerText=ModulReader.ReadString();
									XmlAttribute ATTID=XMLPage.CreateAttribute("","id","");
									ATTID.Value=CountTransLations.ToString();
									TRANSLATION.Attributes.Prepend(ATTID);
									APPINFO.AppendChild(TRANSLATION);
									XMLPage.DocumentElement.AppendChild(APPINFO);

								}

							}

							// ok nächste Modul ID

						}

					}//end CacheDir

				}// end ModulMD5

				return XMLPage.DocumentElement.OuterXml;

			}
			catch(Exception e)
			{

				return e.Message;

			}



		}// end AddAppInfo
	}
}
