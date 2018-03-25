using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Shared
{
    /// <summary>An error resource.</summary>
    [LocalizedResource]
    public class ErrorResource
    {
        /// <summary>Gets or sets the unknown error header.</summary>
        /// <value>The unknown error header.</value>
        [TranslationForCulture("Unbekannter Fehler", "de")]
        public static string UnknownErrorHeader => "Unknown Error";

        /// <summary>Gets or sets the unknown error header 2.</summary>
        /// <value>The unknown error header 2.</value>
        [TranslationForCulture("Unbekannter Fehler", "de")]
        public static string UnknownErrorHeader2 => "Unknown Error";

        /// <summary>Gets or sets the unknown error text.</summary>
        /// <value>The unknown error text.</value>
        [TranslationForCulture("Leider ist ein unbekannter Fehler aufgetreten. Der Service wurde bereits über den Fehler informiert.", "de")]
        public static string UnknownErrorText => "We've encountered an unknown error. The service will fix this this as soon as possible.";

        /// <summary>Gets or sets the unknown error help text.</summary>
        /// <value>The unknown error help text.</value>
        [TranslationForCulture("In der Zwischenzeit können Sie versuchen, ob Sie mit anderen Eingaben weiter kommen.", "de")]
        public static string UnknownErrorHelpText => "In the meantime - please try again with different input.";
    }
}