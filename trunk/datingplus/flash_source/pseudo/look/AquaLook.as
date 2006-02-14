class pseudo.look.AquaLook implements pseudo.look.ILabelLook,
	pseudo.look.IEditLook, pseudo.look.IWindowManagerLook
{
	private var m_clrHighlight:Number;
	private var m_clrHilightText:Number;
	private var m_clrBtnText:Number;
	private var m_clrBtnHover:Number;
	private var m_clrBtnPressed:Number;
	private var m_clrCellOver:Number;
	private var m_clrCellOut1:Number;
	private var m_clrCellOut2:Number;
	private var m_clrCellPress:Number;
	private var m_data:Object;
	private var m_strThemeId:String;

	static private var m_instance:pseudo.look.AquaLook = null;

	//
	// PUBLIC METHODS
	//
	static public function getInstance():pseudo.look.AquaLook
	{
		if(!m_instance) m_instance = new pseudo.look.AquaLook();
		return m_instance;
	}

	public function setData(data:Object):Void
	{
		m_data = data;
		m_strThemeId = m_data.getAttr("default");
		var arrThemes:Array = data.getNodes("theme");
		for(var i:Number = 0; i , arrThemes.length; i++)
			if(arrThemes[i].getAttr("id") == m_strThemeId)
			{
				fromXML(arrThemes[i]);
				break;
			}
	}

	public function getId():String
	{
		return m_data.getAttr("id");
	}

	public function isSameTheme(xmlTheme:XML):Boolean
	{
		var xmlCurTheme:XML = toXML();
		return xmlCurTheme.attributes.id == xmlTheme.attributes.id;
	}

	//
	// CONTENT METHODS (begin)
	//
	public function fillContent(movie:MovieClip, ctrls:Object):Void
	{
		movie.addListener("update", this, onUpdateContent);
		var list:MovieClip = movie.addItem(ctrls.List, "list", 1);
		list.setCellClass(ctrls.CellRenderer);
		list.addListener("changed", this, onChangeTheme, list);
		list.setData({border:6});
		var arrListData:Array = new Array();
		var arrXMLThemes:Array = m_data.getNodes("theme");
		var nSelId:Number = -1;
		for(var i:Number = 0; i < arrXMLThemes.length; i++)
		{
			arrListData.push(({data:arrXMLThemes[i], text:arrXMLThemes[i].getAttr("name")}));
			if(arrXMLThemes[i].getAttr("id") == m_strThemeId) nSelId = i;
		}
		list.setListData(arrListData);
		list.setSelCell(nSelId);
	}

	private function onUpdateContent(movie:MovieClip, nW:Number, nH:Number):Void
	{
		var list:MovieClip = movie.getItem("list");
		list.setSize(nW, nH);
	}

	private function onChangeTheme(list:Object):Void
	{
		var data:Object = list.getSelData().data;
		fromXML(data);
		_global.themesManager.setLook(this);
		_global.main.update();
		_global.main.draw();
	}

	public function setThemeId(strId:String):Void
	{
		var arrXMLThemes:Array = m_data.getNodes("theme");
		for(var i:Number = 0; i < arrXMLThemes.length; i++)
			if(arrXMLThemes[i].getAttr("id") == strId)
			{
				fromXML(arrXMLThemes[i]);
				break;
			}
	}

  public function toXML():XML
  {
    var xml:XML = new XML();
		var node:XMLNode = xml.createElement("theme");
		node.attributes.id = m_strThemeId;
		xml.appendChild(node);
    return xml.childNodes[0];
  }

	public function fromXML(data:Object):Void
	{
		m_strThemeId = data.getAttr("id");
	}

	public function getThemeId():String
	{
		return m_strThemeId;
	}

	//
	// CONTENT METHODS (end)
	//

	public function getIconPath(strIcon:String):String
	{
		switch(strIcon)
		{
			case "newForum":
				return "themes/stdLook_new_forum.swf";
			case "oldForum":
			case "newUser":
				return "themes/stdLook_new_user.swf";
			case "forgotPass":
				return "themes/stdLook_forgot_pass.swf";
			case "search":
				return "themes/stdLook_search.swf";
			case "members":
				return "themes/stdLook_members.swf";
			case "groups":
				return "themes/stdLook_groups.swf";
			case "profile":
				return "themes/stdLook_profile.swf";
			case "private_messages":
				return "themes/stdLook_private_messages.swf";
			case "themes":
				return "themes/stdLook_themes.swf";
			case "faq":
				return "themes/stdLook_faq.swf";
			case "chat":
				return "themes/stdLook_chat.swf";
			case "stats":
				return "themes/stdLook_stats.swf";
			case "about":
				return "themes/stdLook_about.swf";
			case "iconWarning":
				return "themes/stdLook_iconWarning.swf";
			case "iconInfo":
				return "themes/stdLook_iconInfo.swf";
			case "iconQuestion":
				return "themes/stdLook_iconQuestion.swf";
			case "iconError":
				return "themes/stdLook_iconError.swf";
			case "contentPreloader":
				return "themes/stdLook_contentPreloader.swf";
		}
		return null;
	}

	public function getCursorPath(strCursor:String):String
	{
		switch(strCursor)
		{
			case "diagResize1":
				return "themes/stdLook_diagResize1.swf";
			case "horzResize":
				return "themes/stdLook_horzResize.swf";
			case "vertResize":
				return "themes/stdLook_vertResize.swf";
		}
		return null;
	}

	public function getCursors():Array
	{
		return new Array("diagResize1", "horzResize", "vertResize");
	}

	//
	// IBaseLook implementation
	//
	public function getBorder(strBorder:String, data:Object):Number
	{
		var nBorderPos:Number = 0;
		switch(strBorder)
		{
			case "top": nBorderPos = 1; break;
			case "left": nBorderPos = 2; break;
			case "bottom": nBorderPos = 4; break;
			case "right": nBorderPos = 8; break;
		}
		switch(data.type)
		{
			case "main":
			case "titledIconButton":
			case "url":
			case "gallery":
				return 0;
			case "resizeTitle":
				return 1;
			default:
				return (data.border == undefined || data.border == null) || data.border & nBorderPos ? 1 : 0;
		}
		return 0;
	}

	public function getMargin(strMargin:String, data:Object):Number
	{
		var nMargin:Number = 0;
		var strType:String = data.type;
		switch(data.className)
		{
			case "WindowTitle":
				strType = "titleBtnBack";
				break;
			case "Label":
				switch(strType)
				{
					case "edit":
					case "textArea":
					case "comboBoxTitle":
					case "info":
						break;
					//case "titleBtnBack":
					//case "resizeTitle":
					default:
						strType = "label";
						break;
				}
				break;
		}
		switch(strType)
		{
			case "main":
				nMargin = 5;
				break;
			case "cell":
				nMargin = 2 + getBorder(strMargin, data);
				break;
			case "titleBtnBack":
				switch(strMargin)
				{
					case "right": nMargin = 8 + getBorder(strMargin, data); break;
					case "left": nMargin = 8 + getBorder(strMargin, data); break;
					case "top":
					case "bottom":
						nMargin = 1 + getBorder(strMargin, data);
						break;
				}
				break;
			case "resizeTitle":
				switch(strMargin)
				{
					case "left": nMargin = 8 + getBorder(strMargin, data); break;
					case "right": nMargin = 23 + getBorder(strMargin, data); break;
					case "top":
					case "bottom":
						nMargin = 2 + getBorder(strMargin, data);
						break;
				}
				break;
			case "edit":
			case "textArea":
			case "comboBoxTitle":
			case "info":
				nMargin = strMargin == "left" || strMargin == "right" ? 2 : 0;
				break;
			case "label":
				nMargin = 0;
				break;
			case "gallery":
				nMargin = 5 + getBorder(strMargin, data);
				break;
			case "titledIconButton":
			case "url":
				break;
			case "cellThread":
				nMargin = getBorder(strMargin, data) + 3;
				break;
			case "checkbox":
				nMargin = getBorder(strMargin, data) + (strMargin == "left" ? 14 : 0);
				break;
			default:
				nMargin = getBorder(strMargin, data);
				break;
		}
		return nMargin;
	}

	public function updateMask(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		pseudo.Global.drawRect(movie, 0, 0, nW, nH);
	}

	public function draw(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.className)
		{
			case "ComboBox":
				drawComboBox(movie, nW, nH, data);
				break;
			case "TextArea":
			case "Button":
				drawButton(movie, nW, nH, data);
				break;
			case "Pane":
			case "List":
				drawPane(movie, nW, nH, data);
				break;
			case "Label":
				drawLabel(movie, nW, nH, data);
				break;
			case "TitledIcon":
				drawIconLayer(movie, nW, nH, data);
				break;
			case "Main":
				drawMain(movie, nW, nH, data);
				break;
			case "CellText":
			case "CellIconText":
				drawCellText(movie, nW, nH, data);
				break;
			case "CellTree":
				drawCellTree(movie, nW, nH, data);
				break;
			case "CellThread":
				drawCellThread(movie, nW, nH, data);
				break;
			default:
				drawMovie(movie, nW, nH, data);
				break;
		}
	}

	public function getTextFormat(data:Object):TextFormat
	{
		var tf:TextFormat = new TextFormat();
		switch(data.type)
		{
			//case "label":
			//case "edit":
			default:
				tf.color = m_clrBtnText;
				tf.size = 12;
				tf.font = "Tahoma";
				break;
		}
		return tf;
	}

	public function getTextDecoration(strType:String, data:Object):String
	{
		var strRes:String = "";
		switch(strType)
		{
			case "open":
				switch(data.type)
				{
					case "cellThread":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>" +
							(data.mode == "name" ? "<b>" : "");
						break;
					case "label":
					case "edit":
					case "info":
					case "textArea":
					case "comboBoxTitle":
					case "checkbox":
					case "cellText":
					case "cellIconText":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>";
						break;
					case "cellTree":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='"
							+ (data.cellType == 1 ? "12" : "11") + "'>";
						break;
					case "topTime":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='16'><b>";
						break;
					case "comboBoxCell":
						switch(data.mode)
						{
							case "over":
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrHilightText) + "' face='Tahoma' size='12'>";
								break;
							//case "out":
							default:
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>";
								break;
						}
						break;
					case "url":
						switch(data.mode)
						{
							case "over":
							case "press":
								strRes = "<u><font color='#5274b4' face='Tahoma' size='12'>";
								break;
							//case "out":
							default:
								strRes = "<font color='#5274b4' face='Tahoma' size='12'>";
								break;
						}
						break;
					case "titleBtnBack":
						switch(data.mode)
						{
							case "out":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(0xffffff) + "' face='Tahoma' size='12'><b>";
								break;
							case "over":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'><b>";
								break;
							case "disabled":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(0x303030) + "' face='Tahoma' size='12'><b>";
								break;
						}
					break;
					case "resizeTitle":
						switch(data.mode)
						{
							case "out":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'><b>";
								break;
							case "over":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrHighlight) + "' face='Tahoma' size='12'><b>";
								break;
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrHilightText) + "' face='Tahoma' size='12'><b>";
								break;
							case "disabled":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(0x303030) + "' face='Tahoma' size='12'><b>";
								break;
						}
					break;
					case "edit":
						switch(data.mode)
						{
							case "out":
							case "over":
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>";
								break;
							case "disabled":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(0x303030) + "' face='Tahoma' size='12'>";
								break;
						}
					break;
					default:
						switch(data.mode)
						{
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrHilightText) + "' face='Tahoma' size='12'>";
								break;
							case "disabled":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(0xcccccc) + "' face='Tahoma' size='12'>";
								break;
							default:
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>";
								break;
						}
					break;
				}
				break;
			case "close":
				switch(data.type)
				{
					case "resizeTitle":
					case "titleBtnBack":
						strRes = "</b></font>";
						break;
					case "url":
						strRes = (data.mode != "out" ? "<u>" : "") + "</font>";
						break;
					case "cellThread":
						strRes = (data.mode == "name" ? "</b>" : "") + "</font>";
						break;
					//case "edit":
					default:
						strRes = "</font>";
						break;
				}
			break;
		}
		return strRes;
	}

	public function getParams(data:Object):Object
	{
		switch(data.type)
		{
			case "wndTitle": return getWndTitleParams();
			case "resizeBtn": return getResizeBtnParams();
			case "resizeLine": return getResizeLineParams(data.align, data.data);
			case "checkbox": return {align:"left"};
			case "cellIconText":
			case "cellTree": return getTreeParams();
		}
		return null;
	}

	//
	// IWindowManagerLook implementation
	//
	public function drawResizeFrame(movie:MovieClip, nX:Number, nY:Number, nW:Number, nH:Number):Void
	{
		movie.clear();
		var clr:Number = 0xa0a0a0;
		pseudo.Global.drawRect(movie, nX - 1, nY - 1, nW + 2, 2, clr);
		pseudo.Global.drawRect(movie, nX - 1, nY + 1, 2, nH, clr);
		pseudo.Global.drawRect(movie, nX + 1, nY + nH - 1, nW, 2, clr);
		pseudo.Global.drawRect(movie, nX + nW - 1, nY + 1, 2, nH, clr);
	}

	//
	// PRIVATE METHODS
	//

	private function AquaLook()
	{
		m_strThemeId = "";
		m_clrHighlight = 0x0a246a;
		m_clrHilightText = 0xffffff;
		m_clrBtnText = 0;
		m_clrBtnHover = 0x979cac;
		m_clrBtnPressed = 0x6f7a99;
		m_clrCellOver = 0xfafafa;
		m_clrCellOut1 = 0xe4e4e4;
		m_clrCellOut2 = 0xdddddd;
		m_clrCellPress = 0xffffff;
	}

	private function drawMain(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		pseudo.Global.drawRect(movie, 0, 0, nW, nH, 0xfbfbfb);
	}

	private function drawMovie(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "resizeLine":
				drawResizeLine(movie, 0, 0, nW, nH, data);
				break;
			case "sign":
				drawSign(movie, nW, nH, data);
				break;
			case "iconLayer":
				drawIconLayer(movie, nW, nH, data);
				break;
		}
	}


	private function drawCellText(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		var clr:Number = 0xffffff;
		switch(data.type)
		{
			case "comboBoxCell":
				switch(data.mode)
				{
					case "over": clr = m_clrBtnHover; break;
					case "press": clr = m_clrBtnHover; break;
					default: clr = 0xffffff; break;
				}
				break;
			default:
				switch(data.mode)
				{
					case "over": clr = 0xfafafa; break;
					case "press": clr = 0xffffff; break;
					default: clr = data.ind % 2 ? 0xdddddd : 0xe4e4e4; break;
				}
				break;
		}
		pseudo.Global.drawRect(movie, 0, 0, nW, nH, clr);
	}

	private function drawCellTree(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		var clr:Number = 0xffffff;
		switch(data.mode)
		{
			case "over":
				clr = m_clrCellOver;
				break;
			case "press":
				clr = m_clrCellPress;
				break;
			default:
				clr = data.clrInd % 2 ? m_clrCellOut1 : m_clrCellOut2;
				break;
		}
		pseudo.Global.drawRect(movie, 0, 0, nW, nH, clr);
		var params:Object = getTreeParams();
		var off:Number = params.offStart + (data.lines.length - 1) * params.off;
		var dh:Number = Math.round(nH / 2);
		var alpha = 30;
		if(data.ind)
		{
			var lines:Array = data.lines;
			for(var i:Number = 0; i < lines.length; i++)
				if(lines[i])
					pseudo.Global.drawRect(movie, params.offStart + i * params.off, 0, 1, nH, 0x303030, alpha);
			if(data.last) pseudo.Global.drawRect(movie, off, 0, 1, dh, 0x303030, alpha);
		}
		else if(!data.last)
			pseudo.Global.drawRect(movie, off, dh, 1, nH - dh, 0x303030, alpha);
		if(data.cellType == 1)
		{
			var size:Number = 9;
			var dsize:Number = 4;
			var x:Number = off - dsize;
			var y:Number = Math.round((nH - size) / 2);
			//drawDrop(movie, x, y, size, size, 0x30aa30, data);
			drawRoundDrop(movie, x - 0.25, y - 0.25, size + 0.5, size + 0.5, (data.visible || !data.hasChildren) ? 0xeeeeee : 0xcfeca4, data);
			if(data.hasChildren)
			{
				// draw minus line
				pseudo.Global.drawRect(movie, x + 2, y + dsize, size - 4, 1, 0x303030);
				if(data.visible)
				{ // draw -| lines
					pseudo.Global.drawRect(movie, x + size, y + dsize, params.off - dsize, 1, 0x303030, alpha);
					pseudo.Global.drawRect(movie, off + params.off, y + dsize + 1, 1, nH - y - dsize - 1, 0x303030, alpha);
				}
				else // draw plus line
					pseudo.Global.drawRect(movie, x + dsize, y + 2, 1, size - 4, 0x303030);
			}
		}
	}

	private function drawCellThread(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		var nTitleH:Number = 50;
		pseudo.Global.drawRect(movie, 4, 4, nW - 8, nTitleH, 0xe5e5e5);
		pseudo.Global.drawRect(movie, 4, nTitleH + 4, nW - 8, nH - nTitleH - 8, 0xffffff);
		switch(data.mode)
		{
			case "over":
				pseudo.Global.drawFrame(movie, 2, 2, nW - 4, nH - 4, 0xc0c0c0, 100, 2);
				break;
			case "press":
				pseudo.Global.drawFrame(movie, 2, 2, nW - 4, nH - 4, 0x353535, 100, 2);
				break;
			default:
				//pseudo.Global.drawFrame(movie, 2, 2, nW - 4, nH - 4, 0xffffff, 100, 2);
				break;
		}
	}

	private function drawComboBoxBtn(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		movie.beginFill(0x97a4b3, 35);
		drawRoundRect(movie, 1, 1, nW - 1, nH - 1, 2);
		movie.endFill();
		var size:Number = Math.min(nW, nH) / 4;
		var cw:Number = nW / 2;
		var ch:Number = nH * 3 / 4;
		var halfSize:Number = size / 2;
		movie.beginFill(0, 80);
		movie.moveTo();
		movie.moveTo(cw, ch + halfSize);
		movie.lineTo(cw - halfSize, ch - halfSize);
		movie.lineTo(cw + halfSize, ch - halfSize);
		movie.lineTo(cw, ch + halfSize);
		movie.endFill();
		ch = nH / 4;
		movie.beginFill(0, 80);
		movie.moveTo();
		movie.moveTo(cw, ch - halfSize);
		movie.lineTo(cw - halfSize, ch + halfSize);
		movie.lineTo(cw + halfSize, ch + halfSize);
		movie.lineTo(cw, ch - halfSize);
		movie.endFill();
	}

	private function drawComboBox(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		switch(data.mode)
		{
			default:
				movie.beginFill(0x8f8f8f, 100);
				drawRoundRect(movie, 0, 0, nW, nH, 3);
				movie.endFill();
				var colors:Array = new Array(0xababab, 0xfafafa);
				var alphas:Array = new Array(100, 100);
				var ratios:Array = new Array(0, 180);
				var matrix:Object = {matrixType:"box", x:1, y:1, w:nW - 2, h:nH - 2, r:Math.PI / 2};
				movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
				drawRoundRect(movie, 1, 1, nW - 1, nH - 1, 2);
				movie.endFill();
				// highlight
				colors = new Array(0xffffff, 0xffffff, 0xffffff);
				alphas = new Array(100, 50, 0);
				ratios = new Array(10, 110, 110);
				matrix = {matrixType:"box", x:1, y:1, w:nW - 2, h:nH - 2, r:Math.PI / 2};
				movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
				drawRoundRect(movie, 1, 1, nW - 1, nH - 1, 2);
				movie.endFill();
				break;
		}
	}

	private function drawButton(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.mode)
		{
			case "press":
				drawBtnPress(movie, nW, nH, data);
				break;
			case "over":
				drawBtnOver(movie, nW, nH, data);
				break;
			case "out":
				drawBtnOut(movie, nW, nH, data);
				break;
		}
	}

	private function drawBtnOut(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "resizeLeft":
			case "resizeRight":
			case "resizeTop":
			case "resizeBottom":
				drawResizeBtnLayer(movie, nW, nH, data);
				break;
			case "resizeTitle":
				drawResizeTitle(movie, nW, nH, data);
				break;
			case "edit":
				drawLayer(movie, nW, nH, 0xffffff, 0x303030, data.border);
				break;
			case "scrollBack":
				drawScrollBack(movie, nW, nH, data);
				break;
			case "comboBoxBtn":
				drawComboBoxBtn(movie, nW, nH, data);
				break;
			case "scroll":
				movie.clear();
				drawRoundDrop(movie, 0, 0, nW, nH, 0xc0c9d1, data);
				break;
			case "scrollLow":
			case "scrollHi":
				drawScrollLayer(movie, nW, nH, data);
				break;
			case "titledIconButton":
			case "iconButton": // this btn without background
			case "url":
				movie.clear();
				break;
			case "titleBtnBack":
				drawTitleBack(movie, nW, nH, data);
				break;
			case "titleBtnHide":
			case "titleBtnMinimize":
			case "titleBtnClose":
				drawTitleButton(movie, nW, nH, data);
				break;
			case "resizeHandle":
				drawResizeHandleBtn(movie, nW, nH, 0x8f8f8f);
				break;
			case "comboBox":
				drawLayer(movie, nW, nH, 0xffffff, 0x303030, data.border);
				break;
			case "btnGo":
				movie.clear();
				drawRoundDrop(movie, 0, 0, nW, nH, 0xb5bec8, data);
				drawGo(movie, 0, 0, nW, nH, 0);
				break;
			case "checkbox":
				drawBtnCheckBox(movie, nW, nH, data);
				break;
			default:
				movie.clear();
				if(data.state)
					drawRoundDrop(movie, 0, 0, nW, nH, data.state == "sunken" ? 0x6b7e94 : 0xdddddd, data);
				else
					drawRoundDrop(movie, 0, 0, nW, nH, 0xb5bec8, data);
				break;
		}
	}

	private function drawBtnOver(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "resizeLeft":
			case "resizeRight":
			case "resizeTop":
			case "resizeBottom":
				drawResizeBtnLayer(movie, nW, nH, data);
				break;
			case "resizeTitle":
				drawResizeTitle(movie, nW, nH, data);
				break;
			case "edit":
				drawLayer(movie, nW, nH, 0xffffff, 0xc7c7c7, data.border);
				break;
			case "scrollBack":
				break;
			case "comboBoxBtn":
				drawComboBoxBtn(movie, nW, nH, data);
				break;
			case "scroll":
				movie.clear();
				drawRoundDrop(movie, 0, 0, nW, nH, 0xccd5dd, data);
				break;
			case "scrollLow":
			case "scrollHi":
				drawScrollLayer(movie, nW, nH, data);
				break;
			case "titledIconButton":
			case "url":
				movie.clear();
				break;
			case "titleBtnBack":
				drawTitleBack(movie, nW, nH, data);
				break;
			case "titleBtnHide":
			case "titleBtnMinimize":
			case "titleBtnClose":
				drawTitleButton(movie, nW, nH, data);
				break;
			case "resizeHandle":
				drawResizeHandleBtn(movie, nW, nH, 0x8f8f8f);
				break;
			case "comboBox":
				drawLayer(movie, nW, nH, 0xffffff, m_clrHighlight, data.border);
				break;
			case "btnGo":
				movie.clear();
				drawRoundDrop(movie, 0, 0, nW, nH, 0xc8cfd7, data);
				drawGo(movie, 0, 0, nW, nH, 0);
				break;
			case "checkbox":
				drawBtnCheckBox(movie, nW, nH, data);
				break;
			default:
				movie.clear();
				if(data.state)
					drawRoundDrop(movie, 0, 0, nW, nH, data.state == "sunken" ? 0x8595a7 : 0xeeeeee, data);
				else
					drawRoundDrop(movie, 0, 0, nW, nH, 0xc8cfd7, data);
				break;
		}
	}

	private function drawBtnPress(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "resizeLeft":
			case "resizeRight":
			case "resizeTop":
			case "resizeBottom":
				drawResizeBtnLayer(movie, nW, nH, data, m_clrBtnPressed, m_clrHighlight, m_clrHilightText);
				break;
			case "resizeTitle":
				drawResizeTitle(movie, nW, nH, data);
				break;
			case "edit":
				drawLayer(movie, nW, nH, 0xffffff, 0xa0a0a0, data.border);
				break;
			case "scrollBack":
				break;
			case "comboBoxBtn":
				drawComboBoxBtn(movie, nW, nH, data);
				break;
			case "scroll":
				movie.clear();
				drawRoundDrop(movie, 0, 0, nW, nH, 0xC0C9D1, data);
				break;
			case "scrollLow":
			case "scrollHi":
				drawScrollLayer(movie, nW, nH, data);
				break;
			case "titledIconButton":
			case "url":
				movie.clear();
				break;
			case "titleBtnBack":
				drawTitleBack(movie, nW, nH, data);
				break;
			case "titleBtnHide":
			case "titleBtnMinimize":
			case "titleBtnClose":
				drawTitleButton(movie, nW, nH, data);
				break;
			case "resizeHandle":
				drawResizeHandleBtn(movie, nW, nH, 0x8f8f8f);
				break;
			case "comboBox":
				drawLayer(movie, nW, nH, 0xffffff, m_clrHighlight, data.border);
				break;
			case "btnGo":
				movie.clear();
				drawRoundDrop(movie, 0, 0, nW, nH, 0xb5bec8, data);
				drawGo(movie, 0, 0, nW, nH, 0xffffff);
				break;
			case "checkbox":
				drawBtnCheckBox(movie, nW, nH, data);
				break;
			default:
				movie.clear();
				if(data.state)
					drawRoundDrop(movie, 0, 0, nW, nH, data.state == "sunken" ? 0x6b7e94 : 0xdddddd, data);
				else
					drawRoundDrop(movie, 0, 0, nW, nH, 0xb5bec8, data);
				break;
		}
	}

	private function drawTitleBack(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		drawBaseTitle(movie, nW, nH, data);
	}

	private function drawResizeHandleBtn(movie:MovieClip, nW:Number, nH:Number, clr:Number):Void
	{
		movie.clear();
		movie.lineStyle(1, clr);
		movie.beginFill(0xffffff, 100);
		drawFillRect(movie, 0.5, 0.5, nW - 1, nH - 1);
		movie.endFill();
		movie.lineStyle(undefined);
		for(var i:Number = 3; i < nW - 2; i += 3)
		{
			drawLine(movie, i, nH - 3, nW - 3, i, clr);
			i++;
			drawLine(movie, i, nH - 3, nW - 3, i, clr);
		}
	}

	private function drawLine(movie:MovieClip, x1:Number, y1:Number, x2:Number, y2:Number, clr:Number, alpha:Number):Void
	{
		var dx:Number = Math.abs(x2 - x1);
		var dy:Number = Math.abs(y2 - y1);
		var sx:Number = x2 >= x1 ? 1 : -1;
		var sy:Number = y2 >= y1 ? 1 : -1;
		pseudo.Global.drawRect(movie, x1, y1, 1, 1, clr, alpha);
		if(dy <= dx)
		{
			var d1:Number = dy << 1;
			var d:Number  = d1 - dx;
			var d2:Number = ( dy - dx ) << 1;
			var x:Number = x1 + sx;
			var y:Number = y1;
			for(var i:Number = 1; i <= dx; i++)
			{
				if (d > 0)
				{
					d += d2;
					y += sy;
				}
				else d += d1;
				pseudo.Global.drawRect(movie, x, y, 1, 1, clr, alpha);
				x += sx;
			}
		}
		else
		{
			var d1:Number = dx << 1;
			var d:Number  = d1 - dy;
			var d2:Number = (dx - dy) << 1;
			var x:Number = x1;
			var y:Number = y1 + sy;
			for (var i:Number = 1; i <= dy; i++)
			{
				if( d > 0)
				{
					d += d2;
					x += sx;
				}
				else d += d1;
				pseudo.Global.drawRect(movie, x, y, 1, 1, clr, alpha);
				y += sy;
			}
		}
	}

	private function drawTitleButton(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		movie._alpha = 100; // xxx this line fixes alpha value, changed in other themes
		if(!data.faded || data.mode != "out")
		{
			var clr:Number = data.mode == "press" ? 0xffffff : 0;
			var alpha:Number = data.mode == "press" ? 100 : 60;
			switch(data.type)
			{
				case "titleBtnHide":
					drawDrop(movie, 0, 0, nW, nH, 0x8add00, data);
					if(data.mode == "press" || data.mode == "over")
						drawMinus(movie, 0, 0, nW, nH, clr, alpha);
					break;
				case "titleBtnMinimize":
					drawDrop(movie, 0, 0, nW, nH, 0xffd220, data);
					if(data.mode == "press" || data.mode == "over")
						drawPlus(movie, 0, 0, nW, nH, clr, alpha);
					break;
				case "titleBtnClose":
					drawDrop(movie, 0, 0, nW, nH, 0xf42d2d, data);
					if(data.mode == "press" || data.mode == "over")
						drawCross(movie, 0, 0, nW, nH, clr, alpha);
					break;
			}
		}
		else drawDrop(movie, 0, 0, nW, nH, 0xf0f0f0);
	}

	private function drawPane(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "utilitiesPane":
			case "infoPane":
			case "comboBoxPane":
				drawLayer(movie, nW, nH, 0xffffff, 0x8f8f8f, data.border);
				break;
			case "topPane":
				drawLayer(movie, nW, nH, 0xdddddd, 0x8f8f8f, data.border);
				break;
			default:
				drawLayer(movie, nW, nH, 0xf0f0f0, 0x8f8f8f, data.border);
				break;
		}
	}

	private function drawResizeLine(movie:MovieClip, nX:Number, nY:Number, nW:Number, nH:Number):Void
	{
		movie.clear();
		pseudo.Global.drawRect(movie, nX, nY, nW, nH, 0xa0a0a0);
	}

	private function drawSign(movie:MovieClip, w:Number, h:Number):Void
	{
		var strPath:String = getIconPath("contentPreloader");
		if(movie["icon"].iconPath != strPath)
		{ // we load icon only if it is new or different icon
			var listener:Object = new Object();
			listener.w = w;
			listener.h = h;
			listener.movie = movie;
			listener.path = strPath;
			listener.onLoadInit = function(target:MovieClip):Void
			{
				target._x = Math.round(-target._width / 2);
				target._y = Math.round(-target._height / 2);
				target.iconPath = this.path;
				this.movie.fireEvent("onLoadIcon");
				delete this.loader;
				delete this;
			}
			var loader:MovieClipLoader = new MovieClipLoader();
			listener.loader = loader;
			loader.addListener(listener);
			loader.loadClip(strPath, movie.createEmptyMovieClip("icon", 2));
		}
	}

	private function drawLabel(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "edit":
				drawButton(movie, nW, nH, data);
				break;
			case "info":
				movie.clear();
				pseudo.Global.drawRect(movie, 0, 0, nW, nH, 0xf0f0f0);
				break;
		}
	}

	private function drawIconLayer(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		var strPath:String = getIconPath(data.icon);
		var icon:MovieClip = movie["icon"];
		var iconH:Number = data.iconH ? data.iconH : nH;
		var iconW:Number = nW;
		if(!icon || icon.iconPath != strPath)
		{ // we are loading icon only if it is new or different icon
			var listener:Object = new Object();
			listener.onLoadInit = function(target:MovieClip):Void
			{
				target._x = Math.round((iconW - target._width) / 2);
				target._y = Math.round((iconH - target._height) / 2);
				target.iconPath = strPath;
				if(data.drawBg)
				{
					movie.clear();
					if(data.fldText)
						pseudo.Global.drawRect(movie, target._x, target._y, target._width, iconH + 2, 0, 0);
					else
						pseudo.Global.drawRect(movie, 0, 0, iconW, iconH, 0, 0);
				}
				delete this.loader;
				delete this;
				movie.fireEvent("loaded", target);
			}
			var loader:MovieClipLoader = new MovieClipLoader();
			listener.loader = loader;
			loader.addListener(listener);
			loader.loadClip(strPath, movie.createEmptyMovieClip("icon", 2));
		}
		else
		{
			movie.fireEvent("loaded", icon);
			icon._x = Math.round((iconW - icon._width) / 2);
			icon._y = Math.round((iconH - icon._height) / 2);
			if(data.drawBg)
			{
				movie.clear();
				if(data.fldText)
					pseudo.Global.drawRect(movie, icon._x, icon._y, icon._width, iconH + 2, 0, 0);
				else
					pseudo.Global.drawRect(movie, 0, 0, iconW, iconH, 0, 0);
			}
		}
		data.fldText.background = false; // these 2 fields should be set to false
		data.fldText.border = false;
		var x:Number = data.fldText._x;
		var y:Number = data.fldText._y;
		var w:Number = data.fldText._width;
		var h:Number = data.fldText._height;
		var clr = new Color(movie["icon"]);
		var matrix:Object;
		switch(data.mode)
		{
			case "over":
				matrix = {ra:'85', rb:'0', ga:'85', gb:'0', ba:'85', bb:'0'};
				var colors:Array = [0x576877, 0xf4f4f4];
				var alphas:Array = [100, 100];
				var ratios:Array = [0, 210];
				var matrixGrad = {matrixType:"box", x:x, y:y, w:w, h:h, r:Math.PI / 2};
				movie.beginGradientFill("linear", colors, alphas, ratios, matrixGrad);
				drawRoundRect(movie, x, y, x + w, y + h, 3);
				movie.endFill();
				colors = [0xffffff, 0xffffff];
				alphas = [100, 30];
				ratios = [10, 255];
				matrixGrad = {matrixType:"box", x:x, y:y, w:w, h:h * 0.5, r:Math.PI / 2};
				movie.beginGradientFill("linear", colors, alphas, ratios, matrixGrad);
				drawRoundRect(movie, x, y, x + w, y + h * 0.5, 3);
				movie.endFill();
				drawRoundRect(movie, x + 0.5, y + 0.5, x + w - 0.5, y + h - 0.5, 3, 0xaaaaaa);
				break;
			case "press":
				matrix = {ra:'75', rb:'0', ga:'75', gb:'0', ba:'80', bb:'10'};
				movie.beginFill(m_clrBtnPressed, 100);
				drawRoundRect(movie, x, y, x + w, y + h, 3);
				movie.endFill();
				break;
			case "out":
				matrix = {ra:'100', rb:'0', ga:'100', gb:'0', ba:'100', bb:'0'};
				break;
		}
		clr.setTransform(matrix);
	}

	private function drawLayer(movie:MovieClip, nW:Number, nH:Number, clrFill:Number, clrBorder:Number, nBorder:Number):Void
	{
		if(nBorder == undefined || nBorder == null) nBorder = 1 + 2 + 4 + 8; // draw all border lines on default
		movie.clear();
		pseudo.Global.drawRect(movie, 0, 0, nW, nH, clrFill);
    if(nBorder & 1) pseudo.Global.drawRect(movie, 0, 0, nW, 1, clrBorder);
    if(nBorder & 2) pseudo.Global.drawRect(movie, 0, 0, 1, nH, clrBorder);
    if(nBorder & 4) pseudo.Global.drawRect(movie, 0, nH - 1, nW, 1, clrBorder);
    if(nBorder & 8) pseudo.Global.drawRect(movie, nW - 1, 0, 1, nH, clrBorder);
	}

	private function drawCheckBox(movie:MovieClip, x:Number, y:Number, data:Object):Void
	{
		movie.beginFill(0x8f8f8f, 100);
		drawRoundRect(movie, x, y, x + 13, y + 13, 1);
		movie.endFill();
		;
		var colors:Array = new Array(
			data.state == "sunken" ? 0x677789 : 0xa0a0a0,
			data.state == "sunken" ? 0xe2e6e9 : 0xf5f5f5
		);
		var alphas:Array = new Array(100, 100);
		var ratios:Array = new Array(0, 180);
		var matrix:Object = {matrixType:"box", x:x + 1, y:y + 1, w:11, h:11, r:Math.PI / 2};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		drawRoundRect(movie, x + 1, y + 1, x + 12, y + 12, 1);
		movie.endFill();
		// highlight
		colors = new Array(0xffffff, 0xffffff, 0xffffff);
		alphas = new Array(90, 45, 0);
		ratios = new Array(10, 110, 110);
		matrix = {matrixType:"box", x:x + 1, y:y + 1, w:11, h:11, r:Math.PI / 2};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		drawRoundRect(movie, x + 1, y + 1, x + 12, y + 12, 1);
		movie.endFill();
		switch(data.mode)
		{
			case "press":
				fillRoundRect(movie, x, y, x + 13, y + 13, 1, 0, 10);
				break;
			case "over":
				fillRoundRect(movie, x, y, x + 13, y + 13, 1, 0xffffff, 30);
				break;
		}
		if(data.state == "sunken")
		{
			movie.lineStyle(2);
			movie.moveTo(x + 3, y + 4);
			movie.lineTo(x + 6, y + 9);
			movie.lineTo(x + 12, y - 1);
		}
	}

	private function drawBtnCheckBox(movie:MovieClip, w:Number, h:Number, data:Object):Void
	{
		movie.clear();
		pseudo.Global.drawRect(movie, 0, 0, w, h, 0, 0);
		drawCheckBox(movie, 0, Math.round((h - 13) / 2 - 1), data);
	}

	private function drawBaseTitle(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		var colors:Array = [0xefefef, 0xcacaca];
		var alphas:Array = [100, 100];
		var ratios:Array = [0, 0xff];
		var matrix = {matrixType:"box", x:0, y:0, w:nW, h:nH, r:Math.PI / 2};
		movie.clear();
		var r:Number = 8;
		movie.lineStyle(1, 0x8f8f8f);
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		// theta = 45 degrees in radians
		var theta:Number = Math.PI / 4;
		movie.moveTo(r + 0.5, 0.5);
		movie.lineTo(nW - r - 0.5, 0.5);
		//angle is currently 90 degrees
		var angle:Number = -Math.PI / 2;
		// draw tr corner in two parts
		var cx:Number = nW - r - 0.5 + (Math.cos(angle + (theta / 2)) * r / Math.cos(theta / 2));
		var cy:Number = r + 0.5 + (Math.sin(angle + (theta / 2)) * r / Math.cos(theta / 2));
		var px:Number = nW - r - 0.5 + (Math.cos(angle + theta) * r);
		var py:Number = r + 0.5 + (Math.sin(angle + theta) * r);
		movie.curveTo(cx, cy, px, py);
		angle += theta;
		cx = nW - r - 0.5 + (Math.cos(angle + (theta / 2)) * r / Math.cos(theta / 2));
		cy = r + 0.5 + (Math.sin(angle + (theta / 2)) * r / Math.cos(theta / 2));
		px = nW - r - 0.5 + (Math.cos(angle + theta) * r);
		py = r + 0.5 + (Math.sin(angle + theta) * r);
		movie.curveTo(cx, cy, px, py);
		var bottom:Boolean = !data.border || data.border & 4;
		movie.lineTo(nW - 0.5, nH - (bottom ? 0.5 : 0));
		if(!bottom) movie.lineStyle(undefined);
		movie.lineTo(0.5, nH - (bottom ? 0.5 : 0));
		movie.lineStyle(1, 0x8f8f8f);
		movie.lineTo(0.5, r + 0.5);

		// draw tl corner
		angle = Math.PI;
		cx = r + 0.5 + (Math.cos(angle + (theta / 2)) * r / Math.cos(theta / 2));
		cy = r + 0.5 + (Math.sin(angle + (theta / 2)) * r / Math.cos(theta / 2));
		px = r + 0.5 + (Math.cos(angle+  theta) * r);
		py = r + 0.5 + (Math.sin(angle + theta) * r);
		movie.curveTo(cx, cy, px, py);
		angle += theta;
		cx = r + 0.5 + (Math.cos(angle + (theta / 2)) * r / Math.cos(theta / 2));
		cy = r + 0.5 + (Math.sin(angle + (theta / 2)) * r / Math.cos(theta / 2));
		px = r + 0.5 + (Math.cos(angle + theta) * r);
		py = r + 0.5 + (Math.sin(angle + theta) * r);
		movie.curveTo(cx, cy, px, py);

		movie.endFill();
		movie.lineStyle(undefined);
	}

	private function drawResizeTitle(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		drawBaseTitle(movie, nW, nH, data);
		var x:Number = nW - 14 - 8;
		var y:Number = Math.round((nH - 14) / 2);
		drawDrop(movie, x, y, 14, 14, 0x8add00, data);
		if(data.mode == "press" || data.mode == "over")
		{
			var clr:Number =  data.mode == "press" ? 0xffffff : 0;
			var alpha:Number =  data.mode == "press" ? 100 : 60;
			if(data.state == "sunken") drawPlus(movie, x, y, 14, 14, clr, alpha)
			else drawMinus(movie, x, y, 14, 14, clr, alpha);
		}
	}

	private function drawSingleArrow(movie:MovieClip, nX:Number, nY:Number, nW:Number, nH:Number, dir:String, clr:Number, alpha:Number):Void
	{
		if(!alpha) alpha = 100;
		var bVert:Boolean = dir == "up" || dir == "down";
		var size:Number = bVert 
			? ((nW / 2 > nH) ? nH * 2 : nW)
			: ((nH / 2 > nW) ? nW * 2 : nH);
		size -= size % 2;
		var halfSize:Number = size / 2;
		var x:Number = nX + Math.round((nW - (bVert ? size : halfSize)) / 2);
		var y:Number = nY + Math.round((nH - (bVert ? halfSize : size)) / 2);
		switch(dir)
		{
			case "up":
				pseudo.Global.drawRect(movie, x, y + halfSize - 2, 1, 2, clr, alpha);
				pseudo.Global.drawRect(movie, x + size - 1, y + halfSize - 2, 1, 2, clr, alpha);
				for(var i:Number = 1; i < halfSize; i++)
				{
					pseudo.Global.drawRect(movie, x + i, y + halfSize - i - 2, 1, 3, clr, alpha);
					pseudo.Global.drawRect(movie, x + size - i - 1, y + halfSize - i - 2, 1, 3, clr, alpha);
				}
				break;
			case "down":
				pseudo.Global.drawRect(movie, x, y, 1, 2, clr, alpha);
				pseudo.Global.drawRect(movie, x + size - 1, y, 1, 2, clr, alpha);
				for(var i:Number = 1; i < halfSize; i++)
				{
					pseudo.Global.drawRect(movie, x + i, y + i - 1, 1, 3, clr, alpha);
					pseudo.Global.drawRect(movie, x + size - i - 1, y + i - 1, 1, 3, clr, alpha);
				}
				break;
			case "left":
				pseudo.Global.drawRect(movie, x + halfSize - 2, y, 2, 1, clr, alpha);
				pseudo.Global.drawRect(movie, x + halfSize - 2, y + size - 1, 2, 1, clr, alpha);
				for(var i:Number = 1; i < halfSize; i++)
				{
					pseudo.Global.drawRect(movie, x + halfSize - i - 2, y + i, 3, 1, clr, alpha);
					pseudo.Global.drawRect(movie, x + halfSize - i - 2, y + size - i - 1, 3, 1, clr, alpha);
				}
				break;
			case "right":
				pseudo.Global.drawRect(movie, x, y, 2, 1, clr, alpha);
				pseudo.Global.drawRect(movie, x, y + size - 1, 2, 1, clr, alpha);
				for(var i:Number = 1; i < halfSize; i++)
				{
					pseudo.Global.drawRect(movie, x + i - 1, y + i, 3, 1, clr, alpha);
					pseudo.Global.drawRect(movie, x + i - 1, y + size - i - 1, 3, 1, clr, alpha);
				}
				break;
		}
	}

	private function drawGo(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, clr:Number):Void
	{
		drawSingleArrow(movie, x - 1, y + 6, w - 2, h - 12, "right", clr);
		drawSingleArrow(movie, x + 6, y + 6, w - 9, h - 12, "right", clr);
	}

	private function drawResizeBtnLayer(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		drawRoundDrop(movie, 0, 0, nW, nH, 0xa2d37c, data);
		if(data.mode == "press" || data.mode == "over")
		{
			var bSunken:Boolean = data.state == "sunken";
			var clr:Number = data.mode == "press" ? 0xffffff : 0;
			var alpha:Number = data.mode == "press" ? 100 : 60;
			switch(data.type)
			{
				case "resizeRight":
				case "resizeLeft":
					drawSingleArrow(movie, 4, 4, nW - 8, nH - 8, (bSunken && data.type == "resizeRight" ||
						!bSunken && data.type == "resizeLeft") ? "left" : "right", clr, alpha);
					break;
				case "resizeTop":
				case "resizeBottom":
					drawSingleArrow(movie, 4, 4, nW - 8, nH - 8, (bSunken && data.type == "resizeTop" ||
						!bSunken && data.type == "resizeBottom") ? "down" : "up", clr, alpha);
					break;
			}
		}
	}

	private function drawScrollLayer(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		var colors:Array = new Array(0xffffff, 0xffffff, 0xffffff);
		var alphas:Array = new Array(50, 100, 50);
		var ratios:Array = new Array(0, 180, 255);
		var matrix:Object = null;
		var bLow:Boolean = data.type == "scrollLow";
		if(data.dir == "vert")
		{
			var w:Number = nW * 4 / 11;
			var h:Number = nH / 3;
			var off:Number = bLow ? 1 : 0;
			matrix = {matrixType:"box", x:1, y:off, w:w, h:nH - (1 - off), r:0};
			movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
			movie.moveTo(1, off);
			var obj:Object = drawArc(movie, 1, off, w, -90, 90, h);
			var curX:Number = w + 1;
			var curY:Number = nH - h - (1 - off);
			movie.lineTo(curX, curY);
			obj = drawArc(movie, curX, curY, w, -90, 0, h);
			movie.lineTo(1, off);
			movie.endGradientFill();
			movie.beginFill(0, 80);
			w = nH / 3;
			h = nH / 5;
			movie.moveTo(nW / 2, bLow ? nH / 2 - h : nH / 2 + h);
			movie.lineTo(nW / 2 - w / 2, bLow ? nH / 2 + h : nH / 2 - h);
			movie.lineTo(nW / 2 + w / 2, bLow ? nH / 2 + h : nH / 2 - h);
			movie.lineTo(nW / 2, bLow ? nH / 2 - h : nH / 2 + h);
			movie.endFill();
		}
		else
		{
			var w:Number = nW / 3;
			var h:Number = nH * 4 / 11;
			var off:Number = data.type == "scrollLow" ? 1 : 0;
			matrix = {matrixType:"box", x:off, y:1, w:w - (1 - off), h:nH, r:Math.PI / 2};
			movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
			movie.moveTo(off, 1);
			var obj:Object = drawArc(movie, off, 1, w, 90, 180, h);
			var curX:Number = nW - w - (1 - off);
			var curY:Number = h + 1;
			movie.lineTo(curX, curY);
			obj = drawArc(movie, curX, curY, w, 90, 270, h);
			movie.lineTo(off, 1);
			movie.endFill();
			movie.beginFill(0, 80);
			w = nW / 5;
			h = nW / 3;
			movie.moveTo(bLow ? nW / 2 - w : nW / 2 + w, nH / 2);
			movie.lineTo(bLow ? nW / 2 + w : nW / 2 - w, nH / 2 - h / 2);
			movie.lineTo(bLow ? nW / 2 + w : nW / 2 - w, nH / 2 + h / 2);
			movie.lineTo(bLow ? nW / 2 - w : nW / 2 + w, nH / 2);
			movie.endFill();
		}
		delete colors;
		delete alphas;
		delete ratios;
		delete matrix;
		movie.drawRect(0, 0, nW, nH, 0, 0);
	}

	//
	// different shapes drawing routine
	//
	private function drawMinus(movie:MovieClip, nX:Number, nY:Number, nW:Number, nH:Number, clr:Number, alpha:Number):Void
	{
		var w:Number = 8;
		var h:Number = 2;
		var x:Number = nX + Math.round((nW - w) / 2);
		var y:Number = nY + Math.round((nH - h) / 2);
		pseudo.Global.drawRect(movie, x, y, w, h, clr, alpha);
	}

	private function drawPlus(movie:MovieClip, nX:Number, nY:Number, nW:Number, nH:Number, clr:Number, alpha:Number):Void
	{
		var size:Number = 8;
		var thick:Number = 2;
		var x:Number = nX + Math.round((nW - size) / 2);
		var y:Number = nY + Math.round((nH - size) / 2);
		var cx:Number = nX + Math.round((nW - thick) / 2);
		var cy:Number = nY + Math.round((nH - thick) / 2);
		var dh:Number = Math.round(size - thick) / 2;
		pseudo.Global.drawRect(movie, x, cy, size, thick, clr, alpha);
		pseudo.Global.drawRect(movie, cx, y, thick, dh, clr, alpha);
		pseudo.Global.drawRect(movie, cx, cy + thick, thick, dh, clr, alpha);
	}

	private function drawCross(movie:MovieClip, nX:Number, nY:Number, nW:Number, nH:Number, clr:Number, alpha:Number):Void
	{
		var size:Number = 8;
		var size2:Number = Math.round(size / 2);
		var x:Number = nX + Math.round((nW - size) / 2);
		var y:Number = nY + Math.round((nH - size) / 2);
		drawLine(movie, x, y, x + size - 1, y + size - 1, clr, alpha);
		drawLine(movie, x + 1, y, x + size - 1, y + size - 2, clr, alpha);
		drawLine(movie, x, y + 1, x + size - 2, y + size - 1, clr, alpha);

		drawLine(movie, x, y + size - 1, x + size2 - 2, y + size2 + 1, clr, alpha);
		drawLine(movie, x + 1, y + size - 1, x + size2 - 1, y + size2 + 1, clr, alpha);
		drawLine(movie, x, y + size - 2, x + size2 - 2, y + size2, clr, alpha);

		drawLine(movie, x + size2 + 1, y + size2 - 2, x + size - 1, y, clr, alpha);
		drawLine(movie, x + size2 + 1, y + size2 - 1, x + size - 1, y + 1, clr, alpha);
		drawLine(movie, x + size2, y + size2 - 2, x + size - 2, y, clr, alpha);
	}

	private function drawFillRect(movie:MovieClip, x:Number, y:Number, w:Number, h:Number):Void
	{
		movie.moveTo(x, y);
		movie.lineTo(x + w, y);
		movie.lineTo(x + w, y + h);
		movie.lineTo(x, y + h);
		movie.lineTo(x, y);
	}

	private function drawScrollBack(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		var bVert:Boolean = data.dir == "vert";
		var colors:Array = new Array(0xcacaca, 0xffffff);
		var alphas:Array = new Array(100, 100);
		var ratios:Array = new Array(0, 188);
		var matrix:Object = {matrixType:"box", x:0, y:0, w:nW, h:nH, r:bVert ? 0 : Math.PI / 2};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		drawFillRect(movie, 0, 0, nW, nH);
		movie.endFill();
		delete colors;
		delete alphas;
		delete ratios;
		delete matrix;
		colors = new Array(0, 0xffffff);
		alphas = new Array(30, 0);
		ratios = new Array(0, 180);
		var size:Number = Math.min(nW, nH);
		var x:Number = bVert ? 0 : size;
		var y:Number = bVert ? size : 0;
		matrix = {matrixType:"box", x:x, y:y, w:size, h:size, r:bVert ? Math.PI / 2 : 0};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		drawOvalRect(movie, x, y, size, size);
		movie.endFill();
		delete matrix;
		x = bVert ? 0 : nW - size * 2;
		y = bVert ? nH - size * 2: 0;
		matrix = {matrixType:"box", x:x, y:y, w:size, h:size, r:bVert ? Math.PI * 3 / 2 : Math.PI};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		drawOvalRect(movie, x, y, size, size);
		movie.endFill();
		delete colors;
		delete alphas;
		delete ratios;
		delete matrix;
	}

	//
	// drops drawing routine
	//
	private function rgb2hsb(colRGB:Number):Object
	{
		var red:Number = (colRGB & 0xff0000) >> 16;
		var gre:Number = (colRGB & 0x00ff00) >> 8;
		var blu:Number = colRGB & 0x0000ff;
		var max:Number = Math.max(red, Math.max(gre, blu));
		var min:Number = Math.min(red, Math.min(gre, blu));
		var hsb:Object = new Object({h:0, s:0, b:Math.round(max * 100 / 255)});
		if(max != min)
		{ 
			hsb.s = Math.round(100 * (max - min) / max);
			var tmpR:Number = (max - red) / (max - min);
			var tmpG:Number = (max - gre) / (max - min);
			var tmpB:Number = (max - blu) / (max - min);
			switch(max)
			{
				case red: hsb.h = tmpB - tmpG; break;
				case gre: hsb.h = 2 + tmpR - tmpB; break;
				case blu: hsb.h = 4 + tmpG - tmpR; break;
			}
			hsb.h = (Math.round(hsb.h * 60) + 360) % 360;
		}
		return hsb;
	}

	private function hsb2rgb(hsb:Object):Number
	{
		var red:Number = hsb.b;
		var gre:Number = hsb.b;
		var blu:Number = hsb.b;
		if(hsb.s)
		{ // if not grey
			var hue:Number = (hsb.h + 360) % 360;
			var dif:Number = (hue % 60) / 60;
			var mid1:Number = hsb.b * (100 - hsb.s * dif) / 100;
			var mid2:Number = hsb.b * (100 - hsb.s * (1 - dif)) / 100;
			var min:Number = hsb.b * (100 - hsb.s) / 100;
			switch(Math.floor(hue / 60))
			{
				case 0: red = hsb.b; gre = mid2; blu = min; break;
				case 1: red = mid1; gre = hsb.b; blu = min; break;
				case 2: red = min; gre = hsb.b; blu = mid2; break;
				case 3: red = min; gre = mid1; blu = hsb.b; break;
				case 4: red = mid2; gre = min; blu = hsb.b; break;
				default: red = hsb.b; gre = min; blu = mid1; break;
			}
		}
		return Math.round(red * 2.55) * 65536 +
			Math.round(gre * 2.55) * 256 +
			Math.round(blu * 2.55);
	}

	private function drawOvalRect(movie:MovieClip, x:Number, y:Number,
		w:Number, h:Number, color:Number, nAlpha:Number, nSize:Number):Void
	{
		var rx:Number = Math.abs(w / 2);
		var ry:Number = Math.abs(h / 2);
		drawOval(movie, x + rx, y + ry, rx, ry, color, nAlpha, nSize);
	}

	private function fillOvalRect(movie:MovieClip, x:Number, y:Number, w:Number, h:Number,
		bgCol:Number, bgAlpha:Number, lineCol:Number, lineAlpha:Number):Void
	{
		if(!bgAlpha) bgAlpha = 100;
		movie.beginFill(bgCol, bgAlpha)
		drawOvalRect(movie, x, y, w, h, lineCol, lineAlpha);
		movie.endFill();
	}

	private function drawOval(movie:MovieClip, x:Number, y:Number,
		radius:Number, yRadius:Number, color:Number, nAlpha:Number, nSize:Number):Void
	{
		if (arguments.length < 3) return;
		if(nSize == undefined || nSize == null) nSize = 1;
		if(nAlpha == undefined) nAlpha = 100;
		if(color != null && color != undefined) movie.lineStyle(nSize, color, nAlpha);
		else movie.lineStyle(null, null, null);
		// init variables
		var theta, xrCtrl, yrCtrl, angle, angleMid, px, py, cx, cy:Number;
		// if only yRadius is undefined, yRadius = radius
		if (yRadius == undefined) yRadius = radius;
		// convert 45 degrees to radians for our calculations
		theta = Math.PI / 4;
		// calculate the distance for the control point
		xrCtrl = radius / Math.cos(theta / 2);
		yrCtrl = yRadius / Math.cos(theta / 2);
		// start on the right side of the circle
		angle = 0;
		movie.moveTo(x + radius, y);
		// this loop draws the circle in 8 segments
		for (var i = 0; i < 8; i++)
		{
			// increment our angles
			angle += theta;
			angleMid = angle - (theta / 2);
			// calculate our control point
			cx = x + Math.cos(angleMid) * xrCtrl;
			cy = y + Math.sin(angleMid) * yrCtrl;
			// calculate our end point
			px = x + Math.cos(angle) * radius;
			py = y + Math.sin(angle) * yRadius;
			// draw the circle segment
			movie.curveTo(cx, cy, px, py);
		}
	}
	
	function drawDrop(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, col:Number, data:Object):Void
	{
		movie.beginFill(0, 60);
		drawOvalRect(movie, x, y, w, h);
		movie.endFill();

		var hsb:Object = rgb2hsb(col);
		var colors:Array = new Array(
			hsb2rgb({h:hsb.h, s:Math.max(0, hsb.s - 60), b:Math.min(100, hsb.b + 30)}),
			hsb2rgb({h:hsb.h, s:Math.max(0, hsb.s - 55), b:Math.min(100, hsb.b + 25)}),
			hsb2rgb({h:hsb.h, s:Math.max(0, hsb.s), b:Math.min(100, hsb.b - 12)}),
			hsb2rgb({h:hsb.h, s:Math.max(0, hsb.s), b:Math.min(100, hsb.b - 65)}));//0xdffeab, 0xbfff55, 0x136806, 0);
		var alphas:Array = new Array(100, 100, 100, 100);
		var ratios:Array = new Array(0, 60, 140, 255);
		var w1:Number = w - 2;
		var h1:Number = h - 2;
		var matrix:Object = {a:w1 * 1.55, b:0, c:0, d:0, e:h1 * 1.55, f:0, g:x + 1 + w1 / 2, h:y + 1 + h1 * 0.85, i:1};
		movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
		drawOvalRect(movie, x + 1, y + 1, w1, h1);
		movie.endFill();
		colors.splice(0);
		alphas.splice(0);
		ratios.splice(0);
		colors.push(0xffffff, 0xffffff);
		alphas.push(80, 10);
		ratios.push(65, 255);
		matrix = {a:w1 * 0.9, b:0, c:0, d:0, e:h1 * 0.5, f:0, g:x + w / 2, h:y + 1 + h1 * 0.1, i:1};
		movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
		drawOvalRect(movie, x + (w - w1 * 0.7) / 2, y + 1 + h1 * 0.02, w1 * 0.7, h1 * 0.35);
		movie.endFill();
		delete colors;
		delete alphas;
		delete ratios;
		if(data.mode == "press") fillOvalRect(movie, x, y, w, h, 0, 20);
		else if(data.mode == "over") fillOvalRect(movie, x, y, w, h, 0xffffff, 20);
	}

	//
	// round green button
	//
	private function drawRoundRect(movie:MovieClip, nX1:Number, nY1:Number, nX2:Number,
		nY2:Number, cornerRadius:Number, color:Number, alpha:Number, nSize:Number):Void
	{
		if(nSize == undefined || nSize == null) nSize = 1;
		if(alpha == undefined) alpha = 100;
		if(color == null || color == undefined) movie.lineStyle(undefined);
		else movie.lineStyle(nSize, color, alpha);
		var x:Number = Math.min(nX1, nX2);
		var y:Number = Math.min(nY1, nY2);
		var w:Number = Math.abs(nX2 - nX1);
		var h:Number = Math.abs(nY2 - nY1);
		// ==============
		// mc.drawRect() - by Ric Ewing (ric@formequalsfunction.com) - version 1.1 - 4.7.2002
		// 
		// x, y = top left corner of rect
		// w = width of rect
		// h = height of rect
		// cornerRadius = [optional] radius of rounding for corners (defaults to 0)
		// ==============
		if (arguments.length < 4) return;
		// if the user has defined cornerRadius our task is a bit more complex. :)
		if (cornerRadius > 0)
		{
			// init vars
			var theta, angle, cx, cy, px, py;
			// make sure that w + h are larger than 2*cornerRadius
			var cr:Number = Math.min(w, h) / 2;
			if (cornerRadius > cr)
				cornerRadius = cr;
			// theta = 45 degrees in radians
			theta = Math.PI / 4;
			// draw top line
			movie.moveTo(x + cornerRadius, y);
			movie.lineTo(x + w - cornerRadius, y);
			//angle is currently 90 degrees
			angle = -Math.PI / 2;
			// draw tr corner in two parts
			cx = x + w - cornerRadius + (Math.cos(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			cy = y + cornerRadius + (Math.sin(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			px = x + w - cornerRadius + (Math.cos(angle + theta) * cornerRadius);
			py = y + cornerRadius + (Math.sin(angle + theta) * cornerRadius);
			movie.curveTo(cx, cy, px, py);
			angle += theta;
			cx = x + w - cornerRadius + (Math.cos(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			cy = y + cornerRadius + (Math.sin(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			px = x + w - cornerRadius + (Math.cos(angle + theta) * cornerRadius);
			py = y + cornerRadius + (Math.sin(angle + theta) * cornerRadius);
			movie.curveTo(cx, cy, px, py);
			// draw right line
			movie.lineTo(x + w, y + h - cornerRadius);
			// draw br corner
			angle += theta;
			cx = x + w - cornerRadius + (Math.cos(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			cy = y + h - cornerRadius + (Math.sin(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			px = x + w - cornerRadius + (Math.cos(angle + theta) * cornerRadius);
			py = y + h - cornerRadius + (Math.sin(angle + theta) * cornerRadius);
			movie.curveTo(cx, cy, px, py);
			angle += theta;
			cx = x + w - cornerRadius + (Math.cos(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			cy = y + h - cornerRadius + (Math.sin(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			px = x + w - cornerRadius + (Math.cos(angle + theta) * cornerRadius);
			py = y + h - cornerRadius + (Math.sin(angle + theta) * cornerRadius);
			movie.curveTo(cx, cy, px, py);
			// draw bottom line
			movie.lineTo(x+cornerRadius, y+h);
			// draw bl corner
			angle += theta;
			cx = x + cornerRadius + (Math.cos(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			cy = y + h - cornerRadius + (Math.sin(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			px = x + cornerRadius + (Math.cos(angle + theta) * cornerRadius);
			py = y + h - cornerRadius + (Math.sin(angle + theta) * cornerRadius);
			movie.curveTo(cx, cy, px, py);
			angle += theta;
			cx = x + cornerRadius + (Math.cos(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			cy = y + h - cornerRadius + (Math.sin(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			px = x + cornerRadius + (Math.cos(angle + theta) * cornerRadius);
			py = y + h - cornerRadius + (Math.sin(angle + theta) * cornerRadius);
			movie.curveTo(cx, cy, px, py);
			// draw left line
			movie.lineTo(x, y + cornerRadius);
			// draw tl corner
			angle += theta;
			cx = x + cornerRadius + (Math.cos(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			cy = y + cornerRadius + (Math.sin(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			px = x + cornerRadius + (Math.cos(angle+  theta) * cornerRadius);
			py = y + cornerRadius + (Math.sin(angle + theta) * cornerRadius);
			movie.curveTo(cx, cy, px, py);
			angle += theta;
			cx = x + cornerRadius + (Math.cos(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			cy = y + cornerRadius + (Math.sin(angle + (theta / 2)) * cornerRadius / Math.cos(theta / 2));
			px = x + cornerRadius + (Math.cos(angle + theta) * cornerRadius);
			py = y + cornerRadius + (Math.sin(angle + theta) * cornerRadius);
			movie.curveTo(cx, cy, px, py);
		}
		else
		{
			// cornerRadius was not defined or = 0. This makes it easy.
			movie.moveTo(x, y);
			movie.lineTo(x + w, y);
			movie.lineTo(x + w, y + h);
			movie.lineTo(x, y + h);
			movie.lineTo(x, y);
		}
	}
	
	private function fillRoundRect(movie:MovieClip, x1:Number, y1:Number, x2:Number, y2:Number, r:Number,
		bgCol:Number, bgAlpha:Number, lineCol:Number, lineAlpha:Number):Void
	{
		if(!bgAlpha) bgAlpha = 100;
		movie.beginFill(bgCol, bgAlpha)
		drawRoundRect(movie, x1, y1, x2, y2, r, lineCol, lineAlpha);
		movie.endFill();
	}

		/*movie.beginFill(0, 60);
		var r:Number = Math.min(w, h) / 2;
		drawRoundRect(movie, x, y, w, h, r);
		movie.endFill();
		var hsb:Object = rgb2hsb(col);
		var colors:Array = new Array(
			hsb2rgb({h:hsb.h, s:hsb.s, b:Math.max(0, hsb.b - 30)}),
			hsb2rgb({h:hsb.h, s:hsb.s, b:Math.max(0, hsb.b - 8)}),
			hsb2rgb({h:hsb.h, s:hsb.s, b:Math.min(100, hsb.b + 5)}),
			hsb2rgb({h:hsb.h, s:hsb.s, b:Math.max(0, hsb.b - 8)}),
			hsb2rgb({h:hsb.h, s:hsb.s, b:Math.max(0, hsb.b - 30)}));
		var alphas:Array = new Array(100, 100, 100, 100, 100);
		var ratios:Array = new Array(0, 50, 128, 205, 255);
		var w1:Number = w - 2;
		var h1:Number = h - 2;
		var r1:Number = Math.min(w1, h1) / 2;
		var matrix:Object = {matrixType:"box", x:x + 1, y:y + 1, w:w1, h:h1, r:w > h ? Math.PI / 2 : 0};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		drawRoundRect(movie, x + 1, y + 1, w - 1, h - 1, r);
		movie.endFill();
	
		colors.splice(0);
		alphas.splice(0);
		ratios.splice(0);
		colors.push(0xffffff, 0xffffff, 0xffffff);
		alphas.push(80, 80, 2);
		ratios.push(20, 30, 255);
		var offX:Number = w > h ? x + 1 - r1 * 0.2 : x + r;
		var offY:Number = w > h ? y + r : y + 1 - r1 * 0.2;
		matrix = {a:r1 * 2, b:0, c:0, d:0, e:r1 * 2, f:0, g:offX, h:offY, i:1};
		movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
		drawOvalRect(movie, x + 1, y + 1, r1 * 2, r1 * 2);
		movie.endFill();
	
		colors.splice(0);
		alphas.splice(0);
		ratios.splice(0);
		colors.push(0xffffff, 0xffffff, 0xffffff);
		alphas.push(80, 65, 2);
		ratios.push(65, 100, 255);
		offX = w > h ? x + w - 1 - r1 * 0.3 : x + r;
		offY = w > h ? y + r : y + h - 1 - r1 * 0.3;
		var rw:Number = r1 * (2 + (w > h ? 0 : 1));
		var rh:Number = r1 * (2 + (w > h ? 1 : 0));
		matrix = {a:rw, b:0, c:0, d:0, e:rh, f:0, g:offX, h:offY, i:1};
		movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
		offX = w > h ? x + w - 1 - r1 * 2 : x + 1;
		offY = w > h ? y + 1 : y + h - 1 - r1 * 2;
		drawOvalRect(movie, offX, offY, r1 * 2, r1 * 2);
		movie.endFill();
		if(data.mode == "press") fillRoundRect(movie, x, y, w, h, r, 0, 20);*/


/*	private function drawRoundDrop(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, col:Number, data:Object):Void
	{
		var r:Number = Math.min(w, h) / 2;
		var w1:Number = w - 2;
		var h1:Number = h - 2;
		var r1:Number = Math.min(w1, h1) / 2;
		movie.beginFill(col, 100);
		drawRoundRect(movie, x + 1, y + 1, w - 1, h - 1, r - 1);
		movie.endFill();
	
		if(w < h)
		{
			var hsb:Object = rgb2hsb(col);
			var colors:Array = new Array(
				hsb2rgb({h:hsb.h, s:hsb.s, b:Math.max(0, hsb.b - 30)}),
				col,
				col,
				hsb2rgb({h:hsb.h, s:hsb.s, b:Math.max(0, hsb.b - 30)}));
			var alphas:Array = new Array(100, 100, 100, 100);
			var ratios:Array = new Array(0, 90, 165, 255);
			var matrix:Object = {matrixType:"box", x:x + 1, y:y + 1, w:w1, h:h1, r:0};
			movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
			drawRoundRect(movie, x + 1, y + 1, w - 1, h - 1, r);
			movie.endFill();
		}
		else
		{
			var colors:Array = new Array(0, 0);
			var alphas:Array = new Array(0, 50);
			var ratios:Array = new Array(160, 255);
			var matrix:Object = new Object({a:r1 * 3, b:0, c:0, d:0, e:r1 * 3, f:0, g:x + r * 1.4, h:y + r});
			movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
			drawOvalRect(movie, x + 1, y + 1, r1 * 2, r1 * 2);
			movie.endFill();
			colors.splice(0);
			alphas.splice(0);
			ratios.splice(0);
			colors.push(0, 0);
			alphas.push(0, 50);
			ratios.push(160, 255);
			var matrix:Object = new Object({a:r1 * 3, b:0, c:0, d:0, e:r1 * 3, f:0, g:x + w - r * 1.4, h:y + r});
			movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
			drawOvalRect(movie, x + w - r1 * 2 - 1, y + 1, r1 * 2, r1 * 2);
			movie.endFill();
		}
		colors.splice(0);
		alphas.splice(0);
		ratios.splice(0);
		colors.push(0xffffff, 0xffffff, 0xffffff);
		alphas.push(100, 40, 35);
		ratios.push(0, 30, 100);
		var offX:Number = 1;
		var offY:Number = 1;
		matrix = {matrixType:"box", x:offX, y:offY, w:w1, h:r1 * 2, r:Math.PI / 2};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		drawRoundRect(movie, x + 1 + r1 / 4, y + 1, w - 1 - r1 / 4, r1 - 0.5, r);
		movie.endFill();
	
		colors.splice(0);
		alphas.splice(0);
		ratios.splice(0);
		var hsb:Object = rgb2hsb(col);
		colors.push(0xffffff,
			hsb2rgb({h:hsb.h, s:Math.max(0, hsb.s - 60), b:Math.min(100, hsb.b + 27)}),
			hsb2rgb({h:hsb.h, s:Math.max(0, hsb.s - 55), b:Math.min(100, hsb.b + 25)}));
		//colors.push(0xffffff, 0xffffff);
		alphas.push(0, 100, 100);
		ratios.push(90, 140, 235);
		var offX:Number = 1;
		var offY:Number = y + h - r1 * 2 - 1;
		matrix = {matrixType:"box", x:offX, y:offY, w:w1, h:r1 * 2, r:Math.PI / 2};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		drawRoundRect(movie, x + 1, y + h - r1 * 2 - 1, w - 1, y + h - 1, r);
		movie.endFill();
	
		drawRoundRect(movie, x + 0.5, y + 0.5, w - 0.5, h - 0.5, r - 0.5, 0x444444, 100, 1);
		movie.lineStyle(undefined);
		if(data.mode == "press") fillRoundRect(movie, x, y, w, h, r, 0, 20);
	}
*/
	private function drawRoundDrop(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, col:Number, data:Object):Void
	{
		var r:Number = Math.min(w, h) / 2;
		var w1:Number = w - 2;
		var h1:Number = h - 2;
		var r1:Number = Math.min(w1, h1) / 2;
		movie.beginFill(col, 100);
		drawRoundRect(movie, x + 1, y + 1, x + w - 1, y + h - 1, r - 1);
		movie.endFill();

		if(w < h)
		{
			var colors:Array = new Array(0, 0);
			var alphas:Array = new Array(0, 50);
			var ratios:Array = new Array(160, 255);
			var matrix:Object = new Object({a:r1 * 3, b:0, c:0, d:0, e:r1 * 3, f:0, g:x + r, h:y + r * 1.4});
			movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
			drawOvalRect(movie, x + 1, y + 1, r1 * 2, r1 * 2);
			movie.endFill();
			colors.splice(0);
			alphas.splice(0);
			ratios.splice(0);
			colors.push(0, 0);
			alphas.push(0, 50);
			ratios.push(160, 255);
			matrix = new Object({a:r1 * 3, b:0, c:0, d:0, e:r1 * 3, f:0, g:x + r, h:y + h - r * 1.4});
			movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
			drawOvalRect(movie, x + 1, y + h - r1 * 2 - 1, r1 * 2, r1 * 2);
			movie.endFill();
	
			colors.splice(0);
			alphas.splice(0);
			ratios.splice(0);
			colors.push(0xffffff, 0xffffff, 0xffffff);
			alphas.push(65, 40, 35);
			ratios.push(10, 50, 100);
			var offX:Number = 1;
			var offY:Number = 1;
			matrix = {matrixType:"box", x:offX, y:offY, w:r1 * 2, h:h1, r:0};
			movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
			drawRoundRect(movie, x + 1, y + 1 + r1 / 4, r1 - 0.5, h - 1 - r1 / 4, r);
			movie.endFill();
		
			colors.splice(0);
			alphas.splice(0);
			ratios.splice(0);
			colors.push(0xffffff, 0xffffff);
			alphas.push(0, 85);
			ratios.push(90, 235);
			offX = x + w - r1 * 2 - 1;
			offY = 1;
			matrix = {matrixType:"box", x:offX, y:offY, w:r1 * 2, h:h1, r:0};
			movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
			drawRoundRect(movie, x + w - r1 * 2 - 1, y + 1, x + w - 1, h - 1, r);
			movie.endFill();
		}
		else
		{
			var colors:Array = new Array(0, 0);
			var alphas:Array = new Array(0, 50);
			var ratios:Array = new Array(160, 255);
			var matrix:Object = new Object({a:r1 * 3, b:0, c:0, d:0, e:r1 * 3, f:0, g:x + r * 1.4, h:y + r});
			movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
			drawOvalRect(movie, x + 1, y + 1, r1 * 2, r1 * 2);
			movie.endFill();
			colors.splice(0);
			alphas.splice(0);
			ratios.splice(0);
			colors.push(0, 0);
			alphas.push(0, 50);
			ratios.push(160, 255);
			matrix = new Object({a:r1 * 3, b:0, c:0, d:0, e:r1 * 3, f:0, g:x + w - r * 1.4, h:y + r});
			movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
			drawOvalRect(movie, x + w - r1 * 2 - 1, y + 1, r1 * 2, r1 * 2);
			movie.endFill();
	
			colors.splice(0);
			alphas.splice(0);
			ratios.splice(0);
			colors.push(0xffffff, 0xffffff, 0xffffff);
			alphas.push(65, 40, 35);
			ratios.push(10, 50, 100);
			var offX:Number = 1;
			var offY:Number = 1;
			matrix = {matrixType:"box", x:offX, y:offY, w:w1, h:r1 * 2, r:Math.PI / 2};
			movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
			drawRoundRect(movie, x + 1 + r1 / 4, y + 1, x + w - 1 - r1 / 4, y + r1 - 0.5, r);
			movie.endFill();
		
			colors.splice(0);
			alphas.splice(0);
			ratios.splice(0);
			colors.push(0xffffff, 0xffffff);
			alphas.push(0, 85);
			ratios.push(90, 235);
			offX = 1;
			offY = y + h - r1 * 2 - 1;
			matrix = {matrixType:"box", x:offX, y:offY, w:w1, h:r1 * 2, r:Math.PI / 2};
			movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
			drawRoundRect(movie, x + 1, y + h - r1 * 2 - 1, x + w - 1, y + h - 1, r);
			movie.endFill();
		}
	
		drawRoundRect(movie, x + 0.5, y + 0.5, x + w - 0.5, y + h - 0.5, r - 0.5, 0x444444, 100, 1);
		movie.lineStyle(undefined);
		if(data.mode == "press") fillRoundRect(movie, x, y, x + w, y + h, r, 0, 20);
	}

	function drawArc(movie:MovieClip, x:Number, y:Number, radius:Number,
		arc:Number, startAngle:Number, yRadius:Number, color:Number):Object
	{
		if(color != null && color != undefined) movie.lineStyle(1, color, 100);
		// if yRadius is undefined, yRadius = radius
		if (yRadius == undefined) yRadius = radius;
		// Init vars
		var segAngle, theta, angle, angleMid, segs, ax, ay, bx, by, cx, cy:Number;
		// no sense in drawing more than is needed :)
		if (Math.abs(arc) > 360) arc = 360;
		segs = Math.ceil(Math.abs(arc) / 45);
		// Now calculate the sweep of each segment
		segAngle = arc / segs;
		// The math requires radians rather than degrees. To convert from degrees
		// use the formula (degrees/180)*Math.PI to get radians. 
		theta = -(segAngle / 180) * Math.PI;
		// convert angle startAngle to radians
		angle = -(startAngle / 180) * Math.PI;
		// find our starting points (ax,ay) relative to the specified x,y
		ax = x - Math.cos(angle) * radius;
		ay = y - Math.sin(angle) * yRadius;
		// if our arc is larger than 45 degrees, draw as 45 degree segments
		// so that we match Flash's native circle routines.
		if (segs > 0)
		{
			// Loop for drawing arc segments
			for (var i = 0; i < segs; i++)
			{
				// increment our angle
				angle += theta;
				// find the angle halfway between the last angle and the new
				angleMid = angle-(theta / 2);
				// calculate our end point
				bx = ax + Math.cos(angle) * radius;
				by = ay + Math.sin(angle) * yRadius;
				// calculate our control point
				cx = ax + Math.cos(angleMid) * (radius / Math.cos(theta / 2));
				cy = ay + Math.sin(angleMid) * (yRadius / Math.cos(theta / 2));
				// draw the arc segment
				movie.curveTo(cx, cy, bx, by);
			}
		}
		return {x:bx, y:by};
	};

	private function getWndTitleParams():Object
	{
		// off1 - offset between hide and maximize buttons
		// off2 - offset between maximize and close buttons
		return new Object({off1:7, off2:7, h:22, btnW:14, btnH:14});
	}

	private function getResizeBtnParams():Object
	{
		return new Object({w:15, h:15, offX:18, offY:5});
	}

	private function getResizeLineParams(strAlign:String, data:Object):Object
	{
		var obj:Object = new Object();
		switch(strAlign)
		{
			case "top":
			case "bottom":
				obj.btnW = 34;
				obj.btnH = 12;
				break;
			default: // left or right
				obj.btnW = 12;
				obj.btnH = 34;
				break;
		}
		return obj;
	}

	private function getTreeParams():Object
	{
		return {offStart:8, off:8, iconW:9, iconH:12};
	}
}