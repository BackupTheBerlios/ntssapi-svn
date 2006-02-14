/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.List extends pseudo.BaseComponent
{
	/** Array of visible cells */
	private var m_arrCells:Array;
	/** list data */
	private var m_arrData:Array;
	private var m_mcContent:MovieClip;
	private var m_mask:MovieClip;
	private var m_scrollVert:pseudo.ScrollBar;
	private var m_scrollHorz:pseudo.ScrollBar;
	private var m_pCellClass:Function;
	private var m_nPosX:Number;
	private var m_nPosY:Number;
	private var m_nFirstVisible:Number;
	private var m_nCurCell:Number;
	private var m_nSelCell:Number;
	private var m_nOldSel:Number;
	private var m_bParseMouse:Boolean;
	private var m_nCellH:Number;
	private var m_objCellsDrawData:Object;
	private var m_strType:String;
	private var m_arrCellsH:Array; // summary height of cells

	//
	// PUBLIC METHODS
	//

	/**
	 * Creates list.
	 * @param pOwner Parent of the list.
	 * @param strName List name.
	 * @param nDepth List movie depth.
	 * @return Created list.
	 */
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.List
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.List(pOwner[strName]);
		return pOwner[strName];
	}

	/**
	 * Constructor. You should create list by calling
	 * pseudo.List.create(...) instead of calling
	 * this constructor otherwise you can't have movie instance.
	 * @param pThis Pointer to this MovieClip.
	 */
	public function List(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.List;

		m_arrCells = new Array();
		pThis.createEmptyMovieClip("m_mcContent", 2);
		pThis.createEmptyMovieClip("m_mask", 1);
		pThis["m_mask"]._visible = false;
		pThis["m_mcContent"].setMask(pThis["m_mask"]);
		m_pCellClass = null;
		m_nPosX = m_nPosY = 0;
		m_data.mode = "out";
		m_nFirstVisible = 0;
		m_data.className = "List";
		m_nCurCell = m_nSelCell = m_nOldSel = -1;
		m_bParseMouse = true;
		m_nCellH = 20;
		m_strType = "menu";
		m_objCellsDrawData = new Object();
		m_arrCellsH = new Array();
	}

	public function getMinW():Number
	{
		var minW:Number = 0;
		for(var i:Number = 0; i < m_arrData.length; i++)
			minW = Math.max(minW, m_pCellClass.getMinCellW(m_look, m_arrData[i]));
		return minW + getBorderW();
	}

	public function setType(strType:String):Void
	{
		m_strType = strType;
	}

	public function setLook(look:Object):Void
	{
		super.setLook(look);
		for(var i:Number = 0; i < m_arrCells.length; i++)
			m_arrCells[i].setLook(look);
	}

	public function getUserW():Number
	{
		return super.getUserW() - (m_scrollVert ? m_scrollVert.getW() : 0);
	}

	public function getUserH():Number
	{
		return super.getUserH() - (m_scrollHorz ? m_scrollHorz.getH() : 0);
	}

	public function setCellH(nH:Number):Void
	{
		m_nCellH = nH;
	}

	public function setListData(arrData:Array):Void
	{
		m_arrData = arrData;
		m_nFirstVisible = 0;
		setUpdated(false);
	}

	public function getListData():Array
	{
		return m_arrData;
	}

	public function setUpdated(bUpdated:Boolean):Void
	{
		if(m_bUpdated != bUpdated)
		{
			if(!bUpdated)
				for(var i:Number = 0; i < m_arrCells.length; i++)
					m_arrCells[i].setUpdated(false);
		}
		super.setUpdated(bUpdated);
	}

	public function setCellClass(pClass:Function):Void
	{
		removeCells();
		m_pCellClass = pClass;
		m_bUpdated = false;
	}

	public function setPosX(nX:Number):Void
	{
		if(m_nPosX != nX)
		{
			m_nPosX = nX;
			for(var i:Number = 0; i < m_arrCells.length; i++)
				m_arrCells[i]._x = nX;
			// xxx make horz scroll
		}
	}

	public function setPosY(nY:Number):Void
	{
		if(m_nPosY != nY) m_nPosY = nY;
	}

	public function update():Void
	{
		if(!m_bUpdated)
		{
			recalcSumCellsH();
			var bVert:Boolean = m_scrollVert._visible;
			var bHorz:Boolean = m_scrollHorz._visible;
			// show vert scroll if we need it
			if(getCellsH() > getUserH())
			{
				createScrollVert();
				if(!bVert) recalcSumCellsH();
				m_scrollVert._y = m_look.getBorder("top", m_data);
				m_scrollVert._x = m_nW - m_scrollVert.getW() - m_look.getBorder("right", m_data);
				m_scrollVert.setRange(0, getCellsH());
				m_scrollVert.setPos(m_scrollVert.getPos());
			}
			else
			{
				m_scrollVert.remove();
				delete m_scrollVert;
			}
			// xxx calculate whether we need horz scroll
			var nUserW:Number = getUserW();
			var nCellW:Number = m_pCellClass.getCellW(nUserW, m_look);
			if(nCellW > nUserW)
			{
				createScrollHorz();
				if(!bHorz) recalcSumCellsH();
				m_scrollHorz._y = m_nH - m_look.getBorder("bottom", m_data) - m_scrollHorz.getH();
				m_scrollHorz._x = m_look.getBorder("right", m_data);
				m_scrollHorz.setRange(0, nCellW);
			}
			else
			{
				m_scrollHorz.remove();
				delete m_scrollHorz;
			}
			// update current scrollers
			if(m_scrollVert)
			{
				m_scrollVert.setH(getScrollH());
				m_scrollVert.setScrollSize(getUserH());
			}
			if(m_scrollHorz)
			{
				m_scrollHorz.setW(getScrollW());
				m_scrollHorz.setScrollSize(getUserW());
			}
			m_mask._x = m_mcContent._x = m_look.getMargin("left", m_data);
			m_mask._y = m_mcContent._y = m_look.getMargin("top", m_data);
			updateIndex();
			updateList();
			m_look.updateMask(m_mask, nUserW, getUserH(), m_data);
		}
		super.update();
	}

	public function draw():Void
	{
		super.draw();
		for(var i:Number = 0; i < m_arrCells.length; i++)
			m_arrCells[i].draw();
	}

	public function getSelData():Object
	{
		return (m_nSelCell > -1) ? m_arrData[m_nSelCell] : null;
	}

	public function setCellsDrawData(data:Object):Void
	{
		for(var i:String in data)
			m_objCellsDrawData[i] = data[i];
		m_bUpdated = false;
	}

	public function setSelCell(nCell:Number, mode:String):Void
	{
		if(!mode) mode = "press";
		if(nCell >= 0)
		{
			var curCell:pseudo.BaseMovie = m_arrCells[nCell - m_nFirstVisible];
			curCell.setData({mode:mode});
			curCell.update();
			curCell.draw();
			if(!m_bMouseDown && mode == "press") m_nOldSel = nCell; // set old selected cell id to the selected cell
		}
		else m_nOldSel = -1;
		var nThisCell:Number = mode == "press" ? m_nSelCell : m_nCurCell;
		if(nThisCell >= 0 && nThisCell != nCell)
		{
			var cell:pseudo.BaseMovie = m_arrCells[nThisCell - m_nFirstVisible];
			cell.setData({mode:(nThisCell == m_nCurCell && mode == "press") ? "over" : "out"});
			cell.update();
			cell.draw();
		}
		switch(mode)
		{
			case "press":
				m_nSelCell = nCell;
				break;
			case "over":
				m_nCurCell = nCell;
				break;
		}
	}

	public function getSelId():Number
	{
		return m_nSelCell;
	}

	public function getMaxH():Number
	{
		return getCellsH() + m_look.getMargin("top", m_data) + m_look.getMargin("bottom", m_data);
	}

	public function remove():Void
	{
		removeCells();
		delete m_arrCells;
		m_mcContent.remove();
		super.remove();
	}

	public function getCellsH(nId:Number):Number
	{
		var id:Number = (isNaN(nId) ? m_arrCellsH.length : Math.min(m_arrCellsH.length, nId)) - 1;
		return id < 0 ? 0 : m_arrCellsH[id];
	}

	//
	// PRIVATE METHODS
	//

	private function removeCells()
	{
		for(var i:Number = 0; i < m_arrCells.length; i++)
			m_arrCells[i].remove();
		m_arrCells.splice(0);
	}

	private function getPosX():Number
	{
		return m_scrollHorz ? m_scrollHorz.getPos() : 0;
	}

	private function getPosY():Number
	{
		return m_scrollVert ? m_scrollVert.getPos() : 0;
	}

	private function updateIndex():Void
	{
		for(var i:Number = 0; i < m_arrData.length; i++)
			m_arrData[i].ind = i;
	}

	private function updateList():Void
	{
		reworkCells();
		updateCells();
	}

	private function reworkCells():Void
	{
		// to avoid variances between visible space and current pos
		m_nPosY = -getPosY();
		setPosX(-getPosX());

		var nFirstVisible:Number = getFirstVisible(-m_nPosY);
		// number of shifted cells
		var nOff:Number = nFirstVisible - m_nFirstVisible;
		m_nFirstVisible = nFirstVisible;
		// number of cells
		var nNumOfCells:Number = Math.min(m_arrData.length, getFirstVisible(-m_nPosY + getUserH() - 1) + 1);
		// difference between number of existing and expected number of cells
		var nDiff:Number = nNumOfCells - m_arrCells.length - m_nFirstVisible;

		//
		// add/remove cells
		if(nDiff > 0)
		{ // add cells
			var nDepth:Number = m_mcContent.getNextHighestDepth();
			for(var i:Number = 0; i < nDiff; i++)
			{
				var cell:pseudo.BaseMovie = m_pCellClass.create(m_mcContent, "cell_" + nDepth, nDepth++);
				cell.setLook(m_look);
				nOff >= 0 ? m_arrCells.push(cell) : m_arrCells.unshift(cell);
			}
			if(nOff < 0) nOff += nDiff;
		}
		else if(nDiff < 0)
		{ // remove cells
			if(nOff > 0)
			{
				var count:Number = Math.min(nOff, -nDiff);
				for(var i:Number = 0; i < count; i++)
					m_arrCells[i].remove();
				m_arrCells.splice(0, count);
				nDiff += count;
				nOff -= count;
			}
			for(var i:Number = m_arrCells.length + nDiff; i < m_arrCells.length; i++)
				m_arrCells[i].remove();
			m_arrCells.splice(m_arrCells.length + nDiff);
		}
		//
		// re-sort current cells in array in order to occupy their places
		if(nOff > 0) // scroll down
		{ // xxx swap depths
			var last:Number = m_arrCells.length - 1;
			for(var i:Number = 0; i < nOff; i++)
			{
				m_arrCells.push(m_arrCells.shift());
				m_arrCells[last].setUpdated(false);
			}
		}
		else
		{ // xxx swap depths
			for(var i:Number = 0; i < -nOff; i++)
			{
				m_arrCells.unshift(m_arrCells.pop());
				m_arrCells[0].setUpdated(false);
			}
		}
	}

	private function updateCells():Void
	{
		// update all cells
		var nCurY:Number = m_nPosY + getCellsH(m_nFirstVisible);
		var nUserW:Number = getUserW();
		for(var i:Number = 0; i < m_arrCells.length; i++)
		{
			var id:Number = m_nFirstVisible + i;
			var cell:pseudo.BaseMovie = m_arrCells[i];
			if(!cell.isUpdated())
			{
				cell.setData(m_objCellsDrawData, true);
				cell.setData(m_arrData[id]);
			}
			cell.setData({mode:id == m_nSelCell ? "press" : (id == m_nCurCell ? "over" : "out")});
			if(!(m_bUpdated && cell.isUpdated())) cell.setSize(nUserW, m_nCellH);
			cell.update();
			cell._y = nCurY;
			nCurY += cell.getH();
		}
	}

	private function getScrollW():Number
	{
		return m_nW - (m_scrollVert ? m_scrollVert.getW() : 0) -
			m_look.getBorder("left", m_data) -
			m_look.getBorder("right", m_data);
	}

	private function getScrollH():Number
	{
		return m_nH - (m_scrollHorz ? m_scrollHorz.getH() : 0) -
			m_look.getBorder("top", m_data) -
			m_look.getBorder("bottom", m_data);
	}

	private function onScrollHorz():Void
	{
		setPosX(-m_scrollHorz.getPos());
	}

	private function onScrollVert():Void
	{
		setPosY(-m_scrollVert.getPos());
		updateList();
		draw();
	}

	private function contentRollOut():Void
	{
		var curCell:pseudo.BaseMovie = m_arrCells[m_nCurCell - m_nFirstVisible];
		if(m_strType == "menu")
		{
			if(m_nCurCell != m_nSelCell)
			{
				curCell.setData({mode:"out"});
				curCell.update();
			}
			m_nCurCell = -1;
		}
		curCell.draw();
	}

	private function movieRollOut(bSkip:Boolean):Void
	{
		if(!bSkip && m_nCurCell > -1)
			contentRollOut();
		super.movieRollOut(true);
	}

	private function movieMouseDown(bSkip:Boolean):Void
	{
		if(!bSkip)
		{
			m_bParseMouse = m_mask.hitTest(_root._xmouse, _root._ymouse);
			m_bMouseDown = true; // this line is needed for setSelCell, to correctly change m_nOldCell value
			if(m_bParseMouse && m_nCurCell > -1) setSelCell(m_nCurCell);
		}
		super.movieMouseDown(true);
	}

	private function movieMouseUp(bSkip:Boolean):Void
	{
		if(!bSkip)
		{
			if(/*m_nOldSel != m_nSelCell && */m_nSelCell > -1 && m_bParseMouse && m_nCurCell > -1)//m_nCurCell > -1 && m_mask.hitTest(_root._xmouse, _root._ymouse))
			{
				m_nOldSel = m_nSelCell;
				fireEvent("changed");
			}
			m_bParseMouse = true;
		}
		super.movieMouseUp(true);
	}

	private function refreshList():Void
	{
		var nCell:Number = getCellIdFromCursor();
		var selCell:pseudo.BaseMovie = m_arrCells[m_nSelCell - m_nFirstVisible];
		if(m_bMouseDown && nCell > -1 && m_nSelCell != nCell)
		{
			selCell.setData({mode:"out"});
			selCell.update();
			m_nSelCell = nCell;
		}
		selCell.draw();
		// not pressed cells
		if(nCell > -1)
		{
			var cell:pseudo.BaseMovie = m_arrCells[nCell - m_nFirstVisible];
			var strMode:String = m_bMouseDown || m_nSelCell == nCell ? "press" : "over";
			if(strMode != cell.getData().mode)
			{
				cell.setData({mode:strMode});
				cell.update();
			}
			cell.draw(); // we have to show tooltip if possible
		}
		if(nCell > -1 || m_strType == "menu")
		{
			var curCell:pseudo.BaseMovie = null;
			if(m_nCurCell > -1 && m_nCurCell != nCell && m_nCurCell != m_nSelCell)
			{
				curCell = m_arrCells[m_nCurCell - m_nFirstVisible];
				curCell.setData({mode:"out"});
				curCell.update();
			}
			if(curCell) curCell.draw(); // we have to show tooltip if possible
			m_nCurCell = nCell;
		}
	}

	private function movieMouseMove(bSkip:Boolean):Void
	{
		if(!bSkip)
		{
			if(m_bParseMouse && m_mask.hitTest(_root._xmouse, _root._ymouse))
				refreshList();
			else
			{
				m_arrCells[m_nCurCell - m_nFirstVisible].draw(); // hide tooltip
				contentRollOut();
			}
		}
		super.movieMouseMove(true);
	}

	private function getCellIdFromCursor():Number
	{
		for(var i:Number = 0; i < m_arrCells.length; i++)
			if(m_arrCells[i].isMouseOver()) return i + m_nFirstVisible;
		return -1;
	}

	// cell's position calculating routine
	// (getCellsH is public now)

	private function recalcSumCellsH():Void
	{
		var userW:Number = getUserW();
		m_arrCellsH.splice(0);
		var nSum:Number = 0;
		for(var i:Number = 0; i < m_arrData.length; i++)
		{
			nSum += m_pCellClass.getCellH(m_nCellH, userW, m_look, m_arrData[i]);
			m_arrCellsH[i] = nSum;
		}
	}

	private function getFirstVisible(nH:Number):Number
	{
		var i:Number;
		for(i = 0; i < m_arrCellsH.length; i++)
			if(m_arrCellsH[i] > nH) break;
		return i;
	}

	private function createScrollHorz():Void
	{
		if(!m_scrollHorz)
		{
			m_scrollHorz = pseudo.ScrollBar.create(this, "m_scrollHorz", 3);
			m_scrollHorz.setLook(m_look);
			m_scrollHorz.setName("scrollHorz");
			m_scrollHorz.setAlign("horz");
			m_scrollHorz.setH(15);
			m_scrollHorz.addListener("changePos", this, onScrollHorz);
			m_arrItems.push(m_scrollHorz);
		}
	}

	private function createScrollVert():Void
	{
		if(!m_scrollVert)
		{
			m_scrollVert = pseudo.ScrollBar.create(this, "m_scrollVert", 4);
			m_scrollVert.setLook(m_look);
			m_scrollVert.setName("scrollVert");
			m_scrollVert.setW(15);
			m_scrollVert.addListener("changePos", this, onScrollVert);
			m_arrItems.push(m_scrollVert);
		}
	}
}