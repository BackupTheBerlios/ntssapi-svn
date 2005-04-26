package queries;

import java.io.File;
import java.util.ArrayList;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.xpath.XPath;
import javax.xml.xpath.XPathConstants;
import javax.xml.xpath.XPathFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

/**
 * Übersetzt Bibelbuchnummer zu Buchbezeichnungen und umgekehrt.
 * z.B.  10 ==> 2Sam
 * @author Michael Leimer
 * @version 1.0
 */
public class ZefMapNames {
    /** Versionsinfo */
    private static final String VERSIONINFO = "0.0.0.2";
    /**
     * Diese Enumeration wird verwendet, um auf die
     * kurze oder lange Form des Bibelbuchnames zuzugreifen.
     * @see #getBookNameByNumber(String, BookNameType, int)
     */ 
    public static enum BookNameType {SHORTNAME, LONGNAME};
    /** Diese Variable enthält den Inhalt einer bnames Datei. */
    private Document namesXMLResource = null;
    /**
     * Der Konstruktor für eine Map-Klasse
     * @param pathToNamesFile Pfad zur XML-Resource mit Zuordnungen Buchnummern zu Buchnamen. vergl: http://tinyurl.com/94mr2 
     */
    public ZefMapNames(File pathToNamesFile)
    {
        try {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            factory.setValidating(false);
            factory.setNamespaceAware(false);
            
            // API für DOM instanziieren
            DocumentBuilder builder = factory.newDocumentBuilder();
            // Dokument parsen
            namesXMLResource = builder.parse( pathToNamesFile );
        } catch(Exception e) {
        }
    }
    /**
     * Gibt die Versionsnummer der zefMapNames-Klasse zurück.
     */
    public String getMapVersion() {
        return VERSIONINFO;
    }
    /**
     * Diese Methode liefert zu einer Buchnummer entweder die lange oder die kurze Form
     * eine Bibelbuchnamens zurück.
     * @param LangID Die Sprach ID
     * @param NameType BookNameType.SHORTNAME oder BookNameType.LONGNAME
     * @param BookNumber Die Buchnummer
     * @return Den Buchnamen z.B. Genesis
     */
    public String getBookNameByNumber(String LangID, BookNameType NameType, int BookNumber) {
        try {
            XPath xpath = XPathFactory.newInstance().newXPath();
            String expression = "descendant::ID[@descr='"+LangID+"']/BOOK[@bnumber='"+BookNumber+"']";
            Node bookItem = (Node)xpath.evaluate(expression, namesXMLResource, XPathConstants.NODE);
            if(bookItem!=null) {
                if(NameType==BookNameType.SHORTNAME) {
                    String bookName = ((Element)bookItem).getAttribute("bshort"); 
                    return bookName; 
                } else if(NameType==BookNameType.LONGNAME) {
                    String bookName = ((Element)bookItem).getFirstChild().getTextContent();
                    return bookName;
                }
            }
        }
        catch(Exception e) {
        }
        return "";
    }
    /**
     * Diese Methode liefert eine Liste alle in einer bnames Datei verfügbaren Sprach IDs zurück.
     * @return Eine Liste aller Sprach Ids
     */
    public ArrayList getListOfIds() {
        ArrayList<String> internalList=new ArrayList<String>(); 
        try
        {
            // Liste aller IDs durchgehen
            NodeList ndListID = namesXMLResource.getElementsByTagName( "ID" );
            for( int i=0; i<ndListID.getLength(); i++ ) {
                Node ndID = ndListID.item( i );
                Element elementID = (Element)ndID;
                
                String desc = elementID.getAttribute("descr");
                if (!desc.equals("")) {
                    internalList.add(desc);
                }
            }                
        } catch(Exception e) {
        }
        return internalList;	
    }
}
