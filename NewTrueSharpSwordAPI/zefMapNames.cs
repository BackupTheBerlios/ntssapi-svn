using System;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections;

namespace NewTrueSharpSwordAPI.Queries
{
	/// <summary>
	/// maps  Bibelbuchnummer  zu Buchbezeichnungen und umgekehrt.
	/// z.B.  10==> 2Sam
	/// </summary>
	/// <summary>
	/// Diese Enumeration kann verwendet werden, um auf die 
	/// kurze oder lange Form des Bibelbuchnames zuzugreifen.
	/// <seealso cref="GetBookNameByNumber"/>
	/// </summary>
	public enum BookNameType {shortname=1,longname=2};
	/// <summary>
	/// Diese Aufzählung dient für die genauere Bestimmung der Bibeluntergliederung dienen.
	/// </summary>
	public enum BookGroup{at=1,nt=2,apo=3,pent=4,gb=5,chro=6,lul=7,gp=8,kp=9,ssg=10,sss=11,ssp=12,eva=13,bp=14,bk=15};

	public class zefMapNames
	{   

		/// <summary>
		///  Diese Variable enthält den Inhalt einer bnames Datei.
		/// </summary>
		private XmlDocument NamesXMLResource=new XmlDocument();
		/// <summary>
		///  Der Konstruktor für eine Map-Klasse
		/// </summary>
		/// <param name="pathToNamesFile">
		///  Pfad zur XML-Resource mit Zuordnungen Buchnummern zu Buchnamen.
		///  vergl: 
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
				Version v =new Version("0.0.0.9");
				return v.Major+"."+v.Minor+"."+v.Revision+"."+v.Build;

			}

		}
        public string GetBookNumber(string reference) {

            string BookNumber = "-1";
            
            try
            {
                XmlNodeList BookNamesList = NamesXMLResource.DocumentElement.SelectNodes("descendant::BOOK[@bshort='"+reference+"']");
                if (BookNamesList.Count>0) {

                    XmlNode BN = BookNamesList[0];
                    return BN.Attributes.GetNamedItem("bnumber").Value;
                }
                BookNamesList = NamesXMLResource.DocumentElement.SelectNodes("descendant::BOOK[text()='" + reference + "']");
                if (BookNamesList.Count > 0)
                {

                    XmlNode BN = BookNamesList[0];
                    return BN.Attributes.GetNamedItem("bnumber").Value;
                }

                return BookNumber;
            }

            catch (Exception e) {

                return BookNumber;
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
				return e.Message;
			}

		}

		/// <summary>
		///   Testet,ob eine Buchnummer in einer Buchgruppe vorkommt.
		///   <seealso cref="GetListOfBookNamesByBookGroups"/>
		/// </summary>
		/// <param name="BN">Die Buchnummer</param>
		/// <param name="BookGr">Die Buchgruppe</param>
		/// <returns>true, wenn Buchnummer in Buchgruppe vorkommt, sonst false</returns>
		private bool isInBookGroup(string BN,BookGroup BookGr)
		{
			int BOOKN=Convert.ToInt16(BN);
			bool intern=false;
			try
			{

				switch((int)BookGr)
				{
					case 1:

						// altes Testament
						if((BOOKN>=1)&(BOOKN<=39))
						{
							intern=true;
						}

						break;
					case 2:
						// neues Testament
						if((BOOKN>=40)&(BOOKN<=66))
						{
							intern=true;
						}

						break;
					case 3:
						// Apokryphen
						if((BOOKN>=67)&(BOOKN<=100))
						{
							intern=true;
						}
						break;	 
					case 4:
						//Pentateuch
						if((BOOKN>=1)&(BOOKN<=5))
						{
							intern=true;
						}
						break; 
					case 5:
						// Geschichtsbücher
						if((BOOKN>=6)&(BOOKN<=12))
						{
							intern=true;
						}
						break;	
					case 6:
						// Chronistisches Geschichtswerk
						if((BOOKN>=13)&(BOOKN<=17))
						{
							intern=true;
						}

						break;
					case 7:
						//Lieder und Lehrsprüche
						if((BOOKN>=18)&(BOOKN<=22))
						{
							intern=true;
						}

						break;
					case 8:
						// Große Propheten
						if((BOOKN>=23)&(BOOKN<=27))
						{
							intern=true;
						}

						break;
					case 9:
						//kleine Propheten
						if((BOOKN>=28)&(BOOKN<=39))
						{
							intern=true;
						}

						break;
					case 10:
						// Spätschriften-geschichtliche
						if((BOOKN==69)|(BOOKN==67)|(BOOKN==72)|(BOOKN==73)|(BOOKN==75))
						{
							intern=true;
						}

						break;
					case 11:
						// Spätschriften-Sprüche
						if((BOOKN==68)|(BOOKN==70))
						{
							intern=true;
						}
						break;
					case 12:
						// Spätschriften-prophetische
						if((BOOKN==71)|(BOOKN==79)|(BOOKN==74))
						{
							intern=true;
						}
						break;
					case 13:
						// Evangelien
						if((BOOKN>=40)&(BOOKN<=43))
						{
							intern=true;
						}
						break;
					case 14:
						// Briefe des Apostels Paulus
						if((BOOKN>=45)&(BOOKN<=57))
						{
							intern=true;
						}

						break;
					case 15:
						// katholische Briefe
						if((BOOKN>=58)&(BOOKN<=65))
						{
							intern=true;
						}

						break;

					default:
						return intern;
						
				}// end switch
				return intern;
			}

			catch(Exception e)
			{   

				return false;
			}

		}

		/// <summary>
		///  Liefert die Namensliste für eine bestimmte Buchgruppen zurück.
		///  <seealso cref="isInBookGroup"/>
		/// </summary>
		/// <param name="LangID">Die SprachID</param>
		/// <param name="NameType">langen oder die kurzen Namen </param>
		/// <param name="BookGr">Welche Buchgruppe?</param>
		/// <returns>Eine Liste mit spezifischer Buchnamenauswahl</returns>
		public ArrayList GetListOfBookNamesByBookGroups(string LangID,BookNameType NameType,BookGroup BookGr)
		{

			ArrayList internalList=new ArrayList();

			XmlNodeList BOOKs;
			string BN;
			try
			{
				BOOKs=NamesXMLResource.DocumentElement.SelectNodes("descendant::ID[@descr='"+LangID+"']/BOOK");
				if(BOOKs!=null)
				{

					foreach(XmlNode BOOK in BOOKs)
					{

						BN=BOOK.Attributes.GetNamedItem("bnumber").InnerText;

						if(isInBookGroup(BN,BookGr))
						{

							switch((int)NameType)
							{
								case 1:
									internalList.Add(BOOK.Attributes.GetNamedItem("bshort").InnerText);
									break;
								case 2:
									internalList.Add(BOOK.InnerText);
									break;


							}// end switch

						}	
					}// end foreach


				}
				return internalList;
			}
			catch(Exception e)
			{   
				internalList.Add(e.Message);
				return internalList;
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
				IDs=NamesXMLResource.DocumentElement.SelectNodes("descendant::id");
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
				string r=e.Message;
				return internalList;	
			}


		}

	}
}
