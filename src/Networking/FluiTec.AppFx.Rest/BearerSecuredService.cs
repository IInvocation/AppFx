using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.IdentityModel.Tokens;

namespace FluiTec.AppFx.Rest
{
    /// <summary>   A bearer secured service. </summary>
    /// <typeparam name="TOptions"> Type of the options. </typeparam>
    public class BearerSecuredService<TOptions> where TOptions : BearerSecuredServiceOptions
    {
        #region Constructors

        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or
        ///     illegal values.
        /// </exception>
        /// <param name="options">  Options for controlling the operation. </param>
        protected BearerSecuredService(TOptions options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            if (!ValidateOptions(options))
                throw new ArgumentException("Invalid options.");
            Options = options;
        }

        #endregion

        #region Fields

        private const int TokenValiditySafetySeconds = 10;
        private readonly TimeSpan _tokenValiditySafety = new TimeSpan(0, 0, 0, TokenValiditySafetySeconds);
        private DiscoveryResponse _discoveryClient;

        #endregion

        #region Properties

        /// <summary>   Gets options for controlling the operation. </summary>
        /// <value> The options. </value>
        protected TOptions Options { get; }

        /// <summary>   Gets the access token. </summary>
        /// <value> The access token. </value>
        protected KeyValuePair<SecurityToken, string> AccessToken { get; private set; }

        #endregion

        #region AccessToken

        /// <summary>   Gets access token. </summary>
        /// <returns>   An asynchronous result that yields the access token. </returns>
        protected async Task<string> GetAccessToken()
        {
            if (AccessToken.Key != null &&
                AccessToken.Key.ValidTo.Subtract(_tokenValiditySafety) > DateTime.Now.ToUniversalTime())
                return AccessToken.Value;
            return await FetchAccessToken();
        }

        /// <summary>   Fetches access token. </summary>
        /// <returns>   An asynchronous result that yields the access token. </returns>
        private async Task<string> FetchAccessToken()
        {
            var tokenClient = new TokenClient(_discoveryClient.TokenEndpoint, Options.ClientId, Options.ClientSecret);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync(Options.Scope);

            if (tokenResponse.IsError)
                throw new TokenResponseException(tokenResponse);

            var handler = new JwtSecurityTokenHandler();
            AccessToken = new KeyValuePair<SecurityToken, string>(handler.ReadToken(tokenResponse.AccessToken),
                tokenResponse.AccessToken);
            return tokenResponse.AccessToken;
        }

        /// <summary>   Prepare access token. </summary>
        public async void PrepareAccessToken()
        {
            await GetAccessToken();
        }

        /// <summary>   Refetch access token. </summary>
        public async void RefetchAccessToken()
        {
            await FetchAccessToken();
        }

        #endregion

        #region Validation

        /// <summary>   Validates the options described by options. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        protected virtual bool ValidateOptions(TOptions options)
        {
            if (options == null)
                return false;
            if (string.IsNullOrWhiteSpace(options.Scope))
                return false;
            if (string.IsNullOrWhiteSpace(options.BearerServiceUrl))
                return false;
            if (string.IsNullOrWhiteSpace(options.ClientId))
                return false;
            if (string.IsNullOrWhiteSpace(options.ClientSecret))
                return false;
            if (!ValidateDiscovery(options))
                return false;

            return true;
        }

        /// <summary>   Validates the discovery described by options. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// <returns>   An asynchronous result that yields true if it succeeds, false if it fails. </returns>
        private bool ValidateDiscovery(TOptions options)
        {
            try
            {
                var disco = DiscoveryClient.GetAsync(options.BearerServiceUrl).Result;
                if (disco == null || disco.IsError) return false;
                _discoveryClient = disco;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}