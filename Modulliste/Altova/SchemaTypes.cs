using System;

namespace Altova.Types
{
	public abstract class SchemaType
	{
		//public abstract string asString();
	}

	public class SchemaString : SchemaType
	{
		public string Value;

		public SchemaString(string Value)
		{
			this.Value = Value;
		}

		override public string ToString()
		{
			return Value;
		}
	}

	public class SchemaBoolean : SchemaType
	{
		public bool Value;

		public SchemaBoolean(bool Value)
		{
			this.Value = Value;
		}

		public SchemaBoolean(string Value)
		{
			this.Value = Value == "true" || Value == "1";
		}

		override public string ToString()
		{
			return Value ? "true" : "false";
		}
	}

	public class SchemaInteger : SchemaType
	{
		public int Value;

		public SchemaInteger(int Value)
		{
			this.Value = Value;
		}

		public SchemaInteger(string Value)
		{
			this.Value = Convert.ToInt32(Value);
		}

		override public string ToString()
		{
			return Convert.ToString(Value);
		}
	}

	public class SchemaDouble : SchemaType
	{
		public double Value;

		public SchemaDouble(double Value)
		{
			this.Value = Value;
		}

		public SchemaDouble(string Value)
		{
			this.Value = Convert.ToDouble(Value);
		}

		override public string ToString()
		{
			return Convert.ToString(Value);
		}
	}
}
