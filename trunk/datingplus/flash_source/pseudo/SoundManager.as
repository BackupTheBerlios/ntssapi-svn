/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.SoundManager implements pseudo.IBroadcaster
{
	static private var m_instance:pseudo.SoundManager;

	/** Number of sounds which should be loaded. */
	private var m_nToLoad:Number = 0;
	/** Array of sounds. */
	private var m_arrSounds:Array = new Array();
	private var m_caster:pseudo.IBroadcaster;

	//
	// PUBLIC METHODS
	//

	public function SoundManager()
	{
		m_caster = new pseudo.Broadcaster();
	}

	public function fireEvent(strEvent:String):Boolean
	{
		return Boolean(m_caster.fireEvent.apply(Object(m_caster), arguments));
	}

	public function addListener(strEvent:String, pOwner:Object, fnCallBack:Function):Void
	{
		m_caster.addListener.apply(Object(m_caster), arguments);
	}

	public function removeListener(strEvent:String, pListener:Object):Void
	{
		m_caster.removeListener(strEvent, pListener);
	}

	public function getEventData(strEvent:String):Object
	{
		return m_caster.getEventData(strEvent);
	}

	public function removeListeners():Void
	{
		m_caster.removeListeners();
	}

	static public function getInstance():pseudo.SoundManager
	{
		if(!m_instance) m_instance = new pseudo.SoundManager();
		return m_instance;
	}

	public function getSound(name:String):Sound
	{
		for(var i:Number = 0; i < m_arrSounds.length; i++)
		{
			if(m_arrSounds[i].name == name)
				return m_arrSounds[i].sound;
		}
		return null;
	}

	public function playSound(name:String):Sound
	{
		var sound:Sound = getSound(name);
		if(sound) sound.start();
		return sound;
	}

	public function addSound(name:String, path:String):Void
	{
		if(name && path)
		{
			for(var i = 0; i < m_arrSounds.length; i++)
				if(m_arrSounds[i].name == name)
				{
					m_arrSounds[i].path = path;
					return;
				}
			var obj:Object = new Object();
			obj.name = name;
			obj.path = path;
			obj.sound = new Sound();
			obj.sound.owner = this;
			obj.sound.onLoad = function(bSuccess:Boolean):Void
			{
				this.owner.m_nToLoad--;
				if(this.owner.m_nToLoad == 0 && this.owner.m_fnLoad)
					this.owner.m_fnLoad.call(this.owner.m_pOwner, true);
			}
			m_arrSounds.push(obj);
		}
	}

	/**
	 * Loads sounds of the specific load type.
	 */
	public function loadSounds():Void
	{
		for(var i = 0; i < m_arrSounds.length; i++)
		{
			m_nToLoad++;
			m_arrSounds[i].sound.loadSound(m_arrSounds[i].path);
		}
		if(m_nToLoad == 0) fireEvent("onLoadAll", true);
	}

	/**
	 * Gets current pos of loading.
	 * @return Loading progress in percents.
	 */
	public function getPos():Number
	{
		var nTotal:Number = 0;
		var nLoaded:Number = 0;
		for(var i = 0; i < m_arrSounds.length; i++)
		{
			nTotal += m_arrSounds[i].sound.getBytesTotal();
			nLoaded += m_arrSounds[i].sound.getBytesLoaded();
		}
		return nTotal > 0 ? nLoaded * 100 / nTotal : 100;
	}
}