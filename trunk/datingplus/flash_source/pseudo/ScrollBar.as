/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.ScrollBar extends pseudo.BaseComponent
{
	private var m_nCurPos:Number;
	private var m_nMinPos:Number;
	private var m_nMaxPos:Number;
	private var m_nSmallScroll:Number;
	private var m_nBigScroll:Number;
	private var m_nScrollSize:Number;
	private var m_bVert:Boolean;
	private var m_btnBack:pseudo.PushButton; // scrollbar background
	private var m_btnLow:pseudo.PushButton;
	private var m_btnHi:pseudo.PushButton;
	private var m_btnScroll:pseudo.PushButton;
	private var m_btnLast:pseudo.Button;
	private var m_strLastType:String;
	private var m_nDX:Number; // mouse offset from m_btnScroll._x
	private var m_nDY:Number; // mouse offset from m_btnScroll._y
	private var m_nTimer:Number;
	private var m_bTimerRep:Boolean;
	private var m_nTimerRep:Number;
	private var m_clrBg:Number;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.ScrollBar
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.ScrollBar(pOwner[strName]);
		return pOwner[strName];
	}

	public function ScrollBar(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.ScrollBar;

		m_bVert = true;
		m_nMinPos = 0;
		m_nMaxPos = 0;
		m_nSmallScroll = 10;
		m_nScrollSize = 0;
		m_nBigScroll = 40;
		m_nCurPos = 0;
		m_btnBack = pseudo.PushButton.create(pThis, "m_btnBack", 2);
		m_btnBack.setData({type:"scrollBack", dir:"vert"});
		m_btnBack.setName("btnBack");
		m_btnLow = pseudo.PushButton.create(pThis, "m_btnLow", 3);
		m_btnLow.setData({type:"scrollLow", dir:"vert"});
		m_btnLow.setName("btnLow");
		m_btnHi = pseudo.PushButton.create(pThis, "m_btnHi", 4);
		m_btnHi.setData({type:"scrollHi", dir:"vert"});
		m_btnHi.setName("btnHi");
		m_btnScroll = pseudo.PushButton.create(pThis, "m_btnScroll", 5);
		m_btnScroll.setData({type:"scroll", dir:"vert"});
		m_btnScroll.setName("btnScroll");
		m_btnScroll._visible = false;
		m_btnLast = null;
		m_nTimer = null;
		m_strLastType = null;
		m_nDX = -1;
		m_nDY = -1;
		m_bTimerRep = false;
		m_nTimerRep = null;
		m_arrItems.push(m_btnBack, m_btnLow, m_btnHi, m_btnScroll);
	}

	public function setData(data:Object):Void
	{
		super.setData(data);
		m_btnBack.setData({type:data.type});
	}

	public function setRange(nMin:Number, nMax:Number):Void
	{
		m_nMinPos = nMin;
		m_nMaxPos = nMax;
		m_bUpdated = false;
		m_nScrollSize = Math.min(nMax - nMin, m_nScrollSize);
		if(m_nScrollSize = 0) m_btnScroll._visible = false;
		else m_btnScroll._visible = true;
		setPos(Math.min(Math.max(nMin, m_nCurPos), nMax));
	}

	public function setSmallScroll(nScroll:Number):Void
	{
		m_nSmallScroll = nScroll;
	}

	public function setBigScroll(nScroll:Number):Void
	{
		m_nBigScroll = nScroll;
	}

	public function doScroll(type:String, dir:String):Void
	{
		switch(type)
		{
			case "small":
				setPosCallback(m_nCurPos + (dir == "increase" ? 1 : -1) * m_nSmallScroll);
				break;
			case "big":
				setPosCallback(m_nCurPos + (dir == "increase" ? 1 : -1) * m_nBigScroll);
				break;
			case "bigscroll":
				if(getButtonFromPoint(_root._xmouse, _root._ymouse, false) != m_btnScroll)
					setPosCallback(m_nCurPos + (dir == "increase" ? 1 : -1) * m_nBigScroll);
				break;
		}
	}

	public function setPos(nPos:Number):Boolean
	{
		nPos = Math.max(m_nMinPos, Math.min(m_nMaxPos - m_nScrollSize, nPos));
		var bRes:Boolean = m_nCurPos != nPos;
		m_nCurPos = nPos;
		if(m_bVert)
		{
			m_btnScroll._y = m_btnLow.getH() +
				Math.round((m_nH - m_btnLow.getH() - m_btnHi.getH() - m_btnScroll.getH()) *
				(m_nCurPos - m_nMinPos) / (m_nMaxPos - m_nMinPos - m_nScrollSize));
		}
		else
		{
			m_btnScroll._x = m_btnLow.getW() +
				Math.round((m_nW - m_btnLow.getW() - m_btnHi.getW() - m_btnScroll.getW()) *
				(m_nCurPos - m_nMinPos) / (m_nMaxPos - m_nMinPos - m_nScrollSize));
		}
		return bRes;
	}

	public function getPos():Number
	{
		return m_nCurPos;
	}

	public function getMaxPos():Number
	{
		return m_nMaxPos;
	}

	public function getMinPos():Number
	{
		return m_nMinPos;
	}

	public function setScrollSize(nSize:Number):Void
	{
		m_nScrollSize = Math.min(m_nMaxPos - m_nMinPos, nSize);
		m_nBigScroll = nSize;
		rearrangeScroll();
	}

	public function setAlign(strAlign:String):Void
	{
		if(strAlign == "horz") m_bVert = false;
		else m_bVert = true;
		m_btnLow.setData({dir:strAlign});
		m_btnHi.setData({dir:strAlign});
		m_btnScroll.setData({dir:strAlign});
		m_btnBack.setData({dir:strAlign});
	}

	public function update():Void
	{
		if(!m_bUpdated)
		{
			m_btnBack.setSize(m_nW, m_nH);
			rearrangeButtons();
		}
		super.update();
	}

	public function remove():Void
	{
		clearTimer();
		super.remove();
	}

	//
	// PRIVATE METHODS
	//
	private function setPosFromPoint(nX:Number, nY:Number):Void
	{
		var nPos:Number = 0;
		if(m_bVert)
		{
			var nDiv:Number = m_nH - m_btnLow.getH() - m_btnHi.getH() - m_btnScroll.getH();
			if(nDiv)
				setPosCallback(m_nMinPos + Math.round((m_nMaxPos - m_nMinPos - m_nScrollSize) * (nY - m_btnLow.getH()) / nDiv));
			else setPosCallback(nY > m_btnLow.getH() ? m_nMaxPos : m_nMinPos);
		}
		else
		{
			var nDiv:Number = m_nW - m_btnLow.getW() - m_btnHi.getW() - m_btnScroll.getW();
			if(nDiv)
				setPosCallback(m_nMinPos + Math.round((m_nMaxPos - m_nMinPos - m_nScrollSize) * (nX - m_btnLow.getW()) / nDiv));
			else setPosCallback(nX > m_btnLow.getH() ? m_nMaxPos : m_nMinPos);
		}
	}

	private function setPosCallback(nPos:Number):Boolean
	{
		if(!setPos(nPos)) return false;
		fireEvent("changePos");
		return true;
	}

	private function rearrangeScroll():Void
	{
		var nSize:Number;
		var curSize:Number;
		if(m_bVert)
		{
			curSize = Math.round((m_nH - m_btnLow.getH() - m_btnHi.getH()) *
				m_nScrollSize / (m_nMaxPos - m_nMinPos));
			curSize = Math.max(10, curSize);
			nSize = Math.max(10, m_nW);
			m_btnScroll.setSize(nSize, curSize);
		}
		else
		{
			curSize = Math.round((m_nW - m_btnLow.getW() - m_btnHi.getW()) *
				m_nScrollSize / (m_nMaxPos - m_nMinPos));
			curSize = Math.max(10, curSize);
			nSize = Math.max(10, m_nH);
			m_btnScroll.setSize(curSize, nSize);
		}
		setPos(m_nCurPos);
	}

	private function rearrangeButtons():Void
	{
		var nSize:Number;
		if(m_bVert)
		{
			nSize = Math.max(10, Math.min(20, m_nW));
			m_btnHi._y = m_nH - nSize;
			m_btnHi._x = 0;
			m_btnLow.setSize(m_nW, nSize);
			m_btnHi.setSize(m_nW, nSize);
			m_btnScroll._x = 0;
		}
		else
		{
			nSize = Math.max(10, Math.min(20, m_nH));
			m_btnHi._x = m_nW - nSize;
			m_btnHi._y = 0;
			m_btnLow.setSize(nSize, m_nH);
			m_btnHi.setSize(nSize, m_nH);
			m_btnScroll._y = 0;
		}
		rearrangeScroll();
	}

	private function getTypeFromPoint(nX:Number, nY:Number):String
	{
		var strType:String = null;
		if(m_btnHi.isMouseOver()) strType = "hi";
		else if(m_btnLow.isMouseOver()) strType = "low";
		else if(m_btnScroll.isMouseOver()) strType = "scroll";
		else if(m_btnBack.isMouseOver())
		{
			if(m_bVert)
			{
				if(nY < m_btnScroll._y) strType = "overscroll";
				else strType = "belowscroll";
			}
			else
			{
				if(nX < m_btnScroll._x) strType = "overscroll";
				else strType = "belowscroll";
			}
		}
		return strType;
	}

	private function getButtonFromPoint(nX:Number, nY:Number):pseudo.Button
	{
		if(m_btnHi.isMouseOver()) return m_btnHi;
		if(m_btnLow.isMouseOver()) return m_btnLow;
		if(m_btnScroll.isMouseOver()) return m_btnScroll;
		if(m_btnBack.isMouseOver()) return m_btnBack;
		return null;
	}

	private function clearTimer():Void
	{
		if(m_nTimer) clearInterval(m_nTimer);
		m_nTimer = null;
		if(m_nTimerRep) clearInterval(m_nTimerRep);
		m_nTimerRep = 0;
		m_bTimerRep = false;
	}

	private function doImmedScroll(btnCur:MovieClip):Void
	{
		if(btnCur == m_btnLow)
			doScroll("small", "decrease");
		else if(btnCur == m_btnHi)
			doScroll("small", "increase");
		else if(btnCur == m_btnBack)
		{
			var strType:String = getTypeFromPoint(_xmouse, _ymouse);
			if(strType == m_strLastType)
			{
				var dir:String = strType == "overscroll" ? "decrease" : "increase";
				doScroll("bigscroll", dir);
			}
		}
	}

	private function clearTimers():Void
	{
		if(m_nTimer)
		{
			clearInterval(m_nTimer);
			m_nTimer = null;
		}
		if(m_nTimerRep)
		{
			clearInterval(m_nTimerRep);
			m_nTimerRep = null;
			m_bTimerRep = true;
		}
	}

	private function updateTimers(btnCur:MovieClip):Void
	{
		if(m_nTimer) clearInterval(m_nTimer);
		m_nTimer = null;

		if(m_nTimerRep)
		{
			clearInterval(m_nTimerRep);
			m_bTimerRep = true;
			m_nTimerRep = null;
			doImmedScroll(btnCur);
		}
		if(!m_bTimerRep)
		{
			m_nTimerRep = setInterval(this, "updateTimers", 400, btnCur);
			return;
		}
		if(btnCur == m_btnLow)
			m_nTimer = setInterval(this, "doScroll", 50, "small", "decrease");
		else if(btnCur == m_btnHi)
			m_nTimer = setInterval(this, "doScroll", 50, "small", "increase");
		else if(btnCur == m_btnBack)
		{
			var strType:String = getTypeFromPoint(_xmouse, _ymouse);
			if(strType == m_strLastType)
			{
				var dir:String = strType == "overscroll" ? "decrease" : "increase";
				m_nTimer = setInterval(this, "doScroll", 50, "bigscroll", dir);
			}
		}
	}

	private function movieMouseMove(bSkip:Boolean):Void
	{
		super.movieMouseMove(true);
		if(bSkip) return; // to avoid double calling of this function
		var btnCur = getButtonFromPoint(_root._xmouse, _root._ymouse);
		if(m_bMouseDown)
		{
			if(m_btnLast == m_btnScroll)
			{
				setPosFromPoint(_xmouse - m_nDX, _ymouse - m_nDY);
				m_btnLast.showLayer("press");
			}
			else if(btnCur != m_btnLast)
				clearTimers();
			else
			{
				if(!m_nTimerRep && !m_nTimer)
				{
					doImmedScroll(btnCur);
					updateTimers(btnCur);
				}
			}
		}
	}

	private function movieMouseDown(bSkip:Boolean):Void
	{
		if(!bSkip)
		{
			m_btnLast = getButtonFromPoint(_root._xmouse, _root._ymouse);
			m_strLastType = getTypeFromPoint(_xmouse, _ymouse);
			updateTimers(m_btnLast);
			m_nDX = -1;
			m_nDY = -1;
			if(m_btnLast == m_btnScroll)
			{
				m_nDX = _xmouse - m_btnScroll._x;
				m_nDY = _ymouse - m_btnScroll._y;
			}
			else
				doImmedScroll(m_btnLast);
		}
		super.movieMouseDown(true);
	}

	private function movieMouseUp(bSkip:Boolean):Void
	{
		if(!bSkip)
		{
			clearTimer();
			var btnCur = getButtonFromPoint(_root._xmouse, _root._ymouse);
			if(btnCur == null) movieRollOut();
			if(m_btnLast && m_btnLast != btnCur) m_btnLast.showLayer("out");
			if(btnCur) btnCur.showLayer("over");
			m_btnLast = btnCur;
		}
		super.movieMouseUp(true);
	}
}