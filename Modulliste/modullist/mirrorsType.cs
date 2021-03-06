//
// mirrorsType.cs.cs
//
// This file was generated by XMLSPY 5 Enterprise Edition.
//
// YOU SHOULD NOT MODIFY THIS FILE, BECAUSE IT WILL BE
// OVERWRITTEN WHEN YOU RE-RUN CODE GENERATION.
//
// Refer to the XMLSPY Documentation for further details.
// http://www.altova.com/xmlspy
//


using System;
using System.Xml;
using Altova.Types;

namespace modullist
{
	public class mirrorsType : Altova.Node
	{
		#region Forward constructors
		public mirrorsType() : base() {}
		public mirrorsType(XmlDocument doc) : base(doc) {}
		public mirrorsType(XmlNode node) : base(node) {}
		public mirrorsType(Altova.Node node) : base(node) {}
		#endregion // Forward constructors

		#region urlinfix accessor methods
		public int GeturlinfixMinCount()
		{
			return 1;
		}

		public int GeturlinfixMaxCount()
		{
			return 1;
		}

		public int GeturlinfixCount()
		{
			return DomChildCount(NodeType.Attribute, "", "urlinfix");
		}

		public bool Hasurlinfix()
		{
			return HasDomChild(NodeType.Attribute, "", "urlinfix");
		}

		public SchemaString GeturlinfixAt(int index)
		{
			return new SchemaString(GetDomNodeValue(GetDomChildAt(NodeType.Attribute, "", "urlinfix", index)));
		}

		public SchemaString Geturlinfix()
		{
			return GeturlinfixAt(0);
		}

		public void RemoveurlinfixAt(int index)
		{
			RemoveDomChildAt(NodeType.Attribute, "", "urlinfix", index);
		}

		public void Removeurlinfix()
		{
			while (Hasurlinfix())
				RemoveurlinfixAt(0);
		}

		public void Addurlinfix(SchemaString newValue)
		{
			AppendDomChild(NodeType.Attribute, "", "urlinfix", newValue.ToString());
		}

		public void InserturlinfixAt(SchemaString newValue, int index)
		{
			InsertDomChildAt(NodeType.Attribute, "", "urlinfix", index, newValue.ToString());
		}

		public void ReplaceurlinfixAt(SchemaString newValue, int index)
		{
			ReplaceDomChildAt(NodeType.Attribute, "", "urlinfix", index, newValue.ToString());
		}
		#endregion // urlinfix accessor methods

		#region mirror accessor methods
		public int GetmirrorMinCount()
		{
			return 1;
		}

		public int GetmirrorMaxCount()
		{
			return Int32.MaxValue;
		}

		public int GetmirrorCount()
		{
			return DomChildCount(NodeType.Element, "", "mirror");
		}

		public bool Hasmirror()
		{
			return HasDomChild(NodeType.Element, "", "mirror");
		}

		public mirrorType GetmirrorAt(int index)
		{
			return new mirrorType(GetDomChildAt(NodeType.Element, "", "mirror", index));
		}

		public mirrorType Getmirror()
		{
			return GetmirrorAt(0);
		}

		public void RemovemirrorAt(int index)
		{
			RemoveDomChildAt(NodeType.Element, "", "mirror", index);
		}

		public void Removemirror()
		{
			while (Hasmirror())
				RemovemirrorAt(0);
		}

		public void Addmirror(mirrorType newValue)
		{
			AppendDomElement("", "mirror", newValue);
		}

		public void InsertmirrorAt(mirrorType newValue, int index)
		{
			InsertDomElementAt("", "mirror", index, newValue);
		}

		public void ReplacemirrorAt(mirrorType newValue, int index)
		{
			ReplaceDomElementAt("", "mirror", index, newValue);
		}
		#endregion // mirror accessor methods
	}
}
