using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace NewTrueSharpSwordAPI.Cache
{
	/// <summary>
	/// zefCacheMaintenance verwaltet, erstellt und liefert Informationen über den Zefania XML 
	/// ModulCache.
	/// </summary>
	public class zefCacheMaintenance
	{
		
		public delegate void OnIncomingEventHandler(object sender, EventArgs e,string PathToModul);
        public event OnIncomingEventHandler OnIncomingNotCached;
        public event OnIncomingEventHandler OnIncomingInCache;

		/// <summary>
		/// Diese Liste enthält alle Pfade zu den Modulen in den Eingangsverzeichnissen,
		/// die  im Cache sind.
		/// </summary>
		private ArrayList FPathListOfCachedModuls=new ArrayList();
		/// <summary>
		/// Diese Liste enthält alle Pfade zu den Modulen in den Eingangsverzeichnissen,
		/// die nicht im Cache sind.
		/// </summary>
		private ArrayList FPathListOfIncomingModuls=new ArrayList();
		/// <summary>
		/// Diese Liste enthält die Namen aller Bibelmodule im Cache.
		/// </summary>
		private ArrayList FNameListOfBibles=new ArrayList();
		/// <summary>
		/// Diese Liste enthält die Namen und Pfade aller Bibelmodule im Cache.
		/// </summary>
		private ArrayList FNamePathListOfBibles=new ArrayList();
		/// <summary>
		/// Diese Liste enthält die Namen der Bibelmodule, die gerade vom User ausgewählt wurden.
		/// </summary>
		private ArrayList FNameListOfSelectedBibles=new ArrayList();
		/// <summary>
		/// Die Eingangsverzeichnisse für Zefania XML Module
		/// </summary>
		private ArrayList FListOfModulInputDirectories=new ArrayList();
		/// <summary>
		/// Liste der Speicherorte für die erstellten ModulCaches
		/// </summary>
		private ArrayList FListOfCacheDirectories=new ArrayList();
		/// <summary>
		/// Konstruktor
		/// </summary>
		public zefCacheMaintenance()
		{
			//
			// TODO: Fügen Sie hier die Konstruktorlogik hinzu
			//
		}

		/// <summary>
		/// Die Liste der gerade aktuell ausgewählten Bibelmodule.
		/// </summary>
		public ArrayList NameListOfSelectedBibles
		{
			get
			{
				return FNameListOfSelectedBibles;
			}
			set
			{
				FNameListOfSelectedBibles=value;
			
			}
		
		}
		
		/// <summary>
		/// Die Liste der Bibelnamen im Cache.
		/// </summary>
		public ArrayList NameListOfBibles
		{
			get
			{   
				FNameListOfBibles.Clear();
				MakeListOfCachedBibles();
				int x=1;
				foreach(string BibleName in FNamePathListOfBibles)
				{
					if(x%2!= 0)
					{
						// an den ungeraden Indices stehen die Bibelnamen
						FNameListOfBibles.Add(BibleName); 
					}
					
					x++;
				}
				
				return FNameListOfBibles;	
			}
			
		}
		
	
		/// <summary>
		/// Die Liste der vorhandenen BibelModule im Cache. Wird durch Aufruf
		/// von <seealso cref="MakeListOfCachedBibles"/> gefüllt.
		/// Die Liste enthält Paare von Einträgen Bibelname/Pfade zum Cache.
		/// </summary>
		public ArrayList NamePathListOfBibles
		{
			get
			{
				return FNamePathListOfBibles;
			}
			
		
		}
		/// <summary>
		/// Die Liste der Eingangsverzeichnisse für Zefania XML Bibelmodule.
		/// </summary>
		public ArrayList ListOfModulInputDirectories
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
		///  Die Liste der Module im Eingangverzeichnis, die nicht im Cache sind
		/// </summary>
		public ArrayList ListOfPathIncomingModuls
		{
		  
			get
			{
			  
				return  FPathListOfIncomingModuls;
			
			}
		
		
		
		}
		/// <summary>
		///  Die Liste der Module im Eingangverzeichnis, die im Cache sind
		/// </summary>
		public ArrayList PathListOfCachedModuls
		{
		
			get{
			
			   return FPathListOfCachedModuls;
			}
		
		}
		/// <summary>
		/// Die Liste der CacheVerzeichnisse der Zefania XML Bibelmodule.
		/// </summary>
		public ArrayList ListOfCacheDirectories
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

		/// <summary>
		/// Liefert die Liste von CacheDir(s) zu einem Bibelnamen zurück
		/// </summary>
		/// <param name="BibleName">Der Bibelname</param>
		/// <returns>Liste von CacheDir(s) zu einem Bibelnamen</returns>
		public ArrayList GetListOfModulPathsByBibleName(string BibleName)
		{
		 
			ArrayList internalList=new ArrayList();
			try
			{
				if(FNameListOfBibles.Contains(BibleName))
				{
				    
					int index=0;
					foreach(string Name in FNamePathListOfBibles)
					{
					   
						if(Name==BibleName)
						{
							internalList.AddRange(FNamePathListOfBibles.GetRange(index+1,1)); 
						}
						index++;
					}
					
					return internalList;
				}
				return internalList;
			}
			catch(Exception e)
			{
				internalList.Clear();
				return internalList;
			}
		}

		/// <summary>
		/// erstellt die Pfadliste der Zefania Module in den Eingangsverzeichnissen
		/// </summary>
		public void MakeListOfIncomingModuls()
		{
            EventArgs e1=new EventArgs();
			FPathListOfIncomingModuls.Clear();
			FPathListOfCachedModuls.Clear();

			try
			{
				foreach( string ModulInputDir in FListOfModulInputDirectories)
				{
					string [] ModulFiles = Directory.GetFiles(ModulInputDir,"*");
					foreach(string MPath in ModulFiles)
					{
					
						if((Path.GetExtension(MPath)==".xml")|(Path.GetExtension(MPath)==".zip"))
						{

							if(ModulIsInCache(MPath))
							{
								FPathListOfCachedModuls.Add(MPath);
								if(OnIncomingInCache!=null)
								{
								 
									OnIncomingInCache(this,e1,MPath);
								  
								}
							}
							else
							{
								FPathListOfIncomingModuls.Add(MPath);
                                if(OnIncomingNotCached!=null)
								{
								 
									OnIncomingNotCached(this,e1,MPath);
								  
								}

							}
																							  
						}

					}
				
				}
			
			}
			catch(Exception e)
			{
				
			}
		}
		
		/// <summary>
		///  Liest alle info.xml Dateien von  Zefania XML Modulen im Cache und
		///  setzt die füllt die interne Liste <see cref="FNamePathListOfBibles"/>.
		/// </summary>
		public void MakeListOfCachedBibles()
		{

			FNamePathListOfBibles.Clear();
			ArrayList InfoFileEntries=new ArrayList();
			try
			{

				foreach(string CachDir in FListOfCacheDirectories)
				{

					InfoFileEntries.Clear();

					string [] ModulMD5Dirs=Directory.GetDirectories(CachDir);

					foreach (string ModulMD5Dir in ModulMD5Dirs)
					{

						string [] InfoFile = Directory.GetFiles(ModulMD5Dir,"info.xml");
						InfoFileEntries.AddRange(InfoFile);

					}
					// aus jedem info.xml den Bibelnamen lesen
					foreach(string fileName in InfoFileEntries)
					{
						XmlTextReader ModulInfoReader=new XmlTextReader(fileName);
						while (ModulInfoReader.Read()) 
						{
							if(ModulInfoReader.Name=="title")
							{
								FNamePathListOfBibles.Add(ModulInfoReader.ReadString());
								FNamePathListOfBibles.Add(Path.GetDirectoryName(fileName));
								ModulInfoReader.Close();
								break;

							}
						}// end while

					}// end fileName

				}// end ChachDir

			
			}
			catch(Exception e)
			{
				

			}


		}

		/// <summary>
		///  Prüft, ob für ein Modul im Eingangsverzeichnis ein Cache existiert.
		/// </summary>
		/// <param name="PathToIncomingModul">Der komplette Pfad zum Eingangsmodul</param>
		/// <returns>true, wenn Modul im Cache, sonst false</returns>
		public bool ModulIsInCache(string PathToIncomingModul)
		{

			ArrayList InfoFileEntries=new ArrayList();
			try
			{

				foreach(string CachDir in FListOfCacheDirectories)
				{

					InfoFileEntries.Clear();

					string [] ModulMD5Dirs=Directory.GetDirectories(CachDir);

					foreach (string ModulMD5Dir in ModulMD5Dirs)
					{

						string [] InfoFile = Directory.GetFiles(ModulMD5Dir,"info.xml");
						InfoFileEntries.AddRange(InfoFile);

					}
					// aus jedem info.xml den Bibelnamen lesen
					foreach(string fileName in InfoFileEntries)
					{
						XmlTextReader ModulInfoReader=new XmlTextReader(fileName);
						while (ModulInfoReader.Read()) 
						{
							if(ModulInfoReader.Name=="sourcepath")
							{
								if(ModulInfoReader.ReadString()==PathToIncomingModul){
								  
                                   return true;
								}
								

							}
						}// end while

					}// end fileName

				}// end ChachDir
			  return false;
			}
			catch(Exception e)
			{
				
				return false;

			}
		}

		/// <summary>
		/// Gibt die Versionsnummer der zefCacheMaintenance-Klasse zurück.
		/// </summary>
		public string CacheVersion
		{

			get
			{
				Version v =new Version("0.0.0.6");
				return v.Major+"."+v.Minor+"."+v.Revision+"."+v.Build;

			}

		}

	}
}
