/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.Label extends pseudo.BaseComponent
{
	private var m_mcTextHolder:MovieClip;
	private var m_fldText:TextField;
	private var m_layerMask:MovieClip;
	private var m_strAlign:String;
	private var m_strVAlign:String;
	private var m_bAutoSize:Boolean;
	private var m_strText:String;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.Label
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.Label(pOwner[strName]);
		return pOwner[strName];
	}

	public function Label(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.Label;

		pThis.createEmptyMovieClip("m_mcTextHolder", 2);
		pThis["m_mcTextHolder"].createTextField("m_fldText", 1, 0, 0, 0, 0);
		m_fldText = pThis["m_mcTextHolder"]["m_fldText"];
		m_fldText.autoSize = "left";
		m_fldText.selectable = false;
		m_fldText.multiline = true;
		m_fldText.html = true;
		
		m_strAlign = "left";
		m_strVAlign = "middle";
		m_bAutoSize = false;
		pThis.createEmptyMovieClip("m_layerMask", 3);
		pThis["m_mcTextHolder"].setMask(pThis["m_layerMask"]);
		pThis["m_layerMask"]._visible = false;

		m_strText = "";
		m_data.type = "label";
		m_data.mode = "out";
		m_data.className = "Label";
	}

	public function getTextW():Number
	{
		updateText();
		return m_fldText.textWidth;
	}

	public function getTextH():Number
	{
		updateText();
		return m_fldText.textHeight;
	}

	public function getMinW():Number
	{
		return getTextW() + 4;
	}

	public function getMinH():Number
	{
		return getTextH() + 4;
	}

	public function setHtml(bHtml:Boolean):Void
	{
		if(m_fldText.html != bHtml) m_bUpdated = false;
		m_fldText.html = bHtml;
	}

	public function setAutoSize(bAutoSize:Boolean):Void
	{
		if(m_bAutoSize != bAutoSize) m_bUpdated = false;
		m_bAutoSize = bAutoSize;
	}

	public function setWordWrap(bWordWrap:Boolean):Void
	{
		if(m_fldText.wordWrap != bWordWrap) m_bUpdated = false;
		m_fldText.wordWrap = bWordWrap;
	}

	public function setMultiline(bMultiline:Boolean):Void
	{
		if(m_fldText.multiline != bMultiline) m_bUpdated = false;
		m_fldText.multiline = bMultiline;
	}

	public function setText(strText:String):Void
	{
		m_strText = strText;
		m_bUpdated = false;
	}

	public function getField():TextField
	{
		return m_fldText;
	}

	public function getText():String
	{
		return m_strText;
	}

	public function getFieldText():String
	{
		return m_fldText.html ? m_fldText.htmlText : m_fldText.text;
	}

	public function setAlign(strAlign:String):Void
	{
		m_strAlign = strAlign;
		m_bUpdated = false;
		m_bDrawn = false;
	}

	public function setVAlign(strVAlign:String):Void
	{
		m_strVAlign = strVAlign;
		m_bUpdated = false;
		m_bDrawn = false;
	}

	public function updateText():Void
	{
		if(m_fldText.html)
		{
			var strBeg:String = m_look ? m_look.getTextDecoration("open", m_data) : "";
			var strEnd:String = m_look ? m_look.getTextDecoration("close", m_data) : "";
			m_fldText.htmlText = strBeg + pseudo.Global.fixHtmlSpace(m_strText) + strEnd;
		}
		else
		{
			var tf:TextFormat = m_look.getTextFormat(m_data);
			m_fldText.setNewTextFormat(tf);
			m_fldText.text = m_strText;
		}
	}

	public function update():Void
	{
		if(!m_bUpdated)
		{
			m_bDrawn = false;
			updateText();

			var nOffLeft:Number = m_look.getMargin("left", m_data);
			var nOffRight:Number = m_look.getMargin("right", m_data);
			var nOffTop:Number = m_look.getMargin("top", m_data);
			var nOffBottom:Number = m_look.getMargin("bottom", m_data);

			if(m_bAutoSize)
			{
				m_nW = m_fldText._width + nOffLeft + nOffRight;
				m_nH = m_fldText._height + nOffTop + nOffBottom;
			}
			m_fldText._width = getUserW();
			m_fldText._height = getUserH();

			m_layerMask._x = nOffLeft;
			m_layerMask._y = nOffTop;
			switch(m_strAlign)
			{
				case "right":
					m_fldText._x = m_nW - m_fldText._width - nOffRight;
					break;
				case "center":
					m_fldText._x = nOffLeft + Math.round((m_nW - nOffLeft - nOffRight - m_fldText._width) / 2);
					break;
				default:
					m_fldText._x = nOffLeft;
					break;
			}
			switch(m_strVAlign)
			{
				case "top":
					m_fldText._y = nOffTop - 1;
					break;
				case "middle":
					m_fldText._y = nOffTop + Math.round((m_nH - nOffTop - nOffBottom - m_fldText._height) / 2) - 1;
					break;
				default:
					m_fldText._y = m_nH - m_fldText._height - nOffBottom;
					break;
			}
		}
		super.update();
	}

	public function draw():Void
	{
		if(!m_bDrawn)
		{
			super.draw();
			m_look.updateMask(m_layerMask, getUserW(), getUserH(), m_data);
		}
	}
}