using System;

using System.Collections;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Specialized;
using ICSharpCode.SharpZipLib.Zip;
using System.Security.Cryptography;

namespace NewTrueSharpSwordAPI.Utilities
{
	/// <summary>
	/// zefUtilities enthäl t Methoden, die allgemein in den verschiedenen Klassen der API verwendbar sind.
	/// </summary>
	// versiegelt, um Ableitung zu verbieten
	sealed class zefUtilities
	{
		// verbietet Instanzierung
		private zefUtilities(){}


		
		/// <summary>
		/// Diese Methode berechnet aus dem Zefania XML Bibelmodul einen MD5-Hashwert, der als Verzeichnisname
		/// für das in Bibelbücher(Kapitel) zerlegte Zefania XML Bibelmodul dient.
		/// </summary>
		/// <returns>
		///   MD5-Hashwert des Zefania XML Bibelmoduls.
		/// </returns>
		public static string CreateMD5Dir(Stream fs)
		{
			//FileStream fs = File.Open(Path);

			try
			{
				MD5CryptoServiceProvider cryptHandler;
				cryptHandler = new MD5CryptoServiceProvider();
				byte[] hash = cryptHandler.ComputeHash(fs);
				string ret = "";
				foreach (byte a in hash) 
				{
					if (a<16)
						ret += "0" + a.ToString ("x");
					else
						ret += a.ToString ("x");
				}
				return ret ;
			}
			catch(Exception e)
			{
				return e.Message;
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
				while ((theEntry=s.GetNextEntry())!= null) 
				{
					if(theEntry.Size>10000 & (Path.GetExtension(theEntry.Name)==".xml"))
					{
						
						return s;
					}	
				}
				return null;
			}

			catch(Exception e)
			{
				return null;
			}
		}

        
		// begin find files

		/* Delegate für eine Fortschrittsmeldung */

		public delegate void FindProgress(string folderName);

		/* Methode zum Suchen von Dateien in einem Ordner */
		private static StringCollection FindFiles(string folderName,
			string searchPattern, bool recurse, FindProgress findProgress)
		{
			// StringCollection-Objekt für die Rückgabe erzeugen
			StringCollection resultFiles =  new StringCollection();

			// DirectoryInfo-Objekt für den Ordner erzeugen
			DirectoryInfo folder = new DirectoryInfo(folderName);

			// Die rekursive Methode zum Suchen in einem Ordner aufrufen
			FindFilesInFolder(searchPattern, folder, recurse, resultFiles, 
				findProgress);

			// StringCollection zurückgeben
			return resultFiles;
		}

		/* Rekursive Methode zum Suchen von Dateien */
		public static void FindFilesInFolder(string searchPattern, 
			DirectoryInfo folder, bool recurse, StringCollection resultFiles,
			FindProgress findProgress)
		{
			// Delegate aufrufen, falls dieser übergeben wurde
			if (findProgress != null)
				findProgress(folder.FullName); 

			// Zunächst für alle Unterordner FindFilesInFolder rekursiv aufrufen, 
			// wenn dies gewünscht ist
			if (recurse)
			{
				DirectoryInfo[] subFolders = folder.GetDirectories();
				for (int i = 0; i < subFolders.Length; i++)
					FindFilesInFolder(searchPattern, subFolders[i], true, resultFiles,
						findProgress);
			}

			// Alle Dateien ermitteln, die dem übergebenen Suchmuster entsprechen 
			FileInfo[] files = folder.GetFiles(searchPattern);

			// Die gefundenen Dateien durchgehen und deren vollen Namen an die
			// StringCollection anhängen
			for (int i = 0; i < files.Length; i++)
				resultFiles.Add(files[i].FullName);
		}

		// end find files
		
		// readStream is the stream you need to read
		// writeStream is the stream you want to write to
		public static void ReadWriteStream(Stream readStream, Stream writeStream)
		{
			int Length = 256;
			Byte [] buffer = new Byte[Length];
			int bytesRead = readStream.Read(buffer,0,Length);
			// write the required bytes
			while( bytesRead > 0 )
			{
				writeStream.Write(buffer,0,bytesRead);
				bytesRead = readStream.Read(buffer,0,Length);
			}
			readStream.Close();
			writeStream.Close();
		}

	}
}
