using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A confirm email notification resource. </summary>
    [LocalizedResource]
    public class ConfirmEmailNotificationResource
    {
        /// <summary>   Gets the confirm header. </summary>
        /// <value> The confirm header. </value>
        [TranslationForCulture("E-Mail-Bestätigung", "de")]
        public static string ConfirmHeader => "Email-confirmation";

        /// <summary>   Gets the user must confirm text. </summary>
        /// <value> The user must confirm text. </value>
        [TranslationForCulture("Um sich anzumelden und diese Anwendung verwenden zu können, bestätigen Sie bitte zuerst Ihre E-Mail-Adresse. Schauen Sie bitte in Ihrem Posteingang und/oder Spamordner nach.", "de")]
        public static string UserMustConfirmText =>
            "In order to login and use this application, you will have to confirm your mail-address. Please look into your inbox (including the spam folder).";

        /// <summary>   Gets the admin must confirm text. </summary>
        /// <value> The admin must confirm text. </value>
        [TranslationForCulture("Um sich anmelden zu können muss zuerst ein Administrator Ihren Account bestätigen. Sie erhalten in Bälde eine entsprechende Nachricht.", "de")]
        public static string AdminMustConfirmText => "In order to login, first an administrator must confirm your account. You will receive according notice shortly.";

        /// <summary>   Gets the thank you text. </summary>
        /// <value> The thank you text. </value>
        [TranslationForCulture("Vielen Dank für Ihr Entgegenkommen.", "de")]
        public static string ThankYouText => "Thanks for your patience.";
    }
}