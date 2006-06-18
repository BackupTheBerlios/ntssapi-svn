using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

using System.ComponentModel;
using System.Net;
using System.Xml;



namespace zefdownloader
{
    public class ZefModulDownLoader
    {
        /// <summary>
        /// Die url zur Modulliste auf dem Server
        /// </summary>
        private string FUrlModulList = "http://";

        /// <summary>
        /// Feld speichert Pfad zum DownloadDirectory
        /// </summary>
        private string FDownloadDirectory;
        private string FFinalDownloadURL;
        private string FModulName;
        private string FServerName;
        private string FModullisteFileName;
        private string FMirrorPageFileName;

        public delegate void ModulListEventHandler(object sender, EventArgs e, XmlNode modulnode, XmlNode ISO639);
        public delegate void ModulServerEventHandler(object sender, XmlNode server);
        public delegate void ModulListServerEventHandler(object sender, XmlNode server);

        public delegate void WebEventExecptionHandler(object sender, WebException e);
        public event ModulListEventHandler OnModulNode;
        public event ModulServerEventHandler OnServerNode;
        public event AsyncCompletedEventHandler DownloadCompleted;
        public event DownloadProgressChangedEventHandler DownloadProgress;
        public event WebEventExecptionHandler OnWebExeption;



        /// <summary>
        /// Diese Eigenschaft setzt oder liest die Url zur Moduliste
        /// </summary>
        /// <value>http://zefania-sharp.sourceforge.net/zefmod.xml</value>
        public string UrlModulList
        {
            get
            {
                return FUrlModulList;
            }
            set
            {
                FUrlModulList = value;
            }
        }

        /// <summary>
        /// Setzt oder liest das Downloadverzeichnis
        /// </summary>
        public string DownloadDirectory
        {
            get
            {
                return FDownloadDirectory;
            }
            set
            {
                FDownloadDirectory = value;
            }
        }

        public string ModulName
        {
            get
            {
                return FModulName;
            }

        }

        //****************************************************************************************
        /// <summary>
        /// Diese Methode lädt ein Modul von einem bestimmten Server herunter
        /// </summary>
        /// <param name="ModulName">Der Name des Zefania XML Moduls</param>
        /// <param name="ServerName">Der Name des Servers</param>
        /// <see cref="http://tinyurl.com/zeyo8"/>
        public void GetModulByName(string ModulName, string ServerName)
        {

            try
            {
                // Zuerst Modulliste vom Server holen
                FModulName = ModulName;
                FServerName = ServerName;
                
                FModullisteFileName = Path.GetTempFileName();

                FMirrorPageFileName = Path.GetTempFileName();


                WebClient WebClientModulListe = new WebClient();
                WebClientModulListe.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClientModulListe_DownloadFileCompleted);
                if (!FUrlModulList.EndsWith(".xml"))
                {

                    FUrlModulList = FUrlModulList + @"/zefmod.xml";
                }
                
                Uri siteUri = new Uri(FUrlModulList);
                /// Modulliste herunterladen
                WebClientModulListe.DownloadFileAsync(siteUri, FModullisteFileName);


            }

            catch (WebException ee)
            {
                if (OnWebExeption != null)
                {
                    OnWebExeption(this, ee);
                }
            }
            catch (Exception e)
            {


            }



        }

        void WebClientModulListe_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                WebClient WebClientMirrorPage = new WebClient();
                XmlDocument ModulListe = new XmlDocument();

                ModulListe.Load(FModullisteFileName);

                XmlNodeList ModulNodes = ModulListe.SelectNodes("descendant::module");
                XmlNode ModulNode = null;
                foreach (XmlNode N in ModulNodes)
                {

                    string name = N.Attributes.GetNamedItem("name").Value;
                    if (name == ModulName)
                    {
                        ModulNode = N;
                        break;

                    }


                }

                string FileName = ModulNode.Attributes.GetNamedItem("filename").Value;


                XmlNode BasisServer = ModulListe.SelectSingleNode("descendant::mirrors");

                string urlinfix = BasisServer.Attributes.GetNamedItem("urlinfix").Value;


                XmlNode Server = ModulListe.DocumentElement.SelectSingleNode("descendant::mirror[@location='" + FServerName + "']");

                string ServerSuffix = Server.Attributes.GetNamedItem("suffix").Value;

                string SubDomain = Server.Attributes.GetNamedItem("subdomain").Value;

                if (SubDomain == String.Empty)
                {

                    SubDomain = "http://";
                }
                string ModulURL = SubDomain + urlinfix + FileName + ServerSuffix;



                if (ModulURL == null)
                {

                    return;
                }

