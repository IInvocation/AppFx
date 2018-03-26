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

        /// <summary>   Gets the register link. </summary>
        /// <value> The register link. </value>
        [TranslationForCulture("Registrieren", "de")]
        public static string RegisterLink => "Register";

        /// <summary>   Gets the forgot password link. </summary>
        /// <value> The forgot password link. </value>
        [TranslationForCulture("Passwort vergessen", "de")]
        public static string ForgotPasswordLink => "Forgot password";

        /// <summary>   Gets the confirm email again link. </summary>
        /// <value> The confirm email again link. </value>
        [TranslationForCulture("E-Mail erneut bestätigen", "de")]
        public static string ConfirmEmailAgainLink => "Confirm mail again";
    }
}