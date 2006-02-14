class pseudo.Tree extends pseudo.List
{
	private var m_arrTreeData:Array;
	private var m_nSelLeaf:Number;

	//
	// PUBLIC METHODS
	//

	/**
	 * Creates tree.
	 * @param pOwner Parent of the tree.
	 * @param strName Tree name.
	 * @param nDepth Tree movie depth.
	 * @return Created tree.
	 */
	static public function create(pOwner:MovieClip, strName:String, nDepth:Number):pseudo.Tree
	{
		pOwner.createEmptyMovieClip(strName, nDepth);
		pOwner[strName].__proto__ = new pseudo.Tree(pOwner[strName]);
		return pOwner[strName];
	}

	/**
	 * Constructor. You should create tree by calling
	 * pseudo.Tree.create(...) instead of calling
	 * this constructor otherwise you don't get movie instance.
	 * @param pThis Pointer to this MovieClip.
	 */
	public function Tree(pThis:MovieClip)
	{
		super(pThis);
		if(!pThis) pThis = this;
		m_pClass = pseudo.Tree;

		m_arrData = new Array();
		addListener("changed", pThis, onChanged);
	}

	/**
	 * Updates tree data. Generates temporary tree structure. By using this
	 * tree adds to m_arrTreeData information about vert. lines visibility.
	 * Also adds to m_arrTreeData previous and next depths values.
	 * This functions should always be called whenever the data values are changed.
	 */
	public function updateTreeData():Void
	{
		var arrLines:Array = new Array();
		var node:Object = getTreeStruct(m_arrTreeData).nodes[0];
		while(node)
		{
			var nodes:Array = node.parent.nodes;
			var item:Object = node.item;
			// is node first
			item.first = node == nodes[0];
			// is node last
			item.last = node == nodes[nodes.length - 1];
			// does the node have children
			var hasChildren:Boolean = node.nodes ? node.nodes.length > 0 : false;
			if(item.cellType == -1) item.cellType = hasChildren ? 1 : 0;
			if(item.cellType == 1)
				item.hasChildren = hasChildren;
			var depth:Number = item.depth;
			if(arrLines.length > depth)
				arrLines.splice(depth);
			arrLines.push(!item.last);
			item.lines = arrLines.slice();
			node = node.next;
		}
		m_bUpdated = false;
	}

	public function setTreeData(arrData:Array)
	{
		m_arrTreeData = arrData;
		m_nSelLeaf = -1;
		updateTreeData();
	}

	public function getTreeData():Array
	{
		return m_arrTreeData;
	}

	public function collapseAll():Void
	{
		m_nOldSel = m_nSelCell = -1;
		for(var i:Number = 0; i < m_arrTreeData.length; i++)
			if(m_arrTreeData[i].cellType == 1) m_arrTreeData[i].visible = false;
		updateData();
		//updateTreeSel();
	}

	public function expandAll():Void
	{
		m_nOldSel = m_nSelCell = -1;
		for(var i:Number = 0; i < m_arrTreeData.length; i++)
			if(m_arrTreeData[i].cellType == 1) m_arrTreeData[i].visible = true;
		updateData();
		//updateTreeSel();
	}

	public function getTreeStruct(arrData:Array):Object
	{
		var root:Object = null;
		if(arrData.length > 0)
		{
			var node:Object = root = new Object();
			var prevItem:Object = null;
			for(var i:Number = 0; i < arrData.length; i++)
			{
				var item:Object = arrData[i];
				while(node.item && node.item.depth >= item.depth)
					node = node.parent;
				var subNode:Object = {item:item, parent:node};
				if(prevItem) prevItem.next = subNode;
				prevItem = subNode;
				if(!node.nodes) node.nodes = new Array();
				node.nodes.push(subNode);
				node = subNode;
			}
		}
		return root;
	}
/*
	private function updateBranch(id:Number):Void
	{
		var clrInd:Number = m_arrTreeData[id].clrInd;
		var depth, cellType:Number;
		var minDepth:Number = m_arrTreeData[id].depth;
		var arrNewData:Array = new Array();
		var i:Number = id;
		do
		{
			var curItem:Object = m_arrTreeData[i];
			if(curItem.cellType != cellType || curItem.depth != depth)
			{ // increase color number and update color switchers
				depth = curItem.depth;
				cellType = curItem.cellType;
				clrInd++;
			}
			if(curItem.cellType == 1 && !curItem.visible)
			{ // hidden branch
				var curDepth:Number = curItem.depth;
				while(++i < m_arrTreeData.length)
					if(m_arrTreeData[i].depth <= curDepth) break;
					else m_arrTreeData[i].ind = -1;
				i--;
			}
			curItem.clrInd = clrInd;
			arrNewData.push(curItem);
			i++;
		} while(i < m_arrTreeData.length && m_arrTreeData[i].depth > minDepth)
		arrNewData.shift();
		var listId1:Number = m_arrTreeData[id].ind;
		if(!listId1) listId1 = 0;
		listId1++;
		var listId2:Number = m_arrTreeData[i].ind;
		if(!listId2) listId2 = 0;
		if(listId2) m_arrData.splice(listId1, listId2 - listId1);
		for(i = arrNewData.length - 1; i >= 0; i--)
			m_arrData.splice(listId1, 0, arrNewData[i]);
		//var count:Number = Math.max(m_arrCells.length, listId1 - m_nFirstVisible + arrNewData.length);
		//for(i = listId1 - m_nFirstVisible; i < count; i++)
		//	m_arrCells[i].setUpdated(false);
//		var off:Number = arrNewData.length - listId2 + listId1;
//		if(off > 0)
//		{
//			var arrCells:Array = m_arrCells.splice(listId1, off);
//			for(i = 0; i < arrCells.length; i++)
//				arrCells[i].setUpdated(false);
//			m_arrCells = m_arrCells.concat(arrCells);
//		}
//		else if(off < 0)
//			m_arrCells = m_arrCells.splice(m_arrCells.length - off - 1, -off).concat(m_arrCells);
		var count:Number = Math.min(m_arrData.length, m_arrCells.length);
		for(i = listId1 - m_nFirstVisible - 1; i < count; i++)
			m_arrCells[i].setUpdated(false);
		m_bUpdated = false;
	}
*/
	/**
	 * Updates list data from tree data. Removes/adds items
	 * according to their visibility.
	 */
	private function updateData(id:Number):Void
	{
		var clrInd:Number = -1;
		var depth, cellType:Number;
		var i:Number = 0;
		m_arrData.splice(0);
		while(i < m_arrTreeData.length)
		{
			var curItem:Object = m_arrTreeData[i];
			if(curItem.cellType != cellType || curItem.depth != depth)
			{ // increase color number and update color switchers
				depth = curItem.depth;
				cellType = curItem.cellType;
				clrInd++;
			}
			if(curItem.cellType == 1 && !curItem.visible)
			{ // hidden branch
				var curDepth:Number = curItem.depth;
				while(++i < m_arrTreeData.length)
					if(m_arrTreeData[i].depth <= curDepth) break;
					else m_arrTreeData[i].ind = -1;
				i--;
			}
			curItem.clrInd = clrInd;
			m_arrData.push(curItem);
			i++;
		}
		var start:Number = id ? m_arrTreeData[id].ind - m_nFirstVisible : 0;
		var count:Number = Math.min(m_arrData.length, m_arrCells.length);
		for(i = start; i < count; i++)
			m_arrCells[i].setUpdated(false);
		/*for(i = 0; i < m_arrCells.length; i++)
			m_arrCells[i].setUpdated(false);*/
		m_bUpdated = false;
	}

	public function showBranch(id:Number):Void
	{ // xxx don't update all array but its part
		if(m_arrTreeData[id].cellType == 1)
		{
			m_arrTreeData[id].visible = true;
			updateData(id);
		}
	}

	public function hideBranch(id:Number):Void
	{ // xxx don't update all array but its part
		if(m_arrTreeData[id].cellType == 1)
		{
			m_arrTreeData[id].visible = false;
			updateData(id);
		}
	}

	public function getSelData():Object
	{
		return (m_nSelCell > -1) ? super.getSelData() : m_arrTreeData[m_nSelLeaf];
	}

	//
	// PRIVATE METHODS
	//

	private function getTreeId(listId:Number):Number
	{
		for(var i:Number = 0; i < m_arrTreeData.length; i++)
			if(m_arrTreeData[i].ind == listId) return i;
		return -1;
	}

	/*private function updateTreeSel():Void
	{
		m_nOldSel = m_nSelCell = (m_nSelLeaf > -1) ? m_arrTreeData[m_nSelLeaf].ind : -1;
	}*/

	private function onChanged():Void
	{
		var id:Number = getTreeId(m_nSelCell);
		if(getSelData().cellType == 1)
		{
			m_arrTreeData[id].visible ? hideBranch(id) : showBranch(id);
			//updateIndex();
			//updateTreeSel();
			update();
			draw();
		}
		else m_nSelLeaf = id;
	}
}