namespace FluiTec.AppFx.Data.Dapper.Pgsql.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyPgsqlDataService : PgsqlDapperDataService
    {
	    /// <summary>	Default constructor. </summary>
	    public DummyPgsqlDataService() : base("User ID=srv-callrouting;Password=test123;Host=localhost;Port=5432;Database=callrouting;Pooling=true;", new PgsqlConnectionFactory())
	    {
	    }

	    /// <summary>	The name. </summary>
	    public override string Name => "DummyPgsqlDataService";
    }
}
