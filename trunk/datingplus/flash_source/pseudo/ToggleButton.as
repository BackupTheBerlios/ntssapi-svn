/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.ToggleButton extends pseudo.PushButton
{
	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.ToggleButton
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.ToggleButton(pOwner[strName]);
		return pOwner[strName];
	}

	public function ToggleButton(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.ToggleButton;

		m_data.state = "normal";
	}

	public function setState(state:String):Void
	{
		if(m_data.state != state)
		{
			setData({state:state});
			m_layerUser.setData({state:state});
			invokeEvent("showLayer");
		}
	}

	public function isSunken():Boolean
	{
		return m_data.state == "sunken";
	}

	public function addItem(pClass:Function, strName:String, nDepth:Number):pseudo.BaseMovie
	{
		var layerUser:pseudo.BaseMovie = super.addItem(pClass, strName, nDepth);
		if(layerUser.getName() == "layerUser")
		{
			m_layerUser.setData({state:m_data.state});
			m_layerUser.setBehavior("layer");
		}
		return m_layerUser;
	}

	//
	// PRIVATE METHODS
	//
	private function movieMouseRelease(bSkipParent:Boolean, bSkip:Boolean):Void
	{
		if(!bSkip) setState(m_data.state == "sunken" ? "normal" : "sunken");
		super.movieMouseRelease(false, true);
	}
}