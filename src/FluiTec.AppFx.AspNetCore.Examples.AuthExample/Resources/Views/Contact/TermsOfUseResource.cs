using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Contact
{
    /// <summary>The terms of use resource.</summary>
    [LocalizedResource]
    public class TermsOfUseResource
    {
        /// <summary>Gets or sets the terms of use header.</summary>
        /// <value>The terms of use header.</value>
        [TranslationForCulture("Nutzungsbedingungen", "de")]
        public static string TermsOfUseHeader => "Terms of use";

        /// <summary>Gets or sets the entitled users header.</summary>
        /// <value>The entitled users header.</value>
        [TranslationForCulture("Berechtigte Nutzer", "de")]
        public static string EntitledUsersHeader => "Entitled users";

        /// <summary>Gets or sets the users text 1.</summary>
        /// <value>The users text 1.</value>
        [TranslationForCulture("Diese Homepage ist nur für die Verwendung eines eingeschränkten Kreises von Nutzern und Programmen gemacht.", "de")]
        public static string UsersText1 => "This application was designed for a small, restricted group of users.";

        /// <summary>Gets or sets the users text 2.</summary>
        /// <value>The users text 2.</value>
        [TranslationForCulture("Sollten Sie keine Einladung erhalten haben, möchten wir Sie bitten die Homepage zu verlassen.", "de")]
        public static string UsersText2 => "If you did not get an invitation to use this homepage - please leave.";

        /// <summary>Gets or sets the users text 3.</summary>
        /// <value>The users text 3.</value>
        [TranslationForCulture("Aussperrung, Sperrung, Löschung", "de")]
        public static string UsersText3 => "Lockout, complete lock, deletion";

        /// <summary>Gets or sets the users text 4.</summary>
        /// <value>The users text 4.</value>
        [TranslationForCulture("Wir behalten uns vor Ihren Account für eine bestimmte Zeit auszusperren, komplett zu sperren oder zu löschen. (Dies geschieht zum Teil automatisch)", "de")]
        public static string UsersText4 => "We reserve ourselves to right to block your account completely or for some time as well as the right to completely delete it. (This happens partially automatic";
    }
}