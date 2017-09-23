using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.Data.Dapper.Pgsql.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyPgsqlDataService : PgsqlDapperDataService
    {
	    /// <summary>	Default constructor. </summary>
	    public DummyPgsqlDataService() : base(ConnectionStringHelper.GetConnectionStringFor("PGSQL"))
	    {
	    }

	    /// <summary>	The name. </summary>
	    public override string Name => "DummyPgsqlDataService";
    }
}
