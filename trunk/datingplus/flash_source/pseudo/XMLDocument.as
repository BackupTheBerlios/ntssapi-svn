/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
/** Contains helper functions which simplify working with xml. */
class pseudo.XMLDocument implements pseudo.IBroadcaster
{
  /** Node that contains all xml. */
  public var m_xmlNode:XML;
	private var m_caster:pseudo.IBroadcaster;
	private var m_timerId:Number;
	private var m_nLoadProgress:Number;

	// PUBLIC METHODS
  /**
   * Constructor.
   * @param xmlNode Node from which object is initialized.
   */
  public function XMLDocument(node:XML)
  {
    if(node)
      m_xmlNode = node.nodeName ? node : XML(node.firstChild);
    else
      m_xmlNode = new XML();

		/**
		 * This function is called when onData event is fired.
		 * @param src Unparsed xml string.
		 */
		m_xmlNode.onData = function(src:String):Void
		{
			clearInterval(this.owner.m_timerId);
			this.owner.fireEvent("onData", src, this.owner);
			if(src == undefined) this.onLoad(false);
			else
			{
				this.parseXML(src);
				this.loaded = true;
				this.onLoad(true);
			}
		}

		/**
		 * This function is called when onLoad event is fired.
		 * @param bSuccess true if xml loading was finished successfully false otherwise.
		 */
		m_xmlNode.onLoad = function(bSuccess:Boolean):Void
		{
			this.owner.updateNode.call(this.owner);
			this.owner.fireEvent("onLoad", bSuccess, this.owner);
		}

    m_xmlNode["owner"] = this;
    m_xmlNode.ignoreWhite = true;
    m_xmlNode.contentType = "text/xml"; // this needs only when you send xml to server
		m_caster = new pseudo.Broadcaster();
  }

	public function fireEvent(strEvent:String):Boolean
	{
		return Boolean(m_caster.fireEvent.apply(Object(m_caster), arguments));
	}

	public function addListener(strEvent:String, pOwner:Object, fnCallBack:Function):Void
	{
		m_caster.addListener.apply(Object(m_caster), arguments);
	}

	public function removeListener(strEvent:String, pListener:Object):Void
	{
		m_caster.removeListener(strEvent, pListener);
	}

	public function removeListeners():Void
	{
		m_caster.removeListeners();
	}

	public function getEventData(strEvent:String):Object
	{
		return m_caster.getEventData(strEvent);
	}

  /**
   * Sends and loads xml from given url.
   * @param url Path to xml.
	 * @param xmlResult Receiver of loaded xml.
   */
  public function sendAndLoad(url:String, xmlResult:pseudo.XMLDocument):Void
  {
		m_nLoadProgress = 0;
		clearInterval(m_timerId);
		if(getEventData("onLoadProgress"))
			m_timerId = setInterval(this, "fireEvent", 500, "onLoadProgress", this);
		if(!xmlResult) xmlResult = this;
    m_xmlNode.sendAndLoad(url, xmlResult.m_xmlNode);
  }

	/**
   * Loads xml from given url.
   * @param Url Path to xml.
   */
  public function load(url:String):Void
  {
		m_nLoadProgress = 0;
		clearInterval(m_timerId);
		if(getEventData("onLoadProgress"))
			m_timerId = setInterval(this, "fireEvent", 500, "onLoadProgress", this);
    m_xmlNode.load(url);
  }

  /**
   * Gets appropriate xml string.
   * @return Xml string.
   */
  public function toString():String
  {
    return m_xmlNode.toString();
  }

  /**
   * Gets node. Uses '.' as node separator.
   * @param strNodeName Path to node.
   * @return null if no node is found, node object otherwise.
   */
  public function getNode(strNodeName:String):XMLDocument
  {
    if(!strNodeName || strNodeName == m_xmlNode.nodeName) return new pseudo.XMLDocument(m_xmlNode)
    var arrNodeNames:Array = strNodeName.split(".");
		if(arrNodeNames[0] == m_xmlNode.nodeName) arrNodeNames.shift();
    var xmlCurNode:XML = m_xmlNode;
		var bExist:Boolean = false;
    for(var i = 0; i < arrNodeNames.length; i++)
		{
			bExist = false;
      for(var j = 0; j < xmlCurNode.childNodes.length; j++)
        if(xmlCurNode.childNodes[j].nodeName == arrNodeNames[i] || arrNodeNames[i] == "*")
				{
					bExist = true;
          xmlCurNode = xmlCurNode.childNodes[j];
					break;
				}
			if(!bExist) break;
		}
		return  bExist ? new pseudo.XMLDocument(xmlCurNode) : null;
  }

