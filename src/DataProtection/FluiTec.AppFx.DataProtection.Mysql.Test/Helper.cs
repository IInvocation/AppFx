﻿using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mysql;
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
            var options = new DapperServiceOptions
            {
                ConnectionFactory = new MysqlConnectionFactory(),
                ConnectionString = ConnectionStringHelper.GetConnectionStringFor("MYSQL")
            };

            return new MysqlDapperDataProtectionDataService(options);
        }
    }
}