using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.IdentityServer.Dynamic.Configuration
{
    /// <summary>	An identityserver options. </summary>
    [ConfigurationName("IdentityServerOptions")]
    public class IdentityServerOptions
    {
        /// <summary>	Gets or sets the provider. </summary>
        /// <value>	The provider. </value>
        /// <remarks>
        ///     Possible values:
        ///     - MSSQL
        ///     - PGSQL
        ///     - MYSQL
        ///     - LITEDB
        ///     <see cref="DataProvider" />
        /// </remarks>
        public DataProvider Provider { get; set; }
    }
}