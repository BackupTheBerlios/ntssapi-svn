using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Threading;
using System.Collections.Specialized;
using ICSharpCode.SharpZipLib.Zip;
using System.Security.Cryptography;

namespace NewTrueSharpSwordAPI.Cache
{
	/// <summary>
	/// zefCacheMaintenance verwaltet, erstellt und liefert Informationen über den Zefania XML 
	/// ModulCache.
	/// </summary>
	[Serializable]
	public class zefCacheMaintenance
	{

		public delegate void OnCachedEventHandler(object sender, EventArgs e,string message);
		[field:NonSerialized]
		public event OnCachedEventHandler OnCacheProgress;
		[field:NonSerialized]
		public event OnCachedEventHandler OnCacheFinished;
		[field:NonSerialized]
		public event OnCachedEventHandler OnInvalidFormat;

		[field:NonSerialized]
		public event OnCachedEventHandler OnBuildListsProgress;




		/// <summary>
		/// Die Dateipfade aller Module in den Eingangsverzeichnissen
		/// </summary>
		private StringCollection FIncomingModulPaths=new StringCollection();
		/// <summary>
		/// Die Dateipfade aller info.xml 
		/// </summary>
		private StringCollection FCachedInfoFilesPaths=new StringCollection();	


		private CacheInfoItemDictionary FCacheInfoDictionary=new CacheInfoItemDictionary();
		/// <summary>
		/// Die Eingangsverzeichnisse für Zefania XML Module
		/// </summary>
		private StringCollection FListOfModulInputDirectories=new StringCollection();
		/// <summary>
		/// Liste der Speicherorte für  erstellte ModulCaches
		/// </summary>
		private StringCollection FListOfCacheDirectories=new StringCollection();
		/// <summary>
		/// Konstruktor
		/// </summary>
		public zefCacheMaintenance()
		{
			//
			// TODO: Fügen Sie hier die Konstruktorlogik hinzu
			//
		}


		public CacheInfoItemDictionary CacheInfoDictionary
		{

			get
			{

				return FCacheInfoDictionary;

			}


		}

		/// <summary>
		/// Die Liste der Eingangsverzeichnisse für Zefania XML Bibelmodule.
		/// </summary>
		public StringCollection ListOfModulInputDirectories
		{

			get
			{
				return FListOfModulInputDirectories;
			}
			set
			{

				FListOfModulInputDirectories=value;

			}

		}

		/// <summary>
		/// Die Liste der CacheVerzeichnisse der Zefania XML Bibelmodule.
		/// </summary>
		public StringCollection ListOfCacheDirectories
		{

			get
			{
				return FListOfCacheDirectories;
			}
			set
			{

				FListOfCacheDirectories=value;

			}

		}

		// Cache erzeugen mit Threads

		private class CacheFetchBooks
		{
			ZefaniaCache my_cache;
			bool my_zipped;

			public CacheFetchBooks (ZefaniaCache cache,bool zipped)
			{
				my_cache = cache;
				my_zipped=zipped;
			}

			public void Fetch()
			{
				my_cache.CreateCacheBooks(my_zipped);
			}
		}

		private class CacheFetchChapters
		{
			ZefaniaCache my_cache;
			bool my_zipped;

			public CacheFetchChapters (ZefaniaCache cache,bool zipped)
			{
				my_cache = cache;
				my_zipped=zipped;
			}

			public void Fetch()
			{
				my_cache.CreateCacheChapters(my_zipped);
			}
		}

        /// <summary>
		/// Diese Methode erstelle mit Hilfe der <see cref="ZefaniaCache"/> Klasse das Cachverzeichnis für das Modul.
        /// </summary>
        /// <param name="ModulPath">Der Pfad zum Zefania XML Bibelmodul</param>
        /// <param name="ID">Integerkennzeichnung für die Instanz der <see cref="ZefaniaCache"/>Klasse </param>
        /// <param name="zipped">Wenn true, besteht der Cache aus zipped Files</param>
        /// <param name="chapters">Wenn true ist der Cache vom Type x-chapters, sonst x-books</param>
		public void CreateCacheFromModul(string ModulPath,int ID,bool zipped,bool chapters)
		{

			try
			{  

				ZefaniaCache SingleCache=new ZefaniaCache(ModulPath);
				SingleCache.OnSplitted+=new NewTrueSharpSwordAPI.Cache.ZefaniaCache.OnSplittedEventHandler(SingleCache_OnSplitted);
				SingleCache.OnCachedSuccess+=new NewTrueSharpSwordAPI.Cache.ZefaniaCache.OnCachedEventHandler(SingleCache_OnCachedSuccess);
				SingleCache.OnInvalidFileFormat+=new NewTrueSharpSwordAPI.Cache.ZefaniaCache.OnInvalidFileFormatEventHandler(SingleCache_OnInvalidFileFormat);

				SingleCache.Tag=ID;

				if(chapters)
				{
					CacheFetchChapters fetcher = new CacheFetchChapters (SingleCache,zipped);
					new Thread (new ThreadStart (fetcher.Fetch)).Start();
				}
				else
				{
					CacheFetchBooks fetcher = new CacheFetchBooks (SingleCache,zipped);
					new Thread (new ThreadStart (fetcher.Fetch)).Start();
				}



			}
			catch(Exception e)
			{


			}
		}

