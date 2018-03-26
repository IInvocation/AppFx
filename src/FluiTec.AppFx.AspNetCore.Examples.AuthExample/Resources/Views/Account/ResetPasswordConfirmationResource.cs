using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A reset password confirmation resource. </summary>
    [LocalizedResource]
    public class ResetPasswordConfirmationResource
    {
        /// <summary>   Gets the header. </summary>
        /// <value> The header. </value>
        [TranslationForCulture("Passwort geändert", "de")]
        public static string Header => "Password changed";

        /// <summary>   Gets the text. </summary>
        /// <value> The text. </value>
        [TranslationForCulture("Das Passwort wurde erfolgreich geändert.", "de")]
        public static string Text => "The password was changed successfully.";
    }
}