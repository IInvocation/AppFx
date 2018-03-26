using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>A login resource.</summary>
    [LocalizedResource]
    public class LoginResource
    {
        /// <summary>Gets or sets the login header.</summary>
        /// <value>The login header.</value>
        [TranslationForCulture("Login", "de")]
        public static string LoginHeader => "Login";

        /// <summary>The local account header.</summary>
        [TranslationForCulture("Lokale Anmeldung", "de")]
        public static string LocalAccountHeader = "Local login";

        /// <summary>Gets or sets the email place holder.</summary>
        /// <value>The email place holder.</value>
        [TranslationForCulture("Email", "de")]
        public static string EmailPlaceHolder => "Mail";

        /// <summary>Gets or sets the email required.</summary>
        /// <value>The email required.</value>
        [TranslationForCulture("E-Mail ist ein Pflichtfeld", "de")]
        public static string EmailRequired => "Mail is required";

        /// <summary>Gets or sets the password placeholder.</summary>
        /// <value>The password placeholder.</value>
        [TranslationForCulture("Passwort", "de")]
        public static string PasswordPlaceholder => "Password";

        /// <summary>Gets or sets the password required.</summary>
        /// <value>The password required.</value>
        [TranslationForCulture("Passwort ist ein Pflichtfeld", "de")]
        public static string PasswordRequired => "Password is required";

        /// <summary>   Gets the login button. </summary>
        /// <value> The login button. </value>
        [TranslationForCulture("Login", "de")]
        public static string LoginButton => "Login";

        /// <summary>   Gets the reset button. </summary>
        /// <value> The reset button. </value>
        [TranslationForCulture("Zurücksetzen", "de")]
        public static string ResetButton => "Reset";
    }
}