		private void SingleCache_OnSplitted(object sender, EventArgs e, ArrayList message)
		{
			//
			EventArgs e1=new EventArgs();

			if(OnCacheProgress!=null)
			{

				OnCacheProgress(sender,e,message[0].ToString());

			}

		}

		private void SingleCache_OnCachedSuccess(object sender, EventArgs e, ArrayList message)
		{
			//
			EventArgs e1=new EventArgs();

			string SP=(sender as ZefaniaCache).GetPathToModul;
			string IP=(sender as ZefaniaCache).GetInfoPath;
		

            CacheInfoItem CII=new CacheInfoItem(IP,false);

            if(FCacheInfoDictionary.Contains(CII.Sourcepath)){FCacheInfoDictionary.Remove(CII.Sourcepath);}

            FCacheInfoDictionary.Add(SP,CII);

			if(OnCacheFinished!=null)
			{

				OnCacheFinished(sender,e,message[0].ToString());

			}

		}
		private void SingleCache_OnInvalidFileFormat(object sender, EventArgs e)
		{
			EventArgs e1=new EventArgs();

			if(OnInvalidFormat!=null)
			{


				OnInvalidFormat(this,e1,"");

			}
		}


		// ende Cache erzeugen mit Thread;




		private void RefreshCachedInfoFilesPathList()
		{

			try
			{
				FCachedInfoFilesPaths.Clear();
				foreach(string Dir in this.ListOfCacheDirectories)
				{
					DirectoryInfo DI=new DirectoryInfo(Dir);
					FindFilesInFolder("info.xml",DI,true,FCachedInfoFilesPaths,null);

				}

			}
			catch(Exception e)
			{

			}
		}

		/// <summary>
		///  Das <see cref="CacheInfoItemDictionary"/> updaten und optional die MD5-Hashwerte checken
		/// </summary>
		/// <param name="checkMd5">Wenn true, MD5 checken</param>
		private void RefreshCacheItemsList(bool checkMd5)
		{
			EventArgs e1=new EventArgs();
			try
			{
				FCacheInfoDictionary.Clear();
				foreach(string InfoPath in FCachedInfoFilesPaths)
				{
					CacheInfoItem CI=new CacheInfoItem(InfoPath,checkMd5);


					if(FCacheInfoDictionary.Contains(CI.Sourcepath)){FCacheInfoDictionary.Remove(CI.Sourcepath);}
					
					FCacheInfoDictionary.Add(CI.Sourcepath,CI);


					if(OnBuildListsProgress!=null)
					{

						OnBuildListsProgress(this,e1,CI.Title);

					}
				}

				foreach(string ModulPath in FIncomingModulPaths)
				{
					if(!CacheInfoDictionary.Contains(ModulPath))
					{
						CacheInfoItem CII=new CacheInfoItem(ModulPath,checkMd5);
						
						
					
						FCacheInfoDictionary.Add(CII.Sourcepath,CII);
						if(OnBuildListsProgress!=null)
						{

							OnBuildListsProgress(this,e1,CII.Title);

						}
					}
				}

			}


			catch(Exception e)
			{

			}

		}
		/// <summary>
		/// Löscht ein Cacheverzeichnis anhand des MD5-Hash Wertes
		/// </summary>
		/// <param name="MD5">Der MD5 Verzeichnisname des Caches</param>
		public void DeleteCacheByMD5(string MD5)
		{
			try
			{
				// Das CacheDictionary durchsuchen.
				foreach( DictionaryEntry entry in CacheInfoDictionary)
				{
					CacheInfoItem CI=(CacheInfoItem) entry.Value;
					if(CI.Modulmd5==MD5)
					{

						if(File.Exists(CI.Infopath))
						{

							// Cache löschen.
							string p=Path.GetDirectoryName(CI.Infopath);
							Directory.Delete(p,true);
							CI.reset2NoneCached();

						}


					}
				}

			}
			catch(Exception e)
			{

			}
		}
		/// <summary>
		///  Anhand des Sourcepfades im <see cref="CacheInfoItemDictionary"/> nach dem <see cref="CacheInfoItem"/> suchen
		///  und nachsehen, ob der in der info.xml hinterlegte MD5-Hashwert vom tatsächlichen MD5-Hash des Moduls abweicht.
		/// </summary>
		/// <remarks>Das kann geschehen, wenn das Sourcemodul editiert wurde</remarks>
		/// <param name="SourcePath">Der Pfad zum Sourcemodul</param>
		/// <returns>true, wenn MD5-Hash abweicht</returns>
		public bool IsInConsistent(string SourcePath)
		{

			try
			{
				foreach( DictionaryEntry entry in CacheInfoDictionary)
				{
					CacheInfoItem CI=(CacheInfoItem) entry.Value;
					if(CI.Sourcepath==SourcePath)
					{


						return CI.Inconsistent;

					}
				}

				return false;

			}
			catch(Exception e)
			{
				return true;
			}



		}
       
