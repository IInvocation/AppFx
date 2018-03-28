using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace FluiTec.AppFx.Authentication.Amazon
{
    /// <summary>	An amazon options. </summary>
    public class AmazonOptions : OAuthOptions
    {
        /// <summary>	Default constructor. </summary>
        public AmazonOptions()
        {
            CallbackPath = new PathString("/signin-amazon");
            AuthorizationEndpoint = AmazonDefaults.AuthorizationEndpoint;
            TokenEndpoint = AmazonDefaults.TokenEndpoint;
            UserInformationEndpoint = AmazonDefaults.UserInformationEndpoint;
            Scope.Add("profile");
        }

        /// <summary>
        ///     access_type. Set to 'offline' to request a refresh token.
        /// </summary>
        public string AccessType { get; set; }
    }
}