  /**
   * Gets array of nodes with the same names from given path. For example,
   * if you have the given xml structure: <xml><child1><child2/><child2/></child1></xml>
   * and you want to get all <child2> node, the string should be: "xml.child1.child2".
   * @param strNodeName Path to xml.
   * @return Array of requestend nodes if they were found null otherwise.
   */
  public function getNodes(strNodeName:String):Array
  {
    var arrNodes:Array = new Array();
    var xmlCurDocNode:XMLDocument = getNode(strNodeName);
    if(xmlCurDocNode)
    {
      // get name of last node separated by "."
      var strLastNodeName = strNodeName.substr(strNodeName.lastIndexOf(".") + 1);
      // fill array with nodes with the same names
      var xmlCurNode = xmlCurDocNode.m_xmlNode;
      while(xmlCurNode)
      { // add all appropriate nodes to the array
        if(strLastNodeName == "*" || xmlCurNode.nodeName == strLastNodeName)
	        arrNodes.push(new pseudo.XMLDocument(xmlCurNode));
        xmlCurNode = xmlCurNode.nextSibling;
      }
    }
    else return null;
    return arrNodes;
  }

  /**
   * Gets current node name.
   * @return Node name.
   */
  public function getNodeName():String
  {
    return m_xmlNode.nodeName;
  }

  /**
   * Gets requested node attribute as string. Note that you should convert it
   * to the appropriate format you want.
   * @return Attribute value.
   */
  public function getAttr(strAttrName:String, strNodeName:String):String
  {
    return getNode(strNodeName).m_xmlNode.attributes[strAttrName];
  }

  /**
   * Gets node value, from the requested node. For example,
   * if you have the given xml structure: <xml><child1><child2>some text</child2></child1></xml>
   * and you want to get child2 node value, you should write the following string:
   * "xml.child1.child2".
   * @param strNodeName Path to node.
   * @return Node value.
   */
  public function getNodeValue(strNodeName:String):String
  {
		var val:String = getNode(strNodeName).m_xmlNode.firstChild.nodeValue;
    return val ? val : "";
  }

  /**
   * Gets next sibling.
   * @return Next sibling if exist, null otherwise.
   */
  public function getNextSibling():XMLDocument
  {
    return new pseudo.XMLDocument(XML(m_xmlNode.nextSibling));
  }

  /**
   * Gets previous sibling.
   * @return Previous sibling if exist, null otherwise.
   */
  public function getPrevSibling():XMLDocument
  {
    return new pseudo.XMLDocument(XML(m_xmlNode.previousSibling));
  }

  /**
   * Gets child nodes as array.
   * @return Array of child nodes.
   */
  public function childNodes():Array
  {
    return m_xmlNode.childNodes;
  }

	/**
	 * Gets number of loaded bytes. Calls the same method of m_xmlNode.
	 * @return Number of loaded bytes.
	 */
	public function getBytesLoaded():Number
	{
		return m_xmlNode.getBytesLoaded();
	}

	/**
	 * Gets number of total bytes. Calls the same method of m_xmlNode.
	 * @return Number of total bytes.
	 */
	public function getBytesTotal():Number
	{
		return m_xmlNode.getBytesTotal();
	}

	public function remove():Void
	{
		delete m_xmlNode.onLoad;
		delete m_xmlNode;
		delete m_caster;
		delete this;
	}

	//
	// PRIVATE METHODS
	//
	private function updateNode():Void
	{
		if(!m_xmlNode.nodeName)
		{
			m_xmlNode = m_xmlNode.childNodes[0];
			m_xmlNode["owner"] = this;
		}
	}
}
