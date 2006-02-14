/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.RadioButton extends pseudo.ToggleButton
{
  static private var m_arrGroups:Array = new Array();
  private var m_strGroupName:String;
	private var m_bProcessed:Boolean;

	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.RadioButton
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.RadioButton(pOwner[strName]);
		return pOwner[strName];
	}

  static public function isGroupName(strGroupName:String):Boolean
  {
    for(var i = 0; i < m_arrGroups.length; i++)
      if(m_arrGroups[i].getGroupName() == strGroupName) return true;
    return false;
  }

	public function RadioButton(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.RadioButton;

		m_strGroupName = "defgroup";
		m_arrGroups.push(pThis);
		m_bProcessed = false;
	}

	public function setGroupName(strGroupName:String):Void
  {
    m_strGroupName = strGroupName;
  }

  public function getGroupName():String
  {
    return m_strGroupName;
  }

	public function setState(strState):Void
  {
    super.setState(strState);
		if(strState == "sunken")
		{
			for(var i = 0; i < m_arrGroups.length; i++)
				if(m_arrGroups[i] && m_arrGroups[i] != this &&
					m_arrGroups[i].getGroupName() == m_strGroupName &&
					m_arrGroups[i].isSunken())
				{
					m_arrGroups[i].setState("normal");
				}
			m_bProcessed = true;
		}
		else m_bProcessed = false;
  }

	//
	// PRIVATE METHODS
	//
	private function movieMouseRelease(bSkip2:Boolean, bSkip1:Boolean, bSkip:Boolean):Void
	{
		if(!(bSkip || m_bProcessed))
		{
			super.movieMouseRelease(false, false, true);
			m_bProcessed = true;
		}
	}
}