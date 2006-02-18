using System;
using System.IO;
using System.Xml;
using System.Text;

namespace NewTrueSharpSwordAPICF
{
	/// <summary>
	/// Zusammenfassung für cfhtmlpages
	/// </summary>

	/// <summary>
	///  Der Pfad zum Modul, das abgefragt werden soll.
	/// </summary>
	public class cfhtmlpages
	{
		private string FPathTOModulCache;
		public string CachePathForModul
		{
		
			set
			{
				
				FPathTOModulCache=value;
			}
			get
			{
			   
				return FPathTOModulCache;
			}
		
		}
		
		/// <summary>
		/// Indikator, ob im Ergebniss html eine Note eingeblendet ist.
		/// </summary>
		private bool FFacetNote=true;
		public bool ShowNotes
		{
		
			set
			{
				
				FFacetNote=value;
			}
			get
			{
			   
				return FFacetNote;
			}
		
		}
        
		/// <summary>
		/// Indikator, ob im Ergebniss html eine Überschrift eingeblendet ist.
		/// </summary>
		private bool FFacetCaption=true;
		public bool ShowCaptions
		{
		
			set
			{
				
				FFacetCaption=value;
			}
			get
			{
			   
				return FFacetCaption;
			}
		
		}


		public cfhtmlpages()
		{
			//
			// TODO: Fügen Sie hier die Konstruktorlogik hinzu
			//
		}
		/// <summary>
		/// Liefert den HTML-Text in Fließtextdarstellung.
		/// </summary>
		public string GetChapterAsFlowText2(string BookNumber,string ChapterNumber)
		{
			try
			{
				
				string pathToChapterFile=CachePathForModul+@"\"+BookNumber+"_"+ChapterNumber+@".xml";
				XmlDocument doc=new XmlDocument();
				doc.Load(pathToChapterFile);
				return doc.OuterXml;
			}
			catch(Exception e)
			{
			
				return "<html><body><div>"+BookNumber+"_"+ChapterNumber+@".xml not found!</div></body></html>";
			}
		
		}

		/// <summary>
		/// Liefert den HTML-Text in html-table Darstellung.
		/// </summary>
		public string GetChapterAsHtmlTable(string BookNumber,string ChapterNumber)
		{
			try
			{
				StringWriter sw = new StringWriter();
				XmlTextWriter writer = new XmlTextWriter(sw);
				//writer.Formatting = Formatting.Indented;
				writer.WriteStartElement("html");
				writer.WriteStartElement("body");
			

				string pathToChapterFile=CachePathForModul+@"\"+BookNumber+"_"+ChapterNumber+@".xml";
				
				XmlTextReader reader = new XmlTextReader(pathToChapterFile);
				reader.MoveToContent();

				while (reader.Read())

				{
					

					if(reader.Name=="VERS"&&reader.NodeType == XmlNodeType.Element)
					{
						
					  

						reader.MoveToFirstAttribute();

						writer.WriteStartElement("span");
						writer.WriteAttributeString("style","color:darkred;font-weight:bold");
						writer.WriteString(reader.Value+" ");
						writer.WriteEndElement();
						
					}
					
					if(reader.Name==""&&reader.NodeType == XmlNodeType.Text)
					{
						
						writer.WriteString(reader.ReadString());
					
						
						
					}

					if (reader.Name == "NOTE") 
					{
						writer.WriteStartElement("span");

						writer.WriteAttributeString("style","color:darkgreen;font-weight:lighter");
						writer.WriteString("{"+reader.ReadString()+"}");

						writer.WriteEndElement();
					}

					if (reader.Name == "CAPTION") 
					{
						writer.WriteStartElement("span");

						writer.WriteAttributeString("style","color:blue;font-weight:lighter");
						writer.WriteString(reader.ReadString()+"<br>");

						writer.WriteEndElement();
					}

					if (reader.Name == "STYLE") 
					{
						
						
						writer.WriteStartElement("span");
						writer.WriteAttributeString("style",reader.GetAttribute("css",""));
                        writer.WriteString(reader.ReadString());
						writer.WriteEndElement();
						
					}

					if (reader.Name == "gr") 
					{
						
						
						   
								
						    
						        writer.WriteStartElement("A");

						       writer.WriteAttributeString("href",reader.GetAttribute("str",""));
						       writer.WriteString(" ("+reader.GetAttribute("str","")+") ");
						       
						     writer.WriteEndElement();//A


						writer.WriteString(reader.ReadString());
					
						
					}

					if(reader.Name=="VERS"&&reader.NodeType == XmlNodeType.EndElement)
					{
						writer.WriteStartElement("br");
						writer.WriteEndElement();
										    
					}
				}
               
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.Close();
				reader.Close();
				return sw.ToString();
			}
			catch(Exception e)
			{
			
				return "<html><body><div>"+e.Message+"</div></body></html>";
			}
		
		}

		/// <summary>
		/// Liefert den HTML-Text in Fließtextdarstellung.
		/// </summary>
		public string GetChapterAsFlowText(string BookNumber,string ChapterNumber)
		{
			try
			{
				StringWriter sw = new StringWriter();
				XmlTextWriter writer = new XmlTextWriter(sw);
				writer.Formatting = Formatting.Indented;
				writer.WriteStartElement("html");
				

				writer.WriteStartElement("body");

				string pathToChapterFile=CachePathForModul+@"\"+BookNumber+"_"+ChapterNumber+@".xml";
				
				XmlTextReader reader = new XmlTextReader(pathToChapterFile);
				reader.MoveToContent();
				while (reader.Read())
				{
					if(reader.Name=="VERS"&&reader.NodeType == XmlNodeType.Element)
					{
						writer.WriteStartElement("span");
					  

						reader.MoveToFirstAttribute();
						writer.WriteStartElement("span");
						writer.WriteAttributeString("style","color:darkred;font-weight:bold");
					  
						writer.WriteString(reader.Value+" ");
						writer.WriteEndElement();
					}
					
					if(reader.Name==""&&reader.NodeType == XmlNodeType.Text)
					{
						writer.WriteStartElement("span");
						writer.WriteString(reader.ReadString());
						writer.WriteEndElement();
						
					}

					if (reader.Name == "NOTE") 
					{
						writer.WriteStartElement("span");

						writer.WriteAttributeString("style","color:darkgreen;font-weight:lighter");
						writer.WriteString("{"+reader.ReadString()+"}");

						writer.WriteEndElement();
					}

					if(reader.Name=="VERS"&&reader.NodeType == XmlNodeType.EndElement)
					{
						
						writer.WriteEndElement();
										    
					}
				}
               
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.Close();
				reader.Close();
				return sw.ToString();
			}
			catch(Exception e)
			{
			
				return "<html><body><div>"+e.Message+"</div></body></html>";
			}
		
		}
	}
}
