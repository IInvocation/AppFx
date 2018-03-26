using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Profile
{
    /// <summary>An index resource.</summary>
    [LocalizedResource]
    public class IndexResource
    {
        /// <summary>Gets or sets the profile header.</summary>
        /// <value>The profile header.</value>
        [TranslationForCulture("Profil", "de")]
        public static string ProfileHeader => "Profile";

        /// <summary>Gets or sets the change settings header.</summary>
        /// <value>The change settings header.</value>
        [TranslationForCulture("Einstellungen ändern", "de")]
        public static string ChangeSettingsHeader => "Change settings";

        /// <summary>Gets or sets the status header.</summary>
        /// <value>The status header.</value>
        [TranslationForCulture("Status", "de")]
        public static string StatusHeader => "State";

        /// <summary>Gets or sets the account header.</summary>
        /// <value>The account header.</value>
        [TranslationForCulture("Account", "de")]
        public static string AccountHeader => "Account";

        /// <summary>Gets or sets the delete account link.</summary>
        /// <value>The delete account link.</value>
        [TranslationForCulture("Account löschen", "de")]
        public static string DeleteAccountLink => "Delete account";

        /// <summary>Gets or sets the password header.</summary>
        /// <value>The password header.</value>
        [TranslationForCulture("Passwort", "de")]
        public static string PasswordHeader => "Password";

        /// <summary>Gets or sets the change password link.</summary>
        /// <value>The change password link.</value>
        [TranslationForCulture("Passwort ändern", "de")]
        public static string ChangePasswordLink => "Change password";

        /// <summary>Gets or sets the external logins header.</summary>
        /// <value>The external logins header.</value>
        [TranslationForCulture("Externe Logins", "de")]
        public static string ExternalLoginsHeader => "External logins";

        /// <summary>Gets or sets the linked accounts counter text.</summary>
        /// <value>The linked accounts counter text.</value>
        [TranslationForCulture("Verbundene Accounts: {0}", "de")]
        public static string LinkedAccountsCounterText => "Linked accounts: {0}";

        /// <summary>Gets or sets the no linked accounts text.</summary>
        /// <value>The no linked accounts text.</value>
        [TranslationForCulture("Keine externen Logins vorhanden", "de")]
        public static string NoLinkedAccountsText => "No external logins set up";

        /// <summary>Gets or sets the manage external logins text.</summary>
        /// <value>The manage external logins text.</value>
        [TranslationForCulture("Externe Logins verwalten", "de")]
        public static string ManageExternalLoginsText => "Manage external logins";

        /// <summary>Gets or sets the phone header.</summary>
        /// <value>The phone header.</value>
        [TranslationForCulture("Telefon", "de")]
        public static string PhoneHeader => "Phone";

        /// <summary>Gets or sets the change phone link.</summary>
        /// <value>The change phone link.</value>
        [TranslationForCulture("Telefonnummer ändern", "de")]
        public static string ChangePhoneLink => "Change phone";
    }
}