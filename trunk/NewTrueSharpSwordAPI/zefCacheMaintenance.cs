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

		// <summary>
		/// Die Liste der Eingangsverzeichnisse der Zefania XML Bibelmodule.
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
		// <summary>
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
		///  Liest alle info.xml Dateien von  Zefania XML Modulen im Cache.
		/// </summary>
		/// <returns>Liste der Bibelnamen</returns>
		public ArrayList GetNamesOfCachedBibles()
		{
		    
			ArrayList internalList=new ArrayList();
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
								internalList.Add(ModulInfoReader.ReadString());
								ModulInfoReader.Close();
								break;
                                
							}
						}// end while

					}// end fileName

				}// end ChachDir
			
				return internalList;
			}
			catch(Exception e)
			{
				internalList.Clear();
				return internalList;

			}
		
		
		}
		
		/// <summary>
		/// Gibt die Versionsnummer der zefCacheMaintenance-Klasse zurück.
		/// </summary>
		public string CacheVersion
		{

			get
			{
				Version v =new Version("0.0.0.1");
				return v.Major+"."+v.Minor+"."+v.Revision+"."+v.Build;

			}

		}

	}
}
