/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.BaseMovie extends MovieClip implements pseudo.IBroadcaster
{
	private var m_data:Object;
	private var m_nW:Number;
	private var m_nH:Number;
	private var m_bDrawn:Boolean;
	private var m_bUpdated:Boolean;
	private var m_nDrawnW:Number;
	private var m_nDrawnH:Number;
	private var m_look:Object;
	private var m_strBehavior:String;
	private var m_arrItems:Array;
	private var m_strName:String;
	private var m_bDrawHidden:Boolean;
	private var m_caster:pseudo.IBroadcaster;
	private var m_pClass:Function;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.BaseMovie
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.BaseMovie(pOwner[strName]);
		return pOwner[strName];
	}

	public function getClass():Function
	{
		return m_pClass;
	}

	public function BaseMovie(pThis:MovieClip)
	{
		if(!pThis) pThis = this;
		m_pClass = pseudo.BaseMovie;
		m_nW = 0;
		m_nH = 0;
		m_data = new Object();
		pThis.useHandCursor = false;
		m_bDrawn = false;
		m_bUpdated = false;
		m_look = null;
		m_nDrawnW = 0;
		m_nDrawnH = 0;
		m_strBehavior = "";
		m_arrItems = new Array();
		m_strName = null;
		m_bDrawHidden = false;
		m_caster = new pseudo.Broadcaster();
	}

	public function getParent(pClass:Function):MovieClip
	{
		var curMovie:MovieClip = this._parent;
		var curItem:MovieClip = curMovie;
		while(!curItem && curMovie._parent)
		{
			curMovie = curMovie._parent;
			curItem = MovieClip(pClass.call(curMovie, curMovie));
		}
		return curItem;
//		var movie:MovieClip = this._parent;
//		while(!(movie instanceof pClass) && movie._parent)
//			movie = movie._parent;
//		return movie;
	}

	public function getNextFreeDepth(depth:Number):Number
	{
		while(getInstanceAtDepth(depth)) depth++;
		return depth;
	}

	public function fireBroadEvent(strEvent:String):Boolean
	{
		m_caster.fireEvent.apply(Object(m_caster), arguments);
		var bRes:Boolean = false;
		var curMovie:MovieClip = getParent(pseudo.BaseMovie);
		while(!bRes && curMovie)
		{
			bRes = Boolean(curMovie.fireEvent.apply(curMovie, arguments));
			curMovie = curMovie.getParent(pseudo.BaseMovie);
		}
		return bRes;
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

	public function getMinW():Number
	{
		return m_look ? m_look.getMargin("left", m_data) +
			m_look.getMargin("right", m_data) : 0;
	}

	public function getMinH():Number
	{
		return m_look ? m_look.getMargin("top", m_data) +
			m_look.getMargin("bottom", m_data) : 0;
	}

	public function getMaxW():Number
	{
		return getMinW();
	}

	public function getMaxH():Number
	{
		return getMinH();
	}

	public function getPrefW():Number
	{
		return getMinW();
	}

	public function getPrefH():Number
	{
		return getMinH();
	}

	public function getBorderW():Number
	{
		return m_look.getMargin("left", m_data) + m_look.getMargin("right", m_data);
	}

	public function getBorderH():Number
	{
		return m_look.getMargin("top", m_data) + m_look.getMargin("bottom", m_data);
	}

	public function setUpdated(bUpdated:Boolean):Void
	{
		m_bUpdated = bUpdated;
	}

	public function isUpdated():Boolean
	{
		return m_bUpdated;
	}

	public function setDrawn(bDrawn:Boolean):Void
	{
		m_bDrawn = bDrawn;
	}

	public function isDrawn():Boolean
	{
		return m_bDrawn;
	}

	public function setName(strName:String):Void
	{
		m_strName = strName;
	}

	public function getName():String
	{
		return m_strName ? m_strName : _name;
	}

	public function setBehavior(strBehavior:String):Void
	{
		m_strBehavior = strBehavior;
	}

	public function getBehavior():String
	{
		return m_strBehavior;
	}

	public function setLook(look:Object):Void
	{
		m_look = look;
		for(var i:Number = 0; i < m_arrItems.length; i++)
			m_arrItems[i].setLook(look);
		m_bUpdated = false;
		m_bDrawn = false;
	}

	public function setData(data:Object, bRecreate:Boolean):Void
	{
		if(bRecreate)
		{
			delete m_data;
			m_data = new Object();
		}
		for(var item:String in data)
			if(m_data[item] != data[item])
			{
				m_bUpdated = false;
				m_data[item] = data[item];
			}
	}

	public function getData():Object
	{
		return m_data;
	}

	public function setW(nW:Number):Void
	{
		setSize(nW, m_nH);
	}

	public function getW():Number
	{
		return m_nW;
	}

	public function setH(nH:Number):Void
	{
		setSize(m_nW, nH);
	}

	public function getH():Number
	{
		return m_nH;
	}

	public function getUserW():Number
	{
		return m_nW - getBorderW();
	}

	public function getUserH():Number
	{
		return m_nH - getBorderH();
	}

	public function setSize(nW:Number, nH:Number):Void
	{
		if(m_nW != nW || m_nH != nH)
		{
			m_bUpdated = false;
			m_nW = nW;
			m_nH = nH;
			fireEvent("size");
		}
	}

	public function update():Void
	{
		if(!m_bUpdated) fireEvent("update", this, m_nW, m_nH);
		m_bUpdated = true;
		if(m_nDrawnW != m_nW || m_nDrawnH != m_nH)
			m_bDrawn = false;
		for(var i:Number = 0; i < m_arrItems.length; i++)
			m_arrItems[i].update();
	}

	public function isVisible():Boolean
	{
		return pseudo.Global.isVisible(this);
	}

	public function draw():Void
	{
		if(!m_bDrawn && (isVisible() || m_bDrawHidden))
		{
			m_bDrawn = true;
			m_nDrawnW = m_nW;
			m_nDrawnH = m_nH;
			m_look.draw(this, m_nW, m_nH, m_data);
		}
		for(var i:Number = 0; i < m_arrItems.length; i++)
			m_arrItems[i].draw();
	}

//	public function isMouseOver1(x:Number, y:Number, bShow:Boolean):Boolean
//	{
//		if(isNaN(x)) x = _root._xmouse;
//		if(isNaN(y)) y = _root._ymouse;
//		if(isVisible() && hitTest(x, y, true))
//		{
//			var movie:MovieClip = this;
//			while(movie)
//			{
//				if(movie._mask && !movie._mask.hitTest(x, y, false))
//					return false;
//				movie = movie._parent;
//			}
//			var bHit:Boolean = false;
//			for(var i:Number = 0; i < m_arrItems.length; i++)
//				if(m_arrItems[i].hitTest(x, y, true))
//				{
//					if(m_arrItems[i].isMouseOver1(x, y, bShow)) return true;
//					if(bShow) _root.trace(".." + m_arrItems[i].isMouseOver1() + " " + m_arrItems[i]);
//					bHit = true;
//				}
//			if(bHit) return false;
//			return true;
//		}
//		return false;
//	}

	public function isMouseOver(x:Number, y:Number):Boolean
	{
		if(isNaN(x)) x = _root._xmouse;
		if(isNaN(y)) y = _root._ymouse;
		if(isVisible() && hitTest(x, y, true))
		{
			var movie:MovieClip = this;
			while(movie)
			{
				if(movie._mask && !movie._mask.hitTest(x, y, false))
					return false;
				movie = movie._parent;
			}
			return true;
		}
		return false;
		//return isVisible() ? hitTest(_root._xmouse, _root._ymouse, true) : false; // xxx ignore masks
	}

	public function setVisible(bVisible):Void
	{
		_visible = bVisible;
	}

	public function drawRect(nX:Number, nY:Number, nW:Number, nH:Number, nColor:Number, nAlpha:Number):Void
	{
		pseudo.Global.drawRect(this, nX, nY, nW, nH, nColor, nAlpha);
	}

  public function drawFrame(nX1:Number, nY1:Number,
		nX2:Number, nY2:Number, clr:Number, nAlpha:Number, nSize:Number):Void
	{
		pseudo.Global.drawFrame(this, nX1, nY1, nX2, nY2, clr, nAlpha, nSize);
	}

	public function getValue():Object
	{
		return pseudo.Global.getValue.apply(this, arguments);
	}

/*	public function ptInRect(ptX:Number, ptY:Number,
		nX:Number, nY:Number, nW:Number, nH:Number):Boolean
	{
		return pseudo.Global.ptInRect(ptX, ptY, nX, nY, nW, nH);
	}
*/
	public function createLabel(strName:String, nDepth:Number):TextField
	{
		return pseudo.Global.createLabel(this, strName, nDepth);
	}

	public function isChildOf(movie:MovieClip):Boolean
	{
		var curMovie:MovieClip = this;
		while(curMovie)
		{
			if(curMovie._target == movie._target) return true;
			curMovie = curMovie._parent;
		}
		return false;
	}

	//
	// PRIVATE METHODS
	//

	private function isSameBranch(item:pseudo.BaseMovie):Boolean
	{
		return isChildOf(item) || item.isChildOf(this);
	}

	private function isBelow(item:pseudo.BaseMovie):Boolean
	{
		var curMovie:MovieClip = this;
		var curItem:MovieClip = item;
		var bExist:Boolean = false;
		while(curMovie)
		{
			curItem = item;
			while(curItem)
			{
				if(curItem._parent == curMovie._parent)
				{
					bExist = true;
					break;
				}
				curItem = curItem._parent;
			}
			if(bExist) break;
			curMovie = curMovie._parent;
		}
		return curItem && curMovie ? curItem.getDepth() < curMovie.getDepth() : false;
	}

	public function remove():Void
	{
		removeItems();
		delete m_arrItems;
		this.removeMovieClip();
	}

	public function addItem(pClass:Function, strName:String, nDepth:Number):pseudo.BaseMovie
	{
		var nId:Number = getItemId(strName);
		var item:pseudo.BaseMovie = null;
		if(!pClass) pClass = pseudo.BaseMovie;
		var arrArgs:Array = arguments.slice(1);
		arrArgs.unshift(this);
		if(nId >= 0)
		{
			if(!nDepth) nDepth = m_arrItems[nId].getDepth();
			m_arrItems[nId] = item = pClass.create.apply(pClass, arrArgs);
		}
		else
		{
			if(!nDepth) nDepth = getNextHighestDepth();
			item = pClass.create.apply(pClass, arrArgs);
			m_arrItems.push(item);
		}
		item.setLook(m_look);
		item.setName(strName);
		return item;
	}

	public function removeItem(strName:String):Void
	{
		if(strName)
			for(var i:Number = 0; i < m_arrItems.length; i++)
				if(strName == m_arrItems[i].getName())
				{
					m_arrItems[i].remove();
					m_arrItems.splice(i, 1);
					break;
				}
	}

	public function getItems():Array
	{
		return m_arrItems;
	}

	public function getItem(strName:String):pseudo.BaseMovie
	{
		if(!strName || strName == "") return null;
		for(var i:Number = 0; i < m_arrItems.length; i++)
			if(strName == m_arrItems[i].getName()) return m_arrItems[i];
		return null;
	}

	public function removeItems():Void
	{
		for(var i:Number = 0; i < m_arrItems.length; i++)
			m_arrItems[i].remove();
		m_arrItems.splice(0);
		m_bUpdated = false;
	}

	public function getItemId(strName:String):Number
	{
		for(var i:Number = 0; i < m_arrItems.length; i++)
			if(strName == m_arrItems[i].getName()) return i;
		return -1;
	}
}