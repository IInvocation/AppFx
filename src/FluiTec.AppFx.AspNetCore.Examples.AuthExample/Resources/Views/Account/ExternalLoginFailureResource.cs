using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Account
{
    /// <summary>   An external login failure resource. </summary>
    [LocalizedResource]
    public class ExternalLoginFailureResource
    {
        /// <summary>   Gets the error header. </summary>
        /// <value> The error header. </value>
        [TranslationForCulture("Login-Fehler", "de")]
        public static string ErrorHeader => "Login error";

        /// <summary>   Gets the error text. </summary>
        /// <value> The error text. </value>
        [TranslationForCulture("Leider ist bei der Kommunikation mit dem entfernten Dienst ein Fehler aufgetreten. Bitte versuchen Sie es später erneut.", "de")]
        public static string ErrorText => "Sorry - we encountered a problem communicating with the provider. Please try again later";
    }
}