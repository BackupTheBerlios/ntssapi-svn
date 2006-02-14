/**
 * Copyright (C) 2004 Serguei Pisarev & Maksim Galkin (goldman_alex@mail.ru)
 * You can use this source code in your freeware applications. You cannot change
 * this source code without the express written consent of Serguei Pisarev & Maksim Galkin.
 */
class pseudo.ScaleArray
{
	private var m_arrK:Array;

	//
	// PUBLIC METHODS
	//
	public function ScaleArray(nSize:Number)
	{
		m_arrK = new Array();
		if(nSize) setSize(nSize);
	}

	public function setSize(nSize:Number):Void
	{
		for(var i:Number = 0; i < m_arrK.length; i++)
			delete m_arrK[i];
		m_arrK.splice(0);
		var k:Number = 1 / nSize;
		for(var i:Number = 0; i < nSize; i++)
			m_arrK.push(new Object({k:k, visible:true}));
	}

	public function setVisible(nId:Number, bShow:Boolean):Void
	{
		m_arrK[nId].visible = bShow;
	}

	public function getK(nId:Number):Number
	{
		return m_arrK[nId].k / getSum(null, null, true);
	}

	public function canResize(nId:Number):Boolean
	{
		return getTopId(nId) >= 0 && getBottomId(nId) >= 0;
	}

	public function getArray():Array
	{
		var arr:Array = new Array();
		var sum:Number = getSum(null, null, true);
		for(var i:Number = 0; i < m_arrK.length; i++)
			arr.push(new Object({k:m_arrK[i].k / sum, visible:m_arrK[i].visible}));
		return arr;
	}

	public function normalize():Void
	{
		var sum:Number = 0;
		for(var i:Number = 0; i < m_arrK.length; i++)
			sum += m_arrK[i];
		if(sum != 1)
			for(var i:Number = 0; i < m_arrK.length; i++)
				m_arrK[i] /= sum;
	}

	public function scale(nId:Number, dk:Number, bModify:Boolean, bRatio:Boolean):Array
	{
		var arr:Array = null;
		dk *= getSum(null, null, true);
		if(bRatio)
		{ // do not work if some panes are hidden
			/*var sum1:Number = getSum(0, nId);
			var sum2:Number = getSum(nId + 1);
			for(var i:Number = 0; i <= nId; i++)
				m_arrK[i].k += dk * m_arrK[i].k / sum1;
			for(var i:Number = nId + 1; i < m_arrK.length; i++)
				m_arrK[i].k -= dk * m_arrK[i].k / sum2;*/
		}
		else
		{
			var id1:Number = getTopId(nId);
			var id2:Number = getBottomId(nId);
			if(id1 >= 0 && id2 >= 0)
			{
				var minK:Number = 0.1;
				dk = Math.max(dk, Math.min(0, minK - m_arrK[id1].k));
				dk = Math.min(dk, Math.max(0, m_arrK[id2].k - minK));
				arr = getArray();
				if(bModify)
				{
					m_arrK[id1].k += dk;
					m_arrK[id2].k -= dk;
				}
				var sum:Number = getSum(null, null, true);
				arr[id1].k += dk / sum;
				arr[id2].k -= dk / sum;
			}
		}
		return arr;
	}

	//
	// PRIVATE METHODS
	//

	private function getTopId(nId:Number):Number
	{
		for(var i:Number = nId; i >= 0; i--)
			if(m_arrK[i].visible) return i;
		return -1;
	}

	private function getBottomId(nId:Number):Number
	{
		for(var i:Number = nId + 1; i < m_arrK.length; i++)
			if(m_arrK[i].visible) return i;
		return -1;
	}

	private function getSum(nFirst:Number, nLast:Number, bOnlyVisible:Boolean):Number
	{
		if(!nFirst) nFirst = 0;
		if(isNaN(nLast)) nLast = m_arrK.length - 1;
		var sum:Number = 0;
		for(var i:Number = nFirst; i <= nLast; i++)
			if(!bOnlyVisible || m_arrK[i].visible) sum += m_arrK[i].k;
		return sum;
	}
}