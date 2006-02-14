/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.ComboBox extends pseudo.BaseComboBox
{
	private var m_edit:pseudo.Edit;
	private var m_btnDrop:pseudo.Button;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.ComboBox
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.ComboBox(pOwner[strName]);
		return pOwner[strName];
	}

	public function ComboBox(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.ComboBox;

		m_edit = pseudo.Edit.create(pThis, "m_edit", 1);
		m_edit.setName("edit");
		m_edit.setData({type:"comboBoxTitle"});
		m_btnDrop = pseudo.Button.create(pThis, "btnDrop", 2);
		m_btnDrop.setData({type:"comboBoxBtn"});
		m_btnDrop.addListener("dragOver", this, dropDragOver);

		m_data.className = "ComboBox";
		m_data.type = "comboBox";

		m_arrItems.push(m_edit, m_btnDrop);
	}

	public function setSelId(nId:Number):Void
	{
		m_edit.setText(m_arrData[nId].text);
		m_edit.update();
		m_edit.draw();
		super.setSelId(nId);
	}

	public function setEdit(bEdit:Boolean):Void
	{
		m_edit.setEdit(bEdit);
		m_edit.setSelectable(bEdit);
		m_edit.setHtml(!bEdit);
		if(bEdit) m_btnDrop.addListener("dragOver", this, dropDragOver);
		else m_btnDrop.removeListener("dragOver", this);
	}

	public function showLayer(strLayer:String):Void
	{
		super.showLayer(strLayer);
		if(strLayer != "press" || !m_edit.isEditable() || m_btnDrop.isMouseOver())
			m_btnDrop.showLayer(strLayer);
	}

	public function getUserW():Number
	{
		return super.getUserW() - m_btnDrop.getW();
	}

	public function update():Void
	{
		if(!m_bUpdated)
		{
			m_btnDrop.setSize(Math.min(15, m_nH), m_nH);
			m_btnDrop._x = m_nW - m_btnDrop.getW();
			m_edit._x = m_look.getMargin("left", m_data);
			m_edit._y = m_look.getMargin("right", m_data);
			m_edit.setSize(getUserW(), getUserH());
		}
		super.update();
	}

	//
	// PRIVATE METHODS
	//

	private function movieMouseRelease(bSkip3:Boolean, bSkip2:Boolean, bSkip1:Boolean, bSkip:Boolean):Void
	{
		super.movieMouseRelease(false, false, m_edit.isEditable() && !m_btnDrop.isMouseOver(), true);
	}

	private function dropDragOver():Void
	{
		m_btnDrop.showLayer(m_data.mode);
	}
}