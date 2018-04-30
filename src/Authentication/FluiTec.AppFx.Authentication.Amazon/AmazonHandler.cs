using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FluiTec.AppFx.Authentication.Amazon
{
    /// <summary>	An amazon handler. </summary>
    internal class AmazonHandler : OAuthHandler<AmazonOptions>
    {
        /// <summary>	Constructor. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        /// <param name="logger"> 	The logger. </param>
        /// <param name="encoder">	The encoder. </param>
        /// <param name="clock">  	The clock. </param>
        public AmazonHandler(IOptionsMonitor<AmazonOptions> options, ILoggerFactory logger, UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        /// <summary>	Builds challenge URL. </summary>
        /// <param name="properties"> 	The properties. </param>
        /// <param name="redirectUri">	URI of the redirect. </param>
        /// <returns>	A string. </returns>
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            var queryStrings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"response_type", "code"},
                {"client_id", Options.ClientId},
                {"redirect_uri", redirectUri}
            };

            AddQueryString(queryStrings, properties, "scope", FormatScope());
            AddQueryString(queryStrings, properties, "access_type", Options.AccessType);
            AddQueryString(queryStrings, properties, "approval_prompt");
            AddQueryString(queryStrings, properties, "prompt");
            AddQueryString(queryStrings, properties, "login_hint");
            AddQueryString(queryStrings, properties, "include_granted_scopes");

            var state = Options.StateDataFormat.Protect(properties);
            queryStrings.Add("state", state);

            var authorizationEndpoint = QueryHelpers.AddQueryString(Options.AuthorizationEndpoint, queryStrings);
            return authorizationEndpoint;
        }

        /// <summary>	Adds a query string. </summary>
        /// <param name="queryStrings">	The query strings. </param>
        /// <param name="properties">  	The properties. </param>
        /// <param name="name">		   	The name. </param>
        /// <param name="defaultValue">	(Optional) The default value. </param>
        private static void AddQueryString(
            IDictionary<string, string> queryStrings,
            AuthenticationProperties properties,
            string name,
            string defaultValue = null)
        {
            if (!properties.Items.TryGetValue(name, out var value))
                value = defaultValue;
            else
                properties.Items.Remove(name);

            if (value == null)
                return;

            queryStrings[name] = value;
        }

        /// <summary>	Creates ticket asynchronous. </summary>
        /// <exception cref="HttpRequestException"> Thrown when a HTTP Request error condition occurs. </exception>
        /// <param name="identity">  	The identity. </param>
        /// <param name="properties">	The properties. </param>
        /// <param name="tokens">	 	The tokens. </param>
        /// <returns>	The new ticket asynchronous. </returns>
        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity,
            AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            // construct endpoint-address
            var endpoint =
                QueryHelpers.AddQueryString(Options.UserInformationEndpoint, "access_token", tokens.AccessToken);

            // query endpoint
            var response = await Backchannel.GetAsync(endpoint, Context.RequestAborted);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(
                    $"An error occurred when retrieving Facebook user information ({response.StatusCode}). Please check if the authentication information is correct and the corresponding Facebook Graph API is enabled.");

            // parse endpoint-response
            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
            var user = JsonConvert.DeserializeObject<AmazonUser>(await response.Content.ReadAsStringAsync());

            // parse Amazon-content manually
            var identifier = user.UserId;
            if (!string.IsNullOrEmpty(identifier))
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String,
                    Options.ClaimsIssuer));

            var name = user.Name;
            if (!string.IsNullOrEmpty(name))
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));

            var email = user.EMail;
            if (!string.IsNullOrEmpty(email))
                identity.AddClaim(new Claim(ClaimTypes.Email, email, ClaimValueTypes.String, Options.ClaimsIssuer));

            var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), properties, Context, Scheme,
                Options, Backchannel, tokens, payload);
            context.RunClaimActions();

            await Events.CreatingTicket(context);

            return new AuthenticationTicket(context.Principal, context.Properties, Scheme.Name);
        }
    }
}