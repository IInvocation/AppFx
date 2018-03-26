using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A confirm email resource. </summary>
    [LocalizedResource]
    public class ConfirmEmailResource
    {
        /// <summary>   Gets the confirmed header. </summary>
        /// <value> The confirmed header. </value>
        [TranslationForCulture("Account bestätigt", "de")]
        public static string ConfirmedHeader => "Account confirmed";

        /// <summary>   Gets the confirmed text. </summary>
        /// <value> The confirmed text. </value>
        [TranslationForCulture("Der Account wurde bestätigt. Sie können sich nun anmelden", "de")]
        public static string ConfirmedText => "The account was confirmed. You can now login.";

        /// <summary>   Gets the login text. </summary>
        /// <value> The login text. </value>
        [TranslationForCulture("Jetzt anmelden", "de")]
        public static string LoginText => "Login now";
    }
}