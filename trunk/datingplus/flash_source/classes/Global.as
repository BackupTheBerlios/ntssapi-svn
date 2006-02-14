class classes.Global
{
	static public function alert(strTitle:String, strMsg:String, strIconPath:String, strBtns:String):pseudo.BaseWindow
	{
		var manager:pseudo.WindowManager = pseudo.WindowManager(_global.main.getItem("alertMng"));
		var nDepth:Number = manager.getNextHighestDepth();
		var wnd:pseudo.BaseWindow = manager.addWindow(strTitle, null, strTitle + nDepth);
		wnd._visible = false;
		wnd.setIsResizable(false);
		var title:classes.WindowTitle = classes.WindowTitle(wnd.setTitleBar(classes.WindowTitle));
		title.setText(strTitle);
		title.setCanHide(false);
		title.setCanMaximize(false);
		var content:pseudo.AlertContent = pseudo.AlertContent(wnd.setPane(pseudo.Pane).setContent(pseudo.AlertContent));
		content.setText(strMsg);
		var listener:Object = new Object({wnd:wnd, manager:manager});
		listener.onLoadIcon = function()
		{
			this.wnd._visible = true;
			this.wnd.setSize(wnd.getMinW(), wnd.getMinH());
			this.manager.update();
			this.manager.draw();
			delete this;
		}
		content.addListener("onLoadIcon", listener, listener.onLoadIcon);
		content.setIcon(strIconPath);
		if(!strBtns) strBtns = "ok," + _global.lng.getAttr("OK");
		content.setButtons(strBtns);
		return wnd;
	}

	static public function getRect(movie:MovieClip, bZeroHiddenSize:Boolean, bLocal:Boolean):Object
	{
		var pt:Object = new Object({x:movie._x, y:movie._y});
		if(!bLocal) movie._parent.localToGlobal(pt);
		if(bZeroHiddenSize && !pseudo.Global.isVisible(movie))
			return new Object({x:pt.x, y:pt.y, w:0, h:0})
		else if(movie instanceof pseudo.BaseMovie)
			return new Object({x:pt.x, y:pt.y, w:movie.getW(), h:movie.getH()});
		else
			return new Object({x:pt.x, y:pt.y, w:movie._width, h:movie._height});
	}

	static private var m_objAni:Object;
	static public function playAniFrame(rFrom:Object, rTo:Object, nSteps:Number):Void
	{
		if(m_objAni)
		{
			clearInterval(m_objAni.timerId);
			delete m_objAni.arrLayres;
			delete m_objAni;
		}
		m_objAni = new Object();
		m_objAni.steps = nSteps ? nSteps : 10;
		m_objAni.from = rFrom;
		m_objAni.to = rTo;
		if(_global.popup.layerAni) _global.popup.layerAni.removeMovieClip();
		var layerAni:MovieClip = _global.popup.createEmptyMovieClip("layerAni", _global.popup.getNextHighestDepth());
		m_objAni.arrLayers = new Array();
		for(var i:Number = 0; i < 3; i++)
			m_objAni.arrLayers.push(layerAni.createEmptyMovieClip("layer" + i, i));
		m_objAni.dx = (rTo.x - rFrom.x) / m_objAni.steps; // note that result can be float
		m_objAni.dy = (rTo.y - rFrom.y) / m_objAni.steps; // note that result can be float
		m_objAni.dw = (rTo.w - rFrom.w) / m_objAni.steps; // note that result can be float
		m_objAni.dh = (rTo.h - rFrom.h) / m_objAni.steps; // note that result can be float
		m_objAni.step = 0;
		m_objAni.timerId = setInterval(classes.Global.onWndAnimate, 20);
		onWndAnimate(); // do first animate step immediately
	}

	static public function onWndAnimate():Void
	{
		m_objAni.arrLayers[0].clear();
		m_objAni.arrLayers[0].left.clear();
		m_objAni.arrLayers[0].right.clear();
		m_objAni.arrLayers[0].top.clear();
		m_objAni.arrLayers[0].bottom.clear();
		if(Math.abs(m_objAni.from.x - m_objAni.to.x - m_objAni.dx) > 1
			|| Math.abs(m_objAni.from.y - m_objAni.to.y - m_objAni.dy) > 1
			|| Math.abs(m_objAni.from.w - m_objAni.to.w - m_objAni.dw) > 1			|| Math.abs(m_objAni.from.h - m_objAni.to.h - m_objAni.dh) > 1)
		{
			pseudo.Global.drawFrame(m_objAni.arrLayers[0], Math.round(m_objAni.from.x),
				Math.round(m_objAni.from.y), Math.round(m_objAni.from.w), Math.round(m_objAni.from.h), 0, 100, 1);
			m_objAni.from.x += m_objAni.dx;
			m_objAni.from.y += m_objAni.dy;
			m_objAni.from.w += m_objAni.dw;
			m_objAni.from.h += m_objAni.dh;
		}
		m_objAni.arrLayers.unshift(m_objAni.arrLayers.pop()); // move last layer to the beginning of the array
		if(m_objAni.step++ > m_objAni.steps + m_objAni.arrLayers.length)
		{
			clearInterval(m_objAni.timerId);
			if(_global.popup.layerAni) _global.popup.layerAni.removeMovieClip();
			delete m_objAni.arrLayres;
			delete m_objAni;
		}
	}
}
