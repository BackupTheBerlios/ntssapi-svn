/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
/**
 * Allows any movies to show its tooltip by calling tryToShow function.
 * Only one instance is needed.
 */
class pseudo.ToolTip extends MovieClip
{
// attributes
	/** Delay in ms before the tooltip is showed. */
	static var m_nDelay:Number = 700;
	/** Owner movie for which tooltip will be shown. */
	private var m_owner:MovieClip;
	/** Id of current timer instance. */
	private var m_nID:Number;
	/** Text to show. */
	private var m_strText:String;
	/** Text field. */
	private var m_tipText:TextField;
	static private var m_instance:pseudo.ToolTip;
	private var m_data:Object;
	private var m_look:Object;

  /**
   * Creates tooltip.
   * @param pOwner Parent of the tooltip.
   * @param strName Tooltip name.
   * @param nDepth Tooltip movie depth.
   * @return Created tooltip.
   */
  static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.ToolTip
  {
    pOwner.createEmptyMovieClip(strName, nDepth);
    pOwner[strName].__proto__ = new pseudo.ToolTip(pOwner[strName]);
	m_instance = pOwner[strName];
    return m_instance;
  }

	static public function getInstance():pseudo.ToolTip
	{
		return m_instance;
	}

	public function getClass():Function
	{
		return ToolTip;
	}

	/** Constructor. */
	public function ToolTip(pThis:MovieClip)
	{
		_visible = false;
		if(!pThis) pThis = this;

		pThis._visible = false;
		m_strText = "";
		m_nID = null;
		m_owner = null;
		pThis.createTextField("m_tipText", 1, 0, 0, 0, 0);
		m_tipText = pThis["m_tipText"];
		m_tipText.autoSize = "left";
		m_tipText.selectable = false;
		m_tipText.border = true;
		m_tipText.background = true;
		m_tipText.backgroundColor = 0xffffe6;
		//var tf:TextFormat = new TextFormat();
		//tf.font = "Tahoma";
		//tf.size = 12;
		//m_tipText.setNewTextFormat(tf);
		m_tipText.html = true;
		m_data = new Object();
	}

	public function setLook(look:Object):Void
	{
		m_look = look;
	}

	public function setData(data:Object):Void
	{
		for(var i:String in data)
			m_data[i] = data[i];
	}

	/**
	 * Tries to show tool tip after delay.
	 * @param owner Owner for which tool tip will be shown after delay.
	 * @param strText Text to show.
	 */
	public function tryToShow(owner:MovieClip, strText:String):Void
	{
		if(strText.length == 0 || strText == undefined)
			return;
		hide();
		m_owner = owner;
		onMouseDown = toolTipMouseDown;
		onMouseMove = toolTipMouseMove;
		m_strText = " " + strText;
		m_nID = setInterval(this, "show", m_nDelay);
	}

	/**
	 * Shows tool tip.
	 */
	public function show(strText:String, x:Number, y:Number):Void
	{
		if(strText) m_strText = strText;
		clearInterval(m_nID);
		m_nID = null;
		m_tipText.htmlText = m_look.getTextDecoration("open", m_data)
			+ "<font color='#000000'>" + m_strText
			+ "</font>" + m_look.getTextDecoration("close", m_data);
		_x = x ? x : Math.min(_parent._xmouse, Stage.width - m_tipText._width - 2);
		if(y || Stage.height > _parent._ymouse + 19 + m_tipText._height)
			_y = y ? y : _parent._ymouse + 19;
		else
			_y = _parent._ymouse - m_tipText._height - 2;
		_visible = true;
	}

	/**
	 * Hides tool tip.
	 */
	public function hide():Void
	{
		delete onMouseMove;
		delete onMouseDown;
		clearInterval(m_nID);
		m_nID = null;
		_visible = false;
	}

	/**
	 * Handles mouse moving.
	 */
	private function toolTipMouseMove():Void
	{
		clearInterval(m_nID);
		m_nID = null;
		if(m_owner && m_owner.hitTest(_root._xmouse, _root._ymouse, true))
		{
			if(hitTest(_root._xmouse, _root._ymouse, false)) _visible = false;
			if(!_visible) m_nID = setInterval(this, "show", m_nDelay, m_strText);
		}
		else
			hide();
	}

	/**
	 * Handles mouse left button down.
	 */
	private function toolTipMouseDown():Void
	{
		hide();
	}
}
