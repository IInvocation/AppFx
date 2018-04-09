using System.Collections.Generic;
using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.AspNetCore.Configuration
{
    /// <summary>   An identity server options. </summary>
    [ConfigurationName("IdentityServer")]
    public class IdentityServerOptions
    {
        /// <summary>   Default constructor. </summary>
        public IdentityServerOptions()
        {
            DefaultClaimTypes = new List<DefaultClaimType>();
        }

        /// <summary>   Gets or sets the default claim types. </summary>
        /// <value> The default claim types. </value>
        public List<DefaultClaimType> DefaultClaimTypes { get; set; }
    }
}