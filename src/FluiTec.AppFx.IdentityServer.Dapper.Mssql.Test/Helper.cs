using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mssql;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mssql.Test
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
				ConnectionFactory = new MssqlConnectionFactory(),
				ConnectionString =
					"Data Source=.\\SQLEXPRESS;Initial Catalog=AppFx;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
			};

			return new MssqlDapperIdentityServerDataService(options);
		}
	}
}