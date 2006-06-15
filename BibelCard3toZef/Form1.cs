using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;

using TrueSharpSwordAPI;

namespace BibelCard3toZef
{
	/// <summary>
	/// Zusammenfassung für Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;

		private TrueSharpSwordAPI.ZefBibleBuilder Bibel=new ZefBibleBuilder("snames.xml");
		private DataSet DS=new DataSet();
		
		private int CountVerse=0;
		

		public Form1()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(16, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.InitialDirectory = ".";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.RosyBrown;
			this.ClientSize = new System.Drawing.Size(178, 42);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.Text = "BibelCard 3.0 to Zefania XML";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog()==DialogResult.OK){
			   
               button1.Enabled=false;
			   Bibel.CommonVpl2Zef(openFileDialog1.FileName,DS);
			   InfoUndSave();
               CountVerse=0;
			   button1.Text="Fertig!";
			   button1.Enabled=true;
			  
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{  
		 DS.ReadXml("hfa3.xml");
         this.Bibel.OnVersesAdded+=new TrueSharpSwordAPI.ZefBibleBuilder.OnVersesAddedEventHandler(Bibel_OnVersesAdded);
		 
		}

		private void Bibel_OnVersesAdded(object sender, EventArgs e, System.Xml.XmlNode verses)
		{
			CountVerse++;
			button1.Text="Vers "+CountVerse.ToString();
            
			Application.DoEvents();
		}
        
		private void InfoUndSave(){
		
		    Bibel.SetAttributeOnXMLBIBLE(attXmlBible.biblename,"Hoffnung für Alle BC3");
			Bibel.SetAttributeOnXMLBIBLE(attXmlBible.revision,"0");
			Bibel.SetAttributeOnXMLBIBLE(attXmlBible.status,"v");
			Bibel.SetAttributeOnXMLBIBLE(attXmlBible.type,"x-bible");


			Bibel.SetDublinCore(dublinCore.title,"Hoffnung für Alle BC3");
 		    Bibel.SetDublinCore(dublinCore.identifier,"hfabc3");
			Bibel.SetDublinCore(dublinCore.language,"GER");
			Bibel.SetDublinCore(dublinCore.format,"Zefania XML Bible Markup Language");
			Bibel.SetDublinCore(dublinCore.creator,"BibelCard3toZef.exe");
			Bibel.SetDublinCore(dublinCore.source,"BibelCard 3.0");
            string Datum= DateTime.Now.Year.ToString()+"-"+DateTime.Now.Month.ToString()+"-"+DateTime.Now.Day.ToString();
			Bibel.SetDublinCore(dublinCore.date,Datum);
			Bibel.SaveBible("hfaBC3.xml");
		}
		
	}
}
