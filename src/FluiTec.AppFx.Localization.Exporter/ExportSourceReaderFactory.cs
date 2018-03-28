using System;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Localization.LiteDb;
using FluiTec.AppFx.Localization.Mssql;
using FluiTec.AppFx.Localization.Mysql;
using FluiTec.AppFx.Localization.Pgsql;

namespace FluiTec.AppFx.Localization.Exporter
{
    /// <summary>An export source reader factory.</summary>
    public static class ExportSourceReaderFactory
    {
        /// <summary>Creates a new IExportSourceReader.</summary>
        /// <param name="sourceType">   Type of the source. </param>
        /// <param name="source">       Source for the. </param>
        /// <returns>An IExportSourceReader.</returns>
        public static IExportSourceReader Create(ExportSourceType sourceType, string source)
        {
            switch (sourceType)
            {
                case ExportSourceType.LiteDb:
                    return UseLiteDb(source);
                case ExportSourceType.Mssql:
                    return UseMssql(source);
                case ExportSourceType.Pgsql:
                    return UsePgsql(source);
                case ExportSourceType.Mysql:
                    return UseMysql(source);
                case ExportSourceType.Assembly:
                    return new AssemblyExportSourceReader(source);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>Use lite database.</summary>
        /// <param name="databaseFile"> The database file. </param>
        /// <returns>An IExportSourceReader.</returns>
        private static IExportSourceReader UseLiteDb(string databaseFile)
        {
            var dataService = new LiteDbLocalizationDataService(true, databaseFile);
            return new RepositoryExportSourceReader(dataService);
        }

        /// <summary>Use mssql.</summary>
        /// <param name="connectionString"> The connection string. </param>
        /// <returns>An IExportSourceReader.</returns>
        private static IExportSourceReader UseMssql(string connectionString)
        {
            var dataService =
                new MssqlDapperLocalizationDataService(new MssqlDapperServiceOptions
                {
                    ConnectionString = connectionString
                });
            return new RepositoryExportSourceReader(dataService);
        }

        /// <summary>Use pgsql.</summary>
        /// <param name="connectionString"> The connection string. </param>
        /// <returns>An IExportSourceReader.</returns>
        private static IExportSourceReader UsePgsql(string connectionString)
        {
            var dataService =
                new PgsqlDapperLocalizationDataService(new PgsqlDapperServiceOptions
                {
                    ConnectionString = connectionString
                });
            return new RepositoryExportSourceReader(dataService);
        }

        /// <summary>Use mysql.</summary>
        /// <param name="connectionString"> The connection string. </param>
        /// <returns>An IExportSourceReader.</returns>
        private static IExportSourceReader UseMysql(string connectionString)
        {
            var dataService =
                new MysqlDapperLocalizationDataService(new MysqlDapperServiceOptions
                {
                    ConnectionString = connectionString
                });
            return new RepositoryExportSourceReader(dataService);
        }
    }
}