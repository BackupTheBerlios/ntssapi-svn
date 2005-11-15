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
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageBibel;
		private System.Windows.Forms.Panel panelbase;
		private System.Windows.Forms.Panel panelHead;
		private OpenNETCF.Windows.Forms.ButtonEx buttonNextChapter;
		private OpenNETCF.Windows.Forms.ButtonEx buttonPrevChapter;
		private System.Windows.Forms.Panel panelmain;
		private System.Windows.Forms.Panel paneldict;
		private OpenNETCF.Windows.Forms.WebBrowser webBrowserBible;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private OpenNETCF.Windows.Forms.ButtonEx buttonprevBook;
		private OpenNETCF.Windows.Forms.ButtonEx buttonnextBook;
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
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panelbase = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageBibel = new System.Windows.Forms.TabPage();
			this.panelmain = new System.Windows.Forms.Panel();
			this.paneldict = new System.Windows.Forms.Panel();
			this.webBrowserBible = new OpenNETCF.Windows.Forms.WebBrowser();
			this.panelHead = new System.Windows.Forms.Panel();
			this.buttonPrevChapter = new OpenNETCF.Windows.Forms.ButtonEx();
			this.buttonNextChapter = new OpenNETCF.Windows.Forms.ButtonEx();
			this.imageList1 = new System.Windows.Forms.ImageList();
			this.buttonprevBook = new OpenNETCF.Windows.Forms.ButtonEx();
			this.buttonnextBook = new OpenNETCF.Windows.Forms.ButtonEx();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			// 
			// menuItem1
			// 
			this.menuItem1.MenuItems.Add(this.menuItem2);
			this.menuItem1.MenuItems.Add(this.menuItem6);
			this.menuItem1.MenuItems.Add(this.menuItem5);
			this.menuItem1.Text = "View";
			// 
			// menuItem2
			// 
			this.menuItem2.MenuItems.Add(this.menuItem4);
			this.menuItem2.Text = "Module";
			// 
			// menuItem4
			// 
			this.menuItem4.Text = "Downloader";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Text = "Exit";
			// 
			// menuItem6
			// 
			this.menuItem6.Text = "Bibelselektor";
			this.menuItem6.Click += new System.EventHandler(this.menuItem5_Click_1);
			// 
			// panelbase
			// 
			this.panelbase.BackColor = System.Drawing.Color.DarkGray;
			this.panelbase.Controls.Add(this.tabControl1);
			this.panelbase.Size = new System.Drawing.Size(246, 272);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageBibel);
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(240, 272);
			// 
			// tabPageBibel
			// 
			this.tabPageBibel.Controls.Add(this.panelmain);
			this.tabPageBibel.Controls.Add(this.panelHead);
			this.tabPageBibel.Location = new System.Drawing.Point(4, 4);
			this.tabPageBibel.Size = new System.Drawing.Size(232, 246);
			this.tabPageBibel.Text = "Bibel";
			// 
			// panelmain
			// 
			this.panelmain.BackColor = System.Drawing.Color.RosyBrown;
			this.panelmain.Controls.Add(this.paneldict);
			this.panelmain.Controls.Add(this.webBrowserBible);
			this.panelmain.Location = new System.Drawing.Point(0, 25);
			this.panelmain.Size = new System.Drawing.Size(232, 218);
			// 
			// paneldict
			// 
			this.paneldict.BackColor = System.Drawing.Color.MistyRose;
			this.paneldict.Location = new System.Drawing.Point(0, 168);
			this.paneldict.Size = new System.Drawing.Size(232, 56);
			// 
			// webBrowserBible
			// 
			this.webBrowserBible.BackColor = System.Drawing.Color.LightCoral;
			this.webBrowserBible.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular);
			this.webBrowserBible.Size = new System.Drawing.Size(232, 176);
			this.webBrowserBible.Text = "webBrowser1";
			this.webBrowserBible.Url = null;
			// 
			// panelHead
			// 
			this.panelHead.BackColor = System.Drawing.Color.PeachPuff;
			this.panelHead.Controls.Add(this.buttonnextBook);
			this.panelHead.Controls.Add(this.buttonprevBook);
			this.panelHead.Controls.Add(this.buttonPrevChapter);
			this.panelHead.Controls.Add(this.buttonNextChapter);
			this.panelHead.Size = new System.Drawing.Size(240, 24);
			// 
			// buttonPrevChapter
			// 
			this.buttonPrevChapter.ActiveForeColor = System.Drawing.Color.PeachPuff;
			this.buttonPrevChapter.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.buttonPrevChapter.Location = new System.Drawing.Point(104, 3);
			this.buttonPrevChapter.Size = new System.Drawing.Size(32, 18);
			this.buttonPrevChapter.Text = "<";
			this.buttonPrevChapter.TextAlign = OpenNETCF.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPrevChapter.Click += new System.EventHandler(this.buttonPrevChapter_Click);
			// 
			// buttonNextChapter
			// 
			this.buttonNextChapter.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.buttonNextChapter.Location = new System.Drawing.Point(144, 3);
			this.buttonNextChapter.Size = new System.Drawing.Size(32, 18);
			this.buttonNextChapter.Text = ">";
			this.buttonNextChapter.TextAlign = OpenNETCF.Drawing.ContentAlignment.MiddleCenter;
			this.buttonNextChapter.Click += new System.EventHandler(this.buttonNextChapter_Click);
			// 
			// imageList1
			// 
			this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			// 
			// buttonprevBook
			// 
			this.buttonprevBook.ActiveForeColor = System.Drawing.Color.PeachPuff;
			this.buttonprevBook.BackColor = System.Drawing.Color.OrangeRed;
			this.buttonprevBook.Location = new System.Drawing.Point(64, 3);
			this.buttonprevBook.Size = new System.Drawing.Size(32, 18);
			this.buttonprevBook.Text = "<<";
			this.buttonprevBook.TextAlign = OpenNETCF.Drawing.ContentAlignment.MiddleCenter;
			this.buttonprevBook.Click += new System.EventHandler(this.buttonprevBook_Click);
			// 
			// buttonnextBook
			// 
			this.buttonnextBook.BackColor = System.Drawing.Color.OrangeRed;
			this.buttonnextBook.Location = new System.Drawing.Point(184, 3);
			this.buttonnextBook.Size = new System.Drawing.Size(32, 18);
			this.buttonnextBook.Text = ">>";
			this.buttonnextBook.TextAlign = OpenNETCF.Drawing.ContentAlignment.MiddleCenter;
			this.buttonnextBook.Click += new System.EventHandler(this.buttonnextBook_Click);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			// 
			// frmmain
			// 
			this.ClientSize = new System.Drawing.Size(240, 273);
			this.Controls.Add(this.panelbase);
			this.Menu = this.mainMenu1;
			this.Text = "Zefania PPC";
			this.Load += new System.EventHandler(this.frmmain_Load);

		}
		#endregion

		private string AppPath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
		private string CachePath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName)+@"\zefcache\";
		private cfhtmlpages HTMLPAGER =new cfhtmlpages();
		private XmlNode Moduls;
		private System.Xml.XmlDocument INFO=new XmlDocument();
		private string selectedBiblePath=null;
		private bool ViewIsSplitted=false;
		frdownloader frDown =null;
		private string ChapterNumber="1";
		private string BookNumber="1";

		private OpenNETCF.Windows.Forms.ComboBoxEx cbBibles=new OpenNETCF.Windows.Forms.ComboBoxEx();
		private OpenNETCF.Windows.Forms.ComboBoxEx cbBibleGroup=new OpenNETCF.Windows.Forms.ComboBoxEx();
		private OpenNETCF.Windows.Forms.ButtonEx   cbBibleRefresh=new OpenNETCF.Windows.Forms.ButtonEx();

	
		
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
				
				cbBibles.SelectedIndexChanged+=new EventHandler(cbBibles_SelectedIndexChanged);
				cbBibleGroup.SelectedIndexChanged+=new EventHandler(cbBibleGroup_SelectedIndexChanged);
				cbBibleRefresh.Click+=new EventHandler(cbBibleRefresh_Click);
			
				Directory.CreateDirectory(AppPath+@"\zefcache");
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		}
		public void ChangeBibleGroup(string group)
		{
			try
			{   
				
				this.cbBibles.Items.Clear();
				XmlDocument Config=new XmlDocument();
				if(File.Exists(AppPath+@"\config.xml"))
				{
					Config.Load(AppPath+@"\config.xml");
					Moduls=Config.DocumentElement;
					foreach(XmlNode m in Moduls.ChildNodes)
					{
						if(m.Attributes.GetNamedItem("group").Value==group)
						{
							this.cbBibles.Items.Add(m.Attributes.GetNamedItem("name").InnerText);
						}
					}
				}
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		
		
		}
		
		public  void PopulateBiblesCombo()
		{
			try
			{
				this.cbBibleGroup.Items.Clear();
				XmlDocument Config=new XmlDocument();
                
				
				if(File.Exists(AppPath+@"\config.xml"))
				{
					Config.Load(AppPath+@"\config.xml");
					Moduls=Config.DocumentElement;
					foreach(XmlNode m in Moduls.ChildNodes)
					{
						XmlNode G=m.Attributes.GetNamedItem("group");
						if(G!=null)
						{
							this.cbBibleGroup.Items.Add(G.Value.ToString());
						}
					}
					 
				}

				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
			
		}
		private void SplittView(bool isSplitted)
		{
		  
			try
			{
			  
				if(isSplitted)
				{
					
					panelmain.Width=tabPageBibel.ClientSize.Width-5;
					paneldict.Height=70;
					webBrowserBible.Height=panelmain.Height-paneldict.Height;
					paneldict.Location=new Point(paneldict.Location.X,panelmain.Height-69);
					paneldict.Width=panelmain.Width;
				}
				else
				{
					
					panelmain.Width=tabPageBibel.ClientSize.Width-5;
					paneldict.Height=0;
					paneldict.Width=panelmain.Width;
					webBrowserBible.Height=panelmain.Height;
					webBrowserBible.Width=panelmain.Width;
				
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		
		}

		private void SelectBiblePath()
		{

			try
			{
			    
				string MD5Dir=null;

				foreach(XmlNode m in Moduls.ChildNodes)
				{
					if(m.Attributes.GetNamedItem("name").InnerText==cbBibles.SelectedItem.ToString())
					{
					  
						MD5Dir=m.InnerText;
						MD5Dir.Replace(@"\","");
										
					}
				}	
                
				
				this.selectedBiblePath=AppPath+@"\zefcache\"+MD5Dir;
				this.INFO.Load(selectedBiblePath+@"\info.xml");
				HTMLPAGER.CachePathForModul=selectedBiblePath;
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		
		}



		private void SetOnFirstBookAndChapter()
		{   
			bool found=false;
			try
			{
				XmlNodeList GROUPS=this.INFO.GetElementsByTagName("group");

				foreach(XmlNode group in GROUPS)
				{
				  
					foreach(XmlNode item in group.ChildNodes)
					{
						    
						this.BookNumber=item.Attributes.GetNamedItem("bn").InnerText;
						if(BookNumber=="10"){BookNumber="1";};
						this.ChapterNumber=item.Attributes.GetNamedItem("cn").InnerText;
						this.SetActiveChapter(BookNumber,ChapterNumber);
						found=true;
						break;
					}
					if(found){break;}
				}
			}
		
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		}
		
		
		private void ShowActivChapter()
		{
			bool activChapterFound=false;
			

			try
			{
				XmlNodeList GROUPS=this.INFO.GetElementsByTagName("group");

				foreach(XmlNode group in GROUPS)
				{
				  
					foreach(XmlNode item in group.ChildNodes)
					{
						
						if(item.Attributes.GetNamedItem("active").InnerText=="True")
						{
							
							activChapterFound=true;
							this.BookNumber=item.Attributes.GetNamedItem("bn").InnerText;
							this.ChapterNumber=item.Attributes.GetNamedItem("cn").InnerText;
							break;
						}
					}

					if(activChapterFound){break;}
				}

				
                 
				webBrowserBible.DocumentText=HTMLPAGER.GetChapterAsHtmlTable(BookNumber,ChapterNumber); 
			  
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Zefania PPC");
			}
		}
		
		
		
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			ViewIsSplitted=!ViewIsSplitted;
			SplittView(ViewIsSplitted);
		}

		
		

		

		

		private void menuItem5_Click_1(object sender, System.EventArgs e)
		{
			ViewIsSplitted=!ViewIsSplitted;
			
			AddBibleSelector();

			SplittView(ViewIsSplitted);


		}
		private void AddBibleSelector(){
			try{
			
				paneldict.Controls.Clear();
				
				paneldict.Controls.Add(this.cbBibles);
				cbBibles.Left=10;cbBibles.Top=10;
				cbBibles.Width=paneldict.Width-20;
				paneldict.Controls.Add(this.cbBibleGroup);
                cbBibleGroup.Left=10;cbBibleGroup.Top=40;
				paneldict.Controls.Add(this.cbBibleRefresh);
				this.cbBibleRefresh.Text="R";
				this.cbBibleRefresh.Left=cbBibleGroup.Width+20;cbBibleRefresh.Top=40;

			
			}
		
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				
			}
		}

		private bool unSetActiveChapter(string bn,string cn)
		{
			try
			{
				string cnn=null;
				string bnn=null;
				XmlNodeList GROUPS=this.INFO.GetElementsByTagName("group");

				foreach(XmlNode group in GROUPS)
				{
					
					
					foreach(XmlNode item in group.ChildNodes)
					{
						bnn=item.Attributes.GetNamedItem("bn").InnerText;
						cnn=item.Attributes.GetNamedItem("cn").InnerText;

						if((bn==bnn)&(cn==cnn))
						{
							item.Attributes.GetNamedItem("active").InnerText="False";
							//INFO.Save(selectedBiblePath+@"\info.xml");
							return true;
							
						}
					}		
				
				}

				return false;

			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		
		}

		private bool SetActiveChapter(string bn,string cn)
		{
			try
			{
				string cnn=null;
				string bnn=null;
				XmlNodeList GROUPS=this.INFO.GetElementsByTagName("group");

				foreach(XmlNode group in GROUPS)
				{
					
					
					foreach(XmlNode item in group.ChildNodes)
					{
						bnn=item.Attributes.GetNamedItem("bn").InnerText;
						cnn=item.Attributes.GetNamedItem("cn").InnerText;

						if((bn==bnn)&(cn==cnn))
						{
							item.Attributes.GetNamedItem("active").InnerText="True";
							//INFO.Save(selectedBiblePath+@"\info.xml");
							return true;
							
						}
					}		
				
				}

				return false;

			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		
		}

		private void MoveToNextChapter()
		{
			try
			{
			
               
			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void cbBibles_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectBiblePath();
			SetOnFirstBookAndChapter();
			this.ShowActivChapter();
			INFO.Save(selectedBiblePath+@"\info.xml");
		}

		private void cbBibleGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ChangeBibleGroup(cbBibleGroup.SelectedItem.ToString());
		}

		

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			try
			{   
				
				if(frDown==null)
				{
					frDown=new frdownloader();
					frDown.Text=Text+"(DL)";
					frDown.DataDirectory=AppPath;
				}
				
				frDown.Show();
			}

			catch(Exception ex)
			{
				frDown=null;
			}

		}

		private void buttonNextChapter_Click(object sender, System.EventArgs e)
		{
			unSetActiveChapter(BookNumber,ChapterNumber);
			int nc=Convert.ToInt16(ChapterNumber)+1;
			ChapterNumber=nc.ToString();
			if(SetActiveChapter(BookNumber,ChapterNumber))
			{
				ShowActivChapter();
			}
			else
			{
				// Buchende erreicht;
			
			}
		}

		private void buttonPrevChapter_Click(object sender, System.EventArgs e)
		{
			unSetActiveChapter(BookNumber,ChapterNumber);
			int nc=Convert.ToInt16(ChapterNumber)-1;
			if (nc==0){nc=1;};
			ChapterNumber=nc.ToString();
			if(SetActiveChapter(BookNumber,ChapterNumber))
			{
				ShowActivChapter();
			}
			else
			{
				// Buchanfang erreicht;
			
			}
		}

		private void cbBibleRefresh_Click(object sender, EventArgs e)
		{
                  this.PopulateBiblesCombo();
		}

		private void buttonnextBook_Click(object sender, System.EventArgs e)
		{
		    unSetActiveChapter(BookNumber,ChapterNumber);
			int nc=Convert.ToInt16(BookNumber)+1;
			BookNumber=nc.ToString();
			ChapterNumber="1";
			if(SetActiveChapter(BookNumber,ChapterNumber))
			{
				ShowActivChapter();
			}
			else
			{
				// Buchanfang erreicht;
			
			}

		}

		private void buttonprevBook_Click(object sender, System.EventArgs e)
		{
			unSetActiveChapter(BookNumber,ChapterNumber);
			int nc=Convert.ToInt16(BookNumber)-1;
			if (nc==0){nc=1;};
			BookNumber=nc.ToString();
			ChapterNumber="1";
			if(SetActiveChapter(BookNumber,ChapterNumber))
			{
				ShowActivChapter();
			}
			else
			{
				// Buchanfang erreicht;
			
			}
		}
	}
	
}

