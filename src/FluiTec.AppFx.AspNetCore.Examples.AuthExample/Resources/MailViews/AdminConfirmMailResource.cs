using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews
{
    /// <summary>   An admin confirm mail resource. </summary>
    [LocalizedResource]
    public class AdminConfirmMailResource
    {
        /// <summary>   Gets the subject. </summary>
        /// <value> The subject. </value>
        [TranslationForCulture("Bestätigen Sie diese E-Mail-Adresse", "de")]
        public static string Subject => "Confirm this mail-address";

        /// <summary>   Gets the header. </summary>
        /// <value> The header. </value>
        [TranslationForCulture("Account-Management", "de")]
        public static string Header => "Account-Management";

        /// <summary>   Gets the pleae confirm text. </summary>
        /// <value> The pleae confirm text. </value>
        [TranslationForCulture("Hallo, <br/><br/>bitte bestätigen Sie die E-Mail-Adresse durch das Öffnen des folgenden Links:", "de")]
        public static string PleaeConfirmText => "Hello, <br /><br />please confirm this mail-address by opening the following link:";

        /// <summary>   Gets the confirm link text. </summary>
        /// <value> The confirm link text. </value>
        [TranslationForCulture("E-Mail-Adresse bestätigen", "de")]
        public static string ConfirmLinkText => "Confirm mail-address";

        /// <summary>   Gets the confirm email reason text. </summary>
        /// <value> The confirm email reason text. </value>
        [TranslationForCulture("Sie erhalten diese Nachricht, da jemand versucht hat einen Account auf <a href=\"{0}\">{1}</a> zu erstellen und Sie der Administrator sind.", "de")]
        public static string ConfirmEmailReasonText => "You're receiving this message, as somebody tried creating an account on <a href=\"{0}\">{1}</a> and you're the designated administrator.";

        /// <summary>   Gets the thank you text. </summary>
        /// <value> The thank you text. </value>
        [TranslationForCulture("Vielen Dank. <br />Ihr Team von <a hrf=\"{0}\">{1}</a>", "de")]
        public static string ThankYouText => "Thank you for your patience.<br />Your team from <a hrf=\"{0}\">{1}</a>.";
    }
}