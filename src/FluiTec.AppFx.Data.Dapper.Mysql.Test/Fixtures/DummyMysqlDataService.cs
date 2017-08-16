using Dapper.Contrib.Extensions;

namespace FluiTec.AppFx.Data.Dapper.Mysql.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyMysqlDataService : DapperDataService
    {
		/// <summary>	Default constructor. </summary>
		/// <remarks>
		/// ConnectionReset=true is required because of a MySql-bug, see https://bugs.mysql.com/bug.php?id=71502
		/// </remarks>
		public DummyMysqlDataService() : base("server=intranet2.wtschnell.local;user=dummy;database=CallRouting;port=3306;password=dummy;SslMode=none;ConnectionReset=true", new MysqlConnectionFactory())
	    {
		    SqlMapperExtensions.GetDatabaseType = connection => "mysqlconnection";
	    }

	    /// <summary>	The name. </summary>
	    public override string Name => "DummyMysqlDataService";
    }
}
