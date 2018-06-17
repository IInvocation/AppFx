using System;
using IdentityModel.Client;

namespace FluiTec.AppFx.Rest
{
    /// <summary>   Exception for signalling token response errors. </summary>
    public class TokenResponseException : Exception
    {
        /// <summary>   Gets the response. </summary>
        /// <value> The response. </value>
        public TokenResponse Response { get; }

        /// <summary>   Constructor. </summary>
        /// <param name="response"> The response. </param>
        public TokenResponseException(TokenResponse response)
        {
            Response = response;
        }
    }
}
