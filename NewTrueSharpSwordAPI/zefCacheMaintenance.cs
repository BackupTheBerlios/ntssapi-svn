using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Threading;
using System.Collections.Specialized;

using NewTrueSharpSwordAPI.Utilities;

namespace NewTrueSharpSwordAPI.Cache
{
    /// <summary>
    /// zefCacheMaintenance ver waltet, erstellt und liefert Informationen über den Zefania XML 
    /// ModulCache.
    /// </summary>
    [Serializable]
    public class zefCacheMaintenance
    {/// <summary>
        ///  Fortschrittsevent für die Cacheerstellung
        /// </summary>
        public delegate void OnCachedEventHandler(object sender, EventArgs e, string message);
        /// <summary>
        ///  Fortschrittsevent für die Cacheerstellung
        /// </summary>
        [field: NonSerialized]
        public event OnCachedEventHandler OnCacheProgress;
        /// <summary>
        /// Event, wenn ein Cache erstellt wurde.
        /// </summary>
        [field: NonSerialized]
        public event OnCachedEventHandler OnCacheFinished;
        /// <summary>
        /// Event, wenn versucht wurde ein non Zefania file zu cachen
        /// </summary>
        [field: NonSerialized]
        public event OnCachedEventHandler OnInvalidFormat;

        [field: NonSerialized]
        public event OnCachedEventHandler OnBuildListsProgress;


        /// <summary>
        /// Eingangsverzeichnis für Zefania XML Module
        /// </summary>
        private string FModulInputDirectory;
        /// <summary>
        /// Speicherort für  erstellte ModulCaches
        /// </summary>
        private string FCacheDir;
        /// <summary>
        /// Konstruktor
        /// </summary>
        public zefCacheMaintenance()
        {
            //
            // TODO: Fügen Sie hier die Konstruktorlogik hinzu
            //
        }

        /// <summary>
        /// Eingangsverzeichnis für Zefania XML Bibelmodule.
        /// </summary>
        public string ModulInputDirectory
        {
            get
            {
                return FModulInputDirectory;
            }
            set
            {
                FModulInputDirectory = value;
            }
        }

        /// <summary>
        /// CacheVerzeichnis der Zefania XML Bibelmodule.
        /// </summary>
        public string CacheDirectorie
        {
            get
            {
                return FCacheDir;
            }
            set
            {
                FCacheDir = value;
            }
        }

        // Cache erzeugen mit Threads

        private class CacheFetchBooks
        {
            ZefaniaCache my_cache;
            bool my_zipped;

            public CacheFetchBooks(ZefaniaCache cache, bool zipped)
            {
                my_cache = cache;
                my_zipped = zipped;
            }

            public void Fetch()
            {
                my_cache.CreateCacheBooks(my_zipped);
            }
        }

        private class CacheFetchChapters
        {
            ZefaniaCache my_cache;
            bool my_zipped;

            public CacheFetchChapters(ZefaniaCache cache, bool zipped)
            {
                my_cache = cache;
                my_zipped = zipped;
            }

            public void Fetch()
            {
                my_cache.CreateCacheChapters(my_zipped);

            }
        }

        /// <summary>
        /// Diese Methode erstelle mit Hilfe der <see cref="ZefaniaCache"/> Klasse das Cachverzeichnis für das Modul.
        /// </summary>
        /// <param name="ModulPath">Der Pfad zum Zefania XML Bibelmodul</param>
        /// <param name="ID">Integerkennzeichnung für die Instanz der <see cref="ZefaniaCache"/>Klasse </param>
        /// <param name="zipped">Wenn true, besteht der Cache aus zipped Files</param>
        /// <param name="chapters">Wenn true ist der Cache vom Type x-chapters, sonst x-books</param>
        public void CreateCacheFromModul(string ModulPath, int ID, bool zipped, bool chapters)
        {
            try
            {

                ZefaniaCache SingleCache = new ZefaniaCache(ModulPath);
                SingleCache.OnSplitted += new NewTrueSharpSwordAPI.Cache.ZefaniaCache.OnSplittedEventHandler(SingleCache_OnSplitted);
                SingleCache.OnCachedSuccess += new NewTrueSharpSwordAPI.Cache.ZefaniaCache.OnCachedEventHandler(SingleCache_OnCachedSuccess);
                SingleCache.OnInvalidFileFormat += new NewTrueSharpSwordAPI.Cache.ZefaniaCache.OnInvalidFileFormatEventHandler(SingleCache_OnInvalidFileFormat);
                SingleCache.BaseCacheDir = this.FCacheDir;
                SingleCache.Tag = ID;

                if (chapters)
                {
                    CacheFetchChapters fetcher = new CacheFetchChapters(SingleCache, zipped);
                    new Thread(new ThreadStart(fetcher.Fetch)).Start();
                }
                else
                {
                    CacheFetchBooks fetcher = new CacheFetchBooks(SingleCache, zipped);
                    new Thread(new ThreadStart(fetcher.Fetch)).Start();
                }
            }
            catch (Exception e)
            {

            }
        }

        private void SingleCache_OnSplitted(object sender, EventArgs e, ArrayList message)
        {
            //
            EventArgs e1 = new EventArgs();

            if (OnCacheProgress != null)
            {
                OnCacheProgress(sender, e, message[0].ToString());
            }
        }

        private void SingleCache_OnCachedSuccess(object sender, EventArgs e, ArrayList message)
        {
            //
            EventArgs e1 = new EventArgs();



            if (OnCacheFinished != null)
            {
                OnCacheFinished(sender, e, message[0].ToString());
            }
        }
        private void SingleCache_OnInvalidFileFormat(object sender, EventArgs e)
        {
            EventArgs e1 = new EventArgs();

            if (OnInvalidFormat != null)
            {
                OnInvalidFormat(this, e1, "");
            }
        }

        // ende Cache erzeugen mit Thread;








        /// <summary>
        /// Gibt die Versionsnummer der zefCacheMaintenance-Klasse zurück.
        /// </summary>
        public string CacheVersion
        {
            get
            {
                Version v = new Version("0.0.0.18");
                return v.Major + "." + v.Minor + "." + v.Revision + "." + v.Build;
            }
        }



    }
}
