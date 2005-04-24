using System;
using System.Xml;
using System.Collections;

namespace NewTrueSharpSwordAPI.Queries
{
	/// <summary>
	/// maps  Bibelbuchnummer zu Buchbezeichnungen und umgekehrt.
	/// z.B.  10==> 2Sam
	/// </summary>
	/// <summary>
	/// Diese Enumeration kann verwendet werden, um auf die 
	/// kurze oder lange Form des Bibelbuchnames zuzugreifen.
	/// <seealso cref="GetBookNameByNumber"/>
	/// </summary>
	public enum BookNameType {shortname=1,longname=2};
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
				Version v =new Version("0.0.0.2");
				return v.Major+"."+v.Minor+"."+v.Revision+"."+v.Build;

			}

		}
		/// <summary>
		///  Diese Methode liefert zu einer Buchnummer entweder die lange oder die kurze Form
		///  eine Bibelbuchnamens zurück
		/// </summary>
		/// <param name="LangID">Die Sprach ID</param>
		/// <param name="NameType">shortname oder longname</param>
		/// <param name="BookNumber">Die Buchnummer</param>
		/// <returns>Den Buchnamen z.B. Genesis</returns>
		public string GetBookNameByNumber(string LangID,BookNameType NameType,int BookNumber)
		{
			
			XmlNode BookItem;
			XmlNode BookName;
			string BNUMBER=Convert.ToString(BookNumber);
			try
			{
				BookItem=NamesXMLResource.DocumentElement.SelectSingleNode("descendant::ID[@descr='"+LangID+"']/BOOK[@bnumber='"+BNUMBER+"']"); 
				if(BookItem!=null)
				{
                   
					if(NameType==BookNameType.shortname)
					{
					   
						BookName=BookItem.Attributes.GetNamedItem("bshort");
						if(BookName!=null)
						{

							return BookName.InnerText; 
										  
						}
						else
							return "";
					
					}//endif

					if(NameType==BookNameType.longname)
					{
						return BookItem.InnerText;
					}
					return "";
				
				}
				else 
					// leeren String zurückgeben, falls nichts gefunden wird z.B. wegen falscher LangID.
					return "";
			}
			catch(Exception e)
			{
				return "";
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
					   
						DESC=ID.Attributes.GetNamedItem("descr");
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
