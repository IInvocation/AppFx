using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   An external login confirmation resource. </summary>
    [LocalizedResource]
    public class ExternalLoginConfirmationResource
    {
        /// <summary>   Gets the external registration header. </summary>
        /// <value> The external registration header. </value>
        [TranslationForCulture("Externe Registrierung", "de")]
        public static string ExternalRegistrationHeader => "External registration";

        /// <summary>   Gets the local information header. </summary>
        /// <value> The local information header. </value>
        [TranslationForCulture("Lokal benötigte Informationen", "de")]
        public static string LocalInformationHeader => "Local needed user-info";

        /// <summary>Gets or sets the email place holder.</summary>
        /// <value>The email place holder.</value>
        [TranslationForCulture("Email", "de")]
        public static string EmailPlaceHolder => "Mail";

        /// <summary>Gets or sets the email required.</summary>
        /// <value>The email required.</value>
        [TranslationForCulture("E-Mail ist ein Pflichtfeld", "de")]
        public static string EmailRequired => "Mail is required";

        /// <summary>   Gets the name place holder. </summary>
        /// <value> The name place holder. </value>
        [TranslationForCulture("Name", "de")]
        public static string NamePlaceHolder => "Name";

        /// <summary>   Gets the name required. </summary>
        /// <value> The name required. </value>
        [TranslationForCulture("Name ist ein Pflichtfeld", "de")]
        public static string NameRequired => "Name is required";

        /// <summary>   Gets the phone place holder. </summary>
        /// <value> The phone place holder. </value>
        [TranslationForCulture("Telefon", "de")]
        public static string PhonePlaceHolder => "Phone";

        /// <summary>   Gets the phone required. </summary>
        /// <value> The phone required. </value>
        [TranslationForCulture("Telefon ist ein Pflichtfeld", "de")]
        public static string PhoneRequired => "Phone is required";

        /// <summary>   Gets the register button. </summary>
        /// <value> The register button. </value>
        [TranslationForCulture("Registrieren", "de")]
        public static string RegisterButton => "Register";

        /// <summary>   Gets the reset button. </summary>
        /// <value> The reset button. </value>
        [TranslationForCulture("Registrieren", "de")]
        public static string ResetButton => "Reset";
    }
}