using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Data.Dapper.Mysql.Test
{
	[TestClass]
    public class ServiceOptionsTest
    {
		[TestMethod]
	    public void CanCreate()
	    {
			var options = new MysqlDapperServiceOptions();
			Assert.IsNotNull(options);
			Assert.IsNotNull(options.ConnectionFactory);
	    }
    }
}
