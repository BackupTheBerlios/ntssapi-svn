/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
interface pseudo.IBroadcaster
{
	public function fireEvent(strEvent:String):Boolean;
	public function addListener(strEvent:String, pOwner:Object, fnCallBack:Function):Void;
	public function removeListener(strEvent:String, pListener:Object):Void;
	public function getEventData(strEvent:String):Object;
	public function removeListeners():Void;
}