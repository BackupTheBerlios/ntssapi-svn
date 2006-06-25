using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Globalization;
using zefdownloader;
using System.Threading;
using System.IO;
using System.Diagnostics;

using System.Runtime.Serialization.Formatters.Binary;
using ICSharpCode.SharpZipLib.Zip;




namespace ModulDownloader
{
    public partial class MainForm : Form
    {

        

        private int LangID = 0;
        private List<string> ModulListServers = new List<string>();
        private List<string> MyBibleInstall = new List<string>();

        private string[][] LangArray = new string[2][];

        private List<TreeNode> DownLoadListe = new List<TreeNode>();
        private List<TreeNode> MyBibleYetToInstall = new List<TreeNode>();


        delegate void SetTextCallback(string ModulName, string Percentage, TreeNode Node);
        delegate void RemoveTextCallback(string ModulName, TreeNode Node,string FileName);
        delegate void BuildServerTreeCallback();


        private BackgroundWorker DownloadThread;
        ZefModulDownLoader MDL = new ZefModulDownLoader();
        ZefModulDownLoader MLoader;
     
        private string FModulListServer = "http://";
        private const string myVersion="Beta 0.5";

        public MainForm()
        {
            InitializeComponent();
        }

        private void BuildServerTree()
        {

            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (treeView1.InvokeRequired)
            {

                BuildServerTreeCallback d = new BuildServerTreeCallback(BuildServerTree);
                this.Invoke(d);
            }
            else
            {

                ReadModullistFromServer();

            }
        }


