using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A reset password resource. </summary>
    [LocalizedResource]
    public class ResetPasswordResource
    {
        /// <summary>   Gets the reset password header. </summary>
        /// <value> The reset password header. </value>
        [TranslationForCulture("Passwort zurücksetzen", "de")]
        public static string ResetPasswordHeader => "Reset password";

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

        /// <summary>   Gets the confirm password place holder. </summary>
        /// <value> The confirm password place holder. </value>
        [TranslationForCulture("Passwort-Bestätigung", "de")]
        public static string ConfirmPasswordPlaceHolder => "Password confirmation";

        /// <summary>   Gets the comfirm password required. </summary>
        /// <value> The comfirm password required. </value>
        [TranslationForCulture("Passwort-Bestätigung ist ein Pflichtfeld", "de")]
        public static string ConfirmPasswordRequired => "Password confirmation is required";

        /// <summary>   Gets the submit button. </summary>
        /// <value> The submit button. </value>
        [TranslationForCulture("Absenden", "de")]
        public static string SubmitButton => "Submit";
    }
}