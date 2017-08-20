namespace FluiTec.AppFx.Data.Dapper.Pgsql.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyPgsqlDataService : PgsqlDapperDataService
    {
	    /// <summary>	Default constructor. </summary>
	    public DummyPgsqlDataService() : base("User ID=appfx;Password=appfx;Host=localhost;Port=5432;Database=AppFx;Pooling=true;")
	    {
	    }

	    /// <summary>	The name. </summary>
	    public override string Name => "DummyPgsqlDataService";
    }
}
