using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.IO;

using TrueSharpSwordAPI;

namespace BibelCardEUEtoZef
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

        private TrueSharpSwordAPI.ZefBibleBuilder Bibel = new ZefBibleBuilder("snames.xml");
        private String PatheToSnames = Path.GetDirectoryName(Application.ExecutablePath) + @"\sc_eue.xml";

      

        private int CountVerse = 0;


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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
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
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = ".";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(178, 42);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "BibelCard EÜ to Zefania XML";
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

            String[] Drives = Environment.GetLogicalDrives();
            foreach( string lw in Drives){
               if(File.Exists(lw+@"\at\AMOS001.htm")){
                 button1.Enabled = false;
                 Bibel.SC_EUEToZef(lw, this.PatheToSnames);
                 InfoUndSave();
                 CountVerse = 0;
                 button1.Text = "Fertig!";
                 button1.Enabled = true;
                 break;
               }            
            
            }         
            
        }

       

        private void Form1_Load(object sender, System.EventArgs e)
        {

            
            this.Bibel.OnVersesAdded += new TrueSharpSwordAPI.ZefBibleBuilder.OnVersesAddedEventHandler(Bibel_OnVersesAdded);

        }

        private void Bibel_OnVersesAdded(object sender, EventArgs e, System.Xml.XmlNode verses)
        {
            CountVerse++;
            button1.Text = "Vers " + CountVerse.ToString();
            Application.DoEvents();
        }

        private void InfoUndSave()
        {
            string Datum = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            Bibel.SetDublinCore(dublinCore.date, Datum);
            Bibel.SaveBible(Path.GetDirectoryName(Application.ExecutablePath) + @"\bceue.xml");
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

    }
}
