using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Resources
{
    /// <summary>The status code 404 resource.</summary>
    [LocalizedResource]
    public class StatusCode404Resource
    {
        /// <summary>Gets or sets the not found text.</summary>
        /// <value>The not found text.</value>
        [TranslationForCulture("Es tut mir leid, aber die angeforderte Seite konnte nicht gefunden werden. Schauen Sie doch einfach auf den anderen Seiten nach.", "de")]
        public static string NotFoundText => "I'm sorry, but the requested page could not be found. Please use the navigation to find the right page";

        /// <summary>Gets or sets the not found help.</summary>
        /// <value>The not found help.</value>
        [TranslationForCulture("Falls Sie von dieser oder einer anderen Website einen fehlerhaften Link aufgerufen haben, der zu dieser Seite führte - würde ich mich über eine kurze Mitteilung freuen. Vielen Dank im Voraus!", "de")]
        public static string NotFoundHelp => "If you came to this page using this application - please contact me to fix this issue.";

        /// <summary>Gets or sets the not found header.</summary>
        /// <value>The not found header.</value>
        [TranslationForCulture("Die Seite konnte nicht gefunden werden.", "de")]
        public static string NotFoundHeader => "The page could not be found.";
    }
}