        private void SetText(string ModulName, string Percentage, TreeNode Node)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (treeView1.InvokeRequired)
            {

                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { ModulName, Percentage, Node });
            }
            else
            {
                treeView1.BeginUpdate();
                TreeNode percentage;
                int index=Node.Nodes.IndexOfKey("percent");
                
                if (index ==-1)
                {

                    percentage =Node.Nodes.Insert(0, "percent","0"); 
                    percentage.ImageIndex = 226;
                    percentage.SelectedImageIndex = 226;
                    Node.Expand();
                    
                }else
                {
                  
                    percentage = Node.Nodes[index]; 
                }

                percentage.Text = Percentage;

                treeView1.EndUpdate();

            }
        }

        private void updateAfterDownload(string ModulName, TreeNode Node,string FileName)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (treeView1.InvokeRequired)
            {

                RemoveTextCallback d = new RemoveTextCallback(updateAfterDownload);
                this.Invoke(d, new object[] { ModulName, Node,FileName });
            }
            else
            {


                if (File.Exists(FileName))
                {
                    ZipInputStream ZIP = GetZippedModulContent(FileName);
                    string FN = GetMyBibleModulesDirectory() + GetModulNameFromZippedModul(FileName);
                    if (File.Exists(FN))
                    {

                        Node.ForeColor = Color.Blue;
                    }
                    else
                    {
                        Node.ForeColor = Color.Green;
                    }
                }
                
                
                Node.Checked = false;
                
                
                Node.FirstNode.Remove();

                DownLoadListe.Remove(Node);

                if (DownLoadListe.Count == 0) {

                    CreateMyBibleInstallFile();
                
                }
                

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //SwitchLanguage("en-US");

            Text = "Zefania XML Downloader " + myVersion; 
            MDL.DownloadDirectory = Application.CommonAppDataPath;
            MDL.OnModulNode += new ZefModulDownLoader.ModulListEventHandler(MDL_OnModulNode);
            MDL.OnServerNode += new ZefModulDownLoader.ModulServerEventHandler(MDL_OnServerNode);

            string lang = Application.CurrentCulture.Name;
            
            if(lang.Contains("en-")){
            
               LangID=0;
            
            }
            if (lang.Contains("de-"))
            {

                LangID = 1;

            }

            LanguageTexts();

            CheckMyBible();

            

            string file1 = Path.Combine(Application.UserAppDataPath, "menu.dat");
            if (File.Exists(file1))
            {
                ModulListServers = (List<string>)DeserializeFromFile(file1);
            }

        }

        private void LanguageTexts()
        {

            LangArray[0]= new string[]{"Select Preferred Download Mirror", "Please select at least one Download Mirror!", "Be patient read modules list from server .....","was already downloaded! Will you download it again?"};

            LangArray[1] = new string[] { "Download Mirror auswählen", "Bitte mindestens einen Download Mirror auswählen!", "Bitte einen Augenblick Geduld, lese Modulliste vom Server....","wurde schon heruntergeladen! Wollen Sie das Modul erneut herunterladen?" };
           
        }

        private void CheckMyBible()
        {
            if (GetMyBibleModulesDirectory() != string.Empty)
            {

                groupBox1.Visible = true;
                checkBox1.Checked = true;

            }
        }

        void MDL_OnServerNode(object sender, XmlNode server)
        {

            string srv = server.Attributes.GetNamedItem("location").Value;

            TreeNode Mirror = treeView1.Nodes[0].Nodes[0].Nodes.Add(srv, srv);

            Mirror.SelectedImageIndex = 231;
            Mirror.ImageIndex = 231;
            Mirror.Tag = "8888";
            


        }

        void MDL_OnModulNode(object sender, EventArgs e, System.Xml.XmlNode modulnode, System.Xml.XmlNode ISO)
        {
            int ImageIndex = 500;
            string Language = modulnode.Attributes.GetNamedItem("language").Value;
            string ModulName = modulnode.Attributes.GetNamedItem("name").Value;
            string ModulType = modulnode.Attributes.GetNamedItem("type").Value;
            string FileName = modulnode.Attributes.GetNamedItem("filename").Value;
            string Revision = modulnode.Attributes.GetNamedItem("revision").Value;
            if (ISO != null)
            {
                XmlNode ImageIx = ISO.Attributes.GetNamedItem("ix");

                if (ImageIx != null)
                {

                    ImageIndex = Convert.ToInt16(ImageIx.Value);
                }
            }
            TreeNode root = treeView1.Nodes[0];
            TreeNode MName;
            TreeNode MType;
            TreeNode LG;
            int index = root.Nodes.IndexOfKey(ModulType);

            if (index == -1)
            {
                MType = root.Nodes.Add(ModulType, ModulType);
                LG = MType.Nodes.Add(Language, Language);

                MName = LG.Nodes.Add(ModulName, ModulName);

                MName.Nodes.Add(FileName, FileName);
                MName.Nodes.Add(Revision, "Revision " + Revision);

            }
            else
            {
                MType = root.Nodes[index];
                int index2 = MType.Nodes.IndexOfKey(Language);
                if (index2 == -1)
                {
                    LG = MType.Nodes.Add(Language, Language);

                    MName = LG.Nodes.Add(ModulName, ModulName);
                   
                    MName.Nodes.Add(FileName, FileName);
                    MName.Nodes.Add(Revision, "Revision " + Revision);

                }
                else
                {

                    LG = MType.Nodes[index2];
                    MName = LG.Nodes.Add(ModulName, ModulName);
                    
                    MName.Nodes.Add(FileName, FileName);
                    MName.Nodes.Add(Revision, "Revision " + Revision);

                }

            }

            if (File.Exists(MDL.DownloadDirectory + @"\" + FileName))
            {
                ZipInputStream ZIP = GetZippedModulContent(MDL.DownloadDirectory + @"\" + FileName);
                string FN = GetMyBibleModulesDirectory() + GetModulNameFromZippedModul(MDL.DownloadDirectory + @"\" + FileName);
                if (File.Exists(FN))
                {

                    MName.ForeColor = Color.Blue;
                }
                else
                {
                    MName.ForeColor = Color.Green;
                }
            }

            LG.ImageIndex = ImageIndex;
            LG.SelectedImageIndex = ImageIndex;

            MName.ImageIndex = 230;
            MName.SelectedImageIndex = 230;
            MName.Tag = "9999";
            MType.ImageIndex = 230;
            MType.SelectedImageIndex = 230;


        }



        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            TreeNode N = (sender as TreeView).SelectedNode;
            if (N == null) { return; }
            if (e.KeyCode == Keys.Enter)
            {


                N.Toggle();


            }

        }

        void demoThread_DoWork(object sender, DoWorkEventArgs e)
        {
            List<TreeNode> LVS = (e.Argument as List<TreeNode>);
            
            foreach (TreeNode N in LVS)
            {

                MLoader = new ZefModulDownLoader();
                MLoader.DownloadDirectory = Application.CommonAppDataPath;
                MLoader.DownloadProgress += new System.Net.DownloadProgressChangedEventHandler(MLoader_DownloadProgress);
                MLoader.DownloadCompleted += new AsyncCompletedEventHandler(MLoader_DownloadCompleted);
                MLoader.OnWebExeption += new ZefModulDownLoader.WebEventExecptionHandler(MLoader_OnWebExeption);
                MLoader.UrlModulList = this.FModulListServer;
                MLoader.GetModulByName(N.Text, N.ToolTipText);
            }
        }

        void MLoader_OnWebExeption(object sender, System.Net.WebException e)
        {
            string Key = (sender as ZefModulDownLoader).ModulName;
            //this.SetText(Key, e.Message,);
        }

        void MLoader_DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ZefModulDownLoader ML = (sender as ZefModulDownLoader);
            string Key = (sender as ZefModulDownLoader).ModulName;
           
            foreach (TreeNode N in DownLoadListe)
            {

                if (N.Text == Key)
                {
                    
                   

                    if (checkBox1.Checked)
                    {
                        string pathXML = GetMyBibleModulesDirectory() + GetModulNameFromZippedModul(ML.LocalFilePath);
                        FileStream fs = new FileStream(pathXML, FileMode.Create);
                        ReadWriteStream(GetZippedModulContent(ML.LocalFilePath), fs);
                        if(!MyBibleInstall.Contains(pathXML)){
                          MyBibleInstall.Add(Path.GetFileName(pathXML));
                        }
                    }

                    updateAfterDownload(Key, N,ML.LocalFilePath);
                    ML.DeleteTempFiles();

                    
                    break;

                }
            }

        }

        private string SelectDownloadServer()
        {

            TreeNode ServerNodes = treeView1.Nodes[0].Nodes[0];


            int x = -1;
            foreach (TreeNode Server in ServerNodes.Nodes)
            {

                if (Server.Checked)
                {

                    x = x + 1;

                }

            }
            if (x == -1)
            {

                MessageBox.Show(LangArray[LangID][1],"!!");
                return "";

            }
            Random r = new Random(unchecked((int)DateTime.Now.Ticks) * this.GetHashCode());
            return ServerNodes.Nodes[r.Next(x)].Text;

        }

        void MLoader_DownloadProgress(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {


            string Key = (sender as ZefModulDownLoader).ModulName;
            foreach (TreeNode N in DownLoadListe)
            {

                if (N.Text == Key)
                {

                    SetText(Key, e.BytesReceived.ToString() + "/" + e.TotalBytesToReceive.ToString(), N);
                    break;

                }
            }





        }


        //***********************************************************************************
        private void SwitchLanguage(string culture)
        {
            CultureInfo cInfo = new CultureInfo(culture);
            ComponentResourceManager resManager = new ComponentResourceManager(this.GetType());
            Point old_location = this.Location;
            resManager.ApplyResources(this, "$this", cInfo);
            this.Location = old_location; //nur für .NET 1.1 nötig
            ApplyRessourcesAllControls(this, resManager, cInfo);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        private void ApplyRessourcesAllControls(Control control, ComponentResourceManager resManager, CultureInfo cInfo)
        {
            foreach (Control ctl in control.Controls)
            {
                if (ctl.Controls.Count > 0)
                    ApplyRessourcesAllControls(ctl, resManager, cInfo);
                resManager.ApplyResources(ctl, ctl.Name, cInfo);
            }
        }

        // search all child tree nodes not installed in Mybible recursively.
        private void SearchAllChildNodes(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.ForeColor == Color.Green) {

                    MyBibleYetToInstall.Add(node);
                
                }
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the SearchAllChildsNodes method recursively.
                    this.SearchAllChildNodes(node);
                }
            }
        }

        

        // Updates all child tree nodes recursively.
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        // NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
        // After a tree node's Checked property is changed, all its child nodes are updated to the same value.
        private void node_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Tag != null)
            {

                if (e.Node.Tag.ToString() == "9999")
                {

                    if (e.Node.Checked)
                    {


                        if (!DownLoadListe.Contains(e.Node))
                        {
                            e.Node.ToolTipText = SelectDownloadServer();
                            if (e.Node.ToolTipText == "")
                            {
                                e.Node.Checked = false;
                                return;

                            }

                            if ((e.Node.ForeColor == Color.Green)||(e.Node.ForeColor == Color.Blue)) {

                                DialogResult DR = MessageBox.Show(e.Node.Text+" "+LangArray[this.LangID][3], "!!", MessageBoxButtons.YesNo);
                                if (DR == DialogResult.No) {

                                    e.Node.Checked = false;
                                    return;
                                
                                }

                            
                            }

                            DownLoadListe.Add(e.Node);
                            button2.Enabled = true;
                        }
                    }

                    else
                    {

                        DownLoadListe.Remove(e.Node);
                        if (DownLoadListe.Count == 0)
                        {
                            button2.Enabled = false;

                        }
                    }


                }

            }
            

            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }



       


        private void ReadModullistFromServer()
        {
            try
            {


                Uri URL = new Uri(MDL.UrlModulList);
                treeView1.BeginUpdate();

                treeView1.Nodes.Clear();
                TreeNode Root = treeView1.Nodes.Add(MDL.UrlModulList);
                TreeNode Mirror = Root.Nodes.Add(LangArray[LangID][0], LangArray[LangID][0]);
                Mirror.SelectedImageIndex = 231;
                Mirror.ImageIndex = 231;

                DownLoadListe.Clear();


                Root.ForeColor = Color.Maroon;
                Root.ImageIndex = 226;
                Root.SelectedImageIndex = 226;

                MDL.ScanModulList(true);

                // Begin repainting the TreeView.
                treeView1.EndUpdate();
            }
            catch (UriFormatException ee)
            {
                MessageBox.Show(MDL.UrlModulList + " : " + ee.Message, "!!");


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = this.Controls.Count;
            DownloadThread = new BackgroundWorker();
            DownloadThread.DoWork += new DoWorkEventHandler(demoThread_DoWork);
            MyBibleInstall.Clear();
            DownloadThread.RunWorkerAsync(DownLoadListe);
        }




        private string GetModulNameFromZippedModul(string ModulPath) {

            ZipEntry theEntry;

            try
            {
                ZipInputStream s = new ZipInputStream(File.OpenRead(ModulPath));
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.Size > 10000 & (Path.GetExtension(theEntry.Name) == ".xml"))
                    {

                        return theEntry.Name;
                    }
                }
                return string.Empty;
            }

            catch (Exception e)
            {
                return string.Empty;
            }
        
        }
        
        /// <summary>
        /// Extrahiert eine Datei aus einem zip-archiv
        /// </summary>
        /// <param name="ModulPath">Pfade zur zip-datei</param>
        /// <returns>Zefania XML Modul als Stream.</returns>
        public static ZipInputStream GetZippedModulContent(string ModulPath)
        {
            ZipEntry theEntry;

            try
            {
                ZipInputStream s = new ZipInputStream(File.OpenRead(ModulPath));
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.Size > 10000 & (Path.GetExtension(theEntry.Name) == ".xml"))
                    {

                        return s;
                    }
                }
                return null;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        // readStream is the stream you need to read
        // writeStream is the stream you want to write to
        public  void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string file1 = Path.Combine(Application.UserAppDataPath, "menu.dat");
            SerializeToFile(ModulListServers, file1);

        } // method: InputBox

        /* Methode zum Serialisieren eines Objekts in eine Datei */
        public static void SerializeToFile(object obj, string fileName)
        {
            FileStream fileStream = null;
            try
            {
                // FileStream für die Datei erzeugen
                fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                // Objekt serialisieren
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, obj);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }

        /* Methode zum Deserialisieren eines Objekts aus einer Datei */
        public static object DeserializeFromFile(string fileName)
        {
            FileStream fileStream = null;
            try
            {
                // FileStream für die Datei erzeugen
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                // Objekt deserialisieren
                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(fileStream);
                
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }





        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (string Server in ModulListServers)
            {

                comboBox1.Items.Add(Server);
            }

        }

        private void CreateMyBibleInstallFile(){
        
         try{

             
             string install_lst = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MyBible\Modules\install.lst";

             using (StreamWriter sw = new StreamWriter(install_lst, false))
             {
                 foreach (string XmlModulPath in MyBibleInstall)
                 {
                     sw.WriteLine(XmlModulPath);
                 }
                 sw.Flush();
             }
         }
        catch(Exception e) {
         
         
         }
        
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MDL.UrlModulList = comboBox1.Text;
            FModulListServer = MDL.UrlModulList;
            treeView1.Nodes.Clear();
            TreeNode N=treeView1.Nodes.Add(LangArray[LangID][2]);
            N.SelectedImageIndex = 227;
            N.ImageIndex = 227;
            bWModullist.RunWorkerAsync();

        }

        private void bWModullist_DoWork(object sender, DoWorkEventArgs e)
        {
            BuildServerTree();
        }

        private string GetMyBibleModulesDirectory() {

            try {

              string MyBibleMDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MyBible\Modules\";
              if(Directory.Exists(MyBibleMDir)){
              
                 return MyBibleMDir;
              
              }

              MyBibleMDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\MyBible\Modules\";
              if (Directory.Exists(MyBibleMDir))
              {

                  return MyBibleMDir;

              }
              else {

                  return "";
              
              }
            }


            catch (Exception e)
            {

                return "";

            }
        
        }

        private bool allChildrenSelected(TreeNode Node) { 
        
           try{

               foreach(TreeNode N in Node.Nodes){
                   
                   if(!N.Checked){
                   
                     return false;
                   }
               
               }

               return true;
           
           }
        catch (Exception e)
            {

                return false;

            }
        }
      

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string ListServer=comboBox1.Text;
            
            if (e.KeyCode == Keys.Enter) {
                
                if(!ModulListServers.Contains(ListServer)){
                   ModulListServers.Add(ListServer);
                   MDL.UrlModulList = ListServer;
                   FModulListServer = MDL.UrlModulList;
                   treeView1.Nodes.Clear();
                   treeView1.Nodes.Add(LangArray[LangID][2]);
                   bWModullist.RunWorkerAsync();
                   
                }
            
            }
            if (e.KeyCode == Keys.Delete)
            {

                comboBox1.Items.Remove(ListServer);
                ModulListServers.Remove(ListServer);
                

            }

        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LangID == 0)
            {
                Process.Start("http://zykloide.de/supporters/");
            }
            else
            {
                Process.Start("http://zykloide.de/supporter/");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyBibleYetToInstall.Clear();
            SearchAllChildNodes(treeView1.Nodes[0]);
            

        }

       
      


        

    }


}