                //**************************************************
                if (ModulURL.IndexOf("prdownloads.sourceforge.net") == -1)
                {
                    //Falls wir nicht von sourceforge laden, überpringen wir das herunterladen der SF Mirrorpage
                    // und laden das Modul sofort herunter.
                    FFinalDownloadURL = ModulURL;
                    WebClient ModulClient = new WebClient();
                    ModulClient.DownloadFileCompleted += new AsyncCompletedEventHandler(ModulClient_DownloadFileCompleted);
                    ModulClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ModulClient_DownloadProgressChanged);
                    Uri siteUri2 = new Uri(FFinalDownloadURL);
                    String MFileName = siteUri2.Segments[siteUri2.Segments.Length - 1];
                    ModulClient.DownloadFileAsync(siteUri2, this.FDownloadDirectory + @"/" + MFileName);

                }
                else
                {

                    Uri siteUri = new Uri(ModulURL);
                    WebClientMirrorPage.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClientMirrorPage_DownloadFileCompleted);
                    WebClientMirrorPage.DownloadFileAsync(siteUri,FMirrorPageFileName);




                }


            }
            catch (WebException ee)
            {
                if (OnWebExeption != null)
                {
                    OnWebExeption(this, ee);
                }
            }
            catch (Exception ee)
            {

            }
        }

        void WebClientMirrorPage_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {

                StreamReader sr = new StreamReader(FMirrorPageFileName, Encoding.GetEncoding("windows-1252"));
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.ToLower().IndexOf("/>or download from") > -1)
                    {

                        line = line.Remove(0, 90);
                        FFinalDownloadURL = line.Remove(line.IndexOf(".zip") + 4).Trim();
                        break;

                    }
                }
                if (FFinalDownloadURL == null)
                {

                    return;

                }

                WebClient ModulClient = new WebClient();
                ModulClient.DownloadFileCompleted += new AsyncCompletedEventHandler(ModulClient_DownloadFileCompleted);
                ModulClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ModulClient_DownloadProgressChanged);
                Uri siteUri2 = new Uri(FFinalDownloadURL);
                String MFileName = siteUri2.Segments[siteUri2.Segments.Length - 1];
                ModulClient.DownloadFileAsync(siteUri2, this.FDownloadDirectory + @"/" + MFileName);
            }



            catch (WebException ee)
            {
                if (OnWebExeption != null)
                {
                    OnWebExeption(this, ee);
                }
            }

            catch (Exception ex)
            {


            }

        }

        void ModulClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
            if (DownloadCompleted != null)
            {
                DownloadCompleted(this, e);
            }
        }

        //****************************************************************************************
        /// <summary>
        /// Holt die Modulliste vom Server
        /// </summary>
        private void GetModulListFromServer()
        {
            try
            {

                WebClient ClientModulList = new WebClient();
                Uri siteUri = new Uri(FUrlModulList);
                ClientModulList.DownloadFile(siteUri, FDownloadDirectory + @"\" + FModullisteFileName);



            }
            catch (WebException ee)
            {
                if (OnWebExeption != null)
                {
                    OnWebExeption(this, ee);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public void ScanModulList(bool ForceRefresh)
        {

            try
            {
                WebClient ClientModulList = new WebClient();

                if (!FUrlModulList.EndsWith(".xml")) { 
                
                  FUrlModulList=FUrlModulList+@"/zefmod.xml";
                }
                Uri siteUri = new Uri(FUrlModulList);


                



                Uri siteUri2 = new Uri(@"http://zefania-sharp.sourceforge.net/iso639_codes.xml");
                if (ForceRefresh)
                {


                    ClientModulList.DownloadFile(siteUri, FDownloadDirectory + @"\modulliste.xml");
                    ClientModulList.DownloadFile(siteUri2, FDownloadDirectory + @"\iso639_codes.xml");
                }

                if (!File.Exists(FDownloadDirectory + @"\modulliste.xml"))
                {


                    ClientModulList.DownloadFile(siteUri, FDownloadDirectory + @"\modulliste.xml");
                    ClientModulList.DownloadFile(siteUri2, FDownloadDirectory + @"\iso639_codes.xml");
                }

                if (!File.Exists(FDownloadDirectory + @"\iso639_codes.xml"))
                {

                    ClientModulList.DownloadFile(siteUri2, FDownloadDirectory + @"\iso639_codes.xml");
                }


                XmlDocument IS0639 = new XmlDocument();
                IS0639.Load(FDownloadDirectory + @"\iso639_codes.xml");
                XmlDocument ML = new XmlDocument();
                ML.Load(FDownloadDirectory + @"\modulliste.xml");
                XmlNodeList ModulNodes = ML.SelectNodes("descendant::module");

                foreach (XmlNode ModulNode in ModulNodes)
                {
                    string LangCode = ModulNode.Attributes.GetNamedItem("language").Value.ToLower();
                    XmlNode ISO = IS0639.SelectSingleNode("descendant::code[@threecharcode='" + LangCode + "']");
                    if (OnModulNode != null)
                    {
                        //Jedes modul-XML Node per event an Applikation melden
                        OnModulNode(this, new EventArgs(), ModulNode, ISO);
                    }
                }

                XmlNodeList ServerNodes = ML.SelectNodes("descendant::mirror");
                foreach (XmlNode ServerNode in ServerNodes)
                {

                    if (OnServerNode != null)
                    {
                        //Jeden Server-XML Node per event an Applikation melden
                        OnServerNode(this, ServerNode);
                    }

                }


            }
            catch (WebException ee)
            {
                if (OnWebExeption != null)
                {
                    OnWebExeption(this, ee);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }




        void ModulClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (DownloadProgress != null)
            {
                DownloadProgress(this, e);
            }
        }

        /// <summary>
        /// Löscht temporäre Files, die beim Download entstehen.
        /// </summary>
        public void DeleteTempFiles()
        {
            try{

                File.Delete(this.FMirrorPageFileName);
                File.Delete(this.FModullisteFileName);
            
            }
            catch (Exception ee){
            
            }
        }

        

    }
}
