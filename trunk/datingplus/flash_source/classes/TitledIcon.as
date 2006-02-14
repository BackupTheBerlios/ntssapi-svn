class classes.TitledIcon extends pseudo.BaseMovie
{
	private var m_fldText:TextField;
	private var m_strText:String;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):classes.TitledIcon
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new classes.TitledIcon(pOwner[strName]);
		return pOwner[strName];
	}

	public function TitledIcon(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = classes.TitledIcon;

		pThis.createTextField("m_fldText", 1, 0, 0, 0, 0);
		m_fldText = pThis["m_fldText"];
		m_fldText.selectable = false;
		m_fldText.multiline = true;
		m_fldText.html = true;
		m_strText = "";
		m_data.className = "TitledIcon";
		m_data.iconW = m_data.iconH = 30;
		m_data.drawBg = true;
		m_data.fldText = m_fldText;
	}

	public function setText(strText:String, styleSheet:TextField.StyleSheet):Void
	{
		m_strText = strText;
		m_fldText.styleSheet = styleSheet;
		m_fldText.htmlText = m_look.getTextDecoration("open", m_data) +
			m_strText + m_look.getTextDecoration("close", m_data);
	}

	public function update():Void
	{
		if(!m_bUpdated) updateText();
		super.update();
	}

	//
	// PRIVATE METHODS
	//
	private function updateText():Void
	{
		m_fldText.htmlText = m_look.getTextDecoration("open", m_data) +
			m_strText + m_look.getTextDecoration("close", m_data);
		m_fldText.wordWrap = false;
		m_fldText._width = Math.min(m_fldText.textWidth + 4, m_nW + 5);
		m_fldText.wordWrap = true;
		m_fldText._height = Math.min(m_fldText.textHeight + 4, m_nH - m_data.iconH - 3);
		m_fldText._x = Math.round((m_nW - m_fldText._width) / 2);
		m_fldText._y = m_data.iconH + 2;
		m_bDrawn = false;
	}
}