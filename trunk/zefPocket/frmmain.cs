using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Reflection;

using NewTrueSharpSwordAPICF;
using ICSharpCode.SharpZipLib.Zip;



namespace zefPocket
{
	
	/// <summary>
	/// Zusammenfassung für Form1.
	/// </summary>
	public class frmmain : System.Windows.Forms.Form
	{
		private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageBibel;
		private System.Windows.Forms.Panel paneldict;
		private System.Windows.Forms.Panel panelbase;
		private System.Windows.Forms.Panel panelmain;
		private OpenNETCF.Windows.Forms.ComboBoxEx comboBoxBibles;
		private OpenNETCF.Windows.Forms.WebBrowser webBrowserBible;
		private System.Windows.Forms.Panel panelHead;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.MenuItem menuItemBibledownloader;
		private System.Windows.Forms.MainMenu mainMenu1;

		
		
		public frmmain()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmmain));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItemBibledownloader = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panelbase = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageBibel = new System.Windows.Forms.TabPage();
			this.paneldict = new System.Windows.Forms.Panel();
			this.panelmain = new System.Windows.Forms.Panel();
			this.webBrowserBible = new OpenNETCF.Windows.Forms.WebBrowser();
			this.panelHead = new System.Windows.Forms.Panel();
			this.comboBoxBibles = new OpenNETCF.Windows.Forms.ComboBoxEx();
			this.imageList1 = new System.Windows.Forms.ImageList();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			// 
			// menuItem1
			// 
			this.menuItem1.MenuItems.Add(this.menuItem6);
			this.menuItem1.MenuItems.Add(this.menuItem4);
			this.menuItem1.MenuItems.Add(this.menuItem3);
			this.menuItem1.Text = "View";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Text = "SplitView";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.MenuItems.Add(this.menuItemBibledownloader);
			this.menuItem4.Text = "Installieren";
			// 
			// menuItemBibledownloader
			// 
			this.menuItemBibledownloader.Text = "Bibelmodul(e)";
			this.menuItemBibledownloader.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Text = "Exit";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// panelbase
			// 
			this.panelbase.BackColor = System.Drawing.Color.DarkGray;
			this.panelbase.Controls.Add(this.tabControl1);
			this.panelbase.Size = new System.Drawing.Size(246, 248);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageBibel);
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(240, 272);
			// 
			// tabPageBibel
			// 
			this.tabPageBibel.Controls.Add(this.paneldict);
			this.tabPageBibel.Controls.Add(this.panelmain);
			this.tabPageBibel.Controls.Add(this.panelHead);
			this.tabPageBibel.Location = new System.Drawing.Point(4, 4);
			this.tabPageBibel.Size = new System.Drawing.Size(232, 246);
			this.tabPageBibel.Text = "Bibel";
			// 
			// paneldict
			// 
			this.paneldict.BackColor = System.Drawing.Color.MistyRose;
			this.paneldict.Location = new System.Drawing.Point(0, 168);
			this.paneldict.Size = new System.Drawing.Size(232, 80);
			// 
			// panelmain
			// 
			this.panelmain.BackColor = System.Drawing.Color.RosyBrown;
			this.panelmain.Controls.Add(this.webBrowserBible);
			this.panelmain.Location = new System.Drawing.Point(0, 35);
			this.panelmain.Size = new System.Drawing.Size(232, 133);
			// 
			// webBrowserBible
			// 
			this.webBrowserBible.BackColor = System.Drawing.Color.Snow;
			this.webBrowserBible.Size = new System.Drawing.Size(232, 136);
			this.webBrowserBible.Text = "webBrowser1";
			this.webBrowserBible.Url = null;
			// 
			// panelHead
			// 
			this.panelHead.BackColor = System.Drawing.Color.PeachPuff;
			this.panelHead.Controls.Add(this.comboBoxBibles);
			this.panelHead.Size = new System.Drawing.Size(246, 35);
			// 
			// comboBoxBibles
			// 
			this.comboBoxBibles.Location = new System.Drawing.Point(8, 8);
			this.comboBoxBibles.Size = new System.Drawing.Size(120, 21);
			// 
			// imageList1
			// 
			this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.Add(this.toolBarButton1);
			this.toolBar1.Buttons.Add(this.toolBarButton2);
			this.toolBar1.Buttons.Add(this.toolBarButton3);
			this.toolBar1.Buttons.Add(this.toolBarButton4);
			this.toolBar1.Buttons.Add(this.toolBarButton5);
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 0;
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 0;
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.ImageIndex = 0;
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 0;
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.ImageIndex = 0;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			// 
			// frmmain
			// 
			this.Controls.Add(this.panelbase);
			this.Controls.Add(this.toolBar1);
			this.Menu = this.mainMenu1;
			this.Text = "Zefania PPC";
			this.Load += new System.EventHandler(this.frmmain_Load);

		}
		#endregion

		private string AppPath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
		private string CachePath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName)+@"\zefcache\";
		private cfhtmlpages HTMLPAGER =new cfhtmlpages();
		private XmlNode Moduls;
		private bool ViewIsSplitted=false;
		frdownloader frDown =null;
		
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>

		static void Main() 
		{
			Application.Run(new frmmain());
		}

		private void frmmain_Load(object sender, System.EventArgs e)
		{
			try
			{   
				
				SplittView(ViewIsSplitted);
				AppPath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
				PopulateBiblesCombo();
				comboBoxBibles.SelectedIndex=0;
				Directory.CreateDirectory(AppPath+@"\zefcache");
				
			}
			catch(Exception ex)
			{
			
			}
		}
		
		public  void PopulateBiblesCombo()
		{
			try
			{
				comboBoxBibles.Items.Clear();
				XmlDocument Config=new XmlDocument();
                
				
				if(File.Exists(AppPath+@"\config.xml"))
				{
					Config.Load(AppPath+@"\config.xml");
					Moduls=Config.DocumentElement;
					foreach(XmlNode m in Moduls.ChildNodes)
					{
						comboBoxBibles.Items.Add(m.Attributes.GetNamedItem("name").InnerText);
					}
					 
				}

				
			}
			catch(Exception ex)
			{
			
			}
			
		}
		private void SplittView(bool isSplitted)
		{
		  
			try
			{
			  
				if(isSplitted)
				{
					panelmain.Height=152;
					paneldict.Height=80;
					webBrowserBible.Height=panelmain.Height;
					paneldict.Location=new Point(paneldict.Location.X,tabPageBibel.ClientSize.Height-80);
					paneldict.Width=tabPageBibel.ClientSize.Width;
				}
				else
				{
					
					

					panelbase.Width=ClientSize.Width;
					panelbase.Height=this.ClientSize.Height;
					
					tabControl1.Width=panelbase.Width;
					tabControl1.Height=panelbase.Height;
					panelHead.Location=new Point(0,0);
					panelHead.Height=35;
					panelHead.Width=tabPageBibel.ClientSize.Width;
					panelmain.Location=new Point(0,panelHead.Height);
					panelmain.Height=tabPageBibel.ClientSize.Height-panelHead.Height;
					panelmain.Width=tabPageBibel.ClientSize.Width;
					webBrowserBible.Width=panelmain.Width;
					webBrowserBible.Height=panelmain.Height;
					paneldict.Height=0;
				
				}
			}
			catch(Exception ex)
			{
			
			}
		
		}

		private void LoadBibleChapterToScreen(string BookNumber,string ChapterNumber)
		{

			try
			{
			    
				string MD5Dir=null;

				foreach(XmlNode m in Moduls.ChildNodes)
				{
					if(m.Attributes.GetNamedItem("name").InnerText=="comboBoxBibles.SelectedItem.ToString()")
					{
					  
						MD5Dir=m.InnerText;
						MD5Dir.Replace(@"\","");
										
					}
				}	
                
				HTMLPAGER.CachePathForModul=AppPath+@"\zefcache\"+MD5Dir;
				//webBrowser1.DocumentText=HTMLPAGER.GetChapterAsFlowText(BookNumber,ChapterNumber);
				
			}
			catch(Exception ex)
			{
			
			}
		
		}
		
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			PopulateBiblesCombo();
		}

		private void buttonEx1_Click(object sender, System.EventArgs e)
		{
			//LoadBibleChapterToScreen(textBoxEx1.Text,textBoxEx2.Text);
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
		
		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			try
			{   
				if(frDown==null){
				
				   frDown=new frdownloader();
				   frDown.Text=Text;
				
				}
				frDown.Show();
			}

			catch(Exception ex)
			{
		         MessageBox.Show(ex.Message);
			}

		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			ViewIsSplitted=!ViewIsSplitted;
			SplittView(ViewIsSplitted);
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			try
			{
			  
				
			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void InstallPPC_OnChapter(object sender, EventArgs e, string message)
		{
			foreach(Control c in this.paneldict.Controls)
			{
			  
				c.Text=message;
			
			}
			Application.DoEvents();
		}
	}
	class InstallThread
	{
		public delegate void OnGetChapter(object sender, EventArgs e,string message);
		public event OnGetChapter OnChapter;
		
		public string AppPath=null;
		public void Imstall()
		{

			try
			{
				string[] ppcmoduls=Directory.GetFiles(AppPath,"*.zip");
				foreach(string path in ppcmoduls)
				{
					InstallBibleModul(path);
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
				ZipEntry theEntry;
            
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
							   
							OnChapter(this,e1,fileName);
						}
						streamWriter.Close();
						
						
					}
				}// end while
				
				// im realen Gerät würde man das PPC-Modulzip jetzt aus Platzgründen löschen
				
				File.Delete(modulzip);

				// aktuallisiere config.xml
				XmlDocument INFO=new XmlDocument();
				XmlDocument Config=new XmlDocument();
				INFO.Load(AppPath+@"\zefcache\"+directoryName+@"\info.xml");
				Config.Load(AppPath+@"\config.xml");

				XmlNodeList TITLE=INFO.GetElementsByTagName("title");
				foreach(XmlNode title in TITLE)
				{
					BibleName=title.InnerText;
					XmlNode newModul=Config.CreateNode(XmlNodeType.Element,"modul","");
					XmlNode Att=Config.CreateNode(XmlNodeType.Attribute,"name","");
					Att.Value=BibleName;
					newModul.Attributes.SetNamedItem(Att);
					newModul.InnerText=directoryName;
					Config.DocumentElement.AppendChild(newModul);
					Config.Save(AppPath+@"\config.xml");
					 
				}
				s.Close();
			}

			finally
			{
				
			}
																		   
			
		}
	}
}

