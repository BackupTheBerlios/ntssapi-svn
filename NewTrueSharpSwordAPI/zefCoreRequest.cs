using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip;
using NewTrueSharpSwordAPI.Cache;

namespace NewTrueSharpSwordAPI.Queries
{

    /// <summary>
    /// Mit zefCoreRequest kann  ein Zefania XML Cache mit einer Liste von Bibelstellen im
    /// Format:
    /// 40:7:9
    /// 56:12:7
    /// 19:4:5
    /// abgefragt werden.
    /// </summary>
    public class zefCoreRequest
    {
        /// <summary>
        /// Diese Liste enthaelt in jedem XmlDokument  der Liste ein Zefania XML 
        /// Abfragemodul entsprechend der Abrage.
        /// </summary>
        private List<XmlDocument> ResultsXmlDocs = new List<XmlDocument>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">zefCoreRequest</param>
        /// <param name="QueryResults">Eine Liste mit XmlDocumenten der in MaxVersePerPage zelegten Abfrage</param>
        public delegate void QueryFinished(object sender, List<XmlDocument> QueryResults);
        /// <summary>
        /// Dieses Ereignis wird aufgerufen, wenn eine Abfrage komplett beendet ist.
        /// </summary>
        public event QueryFinished OnQueryFinished;
        /// <summary>
        ///  Eine Abfrageliste von Bibelstellen kann in mehrere Unterlisten mit MaxVersePerPage zerlegt werden.
        ///  Jede beendete Abfrage einer Teilliste löst das Erreignis PageQueryFinished aus und 
        ///  meldet das Ergebnis als XmlDocument.
        /// </summary>
        /// <param name="sender">zefCoreRequest</param>
        /// <param name="PageQueryResults">Das Ergebnis der Abfrage als XmlDocument</param>
        public delegate void PageQueryFinished(object sender, XmlDocument PageQueryResults);
        /// <summary>
        /// Dieses Ereignis wird aufgerufen, wenn eine Abfrage beendet ist.
        /// </summary>
        public event PageQueryFinished OnPageQueryFinished;

