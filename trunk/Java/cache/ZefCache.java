package cache;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FilenameFilter;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import java.util.zip.ZipOutputStream;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import org.w3c.dom.Attr;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Text;

/**
 * Die Klasse ZefCache stellt Methoden zur Erstellung eines
 * Cache f�r Zefania XML Bibelmodule zur Verf�gung.
 * @author Michael Leimer
 * @version 1.0
 */
public class ZefCache {
    /** Versionsinfo */
    private static final String VERSIONINFO = "0.1.0.17";
    /** Dateiname f�r die Cache-Informationsdatei */
    private static final String INFOFILENAME = "info.xml";
    
    /** Variable zu Zwischenspeicherung des Inhaltsbaumes */
    private Document ContentTree=null;
    /** Feld ist true, wenn Datei als Zefania XML Module erkannt wird. */
    private boolean IsZefaniaFormat=false;
    /** Feld ist true wenn Usertree existiert */
    private boolean UserDefTree=false;
    /** Feld f�r Bibelname */
    private String BibleName="";
    /** Cache ist gezipped */
    private boolean Zipped=false;
    /** Signalisiert, ob der Cache f�r das Zefania XML Bibelmodul schon erstellt wurde. */
    private boolean Cached=false;
    /**
     * Zeigt, ob Modulcache f�r die aktuelle Instanz schon erstellt wurde.
     */
    public boolean isCached() {
        return Cached;
    }
    /**
     * Zeigt, ob Cache gezipped ist.
     */
    public boolean isZipped() {
        return Zipped;
    }
    /**
     * Gibt den Bibelnamen f�r den Cache zur�ck.
     */
    public String getBibleName() {
        return BibleName;
    }
    /**
     * Gibt true zur�ck, wenn ein User-Inhaltsbaum existiert.
     * @see #restoreUserTree()
     */
    public boolean haveUserTree() {
        return UserDefTree;
    }
    /**
     * Gibt die Versionsnummer der ZefaniaCache-Klasse zur�ck.
     */
    public String CacheVersion() {
        return VERSIONINFO;
    }
    /**
     * Diese Funktion ersetzt den Default Inhaltsbaum durch einen eventuell gesicherten Userdefinierten
     */
    public void restoreUserTree() {
        try {
            if( haveUserTree() ) {
                NodeList ndListTree = ContentTree.getElementsByTagName( "tree" );
                if (ndListTree.getLength()>0) {
                    File infofile = new File(FullCachePath, INFOFILENAME);
                    if(infofile.exists()) {
                        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
                        factory.setValidating(false);
                        factory.setNamespaceAware(false);
                        
                        // API f�r DOM instanziieren
                        DocumentBuilder builder = factory.newDocumentBuilder();
                        // Dokument parsen
                        Document docInfo1 = builder.parse( infofile );
                        
                        // Element "tree" suchen
                        NodeList ndListTree1 = docInfo1.getElementsByTagName( "tree" );
                        if (ndListTree.getLength()>0) {
                            // Element "tree" vorhanden
                            Element ndTree1 = (Element)ndListTree1.item(0);
                            
                            // Aktuellen tree kopieren
                            Element ndTree = (Element)ndListTree.item(0);
                            Element ndListTreeNew = (Element)ndTree.cloneNode(true);
                            
                            // "userdef" auf true setzen
                            ndListTreeNew.setAttribute("userdef", "true"); 
                            
                            // Im eingelesenen File das Element tree durch das aktuelle ersetzen.
                            Element docRoot = docInfo1.getDocumentElement();
                            docRoot.replaceChild(ndListTreeNew, ndTree1);
                            
                            // Ein XSLT-Transformer zum Schreiben der Info-XML-Datei
                            Transformer transformer = TransformerFactory.newInstance().newTransformer();
                            // DOM-Tree des Informationsfiles schreiben
                            FileOutputStream osinfo = new FileOutputStream( infofile );
                            transformer.transform( new DOMSource( docInfo1 ), new StreamResult( osinfo ) );
                            osinfo.close();
                        }
                    }
                }
            }
        }
        catch(Exception e) {
        }
    }

