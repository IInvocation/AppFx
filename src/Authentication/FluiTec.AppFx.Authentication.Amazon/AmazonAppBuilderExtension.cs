using System;
using Microsoft.AspNetCore.Builder;

namespace FluiTec.AppFx.Authentication.Amazon
{
    /// <summary>	An amazon application builder extension. </summary>
    public static class AmazonAppBuilderExtension
    {
        /// <summary>
        ///     An IApplicationBuilder extension method that use amazon authentication.
        /// </summary>
        /// <param name="app">	The app to act on. </param>
        /// <returns>	An IApplicationBuilder. </returns>
        [Obsolete(
            "UseAmazonAuthentication is obsolete. Configure Amazon authentication with AddAuthentication().AddAmazon in ConfigureServices. See https://go.microsoft.com/fwlink/?linkid=845470 for more details.",
            true)]
        public static IApplicationBuilder UseAmazonAuthentication(this IApplicationBuilder app)
        {
            throw new NotSupportedException(
                "This method is no longer supported, see https://go.microsoft.com/fwlink/?linkid=845470");
        }

        /// <summary>
        ///     An IApplicationBuilder extension method that use google authentication.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="app">	  	The app to act on. </param>
        /// <param name="options">	Options for controlling the operation. </param>
        /// <returns>	An IApplicationBuilder. </returns>
        [Obsolete(
            "UseAmazonAuthentication is obsolete. Configure Amazon authentication with AddAuthentication().AddAmazon in ConfigureServices. See https://go.microsoft.com/fwlink/?linkid=845470 for more details.",
            true)]
        public static IApplicationBuilder UseAmazonAuthentication(this IApplicationBuilder app, AmazonOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            throw new NotSupportedException(
                "This method is no longer supported, see https://go.microsoft.com/fwlink/?linkid=845470");
        }
    }
}