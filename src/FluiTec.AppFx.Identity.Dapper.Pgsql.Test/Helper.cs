using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.Identity.Dapper.Pgsql.Test
{
	/// <summary>	A helper. </summary>
	public static class Helper
	{
		/// <summary>	Gets data service. </summary>
		/// <returns>	The data service. </returns>
		public static IIdentityDataService GetDataService()
		{
			var options = new DapperServiceOptions
			{
				ConnectionFactory = new PgsqlConnectionFactory(),
				ConnectionString = ConnectionStringHelper.GetConnectionStringFor("PGSQL")
            };

			return new PgsqlDapperIdentityDataService(options);
		}
	}
}