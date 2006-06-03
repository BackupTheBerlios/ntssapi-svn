using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Net;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;


namespace zefPocket
{
	/// <summary>
	/// Zusammenfassung für frdownloader.
	/// </summary>
	public class frdownloader : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ProgressBar progressBar1;
		private OpenNETCF.Windows.Forms.ComboBoxEx cbLanguage;
		private OpenNETCF.Windows.Forms.SmartList smartListModule;
		
		private System.Xml.XmlDocument ModulListe=new XmlDocument();
		
		private System.Windows.Forms.MenuItem menuItemModulliste;
		private System.Windows.Forms.MenuItem menuItemServer;
		private System.Windows.Forms.MenuItem menuItemGetIt;
		private System.Windows.Forms.Label labelInfo;

		private string DataDir=null;
		private string DownURL=null;
		private string LatestModul=null;
		private string What=null;
		
		
		string ServerSuffix="?use_mirror=mesh";
	
		public frdownloader()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Konstruktorcode hinter dem InitializeComponent-Aufruf hinzufügen
			//
		}

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItemModulliste = new System.Windows.Forms.MenuItem();
			this.menuItemServer = new System.Windows.Forms.MenuItem();
			this.menuItemGetIt = new System.Windows.Forms.MenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbLanguage = new OpenNETCF.Windows.Forms.ComboBoxEx();
			this.panel2 = new System.Windows.Forms.Panel();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.smartListModule = new OpenNETCF.Windows.Forms.SmartList();
			this.labelInfo = new System.Windows.Forms.Label();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItemModulliste);
			this.mainMenu1.MenuItems.Add(this.menuItemServer);
			this.mainMenu1.MenuItems.Add(this.menuItemGetIt);
			// 
			// menuItemModulliste
			// 
			this.menuItemModulliste.Text = "Liste";
			this.menuItemModulliste.Click += new System.EventHandler(this.menuItemModulliste_Click);
			// 
			// menuItemServer
			// 
			this.menuItemServer.Text = "Server";
			this.menuItemServer.Click += new System.EventHandler(this.menuItemServer_Click);
			// 
			// menuItemGetIt
			// 
			this.menuItemGetIt.Text = "Get it!";
			this.menuItemGetIt.Click += new System.EventHandler(this.menuItemGetIt_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.PeachPuff;
			this.panel1.Controls.Add(this.cbLanguage);
			this.panel1.Size = new System.Drawing.Size(240, 35);
			// 
			// cbLanguage
			// 
			this.cbLanguage.Location = new System.Drawing.Point(8, 8);
			this.cbLanguage.Size = new System.Drawing.Size(80, 21);
			this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.RosyBrown;
			this.panel2.Controls.Add(this.progressBar1);
			this.panel2.Location = new System.Drawing.Point(0, 248);
			this.panel2.Size = new System.Drawing.Size(240, 24);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 8);
			this.progressBar1.Size = new System.Drawing.Size(224, 8);
			// 
			// smartListModule
			// 
			this.smartListModule.AutoNumbering = false;
			this.smartListModule.BackColor = System.Drawing.SystemColors.Window;
			this.smartListModule.DataSource = null;
			this.smartListModule.DisplayMember = null;
			this.smartListModule.EvenItemColor = System.Drawing.Color.Gainsboro;
			this.smartListModule.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular);
			this.smartListModule.ForeColor = System.Drawing.SystemColors.ControlText;
			this.smartListModule.FullKeyboard = false;
			this.smartListModule.ImageList = null;
			this.smartListModule.ItemHeight = 16;
			this.smartListModule.LineColor = System.Drawing.SystemColors.ControlText;
			this.smartListModule.Location = new System.Drawing.Point(8, 40);
			this.smartListModule.SelectedIndex = -1;
			this.smartListModule.ShowLines = true;
			this.smartListModule.ShowScrollbar = true;
			this.smartListModule.Size = new System.Drawing.Size(224, 176);
			this.smartListModule.Text = "smartListModule";
			this.smartListModule.TopIndex = 0;
			this.smartListModule.WrapText = false;
			// 
			// labelInfo
			// 
			this.labelInfo.Location = new System.Drawing.Point(8, 224);
			this.labelInfo.Size = new System.Drawing.Size(224, 16);
			// 
			// frdownloader
			// 
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.smartListModule);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Menu = this.mainMenu1;
			this.Text = "frdownloader";
			this.Load += new System.EventHandler(this.frdownloader_Load);

		}
		#endregion

		/// <summary>
		///  Lesen und setzen des Downloadverzeichnisses
		/// </summary>
		public string DataDirectory
		{
		
			get
			{
				return this.DataDir;
			}
			set
			{
				this.DataDir=value;
			}
		}

		public void DownloadEndHandler(Stream destStream)
		{
		  
			//Die Datei schließen
			destStream.Flush();
			destStream.Close();
			//Info ausgeben
			
			this.progressBar1.Value=0;

			if(this.What=="modppc")
			{
				this.What=null;
				FillBoxes();
				this.cbLanguage.SelectedIndex=0;
			
			}
			this.menuItemModulliste.Enabled=true;
			if(this.What=="mirror")
			{
				this.What=null;
				this.DownModul();
			
			}

			if(this.What=="downppc")
			{
				this.What=null;
				this.labelInfo.Text="Entpacke Modul ....";
				this.labelInfo.Refresh();
				InstallThread InStallModul=new InstallThread();
				InStallModul.AppPath=this.DataDirectory;
				InStallModul.ModulPath=this.LatestModul;
				InStallModul.OnChapter+=new zefPocket.InstallThread.OnGetChapter(InStallModul_OnChapter);
				InStallModul.OnIsInstalled+=new zefPocket.InstallThread.OnInstalled(InStallModul_OnIsInstalled);
				InStallModul.Install();
				
			
			}

		
		}
		public void DownloadErrorHandler(string error)
		{
			this.What=null;
			MessageBox.Show(error,"Zefania PPC");
		}
		public void DownloadProgressHandler(WebDownload.DownloadState downloadstate,int currentBytes,long totalBytes)
		{
		   
			lock(this)
			{			       
				switch(downloadstate)
				{
					case WebDownload.DownloadState.OpeningConnection:
						this.progressBar1.Value=0;
						
						break;

					case WebDownload.DownloadState.ReadingData:
						
						int progress =(int)((currentBytes/(double)totalBytes)*100);
						if(progress<-0){progress=0;}
						this.progressBar1.Value=progress;
						
						break;


					case WebDownload.DownloadState.DataReady:
						this.progressBar1.Value=0;
						
						break;
			   
				}
			}
		}
		private void menuItemModulliste_Click(object sender, System.EventArgs e)
		{
			this.What="modppc";
			this.labelInfo.Text="Lade Modulliste ...";
			this.labelInfo.Refresh();
			FileStream fileStream=null;
			try
			{
				string TargetFile=this.DataDirectory+@"\zefmodsppc.xml";
				fileStream = new FileStream(TargetFile,FileMode.Create,FileAccess.Write);
				
				
				
				
			}
			catch(Exception ex)
			{
			     
				MessageBox.Show(ex.Message,"Zefania PPC");
				// FileStream schließen
				try
				{
					fileStream.Close();
				
				}
				catch{}

				return;

			
			}
			// Datei asynchron herunterladen
			try
			{

				
				WebDownload ModulList=new WebDownload();
				string TargetURL=@"http://zefania-sharp.sourceforge.net/zefmodppc.xml";
				ModulList.DownloadSync(TargetURL,fileStream,1024,
					new WebDownload.DownloadProgress(this.DownloadProgressHandler),
					new WebDownload.DownloadEnd(this.DownloadEndHandler),
					new WebDownload.DownloadError(this.DownloadErrorHandler));
              

			}
			catch(Exception ex)
			{
			     
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		}
		//****

		private string GetModulURL()
		{
			try
			{

				StreamReader sr = new StreamReader(this.DataDirectory+@"\mirrorpage.html",Encoding.GetEncoding("windows-1252")); 
				string line=null;
				while(( line=sr.ReadLine())!=null)
				{
					if(line.IndexOf("<META HTTP-EQUIV")>-1)
					{
				  
						break;
				
					}
				}
				line=line.Remove(0,44);
				line=line.Replace("\">","");
				return line;
			}
		
			catch(Exception ex)
			{
			    
				MessageBox.Show(ex.Message,"Zefania PPC");
				return null;
			}
		}

		//****

		//*****
		private void DownModul()
		{
			this.What="downppc";
			this.labelInfo.Text="Lade Modul ...";
			this.labelInfo.Refresh();
			FileStream fileStream=null;
			try
			{
				
				string TargetFile=this.DataDirectory+@"\"+Path.GetFileName(GetModulURL());
				this.LatestModul=TargetFile;
				fileStream = new FileStream(TargetFile,FileMode.Create,FileAccess.Write);
				
					
			}
			catch(Exception ex)
			{
			     
				MessageBox.Show(ex.Message,"Zefania PPC");
				// FileStream schließen
				try
				{
					fileStream.Close();
				
				}
				catch{}

				return;

			
			}
			// Datei asynchron herunterladen
			try
			{

				
				WebDownload ModulList=new WebDownload();
				
				ModulList.DownloadSync(this.GetModulURL(),fileStream,4096,
					new WebDownload.DownloadProgress(this.DownloadProgressHandler),
					new WebDownload.DownloadEnd(this.DownloadEndHandler),
					new WebDownload.DownloadError(this.DownloadErrorHandler));
              

			}
			catch(Exception ex)
			{
			     
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		}



		//*****

		//*****
		private void DownMirrorPage()
		{
			this.What="mirror";
			FileStream fileStream=null;
			try
			{
				string TargetFile=this.DataDirectory+@"\mirrorpage.html";
				fileStream = new FileStream(TargetFile,FileMode.Create,FileAccess.Write);
				
					
			}
			catch(Exception ex)
			{
			     
				MessageBox.Show(ex.Message,"Zefania PPC");
				// FileStream schließen
				try
				{
					fileStream.Close();
				
				}
				catch{}

				return;

			
			}
			// Datei asynchron herunterladen
			try
			{

				
				WebDownload ModulList=new WebDownload();
				
				ModulList.DownloadSync(DownURL,fileStream,1024,
					new WebDownload.DownloadProgress(this.DownloadProgressHandler),
					new WebDownload.DownloadEnd(this.DownloadEndHandler),
					new WebDownload.DownloadError(this.DownloadErrorHandler));
              

			}
			catch(Exception ex)
			{
			     
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		}


		//*****

		
		private void FillBoxes()
		{
	
			try
			{
				string target=this.DataDirectory+@"\zefmodsppc.xml";
				if(File.Exists(target))
				{
					//erst alle Boxen löschen;
					this.cbLanguage.Items.Clear();
					
					ModulListe.Load(target);
					System.Xml.XmlNodeList modules=ModulListe.DocumentElement.GetElementsByTagName("modul");
					
					foreach (XmlNode n in modules)
					{
					    
						string ModulLang=n.Attributes.GetNamedItem("lang").Value;
						if(!cbLanguage.Items.Contains(ModulLang))
						{
						  
							cbLanguage.Items.Add(ModulLang);
						
						}
					
					}
					
				}
			}

			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Zefania PPC");
			}

		}

		private void SelectDownloadURL(string InstallModul)
		{
			try
			{
				System.Xml.XmlNodeList modules=ModulListe.DocumentElement.GetElementsByTagName("modul");			
				
				foreach (XmlNode n in modules)
				{

					string ModulName=n.Attributes.GetNamedItem("name").Value;
				
					if(ModulName==InstallModul)
					{
						string FileName=n.Attributes.GetNamedItem("filename").Value;
						
						this.DownURL="http://prdownloads.sourceforge.net/zefania-sharp/"+FileName+this.ServerSuffix;


					}
				
				}
			}
			catch(Exception ex)
			{
			     
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		}


		private void SelectServer()
		{
			try
			{
               
				System.Xml.XmlNodeList mirrors=ModulListe.DocumentElement.GetElementsByTagName("mirror");
			    
				Random rnd = new Random();
				int Zufallszahl = rnd.Next(0, mirrors.Count);
				XmlNode Server=mirrors.Item(Zufallszahl);
				this.labelInfo.Text=Server.Attributes.GetNamedItem("location").Value;
				ServerSuffix=Server.Attributes.GetNamedItem("suffix").Value;
		
			}
			catch(Exception ex)
			{
			     
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		}


		private void cbLanguage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string name=(sender as ComboBox).SelectedItem.ToString();
			System.Xml.XmlNodeList modules=ModulListe.DocumentElement.GetElementsByTagName("modul");
			smartListModule.Items.Clear();
			smartListModule.BeginUpdate();
			foreach (XmlNode n in modules)
			{
					    
				string ModulLang=n.Attributes.GetNamedItem("lang").Value;
				string ModulName=n.Attributes.GetNamedItem("name").Value;
				
				if(ModulLang==name)
				{
					this.smartListModule.Items.Add(ModulName);
				}
				
			}
			smartListModule.EndUpdate();	
		}

		private void menuItemServer_Click(object sender, System.EventArgs e)
		{
			this.SelectServer();
		}	

		private void menuItemGetIt_Click(object sender, System.EventArgs e)
		{
			int si=smartListModule.SelectedIndex;
			if(si==-1)
			{
				MessageBox.Show("Bitte erst ein Modul auswählen!","Zefania PPC");
			}
			else
			{
				this.SelectDownloadURL(this.smartListModule.Items[si].Text);
				this.DownMirrorPage();
			}
		}

		

		private void InStallModul_OnChapter(object sender, EventArgs e, string message, int count, int maxchapter)
		{
			this.progressBar1.Maximum=maxchapter;
			this.progressBar1.Value=count;
			   
		}

		private void InStallModul_OnIsInstalled(object sender, EventArgs e)
		{
			this.labelInfo.Text="Bereit";
			this.progressBar1.Value=0;
			this.progressBar1.Maximum=100;
		}

		private void frdownloader_Load(object sender, System.EventArgs e)
		{
			this.FillBoxes();
			
		}

		
	}
    
	/// <summary>
	/// Downloadklasse
	/// </summary>
	public class WebDownload
	{
		/* Aufzählung und Delegates für den Fortschritt und das Ende der
		 * Download-Methode und für Fehlermeldungen */
		public enum DownloadState
		{
			OpeningConnection,
			ReadingData,
			DataReady
		}
		public delegate void DownloadProgress(DownloadState downloadState, 
			int currentBytes, long totalBytes);
		public delegate void DownloadEnd(Stream destStream);
		public delegate void DownloadError(string message);

		/* Klasse, über deren Instanzen ein Download ausgeführt wird */
		private class Download
		{
			public string Url;
			public int BlockSize;
			public DownloadProgress DownloadProgress;
			public DownloadEnd DownloadEnd;
			public DownloadError DownloadError;
			public Stream DestStream;

			/* Konstruktor */
			public Download(string url, Stream destStream, int blockSize,
				DownloadProgress downloadProgress, DownloadEnd downloadEnd,
				DownloadError downloadError)
			{
				this.Url = url;
				this.BlockSize = blockSize;
				this.DownloadProgress = downloadProgress;
				this.DownloadEnd  = downloadEnd;
				this.DestStream = destStream;
				this.DownloadError = downloadError ;
			}

			/* Methode, die den Download ausführt */
			public void PerformDownload()
			{
				WebRequest request = null;
				WebResponse response = null;
				Stream responseStream = null;
				try
				{
					// WebRequest-Instanz für den Download erzeugen, die Antwort
					// anfordern und die Länge der Daten ermitteln
					if (this.DownloadProgress != null)
						this.DownloadProgress(DownloadState.OpeningConnection, 0, 0);
					request = WebRequest.Create(this.Url);
					response = request.GetResponse();
					long fileSize = response.ContentLength;

					// Den Antwort-Stream ermitteln, diesen blockweise lesen und
					// in den Zielstream schreiben
					responseStream = response.GetResponseStream();
					int bytesRead = 0;
					int totalBytesRead = 0;
					byte[] buffer = new byte[this.BlockSize];
					do
					{
						bytesRead = responseStream.Read(buffer, 0, this.BlockSize);
						totalBytesRead += bytesRead;
						this.DestStream.Write(buffer, 0, bytesRead);

						// Fortschritt melden
						if (this.DownloadProgress!= null)
							this.DownloadProgress(DownloadState.ReadingData,
								totalBytesRead, fileSize);
					} while (bytesRead > 0);

				}
				catch (Exception ex)
				{
					if (this.DownloadError != null)
						// Delegate für Fehlermeldungen aufrufen
						this.DownloadError(ex.Message);
					else
						// Ausnahme weiterwerfen
						throw ex;
				}
				finally
				{
					try 
					{
						// Den Response-Stream und das WebResponse-Objekt schließen
						responseStream.Close();
						response.Close();
					}
					catch {}

					// Den Delegate für das Ende des Downloads aufrufen
					if (this.DownloadEnd != null)
						this.DownloadEnd(this.DestStream); 
				}
			}
		}
    
		/* Methode zum synchronen Download einer Datei */
		public void DownloadSync(string url, Stream destStream, int blockSize,
			DownloadProgress downloadProgress, DownloadEnd downloadEnd,
			DownloadError downloadError)
		{
			// Download-Objekt erzeugen und initialisieren
			Download download = new Download(url, destStream, blockSize,
				downloadProgress, downloadEnd, downloadError);

			// Download synchron starten
			download.PerformDownload();
		}

    
		/* Methode zum asynchronen Download einer Datei */
		public void DownloadAsync(string url, Stream destStream, int blockSize, 
			DownloadProgress downloadProgress, DownloadEnd downloadEnd,
			DownloadError downloadError)
		{
			// Download-Objekt erzeugen und initialisieren
			Download download = new Download(url, destStream, blockSize,
				downloadProgress, downloadEnd, downloadError);

			// Thread für den Download starten
			Thread downloadThread = new Thread(new ThreadStart(download.PerformDownload));
			downloadThread.Start();
		}
	}
	//*****
	class InstallThread
	{
		public delegate void OnGetChapter(object sender, EventArgs e,string message,int count,int maxchapter);
		public event OnGetChapter OnChapter;
		public delegate void OnInstalled(object sender, EventArgs e);
		public event OnInstalled OnIsInstalled;
		public string AppPath=null;
		public string ModulPath=null;
		public void Install()
		{

			try
			{
				
			{
				InstallBibleModul(ModulPath);
			}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		
		/// <summary>
		/// istalliert ein gezipptes PPC-Bibelmodul im Cacheverzeichnis
		/// </summary>
		/// <param name="modulzip">z.B.  "b2fb38b57a339c691417a94d77c2cc9d.zip"</param>
		private void InstallBibleModul(string modulzip)
		{
             
			
			try
			{   
				EventArgs e1=new EventArgs();
				string BibleName=null;
				string directoryName=null;
				ZipInputStream s = new ZipInputStream(File.OpenRead(modulzip));
				ZipInputStream sc = new ZipInputStream(File.OpenRead(modulzip));
				ZipEntry theEntry;
				int x=0;int y=0;
				while ((theEntry = sc.GetNextEntry()) != null)
				{
					y=y+1;// Chapter im Zip zählen
				}
				
				while ((theEntry = s.GetNextEntry()) != null)
				{
						
					
					directoryName = Path.GetDirectoryName(theEntry.Name);
					string fileName      = Path.GetFileName(theEntry.Name);
            
					// create directory
					Directory.CreateDirectory(AppPath+@"\zefcache\"+directoryName);
                    
					if (fileName != String.Empty)
					{
						FileStream streamWriter = File.Create(AppPath+@"\zefcache\"+directoryName+@"\"+fileName);
                            
						int size = 2048;
						byte[] data = new byte[2048];
						while (true)
						{
							size = s.Read(data, 0, data.Length);
							if (size > 0)
							{
								streamWriter.Write(data, 0, size);
							}
							else
							{
								break;
							}
						}
						if(OnChapter!=null)
						{
							x=x+1;   
							OnChapter(this,e1,fileName,x,y);
						}
						streamWriter.Close();
						
						
					}
				}// end while
				
				// im realen Gerät würde man das PPC-Modulzip jetzt aus Platzgründen löschen
				
				File.Delete(modulzip);

				// aktualisiere config.xml
				XmlDocument INFO=new XmlDocument();
				XmlDocument Config=new XmlDocument();
				INFO.Load(AppPath+@"\zefcache\"+directoryName+@"\info.xml");
				Config.Load(AppPath+@"\config.xml");
				XmlNodeList INFORMATION=INFO.GetElementsByTagName("INFORMATION");
				foreach(XmlNode info in INFORMATION)
				{
					XmlNode newModul=Config.CreateNode(XmlNodeType.Element,"modul","");
					foreach(XmlNode item in info.ChildNodes)
					{
						if(item.Name=="title")
						{
							BibleName=item.InnerText;
							XmlNode Att=Config.CreateNode(XmlNodeType.Attribute,"name","");
							Att.Value=BibleName;
							newModul.Attributes.SetNamedItem(Att);
							newModul.InnerText=directoryName;
							Config.DocumentElement.AppendChild(newModul);
						}
						if(item.Name=="language")
						{
							
							XmlNode Att=Config.CreateNode(XmlNodeType.Attribute,"group","");
							Att.Value=item.InnerText;
							newModul.Attributes.SetNamedItem(Att);
							newModul.InnerText=directoryName;
							Config.DocumentElement.AppendChild(newModul);
						}
					}


					Config.Save(AppPath+@"\config.xml");
					 
				}
				s.Close();
				if(OnIsInstalled!=null)
				{
					OnIsInstalled(this,e1);
				}
			}

			finally
			{
				
			}
																		   
			
		}
	}
	//*****
}
