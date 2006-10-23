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
        /// Diese Liste enthaelt in jedem XmlDokument ein Zefania XML Abfragemodul entsprechend der Abrage.
        /// </summary>
        private List<XmlDocument> ResultsXmlDocs=new List<XmlDocument>();

        public delegate void QueryFinished(object sender, List<XmlDocument> QueryResults);
        /// <summary>
        /// Dieses Ereignis wird aufgerufen, wenn eine Abfrage beendet ist.
        /// </summary>
        public event QueryFinished OnQueryFinished;
     
        public zefCoreRequest() {

        }
        
        public void GetResults(List<string>BibleReferences,List<string>PathsToCaches){
            
            string BN=string.Empty, CN=string.Empty, VN=string.Empty;
            string PathToCachedFile = string.Empty;
            int MyIndex = -1;
            List<XmlDocument> ModulInfoList = new List<XmlDocument>();
            XmlDocument INFO=new XmlDocument();
            XmlDocument RESULT = new XmlDocument();
            string[] VersItemArray;
            StringBuilder ResultXMLString = new StringBuilder(5000);
            try
            {
                foreach (string CachePath in PathsToCaches)
                {
                   ModulInfoList.Add(INFO);
                   ModulInfoList[ModulInfoList.Count-1].Load(CachePath+@"\info.xml");
                }

                ResultXMLString.Append("<XMLBIBLE xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"zef2005.xsd\" version=\"2.0.0.0\" status=\"v\" biblename=\"internal\" type=\"x-other\" >\n<INFORMATION/>");
                

                foreach (string Reference in BibleReferences) {

                  VersItemArray = Reference.Split(':');
                  BN = VersItemArray[0]; CN = VersItemArray[1]; VN = VersItemArray[2];
                  ResultXMLString.Append("<BIBLEBOOK bnumber=\"" + BN + "\">\n<CHAPTER cnumber=\"" + CN + "\">\n");
                  MyIndex = -1;
                    foreach (XmlDocument INF in ModulInfoList) {
                    MyIndex++;
                    switch(CacheType(INF)){
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
                }// end References

                ResultXMLString.Append("\n</XMLBIBLE>");
                
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
                foreach (XmlDocument INF in ModulInfoList) {
                    MyIndex++;
                    XmlNode EL = INF.DocumentElement.SelectSingleNode("descendant::INFORMATION/title");
                    XmlNode RL = RESULT.CreateNode(XmlNodeType.Element, "TRANSLATION", "");
                    RL.InnerText = EL.InnerText;
                    APPINFO.AppendChild(RL);
                    
                
                }
                RESULT.DocumentElement.AppendChild(APPINFO);
                // End APPINFO einfügeg
                ResultsXmlDocs.Add(RESULT);

                if (OnQueryFinished != null) {

                    OnQueryFinished(this, ResultsXmlDocs);
                
                }


            }
            catch (Exception e) {

                string t = e.Message;
            
            }
        
        }

        private int CacheType(XmlDocument INF)
        {
            try
            {
                XmlNode EL = INF.DocumentElement.SelectSingleNode("descendant::cacheinfo/zipped");
                if (EL.InnerText == "True") {

                    return 2;
                
                }
                EL = INF.DocumentElement.SelectSingleNode("descendant::cacheinfo/type");
                if (EL.InnerText == "x-chapters") {

                    return 0;
                }

                if (EL.InnerText == "x-books")
                {

                    return 1;

                }
                else {

                    return -1;
                }
            }
            catch (Exception e) {

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
            XmlTextReader ModulReader = new XmlTextReader(PathToCacheDir+@"\"+BN+"_"+CN+".xml");
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
