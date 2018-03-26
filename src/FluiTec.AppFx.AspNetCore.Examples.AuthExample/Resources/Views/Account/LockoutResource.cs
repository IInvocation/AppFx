using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A lockout resource. </summary>
    [LocalizedResource]
    public class LockoutResource
    {
        /// <summary>   Gets the lockout header. </summary>
        /// <value> The lockout header. </value>
        [TranslationForCulture("Account ist gesperrt", "de")]
        public static string LockoutHeader => "Account is locked";

        /// <summary>   Gets the lockout message 1. </summary>
        /// <value> The lockout message 1. </value>
        [TranslationForCulture("Dieser Account ist derzeit gesperrt. Bitte kontaktieren Sie uns per Mail, wenn Sie hierzu Rückfragen haben.", "de")]
        public static string LockoutMessage1 => "Your account is current locket out. Please contact us by mail if you have questions about this.";

        /// <summary>   Gets the lockout message 2. </summary>
        /// <value> The lockout message 2. </value>
        [TranslationForCulture("Der Account ist gesperrt bis:", "de")]
        public static string LockoutMessage2 => "Your account will be locked till:";
    }
}