/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class classes.CellButton extends pseudo.BaseMovie
{
//	private var m_txtField:TextField;
	private var m_btn:MovieClip;//Button to display
	var m_lbl:pseudo.Label;//button label 
	static private var m_pTipOwner:pseudo.BaseMovie;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):classes.CellButton
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new classes.CellButton(pOwner[strName]);
		return pOwner[strName];
	}

	static public function getCellW(nW:Number):Number
	{
		return nW;
	}

	static public function getCellH(nH:Number, nW:Number, data:Object):Number
	{
		return 20;
	}

	public function CellButton(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = classes.CellButton;


		m_btn = pseudo.PushButton.create(pThis, "m_btn", 2);
	
		m_lbl = pseudo.Label(m_btn.addItem(pseudo.Label));

		m_btn.setSize(95, 18);
		m_btn._x = 1;
		m_arrItems.push(m_btn);
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
		if(!m_bUpdated)

		{
		//set the button label text when required
			if(m_data.text != objData.text && objData.text)
			{
			 m_lbl.setText(objData.text);
			}
		}
		super.setData(objData);
		
		
	}

	public function update():Void
	{
		if(!m_bUpdated)
		{
			m_nW = getCellW(m_nW);
			super.update();
		}
	}

	public function draw():Void
	{
		super.draw();
		var tip:pseudo.ToolTip = pseudo.ToolTip.getInstance();
		if(m_btn._width > m_nW && isMouseOver())
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