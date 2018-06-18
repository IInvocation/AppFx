using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using FluiTec.AppFx.OpenId;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class OpenIdConnectExtension
    {
        /// <summary>An IServiceCollection extension method that configure open identifier connect.</summary>
        /// <param name="services">         The services to act on. </param>
        /// <param name="configuration">    The configuration. </param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureOpenIdConnect(this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var settings = configuration.GetConfiguration<OpenIdConnectOptions>();
            services.AddSingleton(settings);
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    // defines what will be used after we completed the challenge
                    options.SignInScheme = settings.SignInScheme;

                    // setup endpoint
                    options.Authority = settings.Authority;
                    options.RequireHttpsMetadata = settings.RequireHttpsMetadata;

                    // init credentials
                    options.ClientId = settings.ClientId;
                    options.ClientSecret = settings.ClientSecret;
                    options.ResponseType = settings.ResponseType;

                    // define behavior
                    options.SaveTokens = settings.SaveTokens;
                    options.GetClaimsFromUserInfoEndpoint = settings.GetClaimsFromUserInfoEndpoint;

                    // add scopes
                    if (settings.Scopes == null || !settings.Scopes.Any()) return;
                    foreach(var scope in settings.Scopes)
                        options.Scope.Add(scope);
                });

            return services;
        }
    }
}
