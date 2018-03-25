using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Shared
{
    /// <summary>A head resource.</summary>
    [LocalizedResource]
    public class HeadResource
    {
        /// <summary>Gets or sets the name of the application.</summary>
        /// <value>The name of the application.</value>
        [TranslationForCulture("Auth-Beispiel", "de")]
        public static string ApplicationName => "Auth-Sample";
    }
}