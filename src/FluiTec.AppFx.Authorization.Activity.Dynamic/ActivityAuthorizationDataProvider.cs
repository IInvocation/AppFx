using System;
using FluiTec.AppFx.Authorization.Activity.Dapper.Mssql;
using FluiTec.AppFx.Authorization.Activity.Dapper.Mysql;
using FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql;
using FluiTec.AppFx.Authorization.Activity.Dynamic.Configuration;
using FluiTec.AppFx.Authorization.Activity.LiteDb;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;

namespace FluiTec.AppFx.Authorization.Activity.Dynamic
{
    public class ActivityAuthorizationDataProvider
    {
        /// <summary>	Options for controlling the operation. </summary>
	    private readonly ActivityAuthorizationOptions _options;

        /// <summary>	Constructor. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        public ActivityAuthorizationDataProvider(ActivityAuthorizationOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>	Gets data service. </summary>
        /// <param name="configuration">	The configuration. </param>
        /// <returns>	The data service. </returns>
        public IAuthorizationDataService GetDataService(IConfigurationRoot configuration)
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

            internal static IAuthorizationDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<MssqlDapperServiceOptions>();
                return new MssqlDapperAuthorizationDataService(_options);
            }
        }

        private static class PgsqlHelper
        {
            private static IDapperServiceOptions _options;

            internal static IAuthorizationDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<PgsqlDapperServiceOptions>();
                return new PgsqlDapperAuthorizationDataService(_options);
            }
        }

        private static class MysqlHelper
        {
            private static IDapperServiceOptions _options;

            internal static IAuthorizationDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<MysqlDapperServiceOptions>();
                return new MysqlDapperAuthorizationDataService(_options);
            }
        }

        private static class LiteDbHelper
        {
            private static ILiteDbServiceOptions _options;

            internal static IAuthorizationDataService ProvideService(IConfigurationRoot configuration)
            {
                if (_options == null)
                    _options = configuration.GetConfiguration<LiteDbServiceOptions>();
                return new LiteDbAuthorizationDataService(_options);
            }
        }
    }
}