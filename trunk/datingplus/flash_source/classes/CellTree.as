/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class classes.CellTree extends pseudo.BaseMovie
{
	static private var m_pTipOwner:pseudo.BaseMovie;
	private var m_txtField:TextField;
	//private var m_btnTree:pseudo.PushButton;
	private var m_icon:pseudo.BaseMovie;


	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):classes.CellTree
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new classes.CellTree(pOwner[strName]);
		return pOwner[strName];
	}

	static public function getCellW(nW:Number):Number
	{
		return nW;
	}

	static public function getCellH(nH:Number, nW:Number, look:Object, data:Object):Number
	{
		return 20;
	}

	public function CellTree(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = classes.CellText;

		pThis.createTextField("m_txtField", 1, 0, 0, 0, 0);
		m_txtField = pThis["m_txtField"];
		m_txtField.selectable = false;
		m_txtField.autoSize = "left";
		m_txtField.html = true;
		m_data.className = "CellTree";
		m_data.type = "cellTree";
		m_data.mode = "out";
	}

	public function setLook(look:Object):Void
	{
		super.setLook(look);
	}

	public function setData(data:Object, bRecreate:Boolean):Void
	{
		if(m_data.mode != data.mode) m_bDrawn = false;
		if(/*m_data.cellType === 0 && */m_data.icon)
		{
			if(!m_icon)
			{
				m_icon = addItem(pseudo.BaseMovie, "icon");
				var params:Object = m_look.getParams(m_data);
				m_icon.setSize(params.iconW, params.iconH);
				m_icon.getData().type = "iconLayer";
			}
			m_icon.getData().icon = m_data.icon;
			m_icon.update();
			m_icon.draw();
		}
		else
		{
			removeItem("icon");
			delete m_icon;
		}
		/*if(m_data.hasChildren || m_data.cellType == 1)
		{
			m_btnTree = pseudo.PushButton.create(this, "btnTree", 2);
			m_btnTree.setLook(m_look);
			m_arrItems.push(m_btnTree);
			m_bUpdated = false;
		}
		else
		{
			removeItem(m_btnTree.getName());
			delete m_btnTree;
			m_bUpdated = false;
		}*/
		super.setData(data, bRecreate);
		if(bRecreate)
		{
			m_data.className = "CellTree";
			m_data.type = "cellTree";
		}
	}

	public function update():Void
	{
		if(!m_bUpdated)
		{
			m_nW = getCellW(m_nW);
			m_txtField.htmlText =
				m_look.getTextDecoration("open", m_data) +
				(m_data.text ? m_data.text : "") +
				m_look.getTextDecoration("close", m_data);
			var params:Object = m_look.getParams(m_data);
			//m_btnTree.setSize(9, 9);
			var x:Number = params.offStart + (m_data.depth + 1) * params.off + 3;
			if(m_data.icon)
			{
				m_icon._x = x;
				m_icon._y = Math.round((m_nH - params.iconH) / 2);
				m_txtField._x = x + params.iconW + 3;
			}
			else m_txtField._x = x;
			//m_btnTree._x = x - 16;
			//m_btnTree._y = Math.round((m_nH - m_btnTree.getH()) / 2);
			super.update();
		}
	}

	public function draw():Void
	{
		super.draw();
		var tip:pseudo.ToolTip = pseudo.ToolTip.getInstance();
		if(m_txtField._x + m_txtField._width > m_nW && isMouseOver())
		{
			if(m_data.text && m_pTipOwner != this)
			{
				var pt:Object = new Object({x:m_txtField._x, y:0});
				localToGlobal(pt);
				tip.setData(m_data);
				tip.show(m_data.text, pt.x, pt.y);
			}
			m_pTipOwner = this;
		}
		else if(m_pTipOwner == this)
		{
			m_pTipOwner = null;
			tip.hide();
		}
	}
}