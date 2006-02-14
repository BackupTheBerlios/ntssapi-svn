/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.Button extends pseudo.BaseComponent
{
	private var m_layerUser:pseudo.BaseMovie;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.Button
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.Button(pOwner[strName]);
		return pOwner[strName];
	}

	public function Button(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.Button;

		m_data.className = "Button";
		m_data.mode = "out";
		m_bDrawHidden = true;
	}

	public function getMinW():Number
	{
		return super.getMinW() + (m_layerUser ? m_layerUser.getMinW() : 0);
	}

	public function getMinH():Number
	{
		return super.getMinH() + (m_layerUser ? m_layerUser.getMinH() : 0);
	}

	public function setData(data:Object, bRecreate:Boolean):Void
	{
		super.setData(data, bRecreate);
		m_layerUser.setData({type:m_data.type, mode:m_data.mode});
	}

	public function showLayer(strLayer:String):Void
	{
		if(m_data.mode != "disabled")
		{
			setData({mode:strLayer});
			m_bDrawn = false;
			update();
			draw();
			fireEvent("showLayer");
		}
	}

	public function addItem(pClass:Function, strName:String, nDepth:Number):pseudo.BaseMovie
	{
		if(!strName) strName = "layerUser";
		var item:pseudo.BaseMovie =
			super.addItem(pClass, strName, nDepth ? nDepth : 1);
		item.setData({mode:m_data.mode, type:m_data.type});
		item.setBehavior("layer");
		if(strName == "layerUser") m_layerUser = item;
		return item;
	}

	public function update():Void
	{
		if(!m_bUpdated && m_layerUser)
		{
			m_layerUser.setSize(
				m_nW - m_look.getMargin("left", m_data) - m_look.getMargin("right", m_data),
				m_nH - m_look.getMargin("top", m_data) - m_look.getMargin("bottom", m_data)
			);
			m_layerUser._x = m_look.getMargin("left", m_data);
			m_layerUser._y = m_look.getMargin("top", m_data);
		}
		super.update();
	}
}