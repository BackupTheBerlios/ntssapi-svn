interface pseudo.look.IEditLook extends pseudo.look.IBaseLook
{
	public function getTextFormat(data:Object):TextFormat;
	public function getTextDecoration(strType:String, data:Object):String;
}