class pseudo.look.StdLook implements pseudo.look.ILabelLook,
	pseudo.look.IEditLook, pseudo.look.IWindowManagerLook
{
	private var m_clrWindow:Number;
	private var m_clrHighlight:Number;
	private var m_clrBtnFace:Number;
	private var m_clrBtnShadow:Number;
	private var m_clrHilightText:Number;
	private var m_clrBtnText:Number;
	private var m_clrBtnHover:Number;
	private var m_clrBtnPressed:Number;
	private var m_clrBtnChecked:Number;
	private var m_clrBgHalf:Number;
	private var m_clrCellOver:Number;
	private var m_clrCellOut1:Number;
	private var m_clrCellOut2:Number;
	private var m_clrBox1:Number;
	private var m_clrBox2:Number;
	private var m_clrCellPress:Number;
	private var m_data:Object;
	private var m_strThemeId:String;

	static private var m_instance:pseudo.look.StdLook = null;

	//
	// PUBLIC METHODS
	//
	static public function getInstance():pseudo.look.StdLook
	{
		if(!m_instance) m_instance = new pseudo.look.StdLook();
		return m_instance;
	}

	public function setTheme(clrWindow:Number, clrHighlight:Number, clrBtnFace:Number,
		clrBtnShadow:Number, clrHilightText:Number, clrBtnText:Number):Void
	{
		m_clrWindow = clrWindow;
		m_clrHighlight = clrHighlight;
		m_clrBtnFace = clrBtnFace;
		m_clrBtnShadow = clrBtnShadow;
		m_clrHilightText = clrHilightText;
		m_clrBtnText = clrBtnText;

		var r1, r2, r3, g1, g2, g3, b1, b2, b3:Number;
		r1 = pseudo.Global.getR(m_clrWindow);
		g1 = pseudo.Global.getG(m_clrWindow);
		b1 = pseudo.Global.getB(m_clrWindow);
		r2 = pseudo.Global.getR(m_clrHighlight);
		g2 = pseudo.Global.getG(m_clrHighlight);
		b2 = pseudo.Global.getB(m_clrHighlight);
		r3 = pseudo.Global.getR(m_clrBtnFace);
		g3 = pseudo.Global.getG(m_clrBtnFace);
		b3 = pseudo.Global.getB(m_clrBtnFace);
	
		m_clrBtnHover = pseudo.Global.RGB(Math.round((r1 * 7 + r2 * 3) / 10), Math.round((g1 * 7 + g2 * 3) / 10), Math.round((b1 * 7 + b2 * 3) / 10));
		m_clrBtnPressed = pseudo.Global.RGB(Math.round((r1 + r2) / 2), Math.round((g1 + g2) / 2), Math.round((b1 + b2) / 2));
		m_clrBtnChecked = pseudo.Global.RGB(Math.round((r1 * 24 + r2 * 5 + r3 * 21) / 50), Math.round((g1 * 24 + g2 * 5 + g3 * 21) / 50), Math.round((b1 * 24 + b2 * 5 + b3 * 21) / 50));
		m_clrBgHalf = pseudo.Global.getBlendedColor(m_clrHighlight, 0xffffff, 10);
		m_clrCellOver = pseudo.Global.getBlendedColor(m_clrHighlight, 0xffffff, 12);
		m_clrCellOut1 = pseudo.Global.getBlendedColor(pseudo.Global.getBlendedColor(
			m_clrHighlight, m_clrWindow, 35), 0xffffff, 40);
		m_clrCellOut2 = pseudo.Global.getBlendedColor(pseudo.Global.getBlendedColor(
			m_clrHighlight, m_clrWindow, 60), 0xffffff, 40);
		m_clrBox1 = pseudo.Global.getBlendedColor(pseudo.Global.getBlendedColor(
			m_clrHighlight, m_clrWindow, 35), 0xffffff, 40);
		m_clrBox2 = pseudo.Global.getBlendedColor(pseudo.Global.getBlendedColor(
			m_clrHighlight, m_clrWindow, 60), 0xffffff, 60);
		m_clrCellPress = pseudo.Global.getBlendedColor(m_clrHighlight, 0xffffff, 5);
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
		return (xmlCurTheme.attributes.id == xmlTheme.attributes.id &&
			parseInt(xmlCurTheme.attributes.clrWindow) == parseInt(xmlTheme.attributes.clrWindow) &&
			parseInt(xmlCurTheme.attributes.clrHighlight) == parseInt(xmlTheme.attributes.clrHighlight) &&
			parseInt(xmlCurTheme.attributes.clrBtnFace) == parseInt(xmlTheme.attributes.clrBtnFace) &&
			parseInt(xmlCurTheme.attributes.clrBtnShadow) == parseInt(xmlTheme.attributes.clrBtnShadow) &&
			parseInt(xmlCurTheme.attributes.clrHilightText) == parseInt(xmlTheme.attributes.clrHilightText) &&
			parseInt(xmlCurTheme.attributes.clrBtnText) == parseInt(xmlTheme.attributes.clrBtnText));
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
		node.attributes.clrWindow = m_clrWindow;
		node.attributes.clrHighlight = m_clrHighlight
		node.attributes.clrBtnFace = m_clrBtnFace;
		node.attributes.clrBtnShadow = m_clrBtnShadow;
		node.attributes.clrHilightText = m_clrHilightText;
		node.attributes.clrBtnText = m_clrBtnText;
		xml.appendChild(node);
    return xml.childNodes[0];
  }

	public function fromXML(data:Object):Void
	{
		m_strThemeId = data.getAttr("id");
		setTheme(
			parseInt(data.getAttr("clrWindow")), parseInt(data.getAttr("clrHighlight")),
			parseInt(data.getAttr("clrBtnFace")), parseInt(data.getAttr("clrBtnShadow")),
			parseInt(data.getAttr("clrHilightText")), parseInt(data.getAttr("clrBtnText"))
		);
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
			case "move":
				return "themes/stdLook_move.swf";
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
		return new Array("diagResize1", "horzResize", "vertResize", "move");
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
			case "btnTab":
				return strBorder == "right" ? 3 : (strBorder == "left" ? 1 : 0);
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
			case "WindowPaneTitle":
			case "PaneTitle":
				strType = "windowPaneTitle";
				break;
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
			case "tabMark":
				nMargin = getBorder(strMargin, data);
				switch(strMargin)
				{
					case "left":
				 		nMargin += 9;
				 		break;
					case "top":
				 		nMargin += 1;
				 		break;
				}
				break;
			case "windowPaneTitle":
				nMargin = getBorder(strMargin, data);
				switch(strMargin)
				{
					case "left":
						nMargin += 10;
						break;
					case "right":
						nMargin += 2;
						break;
					case "top":
					case "bottom":
						nMargin += 1;
						break;
				}
				break;
			case "main":
				nMargin = 5;
				break;
			case "cell":
				nMargin = 2 + getBorder(strMargin, data);
				break;
			case "titleBtnBack":
			case "tabBack":
				nMargin = getBorder(strMargin, data);
				switch(strMargin)
				{
					case "right":
					case "left":
						nMargin += 2;
						break;
					case "top":
					case "bottom":
						nMargin += 1;
						break;
				}
				break;
			case "resizeTitle":
				nMargin = getBorder(strMargin, data) + (strMargin == "right" ? 18 : 2);
				break;
			case "edit":
			case "textArea":
			case "comboBoxTitle":
			case "info":
				nMargin = strMargin == "left" || strMargin == "right" ? 2 : 0;
				break;
			case "gallery":
				nMargin = 5 + getBorder(strMargin, data);
				break;
			case "label":
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
			case "TextArea":
			case "ComboBox":			case "BaseComboBox":
			case "Button":
			case "PaneTitle":
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
					case "btnTab":
						var mode:String = data.focus == 0 ? "out" : data.mode;
						switch(mode)
						{
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrHilightText) + "' face='Tahoma' size='12'>";
								break;
							case "disabled":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnShadow) + "' face='Tahoma' size='12'>";
								break;
							default:
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>";
								break;
						}
						break;
					case "cellThread":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>" +
							(data.mode == "name" ? "<b>" : "");
						break;
					case "tabMark":
						switch(data.mode)
						{
							case "press":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrHilightText) + "' face='Tahoma' size='9'>";
								break;
							default:
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='9'>";
								break;
						}
						break;
					case "label":
					case "edit":
					case "info":
					case "textArea":
					case "comboBoxTitle":
					case "checkbox":
						strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'>";
						break;
					case "cellIconText":
					case "cellText":
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
								strRes = "<u><font color='" + pseudo.Global.getHTMLColor(m_clrHighlight) + "' face='Tahoma' size='12'>";
								break;
							//case "out":
							default:
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrHighlight) + "' face='Tahoma' size='12'>";
								break;
						}
						break;
					case "titleBtnBack":
						switch(data.mode)
						{
							case "out":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrHighlight) + "' face='Tahoma' size='12'><b>";
								break;
							case "over":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnText) + "' face='Tahoma' size='12'><b>";
								break;
							case "disabled":
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnShadow) + "' face='Tahoma' size='12'><b>";
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
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnShadow) + "' face='Tahoma' size='12'><b>";
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
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnShadow) + "' face='Tahoma' size='12'>";
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
								strRes = "<font color='" + pseudo.Global.getHTMLColor(m_clrBtnShadow) + "' face='Tahoma' size='12'>";
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
		pseudo.Global.drawRect(movie, nX - 1, nY - 1, nW + 2, 2, m_clrBtnPressed);
		pseudo.Global.drawRect(movie, nX - 1, nY + 1, 2, nH, m_clrBtnPressed);
		pseudo.Global.drawRect(movie, nX + 1, nY + nH - 1, nW, 2, m_clrBtnPressed);
		pseudo.Global.drawRect(movie, nX + nW - 1, nY + 1, 2, nH, m_clrBtnPressed);
	}

	//
	// PRIVATE METHODS
	//

	private function StdLook()
	{
		m_strThemeId = "";
		setTheme(0xd4d0c8, 0x0a246a, 0xd4d0c8, 0x303030, 0xffffff, 0); // blue
	}

	private function drawMain(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		//0xf4f8f3
		var colors:Array = [m_clrBgHalf, 0xffffff, 0xffffff, m_clrBgHalf];
		var alphas:Array = [100, 100, 100, 100];
		var ratios:Array = [0, 108, 148, 255];
		var matrix = {matrixType:"box", x:0, y:0, w:nW, h:nH, r:Math.PI / 2};
		movie.clear();
		movie.beginGradientFill("linear", colors, alphas, ratios, matrix);
		movie.moveTo(0, 0);
		movie.lineTo(nW, 0);
		movie.lineTo(nW, nH);
		movie.lineTo(0, nH);
		movie.lineto(0, 0);
		movie.endFill();
	}

	private function drawMovie(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "resizeLine":
				drawResizeLine(movie, 0, 0, nW, nH);
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
					case "over":
						clr = m_clrBtnHover;
						break;
					case "press":
						clr = m_clrBtnHover;
						break;
					default:
						clr = 0xffffff;
						break;
				}
				break;
			default:
				switch(data.mode)
				{
					case "over":
						clr = m_clrCellOver;
						break;
					case "press":
						clr = m_clrCellPress;
						break;
					default:
						clr = data.ind % 2 ? m_clrCellOut1 : m_clrCellOut2;
						break;
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
					pseudo.Global.drawRect(movie, params.offStart + i * params.off, 0, 1, nH, m_clrBtnShadow, alpha);
			if(data.last) pseudo.Global.drawRect(movie, off, 0, 1, dh, m_clrBtnShadow, alpha);
		}
		else if(!data.last)
			pseudo.Global.drawRect(movie, off, dh, 1, nH - dh, m_clrBtnShadow, alpha);
		if(data.cellType == 1)
		{
			var size:Number = 9;
			var dsize:Number = 4;
			var x:Number = off - dsize;
			var y:Number = Math.round((nH - 9) / 2);
			// draw outer rect
			pseudo.Global.drawRect(movie, x, y, size, size, m_clrBtnShadow);
			// draw inner rect
			pseudo.Global.drawRect(movie, x + 1, y + 1, size - 2, size - 2,
				(data.visible || !data.hasChildren) ? m_clrBox1 : m_clrBox2);
			// draw '-' line
			pseudo.Global.drawRect(movie, x + size, y + dsize, params.off - dsize, 1, m_clrBtnShadow, alpha);
			if(data.hasChildren)
			{
				// draw minus
				pseudo.Global.drawRect(movie, x + 2, y + dsize, size - 4, 1, m_clrBtnShadow);
				if(data.visible) // draw '|' line
					pseudo.Global.drawRect(movie, off + params.off, y + dsize + 1, 1, nH - y - dsize - 1, m_clrBtnShadow, alpha);
				else // draw vert line
					pseudo.Global.drawRect(movie, x + dsize, y + 2, 1, size - 4, m_clrBtnShadow);
			}
		}
		else
			pseudo.Global.drawRect(movie, off + 1, dh - 1, 6, 1, m_clrBtnShadow, alpha);
	}

	private function drawCellThread(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		var nTitleH:Number = 50;
		pseudo.Global.drawRect(movie, 4, 4, nW - 8, nTitleH, m_clrCellOut1);
		pseudo.Global.drawRect(movie, 4, nTitleH + 4, nW - 8, nH - nTitleH - 8, m_clrCellOver);
		switch(data.mode)
		{
			case "over":
				pseudo.Global.drawFrame(movie, 2, 2, nW - 4, nH - 4, m_clrBtnPressed, 100, 2);
				break;
			case "press":
				pseudo.Global.drawFrame(movie, 2, 2, nW - 4, nH - 4, m_clrBtnShadow, 100, 2);
				break;
			default:
				//pseudo.Global.drawFrame(movie, 2, 2, nW - 4, nH - 4, 0xffffff, 100, 2);
				break;
		}
	}

	private function drawButton(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.mode)
		{
			/*case "disabled":
				drawBtnDisabled(movie, nW, nH, data);
				break;*/
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
			case "btnTab":
				drawBtnTab(movie, nW, nH, data);
				break;
			case "tabMark":
				drawTabMark(movie, nW, nH, data);
				break;
			case "moveHandler":
				drawMoveHandler(movie, nW, nH, data);
				break;
			case "resizeLeft":
			case "resizeRight":
			case "resizeTop":
			case "resizeBottom":
				drawResizeBtnLayer(movie, nW, nH, data, m_clrBtnFace, m_clrBtnShadow, m_clrBtnText);
				break;
			case "resizeTitle":
				drawResizeTitle(movie, nW, nH, m_clrBtnHover, m_clrBtnShadow, m_clrBtnText, data);
				break;
			case "edit":
				drawLayer(movie, nW, nH, 0xffffff, m_clrBtnShadow, data.border);
				break;
			case "scrollBack":
				movie.clear();
				pseudo.Global.drawRect(movie, 0, 0, nW, nH, m_clrBtnFace);
				break;
			case "comboBoxBtn":
			case "scrollLow":
			case "scrollHi":
				drawScrollLayer(movie, nW, nH, data, m_clrBtnFace, m_clrBtnShadow, m_clrBtnText);
				break;
			case "titledIconButton":
			case "iconButton":
			case "url":
				movie.clear();
				break;
			case "tabBack":
				drawTabBack(movie, nW, nH, data);
				break;
			case "titleBtnBack":
				drawTitleBack(movie, nW, nH, data);
				break;
			case "titleBtnHide":
			case "titleBtnMinimize":
				drawTitleButton(movie, nW, nH, m_clrBtnFace, m_clrBtnShadow, m_clrBtnText, data);
				break;
			case "titleBtnClose":
				drawTitleButton(movie, nW, nH, 0xf9dcd2, m_clrBtnShadow, m_clrBtnText, data);
				break;
			case "resizeHandle":
				drawResizeHandleBtn(movie, nW, nH, m_clrBtnShadow);
				break;
			case "comboBox":
				drawLayer(movie, nW, nH, 0xffffff, m_clrBtnShadow, data.border);
				break;
			case "btnGo":
				drawLayer(movie, nW, nH, m_clrBtnFace, m_clrBtnShadow, data.border);
				drawGo(movie, 0, 0, nW, nH, m_clrBtnText);
				break;
			case "checkbox":
				drawBtnCheckBox(movie, nW, nH, m_clrBtnFace, m_clrBtnShadow, m_clrBtnShadow, data);
				break;
			default:
				drawDefaultBtn(movie, nW, nH, data);
				break;
		}
	}

	private function drawBtnOver(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "btnTab":
				drawBtnTab(movie, nW, nH, data);
				break;
			case "tabMark":
				drawTabMark(movie, nW, nH, data);
				break;
			case "moveHandler":
				drawMoveHandler(movie, nW, nH, data);
				break;
			case "resizeLeft":
			case "resizeRight":
			case "resizeTop":
			case "resizeBottom":
				drawResizeBtnLayer(movie, nW, nH, data, m_clrBtnHover, m_clrHighlight, m_clrBtnText);
				break;
			case "resizeTitle":
				drawResizeTitle(movie, nW, nH, m_clrBtnHover, m_clrBtnShadow, m_clrHighlight, data);
				break;
			case "edit":
				drawLayer(movie, nW, nH, 0xffffff, m_clrBtnHover, data.border);
				break;
			case "comboBoxBtn":
			case "scrollLow":
			case "scrollHi":
				drawScrollLayer(movie, nW, nH, data, m_clrBtnHover, m_clrHighlight, m_clrBtnText);
				break;
			case "titledIconButton":
			case "scrollBack":
			case "url":
				//movie.clear();
				break;
			case "tabBack":
				drawTabBack(movie, nW, nH, data);
				break;
			case "titleBtnBack":
				drawTitleBack(movie, nW, nH, data);
				break;
			case "titleBtnHide":
			case "titleBtnMinimize":
				drawTitleButton(movie, nW, nH, m_clrBtnHover, m_clrHighlight, m_clrBtnText, data);
				break;
			case "titleBtnClose":
				drawTitleButton(movie, nW, nH, 0xfaa69a, m_clrHighlight, m_clrBtnText, data);
				break;
			case "resizeHandle":
				drawResizeHandleBtn(movie, nW, nH, m_clrBtnShadow);
				break;
			case "comboBox":
				drawLayer(movie, nW, nH, 0xffffff, m_clrHighlight, data.border);
				break;
			case "btnGo":
				drawLayer(movie, nW, nH, m_clrBtnHover, m_clrHighlight, data.border);
				drawGo(movie, 0, 0, nW, nH, m_clrBtnText);
				break;
			case "checkbox":
				drawBtnCheckBox(movie, nW, nH, m_clrBtnHover, m_clrHighlight, m_clrBtnShadow, data);
				break;
			default:
				drawDefaultBtn(movie, nW, nH, data);
				break;
		}
	}

	private function drawBtnPress(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "btnTab":
				drawBtnTab(movie, nW, nH, data);
				break;
			case "tabMark":
				drawTabMark(movie, nW, nH, data);
				break;
			case "moveHandler":
				drawMoveHandler(movie, nW, nH, data);
				break;
			case "resizeLeft":
			case "resizeRight":
			case "resizeTop":
			case "resizeBottom":
				drawResizeBtnLayer(movie, nW, nH, data, m_clrBtnPressed, m_clrHighlight, m_clrHilightText);
				break;
			case "resizeTitle":
				drawResizeTitle(movie, nW, nH, m_clrBtnHover, m_clrBtnShadow, m_clrHilightText, data);
				break;
			case "edit":
				drawLayer(movie, nW, nH, 0xffffff, m_clrBtnPressed, data.border);
				break;
			case "comboBoxBtn":
			case "scrollLow":
			case "scrollHi":
				drawScrollLayer(movie, nW, nH, data, m_clrBtnPressed, m_clrHighlight, m_clrHilightText);
				break;
			case "scrollBack":
			case "titledIconButton":
			case "url":
				//movie.clear();
				break;
			case "tabBack":
				drawTabBack(movie, nW, nH, data);
				break;
			case "titleBtnBack":
				drawTitleBack(movie, nW, nH, data);
				break;
			case "titleBtnHide":
			case "titleBtnMinimize":
				drawTitleButton(movie, nW, nH, m_clrBtnPressed, m_clrHighlight, m_clrHilightText, data);
				break;
			case "titleBtnClose":
				drawTitleButton(movie, nW, nH, 0xea8e8e, m_clrHighlight, m_clrHilightText, data);
				break;
			case "resizeHandle":
				drawResizeHandleBtn(movie, nW, nH, m_clrBtnShadow);
				break;
			case "comboBox":
				drawLayer(movie, nW, nH, 0xffffff, m_clrHighlight, data.border);
				break;
			case "btnGo":
				drawLayer(movie, nW, nH, m_clrBtnPressed, m_clrHighlight, data.border);
				drawGo(movie, 0, 0, nW, nH, m_clrHilightText);
				break;
			case "checkbox":
				drawBtnCheckBox(movie, nW, nH, m_clrBtnPressed, m_clrHighlight, m_clrBtnShadow, data);
				break;
			default:
				drawDefaultBtn(movie, nW, nH, data);
				break;
		}
	}

	private function drawDefaultBtn(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		if(data.state == "sunken")
		{
			var clr1:Number = m_clrBtnChecked;
			var clr2:Number = m_clrBtnShadow;
			switch(data.mode)
			{
				case "over":
					clr1 = m_clrBtnHover;
					clr2 = m_clrHighlight;
					break;
				case "press":
					clr1 = m_clrBtnPressed;
					clr2 = m_clrHighlight;
				break;
			}
			drawCheckedLayer(movie, nW, nH, clr1, clr2, data.border);
		}
		else
		{
			var clr1:Number = m_clrBtnFace;
			var clr2:Number = m_clrBtnShadow;
			switch(data.mode)
			{
				case "over":
					clr1 = m_clrBtnHover;
					clr2 = m_clrHighlight;
					break;
				case "press":
					clr1 = m_clrBtnPressed;
					clr2 = m_clrHighlight;
					break;
			}
			drawLayer(movie, nW, nH, clr1, clr2, data.border);
		}
	}

	private function drawMoveHandler(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		pseudo.Global.drawRect(movie, 0, 0, nW, nH, 0, 0);
		var x:Number = Math.round(nW / 2) - 1;
		var count:Number = Math.round((nH - 5) / 5);
		var y:Number = Math.round((nH - count * 5) / 2) + 1;
		for(var i:Number = 0; i < count; i++)
		{
			pseudo.Global.drawRect(movie, x, y, 2, 3);
			y += 5;
		}
		/*for(var i:Number = 0; i < 2; i++)
			for(var j:Number = 0; j < 4; j++)
				pseudo.Global.drawRect(movie, nW - i * 4 - 3, j * 4 + 4, 2, 2, 0);*/
	}

	private function drawBtnTab(movie:MovieClip, w:Number, h:Number, data:Object):Void
	{
		movie.clear();
		var clr:Number = m_clrBtnFace;
		var alpha:Number = data.focus ? 0 : 100;
		pseudo.Global.drawRect(movie, 0, 0, w, h, clr, alpha);
		if(data.focus && data.focus != 1) pseudo.Global.drawRect(movie, w - 1, 3, 1, h - 7, m_clrBtnShadow);
	}

	private function drawTabBack(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		drawLayer(movie, nW, nH, m_clrBtnHover, m_clrBtnShadow, 11);
	}

	private function drawTitleBack(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		drawLayer(movie, nW, nH, data.mode == "over" ? m_clrBtnHover : m_clrBtnFace, m_clrBtnShadow, data.border);
	}

	private function drawResizeHandleBtn(movie:MovieClip, nW:Number, nH:Number, clrFill:Number):Void
	{
		movie.clear();
		movie.beginFill(0, 0);
		movie.moveTo(0, nH - 3);
		movie.lineTo(nW - 3, nH - 3);
		movie.lineTo(nW - 3, 0);
		movie.endFill();
		pseudo.Global.drawRect(movie, nW - 3, 0, 3, 9, clrFill);
		pseudo.Global.drawRect(movie, 0, nH - 3, 9, 3, clrFill);
	}

	private function drawTitleButton(movie:MovieClip, nW:Number, nH:Number, clrFill:Number, clrBorder:Number, clrImg:Number, data:Object):Void
	{
		drawLayer(movie, nW, nH, clrFill, clrBorder, data.border);
		switch(data.type)
		{
			case "titleBtnHide":
				var nOffX:Number = Math.round((nW - 6) / 2);
				var nOffY:Number = Math.round((nH - 8) / 2);
				pseudo.Global.drawRect(movie, nOffX - 1, nOffY + 6, 6, 2, clrImg);
				break;
			case "titleBtnMinimize":
				var nOffX:Number = Math.round((nW - 9) / 2);
				var nOffY:Number = Math.round((nH - 9) / 2);
				if(data.state == "sunken")
				{
					pseudo.Global.drawRect(movie, nOffX + 2, nOffY, 7, 2, clrImg);
					pseudo.Global.drawRect(movie, nOffX + 8, nOffY + 2, 1, 4, clrImg);
					pseudo.Global.drawRect(movie, nOffX, nOffY + 3, 7, 2, clrImg);
					pseudo.Global.drawRect(movie, nOffX, nOffY + 5, 1, 4, clrImg);
					pseudo.Global.drawRect(movie, nOffX + 1, nOffY + 8, 6, 1, clrImg);
					pseudo.Global.drawRect(movie, nOffX + 6, nOffY + 5, 1, 4, clrImg);
				}
				else
				{
					pseudo.Global.drawRect(movie, nOffX, nOffY, 9, 2, clrImg);
					pseudo.Global.drawRect(movie, nOffX, nOffY + 2, 1, 7, clrImg);
					pseudo.Global.drawRect(movie, nOffX + 1, nOffY + 8, 8, 1, clrImg);
					pseudo.Global.drawRect(movie, nOffX + 8, nOffY + 2, 1, 7, clrImg);
				}
				break;
			case "titleBtnClose":
				var nOffX:Number = Math.round((nW - 8) / 2);
				var nOffY:Number = Math.round((nH - 7) / 2);
				for(var i = 0; i < 7; i++)
				{
					pseudo.Global.drawRect(movie, nOffX + i, nOffY + i, 2, 1, clrImg);
					pseudo.Global.drawRect(movie, nOffX + 6 - i, nOffY + i, 2, 1, clrImg);
				}
				break;
		}
		movie._alpha = data.faded && data.mode == "out" ? 60 : 100;
	}

	private function drawPane(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		switch(data.type)
		{
			case "utilitiesPane":
			case "infoPane":
			case "comboBoxPane":
				drawLayer(movie, nW, nH, 0xffffff, m_clrBtnShadow, data.border);
				break;
			default:
				drawLayer(movie, nW, nH, m_clrWindow, m_clrBtnShadow, data.border);
				break;
		}
	}

	private function drawResizeLine(movie:MovieClip, nX:Number, nY:Number, nW:Number, nH:Number, data:Object):Void
	{
		movie.clear();
		pseudo.Global.drawRect(movie, nX, nY, nW, nH, m_clrBtnPressed);
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
				pseudo.Global.drawRect(movie, 0, 0, nW, nH, m_clrBtnFace);
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
		var clr = new Color(icon);
		var matrix:Object;
		switch(data.mode)
		{
			case "over":
				var r:Number = pseudo.Global.getR(m_clrBtnHover);
				var g:Number = pseudo.Global.getG(m_clrBtnHover);
				var b:Number = pseudo.Global.getB(m_clrBtnHover);
				var min:Number = pseudo.Global.max(r, g, b) - 40;
				r -= min;
				g -= min;
				b -= min;
				matrix = {ra:'80', rb:r, ga:'80', gb:g, ba:'80', bb:b};
				data.fldText.border = true;
				data.fldText.borderColor = m_clrHighlight;
				data.fldText.background = true;
				data.fldText.backgroundColor = m_clrBtnHover;
				break;
			case "press":
				var r:Number = pseudo.Global.getR(m_clrBtnPressed);
				var g:Number = pseudo.Global.getG(m_clrBtnPressed);
				var b:Number = pseudo.Global.getB(m_clrBtnPressed);
				var min:Number = pseudo.Global.max(r, g, b) - 40;
				r -= min;
				g -= min;
				b -= min;
				matrix = {ra:'80', rb:r, ga:'80', gb:g, ba:'80', bb:b};
				data.fldText.border = true;
				data.fldText.borderColor = m_clrHighlight;
				data.fldText.background = true;
				data.fldText.backgroundColor = m_clrBtnPressed;
				break;
			case "out":
				matrix = {ra:'100', rb:'0', ga:'100', gb:'0', ba:'100', bb:'0'};
				data.fldText.border = false;
				data.fldText.background = false;
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

	private function drawCheckedLayer(movie:MovieClip, nW:Number, nH:Number, clrFill:Number, clrBorder:Number, nBorder:Number):Void
	{
		if(nBorder == undefined || nBorder == null) nBorder = 1 + 2 + 4 + 8; // draw all border lines on default
		drawLayer(movie, nW, nH, clrFill, clrBorder, nBorder);
		if(nBorder & 1) pseudo.Global.drawRect(movie, 1, 1, nW - 2, 1, clrBorder);
		if(nBorder & 2) pseudo.Global.drawRect(movie, 1, 1, 1, nH - 2, clrBorder);
		if(nBorder & 4) pseudo.Global.drawRect(movie, 1, nH - 2, nW - 2, 1, clrBorder);
		if(nBorder & 8) pseudo.Global.drawRect(movie, nW - 2, 1, 1, nH - 2, clrBorder);
	}

	private function drawCheckBox(movie:MovieClip, x:Number, y:Number, clrFill:Number, clrBorder:Number, clrImage:Number, bChecked:Boolean):Void
	{
		pseudo.Global.drawRect(movie, x, y, 13, 13, clrFill);
		pseudo.Global.drawFrame(movie, x, y, 13, 13, clrBorder, 100, bChecked ? 2 : 1);
		if(bChecked)
		{
			for(var i = 0; i < 3; i++)
				pseudo.Global.drawRect(movie, x + i + 3, y + i + 5, 1, 3, clrImage);
			for(var i = 0; i < 4; i++)
				pseudo.Global.drawRect(movie, x - i + 9, y + i + 3, 1, 3, clrImage);
		}
	}

	private function drawBtnCheckBox(movie:MovieClip, w:Number, h:Number, clrFill:Number, clrBorder:Number, clrImage:Number, data:Object):Void
	{
		movie.clear();
		pseudo.Global.drawRect(movie, 0, 0, w, h, 0, 0);
		drawCheckBox(movie, 0, Math.round((h - 13) / 2 - 1), clrFill, clrBorder, clrImage, data.state == "sunken");
	}

	private function drawResizeTitle(movie:MovieClip, nW:Number, nH:Number, clrFill:Number, clrBorder:Number, clrImage:Number, data:Object):Void
	{
		drawLayer(movie, nW, nH, clrFill, clrBorder, data.border);
		drawDoubleArrow(movie, nW - 13, Math.round((nH - 8) / 2),
			data.state == "normal" ? "up" : "down", clrImage);
	}

	private function drawTabMark(movie:MovieClip, nW:Number, nH:Number, data:Object):Void
	{
		drawDefaultBtn(movie, nW, nH, data);
		var clr:Number = data.mode == "press" ? m_clrHilightText : m_clrBtnText;
		drawSingleArrow(movie, 3, 4, "down", clr);
		drawSingleArrow(movie, 3, 4 + 4, "down", clr);
	}

	private function drawDoubleArrow(movie:MovieClip, nX:Number, nY:Number, strDir:String, clrImage:Number):Void
	{
		drawSingleArrow(movie, nX, nY, strDir, clrImage);
		drawSingleArrow(movie, nX, nY + 4, strDir, clrImage);
	}

	private function drawSingleArrow(movie:MovieClip, nX:Number, nY:Number, strDir:String, clrImage:Number):Void
	{
		var nSign:Number = strDir == "down" ? -1 : 1;
		var nOff:Number = strDir == "down" ? 3 : 0;
		pseudo.Global.drawRect(movie, nX + 0, nY + nOff + nSign * 3, 2, 1, clrImage);
		pseudo.Global.drawRect(movie, nX + 1, nY + nOff + nSign * 2, 2, 1, clrImage);
		pseudo.Global.drawRect(movie, nX + 2, nY + nOff + nSign * 1, 3, 1, clrImage);
		pseudo.Global.drawRect(movie, nX + 3, nY + nOff + nSign * 0, 1, 1, clrImage);
		pseudo.Global.drawRect(movie, nX + 4, nY + nOff + nSign * 2, 2, 1, clrImage);
		pseudo.Global.drawRect(movie, nX + 5, nY + nOff + nSign * 3, 2, 1, clrImage);
	}

	private function drawSolidArrow(movie:MovieClip, nX:Number, nY:Number,
		nW:Number, nH:Number, dir:String, clr:Number):Void
	{
		var bVert:Boolean = dir == "up" || dir == "down";
		var size:Number = bVert
			? ((nW / 2 > nH) ? nH * 2 : nW)
			: ((nH / 2 > nW) ? nW * 2 : nH);
		size -= size % 2 ? 0 : 1;
		var halfSize:Number = (size + 1) / 2;
		var x:Number = nX + Math.round((nW - (bVert ? size : halfSize)) / 2);
		var y:Number = nY + Math.round((nH - (bVert ? halfSize : size)) / 2);
		switch(dir)
		{
			case "up":
				for(var i:Number = 0; i < halfSize; i++)
					pseudo.Global.drawRect(movie, x + i, y + halfSize - 1 - i, size - i * 2, 1, clr);
				break;
			case "down":
				for(var i:Number = 0; i < Math.floor(size / 2) + 1; i++)
					pseudo.Global.drawRect(movie, x + i, y + i, size - i * 2, 1, clr);
				break;
			case "left":
				for(var i:Number = 0; i < halfSize; i++)
					pseudo.Global.drawRect(movie, x + halfSize - 1 - i, y + i, 1, size - i * 2, clr);
				break;
			case "right":
				for(var i:Number = 0; i < Math.floor(size / 2) + 1; i++)
					pseudo.Global.drawRect(movie, x + i, y + i, 1, size - i * 2, clr);
				break;
		}
	}

	private function drawGo(movie:MovieClip, x:Number, y:Number, w:Number, h:Number, clr:Number):Void
	{
		drawSolidArrow(movie, x, y + 5, w - 2, h - 10, "right", clr);
		drawSolidArrow(movie, x + 8, y + 5, w - 10, h - 10, "right", clr);
	}

	private function drawResizeBtnLayer(movie:MovieClip, nW:Number, nH:Number, data:Object,
		clrFill:Number, clrBorder:Number, clrImage:Number):Void
	{
		movie.clear();
		drawLayer(movie, nW, nH, clrFill, clrBorder);
		var bSunken:Boolean = data.state == "sunken";
		switch(data.type)
		{
			case "resizeRight":
				drawSolidArrow(movie, bSunken ? 2 : 1, 1, nW - 3, nH - 2, bSunken ? "left" : "right", clrImage);
				break;
			case "resizeLeft":
				drawSolidArrow(movie, bSunken ? 1 : 2, 1, nW - 3, nH - 2, bSunken ? "right" : "left", clrImage);
				break;
			case "resizeTop":
				drawSolidArrow(movie, 1, bSunken ? 1 : 2, nW - 2, nH - 3, bSunken ? "down" : "up", clrImage);
				break;
			case "resizeBottom":
				drawSolidArrow(movie, 1, bSunken ? 2 : 1, nW - 2, nH - 3, bSunken ? "up" : "down", clrImage);
				break;
		}
	}

	private function drawScrollLayer(movie:MovieClip, nW:Number, nH:Number,
		data:Object, clrFill:Number, clrBorder:Number, clrImage:Number):Void
	{
		drawLayer(movie, nW, nH, clrFill, clrBorder, data.border);
		var nX, nY, nMaxLong, nMaxShort, nHalf, nSize:Number;
		var bLow:Boolean = data.type == "scrollLow" && data.type != "comboBoxBtn";
		var bVert:Boolean = data.dir == "vert" || data.type == "comboBoxBtn";
		if(bVert)
		{
			nMaxLong = nW - 8 + (nW - 1) % 2;
			nMaxShort = nH - 8 + nH % 2;
			nSize = nMaxLong > nMaxShort * 2 - 1 ? nMaxShort * 2 - 1 : nMaxLong;
			nHalf = Math.floor(nH / 2 + (bLow ? 1 : -1) * ((nSize + 1) / 4 - 1));
			nX = Math.floor((nW - nSize) / 2);
		}
		else
		{
			nMaxShort = nW - 8 + nW % 2;
			nMaxLong = nH - 8 + (nH - 1) % 2;
			nSize = nMaxLong > nMaxShort * 2 - 1 ? nMaxShort * 2 - 1 : nMaxLong;
			nHalf = Math.floor(nW / 2 + (bLow ? 1 : -1) * ((nSize + 1) / 4 - 1));
			nY = Math.floor((nH - nSize) / 2);
		}
		if(bLow)
		{
			if(bVert)
			{
				for(var i:Number = nSize; i > 0; i -= 2)
					pseudo.Global.drawRect(movie, nX + (nSize - i) / 2, nHalf - (nSize - i) / 2, i, 1, clrImage);
			}
			else
			{
				for(var i:Number = nSize; i > 0; i -= 2)
					pseudo.Global.drawRect(movie, nHalf - (nSize - i) / 2, nY + (nSize - i) / 2, 1, i, clrImage);
			}
		}
		else
		{
			if(bVert)
			{
				for(var i:Number = nSize; i > 0; i -= 2)
					pseudo.Global.drawRect(movie, nX + (nSize - i) / 2, nHalf + (nSize - i) / 2, i, 1, clrImage);
			}
			else
			{
				for(var i:Number = nSize; i > 0; i -= 2)
					pseudo.Global.drawRect(movie, nHalf + (nSize - i) / 2, nY + (nSize - i) / 2, 1, i, clrImage);
			}
		}
	}

	private function getWndTitleParams():Object
	{
		// off1 - offset between hide and maximize buttons
		// off2 - offset between maximize and close buttons
		return new Object({off1:1, off2:3, h:22, btnW:15, btnH:15});
	}

	private function getResizeBtnParams():Object
	{
		return new Object({w:9, h:9, offX:5, offY:5});
	}

	private function getResizeLineParams(strAlign:String, data:Object):Object
	{
		var obj:Object = new Object();
		switch(strAlign)
		{
			case "top":
			case "bottom":
				obj.btnW = 28;
				obj.btnH = 8;
				break;
			default: // left or right
				obj.btnW = 8;
				obj.btnH = 28;
				break;
		}
		return obj;
	}

	private function getTreeParams():Object
	{
		return {offStart:8, off:8, iconW:9, iconH:12};
	}
}