using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Home
{
    /// <summary>An about resource.</summary>
    [LocalizedResource]
    public class AboutResource
    {
        /// <summary>Gets or sets the header.</summary>
        /// <value>The header.</value>
        [TranslationForCulture("Über", "de")]
        public static string Header => "About";

        /// <summary>Gets or sets the funcionality.</summary>
        /// <value>The funcionality.</value>
        [TranslationForCulture("Funktion", "de")]
        public static string FuncionalityHeader => "Functionality";

        /// <summary>Gets or sets information describing the funcionality.</summary>
        /// <value>Information describing the funcionality.</value>
        [TranslationForCulture("Diese Homepage dient einzig der Authentifizierung von Nutzern anderer Webanwendungen.", "de")]
        public static string FuncionalityDescription => "This homepage servers the purpose of identifying users of different web-applications.";

        /// <summary>Gets or sets the feature header.</summary>
        /// <value>The feature header.</value>
        [TranslationForCulture("Features", "de")]
        public static string FeatureHeader => "Features";

        /// <summary>Gets or sets information describing the feature.</summary>
        /// <value>Information describing the feature.</value>
        [TranslationForCulture("Angeboten wird OpenIdConnect für externe Anwendungen in folgenden Modi (samt Refresh-Token):", "de")]
        public static string FeatureDescription => "We offer OpenIdConnect for external applications covering the following modes (including Refresh-Token):";

        /// <summary>Gets or sets the hybrid mode.</summary>
        /// <value>The hybrid mode.</value>
        [TranslationForCulture("Hybrid", "de")]
        public static string HybridMode => "hybrid";

        /// <summary>Gets or sets the client credentials mode.</summary>
        /// <value>The client credentials mode.</value>
        [TranslationForCulture("Client-Anmeldedaten", "de")]
        public static string ClientCredentialsMode => "client-credentials";

        /// <summary>Gets or sets the user credentials mode.</summary>
        /// <value>The user credentials mode.</value>
        [TranslationForCulture("Benutzer-Anmeldedaten", "de")]
        public static string UserCredentialsMode => "user-credentials";

        /// <summary>Gets or sets the external services header.</summary>
        /// <value>The external services header.</value>
        [TranslationForCulture("Externe Anmeldedienste", "de")]
        public static string ExternalServicesHeader => "External services";

        /// <summary>Gets or sets information describing the external services.</summary>
        /// <value>Information describing the external services.</value>
        [TranslationForCulture("Sie können die folgenden Dienste verwenden um Ihr Passwort nicht eingeben zu müssen:", "de")]
        public static string ExternalServicesDescription => "You can use the following, external services in order to not give us your password:";

        /// <summary>Gets or sets the google service.</summary>
        /// <value>The google service.</value>
        [TranslationForCulture("Google", "de")]
        public static string GoogleService => "Google";

        /// <summary>Gets or sets the amazon service.</summary>
        /// <value>The amazon service.</value>
        [TranslationForCulture("Amazon", "de")]
        public static string AmazonService => "Service";
    }
}