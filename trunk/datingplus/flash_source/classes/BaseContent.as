class classes.BaseContent extends pseudo.BaseMovie implements classes.IContent
{
	private var m_mode:String;
	private var m_preloader:pseudo.BaseMovie;

	//
	// PUBLIC METHODS
	//

	public function BaseContent(pThis:MovieClip)
	{
		super(pThis);
		m_mode = "";
	}

	public function setMode(mode:String):Void
	{
		m_mode = mode;
		switch(mode)
		{
			case "noData":
				if(!m_preloader)
				{
					m_bUpdated = false;
					m_preloader = addItem(pseudo.BaseMovie, "preloader", getNextHighestDepth());
					m_preloader.setData({type:"sign", icon:"contentPreloader"});
					m_preloader.addListener("onLoadIcon", this, updatePreloader);
					m_preloader.draw();
					//updatePreloader();
				}
				else updatePreloader();
				break;
			case "hasData":
				removeItem("preloader");
				delete m_preloader;
				break;
		}
	}

	public function getMode():String
	{
		return m_mode;
	}

	public function setValue(val:Object):Void
	{
	}

	public function getValue(type:String):Object
	{
		return null;
	}

	public function update():Void
	{
		if(!m_bUpdated)
			updatePreloader();
		super.update();
	}

	private function updatePreloader():Void
	{
		if(m_preloader)
		{
			m_preloader._x = Math.round(m_nW / 2);
			m_preloader._y = Math.round(m_nH / 2);
		}
	}
}