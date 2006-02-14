/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.BaseComboBox extends pseudo.ToggleButton
{
	private var m_list:pseudo.List;
	private var m_nSelId:Number;
	private var m_nListH:Number;
	private var m_arrData:Array;
	private var m_listMaxW:Number;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.BaseComboBox
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.BaseComboBox(pOwner[strName]);
		return pOwner[strName];
	}

	public function BaseComboBox(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.BaseComboBox;

		m_data.className = "BaseComboBox";
		m_data.type = "baseComboBox";
		m_nSelId = -1;
		m_nListH = 7;
		m_listMaxW = 0;
	}

	public function setListMaxW(maxW:Number):Void
	{
		m_listMaxW = maxW;
	}

	public function setListData(arrData:Array):Void
	{
		m_arrData = arrData;
		if(m_list) m_list.setListData(m_arrData);
	}

	public function getListData():Array
	{
		return m_arrData;
	}

	public function setSelId(nId:Number):Void
	{
		if(m_list._visible) m_list.setSelCell(nId, "over");
		m_nSelId = nId;
	}

	public function getSelId():Number
	{
		return m_nSelId;
	}

	public function getSelData():Object
	{
		return m_arrData[m_nSelId];
	}

	public function setListH(nH:Number):Void
	{
		m_nListH = nH;
	}

	public function update():Void
	{
		if(m_list) m_list.setSize(getListW(), calcListH());
		super.update();
	}

	public function remove():Void
	{
		_global.popup.removeItem(m_list.getName());
		super.remove();
	}

	//
	// PRIVATE METHODS
	//

	private function getListW():Number
	{
		var w:Number = Math.max(m_nW, m_list.getMinW());
		if(m_listMaxW) w = Math.min(w, m_listMaxW);
		return w;
	}

	private function setListVisibility(bShow:Boolean):Void
	{
		m_list._visible = bShow;
		if(bShow)
		{
			var pt:Object = new Object({x:0, y:0});
			localToGlobal(pt);
			_global.popup.globalToLocal(pt);
			m_list._x = pt.x;
			if(pt.y + m_list.getH() > Stage.height)
				m_list._y = pt.y - m_list.getH();
			else
				m_list._y = pt.y + m_nH;
			m_list.setSelCell(-1, "press");
			m_list.setSelCell(-1, "over");
			m_list.setSelCell(m_nSelId, "over");
			m_list.setSize(getListW(), calcListH());
			m_list.update();
			m_list.draw();
			Stage.addListener(this);
		}
		else Stage.removeListener(this);
		
	}

	private function movieMouseRelease(bSkip1:Boolean, bSkip2:Boolean, bSkip:Boolean):Void
	{
		if(!bSkip && isMouseOver())
		{
			if(!m_list)
			{
				var nDepth:Number = _global.popup.getNextHighestDepth();
				m_list = _global.popup.addItem(pseudo.List, "m_list" + nDepth, nDepth);
//				pseudo.List.create(_global.popup, "m_list" + nDepth, nDepth);
				m_list.setData({type:"comboBoxPane"});
				m_list.setName("list");
				m_list.setType("scroll");
				m_list.setCellClass(classes.CellText);
				m_list.setCellsDrawData({type:"comboBoxCell"});
				m_list.addListener("changed", this, onChangeVal);
				m_list.setLook(m_look);
				m_list.setListData(m_arrData);
				// this 2 lines are needed to draw selected item when the list is shown at the first time
				m_list.setSize(getListW(), calcListH());
				m_list.update();
				m_list._visible = false;
				m_arrItems.push(m_list);
			}
			setListVisibility(!m_list._visible);
		}
		super.movieMouseRelease(false, false, true);
	}

	private function onChangeVal():Void
	{
		setSelId(m_list.getSelId());
		setListVisibility(false);
		setState("normal");
		fireEvent("changed");
	}

	private function movieRollOver(bSkipParent:Boolean, bSkip:Boolean):Void
	{
		if(!bSkip) Mouse.removeListener(this);
		super.movieRollOver(false, true);
	}

	private function movieRollOut(bSkipParent:Boolean, bSkip:Boolean):Void
	{
		if(!bSkip && m_list._visible) Mouse.addListener(this);
		super.movieRollOut(false, true);
	}

	private function onMouseDown():Void
	{
		if(onRollOver && !m_list.isMouseOver())
		{
			setListVisibility(false);
			setState("normal");
			Mouse.removeListener(this);
		}
	}

	private function calcListH():Number
	{
		return Math.min(m_list.getMaxH(), m_look.getMargin("top", m_list.getData()) +
			m_list.getCellsH(m_nListH) + m_look.getMargin("bottom", m_list.getData()));
	}

	private function onResize():Void
	{
		setListVisibility(false);
		setState("normal");
	}
}