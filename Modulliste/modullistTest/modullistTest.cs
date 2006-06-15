using System;
using Altova.Types;

namespace modullist
{
	/// <summary>
	/// Summary description for modullistTest.
	/// </summary>
	class modullistTest
	{
		protected static void Example()
		{
			//
			// TODO:
			//   Insert your code here...
			//
			// Example code to create and save a structure:
			//   modullistDoc doc = new modullistDoc();
			//   zefania_modules_list_serversType root = new zefania_modules_list_serversType();
			//   ...
			//   doc.SetRootElementName("", "zefania-modules-list-servers");
			//   doc.SetSchemaLocation("modullist.xsd"); // optional
			//   doc.Save("modullist1.xml", root);
			//
			// Example code to load and save a structure:
			//   modullistDoc doc = new modullistDoc();
			//   zefania_modules_list_serversType root = new zefania_modules_list_serversType(doc.Load("modullist1.xml"));
			//   ...
			//   doc.Save("modullist1.xml", root);
			//
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static int Main(string[] args)
		{
			try
			{
				Console.WriteLine("modullist Test Application");
				Example();
				Console.WriteLine("OK");
				return 0;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return 1;
			}
		}
	}
}
