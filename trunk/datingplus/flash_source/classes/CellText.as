/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class classes.CellText extends pseudo.BaseMovie
{
	private var m_txtField:TextField;
	static private var m_pTipOwner:pseudo.BaseMovie;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):classes.CellText
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new classes.CellText(pOwner[strName]);
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

	static public function getMinCellW(look:Object, data:Object):Number
	{
		var fld:TextField = _global.testLayer["fld"];
		if(!fld) return 0;
		fld.htmlText =
			look.getTextDecoration("open", data)
			+ (data.text ? data.text : "")
			+ look.getTextDecoration("close", data);
		return fld._width + 5;
	}

	public function CellText(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = classes.CellText;

		pThis.createTextField("m_txtField", 1, 0, 0, 0, 0);
		m_txtField = pThis["m_txtField"];
		m_txtField.selectable = false;
		m_txtField.autoSize = "left";
		m_txtField.html = true;
		m_txtField._x = 1;
		m_data.className = "CellText";
		m_data.type = "cellText";
		m_data.mode = "out";
	}

	public function setLook(look:Object):Void
	{
		super.setLook(look);
	}

	public function setData(objData:Object):Void
	{
		if(m_data.mode != objData.mode) m_bDrawn = false;
		super.setData(objData);
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
			super.update();
		}
	}

	public function draw():Void
	{
		super.draw();
		var tip:pseudo.ToolTip = pseudo.ToolTip.getInstance();
		if(m_txtField._width > m_nW && isMouseOver())
		{
			if(m_data.text && m_pTipOwner != this)
			{
				var pt:Object = new Object({x:1, y:0});
				localToGlobal(pt);
				tip.setData({type:m_data.type, mode:m_data.mode});
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