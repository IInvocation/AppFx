using System;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Dapper.Mssql;
using FluiTec.AppFx.IdentityServer.Dapper.Mysql;
using FluiTec.AppFx.IdentityServer.Dapper.Pgsql;
using FluiTec.AppFx.IdentityServer.Dynamic.Configuration;
using FluiTec.AppFx.IdentityServer.LiteDb;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;

namespace FluiTec.AppFx.IdentityServer.Dynamic
{
    /// <summary>	An identity data provider. </summary>
    public class IdentityServerDataProvider
    {
        /// <summary>	Options for controlling the operation. </summary>
        private readonly IdentityServerOptions _options;

        /// <summary>	Constructor. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        public IdentityServerDataProvider(IdentityServerOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>	Gets data service. </summary>
        /// <param name="configuration">	The configuration. </param>
        /// <returns>	The data service. </returns>
        public IIdentityServerDataService GetDataService(IConfigurationRoot configuration)
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

            internal static IIdentityServerDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<MssqlDapperServiceOptions>();
                return new MssqlDapperIdentityServerDataService(_options);
            }
        }

        private static class PgsqlHelper
        {
            private static IDapperServiceOptions _options;

            internal static IIdentityServerDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<PgsqlDapperServiceOptions>();
                return new PgsqlDapperIdentityServerDataService(_options);
            }
        }

        private static class MysqlHelper
        {
            private static IDapperServiceOptions _options;

            internal static IIdentityServerDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<MysqlDapperServiceOptions>();
                return new MysqlDapperIdentityServerDataService(_options);
            }
        }

        private static class LiteDbHelper
        {
            private static ILiteDbServiceOptions _options;

            internal static IIdentityServerDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<LiteDbServiceOptions>();
                return new LiteDbIdentityServerDataService(_options);
            }
        }
    }
}