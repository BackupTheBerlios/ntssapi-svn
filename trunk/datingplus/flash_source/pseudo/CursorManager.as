/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.CursorManager
{
	static private var m_instance:pseudo.CursorManager;
	private var m_holder:MovieClip; // holder for cursors
	private var m_arrCursors:Array;
	private var m_look:Object;
	private var m_strCursor:String;
	private var m_cursor:MovieClip;

	//
	// PUBLIC METHODS
	//
	static public function getInstance():pseudo.CursorManager
	{
		if(!m_instance) m_instance = new pseudo.CursorManager();
		return m_instance;
	}

	public function setCursorsHolder(holder:MovieClip):Void
	{
		m_holder = holder;
	}

	public function setLook(look:Object):Void
	{
		m_look = look;
		loadCursors();
	}

	public function loadCursors():Void
	{
		for(var i:Number = 0; i < m_arrCursors.length; i++)
			if(m_arrCursors[i].cursor)
			{
				m_arrCursors[i].cursor.removeMovieClip();
				m_arrCursors[i].cursor = null;
			}
		m_arrCursors.splice(0);
		var arrCursorsNames:Array = m_look.getCursors();
		var nDepth:Number = m_holder.getNextHighestDepth();
		for(var i:Number = 0; i < arrCursorsNames.length; i++)
		{ // load all cursors into cursorsHolder
			m_holder.createEmptyMovieClip(arrCursorsNames[i], nDepth++);
			var cursor:MovieClip = m_holder[arrCursorsNames[i]];
			cursor._visible = false;
			var movieLoader:MovieClipLoader = new MovieClipLoader();
			var listener:Object = new Object();
			listener.onLoadInit = function(target:MovieClip):Void
			{
				target._visible = false;
				delete this.loader;
				delete this;
			}
			listener.loader = movieLoader;
			movieLoader.addListener(listener);
			movieLoader.loadClip(m_look.getCursorPath(arrCursorsNames[i]), cursor);
			m_arrCursors.push({name:arrCursorsNames[i], cursor:cursor});
		}
	}

	public function setCursor(strCursor:String):Void
	{
		m_strCursor = strCursor;
		if(m_cursor)
		{
			m_cursor._visible = false;
			m_cursor = null;
		}
		for(var i:Number = 0; i < m_arrCursors.length; i++)
			if(m_arrCursors[i].name == strCursor)
			{
				m_cursor = m_arrCursors[i].cursor;
				m_cursor._visible = true;
				onMouseMove();
				break;
			}
		m_cursor ? Mouse.hide() : Mouse.show();
	}

	public function getCursor():String
	{
		return m_strCursor;
	}

	//
	// PRIVATE METHODS
	//

	private function CursorManager()
	{
		m_holder = _root;
		m_look = null;
		m_arrCursors = new Array();
		m_strCursor = "";
		m_cursor = null;
		Mouse.addListener(this);
	}

	private function onMouseMove():Void
	{
		if(m_cursor)
		{
			m_cursor._x = m_holder._xmouse;
			m_cursor._y = m_holder._ymouse;
		}
	}
}