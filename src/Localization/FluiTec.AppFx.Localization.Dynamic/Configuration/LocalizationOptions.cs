using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.Localization.Dynamic.Configuration
{
    /// <summary>	An identityserver options. </summary>
    [ConfigurationName("DbLocalizationOptions")]
    public class LocalizationOptions
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