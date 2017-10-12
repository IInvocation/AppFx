using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.Identity.Dynamic.Configuration
{
	/// <summary>	An identity options. </summary>
	[ConfigurationName(name: "IdentityOptions")]
	public class IdentityOptions
    {
	    /// <summary>	Gets or sets the provider. </summary>
	    /// <value>	The provider. </value>
	    /// <remarks>
	    /// Possible values:
	    /// - MSSQL  
	    /// - PGSQL  
	    /// - MYSQL  
	    /// - LITEDB  
	    /// <see cref="DataProvider" />
	    /// </remarks>
	    public DataProvider Provider { get; set; }
    }
}
