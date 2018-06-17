using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.DataProtection.Mssql.Test
{
    /// <summary>	A helper. </summary>
    public static class Helper
    {
        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IDataProtectionDataService GetDataService()
        {
            var options = new MssqlDapperServiceOptions
            {
                ConnectionFactory = new MssqlConnectionFactory(),
                ConnectionString = ConnectionStringHelper.GetConnectionStringFor("MSSQL")
            };

            return new MssqlDapperDataProtectionDataService(options);
        }
    }
}
