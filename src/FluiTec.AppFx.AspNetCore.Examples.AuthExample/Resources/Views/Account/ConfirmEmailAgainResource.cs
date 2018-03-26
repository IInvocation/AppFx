using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   A confirm email again resource. </summary>
    [LocalizedResource]
    public class ConfirmEmailAgainResource
    {
        /// <summary>   Gets the confirm header. </summary>
        /// <value> The confirm header. </value>
        [TranslationForCulture("Account bestätigen", "de")]
        public static string ConfirmHeader => "Confirm account";

        /// <summary>Gets or sets the email place holder.</summary>
        /// <value>The email place holder.</value>
        [TranslationForCulture("Email", "de")]
        public static string EmailPlaceHolder => "Mail";

        /// <summary>Gets or sets the email required.</summary>
        /// <value>The email required.</value>
        [TranslationForCulture("E-Mail ist ein Pflichtfeld", "de")]
        public static string EmailRequired => "Mail is required";

        /// <summary>   Gets the submit button. </summary>
        /// <value> The submit button. </value>
        [TranslationForCulture("Abschicken", "de")]
        public static string SubmitButton => "Submit";
    }
}