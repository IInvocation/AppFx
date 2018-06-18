using System;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Data.Dynamic.Configuration;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;

namespace FluiTec.AppFx.Data.Dynamic
{
    /// <summary>   A dynamic data provider. </summary>
    /// <typeparam name="TDataService"> Type of the data service. </typeparam>
    public abstract class DynamicDataProvider<TDataService>
    {
        /// <summary>   Options for controlling the operation. </summary>
        protected readonly DynamicDataOptions Options;

        /// <summary>   Constructor. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="options">  Options for controlling the operation. </param>
        protected DynamicDataProvider(DynamicDataOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>   Gets data service. </summary>
        /// <param name="configuration">    The configuration. </param>
        /// <returns>   The data service. </returns>
        public virtual TDataService GetDataService(IConfigurationRoot configuration)
        {
            switch (Options.Provider)
            {
                case DataProvider.MSSQL:
                    return MssqlHelper.ProvideService(configuration, this);
                case DataProvider.PGSQL:
                    return PgsqlHelper.ProvideService(configuration, this);
                case DataProvider.MYSQL:
                    return MysqlHelper.ProvideService(configuration, this);
                case DataProvider.LITEDB:
                    return LiteDbHelper.ProvideService(configuration, this);
                default:
                    throw new NotImplementedException($"Provider {Options.Provider} was not implemented!");
            }
        }

        /// <summary>   Provide using mssql. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// <returns>   A TDataService. </returns>
        protected internal abstract TDataService ProvideUsingMssql(MssqlDapperServiceOptions options);

        /// <summary>   Provide using pgsql. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// <returns>   A TDataService. </returns>
        protected internal abstract TDataService ProvideUsingPgsql(PgsqlDapperServiceOptions options);

        /// <summary>   Provide using mysql. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// <returns>   A TDataService. </returns>
        protected internal abstract TDataService ProvideUsingMysql(MysqlDapperServiceOptions options);

        /// <summary>   Provide using lite database. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// <returns>   A TDataService. </returns>
        protected internal abstract TDataService ProvideUsingLiteDb(ILiteDbServiceOptions options);
    }

    /// <summary>   A mssql helper. </summary>
    internal static class MssqlHelper
    {
        /// <summary>   Options for controlling the operation. </summary>
        private static MssqlDapperServiceOptions _options;

        /// <summary>   Provide service. </summary>
        /// <param name="configuration">    The configuration. </param>
        /// <param name="provider">         The provider. </param>
        /// <returns>   A TDataService. </returns>
        internal static TDataService ProvideService<TDataService>(IConfigurationRoot configuration, DynamicDataProvider<TDataService> provider)
        {
            if (_options == null)
                _options = configuration.GetConfiguration<MssqlDapperServiceOptions>();
            return provider.ProvideUsingMssql(_options);
        }
    }

    /// <summary>   A pgsql helper. </summary>
    internal static class PgsqlHelper
    {
        /// <summary>   Options for controlling the operation. </summary>
        private static PgsqlDapperServiceOptions _options;

        /// <summary>   Provide service. </summary>
        /// <param name="configuration">    The configuration. </param>
        /// <param name="provider">         The provider. </param>
        /// <returns>   A TDataService. </returns>
        internal static TDataService ProvideService<TDataService>(IConfigurationRoot configuration, DynamicDataProvider<TDataService> provider)
        {
            if (_options == null)
                _options = configuration.GetConfiguration<PgsqlDapperServiceOptions>();
            return provider.ProvideUsingPgsql(_options);
        }
    }

    /// <summary>   A mysql helper. </summary>
    internal static class MysqlHelper
    {
        /// <summary>   Options for controlling the operation. </summary>
        private static MysqlDapperServiceOptions _options;

        /// <summary>   Provide service. </summary>
        /// <param name="configuration">    The configuration. </param>
        /// <param name="provider">         The provider. </param>
        /// <returns>   A TDataService. </returns>
        internal static TDataService ProvideService<TDataService>(IConfigurationRoot configuration, DynamicDataProvider<TDataService> provider)
        {
            if (_options == null)
                _options = configuration.GetConfiguration<MysqlDapperServiceOptions>();
            return provider.ProvideUsingMysql(_options);
        }
    }

    /// <summary>   A lite database helper. </summary>
    internal static class LiteDbHelper
    {
        /// <summary>   Options for controlling the operation. </summary>
        private static ILiteDbServiceOptions _options;

        /// <summary>   Provide service. </summary>
        /// <typeparam name="TDataService"> Type of the data service. </typeparam>
        /// <param name="configuration">    The configuration. </param>
        /// <param name="provider">         The provider. </param>
        /// <returns>   A TDataService. </returns>
        internal static TDataService ProvideService<TDataService>(IConfigurationRoot configuration, DynamicDataProvider<TDataService> provider)
        {
            if (_options == null)
                _options = configuration.GetConfiguration<LiteDbServiceOptions>();
            return provider.ProvideUsingLiteDb(_options);
        }
    }
}
