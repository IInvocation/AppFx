using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.IdentityServer.Configuration
{
    /// <summary>A certificate options.</summary>
    [ConfigurationName("CertificateOptions")]
    public class CertificateOptions
    {
        /// <summary>Gets or sets the current thumbprint.</summary>
        /// <value>The current thumbprint.</value>
        public string CurrentThumbprint { get; set; }

        /// <summary>Gets or sets the validation thumbprints.</summary>
        /// <value>The validation thumbprints.</value>
        public List<string> ValidationThumbprints { get; set; }

        /// <summary>Gets or sets the store location.</summary>
        /// <value>The store location.</value>
        public StoreLocation StoreLocation { get; set; }

        /// <summary>Gets or sets the name of the store.</summary>
        /// <value>The name of the store.</value>
        public StoreName StoreName { get; set; }
    }
}