    /** Der komplette Pfad zum ModulCache-Verzeichnis */
    private File FullCachePath;
    /** 
     * Diese Variable enth�lt das Modulverzeichnis f�r das in einzelnen Bibelb�cher zerlegte Zefania XML-Modul.
     * @see #CacheBaseDirectory
     */
    private String ModulCacheDir;
    /**
     * Diese Variable enth�lt das Basisverzeichnis f�r den anzulegenden Cache. <br>
     * Voreinstellung ist das Verzeichnis, das als allgemeines Repository f�r 
     * programmspezifische Daten verwendet wird, die von allen Benutzern verwendet werden.
     * @see #getBaseCacheDir()
     * @see #setBaseCacheDir(File)
     */
    private File CacheBaseDirectory;
    /**
     * Liest das Basisverzeichnis f�r den Cache.
     * @see #CacheBaseDirectory
     * @see #setBaseCacheDir(File)
     */
    public File getBaseCacheDir()	{
        return CacheBaseDirectory;
    }
    /**
     * Setzt das Basisverzeichnis f�r den Cache.
     * @param value Verzeichnis f�r Cache
     * @return true, wenn Verzeichnis erfolgreich gesetzt wurde.
     * @see #CacheBaseDirectory
     * @see #getBaseCacheDir()
     */
    public boolean setBaseCacheDir(File value) {
        if(value.exists()) {
            CacheBaseDirectory=value;
            return true;
        } else {
            CacheBaseDirectory=value;
            return value.mkdirs();
        }
    }
    /** 
     * Die Variable enth�lt den Dateipfad zum Zefania XML Bibelmodul.
     * @see #getPathToModul()
     */
    private File ModulPath;
    /**
     * Liefert den Pfad zum Zefania XML Modul zur�ck.
     * @see #ModulPath
     */
    public File getPathToModul() {
        return ModulPath;
    }
    /**
     * Konstruktor f�r die Klasse. <br>
     * Setzt das Cache-Basisverzeichnis auf das allgemeine Repository 
     * das f�r programmspezifische Daten verwendet wird, 
     * die von allen Benutzern verwendet werden.
     * @param pathToZefaniaModul Dateipfad zu einem Zefania XML Bibelmodul
     * @see #CacheBaseDirectory
     * @see #ModulPath
     */
    public ZefCache(File pathToZefaniaModul)
    {
        // Pfad zum Zefania XML Modul zur weiteren Verwendung sichern.
        ModulPath=pathToZefaniaModul;
        // Basisverzeichnis f�r Cache setzen. user.home
        this.setBaseCacheDir(new File(System.getProperty("user.dir")));
    }
    /**
     * Diese Methode berechnet aus dem Zefania XML Bibelmodul einen MD5-Hashwert, der als Verzeichnisname
     * f�r das in Bibelb�cher(Kapitel) zerlegte Zefania XML Bibelmodul dient.
     * @return MD5-Hashwert des Zefania XML Bibelmoduls.
     * @throws NoSuchAlgorithmException Falls MD5-Algorithmus nicht verf�gbar ist.
     * @throws IOException Falls IO-Fehler beim Zugriff auf das Bibelmodul auftrat.
     */
    private String CreateMD5Dir() throws NoSuchAlgorithmException, IOException {
        // MessageDigest erstellen
        MessageDigest md = MessageDigest.getInstance("MD5");
        FileInputStream in = new FileInputStream(ModulPath);
        int len;
        byte[] data = new byte[1024];
        while ((len = in.read(data)) > 0) {
            // MessageDigest updaten
            md.update(data, 0, len);
        }
        in.close();
        // MessageDigest berechnen und ausgeben
        byte[] result = md.digest();
        String hexdigit = "";
        for (int i = 0; i < result.length; ++i) {
            byte b = result[i];
            int value = (b & 0x7F) + (b < 0 ? 128 : 0);
            String hex = (value < 16 ? "0" : "");
            hex = hex + Integer.toHexString(value);
            hexdigit = hexdigit + hex;
        }
        return hexdigit;
    }
    /**
     * L�scht alle Elemente in einem Verzeichnis (rekursives L�schen)
     * @param path Verzeichnispfad, der "geleert" werden soll.
     * @param removeRootPath Wenn true, wird das �bergebene Rootverzeichnis auch gel�scht.
     */
    private static void deleteTree( File path, boolean removeRootPath )
    {
        File files[] = path.listFiles();
        for ( int i = 0; i < files.length; i++ )
        {
            if ( files[i].isDirectory() )
                deleteTree( files[i], removeRootPath );
            files[i].delete();
        }
        if (removeRootPath) {
            path.delete();
        }
    }
    /**
     * Diese Methode erstellt den Cache f�r das Zefania XML Bibelmodul; Das Modul wird in einzelne Bibelb�cher zerlegt. <br>
     * Zerlegt ein Zefania XML Bibelmodul in einzelne Bibelb�cher; Sollte der Cache schon existieren wird er zuerst gel�scht.
     * @param zippedCache Wenn true, werden die Bibelb�cher gezipped.
     */
    public void createCacheBooks(boolean zippedCache) {
        createCacheBooksIntern(zippedCache, false);
    }
    /**
     * Diese Methode erstellt den Cache f�r das Zefania XML Bibelmodul; Das Modul wird in einzelne Kapitel zerlegt. <br>
     * Zerlegt ein Zefania XML Bibelmodul in einzelne Bibelkapitel; Sollte der Cache schon existieren wird er zuerst gel�scht.
     * @param zippedCache Wenn true, werden die Bibelkapitel gezipped.
     */
    public void createCacheChapters(boolean zippedCache) {
        createCacheBooksIntern(zippedCache, true);
    }
    /**
     * Diese Methode erstellt den Cache f�r das Zefania XML Bibelmodul; Das Modul wird in einzelne B�cher bzw. Kapitel zerlegt. <br>
     * Zerlegt ein Zefania XML Bibelmodul in einzelne Bibelb�cher/kapitel; Sollte der Cache schon existieren wird er zuerst gel�scht.
     * @param zippedCache Wenn true, werden die Bibelkapitel gezipped.
     * @param chapterCache Wenn true, wird das Bibelmodul in einzelne Kapitel zerlegt.
     */
    private void createCacheBooksIntern(boolean zippedCache, boolean chapterCache) {
        try {
            Zipped=zippedCache;
            
            ArrayList List=new ArrayList();
            ModulCacheDir=CreateMD5Dir();
            
            File f = new File(CacheBaseDirectory, "zefcache");
            FullCachePath=new File (f, ModulCacheDir);
            
            // eventuell schon vorhandenen Inhaltsbaum sichern
            UserDefTree=catchUserTree();
            
            if(FullCachePath.exists())
            {
                deleteTree(FullCachePath, false);
            } else {
                FullCachePath.mkdirs();
            }
            
            // Factory f�r DOM-Parser holen
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            factory.setValidating(false);
            factory.setNamespaceAware(false);
            
            // API f�r DOM instanziieren
            DocumentBuilder builder = factory.newDocumentBuilder();
            // Dokument parsen
            Document document = builder.parse( ModulPath );
            
            IsZefaniaFormat=true;
            
            // Rootnode des gelesenen Bibelmoduls
            // FIXME Element rootnode = document.getDocumentElement();
            NodeList ndListXmlbible = document.getElementsByTagName( "XMLBIBLE" );
            Node ndXmlbible = ndListXmlbible.item(0);
            
            // Variablen f�r Gebrauch in der Schleife
            String bnumber;
            String cnumber="";
            // Ein XSLT-Transformer zum Schreiben der XML-Dateien
            Transformer transformer = TransformerFactory.newInstance().newTransformer();
            
            // Liste aller Bibelb�cher-Nodes durchgehen
            NodeList ndListBiblebook = document.getElementsByTagName( "BIBLEBOOK" );
            for( int i=0; i<ndListBiblebook.getLength(); i++ ) {
                Node ndBiblebook = ndListBiblebook.item( i );
                Element elementBiblebook = (Element)ndBiblebook;
                
                bnumber = elementBiblebook.getAttribute("bnumber");
                
                if (chapterCache) {
                    // Kapitel-Cache erstellen
                    NodeList ndListChapter = elementBiblebook.getElementsByTagName("CHAPTER");
                    for( int j=0; j<ndListChapter.getLength(); j++ ) {
                        Node ndChapter = ndListChapter.item( j );
                        Element elementChapter = (Element)ndChapter;
                        
                        cnumber = elementChapter.getAttribute("cnumber");
                        
                        copyAndWriteXmlCacheFile(
                    	        builder, 
                                ndXmlbible,
                    	        ndChapter, 
                    	        zippedCache, 
                    	        bnumber, 
                    	        cnumber,
                    	        transformer
                    	        );
                    }
                } else {
                    // Buch-Cache erstellen
                    copyAndWriteXmlCacheFile(
                	        builder, 
                            ndXmlbible,
                	        ndBiblebook, 
                	        zippedCache, 
                	        bnumber, 
                	        cnumber,
                	        transformer
                	        );
                }
            }
            
            // Node mit den Bibelmodulinformationen
            NodeList ndListInformation = document.getElementsByTagName( "INFORMATION" );
            Element ndInformation = (Element)ndListInformation.item(0);
            // Bibelname extrahieren
            NodeList ndListInformationTitle = ndInformation.getElementsByTagName( "title" );
            if (ndListInformationTitle.getLength()>0) {
                Node ndInformationTitle = ndListInformationTitle.item(0);
                BibleName=ndInformationTitle.getFirstChild().getNodeValue();
            } else {
                BibleName="";
            }
            
            // ModulCacheInfos
            // DOM-Tree des Informationsfiles aufbauen
            Document docInfo = builder.newDocument();
            Node rootInfo = docInfo.createElement("cacheinfo"); 
            docInfo.appendChild(rootInfo);
            Node ndInformationNew = docInfo.importNode(ndInformation,true);
            rootInfo.appendChild( ndInformationNew );
            // Modulpfad
            Node ndModulpath = docInfo.createElement("modulpath");
            Text ndTextModulpath = docInfo.createTextNode( ModulPath.toString() );
            ndModulpath.appendChild(ndTextModulpath);
            rootInfo.appendChild(ndModulpath);
            // MD5-Hashwert
            Node ndModulmd5 = docInfo.createElement("modulMD5");
            Text ndTextModulmd5 = docInfo.createTextNode( ModulCacheDir.toString() );
            ndModulmd5.appendChild(ndTextModulmd5);
            rootInfo.appendChild(ndModulmd5);
            // gezipped
            Node ndZipped = docInfo.createElement("zipped");
            Text ndTextZipped = docInfo.createTextNode( (zippedCache==true ? "yes" : "no") );
            ndZipped.appendChild(ndTextZipped);
            rootInfo.appendChild(ndZipped);
            // gezipped
            Node ndType = docInfo.createElement("type");
            Text ndTextType = docInfo.createTextNode( (true ? "x-books" : "x-chapter") );
            ndType.appendChild(ndTextType);
            rootInfo.appendChild(ndType);
            // DOM-Tree des Informationsfiles schreiben
            FileOutputStream osinfo = new FileOutputStream( new File( FullCachePath, INFOFILENAME ) );
            transformer.transform( new DOMSource( docInfo ), new StreamResult( osinfo ) );
            osinfo.close();
            
            Cached=true;
            // Inhaltsbaum aufbauen
            createDefaultTree();
            
            // TODO Was tun bei fehlerhaftes Dateiformat?
        }
        catch(Exception e)
        {
            //System.out.println(e);
            //e.printStackTrace();
        }
    }// end createCacheBooksIntern()

