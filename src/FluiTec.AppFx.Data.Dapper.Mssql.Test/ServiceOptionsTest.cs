using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Data.Dapper.Mssql.Test
{
	[TestClass]
    public class ServiceOptionsTest
    {
		[TestMethod]
	    public void CanCreate()
	    {
			var options = new MssqlDapperServiceOptions();
			Assert.IsNotNull(options);
			Assert.IsNotNull(options.ConnectionFactory);
	    }
    }
}
