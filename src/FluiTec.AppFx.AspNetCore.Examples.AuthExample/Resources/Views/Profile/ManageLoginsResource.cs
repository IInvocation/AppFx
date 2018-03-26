using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Profile
{
    /// <summary>A manage logins resource.</summary>
    [LocalizedResource]
    public class ManageLoginsResource
    {
        /// <summary>Gets or sets the external logins header.</summary>
        /// <value>The external logins header.</value>
        [TranslationForCulture("Externe Logins", "de")]
        public static string ExternalLoginsHeader => "External logins";

        /// <summary>Gets or sets the connected logins header.</summary>
        /// <value>The connected logins header.</value>
        [TranslationForCulture("Verbundene Logins", "de")]
        public static string ConnectedLoginsHeader => "Connected logins";

        /// <summary>Gets or sets the remove text.</summary>
        /// <value>The remove text.</value>
        [TranslationForCulture("{0} entfernen", "de")]
        public static string RemoveText => "remove {0}";

        /// <summary>Gets or sets the available logins.</summary>
        /// <value>The available logins.</value>
        [TranslationForCulture("Verfügbare Logins", "de")]
        public static string AvailableLogins => "Available logins";

        /// <summary>Gets or sets the add text.</summary>
        /// <value>The add text.</value>
        [TranslationForCulture("{0} hinzufügen", "de")]
        public static string AddText => "âdd {0}";
    }
}