/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.PushButton extends pseudo.Button
{
	//
	// PUBLIC METHODS
	//
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.PushButton
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.PushButton(pOwner[strName]);
		return pOwner[strName];
	}

	public function PushButton(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.PushButton;

		addListener("mouseRelease", pThis, onPlaySound);
	}

	public function invokeEvent(strEvent:String):Void
	{

		super.invokeEvent(strEvent);
		switch(strEvent)
		{
			case "showLayer":
				if(m_data.mode != "disabled")
				{
					if(m_nLock) showLayer("out");
					else
					{
						if(isMouseOver()) showLayer(m_bMouseDown ? "press" : "over");
						else
						{
							showLayer(m_bDragOut ? "over" : "out");
							if(!m_bMouseDown) componentRollOut();
						}
					}
				}
				break;
		}
	}

	//
	// PRIVATE METHODS
	//
	private function movieRollOver(bSkip:Boolean):Void
	{
		if(!bSkip) showLayer("over");
		super.movieRollOver(true);
	}

	private function movieRollOut(bSkip:Boolean):Void
	{
		if(!bSkip) showLayer("out");
		super.movieRollOut();
	}

	private function movieDragOver(bSkip:Boolean):Void
	{
		if(!bSkip) showLayer(m_bMouseDown ? "press" : "over");
		super.movieDragOver(true);
	}

	private function movieDragOut(bSkip:Boolean):Void
	{
		if(!bSkip) showLayer("over");
		super.movieDragOut(true);
	}

	private function movieMouseDown(bSkip:Boolean):Void
	{
		if(!bSkip) showLayer("press");
		super.movieMouseDown(true);
	}

	private function movieMouseUp(bSkip:Boolean):Void
	{
		if(!bSkip) showLayer("over");
		super.movieMouseUp(true);
	}

	private function onPlaySound():Void
	{
		var sound:String = m_data.sound;
		if(!sound)
			switch(m_data.type)
			{
				case undefined:
				case null:
				case "":
					sound = "btnRelease";
					break;
			}
		if(sound) pseudo.SoundManager.getInstance().playSound(sound);
	}
}