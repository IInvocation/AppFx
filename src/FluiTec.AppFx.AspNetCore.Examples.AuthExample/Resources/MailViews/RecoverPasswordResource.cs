using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews
{
    /// <summary>   A recover password resource. </summary>
    [LocalizedResource]
    public class RecoverPasswordResource
    {
        /// <summary>   Gets the subject. </summary>
        /// <value> The subject. </value>
        [TranslationForCulture("Passwort zurücksetzen", "de")]
        public static string Subject => "Recover password";

        /// <summary>   Gets the header. </summary>
        /// <value> The header. </value>
        [TranslationForCulture("Account-Management", "de")]
        public static string Header => "Account-Management";

        /// <summary>   Gets the pleae confirm text. </summary>
        /// <value> The pleae confirm text. </value>
        [TranslationForCulture("Hallo, <br/>wir haben erfahren, dass Sie ihr Passwort zurücksetzen möchten. Bitte folgen Sie dafür nachfolgendem Link:", "de")]
        public static string PleaeConfirmText => "Hello, <br />it seems you want to recover your password. If you do - please use the following link:";

        /// <summary>   Gets the confirm link text. </summary>
        /// <value> The confirm link text. </value>
        [TranslationForCulture("Passwort zurücksetzen", "de")]
        public static string ConfirmLinkText => "Recover password";

        /// <summary>   Gets the confirm email reason text. </summary>
        /// <value> The confirm email reason text. </value>
        [TranslationForCulture("Sollten Sie die Zurücksetzung Ihres Passworts nicht beauftragt haben - ignorieren Sie diese Mail bitte einfach.", "de")]
        public static string ConfirmEmailReasonText => "If you did not want to recover your password - please just ignore this message.";

        /// <summary>   Gets the thank you text. </summary>
        /// <value> The thank you text. </value>
        [TranslationForCulture("Vielen Dank.<br />Ihr Team von <a href=\"{0}\">{1}</a>.", "de")]
        public static string ThankYouText => "Tank you.<br />Your team from <a href=\"{0}\">{1}</a>.";
    }
}