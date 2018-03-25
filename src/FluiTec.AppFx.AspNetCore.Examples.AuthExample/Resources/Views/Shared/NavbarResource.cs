using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Shared
{
    /// <summary>A navbar resource.</summary>
    [LocalizedResource]
    public class NavbarResource
    {
        /// <summary>Gets or sets the home.</summary>
        /// <value>The home.</value>
        [TranslationForCulture("Home", "de")]
        public static string Home => "Home";

        /// <summary>Gets or sets the about.</summary>
        /// <value>The about.</value>
        [TranslationForCulture("Über", "de")]
        public static string About => "About";

        /// <summary>Gets or sets the login.</summary>
        /// <value>The login.</value>
        [TranslationForCulture("Login", "de")]
        public static string Login => "Login";

        /// <summary>Gets or sets the logout.</summary>
        /// <value>The logout.</value>
        [TranslationForCulture("Abmelden", "de")]
        public static string Logout => "Logout";

        /// <summary>Gets or sets the profile.</summary>
        /// <value>The profile.</value>
        [TranslationForCulture("Profil", "de")]
        public static string Profile => "Profile";

        /// <summary>Gets or sets the admin.</summary>
        /// <value>The admin.</value>
        [TranslationForCulture("Admin", "de")]
        public static string Admin => "Admin";

        /// <summary>Gets or sets the search.</summary>
        /// <value>The search.</value>
        [TranslationForCulture("Suchen", "de")]
        public static string Search => "Search";
    }
}