		/// <summary>
		/// Löscht  die Sourcedatei eine Caches
		/// </summary>
		/// <param name="SourcePath"></param>
		public void DeleteSourcePath(string SourcePath)
		{

			try
			{
				foreach( DictionaryEntry entry in CacheInfoDictionary)
				{
					CacheInfoItem CI=(CacheInfoItem) entry.Value;
					if(CI.Sourcepath==SourcePath)
					{

						if(File.Exists(CI.Sourcepath))
						{

							// Source löschen.
							
							File.Delete(CI.Sourcepath);
							CI.reset2Orphaned();
						

						}


					}
				}

			}
			catch(Exception e)
			{
				
			}


		}
        

        /// <summary>
        /// Löscht einen Cache anhand des Sourcepfad des Moduls
        /// </summary>
        /// <param name="SourcePath"></param>
		public void DeleteCacheBySourcePath(string SourcePath)
		{

			try
			{
				foreach( DictionaryEntry entry in CacheInfoDictionary)
				{
					CacheInfoItem CI=(CacheInfoItem) entry.Value;
					if(CI.Sourcepath==SourcePath)
					{

						if(File.Exists(CI.Infopath))
						{

							// Cache löschen.
							string p=Path.GetDirectoryName(CI.Infopath);
							Directory.Delete(p,true);
							CI.reset2NoneCached();

						}


					}
				}

			}
			catch(Exception e)
			{
				
			}


		}

		/// <summary>
		/// Alle Verzeichnislisten  und das <see cref="CacheInfoItemDictionary"/> aktualisieren.
		/// </summary>
		/// <param name="checkMd5">Wenn true, wird zusätzlich der MD5-Hashwert des Moduls überprüft.</param>
		public void refreshModulList(bool checkMd5)
		{

			try
			{
				RefreshIncomingModulPathList();
				RefreshCachedInfoFilesPathList();
				RefreshCacheItemsList(checkMd5);

			}
			catch(Exception e)
			{

			}
		}

		/// <summary>
		///  Alle Eingangsverzeichnisse nach möglichen Modulen durchsuchen und in <see cref="FIncomingModulPaths"/> auflisten.
		/// </summary>
		private void RefreshIncomingModulPathList()
		{

			try
			{
				FIncomingModulPaths.Clear();

				foreach(string Dir in ListOfModulInputDirectories)
				{
					DirectoryInfo DI=new DirectoryInfo(Dir);
					FindFilesInFolder("*.xml",DI,true,FIncomingModulPaths,null);
					FindFilesInFolder("*.zip",DI,true,FIncomingModulPaths,null);

				}

			}
			catch(Exception e)
			{

			}
		}


		/// <summary>
		/// Gibt die Versionsnummer der zefCacheMaintenance-Klasse zurück.
		/// </summary>
		public string CacheVersion
		{

			get
			{
				Version v =new Version("0.0.0.9");
				return v.Major+"."+v.Minor+"."+v.Revision+"."+v.Build;

			}

		}

