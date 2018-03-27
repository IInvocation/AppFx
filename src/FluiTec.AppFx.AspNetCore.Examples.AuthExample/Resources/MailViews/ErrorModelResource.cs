using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews
{
    /// <summary>   An error model resource. </summary>
    [LocalizedResource]
    public class ErrorModelResource
    {
        /// <summary>   Gets the subject. </summary>
        /// <value> The subject. </value>
        [TranslationForCulture("Auth-Beispiel Fehler", "de")]
        public static string Subject => "Auth-Sample Error";

        /// <summary>   Gets the header. </summary>
        /// <value> The header. </value>
        [TranslationForCulture("Unbekannter Fehler", "de")]
        public static string Header => "Unknown error";

        /// <summary>   Gets the exception pre text. </summary>
        /// <value> The exception pre text. </value>
        [TranslationForCulture("Es ist ein Fehler aufgetreten. Details:", "de")]
        public static string ExceptionPreText => "An unexpected exception occured, details:";
    }
}