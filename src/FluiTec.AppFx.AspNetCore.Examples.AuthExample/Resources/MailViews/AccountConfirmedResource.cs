using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews
{
    /// <summary>   An account confirmed resource. </summary>
    [LocalizedResource]
    public class AccountConfirmedResource
    {
        /// <summary>   Gets the confirmed text. </summary>
        /// <value> The confirmed text. </value>
        [TranslationForCulture("Ihr Account wurde von einem Administrator bestätigt.", "de")]
        public static string ConfirmedText => "You account has been confirmed by an administrator.";

        [TranslationForCulture("Sie können sich nun unter <a href=\"{0}\">{1}</a> anmelden.", "de")]
        public static string LoginText => "You can now login to <a href=\"{0}\">{1}</a>.";
    }
}