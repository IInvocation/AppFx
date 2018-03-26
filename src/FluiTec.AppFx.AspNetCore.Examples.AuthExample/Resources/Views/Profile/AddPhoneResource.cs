using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Profile
{
    /// <summary>An add phone resource.</summary>
    [LocalizedResource]
    public class AddPhoneResource
    {
        /// <summary>Gets or sets the phone header.</summary>
        /// <value>The phone header.</value>
        [TranslationForCulture("Telefonnummer", "de")]
        public static string PhoneHeader => "Phone number";

        /// <summary>Gets or sets the change phone header.</summary>
        /// <value>The change phone header.</value>
        [TranslationForCulture("Telefonnummer ändern", "de")]
        public static string ChangePhoneHeader => "Change phone number";

        /// <summary>   Gets the phone place holder. </summary>
        /// <value> The phone place holder. </value>
        [TranslationForCulture("Telefon", "de")]
        public static string PhonePlaceHolder => "Phone";

        /// <summary>   Gets the phone required. </summary>
        /// <value> The phone required. </value>
        [TranslationForCulture("Telefon ist ein Pflichtfeld", "de")]
        public static string PhoneRequired => "Phone is required";

        /// <summary>Gets or sets the submit button.</summary>
        /// <value>The submit button.</value>
        [TranslationForCulture("Absenden", "de")]
        public static string SubmitButton => "Submit";
    }
}