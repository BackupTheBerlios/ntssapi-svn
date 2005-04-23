using System;
using System.Xml;
using System.Collections;

namespace NewTrueSharpSwordAPI.Queries
{
	/// <summary>
	/// maps  Bibelbuchnummer zu Buchbezeichnungen und umgekehrt.
	/// z.B.  10==> 2Sam
	/// </summary>
	public class zefMapNames
	{   
		/// <summary>
		///  Diese Variable enthält den Inhalt einer bnames Datei.
		/// </summary>
		private XmlDocument NamesXMLResource= new XmlDocument();
		/// <summary>
		///  Der Konstruktor für eine Map-Klasse
		/// </summary>
		/// <param name="pathToNamesFile">
		///  Pfad zur XML-Resource mit Zuordnungen Buchnummern zu Buchnamen.
		///  vergl: http://tinyurl.com/94mr2
		/// </param>
		public zefMapNames(string pathToNamesFile)
		{
			try
			{
                
				NamesXMLResource.Load(pathToNamesFile);

			}
			catch(Exception e)
			{
				
			}
		}
		/// <summary>
		/// Gibt die Versionsnummer der zefMapNames-Klasse zurück.
		/// </summary>
		public string MapVersion
		{

			get
			{
				Version v =new Version("0.0.0.1");
				return v.Major+"."+v.Minor+"."+v.Revision+"."+v.Build;

			}

		}
		/// <summary>
		///  Diese Methode liefert eine Liste alle in einer bnames Datei verfügbaren Sprach IDs zurück.
		/// </summary>
		/// <returns> Eine Arrayliste aller Sprach Ids</returns>
		public ArrayList GetListOfIds()
		{
			ArrayList internalList=new ArrayList(); 
			XmlNodeList IDs;
			XmlNode DESC;
			try
			{
				IDs=NamesXMLResource.DocumentElement.SelectNodes("descendant::ID");
				if(IDs!=null)
				{
					foreach(XmlNode ID in IDs)
					{
					   
						DESC=ID.Attributes.GetNamedItem("desc");
						if(DESC!=null)
						{
						 
							internalList.Add(DESC.InnerText);
						
						}
					}
					return internalList;
				}// end if
				else
					// Leere Liste zurückgeben
					return internalList;
			 
			}
		
			catch(Exception e)
			{// Leere Liste zurückgeben
				return internalList;	
			}
		
		
		}

	}
}
