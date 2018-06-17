using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mssql.Test
{
    /// <summary>	A helper. </summary>
    public static class Helper
    {
        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IIdentityServerDataService GetDataService()
        {
            var options = new MssqlDapperServiceOptions
            {
                ConnectionFactory = new MssqlConnectionFactory(),
                ConnectionString = ConnectionStringHelper.GetConnectionStringFor("MSSQL")
            };

            return new MssqlDapperIdentityServerDataService(options);
        }
    }
}