	/**
	 * Schreibt eine XML-Datei des Caches.
	 * @param builder DOM-Dokument-API f�r die Erstellung
     * @param ndXmlbible Node XMLBIBLE, der in die Cachedatei �bernommen wird. 
	 * @param copyTree Teilbaum (BIBLEBOOK, CHAPTER)
	 * @param zippedCache Wenn true, werden die XML-Dateien gezipped.
	 * @param bnumber Buchnummer
	 * @param cnumber Kapitelnummer
	 * @param transformer Transformer f�r Output
	 * @throws TransformerException
	 * @throws IOException
	 */
	private void copyAndWriteXmlCacheFile(
	        DocumentBuilder builder, 
            Node ndXmlbible,
	        Node copyTree, 
	        boolean zippedCache, 
	        String bnumber, 
	        String cnumber,
	        Transformer transformer
	        ) throws TransformerException, IOException {
        // Buch bzw. Kapitel-DOM-Tree aufbauen
        Document docBiblePart = builder.newDocument();
        // XMLBIBLE-Node kopieren 
        Element root = (Element)docBiblePart.importNode(ndXmlbible, false);
        docBiblePart.appendChild(root);
        root.appendChild( docBiblePart.createElement("INFORMATION") );
        // Buch-/Kapitel-Teilbaum kopieren
        Node ndCopyTreeNew = docBiblePart.importNode(copyTree, true);
        if ( copyTree.getNodeName().equals("CHAPTER") ) {
            // Zu kopierender Teilbaum ist ein CHAPTER
            // => Kapitel-Cache, also muss Element <BIBLEBOOK bnumber="xxx"> noch eingef�gt werden
            // BIBLEBOOK
            Element ndBibleBook = docBiblePart.createElement("BIBLEBOOK");
            // BIBLEBOOK bnumber
            Attr atrBnumber = docBiblePart.createAttribute("bnumber");
            atrBnumber.setValue( bnumber );
            ndBibleBook.setAttributeNode(atrBnumber);
            
            root.appendChild( ndBibleBook );
            ndBibleBook.appendChild( ndCopyTreeNew );
        } else {
            root.appendChild( ndCopyTreeNew );
        }
        
        // Schreiben der XML-Datei
        OutputStream os = null;
        StreamResult result = null;;
        String filenamePrefix = bnumber+(cnumber==null || cnumber.equals("")? "" : "_"+cnumber);
        if (zippedCache) {
            ZipOutputStream zos = new ZipOutputStream( new FileOutputStream( new File( FullCachePath, filenamePrefix+".zip" ) ) );
            zos.setLevel(9);
            zos.putNextEntry( new ZipEntry(filenamePrefix+".xml" ) );
            os = zos;
        } else {
            os = new FileOutputStream( new File( FullCachePath, filenamePrefix+".xml" ) );
        }
        transformer.transform( new DOMSource( docBiblePart ), new StreamResult( os ) );
        os.close();
    }
    /**
     * Diese Methode erzeugt aus dem Zefania XML Modul einen Inhaltsbaum f�r die Verwendung
     * in Bibelnavigations Klassen.
     */
    private void createDefaultTree() {
        File infofile = new File(FullCachePath, INFOFILENAME);
        try
        {   
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            factory.setValidating(false);
            factory.setNamespaceAware(false);
            // API f�r DOM instanziieren
            DocumentBuilder builder = factory.newDocumentBuilder();
            
            // Informationsdatei parsen
            Document docInfo = builder.parse( infofile );
            // Wurzelelement holen
            Element rootInfo = docInfo.getDocumentElement();
            
            // tree
            Element ndTree = docInfo.createElement("tree");
            rootInfo.appendChild(ndTree);
            // tree title
            Attr atrTitle = docInfo.createAttribute("title");
            atrTitle.setValue( getBibleName() );
            ndTree.setAttributeNode(atrTitle);
            // tree userdef
            Attr atrUserdef = docInfo.createAttribute("userdef");
            atrUserdef.setValue( "false" );
            ndTree.setAttributeNode(atrUserdef);
            
            // group AT
            Element ndAT = docInfo.createElement("group");
            ndTree.appendChild(ndAT);
            Attr atrTitleAT = docInfo.createAttribute("title");
            atrTitleAT.setValue( "AT" );
            ndAT.setAttributeNode(atrTitleAT);
            // group NT
            Element ndNT = docInfo.createElement("group");
            ndTree.appendChild(ndNT);
            Attr atrTitleNT = docInfo.createAttribute("title");
            atrTitleNT.setValue( "NT" );
            ndNT.setAttributeNode(atrTitleNT);
            // group AP
            Element ndAP = docInfo.createElement("group");
            ndTree.appendChild(ndAP);
            Attr atrTitleAP = docInfo.createAttribute("title");
            atrTitleAP.setValue( "AP" );
            ndAP.setAttributeNode(atrTitleAP);
            
            String books[];
            if( isZipped() ) {
                books = FullCachePath.list( new FilenameFilter() {
                    public boolean accept( File d, String n ) {
                        return ( n.toLowerCase().endsWith( ".zip" ) );
                    } } );
            } else {
                books = FullCachePath.list( new FilenameFilter() {
                    public boolean accept( File d, String n ) {
                        return ( !n.equalsIgnoreCase(INFOFILENAME) && n.toLowerCase().endsWith( ".xml" ) );
                    } } );
            }
            
            // �ber alle Dateien im Cache iterieren
            for (int index=0; index<books.length; index++) {
                // Einzulesende Datei
                File filetoread = new File(FullCachePath, books[index]);
                // Input-Stream bestimmen
                InputStream in = null;
                if( isZipped() ) {
                    ZipInputStream inzip = new ZipInputStream( new FileInputStream( filetoread ));
                    inzip.getNextEntry();
                    in=inzip;
                } else {
                    in = new FileInputStream( filetoread );
                }
                // Datei im Cache einlesen
                Document document = builder.parse(in);
                in.close();
                
                String bnumber;
                String cnumber="";
                // Liste aller Bibelb�cher-Nodes durchgehen
                NodeList ndListBiblebook = document.getElementsByTagName( "BIBLEBOOK" );
                for( int i=0; i<ndListBiblebook.getLength(); i++ ) {
                    Node ndBiblebook = ndListBiblebook.item( i );
                    Element elementBiblebook = (Element)ndBiblebook;
                    
                    bnumber = elementBiblebook.getAttribute("bnumber");
                    int ibnumber = Integer.parseInt(bnumber);
                    
                    // Liste aller Kapitel-Nodes durchgehen
                    NodeList ndListChapter = elementBiblebook.getElementsByTagName("CHAPTER");
                    for( int j=0; j<ndListChapter.getLength(); j++ ) {
                        Node ndChapter = ndListChapter.item( j );
                        Element elementChapter = (Element)ndChapter;
                        
                        cnumber = elementChapter.getAttribute("cnumber");
                        if (!cnumber.equals("")) {
                            // Kapitelnummer ist nicht leer
                            
                            // item
                            Element ndItem = docInfo.createElement("item");
                            if (ibnumber<40) {
                                ndAT.appendChild(ndItem);
                            } else if (ibnumber>39 && ibnumber<67) {
                                ndNT.appendChild(ndItem);
                            } else if (ibnumber>66) {
                                ndAP.appendChild(ndItem);
                            }
                            // item bn
                            Attr atrBn = docInfo.createAttribute("bn");
                            atrBn.setValue( bnumber );
                            ndItem.setAttributeNode(atrBn);
                            // item cn
                            Attr atrCn = docInfo.createAttribute("cn");
                            atrCn.setValue( cnumber );
                            ndItem.setAttributeNode(atrCn);
                            // item active
                            Attr atrActive = docInfo.createAttribute("active");
                            atrActive.setValue( "false" );
                            ndItem.setAttributeNode(atrActive);
                        }
                    }
                }
            }
            // Ein XSLT-Transformer zum Schreiben der Info-XML-Datei
            Transformer transformer = TransformerFactory.newInstance().newTransformer();
            // DOM-Tree des Informationsfiles schreiben
            FileOutputStream osinfo = new FileOutputStream( new File( FullCachePath, INFOFILENAME ) );
            transformer.transform( new DOMSource( docInfo ), new StreamResult( osinfo ) );
            osinfo.close();
        }
        catch(Exception e) {
            //System.out.println(e.getLocalizedMessage());
            //e.printStackTrace();
        }
    }
	/**
	 * Liest eine eventuell vorhandene Cache Info Datei und sichert, falls vorhanden, einen durch den User ver�nderten Inhaltsbaum
	 * in der Variable ContentTree.
	 * @return Gibt True zur�ck, wenn ein userdefinierter Inhaltsbaum gefunden wurde.
     * @see #ContentTree 
	 */
    private boolean catchUserTree() {
        boolean returnValue = false;
        try {
            File infofile = new File(FullCachePath, INFOFILENAME);
            if(infofile.exists()) {
                DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
                factory.setValidating(false);
                factory.setNamespaceAware(false);
                
                // API f�r DOM instanziieren
                DocumentBuilder builder = factory.newDocumentBuilder();
                // Dokument parsen
                Document document = builder.parse( infofile );
                
                // Element "tree" suchen
                NodeList ndListTree = document.getElementsByTagName( "tree" );
                if (ndListTree.getLength()>0) {
                    // Element "tree" vorhanden
                    Element ndTree = (Element)ndListTree.item(0);
                    String flag = ndTree.getAttribute("userdef");
                    if (flag.equals("true")) {
                        returnValue = true;
                        ContentTree = document;
                    }
                }
            }
        } catch(Exception e) {
        }
        return returnValue;
    }
}
