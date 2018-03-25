using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Home
{
    /// <summary>An index resource.</summary>
    [LocalizedResource]
    public class IndexResource
    {
        [TranslationForCulture("Authentifizierungs-Service", "de")]
        public static string Header => "Authentication-Service";

        [TranslationForCulture("Diese Seite dient der Authentifizierung von Benutzern", "de")]
        public static string Description => "This page helps authenticate users";
    }
}