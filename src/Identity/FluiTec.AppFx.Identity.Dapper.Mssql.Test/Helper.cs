using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.Identity.Dapper.Mssql.Test
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
                ConnectionFactory = new MssqlConnectionFactory(),
                ConnectionString = ConnectionStringHelper.GetConnectionStringFor("MSSQL")
            };

            return new MssqlDapperIdentityDataService(options);
        }
    }
}