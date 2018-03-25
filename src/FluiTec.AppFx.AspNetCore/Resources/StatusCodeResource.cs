using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Resources
{
    [LocalizedResource]
    public class StatusCodeResource
    {
        /// <summary>Gets or sets the error.</summary>
        /// <value>The error.</value>
        [TranslationForCulture("Fehler", "de")]
        public static string Error => "Error";
    }
}