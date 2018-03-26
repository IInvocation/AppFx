using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A forgot password resource. </summary>
    [LocalizedResource]
    public class ForgotPasswordResource
    {
        /// <summary>   Gets the forgot header. </summary>
        /// <value> The forgot header. </value>
        [TranslationForCulture("Passwort vergessen?", "de")]
        public static string ForgotHeader => "Forgot your password?";

        /// <summary>   Gets the recover header. </summary>
        /// <value> The recover header. </value>
        [TranslationForCulture("Passwort zurücksetzen", "de")]
        public static string RecoverHeader => "Recover your password";

        /// <summary>Gets or sets the email place holder.</summary>
        /// <value>The email place holder.</value>
        [TranslationForCulture("Email", "de")]
        public static string EmailPlaceHolder => "Mail";

        /// <summary>Gets or sets the email required.</summary>
        /// <value>The email required.</value>
        [TranslationForCulture("E-Mail ist ein Pflichtfeld", "de")]
        public static string EmailRequired => "Mail is required";

        /// <summary>   Gets the submit button. </summary>
        /// <value> The submit button. </value>
        [TranslationForCulture("Absenden", "de")]
        public static string SubmitButton => "Submit";
    }
}