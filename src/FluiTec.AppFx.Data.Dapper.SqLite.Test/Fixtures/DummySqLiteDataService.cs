using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.Data.Dapper.SqLite.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummySqLiteDataService : SqLiteDapperDataService
    {
		/// <summary>	Default constructor. </summary>
		public DummySqLiteDataService() : base(ConnectionStringHelper.GetConnectionStringFor("SqLite"), new SqLiteConnectionFactory())
	    {
	    }

	    /// <summary>	The name. </summary>
	    public override string Name => "DummySqLiteDataService";
    }
}
