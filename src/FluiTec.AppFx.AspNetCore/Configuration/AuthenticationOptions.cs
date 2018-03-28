using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.AspNetCore.Configuration
{
    /// <summary>An authentication options.</summary>
    [ConfigurationName("Authentication")]
    public class AuthenticationOptions
    {
        public AuthenticationOptions()
        {
            LoginPath = "/Account/Login";
        }

        /// <summary>   Gets or sets the full pathname of the login file. </summary>
        /// <value> The full pathname of the login file. </value>
        public string LoginPath { get; set; }

        /// <summary>   Gets or sets the google. </summary>
        /// <value> The google. </value>
        public OpenIdProvider Google { get; set; }

        /// <summary>   Gets or sets the amazon. </summary>
        /// <value> The amazon. </value>
        public OpenIdProvider Amazon { get; set; }
    }
}