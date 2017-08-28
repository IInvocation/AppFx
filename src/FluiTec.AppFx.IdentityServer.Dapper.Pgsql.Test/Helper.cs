using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Pgsql;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Test
{
	/// <summary>	A helper. </summary>
	public static class Helper
	{
		/// <summary>	Gets data service. </summary>
		/// <returns>	The data service. </returns>
		public static IIdentityServerDataService GetDataService()
		{
			var options = new DapperServiceOptions
			{
				ConnectionFactory = new PgsqlConnectionFactory(),
				ConnectionString =
					"User ID=appfx;Password=appfx;Host=localhost;Port=5432;Database=AppFx;Pooling=true;"
			};

			return new MssqlDapperIdentityServerDataService(options);
		}
	}
}