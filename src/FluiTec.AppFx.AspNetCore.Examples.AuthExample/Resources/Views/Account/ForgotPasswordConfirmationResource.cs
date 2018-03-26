using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A forgot password confirmation resource. </summary>
    [LocalizedResource]
    public class ForgotPasswordConfirmationResource
    {
        /// <summary>   Gets the header. </summary>
        /// <value> The header. </value>
        [TranslationForCulture("Passwort vergessen bestätigt", "de")]
        public static string Header => "Forgot password confirmed";

        /// <summary>   Gets the text. </summary>
        /// <value> The text. </value>
        [TranslationForCulture("Die Aufforderung zur Zurücksetzung des Passworts wurde per Mail versandt.", "de")]
        public static string Text => "The password-recovery mail was sent to the given mail-address.";
    }
}