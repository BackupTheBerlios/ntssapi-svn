/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class classes.WindowTitle extends pseudo.BaseComponent
{
	private var m_btnBack:pseudo.Button;
	private var m_lblText:pseudo.Label;
	private var m_btnHide:pseudo.PushButton;
	private var m_btnMinimize:pseudo.ToggleButton; // minimize/maximize toggle button
	private var m_btnClose:pseudo.PushButton;
	private var m_bMoveTitle:Boolean;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):classes.WindowTitle
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new classes.WindowTitle(pOwner[strName]);
		return pOwner[strName];
	}

	public function WindowTitle(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = classes.WindowTitle;

		m_btnBack = pseudo.Button.create(pThis, "m_btnBack", 1);
		m_btnBack.setData({type:"titleBtnBack", border:11});
		m_btnBack.addListener("doubleClick", pThis, onDoubleClick);
		m_btnBack.setName("btnBack");
		m_btnHide = pseudo.PushButton.create(pThis, "m_btnHide", 3);
		m_btnHide.setData({type:"titleBtnHide", sound:"btnRelease"});
		m_btnHide.addListener("mouseRelease", pThis, function(){this.fireEvent("hideWindow");});
		m_btnHide.setName("btnHide");
		m_btnMinimize = pseudo.ToggleButton.create(pThis, "m_btnMinimize", 4);
		m_btnMinimize.setData({type:"titleBtnMinimize", sound:"btnRelease"});
		m_btnMinimize.addListener("mouseRelease", pThis, onMaximize);
		m_btnMinimize.setName("btnMinimize");
		m_btnClose = pseudo.PushButton.create(pThis, "m_btnClose", 5);
		m_btnClose.setData({type:"titleBtnClose", sound:"btnRelease"});
		m_btnClose.addListener("mouseRelease", pThis, function(){this.fireEvent("close");});
		m_btnClose.setName("btnClose");
		m_bMoveTitle = false;
		m_data.className = "WindowTitle";
		m_arrItems.push(m_btnBack, m_btnHide, m_btnMinimize, m_btnClose);
		m_nH = 22;
	}

	public function setCanHide(bCanHide:Boolean):Void
	{
		if(m_btnHide._visible != bCanHide)
		{
			m_btnHide._visible = bCanHide;
			m_bUpdated = false;
		}
	}

	/**
	 * Shows/hides 'maximize/minimize' toggle button
	 * @param bCanMaximize If true - shows 'maximize/minimize' toggle button, hides it otherwise.
	 */
	public function setCanMaximize(bCanMaximize:Boolean):Void
	{
		if(m_btnMinimize._visible != bCanMaximize)
		{
			m_btnMinimize._visible = bCanMaximize;
			m_bUpdated = false;
		}
	}

	public function getMinW():Number
	{
		return m_nW - m_btnHide._x + 5;
	}

	public function getMinH():Number
	{
		return m_nH;
	}

	public function setText(strText:String):Void
	{
		if(!m_lblText)
		{
			m_lblText = pseudo.Label.create(this, "m_lblText", 2);
			m_lblText.setAlign("left");
			m_lblText.setLook(m_look);
			var data:Object = m_btnBack.getData();
			m_lblText.setData({type:data.type, mode:data.mode});
			m_lblText.setBehavior("layer");
			m_lblText.setName("lblText");
			m_arrItems.push(m_lblText);
		}
		m_lblText.setText(strText);
	}

	public function setData(data:Object, bRecreate:Boolean):Void
	{
		if(m_data.mode != data.mode)
		{
			m_btnBack.setData({mode:data.mode});
			m_btnBack.setDrawn(false);
		}
		var bFaded:Boolean = data.mode != "over";
		if(m_data.faded != bFaded)
		{
			m_btnHide.setData({faded:bFaded});
			m_btnMinimize.setData({faded:bFaded});
			m_btnClose.setData({faded:bFaded});
			m_btnHide.setDrawn(false);
			m_btnMinimize.setDrawn(false);
			m_btnClose.setDrawn(false);
			m_lblText.setData({mode:data.mode});
		}
		super.setData(data, bRecreate);
	}

	public function setLook(look:Object):Void
	{
		super.setLook(look);
		var objTitleParams:Object = m_look.getParams({type:"wndTitle"});
		m_nH = objTitleParams.h;
	}

	public function invokeEvent(strEvent:String):Void
	{
		super.invokeEvent(strEvent);
		switch(strEvent)
		{
			case "maximizeWindow":
				m_btnMinimize.setState("sunken");
				break;
			case "minimizeWindow":
				m_btnMinimize.setState("normal");
				break;
		}
	}

	public function update():Void
	{
		if(!m_bUpdated)
		{
			var objTitleParams:Object = m_look.getParams({type:"wndTitle"});
			m_nH = objTitleParams.h;
			m_btnBack.setSize(m_nW, m_nH);
			m_btnHide.setSize(objTitleParams.btnW, objTitleParams.btnH);
			m_btnMinimize.setSize(objTitleParams.btnW, objTitleParams.btnH);
			m_btnClose.setSize(objTitleParams.btnW, objTitleParams.btnH);
			m_btnClose._x = m_nW - m_btnClose.getW() - m_look.getMargin("right", m_btnBack.getData());
			m_btnMinimize._x = m_btnClose._x - m_btnMinimize.getW() - objTitleParams.off2;
			m_btnHide._x = m_btnMinimize._visible
				? m_btnMinimize._x - m_btnHide.getW() - objTitleParams.off1
				: m_btnMinimize._x;
			m_btnHide._y = m_btnMinimize._y = m_btnClose._y =
				m_look.getMargin("top", m_data) + Math.round((getUserH() - m_btnHide.getH()) / 2);

			m_btnHide._visible = m_btnHide._x >= 0;			m_btnMinimize._visible = m_btnMinimize._x >= 0;			m_btnClose._visible = m_btnClose._x >= 0;

			//var data:Object = m_btnBack.getData();
			m_lblText._x = m_look.getMargin("left", m_data);
			m_lblText._y = m_look.getMargin("top", m_data);
			m_lblText.setSize(
				(m_btnHide._visible
					? m_btnHide._x
					: (m_btnMinimize._visible ? m_btnMinimize._x : m_btnClose._x))
					- m_lblText._x - 2
				, m_btnBack.getUserH()
			);
		}
		super.update();
	}

	//
	// PRIVATE METHODS
	//

	private function onDoubleClick():Void
	{
		if(m_btnMinimize._visible) fireEvent(m_btnMinimize.isSunken() ? "minimizeWindow" : "maximizeWindow");
	}

	private function movieMouseDown(bSkip:Boolean):Void
	{
		if(!bSkip)
			m_bMoveTitle = !(m_btnHide.isMouseOver() || m_btnMinimize.isMouseOver() || m_btnClose.isMouseOver());
		super.movieMouseDown(true);
	}

	private function movieMouseUp(bSkip:Boolean):Void
	{
		if(!bSkip) m_bMoveTitle = false;
		super.movieMouseUp(true);
	}

	private function movieMouseMove(bSkip:Boolean):Void
	{
		if(!bSkip)
		{
			if(m_bMoveTitle)
				fireEvent("moveWindow");
		}
		super.movieMouseMove(true);
	}

	private function onMaximize()
	{
		fireEvent(m_btnMinimize.isSunken() ? "maximizeWindow" : "minimizeWindow");
		m_btnMinimize.invokeEvent("showLayer");
	}
}