		/// <summary>
		///  Diese Hilfsklasse speichert alle wichtigen Infos über Module.
		///  <see cref="CacheInfoItemDictionary"/>
		/// </summary>
		[Serializable]
			public class CacheInfoItem
		{
			private string Ftitle="";
			private string Fsourcepath="";
			private string Flanguage="";
			private string Fidentifier="";
			private string Fdate="";
			private string Fzipped="";
			private string Ftype="";
			private string Fmodulmd5="";
			private bool Forphaned=false;
			private bool Fcached=false;
			private bool Finconsistent=false;
			private string Finfopath;

			public CacheInfoItem(string InfoPath,bool checkMd5)
			{

				try
				{

					Fcached=false;
					Forphaned=false;
					Finfopath="";
					if(InfoPath.EndsWith("info.xml"))
					{
						XmlDocument INFO=new XmlDocument();
						INFO.Load(InfoPath);
						Finfopath=InfoPath;
						XmlNode N=INFO.DocumentElement.SelectSingleNode("descendant::INFORMATION/title");
						if(N!=null)
						{
							Ftitle=N.InnerText;
						}


						N=INFO.DocumentElement.SelectSingleNode("descendant::cacheinfo/sourcepath");

						if(N!=null)
						{
							Fsourcepath=N.InnerText;
							Forphaned=!File.Exists(Fsourcepath);
							Fcached=true;
						}

						N=INFO.DocumentElement.SelectSingleNode("descendant::INFORMATION/language");
						if(N!=null)
						{

							Flanguage=N.InnerText;
						}


						N=INFO.DocumentElement.SelectSingleNode("descendant::INFORMATION/identifier");

						if(N!=null)
						{

							Fidentifier=N.InnerText;
						}


						N=INFO.DocumentElement.SelectSingleNode("descendant::INFORMATION/date");

						if(N!=null)
						{

							Fdate=N.InnerText;
						}


						N=INFO.DocumentElement.SelectSingleNode("descendant::cacheinfo/zipped");

						if(N!=null)
						{
							Fzipped=N.InnerText;
						}


						N=INFO.DocumentElement.SelectSingleNode("descendant::cacheinfo/type");

						if(N!=null)
						{
							Ftype=N.InnerText;
						}

						N=INFO.DocumentElement.SelectSingleNode("descendant::cacheinfo/modulmd5");

						if(N!=null)
						{
							Fmodulmd5=N.InnerText;
							// nachfolgend überprüfen wir, ob der MD5-Hashwert der Quelldatei
							// noch mit dem Vermerk in der info.xml übereinstimmt.
							if(checkMd5)
							{



								if(Path.GetExtension(Sourcepath)==".zip")
								{
									// Zefania Modul aus zip entpacken
									Finconsistent=!(CreateMD5Dir(GetZippedModulContent(Sourcepath))==Fmodulmd5);

								}
								else
								{

									Finconsistent=!(CreateMD5Dir(File.OpenRead(Sourcepath))==Fmodulmd5);


								}
							}

						}
					}
					else
					{

						Fsourcepath=InfoPath;
						Ftitle=Path.GetFileName(InfoPath);


					}
				}

				catch(Exception e)
				{

				}
			}
			// methoden
			public void reset2NoneCached()
			{
			
				Fcached=false;
				Fdate="";
				Fidentifier="";
				Finconsistent=false;
				Finfopath="";
				Flanguage="";
				Fmodulmd5="";
				Forphaned=false;
				Ftype="";
				Fzipped="";
			}
            
			public void reset2Orphaned()
			{
			    Forphaned=true;
				
			}

