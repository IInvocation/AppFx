using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Shared
{
    /// <summary>An external login resource.</summary>
    [LocalizedResource]
    public class ExternalLoginResource
    {
        /// <summary>Gets or sets information describing the external login.</summary>
        /// <value>Information describing the external login.</value>
        [TranslationForCulture("Einen anderen Dienst zum Anmelden verwenden", "de")]
        public static string ExternalLoginDescription => "Use another service to login";

        /// <summary>Gets or sets information describing the external login provider.</summary>
        /// <value>Information describing the external login provider.</value>
        [TranslationForCulture("Mit {0} anmelden", "de")]
        public static string ExternalLoginProviderDescription => "Login with {0}";
    }
}