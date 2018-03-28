using System;
using FluiTec.AppFx.Authentication.Amazon;
using Microsoft.AspNetCore.Authentication;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>	An amazon extension. </summary>
    public static class AmazonAuthenticationOptionsExtensions
    {
        /// <summary>	An AuthenticationBuilder extension method that adds an amazon. </summary>
        /// <param name="builder">	The builder to act on. </param>
        /// <returns>	An AuthenticationBuilder. </returns>
        public static AuthenticationBuilder AddAmazon(this AuthenticationBuilder builder)
        {
            return builder.AddAmazon(AmazonDefaults.AuthenticationScheme, _ => { });
        }

        /// <summary>
        ///     An AuthenticationBuilder extension method that adds an amazon to 'configureOptions'.
        /// </summary>
        /// <param name="builder">		   	The builder to act on. </param>
        /// <param name="configureOptions">	Options for controlling the configure. </param>
        /// <returns>	An AuthenticationBuilder. </returns>
        public static AuthenticationBuilder AddAmazon(this AuthenticationBuilder builder,
            Action<AmazonOptions> configureOptions)
        {
            return builder.AddAmazon(AmazonDefaults.AuthenticationScheme, configureOptions);
        }

        /// <summary>	An AuthenticationBuilder extension method that adds an amazon. </summary>
        /// <param name="builder">			   	The builder to act on. </param>
        /// <param name="authenticationScheme">	The authentication scheme. </param>
        /// <param name="configureOptions">	   	Options for controlling the configure. </param>
        /// <returns>	An AuthenticationBuilder. </returns>
        public static AuthenticationBuilder AddAmazon(this AuthenticationBuilder builder, string authenticationScheme,
            Action<AmazonOptions> configureOptions)
        {
            return builder.AddAmazon(authenticationScheme, AmazonDefaults.DisplayName, configureOptions);
        }

        /// <summary>	An AuthenticationBuilder extension method that adds an amazon. </summary>
        /// <param name="builder">			   	The builder to act on. </param>
        /// <param name="authenticationScheme">	The authentication scheme. </param>
        /// <param name="displayName">		   	Name of the display. </param>
        /// <param name="configureOptions">	   	Options for controlling the configure. </param>
        /// <returns>	An AuthenticationBuilder. </returns>
        public static AuthenticationBuilder AddAmazon(this AuthenticationBuilder builder, string authenticationScheme,
            string displayName, Action<AmazonOptions> configureOptions)
        {
            return builder.AddOAuth<AmazonOptions, AmazonHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}