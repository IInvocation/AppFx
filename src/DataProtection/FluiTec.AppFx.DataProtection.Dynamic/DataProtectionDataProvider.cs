using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.DataProtection.Dynamic.Configuration;
using FluiTec.AppFx.DataProtection.LiteDb;
using FluiTec.AppFx.DataProtection.Mssql;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;
using System;
using FluiTec.AppFx.DataProtection.Mysql;
using FluiTec.AppFx.DataProtection.Pgsql;

namespace FluiTec.AppFx.DataProtection.Dynamic
{
    public class DataProtectionDataProvider
    {
        /// <summary>	Options for controlling the operation. </summary>
        private readonly DataProtectionOptions _options;

        /// <summary>   Constructor. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="options">  Options for controlling the operation. </param>
        public DataProtectionDataProvider(DataProtectionOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>	Gets data service. </summary>
        /// <param name="configuration">	The configuration. </param>
        /// <returns>	The data service. </returns>
        public IDataProtectionDataService GetDataService(IConfigurationRoot configuration)
        {
            switch (_options.Provider)
            {
                case DataProvider.MSSQL:
                    return MssqlHelper.ProvideService(configuration);
                case DataProvider.PGSQL:
                    return PgsqlHelper.ProvideService(configuration);
                case DataProvider.MYSQL:
                    return MysqlHelper.ProvideService(configuration);
                case DataProvider.LITEDB:
                    return LiteDbHelper.ProvideService(configuration);
                default:
                    throw new NotImplementedException($"Provider {_options.Provider} was not implemented!");
            }
        }

        private static class MssqlHelper
        {
            private static IDapperServiceOptions _options;

            internal static IDataProtectionDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<MssqlDapperServiceOptions>();
                return new MssqlDapperDataProtectionDataService(_options);
            }
        }

        private static class PgsqlHelper
        {
            private static IDapperServiceOptions _options;

            internal static IDataProtectionDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<PgsqlDapperServiceOptions>();
                return new PgsqlDapperDataProtectionDataService(_options);
            }
        }

        private static class MysqlHelper
        {
            private static IDapperServiceOptions _options;

            internal static IDataProtectionDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<MysqlDapperServiceOptions>();
                return new MysqlDapperDataProtectionDataService(_options);
            }
        }

        private static class LiteDbHelper
        {
            private static ILiteDbServiceOptions _options;

            internal static IDataProtectionDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<LiteDbServiceOptions>();
                return new LiteDbDataProtectionDataService(_options);
            }
        }
    }
}
