using System;
using System.Collections;
using System.Xml;
using System.IO;

namespace NewTrueSharpSwordAPI.Queries
{
	/// <summary>
	/// Mit zefCoreRequest kann ein Zefania XML Cache mit einer Liste von Bibelstellen im
	/// Format:
	/// 40:7:9
	/// 56:12:7
	/// 19:4:5
	/// abgefragt werden.
	/// TODO: Zip-Support
	/// </summary>
	public class zefCoreRequest
	{
		/// <summary>
		///  Dieser Event wird ausgel�st, wenn die Abfrage komplett beendet wurde.
		/// </summary>
		/// <remarks>Das Ergebnis kann dann �ber <seealso cref="ResultRequestPages"/> untersucht werden.</remarks>
		public delegate void OnRequestFinishedEventHandler(object sender, EventArgs e, ArrayList ResultList);
		/// <summary>
		/// <seealso cref="OnRequestFinishedEventHandler"/>
		/// </summary>
		public event OnRequestFinishedEventHandler OnRequestFinished;
		/// <summary>
		///  Dieser Event wird ausgel�st, wenn eine Seite f�r eine Abfrage erstellt wurde.
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
		/// Eine Liste f�r die Ergebnise einer Abfrage.
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
		/// Liefert die Liste der Ergebniseiten zur�ck;
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
		/// Gibt die Versionsnummer der CoreRequest-Klasse zur�ck.
		/// </summary>
		public string CoreRequestVersion
		{

			get
			{
				Version v =new Version("0.0.0.3");
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
			// vorhergehende Ergebnisliste l�schen
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
					if(OnRequestFinished!=null){
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
		/// <param name="SubVerses">Enth�lt eine Untermenge der VerseItems Liste abh�ngig von MaxVersePerPage
		/// und Anzahl der Bibelausgaben in FMD5ModulDirList.
		/// <seealso cref="GetRequest"/> </param>
		private void BuildResultPage(ArrayList SubVerses)
		{

			string BN,CN,VN;
			string PathToCachedFile="";
			string[] VersItemArray;
			string ResultXMLString="";

			try
			{
				ResultXMLString=("<XMLBIBLE xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"zef2005.xsd\" version=\"2.0.0.2\" status=\"v\" biblename=\"internal\" type=\"x-other\" >\n<INFORMATION/>");

				foreach(string VersItem in SubVerses)
				{

					VersItemArray=VersItem.Split(':');
					BN=VersItemArray[0];CN=VersItemArray[1];VN=VersItemArray[2];
					// wir gehen alle Modul IDs durch


					ResultXMLString=ResultXMLString+"<BIBLEBOOK bnumber=\""+BN+"\">\n<CHAPTER cnumber=\""+CN+"\">\n";

					int CountTransLations=0;

					foreach(string ModulMD5 in FMD5ModulDirList)
					{
						// wir durchsuchen CacheDIRS, die an verschiedenen Speicherorten liegen k�nnen.
						CountTransLations++;
						foreach(string CacheDir in FCacheDirectories)
						{
							// teste ob ein file vom type x-books vorliegt
							PathToCachedFile=CacheDir+@"\"+ModulMD5+@"\"+BN+".xml";

							if(File.Exists(PathToCachedFile))
							{
								// Cache mit x-Books gefunden
								// Vers erg�nzen mit id
								// 
								ResultXMLString=ResultXMLString+"\n"+GetVerseXBooks(PathToCachedFile,BN,CN,VN).Replace("vnumber","id=\""+CountTransLations.ToString()+"\" vnumber");

								// ok n�chste Modul ID
								continue;
							}

							// teste ob ein file vom type x-chapters vorliegt
							PathToCachedFile=CacheDir+@"\"+ModulMD5+@"\"+BN+"_"+CN+".xml";
							if(File.Exists(PathToCachedFile))
							{
								// Cache mit x-Books gefunden	
								ResultXMLString=ResultXMLString+"\n"+GetVerseXChapters(PathToCachedFile,BN,CN,VN).Replace("vnumber","id=\""+CountTransLations.ToString()+"\" vnumber");
								// ok n�chste Modul ID
							}
							else
							{
								ResultXMLString=ResultXMLString+"\n"+"<VERS id=\""+CountTransLations.ToString()+"\" vnumber=\""+VN+"\">--</VERS>";
								continue;
							}

						}//end CacheDir

					}	// end ModulMd5

					ResultXMLString=ResultXMLString+"\n</CHAPTER>\n</BIBLEBOOK>";

				}

				ResultXMLString=ResultXMLString+"\n</XMLBIBLE>";
				FResultRequestPages.Add(AddAppInfo(ResultXMLString));
				
				if(OnPageRequest!=null){
				 // Page Request Event feuern
				 EventArgs e1=new EventArgs();
				 OnPageRequest(this,e1,ResultXMLString);
				}

			}
			catch(Exception e)
			{

			}

		}
		/// <summary>
		///  Liefert aus einem x-chapters file den Verstext incl. XML-Markup zur�ck.
		/// </summary>
		/// <param name="PathToCachedBookFile">Der Pfad zur Buchdatei im Cache.</param>
		/// <param name="BN">Die Buchnummer</param>
		/// <param name="CN">Die Kapitelnummer</param>
		/// <param name="VN">Die Versnummer</param>
		/// <returns>Verstext incl. XML-Markup</returns>
		private string GetVerseXChapters(string PathToCachedBookFile,string BN,string CN,string VN)
		{
			XmlTextReader ModulReader=new XmlTextReader(PathToCachedBookFile);
			try
			{
				while (ModulReader.Read()) 
				{
					if(ModulReader.Name=="VERS")
					{
						if((ModulReader.GetAttribute("vnumber")==VN))
						{
							// Sodele Vers gefunden!
							return ModulReader.ReadOuterXml();

						}
					}
				}
				return "<VERS vnumber=\""+VN+"\">--</VERS>";
			}
			catch(Exception e)
			{

				return e.Message;

			}


		}

		/// <summary>
		/// Liefert aus einem x-books file den Verstext incl. XML-Markup zur�ck.
		/// </summary>
		/// <param name="PathToCachedBookFile">Der Pfad zur Buchdatei im Cache.</param>
		/// <param name="BN">Die Buchnummer</param>
		/// <param name="CN">Die Kapitelnummer</param>
		/// <param name="VN">Die Versnummer</param>
		/// <returns>Verstext incl. XML-Markup</returns>
		private string GetVerseXBooks(string PathToCachedBookFile,string BN,string CN,string VN)
		{

			bool ChapterFound=false;

			XmlTextReader ModulReader=new XmlTextReader(PathToCachedBookFile);
			try
			{   
				while (ModulReader.Read()) 
				{


					if(ModulReader.Name=="CHAPTER")
					{   
						if(ModulReader.GetAttribute("cnumber")==CN)
						{   
							ChapterFound=true;
						}

					}
					if(ModulReader.Name=="VERS")
					{
						if((ModulReader.GetAttribute("vnumber")==VN)&ChapterFound)
						{   

							// Sodele Vers gefunden!
							return ModulReader.ReadOuterXml();

						}
					}


				}//end while
				return "<VERS vnumber=\""+VN+"\">--</VERS>";	

			}
			catch(Exception e)
			{

				return e.Message;

			}


		}// end get


		/// <summary>
		///  F�gt eine ResultPage die ApplicationInfo hinzu.
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
					// wir durchsuchen CacheDIRS, die an verschiedenen Speicherorten liegen k�nnen.
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

							// ok n�chste Modul ID

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
