using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.Data.Dapper.Mssql.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyMssqlDataService : DapperDataService
    {
	    /// <summary>	Default constructor. </summary>
	    public DummyMssqlDataService() : base(ConnectionStringHelper.GetConnectionStringFor("MSSQL"), new MssqlConnectionFactory())
	    {
	    }

	    /// <summary>	The name. </summary>
	    public override string Name => "DummyMssqlDataService";
    }
}
