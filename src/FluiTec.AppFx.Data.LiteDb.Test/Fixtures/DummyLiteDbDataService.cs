namespace FluiTec.AppFx.Data.LiteDb.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyLiteDbDataService : LiteDbDataService
    {
	    /// <summary>	Default constructor. </summary>
	    public DummyLiteDbDataService() : base(true, "dummy.ldb", "FluiTec/AppFx")
	    {
	    }

	    /// <summary>	The name. </summary>
	    public override string Name => "DummyLiteDbDataService";
    }
}
