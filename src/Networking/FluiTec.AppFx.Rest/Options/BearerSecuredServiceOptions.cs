namespace FluiTec.AppFx.Rest
{
    /// <summary>   A bearer secured service options. </summary>
    public class BearerSecuredServiceOptions : RestServiceOptions
    {
        /// <summary>   Gets or sets URL of the service. </summary>
        /// <value> The service URL. </value>
        public string BearerServiceUrl { get; set; }

        /// <summary>   Gets or sets the identifier of the client. </summary>
        /// <value> The identifier of the client. </value>
        public string ClientId { get; set; }

        /// <summary>   Gets or sets the client secret. </summary>
        /// <value> The client secret. </value>
        public string ClientSecret { get; set; }

        /// <summary>   Gets or sets the scope. </summary>
        /// <value> The scope. </value>
        public string Scope { get; set; }
    }
}