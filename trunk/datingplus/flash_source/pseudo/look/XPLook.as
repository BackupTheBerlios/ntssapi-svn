class pseudo.look.XPLook implements pseudo.look.ILabelLook,
	pseudo.look.IEditLook, pseudo.look.IWindowManagerLook
{
	private var m_clrHighlight:Number;
	private var m_clrBtnText:Number;
	private var m_clrEditText:Number;
	private var m_clrBtnHover:Number;
	private var m_clrBtnPressed:Number;
	private var m_clrCellOver:Number;
	private var m_clrCellOut1:Number;
	private var m_clrCellOut2:Number;
	private var m_clrCellPress:Number;
	private var m_data:Object;
	private var m_strThemeId:String;

	static private var m_instance:pseudo.look.XPLook = null;

	//
	// PUBLIC METHODS
	//
	static public function getInstance():pseudo.look.XPLook
	{
		if(!m_instance) m_instance = new pseudo.look.XPLook();
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
		trace( data );
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
			arrListData.push({data:arrXMLThemes[i], text:arrXMLThemes[i].getAttr("name")});
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
			case "iconButton":
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
					case "left":
					case "right": nMargin = 4 + getBorder(strMargin, data); break;
					case "top":
					case "bottom": nMargin = 1 + getBorder(strMargin, data); break;
				}
				break;
			case "resizeTitle":
				switch(strMargin)
				{
					case "left": nMargin = 15 + getBorder(strMargin, data); break;
					case "right": nMargin = 17 + getBorder(strMargin, data); break;
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
			case "url":
			case "titledIconButton":
			case "iconButton":
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
			case "CellIconText":
			case "CellText":
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
				tf.color = m_clrEditText;
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
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrEditText) + "' face='Tahoma' size='12'>" +
							(data.mode == "name" ? "<b>" : "");
						break;
					case "info":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(0x016be3) + "' face='Tahoma' size='12'>";
						break;
					case "label":
					case "edit":
					case "textArea":
					case "comboBoxTitle":
					case "checkbox":
					case "cellIconText":
					case "cellText":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrEditText) + "' face='Tahoma' size='12'>";
						break;
					case "cellTree":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrEditText) + "' face='Tahoma' size='"
							+ (data.cellType == 1 ? "12" : "11") + "'>";
						break;
					case "topTime":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrEditText) + "' face='Tahoma' size='14'><b>";
						break;
					case "topUser":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'><b>";
						break;
					case "titledIconButton":
						switch(data.mode)
						{
							case "out":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrEditText) + "' face='Tahoma' size='12'>";
								break;
							case "over":
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>";
								break;
						}
					break;
					case "url":
						switch(data.mode)
						{
							case "out":
								strRes = "<font color='#016be3' face='Tahoma' size='12'>";
								break;
							case "over":
							case "press":
								strRes = "<u><font color='#016be3' face='Tahoma' size='12'>";
								break;
						}
						break;
					case "comboBoxCell":
						switch(data.mode)
						{
							case "over":
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>";
								break;
							//case "out":
							default:
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrEditText) + "' face='Tahoma' size='12'>";
								break;
						}
						break;
					case "titleBtnBack":
						switch(data.mode)
						{
							case "out":
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
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrEditText) + "' face='Tahoma' size='12'><b>";
								break;
							case "over":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'><b>";
								break;
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'><b>";
								break;
							case "disabled":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(0x303030) + "' face='Tahoma' size='12'><b>";
								break;
						}
					break;
					default:
						switch(data.mode)
						{
							case "out":
							case "over":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'><b>";
								break;
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'><b>";
								break;
							case "disabled":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(0xcccccc) + "' face='Tahoma' size='12'><b>";
								break;
						}
					break;
				}
				break;
			case "close":
				switch(data.type)
				{
					case "label":
					case "edit":
					case "info":
					case "cellText":
					case "cellTree":
					case "comboBoxCell":
					case "titledIconButton":
						strRes = "</font>";
						break;
					case "url":
						strRes = (data.mode != "out" ? "<u>" : "") + "</font>";
						break;
					case "cellThread":
						strRes = (data.mode == "name" ? "</b>" : "") + "</font>";
						break;
					case "cellText":
						switch(data.cellType)
						{
							case 1:
								strRes = "</b></font>";
								break;
							default:
								strRes = "</font>";
								break;
						}
						break;
					//case "edit":
					default:
						strRes = "</b></font>";
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

	private function XPLook()
	{
		m_strThemeId = "";
		m_clrHighlight = 0x0a246a;
		m_clrEditText = 0;
		m_clrBtnText = 0xffffff;
		m_clrBtnHover = 0x979cac;
		m_clrBtnPressed = 0x6f7a99;
		m_clrCellOver = 0xfafafa;
		m_clrCellOut1 = 0xe6e6e6;
		m_clrCellOut2 = 0xeeeeee;
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
//					case "over": clr = 0x016be3; break;
//					case "press": clr = 0x016be3; break;
					// change dorpdown pane
					case "over": clr = 0x6180AA; break;
					case "press": clr = 0x6180AA; break;
					default: clr = 0xFFFFFF; break;
				}
				break;
			default:
				switch(data.mode)
				{
					case "over": clr = m_clrCellOver; break;
					case "press": clr = m_clrCellPress; break;
					default: clr = data.ind % 2 ? m_clrCellOut2 : m_clrCellOut1; break;
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
		var alpha:Number = 30;
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
			drawPureBtn(movie, x, y, size, size, data);
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
		drawScrollLayer(movie, nW, nH, {mode:data.mode, dir:"vert", type:"scrollHi"});
	}

	private function drawComboBox(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		switch(data.mode)
		{
			default:
				// Change Line Color
//				movie.lineStyle(1, 0x015796, 100);
				movie.lineStyle(1, 0x000000, 100);
				movie.beginFill(0xffffff, 100);
				drawFillRect(movie, 0.5, 0.5, nW - 1, nH - 1);
				movie.endFill();
				movie.lineStyle(undefined);
				break;
		}
	}

	private function drawButton(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.mode)
		{
			//case "disabled":
			//	drawBtnDisabled(movie, nW, nH, data);
			//	break;
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
				drawLayer(movie, nW, nH, 0xffffff, 0xc7c7c7, data.border);
				break;
			case "scroll":
				drawScroll(movie, nW, nH, 0x028af1, 0x015796, data);
				break;
			case "scrollBack":
				drawScrollBack(movie, nW, nH, data);
				break;
			case "comboBoxBtn":
				drawComboBoxBtn(movie, nW, nH, data);
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
				drawResizeHandleBtn(movie, nW, nH, 0x727272);
				break;
			case "comboBox":
				drawLayer(movie, nW, nH, 0xffffff, 0x303030, data.border);
				break;
			case "btnClose":
				drawRoundBtn(movie, 0, 0, nW, nH, 0xf3620c, 0xa01c1d, data);
				break;
			case "btnSubmit":
				drawRoundBtn(movie, 0, 0, nW, nH, 0x5cbc2e, 0x006600, data);
				break;
			case "btnGo":
				drawRoundBtn(movie, 0, 0, nW, nH, 0x5cbc2e, 0x006600, data);
				drawGo(movie, 0, 0, nW, nH, 0xffffff);
				break;
			case "checkbox":
				drawBtnCheckBox(movie, nW, nH, data);
				break;
			default:
				movie.clear();
				if(data.state)
					drawRoundBtn(movie, 0, 0, nW, nH, data.state == "sunken" ? 0x489524 : 0x5cbc2e, 0x006600, data);
				else
					drawRoundBtn(movie, 0, 0, nW, nH, 0x028af1, 0x015796, data);
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
				drawLayer(movie, nW, nH, 0xffffff, 0xe7e7e7, data.border);
				break;
			case "scroll":
				drawScroll(movie, nW, nH, 0x028af1, 0x015796, data);
				break;
			case "scrollBack":
				break;
			case "comboBoxBtn":
				drawComboBoxBtn(movie, nW, nH, data);
				break;
			case "scrollLow":
			case "scrollHi":
				drawScrollLayer(movie, nW, nH, data);
				break;
			case "titledIconButton":
			case "iconButton":
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
				drawResizeHandleBtn(movie, nW, nH, 0x727272);
				break;
			case "comboBox":
				drawLayer(movie, nW, nH, 0xffffff, m_clrHighlight, data.border);
				break;
			case "btnClose":
				drawRoundBtn(movie, 0, 0, nW, nH, 0xf3620c, 0xa01c1d, data);
				break;
			case "btnSubmit":
				drawRoundBtn(movie, 0, 0, nW, nH, 0x5cbc2e, 0x006600, data);
				break;
			case "btnGo":
				drawRoundBtn(movie, 0, 0, nW, nH, 0x5cbc2e, 0x006600, data);
				drawGo(movie, 0, 0, nW, nH, 0xffffff);
				break;
			case "checkbox":
				drawBtnCheckBox(movie, nW, nH, data);
				break;
			default:
				movie.clear();
				if(data.state)
					drawRoundBtn(movie, 0, 0, nW, nH, data.state == "sunken" ? 0x489524 : 0x5cbc2e, 0x006600, data);
				else
					drawRoundBtn(movie, 0, 0, nW, nH, 0x028af1, 0x015796, data);
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
				drawResizeBtnLayer(movie, nW, nH, data, m_clrBtnPressed, m_clrHighlight, m_clrBtnText);
				break;
			case "resizeTitle":
				drawResizeTitle(movie, nW, nH, data);
				break;
			case "edit":
				drawLayer(movie, nW, nH, 0xffffff, 0x9bff66, data.border);
				break;
			case "scroll":
				drawScroll(movie, nW, nH, 0x028af1, 0x015796, data);
				break;
			case "scrollBack":
				break;
			case "comboBoxBtn":
				drawComboBoxBtn(movie, nW, nH, data);
				break;
			case "scrollLow":
			case "scrollHi":
				drawScrollLayer(movie, nW, nH, data);
				break;
			case "titledIconButton":
			case "iconButton":
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
				drawResizeHandleBtn(movie, nW, nH, 0x727272);
				break;
			case "comboBox":
				drawLayer(movie, nW, nH, 0xffffff, m_clrHighlight, data.border);
				break;
			case "btnClose":
				drawRoundBtn(movie, 0, 0, nW, nH, 0xf3620c, 0xa01c1d, data);
				break;
			case "btnSubmit":
				drawRoundBtn(movie, 0, 0, nW, nH, 0x5cbc2e, 0x006600, data);
				break;
			case "btnGo":
				drawRoundBtn(movie, 0, 0, nW, nH, 0x5cbc2e, 0x006600, data);
				drawGo(movie, 0, 0, nW, nH, 0xffffff);
				break;
			case "checkbox":
				drawBtnCheckBox(movie, nW, nH, data);
				break;
			default:
				movie.clear();
				if(data.state)
					drawRoundBtn(movie, 0, 0, nW, nH, data.state == "sunken" ? 0x489524 : 0x5cbc2e, 0x006600, data);
				else
					drawRoundBtn(movie, 0, 0, nW, nH, 0x028af1, 0x015796, data);
				break;
		}
	}

	private function drawTitleBack(movie:MovieClip, w:Number, h:Number, data:Object):Void
	{
		movie.clear();
		// border rect coords
		var left:Number = getBorder("left", data);
		var right:Number = getBorder("right", data);
		var top:Number = getBorder("top", data);
		var bottom:Number = getBorder("bottom", data);
		if(isNaN(data.border) || data.border)
			pseudo.Global.drawRect(movie, 0, 0, w, h, 0x8f8f8f);
		var colors:Array = [0x1e72ea, 0x28a3ec, 0x1c68ea, 0x2597eb, 0x1a5eea];
		var alphas:Array = [100, 100, 100, 100, 100];
		var ratios:Array = [0, 18, 40, 203, 255];
		var matrix = {matrixType:"box", x:left, y:top, w:w - left - right, h:h - top - bottom, r:Math.PI / 2};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
//		movie.beginGradientFill("linear", 0xFF0000, alphas, ratios, matrix);
		drawFillRect(movie, left, top, w - left - right, h - top - bottom);
		movie.endFill();
		if(data.mode == "out")
		{
			movie.beginFill(0xffffff, 40);
			drawFillRect(movie, left, top, w - left - right, h - top - bottom);
			movie.endFill();
		}
	}

	private function drawResizeDots(movie:MovieClip, nW:Number, nH:Number, nOffX:Number, nOffY:Number, clrFill:Number):Void
	{
		pseudo.Global.drawRect(movie, nW - 5 + nOffX, nH - 13 + nOffY, 2, 2, clrFill);
		pseudo.Global.drawRect(movie, nW - 5 + nOffX, nH - 9 + nOffY, 2, 2, clrFill);
		pseudo.Global.drawRect(movie, nW - 5 + nOffX, nH - 5 + nOffY, 2, 2, clrFill);
		pseudo.Global.drawRect(movie, nW - 9 + nOffX, nH - 9 + nOffY, 2, 2, clrFill);
		pseudo.Global.drawRect(movie, nW - 9 + nOffX, nH - 5 + nOffY, 2, 2, clrFill);
		pseudo.Global.drawRect(movie, nW - 13 + nOffX, nH - 5 + nOffY, 2, 2, clrFill);
	}

	private function drawResizeHandleBtn(movie:MovieClip, nW:Number, nH:Number, clrFill:Number):Void
	{
		movie.clear();
		movie.beginFill(0, 0);
		drawFillRect(movie, 0, 0, nW, nH);
		movie.endFill();
		drawResizeDots(movie, nW, nH, 1, 1, 0xffffff);
		drawResizeDots(movie, nW, nH, 0, 0, clrFill);
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
		var bFaded:Boolean = data.faded && data.mode == "out";

		switch(data.type)
		{
			case "titleBtnHide":
				drawSquareBtn(movie, 0, 0, nW, nH, bFaded ? 0x78c5fe : 0x028af1, 0xffffff, data);
				var nOffX:Number = Math.round((nW - 6) / 2);
				var nOffY:Number = Math.round((nH - 8) / 2);
				pseudo.Global.drawRect(movie, nOffX - 1, nOffY + 6, 6, 3, 0xffffff);
				break;
			case "titleBtnMinimize":
				drawSquareBtn(movie, 0, 0, nW, nH, bFaded ? 0x78c5fe : 0x028af1, 0xffffff, data);
				var nOffX:Number = Math.round((nW - 9) / 2);
				var nOffY:Number = Math.round((nH - 9) / 2);
				if(data.state == "sunken")
				{
					pseudo.Global.drawRect(movie, nOffX + 2, nOffY, 7, 2, 0xffffff);
					pseudo.Global.drawRect(movie, nOffX + 8, nOffY + 2, 1, 4, 0xffffff);
					pseudo.Global.drawRect(movie, nOffX, nOffY + 3, 7, 2, 0xffffff);
					pseudo.Global.drawRect(movie, nOffX, nOffY + 5, 1, 4, 0xffffff);
					pseudo.Global.drawRect(movie, nOffX + 1, nOffY + 8, 6, 1, 0xffffff);
					pseudo.Global.drawRect(movie, nOffX + 6, nOffY + 5, 1, 4, 0xffffff);
				}
				else
				{
					pseudo.Global.drawRect(movie, nOffX, nOffY, 9, 2, 0xffffff);
					pseudo.Global.drawRect(movie, nOffX, nOffY + 2, 1, 7, 0xffffff);
					pseudo.Global.drawRect(movie, nOffX + 1, nOffY + 8, 8, 1, 0xffffff);
					pseudo.Global.drawRect(movie, nOffX + 8, nOffY + 2, 1, 7, 0xffffff);
				}
				break;
			case "titleBtnClose":
				drawSquareBtn(movie, 0, 0, nW, nH, bFaded ? 0xf9aa7b : 0xf3620c, 0xffffff, data);
				drawCross(movie, 0, 0, nW, nH, 0xffffff);
				break;
		}
	}

	private function drawPane(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "utilitiesPane":
			case "infoPane":
			case "comboBoxPane":
				drawLayer(movie, nW, nH, 0xffffff, 0x727272, data.border);
				break;
			case "topPane":
				drawTopPane(movie, nW, nH, data);
				break;
			default:
				drawLayer(movie, nW, nH, 0xf2f2f2, 0x727272, data.border);
				break;
		}
	}

	private function drawTopPane(movie:MovieClip, w:Number, h:Number, data:Object):Void
	{
		movie.clear();
		var colors:Array = [0x0066ca, 0x99cdff];
		var alphas:Array = [100, 100];
		var ratios:Array = [0, 255];
		var matrix = {matrixType:"box", x:0, y:0, w:w, h:h, r:0};
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
//		movie.beginGradientFill("linear", 0xFF0000, alphas, ratios, matrix);
		drawFillRect(movie, 0, 0, w, h);
		movie.endFill();
	}

	private function drawResizeLine(movie:MovieClip, nX:Number, nY:Number, nW:Number, nH:Number):Void
	{
		movie.clear();
		pseudo.Global.drawRect(movie, nX, nY, nW, nH, 0xa0a0a0);
	}

	private function drawSign(movie:MovieClip, w:Number, h:Number, data:Object):Void
	{
		var strPath:String = getIconPath(data.icon);
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
				/*movie.lineStyle(1, 0xa0a0a0);
				movie.beginFill(0xffffff, 100);
				drawFillRect(movie, 0.5, 0.5, nW - 1, nH - 1);
				movie.endFill();
				movie.lineStyle(undefined);*/
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
				matrix = {ra:'80', rb:'0', ga:'90', gb:'0', ba:'100', bb:'0'};
				movie.beginFill(0x016be3, 100);
				drawRoundRect(movie, x, y, x + w, y + h, 3);
				movie.endFill();
				break;
			case "press":
				matrix = {ra:'70', rb:'0', ga:'80', gb:'0', ba:'90', bb:'0'};
				movie.beginFill(0x015ec5, 100);
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

	private function drawPureBtn(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, data:Object):Void
	{
		switch(data.mode)
		{
			case "out":
			case "press":
				var colors:Array = new Array(
					data.mode == "out" ? 0xdcdcd7 : 0xb0b0a7, data.mode == "out" ? 0xffffff : 0xf1efdf);
				var alphas:Array = new Array(100, 100);
				var ratios:Array = new Array(0, 255);
				var matrix:Object = {matrixType:"box", x:x + 1, y:y + 1, w:w - 2, h:h - 2, r:Math.PI / 4};
				movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
//				movie.beginGradientFill("linear", 0xFF0000, alphas, ratios, matrix);
				drawFillRect(movie, x + 1, y + 1, w - 2, h - 2);
				movie.endFill();
				break;
			case "over":
				var colors:Array = new Array(0xfff0cf, 0xf8b330);
				var alphas:Array = new Array(100, 100);
				var ratios:Array = new Array(0, 255);
				var matrix:Object = {matrixType:"box", x:x + 1, y:y + 1, w:w - 2, h:h - 2, r:Math.PI / 4};
				movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
//				movie.beginGradientFill("linear", 0xFF0000, alphas, ratios, matrix);
				drawFillRect(movie, x + 1, y + 1, w - 2, h - 2);
				movie.endFill();
				pseudo.Global.drawRect(movie, x + 3, y + 3, w - 6, h - 6, 0xe7e7e3);
				break;
		}
		pseudo.Global.drawFrame(movie, x, y, w, h, 0x1c5180);
	}

	private function drawCheckBox(movie:MovieClip, x:Number, y:Number, data:Object):Void
	{
		drawPureBtn(movie, x, y, 13, 13, data);
		if(data.state == "sunken")
		{
			for(var i = 0; i < 3; i++)
				pseudo.Global.drawRect(movie, x + i + 3, y + i + 5, 1, 3, 0x21a121);
			for(var i = 0; i < 4; i++)
				pseudo.Global.drawRect(movie, x - i + 9, y + i + 3, 1, 3, 0x21a121);
		}
	}

	private function drawBtnCheckBox(movie:MovieClip, w:Number, h:Number, data:Object):Void
	{
		movie.clear();
		pseudo.Global.drawRect(movie, 0, 0, w, h, 0, 0);
		drawCheckBox(movie, 0, Math.round((h - 13) / 2 - 1), data);
	}

	private function drawResizeTitle(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		var r:Number = nH - 1;
		movie.lineStyle(1, 0x727272);
		var colBg:Number = 0xdcdcdc;
		switch(data.mode)
		{
			case "over": colBg = 0x016be3; break;
			case "press": colBg = 0x015ec5; break;
		}
		movie.beginFill(colBg, 100);
		// theta = 45 degrees in radians
		movie.moveTo(r + 0.5, 0.5);
		movie.lineTo(nW - 0.5, 0.5);
		var bottom:Boolean = !data.border || data.border & 4;
		movie.lineTo(nW - 0.5, nH - (bottom ? 0.5 : 0));
		if(!bottom) movie.lineStyle(undefined);
		movie.lineTo(0.5, nH - (bottom ? 0.5 : 0));
		movie.lineStyle(1, 0x727272);
		movie.lineTo(0.5, r + 0.5);

		var theta, angle, cx, cy, px, py;
		theta = Math.PI / 4;
		// draw tl corner
		angle = Math.PI;
		cx = r + 0.5 + (Math.cos(angle + (theta / 2)) * r / Math.cos(theta / 2));
		cy = r + 0.5 + (Math.sin(angle + (theta / 2)) * r / Math.cos(theta / 2));
		px = r + 0.5 + (Math.cos(angle + theta) * r);
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
		var x:Number = nW - 15;
		var y:Number = Math.round((nH - 9) / 2);
		drawDoubleArrow(movie, x, y, 9, 9, data.state == "sunken" ? "down" : "up",
			data.mode == "out" ? 0 : 0xffffff);
	}

	private function drawDoubleArrow(movie:MovieClip, nX:Number, nY:Number, nW:Number, nH:Number, strDir:String, clrImage:Number):Void
	{
		drawSingleArrow(movie, nX, nY, nW, nH - 5, strDir, clrImage);
		drawSingleArrow(movie, nX, nY + 5, nW, nH - 5, strDir, clrImage);
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

	private function drawResizeBtnLayer(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		drawRoundBtn(movie, 0, 0, nW, nH, 0x028af1, 0x015796, data);
		var bSunken:Boolean = data.state == "sunken";
		switch(data.type)
		{
			case "resizeRight":
			case "resizeLeft":
				drawSingleArrow(movie, 4, 4, nW - 8, nH - 8, (bSunken && data.type == "resizeRight" ||
					!bSunken && data.type == "resizeLeft") ? "left" : "right", 0xffffff, 100);
				break;
			case "resizeTop":
			case "resizeBottom":
				drawSingleArrow(movie, 4, 4, nW - 8, nH - 8, (bSunken && data.type == "resizeTop" ||
					!bSunken && data.type == "resizeBottom") ? "down" : "up", 0xffffff, 100);
				break;
		}
	}

	private function drawScroll(movie:MovieClip, nW:Number, nH:Number, col:Number, colBg:Number, data:Object):Void
	{
		drawRoundBtn(movie, 0, 0, nW, nH, col, colBg, data);
		if(data.dir == "vert")
		{
			if(nH > 15)
			{
				var x:Number = 3;
				var y:Number = Math.round((nH - 8) / 2);
				var w:Number = nW - 6;
				for(var i:Number = 0; i < 8; i++)
					pseudo.Global.drawRect(movie, x + (i % 2 ? 1 : 0), y + i, w, 1, i % 2 ? 0x006ab8 : 0xc9e7ec);
			}
		}
		else
		{
			if(nW > 15)
			{
				var x:Number = Math.round((nW - 8) / 2);
				var y:Number = 3;
				var h:Number = nH - 6;
				for(var i:Number = 0; i < 8; i++)
					pseudo.Global.drawRect(movie, x + i, y + (i % 2 ? 1 : 0), h, i % 2 ? 0x006ab8 : 0xc9e7ec, 1);
			}
		}
	}

	private function drawScrollLayer(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		//change arrow box
//		drawSquareBtn(movie, 0, 0, nW, nH, 0x028af1, 0x015796, data);
		drawSquareBtn(movie, 0, 0, nW, nH, 0x6180AA, 0x6180AA, data);
		var dir:String = "";
		switch(data.dir)
		{
			case "vert":
				switch(data.type)
				{
					case "scrollLow": dir="up"; break;
					case "scrollHi": dir="down"; break;
				}
				break;
			case "horz":
				switch(data.type)
				{
					case "scrollLow": dir="left"; break;
					case "scrollHi": dir="right"; break;
				}
				break;
		}
		if(dir) drawSingleArrow(movie, 3, 3, nW - 6, nH - 6, dir, 0xffffff);
	}

	//
	// different shapes drawing routine
	//
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
		var colors:Array = new Array(0xe6e8ee, 0xfcfcfe);
		var alphas:Array = new Array(100, 100);
		var ratios:Array = new Array(0, 188);
		var matrix:Object = {matrixType:"box", x:0, y:0, w:nW, h:nH, r:bVert ? 0 : Math.PI / 2};
		movie.lineStyle(1, 0xe6e7ee);
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		drawFillRect(movie, 0.5, 0.5, nW - 1, nH - 1);
		movie.endFill();
		movie.lineStyle(undefined);
		delete colors;
		delete alphas;
		delete ratios;
		delete matrix;
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
	
	function drawSquareBtn(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, col:Number, colBorder:Number, data:Object):Void
	{
		movie.clear();
		var r:Number = Math.min(data.type == "scrollLow" || data.type == "scrollHi" ? 1 : 3, Math.min(w, h) / 2);
		fillRoundRect(movie, x + 0.5, y + 0.5, w - 0.5, h - 0.5, r, col, 100, colBorder, 100);
		var colors:Array = new Array(0xffffff, 0xffffff);
		var alphas:Array = new Array(60, 0);
		var ratios:Array = new Array(40, 255);
		var flareH:Number = h * 2 / 3;
		var matrix:Object = {a:w - 2, b:0, c:0, d:0, e:flareH, f:0, g:w / 4, h:h / 4, i:1};
		movie.beginGradientFill("radial", colors, alphas, ratios, matrix);
//		movie.beginGradientFill("radial", 0xFF0000, alphas, ratios, matrix);
		drawRoundRect(movie, 1, 1, w - 1, flareH + 1, Math.max(0, r - 0.5));
		movie.endFill();
		switch(data.mode)
		{
			case "press": fillRoundRect(movie, x, y, w, h, r, 0, 10); break;
			case "over": fillRoundRect(movie, x, y, w, h, r, 0xffffff, 20); break;
		}
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
	
	private function fillRoundRect(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, r:Number,
		bgCol:Number, bgAlpha:Number, lineCol:Number, lineAlpha:Number):Void
	{
		if(!bgAlpha) bgAlpha = 100;
		movie.beginFill(bgCol, bgAlpha)
		//Change Round Fill Color
		//movie.beginFill(0xFF0000, bgAlpha)		
		drawRoundRect(movie, x, y, w, h, r, lineCol, lineAlpha);
		movie.endFill();
	}

	private function drawGo(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, clr:Number):Void
	{
		drawSingleArrow(movie, x - 1, y + 6, w - 2, h - 12, "right", clr);
		drawSingleArrow(movie, x + 6, y + 6, w - 9, h - 12, "right", clr);
	}

	private function drawRoundBtn(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, col:Number, colBorder:Number, data:Object):Void
	{
		movie.clear();
		if(w == h) drawSquareBtn(movie, x, y, w, h, col, colBorder, data);
		else
		{
			var r:Number = Math.min(data.type == "scroll" ? 2 : 4, Math.min(w, h) / 2);
			var bVert:Boolean = w < h;
//			fillRoundRect(movie, x + 0.5, y + 0.5, w - 0.5, h - 0.5, r, col, 100, colBorder, 100);
			fillRoundRect(movie, x + 0.5, y + 0.5, w - 0.5, h - 0.5, r, 0xFF0000, 100, colBorder, 100);
			var colors:Array = new Array(0xffffff, 0xffffff, 0xffffff, 0xffffff);
			var alphas:Array = new Array(50, 65, 45, 0);
			var ratios:Array = new Array(0, 60, 120, 255);
			var flare:Number = (bVert ? w : h) * 2 / 3;
			var matrix:Object = bVert
				? {matrixType:"box", x:1, y:1, w:flare, h:h - 2, r:0}
				: {matrixType:"box", x:1, y:1, w:w - 2, h:flare, r:Math.PI / 2};
			movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
			drawRoundRect(movie, 1, 1, bVert ? flare + 1 : w - 1, bVert ? h - 1 : flare + 1, Math.max(0, r - 0.5));
			movie.endFill();
			switch(data.mode)
			{
				case "press": fillRoundRect(movie, x, y, w, h, r, 0, 10); break;
				case "over": fillRoundRect(movie, x, y, w, h, r, 0xffffff, 20); break;
			}
		}
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
		return new Object({off1:2, off2:2, h:25, btnW:18, btnH:18});
	}

	private function getResizeBtnParams():Object
	{
		return new Object({w:13, h:13, offX:16, offY:5});
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