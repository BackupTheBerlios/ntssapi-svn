class classes.ThemesManager implements pseudo.IBroadcaster
{
	static private var m_instance:classes.ThemesManager;
	private var m_holder:MovieClip;
	private var m_xmlLooks:pseudo.XMLDocument;
	private var m_arrXMLLooks:Array;
	private var m_arrLooks:Array;
	private var m_strLookId:String;
	private var m_caster:pseudo.IBroadcaster;

	//
	// PUBLIC METHODS
	//
	static public function getInstance():classes.ThemesManager
	{
		if(!m_instance) m_instance = new classes.ThemesManager();
		return m_instance;
	}

	public function setHolder(holder:MovieClip):Void
	{
		m_holder = holder;
	}

	public function setLooks(xmlLooks:pseudo.XMLDocument):Void
	{
		m_xmlLooks = xmlLooks;
		if(m_arrLooks) m_arrLooks.splice(0);
		m_arrXMLLooks = xmlLooks.getNodes("look");
	}

	public function getLooks():Array
	{
		return m_arrXMLLooks;
	}

	public function getLook(strId:String):Object
	{
		if(!strId) strId = m_strLookId;
		for(var i:Number = 0; i < m_arrLooks.length; i++)
		{
			if(m_arrLooks[i].id == strId)
				return m_arrLooks[i].look;
		}
		return null;
	}

	public function getLookXML(strId:String):pseudo.XMLDocument
	{
		for(var i:Number = 0; i < m_arrXMLLooks.length; i++)
			if(m_arrXMLLooks[i].getAttr("id") == strId)
				return m_arrXMLLooks[i];
		return null;
	}

	public function loadLook(strId:String, strThemeId:String, event:String):Void
	{
		if(!strId) strId = m_xmlLooks.getAttr("default");
		var look:Object = getLook(strId);
		if(look)
		{
			if(strThemeId) look.setThemeId(strThemeId);
			fireEvent("onLoad", look);
			if(event) fireEvent(event, look);
		}
		else
		{
			var xmlLook:pseudo.XMLDocument = getLookXML(strId);
			if(xmlLook)
			{
				var nDepth:Number = m_holder.getNextHighestDepth();
				var strName:String = "mcLook_" + nDepth;
				m_holder.createEmptyMovieClip(strName, nDepth);
				m_arrLooks.push({themeId:strThemeId, id:strId, movie:m_holder[strName], event:event, xml:xmlLook});
				var loader:MovieClipLoader = new MovieClipLoader();
				loader.addListener(this);
				loader.loadClip(xmlLook.getAttr("path"), m_holder[strName]);
			}
		}
	}

	public function setLook(look:Object):Object
	{
		if(look)
		{
			_global.look = look;
			m_strLookId = _global.look.getId();
			pseudo.CursorManager.getInstance().setLook(look);
			pseudo.ToolTip.getInstance().setLook(look);
			_global.main.setLook(look);
		}
		return look;
	}

	public function setLookId(strId:String):Object
	{
		if(!strId) strId = m_xmlLooks.getAttr("default");
		var newLook:Object = getLook(strId);
		if(newLook.getId() != _global.look.getId()) setLook(newLook);
		return newLook;
	}

	public function toXML():pseudo.XMLDocument
	{
		var xml:XML = new XML();
		xml.nodeName = "theme";
		xml.attributes.lookId = _global.look.getId();
		xml.attributes.id = _global.look.getThemeId();
		return new pseudo.XMLDocument(xml);
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

	//
	// PRIVATE METHODS
	//

	private function ThemesManager()
	{
		m_arrLooks = new Array();
		m_strLookId = "";
		m_caster = new pseudo.Broadcaster();
	}

	private function getLookObj(movie:MovieClip):Object
	{
		for(var i:Number = 0; i < m_arrLooks.length; i++)
		{
			if(m_arrLooks[i].movie == movie)
				return m_arrLooks[i];
		}
		return null;
	}

	private function onLoadProgress(target:MovieClip, bytesLoaded:Number, bytesTotal:Number):Void
	{
		var objLook:Object = getLookObj(target);
		fireEvent("onLoadProgress", objLook.look, bytesLoaded, bytesTotal);
		fireEvent("onLoadProgress" + objLook.id, objLook.look, bytesLoaded, bytesTotal);
	}

	private function onLoadError(target:MovieClip, errorCode:String):Void
	{
		fireEvent("onLoadError", errorCode);
	}

	private function onLoadInit(target:MovieClip):Void
	{
		var objLook:Object = getLookObj(target);
		if(objLook)
		{
			objLook.look = target.getLook();
			objLook.look.setData(objLook.xml);
			if(objLook.themeId)
			{
				objLook.look.setThemeId(objLook.themeId);
				delete objLook.themeId;
			}
			fireEvent("onLoad", objLook.look);
			if(objLook.event) fireEvent(objLook.event, objLook.look);
		}
	}
}