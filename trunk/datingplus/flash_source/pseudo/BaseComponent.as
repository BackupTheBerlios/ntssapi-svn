/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.BaseComponent extends pseudo.BaseMovie
{
	private var m_bMouseDown:Boolean;
	private var m_bDragOut:Boolean;
	private var m_nLock:Number;
	private var m_nClickCount:Number; // used to generate double click
	private var m_nTimerNum:Number; // timer number
	private var m_nLastX:Number;
	private var m_nLastY:Number;
	static private var m_arrActiveItems:Array = new Array();

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.BaseComponent
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.BaseComponent(pOwner[strName]);
		return pOwner[strName];
	}

	public function BaseComponent(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.BaseComponent;

		pThis.onRollOver = componentRollOver;
		m_bMouseDown = false;
		m_bDragOut = false;
		m_nLock = 0;
		m_nClickCount = 0;
		m_nTimerNum = null;
		m_strBehavior = "component";
	}

	public function isMouseDown():Boolean
	{
		return m_bMouseDown;
	}

	public function invokeEvent(event:String):Void
	{
		switch(event)
		{
			case "rollOver":
				movieRollOver();
				break;
			case "rollOut":
				movieRollOut();
				break;
			case "componentRollOver":
				componentRollOver();
				break;
			case "componentRollOut":
				componentRollOut();
				break;
			case "mouseDown":
				movieMouseDown();
				break;
			case "mouseUp":
				movieMouseUp();
				break;
			case "mouseMove":
				movieMouseMove();
				break;
			case "dragOver":
				movieDragOver();
				break;
			case "dragOut":
				movieDragOut();
				break;
		}
	}

	public function remove():Void
	{
		componentRollOut();
		super.remove();
	}

	public function getLock():Number
	{
		return m_nLock;
	}

	public function setLock(nVal:Number):Void
	{
		m_nLock = nVal;
	}

	public function setVisible(bVisible:Boolean):Void
	{
		super.setVisible(bVisible);
		if(!bVisible)
		{
			componentRollOut();
			for(var i:Number = 0; i < m_arrItems.length; i++)
				m_arrItems[i].componentRollOut();
		}
	}

	//
	// PRIVATE METHODS
	//

	private function componentRollOver():Void
	{
		if(m_nLock == 0)
		{
			if(m_strBehavior == "component" || m_strBehavior == "pureComponent") addActiveItem(this);
			if(m_nLock == 0) // m_nLock can be changed
				movieRollOver();
		}
	}

	private function movieRollOver():Void
	{
		delete onRollOver;
		onMouseDown = movieMouseDown;
		onMouseUp = movieMouseUp;
		onMouseMove = movieMouseMove;
		fireEvent("rollOver");
	}

	private function movieMouseDown():Void
	{
		m_bMouseDown = true;
		fireEvent("mouseDown");

		// double click check
		var dx:Number = m_nLastX - _root._xmouse;
		var dy:Number = m_nLastY - _root._ymouse;
		if(dx * dx + dy * dy > 16) m_nClickCount = 0; // 4 px radius
		m_nLastX = _root._xmouse;
		m_nLastY = _root._ymouse;
		if(m_nTimerNum) clearInterval(m_nTimerNum);
		m_nTimerNum = setInterval(this, "clearClicks", 400);
	}

	private function movieMouseUp():Void
	{
		fireEvent("mouseUp");
		m_bMouseDown = false;
		if(isMouseOver())
			movieMouseRelease();
		else
			componentRollOut();
		m_bDragOut = false;

		// double click check
		if(m_nTimerNum)
		{
			clearInterval(m_nTimerNum);
			m_nClickCount++;
			if(m_nClickCount == 2)
			{
				movieDblClick();
				m_nClickCount = 0;
			}
			else
				m_nTimerNum = setInterval(this, "clearClicks", 400);
		}
	}

	private function clearClicks()
	{
		m_nClickCount = 0;
		clearInterval(m_nTimerNum);
		m_nTimerNum = null;
	}

	private function movieDblClick():Void
	{
		fireEvent("doubleClick");
	}

	private function movieMouseRelease():Void
	{
		fireEvent("mouseRelease");
	}

	private function movieMouseMove():Void
	{
		if(isMouseOver())
		{
			if(m_bDragOut && m_bMouseDown)
				movieDragOver();
		}
		else
		{
			if(m_bMouseDown)
			{
				if(!m_bDragOut)
					movieDragOut();
			}
			else
				componentRollOut();
		}
		fireEvent("mouseMove");
	}

	private function movieDragOver():Void
	{
		m_bDragOut = false;
		fireEvent("dragOver");
	}

	private function movieDragOut():Void
	{
		m_bDragOut = true;
		fireEvent("dragOut");
	}

	private function componentRollOut():Void
	{
		if(m_strBehavior == "component" || m_strBehavior == "pureComponent") removeActiveItem(this);
		movieRollOut();
	}

	private function movieRollOut():Void
	{
		onRollOver = componentRollOver;
		m_bMouseDown = false;
		m_bDragOut = false;
		delete onMouseDown;
		delete onMouseUp;
		delete onMouseMove;
		fireEvent("rollOut");
		//for(var i:Number = 0; i < m_arrItems.length; i++)
		//	m_arrItems.invokeEvent("rollOut");
	}

	static private function addActiveItem(item:pseudo.BaseComponent):Void
	{
		if(item.getBehavior() == "pureComponent")
		{
			var curItem:pseudo.BaseComponent = pseudo.BaseComponent(item.getParent(pseudo.BaseComponent));
			var nLock:Number = curItem.getLock();
			curItem.setLock(nLock + 1);
			if(nLock == 0) curItem.invokeEvent("rollOut");
//			var curItem:pseudo.BaseComponent = pseudo.BaseComponent(item.getParent(pseudo.BaseComponent));
//			while(curItem)
//			{
//				curItem = pseudo.BaseComponent(item.getParent(pseudo.BaseComponent));
//				var nLock:Number = curItem.getLock();
//				if(nLock == 0) curItem.invokeEvent("rollOut");
//				curItem.setLock(nLock + 1);
//			}
		}
		for(var i:Number = 0; i < m_arrActiveItems.length; i++)
		{
			var curItem:pseudo.BaseComponent = m_arrActiveItems[i];
			if(!curItem.isSameBranch(item))
			{
				if(curItem.isBelow(item)) // item is below
					item.setLock(item.getLock() + 1);
				else
				{ // item is higher
					var nLock:Number = curItem.getLock();
					curItem.setLock(nLock + 1);
					if(nLock == 0) curItem.invokeEvent("rollOut");
				}
			}
		}
		m_arrActiveItems.unshift(item);
	}

	static private function removeActiveItem(item:pseudo.BaseComponent):Void
	{
		var bExist:Boolean = false;
		for(var i:Number = 0; i < m_arrActiveItems.length; i++)
			if(m_arrActiveItems[i] == item)
			{
				m_arrActiveItems.splice(i--, 1);
				bExist = true;
				break;
			}
		if(!bExist) return;
		if(item.getBehavior() == "pureComponent")
		{
			var curItem:pseudo.BaseComponent = pseudo.BaseComponent(item.getParent(pseudo.BaseComponent));
			var nLock:Number = curItem.getLock();
			curItem.setLock(nLock - 1);
			if(nLock == 1)
			{
				if(curItem.isMouseOver()) curItem.invokeEvent("rollOver");
				else removeActiveItem(curItem);
			}
		}
		for(var i:Number = 0; i < m_arrActiveItems.length; i++)
		{
			var curItem:pseudo.BaseComponent = m_arrActiveItems[i];
			if(!curItem.isSameBranch(item))
			{
				var nLock:Number = curItem.getLock();
				if(item.getLock() < nLock)
				{
					curItem.setLock(nLock - 1);
					if(nLock == 1)
					{
						if(curItem.isMouseOver())
							curItem.invokeEvent("rollOver");
						else
						{
							removeActiveItem(curItem);
							i = -1;
						}
					} // if(nLock == 1)
				} // if(item.getLock() < nLock)
			} // if(!m_arrActiveItems[i].isSameBranch(item))
		}
		item.setLock(0);
	}
}