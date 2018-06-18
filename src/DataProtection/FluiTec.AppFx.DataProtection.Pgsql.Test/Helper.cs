using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.DataProtection.Pgsql.Test
{
    /// <summary>	A helper. </summary>
    public static class Helper
    {
        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IDataProtectionDataService GetDataService()
        {
            var options = new PgsqlDapperServiceOptions
            {
                ConnectionFactory = new PgsqlConnectionFactory(),
                ConnectionString = ConnectionStringHelper.GetConnectionStringFor("PGSQL")
            };

            return new PgsqlDapperDataProtectionDataService(options);
        }
    }
}
