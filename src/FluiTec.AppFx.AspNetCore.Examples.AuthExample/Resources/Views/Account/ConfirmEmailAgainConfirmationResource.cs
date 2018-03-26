using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A confirm email again confirmation resource. </summary>
    [LocalizedResource]
    public class ConfirmEmailAgainConfirmationResource
    {
        /// <summary>   Gets the confirmation header. </summary>
        /// <value> The confirmation header. </value>
        [TranslationForCulture("Account bestätigen", "de")]
        public static string ConfirmationHeader => "Confirm account";

        /// <summary>   Gets the confirmation text. </summary>
        /// <value> The confirmation text. </value>
        [TranslationForCulture("Die Aufforderung zur E-Mail-Bestätigung wurde erneut versandt.", "de")]
        public static string ConfirmationText => "The email to confirm your account has been sent again.";
    }
}