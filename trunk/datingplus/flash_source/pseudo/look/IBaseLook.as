interface pseudo.look.IBaseLook
{
	public function isSameTheme(xmlTheme:XML):Boolean;
  public function toXML():XML
	public function fromXML(data:Object):Void;
	public function getThemeId():String;
	public function setData(data:Object):Void;
	public function fillContent(movie:MovieClip, ctrls:Object):Void
	public function getIconPath(strIcon:String):String;
	public function getCursorPath(strCursor:String):String;
	public function getCursors():Array;
	public function getBorder(strBorder:String, data:Object):Number;
	public function getMargin(strMargin:String, data:Object):Number;
	public function draw(movie:MovieClip, nW:Number, nH:Number, data:Object):Void;
	public function updateMask(movie:MovieClip, nW:Number, nH:Number, data:Object):Void;
	public function getParams(data:Object):Object;
}