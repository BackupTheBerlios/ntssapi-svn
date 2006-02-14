/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.Global
{
	static private var nextId:Number = 1;
	static public function getUniqueId():Number
	{
		if(nextId == 32000 || nextId > 32100)
			_root.trace("Current number of unique ids is exeeded 32000\n"
				+ "You should restart application or risk unexpected behavior.\n"
				+ "Also please notify development team about this!");
		return nextId++;
	}
	
	static private var bExtention:Boolean = doExtention();
	static private function doExtention():Boolean
	{
		/**
		 * Replacement for standard trace. To use - type _root.trace(...) instead of trace(...)
		 * * @param strText text that adds as new line to existing text in movie.
		 */
		_root.trace = function(strText:String, depth:Number):Void
		{
			var txtField:TextField;
			if(!_root.m_mcTrace)
			{ // trace window doesn't exist yet. Create it at first time.
				_root.createEmptyMovieClip("m_mcTrace", depth ? depth : _root.getNextHighestDepth());
				_root.m_mcTrace.onPress = function()
				{
					this.startDrag();
					this.bPress = true;
				}
		
				_root.m_mcTrace.onMouseMove = function()
				{
					if(this.bPress) this.bDragging = true;
				}
			
				_root.m_mcTrace.onRelease = function()
				{
					if(!this.bDragging)
					{
						this._visible = false;
						this.txtField.text = "";
					}
					this.bDragging = false;
					this.bPress = false;
					this.stopDrag();
				}
				_root.m_mcTrace.useHandCursor = false;
				_root.m_mcTrace.createTextField("txtField", 1, 0, 0, 0, 0);
				txtField = _root.m_mcTrace.txtField;
				txtField.border = true;
				txtField.borderColor = 0xaaaaaa;
				txtField.background = true;
				txtField.backgroundColor = 0xfcfffc;
				txtField.autoSize = "left";
				var tf:TextFormat = new TextFormat();
				tf.font = "Tahoma";
				txtField.setNewTextFormat(tf);
				_root.m_mcTrace._visible = false;
			}
			else txtField = _root.m_mcTrace.txtField;
			txtField.text += (txtField.text ? "\n" : "") + strText;
			if(!_root.m_mcTrace._visible)
			{ // if window was hidden then centers it in window and show
				_root.m_mcTrace._x = Math.round((Stage.width - _root.m_mcTrace._width) / 2);
				_root.m_mcTrace._y = Math.round((Stage.height - _root.m_mcTrace._height) / 2);
				_root.m_mcTrace._visible = true;
			}
		}
		MovieClip.prototype.oldSetMask = MovieClip.prototype.setMask;
		MovieClip.prototype.setMask = function(movie:MovieClip):Void
		{
			this.oldSetMask(movie);
			this._mask = movie;
		}
		return true;
	}

	static public function fixHtmlSpace(str:String):String
	{
		return str.split("> ").join(">&#32;");
	}


	static public function isVisible(movie:MovieClip):Boolean
	{
		while(movie)
		{
			if(!movie._visible) return false;
			movie = movie._parent;
		}
		return true;
	}

	static public function drawRect(movie:MovieClip, nX:Number,
		nY:Number, nW:Number, nH:Number, nColor:Number, nAlpha:Number):Void
	{
		if(!nColor) nColor = 0;
		if(nAlpha == undefined || nAlpha == null) nAlpha = 100;
		movie.moveTo(nX, nY);
		movie.beginFill(nColor, nAlpha);
		movie.lineTo(nX + nW, nY);
		movie.lineTo(nX + nW, nY + nH);
		movie.lineTo(nX, nY + nH);
		movie.lineTo(nX, nY);
		movie.endFill();
	}

	static public function max():Number
	{
		var nMax:Number = arguments[0];
		for(var i:Number = 1; i < arguments.length; i++)
			nMax = Math.max(nMax, arguments[i]);
		return nMax;
	}

	static public function createLabel(owner:MovieClip, strName:String, nDepth:Number):TextField
	{
		owner.createTextField(strName, nDepth, 0, 0, 0, 0);
		var fld:TextField = owner[strName];
		fld.selectable = false;
		fld.html = true;
		fld.multiline = true;
		fld.autoSize = "left";
		return fld;
	}

	/*static public function drawFastFrame(movie:MovieClip, nX:Number,
		nY:Number, nW:Number, nH:Number, clr:Number, alpha:Number, nSize:Number):Void
	{
		if(!movie.left)
		{
			movie.createEmptyMovieClip("left", 1);
			movie.createEmptyMovieClip("right", 2);
			movie.createEmptyMovieClip("top", 3);
			movie.createEmptyMovieClip("bottom", 4);
		}
		movie.left._x = nX;
		movie.left._y = nY;
		movie.right._x = nX + nW - nSize;
		movie.right._y = nY;
		movie.top._x = nX + nSize;
		movie.top._y = nY;
		movie.bottom._x = nX + nSize;
		movie.bottom._y = nY + nH - nSize;
		drawRect(movie.left, 0, 0, nSize, nH, clr, alpha);
		drawRect(movie.right, 0, 0, nSize, nH, clr, alpha);
		drawRect(movie.top, 0, 0, nW - nSize * 2, nSize, clr, alpha);
		drawRect(movie.bottom, 0, 0, nW - nSize * 2, nSize, clr, alpha);
	}
*/
	static public function drawFrame(movie:MovieClip, nX:Number,
		nY:Number, nW:Number, nH:Number, clr:Number, alpha:Number, nSize:Number):Void
	{
		var nMinSize:Number = Math.min(nW, nH);
		if(!nSize) nSize = 1;
		if(nSize > nMinSize / 2)
			drawRect(movie, nX, nY, nW, nH, clr, alpha);
		else
		{
			drawRect(movie, nX, nY, nW, nSize, clr, alpha);
			drawRect(movie, nX, nY + nSize, nSize, nH - nSize, clr, alpha);
			drawRect(movie, nX + nSize, nY + nH - nSize, nW - nSize, nSize, clr, alpha);
			drawRect(movie, nX + nW - nSize, nY + nSize, nSize, nH - nSize * 2, clr, alpha);
		}
	}

	static public function ptInRect(ptX:Number, ptY:Number,
		x:Number, y:Number, w:Number, h:Number):Boolean
	{
		return ptX >= x && ptX <= x + w && ptY >= y && ptY <= y + h;
	}

	static public function getBlendedColor(clr1:Number, clr2:Number, alpha:Number):Number
	{
		return RGB(
			Math.round((getR(clr1) * alpha + getR(clr2) * (100 - alpha)) / 100),
			Math.round((getG(clr1) * alpha + getG(clr2) * (100 - alpha)) / 100),
			Math.round((getB(clr1) * alpha + getB(clr2) * (100 - alpha)) / 100)
		);
	}

	static public function getR(color:Number):Number
	{
		return Math.floor((color & 0xff0000) / 256 / 256);
	}
	
	static public function getG(color:Number):Number
	{
		return Math.floor((color & 0x00ff00) / 256);
	}
	
	static public function getB(color:Number):Number
	{
		return color & 0x0000ff;
	}
	
	static public function RGB(r:Number, g:Number, b:Number):Number
	{
		return r * 256 * 256 + g * 256 + b;
	}

	static public function getHTMLColor(nColor:Number):String
	{
		var strCol:String = nColor.toString(16);
		if(strCol.length < 6) strCol = (String("000000").substr(0, 6 - strCol.length)) + strCol;
		return "#" + strCol;
	}

	static public function getValue():Object
	{
		for(var i = 0; i < arguments.length; i++)
			if(arguments[i] != undefined) return arguments[i];
		return null;
	}
}


