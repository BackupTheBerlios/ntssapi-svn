using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

using NewTrueSharpSwordAPICF;
using NewTrueSharpSwordAPI.Cache;
using ICSharpCode.SharpZipLib.Zip;


namespace zefPocket
{
	/// <summary>
	/// Zusammenfassung für Form1.
	/// </summary>
	public class frmmain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel2;
		private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private OpenNETCF.Windows.Forms.WebBrowser webBrowser1;
		private OpenNETCF.Windows.Forms.ComboBoxEx comboBoxBibles;
		private OpenNETCF.Windows.Forms.ButtonEx buttonEx1;
		private OpenNETCF.Windows.Forms.TextBoxEx textBoxEx1;
		private OpenNETCF.Windows.Forms.TextBoxEx textBoxEx2;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.textBoxEx2 = new OpenNETCF.Windows.Forms.TextBoxEx();
			this.textBoxEx1 = new OpenNETCF.Windows.Forms.TextBoxEx();
			this.buttonEx1 = new OpenNETCF.Windows.Forms.ButtonEx();
			this.comboBoxBibles = new OpenNETCF.Windows.Forms.ComboBoxEx();
			this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.webBrowser1 = new OpenNETCF.Windows.Forms.WebBrowser();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			this.mainMenu1.MenuItems.Add(this.menuItem2);
			// 
			// menuItem1
			// 
			this.menuItem1.MenuItems.Add(this.menuItem4);
			this.menuItem1.MenuItems.Add(this.menuItem3);
			this.menuItem1.Text = "View";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.MenuItems.Add(this.menuItem5);
			this.menuItem4.Text = "Installieren";
			// 
			// menuItem5
			// 
			this.menuItem5.Text = "Bibelmodul(e)";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Text = "Exit";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Text = "";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.RosyBrown;
			this.panel2.Controls.Add(this.textBoxEx2);
			this.panel2.Controls.Add(this.textBoxEx1);
			this.panel2.Controls.Add(this.buttonEx1);
			this.panel2.Controls.Add(this.comboBoxBibles);
			this.panel2.Size = new System.Drawing.Size(240, 30);
			// 
			// textBoxEx2
			// 
			this.textBoxEx2.Location = new System.Drawing.Point(152, 4);
			this.textBoxEx2.Size = new System.Drawing.Size(24, 20);
			this.textBoxEx2.Style = OpenNETCF.Windows.Forms.TextBoxStyle.Default;
			this.textBoxEx2.Text = "";
			// 
			// textBoxEx1
			// 
			this.textBoxEx1.Location = new System.Drawing.Point(120, 4);
			this.textBoxEx1.Size = new System.Drawing.Size(24, 20);
			this.textBoxEx1.Style = OpenNETCF.Windows.Forms.TextBoxStyle.Default;
			this.textBoxEx1.Text = "";
			// 
			// buttonEx1
			// 
			this.buttonEx1.Location = new System.Drawing.Point(192, 4);
			this.buttonEx1.Size = new System.Drawing.Size(40, 20);
			this.buttonEx1.Text = "go!";
			this.buttonEx1.TextAlign = OpenNETCF.Drawing.ContentAlignment.MiddleCenter;
			this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
			// 
			// comboBoxBibles
			// 
			this.comboBoxBibles.Location = new System.Drawing.Point(4, 4);
			this.comboBoxBibles.Size = new System.Drawing.Size(108, 21);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Location = new System.Drawing.Point(0, 32);
			this.panel1.Size = new System.Drawing.Size(240, 240);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(240, 240);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.webBrowser1);
			this.tabPage1.Location = new System.Drawing.Point(4, 4);
			this.tabPage1.Size = new System.Drawing.Size(232, 214);
			this.tabPage1.Text = "Bibel";
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(8, 8);
			this.webBrowser1.Size = new System.Drawing.Size(216, 200);
			this.webBrowser1.Text = "webBrowser1";
			this.webBrowser1.Url = null;
			// 
			// frmmain
			// 
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Menu = this.mainMenu1;
			this.Text = "Zefania PPC";
			this.Load += new System.EventHandler(this.frmmain_Load);

		}
		#endregion

		private string AppPath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
		private string CachePath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName)+@"\zefcache\";
		private cfhtmlpages HTMLPAGER =new cfhtmlpages();
		
        private XmlNode Moduls;
		
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

		private void LoadBibleChapterToScreen(string BookNumber,string ChapterNumber)
		{

			try
			{
			    
				string MD5Dir=null;

				foreach(XmlNode m in Moduls.ChildNodes)
				{
					if(m.Attributes.GetNamedItem("name").InnerText==comboBoxBibles.SelectedItem.ToString())
					{
					  
						MD5Dir=m.InnerText;
						MD5Dir.Replace(@"\","");
										
					}
				}	

				HTMLPAGER.CachePathForModul=AppPath+@"\zefcache\"+MD5Dir;
				webBrowser1.DocumentText=HTMLPAGER.GetChapterAsFlowText(BookNumber,ChapterNumber);
				
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
			LoadBibleChapterToScreen(textBoxEx1.Text,textBoxEx2.Text);
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
		/// <summary>
		///  PPC-Bibelmodule im Programmverzeichnis suchen und an InstallBibleModul übergeben.
		/// </summary>
		private void SearchAndInstallPPCModuls()
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
               
						streamWriter.Close();
						
						
					}
				}// end while

				// im realen Gerät würde man das PPC-Modulzip jetzt aus Platzgründen löschen
				//File.Delete(modulzip);

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
					PopulateBiblesCombo();
				}


				s.Close();
			}
																		   
			catch(Exception ex)
			{
		
			}
		
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			try
			{   
				SearchAndInstallPPCModuls();
			}

			catch(Exception ex)
			{
		
			}

		}

	}
}

