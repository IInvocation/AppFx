using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mysql.Test
{
    /// <summary>	A helper. </summary>
    public static class Helper
    {
        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IIdentityServerDataService GetDataService()
        {
            var options = new MysqlDapperServiceOptions
            {
                ConnectionFactory = new MysqlConnectionFactory(),
                ConnectionString = ConnectionStringHelper.GetConnectionStringFor("MYSQL")
            };

            return new MysqlDapperIdentityServerDataService(options);
        }
    }
}