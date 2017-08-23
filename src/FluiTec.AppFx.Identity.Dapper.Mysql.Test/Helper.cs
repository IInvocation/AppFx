using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mysql;

namespace FluiTec.AppFx.Identity.Dapper.Mysql.Test
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
				ConnectionFactory = new MysqlConnectionFactory(),
				ConnectionString =
					"server=intranet2.wtschnell.local;user=appfx;database=AppFx;port=3306;password=appfx;SslMode=none;ConnectionReset=true"
			};

			return new MysqlDapperIdentityDataService(options);
		}
	}
}