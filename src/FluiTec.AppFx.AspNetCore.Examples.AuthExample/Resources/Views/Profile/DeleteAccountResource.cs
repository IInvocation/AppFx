using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Profile
{
    /// <summary>A delete account resource.</summary>
    [LocalizedResource]
    public class DeleteAccountResource
    {
        /// <summary>Gets or sets the account header.</summary>
        /// <value>The account header.</value>
        [TranslationForCulture("Account", "de")]
        public static string AccountHeader => "Account";

        /// <summary>Gets or sets the delete account header.</summary>
        /// <value>The delete account header.</value>
        [TranslationForCulture("Account löschen", "de")]
        public static string DeleteAccountHeader => "Delete account";

        /// <summary>Gets or sets the are you sure text.</summary>
        /// <value>The are you sure text.</value>
        [TranslationForCulture("Sind Sie sicher, dass Sie ihren Account löschen möchten?", "de")]
        public static string AreYouSureText => "Are you sure you want to delete your account?";

        /// <summary>Gets or sets the confirm button.</summary>
        /// <value>The confirm button.</value>
        [TranslationForCulture("Ja, bin ich", "de")]
        public static string ConfirmButton => "Yes, i am";
    }
}