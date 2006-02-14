/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class classes.ResizeTitle extends pseudo.ToggleButton implements pseudo.IAlignable, pseudo.IHideable
{
	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):classes.ResizeTitle
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new classes.ResizeTitle(pOwner[strName]);
		return pOwner[strName];
	}

	public function ResizeTitle(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = classes.ResizeTitle;

		m_nH = 20;
		m_data.type = "resizeTitle";
		m_data.border = 11;
	}

	public function setAlign(align:String):Void {}

	public function getAlign():String
	{
		return "top";
	}

	public function hide():Void
	{
		setData({state:"sunken", border:15});
		m_bDrawn = m_bUpdated;
	}

	public function show():Void
	{
		setData({state:"normal", border:11});
		m_bDrawn = m_bUpdated;
	}

	public function showHide():Void
	{
		isSunken() ? show() : hide();
	}

	//
	// PRIVATE METHODS
	//
	private function movieMouseRelease(bSkip2:Boolean, bSkip1:Boolean, bSkip:Boolean):Void
	{
		if(!bSkip)
		{
			setData({border:isSunken() ? 11 : 15});
			//invokeEvent("showLayer"); // redraw after possible moving
			fireEvent("showHide");
		}
		super.movieMouseRelease(false, false, true);
	}
}