using DbLocalizationProvider;
using DbLocalizationProvider.Abstractions;

namespace WebApplication1.Resources
{
    /// <summary>A controller resource.</summary>
    [LocalizedResource]
    public class ControllerResource
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [TranslationForCulture("ControllerResource|NameNew", "de-DE")]
        public static string Name => "ControllerResource|NameNew"; // this counts for "invariant" and "en"
    }
}