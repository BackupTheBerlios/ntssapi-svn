/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.Edit extends pseudo.Label
{
	private var m_bFocused:Boolean;
	static private var m_tabId:Number = 1; // xxx

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.Edit
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.Edit(pOwner[strName]);
		return pOwner[strName];
	}

	public function Edit(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.Edit;

		m_fldText.type = "input";
		m_fldText.selectable = true;
		m_fldText.html = false;
		m_fldText.autoSize = "none";
		m_fldText.owner = pThis;
		m_bFocused = false;
		m_data.type = "edit";
		m_data.drawType = "edit";
		m_fldText.ownerChanged = editChanged;
		m_fldText.ownerScroll = editScroll;
		m_fldText.ownerSetFocus = editSetFocus;
		m_fldText.ownerKillFocus = editKillFocus;
		m_fldText.tabIndex = m_tabId++; // xxx

		m_fldText.onScroller = function()
		{
			this.ownerScroll.apply(this.owner);
		}
		m_fldText.onChanged = function()
		{
			this.ownerChanged.apply(this.owner);
		}
		m_fldText.onSetFocus = function()
		{
			this.ownerSetFocus.apply(this.owner);
		}
		m_fldText.onKillFocus = function()
		{
			this.ownerKillFocus.apply(this.owner);
		}
	}

	public function isFocused():Boolean
	{
		return m_bFocused;
	}

	public function setEdit(bEdit:Boolean):Void
	{
		m_fldText.type = bEdit ? "input" : "dynamic";
	}

	public function isEditable():Boolean
	{
		return m_fldText.type == "input";
	}

	public function setSelectable(bSelect:Boolean):Void
	{
		m_fldText.selectable = bSelect;
	}

	public function setUsePassword(bUsePassword:Boolean):Void
	{
		m_fldText.password = bUsePassword;
	}

	//
	// PRIVATE METHODS
	//
	private function movieRollOver(bSkip:Boolean):Void
	{
		if(!bSkip) setData({mode:m_bFocused ? "press" : "over"});
		super.movieRollOver(true);
		update();
		draw();
	}

	private function movieRollOut(bSkip:Boolean):Void
	{
		if(!bSkip) setData({mode:m_bFocused ? "press" : "out"});
		super.movieRollOut(true);
		update();
		draw();
	}

	private function editScroll():Void
	{
		fireEvent("scroll");
	}

	private function editChanged():Void
	{
		m_strText = m_fldText.text;
		fireEvent("changed");
	}

	private function editSetFocus():Void
	{
		m_bFocused = true;
		setData({mode:"press"});
		update();
		draw();
		fireEvent("setFocus");
	}

	private function editKillFocus():Void
	{
		m_bFocused = false;
		setData({mode:isMouseOver() ? "over" : "out"});
		update();
		draw();
		fireEvent("killFocus");
	}
}