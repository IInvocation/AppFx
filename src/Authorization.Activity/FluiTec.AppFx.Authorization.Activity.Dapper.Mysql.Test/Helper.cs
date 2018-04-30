using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.Identity;
using FluiTec.AppFx.Identity.Dapper.Mysql;
using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Mysql.Test
{
    /// <summary>	A helper. </summary>
    public static class Helper
    {
        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IAuthorizationDataService GetDataService()
        {
            var options = new DapperServiceOptions
            {
                ConnectionFactory = new MysqlConnectionFactory(),
                ConnectionString = ConnectionStringHelper.GetConnectionStringFor("MYSQL")
            };

            return new MysqlDapperAuthorizationDataService(options);
        }

        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IIdentityDataService GetIdentityDataService()
        {
            var options = new DapperServiceOptions
            {
                ConnectionFactory = new MysqlConnectionFactory(),
                ConnectionString = ConnectionStringHelper.GetConnectionStringFor("MYSQL")
            };

            return new MysqlDapperIdentityDataService(options);
        }
    }
}