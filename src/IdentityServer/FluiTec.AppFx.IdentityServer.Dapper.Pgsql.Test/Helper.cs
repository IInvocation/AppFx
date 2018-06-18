using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Test
{
    /// <summary>	A helper. </summary>
    public static class Helper
    {
        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IIdentityServerDataService GetDataService()
        {
            var options = new PgsqlDapperServiceOptions
            {
                ConnectionFactory = new PgsqlConnectionFactory(),
                ConnectionString = ConnectionStringHelper.GetConnectionStringFor("PGSQL")
            };

            return new PgsqlDapperIdentityServerDataService(options);
        }
    }
}