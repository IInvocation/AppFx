using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A register resource. </summary>
    [LocalizedResource]
    public class RegisterResource
    {
        /// <summary>   Gets the register header. </summary>
        /// <value> The register header. </value>
        [TranslationForCulture("Registrieren", "de")]
        public static string RegisterHeader => "Register";

        [TranslationForCulture("Lokales Konto erstellen", "de")]
        public static string LocalAccountHeader => "Create local account";

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

        /// <summary>Gets or sets the password placeholder.</summary>
        /// <value>The password placeholder.</value>
        [TranslationForCulture("Passwort", "de")]
        public static string PasswordPlaceholder => "Password";

        /// <summary>Gets or sets the password required.</summary>
        /// <value>The password required.</value>
        [TranslationForCulture("Passwort ist ein Pflichtfeld", "de")]
        public static string PasswordRequired => "Password is required";

        /// <summary>   Gets the phone place holder. </summary>
        /// <value> The phone place holder. </value>
        [TranslationForCulture("Telefon", "de")]
        public static string PhonePlaceHolder => "Phone";

        /// <summary>   Gets the phone required. </summary>
        /// <value> The phone required. </value>
        [TranslationForCulture("Telefon ist ein Pflichtfeld", "de")]
        public static string PhoneRequired => "Phone is required";

        /// <summary>   Gets the confirm password place holder. </summary>
        /// <value> The confirm password place holder. </value>
        [TranslationForCulture("Passwort-Bestätigung", "de")]
        public static string ConfirmPasswordPlaceHolder => "Password confirmation";

        /// <summary>   Gets the comfirm password required. </summary>
        /// <value> The comfirm password required. </value>
        [TranslationForCulture("Passwort-Bestätigung ist ein Pflichtfeld", "de")]
        public static string ConfirmPasswordRequired => "Password confirmation is required";

        /// <summary>   Gets the register button. </summary>
        /// <value> The register button. </value>
        [TranslationForCulture("Registrieren", "de")]
        public static string RegisterButton => "Register";

        /// <summary>   Gets the reset button. </summary>
        /// <value> The reset button. </value>
        [TranslationForCulture("Zurücksetzen", "de")]
        public static string ResetButton => "Reset";
    }
}