			/// <summary>
			/// Diese Methode berechnet aus dem Zefania XML Bibelmodul einen MD5-Hashwert, der als Verzeichnisname
			/// für das in Bibelbücher(Kapitel) zerlegte Zefania XML Bibelmodul dient.
			/// </summary>
			/// <returns>
			///   MD5-Hashwert des Zefania XML Bibelmoduls.
			/// </returns>
			private string CreateMD5Dir(Stream fs)
			{

				//FileStream fs = File.Open(Path);

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
			/// Extrahiert ein Zefania XML Modul aus einem zip-archiv
			/// </summary>
			/// <param name="ModulPath">Pfade zur zip-datei</param>
			/// <returns>Zefania XML Modul als Stream.</returns>
			private ZipInputStream GetZippedModulContent(string ModulPath)
			{


				ZipEntry theEntry;


				try
				{

					ZipInputStream s = new ZipInputStream(File.OpenRead(ModulPath));
					while ((theEntry=s.GetNextEntry())!= null) 
					{

						if(theEntry.Size>40000)
						{

							return s;

						}	

					}
					return null;
				}

				catch(Exception e)
				{

					return null;
				}
			}




			// end methoden

			// felder
			public string Title
			{
				get{return Ftitle;}
				set{Ftitle=value;}
			}
			public string Sourcepath
			{
				get{return Fsourcepath;}
				set{Fsourcepath=value;}
			}
			public string Language
			{
				get{return Flanguage;}
				set{Flanguage=value;}
			}
			public string Identifier
			{
				get{return Fidentifier;}
				set{Fidentifier=value;}
			}

			public string Date
			{
				get{return Fdate;}
				set{Fdate=value;}
			}
			public string Zipped
			{
				get{return Fzipped;}
				
			}
			public string Type
			{
				get{return Ftype;}
				
			}
			public string Modulmd5
			{
				get{return Fmodulmd5;}
				
			}

			public bool Orphaned
			{
				get{return Forphaned;}
				
				
			}
			public bool Cached
			{
				get{return Fcached;}
				
				
			}
			public bool Inconsistent
			{
				get{return Finconsistent;}
				
			}
			public string Infopath
			{
				get{return Finfopath;}
				
			}
		}// end class CacheInfoItem
		/// <summary>
		/// Ein Dictionary aller Module mit Instanzen von <see cref="CacheInfoItem"/>
		/// </summary>
		[Serializable]
			public class CacheInfoItemDictionary : DictionaryBase 
		{   //strongly typed accessor 
			public CacheInfoItem this[string key]
			{
				get {return (CacheInfoItem) this.Dictionary[key]; }

				set { this.Dictionary[key] = value; } 
			}
			//add a CacheInfoItem to the collection
			public void Add(string key, CacheInfoItem cacheinfoitem)
            { 
				this.Dictionary.Add(key, cacheinfoitem); 
			} 
			//see if collection contains an entry corresponding to key
			public bool Contains(string key)
			{
				return this.Dictionary.Contains(key);
			}

			public void Remove( string key )  
			{
				this.Dictionary.Remove( key );
			}


			//we will get to this later
			public ICollection Keys
			{
				get {return this.Dictionary.Keys;}
			}

		}// end CacheInfoItemCollection
		//


		// begin find files

		/* Delegate für eine Fortschrittsmeldung */

		public delegate void FindProgress(string folderName);

		/* Methode zum Suchen von Dateien in einem Ordner */
		private static StringCollection FindFiles(string folderName,
			string searchPattern, bool recurse, FindProgress findProgress)
		{
			// StringCollection-Objekt für die Rückgabe erzeugen
			StringCollection resultFiles =  new StringCollection();

			// DirectoryInfo-Objekt für den Ordner erzeugen
			DirectoryInfo folder = new DirectoryInfo(folderName);

			// Die rekursive Methode zum Suchen in einem Ordner aufrufen
			FindFilesInFolder(searchPattern, folder, recurse, resultFiles, 
				findProgress);

			// StringCollection zurückgeben
			return resultFiles;
		}

		/* Rekursive Methode zum Suchen von Dateien */
		private static void FindFilesInFolder(string searchPattern, 
			DirectoryInfo folder, bool recurse, StringCollection resultFiles,
			FindProgress findProgress)
		{
			// Delegate aufrufen, falls dieser übergeben wurde
			if (findProgress != null)
				findProgress(folder.FullName); 

			// Zunächst für alle Unterordner FindFilesInFolder rekursiv aufrufen, 
			// wenn dies gewünscht ist
			if (recurse)
			{
				DirectoryInfo[] subFolders = folder.GetDirectories();
				for (int i = 0; i < subFolders.Length; i++)
					FindFilesInFolder(searchPattern, subFolders[i], true, resultFiles,
						findProgress);
			}

			// Alle Dateien ermitteln, die dem übergebenen Suchmuster entsprechen 
			FileInfo[] files = folder.GetFiles(searchPattern);

			// Die gefundenen Dateien durchgehen und deren vollen Namen an die
			// StringCollection anhängen
			for (int i = 0; i < files.Length; i++)
				resultFiles.Add(files[i].FullName);
		}


		// end find files


	}
}
