using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Profile
{
    /// <summary>A change password resource.</summary>
    [LocalizedResource]
    public class ChangePasswordResource
    {
        /// <summary>Gets or sets the password header.</summary>
        /// <value>The password header.</value>
        [TranslationForCulture("Passwort", "de")]
        public static string PasswordHeader => "Password";

        /// <summary>Gets or sets the change password header.</summary>
        /// <value>The change password header.</value>
        [TranslationForCulture("Passwort ändern", "de")]
        public static string ChangePasswordHeader => "Change password";

        /// <summary>Gets or sets the old password place holder.</summary>
        /// <value>The old password place holder.</value>
        [TranslationForCulture("Altes Passwort", "de")]
        public static string OldPasswordPlaceHolder => "Old password";

        /// <summary>Gets or sets the old password required.</summary>
        /// <value>The old password required.</value>
        [TranslationForCulture("Altes Passwort ist ein Pflichtfeld", "de")]
        public static string OldPasswordRequired => "Old password is required";

        /// <summary>Gets or sets the new password place holder.</summary>
        /// <value>The new password place holder.</value>
        [TranslationForCulture("Neues Password", "de")]
        public static string NewPasswordPlaceHolder => "New password";

        /// <summary>Gets or sets the new password required.</summary>
        /// <value>The new password required.</value>
        [TranslationForCulture("Neues Passwortist ein Pflichtfeld", "de")]
        public static string NewPasswordRequired => "New password is required";

        /// <summary>   Gets the confirm password place holder. </summary>
        /// <value> The confirm password place holder. </value>
        [TranslationForCulture("Passwort-Bestätigung", "de")]
        public static string ConfirmPasswordPlaceHolder => "Password confirmation";

        /// <summary>   Gets the comfirm password required. </summary>
        /// <value> The comfirm password required. </value>
        [TranslationForCulture("Passwort-Bestätigung ist ein Pflichtfeld", "de")]
        public static string ConfirmPasswordRequired => "Password confirmation is required";

        /// <summary>Gets or sets the submit button.</summary>
        /// <value>The submit button.</value>
        [TranslationForCulture("Absenden", "de")]
        public static string SubmitButton => "Submit";

        /// <summary>Gets or sets the reset button.</summary>
        /// <value>The reset button.</value>
        [TranslationForCulture("Zurücksetzen", "de")]
        public static string ResetButton => "Reset";
    }
}