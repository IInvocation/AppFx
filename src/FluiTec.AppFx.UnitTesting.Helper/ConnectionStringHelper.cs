using System;
using System.IO;

namespace FluiTec.AppFx.UnitTesting.Helper
{
    public class ConnectionStringHelper
    {
	    private string rootDir = "";

	    private string fileName = "ConnectionStrings.xml";

		public ConnectionStringHelper()
		{
			var current = Directory.GetCurrentDirectory();
		}

	    public string GetConnectionStringFor(string databasename)
	    {
		    return "";
	    }
    }
}
