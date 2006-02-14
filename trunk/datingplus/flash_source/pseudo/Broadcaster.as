/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.Broadcaster implements pseudo.IBroadcaster
{
	private var m_arrEvents:Array;
	private var m_nKeyEvents:Number;

	public function Broadcaster()
	{
		m_arrEvents = new Array();
		m_nKeyEvents = 0;
	}

	public function fireEvent(strEvent:String):Boolean
	{
		var bRes:Boolean = false;
		for(var i:Number = 0; i < m_arrEvents.length; i++)
		{
			var objEvent:Object = m_arrEvents[i];
			if(objEvent.event == strEvent)
			{
				for(var j:Number = 0; j < objEvent.arrListeners.length; j++)
				{
					var objListener:Object = objEvent.arrListeners[j];
					var arrArgs:Array = arguments.slice(1);
					for(var k:Number = 0; k < objListener.args.length; k++)
						arrArgs.push(objListener.args[k]);
					objListener.func.apply(objListener.owner, arrArgs);
					delete arrArgs;
				}
				bRes = true;
				break;
			}
		}
		return bRes;
	}

	public function addListener(strEvent:String, pOwner:Object, fnCallBack:Function):Void
	{
		if(strEvent == "keyUp") m_nKeyEvents |= 5;
		if(strEvent == "keyDown") m_nKeyEvents |= 6;
		if(m_nKeyEvents) Key.addListener(this);
		var objEventData:Object = getEventData(strEvent);
		if(!objEventData)
		{ // create new eventData
			objEventData = new Object();
			objEventData.arrListeners = new Array();
			objEventData.event = strEvent;
			m_arrEvents.push(objEventData);
		}
		var objEventListener:Object = getEventListener(objEventData, pOwner);
		if(!objEventListener)
		{ // create new event listener
			objEventListener = new Object();
			objEventData.arrListeners.push(objEventListener);
		}
		objEventListener.owner = pOwner;
		objEventListener.func = fnCallBack;
		objEventListener.args = arguments.slice(3);
	}

	public function removeListener(strEvent:String, pListener:Object):Void
	{
		if(strEvent == "keyUp") m_nKeyEvents &= 6;
		if(strEvent == "keyDown") m_nKeyEvents &= 5;
		if(m_nKeyEvents == 4)
		{
			Key.removeListener(this);
			m_nKeyEvents = 0;
		}
		for(var i:Number = 0; i < m_arrEvents.length; i++)
		{
			var obj:Object = m_arrEvents[i];
			if(obj.event == strEvent)
			{
				for(var j:Number = 0; j < obj.arrListeners.length; j++)
					if(!pListener || obj.arrListeners[j].owner == pListener)
					{
						delete obj.arrListeners[j].args;
						delete obj.arrListeners[j];
						obj.arrListeners.splice(j, 1);
						if(pListener) break;
					}
				if(obj.arrListeners.length == 0)
				{
					delete obj.arrListeners;
					delete obj;
					m_arrEvents.splice(i, 1);
				}
				break;
			}
		}
	}

	public function removeListeners():Void
	{
		m_arrEvents.splice(0);
		/*for(var i:Number = 0; i < m_arrEvents.length; i++)
		{
			var arr:Array = m_arrEvents[i].arrListeners;
			for(var j:Number = 0; j < arr.length; j++)
				delete arr[j];
			delete m_arrEvents[i].arrListeners;
			delete m_arrEvents[i];
		}
		m_arrEvents.splice(0);*/
	}

	public function getEventData(strEvent:String):Object
	{
		for(var i:Number = 0; i < m_arrEvents.length; i++)
			if(m_arrEvents[i].event == strEvent) return m_arrEvents[i];
		return null;
	}

	//
	// PRIVATE METHODS
	//

	private function getEventListener(objEventData:Object, pOwner:Object):Object
	{
		if(!pOwner) return null;
		for(var i:Number = 0; i < objEventData.arrListeners.length; i++)
			if(objEventData.arrListeners[i].owner == pOwner)
				return objEventData.arrListeners[i];
		return null;
	}

	private function onKeyDown():Void
	{
		fireEvent("keyDown");
	}

	private function onKeyUp():Void
	{
		fireEvent("keyUp");
	}
}