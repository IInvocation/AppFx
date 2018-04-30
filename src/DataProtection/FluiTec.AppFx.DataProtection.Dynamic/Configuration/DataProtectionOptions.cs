using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.DataProtection.Dynamic.Configuration
{
    /// <summary>   A data protection option. </summary>
    [ConfigurationName("DataProtectionOptions")]
    public class DataProtectionOptions
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
