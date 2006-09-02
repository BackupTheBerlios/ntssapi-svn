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
        private string FLocalFilePath;
        private XmlDocument FModulListe = new XmlDocument();

        public delegate void ModulListEventHandler(object sender, EventArgs e, XmlNode modulnode);
        public delegate void ModulServerEventHandler(object sender, XmlNode server);
        public delegate void ModulListServerEventHandler(object sender, XmlNode server);
        public delegate void AnotherServerFound(object sender, string AnotherServer);
        public delegate void ScanFinished(object sender);

        public delegate void WebEventExecptionHandler(object sender, WebException e);
        public event ModulListEventHandler OnModulNode;
        public event ModulServerEventHandler OnServerNode;
        public event AsyncCompletedEventHandler DownloadCompleted;
        public event DownloadProgressChangedEventHandler DownloadProgress;
      
        public event AnotherServerFound OnAnotherServer;
        public event ScanFinished OnScanFinished;



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

        public string LocalFilePath
        {
            get
            {
                return FLocalFilePath;
            }

        }

        public XmlDocument ModuListe
        {
            get
            {
                return FModulListe;
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

                WebClientModulListe.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClientModulListe_DownloadProgressChanged);
                WebClientModulListe.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClientModulListe_DownloadFileCompleted);
                
                if (!FUrlModulList.EndsWith(".xml"))
                {

                    FUrlModulList = Path.Combine(FUrlModulList,"zefmod.xml");
                }

                Uri siteUri = new Uri(FUrlModulList);

                WebClientModulListe.Headers.Add("download", "running");
                /// Modulliste herunterladen
                WebClientModulListe.DownloadFileAsync(siteUri, FModullisteFileName);


            }

            
            catch (Exception e)
            {

                

            }



        }

        void WebClientModulListe_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
            if (e.BytesReceived == e.TotalBytesToReceive)
            {

                (sender as WebClient).Headers.Set("download", "success");



            }
        }

        void WebClientModulListe_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {

                if ((sender as WebClient).Headers.Get("download") != "success") {

                    ModulClient_DownloadFileCompleted(sender, e);
                    return;
                
                }
                
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
                    FLocalFilePath = Path.Combine(FDownloadDirectory,Path.ChangeExtension(MFileName,".~tmp"));
                    ModulClient.Headers.Add("download", "running");
                    ModulClient.DownloadFileAsync(siteUri2, FLocalFilePath,FLocalFilePath);

                }
                else
                {

                    Uri siteUri = new Uri(ModulURL);
                    WebClientMirrorPage.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClientMirrorPage_DownloadFileCompleted);
                    WebClientMirrorPage.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClientMirrorPage_DownloadProgressChanged);
                    WebClientMirrorPage.Headers.Add("download", "running");
                    WebClientMirrorPage.DownloadFileAsync(siteUri, FMirrorPageFileName);




                }


            }
            
            catch (Exception ee)
            {
               
            }
        }

        void WebClientMirrorPage_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.BytesReceived == e.TotalBytesToReceive)
            {

                (sender as WebClient).Headers.Set("download", "success");



            }
        }

        void WebClientMirrorPage_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if ((sender as WebClient).Headers.Get("download") != "success")
                {
                    ModulClient_DownloadFileCompleted(sender, e);
                    // File konnte z.B. wegen Verbindungsabruch nicht komplett heruntergeladen werden
                    return;

                }
                
                
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
                FLocalFilePath = Path.ChangeExtension(FDownloadDirectory, Path.ChangeExtension(MFileName, ".~tmp"));
                ModulClient.Headers.Add("download", "running");
                ModulClient.DownloadFileAsync(siteUri2, FLocalFilePath,FLocalFilePath);
            }



           

            catch (Exception ex)
            {
                

            }

        }

        void ModulClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            if ((sender as WebClient).Headers.Get("download") == "success")
            {

               
                
                File.Delete( Path.ChangeExtension(e.UserState.ToString(), ".zip"));
                File.Move(e.UserState.ToString(), Path.ChangeExtension(e.UserState.ToString(), ".zip"));
            }
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
                ClientModulList.DownloadFile(siteUri, Path.Combine(FDownloadDirectory ,FModullisteFileName));



            }
           
            catch (Exception e)
            {

                
            }

        }

        public void ScanModulList(bool ForceRefresh)
        {

            try
            {
                WebClient ClientModulList = new WebClient();
                ClientModulList.DownloadProgressChanged+=new DownloadProgressChangedEventHandler(ClientModulList2_DownloadProgressChanged);
                ClientModulList.DownloadFileCompleted+=new AsyncCompletedEventHandler(ClientModulList2_DownloadFileCompleted);


                if (!FUrlModulList.EndsWith(".xml"))
                {

                    FUrlModulList = FUrlModulList+"/zefmod.xml";
                }
                Uri siteUri = new Uri(FUrlModulList);

                if (ForceRefresh)
                {


                    ClientModulList.DownloadFileAsync(siteUri, Path.Combine(FDownloadDirectory,"modulliste.xml"));

                }



                if (!File.Exists(FDownloadDirectory + @"\modulliste.xml"))
                {


                    ClientModulList.DownloadFileAsync(siteUri, Path.Combine(FDownloadDirectory,"modulliste.xml"));

                }


            }
         
            catch (Exception e)
            {

                

            }
        }

        

        void ClientModulList2_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.BytesReceived == e.TotalBytesToReceive)
            {

                (sender as WebClient).Headers.Set("download", "success");



            }
        }

        void ClientModulList2_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {

                if ((sender as WebClient).Headers.Get("download") != "success")
                {
                    return;

                }
                
              
                XmlDocument ML = new XmlDocument();
                ML.Load(FDownloadDirectory + @"\modulliste.xml");
                //Modulliste veroeffentlichen
                FModulListe.Load(Path.Combine(FDownloadDirectory,"modulliste.xml"));
                //
                XmlNodeList ModulNodes = ML.SelectNodes("descendant::module");
                
                foreach (XmlNode ModulNode in ModulNodes)
                {
                    
                    if (OnModulNode != null)
                    {
                        //Jedes modul-XML Node per event an Applikation melden
                        OnModulNode(this, new EventArgs(), ModulNode);
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

                XmlNodeList AnotherServerNodes = ML.SelectNodes("descendant::zefania-modules-list-servers/server");
                
                
                foreach (XmlNode AnotherServerNode in AnotherServerNodes)
                {

                    if (OnAnotherServer != null)
                    {
                        OnAnotherServer(this, AnotherServerNode.InnerText);
                    }

                }

                if (OnScanFinished != null)
                {

                    OnScanFinished(this);

                }
            }

            catch (Exception ee)
            {
                
            }

        }

        void ModulClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            
            if (e.BytesReceived == e.TotalBytesToReceive) {

                (sender as WebClient).Headers.Set("download", "success");
              

            
            }
            
            
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
            try
            {

                File.Delete(this.FMirrorPageFileName);
                File.Delete(this.FModullisteFileName);

            }
            catch (Exception ee)
            {
                
            }
        }



    }
}
