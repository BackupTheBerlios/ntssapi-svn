namespace greekconverter
{
	using System;
	
	public class DynShortArray
	{
		virtual public short[] Array
		{
			// return reference to array:
			
			get
			{
				return array;
			}
			
		}
		virtual public int Pos
		{
			// return current position:
			
			get
			{
				return currPos;
			}
			
		}
		private int initSize; // initial array size
		private int chunkSize; // size of increasement
		private int currPos = - 1;
		public short[] array;
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "31-Aug-2002"; break;
				
				case 1:  info = "Dynamic short array"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Homo sum, humani nil a me alienum puto.";
					break;
				
			}
			return info;
		}
		
		public DynShortArray(int initSize, int chunkSize)
		{
			this.initSize = initSize;
			this.chunkSize = chunkSize;
			array = new short[initSize];
		}
		
		// push element to next free position:
		public virtual void  pushElem(short elem)
		{
			if (++currPos >= array.Length)
			{
				resize();
			}
			array[currPos] = elem;
		}
		
		// put element to specified array position:
		public virtual void  setElem(short elem, int pos)
		{
			array[pos] = elem;
		}
		
		// get element from specified array position:
		public virtual short getElem(int pos)
		{
			return array[pos];
		}
		
		
		// reset array to a new one:
		public virtual void  reset()
		{
			array = new short[initSize];
			currPos = - 1;
		}
		
		// return current array size:
		public virtual int length()
		{
			return array.Length;
		}
		
		
		// resize array:
		private void  resize()
		{
			short[] mem = array;
			array = new short[mem.Length + chunkSize];
			Array.Copy(mem, 0, array, 0, mem.Length);
		}
	}
}