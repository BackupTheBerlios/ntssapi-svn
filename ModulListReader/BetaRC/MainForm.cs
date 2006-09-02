using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using ICSharpCode.SharpZipLib.Zip;



namespace ModulDownloader
{
    public partial class MainForm : Form
    {

        private bool updateChecked = false;
        private int UpdateVersion = 108;
        private const string myVersion = "Beta 0.8";
        

        public MainForm()
        {
            Application.EnableVisualStyles();


            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          CheckMyBible();
          Text = "Zefania XML Downloader: " + myVersion;
          
        
         
        }

       

       

        
       


  

        private void CheckMyBible()
        {
            if (GetMyBibleModulesDirectory() != string.Empty)
            {

                this.StatusLabel1.Text = "MyBible";
               

            }
        }       

     

        private string GetModulNameFromZippedModul(string ModulPath)
        {

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
        public void ReadWriteStream(Stream readStream, Stream writeStream)
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
            

        } 
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
        private string GetMyBibleModulesDirectory()
        {

            try
            {

                string MyBibleMDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MyBible\Modules\";
                if (Directory.Exists(MyBibleMDir))
                {

                    return MyBibleMDir;

                }

                MyBibleMDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\MyBible\Modules\";
                if (Directory.Exists(MyBibleMDir))
                {

                    return MyBibleMDir;

                }
                else
                {

                    return "";

                }
            }


            catch (Exception e)
            {

                return "";

            }

        }

        private void StatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Programme\MyBible\MyBible.exe");
        }

        private void lBoxListServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                lBoxListServer.Items.Remove(lBoxListServer.SelectedItem);

            }

        }

        private void tBoxAddListServer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (!lBoxListServer.Items.Contains(tBoxAddListServer.Text))
                    {

                        lBoxListServer.Items.Add(tBoxAddListServer.Text);
                       
                        tBoxAddListServer.Clear();
                    }
                }
            }
            catch (Exception ew)
            {
                lBoxListServer.Items.Remove(tBoxAddListServer.Text);
                MessageBox.Show(ew.Message);
            }
        }

        

    



    }


}

