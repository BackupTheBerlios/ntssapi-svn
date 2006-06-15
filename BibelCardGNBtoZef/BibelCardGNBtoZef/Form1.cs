using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.IO;

using TrueSharpSwordAPI;

namespace BibelCardGNBtoZef
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
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private TrueSharpSwordAPI.ZefBibleBuilder Bibel = new ZefBibleBuilder("snames.xml");
     

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
            this.btStart = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.btStart.BackColor = System.Drawing.SystemColors.Control;
            this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStart.Location = new System.Drawing.Point(16, 8);
            this.btStart.Name = "button1";
            this.btStart.Size = new System.Drawing.Size(144, 24);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = ".";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(188, 42);
            this.Controls.Add(this.btStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "BibelCard GNB to Zefania XML";
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
            string[] lw = Environment.GetLogicalDrives();
            
            foreach (string dr in lw) {

                if (File.Exists(dr + @"\bibel\at\B001K001.htm")) {
                    
                    btStart.Enabled = false;
                    
                    Bibel.AufbruchInsLebenToZef(dr+@"\bibel");
                    InfoUndSave();
                    CountVerse = 0;
                    btStart.Text = "Fertig!";
                    btStart.Enabled = true;
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
            btStart.Text = "Vers " + CountVerse.ToString();
          
            Application.DoEvents();
        }

        private void InfoUndSave()
        {

            string Datum = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            Bibel.SetDublinCore(dublinCore.date, Datum);
            string BibelText = Bibel.FXmlBible.DocumentElement.OuterXml;
            BibelText=BibelText.Replace("&lt;", "<");
            BibelText=BibelText.Replace("&gt;", ">");
            
            Bibel.FXmlBible.LoadXml(BibelText);
            
            Bibel.SaveBible(Path.GetDirectoryName(Application.ExecutablePath) + @"\gnbbc.xml");
        }

    }
}