        /// <summary>
        /// Konstruktor der Klasse zefCoreRequest
        /// </summary>
        public zefCoreRequest()
        {

        }
        /// <summary>
        ///  Das ist die Hauptmethode, die aus eine Liste von Bibelversen ein Bibelmodul abfragt und das
        ///  Ergebnis in Form von XmlDocumenten zurueckliefert. Die Ergebnisse werden über Ereignisse an die 
        ///  uebergeordnete Anwendung gemeldet.
        /// </summary>
        /// <param name="BibleReferences">
        ///  Eine beliebig lange Liste von Bibelstellen im Format:
        ///  40:7:9
        ///  56:12:7
        ///  19:4:5
        /// </param>
        /// <param name="PathsToCaches">
        ///  Eine Liste von Pfaden zu den Caches der BibelModule, die abgefragt werden sollen.
        ///  
        /// </param>
        /// <param name="MaxVersPerPage">
        /// Ein Abfrageliste kann in mehrere kleine Abfragelisten mit MaxVersPerPage zerlegt werden
        /// MaxVersPerPage = 0 ==> Abfrageliste(BibleReferences) wird nicht zerlegt.
        ///</param>
        public void GetResults(List<string> BibleReferences, List<string> PathsToCaches, int MaxVersPerPage)
        {

            string BN = string.Empty, CN = string.Empty, VN = string.Empty;
            string PathToCachedFile = string.Empty;
            int MyIndex = -1;
            List<XmlDocument> ModulInfoList = new List<XmlDocument>();
            List<List<string>> SubQueries = new List<List<string>>();
            XmlDocument INFO = new XmlDocument();

            string[] VersItemArray;
            StringBuilder ResultXMLString = new StringBuilder(5000);
            try
            {
                foreach (string CachePath in PathsToCaches)
                {
                    ModulInfoList.Add(INFO);
                    ModulInfoList[ModulInfoList.Count - 1].Load(CachePath + @"\info.xml");
                }

                if (MaxVersPerPage == 0)
                {
                    // Keine Zerlegung die Liste wird am Stueck bearbeitet
                    SubQueries.Add(BibleReferences);
                }
                else
                {
                    // Abfrageliste in Unterlisten mit MaxVersePerPage zerlegen
                    int rest = -1;
                    List<string> L = new List<string>();

                    for (int i = 1; i < BibleReferences.Count + 1; i++)
                    {

                        rest = i % MaxVersPerPage;
                        L.Add(BibleReferences[i - 1]);
                        if (rest == 0)
                        {
                            List<string> LL = new List<string>();
                            LL.AddRange(L);
                            SubQueries.Add(LL);
                            L.Clear();


                        }
                        if ((i == BibleReferences.Count) & (L.Count > 0))
                        {

                            List<string> LL = new List<string>();
                            LL.AddRange(L);
                            SubQueries.Add(LL);
                            L.Clear();

                        }


                    }



                }// end Zerlegung in Teilisten

                foreach (List<string> References in SubQueries)
                {

                    // Ergebnis XmlDocument zusammenbauen
                    ResultXMLString.Append("<XMLBIBLE xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"zef2005.xsd\" version=\"2.0.0.0\" status=\"v\" biblename=\"internal\" type=\"x-other\" >\n<INFORMATION/>");
                    XmlDocument RESULT = new XmlDocument();


                    foreach (string Reference in References)
                    {

                        VersItemArray = Reference.Split(':');
                        BN = VersItemArray[0]; CN = VersItemArray[1]; VN = VersItemArray[2];
                        ResultXMLString.Append("<BIBLEBOOK bnumber=\"" + BN + "\">\n<CHAPTER cnumber=\"" + CN + "\">\n");
                        MyIndex = -1;
                        foreach (XmlDocument INF in ModulInfoList)
                        {
                            MyIndex++;
                            switch (CacheType(INF))
                            {
                                case 0://x-chapters
                                    ResultXMLString.Append(GetVerseXChapters(PathsToCaches[MyIndex], BN, CN, VN));
                                    break;
                                case 1://x-bookx
                                    
                                    break;
                                case 2:// x-zipped

                                    break;
                                default:
                                    continue;

                            }

                        }

                        ResultXMLString.Append("\n</CHAPTER>\n</BIBLEBOOK>");
                    }// end foreach References

                    // die Abfrage einer Unterliste ist beendet
                    ResultXMLString.Append("\n</XMLBIBLE>");
                    // Den zusammengebauten XML- String in ein XmlDocument einlesen
                    RESULT.LoadXml(ResultXMLString.ToString());
                    //APPINFO einfügen
                    MyIndex = -1;
                    XmlNode APPINFO = RESULT.CreateNode(XmlNodeType.Element, "APPINFO", "");
                    XmlAttribute ATT1 = RESULT.CreateAttribute("", "client", "");
                    ATT1.Value = "NewTrueSharpSwordAPI";
                    APPINFO.Attributes.Append(ATT1);

                    XmlAttribute ATT2 = RESULT.CreateAttribute("", "version", "");
                    ATT2.Value = "1.0.0.0";
                    APPINFO.Attributes.Append(ATT2);
                    foreach (XmlDocument INF in ModulInfoList)
                    {
                        MyIndex++;
                        XmlNode EL = INF.DocumentElement.SelectSingleNode("descendant::INFORMATION/title");
                        XmlNode RL = RESULT.CreateNode(XmlNodeType.Element, "TRANSLATION", "");
                        RL.InnerText = EL.InnerText;
                        APPINFO.AppendChild(RL);


                    }
                    RESULT.DocumentElement.AppendChild(APPINFO);
                    // End APPINFO einfügeg
                    // XmlDocument in die Liste mit den Ergebnissen einfügen
                    ResultsXmlDocs.Add(RESULT);
                    // XML String für einen eventuellen weiteren Durchgang wieder leeren
                    ResultXMLString.Length = 0;
                    
                    if (OnPageQueryFinished != null) {
                        // Eine XmlDocument mit einer fertigen Abfrage melden    
                        OnPageQueryFinished(this, RESULT);
                    
                    }

                } // end for each SubQueries
                if (OnQueryFinished != null)
                {
                    // Die Abfrage ist jetzt komplett beendet, die Liste mit den XmlDocumenten melden.
                    OnQueryFinished(this, ResultsXmlDocs);

                }


            }
            catch (Exception e)
            {



            }

        }
        /// <summary>
        ///  Den Cache-Type bestimmen.
        /// </summary>
        /// <param name="INF">Jeder ModulCache enthaelt eine info.xml, die als XmlDocument übergeben wird</param>
        /// <returns> 0 = Type x-chapters
        ///           1 = Type x-books
        ///           2 = zipped Cache
        ///</returns>
        private int CacheType(XmlDocument INF)
        {
            try
            {
                XmlNode EL = INF.DocumentElement.SelectSingleNode("descendant::cacheinfo/zipped");
                if (EL.InnerText == "True")
                {

                    return 2;

                }
                EL = INF.DocumentElement.SelectSingleNode("descendant::cacheinfo/type");
                if (EL.InnerText == "x-chapters")
                {

                    return 0;
                }

                if (EL.InnerText == "x-books")
                {

                    return 1;

                }
                else
                {

                    return -1;
                }
            }
            catch (Exception e)
            {

                return -1;

            }
        }
        /// <summary>
        ///  Liefert aus einem x-chapters file den Verstext incl. XML-Markup zurück.
        /// </summary>
        /// <param name="PathToCacheDir">Der Pfad zum Verzeichnis des Caches.</param>
        /// <param name="BN">Die Buchnummer</param>
        /// <param name="CN">Die Kapitelnummer</param>
        /// <param name="VN">Die Versnummer</param>
        /// <returns>Verstext incl. XML-Markup</returns>
        private string GetVerseXChapters(string PathToCacheDir, string BN, string CN, string VN)
        {
            XmlTextReader ModulReader = new XmlTextReader(PathToCacheDir + @"\" + BN + "_" + CN + ".xml");
            try
            {
                while (ModulReader.Read())
                {
                    if (ModulReader.Name == "VERS")
                    {
                        if ((ModulReader.GetAttribute("vnumber") == VN))
                        {
                            // Sodele Vers gefunden!
                            return ModulReader.ReadOuterXml();

                        }
                    }
                }
                return "<VERS vnumber=\"" + VN + "\">--</VERS>";
            }
            catch (Exception e)
            {

                return e.Message;

            }


        }

    }
}
